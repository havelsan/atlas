//$A64F5AEF
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Drawing;
using System.Reflection;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text;
using Newtonsoft.Json;
using TTUtils;
using TTStorageManager.Security;
using System.Web.Script.Serialization;
using RenkliEncryption;
using Core.Security;
using System.Diagnostics;
using Core.Modules.Saglik_Lojistik.Eczane_Modulleri.Ilac_Direktifi_Giris_Modulu;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DrugOrderIntroductionServiceController : Controller
    {
        #region Yeni order ekranı
        public class DrugOrderIntroductionNewForm_Input
        {
            public Guid episodeObjectID { get; set; }
            public Guid masterResourceObjectID { get; set; }
            public Guid subEpisodeObjectID { get; set; }
            public bool allDate { get; set; }
            public Guid activeInPatientPhysicianApp { get; set; }
        }

        public class PatientDTO
        {
            public Guid ObjectID { get; set; }
            public int Age { get; set; }
            public string Sex { get; set; }
            public List<Guid> PatientAllergicIngredient = new List<Guid>();
            public bool IsSGK { get; set; }
            public bool IsLiverTransplant { get; set; }
            public bool IsRequestAlbuminExamination { get; set; }
            public double ResultAlbuminExamination { get; set; }
            public List<ActiveInfectionCommiteeApprove> ActiveInfectionCommiteeApproves = new List<ActiveInfectionCommiteeApprove>();
        }

        public class ActiveInfectionCommiteeApprove
        {
            public Guid MaterialID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        //Yeni order ekranı için yapılan class
        public class DrugOrderIntroductionNewForm_Output
        {
            public DrugOrderIntroduction drugOrderIntroduction { get; set; }
            public List<HospitalTimeSchedule> hospitalTimeSchedule { get; set; }
            public List<HospitalTimeScheduleDetail> hospitalTimeScheduleDetail { get; set; }
            public PatientDTO patientDTO = new PatientDTO();
            public List<DrugOrderIntroductionGridViewModel> DrugOrderGirdViewModelList { get; set; }
            //İlaç Direktiflerinde son kaç günün orderları listelensin parametresi
            public int DrugOrderQueryDate { get; set; }
            //Geriye dönük verilebilecek order süresi (Saat bazında)
            public int DrugOrderTimeOffset { get; set; }
            public bool IsHimssRequired = false;
            public bool isVademecumEntegrasyon = false;
            public bool checkDrugAmount = false;
            public int OrderRestDayCount { get; set; }
            public string OrderRestDayDescription { get; set; }
            public bool isVisible { get; set; }
            public bool isCV { get; set; }

        }

        //Yeni order ekranı için yapılan initialize metodu
        [HttpPost]
        public DrugOrderIntroductionNewForm_Output CreateDrugOrderIntroductionNewForm(DrugOrderIntroductionNewForm_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                DrugOrderIntroductionNewForm_Output outPut = new DrugOrderIntroductionNewForm_Output();
                DrugOrderIntroduction newDrugOrderIntroduction = new DrugOrderIntroduction(objectContext);
                Episode episode = objectContext.GetObject<Episode>(input.episodeObjectID);
                Patient patient = episode.Patient;
                SubEpisode subEpisode = objectContext.GetObject<SubEpisode>(input.subEpisodeObjectID);
                newDrugOrderIntroduction.CurrentStateDefID = DrugOrderIntroduction.States.New;
                outPut.drugOrderIntroduction = newDrugOrderIntroduction;
                outPut.hospitalTimeSchedule = objectContext.QueryObjects<HospitalTimeSchedule>("ACTIVE = 1").ToList();
                outPut.hospitalTimeScheduleDetail = objectContext.QueryObjects<HospitalTimeScheduleDetail>("HOSPITALTIMESCHEDULE.ACTIVE=1").ToList();
                outPut.patientDTO = PreparePatientDTO(subEpisode);
                /*outPut.patientDTO.ObjectID = patient.ObjectID;
                outPut.patientDTO.Age = patient.Age.Value;
                outPut.patientDTO.Sex = patient.Sex.KODU;
                if (subEpisode.SGKSEP != null)
                {
                    if (string.IsNullOrEmpty(subEpisode.SGKSEP.MedulaTakipNo) == false)
                        outPut.patientDTO.IsSGK = true;
                    else
                        outPut.patientDTO.IsSGK = false;
                }
                else
                    outPut.patientDTO.IsSGK = false;*/
                outPut.DrugOrderQueryDate = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("DRUGORDERQUERYDATE", "0"));
                outPut.DrugOrderTimeOffset = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("DRUGORDERTIMEOFFSET", "0"));

                if (subEpisode.OpeningDate > Common.RecTime().AddHours(-outPut.DrugOrderTimeOffset))
                    outPut.DrugOrderTimeOffset = 0;

                if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HIMSSINTEGRATED", "FALSE")))
                {
                    ResSection masterResource = objectContext.GetObject<ResSection>(input.masterResourceObjectID);
                    if (masterResource.HimssRequired.HasValue && masterResource.HimssRequired.Value == true)
                    {
                        outPut.DrugOrderTimeOffset = 0;
                        outPut.IsHimssRequired = true;
                    }
                }

                if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMENTEGRASYON", "FALSE")))
                {
                    outPut.isVademecumEntegrasyon = true;
                }

                if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("ORDERCHECKDRUGAMOUNT", "FALSE")))
                {
                    outPut.checkDrugAmount = true;
                }

                DateTime startDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 00:00:00");
                DateTime endDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");
                BindingList<OrderRestDayDef.GetOrderRestDayByDate_Class> restDay = OrderRestDayDef.GetOrderRestDayByDate(startDate, endDate);
                if (restDay.Count > 0)
                {
                    outPut.OrderRestDayCount = restDay[0].RestDayCount.Value;
                    outPut.OrderRestDayDescription = restDay[0].RestDayDescription;
                }
                else
                {
                    outPut.OrderRestDayCount = 1;
                    outPut.OrderRestDayDescription = string.Empty;
                }

                BindingList<DrugOrder.GetActiveSameDayOrderRQ_Class> sameDayOrders = DrugOrder.GetActiveSameDayOrderRQ(input.episodeObjectID, startDate);
                if (sameDayOrders.Count > 0)
                    outPut.isCV = true;
                else
                    outPut.isCV = false;

                GetDrugOrderGridViewModel_Input getDrugOrderViewModelInput = new GetDrugOrderGridViewModel_Input();
                getDrugOrderViewModelInput.episodeObjectID = input.episodeObjectID;
                getDrugOrderViewModelInput.activeInPatientPhysicianApp = input.activeInPatientPhysicianApp;
                if (input.allDate != true)
                {
                    getDrugOrderViewModelInput.PlannedEndDate = Convert.ToDateTime(Common.RecTime().AddDays(1).ToShortDateString() + " 23:59:59");
                    getDrugOrderViewModelInput.PlannedStartDate = Convert.ToDateTime(Common.RecTime().AddDays(outPut.DrugOrderQueryDate).ToShortDateString() + " 00:00:00");
                }

                outPut.DrugOrderGirdViewModelList = GetDrugOrderGridViewModel(getDrugOrderViewModelInput);
                //if (outPut.patientDTO.PatientAllergicIngredient != null && patient.MedicalInformation != null)
                //    outPut.patientDTO.PatientAllergicIngredient = patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies.Select(x => x.ActiveIngredient.ObjectID).ToList();

                outPut.isVisible = Common.CurrentUser.HasRole(TTRoleNames.Ilac_Direktif_Giris_Yeni);
                return outPut;
            }
        }

        public PatientDTO PreparePatientDTO(SubEpisode subEpisode)
        {
            PatientDTO patientDTO = new PatientDTO();
            patientDTO.ObjectID = subEpisode.Episode.Patient.ObjectID;
            patientDTO.Age = subEpisode.Episode.Patient.Age.Value;
            patientDTO.Sex = subEpisode.Episode.Patient.Sex.KODU;
            if (subEpisode.SGKSEP != null)
            {
                if (string.IsNullOrEmpty(subEpisode.SGKSEP.MedulaTakipNo) == false)
                    patientDTO.IsSGK = true;
                else
                    patientDTO.IsSGK = false;
            }
            else
                patientDTO.IsSGK = false;

            if (patientDTO.PatientAllergicIngredient != null && subEpisode.Episode.Patient.MedicalInformation != null)
            {
                List<Guid> allergies = new List<Guid>();
                if (subEpisode.Episode.Patient.MedicalInformation.MedicalInfoAllergies != null)
                {
                    foreach (MedicalInfoDrugAllergies drugAllergies in subEpisode.Episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies)
                    {
                        if (drugAllergies.ActiveIngredient != null)
                            allergies.Add(drugAllergies.ActiveIngredient.ObjectID);

                    }
                }
                //patientDTO.PatientAllergicIngredient = subEpisode.Episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies.Select(x => x.ActiveIngredient.ObjectID).ToList();
                patientDTO.PatientAllergicIngredient = allergies;
            }

            string codeListText = TTObjectClasses.SystemParameter.GetParameterValue("LIVERTRANSPLANTCODES", "609.080,P609.080");
            List<string> codes = codeListText.Split(',').ToList();
            BindingList<Patient.PatientHasProcedureBySUTCodes_Class> liver = Patient.PatientHasProcedureBySUTCodes(codes, patientDTO.ObjectID);
            if (liver.Count > 0)
                patientDTO.IsLiverTransplant = true;
            else
                patientDTO.IsLiverTransplant = false;

            string albuminTestCode = TTObjectClasses.SystemParameter.GetParameterValue("ALBUMINTESTCODE", "900.210");
            double resultValue = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("HUMANALBUMINCHECKRESULTVALUE", "2.5"));
            int testResult = LaboratoryProcedure.CheckHumanAlbuminTest(subEpisode.ObjectID.ToString(), albuminTestCode);
            if (testResult == 0)
            {
                patientDTO.IsRequestAlbuminExamination = false;
                patientDTO.ResultAlbuminExamination = 0;
            }
            else
            {
                patientDTO.IsRequestAlbuminExamination = true;
                patientDTO.ResultAlbuminExamination = testResult;
            }

            string checkInfectionCommitee = TTObjectClasses.SystemParameter.GetParameterValue("INFECTIONCOMMITEEDAYAPPROVEL", "FALSE");
            if (checkInfectionCommitee == "TRUE")
            {
                BindingList<InfectionCommittee.GetActiveInfectionComApprovel_Class> getActiveInfections = InfectionCommittee.GetActiveInfectionComApprovel(subEpisode.ObjectID, Common.RecTime());
                foreach (InfectionCommittee.GetActiveInfectionComApprovel_Class activeInfection in getActiveInfections)
                {
                    ActiveInfectionCommiteeApprove commiteeApprove = new ActiveInfectionCommiteeApprove();
                    commiteeApprove.MaterialID = activeInfection.Material.Value;
                    commiteeApprove.StartDate = activeInfection.PlannedStartTime.Value;
                    commiteeApprove.EndDate = activeInfection.EndDate.Value;
                    patientDTO.ActiveInfectionCommiteeApproves.Add(commiteeApprove);
                }
            }
            return patientDTO;

        }

        public class SaveDrugOrder_Output
        {
            public bool IsSuccess = false;
            public List<DrugOrderIntroductionGridViewModel> GridViewModel { get; set; }
            public StringBuilder ErrorMessage = new StringBuilder();
        }

        public class DrugOrderIntroductionGridViewModel
        {
            //Client'da malzemeleri objectID ile import etmek için
            public List<DrugOrderTimceSchedule> DrugOrderIntroDuctionTimeSchedule = new List<DrugOrderTimceSchedule>();
            public string ID { get; set; }
            public Guid? ParentDrugOrderObjectID { get; set; }
            public DrugOrderStatusEnum Status { get; set; }
            public Guid LastDrugOrderObjectID { get; set; }
            public DrugOrderIntroductionDet drugOrderIntroductionDet { get; set; }

            public DateTime? PlannedStartTime;
            public DateTime? PlannedEndTime;
            public DateTime? CreationDate;
            public Guid? HospitalTimeScheduleObjectID;
            public double DoseAmount;
            public int Day;
            public string UsageNote;
            public bool? IsImmediate;
            public bool? PatientOwnDrug;
            public bool? CaseOfNeed;
            public bool? IsUpgraded;
            public DrugInfo Material = new DrugInfo();
            public DrugUsageTypeEnum? DrugUsageType;
            public DrugOrderTypeEnum? DrugOrderType;
            public PeriodUnitTypeEnum PeriodUnitType = PeriodUnitTypeEnum.DayPeriod;
            public HospitalTimeSchedule HospitalTimeSchedule;
            public string DoctorName { get; set; }
            public bool? IsCV { get; set; }
            public string RepeatDayWarning { get; set; }
            public bool? IsTeleOrder { get; set; }
            public Guid? DoctorGuid { get; set; }
        }

        public class DrugOrderIntroductionDetDTO
        {
            public DateTime? PlannedStartTime;
            public DateTime? PlannedEndTime;
            public Guid? HospitalTimeScheduleObjectID;
            public double DoseAmount;
            public int Day;
            public string UsageNote;
            public bool? IsImmediate;
            public bool? PatientOwnDrug;
            public bool? CaseOfNeed;
            public DrugInfo Material;
            public DrugUsageTypeEnum? DrugUsageType;
            public DrugOrderTypeEnum? DrugOrderType;
            public PeriodUnitTypeEnum PeriodUnitType = PeriodUnitTypeEnum.DayPeriod;
            public HospitalTimeSchedule HospitalTimeSchedule;
        }


        public class DrugOrderTimceSchedule
        {
            public DateTime? Time;
            public int? DetailNo;
            public string UsageNote { get; set; }
            public double? DoseAmount { get; set; }
            public string MasterID { get; set; }
            public bool UpgradeDetail { get; set; }
        }

        public class DrugOrderIntroductionFormViewModel
        {
            public List<DrugOrderIntroductionGridViewModel> DrugOrderIntroductionGridViewModelDTO;
            public List<DrugOrderIntroductionGridViewModel> DrugOrderIntroductionGridViewModel;
            public DrugOrderIntroduction DrugOrderIntroduction;
        }

        public List<DrugOrderIntroductionDet> GenerateDrugOrderIntroductionForDrugOrder(TTObjectContext objectContext, List<DrugOrderIntroductionGridViewModel> drugOrderIntroductionGridViewModel)
        {
            List<DrugOrderIntroductionDet> introductionList = new List<DrugOrderIntroductionDet>();
            foreach (DrugOrderIntroductionGridViewModel gridViewModel in drugOrderIntroductionGridViewModel)
            {
                DrugOrderIntroductionDet introductionDet = new DrugOrderIntroductionDet(objectContext);
                introductionDet.CaseOfNeed = gridViewModel.CaseOfNeed;
                introductionDet.Day = gridViewModel.Day;
                introductionDet.DoseAmount = gridViewModel.DoseAmount;
                introductionDet.DrugOrderType = gridViewModel.DrugOrderType;
                introductionDet.DrugUsageType = gridViewModel.DrugUsageType;
                introductionDet.IsImmediate = gridViewModel.IsImmediate;
                introductionDet.IsCV = gridViewModel.IsCV;
                introductionDet.IsTeleOrder = gridViewModel.IsTeleOrder;
                introductionDet.PatientOwnDrug = gridViewModel.PatientOwnDrug;
                introductionDet.PeriodUnitType = gridViewModel.PeriodUnitType;
                introductionDet.PlannedStartTime = gridViewModel.PlannedStartTime;
                introductionDet.UsageNote = gridViewModel.UsageNote;
                introductionDet.RepeatDayWarning = gridViewModel.RepeatDayWarning;
                introductionDet.Material = objectContext.GetObject<Material>(new Guid(gridViewModel.Material.drugObjectId));
                if (gridViewModel.DoctorGuid.HasValue)
                    introductionDet.ProcedureDoctor = objectContext.GetObject<ResUser>(gridViewModel.DoctorGuid.Value);
                else
                    introductionDet.ProcedureDoctor = Common.CurrentResource as ResUser;
                introductionDet.DetailCount = gridViewModel.DrugOrderIntroDuctionTimeSchedule.Count;
                gridViewModel.drugOrderIntroductionDet = introductionDet;
                if (gridViewModel.HospitalTimeScheduleObjectID.HasValue)
                {
                    introductionDet.HospitalTimeSchedule = objectContext.GetObject<HospitalTimeSchedule>(gridViewModel.HospitalTimeScheduleObjectID.Value);
                    if (introductionDet.Frequency.HasValue == false && introductionDet.HospitalTimeSchedule != null)
                    {
                        switch (introductionDet.HospitalTimeSchedule.Frequency)
                        {
                            case RefactoredFrequencyEnum.Q1H:
                                introductionDet.Frequency = FrequencyEnum.Q1H;
                                break;
                            case RefactoredFrequencyEnum.Q2H:
                                introductionDet.Frequency = FrequencyEnum.Q2H;
                                break;
                            case RefactoredFrequencyEnum.Q3H:
                                introductionDet.Frequency = FrequencyEnum.Q3H;
                                break;
                            case RefactoredFrequencyEnum.Q4H:
                                introductionDet.Frequency = FrequencyEnum.Q4H;
                                break;
                            case RefactoredFrequencyEnum.Q6H:
                                introductionDet.Frequency = FrequencyEnum.Q6H;
                                break;
                            case RefactoredFrequencyEnum.Q8H:
                                introductionDet.Frequency = FrequencyEnum.Q8H;
                                break;
                            case RefactoredFrequencyEnum.Q12H:
                                introductionDet.Frequency = FrequencyEnum.Q12H;
                                break;
                            case RefactoredFrequencyEnum.Q24H:
                                introductionDet.Frequency = FrequencyEnum.Q24H;
                                break;
                            default:
                                break;
                        }
                    }
                }
                introductionList.Add(introductionDet);
            }

            return introductionList;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Direktif_Giris_Yeni)]
        public SaveDrugOrder_Output SaveDrugOrder(DrugOrderIntroductionFormViewModel model)
        {
            if (model.DrugOrderIntroductionGridViewModelDTO.Count == 0)
                throw new TTException("İlaç seçilmedi!");
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                SaveDrugOrder_Output output = new SaveDrugOrder_Output();
                objectContext.AddToRawObjectList(model.DrugOrderIntroduction);
                objectContext.AddToRawObjectList(model.DrugOrderIntroductionGridViewModelDTO.Select(x => x.HospitalTimeSchedule));
                //objectContext.AddToRawObjectList(GenerateDrugOrderIntroductionForDrugOrder(objectContext, model.DrugOrderIntroductionGridViewModel.Select(x => x.DrugOrderIntroductionDetailDTO).ToList()));
                objectContext.ProcessRawObjects(false);


                foreach (var orderUsegeType in model.DrugOrderIntroductionGridViewModelDTO)
                {
                    if (orderUsegeType.DrugUsageType != (model.DrugOrderIntroductionGridViewModel.Where(x => x.ID == orderUsegeType.ID).FirstOrDefault().DrugUsageType))
                    {
                        orderUsegeType.DrugUsageType = model.DrugOrderIntroductionGridViewModel.Where(x => x.ID == orderUsegeType.ID).FirstOrDefault().DrugUsageType;
                    }
                }

                List<DrugOrderIntroductionDet> introductionDetList = GenerateDrugOrderIntroductionForDrugOrder(objectContext, model.DrugOrderIntroductionGridViewModelDTO);

                DrugOrderIntroduction drugOrderIntroduction = (DrugOrderIntroduction)objectContext.GetLoadedObject(model.DrugOrderIntroduction.ObjectID);

                if (model.DrugOrderIntroductionGridViewModelDTO != null && model.DrugOrderIntroductionGridViewModelDTO.Count > 0)
                {
                    foreach (var item in introductionDetList)
                    {
                        var DrugOrderIntroductionDetImported = (DrugOrderIntroductionDet)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)DrugOrderIntroductionDetImported).IsDeleted)
                            continue;
                        DrugOrderIntroductionDetImported.DrugOrderIntroduction = drugOrderIntroduction;
                    }

                    foreach (var item in model.DrugOrderIntroductionGridViewModelDTO.Select(x => x.HospitalTimeSchedule))
                    {
                        var hospitalTimeScheduleImported = (HospitalTimeSchedule)objectContext.GetLoadedObject(item.ObjectID);
                        foreach (HospitalTimeScheduleDetail hospitalTimeScheduleDetail in hospitalTimeScheduleImported.HospitalTimeScheduleDetails)
                        {
                            var hospitalTimeScheduleDetailImported = (HospitalTimeScheduleDetail)objectContext.GetLoadedObject(hospitalTimeScheduleDetail.ObjectID);
                            hospitalTimeScheduleDetailImported.HospitalTimeSchedule = hospitalTimeScheduleImported;
                        }
                    }
                }

                List<DrugOrderIntroductionGridViewModel> drugOrderIntroductionGridViewModel = model.DrugOrderIntroductionGridViewModelDTO;

                if (drugOrderIntroduction.ActiveInPatientPhysicianApp == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25808", "Hasta yatan durumunda olduğu için Klinik Doktor işlemlerinde ilaç yazabilirsiniz."));

             


                string checkKschedule = CheckSameDrugToKschedule(model, drugOrderIntroduction.ActiveInPatientPhysicianApp);
                if (string.IsNullOrEmpty(checkKschedule) == false)
                    throw new TTException(checkKschedule);

                foreach (var item in drugOrderIntroductionGridViewModel)
                {
                    item.HospitalTimeSchedule = (HospitalTimeSchedule)objectContext.GetLoadedObject(item.HospitalTimeSchedule.ObjectID);
                    //item.DrugOrderIntroductionDetail.RefactoredFrequency = (HospitalTimeSchedule)objectContext.GetLoadedObject(item.DrugOrderIntroductionDetail.ObjectID);
                }

                Dictionary<string, double?> overMaxDoseDrugs = DrugOrder.GetMaxDose(introductionDetList);

                if (overMaxDoseDrugs.Count > 0)
                {
                    StringBuilder overDoseDrugs = new StringBuilder();
                    overDoseDrugs.Append("Maksimum Doz miktarını aşan bir order veremezsiniz!");
                    foreach (var drug in overMaxDoseDrugs)
                    {
                        overDoseDrugs.AppendLine(drug.Key);
                        overDoseDrugs.Append(" ilacı için Maksimum Doz miktarı: ");
                        overDoseDrugs.Append(drug.Value.ToString());
                    }
                    throw new TTException(overDoseDrugs.ToString());
                }

                Dictionary<string, double?> maxDoseDay = DrugOrder.GetMaxDoseDay(introductionDetList);


                if (maxDoseDay.Count > 0)
                {
                    StringBuilder maxDoseDayString = new StringBuilder();
                    foreach (var overmaxDoseDayDrug in maxDoseDay)
                    {
                        maxDoseDayString.AppendLine(overmaxDoseDayDrug.Key);
                        maxDoseDayString.Append(" ilacı ");
                        maxDoseDayString.Append(overmaxDoseDayDrug.Value + "günden fazla yazılamaz !");
                    }
                    throw new TTException(maxDoseDayString.ToString());
                }

                Episode episode = drugOrderIntroduction.Episode;

                GenerateDrugOrders(objectContext, drugOrderIntroductionGridViewModel);

                #region Yeni_DrugOrder_Yaratma_icin_kapatildi
                //foreach (DrugOrderIntroductionGridViewModel gridViewModel in drugOrderIntroductionGridViewModel)
                //{
                //    DrugOrder drugOrder = new DrugOrder(objectContext);
                //    DrugOrderIntroductionDet drugOrderIntroductionDet = gridViewModel.drugOrderIntroductionDet;
                //    drugOrder.Material = drugOrderIntroductionDet.Material;
                //    drugOrder.IsImmediate = drugOrderIntroductionDet.IsImmediate;
                //    drugOrder.Day = drugOrderIntroductionDet.Day;
                //    drugOrder.DoseAmount = drugOrderIntroductionDet.DoseAmount;
                //    drugOrder.Frequency = drugOrderIntroductionDet.Frequency;
                //    drugOrder.HospitalTimeSchedule = gridViewModel.HospitalTimeSchedule;
                //    drugOrder.UsageNote = drugOrderIntroductionDet.UsageNote;
                //    drugOrder.PlannedStartTime = gridViewModel.DrugOrderIntroDuctionTimeSchedule[0].Time;
                //    drugOrder.UsageNote = drugOrderIntroductionDet.UsageNote + " " + drugOrderIntroductionDet.DrugDescription;
                //    drugOrder.Description = drugOrderIntroductionDet.DrugDescription;
                //    drugOrder.DescriptionType = drugOrderIntroductionDet.DrugDescriptionType;
                //    drugOrder.ParentDrugOrder = gridViewModel.ParentDrugOrderObjectID;
                //    drugOrderIntroductionDet.DrugOrder = drugOrder;
                //    if (drugOrderIntroductionDet.DrugUsageType != null)
                //        drugOrder.DrugUsageType = drugOrderIntroductionDet.DrugUsageType;
                //    else
                //        drugOrder.DrugUsageType = ((DrugDefinition)drugOrder.Material).RouteOfAdmin.DrugUsageType;

                //    if (drugOrderIntroductionDet.DrugOrderType != null)
                //        drugOrder.DrugOrderType = drugOrderIntroductionDet.DrugOrderType;
                //    else
                //        drugOrder.DrugOrderType = DrugOrderTypeEnum.Treatment;

                //    drugOrder.Episode = episode;
                //    drugOrder.MasterResource = drugOrderIntroduction.MasterResource;
                //    drugOrder.SecondaryMasterResource = drugOrderIntroduction.SecondaryMasterResource;
                //    drugOrder.SubEpisode = drugOrderIntroduction.SubEpisode;

                //    drugOrder.Episode = drugOrderIntroduction.ActiveInPatientPhysicianApp.Episode;
                //    drugOrder.MasterResource = drugOrderIntroduction.ActiveInPatientPhysicianApp.MasterResource;
                //    drugOrder.SecondaryMasterResource = drugOrderIntroduction.ActiveInPatientPhysicianApp.SecondaryMasterResource;
                //    drugOrder.InPatientPhysicianApplication = drugOrderIntroduction.ActiveInPatientPhysicianApp;

                //    drugOrder.CaseOfNeed = drugOrderIntroductionDet.CaseOfNeed;
                //    drugOrder.PatientOwnDrug = drugOrderIntroductionDet.PatientOwnDrug;
                //    drugOrder.DrugUsageType = drugOrderIntroductionDet.DrugUsageType;
                //    drugOrder.DoseAmount = drugOrderIntroductionDet.DoseAmount;

                //    if (DrugOrder.GetContinueDrugOrder(drugOrder.Episode.ObjectID, drugOrder.Material.ObjectID, (DateTime)drugOrder.PlannedStartTime))
                //    {
                //        DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);

                //        bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                //        double unitAmount = 0;
                //        double totalAmount = 0;
                //        if (drugType)
                //        {
                //            unitAmount = (double)drugOrder.DoseAmount;
                //            totalAmount = unitAmount * (double)gridViewModel.DrugOrderIntroDuctionTimeSchedule.Count;
                //        }
                //        else
                //        {
                //            if (drugDefinition.Volume != null)
                //            {
                //                unitAmount = (double)drugOrder.DoseAmount;
                //                totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)gridViewModel.DrugOrderIntroDuctionTimeSchedule.Count);
                //            }
                //            else
                //            {
                //                throw new TTException(drugDefinition.Name + " ilacının Hacim bilgisi girilmemiştir. İlacı yazabilmeniz için hacim bilgilerinin girilmesi gerekir. Bilgi işleme haber veriniz.");
                //            }
                //        }
                //        drugOrder.Amount = (double)totalAmount;
                //        BindingList<PharmacyStoreDefinition> pharmacys = PharmacyStoreDefinition.GetInpatientPharmacyStore(objectContext);
                //        PharmacyStoreDefinition pharmacyStoreClinic = (PharmacyStoreDefinition)pharmacys[0];
                //        drugOrder.Store = (Store)pharmacyStoreClinic;

                //        bool inheld = IsWorkWithStock(drugDefinition, drugOrder);

                //        if (drugOrder.Material is MagistralPreparationDefinition == false)
                //        {
                //            if (drugOrder.PatientOwnDrug.HasValue == false || drugOrder.PatientOwnDrug == false)
                //            {
                //                if (inheld)
                //                {
                //                    DateTime detailTime = drugOrder.PlannedStartTime.Value;
                //                    drugOrder.Type = TTUtils.CultureService.GetText("M26287", "K-Çizelgesi");
                //                }
                //                else
                //                {
                //                    IList equivalentDrugs = drugDefinition.GetEquivalentDrugs();
                //                    if (equivalentDrugs != null)
                //                    {
                //                        bool equInheld = false;
                //                        foreach (DrugDefinition drug in equivalentDrugs)
                //                        {
                //                            if (((Material)drug).ExistingInheld(((Store)pharmacyStoreClinic)))
                //                            {
                //                                equInheld = true;
                //                                break;
                //                            }
                //                        }

                //                        if (equInheld)
                //                        {
                //                            drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                //                            if (drugDefinition.PrescriptionType == null)
                //                            {
                //                                throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26055", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü doldurtunuz."));
                //                            }

                //                            if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                //                            {
                //                                throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                //                            }
                //                            //}
                //                        }
                //                        else if (episode.PatientStatus == PatientStatusEnum.Inpatient)
                //                        {
                //                            drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                //                            if (drugDefinition.PrescriptionType == null)
                //                            {
                //                                throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26055", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü doldurtunuz."));
                //                            }

                //                            if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                //                            {
                //                                throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                //                            }
                //                            //throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M55053", " ilaç Stokta bulunmamaktadır.\r\n"));
                //                        }
                //                    }
                //                    else
                //                    {
                //                        drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                //                        if (drugDefinition.PrescriptionType == null)
                //                        {
                //                            throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26055", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü doldurtunuz."));
                //                        }

                //                        if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                //                        {
                //                            throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                //                        }
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                drugOrder.Type = TTUtils.CultureService.GetText("M25807", "Hasta Yanında Getirdi");
                //            }
                //        }
                //        else
                //        {
                //            BindingList<PharmacyStoreDefinition> pharmacyStoreClinics = PharmacyStoreDefinition.GetInpatientPharmacyStore(objectContext);
                //            if (drugOrder.Material.ExistingInheld(pharmacyStoreClinics[0]))
                //            {
                //                drugOrder.Type = TTUtils.CultureService.GetText("M26287", "K-Çizelgesi");
                //            }
                //            else
                //            {
                //                if (drugOrder.Material.ObjectID.ToString() == TTObjectClasses.SystemParameter.GetParameterValue("MAGISTRALPRE", null))
                //                {
                //                    drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                //                    if (drugDefinition.PrescriptionType == null)
                //                    {
                //                        throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26055", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü doldurtunuz."));
                //                    }

                //                    if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                //                    {
                //                        throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                //                    }
                //                }
                //                else
                //                {
                //                    MagistralPreparationDefinition magistral = ((MagistralPreparationDefinition)drugOrder.Material);
                //                    if (magistral.Pharmacology == false)
                //                    {
                //                        throw new TTException(drugDefinition.Name + " majistralinin Klinik Eczanesinde mevcudu olmadığı için yazamazsınız!");
                //                    }
                //                    else
                //                    {
                //                        drugOrder.Type = TTUtils.CultureService.GetText("M25570", "Eczacılık Birimlerinden İstenecek");
                //                    }
                //                }
                //            }
                //        }
                //        int orderDay = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("ORDERPLANNIGDAYPERIOD", "1"));
                //        bool returnDateControl = DrugOrderIntroduction.OrderPlanningDateControl(drugOrder);
                //        if (returnDateControl == false)
                //        {
                //            if (drugOrder.Type != TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi"))
                //            {
                //                if (drugOrder.Day > 1)
                //                {
                //                    throw new TTException(drugOrder.Material.Name + " ilacı hastaya " + orderDay.ToString() + " günden fazla yazılamaz");
                //                }
                //                else
                //                {
                //                    throw new TTException(drugOrder.Material.Name + " ilacı için gün alanı boş geçilemez");
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        throw new TTException(drugOrder.Material.Name + " ilacı daha önce order edilmiş ve hala tedavisi devam etmektedir!!!");
                //    }

                //    if (drugOrder.CaseOfNeed == true)
                //    {
                //        drugOrder.Type = TTUtils.CultureService.GetText("M26386", "Lüzumu Halinde");
                //        drugOrder.CurrentStateDefID = DrugOrder.States.New;
                //    }
                //    if (drugOrder.Type == TTUtils.CultureService.GetText("M26287", "K-Çizelgesi"))
                //    {
                //        if (((DrugDefinition)drugOrder.Material).InfectionApproval != true)
                //        {
                //            bool eligible = true;
                //            GenerateDrugOrderDetails(objectContext, gridViewModel, drugOrder, eligible, drugOrder.Type);


                //            foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                //            {
                //                orderDetail.NursingApplication = drugOrder.NursingApplication;
                //            }
                //        }
                //        else
                //        {
                //            drugOrder.CurrentStateDefID = DrugOrder.States.Approve;
                //            // TO DO : Enfeksiyon Komitesi işlemi başlatılacak.
                //            InfectionCommittee infectionCommittee = new InfectionCommittee(objectContext);
                //            infectionCommittee.ActionDate = Common.RecTime();
                //            infectionCommittee.FromResource = drugOrder.MasterResource;
                //            infectionCommittee.MasterResource = drugOrder.MasterResource;
                //            infectionCommittee.Episode = drugOrder.Episode;
                //            infectionCommittee.SubEpisode = drugOrder.SubEpisode;
                //            infectionCommittee.InPatientPhysicianApplication = drugOrder.InPatientPhysicianApplication;
                //            infectionCommittee.CurrentStateDefID = InfectionCommittee.States.New;
                //            InfectionCommitteeDetail infectionCommitteeDetail = new InfectionCommitteeDetail(objectContext);
                //            infectionCommitteeDetail.DrugOrder = drugOrder;
                //            infectionCommitteeDetail.InfectionCommittee = infectionCommittee;
                //        }
                //    }
                //    else if (drugOrder.Type == TTUtils.CultureService.GetText("M25807", "Hasta Yanında Getirdi"))
                //    {
                //        GenerateDrugOrderDetails(objectContext, gridViewModel, drugOrder, false);

                //        foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                //        {
                //            orderDetail.NursingApplication = drugOrder.NursingApplication;
                //        }

                //        //drugOrderDetail.Update();
                //        //drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;

                //        // Burası düzeltilmesi lazım Planned State is entry yapıldı geçici olarak. SS.
                //        //drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
                //    }
                //    else if (drugOrder.Type == TTUtils.CultureService.GetText("M25570", "Eczacılık Birimlerinden İstenecek"))
                //    {
                //        GenerateDrugOrderDetails(objectContext, gridViewModel, drugOrder, false);

                //        foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                //        {
                //            orderDetail.NursingApplication = drugOrder.NursingApplication;
                //        }

                //        // Burası düzeltilmesi lazım Planned State is entry yapıldı geçici olarak. SS.
                //        drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
                //        Guid EczBrmGuid = new Guid("21ff7408-6eef-4feb-bc6e-e8feff3fcd3d");
                //        IList pharmacologyResource = Resource.GetResource(objectContext, EczBrmGuid.ToString());
                //        MagistralPrescription magistralPrescription = new MagistralPrescription(objectContext);
                //        magistralPrescription.ActionDate = Common.RecTime();
                //        magistralPrescription.FillingDate = Common.RecTime();
                //        magistralPrescription.FromResource = drugOrder.MasterResource;
                //        magistralPrescription.MasterResource = ((ResSection)pharmacologyResource[0]);
                //        magistralPrescription.Episode = drugOrder.Episode;
                //        magistralPrescription.DrugOrder = drugOrder;
                //        magistralPrescription.CurrentStateDefID = MagistralPrescription.States.Record;
                //        BaseTreatmentMaterial materailT = new BaseTreatmentMaterial(objectContext);
                //        materailT.Material = drugOrder.Material;
                //        materailT.Amount = drugOrder.Amount;
                //        materailT.Eligible = true;
                //        materailT.Episode = drugOrder.Episode;
                //        materailT.Store = ((ResSection)pharmacologyResource[0]).Store;
                //        materailT.UseAmount = (int)drugOrder.Amount;
                //        materailT.CurrentStateDefID = BaseTreatmentMaterial.States.New;
                //        magistralPrescription.TreatmentMaterials.Add(materailT);
                //    }
                //}
                #endregion Yeni_DrugOrder_Yaratma_icin_kapatildi

                List<DrugOrder> drugOrders = drugOrderIntroduction.DrugOrderIntroductionDetails.Select(x => x.DrugOrder).ToList();
                CreatedKscheduleForNewDrugOrder(drugOrders, drugOrderIntroduction.ActiveInPatientPhysicianApp, objectContext);
                //CreatedNewKschorderByDrugOrderIntroduction(drugOrderIntroduction, objectContext);
                objectContext.Save();

                if (model.DrugOrderIntroductionGridViewModelDTO[0].IsTeleOrder == false)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    foreach (DrugOrderIntroductionDet det in drugOrderIntroduction.DrugOrderIntroductionDetails)
                    {
                        BindingList<FavoriteDrug.GetFavoriteDrugWithDrugID_Class> favs = FavoriteDrug.GetFavoriteDrugWithDrugID(((ResUser)Common.CurrentUser.UserObject).ObjectID, det.Material.ObjectID);
                        if (favs.Count > 0)
                        {
                            FavoriteDrug existFav = (FavoriteDrug)context.GetObject((Guid)favs[0].ObjectID, "FAVORITEDRUG");
                            existFav.Count = existFav.Count + 1;
                        }
                        else
                        {
                            FavoriteDrug newFavoriteDrug = new FavoriteDrug(context);
                            newFavoriteDrug.Count = 1;
                            newFavoriteDrug.DrugDefinition = ((DrugDefinition)det.Material);
                            newFavoriteDrug.ResUser = ((ResUser)Common.CurrentUser.UserObject);
                        }
                    }
                    context.Save();
                    context.Dispose();
                }
                //GetDrugOrderGridViewModel_Input getDrugOrderViewModelInput = new GetDrugOrderGridViewModel_Input();
                //int drugOrderQueryDate = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("DRUGORDERQUERYDATE", "0"));
                //getDrugOrderViewModelInput.episodeObjectID = drugOrderIntroduction.Episode.ObjectID;
                //getDrugOrderViewModelInput.PlannedEndDate = Convert.ToDateTime(Common.RecTime().AddDays(1).ToShortDateString() + " 23:59:59");
                //getDrugOrderViewModelInput.PlannedStartDate = Convert.ToDateTime(Common.RecTime().AddDays(drugOrderQueryDate).ToShortDateString() + " 00:00:00");
                //output.GridViewModel = GetDrugOrderGridViewModel(getDrugOrderViewModelInput);
                output.IsSuccess = true;
                return output;
            }
        }

        private static void GenerateDrugOrders(TTObjectContext objectContext, List<DrugOrderIntroductionGridViewModel> drugOrderIntroductionGridViewModel)
        {
            foreach (DrugOrderIntroductionGridViewModel gridViewModel in drugOrderIntroductionGridViewModel)
            {
                DrugOrder drugOrder = new DrugOrder(objectContext);
                DrugOrderIntroductionDet drugOrderIntroductionDet = gridViewModel.drugOrderIntroductionDet;
                drugOrder.Material = drugOrderIntroductionDet.Material;
                drugOrder.IsImmediate = drugOrderIntroductionDet.IsImmediate;
                drugOrder.IsCV = drugOrderIntroductionDet.IsCV;
                drugOrder.IsTeleOrder = drugOrderIntroductionDet.IsTeleOrder;
                drugOrder.Day = drugOrderIntroductionDet.Day;
                drugOrder.DoseAmount = drugOrderIntroductionDet.DoseAmount;
                drugOrder.Frequency = drugOrderIntroductionDet.Frequency;
                drugOrder.HospitalTimeSchedule = gridViewModel.HospitalTimeSchedule;
                drugOrder.UsageNote = drugOrderIntroductionDet.UsageNote;
                drugOrder.PlannedStartTime = gridViewModel.DrugOrderIntroDuctionTimeSchedule[0].Time;
                drugOrder.UsageNote = drugOrderIntroductionDet.UsageNote + " " + drugOrderIntroductionDet.DrugDescription;
                drugOrder.Description = drugOrderIntroductionDet.DrugDescription;
                drugOrder.DescriptionType = drugOrderIntroductionDet.DrugDescriptionType;
                drugOrder.RepeatDayWarning = drugOrderIntroductionDet.RepeatDayWarning;
                drugOrder.ProcedureDoctor = drugOrderIntroductionDet.ProcedureDoctor;
                if (drugOrderIntroductionDet.CaseOfNeed.HasValue && drugOrderIntroductionDet.CaseOfNeed.Value)
                    drugOrder.ParentDrugOrder = null;
                else
                    drugOrder.ParentDrugOrder = gridViewModel.ParentDrugOrderObjectID;
                drugOrder.MedulaReportNo = gridViewModel.Material.MedulaReportNo;
                drugOrderIntroductionDet.DrugOrder = drugOrder;
                if (gridViewModel.DrugUsageType != null)
                    drugOrder.DrugUsageType = gridViewModel.DrugUsageType;
                else
                    drugOrder.DrugUsageType = ((DrugDefinition)drugOrder.Material).RouteOfAdmin.DrugUsageType;

                if (drugOrderIntroductionDet.DrugOrderType != null)
                    drugOrder.DrugOrderType = drugOrderIntroductionDet.DrugOrderType;
                else
                    drugOrder.DrugOrderType = DrugOrderTypeEnum.Treatment;

                DrugOrderIntroduction drugOrderIntroduction = drugOrderIntroductionDet.DrugOrderIntroduction;
                drugOrder.Episode = drugOrderIntroduction.Episode;
                drugOrder.MasterResource = drugOrderIntroduction.MasterResource;
                drugOrder.SecondaryMasterResource = drugOrderIntroduction.SecondaryMasterResource;
                drugOrder.SubEpisode = drugOrderIntroduction.SubEpisode;

                drugOrder.Episode = drugOrderIntroduction.ActiveInPatientPhysicianApp.Episode;
                drugOrder.MasterResource = drugOrderIntroduction.ActiveInPatientPhysicianApp.MasterResource;
                drugOrder.SecondaryMasterResource = drugOrderIntroduction.ActiveInPatientPhysicianApp.SecondaryMasterResource;
                drugOrder.InPatientPhysicianApplication = drugOrderIntroduction.ActiveInPatientPhysicianApp;

                drugOrder.CaseOfNeed = drugOrderIntroductionDet.CaseOfNeed;
                drugOrder.PatientOwnDrug = drugOrderIntroductionDet.PatientOwnDrug;
                drugOrder.DrugUsageType = gridViewModel.DrugUsageType;
                drugOrder.DoseAmount = drugOrderIntroductionDet.DoseAmount;

                if (DrugOrder.GetContinueDrugOrderNew(drugOrder, (DateTime)drugOrder.PlannedStartTime))
                {
                    DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);

                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    double unitAmount = 0;
                    double totalAmount = 0;
                    if (drugType)
                    {
                        unitAmount = Math.Ceiling(drugOrder.DoseAmount.Value);
                        totalAmount = unitAmount * (double)gridViewModel.DrugOrderIntroDuctionTimeSchedule.Count;
                    }
                    else
                    {
                        if (drugDefinition.Volume != null)
                        {
                            unitAmount = Math.Ceiling(drugOrder.DoseAmount.Value);
                            totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)gridViewModel.DrugOrderIntroDuctionTimeSchedule.Count);
                        }
                        else
                        {
                            throw new TTException(drugDefinition.Name + " ilacının Hacim bilgisi girilmemiştir. İlacı yazabilmeniz için hacim bilgilerinin girilmesi gerekir. Bilgi işleme haber veriniz.");
                        }
                    }
                    drugOrder.Amount = (double)totalAmount;
                    Store pharmacyStoreClinic = Store.GetPharmacyStore(objectContext);
                    drugOrder.Store = pharmacyStoreClinic;

                    if (drugOrder.Material is MagistralPreparationDefinition == false)
                    {
                        if (drugOrder.PatientOwnDrug.HasValue == false || drugOrder.PatientOwnDrug == false)
                        {
                            DateTime detailTime = drugOrder.PlannedStartTime.Value;
                            drugOrder.Type = TTUtils.CultureService.GetText("M26287", "K-Çizelgesi");
                        }
                        else
                        {
                            drugOrder.Type = TTUtils.CultureService.GetText("M25807", "Hasta Yanında Getirdi");
                        }
                    }
                    else
                    {
                        Store pharmacyStoreClinics = Store.GetPharmacyStore(objectContext);
                        if (drugOrder.Material.ExistingInheld(pharmacyStoreClinics))
                        {
                            drugOrder.Type = TTUtils.CultureService.GetText("M26287", "K-Çizelgesi");
                        }
                    }
                    int orderDay = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("ORDERPLANNIGDAYPERIOD", "1"));
                    bool returnDateControl = DrugOrderIntroduction.OrderPlanningDateControl(drugOrder);
                    if (returnDateControl == false)
                    {
                        if (drugOrder.Day > 1)
                            throw new TTException(drugOrder.Material.Name + " ilacı hastaya " + orderDay.ToString() + " günden fazla yazılamaz");
                        else
                            throw new TTException(drugOrder.Material.Name + " ilacı için gün alanı boş geçilemez");
                    }
                }
                else
                {
                    throw new TTException(drugOrder.Material.Name + " ilacı daha önce order edilmiş ve hala tedavisi devam etmektedir!!!");
                }

                if (drugOrder.CaseOfNeed == true)
                {
                    drugOrder.Type = TTUtils.CultureService.GetText("M26386", "Lüzumu Halinde");
                    drugOrder.CurrentStateDefID = DrugOrder.States.New;
                }
                if (drugOrder.Type == TTUtils.CultureService.GetText("M26287", "K-Çizelgesi"))
                {
                    bool eligible = true;
                    GenerateDrugOrderDetails(objectContext, gridViewModel, drugOrder, eligible, drugOrder.Type);

                    foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                        orderDetail.NursingApplication = drugOrder.NursingApplication;

                    /* if (((DrugDefinition)drugOrder.Material).InfectionApproval.HasValue && ((DrugDefinition)drugOrder.Material).InfectionApproval == true)
                     {
                         drugOrder.CurrentStateDefID = DrugOrder.States.Approve;
                         // TO DO : Enfeksiyon Komitesi işlemi başlatılacak.
                         InfectionCommittee infectionCommittee = new InfectionCommittee(objectContext);
                         infectionCommittee.ActionDate = Common.RecTime();
                         infectionCommittee.FromResource = drugOrder.MasterResource;
                         infectionCommittee.MasterResource = drugOrder.MasterResource;
                         infectionCommittee.Episode = drugOrder.Episode;
                         infectionCommittee.SubEpisode = drugOrder.SubEpisode;
                         infectionCommittee.InPatientPhysicianApplication = drugOrder.InPatientPhysicianApplication;
                         infectionCommittee.CurrentStateDefID = InfectionCommittee.States.New;
                         InfectionCommitteeDetail infectionCommitteeDetail = new InfectionCommitteeDetail(objectContext);
                         infectionCommitteeDetail.DrugOrder = drugOrder;
                         infectionCommitteeDetail.InfectionCommittee = infectionCommittee;
                     }*/
                }
                else if (drugOrder.Type == TTUtils.CultureService.GetText("M25807", "Hasta Yanında Getirdi"))
                {
                    GenerateDrugOrderDetails(objectContext, gridViewModel, drugOrder, false);

                    foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                        orderDetail.NursingApplication = drugOrder.NursingApplication;

                }
            }
        }

        private static void GenerateDrugOrderDetails(TTObjectContext objectContext, DrugOrderIntroductionGridViewModel gridViewModel, DrugOrder drugOrder, bool eligible, string drugOrderType = null)
        {
            DateTime detailTime = (DateTime)drugOrder.PlannedStartTime;
            double totalAmount = 0;
            double detailCount = gridViewModel.DrugOrderIntroDuctionTimeSchedule.Count;// gridViewModel.DrugOrderIntroductionDetail.DrugOrderDetailTimeSchedule.Count;
            //double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
            DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
            //detailCount = detailCount * (double)drugOrder.Day;
            bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);

            drugOrder.Amount = (double)totalAmount;

            for (int i = 0; i < detailCount; i++)
            {
                DrugOrderDetail drugOrderDetail = new DrugOrderDetail(objectContext);
                drugOrderDetail.Material = (Material)drugOrder.Material;
                drugOrderDetail.MasterResource = drugOrder.MasterResource;
                drugOrderDetail.FromResource = drugOrder.FromResource;
                drugOrderDetail.Episode = drugOrder.Episode;
                drugOrderDetail.ActionDate = drugOrder.ActionDate; // Bu actionun açıldığı tarih olmalı. SS
                drugOrderDetail.OrderPlannedDate = gridViewModel.DrugOrderIntroDuctionTimeSchedule[i].Time;
                //detailTime = gridViewModel.DrugOrderIntroDuctionTimeSchedule[i].Time; //gridViewModel.DrugOrderIntroductionDetail.DrugOrderDetailTimeSchedule[i];
                drugOrderDetail.UsageNote = gridViewModel.DrugOrderIntroDuctionTimeSchedule[i].UsageNote;
                drugOrderDetail.Day = drugOrder.Day;
                drugOrderDetail.SubEpisode = drugOrder.SubEpisode;
                drugOrderDetail.MedulaReportNo = drugOrder.MedulaReportNo;

                double unitAmount = Math.Ceiling(gridViewModel.DrugOrderIntroDuctionTimeSchedule[i].DoseAmount.Value);
                double doseAmount = 0;

                if (drugType)
                {
                    totalAmount = unitAmount * (double)detailCount;
                    doseAmount = (double)gridViewModel.DrugOrderIntroDuctionTimeSchedule[i].DoseAmount;
                }
                else
                {
                    totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)detailCount);
                    doseAmount = (double)gridViewModel.DrugOrderIntroDuctionTimeSchedule[i].DoseAmount * (double)drugDefinition.Dose;
                }

                drugOrderDetail.Amount = unitAmount;
                drugOrderDetail.DoseAmount = doseAmount;
                drugOrderDetail.Frequency = drugOrder.Frequency;
                drugOrderDetail.HospitalTimeSchedule = gridViewModel.HospitalTimeSchedule;
                drugOrderDetail.DrugOrder = drugOrder;
                drugOrderDetail.DetailNo = i + 1;
                drugOrderDetail.SecondaryMasterResource = drugOrder.NursingApplication.SecondaryMasterResource;
                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                drugOrderDetail.Eligible = eligible;

                /*if (drugType)
                    drugOrderDetail.Eligible = eligible;
                else
                    drugOrderDetail.Eligible = false;*/

                //K-Çizelgesi için eligible ilk drugOrderDetail için true sonrası için drugorder type a bakarak.
                if (!string.IsNullOrEmpty(drugOrderType) && drugOrder.Type == TTUtils.CultureService.GetText("M26287", "K-Çizelgesi"))
                {
                    drugOrderDetail.Eligible = eligible;
                    if (drugType == false)
                    {
                        eligible = false;
                    }
                }
            }

            drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
            objectContext.Update();
        }
        #endregion

        public bool IsWorkWithStock(DrugDefinition drugDefinition, DrugOrder drugOrder)
        {
            bool inheld = false;
            if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == true)
            {
                if ((bool)drugDefinition.WithOutStockInheld.HasValue)
                {
                    if ((bool)drugDefinition.WithOutStockInheld)
                        inheld = true;
                    else
                        inheld = false;
                }
                else
                    inheld = false;
            }
            else
            {
                if (drugOrder.Material.StockInheld(drugOrder.Store) >= drugOrder.Amount)
                {
                    inheld = true;
                    DrugDefinition def = (DrugDefinition)drugOrder.Material;
                    if (def.ShowZeroOnDrugOrder != null && def.ShowZeroOnDrugOrder.Value && drugOrder.Episode.PatientStatus == PatientStatusEnum.Inpatient)
                        inheld = false;
                }
                else
                    inheld = false;
            }
            return inheld;
        }

        public class AddDrugTS_Input
        {
            public System.Guid DrugID
            {
                get;
                set;
            }

            public System.DateTime PlannedStartTime
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.DrugOrderIntroductionDet AddDrugTS(AddDrugTS_Input input)
        {
            var ret = DrugOrderIntroduction.AddDrugTS(input.DrugID, input.PlannedStartTime);
            return ret;
        }

        public class CreateInpatientDrugOrderTS_Input
        {
            public TTObjectClasses.DrugOrder drugOrder
            {
                get;
                set;
            }

            public string drugDescription
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.InpatientDrugOrder CreateInpatientDrugOrderTS(CreateInpatientDrugOrderTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.drugOrder != null)
                    input.drugOrder = (TTObjectClasses.DrugOrder)objectContext.AddObject(input.drugOrder);
                var ret = DrugOrderIntroduction.CreateInpatientDrugOrderTS(input.drugOrder, input.drugDescription, objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class CreateOutpatientDrugOrderTS_Input
        {
            public TTObjectClasses.DrugOrder drugOrder
            {
                get;
                set;
            }

            public TTObjectClasses.DrugUsageTypeEnum? drugUsageType
            {
                get;
                set;
            }

            public string drugDescription
            {
                get;
                set;
            }
        }


        [HttpGet]
        public bool CheckERecetePasswordForCurrentUser()
        {
            return !String.IsNullOrEmpty(Common.CurrentResource.ErecetePassword);
        }

        [HttpPost]
        public TTObjectClasses.OutPatientDrugOrder CreateOutpatientDrugOrderTS(CreateOutpatientDrugOrderTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.drugOrder != null)
                    input.drugOrder = (TTObjectClasses.DrugOrder)objectContext.AddObject(input.drugOrder);
                OutPatientDrugOrder ret = null;
                //var ret = DrugOrderIntroduction.CreateOutpatientDrugOrderTS(input.drugOrder, input.drugUsageType, input.drugDescription);
                objectContext.FullPartialllyLoadedObjects();
                if (ret == null)
                    throw new Exception(TTUtils.CultureService.GetText("M25901", "Hatalı işlem Bilgi İşleme Haber veriniz."));
                return ret;
            }
        }

        public class AddInpatientPrescriptionTS_Input
        {
            public TTObjectClasses.DrugOrderIntroduction drugOrderIntroduction
            {
                get;
                set;
            }

            public TTObjectClasses.DrugOrderIntroductionDet drugOrderIntroductionDet
            {
                get;
                set;
            }

            public TTObjectClasses.DrugOrder drugOrder
            {
                get;
                set;
            }

            public List<InpatientPresDetail> inpatientPresDetails
            {
                get;
                set;
            }

            public List<InpatientPrescription> inpatientPrescriptions
            {
                get;
                set;
            }
        }

        public class AddInpatientPrescriptionTS_Output
        {
            public InpatientPresDetail inpatientPresDetail
            {
                get;
                set;
            }

            public InpatientPrescription inpatientPrescription
            {
                get;
                set;
            }

            public List<InpatientDrugOrder> inpatientDrugOrders
            {
                get;
                set;
            }
        }

        [HttpGet]
        public List<DiagnosisDefinitionList> DiagnosisDefinitionTS()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DiagnosisDefinitionList> returnList = new List<DiagnosisDefinitionList>();
                IBindingList diagnosis = objectContext.QueryObjects("DIAGNOSISDEFINITION", string.Empty);
                foreach (DiagnosisDefinition diag in diagnosis)
                {
                    DiagnosisDefinitionList diagnosisDefinition = new DiagnosisDefinitionList();
                    diagnosisDefinition.DiagnosisName = diag.Code + " " + diag.Name;
                    diagnosisDefinition.DiagnosisObjID = diag.ObjectID;
                    returnList.Add(diagnosisDefinition);
                }
                return returnList;
            }
        }


        [HttpPost]
        public AddInpatientPrescriptionTS_Output AddInpatientPrescriptionTS(AddInpatientPrescriptionTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.drugOrderIntroduction != null)
                    input.drugOrderIntroduction = (TTObjectClasses.DrugOrderIntroduction)objectContext.AddObject(input.drugOrderIntroduction);
                if (input.drugOrder != null)
                    input.drugOrder = (TTObjectClasses.DrugOrder)objectContext.AddObject(input.drugOrder);
                if (input.drugOrderIntroductionDet != null)
                    input.drugOrderIntroductionDet = (TTObjectClasses.DrugOrderIntroductionDet)objectContext.AddObject(input.drugOrderIntroductionDet);
                if (input.inpatientPresDetails != null)
                {
                    foreach (InpatientPresDetail detail in input.inpatientPresDetails)
                    {
                        if (input.inpatientPrescriptions != null)
                        {
                            foreach (InpatientPrescription pres in input.inpatientPrescriptions)
                            {
                                if (detail.InpatientPrescription.ObjectID == pres.ObjectID)
                                {
                                    InpatientPrescription inpatientPrescription = (InpatientPrescription)objectContext.AddObject(pres);
                                }
                            }
                        }

                        InpatientPresDetail presDetail = (InpatientPresDetail)objectContext.AddObject(detail);
                        input.drugOrderIntroduction.InpatientPresDetails.Add(presDetail);
                    }
                }

                var inpatienPresDetail = DrugOrderIntroduction.AddInpatientPrescriptionTS(input.drugOrderIntroduction, input.drugOrderIntroductionDet);
                AddInpatientPrescriptionTS_Output addInpatientPrescriptionTS_Output = new AddInpatientPrescriptionTS_Output();
                addInpatientPrescriptionTS_Output.inpatientPrescription = inpatienPresDetail.InpatientPrescription;
                addInpatientPrescriptionTS_Output.inpatientPresDetail = inpatienPresDetail;
                addInpatientPrescriptionTS_Output.inpatientDrugOrders = new List<InpatientDrugOrder>();
                foreach (InpatientDrugOrder order in inpatienPresDetail.InpatientPrescription.InpatientDrugOrders)
                    addInpatientPrescriptionTS_Output.inpatientDrugOrders.Add(order);
                objectContext.FullPartialllyLoadedObjects();
                return addInpatientPrescriptionTS_Output;
            }
        }

        public class AddInpatientPrescription_Input
        {
            public TTObjectClasses.DrugOrder drugOrder
            {
                get;
                set;
            }

            public InpatientPrescription inpatientPrescription
            {
                get;
                set;
            }

            public string drugDescription
            {
                get;
                set;
            }
        }

        public class AddInpatientPrescription_Output
        {
            public InpatientPrescription inpatientPrescription
            {
                get;
                set;
            }

            public InpatientDrugOrder inpatientDrugOrder
            {
                get;
                set;
            }
        }

        [HttpPost]
        public AddInpatientPrescription_Output AddInpatientPrescription(AddInpatientPrescription_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                AddInpatientPrescription_Output addInpatientPrescription_Output = new AddInpatientPrescription_Output();
                InpatientPrescription inpatientPrescription = null;
                if (input.drugOrder != null)
                    input.drugOrder = (TTObjectClasses.DrugOrder)objectContext.AddObject(input.drugOrder);
                if (input.inpatientPrescription != null)
                    inpatientPrescription = (InpatientPrescription)objectContext.AddObject(input.inpatientPrescription);
                if (input.drugOrder.Type == "Yatan Hasta Reçetesi")
                {
                    if (inpatientPrescription != null)
                    {
                        DrugOrder drugOrder = input.drugOrder;
                        InpatientDrugOrder inpatientDrugOrder = CreateInpatientDrugOrder(drugOrder, input.drugDescription, objectContext);
                        inpatientPrescription.InpatientDrugOrders.Add(inpatientDrugOrder);
                        addInpatientPrescription_Output.inpatientPrescription = inpatientPrescription;
                        addInpatientPrescription_Output.inpatientDrugOrder = inpatientDrugOrder;
                    }
                    else
                    {
                        /* bool gunuBirlikHastaMi = drugOrderIntroduction.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily);
                         if (gunuBirlikHastaMi)
                             throw new ApplicationException("Depo mevcudu olmayan ilaçlar için lütfen ayaktan hasta reçetesi ekranını kullanınız");*/
                        inpatientPrescription = new InpatientPrescription(objectContext);
                        inpatientPrescription.ActionDate = Common.RecTime();
                        inpatientPrescription.FillingDate = Common.RecTime();
                        inpatientPrescription.FromResource = input.drugOrder.FromResource;
                        inpatientPrescription.MasterResource = input.drugOrder.MasterResource;
                        inpatientPrescription.MasterAction = input.drugOrder.InPatientPhysicianApplication;
                        inpatientPrescription.Episode = input.drugOrder.Episode;
                        inpatientPrescription.SubEpisode = input.drugOrder.SubEpisode;
                        inpatientPrescription.PrescriptionType = ((DrugDefinition)input.drugOrder.Material).PrescriptionType;
                        IList presTypeMaterialMatch = objectContext.QueryObjects("PRESTYPEMATERIALMATCHDEF", "PRESCRIPTIONTYPE =" + ((int)inpatientPrescription.PrescriptionType).ToString());
                        if (presTypeMaterialMatch.Count > 0)
                            inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                        else
                            inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                        InpatientDrugOrder inpatientDrugOrder = CreateInpatientDrugOrder(input.drugOrder, input.drugDescription, objectContext);
                        inpatientPrescription.InpatientDrugOrders.Add(inpatientDrugOrder);
                        addInpatientPrescription_Output.inpatientPrescription = inpatientPrescription;
                        addInpatientPrescription_Output.inpatientDrugOrder = inpatientDrugOrder;
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return addInpatientPrescription_Output;
            }
        }

        public static InpatientDrugOrder CreateInpatientDrugOrder(DrugOrder drugOrder, string drugDescription, TTObjectContext context)
        {
            InpatientDrugOrder inpatientDrugOrder = new InpatientDrugOrder(context);
            inpatientDrugOrder.ActionDate = drugOrder.ActionDate;
            inpatientDrugOrder.Amount = drugOrder.Amount;
            inpatientDrugOrder.Day = drugOrder.Day;
            inpatientDrugOrder.DoseAmount = drugOrder.DoseAmount;
            inpatientDrugOrder.Frequency = drugOrder.Frequency;
            inpatientDrugOrder.FromResource = drugOrder.FromResource;
            inpatientDrugOrder.MasterResource = drugOrder.MasterResource;
            inpatientDrugOrder.Episode = drugOrder.Episode;
            inpatientDrugOrder.Material = drugOrder.Material;
            inpatientDrugOrder.UsageNote = drugOrder.UsageNote;
            inpatientDrugOrder.SubEpisode = drugOrder.SubEpisode;
            inpatientDrugOrder.DrugOrderID = drugOrder.ObjectID;
            inpatientDrugOrder.PackageAmount = Math.Ceiling((double)drugOrder.Amount / (double)drugOrder.Material.PackageAmount);
            if (((DrugDefinition)drugOrder.Material).PatientSafetyFrom.HasValue && (bool)((DrugDefinition)drugOrder.Material).PatientSafetyFrom)
            {
                inpatientDrugOrder.DescriptionType = DescriptionTypeEnum.PatientSafetyAndMonitoringFormDescription;
                inpatientDrugOrder.Description = drugOrder.Description;
            }
            else
            {
                inpatientDrugOrder.DescriptionType = drugOrder.DescriptionType;
                inpatientDrugOrder.Description = drugOrder.Description;

            }

            if (drugOrder.MagistralChemicalDetails.Count > 0)
            {
                foreach (MagistralChemicalDetail magistralChemicalDetail in drugOrder.MagistralChemicalDetails)
                {
                    MagistralChemicalDetail inMagistralChemicalDetail = new MagistralChemicalDetail(context);
                    inMagistralChemicalDetail.MagistralChemicalDefinition = magistralChemicalDetail.MagistralChemicalDefinition;
                    inMagistralChemicalDetail.ChemicalAmount = magistralChemicalDetail.ChemicalAmount;
                    inpatientDrugOrder.MagistralChemicalDetails.Add(inMagistralChemicalDetail);
                }
            }

            if (drugOrder.MagistralDrugDetails.Count > 0)
            {
                foreach (MagistralDrugDetail magistralDrugDetail in drugOrder.MagistralDrugDetails)
                {
                    MagistralDrugDetail inMagistralDrugDetail = new MagistralDrugDetail(context);
                    inMagistralDrugDetail.Material = magistralDrugDetail.Material;
                    inMagistralDrugDetail.PreparatAmount = magistralDrugDetail.PreparatAmount;
                    inpatientDrugOrder.MagistralDrugDetails.Add(inMagistralDrugDetail);
                }
            }

            inpatientDrugOrder.CurrentStateDefID = InpatientDrugOrder.States.New;
            inpatientDrugOrder.NursingApplication = drugOrder.NursingApplication;
            return inpatientDrugOrder;
        }

        public class AddOutpatientPrescription_Input
        {
            public TTObjectClasses.DrugOrder drugOrder
            {
                get;
                set;
            }

            public OutPatientPrescription outPatientPrescription
            {
                get;
                set;
            }

            public string drugDescription
            {
                get;
                set;
            }

            public DrugUsageTypeEnum drugUsageType
            {
                get;
                set;
            }
            public DrugOrderIntroductionDet drugOrderIntroductionDet
            {
                get;
                set;
            }
        }

        public class AddOutpatientPrescription_Output
        {
            public OutPatientPrescription outPatientPrescription
            {
                get;
                set;
            }

            public OutPatientDrugOrder outPatientDrugOrder
            {
                get;
                set;
            }

        }

        [HttpPost]
        public AddOutpatientPrescription_Output AddOutpatientPrescription(AddOutpatientPrescription_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                AddOutpatientPrescription_Output addOutpatientPrescription_Output = new AddOutpatientPrescription_Output();
                OutPatientPrescription outPatientPrescription = null;
                if (input.drugOrder != null)
                    input.drugOrder = (TTObjectClasses.DrugOrder)objectContext.AddObject(input.drugOrder);
                if (input.outPatientPrescription != null)
                    outPatientPrescription = (OutPatientPrescription)objectContext.AddObject(input.outPatientPrescription);
                if (input.drugOrder.Type == "Yatan Hasta Reçetesi")
                {
                    if (outPatientPrescription != null)
                    {
                        DrugOrder drugOrder = input.drugOrder;
                        OutPatientDrugOrder outPatientDrugOrder = CreateOutpatientDrugOrder(drugOrder, input.drugDescription, input.drugUsageType, input.drugOrderIntroductionDet, objectContext);
                        outPatientPrescription.OutPatientDrugOrders.Add(outPatientDrugOrder);
                        addOutpatientPrescription_Output.outPatientPrescription = outPatientPrescription;
                        addOutpatientPrescription_Output.outPatientDrugOrder = outPatientDrugOrder;
                    }
                    else
                    {
                        outPatientPrescription = new OutPatientPrescription(objectContext);
                        outPatientPrescription.ActionDate = Common.RecTime();
                        outPatientPrescription.FillingDate = Common.RecTime();
                        outPatientPrescription.FromResource = input.drugOrder.MasterResource;
                        outPatientPrescription.MasterResource = input.drugOrder.MasterResource;
                        outPatientPrescription.Episode = input.drugOrder.Episode;
                        outPatientPrescription.SubEpisode = input.drugOrder.SubEpisode;
                        outPatientPrescription.PrescriptionType = ((DrugDefinition)input.drugOrder.Material).PrescriptionType;
                        outPatientPrescription.PrescriptionSubType = PrescriptionSubTypeEnum.DailyPrescriptionSubType;
                        outPatientPrescription.CurrentStateDefID = OutPatientPrescription.States.Request;
                        OutPatientDrugOrder outPatientDrugOrder = CreateOutpatientDrugOrder(input.drugOrder, input.drugDescription, input.drugUsageType, input.drugOrderIntroductionDet, objectContext);
                        outPatientPrescription.OutPatientDrugOrders.Add(outPatientDrugOrder);
                        addOutpatientPrescription_Output.outPatientPrescription = outPatientPrescription;
                        addOutpatientPrescription_Output.outPatientDrugOrder = outPatientDrugOrder;
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return addOutpatientPrescription_Output;
            }
        }

        public static OutPatientDrugOrder CreateOutpatientDrugOrder(DrugOrder drugOrder, string drugDescription, DrugUsageTypeEnum drugUsageType, DrugOrderIntroductionDet drugOrderIntroductionDet, TTObjectContext context)
        {
            OutPatientDrugOrder outPatientDrugOrder = new OutPatientDrugOrder(context);
            outPatientDrugOrder.ActionDate = drugOrder.ActionDate;
            outPatientDrugOrder.Amount = drugOrder.Amount;
            outPatientDrugOrder.Day = drugOrder.Day;
            outPatientDrugOrder.DoseAmount = drugOrder.DoseAmount;
            outPatientDrugOrder.Frequency = drugOrder.Frequency;
            outPatientDrugOrder.PeriodUnitType = drugOrderIntroductionDet.PeriodUnitType;
            outPatientDrugOrder.PhysicianDrug = (DrugDefinition)drugOrder.Material;
            outPatientDrugOrder.DrugUsageType = drugUsageType;
            outPatientDrugOrder.FromResource = drugOrder.FromResource;
            outPatientDrugOrder.MasterResource = drugOrder.MasterResource;
            outPatientDrugOrder.Episode = drugOrder.Episode;
            outPatientDrugOrder.Material = drugOrder.Material;
            outPatientDrugOrder.UsageNote = drugOrder.UsageNote;
            outPatientDrugOrder.SubEpisode = drugOrder.SubEpisode;
            outPatientDrugOrder.PackageAmount = drugOrderIntroductionDet.PackageAmount;
            if (((DrugDefinition)drugOrder.Material).PatientSafetyFrom.HasValue && (bool)((DrugDefinition)drugOrder.Material).PatientSafetyFrom)
            {
                outPatientDrugOrder.DescriptionType = DescriptionTypeEnum.PatientSafetyAndMonitoringFormDescription;
                outPatientDrugOrder.Description = drugOrder.Description;
            }
            else
            {
                outPatientDrugOrder.DescriptionType = drugOrder.DescriptionType;
                outPatientDrugOrder.Description = drugOrder.Description;
            }

            if (drugOrder.MagistralChemicalDetails.Count > 0)
            {
                foreach (MagistralChemicalDetail magistralChemicalDetail in drugOrder.MagistralChemicalDetails)
                {
                    MagistralChemicalDetail inMagistralChemicalDetail = new MagistralChemicalDetail(context);
                    inMagistralChemicalDetail.MagistralChemicalDefinition = magistralChemicalDetail.MagistralChemicalDefinition;
                    inMagistralChemicalDetail.ChemicalAmount = magistralChemicalDetail.ChemicalAmount;
                    outPatientDrugOrder.MagistralChemicalDetails.Add(inMagistralChemicalDetail);
                }
            }

            if (drugOrder.MagistralDrugDetails.Count > 0)
            {
                foreach (MagistralDrugDetail magistralDrugDetail in drugOrder.MagistralDrugDetails)
                {
                    MagistralDrugDetail inMagistralDrugDetail = new MagistralDrugDetail(context);
                    inMagistralDrugDetail.Material = magistralDrugDetail.Material;
                    inMagistralDrugDetail.PreparatAmount = magistralDrugDetail.PreparatAmount;
                    outPatientDrugOrder.MagistralDrugDetails.Add(inMagistralDrugDetail);
                }
            }

            outPatientDrugOrder.CurrentStateDefID = OutPatientDrugOrder.States.New;
            return outPatientDrugOrder;
        }

        public class AddOutpatientPrescriptionTS_Input
        {
            public TTObjectClasses.DrugOrderIntroduction drugOrderIntroduction
            {
                get;
                set;
            }

            public TTObjectClasses.DrugOrderIntroductionDet drugOrderIntroductionDet
            {
                get;
                set;
            }

            public TTObjectClasses.DrugOrder drugOrder
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.OutpatientPresDetail AddOutpatientPrescriptionTS(AddOutpatientPrescriptionTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.drugOrderIntroduction != null)
                    input.drugOrderIntroduction = (TTObjectClasses.DrugOrderIntroduction)objectContext.AddObject(input.drugOrderIntroduction);
                if (input.drugOrder != null)
                    input.drugOrder = (TTObjectClasses.DrugOrder)objectContext.AddObject(input.drugOrder);
                if (input.drugOrderIntroductionDet != null)
                    input.drugOrderIntroductionDet = (TTObjectClasses.DrugOrderIntroductionDet)objectContext.AddObject(input.drugOrderIntroductionDet);
                var ret = DrugOrderIntroduction.AddOutpatientPrescriptionTS(input.drugOrderIntroduction, input.drugOrderIntroductionDet);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class CreateDrugOrderTS_Input
        {
            public bool? IsImmediate { get; set; }
            public Guid DrugObjectID { get; set; }
            public DateTime PlannedStartTime { get; set; }
            public string DrugDescription { get; set; }
            public Guid EpisodeObjectID { get; set; }
            public Guid MasterResourceObjectID { get; set; }
            public Guid SecondaryMasterResourceObjectID { get; set; }
            public Guid SubEpisodeObjectID { get; set; }
            public Guid ActiveInPatientPhysicianAppObjectID { get; set; }
            public bool? CaseOfNeed { get; set; }
            public TTObjectClasses.DrugOrderIntroductionDet drugOrderIntroductionDet { get; set; }

        }

        [HttpPost]
        public DrugOrderIntroduction.CreateDrugOrderTSViewModel CreateDrugOrderTS(CreateDrugOrderTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.drugOrderIntroductionDet != null)
                    input.drugOrderIntroductionDet = (TTObjectClasses.DrugOrderIntroductionDet)objectContext.AddObject(input.drugOrderIntroductionDet);

                //DrugOrder drugOrder = null;
                DrugOrderIntroduction.CreateDrugOrderTSViewModel createDrugOrderTSViewModel;
                try
                {
                    createDrugOrderTSViewModel = DrugOrderIntroduction.CreateDrugOrderTS(
                        input.IsImmediate,
                        input.DrugObjectID,
                        input.PlannedStartTime,
                        input.DrugDescription,
                        input.EpisodeObjectID,
                        input.MasterResourceObjectID,
                        input.SecondaryMasterResourceObjectID,
                        input.SubEpisodeObjectID,
                        input.ActiveInPatientPhysicianAppObjectID,
                        input.CaseOfNeed,
                        input.drugOrderIntroductionDet);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                objectContext.FullPartialllyLoadedObjects();
                return createDrugOrderTSViewModel; //drugOrder;
            }
        }

        public class GetOldDrugOrderIntroductionDets_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
            public DateTime? PlannedStartDate
            {
                get;
                set;
            }
            public DateTime? PlannedEndDate
            {
                get;
                set;
            }

        }

        public class GetDrugOrderGridViewModel_Input
        {
            public Guid episodeObjectID
            {
                get;
                set;
            }
            public DateTime? PlannedStartDate
            {
                get;
                set;
            }
            public DateTime? PlannedEndDate
            {
                get;
                set;
            }
            public Guid activeInPatientPhysicianApp
            {
                get;
                set;
            }
        }


        [HttpGet]
        public string GetDrugOrderQueryDayNumber()
        {

            string queryDay = TTObjectClasses.SystemParameter.GetParameterValue("DAYDURATIONFORLOADING", "10");
            return queryDay;
        }

        [HttpGet]
        public int GetDrugOrderTimeOffset()
        {
            int drugOrderTimeOffset = 0;
            try
            {
                drugOrderTimeOffset = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("DRUGORDERTIMEOFFSET", "1"));
            }
            catch (Exception ex)
            {
                throw new TTException(ex.ToString() + "Geçmişe yönelik order zamanı (DRUGORDERTIMEOFFSET sistem parametresi) tam sayı olmalıdır!!");
            }
            return drugOrderTimeOffset;
        }

        public void CreateDrugInfoForDrugOrderGridViewModel(TTObjectContext objectContext, Guid materialObjectID, DrugOrderIntroductionGridViewModel drugOrderIntroductionGridViewModel)
        {
            DrugDefinition material = objectContext.GetObject<DrugDefinition>(materialObjectID);
            drugOrderIntroductionGridViewModel.Material.drugObjectId = material.ObjectID.ToString();
            drugOrderIntroductionGridViewModel.Material.name = material.Name;

            if (string.IsNullOrEmpty(material.Description) == false)
            {
                if (material.MaterialDescriptionShowType != null)
                {
                    if (material.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.Order || material.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.All)
                        drugOrderIntroductionGridViewModel.Material.DrugDescription = material.Description;
                    else
                        drugOrderIntroductionGridViewModel.Material.DrugDescription = string.Empty;
                }
                else
                    drugOrderIntroductionGridViewModel.Material.DrugDescription = material.Description;
            }
            else
                drugOrderIntroductionGridViewModel.Material.DrugDescription = string.Empty;


            drugOrderIntroductionGridViewModel.Material.ActiveIngeridents = new List<DrugIngredient>();
            if (material.RouteOfAdmin != null)
                drugOrderIntroductionGridViewModel.Material.drugUsageTypeEnum = material.RouteOfAdmin.DrugUsageType;
            drugOrderIntroductionGridViewModel.Material.DrugSpecifications = new List<DrugSpecificationEnum>();
            if (material.MinPatientAge.HasValue)
                drugOrderIntroductionGridViewModel.Material.minAge = material.MinPatientAge.Value;
            else
                drugOrderIntroductionGridViewModel.Material.minAge = 0;
            if (material.MaxPatientAge.HasValue)
                drugOrderIntroductionGridViewModel.Material.maxAge = material.MaxPatientAge.Value;
            else
                drugOrderIntroductionGridViewModel.Material.maxAge = 100;
            drugOrderIntroductionGridViewModel.Material.drugType = DrugOrder.GetDrugUsedType(material);
            if (material.InpatientReportType != null)
                drugOrderIntroductionGridViewModel.Material.DrugReportType = material.InpatientReportType.Value;
            else
                drugOrderIntroductionGridViewModel.Material.DrugReportType = DrugReportType.Odenir;
            foreach (DrugSpecifications drugSpec in material.DrugSpecifications)
            {
                if (drugSpec.DrugSpecification.HasValue)
                    drugOrderIntroductionGridViewModel.Material.DrugSpecifications.Add(drugSpec.DrugSpecification.Value);
            }

            foreach (DrugActiveIngredient ing in material.DrugActiveIngredients)
            {
                DrugIngredient drugIng = new DrugIngredient();
                drugIng.Name = ing.ActiveIngredient.Name;
                drugIng.Objectid = ing.ObjectID;
                drugOrderIntroductionGridViewModel.Material.ActiveIngeridents.Add(drugIng);
            }

            Store pharmacy = Store.GetPharmacyStore(objectContext);
            if (pharmacy != null)
            {
                Stock materialStock = pharmacy.GetStock(material);
                if (materialStock != null)
                    drugOrderIntroductionGridViewModel.Material.inheldStatus = materialStock.Inheld.ToString();
                else
                    drugOrderIntroductionGridViewModel.Material.inheldStatus = "0";
            }
            else
            {
                drugOrderIntroductionGridViewModel.Material.inheldStatus = "0";
            }

            if (material.InfectionApproval == true)
                drugOrderIntroductionGridViewModel.Material.InfectionApproval = true;
            else
                drugOrderIntroductionGridViewModel.Material.InfectionApproval = false;
        }

        [HttpPost]
        public List<DrugOrderIntroductionGridViewModel> GetDrugOrderGridViewModel(GetDrugOrderGridViewModel_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugOrderIntroductionGridViewModel> output = new List<DrugOrderIntroductionGridViewModel>();
                if (input.episodeObjectID != Guid.Empty)
                {
                    string filter = "";
                    if (input.PlannedStartDate != null)
                    {
                        //string firstDate = input.PlannedStartDate.Value;
                        string firstDate = Convert.ToDateTime((input.PlannedStartDate.Value.ToShortDateString() + " 00:00:00")).ToString("yyyy-MM-dd HH:mm:ss");
                        filter = " AND DRUGORDER.PlannedStartTime >= TODATE('" + firstDate + "')";
                    }

                    if (input.PlannedEndDate != null && input.PlannedEndDate > DateTime.Now.AddDays(-365))
                    {
                        string lastDate = Convert.ToDateTime((input.PlannedEndDate.Value.ToShortDateString() + " 23:59:59")).ToString("yyyy-MM-dd HH:mm:ss");
                        filter += " AND DRUGORDER.PlannedStartTime <= TODATE('" + lastDate + "')";
                    }

                    if (input.activeInPatientPhysicianApp != null && input.activeInPatientPhysicianApp != Guid.Empty)
                    {
                        filter += " AND DRUGORDER.INPATIENTPHYSICIANAPPLICATION=" + TTConnectionManager.ConnectionManager.GuidToString(input.activeInPatientPhysicianApp);
                    }

                    BindingList<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class> details = DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery(input.episodeObjectID, filter);

                    Dictionary<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>> parentDrugOrderDict = new Dictionary<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>>();

                    foreach (DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class detail in details)
                    {
                        if (detail.ParentDrugOrder == null)
                        {
                            if (parentDrugOrderDict.ContainsKey(detail.Drugorderid.Value))
                            {
                                parentDrugOrderDict[detail.Drugorderid.Value].Add(detail);
                            }
                            else
                            {
                                List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class> detailList = new List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>();
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
                                List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class> detailList = new List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>();
                                detailList.Add(detail);
                                parentDrugOrderDict.Add(detail.ParentDrugOrder.Value, detailList);
                            }
                        }
                    }

                    foreach (KeyValuePair<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>> detailDic in parentDrugOrderDict)
                    {
                        if (detailDic.Value.Count == 1)
                        {
                            foreach (var item in detailDic.Value)
                            {
                                DrugOrderIntroductionGridViewModel drugOrderIntroductionGridViewModel = new DrugOrderIntroductionGridViewModel();

                                if (item.CaseOfNeed.HasValue)
                                    drugOrderIntroductionGridViewModel.CaseOfNeed = item.CaseOfNeed.Value;
                                else
                                    drugOrderIntroductionGridViewModel.CaseOfNeed = false;

                                drugOrderIntroductionGridViewModel.Day = item.Drugorderday.Value;
                                drugOrderIntroductionGridViewModel.DoseAmount = item.DoseAmount.Value;
                                drugOrderIntroductionGridViewModel.DrugOrderType = item.DrugOrderType;
                                drugOrderIntroductionGridViewModel.DrugUsageType = item.DrugUsageType;
                                drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID = item.Hospitaltimescheduleid;

                                if (item.IsImmediate.HasValue)
                                    drugOrderIntroductionGridViewModel.IsImmediate = item.IsImmediate;
                                else
                                    drugOrderIntroductionGridViewModel.IsImmediate = false;

                                if (item.IsCV.HasValue)
                                    drugOrderIntroductionGridViewModel.IsCV = item.IsCV;
                                else
                                    drugOrderIntroductionGridViewModel.IsCV = false;

                                if (item.IsTeleOrder.HasValue)
                                    drugOrderIntroductionGridViewModel.IsTeleOrder = item.IsTeleOrder;
                                else
                                    drugOrderIntroductionGridViewModel.IsTeleOrder = false;

                                if (item.IsUpgraded.HasValue)
                                    drugOrderIntroductionGridViewModel.IsUpgraded = item.IsUpgraded;
                                else
                                    drugOrderIntroductionGridViewModel.IsUpgraded = false;

                                CreateDrugInfoForDrugOrderGridViewModel(objectContext, item.Material.Value, drugOrderIntroductionGridViewModel);

                                //drugOrderIntroductionGridViewModel.DrugOrderIntroductionDetail.Material = material;
                                drugOrderIntroductionGridViewModel.ID = item.Drugorderintroductiondetid.Value.ToString();

                                if (item.PatientOwnDrug.Value)
                                    drugOrderIntroductionGridViewModel.PatientOwnDrug = item.PatientOwnDrug;
                                else
                                    drugOrderIntroductionGridViewModel.PatientOwnDrug = false;

                                if (drugOrderIntroductionGridViewModel.PatientOwnDrug.Value)
                                {
                                    BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> ownDrugRestDose = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(input.episodeObjectID, new Guid(drugOrderIntroductionGridViewModel.Material.drugObjectId));
                                    int restamount = 0;
                                    foreach (PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class rest in ownDrugRestDose)
                                    {
                                        restamount = restamount + Convert.ToInt16(rest.Restamount);
                                    }
                                    drugOrderIntroductionGridViewModel.Material.inheldStatus = restamount.ToString();
                                }

                                drugOrderIntroductionGridViewModel.PlannedStartTime = item.Orderdate;
                                drugOrderIntroductionGridViewModel.UsageNote = item.UsageNote;

                                List<DrugOrderDetail> drugOrderDetails = objectContext.QueryObjects<DrugOrderDetail>("DRUGORDER = " + TTConnectionManager.ConnectionManager.GuidToString(item.Drugorderid.Value)).ToList();

                                if (drugOrderDetails.Count == 0)
                                {
                                    drugOrderIntroductionGridViewModel.LastDrugOrderObjectID = item.Drugorderid.Value;
                                    //drugOrderIntroductionGridViewModel.PlannedEndTime = drugOrderDetails[drugOrderDetails.Count - 1].OrderPlannedDate.Value;
                                    //drugOrderIntroductionGridViewModel.DoctorName = drugOrderDetails[0].DrugOrder.RequestedByUser.Name;
                                    if (drugOrderIntroductionGridViewModel.CaseOfNeed.Value)
                                    {
                                        DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(item.Drugorderid.Value, typeof(DrugOrder));
                                        if (drugOrder.CurrentStateDefID == DrugOrder.States.Cancelled)
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Cancel;
                                        else if (drugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Stopped;
                                        else
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Continue;
                                    }
                                    else
                                        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Approve;
                                }
                                else
                                {
                                    drugOrderDetails = drugOrderDetails.OrderBy(x => x.OrderPlannedDate).ToList();

                                    drugOrderIntroductionGridViewModel.LastDrugOrderObjectID = drugOrderDetails[0].DrugOrder.ObjectID;
                                    drugOrderIntroductionGridViewModel.PlannedEndTime = drugOrderDetails[drugOrderDetails.Count - 1].OrderPlannedDate.Value;
                                    drugOrderIntroductionGridViewModel.CreationDate = drugOrderDetails[drugOrderDetails.Count - 1].DrugOrder.CreationDate;
                                    if (drugOrderDetails[0].DrugOrder.ProcedureDoctor != null)
                                        drugOrderIntroductionGridViewModel.DoctorName = drugOrderDetails[0].DrugOrder.ProcedureDoctor.Name;
                                    else
                                        drugOrderIntroductionGridViewModel.DoctorName = drugOrderDetails[0].DrugOrder.RequestedByUser.Name;

                                    if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Completed)
                                        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Complated;
                                    else if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Cancelled)
                                        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Cancel;
                                    else if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                                        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Stopped;
                                    else if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Approve)
                                        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Approve;
                                    else
                                    {
                                        if (DrugOrder.GetContinueDrugOrderNew(drugOrderDetails[0].DrugOrder, DateTime.Now))
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Complated;
                                        else
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Continue;
                                    }

                                    if (drugOrderIntroductionGridViewModel.Status == DrugOrderStatusEnum.Complated)
                                    {
                                        if (drugOrderDetails[0].DrugOrder.OutOfTreatment.HasValue && drugOrderDetails[0].DrugOrder.OutOfTreatment.Value)
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.OutOfTreatment;
                                    }

                                    foreach (DrugOrderDetail drugOrderDetail in drugOrderDetails)
                                    {
                                        DrugOrderTimceSchedule drugOrderTimceSchedule = new DrugOrderTimceSchedule();
                                        drugOrderTimceSchedule.DetailNo = drugOrderDetail.DetailNo;
                                        bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
                                        if (drugType)
                                            drugOrderTimceSchedule.DoseAmount = drugOrderDetail.DoseAmount;
                                        else
                                            drugOrderTimceSchedule.DoseAmount = drugOrderDetail.Amount;
                                        drugOrderTimceSchedule.Time = drugOrderDetail.OrderPlannedDate;
                                        drugOrderTimceSchedule.UsageNote = drugOrderDetail.UsageNote;
                                        drugOrderTimceSchedule.MasterID = drugOrderIntroductionGridViewModel.ID;
                                        drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.Add(drugOrderTimceSchedule);
                                    }
                                }
                                output.Add(drugOrderIntroductionGridViewModel);
                            }
                        }
                        else
                        {
                            DrugOrderIntroductionGridViewModel drugOrderIntroductionGridViewModel = new DrugOrderIntroductionGridViewModel();
                            List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class> sortedList = detailDic.Value.OrderBy(x => x.Orderdate).ThenBy(x => x.CreationDate).ToList();
                            DrugOrder parentDrugOrder = (DrugOrder)objectContext.GetObject(detailDic.Key, typeof(DrugOrder));


                            if (parentDrugOrder.CaseOfNeed.HasValue)
                                drugOrderIntroductionGridViewModel.CaseOfNeed = parentDrugOrder.CaseOfNeed.Value;
                            else
                                drugOrderIntroductionGridViewModel.CaseOfNeed = false;



                            drugOrderIntroductionGridViewModel.Day = sortedList[sortedList.Count - 1].Drugorderday.Value;
                            drugOrderIntroductionGridViewModel.DoseAmount = parentDrugOrder.DoseAmount.Value;
                            drugOrderIntroductionGridViewModel.DrugOrderType = parentDrugOrder.DrugOrderType;
                            drugOrderIntroductionGridViewModel.DrugUsageType = sortedList[sortedList.Count - 1].DrugUsageType;
                            drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID = parentDrugOrder.HospitalTimeSchedule.ObjectID;

                            if (parentDrugOrder.IsImmediate.HasValue)
                                drugOrderIntroductionGridViewModel.IsImmediate = parentDrugOrder.IsImmediate.Value;
                            else
                                drugOrderIntroductionGridViewModel.IsImmediate = false;

                            if (sortedList[sortedList.Count - 1].IsCV.HasValue)
                                drugOrderIntroductionGridViewModel.IsCV = sortedList[sortedList.Count - 1].IsCV.Value;
                            else
                                drugOrderIntroductionGridViewModel.IsCV = false;

                            if (sortedList[sortedList.Count - 1].IsTeleOrder.HasValue)
                                drugOrderIntroductionGridViewModel.IsTeleOrder = sortedList[sortedList.Count - 1].IsTeleOrder.Value;
                            else
                                drugOrderIntroductionGridViewModel.IsTeleOrder = false;

                            CreateDrugInfoForDrugOrderGridViewModel(objectContext, parentDrugOrder.Material.ObjectID, drugOrderIntroductionGridViewModel);

                            drugOrderIntroductionGridViewModel.ID = sortedList[0].Drugorderintroductiondetid.Value.ToString();
                            drugOrderIntroductionGridViewModel.PatientOwnDrug = sortedList[sortedList.Count - 1].PatientOwnDrug;
                            drugOrderIntroductionGridViewModel.PlannedStartTime = parentDrugOrder.PlannedStartTime;
                            drugOrderIntroductionGridViewModel.UsageNote = sortedList[sortedList.Count - 1].UsageNote;
                            drugOrderIntroductionGridViewModel.ParentDrugOrderObjectID = detailDic.Key;

                            if (sortedList[sortedList.Count - 1].IsUpgraded.HasValue)
                                drugOrderIntroductionGridViewModel.IsUpgraded = sortedList[sortedList.Count - 1].IsUpgraded;
                            else
                                drugOrderIntroductionGridViewModel.IsUpgraded = false;

                            if (drugOrderIntroductionGridViewModel.PatientOwnDrug.Value)
                            {
                                BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> ownDrugRestDose = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(input.episodeObjectID, new Guid(drugOrderIntroductionGridViewModel.Material.drugObjectId));
                                int restamount = 0;
                                foreach (PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class rest in ownDrugRestDose)
                                {
                                    restamount = restamount + Convert.ToInt16(rest.Restamount);
                                }
                                drugOrderIntroductionGridViewModel.Material.inheldStatus = restamount.ToString();
                            }

                            List<DrugOrderDetail> drugOrderDetails = objectContext.QueryObjects<DrugOrderDetail>("DRUGORDER = " + TTConnectionManager.ConnectionManager.GuidToString(sortedList[sortedList.Count - 1].Drugorderid.Value)).ToList();

                            drugOrderDetails = drugOrderDetails.OrderBy(x => x.OrderPlannedDate).ToList();

                            drugOrderIntroductionGridViewModel.LastDrugOrderObjectID = drugOrderDetails[0].DrugOrder.ObjectID;
                            drugOrderIntroductionGridViewModel.PlannedEndTime = drugOrderDetails[drugOrderDetails.Count - 1].OrderPlannedDate.Value;
                            drugOrderIntroductionGridViewModel.CreationDate = drugOrderDetails[drugOrderDetails.Count - 1].DrugOrder.CreationDate;

                            if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Completed)
                                drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Complated;
                            else if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Cancelled)
                                drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Cancel;
                            else if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                                drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Stopped;
                            else
                            {
                                if (DrugOrder.GetContinueDrugOrderNew(drugOrderDetails[0].DrugOrder, DateTime.Now))
                                    drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Complated;
                                else
                                    drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Continue;
                            }

                            if (drugOrderIntroductionGridViewModel.Status == DrugOrderStatusEnum.Complated)
                            {
                                if (drugOrderDetails[0].DrugOrder.OutOfTreatment.HasValue && drugOrderDetails[0].DrugOrder.OutOfTreatment.Value)
                                    drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.OutOfTreatment;
                            }

                            foreach (DrugOrderDetail drugOrderDetail in drugOrderDetails)
                            {
                                DrugOrderTimceSchedule drugOrderTimceSchedule = new DrugOrderTimceSchedule();
                                drugOrderTimceSchedule.DetailNo = drugOrderDetail.DetailNo;
                                bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
                                if (drugType)
                                    drugOrderTimceSchedule.DoseAmount = drugOrderDetail.DoseAmount;
                                else
                                    drugOrderTimceSchedule.DoseAmount = drugOrderDetail.Amount;
                                drugOrderTimceSchedule.Time = drugOrderDetail.OrderPlannedDate;
                                drugOrderTimceSchedule.UsageNote = drugOrderDetail.UsageNote;
                                drugOrderTimceSchedule.MasterID = drugOrderIntroductionGridViewModel.ID;
                                drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.Add(drugOrderTimceSchedule);
                            }
                            output.Add(drugOrderIntroductionGridViewModel);
                        }
                    }
                }

                objectContext.FullPartialllyLoadedObjects();

                return output;
            }
        }


        public class GetAllDrugOrderGridViewModel_Input
        {
            public Guid episodeObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public List<DrugOrderIntroductionGridViewModel> GetAllDrugOrderGridViewModel(GetAllDrugOrderGridViewModel_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugOrderIntroductionGridViewModel> output = new List<DrugOrderIntroductionGridViewModel>();
                if (input.episodeObjectID != Guid.Empty)
                {
                    BindingList<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class> details = DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery(input.episodeObjectID);

                    Dictionary<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>> parentDrugOrderDict = new Dictionary<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>>();

                    foreach (DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class detail in details)
                    {
                        if (detail.ParentDrugOrder == null)
                        {
                            if (parentDrugOrderDict.ContainsKey(detail.Drugorderid.Value))
                            {
                                parentDrugOrderDict[detail.Drugorderid.Value].Add(detail);
                            }
                            else
                            {
                                List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class> detailList = new List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>();
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
                                List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class> detailList = new List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>();
                                detailList.Add(detail);
                                parentDrugOrderDict.Add(detail.ParentDrugOrder.Value, detailList);
                            }
                        }
                    }

                    foreach (KeyValuePair<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class>> detailDic in parentDrugOrderDict)
                    {
                        if (detailDic.Value.Count == 1)
                        {
                            foreach (var item in detailDic.Value)
                            {
                                DrugOrderIntroductionGridViewModel drugOrderIntroductionGridViewModel = new DrugOrderIntroductionGridViewModel();

                                if (item.CaseOfNeed.HasValue)
                                    drugOrderIntroductionGridViewModel.CaseOfNeed = item.CaseOfNeed.Value;
                                else
                                    drugOrderIntroductionGridViewModel.CaseOfNeed = false;

                                drugOrderIntroductionGridViewModel.Day = item.Drugorderday.Value;
                                drugOrderIntroductionGridViewModel.DoseAmount = item.DoseAmount.Value;
                                drugOrderIntroductionGridViewModel.DrugOrderType = item.DrugOrderType;
                                drugOrderIntroductionGridViewModel.DrugUsageType = item.DrugUsageType;
                                drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID = item.Hospitaltimescheduleid;

                                if (item.IsImmediate.HasValue)
                                    drugOrderIntroductionGridViewModel.IsImmediate = item.IsImmediate;
                                else
                                    drugOrderIntroductionGridViewModel.IsImmediate = false;

                                if (item.IsUpgraded.HasValue)
                                    drugOrderIntroductionGridViewModel.IsUpgraded = item.IsUpgraded;
                                else
                                    drugOrderIntroductionGridViewModel.IsUpgraded = false;

                                CreateDrugInfoForDrugOrderGridViewModel(objectContext, item.Material.Value, drugOrderIntroductionGridViewModel);

                                //drugOrderIntroductionGridViewModel.DrugOrderIntroductionDetail.Material = material;
                                drugOrderIntroductionGridViewModel.ID = item.Drugorderintroductiondetid.Value.ToString();

                                if (item.PatientOwnDrug.Value)
                                    drugOrderIntroductionGridViewModel.PatientOwnDrug = item.PatientOwnDrug;
                                else
                                    drugOrderIntroductionGridViewModel.PatientOwnDrug = false;

                                if (drugOrderIntroductionGridViewModel.PatientOwnDrug.Value)
                                {
                                    BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> ownDrugRestDose = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(input.episodeObjectID, new Guid(drugOrderIntroductionGridViewModel.Material.drugObjectId));
                                    int restamount = 0;
                                    foreach (PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class rest in ownDrugRestDose)
                                    {
                                        restamount = restamount + Convert.ToInt16(rest.Restamount);
                                    }
                                    drugOrderIntroductionGridViewModel.Material.inheldStatus = restamount.ToString();
                                }

                                drugOrderIntroductionGridViewModel.PlannedStartTime = item.Orderdate;
                                drugOrderIntroductionGridViewModel.UsageNote = item.UsageNote;

                                List<DrugOrderDetail> drugOrderDetails = objectContext.QueryObjects<DrugOrderDetail>("DRUGORDER = " + TTConnectionManager.ConnectionManager.GuidToString(item.Drugorderid.Value)).ToList();

                                if (drugOrderDetails.Count == 0)
                                {
                                    drugOrderIntroductionGridViewModel.LastDrugOrderObjectID = item.Drugorderid.Value;
                                    //drugOrderIntroductionGridViewModel.PlannedEndTime = drugOrderDetails[drugOrderDetails.Count - 1].OrderPlannedDate.Value;
                                    //drugOrderIntroductionGridViewModel.DoctorName = drugOrderDetails[0].DrugOrder.RequestedByUser.Name;
                                    if (drugOrderIntroductionGridViewModel.CaseOfNeed.Value)
                                    {
                                        DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(item.Drugorderid.Value, typeof(DrugOrder));
                                        if (drugOrder.CurrentStateDefID == DrugOrder.States.Cancelled)
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Cancel;
                                        else if (drugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Stopped;
                                        else
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Continue;
                                    }
                                    else
                                        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Approve;
                                }
                                else
                                {
                                    drugOrderDetails = drugOrderDetails.OrderBy(x => x.OrderPlannedDate).ToList();

                                    drugOrderIntroductionGridViewModel.LastDrugOrderObjectID = drugOrderDetails[0].DrugOrder.ObjectID;
                                    drugOrderIntroductionGridViewModel.PlannedEndTime = drugOrderDetails[drugOrderDetails.Count - 1].OrderPlannedDate.Value;
                                    drugOrderIntroductionGridViewModel.CreationDate = drugOrderDetails[drugOrderDetails.Count - 1].DrugOrder.CreationDate;
                                    drugOrderIntroductionGridViewModel.DoctorName = drugOrderDetails[0].DrugOrder.RequestedByUser.Name;

                                    if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Completed)
                                        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Complated;
                                    else if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Cancelled)
                                        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Cancel;
                                    else if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                                        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Stopped;
                                    else if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Approve)
                                        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Approve;
                                    else
                                    {
                                        if (DrugOrder.GetContinueDrugOrderNew(drugOrderDetails[0].DrugOrder, DateTime.Now))
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Complated;
                                        else
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Continue;
                                    }

                                    if (drugOrderIntroductionGridViewModel.Status == DrugOrderStatusEnum.Complated)
                                    {
                                        if (drugOrderDetails[0].DrugOrder.OutOfTreatment.HasValue && drugOrderDetails[0].DrugOrder.OutOfTreatment.Value)
                                            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.OutOfTreatment;
                                    }

                                    foreach (DrugOrderDetail drugOrderDetail in drugOrderDetails)
                                    {
                                        DrugOrderTimceSchedule drugOrderTimceSchedule = new DrugOrderTimceSchedule();
                                        drugOrderTimceSchedule.DetailNo = drugOrderDetail.DetailNo;
                                        drugOrderTimceSchedule.DoseAmount = drugOrderDetail.Amount;
                                        drugOrderTimceSchedule.Time = drugOrderDetail.OrderPlannedDate;
                                        drugOrderTimceSchedule.UsageNote = drugOrderDetail.UsageNote;
                                        drugOrderTimceSchedule.MasterID = drugOrderIntroductionGridViewModel.ID;
                                        drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.Add(drugOrderTimceSchedule);
                                    }
                                }
                                output.Add(drugOrderIntroductionGridViewModel);
                            }
                        }
                        else
                        {
                            DrugOrderIntroductionGridViewModel drugOrderIntroductionGridViewModel = new DrugOrderIntroductionGridViewModel();
                            List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelQuery_Class> sortedList = detailDic.Value.OrderBy(x => x.Orderdate).ThenBy(x => x.CreationDate).ToList();
                            DrugOrder parentDrugOrder = (DrugOrder)objectContext.GetObject(detailDic.Key, typeof(DrugOrder));


                            if (parentDrugOrder.CaseOfNeed.HasValue)
                                drugOrderIntroductionGridViewModel.CaseOfNeed = parentDrugOrder.CaseOfNeed.Value;
                            else
                                drugOrderIntroductionGridViewModel.CaseOfNeed = false;



                            drugOrderIntroductionGridViewModel.Day = sortedList[sortedList.Count - 1].Drugorderday.Value;
                            drugOrderIntroductionGridViewModel.DoseAmount = parentDrugOrder.DoseAmount.Value;
                            drugOrderIntroductionGridViewModel.DrugOrderType = parentDrugOrder.DrugOrderType;
                            drugOrderIntroductionGridViewModel.DrugUsageType = parentDrugOrder.DrugUsageType;
                            drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID = parentDrugOrder.HospitalTimeSchedule.ObjectID;

                            if (parentDrugOrder.IsImmediate.HasValue)
                                drugOrderIntroductionGridViewModel.IsImmediate = parentDrugOrder.IsImmediate.Value;
                            else
                                drugOrderIntroductionGridViewModel.IsImmediate = false;

                            CreateDrugInfoForDrugOrderGridViewModel(objectContext, parentDrugOrder.Material.ObjectID, drugOrderIntroductionGridViewModel);

                            drugOrderIntroductionGridViewModel.ID = sortedList[0].Drugorderintroductiondetid.Value.ToString();
                            drugOrderIntroductionGridViewModel.PatientOwnDrug = sortedList[sortedList.Count - 1].PatientOwnDrug;
                            drugOrderIntroductionGridViewModel.PlannedStartTime = parentDrugOrder.PlannedStartTime;
                            drugOrderIntroductionGridViewModel.UsageNote = sortedList[sortedList.Count - 1].UsageNote;
                            drugOrderIntroductionGridViewModel.ParentDrugOrderObjectID = detailDic.Key;

                            if (sortedList[sortedList.Count - 1].IsUpgraded.HasValue)
                                drugOrderIntroductionGridViewModel.IsUpgraded = sortedList[sortedList.Count - 1].IsUpgraded;
                            else
                                drugOrderIntroductionGridViewModel.IsUpgraded = false;

                            if (drugOrderIntroductionGridViewModel.PatientOwnDrug.Value)
                            {
                                BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> ownDrugRestDose = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(input.episodeObjectID, new Guid(drugOrderIntroductionGridViewModel.Material.drugObjectId));
                                int restamount = 0;
                                foreach (PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class rest in ownDrugRestDose)
                                {
                                    restamount = restamount + Convert.ToInt16(rest.Restamount);
                                }
                                drugOrderIntroductionGridViewModel.Material.inheldStatus = restamount.ToString();
                            }

                            List<DrugOrderDetail> drugOrderDetails = objectContext.QueryObjects<DrugOrderDetail>("DRUGORDER = " + TTConnectionManager.ConnectionManager.GuidToString(sortedList[sortedList.Count - 1].Drugorderid.Value)).ToList();

                            drugOrderDetails = drugOrderDetails.OrderBy(x => x.OrderPlannedDate).ToList();

                            drugOrderIntroductionGridViewModel.LastDrugOrderObjectID = drugOrderDetails[0].DrugOrder.ObjectID;
                            drugOrderIntroductionGridViewModel.PlannedEndTime = drugOrderDetails[drugOrderDetails.Count - 1].OrderPlannedDate.Value;
                            drugOrderIntroductionGridViewModel.CreationDate = drugOrderDetails[drugOrderDetails.Count - 1].DrugOrder.CreationDate;

                            if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Completed)
                                drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Complated;
                            else if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Cancelled)
                                drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Cancel;
                            else if (drugOrderDetails[0].DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                                drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Stopped;
                            else
                            {
                                if (DrugOrder.GetContinueDrugOrderNew(drugOrderDetails[0].DrugOrder, DateTime.Now))
                                    drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Complated;
                                else
                                    drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Continue;
                            }

                            if (drugOrderIntroductionGridViewModel.Status == DrugOrderStatusEnum.Complated)
                            {
                                if (drugOrderDetails[0].DrugOrder.OutOfTreatment.HasValue && drugOrderDetails[0].DrugOrder.OutOfTreatment.Value)
                                    drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.OutOfTreatment;
                            }

                            foreach (DrugOrderDetail drugOrderDetail in drugOrderDetails)
                            {
                                DrugOrderTimceSchedule drugOrderTimceSchedule = new DrugOrderTimceSchedule();
                                drugOrderTimceSchedule.DetailNo = drugOrderDetail.DetailNo;
                                drugOrderTimceSchedule.DoseAmount = drugOrderDetail.Amount;
                                drugOrderTimceSchedule.Time = drugOrderDetail.OrderPlannedDate;
                                drugOrderTimceSchedule.UsageNote = drugOrderDetail.UsageNote;
                                drugOrderTimceSchedule.MasterID = drugOrderIntroductionGridViewModel.ID;
                                drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.Add(drugOrderTimceSchedule);
                            }
                            output.Add(drugOrderIntroductionGridViewModel);
                        }
                    }
                }

                objectContext.FullPartialllyLoadedObjects();

                return output;
            }
        }
        [HttpPost]
        public OldDrugOrderIntroductionDet GetOldDrugOrderIntroductionDetsWithDate(GetOldDrugOrderIntroductionDets_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                OldDrugOrderIntroductionDet oldDrugOrderIntroductionDet = new OldDrugOrderIntroductionDet();
                List<TempDrugOrder> tempDrugOrders = new List<TempDrugOrder>();
                List<Material> materials = new List<Material>();
                if (input.episode != null)
                {
                    string filter = "";
                    if (input.PlannedStartDate != null)
                    {
                        string firstDate = Convert.ToDateTime(input.PlannedStartDate).ToShortDateString();
                        filter = " AND DRUGORDERINTRODUCTION.PlannedStartTime >= '" + firstDate + "'";
                    }

                    if (input.PlannedEndDate != null && input.PlannedEndDate > DateTime.Now.AddDays(-365))
                    {
                        string lastDate = Convert.ToDateTime(input.PlannedEndDate).ToShortDateString();
                        filter += " AND DRUGORDERINTRODUCTION.PlannedStartTime <= '" + lastDate + "'";
                    }


                    BindingList<DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByEpisodeAndDate_Class> details = DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByEpisodeAndDate(input.episode.ObjectID, filter);
                    foreach (DrugOrderIntroductionDet.GetDrugOrderIntroductionDetByEpisodeAndDate_Class detail in details)
                    {
                        if (detail.Material != null)
                        {
                            Material material = (Material)objectContext.GetObject((Guid)detail.Material, "Material");
                            if (materials.Contains(material) == false)
                            {
                                materials.Add(material);
                            }

                            TempDrugOrder tempdrugOrder = new TempDrugOrder();
                            tempdrugOrder.OrderID = (int)detail.Drugorderintroductionid;
                            tempdrugOrder.OrderObjectID = (Guid)detail.Drugorderid;
                            tempdrugOrder.DrugName = material.Name;
                            tempdrugOrder.Frequency = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(detail.Frequency).DisplayText;
                            tempdrugOrder.DoseAmount = (int)detail.DoseAmount;
                            tempdrugOrder.Day = (int)detail.Drugorderday;
                            tempdrugOrder.OrderDate = ((DateTime)detail.Orderdate).Date;
                            tempdrugOrder.MaterialObjectID = detail.Material.Value;
                            tempdrugOrder.NextDayOrder = detail.NextDayOrder.HasValue ? detail.NextDayOrder.Value : false;
                            tempdrugOrder.FrequencyEnumValue = detail.Frequency.Value;
                            tempdrugOrder.UsageNote = detail.UsageNote;

                            if (detail.Drugordertype == TTUtils.CultureService.GetText("M26287", "K-Çizelgesi"))
                            {
                                tempdrugOrder.OrderType = "Günlük İlaç Çizelgesi";
                                if (DrugOrder.GetContinueDrugOrder(input.episode.ObjectID, material.ObjectID, DateTime.Now))
                                {
                                    if (detail.CurrentStateDefID == DrugOrder.States.Planned)
                                        tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M27028", "Tamamlandı");
                                    else
                                        tempdrugOrder.OrderStatus = detail.DisplayText;
                                }
                                else
                                    tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M25428", "Devam Ediyor");
                            }
                            else if (detail.Drugordertype == "Yatan Hasta Reçetesi")
                            {
                                if (Convert.ToInt32(detail.Inpatientpresdetailcount.ToString()) > 0)
                                    tempdrugOrder.OrderType = "Yatan Hasta Reçetesi";
                                else
                                    tempdrugOrder.OrderType = "Ayaktan Hasta Reçetesi";
                                tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M27028", "Tamamlandı");
                            }
                            else if (detail.Drugordertype == "Hasta Yanında Getirdi")
                            {
                                tempdrugOrder.OrderType = "Hasta Yanında Getirdi";
                                if (DrugOrder.GetContinueDrugOrder(input.episode.ObjectID, material.ObjectID, DateTime.Now))
                                {
                                    if (detail.CurrentStateDefID == DrugOrder.States.Planned)
                                        tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M27028", "Tamamlandı");
                                    else
                                        tempdrugOrder.OrderStatus = detail.DisplayText;
                                }
                                else
                                    tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M25428", "Devam Ediyor");
                            }
                            else if (detail.Drugordertype == TTUtils.CultureService.GetText("M26386", "Lüzumu Halinde"))
                            {
                                tempdrugOrder.OrderType = "Lüzumu Halinde";
                                tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M25428", "Devam Ediyor");
                            }

                            tempDrugOrders.Add(tempdrugOrder);
                        }

                        oldDrugOrderIntroductionDet.Materials = materials;
                        oldDrugOrderIntroductionDet.TempDrugOrders = tempDrugOrders;
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return oldDrugOrderIntroductionDet;
            }
        }

        [HttpPost]
        public OldDrugOrderIntroductionDet GetOldDrugOrderIntroductionDets(GetOldDrugOrderIntroductionDets_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                OldDrugOrderIntroductionDet oldDrugOrderIntroductionDet = new OldDrugOrderIntroductionDet();
                List<DrugOrderIntroductionDet> drugOrderIntroductionDets = new List<DrugOrderIntroductionDet>();
                List<TempDrugOrder> tempDrugOrders = new List<TempDrugOrder>();
                List<Material> materials = new List<Material>();
                if (input.episode != null)
                {
                    IBindingList details = objectContext.QueryObjects("DRUGORDERINTRODUCTIONDET", "DRUGORDERINTRODUCTION.EPISODE=" + TTConnectionManager.ConnectionManager.GuidToString(input.episode.ObjectID));
                    foreach (DrugOrderIntroductionDet detail in details)
                    {
                        drugOrderIntroductionDets.Add(detail);
                        if (materials.Contains(detail.Material) == false)
                            materials.Add(detail.Material);
                        TempDrugOrder tempdrugOrder = new TempDrugOrder();
                        tempdrugOrder.OrderID = (int)detail.DrugOrderIntroduction.ID.Value;
                        tempdrugOrder.OrderObjectID = detail.DrugOrder.ObjectID;
                        tempdrugOrder.DrugName = detail.DrugOrder.Material.Name;
                        tempdrugOrder.Frequency = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(detail.DrugOrder.Frequency).DisplayText;
                        tempdrugOrder.DoseAmount = (int)detail.DrugOrder.DoseAmount;
                        tempdrugOrder.Day = (int)detail.DrugOrder.Day;
                        tempdrugOrder.OrderDate = ((DateTime)detail.DrugOrder.PlannedStartTime).Date;
                        if (detail.DrugOrder.Type == TTUtils.CultureService.GetText("M26287", "K-Çizelgesi"))
                        {
                            tempdrugOrder.OrderType = "Günlük İlaç Çizelgesi";
                            if (DrugOrder.GetContinueDrugOrder(detail.DrugOrder.Episode.ObjectID, detail.Material.ObjectID, DateTime.Now))
                            {
                                if (detail.DrugOrder.CurrentStateDefID == DrugOrder.States.Planned)
                                    tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M27028", "Tamamlandı");
                                else
                                    tempdrugOrder.OrderStatus = detail.DrugOrder.CurrentStateDef.DisplayText;
                            }
                            else
                                tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M25428", "Devam Ediyor");
                        }
                        else if (detail.DrugOrder.Type == "Yatan Hasta Reçetesi")
                        {
                            if (detail.DrugOrderIntroduction.InpatientPresDetails.Count > 0)
                                tempdrugOrder.OrderType = "Yatan Hasta Reçetesi";
                            else
                                tempdrugOrder.OrderType = "Ayaktan Hasta Reçetesi";
                            tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M27028", "Tamamlandı");
                        }
                        else if (detail.DrugOrder.Type == "Hasta Yanında Getirdi")
                        {
                            tempdrugOrder.OrderType = "Hasta Yanında Getirdi";
                            if (DrugOrder.GetContinueDrugOrder(detail.DrugOrder.Episode.ObjectID, detail.Material.ObjectID, DateTime.Now))
                            {
                                if (detail.DrugOrder.CurrentStateDefID == DrugOrder.States.Planned)
                                    tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M27028", "Tamamlandı");
                                else
                                    tempdrugOrder.OrderStatus = detail.DrugOrder.CurrentStateDef.DisplayText;
                            }
                            else
                                tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M25428", "Devam Ediyor");
                        }
                        else if (detail.DrugOrder.Type == TTUtils.CultureService.GetText("M26386", "Lüzumu Halinde"))
                        {
                            tempdrugOrder.OrderType = "Lüzumu Halinde";
                            tempdrugOrder.OrderStatus = TTUtils.CultureService.GetText("M25428", "Devam Ediyor");
                        }
                        tempDrugOrders.Add(tempdrugOrder);
                    }

                    oldDrugOrderIntroductionDet.DrugOrderIntroductionDets = drugOrderIntroductionDets;
                    oldDrugOrderIntroductionDet.Materials = materials;
                    oldDrugOrderIntroductionDet.TempDrugOrders = tempDrugOrders;
                }

                objectContext.FullPartialllyLoadedObjects();
                return oldDrugOrderIntroductionDet;
            }
        }

        [HttpPost]
        public List<OldDrugOrderIntroduction> GetOldDrugOrderIntroductions(GetOldDrugOrderIntroductionDets_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<OldDrugOrderIntroduction> output = new List<OldDrugOrderIntroduction>();
                if (input.episode != null)
                {
                    IBindingList details = objectContext.QueryObjects("DRUGORDERINTRODUCTION", "EPISODE=" + TTConnectionManager.ConnectionManager.GuidToString(input.episode.ObjectID), "ACTIONDATE");
                    foreach (DrugOrderIntroduction detail in details)
                    {
                        OldDrugOrderIntroduction oldDrugOrderIntroduction = new OldDrugOrderIntroduction();
                        oldDrugOrderIntroduction.ObjectId = detail.ObjectID;
                        oldDrugOrderIntroduction.ActionDate = (DateTime)detail.ActionDate;
                        oldDrugOrderIntroduction.Description = detail.CurrentStateDef.Description;
                        string eReceteStatus = string.Empty;
                        foreach (InpatientPresDetail inPresDetail in detail.InpatientPresDetails)
                        {
                            if (string.IsNullOrEmpty(inPresDetail.InpatientPrescription.EReceteNo) == false)
                                eReceteStatus = eReceteStatus + " - " + inPresDetail.InpatientPrescription.EReceteNo;
                        }
                        foreach (OutpatientPresDetail outPresDetail in detail.OutpatientPresDetails)
                        {
                            if (string.IsNullOrEmpty(outPresDetail.OutPatientPrescription.EReceteNo) == false)
                                eReceteStatus = eReceteStatus + " - " + outPresDetail.OutPatientPrescription.EReceteNo;
                        }

                        oldDrugOrderIntroduction.EReceteStatus = eReceteStatus;
                        output.Add(oldDrugOrderIntroduction);
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class OldDrugOrderIntroduction
        {
            public Guid ObjectId
            {
                get;
                set;
            }

            public DateTime ActionDate
            {
                get;
                set;
            }

            public string Description
            {
                get;
                set;
            }

            public string EReceteStatus
            {
                get;
                set;
            }
        }

        public class OldDrugOrderIntroductionDet
        {
            public List<DrugOrderIntroductionDet> DrugOrderIntroductionDets
            {
                get;
                set;
            }

            public List<Material> Materials
            {
                get;
                set;
            }

            public List<TempDrugOrder> TempDrugOrders
            {
                get;
                set;
            }
        }

        public class TempDrugOrder
        {
            public int OrderID
            {
                get;
                set;
            }

            public string DrugName
            {
                get;
                set;
            }

            public int DoseAmount
            {
                get;
                set;
            }

            public string Frequency
            {
                get;
                set;
            }

            public FrequencyEnum FrequencyEnumValue { get; set; }

            public int Day
            {
                get;
                set;
            }

            public string OrderStatus
            {
                get;
                set;
            }

            public string OrderType
            {
                get;
                set;
            }

            public DateTime OrderDate
            {
                get;
                set;
            }

            public Guid OrderObjectID
            {
                get;
                set;
            }
            public Guid MaterialObjectID { get; set; }
            public bool NextDayOrder { get; set; }
            public string UsageNote { get; set; }
        }

        public class ActiveDrugOrders
        {
            public List<Order> Orders
            {
                get;
                set;
            }

            public List<DrugList> Drugs
            {
                get;
                set;
            }

            public List<OrderDetail> OrderDetails
            {
                get;
                set;
            }

            public List<DrugList> DetailDrugs
            {
                get;
                set;
            }
        }

        public class DrugList
        {
            public string text
            {
                get;
                set;
            }

            public Guid id
            {
                get;
                set;
            }

            public string color
            {
                get;
                set;
            }
        }

        public class Order
        {
            public Guid id
            {
                get;
                set;
            }

            public string text
            {
                get;
                set;
            }

            public Guid ownerId
            {
                get;
                set;
            }

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

            public string color
            {
                get;
                set;
            }

            public string state
            {
                get;
                set;
            }

            public string orderDetail
            {
                get;
                set;
            }
        }

        public class Priority
        {
            public string text
            {
                get;
                set;
            }

            public int id
            {
                get;
                set;
            }

            public string color
            {
                get;
                set;
            }
        }

        List<Priority> prioritiesData = new List<Priority>()
        {new Priority()
        {text = "Low Priority", id = 1, color = "#1e90ff"}, new Priority()
        {text = "High Priority", id = 2, color = "#ff9747"}};
        public class OrderDetail
        {
            public Guid id
            {
                get;
                set;
            }

            public string text
            {
                get;
                set;
            }

            public Guid typeId
            {
                get;
                set;
            }

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
        }
        public class UpdateDrugOrderDetails_Input
        {
            public List<DrugOrderDetail> drugOrderDetails { get; set; }
        }

        [HttpPost]
        public bool UpdateDrugOrderDetails(UpdateDrugOrderDetails_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    objectContext.AddToRawObjectList(input.drugOrderDetails);
                    objectContext.ProcessRawObjects(false);
                    //foreach (DrugOrderDetail detail in input.drugOrderDetails)
                    //{
                    //    DateTime newDate = detail.OrderPlannedDate.Value;
                    //    DrugOrderDetail orderDetail = (DrugOrderDetail)objectContext.GetObject(detail.ObjectID, typeof(DrugOrderDetail));
                    //    orderDetail.OrderPlannedDate = newDate;
                    //}
                    DrugOrderDetail drugOrderDetail = (DrugOrderDetail)objectContext.GetObject(input.drugOrderDetails[0].ObjectID, typeof(DrugOrderDetail));
                    if (drugOrderDetail.DrugOrder.PlannedStartTime != drugOrderDetail.DrugOrder.DrugOrderDetails.Where(x => x.DetailNo == 1).FirstOrDefault().OrderPlannedDate)
                        drugOrderDetail.DrugOrder.PlannedStartTime = drugOrderDetail.DrugOrder.DrugOrderDetails.Where(x => x.DetailNo == 1).FirstOrDefault().OrderPlannedDate;
                    objectContext.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public class UpgradeDrugOrder_Input
        {
            public DrugOrderIntroductionGridViewModel gridViewModel { get; set; }
        }

        public class UpgradeDrugOrder_Output
        {
            public bool result { get; set; }
            public string errorMessage { get; set; }
        }

        public UpgradeDrugOrder_Output UpgradeDrugOrder(UpgradeDrugOrder_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(input.gridViewModel.LastDrugOrderObjectID, typeof(DrugOrder));
                    drugOrder.OldHospitalTimeScheduleID = drugOrder.HospitalTimeSchedule.ObjectID;
                    drugOrder.IsUpgraded = true;
                    HospitalTimeSchedule hospitalTimeSchedule = (HospitalTimeSchedule)objectContext.GetObject(input.gridViewModel.HospitalTimeScheduleObjectID.Value, typeof(HospitalTimeSchedule));
                    drugOrder.HospitalTimeSchedule = hospitalTimeSchedule;
                    drugOrder.DoseAmount = input.gridViewModel.DoseAmount;
                    if (drugOrder.UsageNote.Equals(input.gridViewModel.UsageNote) == false)
                    {
                        drugOrder.UsageNote = input.gridViewModel.UsageNote;
                        foreach (DrugOrderDetail detail in drugOrder.DrugOrderDetails)
                        {
                            detail.UsageNote = input.gridViewModel.UsageNote;
                        }
                    }

                    if (drugOrder.IsCV != input.gridViewModel.IsCV)
                    {
                        KScheduleMaterial scheduleMat = null;
                        IBindingList findKM = objectContext.QueryObjects("KSCHEDULEMATERIAL", "DRUGORDEROBJECTID=" + TTConnectionManager.ConnectionManager.GuidToString(drugOrder.ObjectID));
                        foreach (KScheduleMaterial kScheduleMaterial in findKM)
                        {
                            if (kScheduleMaterial.KSchedule.CurrentStateDefID == KSchedule.States.RequestPreparation)
                            {
                                scheduleMat = kScheduleMaterial;
                                break;
                            }
                        }
                        if (scheduleMat != null)
                        {
                            drugOrder.IsCV = input.gridViewModel.IsCV;
                            IBindingList introductionDet = objectContext.QueryObjects("DRUGORDERINTRODUCTIONDET", "DRUGORDER=" + TTConnectionManager.ConnectionManager.GuidToString(drugOrder.ObjectID));
                            if (introductionDet.Count > 0)
                            {
                                ((DrugOrderIntroductionDet)introductionDet[0]).IsCV = input.gridViewModel.IsCV;
                            }
                            scheduleMat.IsCV = input.gridViewModel.IsCV;
                        }
                        else
                        {
                            throw new Exception("Bu order eczane tarafından karşılandığı için CV durumunu değiştiremezsiniz.");
                        }

                    }


                    DrugDefinition drugDefinition = (DrugDefinition)drugOrder.Material;
                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    double totalAmount = 0;
                    foreach (DrugOrderTimceSchedule timeDetail in input.gridViewModel.DrugOrderIntroDuctionTimeSchedule.Where(x => x.UpgradeDetail == true))
                    {
                        DrugOrderDetail findDrugOrderDetail = drugOrder.DrugOrderDetails.Where(y => y.DetailNo == timeDetail.DetailNo).FirstOrDefault();
                        double unitAmount = Math.Ceiling(timeDetail.DoseAmount.Value);
                        double doseAmount = 0;
                        if (findDrugOrderDetail != null)
                        {
                            DrugOrderDetail updateDrugOrderDetail = (DrugOrderDetail)objectContext.GetObject(findDrugOrderDetail.ObjectID, typeof(DrugOrderDetail));
                            updateDrugOrderDetail.OrderPlannedDate = timeDetail.Time;
                            if (drugType)
                            {
                                totalAmount = totalAmount + (unitAmount - findDrugOrderDetail.Amount.Value);
                                doseAmount = (double)timeDetail.DoseAmount;
                            }
                            else
                            {
                                totalAmount = totalAmount + Math.Ceiling((unitAmount - findDrugOrderDetail.Amount.Value) / (double)drugDefinition.Volume);
                                doseAmount = (double)timeDetail.DoseAmount * (double)drugDefinition.Dose;
                            }
                            updateDrugOrderDetail.OrderPlannedDate = timeDetail.Time;
                            updateDrugOrderDetail.Amount = unitAmount;
                            updateDrugOrderDetail.DoseAmount = doseAmount;
                            updateDrugOrderDetail.UsageNote = timeDetail.UsageNote;
                        }
                        else
                        {
                            DrugOrderDetail drugOrderDetail = new DrugOrderDetail(objectContext);
                            drugOrderDetail.Material = (Material)drugOrder.Material;
                            drugOrderDetail.MasterResource = drugOrder.MasterResource;
                            drugOrderDetail.FromResource = drugOrder.FromResource;
                            drugOrderDetail.Episode = drugOrder.Episode;
                            drugOrderDetail.ActionDate = drugOrder.ActionDate; // Bu actionun açıldığı tarih olmalı. SS
                            drugOrderDetail.OrderPlannedDate = timeDetail.Time;
                            drugOrderDetail.UsageNote = timeDetail.UsageNote;
                            drugOrderDetail.Day = drugOrder.Day;
                            drugOrderDetail.SubEpisode = drugOrder.SubEpisode;
                            drugOrderDetail.MedulaReportNo = drugOrder.MedulaReportNo;
                            if (drugType)
                            {
                                totalAmount = totalAmount + unitAmount;
                                doseAmount = (double)timeDetail.DoseAmount;
                            }
                            else
                            {
                                totalAmount = totalAmount + Math.Ceiling(unitAmount / (double)drugDefinition.Volume);
                                doseAmount = (double)timeDetail.DoseAmount * (double)drugDefinition.Dose;
                            }

                            drugOrderDetail.Amount = unitAmount;
                            drugOrderDetail.DoseAmount = doseAmount;
                            drugOrderDetail.Frequency = drugOrder.Frequency;
                            drugOrderDetail.HospitalTimeSchedule = input.gridViewModel.HospitalTimeSchedule;
                            drugOrderDetail.DrugOrder = drugOrder;
                            drugOrderDetail.DetailNo = timeDetail.DetailNo;
                            drugOrderDetail.SecondaryMasterResource = drugOrder.NursingApplication.SecondaryMasterResource;
                            drugOrderDetail.NursingApplication = drugOrder.NursingApplication;
                            drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;

                            if (drugType)
                                drugOrderDetail.Eligible = true;
                            else
                                drugOrderDetail.Eligible = false;

                        }
                    }
                    objectContext.Update();
                    CreatedKscheduleForUpgradeDrugOrder(drugOrder, totalAmount, objectContext);
                    objectContext.Save();
                    UpgradeDrugOrder_Output output = new UpgradeDrugOrder_Output();
                    output.result = true;
                    output.errorMessage = string.Empty;
                    return output;
                }
                catch (Exception ex)
                {
                    UpgradeDrugOrder_Output output = new UpgradeDrugOrder_Output();
                    output.result = false;
                    output.errorMessage = ex.Message;
                    return output;
                }
            }
        }

        public bool CreatedKscheduleForUpgradeDrugOrder(DrugOrder order, double amount, TTObjectContext contextKshedule)
        {
            try
            {
                bool returnResult = false;

                KScheduleMaterial scheduleMat = null;
                IBindingList findKM = contextKshedule.QueryObjects("KSCHEDULEMATERIAL", "DRUGORDEROBJECTID=" + TTConnectionManager.ConnectionManager.GuidToString(order.ObjectID));
                foreach (KScheduleMaterial kScheduleMaterial in findKM)
                {
                    if (kScheduleMaterial.KSchedule.CurrentStateDefID == KSchedule.States.RequestPreparation)
                    {
                        scheduleMat = kScheduleMaterial;
                        break;
                    }
                }

                if (scheduleMat != null)
                {
                    scheduleMat.Amount = scheduleMat.Amount + amount;
                    scheduleMat.RequestAmount = scheduleMat.RequestAmount + amount;
                    foreach (DrugOrderDetail detail in order.DrugOrderDetails.Where(x => x.KScheduleCollectedOrder == null))
                    {
                        scheduleMat.KScheduleCollectedOrder.DrugOrderDetails.Add(detail);
                        detail.CurrentStateDefID = DrugOrderDetail.States.Request;
                        //DrugOrderDetail drugOrderDetail = contextKshedule.GetObject()
                        //detail.KScheduleCollectedOrder = scheduleMat.KScheduleCollectedOrder;
                    }
                }
                else
                {

                    List<KScheduleMaterial> ksheduleMaterials = new List<KScheduleMaterial>();
                    List<KScheduleUnListMaterial> ksheduleUnListMaterials = new List<KScheduleUnListMaterial>();

                    bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)order.Material);

                    double restDose = 0;
                    Dictionary<object, double> rests = DrugOrderTransaction.GetPatientRestDose(order.Material, order.Episode);
                    List<DrugOrderDetail> unListDetails = new List<DrugOrderDetail>();
                    foreach (KeyValuePair<object, double> rest in rests)
                    {
                        restDose = restDose + rest.Value;
                    }

                    KScheduleMaterial ksmaterial = null;
                    if (restDose == 0)
                    {
                        ksmaterial = new KScheduleMaterial(contextKshedule);
                        ksmaterial.Material = order.Material;
                        ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                        ksmaterial.IsImmediate = order.IsImmediate;
                        ksmaterial.BarcodeVerifyCounter = 0;
                        ksmaterial.DrugOrderObjectID = order.ObjectID;

                        if (drugType)
                        {
                            ksmaterial.RequestAmount = amount;
                            ksmaterial.Amount = amount;
                        }
                        else
                        {
                            double rAmount = ((double)amount) / ((double)((DrugDefinition)order.Material).Volume);
                            ksmaterial.Amount = Math.Ceiling(rAmount);
                            ksmaterial.RequestAmount = Math.Ceiling(rAmount);
                        }

                    }
                    else if (restDose > amount)
                    {
                        foreach (DrugOrderDetail detail in order.DrugOrderDetails.Where(x => x.KScheduleCollectedOrder == null))
                        {
                            unListDetails.Add(detail);
                            detail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                        }
                    }
                    else
                    {
                        double restamount = 0;
                        foreach (DrugOrderDetail detail in order.DrugOrderDetails.Where(x => x.KScheduleCollectedOrder == null))
                        {
                            if (drugType)
                            {
                                if (restDose > detail.Amount)
                                {
                                    detail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                                    restDose = restDose - (double)detail.Amount;
                                }
                                else
                                {
                                    restamount = restamount + (double)detail.Amount;
                                }

                            }
                            else
                            {
                                if (restDose > detail.Amount)
                                {
                                    detail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                                    restDose = restDose - (double)detail.DoseAmount;
                                }
                                else
                                {
                                    restamount = restamount + (double)detail.DoseAmount;
                                }
                            }
                        }
                        if (restamount > 0)
                        {
                            ksmaterial = new KScheduleMaterial(contextKshedule);
                            ksmaterial.Material = order.Material;
                            ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                            ksmaterial.IsImmediate = order.IsImmediate;
                            ksmaterial.BarcodeVerifyCounter = 0;
                            ksmaterial.DrugOrderObjectID = order.ObjectID;

                            if (drugType)
                            {
                                ksmaterial.RequestAmount = restamount;
                                ksmaterial.Amount = restamount;
                            }
                            else
                            {
                                double rAmount = ((double)restamount) / ((double)((DrugDefinition)order.Material).Volume);
                                ksmaterial.Amount = Math.Ceiling(rAmount);
                                ksmaterial.RequestAmount = Math.Ceiling(rAmount);
                            }
                        }
                    }

                    if (ksmaterial != null)
                    {
                        KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(contextKshedule);
                        foreach (DrugOrderDetail detail in order.DrugOrderDetails.Where(x => x.KScheduleCollectedOrder == null))
                        {
                            kScheduleCollectedOrder.DrugOrderDetails.Add(detail);
                            if (detail.CurrentStateDefID != DrugOrderDetail.States.UseRestDose)
                                detail.CurrentStateDefID = DrugOrderDetail.States.Request;
                        }
                        ksmaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;
                        ksheduleMaterials.Add(ksmaterial);
                    }

                    if (unListDetails.Count > 0)
                    {
                        KScheduleUnListMaterial unListMaterial = new KScheduleUnListMaterial(contextKshedule);

                        unListMaterial.UnlistDrug = order.Material.Name;
                        if (drugType)
                        {
                            unListMaterial.UnlistAmount = restDose;
                            unListMaterial.UnlistVolume = restDose * ((DrugDefinition)order.Material).Volume;
                        }
                        else
                        {
                            unListMaterial.UnlistAmount = restDose / ((DrugDefinition)order.Material).Volume;
                            unListMaterial.UnlistVolume = restDose;
                        }

                        foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                        {
                            DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                            unListMaterial.DrugOrderDetails.Add(drugOrderDetail);
                        }
                        ksheduleUnListMaterials.Add(unListMaterial);
                        //kScheduleNew.KScheduleUnListMaterials.Add(unListMaterial);
                    }



                    DateTime startDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 00:00:00");
                    DateTime endDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");
                    BindingList<KSchedule> activeKschedules = KSchedule.GetActiveKSchedule(contextKshedule, order.InPatientPhysicianApplication.ObjectID, startDate, endDate);

                    if (activeKschedules.Count > 0)
                    {
                        KSchedule kSchedule = contextKshedule.GetObject<KSchedule>(activeKschedules[0].ObjectID);

                        foreach (KScheduleMaterial material in ksheduleMaterials)
                            kSchedule.KScheduleMaterials.Add(material);

                        foreach (KScheduleUnListMaterial unListMaterial in ksheduleUnListMaterials)
                            unListMaterial.KSchedule = kSchedule;
                    }
                    else
                    {
                        if (ksheduleMaterials.Count() > 0)
                        {
                            KSchedule kScheduleNew = new KSchedule(contextKshedule);
                            kScheduleNew.StartDate = Common.RecTime();
                            //kScheduleNew.EndDate = dailyDrugSchedule.EndDate;
                            Store pharmacy = Store.GetPharmacyStore(contextKshedule);
                            if (pharmacy != null)
                            {
                                kScheduleNew.Store = pharmacy;
                            }
                            kScheduleNew.DestinationStore = order.InPatientPhysicianApplication.MasterResource.Store;
                            kScheduleNew.Episode = order.InPatientPhysicianApplication.Episode;
                            kScheduleNew.InPatientPhysicianApplication = order.InPatientPhysicianApplication;
                            kScheduleNew.MKYS_TeslimAlanObjID = Common.CurrentUser.UserObject.ObjectID;
                            kScheduleNew.MKYS_TeslimAlan = ((ResUser)Common.CurrentUser.UserObject).Name;


                            foreach (KScheduleMaterial material in ksheduleMaterials)
                                kScheduleNew.KScheduleMaterials.Add(material);

                            foreach (KScheduleUnListMaterial unListMaterial in ksheduleUnListMaterials)
                                unListMaterial.KSchedule = kScheduleNew;

                            kScheduleNew.CurrentStateDefID = KSchedule.States.New;
                            kScheduleNew.Update();
                            kScheduleNew.CurrentStateDefID = KSchedule.States.Approval;
                            kScheduleNew.Update();
                            kScheduleNew.CurrentStateDefID = KSchedule.States.RequestPreparation;
                        }
                    }
                }
                //contextKshedule.Dispose();
                returnResult = true;
                return returnResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public class GetActiveDrugOrderDetails_Input
        {
            public Guid drugOrderObjectID { get; set; }
        }
        public class GetActiveDrugOrderDetails_Output
        {
            public DrugOrderDetail[] drugOrderDetails { get; set; }
        }


        [HttpPost]
        public GetActiveDrugOrderDetails_Output GetActiveDrugOrderDetails(GetActiveDrugOrderDetails_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<DrugOrderDetail> details = new List<DrugOrderDetail>();
                DrugOrder order = (DrugOrder)objectContext.GetObject(input.drugOrderObjectID, typeof(DrugOrder));
                DateTime nowDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                {
                    if (detail.OrderPlannedDate > nowDay)
                    {
                        if (detail.CurrentStateDefID == DrugOrderDetail.States.Planned ||
                            detail.CurrentStateDefID == DrugOrderDetail.States.Request ||
                            detail.CurrentStateDefID == DrugOrderDetail.States.Supply
                            || detail.CurrentStateDefID == DrugOrderDetail.States.UseRestDose)
                            details.Add(detail);
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                return new GetActiveDrugOrderDetails_Output { drugOrderDetails = details.ToArray() };
            }
        }

        [HttpPost]
        public ActiveDrugOrders GetActiveDrugOrders(GetOldDrugOrderIntroductionDets_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ActiveDrugOrders activeDrugOrders = new ActiveDrugOrders();
                List<Order> orders = new List<Order>();
                List<DrugList> drugs = new List<DrugList>();
                List<DrugList> detailDrugs = new List<DrugList>();
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                List<Guid> detailDrugobjectIds = new List<Guid>();
                List<Material> materials = new List<Material>();
                if (input.episode != null)
                {
                    string filter = "EPISODE=" + TTConnectionManager.ConnectionManager.GuidToString(input.episode.ObjectID);
                    if (input.PlannedStartDate != null)
                    {
                        string firstDate = Convert.ToDateTime(input.PlannedStartDate).ToShortDateString();
                        string lastDate = Convert.ToDateTime(DateTime.Now.AddDays(5)).ToShortDateString();

                        filter += " AND PlannedStartTime >= '" + firstDate + "' AND";
                        filter += " PlannedStartTime <= '" + lastDate + "'";
                    }


                    IBindingList details = objectContext.QueryObjects("DRUGORDER", filter);
                    foreach (DrugOrder order in details)
                    {
                        if (order is InpatientDrugOrder == false)
                        {
                            if (order.CurrentStateDefID != DrugOrder.States.Completed && order.CurrentStateDefID != DrugOrder.States.Cancelled && order.CurrentStateDefID != DrugOrder.States.Stopped && order.CurrentStateDefID != DrugOrder.States.New)
                            {
                                Order activeOrder = new Order();
                                activeOrder.id = order.ObjectID;
                                activeOrder.text = order.Material.Name;
                                activeOrder.startDate = (DateTime)order.PlannedStartTime;
                                activeOrder.endDate = ((DateTime)order.PlannedStartTime).AddDays((int)order.Day);
                                activeOrder.ownerId = order.Material.ObjectID;
                                activeOrder.color = GetRandomColorName();
                                activeOrder.state = order.CurrentStateDef.DisplayText;
                                switch (order.Frequency)
                                {
                                    case FrequencyEnum.Q24H:
                                        {
                                            activeOrder.orderDetail = "1 X " + order.DoseAmount.ToString() + " - " + order.Day.ToString() + " gün";
                                            break;
                                        }

                                    case FrequencyEnum.Q12H:
                                        {
                                            activeOrder.orderDetail = "2 X " + order.DoseAmount.ToString() + " - " + order.Day.ToString() + " gün";
                                            break;
                                        }

                                    case FrequencyEnum.Q8H:
                                        {
                                            activeOrder.orderDetail = "3 X " + order.DoseAmount.ToString() + " - " + order.Day.ToString() + " gün";
                                            break;
                                        }

                                    case FrequencyEnum.Q6H:
                                        {
                                            activeOrder.orderDetail = "4 X " + order.DoseAmount.ToString() + " - " + order.Day.ToString() + " gün";
                                            break;
                                        }

                                    case FrequencyEnum.Q4H:
                                        {
                                            activeOrder.orderDetail = "6 X " + order.DoseAmount.ToString() + " - " + order.Day.ToString() + " gün";
                                            break;
                                        }

                                    case FrequencyEnum.Q3H:
                                        {
                                            activeOrder.orderDetail = "8 X " + order.DoseAmount.ToString() + " - " + order.Day.ToString() + " gün";
                                            break;
                                        }

                                    case FrequencyEnum.Q2H:
                                        {
                                            activeOrder.orderDetail = "12 X " + order.DoseAmount.ToString() + " - " + order.Day.ToString() + " gün";
                                            break;
                                        }

                                    case FrequencyEnum.Q1H:
                                        {
                                            activeOrder.orderDetail = "24 X " + order.DoseAmount.ToString() + " - " + order.Day.ToString() + " gün";
                                            break;
                                        }

                                    default:
                                        {
                                            activeOrder.orderDetail = " Yazdığınız doz aralığı planlamaya uygun değildir.";
                                            break;
                                        }
                                }

                                if (materials.Contains(order.Material) == false)
                                    materials.Add(order.Material);
                                orders.Add(activeOrder);
                                foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                {
                                    if (detail.CurrentStateDefID != DrugOrderDetail.States.Supply && detail.CurrentStateDefID != DrugOrderDetail.States.Cancel && detail.CurrentStateDefID != DrugOrderDetail.States.Stop)
                                    {
                                        OrderDetail orderDetail = new OrderDetail();
                                        orderDetail.id = detail.ObjectID;
                                        orderDetail.text = detail.CurrentStateDef.DisplayText;
                                        orderDetail.typeId = detail.Material.ObjectID;
                                        orderDetail.startDate = (DateTime)detail.OrderPlannedDate;
                                        orderDetail.endDate = ((DateTime)detail.OrderPlannedDate).AddMinutes(30);
                                        orderDetails.Add(orderDetail);
                                        if (detailDrugobjectIds.Contains(detail.Material.ObjectID) == false)
                                            detailDrugobjectIds.Add(detail.Material.ObjectID);
                                    }
                                }
                            }
                        }
                    }

                    foreach (Material mat in materials)
                    {
                        DrugList drugList = new DrugList();
                        drugList.id = mat.ObjectID;
                        drugList.text = mat.Name;
                        drugList.color = CommonServiceController.GetRandomLightColor(); //GetRandomColorName();
                        drugs.Add(drugList);
                        if (detailDrugobjectIds.Contains(mat.ObjectID))
                        {
                            DrugList detailDrugList = new DrugList();
                            detailDrugList.id = mat.ObjectID;
                            detailDrugList.text = mat.Name;
                            detailDrugList.color = drugList.color;
                            detailDrugs.Add(detailDrugList);
                        }
                    }

                    activeDrugOrders.Drugs = drugs;
                    activeDrugOrders.Orders = orders;
                    activeDrugOrders.OrderDetails = orderDetails;
                    activeDrugOrders.DetailDrugs = detailDrugs;
                }

                objectContext.FullPartialllyLoadedObjects();
                return activeDrugOrders;
            }
        }

        public class ValidationPatientAgeAndMaterialAgeBand_Input
        {
            public string EpisodeObjectID
            {
                get;
                set;
            }

            public string MaterialObjectID
            {
                get;
                set;
            }
        }
        public class ValidationPatientAgeAndMaterialAgeBand_Output
        {
            public int PatientAge
            {
                get;
                set;
            }

            public int MaterialMaxAge
            {
                get;
                set;
            }
            public int MaterialMinAge
            {
                get;
                set;
            }
        }

        [HttpPost]
        public ValidationPatientAgeAndMaterialAgeBand_Output GetValidationPatientAgeAndMaterialAgeBand(ValidationPatientAgeAndMaterialAgeBand_Input input)
        {
            try
            {

                using (var objectContext = new TTObjectContext(false))
                {

                    DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject(new Guid(input.MaterialObjectID), typeof(DrugDefinition));
                    Episode episode = (Episode)objectContext.GetObject(new Guid(input.EpisodeObjectID), typeof(Episode));

                    ValidationPatientAgeAndMaterialAgeBand_Output output = new ValidationPatientAgeAndMaterialAgeBand_Output();
                    output.PatientAge = episode.Patient.Age.Value;
                    if (drugDefinition.MaxPatientAge != null)
                        output.MaterialMaxAge = drugDefinition.MaxPatientAge.Value;
                    else
                        output.MaterialMaxAge = 999;

                    if (drugDefinition.MinPatientAge != null)
                        output.MaterialMinAge = drugDefinition.MinPatientAge.Value;
                    else
                        output.MaterialMinAge = -1;
                    return output;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [HttpPost]
        public List<DrugOrderObjectModel> GetOldDrugOrders(GetOldDrugOrderIntroductionDets_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugOrderObjectModel> oldOrders = new List<DrugOrderObjectModel>();
                if (input.episode != null)
                {
                    IBindingList details = objectContext.QueryObjects("DRUGORDER", "EPISODE=" + TTConnectionManager.ConnectionManager.GuidToString(input.episode.ObjectID));
                    foreach (DrugOrder order in details)
                    {
                        if (order.CurrentStateDefID == DrugOrder.States.Completed || order.CurrentStateDefID == DrugOrder.States.Cancelled || order.CurrentStateDefID == DrugOrder.States.Stopped)
                        {
                            DrugOrderObjectModel drugOrderObjectModel = new DrugOrderObjectModel();
                            drugOrderObjectModel.drugOrder = order;
                            drugOrderObjectModel.material = order.Material;
                            oldOrders.Add(drugOrderObjectModel);
                        }

                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return oldOrders;
            }
        }

        private Random random = new Random();
        public string GetRandomColorName()
        {
            string color = String.Format("#{0:X6}", random.Next(0x10000));
            return color;
        }


        public class PatientOwnDrugInfo
        {
            public string objectID { get; set; }
            public double amount
            {
                get;
                set;
            }

            public double restamount
            {
                get;
                set;
            }

            public string name
            {
                get;
                set;
            }

            public string barcode
            {
                get;
                set;
            }

            public DateTime expireDate
            {
                get;
                set;
            }
        }


        public class DrugInfo
        {
            public string drugObjectId { get; set; }
            public string name { get; set; }
            public string barcode { get; set; }
            public string inheldStatus { get; set; }
            public DrugUsageTypeEnum? drugUsageTypeEnum { get; set; }
            public bool? PatientSafetyFrom { get; set; }
            public PrescriptionTypeEnum? prescriptionTypeEnum { get; set; }
            public string SgkReturnPay { get; set; }
            public string pharmacyInHeld { get; set; }
            public DrugShapeTypeEnum? drugShapeTypeEnum { get; set; }
            public string Color { get; set; }
            public List<DrugIngredient> ActiveIngeridents { get; set; }
            public List<DrugSpecificationEnum> DrugSpecifications = new List<DrugSpecificationEnum>();
            public int minAge { get; set; }
            public int maxAge { get; set; }
            public DrugReportType DrugReportType { get; set; }
            public string MedulaReportNo { get; set; }
            public bool? isPatientOwnDrug { get; set; }
            public bool? drugType { get; set; }
            public string DrugDescription { get; set; }
            public bool? InfectionApproval { get; set; }
            public bool isDivisibleDrug { get; set; }
        }

        public class DrugIngredient
        {
            public Guid Objectid
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }
        }

        public class SearchDrug_Input
        {
            public string name
            {
                get;
                set;
            }

            public bool inheldStatus
            {
                get;
                set;
            }

            public List<DrugIngredient> drugIngredients
            {
                get;
                set;
            }
        }

        [HttpPost]
        public List<DrugInfo> SearchDrug(SearchDrug_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugInfo> searchDrugs = new List<DrugInfo>();

                string filter = "";


                BindingList<DrugDefinition> list = new BindingList<DrugDefinition>();
                if (input.inheldStatus)
                {
                    if (input.name != null && input.name != "")
                        filter = " AND NAME_SHADOW like '%" + Common.CUCase(input.name.ToUpperInvariant(), false, false) + "%' ";
                    Store pharmacy = Store.GetPharmacyStore(objectContext);
                    list = DrugDefinition.GetDrugDefInheldBiggerThanZero(objectContext, pharmacy.ObjectID, filter);
                }
                else
                {
                    if (input.name != null && input.name != "")
                        filter = " WHERE NAME_SHADOW like '%" + Common.CUCase(input.name.ToUpperInvariant(), false, false) + "%' AND ISACTIVE = 1";
                    list = DrugDefinition.GetDrugDefinition(objectContext, filter);
                }

                foreach (DrugDefinition drug in list)
                {
                    if (input.drugIngredients != null && input.drugIngredients.Count > 0)
                    {
                        List<Guid> drugIngredients = drug.DrugActiveIngredients.Select(t => t.ActiveIngredient.ObjectID).ToList();
                        bool isContainIngredient = false;
                        foreach (DrugIngredient ingredient in input.drugIngredients)
                        {
                            if (drugIngredients.Contains(ingredient.Objectid))
                                isContainIngredient = true;
                        }

                        if (isContainIngredient == false)
                            continue;
                    }

                    DrugInfo drugInfo = new DrugInfo();
                    drugInfo.drugObjectId = drug.ObjectID.ToString();
                    drugInfo.name = drug.Name;
                    drugInfo.inheldStatus = drug.PharmacyInheldStatus;
                    drugInfo.drugShapeTypeEnum = drug.DrugShapeType;
                    drugInfo.Color = ColorHelper.GetFontColor(drug.Color);
                    drugInfo.SgkReturnPay = DrugDefinition.GetSgkReturnPayText(drug.SgkReturnPay);
                    drugInfo.barcode = drug.Barcode;
                    drugInfo.isPatientOwnDrug = false;
                    drugInfo.drugType = DrugOrder.GetDrugUsedType(drug);

                    if (string.IsNullOrEmpty(drug.Description))
                    {
                        if (drug.MaterialDescriptionShowType != null)
                        {
                            if (drug.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.Order || drug.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.All)
                                drugInfo.DrugDescription = drug.Description;
                            else
                                drugInfo.DrugDescription = string.Empty;
                        }
                        else
                            drugInfo.DrugDescription = drug.Description;
                    }
                    else
                        drugInfo.DrugDescription = string.Empty;

                    if (drug.DivisibleDrug.HasValue)
                        drugInfo.isDivisibleDrug = drug.DivisibleDrug.Value;
                    else
                        drugInfo.isDivisibleDrug = false;

                    if (drug.MinPatientAge.HasValue)
                        drugInfo.minAge = drug.MinPatientAge.Value;
                    if (drug.MaxPatientAge.HasValue)
                        drugInfo.maxAge = drug.MaxPatientAge.Value;
                    if (drug.RouteOfAdmin != null)
                        drugInfo.drugUsageTypeEnum = drug.RouteOfAdmin.DrugUsageType;
                    if (drug.PrescriptionType != null)
                        drugInfo.prescriptionTypeEnum = drug.PrescriptionType;
                    if (drug.PatientSafetyFrom.HasValue)
                        drugInfo.PatientSafetyFrom = drug.PatientSafetyFrom;
                    else
                        drugInfo.PatientSafetyFrom = false;
                    if (drug.InpatientReportType != null)
                        drugInfo.DrugReportType = drug.InpatientReportType.Value;
                    else
                        drugInfo.DrugReportType = DrugReportType.Odenir;

                    if (drug.InfectionApproval != null)
                        drugInfo.InfectionApproval = drug.InfectionApproval.Value;
                    else
                        drugInfo.InfectionApproval = false;

                    drugInfo.ActiveIngeridents = new List<DrugIngredient>();
                    if (drug.DrugActiveIngredients.Count > 0)
                    {
                        foreach (DrugActiveIngredient dactiveIngredient in drug.DrugActiveIngredients)
                        {
                            DrugIngredient drugIngredient = new DrugIngredient();
                            drugIngredient.Objectid = dactiveIngredient.ActiveIngredient.ObjectID;
                            drugIngredient.Name = dactiveIngredient.ActiveIngredient.Name;
                            drugInfo.ActiveIngeridents.Add(drugIngredient);
                        }
                    }

                    if (drug.DrugSpecifications.Count > 0)
                        drugInfo.DrugSpecifications = drug.DrugSpecifications.Where(x => x.DrugSpecification.HasValue).Select(x => x.DrugSpecification.Value).ToList();
                    searchDrugs.Add(drugInfo);

                }

                objectContext.FullPartialllyLoadedObjects();
                return searchDrugs;
            }
        }

        [HttpGet]
        public List<DrugIngredient> GetDrugIngredients()
        {
            List<DrugIngredient> output = new List<DrugIngredient>();
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> ingredients = ActiveIngredientDefinition.GetActiveIngredientDefinitions(objectContext, "WHERE ISACTIVE=1");
                foreach (ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class ing in ingredients)
                {
                    DrugIngredient drugIngredient = new DrugIngredient();
                    drugIngredient.Objectid = ing.ObjectID.Value;
                    drugIngredient.Name = ing.Name;
                    output.Add(drugIngredient);
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class UpdateOrderDetail_Input
        {
            public OrderDetail orderDetail
            {
                get;
                set;
            }
        }

        public class UpdateOrderDetail_Output
        {
            public OrderDetail orderDetail
            {
                get;
                set;
            }

            public bool detailUpdate
            {
                get;
                set;
            }

            public string errorDescription
            {
                get;
                set;
            }
        }

        [HttpPost]
        public UpdateOrderDetail_Output UpdateOrderDetail(UpdateOrderDetail_Input input)
        {
            UpdateOrderDetail_Output output = new UpdateOrderDetail_Output();
            string errorDescription = TTUtils.CultureService.GetText("M25891", "hata alındı");
            bool detailUpdate = false;
            TTObjectContext context = new TTObjectContext(false);
            DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject(input.orderDetail.id, typeof(DrugOrderDetail));
            if (drugOrderDetail.Material.ObjectID.Equals(input.orderDetail.typeId))
            {
                if (input.orderDetail.startDate > DateTime.Now)
                {
                    drugOrderDetail.OrderPlannedDate = input.orderDetail.startDate;
                    context.Save();
                    detailUpdate = true;
                    errorDescription = TTUtils.CultureService.GetText("M25244", "Başarılı");
                }
                else
                {
                    errorDescription = TTUtils.CultureService.GetText("M26695", "Planlamayı geçmiş tarihe yapamazsanız");
                }
            }
            else
            {
                errorDescription = TTUtils.CultureService.GetText("M26693", "Planlamanın ilacını değiştiremezsiniz");
            }

            output.detailUpdate = detailUpdate;
            output.errorDescription = errorDescription;
            output.orderDetail = input.orderDetail;
            context.Dispose();
            return output;
        }

        public class GetOrderDetail_Input
        {
            public Guid id
            {
                get;
                set;
            }
        }

        public class GetOrderDetail_Output
        {
            public DrugOrderDetail orderDetail
            {
                get;
                set;
            }
        }

        [HttpPost]
        public DrugOrderDetail GetOrderDetail(GetOrderDetail_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                DrugOrderDetail drugOrderDetail = (DrugOrderDetail)objectContext.GetObject(input.id, typeof(DrugOrderDetail));
                objectContext.FullPartialllyLoadedObjects();
                return drugOrderDetail;
            }
        }

        public class StopDrugOrder_Input
        {
            public Guid id
            {
                get;
                set;
            }
        }

        //Çoklu durdurma
        public class StopDrugOrders_Input
        {
            public List<Guid> DrugOrderObjectIDList { get; set; }
        }
        public class StopDrugOrders_Output
        {
            public bool Result = false;
            public string ResultMessage { get; set; }
            public List<StopDrugOrderDetails> details { get; set; }

        }

        public class StopDrugOrderDetails
        {
            public Guid objectId
            {
                get;
                set;
            }

            public DrugOrderStatusEnum status
            {
                get;
                set;
            }

        }

        [HttpPost]
        public string StopDrugOrder(StopDrugOrder_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                string result = TTUtils.CultureService.GetText("M25496", "Direktif durduruldu.");
                try
                {
                    DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(input.id, typeof(DrugOrder));
                    drugOrder.CurrentStateDefID = DrugOrder.States.Stopped;
                    objectContext.Save();
                }
                catch (Exception ex)
                {
                    result = ex.ToString();
                }

                objectContext.FullPartialllyLoadedObjects();
                return result;
            }
        }

        //Çoklu durdurma
        [HttpPost]
        public StopDrugOrders_Output StopDrugOrders(StopDrugOrders_Input input)
        {
            StopDrugOrders_Output output = new StopDrugOrders_Output();
            output.details = new List<StopDrugOrderDetails>();
            List<Guid> kscheduleObjectID = new List<Guid>();
            List<Guid> infectionCommiteObjectID = new List<Guid>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    foreach (Guid drugOrderObjectID in input.DrugOrderObjectIDList)
                    {
                        DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(drugOrderObjectID, typeof(DrugOrder));
                        if (drugOrder.CurrentStateDefID == DrugOrder.States.Approve)
                        {
                            BindingList<InfectionCommittee.GetActiveInfectionComByDrugOrder_Class> activeInfectionComActionID = InfectionCommittee.GetActiveInfectionComByDrugOrder(drugOrder.ObjectID);
                            if (activeInfectionComActionID.Count > 0)
                            {
                                foreach (InfectionCommittee.GetActiveInfectionComByDrugOrder_Class action in activeInfectionComActionID)
                                {
                                    if (infectionCommiteObjectID.Contains(action.ObjectID.Value) == false)
                                        infectionCommiteObjectID.Add(action.ObjectID.Value);
                                }
                            }
                        }
                        if (drugOrder.PatientOwnDrug.HasValue && drugOrder.PatientOwnDrug.Value)
                        {
                            IBindingList ownDrugMaterial = objectContext.QueryObjects("KSCHEDULEPATIENOWNDRUG", "DRUGORDEROBJECTID =" + TTConnectionManager.ConnectionManager.GuidToString(drugOrder.ObjectID));
                            if (ownDrugMaterial.Count > 0)
                            {
                                KSchedulePatienOwnDrug ownDrug = (KSchedulePatienOwnDrug)ownDrugMaterial[0];
                                if (ownDrug.KSchedule.CurrentStateDefID == KSchedule.States.RequestFulfilled)
                                {
                                    drugOrder.CurrentStateDefID = DrugOrder.States.Stopped;
                                    StopDrugOrderDetails detail = new StopDrugOrderDetails();
                                    detail.objectId = drugOrderObjectID;
                                    detail.status = DrugOrderStatusEnum.Stopped;
                                    output.details.Add(detail);
                                }
                                else
                                {
                                    ownDrug.StockActionStatus = StockActionDetailStatusEnum.Cancelled;
                                    drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
                                    /*foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                                    {
                                        if (orderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply)
                                            orderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                                    }*/
                                    StopDrugOrderDetails detail = new StopDrugOrderDetails();
                                    detail.objectId = drugOrderObjectID;
                                    detail.status = DrugOrderStatusEnum.Cancel;
                                    output.details.Add(detail);
                                }
                                if (kscheduleObjectID.Contains(ownDrug.KSchedule.ObjectID) == false)
                                    kscheduleObjectID.Add(ownDrug.KSchedule.ObjectID);
                            }
                            else
                            {
                                drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
                                /*foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                                {
                                    if (orderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply)
                                        orderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                                }*/
                                StopDrugOrderDetails detail = new StopDrugOrderDetails();
                                detail.objectId = drugOrderObjectID;
                                detail.status = DrugOrderStatusEnum.Cancel;
                                output.details.Add(detail);
                            }
                        }
                        else if (drugOrder.CurrentStateDefID == DrugOrder.States.Approve)
                        {
                            IBindingList infectionDrugMaterial = objectContext.QueryObjects("KSCHEDULEINFECTIONDRUG", "DRUGORDEROBJECTID =" + TTConnectionManager.ConnectionManager.GuidToString(drugOrder.ObjectID));
                            if (infectionDrugMaterial.Count > 0)
                            {
                                KScheduleInfectionDrug infectionDrug = (KScheduleInfectionDrug)infectionDrugMaterial[0];
                                if (infectionDrug.KSchedule.CurrentStateDefID == KSchedule.States.RequestPreparation)
                                {
                                    infectionDrug.StockActionStatus = StockActionDetailStatusEnum.Cancelled;
                                    drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
                                    /*foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                                    {
                                        if (orderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply)
                                            orderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                                    }*/
                                    StopDrugOrderDetails detail = new StopDrugOrderDetails();
                                    detail.objectId = drugOrderObjectID;
                                    detail.status = DrugOrderStatusEnum.Cancel;
                                    output.details.Add(detail);
                                }
                                if (kscheduleObjectID.Contains(infectionDrug.KSchedule.ObjectID) == false)
                                    kscheduleObjectID.Add(infectionDrug.KSchedule.ObjectID);
                            }
                            else
                            {
                                drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
                                foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                                {
                                    if (orderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply)
                                        orderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                                }
                                StopDrugOrderDetails detail = new StopDrugOrderDetails();
                                detail.objectId = drugOrderObjectID;
                                detail.status = DrugOrderStatusEnum.Cancel;
                                output.details.Add(detail);
                            }
                        }
                        else
                        {
                            IBindingList drugMaterial = objectContext.QueryObjects("KSCHEDULEMATERIAL", "DRUGORDEROBJECTID =" + TTConnectionManager.ConnectionManager.GuidToString(drugOrder.ObjectID));
                            if (drugMaterial.Count > 0)
                            {
                                KScheduleMaterial drug = (KScheduleMaterial)drugMaterial[0];
                                if (drug.StockAction.CurrentStateDefID == KSchedule.States.RequestFulfilled)
                                {
                                    drugOrder.CurrentStateDefID = DrugOrder.States.Stopped;
                                    StopDrugOrderDetails detail = new StopDrugOrderDetails();
                                    detail.objectId = drugOrderObjectID;
                                    detail.status = DrugOrderStatusEnum.Stopped;
                                    output.details.Add(detail);
                                }
                                else
                                {
                                    drug.Status = StockActionDetailStatusEnum.Cancelled;
                                    drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
                                    /*foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                                    {
                                        if (orderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply)
                                            orderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                                    }*/
                                    StopDrugOrderDetails detail = new StopDrugOrderDetails();
                                    detail.objectId = drugOrderObjectID;
                                    detail.status = DrugOrderStatusEnum.Cancel;
                                    output.details.Add(detail);
                                }
                                if (kscheduleObjectID.Contains(drug.StockAction.ObjectID) == false)
                                    kscheduleObjectID.Add(drug.StockAction.ObjectID);
                            }
                            else
                            {
                                drugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
                                foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                                {
                                    if (orderDetail.CurrentStateDefID != DrugOrderDetail.States.Apply)
                                        orderDetail.CurrentStateDefID = DrugOrderDetail.States.Cancel;
                                }
                                StopDrugOrderDetails detail = new StopDrugOrderDetails();
                                detail.objectId = drugOrderObjectID;
                                detail.status = DrugOrderStatusEnum.Cancel;
                                output.details.Add(detail);
                            }
                        }
                    }
                    if (infectionCommiteObjectID.Count > 0)
                    {
                        foreach (Guid obj in infectionCommiteObjectID)
                        {
                            InfectionCommittee infectionCommittee = (InfectionCommittee)objectContext.GetObject(obj, typeof(InfectionCommittee));
                            infectionCommittee.CurrentStateDefID = InfectionCommittee.States.Cancel;
                        }
                    }
                    objectContext.Save();
                    CheckKschedule(kscheduleObjectID);
                    output.Result = true;
                    output.ResultMessage = "Direktifler durduruldu & iptal edildi.";
                }
                catch (Exception ex)
                {
                    output.ResultMessage = ex.ToString();
                }

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public void CheckKschedule(List<Guid> kscheduleList)
        {
            foreach (Guid id in kscheduleList)
            {
                TTObjectContext readonlyContext = new TTObjectContext(true);
                KSchedule kSchedule = readonlyContext.GetObject<KSchedule>(id);
                if (kSchedule.CurrentStateDefID == KSchedule.States.RequestPreparation)
                {
                    int matCount = kSchedule.StockActionDetails.Where(x => x.Status == StockActionDetailStatusEnum.New).Count();
                    int infectCount = kSchedule.KScheduleInfectionDrugs.Count();
                    int ownCount = kSchedule.KSchedulePatienOwnDrugs.Where(x => x.StockActionStatus == StockActionDetailStatusEnum.New).Count();
                    if (matCount == 0 && infectCount == 0 && ownCount == 0)
                    {
                        TTObjectContext objectContext = new TTObjectContext(false);
                        KSchedule updateK = objectContext.GetObject<KSchedule>(id);
                        updateK.CurrentStateDefID = KSchedule.States.Cancelled;

                        objectContext.Save();
                        objectContext.Dispose();
                    }
                }
            }
        }

        [HttpPost]
        public StopDrugOrders_Output OutOfTreatmentDrugOrders(StopDrugOrders_Input input)
        {
            StopDrugOrders_Output output = new StopDrugOrders_Output();
            output.details = new List<StopDrugOrderDetails>();
            List<Guid> kscheduleObjectID = new List<Guid>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    foreach (Guid drugOrderObjectID in input.DrugOrderObjectIDList)
                    {
                        DrugOrder drugOrder = objectContext.GetObject<DrugOrder>(drugOrderObjectID);
                        drugOrder.OutOfTreatment = true;
                        StopDrugOrderDetails detail = new StopDrugOrderDetails();
                        detail.objectId = drugOrderObjectID;
                        detail.status = DrugOrderStatusEnum.OutOfTreatment;
                        output.details.Add(detail);
                    }
                    objectContext.Save();
                    output.Result = true;
                    output.ResultMessage = "Direktifler Tedavi Dışı yapıldı.";
                }
                catch (Exception ex)
                {
                    output.ResultMessage = ex.ToString();
                }

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class DrugOrderInfo_Input
        {
            public Guid? DrugOrderObjectID
            {
                get;
                set;
            }
            public Guid? ParentDrugOrderObjectID
            {
                get;
                set;
            }
        }

        public class DrugOrderInfo_Output
        {
            public string DrugName
            {
                get;
                set;
            }
            public List<DrugOrderInfoDetail_Output> DrugOrderInfoDetails
            {
                get;
                set;
            }
        }
        public class DrugOrderInfoDetail_Output
        {
            public Guid ObjectID
            {
                get;
                set;
            }
            public DateTime OrderPlannedDate
            {
                get;
                set;
            }
            public DateTime ActionDate
            {
                get;
                set;
            }
            public string DoctorName
            {
                get;
                set;
            }
            public string Status
            {
                get;
                set;
            }
            public string EHUCancelReason
            {
                get;
                set;
            }
        }

        [HttpPost]
        public DrugOrderInfo_Output GetDrugOrderInfo(DrugOrderInfo_Input input)
        {
            DrugOrderInfo_Output output = new DrugOrderInfo_Output();
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.DrugOrderObjectID != null)
                {
                    DrugOrder order = (DrugOrder)objectContext.GetObject(input.DrugOrderObjectID.Value, typeof(DrugOrder));
                    output.DrugName = order.Material.Name;
                    output.DrugOrderInfoDetails = new List<DrugOrderInfoDetail_Output>();
                    DrugOrderInfoDetail_Output detail_Output = new DrugOrderInfoDetail_Output();
                    detail_Output.ObjectID = order.ObjectID;
                    detail_Output.ActionDate = order.ActionDate.Value;
                    detail_Output.OrderPlannedDate = order.PlannedStartTime.Value;
                    if (order.ProcedureDoctor != null)
                        detail_Output.DoctorName = order.ProcedureDoctor.Name;
                    else
                        detail_Output.DoctorName = order.RequestedByUser.Name;
                    detail_Output.Status = order.CurrentStateDef.DisplayText;
                    detail_Output.EHUCancelReason = order.EHUCancelReason;
                    output.DrugOrderInfoDetails.Add(detail_Output);
                }

                if (input.ParentDrugOrderObjectID != null)
                {
                    IBindingList drugOrders = objectContext.QueryObjects("DRUGORDER", "PARENTDRUGORDER=" + TTConnectionManager.ConnectionManager.GuidToString(input.ParentDrugOrderObjectID.Value), "PLANNEDSTARTTIME");

                    DrugOrder parentOrder = (DrugOrder)objectContext.GetObject(input.ParentDrugOrderObjectID.Value, typeof(DrugOrder));
                    output.DrugName = parentOrder.Material.Name;
                    output.DrugOrderInfoDetails = new List<DrugOrderInfoDetail_Output>();
                    DrugOrderInfoDetail_Output parentDetail = new DrugOrderInfoDetail_Output();
                    parentDetail.ObjectID = parentOrder.ObjectID;
                    parentDetail.ActionDate = parentOrder.ActionDate.Value;
                    parentDetail.OrderPlannedDate = parentOrder.PlannedStartTime.Value;
                    if (parentOrder.ProcedureDoctor != null)
                        parentDetail.DoctorName = parentOrder.ProcedureDoctor.Name;
                    else
                        parentDetail.DoctorName = parentOrder.RequestedByUser.Name;
                    parentDetail.Status = parentOrder.CurrentStateDef.DisplayText;
                    parentDetail.EHUCancelReason = parentOrder.EHUCancelReason;
                    output.DrugOrderInfoDetails.Add(parentDetail);
                    foreach (DrugOrder order in drugOrders)
                    {
                        DrugOrderInfoDetail_Output detail_Output = new DrugOrderInfoDetail_Output();
                        detail_Output.ObjectID = order.ObjectID;
                        detail_Output.ActionDate = order.ActionDate.Value;
                        detail_Output.OrderPlannedDate = order.PlannedStartTime.Value;
                        if (order.ProcedureDoctor != null)
                            detail_Output.DoctorName = order.ProcedureDoctor.Name;
                        else
                            detail_Output.DoctorName = order.RequestedByUser.Name;
                        detail_Output.Status = order.CurrentStateDef.DisplayText;
                        detail_Output.EHUCancelReason = order.EHUCancelReason;
                        output.DrugOrderInfoDetails.Add(detail_Output);
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }


        public class GetEquivalentDrug_Input
        {
            public DrugDefinition drug
            {
                get;
                set;
            }

            public int amount
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DrugInfo> GetEquivalentDrug(GetEquivalentDrug_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugInfo> equivalentDrugs = new List<DrugInfo>();
                DrugDefinition drugDef = (DrugDefinition)objectContext.GetObject(input.drug.ObjectID, typeof(DrugDefinition));
                IList allEquivalentDrugs = drugDef.GetEquivalentDrugs();
                foreach (DrugDefinition drug in allEquivalentDrugs)
                {
                    Store pharmacy = Store.GetPharmacyStore(objectContext);
                    if (pharmacy != null)
                    {
                        if (drug.Stocks.Select("STORE='" + pharmacy.ObjectID.ToString() + "'").Count > 0)
                        {
                            int stockInheld = (int)drug.Stocks.Select("STORE='" + pharmacy.ObjectID.ToString() + "'")[0].Inheld;
                            if (stockInheld >= input.amount)
                            {
                                DrugInfo drugInfo = new DrugInfo();
                                drugInfo.drugObjectId = drug.ObjectID.ToString();
                                drugInfo.name = drug.Name;
                                drugInfo.ActiveIngeridents = new List<DrugIngredient>();
                                if (drug.RouteOfAdmin != null)
                                    drugInfo.drugUsageTypeEnum = drug.RouteOfAdmin.DrugUsageType;
                                drugInfo.DrugSpecifications = new List<DrugSpecificationEnum>();
                                if (drug.MinPatientAge.HasValue)
                                    drugInfo.minAge = drug.MinPatientAge.Value;
                                if (drug.MaxPatientAge.HasValue)
                                    drugInfo.maxAge = drug.MaxPatientAge.Value;
                                drugInfo.isPatientOwnDrug = false;
                                drugInfo.drugType = DrugOrder.GetDrugUsedType(drug);

                                if (string.IsNullOrEmpty(drug.Description))
                                {
                                    if (drug.MaterialDescriptionShowType != null)
                                    {
                                        if (drug.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.Order || drug.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.All)
                                            drugInfo.DrugDescription = drug.Description;
                                        else
                                            drugInfo.DrugDescription = string.Empty;
                                    }
                                    else
                                        drugInfo.DrugDescription = drug.Description;
                                }
                                else
                                    drugInfo.DrugDescription = string.Empty;

                                if (drug.DivisibleDrug.HasValue)
                                    drugInfo.isDivisibleDrug = drug.DivisibleDrug.Value;
                                else
                                    drugInfo.isDivisibleDrug = false;

                                if (drug.InpatientReportType != null)
                                    drugInfo.DrugReportType = drug.InpatientReportType.Value;
                                else
                                    drugInfo.DrugReportType = DrugReportType.Odenir;

                                if (drug.InfectionApproval != null)
                                    drugInfo.InfectionApproval = drug.InfectionApproval.Value;
                                else
                                    drugInfo.InfectionApproval = false;

                                foreach (DrugSpecifications drugSpec in drug.DrugSpecifications)
                                {
                                    if (drugSpec.DrugSpecification.HasValue)
                                        drugInfo.DrugSpecifications.Add(drugSpec.DrugSpecification.Value);
                                }

                                foreach (DrugActiveIngredient ing in drug.DrugActiveIngredients)
                                {
                                    DrugIngredient drugIng = new DrugIngredient();
                                    drugIng.Name = ing.ActiveIngredient.Name;
                                    drugIng.Objectid = ing.ObjectID;
                                    drugInfo.ActiveIngeridents.Add(drugIng);
                                }
                                equivalentDrugs.Add(drugInfo);
                            }
                        }
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return equivalentDrugs;
            }
        }
        public class GetPlannedStartTime_Input
        {
            public FrequencyEnum frequency
            {
                get;
                set;
            }
            public DateTime startDate { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Direktif_Giris_Yeni, TTRoleNames.Ilac_Direktif_Giris_Tamam)]
        public DateTime GetPlannedStartTime(GetPlannedStartTime_Input input)
        {
            int t1 = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("DRUGORDERSCHEDULET1", "8"));
            using (var objectContext = new TTObjectContext(false))
            {
                DateTime plannedStartTime;
                if (input.frequency != FrequencyEnum.Q24H)
                {
                    plannedStartTime = new DateTime(input.startDate.Year, input.startDate.Month, input.startDate.Day, t1, 0, 0); //new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, t1, 0, 0);
                    double detailCount = DrugOrder.GetDetailCount(input.frequency);
                    double detailTimePeriod = DrugOrder.GetDetailTimePeriod(input.frequency);
                    List<DateTime> plannedDateList = new List<DateTime>();
                    plannedDateList.Add(plannedStartTime);
                    for (int i = 0; i < detailCount; i++)
                    {
                        plannedStartTime = plannedStartTime.AddHours(detailTimePeriod);
                        plannedDateList.Add(plannedStartTime);
                    }
                    foreach (DateTime date in plannedDateList)
                    {
                        if (DateTime.Now < date)
                        {
                            plannedStartTime = date;
                            break;
                        }
                    }
                }
                else
                {
                    //fixed the hour bug, by Murat
                    plannedStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
                    plannedStartTime = plannedStartTime.AddHours(1);
                }

                objectContext.FullPartialllyLoadedObjects();
                return plannedStartTime;
            }
        }

        public class GetEreceteList_Input
        {
            public Episode episode
            {
                get;
                set;
            }
        }

        public class GetEGetPresciptionByErecete_Input
        {
            public string ereceteno { get; set; }
            public string patientObjId { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Direktif_Giris_Yeni, TTRoleNames.Ilac_Direktif_Giris_Tamam)]
        public void GetEGetPresciptionByErecete(GetEGetPresciptionByErecete_Input input)
        {
            BindingList<Prescription.GetPresciptionByEreceteNoAndPatient_Class> presciptions = Prescription.GetPresciptionByEreceteNoAndPatient(input.ereceteno, input.patientObjId);
            foreach (Prescription.GetPresciptionByEreceteNoAndPatient_Class pres in presciptions)
            {
                TTObjectContext context = new TTObjectContext(false);
                Prescription ps = (Prescription)context.GetObject((Guid)pres.ObjectID, typeof(Prescription));
                if (ps is InpatientPrescription)
                {
                    ps.CurrentStateDefID = InpatientPrescription.States.Cancelled;
                }
                if (ps is OutPatientPrescription)
                {
                    ps.CurrentStateDefID = OutPatientPrescription.States.Cancelled;
                }
                context.Save();
                context.Dispose();
            }

        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Direktif_Giris_Yeni, TTRoleNames.Ilac_Direktif_Giris_Tamam)]
        public List<ERecete> GetEreceteList(GetEreceteList_Input input)
        {
            List<ERecete> output = new List<ERecete>();
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            using (var objectContext = new TTObjectContext(false))
            {
                Episode patientEpisode = (Episode)objectContext.AddObject(input.episode);
                EReceteIslemleri.ereceteListeSorguIstekDVO request = new EReceteIslemleri.ereceteListeSorguIstekDVO();
                request.doktorTcKimlikNo = (long)Convert.ToDouble(currentUser.UniqueNo);
                request.hastaTcKimlikNo = (long)Convert.ToDouble(patientEpisode.Patient.UniqueRefNo);
                request.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                EReceteIslemleri.ereceteListeSorguCevapDVO response = EReceteIslemleri.WebMethods.ereceteListeSorgulaSync(Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, request);

                if (response != null)
                {
                    if (response.ereceteListesi != null)
                    {
                        foreach (EReceteIslemleri.ereceteDVO item in response.ereceteListesi)
                        {
                            ERecete recete = new ERecete();
                            recete.TakipNo = item.takipNo.ToString();
                            recete.ReceteNo = item.ereceteNo;
                            recete.ReceteTarihi = item.receteTarihi;
                            recete.ProtokolNo = item.protokolNo;
                            recete.Doktor = item.doktorAdi + " " + item.doktorSoyadi;
                            recete.SeriNo = item.seriNo;

                            BindingList<SpecialityDefinition> spe = SpecialityDefinition.GetSpecialityByCode(objectContext, item.doktorBransKodu.ToString());
                            if (spe.Count > 0)
                            {
                                recete.Brans = spe[0].Name;
                            }

                            List<EReceteDetay> detays = new List<EReceteDetay>();
                            EReceteIslemleri.ereceteSorguIstekDVO requestDetay = new EReceteIslemleri.ereceteSorguIstekDVO();
                            requestDetay.doktorTcKimlikNo = (long)Convert.ToDouble(currentUser.UniqueNo);
                            requestDetay.ereceteNo = item.ereceteNo;
                            requestDetay.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                            EReceteIslemleri.ereceteSorguCevapDVO responseDetay = EReceteIslemleri.WebMethods.ereceteSorgulaSync(Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, requestDetay);
                            if (responseDetay != null)
                            {

                                foreach (EReceteIslemleri.ereceteIlacDVO ilac in responseDetay.ereceteDVO.ereceteIlacListesi)
                                {
                                    EReceteDetay detay = new EReceteDetay();
                                    detay.Barkod = ilac.barkod.ToString();
                                    detay.Name = ilac.ilacAdi;
                                    detay.Frequency = ilac.kullanimDoz1.ToString();
                                    detay.DoseAmount = ilac.kullanimDoz2.ToString();
                                    detay.Day = ilac.kullanimPeriyot.ToString();
                                    if (ilac.kullanimPeriyotBirimi == 3)
                                        detay.PeryodUnit = TTUtils.CultureService.GetText("M14998", "Gün");
                                    else if (ilac.kullanimPeriyotBirimi == 4)
                                        detay.PeryodUnit = TTUtils.CultureService.GetText("M25762", "Hafta");
                                    else if (ilac.kullanimPeriyotBirimi == 5)
                                        detay.PeryodUnit = TTUtils.CultureService.GetText("M25201", "Ay");
                                    else if (ilac.kullanimPeriyotBirimi == 6)
                                        detay.PeryodUnit = TTUtils.CultureService.GetText("M24661", "Yıl");
                                    else
                                        detay.PeryodUnit = ilac.kullanimPeriyotBirimi.ToString();
                                    detay.Amount = ilac.adet.ToString();
                                    detays.Add(detay);
                                }
                            }
                            recete.EReceteDetays = detays;
                            output.Add(recete);
                        }
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class IsSGK_Input
        {
            public System.Guid SubEpisodeID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsSGK(IsSGK_Input input)
        {
            bool output = false;
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisode sep = (SubEpisode)objectContext.GetObject(input.SubEpisodeID, typeof(SubEpisode));
                if (sep.SGKSEP != null)
                {
                    if (string.IsNullOrEmpty(sep.SGKSEP.MedulaTakipNo) == false)
                        output = true;
                    else
                        output = false;
                }
                else
                    output = false;
                return output;
            }
        }

        public class GetEreceteMessage_Input
        {
            public System.Guid id
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetEreceteMessage(GetEreceteMessage_Input input)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                DrugOrderIntroduction doi = (DrugOrderIntroduction)objectContext.GetObject(input.id, typeof(DrugOrderIntroduction));
                foreach (OutpatientPresDetail detail in doi.OutpatientPresDetails)
                {
                    if (detail.OutPatientPrescription.EReceteNo != null)
                    {
                        if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.NormalPrescription)
                            output = output + "Normal Reçete E Reçete No: " + detail.OutPatientPrescription.EReceteNo;
                        if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.GreenPrescription)
                            output = output + "Yeşil Reçete E Reçete No: " + detail.OutPatientPrescription.EReceteNo;
                        if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.OrangePrescription)
                            output = output + "Turuncu Reçete E Reçete No: " + detail.OutPatientPrescription.EReceteNo;
                        if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.PurplePrescription)
                            output = output + "Mor Reçete E Reçete No: " + detail.OutPatientPrescription.EReceteNo;
                        if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.RedPrescription)
                            output = output + "Kırmızı Reçete E Reçete No: " + detail.OutPatientPrescription.EReceteNo;
                    }
                }

                foreach (InpatientPresDetail detail in doi.InpatientPresDetails)
                {
                    if (detail.InpatientPrescription.EReceteNo != null)
                    {
                        if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.NormalPrescription)
                            output = output + "Normal Reçete E Reçete No: " + detail.InpatientPrescription.EReceteNo;
                        if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.GreenPrescription)
                            output = output + "Yeşil Reçete E Reçete No: " + detail.InpatientPrescription.EReceteNo;
                        if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.OrangePrescription)
                            output = output + "Turuncu Reçete E Reçete No: " + detail.InpatientPrescription.EReceteNo;
                        if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.PurplePrescription)
                            output = output + "Mor Reçete E Reçete No: " + detail.InpatientPrescription.EReceteNo;
                        if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.RedPrescription)
                            output = output + "Kırmızı Reçete E Reçete No: " + detail.InpatientPrescription.EReceteNo;
                    }
                }
                return output;
            }
        }

        public class ERecete
        {
            public string ReceteNo
            {
                get;
                set;
            }
            public string TakipNo
            {
                get;
                set;
            }

            public string ReceteTarihi
            {
                get;
                set;
            }

            public string ProtokolNo
            {
                get;
                set;
            }
            public string Doktor
            {
                get;
                set;
            }
            public string Brans
            {
                get;
                set;
            }
            public string SeriNo
            {
                get;
                set;
            }
            public List<EReceteDetay> EReceteDetays
            {
                get;
                set;
            }
        }

        public class EReceteDetay
        {
            public string Barkod
            {
                get;
                set;
            }
            public string Name
            {
                get;
                set;
            }

            public string Frequency
            {
                get;
                set;
            }

            public string DoseAmount
            {
                get;
                set;
            }
            public string Day
            {
                get;
                set;
            }
            public string PeryodUnit
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

        /* Renkli Reçete JSON kullanımı ile ilgili yöntem */

        public class RootObject
        {
            public string kullaniciKodu { get; set; }
            public string parola { get; set; }
            public string doktorTc { get; set; }
            public string doktorMedulaPassword { get; set; }
            public string receteAltTuru { get; set; }
            public string takipNo { get; set; }
            public string hastaTc { get; set; }
            public string hastaGsm { get; set; }
            public string yuPass { get; set; }
            public string protokolNo { get; set; }
            public string provizyonTip { get; set; }
            public string doktorBransKodu { get; set; }
            public string doktorSertifikaKodu { get; set; }
            public string XXXXXXReferansNumarasi { get; set; }
            public List<TaniListesi> taniListesi { get; set; }
            public string tesisKodu { get; set; }

            public string hastaDogumTarihi { get; set; }
            public string hastaAdi { get; set; }
            public string hastaSoyadi { get; set; }
            public string hastaCinsiyeti { get; set; }

            public string hastaSigortaliTuru { get; set; }
            public string sysTakipNo { get; set; }

        }

        public class TaniListesi
        {
            public string taniKodu { get; set; }
        }

        public class ColorPrescriptionApproveObject
        {
            public string kullaniciKodu { get; set; }
            public string parola { get; set; }
            public string tcKimlikNo { get; set; }
            public string kullaniciTipi { get; set; }
            public string tesisKodu { get; set; }
        }

        public class InputForPrescriptionApproval
        {
            public string kullaniciTipi { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.ReceteOnay_Bashekim, TTRoleNames.ReceteOnay_Eczaci, TTRoleNames.ReceteOnay_EHUuzman)]
        public string OpenColorPrescriptionWithJSONForApproval(InputForPrescriptionApproval input)
        {
            switch (input.kullaniciTipi)
            {
                case "1":
                    if (!Common.CurrentUser.HasRole(TTRoleNames.ReceteOnay_Bashekim))
                    {
                        throw new TTException("İşlem yapmak için yetkiniz yoktur!");
                    }
                    break;
                case "2":
                    if (!Common.CurrentUser.HasRole(TTRoleNames.ReceteOnay_EHUuzman))
                    {
                        throw new TTException("İşlem yapmak için yetkiniz yoktur!");
                    }
                    break;
                case "3":
                    if (!Common.CurrentUser.HasRole(TTRoleNames.ReceteOnay_Eczaci))
                    {
                        throw new TTException("İşlem yapmak için yetkiniz yoktur!");
                    }
                    break;
                default:
                    break;
            }

            string renkliReceteURL = TTObjectClasses.SystemParameter.GetParameterValue("RENKLIRECETEURL", "http://xxxxxx.com/");

            string url = renkliReceteURL + "Auth/HospitalExternalApiLogin?";

            string JSONString = string.Empty;
            string EncryptedSONString = string.Empty;

            ColorPrescriptionApproveObject approveObject = new ColorPrescriptionApproveObject();

            approveObject.kullaniciKodu = TTObjectClasses.SystemParameter.GetParameterValue("RENKLIRECETEKULLANICIADI", "10000000000");
            approveObject.parola = TTObjectClasses.SystemParameter.GetParameterValue("RENKLIRECETESIFRE", "Q3BhMzNfVUQ=");
            approveObject.tcKimlikNo = Common.CurrentUser.UniqueRefNo.ToString();
            approveObject.kullaniciTipi = input.kullaniciTipi;
            approveObject.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();

            JSONString = JSONHelper.ToJSON(approveObject); //JsonConvert.SerializeObject(rootObjectList);

            var encryptor = new RenkliEncryptor();

            var result = encryptor.Encrypt(JSONString);

            EncryptedSONString = result;

            url = url + EncryptedSONString;

            return url;
        }

        [HttpPost]
        public string OpenColorPrescriptionWithJSON(OpenColorPrescription_Input inputdvo)
        {
            string renkliReceteURL = TTObjectClasses.SystemParameter.GetParameterValue("RENKLIRECETEURL", "http://xxxxxx.com/");
            string url = renkliReceteURL + "Auth/ApiLogin/v2.2/?";

            string JSONString = string.Empty;
            string EncryptedSONString = string.Empty;

            List<TaniListesi> taniListesi = PrepareDiagnosisItemForPrescription(inputdvo.SubEpisodeObjectID);
            RootObject rootObject = PrepareRootObjectForPrescription(inputdvo.SubEpisodeObjectID);
            rootObject.taniListesi = taniListesi;
            List<RootObject> rootObjectList = new List<RootObject>();
            rootObjectList.Add(rootObject);

            //            List<TaniListesi> taniListesi = new List<TaniListesi> { new TaniListesi { taniKodu = "A45.5" }, new TaniListesi { taniKodu = "A44.5" } };
            //            List<RootObject> rootObjectList = new List<RootObject>{new RootObject{kullaniciKodu=" hbys1",parola=" passwrd1",doktorTc="10000000000",doktorMedulaPassword ="123456",receteAltTuru="1",takipNo="0",hastaTc="10000000000",hastaGsm="1234567890",yuPass="414564685465465",
            //protokolNo="122",provizyonTip="0",doktorBransKodu="2400",doktorSertifikaKodu="109",XXXXXXReferansNumarasi="1QAZ2WSX",taniListesi=taniListesi,tesisKodu= "11190001"}};

            JSONString = JSONHelper.ToJSON(rootObjectList); //JsonConvert.SerializeObject(rootObjectList);

            var encryptor = new RenkliEncryptor();

            var result = encryptor.Encrypt(JSONString);

            EncryptedSONString = result;

            url = url + EncryptedSONString;

            return url;
        }


        private List<TaniListesi> PrepareDiagnosisItemForPrescription(Guid subEpisodeID)
        {
            List<TaniListesi> taniListesi = new List<TaniListesi>();
            using (var context = new TTObjectContext(true))
            {
                SubEpisode subEpisode = (SubEpisode)context.GetObject(subEpisodeID, typeof(SubEpisode));

                if (subEpisode.Diagnosis.Count == 0)
                    throw new TTException("Hasta üzerinde kayıtlı en az bir tane tanı girişi yapılmış olmalıdır.Lütfen hasta tanılarını kontrol ediniz!");

                foreach (var diagnosisItem in subEpisode.Diagnosis)
                {
                    TaniListesi taniListeItem = new TaniListesi();
                    taniListeItem.taniKodu = diagnosisItem.DiagnoseCode;
                    taniListesi.Add(taniListeItem);
                }
            }

            return taniListesi;
        }

        private RootObject PrepareRootObjectForPrescription(Guid subEpisodeID)
        {
            RootObject rootObject = new RootObject();
            ResUser doctor = ((ResUser)Common.CurrentUser.UserObject);
            using (var context = new TTObjectContext(true))
            {
                SubEpisode subEpisode = (SubEpisode)context.GetObject(subEpisodeID, typeof(SubEpisode));
                foreach (ResourceSpecialityGrid spec in doctor.ResourceSpecialities)
                {
                    if (spec.MainSpeciality != null)
                    {
                        if (spec.MainSpeciality == true)
                        {
                            if (spec.Speciality != null)
                            {
                                if (!String.IsNullOrEmpty(spec.Speciality.Code))
                                    rootObject.doktorBransKodu = spec.Speciality.Code;
                            }
                        }
                    }
                }
                rootObject.doktorMedulaPassword = doctor.ErecetePassword;
                rootObject.doktorSertifikaKodu = "0";
                rootObject.doktorTc = Common.CurrentUser.UniqueRefNo.ToString();
                if (subEpisode.PatientAdmission.PA_Address != null)
                {
                    if (!String.IsNullOrEmpty(subEpisode.PatientAdmission.PA_Address.MobilePhone))
                        rootObject.hastaGsm = subEpisode.PatientAdmission.PA_Address.MobilePhone;
                }
                rootObject.XXXXXXReferansNumarasi = string.Empty;//TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString(); ///Bunun için sistem parametresi oluşturulacak.Cafer aracılığı ile danışılacak.
                if (subEpisode.Episode.Patient.UniqueRefNo != null)
                {
                    rootObject.hastaTc = subEpisode.Episode.Patient.UniqueRefNo.ToString();
                }
                if (subEpisode.Episode.Patient.YUPASSNO != null)
                {
                    rootObject.yuPass = subEpisode.Episode.Patient.YUPASSNO.ToString();
                }
                rootObject.kullaniciKodu = TTObjectClasses.SystemParameter.GetParameterValue("RENKLIRECETEKULLANICIADI", "10000000000");
                rootObject.parola = TTObjectClasses.SystemParameter.GetParameterValue("RENKLIRECETESIFRE", "Q3BhMzNfVUQ=");
                rootObject.protokolNo = subEpisode.ProtocolNo;

                if (subEpisode.SGKSEP != null)
                {
                    if (subEpisode.SGKSEP.MedulaProvizyonTipi != null)
                    {
                        switch (subEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu)
                        {
                            case "N":
                                rootObject.provizyonTip = ((int)ProvisionTypeEnum.NormalProvision).ToString();
                                break;
                            case "I":
                                rootObject.provizyonTip = ((int)ProvisionTypeEnum.IndustrialAccidentProvision).ToString();
                                break;
                            case "A":
                                rootObject.provizyonTip = ((int)ProvisionTypeEnum.NormalProvision).ToString();
                                break;
                            case "T":
                                rootObject.provizyonTip = ((int)ProvisionTypeEnum.TrafficProvision).ToString();
                                break;
                            case "V":
                                rootObject.provizyonTip = ((int)ProvisionTypeEnum.CriminalCaseProvision).ToString();
                                break;
                            case "M":
                                rootObject.provizyonTip = ((int)ProvisionTypeEnum.OccupationalDiseaseProvision).ToString();
                                break;
                            case "D":
                                rootObject.provizyonTip = ((int)ProvisionTypeEnum.NaturalDisasterProvision).ToString();
                                break;
                            case "L":
                                rootObject.provizyonTip = ((int)ProvisionTypeEnum.MaternityStatusProvision).ToString();
                                break;
                            default:
                                rootObject.provizyonTip = ((int)ProvisionTypeEnum.NormalProvision).ToString();
                                break;
                        }
                    }
                }

                //Reçete Alt Turu için tekrar eklendi.
                if (subEpisode.SGKSEP != null)
                {
                    if (subEpisode.SGKSEP.MedulaTedaviTuru != null)
                    {
                        switch (subEpisode.SGKSEP.MedulaTedaviTuru.tedaviTuruKodu)
                        {
                            case "A":
                                rootObject.receteAltTuru = ((int)PrescriptionSubTypeEnum.OutPatientPrescriptionSubType).ToString();
                                break;
                            case "Y":
                                rootObject.receteAltTuru = ((int)PrescriptionSubTypeEnum.InPatientPrescriptionSubType).ToString();
                                break;
                            case "G":
                                rootObject.receteAltTuru = ((int)PrescriptionSubTypeEnum.DailyPrescriptionSubType).ToString();
                                break;
                        }
                    }

                    if (subEpisode.SGKSEP.MedulaProvizyonTipi != null)
                    {
                        if (subEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu == "A")
                            rootObject.receteAltTuru = ((int)PrescriptionSubTypeEnum.EmergencyPrescriptionSubType).ToString();
                    }
                }
                if (subEpisode.Episode.PatientStatus == PatientStatusEnum.Discharge)
                {
                    rootObject.receteAltTuru = ((int)PrescriptionSubTypeEnum.DischargedPrescriptionSubType).ToString();
                }
                if (subEpisode.Episode.PatientStatus == PatientStatusEnum.Inpatient)
                {
                    if (subEpisode.InpatientAdmission != null && subEpisode.InpatientAdmission.HospitalDischargeDate != null)
                        rootObject.receteAltTuru = ((int)PrescriptionSubTypeEnum.DischargedPrescriptionSubType).ToString();
                }

                if (!String.IsNullOrEmpty(subEpisode.SYSTakipNo))
                {
                    rootObject.sysTakipNo = subEpisode.SYSTakipNo;
                }

                if (subEpisode.SGKSEP != null)
                {
                    if (subEpisode.SGKSEP.MedulaSigortaliTuru != null)
                    {
                        if (subEpisode.SGKSEP.MedulaSigortaliTuru.sigortaliTuruKodu == "1")
                            rootObject.hastaSigortaliTuru = "1";
                        else if (subEpisode.SGKSEP.MedulaSigortaliTuru.sigortaliTuruKodu == "2")
                            rootObject.hastaSigortaliTuru = "2";
                        else
                            rootObject.hastaSigortaliTuru = "3";
                    }
                    else
                        rootObject.hastaSigortaliTuru = "3";
                }

                string takip = string.Empty;
                takip = takip + subEpisode.Episode.Patient.UniqueRefNo.ToString();
                if (subEpisode.Episode.PatientStatus == PatientStatusEnum.Outpatient)
                    takip = takip + ",H";
                else
                {
                    takip = takip + ",E";
                }
                if (subEpisode.SGKSEP != null)
                {
                    if (Common.CurrentDoctor == null)
                    {
                        throw new TTException("Programa giriş yapılan kullanıcının 'Doktor' türünde olması gerekmektedir!");
                    }
                    else
                    {
                        //takip = takip + "," + subEpisode.SGKSEP.MedulaTakipNo + "," + subEpisode.SGKSEP.MedulaBasvuruNo + "," + subEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu + "," + Common.CurrentDoctor.GetSpeciality();
                        if (!String.IsNullOrEmpty(subEpisode.SGKSEP.MedulaTakipNo))
                        {
                            takip = subEpisode.SGKSEP.MedulaTakipNo;
                        }
                        else
                        {
                            //Takip numarası olmayan hastalarda bu sisteme yönlenmeli.
                            takip = string.Empty; //throw new TTException("Medula Takip Numarası bulunmamaktadır!");
                        }
                    }
                }
                //takip = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(takip));
                rootObject.takipNo = takip;
                rootObject.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();

                if (subEpisode.Episode.Patient != null)
                {
                    rootObject.hastaAdi = subEpisode.Episode.Patient.Name;
                    rootObject.hastaSoyadi = subEpisode.Episode.Patient.Surname;
                    rootObject.hastaDogumTarihi = subEpisode.Episode.Patient.BirthDate?.ToString("yyyy-MM-dd");
                    SKRSCinsiyet sex = subEpisode.Episode.Patient.GetSex();
                    if (sex.ADI == "ERKEK")
                        rootObject.hastaCinsiyeti = "E";
                    else if (sex.ADI == "KADIN")
                        rootObject.hastaCinsiyeti = "K";
                }

            }
            return rootObject;
        }

        /* ****************************************************************************************** */

        public class OpenColorPrescription_Input
        {
            public Guid SubEpisodeObjectID { get; set; }
        }

        public class RenkliReceteResult
        {
            public string SonucKodu { get; set; }
            public string SonucAciklama { get; set; }
        }

        [HttpPost]
        public string OpenColorPrescription(OpenColorPrescription_Input inputdvo)
        {
            string renkliReceteURL = TTObjectClasses.SystemParameter.GetParameterValue("RENKLIRECETEURL", "http://xxxxxx.com/");
            string url = string.Empty;
            var receteToken = new
            {
                DoktorTc = Common.CurrentUser.UniqueRefNo.ToString(),
                TesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu(),
                Sifre = TTObjectClasses.SystemParameter.GetParameterValue("RENKLIRECETESIFRE", "Q3BhMzNfVUQ="),
                KullaniciAdi = TTObjectClasses.SystemParameter.GetParameterValue("RENKLIRECETEKULLANICIADI", "10000000000")
            };
            var uri = new Uri("renkliReceteURL");
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            request.Resource = "/api/receteapi/tokenolustur";
            request.Method = Method.POST;
            request.AddJsonBody(receteToken);
            var result = client.Execute(request);
            var sonucKodu = result.Headers.Where(i => i.Name == "SonucKodu").FirstOrDefault();
            if (result.StatusCode.ToString() == "OK")
            {
                var token = result.Headers.Where(i => i.Name == "Token").FirstOrDefault();
                string adress = renkliReceteURL + "Auth/ExternalLogin?accessToken=" + token.Value.ToString() + "&param=";
                using (var context = new TTObjectContext(true))
                {
                    string takip = string.Empty;
                    SubEpisode subEpisode = (SubEpisode)context.GetObject(inputdvo.SubEpisodeObjectID, typeof(SubEpisode));
                    takip = takip + subEpisode.Episode.Patient.UniqueRefNo.ToString();
                    if (subEpisode.Episode.PatientStatus == PatientStatusEnum.Outpatient)
                        takip = takip + ",H";
                    else
                    {
                        adress = renkliReceteURL + "Auth/ChiefDoctorLogin?accessToken=" + token.Value.ToString() + "&param=";
                        takip = takip + ",E";
                    }
                    //takip = takip + "," + subEpisode.SGKSEP.MedulaTakipNo + "," + subEpisode.SGKSEP.MedulaBasvuruNo + ",1,1500";
                    takip = takip + "," + subEpisode.SGKSEP.MedulaTakipNo + "," + subEpisode.SGKSEP.MedulaBasvuruNo + "," + subEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu + "," + Common.CurrentDoctor.GetSpeciality();
                    takip = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(takip));
                    adress = adress + takip;
                    url = adress;
                }
            }
            else
            {
                var renkliReceteResult = JsonConvert.DeserializeObject<RenkliReceteResult>(result.Content);
                throw new Exception($"{renkliReceteResult.SonucKodu} - {renkliReceteResult.SonucAciklama}");
            }
            return url;
        }


        public class repeatDrugOrder_Input
        {
            public List<EReceteDetay> EReceteDetays
            {
                get;
                set;
            }
            public DateTime PlannedStartDate
            {
                get;
                set;
            }
        }

        public class repeatDrugOrder_Output
        {

            public List<DrugOrderIntroductionDet> DrugOrderIntroductionDets
            {
                get;
                set;
            }
        }

        [HttpPost]
        public repeatDrugOrder_Output RepeatDrugOrder(repeatDrugOrder_Input inputValue)
        {
            repeatDrugOrder_Output output = new repeatDrugOrder_Output();
            List<DrugOrderIntroductionDet> drugOrderIntroductionDets = new List<DrugOrderIntroductionDet>();
            if (inputValue.EReceteDetays != null)
            {
                foreach (EReceteDetay detay in inputValue.EReceteDetays)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    DrugOrderIntroductionDet orderIntroductionDet = new DrugOrderIntroductionDet(context);
                    IBindingList matlist = context.QueryObjects(typeof(Material).Name, "BARCODE = '" + detay.Barkod + "'");

                    if (matlist.Count > 0)
                    {
                        Material mat = (Material)matlist[0];
                        orderIntroductionDet.Material = mat;
                        orderIntroductionDet.PlannedStartTime = inputValue.PlannedStartDate;
                        orderIntroductionDet.Day = Convert.ToInt32(detay.Day);
                        orderIntroductionDet.DoseAmount = Convert.ToDouble(detay.DoseAmount);

                        switch (detay.PeryodUnit)
                        {
                            case "Gün":
                                {
                                    orderIntroductionDet.PeriodUnitType = PeriodUnitTypeEnum.DayPeriod;
                                    break;
                                }
                            case "Ay":
                                {
                                    orderIntroductionDet.PeriodUnitType = PeriodUnitTypeEnum.WeekPeriod;
                                    break;
                                }
                            case "Hafta":
                                {
                                    orderIntroductionDet.PeriodUnitType = PeriodUnitTypeEnum.WeekPeriod;
                                    break;
                                }
                            case "Yıl":
                                {
                                    orderIntroductionDet.PeriodUnitType = PeriodUnitTypeEnum.YearPeriod;
                                    break;
                                }
                            default:
                                {
                                    throw new Exception(" Yazdığınız periyot planlamaya uygun değildir.");
                                }
                        }

                        switch (detay.Frequency)
                        {
                            case "1":
                                {
                                    orderIntroductionDet.Frequency = FrequencyEnum.Q24H;
                                    break;
                                }
                            case "2":
                                {
                                    orderIntroductionDet.Frequency = FrequencyEnum.Q12H;
                                    break;
                                }
                            case "3":
                                {
                                    orderIntroductionDet.Frequency = FrequencyEnum.Q8H;
                                    break;
                                }
                            case "4":
                                {
                                    orderIntroductionDet.Frequency = FrequencyEnum.Q6H;
                                    break;
                                }
                            case "6":
                                {
                                    orderIntroductionDet.Frequency = FrequencyEnum.Q4H;
                                    break;
                                }
                            case "8":
                                {
                                    orderIntroductionDet.Frequency = FrequencyEnum.Q3H;
                                    break;
                                }
                            case "12":
                                {
                                    orderIntroductionDet.Frequency = FrequencyEnum.Q2H;
                                    break;
                                }
                            case "24":
                                {
                                    orderIntroductionDet.Frequency = FrequencyEnum.Q1H;
                                    break;
                                }
                            default:
                                {
                                    throw new Exception(" Yazdığınız doz aralığı planlamaya uygun değildir.");

                                }
                        }

                        drugOrderIntroductionDets.Add(orderIntroductionDet);
                    }
                }
            }
            else
            {
                throw new Exception(TTUtils.CultureService.GetText("M25422", "Detayı Olmayan İlaç Tekrarlanamaz."));
            }

            output.DrugOrderIntroductionDets = drugOrderIntroductionDets;
            return output;
        }

        public class GetPatientOwnDrug_Input
        {
            public Episode episode
            {
                get;
                set;
            }
        }
        public class GetPatientOwnDrugDetail_Input
        {
            public Guid subepisode
            {
                get;
                set;
            }
        }

        public class GetPatientOwnDrugDetailDelete_Input
        {
            public Guid trxobjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public List<DrugInfo> GetPatientOwnDrug(GetPatientOwnDrug_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrug_Class> restDrugs = PatientOwnDrugTrx.GetRestPatientOwnDrug(input.episode.ObjectID);
                List<DrugInfo> ownDrugs = new List<DrugInfo>();
                foreach (PatientOwnDrugTrx.GetRestPatientOwnDrug_Class drug in restDrugs)
                {
                    DrugInfo drugInfo = new DrugInfo();
                    DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)drug.Material, typeof(DrugDefinition));
                    drugInfo.drugObjectId = drugDefinition.ObjectID.ToString();
                    drugInfo.name = drugDefinition.Name;
                    double restAmount = Math.Floor(Convert.ToDouble(drug.Restamount));
                    drugInfo.inheldStatus = restAmount.ToString();
                    drugInfo.drugShapeTypeEnum = drugDefinition.DrugShapeType;
                    drugInfo.Color = ColorHelper.GetFontColor(drugDefinition.Color);
                    drugInfo.SgkReturnPay = DrugDefinition.GetSgkReturnPayText(drugDefinition.SgkReturnPay);
                    drugInfo.barcode = drugDefinition.Barcode;
                    drugInfo.drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    drugInfo.isPatientOwnDrug = true;

                    if (string.IsNullOrEmpty(drugDefinition.Description))
                    {
                        if (drugDefinition.MaterialDescriptionShowType != null)
                        {
                            if (drugDefinition.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.Order || drugDefinition.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.All)
                                drugInfo.DrugDescription = drugDefinition.Description;
                            else
                                drugInfo.DrugDescription = string.Empty;
                        }
                        else
                            drugInfo.DrugDescription = drugDefinition.Description;
                    }
                    else
                        drugInfo.DrugDescription = string.Empty;


                    if (drugDefinition.DivisibleDrug.HasValue)
                        drugInfo.isDivisibleDrug = drugDefinition.DivisibleDrug.Value;
                    else
                        drugInfo.isDivisibleDrug = false;


                    if (drugDefinition.RouteOfAdmin != null)
                        drugInfo.drugUsageTypeEnum = drugDefinition.RouteOfAdmin.DrugUsageType;
                    if (drugDefinition.PrescriptionType != null)
                        drugInfo.prescriptionTypeEnum = drugDefinition.PrescriptionType;
                    if (drugDefinition.PatientSafetyFrom.HasValue)
                        drugInfo.PatientSafetyFrom = drugDefinition.PatientSafetyFrom;
                    else
                        drugInfo.PatientSafetyFrom = false;
                    if (drugDefinition.InfectionApproval != null)
                        drugInfo.InfectionApproval = drugDefinition.InfectionApproval.Value;
                    else
                        drugInfo.InfectionApproval = false;
                    drugInfo.ActiveIngeridents = new List<DrugIngredient>();
                    List<Guid> actlist = new List<Guid>();
                    foreach (DrugActiveIngredient drugActiveIngredient in drugDefinition.DrugActiveIngredients)
                    {
                        if (actlist.Contains(drugActiveIngredient.ActiveIngredient.ObjectID) == false)
                        {
                            DrugIngredient drugIngredient = new DrugIngredient();
                            drugIngredient.Objectid = drugActiveIngredient.ActiveIngredient.ObjectID;
                            drugIngredient.Name = drugActiveIngredient.ActiveIngredient.Name;
                            drugInfo.ActiveIngeridents.Add(drugIngredient);
                        }
                    }
                    ownDrugs.Add(drugInfo);
                }
                objectContext.FullPartialllyLoadedObjects();
                return ownDrugs;
            }
        }



        [HttpPost]
        public List<PatientOwnDrugInfo> GetPatientOwnDrugDetail(GetPatientOwnDrugDetail_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<PatientOwnDrugTrx.GetPatientOwnDrugDetailBySubEpisode_Class> restDrugs = PatientOwnDrugTrx.GetPatientOwnDrugDetailBySubEpisode(input.subepisode);
                List<PatientOwnDrugInfo> ownDrugs = new List<PatientOwnDrugInfo>();
                foreach (PatientOwnDrugTrx.GetPatientOwnDrugDetailBySubEpisode_Class drug in restDrugs)
                {
                    PatientOwnDrugInfo ownDrugInfo = new PatientOwnDrugInfo();
                    ownDrugInfo.objectID = drug.ObjectID.ToString();
                    ownDrugInfo.name = drug.Name;
                    ownDrugInfo.expireDate = (DateTime)drug.ExpirationDate;
                    ownDrugInfo.amount = Convert.ToDouble(drug.Amount);
                    ownDrugInfo.restamount = Convert.ToDouble(drug.Restamount);
                    ownDrugInfo.barcode = drug.Barcode;
                    ownDrugs.Add(ownDrugInfo);
                }
                return ownDrugs;
            }
        }


        [HttpPost]
        public string DeletePatientOwnDrugDetail(GetPatientOwnDrugDetailDelete_Input input)
        {
            string returnMessage = "İşlem Başarısız";
            using (var objectContext = new TTObjectContext(false))
            {
                PatientOwnDrugTrx drugTrx = (PatientOwnDrugTrx)objectContext.GetObject(input.trxobjectID, typeof(PatientOwnDrugTrx));
                drugTrx.PatientOwnDrugEntryDetail.Status = OwnDrugStatus.Cancel;
                ((ITTObject)drugTrx).Delete();
                returnMessage = "Hastanın ilacı silindi edildi.";
                objectContext.Save();
            }
            return returnMessage;
        }




        /// <summary>
        public class DiagnosisGridSave_Input
        {

            public Guid drugOrderIntroductionObjectID
            {
                get;
                set;
            }

            public Guid episodeObjectID
            {
                get;
                set;
            }
            public Guid subEpisodeObjectID
            {
                get;
                set;
            }

            public List<DiagnosisGrid> diagnosisGridList
            {
                get;
                set;
            }
            public Guid drug
            {
                get;
                set;
            }
        }

        partial void PreScript_DrugOrderIntroductionNewForm(DrugOrderIntroductionNewFormViewModel viewModel, DrugOrderIntroduction drugOrderIntroduction, TTObjectContext objectContext)
        {
            viewModel.GridEpisodeDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[] { };
        }

        partial void PostScript_DrugOrderIntroductionNewForm(DrugOrderIntroductionNewFormViewModel viewModel, DrugOrderIntroduction drugOrderIntroduction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string result = TTUtils.CultureService.GetText("M300016", "İşlem Başarılı.");
            try
            {
                Episode episode = drugOrderIntroduction.Episode;
                SubEpisode subEpisode = drugOrderIntroduction.SubEpisode;

                foreach (DiagnosisGrid grid in viewModel.GridEpisodeDiagnosisGridList)
                {
                    DiagnosisGrid gridImported = (TTObjectClasses.DiagnosisGrid)objectContext.AddObject(grid);


                    var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(gridImported.ObjectID);
                    if (((ITTObject)diagnosisImported).IsDeleted)
                        continue;
                    diagnosisImported.Episode = episode;

                }

                drugOrderIntroduction.DiagnosisGrid_PostScript(episode.Diagnosis.OfType<DiagnosisGrid>().ToArray());


            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

        }

        [HttpPost]
        public string SaveDiagnosisGrid(DiagnosisGridSave_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                string result = TTUtils.CultureService.GetText("M300016", "İşlem Başarılı.");
                try
                {
                    Episode episode = (Episode)objectContext.GetObject(input.episodeObjectID, "Episode");
                    SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(input.subEpisodeObjectID, "SubEpisode");

                    foreach (DiagnosisGrid grid in input.diagnosisGridList)
                    {
                        DiagnosisGrid gridImported = (TTObjectClasses.DiagnosisGrid)objectContext.AddObject(grid);


                        var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(gridImported.ObjectID);
                        if (((ITTObject)diagnosisImported).IsDeleted)
                            continue;
                        diagnosisImported.Episode = episode;

                    }
                    DrugOrderIntroduction drugOrderIntroduction = (DrugOrderIntroduction)objectContext.GetObject(input.drugOrderIntroductionObjectID, "DrugOrderIntroduction");

                    // drugOrderIntroduction.DiagnosisGrid_PostScript(episode.Diagnosis.OfType<DiagnosisGrid>().ToArray());

                    //                    subEpisode.StarterEpisodeAction.DiagnosisGrid_PostScript(viewModel.GridDiagnosisGridList);


                    // objectContext.Save();
                }
                catch (Exception ex)
                {
                    result = ex.ToString();
                }

                // objectContext.FullPartialllyLoadedObjects();
                return result;
            }
        }
        /// </summary>

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<GetPatientDiagnosisGrid_output> GetPatientDiagnosisGridList(GetDrugOrderIntroductionDet_Input input)
        {
            List<GetPatientDiagnosisGrid_output> list = new List<GetPatientDiagnosisGrid_output>();
            using (var objectContext = new TTObjectContext(false))
            {
                SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(input.id, "SubEpisode");
                if (subEpisode != null)
                {
                    DiagnosisGrid[] GridEpisodeDiagnosisGridList = subEpisode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
                    foreach (DiagnosisGrid grid in GridEpisodeDiagnosisGridList)
                    {
                        GetPatientDiagnosisGrid_output output = new GetPatientDiagnosisGrid_output(grid);
                        list.Add(output);
                    }
                }
            }
            return list;
        }

        public class GetPatientDiagnosisGrid_output
        {
            public GetPatientDiagnosisGrid_output(DiagnosisGrid grid)
            {
                this.diagnosisGrid = grid;
                this.diagnosis = grid.Diagnose;
                this.responsibleDoctor = grid.ResponsibleDoctor;

            }
            public DiagnosisGrid diagnosisGrid
            {
                get;
                set;
            }
            public DiagnosisDefinition diagnosis
            {
                get;
                set;
            }
            public ResUser responsibleDoctor
            {
                get;
                set;
            }
        }
        public class GetDrugOrderIntroductionDet_Input
        {
            public System.Guid id
            {
                get;
                set;
            }
        }



        [HttpPost]
        public DrugOrderIntroductionDet GetDrugOrderIntroductionDet(GetDrugOrderIntroductionDet_Input input)
        {
            DrugOrderIntroductionDet drugOrderIntroductionDet = null;
            using (var objectContext = new TTObjectContext(false))
            {
                IBindingList dets = objectContext.QueryObjects("DRUGORDERINTRODUCTIONDET", "DRUGORDER=" + TTConnectionManager.ConnectionManager.GuidToString(input.id));
                if (dets.Count > 0)
                    drugOrderIntroductionDet = (DrugOrderIntroductionDet)dets[0];
                objectContext.FullPartialllyLoadedObjects();
                return drugOrderIntroductionDet;
            }
        }

        public class GetPatientOwnDrugEntry_Input
        {
            public Episode episode
            {
                get;
                set;
            }
        }

        public class GetPatientOwnDrugEntry_Output
        {
            public int Id
            {
                get;
                set;
            }
            public DateTime ActionDate
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
            public int SendAmount
            {
                get;
                set;
            }
            public int Amount
            {
                get;
                set;
            }
            public string DisplayText
            {
                get;
                set;
            }
        }
        public class GetPatientNewOwnDrugEntry_Output
        {
            public int Id //islem no
            {
                get;
                set;
            }
            public DateTime ActionDate //Tarih
            {
                get;
                set;
            }

            public string Name //ilaç
            {
                get;
                set;
            }

            public string DisplayText //işlem durumu
            {
                get;
                set;
            }
            public Guid ObjectID
            { //Objectid
                get;
                set;
            }
        }

        [HttpPost]
        public List<GetPatientOwnDrugEntry_Output> GetPatientOwnDrugEntry(GetPatientOwnDrugEntry_Input input)
        {
            List<GetPatientOwnDrugEntry_Output> outputs = new List<GetPatientOwnDrugEntry_Output>();
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<PatientOwnDrugEntry.GetPatientOwnDrugEntry_Class> actionList = PatientOwnDrugEntry.GetPatientOwnDrugEntry(input.episode.ObjectID);
                foreach (PatientOwnDrugEntry.GetPatientOwnDrugEntry_Class action in actionList)
                {
                    if (string.IsNullOrEmpty(action.Name) == false)
                    {
                        GetPatientOwnDrugEntry_Output output = new GetPatientOwnDrugEntry_Output();
                        output.Id = (int)action.ID;
                        output.ActionDate = (DateTime)action.ActionDate;
                        output.Barcode = action.Barcode;
                        output.Name = action.Name;
                        output.SendAmount = (int)action.SendAmount;
                        output.Amount = (int)action.Amount;
                        output.DisplayText = action.DisplayText;
                        outputs.Add(output);
                    }
                }
                return outputs;
            }
        }
        [HttpPost]
        public List<GetPatientNewOwnDrugEntry_Output> GetPatientNewOwnDrugEntry(GetPatientOwnDrugEntry_Input input)
        {
            List<GetPatientNewOwnDrugEntry_Output> outputs = new List<GetPatientNewOwnDrugEntry_Output>();
            using (var objectContext = new TTObjectContext(false))
            {

                BindingList<DrugReturnAction.GetDrugReturnActionByPatient_Class> actionList = DrugReturnAction.GetDrugReturnActionByPatient(input.episode.ObjectID);
                foreach (DrugReturnAction.GetDrugReturnActionByPatient_Class action in actionList)
                {
                    DrugReturnAction nameOfDrug = objectContext.GetObject<DrugReturnAction>(new Guid(action.ObjectID.ToString()));
                    GetPatientNewOwnDrugEntry_Output output = new GetPatientNewOwnDrugEntry_Output();
                    output.Id = (int)action.ID;
                    output.ActionDate = (DateTime)action.ActionDate;
                    output.Name = nameOfDrug.ToString().Substring(0, 18);
                    output.ObjectID = (Guid)action.ObjectID;
                    output.DisplayText = action.DisplayText;
                    outputs.Add(output);
                }
                return outputs;
            }
        }

        public class CheckLabProcedure_Input
        {
            public Guid drug
            {
                get;
                set;
            }
            public Episode episode
            {
                get;
                set;
            }
        }

        public class ControlOfActiveIngredientMaterialModel
        {
            public double? Amount { get; set; }
            public Guid ObjectID { get; set; }
            public int Day { get; set; }
        }

        public class ControlOfActiveIngredient_Input
        {
            //public List<KScheduleMaterial> KScheduleMaterials { get; set; }

            //public Guid drug
            //{
            //    get;
            //    set;
            //}
            public Episode episode
            {
                get;
                set;
            }
            //newAddedMaterialObjectIDList Eski DrugOrder için duruyor.
            public List<Guid> newAddedMaterialObjectIDList { get; set; }
            //Eklenen malzemenin ObjectID si ve Amount'u
            public List<ControlOfActiveIngredientMaterialModel> materialModelList { get; set; }

            public DateTime PlannedStartTime { get; set; }
            public DateTime PlannedEndTime { get; set; }
        }

        public class ControlOfActiveIngredient_Output
        {
            public string drug
            {
                get;
                set;
            }
            public string activeIngredient
            {
                get;
                set;
            }
            public Guid? ObjectID { get; set; }
            public Guid ActiveIngredientObjectID { get; set; }
            public bool IsRequestedInDay { get; set; }
        }

        public class CheckLabProcedure_Output
        {
            public string interactionLabProcedure
            {
                get;
                set;
            }
            public string interactionMessage
            {
                get;
                set;
            }
        }

        public class DrugSpecificationControlInputDVO
        {
            public List<Guid> drugObjectIDs { get; set; }
            public Guid? patientObjectID { get; set; }
        }

        [HttpPost]
        public List<CheckLabProcedure_Output> CheckLabProcedure(CheckLabProcedure_Input input)
        {
            List<CheckLabProcedure_Output> outputs = new List<CheckLabProcedure_Output>();
            using (var objectContext = new TTObjectContext(false))
            {
                DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject(input.drug, typeof(DrugDefinition));
                Episode episode = (Episode)objectContext.GetObject(input.episode.ObjectID, typeof(Episode));
                DateTime startDate = DateTime.Now.AddMonths(-1);
                DateTime endDate = DateTime.Now;
                foreach (DrugLabProcInteraction interaction in drugDefinition.DrugLabProcInteractions)
                {
                    BindingList<LaboratoryProcedure.GetLabResultByEpisodeByTestByDate_Class> labResults = LaboratoryProcedure.GetLabResultByEpisodeByTestByDate(startDate, endDate, interaction.LaboratoryTestDefinition.ObjectID.ToString(), episode.ObjectID.ToString());
                    if (labResults.Count > 0)
                    {
                        double testResult = Convert.ToDouble(labResults[0].Result);
                        if (testResult < interaction.MinValue || testResult > interaction.MaxValue)
                        {
                            CheckLabProcedure_Output output = new CheckLabProcedure_Output();
                            output.interactionLabProcedure = interaction.LaboratoryTestDefinition.Name + " Sonucu: " + testResult.ToString();
                            output.interactionMessage = interaction.Message;
                            outputs.Add(output);
                        }
                    }
                }
                return outputs;
            }
        }

        private bool IsItInTheTimeInterval(DateTime? orderPlannedDateTime)
        {
            DateTime StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 00:00:00");
            DateTime EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");

            if (EndDate > orderPlannedDateTime && StartDate < orderPlannedDateTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Doktor İstek yaptığında çağırılan özellikli ilaç uyarısı veren metod
        [HttpGet]
        public string ControlOfDrugSpecificationNewDrugIntroduction(Guid drugObjectID, Guid? patientObjectID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                string message = string.Empty;
                DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject(drugObjectID, typeof(DrugDefinition));
                List<DrugSpecificationEnum?> drugSpecifications = drugDefinition.DrugSpecifications.Select("").Select(x => x.DrugSpecification).ToList();


                foreach (DrugSpecificationEnum drugSpec in drugSpecifications)
                {
                    switch (drugSpec)
                    {
                        case DrugSpecificationEnum.Psychotrophic:
                            message += Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",";
                            break;
                        case DrugSpecificationEnum.HighRisk:
                            message += Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",";
                            break;
                        case DrugSpecificationEnum.ColdChain:
                            break;
                        case DrugSpecificationEnum.Trombotic:
                            break;
                        case DrugSpecificationEnum.Vaccine:
                            break;
                        case DrugSpecificationEnum.Penicillin:
                            break;
                        case DrugSpecificationEnum.Antibiotics:
                            break;
                        case DrugSpecificationEnum.HumanAlbumin:
                            break;
                        case DrugSpecificationEnum.Epidermolysis:
                            break;
                        case DrugSpecificationEnum.AntiTrombotic:
                            break;
                        case DrugSpecificationEnum.PregnancyContraindicate:
                            if (patientObjectID != null && patientObjectID != Guid.Empty)
                            {
                                Patient patient = objectContext.GetObject<Patient>(patientObjectID.Value);
                                if (patient.Sex.KODU == "2" && patient.Age.Value >= 12 && patient.Age.Value <= 55)
                                    message += Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",";
                            }
                            break;
                        case DrugSpecificationEnum.NarrowTherapeuticInterval:
                            message += Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",";
                            break;
                        case DrugSpecificationEnum.ProtectFromLight:
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(message))
                {
                    message = message.Remove(message.LastIndexOf(','), 1);
                    message += " özelliği/özellikleri bulunan bir ilaç istediniz. Bilginize!";
                }

                return message;
            }
        }

        [HttpPost]
        public string ControlOfDrugSpecificationPharmacy(DrugSpecificationControlInputDVO input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                StringBuilder message = new StringBuilder();
                List<DrugDefinition> drugDefinitions = objectContext.QueryObjects<DrugDefinition>(Common.CreateFilterExpressionOfGuidList("", "OBJECTID", input.drugObjectIDs)).ToList();

                foreach (DrugDefinition drugDefinition in drugDefinitions)
                {
                    List<DrugSpecificationEnum?> drugSpecifications = drugDefinition.DrugSpecifications.Select("").Select(x => x.DrugSpecification).ToList();
                    int drugDefSpecCount = 0;
                    foreach (DrugSpecificationEnum drugSpec in drugSpecifications)
                    {
                        switch (drugSpec)
                        {
                            case DrugSpecificationEnum.Psychotrophic:
                                if (drugDefSpecCount == 0)
                                {
                                    message.AppendLine("<b>İlaç Adı:</b>");
                                    message.AppendLine(drugDefinition.Name);
                                    message.AppendLine("<b>Özellik:</b>");
                                }
                                message.Append(Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",");
                                drugDefSpecCount++;
                                break;
                            case DrugSpecificationEnum.HighRisk:
                                if (drugDefSpecCount == 0)
                                {
                                    message.AppendLine("<b>İlaç Adı:</b>");
                                    message.AppendLine(drugDefinition.Name);
                                    message.AppendLine("<b>Özellik:</b>");
                                }
                                message.Append(Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",");
                                drugDefSpecCount++;
                                break;
                            case DrugSpecificationEnum.ColdChain:
                                if (drugDefSpecCount == 0)
                                {
                                    message.AppendLine("<b>İlaç Adı:</b>");
                                    message.AppendLine(drugDefinition.Name);
                                    message.AppendLine("<b>Özellik:</b>");
                                }
                                message.Append(Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",");
                                drugDefSpecCount++;
                                break;
                            case DrugSpecificationEnum.Trombotic:
                                break;
                            case DrugSpecificationEnum.Vaccine:
                                break;
                            case DrugSpecificationEnum.Penicillin:
                                break;
                            case DrugSpecificationEnum.Antibiotics:
                                break;
                            case DrugSpecificationEnum.HumanAlbumin:
                                break;
                            case DrugSpecificationEnum.Epidermolysis:
                                break;
                            case DrugSpecificationEnum.AntiTrombotic:
                                break;
                            case DrugSpecificationEnum.PregnancyContraindicate:
                                if (input.patientObjectID != null && input.patientObjectID != Guid.Empty)
                                {
                                    Patient patient = objectContext.GetObject<Patient>(input.patientObjectID.Value);
                                    if (patient.Sex.KODU == "2")
                                    {
                                        if (drugDefSpecCount == 0)
                                        {
                                            message.AppendLine("<b>İlaç Adı:</b>");
                                            message.AppendLine(drugDefinition.Name);
                                            message.AppendLine("<b>Özellik:</b>");
                                        }
                                        message.Append(Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ", Gebelikte kullanılması sakıncalıdır!,");
                                        drugDefSpecCount++;
                                    }
                                }
                                break;
                            case DrugSpecificationEnum.NarrowTherapeuticInterval:
                                if (drugDefSpecCount == 0)
                                {
                                    message.AppendLine("<b>İlaç Adı:</b>");
                                    message.AppendLine(drugDefinition.Name);
                                    message.AppendLine("<b>Özellik:</b>");
                                }
                                message.Append(Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",");
                                drugDefSpecCount++;
                                break;
                            case DrugSpecificationEnum.ProtectFromLight:
                                break;
                        }
                        if (drugSpecifications.Count == drugDefSpecCount && message.Length != 0)
                        {
                            if (message[message.Length - 1] == ',')
                                message.Length--;
                            message.Append("</br>");
                        }
                    }
                }

                if (message.Length != 0)
                    message.AppendLine(" </br>özelliği/özellikleri bulunan ilaç(lar) istenmiştir. Bilginize!");

                return message.ToString();
            }
        }

        /// <summary>
        /// Gün içerisinde episode'a ait aktif durumdaki order listesini getirir.
        /// </summary>
        /// <param name="episodeObjectID">Guid Episode ObjectID</param>
        /// <returns></returns>
        public List<DrugOrder> DailyEpisodeDrugOrderList(TTObjectContext objectContext, Guid episodeObjectID)
        {
            DateTime StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 00:00:00");
            DateTime EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");

            return DrugOrder.GetDrugOrderForPatient(objectContext, episodeObjectID.ToString()).Where(x => x.CreationDate > StartDate && x.CreationDate < EndDate && x.CurrentStateDefID != DrugOrder.States.Stopped && x.CurrentStateDefID != DrugOrder.States.Cancelled).ToList();
        }

        [HttpPost]
        public List<ControlOfActiveIngredientForRepeat_Output> ControlOfActiveIngredientForRepeatedDrugs(ControlOfActiveIngredient_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                List<ControlOfActiveIngredientForRepeat_Output> crossDrugList = new List<ControlOfActiveIngredientForRepeat_Output>();

                string drugObjectIDs = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", input.newAddedMaterialObjectIDList);
                //Tekrar edilmek için seçilen ilaçlar
                List<DrugDefinition> selectedDrugDefinitions = objectContext.QueryObjects<DrugDefinition>(drugObjectIDs).ToList();

                //Gün içerisinde episode'a ait order listesi
                List<DrugOrder> drugOrderList = DailyEpisodeDrugOrderList(objectContext, input.episode.ObjectID);
                drugOrderList = drugOrderList.Where(x => !selectedDrugDefinitions.Contains(x.Material)).ToList();

                foreach (DrugOrder drugOrder in drugOrderList)
                {
                    List<ActiveIngredientDefinition> drugOrderMaterialActiveIngredientList = new List<ActiveIngredientDefinition>();
                    drugOrderMaterialActiveIngredientList.AddRange(((DrugDefinition)drugOrder.Material).DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient));
                    foreach (DrugDefinition drugDefinition in selectedDrugDefinitions)
                    {
                        var activeIngredientCross = drugOrderMaterialActiveIngredientList.Where(x => drugDefinition.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient).Contains(x));

                        if (activeIngredientCross.Count() > 0)
                        {
                            ControlOfActiveIngredientForRepeat activeIngredientCrossForRepeat = new ControlOfActiveIngredientForRepeat();
                            activeIngredientCrossForRepeat.ActiveIngridientCrossedDrugName = drugOrder.Material.Name;
                            activeIngredientCrossForRepeat.ActiveIngridientCrossedDrugObjectID = drugOrder.Material.ObjectID;
                            activeIngredientCrossForRepeat.IsRequestedInDay = true;
                            List<ControlOfActiveIngredientForRepeat> crossDrugOutput = new List<ControlOfActiveIngredientForRepeat>();
                            crossDrugOutput.Add(activeIngredientCrossForRepeat);
                            ControlOfActiveIngredientForRepeat_Output output;
                            if (crossDrugList.Count > 0 && crossDrugList.Count(x => x.ComparedDrugDef.ObjectID == drugDefinition.ObjectID) > 0)
                                crossDrugList.FirstOrDefault(x => x.ComparedDrugDef.ObjectID == drugDefinition.ObjectID).CrossedActiveIngridientDrugs.Add(activeIngredientCrossForRepeat);
                            else
                            {
                                output = new ControlOfActiveIngredientForRepeat_Output();
                                output.CrossedActiveIngridientDrugs.Add(activeIngredientCrossForRepeat);
                                output.ComparedDrugDef = drugDefinition;
                                output.CrossActiveIngridientNames = string.Join(",", activeIngredientCross.Select(x => x.Name));
                                crossDrugList.Add(output);
                            }
                        }
                    }
                }

                if (input.newAddedMaterialObjectIDList != null && input.newAddedMaterialObjectIDList.Count >= 1)
                {
                    string filterExpression = string.Empty;
                    filterExpression = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", input.newAddedMaterialObjectIDList);
                    //İlaç ekleme ekranında bulunan grid içerisindeki ilaç listesi /Client side dan gelen)
                    List<DrugDefinition> drugDefinitionGridList = objectContext.QueryObjects<DrugDefinition>(filterExpression).ToList();

                    foreach (DrugDefinition drugDef1 in drugDefinitionGridList)
                    {
                        List<ActiveIngredientDefinition> drugActiveIngredient1 = new List<ActiveIngredientDefinition>();
                        drugActiveIngredient1.AddRange(drugDef1.DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient));

                        foreach (DrugDefinition drugDef2 in drugDefinitionGridList.Where(x => x.ObjectID != drugDef1.ObjectID))
                        {
                            List<ActiveIngredientDefinition> drugActiveIngredient2 = new List<ActiveIngredientDefinition>();
                            drugActiveIngredient2.AddRange(drugDef2.DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient));

                            List<ActiveIngredientDefinition> activeIngredientCross = drugActiveIngredient2.Where(x => drugActiveIngredient1.Contains(x)).ToList();

                            if (activeIngredientCross.Count > 0)
                            {
                                string activeIngredients = string.Empty;
                                if (activeIngredientCross.Count > 1)
                                    activeIngredients = string.Join(",", activeIngredientCross.Select(x => x.Name));
                                else
                                    activeIngredients = activeIngredientCross.Select(x => x.Name).FirstOrDefault();

                                ControlOfActiveIngredientForRepeat activeIngredientCrossForRepeat = new ControlOfActiveIngredientForRepeat();
                                activeIngredientCrossForRepeat.ActiveIngridientCrossedDrugName = drugDef2.Name;
                                activeIngredientCrossForRepeat.ActiveIngridientCrossedDrugObjectID = drugDef2.ObjectID;
                                List<ControlOfActiveIngredientForRepeat> crossDrugOutput = new List<ControlOfActiveIngredientForRepeat>();
                                crossDrugOutput.Add(activeIngredientCrossForRepeat);
                                ControlOfActiveIngredientForRepeat_Output output;

                                if (crossDrugList.Count > 0 && crossDrugList.Count(x => x.ComparedDrugDef.ObjectID == drugDef1.ObjectID) > 0)
                                    crossDrugList.FirstOrDefault(x => x.ComparedDrugDef.ObjectID == drugDef1.ObjectID).CrossedActiveIngridientDrugs.Add(activeIngredientCrossForRepeat);
                                else
                                {
                                    output = new ControlOfActiveIngredientForRepeat_Output();
                                    output.CrossedActiveIngridientDrugs.Add(activeIngredientCrossForRepeat);
                                    output.ComparedDrugDef = drugDef1;
                                    output.CrossActiveIngridientNames = string.Join(",", activeIngredientCross.Select(x => x.Name));
                                    crossDrugList.Add(output);
                                }
                            }
                        }
                    }
                }
                return crossDrugList;
            }
        }

        //Doktor İstek ekranında ilaç eklendiği zaman çağırılan etken madde kontrolü metodu.
        //[HttpPost]
        //public List<ControlOfActiveIngredient_Output> ControlOfActiveIngredient(ControlOfActiveIngredient_Input input)
        //{
        //    using (TTObjectContext objectContext = new TTObjectContext(false))
        //    {
        //        List<ControlOfActiveIngredient_Output> returnActiveIng = new List<ControlOfActiveIngredient_Output>();

        //        #region Grid'e yeni eklenecek olan ilaç ile aynı gün verilen orderlar içerisindeki ilaçları karşılaştırır.
        //        DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)input.drug, typeof(DrugDefinition));
        //        //Yeni eklenecek ilacın etken maddeleri
        //        List<ActiveIngredientDefinition> activeIngredientNewOrderList = new List<ActiveIngredientDefinition>();
        //        foreach (DrugActiveIngredient drugActiveIngr in drugDefinition.DrugActiveIngredients)
        //        {
        //            if (activeIngredientNewOrderList.Contains(drugActiveIngr.ActiveIngredient) == false)
        //                activeIngredientNewOrderList.Add(drugActiveIngr.ActiveIngredient);
        //        }

        //        //drugDefinition.DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient).ToList(); ;

        //        List<DrugOrder> drugOrderList = DailyEpisodeDrugOrderList(objectContext, input.episode.ObjectID);
        //        //    DrugOrder.GetDrugOrderForPatient(objectContext, input.episode.ObjectID.ToString()).ToList();
        //        //DateTime StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 00:00:00");
        //        //DateTime EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");
        //        //drugOrderList = drugOrderList.Where(x => x.CreationDate > StartDate && x.CreationDate < EndDate && x.CurrentStateDefID != DrugOrder.States.Stopped && x.CurrentStateDefID != DrugOrder.States.Cancelled).ToList();
        //        List<Guid> warnedActiveIngredientObjectIDList = new List<Guid>();

        //        //string filterExpression = string.Empty;
        //        //filterExpression = Common.CreateFilterExpressionOfGuidList("", "DRUGORDER", drugOrderList.Select(x => x.ObjectID).ToList());

        //        //List<DrugOrderDetail> details = objectContext.QueryObjects<DrugOrderDetail>(filterExpression).ToList();

        //        //if (input.drugOrderObjectID.HasValue && input.drugOrderObjectID != Guid.Empty)
        //        //    drugOrderList = drugOrderList.Where(x => x.ObjectID != input.drugOrderObjectID).ToList();
        //        foreach (DrugOrder drugOrder in drugOrderList)
        //        {
        //            //if (IsItInTheTimeInterval(drugOrder.PlannedStartTime))
        //            //{
        //            //if (drugOrder.CurrentStateDefID != DrugOrder.States.Stopped && drugOrder.CurrentStateDefID != DrugOrder.States.Cancelled)
        //            //{
        //            List<ActiveIngredientDefinition> activeIngredientList = new List<ActiveIngredientDefinition>();
        //            foreach (DrugActiveIngredient oldIng in ((DrugDefinition)drugOrder.Material).DrugActiveIngredients)
        //            {
        //                if (activeIngredientList.Contains(oldIng.ActiveIngredient) == false)
        //                    activeIngredientList.Add(oldIng.ActiveIngredient);
        //            }


        //            //((DrugDefinition)drugOrder.Material).DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient).ToList();
        //            var activeIngredients = activeIngredientList.Where(x => activeIngredientNewOrderList.Contains(x));
        //            foreach (var item in activeIngredients)
        //            {
        //                ControlOfActiveIngredient_Output output = new ControlOfActiveIngredient_Output();
        //                output.drug = drugOrder.Material.Name;
        //                warnedActiveIngredientObjectIDList.Add(item.ObjectID);
        //                output.activeIngredient = item.Name;
        //                output.ObjectID = item.ObjectID;
        //                output.ActiveIngredientObjectID = item.ObjectID;
        //                returnActiveIng.Add(output);
        //            }

        //            //foreach (DrugActiveIngredient activeIngredient in activeIngredientList)
        //            //{
        //            //    foreach (DrugActiveIngredient tempActive in activeIngredientNewOrderList)
        //            //    {
        //            //        if (activeIngredient.ActiveIngredient == tempActive.ActiveIngredient)
        //            //        {
        //            //            ControlOfActiveIngredient_Output output = new ControlOfActiveIngredient_Output();
        //            //            output.drug = drugOrder.Material.Name;
        //            //            output.activeIngredient = tempActive.ActiveIngredient.Name;
        //            //            returnActiveIng.Add(output);
        //            //        }
        //            //    }
        //            //}
        //            //}
        //            //}
        //        }
        //        #endregion

        //        if (input.newAddedMaterialObjectIDList != null && input.newAddedMaterialObjectIDList.Count >= 1)
        //        {
        //            StringBuilder message = new StringBuilder();
        //            string filterExpression = string.Empty;
        //            filterExpression = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", input.newAddedMaterialObjectIDList);
        //            //İlaç karşılama ekranında bulunan grid içerisindeki ilaç listesi /Client side dan gelen)
        //            List<DrugDefinition> drugDefinitionGridList = objectContext.QueryObjects<DrugDefinition>(filterExpression).ToList();
        //            drugDefinitionGridList.Add(drugDefinition);
        //            for (int i = 0; i < drugDefinitionGridList.Count - 1; i++)
        //            {
        //                for (int j = i + 1; j < drugDefinitionGridList.Count; j++)
        //                {
        //                    List<ActiveIngredientDefinition> drugActiveIngredient1 = new List<ActiveIngredientDefinition>();
        //                    foreach (DrugActiveIngredient drugActiveIngr in drugDefinitionGridList[i].DrugActiveIngredients)
        //                    {
        //                        if (drugActiveIngredient1.Contains(drugActiveIngr.ActiveIngredient) == false)
        //                            drugActiveIngredient1.Add(drugActiveIngr.ActiveIngredient);
        //                    }

        //                    List<ActiveIngredientDefinition> drugActiveIngredient2 = new List<ActiveIngredientDefinition>();
        //                    foreach (DrugActiveIngredient drugActiveIngr in drugDefinitionGridList[j].DrugActiveIngredients)
        //                    {
        //                        if (drugActiveIngredient2.Contains(drugActiveIngr.ActiveIngredient) == false)
        //                            drugActiveIngredient2.Add(drugActiveIngr.ActiveIngredient);
        //                    }
        //                    //drugDefinitionGridList[i].DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient).ToList();
        //                    //drugDefinitionGridList[j].DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient).ToList(); ;
        //                    List<ActiveIngredientDefinition> activeIngredientCross = drugActiveIngredient2.Where(x => drugActiveIngredient1.Contains(x)).ToList();
        //                    List<Guid> activeIngredientCrossObjectIDs = activeIngredientCross.Select(x => x.ObjectID).ToList();
        //                    if (activeIngredientCross.Count > 0 && warnedActiveIngredientObjectIDList.Count(x => activeIngredientCrossObjectIDs.Contains(x)) == 0)
        //                    {
        //                        string activeIngredients = string.Empty;
        //                        if (activeIngredientCross.Count > 1)
        //                            activeIngredients = string.Join(",", activeIngredientCross.Select(x => x.Name));
        //                        else
        //                            activeIngredients = activeIngredientCross.Select(x => x.Name).FirstOrDefault();
        //                        //foreach (ActiveIngredientDefinition drugActiveIngredient in activeIngredientCross)
        //                        //{
        //                        ControlOfActiveIngredient_Output output = new ControlOfActiveIngredient_Output();
        //                        output.drug = drugDefinitionGridList[i].Name;
        //                        output.activeIngredient = activeIngredients;
        //                        warnedActiveIngredientObjectIDList.AddRange(activeIngredientCross.Select(x => x.ObjectID));
        //                        //output.ActiveIngredientObjectID = drugActiveIngredient.ObjectID;
        //                        returnActiveIng.Add(output);
        //                        //}
        //                    }
        //                }
        //            }
        //        }
        //        return returnActiveIng;
        //    }
        //}

        //[HttpPost]
        //public string ControlOfActiveIngredientPharmacy(ControlOfActiveIngredient_Input input)
        //{
        //    using (TTObjectContext objectContext = new TTObjectContext(false))
        //    {
        //        StringBuilder message = new StringBuilder();
        //        string filterExpression = string.Empty;
        //        filterExpression = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", input.newAddedMaterialObjectIDList);
        //        //İlaç karşılama ekranında bulunan grid içerisindeki ilaç listesi /Client side dan gelen)

        //        List<DrugDefinition> drugDefinitionGridList = new List<DrugDefinition>();
        //        if (input.newAddedMaterialObjectIDList.Count == 0)
        //        {

        //        }
        //        else
        //        {
        //            drugDefinitionGridList = objectContext.QueryObjects<DrugDefinition>(filterExpression).ToList();
        //        }

        //        //DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)input.drug, typeof(DrugDefinition));
        //        //BindingList<DrugActiveIngredient> activeIngredientNewOrderList = drugDefinition.DrugActiveIngredients.Select("");
        //        List<ControlOfActiveIngredient_Output> returnActiveIng = new List<ControlOfActiveIngredient_Output>();

        //        List<DrugOrder> drugOrderList = DrugOrder.GetDrugOrderForPatient(objectContext, input.episode.ObjectID.ToString()).ToList();
        //        DateTime StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 00:00:00");
        //        DateTime EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");

        //        List<Guid> guids = input.KScheduleMaterials.Select(x => x.DrugOrderObjectID.Value).ToList();

        //        //Episode a ait gün içerisinde girilmiş karşılanması gereken DrugOrder listesi. (Grid deki ilaçların DrugOrder ları hariç)
        //        drugOrderList = drugOrderList.Where(x => x.CreationDate > StartDate && x.CreationDate < EndDate && x.CurrentStateDefID != DrugOrder.States.Stopped && x.CurrentStateDefID != DrugOrder.States.Cancelled && !guids.Contains(x.ObjectID)).ToList();

        //        if (drugOrderList.Count > 0)
        //        {
        //            foreach (DrugDefinition newDrugDefinition in drugDefinitionGridList)
        //            {
        //                List<ActiveIngredientDefinition> newDrugsactiveIngredientList = new List<ActiveIngredientDefinition>();
        //                foreach (DrugActiveIngredient drugActiveIngr in newDrugDefinition.DrugActiveIngredients)
        //                {
        //                    if (newDrugsactiveIngredientList.Contains(drugActiveIngr.ActiveIngredient) == false)
        //                        newDrugsactiveIngredientList.Add(drugActiveIngr.ActiveIngredient);
        //                }
        //                //newDrugDefinition.DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient).ToList();

        //                foreach (DrugOrder drugOrder in drugOrderList)
        //                {
        //                    if (input.KScheduleMaterials.Count > 0 && drugOrder.ObjectID != input.KScheduleMaterials[0].DrugOrderObjectID)
        //                    {
        //                        List<ActiveIngredientDefinition> activeIngredientListExceptNewDrugs = new List<ActiveIngredientDefinition>();
        //                        foreach (DrugActiveIngredient drugActiveIngr in ((DrugDefinition)drugOrder.Material).DrugActiveIngredients)
        //                        {
        //                            if (activeIngredientListExceptNewDrugs.Contains(drugActiveIngr.ActiveIngredient) == false)
        //                                activeIngredientListExceptNewDrugs.Add(drugActiveIngr.ActiveIngredient);
        //                        }

        //                        //((DrugDefinition)drugOrder.Material).DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient).ToList();
        //                        List<ActiveIngredientDefinition> activeIngredientCross = activeIngredientListExceptNewDrugs.Where(x => newDrugsactiveIngredientList.Contains(x)).ToList();
        //                        if (activeIngredientCross.Count > 0)
        //                        {
        //                            string activeIngredients = string.Empty;
        //                            if (activeIngredientCross.Count > 1)
        //                                activeIngredients = string.Join(",", activeIngredientCross.Select(x => x.Name));
        //                            else
        //                                activeIngredients = activeIngredientCross.Select(x => x.Name).FirstOrDefault();

        //                            //foreach (DrugActiveIngredient drugActiveIngredient in activeIngredientCross)
        //                            //{
        //                            if (newDrugDefinition.ObjectID != drugOrder.Material.ObjectID)
        //                            {
        //                                message.AppendLine("<b></br>Gün İçerisindeki Aynı Etken Maddeli İlaçlar</b></br>");
        //                                message.AppendLine("Karşılanması Gereken İlacın");
        //                                message.AppendLine("İlaç Adı :" + newDrugDefinition.Name + " - Etken Madde(ler) :" + activeIngredients + "</br>");
        //                                message.AppendLine("<b>Gün İçerisinde Yazılan İlacın</b></br>");
        //                                message.AppendLine("İlaç Adı :" + drugOrder.Material.Name + " - Etken Madde(ler) :" + activeIngredients);
        //                            }
        //                            else
        //                            {
        //                                message.AppendLine("<b></br>Gün İçerisindeki Aynı Etken Maddeli İlaçlar</b></br>");
        //                                message.AppendLine("Karşılanması Gereken İlacın");
        //                                message.AppendLine("İlaç Adı :" + newDrugDefinition.Name + " - Etken Madde(ler) :" + activeIngredients + "</br>");
        //                                message.AppendLine("<b>Gün İçerisinde Yazılan İlacın</b></br>");
        //                                message.AppendLine("İlaç Adı :" + drugOrder.Material.Name + " - Etken Madde(ler) :" + activeIngredients);
        //                            }
        //                            //}
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if (drugDefinitionGridList.Count > 1)
        //        {
        //            for (int i = 0; i < drugDefinitionGridList.Count - 1; i++)
        //            {
        //                for (int j = i + 1; j < drugDefinitionGridList.Count; j++)
        //                {
        //                    List<ActiveIngredientDefinition> drugActiveIngredient1 = new List<ActiveIngredientDefinition>();
        //                    foreach (DrugActiveIngredient drugActiveIngr in drugDefinitionGridList[i].DrugActiveIngredients)
        //                    {
        //                        if (drugActiveIngredient1.Contains(drugActiveIngr.ActiveIngredient) == false)
        //                            drugActiveIngredient1.Add(drugActiveIngr.ActiveIngredient);
        //                    }

        //                    List<ActiveIngredientDefinition> drugActiveIngredient2 = new List<ActiveIngredientDefinition>();
        //                    foreach (DrugActiveIngredient drugActiveIngr in drugDefinitionGridList[j].DrugActiveIngredients)
        //                    {
        //                        if (drugActiveIngredient2.Contains(drugActiveIngr.ActiveIngredient) == false)
        //                            drugActiveIngredient2.Add(drugActiveIngr.ActiveIngredient);
        //                    }
        //                    //drugDefinitionGridList[i].DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient).ToList();
        //                    //drugDefinitionGridList[j].DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient).ToList(); ;
        //                    List<ActiveIngredientDefinition> activeIngredientCross = drugActiveIngredient2.Where(x => drugActiveIngredient1.Contains(x)).ToList();
        //                    if (activeIngredientCross.Count > 0)
        //                    {
        //                        string activeIngredients = string.Empty;
        //                        if (activeIngredientCross.Count > 1)
        //                            activeIngredients = string.Join(",", activeIngredientCross.Select(x => x.Name));
        //                        else
        //                            activeIngredients = activeIngredientCross.Select(x => x.Name).FirstOrDefault();
        //                        //foreach (ActiveIngredientDefinition drugActiveIngredient in activeIngredientCross)
        //                        //{
        //                        message.AppendLine("<b></br>Gün İçerisindeki Aynı Etken Maddeli İlaçlar</b></br>");
        //                        message.AppendLine("Karşılanması Gereken İlacın");
        //                        message.AppendLine("İlaç Adı :" + drugDefinitionGridList[i].Name + " - Etken Maddesi :" + activeIngredients + "</br>");
        //                        message.AppendLine("<b>Gün İçerisinde Yazılan İlacın</b></br>");
        //                        message.AppendLine("İlaç Adı :" + drugDefinitionGridList[j].Name + " - Etken Maddesi :" + activeIngredients);
        //                        //}
        //                    }
        //                }
        //            }
        //        }
        //        //string filterExpression = string.Empty;
        //        //filterExpression = Common.CreateFilterExpressionOfGuidList("", "DRUGORDER", drugOrderList.Select(x => x.ObjectID).ToList());

        //        //List<DrugOrderDetail> details = objectContext.QueryObjects<DrugOrderDetail>(filterExpression).ToList();

        //        //if (input.drugOrderObjectID.HasValue && input.drugOrderObjectID != Guid.Empty)
        //        //    drugOrderList = drugOrderList.Where(x => x.ObjectID != input.drugOrderObjectID).ToList();
        //        //foreach (DrugOrder drugOrder in drugOrderList)
        //        //{
        //        //    //if (IsItInTheTimeInterval(drugOrder.PlannedStartTime))
        //        //    //{
        //        //    //if (drugOrder.CurrentStateDefID != DrugOrder.States.Stopped && drugOrder.CurrentStateDefID != DrugOrder.States.Cancelled)
        //        //    //{
        //        //    BindingList<DrugActiveIngredient> activeIngredientList = ((DrugDefinition)drugOrder.Material).DrugActiveIngredients.Select("");
        //        //    var activeIngredients = activeIngredientList.Where(x => activeIngredientNewOrderList.Contains(x));
        //        //    foreach (var item in activeIngredients)
        //        //    {
        //        //        ControlOfActiveIngredient_Output output = new ControlOfActiveIngredient_Output();
        //        //        output.drug = drugOrder.Material.Name;
        //        //        output.activeIngredient = item.ActiveIngredient.Name;
        //        //        output.ObjectID = item.ActiveIngredient.ObjectID;
        //        //        output.ActiveIngredientObjectID = item.ObjectID;
        //        //        returnActiveIng.Add(output);
        //        //    }

        //        //foreach (DrugActiveIngredient activeIngredient in activeIngredientList)
        //        //{
        //        //    foreach (DrugActiveIngredient tempActive in activeIngredientNewOrderList)
        //        //    {
        //        //        if (activeIngredient.ActiveIngredient == tempActive.ActiveIngredient)
        //        //        {
        //        //            ControlOfActiveIngredient_Output output = new ControlOfActiveIngredient_Output();
        //        //            output.drug = drugOrder.Material.Name;
        //        //            output.activeIngredient = tempActive.ActiveIngredient.Name;
        //        //            returnActiveIng.Add(output);
        //        //        }
        //        //    }
        //        //}
        //        //}
        //        //}
        //        //}
        //        //return returnActiveIng;
        //        return message.ToString();
        //    }
        //}

        public class ControlOfOverDoseActiveIngredient_Details
        {
            public Guid newMaterialObjectIDList { get; set; }
            public double totalDose { get; set; }
        }

        public class ControlOfOverDoseActiveIngredient_Input
        {
            public List<KScheduleMaterial> KScheduleMaterials { get; set; }

            public Guid drug
            {
                get;
                set;
            }
            public double orderDose
            {
                get;
                set;
            }
            public double orderFreq
            {
                get;
                set;
            }
            public Episode episode
            {
                get;
                set;
            }
            public List<ControlOfOverDoseActiveIngredient_Details> newDetailList { get; set; }
        }

        public class ControlOfOverDoseActiveIngredient_Output
        {
            public string warningMessage
            {
                get;
                set;
            }
            public bool isWarning
            {
                get;
                set;
            }

        }

        [HttpPost]
        public ControlOfOverDoseActiveIngredient_Output ControlOfOverDoseActiveIngredient(ControlOfOverDoseActiveIngredient_Input input)
        {
            ControlOfOverDoseActiveIngredient_Output output = new ControlOfOverDoseActiveIngredient_Output();
            output.isWarning = false;
            output.warningMessage = string.Empty;
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                string drugName = string.Empty;
                DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)input.drug, typeof(DrugDefinition));
                List<DrugActiveIngredient> parentIngredient = drugDefinition.DrugActiveIngredients.Where(t => t.IsParentIngredient == true).ToList();
                if (parentIngredient.Count > 0)
                {
                    ActiveIngredientDefinition activeIngredient = parentIngredient[0].ActiveIngredient;
                    string unit = string.Empty;
                    if (activeIngredient.MaxDoseUnit != null)
                        unit = activeIngredient.MaxDoseUnit.Name;

                    if (activeIngredient.MaxDose != null && activeIngredient.MaxDose > 0)
                    {
                        double totalDose = (input.orderDose * input.orderFreq) * (double)parentIngredient[0].Value;
                        if (totalDose > activeIngredient.MaxDose)
                        {
                            output.warningMessage = activeIngredient.Name + " etken maddesinin bir günlük maksimum doz aşıldı. Maksimum Doz: " + activeIngredient.MaxDose.ToString() + " " + unit + " Verilen Doz: " + totalDose.ToString() + " " + unit;
                            output.isWarning = true;
                        }
                        else
                        {
                            BindingList<DrugActiveIngredient.GetAllDrugByParentActiveIng_Class> anotherDrug = DrugActiveIngredient.GetAllDrugByParentActiveIng(activeIngredient.ObjectID, drugDefinition.ObjectID);
                            if (anotherDrug.Count > 0)
                            {
                                Dictionary<Guid, double> anotherIngredients = new Dictionary<Guid, double>();
                                foreach (DrugActiveIngredient.GetAllDrugByParentActiveIng_Class d in anotherDrug)
                                {
                                    anotherIngredients.Add((Guid)d.Drugdefinition, (double)d.Value);
                                }

                                foreach (ControlOfOverDoseActiveIngredient_Details detail in input.newDetailList)
                                {
                                    if (anotherIngredients.ContainsKey(detail.newMaterialObjectIDList) == true)
                                    {
                                        totalDose = totalDose + (detail.totalDose * anotherIngredients[detail.newMaterialObjectIDList]);
                                        Material material = (Material)objectContext.GetObject(detail.newMaterialObjectIDList, typeof(Material));
                                        if (drugName == string.Empty)
                                            drugName = material.Name;
                                        else
                                            drugName = drugName + ", " + material.Name;
                                    }
                                }

                                IBindingList activeDrugOrder = objectContext.QueryObjects("DRUGORDER", "EPISODE = " + TTConnectionManager.ConnectionManager.GuidToString(input.episode.ObjectID));
                                if (activeDrugOrder.Count > 0)
                                {
                                    foreach (DrugOrder order in activeDrugOrder)
                                    {
                                        if (anotherIngredients.ContainsKey(order.Material.ObjectID) == true)
                                        {
                                            if (DrugOrder.GetContinueDrugOrder(input.episode.ObjectID, order.Material.ObjectID, Common.RecTime()) == false)
                                            {
                                                switch (order.Frequency)
                                                {
                                                    case FrequencyEnum.Q24H:
                                                        {
                                                            totalDose = totalDose + ((double)order.DoseAmount * anotherIngredients[order.Material.ObjectID]);
                                                            break;
                                                        }

                                                    case FrequencyEnum.Q12H:
                                                        {
                                                            totalDose = totalDose + ((2 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
                                                            break;
                                                        }

                                                    case FrequencyEnum.Q8H:
                                                        {
                                                            totalDose = totalDose + ((3 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
                                                            break;
                                                        }

                                                    case FrequencyEnum.Q6H:
                                                        {
                                                            totalDose = totalDose + ((4 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
                                                            break;
                                                        }

                                                    case FrequencyEnum.Q4H:
                                                        {
                                                            totalDose = totalDose + ((6 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
                                                            break;
                                                        }

                                                    case FrequencyEnum.Q3H:
                                                        {
                                                            totalDose = totalDose + ((8 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
                                                            break;
                                                        }

                                                    case FrequencyEnum.Q2H:
                                                        {
                                                            totalDose = totalDose + ((12 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
                                                            break;
                                                        }

                                                    case FrequencyEnum.Q1H:
                                                        {
                                                            totalDose = totalDose + ((24 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
                                                            break;
                                                        }

                                                    default:
                                                        {
                                                            break;
                                                        }
                                                }
                                                if (drugName == string.Empty)
                                                    drugName = order.Material.Name;
                                                else
                                                    drugName = drugName + ", " + order.Material.Name;
                                            }
                                        }
                                    }
                                }
                            }
                            if (totalDose > activeIngredient.MaxDose)
                            {
                                output.warningMessage = activeIngredient.Name + " etken maddesinin bir günlük maksimum doz aşıldı. Maksimum Doz: " + activeIngredient.MaxDose.ToString() + " " + unit + " Verilen Doz: " + totalDose.ToString() + " " + unit + " (" + drugName + ") ";
                                output.isWarning = true;
                            }
                        }
                    }
                }
            }
            return output;
        }

        public class ControlRepeatDay_Input
        {

            public Guid drug
            {
                get;
                set;
            }
            public Episode episode
            {
                get;
                set;
            }
            public DateTime orderStartDate
            {
                get;
                set;
            }
        }

        public class ControlRepeatDay_Output
        {
            public string warningMessage
            {
                get;
                set;
            }
            public bool isWarning
            {
                get;
                set;
            }

        }

        [HttpPost]
        public ControlRepeatDay_Output ControlRepeatDay(ControlRepeatDay_Input input)
        {
            ControlRepeatDay_Output output = new ControlRepeatDay_Output();
            output.isWarning = false;
            output.warningMessage = string.Empty;
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)input.drug, typeof(DrugDefinition));
                if (drugDefinition.OrderRPTDay != null && drugDefinition.OrderRPTDay > 0)
                {
                    DateTime avalibleDate = input.orderStartDate.AddDays(-(double)drugDefinition.OrderRPTDay);
                    List<DrugOrder> oldOrders = DrugOrder.GetDrugOrderForPatientbyDrug(objectContext, input.episode.ObjectID, drugDefinition.ObjectID)
                                               .Where(t => t.PlannedStartTime > avalibleDate).ToList();
                    foreach (DrugOrder order in oldOrders)
                    {
                        if (order.DrugOrderDetails.Select(t => t.CurrentStateDefID == DrugOrderDetail.States.Apply || t.CurrentStateDefID == DrugOrderDetail.States.Supply).ToList().Count > 0)
                        {
                            output.warningMessage = drugDefinition.Name + " isimli ilacı " + order.PlannedStartTime.ToString() + " tarihinde istem yapıldığı için " + drugDefinition.OrderRPTDay.ToString() + " gün geçmeden ikinci istem yapıyorsunuz !";
                            output.isWarning = true;
                            break;
                        }
                    }
                }
            }
            return output;
        }

        public class DoseManage_Input
        {
            public string episodeObjectID
            {
                get;
                set;
            }
            public string password
            {
                get;
                set;
            }
        }

        public bool CreatedKscheduleForNewDrugOrder(List<DrugOrder> drugOrderList, InPatientPhysicianApplication inPatientApp, TTObjectContext contextKshedule)
        {
            try
            {
                bool returnResult = false;

                List<KSchedulePatienOwnDrug> patienOwnDrugs = new List<KSchedulePatienOwnDrug>();
                List<KScheduleMaterial> ksheduleMaterials = new List<KScheduleMaterial>();
                List<KScheduleUnListMaterial> ksheduleUnListMaterials = new List<KScheduleUnListMaterial>();
                List<KScheduleInfectionDrug> kScheduleInfectionDrugs = new List<KScheduleInfectionDrug>();

                foreach (DrugOrder order in drugOrderList)
                {
                    if (order.CaseOfNeed.HasValue && order.CaseOfNeed.Value)
                        continue;

                    double amount = 0;
                    bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)order.Material);

                    if (drugType)
                        amount = order.DrugOrderDetails.Sum(x => x.Amount).Value;
                    else
                        amount = order.DrugOrderDetails.Sum(x => x.DoseAmount).Value;

                    double restDose = 0;
                    Dictionary<object, double> rests = DrugOrderTransaction.GetPatientRestDose(order.Material, order.Episode);
                    List<DrugOrderDetail> unListDetails = new List<DrugOrderDetail>();
                    foreach (KeyValuePair<object, double> rest in rests)
                    {
                        restDose = restDose + rest.Value;
                    }


                    if (order.CurrentStateDefID == DrugOrder.States.Approve)
                    {
                        KScheduleInfectionDrug kScheduleInfectionDrug = new KScheduleInfectionDrug(contextKshedule);
                        kScheduleInfectionDrug.DrugAmount = amount;
                        kScheduleInfectionDrug.Material = order.Material;
                        kScheduleInfectionDrug.BarcodeVerifyCounter = 0;
                        if (order.IsCV.HasValue)
                            kScheduleInfectionDrug.IsCV = order.IsCV;
                        else
                            kScheduleInfectionDrug.IsCV = false;
                        //kScheduleInfectionDrug.KSchedule = kScheduleNew;
                        kScheduleInfectionDrug.StockActionStatus = StockActionDetailStatusEnum.Cancelled;
                        kScheduleInfectionDrug.DrugOrderObjectID = order.ObjectID;
                        kScheduleInfectionDrug.IsApproved = false;


                        BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> trxList = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(order.Episode.ObjectID, order.Material.ObjectID);
                        if (trxList.Count > 0)
                        {
                            if (trxList[0].ExpirationDate != null)
                                kScheduleInfectionDrug.ExpirationDate = trxList[0].ExpirationDate;
                            else
                                kScheduleInfectionDrug.ExpirationDate = DateTime.MinValue;
                        }

                        if (kScheduleInfectionDrug.ExpirationDate == null)
                            kScheduleInfectionDrug.ExpirationDate = DateTime.MinValue;

                        kScheduleInfectionDrugs.Add(kScheduleInfectionDrug);
                    }
                    else
                    {
                        if (order.PatientOwnDrug.HasValue && order.PatientOwnDrug.Value)
                        {
                            KSchedulePatienOwnDrug kSchedulePatienOwnDrug = new KSchedulePatienOwnDrug(contextKshedule);
                            if (drugType)
                                kSchedulePatienOwnDrug.DrugAmount = amount;
                            else
                            {
                                double rAmount = ((double)amount) / ((double)((DrugDefinition)order.Material).Volume);
                                kSchedulePatienOwnDrug.DrugAmount = Math.Ceiling(rAmount);
                            }
                            kSchedulePatienOwnDrug.Material = order.Material;
                            kSchedulePatienOwnDrug.BarcodeVerifyCounter = 0;
                            //kSchedulePatienOwnDrug.KSchedule = kScheduleNew;
                            kSchedulePatienOwnDrug.StockActionStatus = StockActionDetailStatusEnum.New;
                            kSchedulePatienOwnDrug.DrugOrderObjectID = order.ObjectID;
                            if (order.IsCV.HasValue)
                                kSchedulePatienOwnDrug.IsCV = order.IsCV;
                            else
                                kSchedulePatienOwnDrug.IsCV = false;
                            foreach (DrugOrderDetail drugOrderDetail in order.DrugOrderDetails)
                                kSchedulePatienOwnDrug.DrugOrderDetails.Add(drugOrderDetail);

                            BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> trxList = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(order.Episode.ObjectID, order.Material.ObjectID);
                            if (trxList.Count > 0)
                            {
                                if (trxList[0].ExpirationDate != null)
                                    kSchedulePatienOwnDrug.ExpirationDate = trxList[0].ExpirationDate;
                                else
                                    kSchedulePatienOwnDrug.ExpirationDate = DateTime.MinValue;
                            }

                            if (kSchedulePatienOwnDrug.ExpirationDate == null)
                                kSchedulePatienOwnDrug.ExpirationDate = DateTime.MinValue;
                            patienOwnDrugs.Add(kSchedulePatienOwnDrug);
                        }
                        else
                        {
                            KScheduleMaterial ksmaterial = null;
                            if (restDose == 0)
                            {
                                ksmaterial = new KScheduleMaterial(contextKshedule);
                                ksmaterial.Material = order.Material;
                                ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                                ksmaterial.IsImmediate = order.IsImmediate;
                                if (order.IsCV.HasValue)
                                    ksmaterial.IsCV = order.IsCV;
                                else
                                    ksmaterial.IsCV = false;
                                ksmaterial.BarcodeVerifyCounter = 0;
                                ksmaterial.DrugOrderObjectID = order.ObjectID;

                                if (drugType)
                                {
                                    ksmaterial.RequestAmount = amount;
                                    ksmaterial.Amount = amount;
                                }
                                else
                                {
                                    double rAmount = ((double)amount) / ((double)((DrugDefinition)order.Material).Volume);
                                    ksmaterial.Amount = Math.Ceiling(rAmount);
                                    ksmaterial.RequestAmount = Math.Ceiling(rAmount);
                                }

                            }
                            else if (restDose > amount)
                            {
                                foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                {
                                    unListDetails.Add(detail);
                                    detail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                                }
                            }
                            else
                            {
                                double restamount = 0;
                                foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                {
                                    if (drugType)
                                    {
                                        if (restDose > detail.Amount)
                                        {
                                            detail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                                            restDose = restDose - (double)detail.Amount;
                                        }
                                        else
                                        {
                                            restamount = restamount + (double)detail.Amount;
                                        }

                                    }
                                    else
                                    {
                                        if (restDose > detail.Amount)
                                        {
                                            detail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                                            restDose = restDose - (double)detail.DoseAmount;
                                        }
                                        else
                                        {
                                            restamount = restamount + (double)detail.DoseAmount;
                                        }
                                    }
                                }
                                if (restamount > 0)
                                {
                                    ksmaterial = new KScheduleMaterial(contextKshedule);
                                    ksmaterial.Material = order.Material;
                                    ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                                    ksmaterial.IsImmediate = order.IsImmediate;
                                    if (order.IsCV.HasValue)
                                        ksmaterial.IsCV = order.IsCV;
                                    else
                                        ksmaterial.IsCV = false;
                                    ksmaterial.BarcodeVerifyCounter = 0;
                                    ksmaterial.DrugOrderObjectID = order.ObjectID;

                                    if (drugType)
                                    {
                                        ksmaterial.RequestAmount = restamount;
                                        ksmaterial.Amount = restamount;
                                    }
                                    else
                                    {
                                        double rAmount = ((double)restamount) / ((double)((DrugDefinition)order.Material).Volume);
                                        ksmaterial.Amount = Math.Ceiling(rAmount);
                                        ksmaterial.RequestAmount = Math.Ceiling(rAmount);
                                    }
                                }
                            }

                            if (ksmaterial != null)
                            {
                                KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(contextKshedule);
                                foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                {
                                    detail.KScheduleCollectedOrder = null;
                                    kScheduleCollectedOrder.DrugOrderDetails.Add(detail);
                                    if (detail.CurrentStateDefID != DrugOrderDetail.States.UseRestDose)
                                        detail.CurrentStateDefID = DrugOrderDetail.States.Request;
                                }
                                ksmaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;
                                ksheduleMaterials.Add(ksmaterial);
                            }

                            if (unListDetails.Count > 0)
                            {
                                KScheduleUnListMaterial unListMaterial = new KScheduleUnListMaterial(contextKshedule);

                                unListMaterial.UnlistDrug = order.Material.Name;
                                if (drugType)
                                {
                                    unListMaterial.UnlistAmount = restDose;
                                    unListMaterial.UnlistVolume = restDose * ((DrugDefinition)order.Material).Volume;
                                }
                                else
                                {
                                    unListMaterial.UnlistAmount = restDose / ((DrugDefinition)order.Material).Volume;
                                    unListMaterial.UnlistVolume = restDose;
                                }

                                foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                {
                                    DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                                    unListMaterial.DrugOrderDetails.Add(drugOrderDetail);
                                }
                                ksheduleUnListMaterials.Add(unListMaterial);
                                //kScheduleNew.KScheduleUnListMaterials.Add(unListMaterial);
                            }
                        }
                    }
                }

                DateTime startDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 00:00:00");
                DateTime endDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");
                BindingList<KSchedule> activeKschedules = KSchedule.GetActiveKSchedule(contextKshedule, inPatientApp.ObjectID, startDate, endDate);

                if (activeKschedules.Count > 0)
                {
                    KSchedule kSchedule = contextKshedule.GetObject<KSchedule>(activeKschedules[0].ObjectID);
                    foreach (KSchedulePatienOwnDrug ownDrug in patienOwnDrugs)
                        ownDrug.KSchedule = kSchedule;

                    foreach (KScheduleMaterial material in ksheduleMaterials)
                        kSchedule.KScheduleMaterials.Add(material);

                    foreach (KScheduleUnListMaterial unListMaterial in ksheduleUnListMaterials)
                        unListMaterial.KSchedule = kSchedule;

                    foreach (KScheduleInfectionDrug ınfectionDrug in kScheduleInfectionDrugs)
                        ınfectionDrug.KSchedule = kSchedule;

                }
                else
                {
                    if (patienOwnDrugs.Count() > 0 || ksheduleMaterials.Count() > 0 || kScheduleInfectionDrugs.Count > 0)
                    {
                        KSchedule kScheduleNew = new KSchedule(contextKshedule);
                        kScheduleNew.StartDate = Common.RecTime();
                        //kScheduleNew.EndDate = dailyDrugSchedule.EndDate;
                        Store pharmacy = Store.GetPharmacyStore(contextKshedule);
                        if (pharmacy != null)
                        {
                            kScheduleNew.Store = pharmacy;
                        }
                        kScheduleNew.DestinationStore = inPatientApp.MasterResource.Store;
                        kScheduleNew.Episode = inPatientApp.Episode;
                        kScheduleNew.InPatientPhysicianApplication = inPatientApp;
                        kScheduleNew.MKYS_TeslimAlanObjID = Common.CurrentUser.UserObject.ObjectID;
                        kScheduleNew.MKYS_TeslimAlan = ((ResUser)Common.CurrentUser.UserObject).Name;

                        foreach (KSchedulePatienOwnDrug ownDrug in patienOwnDrugs)
                            ownDrug.KSchedule = kScheduleNew;

                        foreach (KScheduleMaterial material in ksheduleMaterials)
                            kScheduleNew.KScheduleMaterials.Add(material);

                        foreach (KScheduleUnListMaterial unListMaterial in ksheduleUnListMaterials)
                            unListMaterial.KSchedule = kScheduleNew;

                        foreach (KScheduleInfectionDrug ınfectionDrug in kScheduleInfectionDrugs)
                            ınfectionDrug.KSchedule = kScheduleNew;

                        kScheduleNew.CurrentStateDefID = KSchedule.States.New;
                        kScheduleNew.Update();
                        kScheduleNew.CurrentStateDefID = KSchedule.States.Approval;
                        kScheduleNew.Update();
                        kScheduleNew.CurrentStateDefID = KSchedule.States.RequestPreparation;
                    }
                }

                //contextKshedule.Dispose();
                returnResult = true;
                return returnResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CreatedNewKschorderByDrugOrderIntroduction(DrugOrderIntroduction drugOrderIntroduction, TTObjectContext contextKshedule)
        {
            try
            {
                bool returnResult = false;
                //TTObjectContext contextKshedule = new TTObjectContext(false);
                InPatientPhysicianApplication inPatientApp = drugOrderIntroduction.ActiveInPatientPhysicianApp;
                KSchedule kScheduleNew = new KSchedule(contextKshedule);
                kScheduleNew.StartDate = drugOrderIntroduction.ActionDate;
                //kScheduleNew.EndDate = dailyDrugSchedule.EndDate;
                Store pharmacy = Store.GetPharmacyStore(contextKshedule);
                if (pharmacy != null)
                {
                    kScheduleNew.Store = pharmacy;
                }
                kScheduleNew.DestinationStore = drugOrderIntroduction.MasterResource.Store;
                kScheduleNew.Episode = drugOrderIntroduction.Episode;
                kScheduleNew.InPatientPhysicianApplication = inPatientApp;
                kScheduleNew.MKYS_TeslimAlanObjID = Common.CurrentUser.UserObject.ObjectID;
                kScheduleNew.MKYS_TeslimAlan = ((ResUser)Common.CurrentUser.UserObject).Name;

                foreach (DrugOrderIntroductionDet det in drugOrderIntroduction.DrugOrderIntroductionDetails)
                {
                    DrugOrder order = det.DrugOrder;
                    if (det.CaseOfNeed == true)
                        continue;

                    if (order.CurrentStateDefID == DrugOrder.States.Approve)
                    {
                        double amount = 0;
                        KScheduleInfectionDrug kScheduleInfectionDrug = new KScheduleInfectionDrug(contextKshedule);
                        foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                        {
                            DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                            if (drugOrderDetail.Amount != null)
                                amount += (double)drugOrderDetail.Amount.Value;
                        }
                        kScheduleInfectionDrug.DrugAmount = amount;
                        kScheduleInfectionDrug.Material = order.Material;
                        kScheduleInfectionDrug.BarcodeVerifyCounter = 0;
                        kScheduleInfectionDrug.KSchedule = kScheduleNew;
                        kScheduleInfectionDrug.StockActionStatus = StockActionDetailStatusEnum.Cancelled;


                        BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> trxList = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(drugOrderIntroduction.Episode.ObjectID, order.Material.ObjectID);
                        if (trxList.Count > 0)
                        {
                            if (trxList[0].ExpirationDate != null)
                                kScheduleInfectionDrug.ExpirationDate = trxList[0].ExpirationDate;
                            else
                                kScheduleInfectionDrug.ExpirationDate = DateTime.MinValue;
                        }

                        if (kScheduleInfectionDrug.ExpirationDate == null)
                            kScheduleInfectionDrug.ExpirationDate = DateTime.MinValue;
                    }
                    else
                    {
                        if (det.PatientOwnDrug != null && det.PatientOwnDrug == true)
                        {
                            double amount = 0;
                            KSchedulePatienOwnDrug kSchedulePatienOwnDrug = new KSchedulePatienOwnDrug(contextKshedule);
                            foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                            {
                                DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                                kSchedulePatienOwnDrug.DrugOrderDetails.Add(drugOrderDetail);
                                if (drugOrderDetail.Amount != null)
                                    amount += (double)drugOrderDetail.Amount.Value;
                            }
                            kSchedulePatienOwnDrug.DrugAmount = amount;
                            kSchedulePatienOwnDrug.Material = order.Material;
                            kSchedulePatienOwnDrug.BarcodeVerifyCounter = 0;
                            kSchedulePatienOwnDrug.KSchedule = kScheduleNew;
                            kSchedulePatienOwnDrug.StockActionStatus = StockActionDetailStatusEnum.New;


                            BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> trxList = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(drugOrderIntroduction.Episode.ObjectID, order.Material.ObjectID);
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
                            if (order.DrugOrderDetails.Count > 0)
                            {
                                double restDose = 0;
                                Dictionary<object, double> rests = DrugOrderTransaction.GetPatientRestDose(order.Material, order.Episode);
                                List<DrugOrderDetail> unListDetails = new List<DrugOrderDetail>();
                                foreach (KeyValuePair<object, double> rest in rests)
                                {
                                    restDose = restDose + rest.Value;
                                }

                                KScheduleMaterial ksmaterial = null;

                                double amount = 0;
                                if (restDose == 0)
                                {
                                    foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                    {
                                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                                        amount += (double)drugOrderDetail.Amount;
                                    }

                                    ksmaterial = new KScheduleMaterial(contextKshedule);
                                    ksmaterial.Material = order.Material;
                                    ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                                    ksmaterial.IsImmediate = order.IsImmediate;
                                    ksmaterial.BarcodeVerifyCounter = 0;


                                    DrugDefinition drugDefinition = (DrugDefinition)order.Material;
                                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                                    if (drugType)
                                    {

                                        ksmaterial.RequestAmount = amount;
                                        ksmaterial.Amount = amount;

                                    }
                                    else
                                    {
                                        double rAmount = ((double)amount) / ((double)drugDefinition.Volume);
                                        ksmaterial.Amount = Math.Ceiling(rAmount);
                                        ksmaterial.RequestAmount = Math.Ceiling(rAmount);
                                    }

                                }

                                if (restDose > 0 && restDose < order.Amount)
                                {
                                    double rAmount = (double)order.Amount - restDose;
                                    double schamount = 0;
                                    List<DrugOrderDetail> schOrderDetails = new List<DrugOrderDetail>();
                                    foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                    {
                                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                                        if (rAmount >= detail.Amount)
                                        {
                                            rAmount -= (double)drugOrderDetail.Amount;
                                            schOrderDetails.Add(drugOrderDetail);
                                            schamount += (double)drugOrderDetail.Amount;
                                        }
                                        else
                                        {
                                            unListDetails.Add(drugOrderDetail);
                                        }
                                    }
                                    ksmaterial = new KScheduleMaterial(contextKshedule);
                                    ksmaterial.Material = order.Material;
                                    ksmaterial.IsImmediate = order.IsImmediate;
                                    ksmaterial.BarcodeVerifyCounter = 0;
                                    ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;

                                    DrugDefinition drugDefinition = (DrugDefinition)order.Material;
                                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                                    if (drugType)
                                    {

                                        ksmaterial.RequestAmount = rAmount;
                                        ksmaterial.Amount = rAmount;

                                    }
                                    else
                                    {
                                        double rAmountNew = ((double)rAmount) / ((double)drugDefinition.Volume);
                                        ksmaterial.Amount = Math.Ceiling(rAmountNew);
                                        ksmaterial.RequestAmount = Math.Ceiling(rAmountNew);
                                    }

                                }

                                if (restDose > 0 && restDose >= order.Amount)
                                {
                                    foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                    {
                                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                                        unListDetails.Add(drugOrderDetail);
                                        drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                                        drugOrderDetail.Eligible = false;
                                    }
                                }

                                if (unListDetails.Count > 0)
                                {
                                    KScheduleUnListMaterial unListMaterial = new KScheduleUnListMaterial(contextKshedule);

                                    bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)order.Material);
                                    unListMaterial.UnlistDrug = order.Material.Name;
                                    if (drugType)
                                    {
                                        unListMaterial.UnlistAmount = restDose;
                                        unListMaterial.UnlistVolume = restDose * ((DrugDefinition)order.Material).Volume;
                                    }
                                    else
                                    {
                                        unListMaterial.UnlistAmount = restDose / ((DrugDefinition)order.Material).Volume;
                                        unListMaterial.UnlistVolume = restDose;
                                    }

                                    foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                    {
                                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                                        unListMaterial.DrugOrderDetails.Add(drugOrderDetail);
                                    }

                                    kScheduleNew.KScheduleUnListMaterials.Add(unListMaterial);
                                }

                                if (ksmaterial != null)
                                {
                                    KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(contextKshedule);
                                    foreach (DrugOrderDetail detail in order.DrugOrderDetails.Select(string.Empty))
                                    {
                                        DrugOrderDetail updateDetail = (DrugOrderDetail)contextKshedule.GetObject(detail.ObjectID, typeof(DrugOrderDetail));
                                        updateDetail.KScheduleCollectedOrder = null;
                                        kScheduleCollectedOrder.DrugOrderDetails.Add(updateDetail);
                                        if (detail.CurrentStateDefID != DrugOrderDetail.States.Apply)
                                            detail.CurrentStateDefID = DrugOrderDetail.States.Request;
                                    }
                                    ksmaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;

                                    kScheduleNew.KScheduleMaterials.Add(ksmaterial);
                                }

                            }
                        }
                    }
                }

                kScheduleNew.CurrentStateDefID = KSchedule.States.New;
                kScheduleNew.Update();
                kScheduleNew.CurrentStateDefID = KSchedule.States.Approval;
                kScheduleNew.Update();
                kScheduleNew.CurrentStateDefID = KSchedule.States.RequestPreparation;

                if (kScheduleNew.KScheduleMaterials.Count != 0 || kScheduleNew.KSchedulePatienOwnDrugs.Count != 0)
                {
                    // contextKshedule.Save();
                    Debug.WriteLine("");
                }
                else
                {
                    //  TTObjectContext objectContextUnDrug = new TTObjectContext(false);
                    foreach (KScheduleUnListMaterial unMaterial in kScheduleNew.KScheduleUnListMaterials)
                    {
                        foreach (DrugOrderDetail usedDetail in unMaterial.DrugOrderDetails.Select(string.Empty))
                        {

                            DrugOrderDetail usedDrug = (DrugOrderDetail)contextKshedule.GetObject(usedDetail.ObjectID, typeof(DrugOrderDetail));
                            if (usedDrug.CurrentStateDefID != DrugOrderDetail.States.Apply)
                            {
                                usedDrug.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                                usedDrug.Eligible = false;
                            }
                        }
                    }
                    //objectContextUnDrug.Save();
                }
                //contextKshedule.Dispose();
                returnResult = true;
                return returnResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [HttpPost]
        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Sistem_Parametresi_Ekleme_Duzeltme)]
        public string CreateDrugOrderDetails()
        {
            try
            {
                string date = TTObjectClasses.SystemParameter.GetParameterValue("CREATEDRUGORDERDETAILDATE", "2018/07/10");
                TTObjectContext readOnlyObjectContext = new TTObjectContext(false);
                IBindingList drugOrders = readOnlyObjectContext.QueryObjects("DRUGORDER", "PLANNEDSTARTTIME > TODATE('" + date + "') and INPATIENTPHYSICIANAPPLICATION is not null");
                string resultMessage = "drugOrders" + drugOrders.Count + " ";
                List<DrugOrderIntroduction> drugOrderIntroductionlist = new List<DrugOrderIntroduction>();
                foreach (DrugOrder drugOrder in drugOrders)
                {
                    if (drugOrder.DrugOrderDetails.Count == 0 && drugOrder.CurrentStateDefID != DrugOrder.States.Stopped)
                    {
                        IBindingList drugOrderIntroductionDetail = readOnlyObjectContext.QueryObjects("DRUGORDERINTRODUCTIONDET", " DRUGORDER = '" + drugOrder.ObjectID.ToString() + "'");
                        if (drugOrderIntroductionDetail.Count > 0)
                        {
                            DrugOrderIntroduction into = ((DrugOrderIntroductionDet)drugOrderIntroductionDetail[0]).DrugOrderIntroduction;
                            if (drugOrderIntroductionlist.Contains(into) == false)
                                drugOrderIntroductionlist.Add(into);
                        }
                        if (drugOrder.Type == TTUtils.CultureService.GetText("M26287", "K-Çizelgesi"))
                        {
                            if (((DrugDefinition)drugOrder.Material).InfectionApproval != true)
                            {
                                DateTime detailTime = (DateTime)drugOrder.PlannedStartTime;
                                double totalAmount = 0;
                                double detailCount = DrugOrder.GetDetailCount(drugOrder.Frequency);
                                double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
                                double unitAmount = 0;
                                double doseAmount = 0;
                                DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
                                detailCount = detailCount * (double)drugOrder.Day;
                                bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                                if (drugType)
                                {
                                    unitAmount = (double)drugOrder.DoseAmount;
                                    totalAmount = unitAmount * (double)detailCount;
                                    doseAmount = (double)drugOrder.DoseAmount;
                                }
                                else
                                {
                                    unitAmount = (double)drugOrder.DoseAmount;
                                    totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)detailCount);
                                    doseAmount = (double)drugOrder.DoseAmount * (double)drugDefinition.Dose;
                                }

                                drugOrder.Amount = (double)totalAmount;
                                bool eligible = true;
                                for (int i = 0; i < detailCount; i++)
                                {
                                    DrugOrderDetail drugOrderDetail = new DrugOrderDetail(drugOrder.ObjectContext);
                                    drugOrderDetail.Material = (Material)drugOrder.Material;
                                    drugOrderDetail.MasterResource = drugOrder.MasterResource;
                                    drugOrderDetail.FromResource = drugOrder.FromResource;
                                    drugOrderDetail.Episode = drugOrder.Episode;
                                    drugOrderDetail.ActionDate = drugOrder.ActionDate; // Bu actionun açıldığı tarih olmalı. SS
                                    drugOrderDetail.OrderPlannedDate = detailTime;
                                    detailTime = detailTime.AddHours(detailTimePeriod);
                                    drugOrderDetail.Amount = unitAmount;
                                    drugOrderDetail.Day = drugOrder.Day;
                                    drugOrderDetail.DoseAmount = doseAmount;
                                    drugOrderDetail.Frequency = drugOrder.Frequency;
                                    drugOrderDetail.UsageNote = drugOrder.UsageNote;
                                    drugOrderDetail.DrugOrder = drugOrder;

                                    if (drugOrder.NursingApplication != null)
                                        drugOrderDetail.SecondaryMasterResource = drugOrder.NursingApplication.SecondaryMasterResource;
                                    else
                                    {
                                        drugOrderDetail.SecondaryMasterResource = drugOrder.SecondaryMasterResource;
                                        drugOrderDetail.SubEpisode = drugOrder.SubEpisode;
                                    }

                                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                                    drugOrderDetail.Eligible = eligible;
                                    if (drugType == false)
                                    {
                                        eligible = false;
                                    }

                                    foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                                    {
                                        orderDetail.NursingApplication = drugOrder.NursingApplication;
                                    }
                                }


                                drugOrder.CurrentStateDefID = DrugOrder.States.Planned;

                            }
                            else
                            {
                                drugOrder.CurrentStateDefID = DrugOrder.States.Approve;
                                // TO DO : Enfeksiyon Komitesi işlemi başlatılacak.
                                InfectionCommittee infectionCommittee = new InfectionCommittee(drugOrder.ObjectContext);
                                infectionCommittee.ActionDate = Common.RecTime();
                                infectionCommittee.FromResource = drugOrder.MasterResource;
                                infectionCommittee.MasterResource = drugOrder.MasterResource;
                                infectionCommittee.Episode = drugOrder.Episode;
                                infectionCommittee.SubEpisode = drugOrder.SubEpisode;
                                infectionCommittee.InPatientPhysicianApplication = drugOrder.InPatientPhysicianApplication;
                                infectionCommittee.CurrentStateDefID = InfectionCommittee.States.New;
                                InfectionCommitteeDetail infectionCommitteeDetail = new InfectionCommitteeDetail(drugOrder.ObjectContext);
                                infectionCommitteeDetail.DrugOrder = drugOrder;
                                infectionCommitteeDetail.InfectionCommittee = infectionCommittee;
                            }
                        }
                        else if (drugOrder.Type == TTUtils.CultureService.GetText("M25807", "Hasta Yanında Getirdi"))
                        {
                            DateTime detailTime = (DateTime)drugOrder.PlannedStartTime;
                            double totalAmount = 0;
                            double detailCount = DrugOrder.GetDetailCount(drugOrder.Frequency);
                            double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
                            double unitAmount = 0;
                            double doseAmount = 0;
                            DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
                            detailCount = detailCount * (double)drugOrder.Day;
                            bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                            if (drugType)
                            {
                                unitAmount = (double)drugOrder.DoseAmount;
                                totalAmount = unitAmount * (double)detailCount;
                                doseAmount = (double)drugOrder.DoseAmount;
                            }
                            else
                            {
                                unitAmount = (double)drugOrder.DoseAmount;
                                totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)detailCount);
                                doseAmount = (double)drugOrder.DoseAmount * (double)drugDefinition.Dose;
                            }

                            drugOrder.Amount = (double)totalAmount;
                            bool eligible = false;
                            for (int i = 0; i < detailCount; i++)
                            {
                                DrugOrderDetail drugOrderDetail = new DrugOrderDetail(drugOrder.ObjectContext);
                                drugOrderDetail.Material = (Material)drugOrder.Material;
                                drugOrderDetail.MasterResource = drugOrder.MasterResource;
                                drugOrderDetail.FromResource = drugOrder.FromResource;
                                drugOrderDetail.Episode = drugOrder.Episode;
                                drugOrderDetail.ActionDate = drugOrder.ActionDate; // Bu actionun açıldığı tarih olmalı. SS
                                drugOrderDetail.OrderPlannedDate = detailTime;
                                detailTime = detailTime.AddHours(detailTimePeriod);
                                drugOrderDetail.Amount = unitAmount;
                                drugOrderDetail.Day = drugOrder.Day;
                                drugOrderDetail.DoseAmount = doseAmount;
                                drugOrderDetail.Frequency = drugOrder.Frequency;
                                drugOrderDetail.UsageNote = drugOrder.UsageNote + " (Hasta ilacı yanında getirdi)";
                                drugOrderDetail.DrugOrder = drugOrder;
                                drugOrderDetail.SecondaryMasterResource = drugOrder.NursingApplication.SecondaryMasterResource;
                                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                                drugOrderDetail.Eligible = eligible;
                                foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                                {
                                    orderDetail.NursingApplication = drugOrder.NursingApplication;
                                }

                                drugOrderDetail.Update();
                                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                            }

                            // Burası düzeltilmesi lazım Planned State is entry yapıldı geçici olarak. SS.
                            drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
                        }
                    }
                }
                foreach (DrugOrderIntroduction item in drugOrderIntroductionlist)
                {
                    CreatedNewKschorderByDrugOrderIntroduction(item, readOnlyObjectContext);
                }
                readOnlyObjectContext.Save();

                return "İşlem Başarılı " + resultMessage;
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }
        [HttpPost]
        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Sistem_Parametresi_Ekleme_Duzeltme)]
        public string MaterialDoseManagerOnPatient(DoseManage_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    string password = TTObjectClasses.SystemParameter.GetParameterValue("DOSEAMAOUNTZERO", "5868");
                    if (password.Equals(input.password))
                    {
                        Episode episode = objectContext.GetObject<Episode>(new Guid(input.episodeObjectID));
                        BindingList<DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class> DrugOrderTransactions = DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode(objectContext, episode.ObjectID.ToString());
                        foreach (DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class trans in DrugOrderTransactions)
                        {
                            DrugOrderTransaction drugOrderTransaction = objectContext.GetObject<DrugOrderTransaction>(trans.ObjectID.Value);
                            drugOrderTransaction.Amount = Convert.ToDouble(trans.Usedamount);
                        }
                        objectContext.Save();
                    }
                    else
                    {
                        return "Şifre Hatalı!";
                    }

                }
                catch (Exception e)
                {
                    objectContext.Dispose();
                    return e.ToString();
                }

                return "İşlem Başarılı";
            }
        }

        public class GetPatientAllergicActiveIngredients_Input
        {
            public Guid EpisodeID { get; set; }
        }

        [HttpPost]
        public List<Guid> GetPatientAllergicActiveIngredients(GetPatientAllergicActiveIngredients_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<Guid> allergies = new List<Guid>();
                Episode episode = (Episode)objectContext.GetObject(input.EpisodeID, typeof(Episode));
                if (episode.Patient.MedicalInformation != null)
                {
                    if (episode.Patient.MedicalInformation.MedicalInfoAllergies != null)
                    {
                        if (episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies != null && episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies.Count > 0)
                        {
                            foreach (MedicalInfoDrugAllergies drugAllergies in episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies)
                            {
                                if (drugAllergies.ActiveIngredient != null)
                                {
                                    if (allergies.Contains(drugAllergies.ActiveIngredient.ObjectID) == false)
                                        allergies.Add(drugAllergies.ActiveIngredient.ObjectID);
                                }
                            }
                        }
                    }
                }
                return allergies;
            }
        }

        public class GetDrugReportNo_Input
        {
            public Guid EpisodeID { get; set; }

            public Guid DrugID { get; set; }
        }


        public class GetDrugReportNo_Output
        {
            public bool result { get; set; }

            public string resultMessage { get; set; }

            public string reportId { get; set; }
        }

        [HttpPost]
        public string GetDrugReportNo(GetDrugReportNo_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Episode episode = objectContext.GetObject<Episode>(input.EpisodeID);
                DrugDefinition drugDefinition = objectContext.GetObject<DrugDefinition>(input.DrugID);
                string output = string.Empty;
                if (drugDefinition.EtkinMadde != null)
                {
                    RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                    IlacRaporuOkuDTOList result = new IlacRaporuOkuDTOList();
                    _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                    _raporOkuTCKimlikNodanDVO.raporTuru = "10";
                    _raporOkuTCKimlikNodanDVO.tckimlikNo = episode.Patient.UniqueRefNo.ToString();

                    RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
                    if (response != null)
                    {
                        if (response.sonucKodu.Equals(0))
                        {
                            if (response.raporlar != null)
                            {
                                foreach (var item in response.raporlar)
                                {
                                    if (item.ilacRapor != null)
                                    {
                                        if (item.ilacRapor.raporEtkinMaddeler != null)
                                        {
                                            foreach (var iteminner in item.ilacRapor.raporEtkinMaddeler)
                                            {
                                                if (item.ilacRapor.raporDVO != null)
                                                {
                                                    if (iteminner.etkinMaddeKodu.Equals(drugDefinition.EtkinMadde.etkinMaddeKodu) && Convert.ToDateTime(item.ilacRapor.raporDVO.bitisTarihi) > Common.RecTime())
                                                    {
                                                        if (item.raporTakipNo != null)
                                                            output = item.raporTakipNo.ToString();
                                                        else
                                                            output = "0";
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (string.IsNullOrEmpty(output))
                                    throw new Exception(drugDefinition.EtkinMadde.etkinMaddeKodu + " kodlu " + drugDefinition.EtkinMadde.etkinMaddeAdi + "  etken maddesini içeren aktif bir ilaç raporu bulunamadı. Lütfen etken maddeye uygun rapor yazınız.");
                            }
                            else
                                throw new Exception("Hastanın raporu bulunamadı.");
                        }
                        else
                            throw new Exception(response.sonucAciklamasi);
                    }
                    else
                        throw new Exception(response.sonucAciklamasi);
                }
                else
                    throw new Exception(drugDefinition.Name + " ilacının Etkin Maddesi tanımlı değil.Eczane ile görüşünüz");

                return output;
            }
        }

        public class UpgradeDrugOrderDVO
        {
            public DrugOrderIntroductionGridViewModel oldDrugOrderIntroductionGridViewModel { get; set; }
            public HospitalTimeSchedule newHospitalTimeSchedule { get; set; }
            public double newDoseAmount { get; set; }
            public string newUsageNote { get; set; }
            public List<HospitalTimeSchedule> timeScheduleDataSource { get; set; }
            public List<DrugOrderDetail> drugOrderDetails { get; set; }
        }

        public class PrepareInteraction_Input
        {
            public List<Guid> drugList { get; set; }
            public Guid episodeID { get; set; }
        }

        public class PrepareInteraction_Output
        {
            public List<InteractionDTO> drugDrugInteractions { get; set; }
            public List<InteractionDTO> drugFoodInteractions { get; set; }
        }

        public class InteractionDTO
        {
            public string Header { get; set; }
            public string Color { get; set; }
            public string Message { get; set; }
        }

        [HttpPost]
        public PrepareInteraction_Output PrepareInteraction(PrepareInteraction_Input input)
        {
            PrepareInteraction_Output output = new PrepareInteraction_Output();
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugDrugInteraction> drugDrugInteractions = new List<DrugDrugInteraction>();
                List<DrugFoodInteraction> drugFoodInteractions = new List<DrugFoodInteraction>();
                output.drugDrugInteractions = new List<InteractionDTO>();
                output.drugFoodInteractions = new List<InteractionDTO>();
                DateTime startDate = new DateTime(Common.RecTime().Year, Common.RecTime().Month, Common.RecTime().Day, 0, 0, 0);
                DateTime endDate = new DateTime(Common.RecTime().Year, Common.RecTime().Month, Common.RecTime().Day, 23, 59, 59);
                BindingList<DietOrder.GetDietMaterials_Class> foodList = DietOrder.GetDietMaterials(input.episodeID, startDate, endDate);
                Dictionary<DrugDefinition, List<Guid>> interactionDic = new Dictionary<DrugDefinition, List<Guid>>();
                for (int i = 0; i < input.drugList.Count; i++)
                {
                    DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject(input.drugList[i], typeof(DrugDefinition));
                    List<Guid> checkDrugList = new List<Guid>();
                    for (int s = i + 1; s < input.drugList.Count; s++)
                    {
                        checkDrugList.Add(input.drugList[s]);
                    }
                    interactionDic.Add(drugDefinition, checkDrugList);
                    foreach (DrugFoodInteraction drugFoodInteraction in drugDefinition.DrugFoodInteractions.Select(string.Empty))
                    {
                        if (foodList.Where(x => x.ObjectID == drugFoodInteraction.DietMaterialDefinition.ObjectID).Any())
                            drugFoodInteractions.Add(drugFoodInteraction);
                    }
                }

                foreach (KeyValuePair<DrugDefinition, List<Guid>> interaction in interactionDic)
                {
                    foreach (DrugDrugInteraction drugDrugInteraction in interaction.Key.DrugDrugInteractions.Select(string.Empty))
                        if (interaction.Value.Contains(drugDrugInteraction.InteractionDrug.ObjectID))
                            drugDrugInteractions.Add(drugDrugInteraction);
                }

                foreach (DrugDrugInteraction ddi in drugDrugInteractions)
                {
                    InteractionDTO interactionDTO = new InteractionDTO();
                    interactionDTO.Header = ddi.DrugDefinition.Name + " - " + ddi.InteractionDrug.Name;
                    if (ddi.InteractionLevelType == InteractionLevelTypeEnum.High)
                        interactionDTO.Color = "red";
                    else if (ddi.InteractionLevelType == InteractionLevelTypeEnum.Medium)
                        interactionDTO.Color = "blue";
                    else
                        interactionDTO.Color = "green";
                    interactionDTO.Message = ddi.Message;
                    output.drugDrugInteractions.Add(interactionDTO);
                }

                foreach (DrugFoodInteraction dfi in drugFoodInteractions)
                {
                    InteractionDTO interactionDTO = new InteractionDTO();
                    interactionDTO.Header = dfi.DrugDefinition.Name + " - " + dfi.DietMaterialDefinition.MaterialName;
                    if (dfi.InteractionLevelType == InteractionLevelTypeEnum.High)
                        interactionDTO.Color = "red";
                    else if (dfi.InteractionLevelType == InteractionLevelTypeEnum.Medium)
                        interactionDTO.Color = "blue";
                    else
                        interactionDTO.Color = "green";
                    interactionDTO.Message = dfi.Message;
                    output.drugFoodInteractions.Add(interactionDTO);
                }
            }
            return output;
        }

        public class UpdateTransferableDrugOrders_Input
        {
            public List<TTObjectClasses.DrugReturnAction.GetReturnableDrugOrders_Output> transferableDrugOrders { get; set; }
        }

        [HttpPost]
        public string UpdateTransferableDrugOrders(UpdateTransferableDrugOrders_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                string output = string.Empty;
                if (input.transferableDrugOrders != null && input.transferableDrugOrders.Count > 0)
                {
                    foreach (TTObjectClasses.DrugReturnAction.GetReturnableDrugOrders_Output order in input.transferableDrugOrders)
                    {
                        DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(order.objectID, typeof(DrugOrder));
                        drugOrder.IsTransfered = true;
                    }
                    try
                    {
                        objectContext.Save();
                        output = "Transfer edilecek ilaç direktiflerinin seçimi yapıldı.";
                    }
                    catch (Exception ex)
                    {
                        output = ex.Message;
                    }
                }
                objectContext.Dispose();
                return output;
            }
        }

        public string CheckSameDrugToKschedule(DrugOrderIntroductionFormViewModel model, InPatientPhysicianApplication application)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                string output = string.Empty;
                if (TTObjectClasses.SystemParameter.GetParameterValue("CHECKSAMEDRUGTOKSCHEDULE", "TRUE") == "TRUE")
                {
                    DateTime startDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 00:00:00");
                    DateTime endDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");
                    BindingList<KSchedule> activeKschedules = KSchedule.GetActiveKSchedule(objectContext, application.ObjectID, startDate, endDate);
                    List<string> materialList = model.DrugOrderIntroductionGridViewModelDTO.Select(x => x.Material.drugObjectId).ToList();
                    foreach (KSchedule kSchedule in activeKschedules)
                    {
                        foreach (KScheduleMaterial kScheduleMaterial in kSchedule.KScheduleMaterials)
                        {
                            if (kScheduleMaterial.Status == StockActionDetailStatusEnum.New)
                            {
                                if (materialList.Contains(kScheduleMaterial.Material.ObjectID.ToString()))
                                {
                                    output = output + kScheduleMaterial.Material.Name + " isimli ilaç";
                                }
                            }
                        }

                        foreach (KScheduleInfectionDrug kScheduleInfection in kSchedule.KScheduleInfectionDrugs)
                        {
                            if (materialList.Contains(kScheduleInfection.Material.ObjectID.ToString()))
                            {
                                output = output + kScheduleInfection.Material.Name + " isimli ilaç";
                            }
                        }

                        foreach (KSchedulePatienOwnDrug kSchedulePatientOwn in kSchedule.KSchedulePatienOwnDrugs)
                        {
                            if (kSchedulePatientOwn.StockActionStatus == StockActionDetailStatusEnum.New)
                            {
                                if (materialList.Contains(kSchedulePatientOwn.Material.ObjectID.ToString()))
                                {
                                    output = output + kSchedulePatientOwn.Material.Name + " isimli ilaç";
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(output) == false)
                            output = output + " mevcut eczane isteği bulunmaktadır. İşlem No:" + kSchedule.StockActionID.ToString();
                    }
                }

                return output;
            }
        }
    }
}