using System;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.ComponentModel;
using System.Linq;
using TTDefinitionManagement;
using System.Collections;
using static TTObjectClasses.TreatmentDischarge;
using TTStorageManager.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class NursingModuleWorkListServiceController : BaseEpisodeActionWorkListServiceController
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public NursingModuleWorkListViewModel LoadNursingModuleWorkListViewModel()
        {
            var viewModel = new NursingModuleWorkListViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.WorkList = new List<NursingModuleWorkListItem>();

                viewModel._SearchCriteria = new NursingModuleWorkListSearchCriteria();
                viewModel._SearchCriteria.WorkListStartDate = Common.RecTime();
                DateTime dt = DateTime.Now;

                viewModel._SearchCriteria.WorkListEndDate = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
                viewModel._SearchCriteria.ActionType = 1;
                viewModel._SearchCriteria.PatientType = 1;

                #region Birim Listesi

                /****** Klinik Birim Listesi ******/

                viewModel.ResourceList = new List<ResSection>();
                foreach (var useResource in Common.CurrentResource.UserResources)
                {
                    if (useResource.Resource.IsActive.HasValue && useResource.Resource.IsActive.Value)
                    {
                        if (useResource.Resource is ResClinic)
                        {
                            var resource = viewModel.ResourceList.Where(t => t.ObjectID == useResource.Resource.ObjectID).FirstOrDefault();
                            if (resource == null)
                                viewModel.ResourceList.Add(useResource.Resource);
                        }
                        else if (useResource.Resource is ResPoliclinic && useResource.Resource.Brans != null && useResource.Resource.Brans.Code == "4400")
                        {
                            var resource = viewModel.ResourceList.Where(t => t.ObjectID == useResource.Resource.ObjectID).FirstOrDefault();
                            if (resource == null)
                                viewModel.ResourceList.Add(useResource.Resource);
                        }
                    }

                }

                viewModel.ResourceList = viewModel.ResourceList.OrderBy(x => x.Name).ToList<ResSection>();

                var CurrentResource = Common.CurrentResource;
                viewModel._SearchCriteria.Resources = new List<ResSection>();
                var selectedInPatientResource = CurrentResource.SelectedInPatientResource;
                if (selectedInPatientResource != null && selectedInPatientResource is ResClinic)
                {
                    viewModel._SearchCriteria.Resources.Add(selectedInPatientResource);
                }
                else if (selectedInPatientResource != null && selectedInPatientResource is ResDepartment)
                {

                    ResDepartment resDepartment = (ResDepartment)objectContext.GetObject(selectedInPatientResource.ObjectID, "ResDepartment");
                    foreach (var sResource in resDepartment.Clinics)
                    {
                        viewModel._SearchCriteria.Resources.Add(sResource);
                    }
                }

                #endregion

                #region EpisodeAction Tipi Seçimi


                #endregion

                #region  state sorguları
                using (var eawsc = new EpisodeActionWorkListServiceController())
                {
                    List<EpisodeActionWorkListItem> _episodeActionWorkListItems = new List<EpisodeActionWorkListItem>();

                    EpisodeActionWorkListItem _episodeActionWorkListItem = new EpisodeActionWorkListItem();
                    _episodeActionWorkListItem.ObjectDefName = "NURSINGORDERDETAIL";
                    _episodeActionWorkListItem.ObjectDefID = "8c3337ca-5d28-4ae2-9b3c-51ae43cee8b7";
                    _episodeActionWorkListItems.Add(_episodeActionWorkListItem);

                    viewModel.NursingOrderWorkListStateItem = eawsc.GetEpisodeActionStateDefinition(_episodeActionWorkListItems, "e0444b60-fa7f-40bc-ba42-8f06556aee7c").WorkListSearchStateItem;

                    viewModel._SearchCriteria.NursingOrderStateItem = new List<EpisodeActionWorkListStateItem>();

                    foreach (EpisodeActionWorkListStateItem item in viewModel.NursingOrderWorkListStateItem)
                    {
                        item.StateDefName = item.StateDefName.Replace("Hemşire Takip Gözlem Uygulaması (Klinik İşlemleri) -", "").Trim();

                        if (item.StateDefID.ToString() == "95d0ea09-0398-42fc-ba11-45f2583520d3")
                            viewModel._SearchCriteria.NursingOrderStateItem.Add(item);
                    }

                    _episodeActionWorkListItems = new List<EpisodeActionWorkListItem>();
                    _episodeActionWorkListItem = new EpisodeActionWorkListItem();
                    _episodeActionWorkListItem.ObjectDefName = "DRUGORDERDETAIL";
                    _episodeActionWorkListItem.ObjectDefID = "5beac21d-06b6-4d8f-a574-ff1ea8af3ce8";
                    _episodeActionWorkListItems.Add(_episodeActionWorkListItem);

                    List<EpisodeActionWorkListStateItem> _temp = new List<EpisodeActionWorkListStateItem>();

                    viewModel.DrugOrderWorkListStateItem = new List<EpisodeActionWorkListStateItem>();
                    viewModel._SearchCriteria.DrugOrderStatesItem = new List<EpisodeActionWorkListStateItem>();

                    _temp = eawsc.GetEpisodeActionStateDefinition(_episodeActionWorkListItems, "25ca7ea8-c804-4d12-ad74-8bb4aa2f9813").WorkListSearchStateItem;
                    foreach (EpisodeActionWorkListStateItem item in _temp)
                    {
                        item.StateDefName = item.StateDefName.Replace("İlaç Uygulama -", "").Trim();
                        item.StateDefName = FormatDrugOrderStatusName(item.StateDefName);// item.StateDefName.Substring(item.StateDefName.IndexOf("-") + 1, item.StateDefName.Length - item.StateDefName.IndexOf("-") - 1); 

                        //item.StateDefName = item.StateDefName.Substring(0, item.StateDefName.IndexOf("-")).Trim();
                        switch (item.StateDefID.ToString())
                        {
                            case "cb22e74b-a2be-456f-8680-660d0b21dc24": // plan
                                if (TTObjectClasses.SystemParameter.GetParameterValue("DAILYDRUGSCHORDERBYPASS", "FALSE") == "FALSE")
                                    viewModel.DrugOrderWorkListStateItem.Add(item);
                                break;
                            case "da01e671-efb9-4d84-8122-4bae07e08c20": //İstek
                            case "d39a37a6-610e-4143-aca2-691ce5818915": //Uygulandı
                            case "f1b24e44-ecb3-4b44-9b23-1d77e9901721": //Durdur
                            case "add6e452-c007-4849-b477-17d30400abe8": //İptal
                            case "4223ab9b-1b9f-4f59-845f-b903adcda8a0"://Eczaneye İade
                            case "14ea4626-5b27-4663-82f9-64968cb4eb63": //Hastaya Teslim
                                viewModel.DrugOrderWorkListStateItem.Add(item);
                                break;
                            case "d4f85132-8d05-4dc7-b9b2-fc04bae622b0": // Karşılandı
                            case "94c4b7eb-b764-4ca5-add6-76e2217f7dd4": //Hastanın Üzerinde
                                viewModel.DrugOrderWorkListStateItem.Add(item);
                                viewModel._SearchCriteria.DrugOrderStatesItem.Add(item);
                                break;
                            case "ad54f2c0-8ebe-4fbb-a57a-b7c870fd1fb3": // Eczacılık Bilimlerinden İstendi
                            case "0586979d-523c-4800-995c-750ac3984606": //Dış Eczane Tarafından Karşılandı
                                item.StateDefName = "Belirsiz";
                                break;
                            default:
                                item.StateDefName = TTUtils.CultureService.GetText("M27042", "Tanımsız durum.Lütfen sistem yöneticisine başvurun!!");
                                break;
                        }
                    }

                }
                #endregion

                viewModel.GicActive = Get_UsercontrolTool();

                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public NursingModuleWorkListViewModel GetNursingModuleWorkList(NursingModuleWorkListSearchCriteria sc)
        {
            int workListMaxItemCount = Common.WorklistMaxItemCount();
            int counter = 0;

            // GENEL 
            ResUser CurrentUser = Common.CurrentResource;
            var viewModel = new NursingModuleWorkListViewModel();
            viewModel.WorkList = new List<NursingModuleWorkListItem>();
            viewModel.maxWorklistItemCount = 0;
            //
            string _filter = string.Empty;

            if (!string.IsNullOrEmpty(sc.PatientObjectID))
            {
                _filter += " AND this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
            }
            else if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (sc.ProtocolNo.Contains("-"))
                    _filter = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                else
                {
                    _filter = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";

                }

            }
            else
            {
                if (!Common.CurrentUser.IsSuperUser && sc.PatientType == 1)// Kendi Hastalarım
                {
                    _filter = " AND THIS.NursingApplication.InPatientTreatmentClinicApp.ResponsibleNurse='" + Common.CurrentUser.TTObjectID.Value + "'";
                }
            }

            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(true))
                {
                    if (sc.ActionType == 2)
                    {
                        if (sc.DrugOrderStatesItem != null && sc.DrugOrderStatesItem.Count > 0)
                            viewModel.WorkList.AddRange(GetDrugOrderList(objectContext, sc, _filter));

                        if (sc.NursingOrderStateItem != null && sc.NursingOrderStateItem.Count > 0)
                            viewModel.WorkList.AddRange(GetNursingOrderList(objectContext, sc, _filter));
                    }
                    else
                    {
                        viewModel.WorkList.AddRange(GetNursingApplicationWorkList(objectContext, sc, counter, CurrentUser, workListMaxItemCount));
                        viewModel.maxWorklistItemCount = viewModel.WorkList.Count;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return viewModel;
        }

        protected List<NursingModuleWorkListItem> GetDrugOrderList(TTObjectContext objectContext, NursingModuleWorkListSearchCriteria sc, string _filter)
        {
            List<NursingModuleWorkListItem> WorkList = new List<NursingModuleWorkListItem>();
            DateTime _rectime = Common.RecTime();

            ControlResourceList(sc.Resources);

            List<Guid> _resources = sc.Resources.Select(x => x.ObjectID).ToList<Guid>();

            #region STATE FİLTER

            System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
            string comma = "";

            _tempString.Append(" AND THIS.CURRENTSTATEDEFID IN(");

            for (int i = 0; i < sc.DrugOrderStatesItem.Count; i++)
            {
                _tempString.Append(comma);
                _tempString.Append("'" + sc.DrugOrderStatesItem[i].StateDefID + "'");
                comma = ",";
            }

            _tempString.Append(") ");

            _filter += _tempString.ToString();

            #endregion

            BindingList<DrugOrderDetail.GetDrugOrderDetailsByMasterResource_Class> drugOrderDetailsByMasterResource = DrugOrderDetail.GetDrugOrderDetailsByMasterResource(sc.WorkListStartDate.Value, sc.WorkListEndDate.Value, _resources, _filter);
            foreach (DrugOrderDetail.GetDrugOrderDetailsByMasterResource_Class detail in drugOrderDetailsByMasterResource)
            {
                if (this.HasWorkListWorkListRight(objectContext, detail.ObjectID.Value, "DRUGORDERDETAIL"))// BASEDEN KULLANILIYOR  
                {
                    NursingModuleWorkListItem nosd = new NursingModuleWorkListItem();

                    DateTime orderEndDate = detail.OrderPlannedDate.Value.AddMinutes(30);
                    nosd.startDate = detail.OrderPlannedDate.Value;
                    nosd.endDate = orderEndDate.Day != nosd.startDate.Day ? detail.OrderPlannedDate.Value.AddMinutes(30 - (orderEndDate.Minute + 1)) : orderEndDate;
                    nosd.PatientNameSurname = detail.Patient_name + ' ' + detail.Patient_surname;
                    nosd.text = detail.Material;

                    TTObjectContext context1 = new TTObjectContext(true);
                    DrugOrderDetail drugOrderDetail = context1.GetObject<DrugOrderDetail>(detail.ObjectID.Value);

                    Guid state = (Guid)detail.CurrentStateDefID;
                    nosd.stateDefID = state;
                    nosd.statusName = FormatDrugOrderStatusName(detail.Statusname.ToString());// detail.Statusname.ToString().Substring(detail.Statusname.ToString().IndexOf("-") + 1, detail.Statusname.ToString().Length - detail.Statusname.ToString().IndexOf("-") - 1);//detail.Statusname.ToString();//ChangeStatusName(state); item.StateDefName.Substring( item.StateDefName.IndexOf("-")+1,item.StateDefName.Length-item.StateDefName.IndexOf("-")-1)

                    nosd.doctorDescription = detail.Note;
                    nosd.Result = "";

                    nosd.MasterResourceName = detail.Masterresource_name;

                    #region BEDandROOM
                    string _roomBed = string.Empty;

                    if (detail.Room != null)
                        _roomBed = detail.Room.ToString() + " / ";

                    if (detail.Bed != null)
                        _roomBed += detail.Bed.ToString();

                    nosd.RoomAndBedName = _roomBed;
                    #endregion

                    nosd.ResponsibleNurse = detail.Responsiblenurse != null ? detail.Responsiblenurse.ToString() : "";

                    #region HIDDEN COLUMN
                    nosd.DoctorName = detail.Proceduredoctor != null ? detail.Proceduredoctor.ToString() : "";
                    nosd.KabulNo = detail.Kabulno != null ? detail.Kabulno.ToString() : "";
                    nosd.ComingReason = detail.Comingreason != null ? detail.Comingreason.ToString() : "";
                    nosd.PayerInfo = detail.Kurum != null ? detail.Kurum.ToString() : "";
                    nosd.DoctorName = detail.Proceduredoctor != null ? detail.Proceduredoctor.ToString() : "";
                    nosd.BirthDate = detail.BirthDate != null ? detail.BirthDate.Value : new DateTime(0001, 01, 01);
                    nosd.FatherName = detail.FatherName != null ? detail.FatherName.ToString() : "";
                    nosd.PhoneNumber = detail.MobilePhone != null ? detail.MobilePhone.ToString() : "";
                    nosd.UniqueRefno = detail.UniqueRefNo == null ? (detail.YUPASSNO != null ? detail.YUPASSNO.Value.ToString() : "") : detail.UniqueRefNo.Value.ToString();
                    nosd.BasvuruTuru = detail.Basvuruturu == null ? "" : detail.Basvuruturu.ToString();
                    nosd.HastaTuru = detail.Hastaturu == null ? "" : detail.Hastaturu.ToString();
                    nosd.Dose = drugOrderDetail.DoseAmount.ToString();
                    //nosd.UsageType = Common.GetDisplayTextOfEnumValue("DrugUsageTypeEnum", (int)drugOrderDetail.DrugOrder.DrugUsageType);

                    if (detail.Episode != null)
                    {
                        Episode _episode = (Episode)objectContext.GetObject((Guid)detail.Episode, "Episode");
                        CompanionApplication _companion = _episode.GetActiveCompanionApplication();
                        nosd.Companion = _companion == null ? "" : _companion.CompanionName;
                    }

                    #endregion

                    #region ICON
                    this.editedSetWorkListIkonProperties(detail.Code, (Patient)objectContext.GetObject((Guid)detail.Patientid, "Patient"), nosd);

                    if (nosd.isPatientDrugAllergic && nosd.isPatientFoodAllergic)
                    {
                        nosd.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                    }
                    else
                    {
                        if (nosd.isPatientDrugAllergic)
                        {
                            nosd.MedicalInformation = "İlaç Alerjisi Var";
                        }

                        if (nosd.isPatientFoodAllergic)
                        {
                            nosd.MedicalInformation = "Gıda Alerjisi Var";
                        }
                    }

                    if (nosd.isPatientOtherAllergic)
                    {
                        nosd.MedicalInformation = "Diğer";
                    }

                    nosd.HasTightContactIsolation = (Boolean)(detail.HasTightContactIsolation == null ? false : detail.HasTightContactIsolation);
                    nosd.HasFallingRisk = (Boolean)(detail.HasFallingRisk == null ? false : detail.HasFallingRisk);
                    nosd.HasDropletIsolation = (Boolean)(detail.HasDropletIsolation == null ? false : detail.HasDropletIsolation);
                    nosd.HasAirborneContactIsolation = (Boolean)(detail.HasAirborneContactIsolation == null ? false : detail.HasAirborneContactIsolation);
                    nosd.HasContactIsolation = (Boolean)(detail.HasContactIsolation == null ? false : detail.HasContactIsolation);
                    #endregion

                    if (((DrugOrderDetail)detail.TTObject).KScheduleCollectedOrder != null)
                    {
                        TTObjectContext context = new TTObjectContext(true);
                        IBindingList col = context.QueryObjects("KSCHEDULEMATERIAL", "KSCHEDULECOLLECTEDORDER=" + TTConnectionManager.ConnectionManager.GuidToString(((DrugOrderDetail)detail.TTObject).KScheduleCollectedOrder.ObjectID));
                        if (col.Count > 0)
                        {
                            KScheduleMaterial colOrder = (KScheduleMaterial)col[0];
                            if (colOrder.StockTransactions.Select(string.Empty).Count > 0)
                            {
                                foreach (StockTransaction trx in colOrder.StockTransactions.Select(string.Empty))
                                {
                                    nosd.ExpireDate = trx.ExpirationDate;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        nosd.ExpireDate = DateTime.MinValue;
                    }


                    nosd.id = detail.ObjectID.Value;
                    nosd.ObjectID = detail.ObjectID.Value;
                    nosd.ObjectDefName = detail.ObjectDefName;
                    nosd.ObjectDefID = detail.ObjectDefID.Value.ToString();
                    nosd.typeId = OrderTypeEnum.DrugOrder;
                    nosd.typeName = TTUtils.CultureService.GetText("M26061", "İlaç Direktifi");//OrderTypeEnum.DrugOrder;

                    nosd.OzelDurum = "";
                    if (detail.TTObject.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        List<TTObjectState> states = detail.TTObject.GetStateHistory().ToList();
                        nosd.ProcedureByUser = states[states.Count - 1].User.FullName;
                        nosd.ExecutionDate = states[states.Count - 1].BranchDate;
                    }
                    else
                        nosd.ExecutionDate = null;
                    //nosd.ProcedureByUser = detail.Procedurebyuser != null ? detail.Procedurebyuser : "";
                    //nosd.ExecutionDate = detail.ExecutionDate.HasValue ? detail.ExecutionDate.Value : (DateTime?)null;
                    if (nosd.startDate < _rectime)
                    {
                        nosd.RowColor = "#ffa2a2";
                    }

                    WorkList.Add(nosd);
                }
            }
            return WorkList;
        }

        protected List<NursingModuleWorkListItem> GetNursingOrderList(TTObjectContext objectContext, NursingModuleWorkListSearchCriteria sc, string _filter)
        {

            List<NursingModuleWorkListItem> WorkList = new List<NursingModuleWorkListItem>();

            DateTime _rectime = Common.RecTime();

            ControlResourceList(sc.Resources);

            List<Guid> _resources = sc.Resources.Select(x => x.ObjectID).ToList<Guid>();

            #region STATE FİLTER

            System.Text.StringBuilder _tempString = new System.Text.StringBuilder();
            string comma = "";

            _tempString.Append(" AND THIS.CURRENTSTATEDEFID IN(");

            for (int i = 0; i < sc.NursingOrderStateItem.Count; i++)
            {
                _tempString.Append(comma);
                _tempString.Append("'" + sc.NursingOrderStateItem[i].StateDefID + "'");
                comma = ",";
            }

            _tempString.Append(") ");

            _filter += _tempString.ToString();

            #endregion

            BindingList<NursingOrderDetail.GetNODByMasterResource_Class> nursingOrderDetailsByMasterResource = NursingOrderDetail.GetNODByMasterResource(_resources, sc.WorkListStartDate.Value, sc.WorkListEndDate.Value, _filter);
            foreach (NursingOrderDetail.GetNODByMasterResource_Class detail in nursingOrderDetailsByMasterResource)
            {
                if (this.HasWorkListWorkListRight(objectContext, detail.ObjectID.Value, "NURSINGORDERDETAIL"))// BASEDEN KULLANILIYOR  
                {
                    NursingModuleWorkListItem nosd = new NursingModuleWorkListItem();

                    DateTime orderEndDate = detail.WorkListDate.Value.AddMinutes(30);
                    nosd.startDate = detail.WorkListDate.Value;
                    nosd.endDate = orderEndDate.Day != nosd.startDate.Day ? detail.WorkListDate.Value.AddMinutes(30 - (orderEndDate.Minute + 1)) : orderEndDate;
                    nosd.PatientNameSurname = detail.Patient_name + ' ' + detail.Patient_surname;
                    nosd.text = detail.Name;

                    Guid state = (Guid)detail.CurrentStateDefID;
                    nosd.stateDefID = state;
                    nosd.statusName = detail.Statusname.ToString();

                    nosd.doctorDescription = detail.Notes;

                    #region Sonuç
                    string _res = string.Empty;

                    VitalSignAndNursingDefinition _vitalSignDef = objectContext.GetObject(detail.Objid.Value, typeof(VitalSignAndNursingDefinition)) as VitalSignAndNursingDefinition;

                    if (_vitalSignDef.VitalSignType == VitalSignType.ANT && detail.Result != null)
                        _res = "Ateş: " + detail.Result;
                    else if (detail.Result != null)
                        _res = "Sonuç: " + detail.Result;

                    _res += detail.Result_Pulse != null ? " Nabız: " + detail.Result_Pulse : "";
                    _res += detail.ResultBloodPressure != null ? " Tan: " + detail.ResultBloodPressure : "";
                    nosd.Result = _res;
                    #endregion

                    nosd.MasterResourceName = detail.Masterresource_name;

                    #region BEDandROOM
                    string _roomBed = string.Empty;

                    if (detail.Room != null)
                        _roomBed = detail.Room.ToString() + " / ";

                    if (detail.Bed != null)
                        _roomBed += detail.Bed.ToString();

                    nosd.RoomAndBedName = _roomBed;
                    #endregion

                    nosd.ResponsibleNurse = detail.Responsiblenurse != null ? detail.Responsiblenurse.ToString() : "";

                    #region HIDDEN COLUMN
                    nosd.DoctorName = detail.Proceduredoctor != null ? detail.Proceduredoctor.ToString() : "";
                    nosd.KabulNo = detail.Kabulno != null ? detail.Kabulno.ToString() : "";
                    nosd.ComingReason = detail.Comingreason != null ? detail.Comingreason.ToString() : "";
                    nosd.PayerInfo = detail.Kurum != null ? detail.Kurum.ToString() : "";
                    nosd.DoctorName = detail.Proceduredoctor != null ? detail.Proceduredoctor.ToString() : "";
                    nosd.BirthDate = detail.BirthDate != null ? detail.BirthDate.Value : new DateTime(0001, 01, 01);
                    nosd.FatherName = detail.FatherName != null ? detail.FatherName.ToString() : "";
                    nosd.PhoneNumber = detail.MobilePhone != null ? detail.MobilePhone.ToString() : "";
                    nosd.UniqueRefno = detail.UniqueRefNo == null ? (detail.YUPASSNO != null ? detail.YUPASSNO.Value.ToString() : "") : detail.UniqueRefNo.Value.ToString();
                    nosd.BasvuruTuru = detail.Basvuruturu == null ? "" : detail.Basvuruturu.ToString();
                    nosd.HastaTuru = detail.Hastaturu == null ? "" : detail.Hastaturu.ToString();

                    if (detail.Episode != null)
                    {
                        Episode _episode = (Episode)objectContext.GetObject((Guid)detail.Episode, "Episode");
                        CompanionApplication _companion = _episode.GetActiveCompanionApplication();
                        nosd.Companion = _companion == null ? "" : _companion.CompanionName;
                    }

                    #endregion

                    #region ICON

                    this.editedSetWorkListIkonProperties(detail.Code, (Patient)objectContext.GetObject((Guid)detail.Patientid, "Patient"), nosd);

                    if (nosd.isPatientDrugAllergic && nosd.isPatientFoodAllergic)
                    {
                        nosd.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                    }
                    else
                    {
                        if (nosd.isPatientDrugAllergic)
                        {
                            nosd.MedicalInformation = "İlaç Alerjisi Var";
                        }

                        if (nosd.isPatientFoodAllergic)
                        {
                            nosd.MedicalInformation = "Gıda Alerjisi Var";
                        }
                    }
                    if (nosd.isPatientOtherAllergic)
                    {
                        nosd.MedicalInformation = "Diğer";
                    }
                    nosd.HasTightContactIsolation = (Boolean)(detail.HasTightContactIsolation == null ? false : detail.HasTightContactIsolation);
                    nosd.HasFallingRisk = (Boolean)(detail.HasFallingRisk == null ? false : detail.HasFallingRisk);
                    nosd.HasDropletIsolation = (Boolean)(detail.HasDropletIsolation == null ? false : detail.HasDropletIsolation);
                    nosd.HasAirborneContactIsolation = (Boolean)(detail.HasAirborneContactIsolation == null ? false : detail.HasAirborneContactIsolation);
                    nosd.HasContactIsolation = (Boolean)(detail.HasContactIsolation == null ? false : detail.HasContactIsolation);
                    #endregion

                    nosd.id = detail.ObjectID.Value;
                    nosd.ObjectID = detail.ObjectID.Value;
                    nosd.ObjectDefName = detail.ObjectDefName;
                    nosd.ObjectDefID = detail.ObjectDefID.Value.ToString();
                    nosd.typeId = OrderTypeEnum.NursingOrder;
                    nosd.typeName = TTUtils.CultureService.GetText("M25918", "Hemşire Direktifi");//OrderTypeEnum.DrugOrder;

                    nosd.OzelDurum = "";

                    nosd.ProcedureByUser = detail.Procedurebyuser != null ? detail.Procedurebyuser : "";

                    nosd.ExecutionDate = detail.ExecutionDate.HasValue ? detail.ExecutionDate.Value : (DateTime?)null;

                    if (nosd.startDate < _rectime)
                    {
                        nosd.RowColor = "#ffa2a2";
                    }

                    WorkList.Add(nosd);
                }
            }
            return WorkList;
        }

        protected List<NursingModuleWorkListItem> GetNursingApplicationWorkList(TTObjectContext objectContext, NursingModuleWorkListSearchCriteria sc, int counter, ResUser CurrentUser, int workListMaxItemCount)
        {
            List<NursingModuleWorkListItem> WorkList = new List<NursingModuleWorkListItem>();

            List<Guid> _resources = sc.Resources.Select(x => x.ObjectID).ToList<Guid>();

            string whereCriteria = string.Empty;
            string whereCriteria_For_InPatientTreatmentClinicApplication = string.Empty;
            string whereCriteria_For_InPatientPhysicianApplication = string.Empty;
            string whereCriteria_For_TreatmentDischarge = string.Empty;
            string whereCriteria_For_DailyInpatient = string.Empty;
            string whereCriteria_For_EmergencyInt = string.Empty;

            bool acception = false, inpatient = false, discharge = false, predischarge = false, dailyInpatient = false;
            int maxWorklistItemCount = 0;

            foreach (var item in sc.InpatientTypeResources)
            {
                if (item.TypeID == 0)
                    acception = true;
                else if (item.TypeID == 1)
                    inpatient = true;
                else if (item.TypeID == 2)
                    discharge = true;
                else if (item.TypeID == 3)
                    predischarge = true;
                else if(item.TypeID == 4)
                     dailyInpatient = true;
            }

            //if (sc.WorkListStartDate == null || sc.WorkListEndDate == null)
            //{
            //    if (sc.consultation_EA || sc.acception || sc.discharge || sc.predischarge) // yanlız inpatient sorgulaması yapılıyorsa dateler boş olabilir 
            //        throw new Exception("Başlangıç Bitiş Tarihi girilmeden sorgulama yapılamaz");
            //}

            if (sc.WorkListStartDate.HasValue)
                sc.WorkListStartDate = Convert.ToDateTime(sc.WorkListStartDate.Value.ToShortDateString() + " " + "00:00:00");

            if (sc.WorkListEndDate.HasValue)
                sc.WorkListEndDate = Convert.ToDateTime(sc.WorkListEndDate.Value.ToShortDateString() + " " + "23:59:59");

            // Hasta seçildi ise diğer sorgular kale alınmayacak Konsültasyon , inPatientPhysicianApplication
            if (!string.IsNullOrEmpty(sc.PatientObjectID))
            {
                whereCriteria_For_InPatientTreatmentClinicApplication = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                whereCriteria_For_InPatientPhysicianApplication = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                whereCriteria_For_TreatmentDischarge = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                whereCriteria_For_DailyInpatient = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                whereCriteria_For_EmergencyInt = " And this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
            }
            else if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                string protocolNoCriteria = "";
                if (sc.ProtocolNo.Contains("-"))
                    protocolNoCriteria = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                else
                {
                    protocolNoCriteria = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";

                }

                whereCriteria_For_InPatientTreatmentClinicApplication = protocolNoCriteria;
                whereCriteria_For_InPatientPhysicianApplication = protocolNoCriteria;
                whereCriteria_For_TreatmentDischarge = protocolNoCriteria;
                whereCriteria_For_DailyInpatient = protocolNoCriteria;
                whereCriteria_For_EmergencyInt = protocolNoCriteria;
            }
            else
            {
                if (sc.Resources == null || sc.Resources.Count == 0)
                    throw new Exception("En az bir birim seçilmeden sorgulama yapılamaz");

                // Birim ile ilgili sorgular 
                string whereCriteria_Resource = string.Empty;
                foreach (var resource in sc.Resources)
                {
                    if (string.IsNullOrEmpty(whereCriteria_Resource))
                        whereCriteria_Resource = " AND this.MASTERRESOURCE IN (''";
                    whereCriteria_Resource += ",'" + resource.ObjectID + "'";
                }
                if (!string.IsNullOrEmpty(whereCriteria_Resource))
                {
                    whereCriteria += whereCriteria_Resource + ") ";
                }


                //Yatış Bekleyen Hasta
                if (acception == true)
                {
                    // Yatışı Bekleyen Hastalar için InPatientTreatmentClinicApplication üzerinden alınan  Sorgu

                    // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                    whereCriteria_For_InPatientTreatmentClinicApplication += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                    // Yanlız kendi Hastalarım sorgusu
                    if (sc.PatientType == 1)
                        whereCriteria_For_InPatientTreatmentClinicApplication += " AND this.ResponsibleNurse = '" + CurrentUser.ObjectID + "'";

                    whereCriteria_For_InPatientTreatmentClinicApplication += whereCriteria;

                }
                //Yatan Hasta ve Taburcu
                if (inpatient == true || discharge == true)
                {
                    // Yatan Ve taburcu olmuş Hastalar için InPatientPhysicianApplication üzerinden alınan Sorgu

                    // Yanlız kendi Hastalarım sorgusu
                    if (sc.PatientType == 1)
                        whereCriteria_For_InPatientPhysicianApplication += " AND this.InPatientTreatmentClinicApp.ResponsibleNurse = '" + CurrentUser.ObjectID + "'";

                    if (inpatient == true && discharge == true)//Yatan Hasta ve Taburcu
                    {
                        // Başlangış - Bitiş Tarihi ile ilgili sorgular 

                        whereCriteria_For_InPatientPhysicianApplication += " AND this.CURRENTSTATEDEFID = States.Application " +
                               " OR (this.CURRENTSTATEDEFID = States.Discharged AND this.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate) + ") ";

                        whereCriteria_For_EmergencyInt += " AND ((this.CURRENTSTATEDEFID = States.Application AND this.EmergencyIntervention.ENTERANCETIME BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate) +" )" +
                               " OR (this.CURRENTSTATEDEFID = States.Discharged AND this.EmergencyIntervention.DISCHARGETIME BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate) + ")) ";
                    }
                    else if (inpatient == true)
                    {
                        // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                        whereCriteria_For_InPatientPhysicianApplication += " AND this.CURRENTSTATEDEFID = States.Application ";
                        whereCriteria_For_EmergencyInt += " AND this.CURRENTSTATEDEFID = States.Application AND this.EmergencyIntervention.ENTERANCETIME BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate)  ; 
                    }
                    else if (discharge == true)
                    {
                        whereCriteria_For_InPatientPhysicianApplication += " AND this.CURRENTSTATEDEFID = States.Discharged ";
                        // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                        whereCriteria_For_InPatientPhysicianApplication += " AND this.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                        whereCriteria_For_EmergencyInt += " AND this.CURRENTSTATEDEFID = States.Discharged AND this.EmergencyIntervention.DISCHARGETIME BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate) ;
                    }

                    whereCriteria_For_InPatientPhysicianApplication += whereCriteria;
                    whereCriteria_For_EmergencyInt += whereCriteria;
                }

                if (dailyInpatient == true)
                {
                    if (sc.PatientType == 1)
                        whereCriteria_For_DailyInpatient += " AND this.InPatientTreatmentClinicApp.ResponsibleNurse = '" + CurrentUser.ObjectID + "'";

                    whereCriteria_For_DailyInpatient += " AND this.InPatientTreatmentClinicApp.IsDailyOperation = 1";
                    whereCriteria_For_DailyInpatient += " AND this.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                    whereCriteria_For_DailyInpatient += whereCriteria;

                }

                //Ön Taburcu
                if (predischarge == true)
                {
                    // ön taburcu olmuş Hastalar için TreatmentDischarge üzerinden alınan Sorgu

                    // Yanlız kendi Hastalarım sorgusu
                    if (sc.PatientType == 1)
                        whereCriteria_For_TreatmentDischarge += " AND this.InPatientTreatmentClinicApp.ResponsibleNurse = '" + CurrentUser.ObjectID + "' ";

                    whereCriteria_For_TreatmentDischarge += " AND this.CURRENTSTATEDEFID = States.PreDischarge ";
                    // Başlangış - Bitiş Tarihi ile ilgili sorgular 
                    whereCriteria_For_TreatmentDischarge += " AND this.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(sc.WorkListStartDate) + " AND " + GetDateAsString(sc.WorkListEndDate);

                    whereCriteria_For_TreatmentDischarge += whereCriteria;
                }


            }

            // SORGULAR
            if (!string.IsNullOrEmpty(whereCriteria_For_InPatientTreatmentClinicApplication)) // Yatışı Bekleyen Hastalar için InPatientTreatmentClinicApplication üzerinden alınan  Sorgu
            {
                var inPatientTreatmentClinicApplicationList = InPatientTreatmentClinicApplication.GetInPatientTreatClinicAppInAcceptionStateForWL(objectContext, whereCriteria_For_InPatientTreatmentClinicApplication);
                foreach (var treatClinicApp in inPatientTreatmentClinicApplicationList)
                {
                    // GENEL 
                    if (this.HasWorkListWorkListRight(objectContext, treatClinicApp))// BASEDEN KULLANILIYOR  
                    {
                        NursingModuleWorkListItem workListItem = new NursingModuleWorkListItem();
                        //var inpatientAdmission = treatClinicApp.BaseInpatientAdmission;
                        var patient = treatClinicApp.Episode.Patient;
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                        workListItem.ObjectDefID = treatClinicApp.ObjectDef.ID.ToString();
                        workListItem.ObjectDefName = treatClinicApp.ObjectDef.Name.ToString();
                        workListItem.ObjectID = treatClinicApp.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = "";
                        if (treatClinicApp.SubEpisode != null && treatClinicApp.SubEpisode.PatientAdmission != null && treatClinicApp.SubEpisode.PatientAdmission.PriorityStatus != null)
                        {
                            PriorityStatus = treatClinicApp.SubEpisode.PatientAdmission.PriorityStatus.Code;
                        }
                        this.editedSetWorkListIkonProperties(PriorityStatus, patient, workListItem);

                        if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                        {
                            workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                        }
                        else
                        {
                            if (workListItem.isPatientDrugAllergic)
                            {
                                workListItem.MedicalInformation = "İlaç Alerjisi Var";
                            }

                            if (workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "Gıda Alerjisi Var";
                            }
                        }

                        if (workListItem.isPatientOtherAllergic)
                        {
                            workListItem.MedicalInformation = "Diğer";
                        }
                        //workListItem.isEmergency = inpatientAdmission.Emergency == true ? true : false;
                        //

                        //workListItem.HasTightContactIsolation = (Boolean)(inpatientAdmission.HasTightContactIsolation == null ? false : inpatientAdmission.HasTightContactIsolation);
                        //workListItem.HasFallingRisk = (Boolean)(inpatientAdmission.HasFallingRisk == null ? false : inpatientAdmission.HasFallingRisk);
                        //workListItem.HasDropletIsolation = (Boolean)(inpatientAdmission.HasDropletIsolation == null ? false : inpatientAdmission.HasDropletIsolation);
                        //workListItem.HasAirborneContactIsolation = (Boolean)(inpatientAdmission.HasAirborneContactIsolation == null ? false : inpatientAdmission.HasAirborneContactIsolation);
                        //workListItem.HasContactIsolation = (Boolean)(inpatientAdmission.HasContactIsolation == null ? false : inpatientAdmission.HasContactIsolation);

                        if (treatClinicApp.RequestDate.HasValue)
                            workListItem.startDate = treatClinicApp.RequestDate.Value;
                        workListItem.PatientNameSurname = patient.FullName;
                        workListItem.KabulNo = treatClinicApp.SubEpisode == null ? "" : treatClinicApp.SubEpisode.ProtocolNo;
                        workListItem.UniqueRefno = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                        workListItem.text = treatClinicApp.ObjectDef.ApplicationName;
                        workListItem.statusName = "Klinik Kabul";
                        workListItem.MasterResourceName = treatClinicApp.MasterResource.Name;
                        //workListItem.RoomAndBedName = inpatientAdmission.Room == null ? "" : inpatientAdmission.Room.Name + "-" + inpatientAdmission.Bed == null ? "" : inpatientAdmission.Bed.Name;
                        workListItem.DoctorName = treatClinicApp.ProcedureDoctor == null ? "" : treatClinicApp.ProcedureDoctor.Name;

                        workListItem.ResponsibleNurse = treatClinicApp.ResponsibleNurse == null ? "" : treatClinicApp.ResponsibleNurse.Name;//Hemşire Adı

                        if (treatClinicApp.SubEpisode != null && treatClinicApp.SubEpisode.PatientAdmission != null && treatClinicApp.SubEpisode.PatientAdmission.AdmissionType != null)
                        {
                            workListItem.ComingReason = treatClinicApp.SubEpisode.PatientAdmission.AdmissionType.provizyonTipiAdi;// Geliş Sebebi
                        }
                        if (treatClinicApp.Episode != null && treatClinicApp.Episode.Payer != null)
                            workListItem.PayerInfo = treatClinicApp.Episode.Payer.Name;
                        workListItem.BirthDate = patient.BirthDate.HasValue ? patient.BirthDate.Value : new DateTime(0001, 1, 1);// Doğum Tarihi
                        workListItem.FatherName = patient.FatherName;// Baba adı
                        if (patient.PatientAddress != null)
                            workListItem.PhoneNumber = patient.PatientAddress.MobilePhone;// Telefon Numarası

                        workListItem.OzelDurum = "";
                        workListItem.ProcedureByUser = "";
                        workListItem.ExecutionDate = (DateTime?)null;
                        if (treatClinicApp.SubEpisode.PatientAdmission != null)
                        {
                            workListItem.HastaTuru = treatClinicApp.SubEpisode.PatientAdmission.PatientClassGroup == null ? "" : Common.GetDisplayTextOfDataTypeEnum(treatClinicApp.SubEpisode.PatientAdmission.PatientClassGroup);
                            workListItem.BasvuruTuru = treatClinicApp.SubEpisode.PatientAdmission.ApplicationReason == null ? "" : Common.GetDisplayTextOfDataTypeEnum(treatClinicApp.SubEpisode.PatientAdmission.ApplicationReason);
                        }
                        if (treatClinicApp.Episode != null)
                        {
                            CompanionApplication _companion = treatClinicApp.Episode.GetActiveCompanionApplication();
                            workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                        }
                        WorkList.Add(workListItem);
                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }

            if (string.IsNullOrEmpty(sc.PatientObjectID) && String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (!string.IsNullOrEmpty(whereCriteria_For_DailyInpatient)) // Yatan Ve taburcu olmuş Hastalar için InPatientPhysicianApplication üzerinden alınan Sorgu
                {
                    var inPatientPhysicianApplicationList = NursingApplication.GetNursingApplicationForWL(objectContext, whereCriteria_For_DailyInpatient);
                    foreach (var inPPAppFWL in inPatientPhysicianApplicationList)
                    {
                        NursingApplication inPatientPhysicianApplication = (NursingApplication)objectContext.GetObject((Guid)inPPAppFWL.ObjectID, "NursingApplication");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, inPatientPhysicianApplication))// BASEDEN KULLANILIYOR  
                        {
                            NursingModuleWorkListItem workListItem = new NursingModuleWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları

                            workListItem.ObjectDefID = inPPAppFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = inPPAppFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)inPPAppFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = inPPAppFWL.Prioritystatus;

                            if (inPatientPhysicianApplication.Episode != null)
                            {
                                this.editedSetWorkListIkonProperties(PriorityStatus, inPatientPhysicianApplication.Episode.Patient, workListItem);

                                if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                                {
                                    workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                                }
                                else
                                {
                                    if (workListItem.isPatientDrugAllergic)
                                    {
                                        workListItem.MedicalInformation = "İlaç Alerjisi Var";
                                    }

                                    if (workListItem.isPatientFoodAllergic)
                                    {
                                        workListItem.MedicalInformation = "Gıda Alerjisi Var";
                                    }
                                }
                                if (workListItem.isPatientOtherAllergic)
                                {
                                    workListItem.MedicalInformation = "Diğer";
                                }

                            }

                            workListItem.isEmergency = inPPAppFWL.Isemergency == true ? true : false;
                            //

                            workListItem.HasTightContactIsolation = inPPAppFWL.HasTightContactIsolation == true ? true : false;
                            workListItem.HasFallingRisk = inPPAppFWL.HasFallingRisk == true ? true : false;
                            workListItem.HasDropletIsolation = inPPAppFWL.HasDropletIsolation == true ? true : false;
                            workListItem.HasAirborneContactIsolation = inPPAppFWL.HasAirborneContactIsolation == true ? true : false;
                            workListItem.HasContactIsolation = inPPAppFWL.HasContactIsolation == true ? true : false;

                            if (inPPAppFWL.Date != null)
                                workListItem.startDate = Convert.ToDateTime(inPPAppFWL.Date);
                            workListItem.PatientNameSurname = inPPAppFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = inPPAppFWL.Kabulno == null ? "" : inPPAppFWL.Kabulno.ToString();
                            workListItem.UniqueRefno = inPPAppFWL.UniqueRefNo == null ? "" : inPPAppFWL.UniqueRefNo.ToString();
                            workListItem.text = inPPAppFWL.Episodeactionname == null ? "" : inPPAppFWL.Episodeactionname.ToString();
                            workListItem.statusName = inPPAppFWL.Statename == null ? "" : inPPAppFWL.Statename.ToString();
                            workListItem.MasterResourceName = inPPAppFWL.Masterresource == null ? "" : inPPAppFWL.Masterresource.ToString(); ;
                            workListItem.RoomAndBedName = inPPAppFWL.Roombed == null ? "" : inPPAppFWL.Roombed.ToString();
                            workListItem.DoctorName = inPPAppFWL.Doctorname == null ? "" : inPPAppFWL.Doctorname.ToString();

                            workListItem.ResponsibleNurse = inPPAppFWL.Nursename == null ? "" : inPPAppFWL.Nursename.ToString();  //Hemşire Adı
                            workListItem.ComingReason = inPPAppFWL.Admissiontype == null ? "" : inPPAppFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerInfo = inPPAppFWL.Payername == null ? "" : inPPAppFWL.Payername.ToString();
                            if (inPPAppFWL.BirthDate != null)
                                workListItem.BirthDate = inPPAppFWL.BirthDate.Value;// Doğum Tarihi
                            else
                                workListItem.BirthDate = new DateTime(0001, 1, 1);// Doğum Tarihi

                            workListItem.FatherName = inPPAppFWL.FatherName == null ? "" : inPPAppFWL.FatherName.ToString();  // Baba adı
                            workListItem.PhoneNumber = inPPAppFWL.Telno == null ? "" : inPPAppFWL.Telno.ToString();  // Telefon Numarası
                            workListItem.OzelDurum = "";
                            workListItem.ProcedureByUser = "";
                            workListItem.ExecutionDate = (DateTime?)null;
                            workListItem.HastaTuru = inPPAppFWL.Hastaturu == null ? "" : inPPAppFWL.Hastaturu.ToString();
                            workListItem.BasvuruTuru = inPPAppFWL.Basvuruturu == null ? "" : inPPAppFWL.Basvuruturu.ToString();
                            if (inPPAppFWL.Episode != null)
                            {
                                Episode _episode = (Episode)objectContext.GetObject((Guid)inPPAppFWL.Episode, "Episode");
                                if (_episode.CompanionApplications.Count > 0)
                                {
                                    CompanionApplication _companion = _episode.GetActiveCompanionApplication();
                                    workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                                }
                            }
                            WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }

            }
            if (!string.IsNullOrEmpty(whereCriteria_For_InPatientPhysicianApplication)) // Yatan Ve taburcu olmuş Hastalar için InPatientPhysicianApplication üzerinden alınan Sorgu
            {
                var inPatientPhysicianApplicationList = NursingApplication.GetNursingApplicationForWL(objectContext, whereCriteria_For_InPatientPhysicianApplication);
                foreach (var inPPAppFWL in inPatientPhysicianApplicationList)
                {
                    NursingApplication inPatientPhysicianApplication = (NursingApplication)objectContext.GetObject((Guid)inPPAppFWL.ObjectID, "NursingApplication");
                    // GENEL 
                    if (this.HasWorkListWorkListRight(objectContext, inPatientPhysicianApplication))// BASEDEN KULLANILIYOR  
                    {
                        NursingModuleWorkListItem workListItem = new NursingModuleWorkListItem();
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları

                        workListItem.ObjectDefID = inPPAppFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = inPPAppFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)inPPAppFWL.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = inPPAppFWL.Prioritystatus;

                        if (inPatientPhysicianApplication.Episode != null)
                        {
                            this.editedSetWorkListIkonProperties(PriorityStatus, inPatientPhysicianApplication.Episode.Patient, workListItem);

                            if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                            }
                            else
                            {
                                if (workListItem.isPatientDrugAllergic)
                                {
                                    workListItem.MedicalInformation = "İlaç Alerjisi Var";
                                }

                                if (workListItem.isPatientFoodAllergic)
                                {
                                    workListItem.MedicalInformation = "Gıda Alerjisi Var";
                                }
                            }
                            if (workListItem.isPatientOtherAllergic)
                            {
                                workListItem.MedicalInformation = "Diğer";
                            }

                        }

                        workListItem.isEmergency = inPPAppFWL.Isemergency == true ? true : false;
                        //

                        workListItem.HasTightContactIsolation = inPPAppFWL.HasTightContactIsolation == true ? true : false;
                        workListItem.HasFallingRisk = inPPAppFWL.HasFallingRisk == true ? true : false;
                        workListItem.HasDropletIsolation = inPPAppFWL.HasDropletIsolation == true ? true : false;
                        workListItem.HasAirborneContactIsolation = inPPAppFWL.HasAirborneContactIsolation == true ? true : false;
                        workListItem.HasContactIsolation = inPPAppFWL.HasContactIsolation == true ? true : false;

                        if (inPPAppFWL.Date != null)
                            workListItem.startDate = Convert.ToDateTime(inPPAppFWL.Date);
                        workListItem.PatientNameSurname = inPPAppFWL.Patientnamesurname.ToString();
                        workListItem.KabulNo = inPPAppFWL.Kabulno == null ? "" : inPPAppFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = inPPAppFWL.UniqueRefNo == null ? "" : inPPAppFWL.UniqueRefNo.ToString();
                        workListItem.text = inPPAppFWL.Episodeactionname == null ? "" : inPPAppFWL.Episodeactionname.ToString();
                        workListItem.statusName = inPPAppFWL.Statename == null ? "" : inPPAppFWL.Statename.ToString();
                        workListItem.MasterResourceName = inPPAppFWL.Masterresource == null ? "" : inPPAppFWL.Masterresource.ToString(); ;
                        workListItem.RoomAndBedName = inPPAppFWL.Roombed == null ? "" : inPPAppFWL.Roombed.ToString();
                        workListItem.DoctorName = inPPAppFWL.Doctorname == null ? "" : inPPAppFWL.Doctorname.ToString();

                        workListItem.ResponsibleNurse = inPPAppFWL.Nursename == null ? "" : inPPAppFWL.Nursename.ToString();  //Hemşire Adı
                        workListItem.ComingReason = inPPAppFWL.Admissiontype == null ? "" : inPPAppFWL.Admissiontype.ToString();  // Geliş Sebebi
                        workListItem.PayerInfo = inPPAppFWL.Payername == null ? "" : inPPAppFWL.Payername.ToString();
                        if (inPPAppFWL.BirthDate != null)
                            workListItem.BirthDate = inPPAppFWL.BirthDate.Value;// Doğum Tarihi
                        else
                            workListItem.BirthDate = new DateTime(0001, 1, 1);// Doğum Tarihi

                        workListItem.FatherName = inPPAppFWL.FatherName == null ? "" : inPPAppFWL.FatherName.ToString();  // Baba adı
                        workListItem.PhoneNumber = inPPAppFWL.Telno == null ? "" : inPPAppFWL.Telno.ToString();  // Telefon Numarası
                        workListItem.OzelDurum = "";
                        workListItem.ProcedureByUser = "";
                        workListItem.ExecutionDate = (DateTime?)null;
                        workListItem.HastaTuru = inPPAppFWL.Hastaturu == null ? "" : inPPAppFWL.Hastaturu.ToString();
                        workListItem.BasvuruTuru = inPPAppFWL.Basvuruturu == null ? "" : inPPAppFWL.Basvuruturu.ToString();
                        if (inPPAppFWL.Episode != null)
                        {
                            Episode _episode = (Episode)objectContext.GetObject((Guid)inPPAppFWL.Episode, "Episode");
                            if (_episode.CompanionApplications.Count > 0)
                            {
                                CompanionApplication _companion = _episode.GetActiveCompanionApplication();
                                workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                            }
                        }
                        WorkList.Add(workListItem);
                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }
            if (!string.IsNullOrEmpty(whereCriteria_For_TreatmentDischarge))// ön taburcu olmuş Hastalar için TreatmentDischarge üzerinden alınan Sorgu
            {
                var treatmentDischargeList = TreatmentDischarge.GetTreatmentDischargeForWL(objectContext, whereCriteria_For_TreatmentDischarge);
                foreach (var tdFWL in treatmentDischargeList)
                {
                    TreatmentDischarge treatmentDischarge = (TreatmentDischarge)objectContext.GetObject((Guid)tdFWL.ObjectID, "TreatmentDischarge");
                    // GENEL 
                    if (this.HasWorkListWorkListRight(objectContext, treatmentDischarge))// BASEDEN KULLANILIYOR  
                    {
                        NursingModuleWorkListItem workListItem = new NursingModuleWorkListItem();
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları

                        workListItem.ObjectDefID = tdFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = tdFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)tdFWL.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = tdFWL.Prioritystatus;
                        //this.setWorkListIkonPropertyies(PriorityStatus, treatmentDischarge.Episode.Patient, workListItem);
                        this.editedSetWorkListIkonProperties(PriorityStatus, treatmentDischarge.Episode.Patient, workListItem);

                        if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                        {
                            workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                        }
                        else
                        {
                            if (workListItem.isPatientDrugAllergic)
                            {
                                workListItem.MedicalInformation = "İlaç Alerjisi Var";
                            }

                            if (workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "Gıda Alerjisi Var";
                            }
                        }

                        if (workListItem.isPatientOtherAllergic)
                        {
                            workListItem.MedicalInformation = "Diğer";
                        }
                        workListItem.isEmergency = tdFWL.Isemergency == true ? true : false;
                        //

                        workListItem.HasTightContactIsolation = tdFWL.HasTightContactIsolation == true ? true : false;
                        workListItem.HasFallingRisk = tdFWL.HasFallingRisk == true ? true : false;
                        workListItem.HasDropletIsolation = tdFWL.HasDropletIsolation == true ? true : false;
                        workListItem.HasAirborneContactIsolation = tdFWL.HasAirborneContactIsolation == true ? true : false;
                        workListItem.HasContactIsolation = tdFWL.HasContactIsolation == true ? true : false;

                        if (tdFWL.Date != null)
                            workListItem.startDate = Convert.ToDateTime(tdFWL.Date);
                        workListItem.PatientNameSurname = tdFWL.Patientnamesurname.ToString();
                        workListItem.KabulNo = tdFWL.Kabulno == null ? "" : tdFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = tdFWL.UniqueRefNo == null ? "" : tdFWL.UniqueRefNo.ToString();
                        workListItem.text = tdFWL.Episodeactionname == null ? "" : tdFWL.Episodeactionname.ToString();
                        workListItem.statusName = tdFWL.Statename == null ? "" : tdFWL.Statename.ToString();
                        workListItem.MasterResourceName = tdFWL.Masterresource == null ? "" : tdFWL.Masterresource.ToString(); ;
                        workListItem.RoomAndBedName = tdFWL.Roombed == null ? "" : tdFWL.Roombed.ToString();
                        workListItem.DoctorName = tdFWL.Doctorname == null ? "" : tdFWL.Doctorname.ToString();

                        workListItem.ResponsibleNurse = tdFWL.Nursename == null ? "" : tdFWL.Nursename.ToString();  //Hemşire Adı
                        workListItem.ComingReason = tdFWL.Admissiontype == null ? "" : tdFWL.Admissiontype.ToString();  // Geliş Sebebi
                        workListItem.PayerInfo = tdFWL.Payername == null ? "" : tdFWL.Payername.ToString();
                        if (tdFWL.BirthDate != null)
                            workListItem.BirthDate = tdFWL.BirthDate.Value;// Doğum Tarihi
                        else
                            workListItem.BirthDate = new DateTime(0001, 1, 1);// Doğum Tarihi

                        workListItem.FatherName = tdFWL.FatherName == null ? "" : tdFWL.FatherName.ToString();  // Baba adı
                        workListItem.PhoneNumber = tdFWL.Telno == null ? "" : tdFWL.Telno.ToString();  // Telefon Numarası

                        //Taburcu işlemi açıldığında default olarak InPatientPhysicianApplication açılsın diye
                        foreach (var nursingApplication in treatmentDischarge.InPatientTreatmentClinicApp.NursingApplications)
                        {
                            TreatmentDischarge.TreatmentDischargeDefaultActionViewModel defaultActionViewModel = new TreatmentDischarge.TreatmentDischargeDefaultActionViewModel();
                            defaultActionViewModel.ObjectDefName = nursingApplication.ObjectDef.Name;
                            defaultActionViewModel.ApplicationName = nursingApplication.ObjectDef.ApplicationName;
                            defaultActionViewModel.ObjectId = nursingApplication.ObjectID;
                            workListItem.CompComponetOpeningInputParam = defaultActionViewModel;
                            break;
                        }

                        workListItem.OzelDurum = "";
                        workListItem.ProcedureByUser = "";
                        workListItem.ExecutionDate = (DateTime?)null;
                        workListItem.HastaTuru = tdFWL.Hastaturu == null ? "" : tdFWL.Hastaturu.ToString();
                        workListItem.BasvuruTuru = tdFWL.Basvuruturu == null ? "" : tdFWL.Basvuruturu.ToString();
                        if (tdFWL.Episode != null)
                        {
                            Episode _episode = (Episode)objectContext.GetObject((Guid)tdFWL.Episode, "Episode");
                            CompanionApplication _companion = _episode.GetActiveCompanionApplication();
                            workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                        }
                        WorkList.Add(workListItem);

                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }
            if (!string.IsNullOrEmpty(whereCriteria_For_EmergencyInt)) // Acil Müşahedeye ALınan Hastalar
            {
                var inPatientPhysicianApplicationList = NursingApplication.GetEmergencyNursingAppForWL(objectContext, whereCriteria_For_EmergencyInt);
                foreach (var inPPAppFWL in inPatientPhysicianApplicationList)
                {
                    NursingApplication inPatientPhysicianApplication = (NursingApplication)objectContext.GetObject((Guid)inPPAppFWL.ObjectID, "NursingApplication");
                    // GENEL 
                    if (this.HasWorkListWorkListRight(objectContext, inPatientPhysicianApplication))// BASEDEN KULLANILIYOR  
                    {
                        NursingModuleWorkListItem workListItem = new NursingModuleWorkListItem();
                        //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları

                        workListItem.ObjectDefID = inPPAppFWL.ObjectDefID.ToString();
                        workListItem.ObjectDefName = inPPAppFWL.ObjectDefName;
                        workListItem.ObjectID = (Guid)inPPAppFWL.ObjectID;
                        // Ikon set etmece
                        string PriorityStatus = inPPAppFWL.Prioritystatus;

                        if (inPatientPhysicianApplication.Episode != null)
                        {
                            this.editedSetWorkListIkonProperties(PriorityStatus, inPatientPhysicianApplication.Episode.Patient, workListItem);

                            if (workListItem.isPatientDrugAllergic && workListItem.isPatientFoodAllergic)
                            {
                                workListItem.MedicalInformation = "İlaç ve Besin Alerjisi Var";
                            }
                            else
                            {
                                if (workListItem.isPatientDrugAllergic)
                                {
                                    workListItem.MedicalInformation = "İlaç Alerjisi Var";
                                }

                                if (workListItem.isPatientFoodAllergic)
                                {
                                    workListItem.MedicalInformation = "Gıda Alerjisi Var";
                                }
                            }
                            if (workListItem.isPatientOtherAllergic)
                            {
                                workListItem.MedicalInformation = "Diğer";
                            }

                        }

                        workListItem.isEmergency =  true ;
                        //

                        workListItem.HasTightContactIsolation =  false;
                        workListItem.HasFallingRisk =  false;
                        workListItem.HasDropletIsolation =  false;
                        workListItem.HasAirborneContactIsolation =  false;
                        workListItem.HasContactIsolation =  false;

                        if (inPPAppFWL.Date != null)
                            workListItem.startDate = Convert.ToDateTime(inPPAppFWL.Date);
                        workListItem.PatientNameSurname = inPPAppFWL.Patientnamesurname.ToString();
                        workListItem.KabulNo = inPPAppFWL.Kabulno == null ? "" : inPPAppFWL.Kabulno.ToString();
                        workListItem.UniqueRefno = inPPAppFWL.UniqueRefNo == null ? "" : inPPAppFWL.UniqueRefNo.ToString();
                        workListItem.text = inPPAppFWL.Episodeactionname == null ? "" : inPPAppFWL.Episodeactionname.ToString();
                        workListItem.statusName = inPPAppFWL.Statename == null ? "" : inPPAppFWL.Statename.ToString();
                        workListItem.MasterResourceName = inPPAppFWL.Masterresource == null ? "" : inPPAppFWL.Masterresource.ToString(); ;
                        workListItem.RoomAndBedName = "";
                        workListItem.DoctorName = "";

                        workListItem.ResponsibleNurse = "";
                        workListItem.ComingReason = inPPAppFWL.Admissiontype == null ? "" : inPPAppFWL.Admissiontype.ToString();  // Geliş Sebebi
                        workListItem.PayerInfo = inPPAppFWL.Payername == null ? "" : inPPAppFWL.Payername.ToString();
                        if (inPPAppFWL.BirthDate != null)
                            workListItem.BirthDate = inPPAppFWL.BirthDate.Value;// Doğum Tarihi
                        else
                            workListItem.BirthDate = new DateTime(0001, 1, 1);// Doğum Tarihi

                        workListItem.FatherName = inPPAppFWL.FatherName == null ? "" : inPPAppFWL.FatherName.ToString();  // Baba adı
                        workListItem.PhoneNumber = inPPAppFWL.Telno == null ? "" : inPPAppFWL.Telno.ToString();  // Telefon Numarası
                        workListItem.OzelDurum = "";
                        workListItem.ProcedureByUser = "";
                        workListItem.ExecutionDate = (DateTime?)null;
                        workListItem.HastaTuru = inPPAppFWL.Hastaturu == null ? "" : inPPAppFWL.Hastaturu.ToString();
                        workListItem.BasvuruTuru = inPPAppFWL.Basvuruturu == null ? "" : inPPAppFWL.Basvuruturu.ToString();
                        if (inPPAppFWL.Episode != null)
                        {
                            Episode _episode = (Episode)objectContext.GetObject((Guid)inPPAppFWL.Episode, "Episode");
                            if (_episode.CompanionApplications.Count > 0)
                            {
                                CompanionApplication _companion = _episode.GetActiveCompanionApplication();
                                workListItem.Companion = _companion == null ? "" : _companion.CompanionName;
                            }
                        }
                        WorkList.Add(workListItem);
                        // GENEL 
                        counter++;
                        if (counter > workListMaxItemCount)
                        {
                            maxWorklistItemCount += counter;
                            break;
                        }
                        //
                    }
                }
            }

            WorkList = WorkList.OrderByDescending(dr => dr.startDate).ToList();

            return WorkList;


        }

        #region LUZUMU HALINDE

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public List<CostomDrugOrder> Get_caseOfNeeDrugOrder(NursingModuleWorkListSearchCriteria input)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            NursingWorkListViewModel model = new NursingWorkListViewModel();
            OutputCaseOFNeedDrugOrder OutputCaseOFNeedDrugOrder = new OutputCaseOFNeedDrugOrder();
            List<CostomDrugOrder> itemDrurOrders = new List<CostomDrugOrder>();

            string _filter = string.Empty;

            if (!Common.CurrentUser.IsSuperUser && input.PatientType == 1)
            {
                _filter = " AND THIS.NursingApplication.InPatientTreatmentClinicApp.ResponsibleNurse='" + Common.CurrentUser.TTObjectID.Value + "'";
            }

            ControlResourceList(input.Resources);

            List<Guid> _resources = input.Resources.Select(x => x.ObjectID).ToList<Guid>();

            BindingList<DrugOrder.GetCaseOfNeedsDrugOrderRQ_Class> drugOrderDetailsByCaseOfNeed = DrugOrder.GetCaseOfNeedsDrugOrderRQ(_resources, input.WorkListStartDate.Value, input.WorkListEndDate.Value, _filter);
            foreach (DrugOrder.GetCaseOfNeedsDrugOrderRQ_Class drugOrderItem in drugOrderDetailsByCaseOfNeed)
            {
                DrugOrder drugOrder = (DrugOrder)objectContext.GetObject((Guid)drugOrderItem.ObjectID, TTObjectDefManager.Instance.ObjectDefs[typeof(DrugOrder).Name], false);
                CostomDrugOrder costomDrugOrder = new CostomDrugOrder();
                costomDrugOrder.objectId = drugOrder.ObjectID.ToString();
                costomDrugOrder.PlannedDateTime = (DateTime)drugOrder.PlannedStartTime;
                costomDrugOrder.PatientName = drugOrder.Episode.Patient.FullName;
                costomDrugOrder.DrugName = drugOrder.Material.Name;
                costomDrugOrder.DrugBarcode = drugOrder.Material.Barcode;
                costomDrugOrder.MasterResourceName = drugOrder.MasterResource.Store.Name;
                costomDrugOrder.DoseAmount = drugOrder.DoseAmount.ToString();
                itemDrurOrders.Add(costomDrugOrder);
            }

            List<CostomDrugOrder> tempList = new List<CostomDrugOrder>();
            List<CostomDrugOrder> blackList = new List<CostomDrugOrder>();
            //ATTENTION : Buraya gelen itemDrurOrders queryden order yapılmış biçimde gelmekte.Aksi taktirde çalışmaz.
            foreach (CostomDrugOrder or in itemDrurOrders)
            {
                if (blackList.Contains(or) == true)
                    continue;

                CostomDrugOrder temp = or;
                foreach (CostomDrugOrder or2 in itemDrurOrders)
                {
                    if (blackList.Contains(or2) == true)
                        continue;

                    if (temp == or2)
                    {
                        if (tempList.Contains(temp) == false)
                            tempList.Add(temp);
                        continue;
                    }

                    if (or.PatientName == or2.PatientName && or.DrugBarcode == or2.DrugBarcode)
                    {
                        if (or.PlannedDateTime > or2.PlannedDateTime)
                        {
                            temp = or;
                            TTObjectContext context = new TTObjectContext(false);
                            DrugOrder drugOrder = (DrugOrder)context.GetObject(new Guid(or2.objectId), TTObjectDefManager.Instance.ObjectDefs[typeof(DrugOrder).Name], false);
                            drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
                            context.Save();
                            context.Dispose();
                            blackList.Add(or2);
                        }
                        else
                        {
                            temp = or2;
                            TTObjectContext context = new TTObjectContext(false);
                            DrugOrder drugOrder = (DrugOrder)context.GetObject(new Guid(or.objectId), TTObjectDefManager.Instance.ObjectDefs[typeof(DrugOrder).Name], false);
                            drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
                            context.Save();
                            context.Dispose();
                            blackList.Add(or);
                        }
                    }
                    if (tempList.Contains(temp) == false)
                        tempList.Add(temp);
                }

            }

            if (tempList.Count > 0)
                itemDrurOrders = tempList;

            return itemDrurOrders;
        }

        private void ControlResourceList(List<ResSection> resources)
        {
            if (resources == null || resources.Count == 0)
                throw new Exception("En az bir birim seçilmeden direktif sorgulaması yapılamaz");
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public string Create_CaseOfNeeDrugOrder(List<CostomDrugOrder> input)
        {
            NursingWorkListViewModel model = new NursingWorkListViewModel();
            string mesaj = string.Empty;

            foreach (CostomDrugOrder drugOrderItem in input)
            {
                DateTime drugApplicationTimeBegin = Common.RecTime().AddDays(-1);
                if (Common.RecTime().AddDays(-1) > (DateTime)drugOrderItem.PlannedDateTime)
                {
                    mesaj = TTUtils.CultureService.GetText("M25695", "Geçmiş güne ait ilaç istenemez.");
                    continue;
                }

                TTObjectContext objectContext = new TTObjectContext(false);
                DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(new Guid(drugOrderItem.objectId), TTObjectDefManager.Instance.ObjectDefs[typeof(DrugOrder).Name], false);

                drugOrder.CurrentStateDefID = DrugOrder.States.Approve;
                objectContext.Update();
                drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
                objectContext.Update();
                objectContext.Save();
                KSchedule kScheduleNew = new KSchedule(objectContext);
                kScheduleNew.StartDate = Common.RecTime();
                Store pharmacy = Store.GetPharmacyStore(objectContext);
                if (pharmacy != null)
                {
                    kScheduleNew.Store = pharmacy;
                }

                kScheduleNew.DestinationStore = drugOrder.MasterResource.Store;
                kScheduleNew.Episode = drugOrder.Episode;
                kScheduleNew.InPatientPhysicianApplication = drugOrder.InPatientPhysicianApplication;
                kScheduleNew.MKYS_TeslimAlanObjID = Common.CurrentUser.UserObject.ObjectID;
                kScheduleNew.MKYS_TeslimAlan = ((ResUser)Common.CurrentUser.UserObject).Name;
                kScheduleNew.CurrentStateDefID = KSchedule.States.New;
                kScheduleNew.Update();
                kScheduleNew.CurrentStateDefID = KSchedule.States.Approval;
                kScheduleNew.Update();
                kScheduleNew.CurrentStateDefID = KSchedule.States.RequestPreparation;

                if (drugOrder.PatientOwnDrug != null && drugOrder.PatientOwnDrug == true)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("HIMSSINTEGRATED", "FALSE") == "TRUE")
                    {
                        if (drugOrder.MasterResource != null && drugOrder.MasterResource.HimssRequired != null)
                        {
                            if (drugOrder.MasterResource.HimssRequired == true)
                            {
                                double amountRes = 0;
                                foreach (DrugOrderDetail drugOrderDetail in drugOrder.DrugOrderDetails)
                                {
                                    DrugOrderDetail orderDetail = (DrugOrderDetail)objectContext.GetObject((Guid)drugOrderDetail.ObjectID, typeof(DrugOrderDetail));
                                    if (orderDetail.Amount != null)
                                        amountRes += (double)orderDetail.Amount.Value;
                                }
                                BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> getRestAmountList = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(drugOrder.Episode.ObjectID, drugOrder.Material.ObjectID);
                                if (getRestAmountList.Count > 0)
                                {
                                    if ((double)getRestAmountList[0].Restamount < amountRes)
                                    {
                                        throw new Exception(drugOrder.Material.Name + " isimli malzemenin mevcudu yetersizdir.");
                                    }
                                }
                            }
                        }
                    }

                    double amount = 0;
                    KSchedulePatienOwnDrug kSchedulePatienOwnDrug = new KSchedulePatienOwnDrug(objectContext);
                    foreach (DrugOrderDetail detail in drugOrder.DrugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)objectContext.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                        kSchedulePatienOwnDrug.DrugOrderDetails.Add(drugOrderDetail);
                        if (drugOrderDetail.Amount != null)
                            amount += (double)drugOrderDetail.Amount.Value;
                    }
                    kSchedulePatienOwnDrug.DrugAmount = amount;
                    kSchedulePatienOwnDrug.Material = drugOrder.Material;
                    kSchedulePatienOwnDrug.BarcodeVerifyCounter = 0;
                    kSchedulePatienOwnDrug.KSchedule = kScheduleNew;
                    kSchedulePatienOwnDrug.StockActionStatus = StockActionDetailStatusEnum.New;


                    BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> trxList = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(drugOrder.Episode.ObjectID, drugOrder.Material.ObjectID);
                    if (trxList.Count > 0)
                    {
                        if (trxList[0].ExpirationDate != null)
                            kSchedulePatienOwnDrug.ExpirationDate = trxList[0].ExpirationDate;
                        else
                            kSchedulePatienOwnDrug.ExpirationDate = DateTime.MinValue;
                    }

                    if (kSchedulePatienOwnDrug.ExpirationDate == null)
                        kSchedulePatienOwnDrug.ExpirationDate = DateTime.MinValue;
                }
                else
                {
                    KScheduleMaterial ksmaterial = new KScheduleMaterial(objectContext);
                    ksmaterial.RequestAmount = drugOrder.Amount;
                    ksmaterial.Amount = drugOrder.Amount;
                    ksmaterial.Material = drugOrder.Material;
                    ksmaterial.BarcodeVerifyCounter = 0;
                    ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                    kScheduleNew.KScheduleMaterials.Add(ksmaterial);
                    KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(objectContext);
                    foreach (DrugOrderDetail detail in drugOrder.DrugOrderDetails.Select(string.Empty))
                    {
                        DrugOrderDetail updateDetail = (DrugOrderDetail)objectContext.GetObject(detail.ObjectID, typeof(DrugOrderDetail));
                        updateDetail.KScheduleCollectedOrder = null;
                        kScheduleCollectedOrder.DrugOrderDetails.Add(updateDetail);
                        detail.CurrentStateDefID = DrugOrderDetail.States.Request;
                    }
                    ksmaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;
                    kScheduleNew.EndDate = ((DateTime)(Common.RecTime()).AddDays(drugOrder.Day.Value));
                }

                objectContext.Save();
                objectContext.Dispose();
                mesaj = ((StockAction)kScheduleNew).StockActionID.ToString() + TTUtils.CultureService.GetText("M26210", "İşlem numarası ile Ecz. istendi.");
            }

            return mesaj;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public NursingWorkListViewModel controlOfPharmacyOpenned()
        {
            NursingWorkListViewModel model = new NursingWorkListViewModel();
            model.pharmcyOpen = false;

            int orderHourOpen = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("PHARMACYOPENEDTIMEPARAM", "7"));//açılış saati
            int orderHourClose = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("PHARMACYCLOSEDTIMEPARAM", "18"));//kapanış saati
            int orderHoliday = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("PHARMACYCLOSEDDAYSPARAM", "0"));//ecz tatil günü

            if (Common.RecTime().Hour < orderHourClose && Common.RecTime().Hour > orderHourOpen)
                model.pharmcyOpen = true;
            if (Common.RecTime().DayOfWeek == DayOfWeek.Sunday || Common.RecTime().DayOfWeek == DayOfWeek.Saturday)
                model.pharmcyOpen = false;
            if (orderHoliday > 0)
                model.pharmcyOpen = false;

            return model;
        }

        #endregion

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public bool Get_UsercontrolTool()
        {
            bool gicActive = false;
            if (TTObjectClasses.SystemParameter.GetParameterValue("DAILYDRUGSCHORDERBYPASS", "FALSE") == "TRUE")
            {
                gicActive = false;
            }
            else
            {
                gicActive = true;
            }
            return gicActive;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public void StateUpdateForSelecetedItem(InputFor_StateUpdateForSelecetedItem input)
        {
            TTObjectContext context = new TTObjectContext(false);
            foreach (Guid item in input.DrugOrderDetails)
            {
                DrugOrderDetail drugOrderDet = (DrugOrderDetail)context.GetObject(item, TTObjectDefManager.Instance.ObjectDefs[typeof(DrugOrderDetail).Name], false);
                if (drugOrderDet != null)
                {
                    if (drugOrderDet.CurrentStateDefID == DrugOrderDetail.States.UseRestDose || drugOrderDet.CurrentStateDefID == DrugOrderDetail.States.Supply)
                    {
                        drugOrderDet.CurrentStateDefID = DrugOrderDetail.States.Apply;
                    }
                }
            }
            context.Save();
        }

        public override int WorkListRightDefID(string objectType)
        {
            if (objectType == "DRUGORDERDETAIL")
                return 1023;
            else
                return 1001;
        }

        //başındaki rakamlardan kurtulmak için - rakamlar sıralama için lazımdı
        public string FormatDrugOrderStatusName(string statusName)
        {
            string newStatus = string.Empty;

            newStatus = statusName.Substring(statusName.IndexOf("-") + 1, statusName.Length - statusName.IndexOf("-") - 1);

            return newStatus;

        }
        public string ChangeStatusName(Guid id)
        {
            string statusName = string.Empty;

            switch (id.ToString())
            {
                case "cb22e74b-a2be-456f-8680-660d0b21dc24": // plan
                    statusName = TTUtils.CultureService.GetText("M25573", "Eczaneden İstenmedi!");
                    break;
                case "da01e671-efb9-4d84-8122-4bae07e08c20": //İstek
                    statusName = TTUtils.CultureService.GetText("M25572", "Eczaneden İstendi");
                    break;
                case "94c4b7eb-b764-4ca5-add6-76e2217f7dd4": //Hastanın Üzerinde
                    statusName = TTUtils.CultureService.GetText("M25385", "Var Olan Kullanım");
                    break;
                case "d4f85132-8d05-4dc7-b9b2-fc04bae622b0": // Karşılandı
                    statusName = TTUtils.CultureService.GetText("M25571", "Eczaneden İstendi Eczane Tarafından Karşılandı!");
                    break;
                case "ad54f2c0-8ebe-4fbb-a57a-b7c870fd1fb3": // Eczacılık Bilimlerinden İstendi
                    statusName = "Eczacılık Bilimlerinden İstendi";
                    break;
                case "f1b24e44-ecb3-4b44-9b23-1d77e9901721": //Durdur
                    statusName = TTUtils.CultureService.GetText("M25549", "Durduruldu");
                    break;
                case "14ea4626-5b27-4663-82f9-64968cb4eb63": //Hastaya Teslim
                    statusName = TTUtils.CultureService.GetText("M25771", "Hasta / Hasta Yakınına teslim edildi.");
                    break;
                case "d39a37a6-610e-4143-aca2-691ce5818915": //Uygulandı
                    statusName = TTUtils.CultureService.GetText("M27138", "Uygulandı");
                    break;
                case "add6e452-c007-4849-b477-17d30400abe8": //İptal
                    statusName = TTUtils.CultureService.GetText("M27135", "Uygulama İptal Edildi!");
                    break;
                case "0586979d-523c-4800-995c-750ac3984606": //Dış Eczane Tarafından Karşılandı
                    statusName = TTUtils.CultureService.GetText("M25431", "Dış Eczane Tarafından Karşılandı");
                    break;
                case "4223ab9b-1b9f-4f59-845f-b903adcda8a0"://Eczaneye İade
                    statusName = TTUtils.CultureService.GetText("M25574", "Eczaneye İade");
                    break;
                default:
                    statusName = TTUtils.CultureService.GetText("M27042", "Tanımsız durum.Lütfen sistem yöneticisine başvurun!!");
                    break;
            }
            return statusName;
        }


        [HttpPost]
        public List<BaseTreatmentMaterial.GetUnnotifiedUsedMaterialBySource_Class> GetUnnotifiedBaseTreatmentMaterialToUTS(InputFor_UnnotifiedBaseTreatmentMaterialToUTS input)
        {
            List<BaseTreatmentMaterial.GetUnnotifiedUsedMaterialBySource_Class> results = new List<BaseTreatmentMaterial.GetUnnotifiedUsedMaterialBySource_Class>();
            using (var objectContext = new TTObjectContext(false))
            {
                var unnotifiedStockTransactions = StockTransaction.UTS_GetUnnotifiedStockTransactions(objectContext);
                List<Guid> StockActionDetailIds = unnotifiedStockTransactions.Select(x => x.ObjectID.Value).Distinct().ToList();

                int listMaxSize = 900;
                int loopCount = StockActionDetailIds.Count() / listMaxSize;
                List<Guid> tmpStockActionDetailIds;
                for (int i = 0; i <= loopCount; i++)
                {
                    if (i < loopCount)
                        tmpStockActionDetailIds = StockActionDetailIds.GetRange(i * listMaxSize, listMaxSize);
                    else
                        tmpStockActionDetailIds = StockActionDetailIds.GetRange(i * listMaxSize, StockActionDetailIds.Count() % listMaxSize);
                    if (TTUser.CurrentUser.HasRole(TTRoleNames.UTS_Bildirim_Tum_Depolar) == true)
                        results = results.Concat(BaseTreatmentMaterial.GetUnnotifiedUsedMaterialBySource(objectContext, input.ResourceIds, tmpStockActionDetailIds,true)).ToList();
                    else
                        results = results.Concat(BaseTreatmentMaterial.GetUnnotifiedUsedMaterialBySource(objectContext, input.ResourceIds, tmpStockActionDetailIds, false)).ToList();
                }
            }
            return results;
        }
    }
}

