using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.Bond;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;
using Core.Security;

namespace Core.Controllers.CashOfficeWorkList
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class CashOfficeWorkListApiController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Vezne_Islemleri, TTRoleNames.Senet_Islemleri)]
        public CashOfficeWorkListFormViewModel PrepareNewCashOfficeWorkListForm()
        {
            CashOfficeWorkListSearchModel searchModel = new CashOfficeWorkListSearchModel();
            CashOfficeWorkListFormViewModel formViewModel = new CashOfficeWorkListFormViewModel();
            TTUser currentUser = TTUser.CurrentUser;
            formViewModel.Roles.Add("MainCashOffice", currentUser.HasRole(Common.VezneTahsilatYeniRoleID));
            formViewModel.Roles.Add("BankDecountPayment", currentUser.HasRole(Common.BankaOdemeFisiYeniRoleID));
            formViewModel.Roles.Add("Bond", currentUser.HasRole(Common.SenetYeniRoleID));
            formViewModel.Roles.Add("BondPayment", currentUser.HasRole(Common.SenetTahsilatYeniRoleID));
            if (TTUser.CurrentUser.UserType == (int)UserTypeEnum.Cashier)
            {
                searchModel.CashierObjID = Common.CurrentResource.ObjectID;
                searchModel.CashOfficeID = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, Common.CurrentResource).ObjectID;
            }

            searchModel.StartDate = DateTime.Now;
            searchModel.EndDate = DateTime.Now;
            searchModel.SelectedOperationTypeListItems = new List<Guid>();
            searchModel.BondSearchModel = new BondWorkListSearchModel();
            formViewModel.CashOfficeWorkListSearchModel = searchModel;
            return formViewModel;
        }



        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Vezne_Islemleri, TTRoleNames.Senet_Islemleri)]
        public CashOfficeWorkListResultModel[] GetCashOfficeWorkList(CashOfficeWorkListSearchModel searchModel)
        {
            List<CashOfficeWorkListResultModel> cashOfficeWorkListResultList = new List<CashOfficeWorkListResultModel>();
            using (var objectContext = new TTObjectContext(true))
            {
                string filterExpression = string.Empty;
                List<EpisodeAccountAction.CashOfficeWorkListNQLNoDate_Class> episodeAccountActionListNoDate = new List<EpisodeAccountAction.CashOfficeWorkListNQLNoDate_Class>();
                List<EpisodeAccountAction.CashOfficeWorkListNQL_Class> episodeAccountActionList = new List<EpisodeAccountAction.CashOfficeWorkListNQL_Class>();
                List<AccountAction.CashOfficeWorkListNQLNoDate_Class> accountActionListNoDate = new List<AccountAction.CashOfficeWorkListNQLNoDate_Class>();
                List<AccountAction.CashOfficeWorkListNQL_Class> accountActionList = new List<AccountAction.CashOfficeWorkListNQL_Class>();
                List<BondWorkListNQL_Class> bondActionList = new List<BondWorkListNQL_Class>();
                if (searchModel.StartDate.HasValue == false)
                    searchModel.StartDate = DateTime.MinValue; //Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                else
                    searchModel.StartDate = new DateTime(searchModel.StartDate.Value.Year, searchModel.StartDate.Value.Month, searchModel.StartDate.Value.Day, 0, 0, 0);
                if (searchModel.EndDate.HasValue == false)
                    searchModel.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                else
                    searchModel.EndDate = new DateTime(searchModel.EndDate.Value.Year, searchModel.EndDate.Value.Month, searchModel.EndDate.Value.Day, 23, 59, 59);
                if (searchModel.State.HasValue)
                {
                    string state;
                    switch (searchModel.State)
                    {
                        case StateStatusEnum.CompletedSuccessfully:
                            state = "SUCCESSFUL";
                            break;
                        case StateStatusEnum.CompletedUnsuccessfully:
                            state = "UNSUCCESSFUL";
                            break;
                        case StateStatusEnum.Uncompleted:
                            state = "UNCOMPLETED";
                            break;
                        case StateStatusEnum.Cancelled:
                            state = "CANCELLED";
                            break;
                        default:
                            state = Enum.GetName(typeof(StateStatusEnum), searchModel.State).ToUpper();
                            break;
                    }

                    filterExpression = " AND CURRENTSTATE IS " + state;
                }

                string filterExpressionPatientStatus = string.Empty;
                if (searchModel.PatientStatus.HasValue)
                {
                    filterExpressionPatientStatus = " AND EPISODE.PATIENTSTATUS = " + (int)searchModel.PatientStatus.Value;
                }

                if (searchModel.SelectedOperationTypeListItems != null && searchModel.SelectedOperationTypeListItems.Count > 0)
                {
                    filterExpression += " AND OBJECTDEFID IN (";
                    foreach (Guid lbo in searchModel.SelectedOperationTypeListItems)
                    {
                        filterExpression += "'" + lbo + "',";
                    }

                    filterExpression = filterExpression.Remove(filterExpression.Length - 1, 1);
                    filterExpression = filterExpression + ")";
                }

                if (searchModel.Id.HasValue)
                {
                    episodeAccountActionListNoDate = EpisodeAccountAction.CashOfficeWorkListNQLNoDate(objectContext, "AND ID = " + searchModel.Id.ToString()).ToList();
                    accountActionListNoDate = AccountAction.CashOfficeWorkListNQLNoDate(objectContext, "AND ID = " + searchModel.Id.ToString()).ToList();
                }
                else if (!string.IsNullOrEmpty(searchModel.UniqueRefNo))
                {
                    episodeAccountActionList = EpisodeAccountAction.CashOfficeWorkListNQL(objectContext, (DateTime)searchModel.StartDate, (DateTime)searchModel.EndDate, filterExpression + filterExpressionPatientStatus + " AND EPISODE.PATIENT.UNIQUEREFNO = " + "'" + searchModel.UniqueRefNo + "'").ToList();
                }
                else if (!string.IsNullOrEmpty(searchModel.ReceiptNo))
                {
                    episodeAccountActionListNoDate = EpisodeAccountAction.CashOfficeWorkListNQLNoDate(objectContext, "AND ACCOUNTDOCUMENTS(DOCUMENTNO = '" + searchModel.ReceiptNo.ToUpper() + "').EXISTS").ToList();
                    accountActionListNoDate = AccountAction.CashOfficeWorkListNQLNoDate(objectContext, "AND ACCOUNTDOCUMENTS(DOCUMENTNO = '" + searchModel.ReceiptNo.ToUpper() + "').EXISTS").ToList();
                }
                else
                {
                    if (searchModel.CashierObjID != null && searchModel.CashierObjID != Guid.Empty)
                        filterExpression += " AND ACCOUNTDOCUMENTS.RESUSER=" + "'" + searchModel.CashierObjID + "'";
                    if (searchModel.CashOfficeID != null && searchModel.CashOfficeID != Guid.Empty)
                        filterExpression += " AND ACCOUNTDOCUMENTS.CASHOFFICE=" + "'" + searchModel.CashOfficeID + "'";
                    if (searchModel.SelectedOperationTypeListItems.Count == 0 || searchModel.SelectedOperationTypeListItems.Count > 1 || (searchModel.SelectedOperationTypeListItems.Count == 1 && !searchModel.SelectedOperationTypeListItems.FirstOrDefault().Equals(new Guid("f2beef18-02b8-455d-9346-bfee74bc507c"))))
                    {
                        episodeAccountActionList = EpisodeAccountAction.CashOfficeWorkListNQL(objectContext, (DateTime)searchModel.StartDate, (DateTime)searchModel.EndDate, filterExpression + filterExpressionPatientStatus).ToList();
                        accountActionList = AccountAction.CashOfficeWorkListNQL(objectContext, (DateTime)searchModel.StartDate, (DateTime)searchModel.EndDate, filterExpression).ToList();
                        #region Eski Borç İş Listesi
                        List<OldDebtReceiptDocument.OldDebtCashOfficeWorkListNQL_Class> oldDebts = OldDebtReceiptDocument.OldDebtCashOfficeWorkListNQL(searchModel.StartDate.Value, searchModel.EndDate.Value).ToList();
                        if (oldDebts.Count > 0)
                            foreach (OldDebtReceiptDocument.OldDebtCashOfficeWorkListNQL_Class eaa in oldDebts)
                            {
                                CashOfficeWorkListResultModel cwom = new CashOfficeWorkListResultModel();
                                cwom.ObjectID = eaa.ObjectID.Value;
                                cwom.Date = Convert.ToDateTime(eaa.Documentdate);
                                cwom.OperationType = eaa.Objdisplaytext;
                                cwom.ObjectDefName = eaa.Objname;
                                if (eaa.Documentno != null)
                                    cwom.ReceiptNo = eaa.Documentno.ToString();
                                cwom.PaymentPrice = eaa.TotalPrice;
                                cwom.PatientFullName = eaa.OldPatientNameSurname;
                                cwom.CashierName = eaa.Cashiername;
                                cwom.UniqueRefNo = eaa.UniqueRefNo.Value.ToString();
                                cashOfficeWorkListResultList.Add(cwom);
                            }
                        #endregion Eski Borç İş Listesi
                    }
                    else
                    {
                        string bondNotificationFilter = string.Empty;
                        if (searchModel.BondSearchModel.SelectedNotificationStatus.HasValue)
                        {
                            switch (searchModel.BondSearchModel.SelectedNotificationStatus)
                            {
                                case BondNotificationStatusEnum.NotifcationNotSend:
                                    bondNotificationFilter += " AND FIRSTNOTIFICATIONDATE IS NULL AND SECONDNOTIFICATIONDATE IS NULL";
                                    break;
                                case BondNotificationStatusEnum.FirstNotificationSent:
                                    bondNotificationFilter += " AND FIRSTNOTIFICATIONDATE IS NOT NULL AND SECONDNOTIFICATIONDATE IS NULL";
                                    break;
                                case BondNotificationStatusEnum.SecondNotificationSent:
                                    bondNotificationFilter += " AND SECONDNOTIFICATIONDATE IS NOT NULL";
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (!searchModel.BondSearchModel.BondDetailStartDate.HasValue || !searchModel.BondSearchModel.BondDetailEndDate.HasValue || !searchModel.BondSearchModel.BondFirstNotStartDate.HasValue || !searchModel.BondSearchModel.BondFirstNotEndDate.HasValue || !searchModel.BondSearchModel.BondSecondNotStartDate.HasValue || !searchModel.BondSearchModel.BondSecondNotEndDate.HasValue)
                            filterExpression += " AND DATE >= TODATE('" + searchModel.StartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')" + " AND DATE <= TODATE('" + searchModel.EndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        #region BondDetailDate ve vadesi geçmiş senet filtre kriterleri
                        if (searchModel.BondSearchModel.BondDetailStartDate.HasValue || searchModel.BondSearchModel.BondDetailEndDate.HasValue)
                        {
                            if (searchModel.BondSearchModel.BondDetailStartDate.HasValue)
                                searchModel.BondSearchModel.BondDetailStartDate = new DateTime(searchModel.BondSearchModel.BondDetailStartDate.Value.Year, searchModel.BondSearchModel.BondDetailStartDate.Value.Month, searchModel.BondSearchModel.BondDetailStartDate.Value.Day, 0, 0, 0);
                            else
                                searchModel.BondSearchModel.BondDetailStartDate = DateTime.MinValue;
                            if (searchModel.BondSearchModel.BondDetailEndDate.HasValue)
                                searchModel.BondSearchModel.BondDetailEndDate = new DateTime(searchModel.BondSearchModel.BondDetailEndDate.Value.Year, searchModel.BondSearchModel.BondDetailEndDate.Value.Month, searchModel.BondSearchModel.BondDetailEndDate.Value.Day, 23, 59, 59);
                            else
                                searchModel.BondSearchModel.BondDetailEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                            filterExpression += " AND CURRENTSTATE IN (STATES.UNPAID, STATES.PARTIALPAID, STATES.LEGALPROCESS)";
                            filterExpression += " AND BONDDETAILS(DATE > TODATE('" + searchModel.BondSearchModel.BondDetailStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')" + " AND DATE < TODATE('" + searchModel.BondSearchModel.BondDetailEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                            if (searchModel.BondSearchModel.BondDetailExpired)
                                filterExpression += " AND CURRENTSTATE <> STATES.PAID";
                            filterExpression += ").EXISTS";
                        }

                        #endregion
                        #region BondFirstNotification filtre kriterleri
                        if (searchModel.BondSearchModel.BondFirstNotStartDate.HasValue || searchModel.BondSearchModel.BondFirstNotEndDate.HasValue)
                        {
                            if (searchModel.BondSearchModel.BondFirstNotStartDate.HasValue)
                                searchModel.BondSearchModel.BondFirstNotStartDate = new DateTime(searchModel.BondSearchModel.BondFirstNotStartDate.Value.Year, searchModel.BondSearchModel.BondFirstNotStartDate.Value.Month, searchModel.BondSearchModel.BondFirstNotStartDate.Value.Day, 0, 0, 0);
                            else
                                searchModel.BondSearchModel.BondFirstNotStartDate = DateTime.MinValue;
                            if (searchModel.BondSearchModel.BondFirstNotEndDate.HasValue)
                                searchModel.BondSearchModel.BondFirstNotEndDate = new DateTime(searchModel.BondSearchModel.BondFirstNotEndDate.Value.Year, searchModel.BondSearchModel.BondFirstNotEndDate.Value.Month, searchModel.BondSearchModel.BondFirstNotEndDate.Value.Day, 23, 59, 59);
                            else
                                searchModel.BondSearchModel.BondFirstNotEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                            filterExpression += " AND FIRSTNOTIFICATIONDATE >= TODATE('" + searchModel.BondSearchModel.BondFirstNotStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')" + " AND FIRSTNOTIFICATIONDATE <= TODATE('" + searchModel.BondSearchModel.BondFirstNotEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        }

                        #endregion
                        #region BondSecondNotification filtre kriterleri
                        if (searchModel.BondSearchModel.BondSecondNotStartDate.HasValue || searchModel.BondSearchModel.BondSecondNotEndDate.HasValue)
                        {
                            if (searchModel.BondSearchModel.BondSecondNotStartDate.HasValue)
                                searchModel.BondSearchModel.BondSecondNotStartDate = new DateTime(searchModel.BondSearchModel.BondSecondNotStartDate.Value.Year, searchModel.BondSearchModel.BondSecondNotStartDate.Value.Month, searchModel.BondSearchModel.BondSecondNotStartDate.Value.Day, 0, 0, 0);
                            else
                                searchModel.BondSearchModel.BondSecondNotStartDate = DateTime.MinValue;
                            if (searchModel.BondSearchModel.BondSecondNotEndDate.HasValue)
                                searchModel.BondSearchModel.BondSecondNotEndDate = new DateTime(searchModel.BondSearchModel.BondSecondNotEndDate.Value.Year, searchModel.BondSearchModel.BondSecondNotEndDate.Value.Month, searchModel.BondSearchModel.BondSecondNotEndDate.Value.Day, 23, 59, 59);
                            else
                                searchModel.BondSearchModel.BondSecondNotEndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                            filterExpression += " AND SECONDNOTIFICATIONDATE >= TODATE('" + searchModel.BondSearchModel.BondSecondNotStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')" + " AND SECONDNOTIFICATIONDATE <= TODATE('" + searchModel.BondSearchModel.BondSecondNotEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        }

                        #endregion
                        if (searchModel.BondSearchModel.SelectedBondStates != null && searchModel.BondSearchModel.SelectedBondStates.Count > 0)
                        {
                            filterExpression += " AND CURRENTSTATE IN (";
                            foreach (string state in searchModel.BondSearchModel.SelectedBondStates)
                            {
                                filterExpression += "STATES." + state + ",";
                            }

                            filterExpression = filterExpression.Remove(filterExpression.Length - 1, 1);
                            filterExpression += ")";
                        }

                        bondActionList = Bond.BondWorkListNQL(objectContext, filterExpression + filterExpressionPatientStatus + bondNotificationFilter).ToList();
                    }
                }



                if (episodeAccountActionListNoDate.Count > 0)
                    foreach (EpisodeAccountAction.CashOfficeWorkListNQLNoDate_Class eaa in episodeAccountActionListNoDate)
                    {
                        CashOfficeWorkListResultModel cwom = new CashOfficeWorkListResultModel();
                        cwom.ObjectID = eaa.ObjectID.Value;
                        cwom.Date = Convert.ToDateTime(eaa.Documentdate);
                        cwom.Id = eaa.ID.ToString();
                        cwom.OperationType = eaa.Objdisplaytext;
                        cwom.ObjectDefName = eaa.Objname;
                        cwom.State = eaa.Currentstate.ToString();
                        if (eaa.Documentno != null)
                            cwom.ReceiptNo = eaa.Documentno.ToString();
                        cwom.PaymentPrice = eaa.Totalprice;
                        cwom.PatientFullName = eaa.Patientname + " " + eaa.Patientsurname;
                        cwom.CashierName = eaa.Cashiername;
                        cwom.UniqueRefNo = eaa.UniqueRefNo.Value.ToString();
                        cwom.EpisodeID = eaa.Episodeid;
                        cashOfficeWorkListResultList.Add(cwom);
                    }

                if (episodeAccountActionList.Count > 0)
                    foreach (EpisodeAccountAction.CashOfficeWorkListNQL_Class eaa in episodeAccountActionList)
                    {
                        CashOfficeWorkListResultModel cwom = new CashOfficeWorkListResultModel();
                        cwom.ObjectID = eaa.ObjectID.Value;
                        cwom.Date = Convert.ToDateTime(eaa.Documentdate);
                        cwom.Id = eaa.ID.ToString();
                        cwom.OperationType = eaa.Objdisplaytext;
                        cwom.ObjectDefName = eaa.Objname;
                        cwom.State = eaa.Currentstate.ToString();
                        if (eaa.Documentno != null)
                            cwom.ReceiptNo = eaa.Documentno.ToString();
                        cwom.PaymentPrice = eaa.Totalprice;
                        cwom.PatientFullName = eaa.Patientname + " " + eaa.Patientsurname;
                        cwom.CashierName = eaa.Cashiername;
                        if (eaa.UniqueRefNo.HasValue)
                            cwom.UniqueRefNo = eaa.UniqueRefNo.Value.ToString();
                        cwom.EpisodeID = eaa.Episodeid;
                        cashOfficeWorkListResultList.Add(cwom);
                    }

                if (bondActionList.Count > 0)
                    foreach (BondWorkListNQL_Class bondAction in bondActionList)
                    {
                        CashOfficeWorkListResultModel cwom = new CashOfficeWorkListResultModel();
                        cwom.ObjectID = bondAction.ObjectID.Value;
                        cwom.Date = Convert.ToDateTime(bondAction.Documentdate);
                        cwom.Id = bondAction.ID.ToString();
                        cwom.OperationType = bondAction.Objdisplaytext;
                        cwom.ObjectDefName = bondAction.Objname;
                        cwom.State = bondAction.Currentstate.ToString();
                        if (bondAction.Documentno != null)
                            cwom.ReceiptNo = bondAction.Documentno.ToString();
                        cwom.PaymentPrice = bondAction.TotalPrice;
                        cwom.PatientFullName = bondAction.Patientname + " " + bondAction.Patientsurname;
                        cwom.CashierName = bondAction.Cashiername;
                        cwom.UniqueRefNo = bondAction.UniqueRefNo.Value.ToString();
                        cwom.EpisodeID = bondAction.Episodeid;
                        cwom.EpisodeObjectID = bondAction.Episodeobjectid;
                        cashOfficeWorkListResultList.Add(cwom);
                    }

                if (accountActionListNoDate.Count > 0)
                    foreach (AccountAction.CashOfficeWorkListNQLNoDate_Class eaa in accountActionListNoDate)
                    {
                        CashOfficeWorkListResultModel cwom = new CashOfficeWorkListResultModel();
                        cwom.ObjectID = eaa.ObjectID.Value;
                        cwom.Date = Convert.ToDateTime(eaa.Documentdate);
                        cwom.Id = eaa.ID.ToString();
                        cwom.OperationType = eaa.Objdisplaytext;
                        cwom.ObjectDefName = eaa.Objname;
                        if (cwom.ObjectDefName == "MAINCASHOFFICEOPERATION")
                        {
                            CashOfficeReceiptDocument cashOfficeReceiptDocument = ((MainCashOfficeOperation)eaa.TTObject).CashOfficeReceiptDocument;
                            cwom.UniqueRefNo = cashOfficeReceiptDocument.PayeeUniqueRefNo;
                            cwom.PatientFullName = cashOfficeReceiptDocument.PayeeName;
                        }
                        cwom.State = eaa.Currentstate.ToString();
                        if (eaa.Documentno != null)
                            cwom.ReceiptNo = eaa.Documentno.ToString();
                        cwom.CashierName = eaa.Cashiername;
                        cwom.PaymentPrice = eaa.TotalPrice;
                        cashOfficeWorkListResultList.Add(cwom);
                    }

                if (accountActionList.Count > 0)
                    foreach (AccountAction.CashOfficeWorkListNQL_Class eaa in accountActionList)
                    {
                        CashOfficeWorkListResultModel cwom = new CashOfficeWorkListResultModel();
                        cwom.ObjectID = eaa.ObjectID.Value;
                        cwom.Date = Convert.ToDateTime(eaa.Documentdate);
                        cwom.Id = eaa.ID.ToString();
                        cwom.OperationType = eaa.Objdisplaytext;
                        cwom.ObjectDefName = eaa.Objname;
                        if (cwom.ObjectDefName == "MAINCASHOFFICEOPERATION")
                        {
                            CashOfficeReceiptDocument cashOfficeReceiptDocument = ((MainCashOfficeOperation)eaa.TTObject).CashOfficeReceiptDocument;
                            cwom.UniqueRefNo = cashOfficeReceiptDocument.PayeeUniqueRefNo;
                            cwom.PatientFullName = cashOfficeReceiptDocument.PayeeName;
                        }
                        cwom.State = eaa.Currentstate.ToString();
                        if (eaa.Documentno != null)
                            cwom.ReceiptNo = eaa.Documentno.ToString();
                        cwom.CashierName = eaa.Cashiername;
                        cwom.PaymentPrice = eaa.TotalPrice;
                        cashOfficeWorkListResultList.Add(cwom);
                    }
                //objectContext.FullPartialllyLoadedObjects();
            }

            cashOfficeWorkListResultList.OrderBy(x => x.Date);
            return cashOfficeWorkListResultList.ToArray();
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Vezne_Islemleri, TTRoleNames.Senet_Islemleri)]
        public CashOfficePatientFormViewModel GetCashOfficeWorkListForPatient([FromQuery] Guid episodeObjectId)
        {
            if (episodeObjectId != null)
            {
                CashOfficePatientFormViewModel cashOfficePatientFormViewModel = new CashOfficePatientFormViewModel();
                using (TTObjectContext objectContext = new TTObjectContext(true))
                {
                    List<EpisodeAccountAction> episodeAccountActions = EpisodeAccountAction.GetByEpisode(objectContext, episodeObjectId).ToList();
                    foreach (EpisodeAccountAction item in episodeAccountActions)
                    {
                        CashOfficeWorkListResultModel cowrm = new CashOfficeWorkListResultModel();
                        cowrm.ObjectID = item.ObjectID;
                        cowrm.ObjectDefName = item.ObjectDef.Name;
                        cowrm.Date = item.WorkListDate.Value;
                        cowrm.Id = item.ID.ToString();
                        cowrm.OperationType = item.ObjectDef.DisplayText;
                        cowrm.State = item.CurrentStateDef.DisplayText;
                        if (item.AccountDocuments != null && item.AccountDocuments.Count > 0)
                        {
                            cowrm.ReceiptNo = item.AccountDocuments[0].DocumentNo;
                            cowrm.PaymentPrice = item.AccountDocuments[0].TotalPrice;
                        }

                        cashOfficePatientFormViewModel.CashOfficeWorkListResultModel.Add(cowrm);
                    }

                    CashOfficePatientDetailModel copdm = new CashOfficePatientDetailModel();
                    Episode episode = objectContext.GetObject(episodeObjectId, typeof(Episode)) as Episode;
                    PatientEpisodePaymentDetail pepd = Episode.CalculatePatientDebt(episode, null, null);
                    copdm.EpisodeID = episode.ID.Value.ToString();
                    copdm.FullName = episode.Patient.FullName;
                    copdm.BirthDate = episode.Patient.BirthDate.HasValue ? episode.Patient.BirthDate.Value.ToShortDateString() : string.Empty;
                    copdm.FatherName = episode.Patient.FatherName;
                    copdm.MotherName = episode.Patient.MotherName;
                    copdm.PayerProtocol = episode.AllSubEpisodeProtocols().OrderByDescending(x => x.Id.Value).FirstOrDefault().Protocol.Name;
                    copdm.MedulaSigortaliTuru = episode.AllSubEpisodeProtocols().OrderByDescending(x => x.Id.Value).FirstOrDefault().MedulaSigortaliTuru.sigortaliTuruAdi;
                    string serviceName = string.Empty;
                    if (episode.PatientStatus == PatientStatusEnum.Outpatient)
                    {
                        if (episode.PatientAdmissions != null && episode.PatientAdmissions.Count > 0 && episode.PatientAdmissions[0].AdmissionStatus.Value == AdmissionStatusEnum.SaglikKurulu)
                            serviceName = episode.EpisodeActions.FirstOrDefault(x => x.GetType() == typeof(HealthCommittee)).MasterResource.Name;
                        else
                            serviceName = episode.GetExaminationPoliclinic()?.Name;
                    }
                    else
                        serviceName = episode.GetInPatientTreatmentClinic()?.Name;
                    copdm.ServiceName = string.IsNullOrEmpty(serviceName) == false ? serviceName : episode?.MainSpeciality?.Name;
                    copdm.TCNo = episode.Patient.UniqueRefNo.ToString();
                    copdm.AdvancePayment = pepd.AdvanceTotal;
                    copdm.BackPrice = (pepd.AdvanceBackTotal + pepd.ReceiptBackTotal);
                    copdm.TotalReceiptPayment = pepd.ReceiptTotal;
                    copdm.ServiceTotal = pepd.ServiceTotal;
                    copdm.BondTotal = pepd.BondTotal;
                    copdm.RemainingDebt = pepd.RemainingDebt;
                    cashOfficePatientFormViewModel.CashOfficePatientDetailModel = copdm;
                }

                return cashOfficePatientFormViewModel;
            }
            else
                return null;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Senet_Islemleri)]
        public OperationStatus SendNotification(BondNotificationItem bondNotificationItem)
        {
            OperationStatus opStatus = new Models.OperationStatus();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (bondNotificationItem != null && bondNotificationItem.ObjectIDs.Count > 0)
                    {
                        StringBuilder filterExpression = new StringBuilder();
                        StringBuilder firstNotificationNotSentItems = new StringBuilder();
                        filterExpression.Append(" OBJECTID IN (");
                        foreach (Guid item in bondNotificationItem.ObjectIDs)
                        {
                            filterExpression.Append("'" + item + "',");
                        }

                        filterExpression = filterExpression.Remove(filterExpression.Length - 1, 1);
                        filterExpression.Append(")");
                        IEnumerable<Bond> bonds = objectContext.QueryObjects<Bond>(filterExpression.ToString()).ToList();
                        switch (bondNotificationItem.NotificationType)
                        {
                            //1. İhbarname
                            case 0:
                                foreach (Bond bond in bonds)
                                {
                                    if (bond.FirstNotificationDate.HasValue == false && (bond.CurrentStateDefID == Bond.States.UnPaid || bond.CurrentStateDefID == Bond.States.PartialPaid) && bond.BondDetails.Where(x => x.PaymentDate.HasValue == false && x.Date < Common.RecTime()).Count() > 0)
                                    {
                                        bond.FirstNotificationDate = Convert.ToDateTime(bondNotificationItem.NotificationDate);
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(bond.BondDocument.DocumentNo))
                                            firstNotificationNotSentItems.Append(bond.BondDocument.DocumentNo + ",");
                                    }
                                }

                                firstNotificationNotSentItems = firstNotificationNotSentItems.Remove(firstNotificationNotSentItems.Length - 1, 1);
                                break;
                            //2. İhbarname
                            case 1:
                                foreach (Bond bond in bonds)
                                {
                                    if (bond.FirstNotificationDate.HasValue && bond.SecondNotificationDate.HasValue == false && (bond.CurrentStateDefID == Bond.States.UnPaid || bond.CurrentStateDefID == Bond.States.PartialPaid) && bond.BondDetails.Where(x => x.PaymentDate.HasValue == false && x.Date < Common.RecTime()).Count() > 0)
                                    {
                                        bond.SecondNotificationDate = Convert.ToDateTime(bondNotificationItem.NotificationDate);
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(bond.BondDocument.DocumentNo))
                                            firstNotificationNotSentItems.Append(bond.BondDocument.DocumentNo + ",");
                                    }
                                }

                                firstNotificationNotSentItems = firstNotificationNotSentItems.Remove(firstNotificationNotSentItems.Length - 1, 1);
                                break;
                            default:
                                throw new TTException(TTUtils.CultureService.GetText("M25691", "Geçersiz işlem"));
                        }

                        opStatus.CustomMessage = firstNotificationNotSentItems.ToString();
                        objectContext.Save();
                        opStatus.Status = true;
                    }
                    else
                        throw new TTException(TTUtils.CultureService.GetText("M26841", "Senet seçilmedi!"));
                }
                catch (Exception ex)
                {
                    opStatus.ErrorMessage = ex.ToString();
                    return opStatus;
                }

                return opStatus;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Makbuz_Numarasi_Degistirme)]
        public OperationStatus ChangeReceiptNo(List<CashOfficeWorkListResultModel> changedItems)
        {
            if (changedItems.Count == 0)
                throw new TTException(TTUtils.CultureService.GetText("M25925", "Herhangi bir değişiklik yapılmadı!"));
            //Boş olan kontrolü
            if (changedItems.Count(x => string.IsNullOrEmpty(x.ReceiptNo)) > 0)
                throw new TTException(TTUtils.CultureService.GetText("M26391", "Makbuz numarası boş olarak kayıt edilemez!"));
            //Değişenler içinde çakışan numara var mı
            var duplicateReceiptNo =
                from c in changedItems
                group c by c.ReceiptNo into g
                where g.Count() > 1
                select g.Key;
            if (duplicateReceiptNo.Count() > 0)
                throw new TTException(TTUtils.CultureService.GetText("M26390", "Makbuz numaraları aynı olamaz!"));
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    CashOfficeDefinition selectedCashOffice;
                    ResUser resUser = Common.CurrentResource;
                    selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser);
                    ReceiptCashOfficeDefinition selectedRCODef = new ReceiptCashOfficeDefinition();
                    selectedRCODef = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(objectContext, selectedCashOffice.ObjectID);
                    string filterExpression = " AND DOCUMENTNO IN(";
                    foreach (string receiptNo in changedItems.Select(x => x.ReceiptNo))
                    {
                        filterExpression += "'" + receiptNo + "',";
                    }

                    //filterExpression = filterExpression.Replace('"', '\'');
                    filterExpression = filterExpression.Remove(filterExpression.Length - 1, 1);
                    filterExpression += ")";
                    filterExpression += " AND DOCUMENTDATE < TODATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    filterExpression += " AND DOCUMENTDATE > TODATE('" + DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    List<Guid> eaaObjectIDs = changedItems.Where(x => x.ObjectDefName == "ADVANCE" || x.ObjectDefName == "BONDPAYMENT" || x.ObjectDefName == "RECEIPT").Select(x => x.ObjectID).ToList();
                    List<Guid> aaObjectIDs = changedItems.Where(x => x.ObjectDefName == "MAINCASHOFFICEOPERATION").Select(x => x.ObjectID).ToList();
                    var checkResult = AccountDocument.CheckForSameReceiptNumbers(objectContext, eaaObjectIDs.Count > 0 ? eaaObjectIDs : null, aaObjectIDs.Count > 0 ? aaObjectIDs : null, filterExpression);
                    var firstCheckResult = checkResult.FirstOrDefault();
                    int receiptNoExistscount = checkResult.Count;
                    if (receiptNoExistscount > 0)
                        throw new TTException( "Değiştirilen makbuz numaraları kayıtlı makbuz numaralarından farklı olmalıdır!(Tarih: "+firstCheckResult.OpeningDate + " Kabul No: " + firstCheckResult.ProtocolNo + " ,Hasta Tc: " +firstCheckResult.UniqueRefNo
                            + " Hasta Adı Soyadı:" + firstCheckResult.Name + " " + firstCheckResult.Surname + " )");
                    foreach (CashOfficeWorkListResultModel item in changedItems)
                    {
                        var obj = objectContext.GetObject(item.ObjectID, item.ObjectDefName);
                        Receipt receipt = obj as Receipt;
                        if (receipt != null)
                        {
                            CheckNextReceiptNumber(item.ReceiptNo, selectedRCODef);
                            CheckReceiptSeriesNo(receipt.ReceiptDocument.DocumentNo, item.ReceiptNo);
                            receipt.ReceiptDocument.DocumentNo = item.ReceiptNo;
                        }

                        Advance advance = obj as Advance;
                        if (advance != null)
                        {
                            CheckNextReceiptNumber(item.ReceiptNo, selectedRCODef);
                            CheckReceiptSeriesNo(advance.AdvanceDocument.DocumentNo, item.ReceiptNo);
                            advance.AdvanceDocument.DocumentNo = item.ReceiptNo;
                        }

                        BondPayment bondPayment = obj as BondPayment;
                        if (bondPayment != null && bondPayment.BondPaymentDocument.PaymentType != PaymentTypeEnum.Bank)
                        {
                            CheckNextReceiptNumber(item.ReceiptNo, selectedRCODef);
                            CheckReceiptSeriesNo(bondPayment.BondPaymentDocument.DocumentNo, item.ReceiptNo);
                            bondPayment.BondPaymentDocument.DocumentNo = item.ReceiptNo;
                        }
                        else if (bondPayment != null)
                            throw new TTException(TTUtils.CultureService.GetText("M25231", "Banka Ödemesi ile yapılan Senet Tahsilatının makbuz numarası değiştirilemez!"));
                        MainCashOfficeOperation mainCashOfficeOp = obj as MainCashOfficeOperation;
                        if (mainCashOfficeOp != null && mainCashOfficeOp.CashOfficeReceiptDocument.PaymentType.Value != PaymentTypeEnum.Bank)
                        {
                            CheckNextReceiptNumber(item.ReceiptNo, selectedRCODef);
                            CheckReceiptSeriesNo(mainCashOfficeOp.CashOfficeReceiptDocument.DocumentNo, item.ReceiptNo);
                            mainCashOfficeOp.CashOfficeReceiptDocument.DocumentNo = item.ReceiptNo;
                        }
                        else if (mainCashOfficeOp != null)
                            throw new TTException(TTUtils.CultureService.GetText("M25230", "Banka Ödemesi ile yapılan Diğer Tahsilatların makbuz numarası değiştirilemez!"));
                    }

                    objectContext.Save();
                    return new OperationStatus { Status = true };
                }
                catch (TTException ex)
                {
                    return new OperationStatus { Status = false, ErrorMessage = ex.Message };
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Vezne_Islemleri)]
        public Guid GetPatientObjectIDForOldReceiptDocument(Guid receiptDocObjectID)
        {
            TTObjectContext context = new TTObjectContext(true);
            OldDebtReceiptDocument receiptDocument = context.GetObject<OldDebtReceiptDocument>(receiptDocObjectID, false);
            if (receiptDocument != null && receiptDocument.PatientOldDebt != null && receiptDocument.PatientOldDebt.Count > 0)
            {
                PatientOldDebt patientOldDebt = receiptDocument.PatientOldDebt.FirstOrDefault(x => x.Patient != null);
                if (patientOldDebt != null)
                    return patientOldDebt.Patient.ObjectID;
            }

            return Guid.Empty;
        }

        public void CheckReceiptSeriesNo(string originalReceiptNo, string changedReceiptNo)
        {
            int indexOfFirstNumber = originalReceiptNo.IndexOfAny(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
            string originalSeriesNo = originalReceiptNo.Substring(0, indexOfFirstNumber);
            indexOfFirstNumber = changedReceiptNo.IndexOfAny(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
            string changedSeriesNo = changedReceiptNo.Substring(0, indexOfFirstNumber);
            if (originalSeriesNo != changedSeriesNo)
                throw new TTException(TTUtils.CultureService.GetText("M26392", "Makbuz Seri Numrası değiştirilemez!"));
        }

        public void CheckNextReceiptNumber(string changedReceiptNo, ReceiptCashOfficeDefinition receiptCashOfficeDef)
        {
            int indexOfFirstNumber = changedReceiptNo.IndexOfAny(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
            string receiptNo = changedReceiptNo.Substring(indexOfFirstNumber);
            if (Convert.ToDouble(receiptNo) >= receiptCashOfficeDef.CurrentReceiptNumber)
                throw new TTException("Sıradaki Makbuz Numarası geçilemez!");
        }
    }
}

namespace Core.Controllers.CashOfficeWorkList
{
    public class BondNotificationItem
    {
        public List<Guid> ObjectIDs
        {
            get;
            set;
        }

        public DateTime NotificationDate
        {
            get;
            set;
        }

        public int NotificationType
        {
            get;
            set;
        }
    }
}