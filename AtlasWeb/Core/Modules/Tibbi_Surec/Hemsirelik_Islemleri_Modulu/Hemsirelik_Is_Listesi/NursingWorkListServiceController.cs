using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using TTDefinitionManagement;
using Core.Security;
using System.Collections;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class NursingWorkListServiceController : Controller
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public NursingWorkListViewModel Get_UserResources()
        {
            NursingWorkListViewModel model = new NursingWorkListViewModel();
            List<Resource> userResources = new List<Resource>();
            OutputResource outputResource = new OutputResource();
            if (Common.CurrentUser.IsSuperUser)
            {
                TTObjectContext context = new TTObjectContext(true);
                BindingList<ResSection> resSectionList = ResSection.GetResSections(context, " WHERE ISACTIVE = 1 AND OBJECTDEFNAME IN ('RESCLINIC') ");
                foreach (ResSection rs in resSectionList)
                {
                    userResources.Add(rs);
                }
            }
            else
            {
                foreach (UserResource userResource in Common.CurrentResource.UserResources)
                {
                    if (userResource.Resource is ResClinic && userResource.Resource.IsActive.HasValue && userResource.Resource.IsActive.Value)
                    {
                        userResources.Add(userResource.Resource);
                    }
                }
            }
            outputResource.resources = userResources;
            model.toolOption = Get_UsercontrolTool().toolOption;
            model.output = outputResource;
            model.output.startDate = Common.RecTime().AddHours(-1).AddMinutes(-Common.RecTime().Minute);
            model.output.endDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");


            return model;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public NursingWorkListViewModel Get_UsercontrolTool()
        {
            NursingWorkListViewModel model = new NursingWorkListViewModel();
            if (TTObjectClasses.SystemParameter.GetParameterValue("DAILYDRUGSCHORDERBYPASS", "FALSE") == "TRUE")
            {
                model.toolOption = false;
            }
            else
            {
                model.toolOption = true;
            }
            return model;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public NursingWorkListViewModel Get_caseOfNeeDrugOrder(InputFor_Get_DrugOrderDetails input)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            NursingWorkListViewModel model = new NursingWorkListViewModel();
            OutputCaseOFNeedDrugOrder OutputCaseOFNeedDrugOrder = new OutputCaseOFNeedDrugOrder();
            List<CostomDrugOrder> itemDrurOrders = new List<CostomDrugOrder>();

            string _filter = string.Empty;

            if (!Common.CurrentUser.IsSuperUser && input.justMyPatient)
            {
                _filter = " AND THIS.NursingApplication.InPatientTreatmentClinicApp.ResponsibleNurse='" + Common.CurrentUser.TTObjectID.Value + "'";
            }

            BindingList<DrugOrder.GetCaseOfNeedsDrugOrderRQ_Class> drugOrderDetailsByCaseOfNeed = DrugOrder.GetCaseOfNeedsDrugOrderRQ(input.MasterResourcesList, input.start_Time, input.end_Time, _filter);
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

            OutputCaseOFNeedDrugOrder.caseOfNeedDrugOrders = itemDrurOrders;
            model.output_caseOfNeedDrugOrder = OutputCaseOFNeedDrugOrder;
            return model;
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

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public NursingWorkListViewModel Create_CaseOfNeeDrugOrder(List<CostomDrugOrder> input)
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

            model.ksMaterialNote = mesaj;
            return model;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public NursingWorkListViewModel Get_DrugOrderDetails(InputFor_Get_DrugOrderDetails input)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            NursingWorkListViewModel model = new NursingWorkListViewModel();
            List<StatusItem> statusItemList = new List<StatusItem>();
            List<PatientItem> patientItemList = new List<PatientItem>();
            List<DrugOrderDetailOutputItem> drugOrderDetailList = new List<DrugOrderDetailOutputItem>();
            OutputDrugOrderDetail outputDrugOrderDetail = new OutputDrugOrderDetail();

            DateTime sDate = input.start_Time;
            DateTime eDate = input.end_Time;
            //DateTime eDate = Convert.ToDateTime(input.end_Time.ToShortDateString() + " 23:59:59");

            StatusItem empStatusItemItem = new StatusItem();
            empStatusItemItem.StateID = Guid.Empty;
            empStatusItemItem.StatusItemName = TTUtils.CultureService.GetText("M26832", "Seçiniz");
            empStatusItemItem.TypeID = -1;//hepsi
            statusItemList.Add(empStatusItemItem);

            PatientItem emptyPatientItem = new PatientItem();
            emptyPatientItem.ObjectID = Guid.Empty;
            emptyPatientItem.PatientFullName = TTUtils.CultureService.GetText("M26832", "Seçiniz");
            emptyPatientItem.PatientUniqueRefNo = string.Empty;
            patientItemList.Add(emptyPatientItem);

            string _filter = string.Empty;

            if (!Common.CurrentUser.IsSuperUser && input.justMyPatient)
            {
                _filter = " AND THIS.NursingApplication.InPatientTreatmentClinicApp.ResponsibleNurse='" + Common.CurrentUser.TTObjectID.Value + "'";
            }

            if (input.typeID == -1 || input.typeID == 0)//hepsi veya ilaç
            {
                BindingList<DrugOrderDetail.GetDrugOrderDetailsByMasterResource_Class> drugOrderDetailsByMasterResource = DrugOrderDetail.GetDrugOrderDetailsByMasterResource(sDate, eDate, input.MasterResourcesList, _filter);
                foreach (DrugOrderDetail.GetDrugOrderDetailsByMasterResource_Class detail in drugOrderDetailsByMasterResource)
                {
                    DrugOrderDetailOutputItem nosd = new DrugOrderDetailOutputItem();

                    if (detail.Episode != null)
                    {
                        Episode episodeInfo = (Episode)objectContext.GetObject((Guid)detail.Episode, TTObjectDefManager.Instance.ObjectDefs[typeof(Episode).Name], false);
                        nosd.PatientFullName = episodeInfo.Patient.FullName;
                        PatientItem patientItem = new PatientItem();
                        patientItem.ObjectID = episodeInfo.Patient.ObjectID;
                        patientItem.PatientFullName = episodeInfo.Patient.FullName;
                        patientItem.PatientUniqueRefNo = episodeInfo.Patient.UniqueRefNo != null ? episodeInfo.Patient.UniqueRefNo.ToString() : (episodeInfo.Patient.YUPASSNO != null ? episodeInfo.Patient.YUPASSNO.ToString() : string.Empty);

                        if (CheckItemExistenceInMyList(patientItemList, patientItem) == false)
                        {
                            patientItemList.Add(patientItem);
                        }

                    }

                    nosd.MasterResourceName = detail.Masterresource_name;

                    DateTime orderEndDate = detail.OrderPlannedDate.Value.AddMinutes(30);
                    nosd.id = detail.ObjectID.Value;
                    nosd.text = detail.Material + "-" + detail.State;
                    nosd.typeId = OrderTypeEnum.DrugOrder;
                    nosd.typeName = TTUtils.CultureService.GetText("M26061", "İlaç Direktifi");//OrderTypeEnum.DrugOrder;
                    nosd.startDate = detail.OrderPlannedDate.Value;
                    nosd.endDate = orderEndDate.Day != nosd.startDate.Day ? detail.OrderPlannedDate.Value.AddMinutes(30 - (orderEndDate.Minute + 1)) : orderEndDate;
                    Guid state = (Guid)detail.CurrentStateDefID;
                    nosd.stateDefID = state;

                    StatusItem statusItemItem = new StatusItem();
                    statusItemItem.StateID = state;
                    switch (state.ToString())
                    {
                        case "cb22e74b-a2be-456f-8680-660d0b21dc24": // plan
                            nosd.statusName = TTUtils.CultureService.GetText("M25573", "Eczaneden İstenmedi!");
                            break;
                        case "da01e671-efb9-4d84-8122-4bae07e08c20": //İstek
                            nosd.statusName = TTUtils.CultureService.GetText("M25572", "Eczaneden İstendi Henüz Karşılanmadı!");
                            break;
                        case "94c4b7eb-b764-4ca5-add6-76e2217f7dd4": //Hastanın Üzerinde
                            nosd.statusName = TTUtils.CultureService.GetText("M25385", "Daha Önce Karşılanan Doz Kullanılacaktır !!!");
                            break;
                        case "d4f85132-8d05-4dc7-b9b2-fc04bae622b0": // Karşılandı
                            nosd.statusName = TTUtils.CultureService.GetText("M25571", "Eczaneden İstendi Eczane Tarafından Karşılandı!");
                            break;
                        case "ad54f2c0-8ebe-4fbb-a57a-b7c870fd1fb3": // Eczacılık Bilimlerinden İstendi
                            nosd.statusName = "Eczacılık Bilimlerinden İstendi";
                            break;
                        case "f1b24e44-ecb3-4b44-9b23-1d77e9901721": //Durdur
                            nosd.statusName = TTUtils.CultureService.GetText("M25549", "Durduruldu");
                            break;
                        case "14ea4626-5b27-4663-82f9-64968cb4eb63": //Hastaya Teslim
                            nosd.statusName = TTUtils.CultureService.GetText("M25771", "Hasta / Hasta Yakınına teslim edildi.");
                            break;
                        case "d39a37a6-610e-4143-aca2-691ce5818915": //Uygulandı
                            nosd.statusName = TTUtils.CultureService.GetText("M27138", "Uygulandı");
                            break;
                        case "add6e452-c007-4849-b477-17d30400abe8": //İptal
                            nosd.statusName = TTUtils.CultureService.GetText("M27135", "Uygulama İptal Edildi!");
                            break;
                        case "0586979d-523c-4800-995c-750ac3984606": //Dış Eczane Tarafından Karşılandı
                            nosd.statusName = TTUtils.CultureService.GetText("M25431", "Dış Eczane Tarafından Karşılandı");
                            break;
                        case "4223ab9b-1b9f-4f59-845f-b903adcda8a0"://Eczaneye İade
                            nosd.statusName = TTUtils.CultureService.GetText("M25574", "Eczaneye İade");
                            break;
                        default:
                            nosd.statusName = TTUtils.CultureService.GetText("M27042", "Tanımsız durum.Lütfen sistem yöneticisine başvurun!!");
                            break;
                    }
                    statusItemItem.StatusItemName = nosd.statusName;
                    statusItemItem.TypeID = 0;//ilaç
                    if (CheckItemExistenceInMyList(statusItemList, statusItemItem) == false)
                    {
                        statusItemList.Add(statusItemItem);
                    }

                    nosd.periodStartTime = DateTime.Now; //bu saatten öncesine detay saati değişmesi
                    nosd.isChanged = false;
                    nosd.doctorDescription = detail.Note;
                    nosd.Result = "";
                    drugOrderDetailList.Add(nosd);
                }
            }

            if (input.typeID == -1 || input.typeID == 1)// hepsi veya sadece hemşire
            {
                BindingList<NursingOrderDetail.GetNODByMasterResource_Class> nursingOrderDetailsByMasterResource = NursingOrderDetail.GetNODByMasterResource(input.MasterResourcesList, sDate, eDate, _filter);
                foreach (NursingOrderDetail.GetNODByMasterResource_Class detail in nursingOrderDetailsByMasterResource)
                {
                    DrugOrderDetailOutputItem nosd = new DrugOrderDetailOutputItem();

                    if (detail.Episode != null)
                    {
                        Episode episodeInfo = (Episode)objectContext.GetObject((Guid)detail.Episode, TTObjectDefManager.Instance.ObjectDefs[typeof(Episode).Name], false);
                        nosd.PatientFullName = episodeInfo.Patient.FullName;
                        PatientItem patientItem = new PatientItem();
                        patientItem.ObjectID = episodeInfo.Patient.ObjectID;
                        patientItem.PatientFullName = episodeInfo.Patient.FullName;
                        patientItem.PatientUniqueRefNo = episodeInfo.Patient.UniqueRefNo != null ? episodeInfo.Patient.UniqueRefNo.ToString() : (episodeInfo.Patient.YUPASSNO != null ? episodeInfo.Patient.YUPASSNO.ToString() : string.Empty);

                        if (CheckItemExistenceInMyList(patientItemList, patientItem) == false)
                        {
                            patientItemList.Add(patientItem);
                        }

                    }

                    nosd.MasterResourceName = detail.Masterresource_name;

                    DateTime orderEndDate = detail.WorkListDate.Value.AddMinutes(30);
                    nosd.id = detail.ObjectID.Value;
                    nosd.text = detail.Name + "-" + detail.Statusname;
                    nosd.typeId = OrderTypeEnum.NursingOrder;
                    nosd.typeName = TTUtils.CultureService.GetText("M25918", "Hemşire Direktifi");//OrderTypeEnum.DrugOrder;
                    nosd.startDate = detail.WorkListDate.Value;
                    nosd.endDate = orderEndDate.Day != nosd.startDate.Day ? detail.WorkListDate.Value.AddMinutes(30 - (orderEndDate.Minute + 1)) : orderEndDate;
                    Guid state = (Guid)detail.CurrentStateDefID;
                    nosd.stateDefID = state;
                    nosd.statusName = detail.Statusname.ToString();

                    StatusItem statusItemItem = new StatusItem();
                    statusItemItem.StateID = state;
                    statusItemItem.StatusItemName = nosd.statusName;
                    statusItemItem.TypeID = 1;//hemşire
                    if (CheckItemExistenceInMyList(statusItemList, statusItemItem) == false)
                    {
                        statusItemList.Add(statusItemItem);
                    }

                    nosd.periodStartTime = DateTime.Now; //bu saatten öncesine detay saati değişmesi
                    nosd.isChanged = false;
                    nosd.doctorDescription = detail.Notes;
                    nosd.Result = detail.Result != null ? detail.Result : "";

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

                    drugOrderDetailList.Add(nosd);
                }
            }

            outputDrugOrderDetail.drugOrderDetails = drugOrderDetailList.OrderBy(x => x.startDate).ToList();
            model.output_drugOrderDetails = outputDrugOrderDetail;
            model.statusList = statusItemList;
            model.patients = patientItemList;
            return model;

        }

        private bool CheckItemExistenceInMyList(List<StatusItem> mypatientList, StatusItem compareItem)
        {
            foreach (StatusItem item in mypatientList)
            {
                if (item.StateID == compareItem.StateID)
                    return true;
            }

            return false;
        }
        private bool CheckItemExistenceInMyList(List<PatientItem> mypatientList, PatientItem compareItem)
        {
            foreach (PatientItem item in mypatientList)
            {
                if (item.ObjectID == compareItem.ObjectID)
                    return true;
            }

            return false;
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

    }
}