namespace Core.Models
{
    public partial class NursingModuleWorkListViewModel : BaseEpisodeActionWorkListFormViewModel
    {
        public List<NursingModuleWorkListItem> WorkList;
        public NursingModuleWorkListSearchCriteria _SearchCriteria
        {
            get;
            set;
        }

        public List<ResSection> ResourceList { get; set; }

        public List<EpisodeActionWorkListStateItem> DrugOrderWorkListStateItem
        {
            get;
            set;
        }

        public List<EpisodeActionWorkListStateItem> NursingOrderWorkListStateItem
        {
            get;
            set;
        }

        public bool GicActive { get; set; }

        public NursingModuleWorkListViewModel()
        {
            this._SearchCriteria = new NursingModuleWorkListSearchCriteria();
            this.WorkList = new List<NursingModuleWorkListItem>();
        }
    }

    [Serializable]
    public class NursingModuleWorkListSearchCriteria : BaseEpisodeActionWorkListSearchCriteria
    {
        public List<ResSection> Resources { get; set; }
        public List<EpisodeActionWorkListStateItem> DrugOrderStatesItem { get; set; }
        public List<EpisodeActionWorkListStateItem> NursingOrderStateItem { get; set; }
        public List<ListObject> InpatientTypeResources { get; set; }
        public int PatientType { get; set; }
        public int ActionType { get; set; }

