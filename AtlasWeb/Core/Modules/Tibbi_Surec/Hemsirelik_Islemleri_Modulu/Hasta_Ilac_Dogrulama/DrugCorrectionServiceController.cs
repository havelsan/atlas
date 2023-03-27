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
using static TTObjectClasses.SubEpisode;
using static TTObjectClasses.Episode;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class DrugCorrectionServiceController : Controller
    {

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public PatientInfo getPatientInfo_FromWristband(InputFor_getPatientInfo_FromWristband input)
        {
            TTObjectContext context = new TTObjectContext(true);

            PatientInfo patientInfo = null;

            SubEpisode subepisode = null;

            SubEpisode.InpatientInfo inpatientInfo = null;

            try
            {
                if (!String.IsNullOrEmpty(input.subEpisodeID))
                {
                    if (input.subEpisodeID.Contains('*'))
                    {
                        input.subEpisodeID = input.subEpisodeID.Replace('*', '-');
                    }
                }
                else
                {
                    return patientInfo;//throw new Exception("Hasta bileklik barkod parametre değeri method çağrısında boş gönderilemez!");
                }

                IBindingList subEpisodes = context.QueryObjects("SUBEPISODE", "PROTOCOLNO='" + input.subEpisodeID.ToString().Trim() + "'");
                if (subEpisodes.Count > 0)
                    subepisode = (SubEpisode)subEpisodes[0];
                else
                    throw new Exception(input.subEpisodeID.ToString() + " hasta bilgisine ulaşılamamıştır.");

                if (subepisode != null)
                {
                    patientInfo = new PatientInfo();
                    patientInfo.patientObjectID = subepisode.Episode.Patient.ObjectID.ToString();
                    patientInfo.patientName = subepisode.Episode.Patient.FullName;
                    patientInfo.patientRefNo = subepisode.Episode.Patient.UniqueRefNo != null ? subepisode.Episode.Patient.UniqueRefNo.ToString() : string.Empty;
                    inpatientInfo = SubEpisode.getInpatientInfoByProtocolNo(input.subEpisodeID.ToString().Trim());
                    patientInfo.admissionDoctor = inpatientInfo.ProcedureDoctor;
                    patientInfo.physicalStateClinic = inpatientInfo.PhysicalStateClinic;
                    patientInfo.roomGroup = inpatientInfo.RoomGroup;
                    patientInfo.room = inpatientInfo.Room;
                    patientInfo.bed = inpatientInfo.Bed;
                }
                return patientInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public PatientInfo getPatientInfo(InputFor_getPatientInfo input)
        {
            TTObjectContext context = new TTObjectContext(true);

            PatientInfo patientInfo = null;
            KSchedule kscheduleAction = null;
            Episode.InpatientInfoByEpisode inpatientInfoByEpisode = null;

            try
            {
                if (!String.IsNullOrEmpty(input.stockActionID))
                {
                    if (input.stockActionID.Contains('*'))
                    {
                        input.stockActionID = input.stockActionID.Replace('*', '-');
                    }
                }
                else
                {
                    return patientInfo;//throw new Exception("Hasta ilaç torba barkod parametre değeri method çağrısında boş gönderilemez!");
                }

                IBindingList kscheduleActions = context.QueryObjects("KSCHEDULE", "STOCKACTIONID='" + input.stockActionID.ToString().Trim() + "'");
                if (kscheduleActions.Count > 0)
                    kscheduleAction = (KSchedule)kscheduleActions[0];
                else
                    throw new Exception(input.stockActionID.ToString() + " Idli işlem sistemde bulunamamıştır.");

                if (kscheduleAction.Episode != null)
                {
                    if (kscheduleAction.Episode.Patient != null)
                    {
                        patientInfo = new PatientInfo();
                        patientInfo.patientObjectID = kscheduleAction.Episode.Patient.ObjectID.ToString();
                        patientInfo.patientName = kscheduleAction.Episode.Patient.FullName;
                        patientInfo.patientRefNo = kscheduleAction.Episode.Patient.UniqueRefNo != null ? kscheduleAction.Episode.Patient.UniqueRefNo.ToString() : string.Empty;
                        patientInfo.inpatientClinicName = kscheduleAction.InPatientPhysicianApplication.MasterResource.Name;

                        inpatientInfoByEpisode = Episode.getInpatientInfoByEpisode(kscheduleAction.Episode.ObjectID);
                        patientInfo.admissionDoctor = kscheduleAction.MKYS_TeslimAlan;
                        patientInfo.physicalStateClinic = inpatientInfoByEpisode.PhysicalStateClinic;
                        patientInfo.roomGroup = inpatientInfoByEpisode.RoomGroup;
                        patientInfo.room = inpatientInfoByEpisode.Room;
                        patientInfo.bed = inpatientInfoByEpisode.Bed;


                    }
                }

                List<DrugOrderInfo> DrugOrderInfoList = new List<DrugOrderInfo>();
                foreach (KScheduleMaterial ksmaterial in kscheduleAction.KScheduleMaterials)
                {
                    foreach (DrugOrderDetail det in ksmaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        DrugOrderInfo drugOrderInfo = new DrugOrderInfo();
                        drugOrderInfo.objectID = det.ObjectID.ToString();
                        drugOrderInfo.stateDefID = det.CurrentStateDefID.ToString();
                        drugOrderInfo.MaterialName = det.Material.Name;
                        drugOrderInfo.MaterialBarcode = det.Material.Barcode;
                        drugOrderInfo.Amount = det.DoseAmount.ToString();
                        drugOrderInfo.drugType = DrugOrder.GetDrugUsedType((DrugDefinition)det.Material);
                        drugOrderInfo.drugDone = false;

                        if (det.CurrentStateDefID == DrugOrderDetail.States.Apply)
                        {
                            drugOrderInfo.DrugCounter = (int)det.DoseAmount;
                        }
                        else
                        {
                            drugOrderInfo.DrugCounter = 0;
                        }

                        drugOrderInfo.OrderPlannedDatetime = (DateTime)det.OrderPlannedDate;
                        drugOrderInfo.IsItInTheTimeInterval = IsItInTheTimeInterval((DateTime)det.OrderPlannedDate);

                        if (det.DrugOrder.DrugUsageType != null)
                            drugOrderInfo.DrugUsageType = Common.GetDescriptionOfDataTypeEnum(det.DrugOrder.DrugUsageType.Value);

                        if (ksmaterial.StockTransactions != null)
                        {
                            foreach (StockTransaction transaction in ksmaterial.StockTransactions.Select(" "))
                            {
                                drugOrderInfo.ExpirationDatetime = transaction.ExpirationDate != null ? transaction.ExpirationDate.Value.Day.ToString()
                                    + "." + transaction.ExpirationDate.Value.Month.ToString()
                                    + "." + transaction.ExpirationDate.Value.Year.ToString() : string.Empty;
                            }
                        }
                        DrugOrderInfoList.Add(drugOrderInfo);
                    }
                }

                foreach (KSchedulePatienOwnDrug ownDrug in kscheduleAction.KSchedulePatienOwnDrugs)
                {
                    foreach (DrugOrderDetail det in ownDrug.DrugOrderDetails)
                    {
                        DrugOrderInfo drugOrderInfo = new DrugOrderInfo();
                        drugOrderInfo.objectID = det.ObjectID.ToString();
                        drugOrderInfo.stateDefID = det.CurrentStateDefID.ToString();
                        drugOrderInfo.MaterialName = det.Material.Name;
                        drugOrderInfo.MaterialBarcode = det.Material.Barcode;
                        drugOrderInfo.Amount = det.DoseAmount.ToString();
                        drugOrderInfo.drugType = DrugOrder.GetDrugUsedType((DrugDefinition)det.Material);
                        drugOrderInfo.drugDone = false;

                        if (det.CurrentStateDefID == DrugOrderDetail.States.Apply)
                        {
                            drugOrderInfo.DrugCounter = (int)det.DoseAmount;
                        }
                        else
                        {
                            drugOrderInfo.DrugCounter = 0;
                        }

                        drugOrderInfo.OrderPlannedDatetime = (DateTime)det.OrderPlannedDate;
                        drugOrderInfo.IsItInTheTimeInterval = IsItInTheTimeInterval((DateTime)det.OrderPlannedDate);
                        drugOrderInfo.ExpirationDatetime = ownDrug.ExpirationDate != null ? ownDrug.ExpirationDate.Value.Day.ToString()
                                  + "." + ownDrug.ExpirationDate.Value.Month.ToString()
                                  + "." + ownDrug.ExpirationDate.Value.Year.ToString() : string.Empty;
                        if (det.DrugOrder.DrugUsageType != null)
                            drugOrderInfo.DrugUsageType = Common.GetDescriptionOfDataTypeEnum(det.DrugOrder.DrugUsageType.Value);
                        DrugOrderInfoList.Add(drugOrderInfo);
                    }
                }

                foreach (KScheduleUnListMaterial unListMaterial in kscheduleAction.KScheduleUnListMaterials)
                {
                    foreach (DrugOrderDetail det in unListMaterial.DrugOrderDetails)
                    {
                        DrugOrderInfo drugOrderInfo = new DrugOrderInfo();
                        drugOrderInfo.objectID = det.ObjectID.ToString();
                        drugOrderInfo.stateDefID = det.CurrentStateDefID.ToString();
                        drugOrderInfo.MaterialName = det.Material.Name;
                        drugOrderInfo.MaterialBarcode = det.Material.Barcode;
                        drugOrderInfo.Amount = det.DoseAmount.ToString();
                        drugOrderInfo.drugType = DrugOrder.GetDrugUsedType((DrugDefinition)det.Material);
                        drugOrderInfo.drugDone = false;

                        if (det.CurrentStateDefID == DrugOrderDetail.States.Apply)
                        {
                            drugOrderInfo.DrugCounter = (int)det.DoseAmount;
                        }
                        else
                        {
                            drugOrderInfo.DrugCounter = 0;
                        }

                        drugOrderInfo.OrderPlannedDatetime = (DateTime)det.OrderPlannedDate;
                        drugOrderInfo.IsItInTheTimeInterval = IsItInTheTimeInterval((DateTime)det.OrderPlannedDate);
                        /*drugOrderInfo.ExpirationDatetime = ownDrug.ExpirationDate != null ? ownDrug.ExpirationDate.Value.Day.ToString()
                                  + "." + ownDrug.ExpirationDate.Value.Month.ToString()
                                  + "." + ownDrug.ExpirationDate.Value.Year.ToString() : string.Empty;*/
                        if (det.DrugOrder.DrugUsageType != null)
                            drugOrderInfo.DrugUsageType = Common.GetDescriptionOfDataTypeEnum(det.DrugOrder.DrugUsageType.Value);
                        DrugOrderInfoList.Add(drugOrderInfo);
                    }
                }
                DrugOrderInfoList = DrugOrderInfoList.OrderBy(o => o.OrderPlannedDatetime).ToList();
                patientInfo.DrugOrderInfoList = DrugOrderInfoList;
                return patientInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool IsItInTheTimeInterval(DateTime orderPlannedDateTime)
        {
            int drugApplicationTimeInterval = Int32.Parse(TTObjectClasses.SystemParameter.GetParameterValue("DRUGAPPLICATIONTIMEINTERVAL", "60"));
            DateTime drugApplicationTimeIntervalBegin = orderPlannedDateTime.AddMinutes(-drugApplicationTimeInterval);
            DateTime drugApplicationTimeIntervalEnd = orderPlannedDateTime.AddMinutes(drugApplicationTimeInterval);
            if (DateTime.Now > drugApplicationTimeIntervalBegin && DateTime.Now < drugApplicationTimeIntervalEnd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public OutputFor_ApplyTheDrugOrderDetail ApplyTheDrugOrderDetail(InputFor_ApplyTheDrugOrderDetail input)
        {

            TTObjectContext context = new TTObjectContext(false);

            OutputFor_ApplyTheDrugOrderDetail output = new OutputFor_ApplyTheDrugOrderDetail();
            output.processCompleted = false;
            output.resultMessage = TTUtils.CultureService.GetText("M26067", "İlaç uygulama gerçekleştirilemedi!");

            if (input.drugOrderInfo == null)
            {
                output.processCompleted = false;
                output.resultMessage = TTUtils.CultureService.GetText("M26068", "İlaç uygulama için tanımsız giriş!");
                output.updatedDrugOrder = input.drugOrderInfo;
                return output;
            }

            int drugApplicationTimeInterval = Int32.Parse(TTObjectClasses.SystemParameter.GetParameterValue("DRUGAPPLICATIONTIMEINTERVAL", "30"));
            DateTime drugApplicationTimeIntervalBegin = input.drugOrderInfo.OrderPlannedDatetime.AddMinutes(-drugApplicationTimeInterval);
            DateTime drugApplicationTimeIntervalEnd = input.drugOrderInfo.OrderPlannedDatetime.AddMinutes(drugApplicationTimeInterval);

            try
            {
                DrugOrderDetail drugOrderDet = (DrugOrderDetail)context.GetObject(new Guid(input.drugOrderInfo.objectID), TTObjectDefManager.Instance.ObjectDefs[typeof(DrugOrderDetail).Name], false);

                if (drugOrderDet != null)
                {
                    drugOrderDet.DrugDone = input.drugOrderInfo.drugDone;
                    if (drugOrderDet.CurrentStateDefID == DrugOrderDetail.States.UseRestDose || drugOrderDet.CurrentStateDefID == DrugOrderDetail.States.Supply)
                    {
                        if (DateTime.Now > drugApplicationTimeIntervalBegin && DateTime.Now < drugApplicationTimeIntervalEnd)
                        {
                            double amount = Convert.ToDouble(input.drugOrderInfo.Amount);
                            if (DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDet.Material))
                            {
                                if (input.drugOrderInfo.DrugCounter + 1 <= Math.Ceiling(amount))
                                    input.drugOrderInfo.DrugCounter = input.drugOrderInfo.DrugCounter + 1;

                                if (Math.Ceiling(amount) == input.drugOrderInfo.DrugCounter)
                                {
                                    drugOrderDet.CurrentStateDefID = DrugOrderDetail.States.Apply;

                                    input.drugOrderInfo.stateDefID = drugOrderDet.CurrentStateDefID.ToString();

                                    output.processCompleted = true;
                                    output.resultMessage = TTUtils.CultureService.GetText("M26069", "İlaç Uygulama işlemi başarıyla gerçekleştirilmiştir.");
                                    if (DateTime.Now > input.drugOrderInfo.OrderPlannedDatetime.AddMinutes(5))
                                    {
                                        TimeSpan varTime = DateTime.Now - input.drugOrderInfo.OrderPlannedDatetime;
                                        double fractionalMinutes = varTime.TotalMinutes;
                                        int wholeMinutes = (int)fractionalMinutes;
                                        output.resultMessage += "Uygulama zamanı " + wholeMinutes.ToString() + " dakika gecikmiştir.";
                                    }
                                    output.updatedDrugOrder = input.drugOrderInfo;

                                    context.Save();
                                }
                                else
                                {
                                    output.processCompleted = true;
                                    output.resultMessage = TTUtils.CultureService.GetText("M26071", "İlaç uygulanan doz miktarı başarıyla güncellenmiştir.");
                                    output.updatedDrugOrder = input.drugOrderInfo;
                                }
                            }
                            else
                            {
                                input.drugOrderInfo.DrugCounter = Int32.Parse(input.drugOrderInfo.Amount);
                                drugOrderDet.CurrentStateDefID = DrugOrderDetail.States.Apply;

                                input.drugOrderInfo.stateDefID = drugOrderDet.CurrentStateDefID.ToString();

                                output.processCompleted = true;
                                output.resultMessage = TTUtils.CultureService.GetText("M26069", "İlaç Uygulama işlemi başarıyla gerçekleştirilmiştir.");
                                if (DateTime.Now > input.drugOrderInfo.OrderPlannedDatetime.AddMinutes(5))
                                {
                                    TimeSpan varTime = DateTime.Now - input.drugOrderInfo.OrderPlannedDatetime;
                                    double fractionalMinutes = varTime.TotalMinutes;
                                    int wholeMinutes = (int)fractionalMinutes;
                                    output.resultMessage += "Uygulama zamanı " + wholeMinutes.ToString() + " dakika gecikmiştir.";
                                }
                                output.updatedDrugOrder = input.drugOrderInfo;

                                context.Save();
                            }

                        }
                        else
                        {
                            output.processCompleted = false;
                            output.resultMessage = "Bu ilacın uygulamasını sadece " + drugApplicationTimeIntervalBegin.ToString() + " - " + drugApplicationTimeIntervalEnd.ToString() + " zaman aralığında gerçekleştirebilirsiniz!";
                            output.updatedDrugOrder = input.drugOrderInfo;
                        }
                    }
                    else
                    {
                        output.processCompleted = false;
                        output.resultMessage = drugOrderDet.CurrentStateDef.DisplayText.ToString() + " durumundaki ilacın uygulaması gerçekleştirilemez!";
                        output.updatedDrugOrder = input.drugOrderInfo;
                    }
                }
                else
                {
                    output.processCompleted = false;
                    output.resultMessage = TTUtils.CultureService.GetText("M26830", "Seçili ilaç uygulanacak ilaçlar listesinde yer almamaktadır!");
                    output.updatedDrugOrder = input.drugOrderInfo;
                }

                return output;

            }
            catch (Exception ex)
            {
                output.processCompleted = false;
                output.resultMessage = ex.ToString();
                output.updatedDrugOrder = input.drugOrderInfo;

                return output;
            }

        }



        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hemsire)]
        public List<DrugOrderDetailOutputItem> GetDrugOrderDetailInformations()
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            List<DrugOrderDetailOutputItem> drugOrderDetailList = new List<DrugOrderDetailOutputItem>();
            OutputDrugOrderDetail outputDrugOrderDetail = new OutputDrugOrderDetail();

            DateTime sDate = DateTime.Now.AddMinutes(-45);
            DateTime eDate = DateTime.Now.AddMinutes(+45);

            List<Guid> userResources = new List<Guid>();
            if (Common.CurrentUser.IsSuperUser)
            {
                TTObjectContext context = new TTObjectContext(true);
                BindingList<ResSection> resSectionList = ResSection.GetResSections(context, " WHERE ISACTIVE = 1");
                foreach (ResSection rs in resSectionList)
                {
                    userResources.Add(rs.ObjectID);
                }
            }
            else
            {
                foreach (UserResource userResource in Common.CurrentResource.UserResources)
                {

                    userResources.Add(userResource.Resource.ObjectID);
                }
            }


            BindingList<DrugOrderDetail.GetDrugOrderDetailsByMasterResNotComp_Class> drugOrderDetailsByMasterResource = DrugOrderDetail.GetDrugOrderDetailsByMasterResNotComp(eDate, userResources, sDate);
            foreach (DrugOrderDetail.GetDrugOrderDetailsByMasterResNotComp_Class detail in drugOrderDetailsByMasterResource)
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

                nosd.periodStartTime = DateTime.Now; //bu saatten öncesine detay saati değişmesi
                nosd.isChanged = false;
                nosd.doctorDescription = detail.Note;
                nosd.Result = "";
                nosd.BackColorName = "White";
                drugOrderDetailList.Add(nosd);
            }

            BindingList<NursingOrderDetail.GetUnCompletedNODByMasterResource_Class> nursingOrderDetailsByMasterResource = NursingOrderDetail.GetUnCompletedNODByMasterResource(eDate,sDate, userResources);
            foreach (NursingOrderDetail.GetUnCompletedNODByMasterResource_Class detail in nursingOrderDetailsByMasterResource)
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

                nosd.periodStartTime = DateTime.Now; //bu saatten öncesine detay saati değişmesi
                nosd.isChanged = false;
                nosd.doctorDescription = detail.Notes;
                nosd.Result = detail.Result != null ? detail.Result : "";
                drugOrderDetailList.Add(nosd);
            }


            List<DrugOrderDetailOutputItem> drugOrderDetails = drugOrderDetailList.OrderBy(x => x.startDate).ToList();
            return drugOrderDetails;
        }
    }
}
