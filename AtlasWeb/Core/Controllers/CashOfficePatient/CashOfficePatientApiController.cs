using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using TTDataDictionary;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Authorization;
using Core.Security;
using TTUtils;

namespace Core.Controllers.CashOfficePatient
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class CashOfficePatientApiController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Vezne_Islemleri, TTRoleNames.Senet_Islemleri)]
        public CashOfficePatientFormViewModel PrepareNewCashOfficePatientForm()
        {
            CashOfficePatientFormViewModel viewModel = new CashOfficePatientFormViewModel();
            TTUser currentUser = TTUser.CurrentUser;
            viewModel.Roles.Add("Receipt", currentUser.HasRole(Common.MushasebeYetkilisiMutemediAlındısıYeniRoleID));
            viewModel.Roles.Add("Advance", currentUser.HasRole(Common.AvansAlmaYeniRoleID));
            viewModel.Roles.Add("ReceiptBack", currentUser.HasRole(Common.MushasebeYetkilisiMutemediAlındısıIadeYeniRoleID));
            viewModel.Roles.Add("AdvanceBack", currentUser.HasRole(Common.AvansIadeYeniRoleID));
            viewModel.Roles.Add("Bond", currentUser.HasRole(Common.SenetYeniRoleID));
            viewModel.Roles.Add("BondPayment", currentUser.HasRole(Common.SenetTahsilatYeniRoleID));
            return viewModel;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Vezne_Islemleri, TTRoleNames.Senet_Islemleri)]
        public List<CashOfficePatientResultModel> GetCashOfficePatientResult(CashOfficePatientSearchModel searchModel)
        {
            string startDate;
            string endDate;
            if (searchModel.ApplicationStartDate.HasValue)
                startDate = Convert.ToDateTime((searchModel.ApplicationStartDate.Value.ToShortDateString() + " 00:00:00")).ToString("yyyy-MM-dd HH:mm:ss");
            else
                startDate = DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
            if (searchModel.ApplicationEndDate.HasValue)
                endDate = Convert.ToDateTime((searchModel.ApplicationEndDate.Value.ToShortDateString() + " 23:59:59")).ToString("yyyy-MM-dd HH:mm:ss");
            else
                endDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss");
            return GetCashOfficePatientResultList(searchModel, startDate, endDate);
        }

        private List<Episode> GetEpisodesForPatientResults(List<Episode.GetForCashOfficeSearch_Class> result, TTObjectContext objectContext)
        {
            List<Guid?> objectEpisodeIds = result.Select(x => x.ObjectID).ToList();
            string joinedIds = string.Join("','", objectEpisodeIds);
            joinedIds = "'" + joinedIds + "'";
            List<Episode> episodeList = objectContext.QueryObjects<Episode>("OBJECTID IN" + "(" + joinedIds + ")").ToList();
            return episodeList;
        }

        private List<CashOfficePatientResultModel> GetCashOfficePatientResultList(CashOfficePatientSearchModel searchModel, string startDate, string endDate)
        {
            StringBuilder queryParams = new StringBuilder();
            List<CashOfficePatientResultModel> patientResultList = new List<CashOfficePatientResultModel>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                if (searchModel.EpisodeID.HasValue && searchModel.EpisodeID.Value > 0)
                {
                    queryParams.Append(" AND ID = " + "" + searchModel.EpisodeID + "");
                    List<Episode.GetForCashOfficeSearch_Class> result = Episode.GetForCashOfficeSearch(objectContext, queryParams.ToString()).ToList();
                    if (result.Count == 0)
                        return null;
                    List<Episode> episodeList = GetEpisodesForPatientResults(result, objectContext);
                    foreach (Episode.GetForCashOfficeSearch_Class item in result)
                    {
                        Episode episode = episodeList.FirstOrDefault(x => x.ObjectID == item.ObjectID);
                        CashOfficePatientResultModel patientResult;
                        patientResult = new CashOfficePatientResultModel();
                        patientResult.EpisodeID = item.ID.Value.ToString();
                        patientResult.ObjectID = item.ObjectID.Value;
                        patientResult.PatientObjectID = episode.Patient.ObjectID;
                        patientResult.FullName = item.Name + " " + item.Surname;
                        patientResult.TCNo = item.UniqueRefNo.ToString();
                        patientResult.Date = episode.OpeningDate.Value;
                        patientResult.TotalDebt = Episode.CalculatePatientDebt(episode, null, null).RemainingDebt;
                        patientResultList.Add(patientResult);
                    }

                    return patientResultList;
                }
                else
                {
                    if (searchModel.SelectedDebtType == PatientDebtTypeEnum.InDebt) // Borçlu sabit koşullar
                    {
                        string blockStates = InvoiceBlockingDefinition.GetCashOfficeBlockStateIDs(objectContext);

                        queryParams.Append(" AND SUBEPISODES(CURRENTSTATE IS NOT STATES.CANCELLED AND ");
                        queryParams.Append(" SUBEPISODEPROTOCOLS.CURRENTSTATE IS NOT STATES.CANCELLED AND");
                        queryParams.Append(" SUBEPISODEPROTOCOLS.ACCOUNTTRANSACTIONS.CURRENTSTATE = STATES.NEW AND");
                        queryParams.Append(" SUBEPISODEPROTOCOLS.ACCOUNTTRANSACTIONS.INVOICEINCLUSION = 1 AND");
                        queryParams.Append(" SUBEPISODEPROTOCOLS.ACCOUNTTRANSACTIONS.ACCOUNTPAYABLERECEIVABLE.TYPE = 0 AND");
                        queryParams.Append(" (SUBEPISODEPROTOCOLS.ACCOUNTTRANSACTIONS.SUBACTIONMATERIAL IS NOT NULL OR (SUBEPISODEPROTOCOLS.ACCOUNTTRANSACTIONS.SUBACTIONPROCEDURE IS NOT NULL AND SUBEPISODEPROTOCOLS.ACCOUNTTRANSACTIONS.SUBACTIONPROCEDURE.CURRENTSTATEDEFID NOT IN (" + blockStates + ") AND SUBEPISODEPROTOCOLS.ACCOUNTTRANSACTIONS.SUBACTIONPROCEDURE.EPISODEACTION.CURRENTSTATEDEFID NOT IN (" + blockStates + "))) AND");
                        queryParams.Append(" SUBEPISODEPROTOCOLS.ACCOUNTTRANSACTIONS.TRANSACTIONDATE BETWEEN TODATE('" + startDate + "') AND TODATE('" + endDate + "')).EXISTS");
                    }
                    else if (searchModel.SelectedDebtType == PatientDebtTypeEnum.Payee) // Alacaklı sabit koşullar
                    {
                        queryParams.Append(" AND ADVANCES(CURRENTSTATE = STATES.PAID).EXISTS");
                        queryParams.Append(" AND SUBEPISODES(CURRENTSTATE IS NOT STATES.CANCELLED AND OPENINGDATE BETWEEN TODATE('" + startDate + "') AND TODATE('" + endDate + "')).EXISTS");
                    }
                    else if (searchModel.SelectedDebtType == PatientDebtTypeEnum.InDebtBond) // Senet Borçlu sabit koşullar
                    {
                        queryParams.Append(" AND BONDS(CURRENTSTATE NOT IN (STATES.CANCELLED, STATES.RESTRUCTURED, STATES.PAID)).EXISTS");
                        queryParams.Append(" AND SUBEPISODES(CURRENTSTATE IS NOT STATES.CANCELLED AND OPENINGDATE BETWEEN TODATE('" + startDate + "') AND TODATE('" + endDate + "')).EXISTS");
                    }

                    if (!string.IsNullOrEmpty(searchModel.TCNo))
                    {
                        queryParams.Append(" AND PATIENT.UNIQUEREFNO = " + "'" + searchModel.TCNo + "'");
                        //Eski hasta borcu listeleme
                        List<CashOfficePatientResultModel> oldDebtPatients = objectContext.QueryObjects<PatientOldDebt>("OLDUNIQUEREFNO = " + "'" + searchModel.TCNo + "' AND OLDDEBTRECEIPTDOCUMENT IS NULL AND (ISREMOVED = 0 OR ISREMOVED IS NULL)").GroupBy(x => x.OldUniqueRefNo).Select(x => new CashOfficePatientResultModel() { FullName = x.First().OldPatientNameSurname, TCNo = x.First().Patient.UniqueRefNo.Value.ToString(), PatientObjectID = x.First().Patient.ObjectID, TotalDebt = x.First().TotalDebt.Value, Date = x.First().OldPADate.Value }).ToList();
                        patientResultList.AddRange(oldDebtPatients);
                        //Eski hasta borcu listeleme
                    }

                    if (!string.IsNullOrEmpty(searchModel.FirstName))
                    {
                        queryParams.Append(" AND PATIENT.NAME LIKE '%" + searchModel.FirstName.ToUpper() + "%'");
                        //Eski hasta borcu listeleme
                        List<CashOfficePatientResultModel> oldDebtPatients = objectContext.QueryObjects<PatientOldDebt>("PATIENT.NAME LIKE '%" + searchModel.FirstName.ToUpper() + "%' AND OLDDEBTRECEIPTDOCUMENT IS NULL AND (ISREMOVED = 0 OR ISREMOVED IS NULL)").GroupBy(x => x.OldUniqueRefNo).Select(x => new CashOfficePatientResultModel() { FullName = x.First().OldPatientNameSurname, TCNo = x.First().Patient.UniqueRefNo.ToString(), PatientObjectID = x.First().Patient.ObjectID, TotalDebt = x.First().TotalDebt, Date = x.First().OldPADate }).ToList();
                        patientResultList.AddRange(oldDebtPatients);
                        //Eski hasta borcu listeleme
                    }

                    if (!string.IsNullOrEmpty(searchModel.LastName))
                    {
                        queryParams.Append(" AND PATIENT.SURNAME LIKE '%" + searchModel.LastName.ToUpper() + "%'");
                        //Eski hasta borcu listeleme
                        List<CashOfficePatientResultModel> oldDebtPatients = objectContext.QueryObjects<PatientOldDebt>("PATIENT.SURNAME LIKE '%" + searchModel.LastName.ToUpper() + "%' AND OLDDEBTRECEIPTDOCUMENT IS NULL AND (ISREMOVED = 0 OR ISREMOVED IS NULL)").GroupBy(x => x.OldUniqueRefNo).Select(x => new CashOfficePatientResultModel() { FullName = x.First().OldPatientNameSurname, TCNo = x.First().Patient.UniqueRefNo.ToString(), PatientObjectID = x.First().Patient.ObjectID, TotalDebt = x.First().TotalDebt, Date = x.First().OldPADate }).ToList();
                        patientResultList.AddRange(oldDebtPatients);
                        //Eski hasta borcu listeleme
                    }

                    if (searchModel.SelectedPayerDefinition != null)
                        queryParams.Append(" AND SUBEPISODES.SUBEPISODEPROTOCOLS.PAYER =" + "'" + searchModel.SelectedPayerDefinition.Value.ToString() + "'");

                    if (searchModel.SelectedBuilding != null)
                        queryParams.Append(" AND SUBEPISODES.PATIENTADMISSION.BUILDING =" + "'" + searchModel.SelectedBuilding.Value.ToString("D") + "'");

                    List<Episode.GetForCashOfficeSearch_Class> result = Episode.GetForCashOfficeSearch(objectContext, queryParams.ToString()).ToList();
                    if (result.Count == 0 && patientResultList.Count() == 0)
                        return null;

                    List<Episode> episodeList = GetEpisodesForPatientResults(result, objectContext);
                    foreach (Episode.GetForCashOfficeSearch_Class item in result)
                    {
                        Episode episode = episodeList.FirstOrDefault(x => x.ObjectID == item.ObjectID);
                        CashOfficePatientResultModel patientResult;
                        if (searchModel.SelectedDebtType == PatientDebtTypeEnum.InDebt)
                        {
                            decimal debtAmount = Episode.CalculatePatientDebt(episode, null, null).RemainingDebt;
                            if (debtAmount > 0)
                            {
                                patientResult = new CashOfficePatientResultModel();
                                patientResult.EpisodeID = item.ID.Value.ToString();
                                patientResult.ObjectID = item.ObjectID.Value;
                                patientResult.PatientObjectID = episode.Patient.ObjectID;
                                patientResult.FullName = item.Name + " " + item.Surname;
                                patientResult.TCNo = item.UniqueRefNo.ToString();
                                patientResult.TotalDebt = debtAmount;
                                patientResult.Date = episode.OpeningDate.Value;
                                patientResultList.Add(patientResult);
                            }
                        }
                        else if (searchModel.SelectedDebtType == PatientDebtTypeEnum.Payee)
                        {
                            decimal debtAmount = Episode.CalculatePatientDebt(episode, null, null).RemainingDebt;
                            if (debtAmount < 0)
                            {
                                patientResult = new CashOfficePatientResultModel();
                                patientResult.EpisodeID = item.ID.Value.ToString();
                                patientResult.ObjectID = item.ObjectID.Value;
                                patientResult.PatientObjectID = episode.Patient.ObjectID;
                                patientResult.FullName = item.Name + " " + item.Surname;
                                patientResult.TCNo = item.UniqueRefNo.ToString();
                                patientResult.TotalDebt = debtAmount;
                                patientResult.Date = episode.OpeningDate.Value;
                                patientResultList.Add(patientResult);
                            }
                        }
                        else if (searchModel.SelectedDebtType == PatientDebtTypeEnum.InDebtBond)
                        {
                            patientResult = new CashOfficePatientResultModel();
                            patientResult.EpisodeID = item.ID.Value.ToString();
                            patientResult.ObjectID = item.ObjectID.Value;
                            patientResult.PatientObjectID = episode.Patient.ObjectID;
                            patientResult.FullName = item.Name + " " + item.Surname;
                            patientResult.TCNo = item.UniqueRefNo.ToString();
                            patientResult.TotalDebt = Episode.CalculatePatientDebt(episode, null, null).RemainingBondTotal;
                            patientResult.Date = episode.OpeningDate.Value;
                            patientResultList.Add(patientResult);
                        }
                    }

                    return patientResultList;
                }
            }
        }
        #region Eski hasta borcu ödeme kodu
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Vezne_Islemleri)]
        public PatientOldDebtFormModel PrepareNewPatientOldDebtForm(Guid patientObjectID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<PatientOldDebt> podList = objectContext.QueryObjects<PatientOldDebt>("PATIENT = '" + patientObjectID + "' AND (ISREMOVED = 0 OR ISREMOVED IS NULL)").ToList();

                if (podList == null || podList.Count == 0)
                    throw new TTException(TTUtils.CultureService.GetText("M25306", "Bu hastanın eski sistemden kalan borcu bulunmamaktadır!"));

                PatientOldDebtFormModel model = new PatientOldDebtFormModel();
                ReceiptCashOfficeDefinition selectedRCODef = new ReceiptCashOfficeDefinition();
                selectedRCODef = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(objectContext, ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, Common.CurrentResource).ObjectID);

                model.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);

                model.Transactions = new List<PatientOldDebtTransactionDebtModel>();
                foreach (PatientOldDebt pod in podList)
                {
                    model.Transactions.Add(new PatientOldDebtTransactionDebtModel { ProcedureCode = pod.ProcedureCode, ProcedureName = pod.ProcedureName, ProcedureType = pod.ProcedureType, TransactionDebt = pod.TransactionDebt });
                }

                model.Date = DateTime.Now;
                model.PatientObjectID = patientObjectID;
                model.PaymentType = 0;
                model.TotalPrice = podList[0].TotalDebt;
                model.PayeeName = podList[0].OldPatientNameSurname;
                return model;
            }

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Vezne_Islemleri)]
        public bool PayPatientOldDebt(PatientOldDebtFormModel model)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                OldDebtReceiptDocument odrd = new OldDebtReceiptDocument(objectContext);
                odrd.ResUser = Common.CurrentResource;
                odrd.CashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, Common.CurrentResource);
                ReceiptCashOfficeDefinition selectedRCODef = new ReceiptCashOfficeDefinition();
                selectedRCODef = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(objectContext, odrd.CashOffice.ObjectID);

                odrd.TotalPrice = model.TotalPrice;
                odrd.DocumentDate = DateTime.Now;
                odrd.PaymentType = model.PaymentType;
                foreach (PatientOldDebt pod in objectContext.QueryObjects<PatientOldDebt>("PATIENT = '" + model.PatientObjectID + "' AND (ISREMOVED = 0 OR ISREMOVED IS NULL)"))
                {
                    odrd.PatientOldDebt.Add(pod);
                }

                switch (model.PaymentType)
                {
                    case PaymentTypeEnum.Cash:
                        {
                            Cash cash = new Cash(objectContext) { Price = model.TotalPrice, CurrencyType = CurrencyTypeDefinition.GetByQref(objectContext, "TL")[0], AccountDocument = odrd };
                            selectedRCODef = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(selectedRCODef);
                            odrd.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);
                            ReceiptCashOfficeDefinition.SetNextReceiptNumber(selectedRCODef);
                        }
                        break;
                    case PaymentTypeEnum.CreditCard:
                        {
                            CreditCard creditCard = new CreditCard(objectContext) { Price = model.TotalPrice, AccountDocument = odrd };
                            selectedRCODef = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(selectedRCODef);
                            odrd.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(selectedRCODef);
                            ReceiptCashOfficeDefinition.SetNextCreditCardReceiptNumber(selectedRCODef);
                        }
                        break;
                    default:
                        break;
                }

                odrd.CreateAccountVoucher();

                objectContext.Save();
                return true;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Vezne_Islemleri)]
        public void RemoveOldDebt(string uniqueRefNo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<PatientOldDebt> oldDebts = objectContext.QueryObjects<PatientOldDebt>("OLDUNIQUEREFNO = " + uniqueRefNo + " AND (ISREMOVED = 0 OR ISREMOVED IS NULL)").ToList();
                if (oldDebts == null || oldDebts.Count == 0)
                    throw new TTException(TTUtils.CultureService.GetText("M25306", "Bu hastanın eski sistemden kalan borcu bulunmamaktadır!"));
                foreach (PatientOldDebt item in oldDebts)
                {
                    item.IsRemoved = true;
                    //((ITTObject)item).Delete();
                }
                objectContext.Save();
            }
        }
        #endregion Eski hasta borcu ödeme kodu

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Vezne_Islemleri, TTRoleNames.Senet_Islemleri)]
        public void sendToDoctorPerf()
        {
            SendToDoctorPerformance.SendAllDPs();
        }
    }
}