        public string ProtocolNo { get; set; }
    }

    public class NursingModuleWorkListItem : BaseEpisodeActionWorkListItem
    {
        public DateTime startDate
        {
            get;
            set;
        }

        public DateTime endDate
        {
            get;
            set;
        }

        public string PatientNameSurname
        {
            get;
            set;
        }

        public string text
        {
            get;
            set;
        }

        public string statusName
        {
            get;
            set;
        }

        public string Result
        {
            get;
            set;
        }

        public string doctorDescription
        {
            get;
            set;
        }

        public string MasterResourceName
        {
            get;
            set;
        }

        public string RoomAndBedName { get; set; }

        public string ResponsibleNurse { get; set; }

        #region HIDDEN COLUMN
        public string DoctorName
        {
            get;
            set;
        }

        public string KabulNo
        {
            get;
            set;
        }

        public string ComingReason { get; set; }

        public string PayerInfo { get; set; }

        public DateTime BirthDate { get; set; }

        public string FatherName { get; set; }

        public string PhoneNumber { get; set; }

        public string UniqueRefno
        {
            get;
            set;
        }

        public string HastaTuru { get; set; }

        public string BasvuruTuru { get; set; }

        public string Companion { get; set; }

        public string ProcedureByUser { get; set; }

        public DateTime? ExecutionDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        #endregion

        #region GRIDDE KULLANILMAYAN PROPERTYLER
        public Guid id
        {
            get;
            set;
        }
        public Guid stateDefID
        {
            get;
            set;
        }

        public OrderTypeEnum typeId
        {
            get;
            set;
        }

        public string typeName { get; set; }

        public string StateID
        {
            get;
            set;
        }
        public string Dose
        {
            get;
            set;
        }
        public string UsageType
        {
            get;
            set;
        }
        #endregion

        #region ICONS
        public bool HasTightContactIsolation { get; set; }
        public bool HasFallingRisk { get; set; }
        public bool HasDropletIsolation { get; set; }
        public bool HasAirborneContactIsolation { get; set; }
        public bool HasContactIsolation { get; set; }
        public string OzelDurum { get; set; }
        #endregion
    }


    public class UnnotifiedBaseTreatmentMaterialViewModel
    {
        public Guid ObjectId { get; set; }
        public DateTime? ActionDate { get; set; }
        public string PatientName { get; set; }
        public string StoreName { get; set; }
        public string MaterialName { get; set; }
        public double Amount { get; set; }
        public string Barcode { get; set; }
        public string DistributionType { get; set; }
        public string Notes { get; set; }
        public string UTSUseNotification { get; set; }
    }

}
