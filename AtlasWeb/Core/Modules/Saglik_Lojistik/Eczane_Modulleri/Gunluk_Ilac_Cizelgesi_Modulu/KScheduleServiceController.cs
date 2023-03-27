//$75A185EB
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using TTUtils;
using TTConnectionManager;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class KScheduleServiceController : Controller
    {
        public class CreateKScheduleMaterial_Input
        {
            public TTObjectClasses.DrugOrder drugOrder
            {
                get;
                set;
            }

            public double amount
            {
                get;
                set;
            }
        }

        public class HimsDrugBarcodesContainer
        {
            public List<HimsDrugInfo> DrugBarcodes { get; set; }
        }

        public class HimsDrugInfo
        {
            public string PrintDate { get; set; }
            public string ProcedureCode { get; set; }
            public string BarcodeCode { get; set; }
            public string ProcedureName { get; set; }
            public string PatientFullName { get; set; }
            public List<HimsDrugsInfo> Drugs { get; set; }
        }
        public class HimsDrugsInfo
        {
            public string DrugName { get; set; }
            public string Doz { get; set; }
            public string PlannedTime { get; set; }
            public string EK { get; set; }
            public string Mi { get; set; }
        }

        private KSchedule KschedulePreliminaryForHimssBarcode(KSchedule kScheduleInput)
        {
            TTObjectContext context = new TTObjectContext(false);
            KSchedule kscheduleAction = null;

            kscheduleAction = (KSchedule)context.GetObject(kScheduleInput.ObjectID, typeof(KSchedule));

            double restAmount = 0;
            double restVolume = 0;
            foreach (KScheduleMaterial kScheduleMaterial in kscheduleAction.StockActionOutDetails)
            {
                Dictionary<Guid, object> drugOrderDetailDictionary = new Dictionary<Guid, object>();
                if (kScheduleMaterial.Status != StockActionDetailStatusEnum.Deleted && kScheduleMaterial.Status != StockActionDetailStatusEnum.Cancelled)
                {
                    Dictionary<Guid, object> drugOrderDictionary = new Dictionary<Guid, object>();
                    restAmount = (double)kScheduleMaterial.Amount;
                    restVolume = (double)((DrugDefinition)kScheduleMaterial.Material).Volume * (double)kScheduleMaterial.Amount;
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        if (DrugOrder.GetDrugUsedType(((DrugDefinition)stateDrugOrderDetail.Material)))
                        {
                            if (restAmount >= stateDrugOrderDetail.Amount)
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID.ToString() == DrugOrderDetail.States.Request.ToString())
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Supply;
                                    if (!drugOrderDictionary.ContainsKey(stateDrugOrderDetail.DrugOrder.ObjectID))
                                    {
                                        drugOrderDictionary.Add(stateDrugOrderDetail.DrugOrder.ObjectID, stateDrugOrderDetail.DrugOrder);
                                    }
                                }
                                restAmount = restAmount - (double)stateDrugOrderDetail.Amount;
                            }
                            else
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request)
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                                }
                                if (drugOrderDetailDictionary.ContainsKey(stateDrugOrderDetail.ObjectID) == false)
                                {
                                    drugOrderDetailDictionary.Add(stateDrugOrderDetail.ObjectID, stateDrugOrderDetail);
                                }
                            }
                        }
                        else
                        {
                            if (restVolume >= stateDrugOrderDetail.Amount)
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID.ToString() == DrugOrderDetail.States.Request.ToString())
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Supply;
                                    if (!drugOrderDictionary.ContainsKey(stateDrugOrderDetail.DrugOrder.ObjectID))
                                    {
                                        drugOrderDictionary.Add(stateDrugOrderDetail.DrugOrder.ObjectID, stateDrugOrderDetail.DrugOrder);
                                    }
                                }
                                restVolume = restVolume - (double)stateDrugOrderDetail.Amount;
                            }
                            else
                            {
                                if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request)
                                {
                                    stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                                }
                                if (drugOrderDetailDictionary.ContainsKey(stateDrugOrderDetail.ObjectID) == false)
                                {
                                    drugOrderDetailDictionary.Add(stateDrugOrderDetail.ObjectID, stateDrugOrderDetail);
                                }

                            }
                        }
                    }

                }
                else
                {
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        if (stateDrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Request)
                        {
                            stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                        }
                        if (drugOrderDetailDictionary.ContainsKey(stateDrugOrderDetail.ObjectID) == false)
                        {
                            drugOrderDetailDictionary.Add(stateDrugOrderDetail.ObjectID, stateDrugOrderDetail);
                        }
                    }
                    kScheduleMaterial.Amount = 0;
                }
                if (drugOrderDetailDictionary.Count > 0)
                {
                    foreach (KeyValuePair<Guid, object> detail in drugOrderDetailDictionary)
                    {
                        if (((DrugOrderDetail)detail.Value).CurrentStateDefID != DrugOrderDetail.States.Cancel)
                            ((DrugOrderDetail)detail.Value).KScheduleCollectedOrder = null;
                    }
                }
            }
            //SS :  INC056882 Windesk işi ile istenen özellik için değiştirildi.

            if (kscheduleAction is KScheduleDaily)
            {
                foreach (KScheduleMaterial kScheduleMaterial in kscheduleAction.StockActionOutDetails)
                {
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        stateDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Supply;
                    }
                }
            }

            return kscheduleAction;

        }

        /// <summary>
        /// Eski nesneler buranın altında
        /// </summary>

        public class DrugBarcodesContainer
        {
            public List<DrugBarcodeInfo> DrugBarcodes { get; set; }
        }

        public class DrugBarcodeInfo
        {
            public string PrintDate { get; set; }
            public string ProcedureCode { get; set; }
            public string ProcedureName { get; set; }
            public string PatientFullName { get; set; }
            public string BirthDate { get; set; }
            public string AcceptionNumber { get; set; }
            public string AcceptionDoctor { get; set; }
            public string OrderDate { get; set; }
            public string IslemNo { get; set; }
            public List<DrugsInfo> Drugs { get; set; }
        }

        public class DrugsInfo
        {
            public string DrugName { get; set; }
            public string Mi { get; set; }
            public string EK { get; set; }
            public string Doz { get; set; }
            public string ExpireDate { get; set; }
        }

        public class GetMyDrugBarcodes_Input
        {
            public TTObjectClasses.KSchedule KscheduleAction
            {
                get;
                set;
            }
        }


        [HttpPost]
        public List<InpatientHasDrugList> GetInpatientHasDrugList(string InPatientPhysicianApplication)
        {
            using (var context = new TTObjectContext(false))
            {
                List<InpatientHasDrugList> InpatientHasDrugList = new List<InpatientHasDrugList>();
                InPatientPhysicianApplication inpatientPhyApp = (InPatientPhysicianApplication)context.GetObject(new Guid(InPatientPhysicianApplication), typeof(InPatientPhysicianApplication));
                string injectionSqlDrugOrder = string.Empty;
                string injectionSqlTreatmentMaterial = string.Empty;
                injectionSqlDrugOrder = " WHERE DRUGORDERINTRODUCTION.SUBEPISODE = " + TTConnectionManager.ConnectionManager.GuidToString(inpatientPhyApp.SubEpisode.ObjectID);
                BindingList<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> drugList = DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient(injectionSqlDrugOrder);
                List<InpatientHasDrugList> createGridView = this.CreateDrugOrderIntroductionGridViewModel(drugList, context, inpatientPhyApp.SubEpisode);
                injectionSqlTreatmentMaterial = " AND THIS.MATERIAL.OBJECTDEFID = '65a2337c-bc3c-4c6b-9575-ad47fa7a9a89' AND  EPISODEACTION.SUBEPISODE= " + TTConnectionManager.ConnectionManager.GuidToString(inpatientPhyApp.SubEpisode.ObjectID);
                BindingList<BaseTreatmentMaterial.GetTreatmentMatByParameter_Class> baseTreatmentList = BaseTreatmentMaterial.GetTreatmentMatByParameter(injectionSqlTreatmentMaterial);
                foreach (BaseTreatmentMaterial.GetTreatmentMatByParameter_Class item in baseTreatmentList)
                {
                    InpatientHasDrugList baseMat = new InpatientHasDrugList();
                    baseMat.Amount = item.Amount.ToString();
                    baseMat.DoctorName = item.Doctor;
                    if (item.CreationDate != null)
                    {
                        baseMat.PlannedEndTime = item.CreationDate.Value;
                        baseMat.PlannedStartTime = item.CreationDate.Value;
                    }
                    baseMat.OutStatus = "Cep Depo";
                    baseMat.DrugName = item.Drugname;
                    baseMat.ClinikName = item.Storename;
                    baseMat.EhuStatus = null;
                    baseMat.TreatmentType = null;
                    baseMat.DoseAmount = null;
                    baseMat.Day = 1;
                    if (item.Materialobjectdefid == new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"))
                        baseMat.MaterialType = "İlaç";
                    else
                        baseMat.MaterialType = "Sarf";
                    createGridView.Add(baseMat);
                }


                return createGridView;
            }
        }


        public List<InpatientHasDrugList> CreateDrugOrderIntroductionGridViewModel(BindingList<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> details, TTObjectContext objectContext, SubEpisode subEpisode)
        {

            List<InpatientHasDrugList> output = new List<InpatientHasDrugList>();

            Dictionary<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>> parentDrugOrderDict = new Dictionary<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>>();

            foreach (DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class detail in details)
            {
                if (detail.ParentDrugOrder == null)
                {
                    if (parentDrugOrderDict.ContainsKey(detail.Drugorderid.Value))
                    {
                        parentDrugOrderDict[detail.Drugorderid.Value].Add(detail);
                    }
                    else
                    {
                        List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> detailList = new List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>();
                        detailList.Add(detail);
                        parentDrugOrderDict.Add(detail.Drugorderid.Value, detailList);
                    }
                }
                else
                {
                    if (parentDrugOrderDict.ContainsKey(detail.ParentDrugOrder.Value))
                    {
                        parentDrugOrderDict[detail.ParentDrugOrder.Value].Add(detail);
                    }
                    else
                    {
                        List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> detailList = new List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>();
                        detailList.Add(detail);
                        parentDrugOrderDict.Add(detail.ParentDrugOrder.Value, detailList);
                    }
                }
            }

            foreach (KeyValuePair<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>> detailDic in parentDrugOrderDict)
            {
                if (detailDic.Value.Count == 1)
                {
                    foreach (var item in detailDic.Value)
                    {
                        InpatientHasDrugList inpatientHasDrug = new InpatientHasDrugList();

                        inpatientHasDrug.DoctorName = item.Doctor;
                        inpatientHasDrug.ClinikName = item.Clinik;
                        inpatientHasDrug.OutStatus = "Eczane";
                        inpatientHasDrug.MaterialType = "İlaç";
                        inpatientHasDrug.Dose = item.Hospitaltimeschedulename;

                        if (item.CaseOfNeed.HasValue)
                            inpatientHasDrug.CaseOfNeed = item.CaseOfNeed.Value;
                        else
                            inpatientHasDrug.CaseOfNeed = false;

                        inpatientHasDrug.Day = item.Drugorderday.Value;
                        inpatientHasDrug.DoseAmount = item.DoseAmount.Value;
                        if (item.DrugUsageType != null)
                            inpatientHasDrug.TreatmentType = item.DrugUsageType.Value;

                        if (item.IsImmediate.HasValue)
                            inpatientHasDrug.IsImmediately = item.IsImmediate.Value;
                        else
                            inpatientHasDrug.IsImmediately = false;

                        Material material = (Material)objectContext.GetObject(item.Material.Value, typeof(Material));
                        if (material is DrugDefinition)
                        {
                            if (((DrugDefinition)material).AntibioticType != null)
                                inpatientHasDrug.EhuStatus = ((DrugDefinition)material).AntibioticType.Value;
                        }
                        inpatientHasDrug.DrugName = material.Name;

                        if (item.PatientOwnDrug.Value)
                            inpatientHasDrug.PatientOwnDrug = item.PatientOwnDrug.Value;
                        else
                            inpatientHasDrug.PatientOwnDrug = false;

                        if (inpatientHasDrug.PatientOwnDrug)
                        {
                            BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> ownDrugRestDose = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(subEpisode.Episode.ObjectID, new Guid(material.ObjectID.ToString()));
                            int restamount = 0;
                            foreach (PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class rest in ownDrugRestDose)
                            {
                                restamount = restamount + Convert.ToInt16(rest.Restamount);
                            }
                        }

                        inpatientHasDrug.PlannedStartTime = item.Orderdate.Value;
                        inpatientHasDrug.Desciption = item.UsageNote;

                        List<DrugOrderDetail> drugOrderDetails = objectContext.QueryObjects<DrugOrderDetail>("DRUGORDER = " + TTConnectionManager.ConnectionManager.GuidToString(item.Drugorderid.Value)).ToList();

                        inpatientHasDrug.Amount = (drugOrderDetails.Count * item.DoseAmount * item.Drugorderday).ToString();
                        if (drugOrderDetails.Count > 0)
                        {

                            drugOrderDetails = drugOrderDetails.OrderBy(x => x.OrderPlannedDate).ToList();
                            inpatientHasDrug.PlannedEndTime = drugOrderDetails[drugOrderDetails.Count - 1].OrderPlannedDate.Value;
                            inpatientHasDrug.PlannedStartTime = drugOrderDetails[drugOrderDetails.Count - 1].DrugOrder.CreationDate.Value;
                            inpatientHasDrug.DoctorName = drugOrderDetails[0].DrugOrder.RequestedByUser.Name;
                        }
                        output.Add(inpatientHasDrug);
                    }
                }
                else
                {
                    InpatientHasDrugList inpatientHasDrug = new InpatientHasDrugList();
                    List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> sortedList = detailDic.Value.OrderBy(x => x.Orderdate).ThenBy(x => x.CreationDate).ToList();
                    DrugOrder parentDrugOrder = (DrugOrder)objectContext.GetObject(detailDic.Key, typeof(DrugOrder));

                    inpatientHasDrug.DoctorName = parentDrugOrder.RequestedByUser.Name;
                    inpatientHasDrug.ClinikName = parentDrugOrder.MasterResource.Name;
                    inpatientHasDrug.OutStatus = "Eczane";
                    inpatientHasDrug.Dose = parentDrugOrder.HospitalTimeSchedule.Name;


                    if (parentDrugOrder.CaseOfNeed.HasValue)
                        inpatientHasDrug.CaseOfNeed = parentDrugOrder.CaseOfNeed.Value;
                    else
                        inpatientHasDrug.CaseOfNeed = false;

                    inpatientHasDrug.Day = sortedList[sortedList.Count - 1].Drugorderday.Value;
                    inpatientHasDrug.DoseAmount = parentDrugOrder.DoseAmount.Value;
                    if (parentDrugOrder.DrugUsageType != null)
                        inpatientHasDrug.TreatmentType = parentDrugOrder.DrugUsageType.Value;

                    if (parentDrugOrder.IsImmediate.HasValue)
                        inpatientHasDrug.IsImmediately = parentDrugOrder.IsImmediate.Value;
                    else
                        inpatientHasDrug.IsImmediately = false;

                    Material material = (Material)objectContext.GetObject(parentDrugOrder.Material.ObjectID, typeof(Material));
                    if (material is DrugDefinition)
                    {
                        if (((DrugDefinition)material).AntibioticType != null)
                            inpatientHasDrug.EhuStatus = ((DrugDefinition)material).AntibioticType.Value;
                    }
                    inpatientHasDrug.DrugName = material.Name;
                    inpatientHasDrug.PatientOwnDrug = sortedList[sortedList.Count - 1].PatientOwnDrug.Value;
                    inpatientHasDrug.PlannedStartTime = parentDrugOrder.PlannedStartTime.Value;
                    inpatientHasDrug.Desciption = sortedList[sortedList.Count - 1].UsageNote;

                    if (inpatientHasDrug.PatientOwnDrug)
                    {
                        BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> ownDrugRestDose = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(subEpisode.Episode.ObjectID, new Guid(material.ObjectID.ToString()));
                        int restamount = 0;
                        foreach (PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class rest in ownDrugRestDose)
                        {
                            restamount = restamount + Convert.ToInt16(rest.Restamount);
                        }
                    }

                    List<DrugOrderDetail> drugOrderDetails = objectContext.QueryObjects<DrugOrderDetail>("DRUGORDER = " + TTConnectionManager.ConnectionManager.GuidToString(sortedList[sortedList.Count - 1].Drugorderid.Value)).ToList();
                    inpatientHasDrug.Amount = (drugOrderDetails.Count * parentDrugOrder.DoseAmount * inpatientHasDrug.Day).ToString();
                    if (drugOrderDetails.Count > 0)
                    {
                        drugOrderDetails = drugOrderDetails.OrderBy(x => x.OrderPlannedDate).ToList();
                        inpatientHasDrug.PlannedEndTime = drugOrderDetails[drugOrderDetails.Count - 1].OrderPlannedDate.Value;
                        inpatientHasDrug.PlannedStartTime = drugOrderDetails[drugOrderDetails.Count - 1].DrugOrder.CreationDate.Value;
                    }
                    output.Add(inpatientHasDrug);
                }
            }
            return output;
        }

        [HttpPost]
        public HimsDrugBarcodesContainer GetMyHimsDrugBarcodes(GetMyDrugBarcodes_Input KscheduleAction)
        {
            HimsDrugBarcodesContainer barcodesContainer = new HimsDrugBarcodesContainer();
            barcodesContainer.DrugBarcodes = new List<HimsDrugInfo>();
            List<HimsDrugsInfo> collectedDrugsList = new List<HimsDrugsInfo>();


            TTObjectContext context = new TTObjectContext(true);
            KSchedule kscheduleAction = null;

            IBindingList kscheduleActions = context.QueryObjects("KSCHEDULE", "STOCKACTIONID='" + KscheduleAction.KscheduleAction.StockActionID + "'");
            if (kscheduleActions.Count > 0)
                kscheduleAction = (KSchedule)kscheduleActions[0];
            else
                throw new Exception(KscheduleAction.KscheduleAction.StockActionID.ToString() + " Idli işlem sistemde bulunamamıştır.");

            if (kscheduleAction != null)
            {
                kscheduleAction = KschedulePreliminaryForHimssBarcode(kscheduleAction);

                foreach (KScheduleMaterial ksmaterial in kscheduleAction.KScheduleMaterials)
                {
                    foreach (DrugOrderDetail det in ksmaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        if (det.CurrentStateDefID == DrugOrderDetail.States.Supply)
                        {
                            HimsDrugsInfo drugsInfo = new HimsDrugsInfo();
                            drugsInfo.DrugName = det.Material.Name;
                            drugsInfo.EK = "(*E*)";
                            drugsInfo.PlannedTime = ((DateTime)det.OrderPlannedDate).ToString();
                            string orderFrequency = string.Empty;
                            DrugOrder drugOrder = det.DrugOrder;
                            if (drugOrder != null && drugOrder.HospitalTimeSchedule != null)
                                orderFrequency = drugOrder.HospitalTimeSchedule.Name.Trim() + drugOrder.DoseAmount.ToString();

                            drugsInfo.Doz = orderFrequency;
                            drugsInfo.Mi = Math.Ceiling(det.DoseAmount.Value).ToString();
                            collectedDrugsList.Add(drugsInfo);
                        }
                    }
                }
                foreach (KSchedulePatienOwnDrug ownDrugMat in kscheduleAction.KSchedulePatienOwnDrugs)
                {
                    foreach (DrugOrderDetail det in ownDrugMat.DrugOrderDetails)
                    {
                        HimsDrugsInfo drugsInfo = new HimsDrugsInfo();
                        drugsInfo.DrugName = det.Material.Name;
                        drugsInfo.EK = "(*K*)";
                        drugsInfo.Doz = det.DoseAmount.ToString();
                        drugsInfo.PlannedTime = ((DateTime)det.OrderPlannedDate).ToString();

                        string orderFrequency = string.Empty;
                        DrugOrder drugOrder = det.DrugOrder;
                        if (drugOrder != null && drugOrder.HospitalTimeSchedule != null)
                            orderFrequency = drugOrder.HospitalTimeSchedule.Name.Trim() + drugOrder.DoseAmount.ToString();

                        drugsInfo.Doz = orderFrequency;
                        drugsInfo.Mi = Math.Ceiling(det.DoseAmount.Value).ToString();
                        collectedDrugsList.Add(drugsInfo);
                    }
                }
                foreach (KScheduleUnListMaterial unListMaterial in kscheduleAction.KScheduleUnListMaterials)
                {
                    foreach (DrugOrderDetail det in unListMaterial.DrugOrderDetails)
                    {
                        HimsDrugsInfo drugsInfo = new HimsDrugsInfo();
                        drugsInfo.DrugName = det.Material.Name;
                        drugsInfo.EK = "(*D.E.T*)";
                        drugsInfo.Doz = det.DoseAmount.ToString();
                        drugsInfo.PlannedTime = ((DateTime)det.OrderPlannedDate).ToString();
                        string orderFrequency = string.Empty;
                        DrugOrder drugOrder = det.DrugOrder;
                        if (drugOrder != null && drugOrder.HospitalTimeSchedule != null)
                            orderFrequency = drugOrder.HospitalTimeSchedule.Name.Trim() + drugOrder.DoseAmount.ToString();

                        drugsInfo.Doz = orderFrequency;
                        drugsInfo.Mi = Math.Ceiling(det.DoseAmount.Value).ToString();
                        collectedDrugsList.Add(drugsInfo);
                    }
                }
            }
            collectedDrugsList = collectedDrugsList.OrderByDescending(o => o.PlannedTime).ToList();
            barcodesContainer.DrugBarcodes = ReturnMyHimsDrugInfoList(collectedDrugsList, kscheduleAction);
            return barcodesContainer;
        }

        private List<HimsDrugInfo> ReturnMyHimsDrugInfoList(List<HimsDrugsInfo> collectedDrugsList, KSchedule kscheduleAction)
        {
            List<HimsDrugInfo> list = new List<HimsDrugInfo>();

            int listCount = 1;
            int modeValue = 0;

            if (collectedDrugsList.Count >= 7)
                listCount = collectedDrugsList.Count / 7;

            if (collectedDrugsList.Count >= 7)
                modeValue = collectedDrugsList.Count % 7;

            if (modeValue != 0)
            {
                listCount = listCount + 1;
            }

            for (int f = 0; f < listCount; f++)
            {
                HimsDrugInfo info = new HimsDrugInfo();
                info.PatientFullName = kscheduleAction.Episode.Patient.FullName;
                info.PrintDate = DateTime.Now.ToString();
                info.ProcedureCode = kscheduleAction.StockActionID.ToString();
                info.BarcodeCode = kscheduleAction.StockActionID.ToString();
                info.ProcedureName = kscheduleAction.InPatientPhysicianApplication.MasterResource.Name;
                list.Add(info);
            }

            int j = collectedDrugsList.Count;
            int i = 0;
            foreach (HimsDrugInfo info in list)
            {
                info.Drugs = new List<HimsDrugsInfo>();

                for (i = j; i > 0; i--)
                {
                    info.Drugs.Add(collectedDrugsList[i - 1]);
                    j = i - 1;
                    if (info.Drugs.Count == 7)
                        break;
                }

                if (info.Drugs.Count != 7)
                {
                    for (int m = info.Drugs.Count; m < 7; m++)
                    {
                        HimsDrugsInfo drugInfoForNaN = new HimsDrugsInfo();
                        drugInfoForNaN.DrugName = string.Empty;
                        drugInfoForNaN.Mi = string.Empty;
                        drugInfoForNaN.Doz = string.Empty;
                        drugInfoForNaN.EK = string.Empty;
                        drugInfoForNaN.PlannedTime = string.Empty;
                        info.Drugs.Add(drugInfoForNaN);
                    }
                }
            }

            return list;

        }


        [HttpPost]
        public DrugBarcodesContainer GetMyDrugBarcodes(GetMyDrugBarcodes_Input KscheduleAction)
        {
            DrugBarcodesContainer barcodesContainer = new DrugBarcodesContainer();
            barcodesContainer.DrugBarcodes = new List<DrugBarcodeInfo>();

            TTObjectContext context = new TTObjectContext(false);
            KSchedule kscheduleAction = (KSchedule)context.GetObject(KscheduleAction.KscheduleAction.ObjectID, typeof(KSchedule));

            if (kscheduleAction != null)
            {
                if (kscheduleAction.KScheduleMaterials.Count > 0)
                {
                    int j = 0;
                    bool IsBarcodeInfoCreated = false;
                    for (int i = 0; i <= kscheduleAction.KScheduleMaterials.Count - 1; i++)
                    {
                        DrugBarcodeInfo barcodeInfo = null;
                        if (IsBarcodeInfoCreated == false)
                        {
                            barcodeInfo = DrugBarcodeInfo_Factory(kscheduleAction);
                            IsBarcodeInfoCreated = true;
                        }

                        for (int k = j; k < kscheduleAction.KScheduleMaterials.Count; k++)
                        {
                            DrugsInfo drugInfo = null;

                            //İptal edilmiş veya silinmiş material için değerleri boş olan bir drugInfo nesnesi oluşturuluyor...(Mecburi!!!)
                            if (kscheduleAction.KScheduleMaterials[k].Status == StockActionDetailStatusEnum.Cancelled || kscheduleAction.KScheduleMaterials[k].Status == StockActionDetailStatusEnum.Deleted)
                            {
                                drugInfo = new DrugsInfo();
                                drugInfo.DrugName = string.Empty;
                                drugInfo.ExpireDate = string.Empty;
                                drugInfo.Mi = string.Empty;
                                drugInfo.EK = string.Empty;
                                drugInfo.Doz = string.Empty;
                            }
                            else
                            {
                                drugInfo = DrugsInfo_Factory(kscheduleAction.KScheduleMaterials[k]);
                            }

                            barcodeInfo.Drugs.Add(drugInfo);

                            if (j == 6 || j == kscheduleAction.KScheduleMaterials.Count - 1)//j==6 olacak
                            {
                                IsBarcodeInfoCreated = false;
                                if (barcodeInfo.Drugs.Count != 7)
                                {
                                    for (int m = barcodeInfo.Drugs.Count; m < 7; m++)
                                    {
                                        DrugsInfo drugInfoForNaN = new DrugsInfo();
                                        drugInfoForNaN.DrugName = string.Empty;
                                        drugInfoForNaN.ExpireDate = string.Empty;
                                        drugInfoForNaN.Mi = string.Empty;
                                        drugInfoForNaN.EK = string.Empty;
                                        drugInfoForNaN.Doz = string.Empty;
                                        barcodeInfo.Drugs.Add(drugInfoForNaN);
                                    }
                                }

                                barcodeInfo.Drugs = barcodeInfo.Drugs.OrderByDescending(x => x.DrugName).ToList(); //Order edilmezse görünüm iğrenç bir hal alabilir!!!

                                barcodesContainer.DrugBarcodes.Add(barcodeInfo);
                                j++;
                                break;
                            }
                            j++;
                        }
                    }
                }
            }

            return barcodesContainer;

        }


        private DrugBarcodeInfo DrugBarcodeInfo_Factory(KSchedule kscheduleAction)
        {
            DrugBarcodeInfo info = new DrugBarcodeInfo();
            info.PatientFullName = kscheduleAction.Episode.Patient.Name + " " + kscheduleAction.Episode.Patient.Surname;
            info.PrintDate = Common.RecTime().Day.ToString() + "." + Common.RecTime().Month.ToString() + "." + Common.RecTime().Year.ToString();
            info.ProcedureName = kscheduleAction.DestinationStore.Name.ToString();
            info.ProcedureCode = kscheduleAction.Episode.HospitalProtocolNo.Value.ToString();
            info.Drugs = new List<DrugsInfo>();
            return info;
        }

        private DrugsInfo DrugsInfo_Factory(KScheduleMaterial kschMat)
        {
            DrugsInfo drugInfo = new DrugsInfo();
            drugInfo.DrugName = String.IsNullOrEmpty(kschMat.Material.Name) ? " " : kschMat.Material.Name;
            double miktar = 0;
            if (kschMat.StockTransactions != null)
            {
                if (kschMat.StockTransactions.Select("").Count > 0)
                {
                    foreach (StockTransaction transaction in kschMat.StockTransactions.Select(" "))
                        miktar += transaction.Amount.Value;
                }
            }
            drugInfo.Mi = miktar.ToString();

            return drugInfo;
        }



        [HttpPost]
        public TTObjectClasses.KScheduleMaterial CreateKScheduleMaterial(CreateKScheduleMaterial_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                if (input.drugOrder != null)
                    input.drugOrder = (TTObjectClasses.DrugOrder)context.AddObject(input.drugOrder);
                var ret = KSchedule.CreateKScheduleMaterial(context, input.drugOrder, input.amount);
                context.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetKScheduleDrugPrescriptionTotalReportQuery_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<KSchedule.GetKScheduleDrugPrescriptionTotalReportQuery_Class> GetKScheduleDrugPrescriptionTotalReportQuery(GetKScheduleDrugPrescriptionTotalReportQuery_Input input)
        {
            var ret = KSchedule.GetKScheduleDrugPrescriptionTotalReportQuery(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetKSchedule_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public string STORE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<KSchedule> GetKSchedule(GetKSchedule_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = KSchedule.GetKSchedule(objectContext, input.STARTDATE, input.ENDDATE, input.STORE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetQuarantineNOForKScheduleQuery_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }

            public Guid MATERIALID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<KSchedule.GetQuarantineNOForKScheduleQuery_Class> GetQuarantineNOForKScheduleQuery(GetQuarantineNOForKScheduleQuery_Input input)
        {
            var ret = KSchedule.GetQuarantineNOForKScheduleQuery(input.TTOBJECTID, input.MATERIALID);
            return ret;
        }

        public class GetQuaratineNOQuery_Input
        {
            public DateTime DATE
            {
                get;
                set;
            }

            public string NATOSTOCKNO
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<KSchedule.GetQuaratineNOQuery_Class> GetQuaratineNOQuery(GetQuaratineNOQuery_Input input)
        {
            var ret = KSchedule.GetQuaratineNOQuery(input.DATE, input.NATOSTOCKNO, input.injectionSQL);
            return ret;
        }

        public class GetKScheduleReportQuery_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<KSchedule.GetKScheduleReportQuery_Class> GetKScheduleReportQuery(GetKScheduleReportQuery_Input input)
        {
            var ret = KSchedule.GetKScheduleReportQuery(input.TTOBJECTID);
            return ret;
        }

        public class KScheduleMaterialBarcodeRQ_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<KSchedule.KScheduleMaterialBarcodeRQ_Class> KScheduleMaterialBarcodeRQ(KScheduleMaterialBarcodeRQ_Input input)
        {
            var ret = KSchedule.KScheduleMaterialBarcodeRQ(input.TTOBJECTID);
            return ret;
        }

        public class GetCompletedKScheduleMaterial_Input
        {
            public Guid EPISODEID
            {
                get;
                set;
            }
        }

        public class GetCompletedKScheduleMaterial_Output
        {
            public string KScheduleMaterialRowType
            {
                get;
                set;
            }
            public int StockActionID
            {
                get;
                set;
            }
            public DateTime TransactionDate
            {
                get;
                set;
            }
            public string Barcode
            {
                get;
                set;
            }
            public string Name
            {
                get;
                set;
            }
            public int Amount
            {
                get;
                set;
            }
        }

        // KScheduleMaterial ve KSchedulePatienOwnDrug nesnelerini Tek Gridde göstermek için kullanılan viewModel
        public class KScheduleMaterialRowViewModel
        {
            public Guid RowObjectId // KScheduleMaterial ve KSchedulePatienOwnDrug nesnelerinin ObjectIDsi
            {
                get;
                set;
            }
            public KScheduleMaterialRowType KScheduleMaterialRowType
            {
                get;
                set;
            }

            // Ortak alanlar
            public Material Material
            {
                get;
                set;
            }
            public double? BarcodeVerifyCounter
            {
                get;
                set;
            }


            public StockActionDetailStatusEnum Status  //KSchedulePatienOwnDrug için adı StockActionStatus
            {
                get;
                set;
            }
            // KScheduleMaterial için 
            public bool? IsImmediate
            {
                get;
                set;
            }
            public DateTime? DrugOrderStartDate
            {
                get;
                set;
            }


            public double? RequestAmount // kScheduleMaterial  RequestAmount  KSchedulePatienOwnDrug için DrugAmount olmalı 
            {
                get;
                set;
            }

            public double? ReceivedAmount
            {
                get;
                set;
            }


            public double? StoreInheld
            {
                get;
                set;
            }
            public string Description
            {
                get;
                set;
            }
            public string UsageNote
            {
                get;
                set;
            }


            // KSchedulePatienOwnDrug için 

            public DateTime? ExpirationDate
            {
                get;
                set;
            }


            //public bool IsNarcotic
            //{
            //    get;
            //    set;
            //}
            //public bool IsPsychotropic
            //{
            //    get;
            //    set;
            //}

            public bool? IsCV
            {
                get;
                set;
            }
            public string PrescriptionNo
            {
                get;
                set;
            }
        }





        //TODO NİDA Daha Önceden karşılanan İlaçlara KSchedulePatienOwnDrug eklenecek datee göre order yapıldı  GetCompletedKScheduleMaterial_Output E(Eczaneden alındı) /H (hasta getirdi) eklencek
        [HttpPost]
        public List<GetCompletedKScheduleMaterial_Output> GetCompletedKScheduleMaterial(GetCompletedKScheduleMaterial_Input input)
        {
            List<GetCompletedKScheduleMaterial_Output> output = new List<GetCompletedKScheduleMaterial_Output>();
            BindingList<KSchedule.GetCompletedKScheduleMaterialByEpisode_Class> retList = KSchedule.GetCompletedKScheduleMaterialByEpisode(input.EPISODEID);
            foreach (KSchedule.GetCompletedKScheduleMaterialByEpisode_Class compKs in retList)
            {
                GetCompletedKScheduleMaterial_Output outputV = new GetCompletedKScheduleMaterial_Output();
                outputV.KScheduleMaterialRowType = "Eczaneden";
                outputV.StockActionID = (int)compKs.StockActionID;
                outputV.TransactionDate = (DateTime)compKs.TransactionDate;
                outputV.Barcode = compKs.Barcode;
                outputV.Name = compKs.Name;
                outputV.Amount = Convert.ToInt32(compKs.Amount);
                output.Add(outputV);
            }
            BindingList<KSchedule.GetCompletedKSchedulePatienOwnDrugByEpisode_Class> retPODList = KSchedule.GetCompletedKSchedulePatienOwnDrugByEpisode(input.EPISODEID);
            foreach (KSchedule.GetCompletedKSchedulePatienOwnDrugByEpisode_Class compKs in retPODList)
            {
                GetCompletedKScheduleMaterial_Output outputV = new GetCompletedKScheduleMaterial_Output();
                outputV.KScheduleMaterialRowType = "Hasta getirdi";
                outputV.StockActionID = (int)compKs.StockActionID;
                outputV.TransactionDate = (DateTime)compKs.TransactionDate;
                outputV.Barcode = compKs.Barcode;
                outputV.Name = compKs.Name;
                outputV.Amount = Convert.ToInt32(compKs.Amount);
                output.Add(outputV);
            }
            return output.OrderByDescending(dr => dr.TransactionDate).ToList();
        }


        [HttpPost]
        public List<GetPatientOwnDrug_Output> GetPatientOwnDrugs(GetPatientOwnDrug_Input input)
        {
            TTObjectContext context = new TTObjectContext(true);
            List<GetPatientOwnDrug_Output> output = new List<GetPatientOwnDrug_Output>();
            //BindingList<DrugOrder> patientOwnDrugOrders = DrugOrder.GetPatientOwnDrugOrdersByEpisode(context, input.EPISODEID);

            KSchedule kSchedule = (KSchedule)context.GetObject(new Guid(input.KSCHEDULEOBJID), typeof(KSchedule));
            foreach (KScheduleMaterial material in kSchedule.KScheduleMaterials)
            {
                foreach (DrugOrderDetail det in material.KScheduleCollectedOrder.DrugOrderDetails.Select(string.Empty))
                {
                    IBindingList drugOrderIntroductionDets = context.QueryObjects(typeof(DrugOrderIntroductionDet).Name, "DRUGORDER ='" + det.DrugOrder.ObjectID + "'");
                    if (drugOrderIntroductionDets.Count > 0)
                    {
                        DrugOrderIntroductionDet _DrugOrderIntroductionDet = (DrugOrderIntroductionDet)drugOrderIntroductionDets[0];
                        IBindingList drugOrderIntroductionDetsTemps = context.QueryObjects(typeof(DrugOrderIntroductionDet).Name, "PATIENTOWNDRUG = 1 AND DRUGORDERINTRODUCTION =" + TTConnectionManager.ConnectionManager.GuidToString(_DrugOrderIntroductionDet.DrugOrderIntroduction.ObjectID));
                        if (drugOrderIntroductionDetsTemps.Count > 0)
                        {
                            foreach (DrugOrderIntroductionDet costomDet in drugOrderIntroductionDetsTemps)
                            {
                                GetPatientOwnDrug_Output outputV = new GetPatientOwnDrug_Output();
                                outputV.Barcode = costomDet.Material.Barcode;
                                outputV.Name = costomDet.Material.Name;
                                outputV.Amount = costomDet.DoseAmount.ToString();
                                outputV.StockActionDetailStatusEnum = StockActionDetailStatusEnum.New;
                                output.Add(outputV);
                            }
                            break;
                        }
                        break;
                    }
                    break;
                }
                break;
            }
            return output;
        }

        public class GetPatientOwnDrug_Output
        {
            public string Barcode { set; get; }
            public string Name { set; get; }
            public string Amount { set; get; }
            public StockActionDetailStatusEnum StockActionDetailStatusEnum { get; set; }
        }

        public class GetPatientOwnDrug_Input
        {
            public string KSCHEDULEOBJID
            {
                get;
                set;
            }
        }


        /*************************/
        public class GetCompletedKSchedule_Input
        {
            public string StoreID
            {
                get;
                set;
            }
            public DateTime StartDate
            {
                get;
                set;
            }
            public DateTime EndDate
            {
                get;
                set;
            }

        }

        public class GetCompletedKSchedule_Output
        {
            public List<CompletedKscheduleAction> CompletedKscheduleList { get; set; }
        }
        public class CompletedKscheduleAction
        {
            public string ActionObjectID
            {
                get;
                set;
            }
            public string ActionID
            {
                get;
                set;
            }
            public string PatientName
            {
                get;
                set;
            }
            public string StoreName
            {
                get;
                set;
            }
            public List<CompletedKscheduleActionDetail> DetailList { get; set; }
        }

        public class CompletedKscheduleActionDetail
        {
            public string Barcode
            {
                get;
                set;
            }
            public string MaterialName
            {
                get;
                set;
            }
            public string Amount
            {
                get;
                set;
            }
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetCompletedKSchedule_Output GetCompletedKscheduleActions(GetCompletedKSchedule_Input input)
        {
            List<CompletedKscheduleAction> CompletedKscheduleActions = new List<CompletedKscheduleAction>();

            GetCompletedKSchedule_Output output = new GetCompletedKSchedule_Output();

            TTObjectContext context = new TTObjectContext(false);



            string myFilter = "";
            myFilter += " CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(new Guid("ca4b60ca-6051-4174-9d73-c63648b16be5"));
            myFilter += " AND TRANSACTIONDATE > " + Globals.CreateNQLToDateParameter(input.StartDate);
            myFilter += " AND TRANSACTIONDATE <" + Globals.CreateNQLToDateParameter(input.EndDate);
            if (!String.IsNullOrEmpty(input.StoreID))
                myFilter += " AND DESTINATIONSTORE =" + ConnectionManager.GuidToString(new Guid(input.StoreID));

            IBindingList returnedActionList = context.QueryObjects("KSCHEDULE", myFilter);

            if (returnedActionList.Count > 0)
            {
                foreach (KSchedule returnedAction in returnedActionList)
                {
                    CompletedKscheduleAction completedKscheduleIAction = new CompletedKscheduleAction();
                    completedKscheduleIAction.ActionObjectID = returnedAction.ObjectID.ToString();
                    completedKscheduleIAction.ActionID = returnedAction.StockActionID.ToString();

                    if (returnedAction.Episode != null)
                        completedKscheduleIAction.PatientName = returnedAction.Episode.Patient.FullName;

                    completedKscheduleIAction.StoreName = returnedAction.DestinationStore.Name;

                    if (returnedAction.KScheduleMaterials.Count > 0)
                    {
                        List<CompletedKscheduleActionDetail> completedDetails = new List<CompletedKscheduleActionDetail>();
                        foreach (KScheduleMaterial material in returnedAction.KScheduleMaterials)
                        {
                            CompletedKscheduleActionDetail detail = new CompletedKscheduleActionDetail();
                            detail.Amount = material.Amount != null ? material.Amount.ToString() : string.Empty;
                            detail.Barcode = String.IsNullOrEmpty(material.Material.Barcode) ? string.Empty : material.Material.Barcode;
                            detail.MaterialName = String.IsNullOrEmpty(material.Material.Name) ? string.Empty : material.Material.Name;
                            completedDetails.Add(detail);
                        }
                        completedKscheduleIAction.DetailList = completedDetails;
                    }

                    CompletedKscheduleActions.Add(completedKscheduleIAction);
                }
            }

            List<CompletedKscheduleAction> orderedlist = CompletedKscheduleActions.OrderBy(x => x.PatientName).ToList();
            output.CompletedKscheduleList = orderedlist;

            return output;

        }

        public class PrintBarcodeForPursaklar_Input
        {
            public string KScheduleObjID { get; set; }
        }

        [HttpPost]
        public DrugBarcodesContainer PrintBarcodeForPursaklar(PrintBarcodeForPursaklar_Input InputKS)
        {
            List<Guid> actionIDList = new List<Guid>();
            if (!string.IsNullOrEmpty(InputKS.KScheduleObjID))
            {
                actionIDList.Add(new Guid(InputKS.KScheduleObjID));


                var listFromMyQuery = KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate(actionIDList);

                var groupedClasses = listFromMyQuery
                                 .GroupBy(x => x.Storename)
                                 .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
                DrugBarcodesContainer container = CreateMyDrugBarcodes(groupedClasses);
                return container;
            }
            else
                return null;

        }

        /*************************/
        public class PrintBarcodeForGivenActions_Input
        {
            public List<CompletedKscheduleAction> GivenActionList { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DrugBarcodesContainer PrintBarcodeForGivenActions(PrintBarcodeForGivenActions_Input input)
        {
            TTObjectContext context = new TTObjectContext(false);
            List<Guid> actionIDList = new List<Guid>();

            foreach (CompletedKscheduleAction item in input.GivenActionList)
            {
                actionIDList.Add(new Guid(item.ActionObjectID));
            }

            var listFromMyQuery = KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate(actionIDList);

            var groupedClasses = listFromMyQuery
                             .GroupBy(x => x.Storename)
                             .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
            DrugBarcodesContainer container = CreateMyDrugBarcodes(groupedClasses);

            return container;
        }

        private DrugBarcodesContainer CreateMyDrugBarcodes(Dictionary<string, List<KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate_Class>> dictionary)
        {
            DrugBarcodesContainer barcodesContainer = new DrugBarcodesContainer();
            barcodesContainer.DrugBarcodes = new List<DrugBarcodeInfo>();

            foreach (KeyValuePair<string, List<KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate_Class>> entry in dictionary)
            {
                var groupedClasses = entry.Value
                             .GroupBy(x => x.Patient)
                             .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

                List<DrugBarcodeInfo> returnedBarcodeInfoList = CreateMyDrugBarcodes(groupedClasses, entry.Key);
                foreach (DrugBarcodeInfo info in returnedBarcodeInfoList)
                {
                    barcodesContainer.DrugBarcodes.Add(info);
                }

            }

            return barcodesContainer;

        }

        private List<DrugBarcodeInfo> CreateMyDrugBarcodes(Dictionary<Guid?, List<KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate_Class>> dictionary, string storeName)
        {
            List<DrugBarcodeInfo> barcodeInfoList = new List<DrugBarcodeInfo>();
            foreach (KeyValuePair<Guid?, List<KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate_Class>> entry in dictionary)
            {
                List<DrugsInfo> returnedDrugs = DrugsInfo_Factory(entry.Value);

                if (returnedDrugs.Count > 7)
                {
                    List<List<DrugsInfo>> splittedList = Split(returnedDrugs);
                    foreach (List<DrugsInfo> listItem in splittedList)
                    {
                        if (listItem.Count != 7)
                        {
                            for (int m = listItem.Count; m < 7; m++)
                            {
                                DrugsInfo drugInfoForNaN = new DrugsInfo();
                                drugInfoForNaN.DrugName = string.Empty;
                                drugInfoForNaN.ExpireDate = string.Empty;
                                drugInfoForNaN.Mi = string.Empty;
                                drugInfoForNaN.EK = string.Empty;
                                drugInfoForNaN.Doz = string.Empty;
                                listItem.Add(drugInfoForNaN);
                            }
                        }
                        List<DrugsInfo> orderedList = listItem.OrderByDescending(x => x.DrugName).ToList();

                        DrugBarcodeInfo drugBarcodeInfo = DrugBarcodeInfo_Factory(entry.Key, storeName, entry.Value[0].ObjectID);
                        drugBarcodeInfo.Drugs = orderedList;
                        barcodeInfoList.Add(drugBarcodeInfo);
                    }
                }
                else
                {
                    if (returnedDrugs.Count != 7)
                    {
                        for (int m = returnedDrugs.Count; m < 7; m++)
                        {
                            DrugsInfo drugInfoForNaN = new DrugsInfo();
                            drugInfoForNaN.DrugName = string.Empty;
                            drugInfoForNaN.ExpireDate = string.Empty;
                            drugInfoForNaN.Mi = string.Empty;
                            drugInfoForNaN.EK = string.Empty;
                            drugInfoForNaN.Doz = string.Empty;
                            returnedDrugs.Add(drugInfoForNaN);
                        }
                    }

                    List<DrugsInfo> orderedList = returnedDrugs.OrderByDescending(x => x.DrugName).ToList();

                    DrugBarcodeInfo drugBarcodeInfo = DrugBarcodeInfo_Factory(entry.Key, storeName, entry.Value[0].ObjectID);
                    drugBarcodeInfo.Drugs = orderedList;
                    barcodeInfoList.Add(drugBarcodeInfo);
                }


            }

            return barcodeInfoList;
        }

        private DrugBarcodeInfo DrugBarcodeInfo_Factory(Guid? patientId, string storeName, Guid? kscheduleObjectID)
        {
            Guid patientIDGuid = new Guid(patientId.ToString());
            TTObjectContext context = new TTObjectContext(true);
            DrugBarcodeInfo info = new DrugBarcodeInfo();
            Patient patient = (Patient)context.GetObject(patientIDGuid, typeof(Patient));
            KSchedule kSchedule = (KSchedule)context.GetObject(kscheduleObjectID.Value, typeof(KSchedule));

            info.PatientFullName = patient.Name + " " + patient.Surname;
            info.PrintDate = Common.RecTime().Day.ToString() + "." + Common.RecTime().Month.ToString() + "." + Common.RecTime().Year.ToString();
            info.ProcedureName = storeName;
            info.ProcedureCode = SubEpisode.GetByPatient(context, patientIDGuid)[0].ProtocolNo;
            info.BirthDate = patient.BirthDate.ToString();
            info.AcceptionNumber = info.ProcedureCode;
            info.AcceptionDoctor = kSchedule.MKYS_TeslimAlan;
            info.IslemNo = kSchedule.StockActionID.ToString();
            info.OrderDate = kSchedule.TransactionDate.ToString();
            info.Drugs = new List<DrugsInfo>();
            return info;
        }

        private List<DrugsInfo> DrugsInfo_Factory(List<KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate_Class> kschMat)
        {
            List<DrugsInfo> drugs = new List<DrugsInfo>();
            foreach (KSchedule.GetKscheduleMaterialsGroupByPatientAndExpDate_Class item in kschMat)
            {
                DrugsInfo drugInfo = new DrugsInfo();
                drugInfo.DrugName = String.IsNullOrEmpty(item.Materialname) ? " " : item.Materialname;

                string orderFrequency = string.Empty;
                if (item.DrugOrderObjectID.HasValue)
                {
                    TTObjectContext context = new TTObjectContext(true);
                    DrugOrder drugOrder = context.GetObject<DrugOrder>(item.DrugOrderObjectID.Value);
                    if (drugOrder != null && drugOrder.HospitalTimeSchedule != null)
                        orderFrequency = drugOrder.HospitalTimeSchedule.Name.Trim() + drugOrder.DoseAmount.ToString();
                }
                string amount = item.Amount != null ? item.Amount.ToString() : string.Empty;

                drugInfo.Doz = orderFrequency;
                drugInfo.Mi = amount;
                if (item.ExpirationDate != null)
                    drugInfo.ExpireDate = item.ExpirationDate.Value.ToShortDateString();
                drugs.Add(drugInfo);
            }

            return drugs;
        }

        private List<List<DrugsInfo>> Split(List<DrugsInfo> source)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 7)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }



        public class KScheduleIsImmediatle_Input
        {
            public Guid KScheduleObjID { get; set; }
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string IsImmadiatleControl(KScheduleIsImmediatle_Input input)
        {
            TTObjectContext context = new TTObjectContext(false);
            string returnMsg = string.Empty;
            List<DrugOrder> drugOrderList = new List<DrugOrder>();
            KSchedule kSchedule = (KSchedule)context.GetObject(input.KScheduleObjID, typeof(KSchedule));
            foreach (KScheduleMaterial mat in kSchedule.KScheduleMaterials)
            {
                List<DrugOrderDetail> drugOrderDet = mat.KScheduleCollectedOrder.DrugOrderDetails.Where(d => d.DrugOrder.IsImmediate == true).ToList();
                foreach (DrugOrderDetail det in drugOrderDet)
                {
                    if (drugOrderList.Contains(det.DrugOrder) == false)
                    {
                        drugOrderList.Add(det.DrugOrder);
                    }
                }

            }
            foreach (DrugOrder dOrder in drugOrderList)
            {
                returnMsg += dOrder.Material.Barcode + "-" + dOrder.Material.Name + ",";
            }
            return returnMsg;
        }






        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string StoppedDrugOrderCheck(KScheduleIsImmediatle_Input input)
        {
            TTObjectContext context = new TTObjectContext(false);
            string returnMsg = string.Empty;
            KSchedule kSchedule = (KSchedule)context.GetObject(input.KScheduleObjID, typeof(KSchedule));
            foreach (KScheduleMaterial mat in kSchedule.KScheduleMaterials)
            {
                foreach (DrugOrderDetail stateDrugOrderDetail in mat.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    if (stateDrugOrderDetail.DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped || stateDrugOrderDetail.DrugOrder.CurrentStateDefID == DrugOrder.States.Cancelled)
                    {
                        // mat.Status = StockActionDetailStatusEnum.Cancelled;
                        returnMsg += mat.Material.Name + " , ";
                    }
                }
            }
            foreach (KSchedulePatienOwnDrug ownDrug in kSchedule.KSchedulePatienOwnDrugs)
            {
                foreach (DrugOrderDetail stateDrugOrderDetail in ownDrug.DrugOrderDetails)
                {
                    if (stateDrugOrderDetail.DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped || stateDrugOrderDetail.DrugOrder.CurrentStateDefID == DrugOrder.States.Cancelled)
                    {
                        //  ownDrug.StockActionStatus = StockActionDetailStatusEnum.Cancelled;
                        returnMsg += ownDrug.Material.Name + " , ";
                    }
                }
            }
            return returnMsg;
        }




    }
}