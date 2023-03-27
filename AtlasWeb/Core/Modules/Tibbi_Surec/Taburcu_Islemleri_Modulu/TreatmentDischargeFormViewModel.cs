//$ECE29B84
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Infrastructure.Helpers;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using static TTObjectClasses.TreatmentDischarge;
using DevExpress.CodeParser;

namespace Core.Controllers
{
    public partial class TreatmentDischargeServiceController
    {
        partial void PreScript_TreatmentDischargeForm(TreatmentDischargeFormViewModel viewModel, TreatmentDischarge treatmentDischarge, TTObjectContext objectContext)
        {

            if (treatmentDischarge.InPatientTreatmentClinicApp == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    InPatientTreatmentClinicApplication inPatientTreatmentClinicApp = null;
                    if (episodeAction is InPatientPhysicianApplication)
                    {
                        inPatientTreatmentClinicApp = ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp;
                    }
                    else if (episodeAction is NursingApplication)
                    {
                        inPatientTreatmentClinicApp = ((NursingApplication)episodeAction).InPatientTreatmentClinicApp;
                    }
                    else if (episodeAction is InPatientTreatmentClinicApplication)
                    {
                        inPatientTreatmentClinicApp = ((InPatientTreatmentClinicApplication)episodeAction);
                    }
                    else
                        throw new Exception(episodeAction.ObjectDef.ApplicationName + " işleminden Taburcu işlemi başlatılamaz");
                    if (inPatientTreatmentClinicApp.CurrentStateDefID != InPatientTreatmentClinicApplication.States.Procedure)
                        throw new Exception(TTUtils.CultureService.GetText("M26973", "Taburcu işlemi ancak aktif bir yatış ekranı üzerinden başlatılabilir"));
                    if (inPatientTreatmentClinicApp.TreatmentDischarge == null)
                    {
                        treatmentDischarge.SetTreatmentDischargePropertiesByMasterEpisodeAction(episodeAction);
                    }

                    viewModel.MasterActionObjectDefName = episodeAction.ObjectDef.Name;
                    viewModel.ClinicInpatientDate = inPatientTreatmentClinicApp.ClinicInpatientDate;
                    //else
                    //{
                    //    treatmentDischarge = inPatientTreatmentClinicApp.TreatmentDischarge;
                    //    viewModel._TreatmentDischarge = inPatientTreatmentClinicApp.TreatmentDischarge;// tretmentDischarge değişince viewModeldeki _TreatmentDischarge değişmiyor.
                    //}
                    objectContext.LoadFormObjects((Guid)treatmentDischarge.CurrentStateDef.FormDefID, treatmentDischarge.ObjectID, treatmentDischarge.ObjectDef.ID);
                    ContextToViewModel(viewModel, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
                else
                {
                    throw new Exception(TTUtils.CultureService.GetText("M26973", "Taburcu işlemi ancak aktif bir yatış ekranı üzerinden başlatılabilir"));
                }
            }

            if (treatmentDischarge.DischargeDate == null || treatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.New)
                treatmentDischarge.DischargeDate = Common.RecTime();
            viewModel.ProcedureDoctorFilterExpression = " USERRESOURCES(RESOURCE = '" + treatmentDischarge.MasterResource.ObjectID.ToString() + "').EXISTS";
            var allDischargeTypeDefinitions = DischargeTypeDefinition.GetAll(objectContext, "");
            viewModel.TransferToOtherClinicDischargeTypeDefinition = allDischargeTypeDefinitions.FirstOrDefault(dr => dr.SKRSCikisSekli.KODU.Trim() == Convert.ToInt16(DischargeTypeEnum.TransferToOtherClinic).ToString());
            viewModel.TransferToOtherHospitalDischargeTypeDefinition = allDischargeTypeDefinitions.FirstOrDefault(dr => dr.SKRSCikisSekli.KODU.Trim() == Convert.ToInt16(DischargeTypeEnum.TransferingToOtherlHospital).ToString());
            viewModel.DischargeTypeFilterExpression = "  OBJECTID NOT IN (";
            if (viewModel.TransferToOtherClinicDischargeTypeDefinition != null)
                viewModel.DischargeTypeFilterExpression += "'" + viewModel.TransferToOtherClinicDischargeTypeDefinition.ObjectID.ToString() + "'";
            if (viewModel.TransferToOtherClinicDischargeTypeDefinition != null && viewModel.TransferToOtherHospitalDischargeTypeDefinition != null)
                viewModel.DischargeTypeFilterExpression += ",";
            if (viewModel.TransferToOtherHospitalDischargeTypeDefinition != null)
                viewModel.DischargeTypeFilterExpression += "'" + viewModel.TransferToOtherHospitalDischargeTypeDefinition.ObjectID.ToString() + "'";
            viewModel.DischargeTypeFilterExpression += ")";
            viewModel.isSGKSubEpisode = SubEpisode.IsSGKSubEpisode(treatmentDischarge.SubEpisode);
            viewModel.TreatmentDischargeProblemList = treatmentDischarge.CheckProblemsAndAddToViewModel();
            viewModel.IsAllRequiredProblemsOk = treatmentDischarge.IsAllRequiredProblemsOk(viewModel.TreatmentDischargeProblemList);


            viewModel.SKRSCikisSeklis = SKRSCikisSekli.GetAllSkrsCikisSekli(objectContext, "").ToArray();

            //Hastada başlatılmış morg işlemi olup olmadığını tutmak için eklendi
            foreach (BaseAction action in treatmentDischarge.LinkedActions)
            {
                if (action is Morgue && !action.IsCancelled)
                {
                    viewModel.HasMorgue = true;
                    break;
                }
            }

            DischargeTypeDefinition[] dischargeTypeArray = DischargeTypeDefinition.GetDischargeTypeBySkrsCikisSekli(objectContext, 6).ToArray();
            if (dischargeTypeArray.Length > 0)
                viewModel.DeathDefinition = dischargeTypeArray[0];

            viewModel.advanceToDischarge = false;
            viewModel.SubepisodeID = viewModel._TreatmentDischarge.SubEpisode.ObjectID.ToString();
            if (Common.CurrentResource.TakesPerformanceScore == true)
            {
                viewModel.ProcedureDoctorObjectIDForOBS = Common.CurrentResource.ObjectID.ToString();

            }
            else
            {
                viewModel.ProcedureDoctorObjectIDForOBS = viewModel._TreatmentDischarge.ProcedureDoctor.ObjectID.ToString();
            }


        }

        partial void PostScript_TreatmentDischargeForm(TreatmentDischargeFormViewModel viewModel, TreatmentDischarge treatmentDischarge, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if((TTObjectClasses.SystemParameter.GetParameterValue("TABURCULUKSAATKONTROL", "FALSE")) == "TRUE")
            {
                string timeRange = TTObjectClasses.SystemParameter.GetParameterValue("TABURCULUKSAATARALIGI", "00:00-23:59");
                string[] splittedTime = timeRange.Split("-");
                string[] startTimeHours = splittedTime[0].Split(":");
                string[] endTimeHours = splittedTime[1].Split(":");

                DateTime startTime = Common.RecTime();
                DateTime endTime = Common.RecTime();
                TimeSpan ts = new TimeSpan(Int32.Parse(startTimeHours[0]), Int32.Parse(startTimeHours[1]), 0);
                startTime = startTime.Date + ts;
                ts = new TimeSpan(Int32.Parse(endTimeHours[0]), Int32.Parse(endTimeHours[1]), 0);
                endTime = endTime.Date + ts;

                if (Common.RecTime() < startTime || Common.RecTime() > endTime)
                {
                    throw new Exception("Taburcu Etme işlemi " + splittedTime[0] + " ile " + splittedTime[1] + " saatleri arasında yapılabilir.");
                }
            }

            viewModel.advanceToDischarge = treatmentDischarge.IsAllRequiredProblemsOk(viewModel.TreatmentDischargeProblemList) && viewModel.advanceToDischarge; // Listenin Taburcu listesi tamamlanmış ve Taburcu butonuna basılmamış ise taburcuya alınır


            treatmentDischarge.InPatientTreatmentClinicApp.TreatmentDischarge = treatmentDischarge; // Prede set edilsede InPatientTreatmentClinicApp kaydedilmediği için kayboluyor
            if (transDef == null)
            {
                if (treatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.New)
                    throw new Exception(TTUtils.CultureService.GetText("M27231", "Yeni adımındaki tedavi işlemi İletletilmek zorundadır kaydet edilemez"));
            }
            else if (transDef.ToStateDef.Status != StateStatusEnum.Cancelled)
            {
                if (treatmentDischarge.DischargeDate == null)
                    throw new Exception(TTUtils.CultureService.GetText("M26977", "Taburcu Tarihi alanı boş geçilemez"));
                if (treatmentDischarge.DischargeType == null)
                    throw new Exception(TTUtils.CultureService.GetText("M26981", "Taburcu Tipi alanı boş geçilemez"));

                treatmentDischarge.CheckDatesByDischargeDate();


                treatmentDischarge.InPatientTreatmentClinicApp.ClinicDischargeDate = treatmentDischarge.DischargeDate;

                if (treatmentDischarge.GetMyDischargeTypeEnum() == DischargeTypeEnum.TransferToOtherClinic)
                {
                    if (treatmentDischarge.TransferTreatmentClinic == null)
                        throw new Exception(TTUtils.CultureService.GetText("M26854", "Sevk Edileceği Klinik alanı boş geçilemez"));
                }

                // Limit Kontrolü
                if (transDef.ToStateDefID == TreatmentDischarge.States.PreDischarge)
                {
                    if (viewModel.advanceToDischarge)// Direk Taburcu edilecek hastaların Limit kontrolü gerekmiyor
                    {
                        treatmentDischarge.CheckDischargeLimit();
                        //int? predischageLimit = null;
                        //if (TTObjectClasses.SystemParameter.GetParameterValue("GETPREDISCHAGERLIMITBYPROCEDUREDOCTOR", "FALSE") == "TRUE")
                        //{
                        //    predischageLimit = treatmentDischarge.ProcedureDoctor.PreDischargeLimit;
                        //    if (predischageLimit != null)
                        //    {
                        //        var preDischargedInfoByProcedureDoctorList = TreatmentDischarge.GetPreDischargedInfoByProcedureDoctor(treatmentDischarge.ProcedureDoctor.ObjectID);
                        //        if (preDischargedInfoByProcedureDoctorList.Count > predischageLimit)
                        //        {
                        //            string msg = "";
                        //            foreach (var preDischargedInfoByProcedureDoctor in preDischargedInfoByProcedureDoctorList)
                        //            {
                        //                msg += "\n" + preDischargedInfoByProcedureDoctor.Patientname;
                        //            }

                        //            throw new Exception(TTUtils.CultureService.GetText("M26984", "Taburcuya Karar Veren Tabip için Ön Taburcu limiti dolmuştur .Ön taburcu yapabilmek için  aşağıdaki hastalardan  en az birini taburcu etmelisiniz.") + msg);
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    if (treatmentDischarge.MasterResource is ResClinic)
                        //    {
                        //        predischageLimit = ((ResClinic)treatmentDischarge.MasterResource).PreDischargeLimit;
                        //        if (predischageLimit != null)
                        //        {
                        //            var preDischargedInfoByClinicList = TreatmentDischarge.GetPreDischargedInfoByClinic(treatmentDischarge.MasterResource.ObjectID);
                        //            if (preDischargedInfoByClinicList.Count > predischageLimit)
                        //            {
                        //                string msg = "";
                        //                foreach (var preDischargedInfoByClinic in preDischargedInfoByClinicList)
                        //                {
                        //                    msg += "\n" + preDischargedInfoByClinic.Patientname;
                        //                }

                        //                throw new Exception(TTUtils.CultureService.GetText("M27078", "Tedavi Kliniği için Ön Taburcu limiti dolmuştur .Ön taburcu yapabilmek için  aşağıdaki hastalardan  en az birini taburcu etmelisiniz.") + msg);
                        //            }
                        //        }
                        //    }
                        //}
                    }
                }

                //Morg viewmodeli contexte ekle
                if (viewModel._MorgueViewModel != null && viewModel._MorgueViewModel._Morgue != null)
                {
                    viewModel._MorgueViewModel.AddMorgueViewModelToContext(objectContext, treatmentDischarge);
                }
                //Çıkış şekli değiştirildiyse morg işlemi iptal ediliyor. Methodun içinde dischargetype kontrol edildiği için tekrar eklenmedi
                if (viewModel.HasMorgue)
                {

                    treatmentDischarge.CheckAndCancelMorgue();
                }

                //Sevk viewmodeli contexte ekle
                if (viewModel._DispatchToOtherHospitalFormViewModel != null)
                {

                    DispatchToOtherHospitalServiceController dispatchToOtherHospitalServiceController = new DispatchToOtherHospitalServiceController();
                    dispatchToOtherHospitalServiceController.DispatchToOtherHospitalFormInternal(viewModel._DispatchToOtherHospitalFormViewModel, objectContext, false);
                    var myDispatchToOtherHospital = objectContext.GetObject(viewModel._DispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.ObjectID, "DispatchToOtherHospital") as DispatchToOtherHospital;
                    treatmentDischarge.DispatchToOtherHospital = myDispatchToOtherHospital;
                }
            }
        }

        partial void AfterContextSaveScript_TreatmentDischargeForm(TreatmentDischargeFormViewModel viewModel, TreatmentDischarge treatmentDischarge, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.FromStateDef.StateDefID == TreatmentDischarge.States.New && transDef.ToStateDef.StateDefID == TreatmentDischarge.States.PreDischarge)
                {
                    bool isOnlyPreDischarged = true;
                    viewModel.TreatmentDischargeProblemList = treatmentDischarge.CheckProblemsAndAddToViewModel();
                    if (viewModel.advanceToDischarge)
                    {
                        if (treatmentDischarge.IsAllRequiredProblemsOk(viewModel.TreatmentDischargeProblemList))
                        {
                            treatmentDischarge.CurrentStateDefID = TreatmentDischarge.States.Discharged;
                            isOnlyPreDischarged = false;
                            objectContext.Save();
                        }
                        else if (TTObjectClasses.SystemParameter.GetParameterValue("IGNOREPREDISCHAGERFORCLINICTRANSFER", "FALSE") == "TRUE") //TODO Kurum içi sevk parametrik olarak direk dischagea alınabilir
                        {
                            if (treatmentDischarge.GetMyDischargeTypeEnum() == DischargeTypeEnum.TransferToOtherClinic)
                            {
                                treatmentDischarge.CurrentStateDefID = TreatmentDischarge.States.Discharged;
                                isOnlyPreDischarged = false;
                                objectContext.Save();
                            }
                        }
                    }
                    //else //NİDA sanki yanlışlıkla eklenmiş  KONTROL ET
                    //{
                    //    isOnlyPreDischarged = false;
                    //}

                    if (isOnlyPreDischarged) // Taburcu edilmediyse Öntaburcuda kaldı ise Faturalandırma kontrolü yapılır uyarı verilir  . Taburcu edildiyorsa zaten StatePostda ise Faturalandırma kontrolü yapılır hata verilir 
                    {
                        InpatientAdmission ia = treatmentDischarge.InPatientTreatmentClinicApp.BaseInpatientAdmission as InpatientAdmission;
                        if (ia != null)
                            ia.FinancialControlToDischarge(true);

                        #region Ön taburcu bilgilendirme
                        EpisodeActionServiceController easc = new EpisodeActionServiceController();
                        string _message = treatmentDischarge.Episode.Patient.Name + " " + treatmentDischarge.Episode.Patient.Surname + " isimli takipli hastanın " + treatmentDischarge.SubEpisode.ProtocolNo + " 'lu kabulüne ait ön taburculuk işlemi yapılmıştır";
                        easc.FindTrackingFollowers(treatmentDischarge.Episode.Patient.ObjectID, treatmentDischarge.SubEpisode.ObjectID, true, true, _message, _message, SMSTypeEnum.TreatmentDischargeInfo);
                        easc.Dispose();
                        #endregion
                    }
                }
                viewModel.advanceToDischarge = false;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Taburcu_Islemleri_Problem_Sorgulama)]
        public TreatmentDischargeFormViewModel GetProblems(TreatmentDischargeFormViewModel viewModel)
        {
            var formDefID = Guid.Parse("fc10a117-73ef-436f-84cc-025cf1860430");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.DischargeTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.ResClinics);
                var entryStateID = Guid.Parse("ef074cf1-50ed-45f0-a73b-92eb8dd685a1");
                objectContext.AddToRawObjectList(viewModel._TreatmentDischarge, entryStateID);
                objectContext.ProcessRawObjects();
                var treatmentDischarge = (TreatmentDischarge)objectContext.GetLoadedObject(viewModel._TreatmentDischarge.ObjectID);
                var transDef = treatmentDischarge.TransDef;
                viewModel.TreatmentDischargeProblemList = treatmentDischarge.CheckProblemsAndAddToViewModel();
                viewModel.IsAllRequiredProblemsOk = treatmentDischarge.IsAllRequiredProblemsOk(viewModel.TreatmentDischargeProblemList);
                return viewModel;
            }
        }

        [HttpGet]
        public string OpenOBS(string SubepisodeID, string ProcedureDoctorObjectIDForOBS)
        {
            string returnURL = string.Empty;
            ObsInput input = new ObsInput();
            using (var objectContext = new TTObjectContext(false))
            {
                var subepisode = objectContext.GetObject<SubEpisode>(new Guid(SubepisodeID));
                input.SaglikKurulusuReferansNo = subepisode.Episode.Patient.ID.ToString();
                input.TcKimlikNo = Convert.ToInt64(subepisode.Episode.Patient.UniqueRefNo);
                input.Adi = subepisode.Episode.Patient.Name;
                input.Soyadi = subepisode.Episode.Patient.Surname;
                input.BabaAdi = subepisode.Episode.Patient.FatherName;
                input.AnaAdi = subepisode.Episode.Patient.MotherName;
                input.DogumTarihi = subepisode.Episode.Patient.BirthDate != null ? Convert.ToDateTime(subepisode.Episode.Patient.BirthDate).ToString("dd.MM.yyyy") : null;
                input.OlumZamani = "";
                input.OlumYeri = 0;
                input.OlumSekli = 0;
                input.OlumNedenleri = "";
                input.SysTakipNo = subepisode.SYSTakipNo;
                input.FixedDoctorUniqueID = null;
                input.FixedDoctorObjectID = new Guid(ProcedureDoctorObjectIDForOBS);

                MorgueServiceController c = new MorgueServiceController();
                returnURL = c.OpenOBSWebPage(input);
            }
            return returnURL;
        }

        // WebApilerdede kullanılabilmesi için TreatmentDischarge Classına taşındı

        //public bool IsAllRequiredProblemsOk(List<TreatmentDischargeProblemViewModel> treatmentDischargeProblemList)
        //{
        //    foreach (var problem in treatmentDischargeProblemList)
        //    {
        //        if (problem.IsRequired && !problem.IsOk)
        //            return false;
        //    }

        //    return true;
        //}

        //public void CheckProblemsAndAddToViewModel(TreatmentDischargeFormViewModel viewModel, TreatmentDischarge treatmentDischarge, TTObjectContext objectContext)
        //{
        //    var treatmentDischargeProblemList = new List<TreatmentDischargeProblemViewModel>();
        //    this.AddEpicrisProblemToViewModel(treatmentDischargeProblemList, treatmentDischarge);
        //    this.AddSecDiagnoseProblemToViewModel(treatmentDischargeProblemList, treatmentDischarge);
        //    this.AddSurgeryReportProblemToViewModel(treatmentDischargeProblemList, treatmentDischarge);
        //    this.AddDischargingInstructionPlansProblemToViewModel(treatmentDischargeProblemList, treatmentDischarge);
        //    this.AddDepositMaterialProblemToViewModel(treatmentDischargeProblemList, treatmentDischarge);
        //    // this.AddControlAppointmentProblemToViewModel(treatmentDischargeProblemList, treatmentDischarge);
        //    this.AddDrugOrderProblemToViewModel(treatmentDischargeProblemList, treatmentDischarge);
        //    this.AddPhysiotherapyProblemToViewModel(treatmentDischargeProblemList, treatmentDischarge);
        //    viewModel.TreatmentDischargeProblemList = treatmentDischargeProblemList;
        //}

        //// TreatmentDischargeProblemList oluşturacak Methodlar
        //public void AddEpicrisProblemToViewModel(List<TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList, TreatmentDischarge treatmentDischarge)
        //{
        //    Boolean epicrisisFound = treatmentDischarge.HasEpicrisis();

        //    TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischargeProblemViewModel();
        //    problemViewModel.IsRequired = true;
        //    if (epicrisisFound)
        //    {
        //        problemViewModel.ProblemString = TTUtils.CultureService.GetText("M25591", "Epikriz Var");
        //        problemViewModel.IsOk = true;
        //    }
        //    else
        //    {
        //        problemViewModel.ProblemString = (treatmentDischarge.SubEpisode.Speciality == null ? "" : treatmentDischarge.SubEpisode.Speciality.Name) + " uzmanlık dalı için epikriz yazılmamıştır.";
        //        problemViewModel.IsOk = false;
        //        var inPatientPhysicianApplication = treatmentDischarge.InPatientTreatmentClinicApp.InPatientPhysicianApplication[0];
        //        problemViewModel.ObjectId = inPatientPhysicianApplication.ObjectID;
        //        problemViewModel.ObjectDefName = inPatientPhysicianApplication.ObjectDef.Name;
        //    }

        //    TreatmentDischargeProblemList.Add(problemViewModel);
        //}

        //public void AddSecDiagnoseProblemToViewModel(List<TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList, TreatmentDischarge treatmentDischarge)
        //{
        //    TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischargeProblemViewModel();
        //    problemViewModel.IsRequired = true;
        //    if (treatmentDischarge.Episode.SecDiagnosis.Count == 0)
        //    {
        //        problemViewModel.ProblemString = TTUtils.CultureService.GetText("M26296", "Kesin Tanı girişi yapılmamıştır");
        //        problemViewModel.IsOk = false;
        //        var inPatientPhysicianApplication = treatmentDischarge.InPatientTreatmentClinicApp.InPatientPhysicianApplication[0];
        //        problemViewModel.ObjectId = inPatientPhysicianApplication.ObjectID;
        //        problemViewModel.ObjectDefName = inPatientPhysicianApplication.ObjectDef.Name;
        //    }
        //    else
        //    {
        //        problemViewModel.ProblemString = TTUtils.CultureService.GetText("M26297", "Kesin Tanı girişi yapılmıştır");
        //        problemViewModel.IsOk = true;
        //    }

        //    TreatmentDischargeProblemList.Add(problemViewModel);
        //}

        //public void AddDischargingInstructionPlansProblemToViewModel(List<TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList, TreatmentDischarge treatmentDischarge)
        //{
        //    TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischargeProblemViewModel();
        //    problemViewModel.IsRequired = false;
        //    if (treatmentDischarge.InPatientTreatmentClinicApp.NursingApplications[0].BaseNursingDischargingInstructionPlans.Count == 0)
        //    {
        //        problemViewModel.ProblemString = TTUtils.CultureService.GetText("M25887", "Hastaya Taburculuk Planlama Yapılmamış");
        //        problemViewModel.IsOk = false;
        //        var nursingApplications = treatmentDischarge.InPatientTreatmentClinicApp.NursingApplications[0];
        //        problemViewModel.ObjectId = nursingApplications.ObjectID;
        //        problemViewModel.ObjectDefName = nursingApplications.ObjectDef.Name;
        //    }
        //    else
        //    {
        //        problemViewModel.ProblemString = TTUtils.CultureService.GetText("M25888", "Hastaya Taburculuk Planlama Yapılmamıştır");
        //        problemViewModel.IsOk = true;
        //    }

        //    TreatmentDischargeProblemList.Add(problemViewModel);
        //}

        //public void AddSurgeryReportProblemToViewModel(List<TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList, TreatmentDischarge treatmentDischarge)
        //{
        //    foreach (Surgery surgery in treatmentDischarge.SubEpisode.Surgeries)
        //    {
        //        if (surgery.CurrentStateDefID == Surgery.States.Surgery || surgery.CurrentStateDefID == Surgery.States.SurgeryRequest)
        //        {
        //            TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischargeProblemViewModel();
        //            problemViewModel.IsRequired = true;
        //            problemViewModel.ProblemString = surgery.ID.ToString() + "' işlem no'lu ameliyat işlemi '" + surgery.CurrentStateDef.DisplayText + "' adımında kalmıştır";
        //            problemViewModel.IsOk = false;
        //            problemViewModel.ObjectId = surgery.ObjectID;
        //            problemViewModel.ObjectDefName = surgery.ObjectDef.Name;
        //            TreatmentDischargeProblemList.Add(problemViewModel);
        //        }
        //        foreach (SubSurgery subSurgery in surgery.SubSurgeries)
        //        {
        //            if (subSurgery.CurrentStateDefID == SubSurgery.States.SubSurgeryReport)
        //            {
        //                TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischargeProblemViewModel();
        //                problemViewModel.IsRequired = true;
        //                problemViewModel.ProblemString = subSurgery.ID.ToString() + "' işlem no'lu ek ameliyat işlemi '" + subSurgery.CurrentStateDef.DisplayText + "' adımında kalmıştır";
        //                problemViewModel.IsOk = false;
        //                problemViewModel.ObjectId = subSurgery.ObjectID;
        //                problemViewModel.ObjectDefName = subSurgery.ObjectDef.Name;
        //                TreatmentDischargeProblemList.Add(problemViewModel);
        //            }
        //        }
        //    }
        //}

        //public void AddControlAppointmentProblemToViewModel(List<TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList, TreatmentDischarge treatmentDischarge)
        //{
        //    TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischargeProblemViewModel();
        //    problemViewModel.IsRequired = false;
        //    if (!(treatmentDischarge.GetMyDischargeTypeEnum() == DischargeTypeEnum.TransferToOtherClinic))
        //    {
        //        var appointmentList = AdmissionAppointment.GetActiveAppointmentByPatientAndSpeciality(treatmentDischarge.ObjectContext, treatmentDischarge.Episode.Patient.ObjectID, treatmentDischarge.ProcedureSpeciality.ObjectID);
        //        if (appointmentList.Count == 0)
        //        {
        //            problemViewModel.ProblemString = TTUtils.CultureService.GetText("M26335", "Kontrol Randevusu Planlanmamış");
        //            problemViewModel.IsOk = false;
        //        //problemViewModel.ObjectId = 
        //        //problemViewModel.ObjectDefName = 
        //        }
        //        else
        //        {
        //            problemViewModel.ProblemString = TTUtils.CultureService.GetText("M26336", "Kontrol Randevusu Planlanmış");
        //            problemViewModel.IsOk = true;
        //        }
        //    }
        //}

        //public void AddDepositMaterialProblemToViewModel(List<TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList, TreatmentDischarge treatmentDischarge)
        //{
        //    TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischargeProblemViewModel();
        //    problemViewModel.IsRequired = false;
        //    //var GivenMsg = Episode.GivenValuableMaterialsMsg(treatmentDischarge.Episode);
        //    //var TakenMsg = Episode.TakenValuableMaterialsMsg(treatmentDischarge.Episode);
        //    //string msg = string.Empty;
        //    //if (!string.IsNullOrEmpty(GivenMsg))
        //    //    msg += "Hastaya Geri Verilmemiş Eşyalar";
        //    //if (!string.IsNullOrEmpty(TakenMsg))
        //    //{
        //    //    if (!string.IsNullOrEmpty(msg))
        //    //        msg += " ve ";
        //    //    msg += "Hastaya Fazladan Verilmiş Eşyalar";
        //    //}
        //    var esya_miktar = 0;
        //    foreach (var inpatientAdmissionDepositMaterial in treatmentDischarge.Episode.InpatientAdmissionDepositMaterials)
        //    {
        //        if (inpatientAdmissionDepositMaterial.QuarantineProcessType == QuarantineProcessTypeEnum.GivedToPatient)
        //            esya_miktar--;
        //        else //
        //            esya_miktar++;
        //    }

        //    if (esya_miktar > 0)
        //    {
        //        string msg = " Hastanın emanete bıraktığı eşyalar mevcuttur.";
        //        problemViewModel.ProblemString = msg;
        //        problemViewModel.IsOk = false;
        //        var inPatientTreatmentClinicApp = treatmentDischarge.InPatientTreatmentClinicApp;
        //        problemViewModel.ObjectId = inPatientTreatmentClinicApp.ObjectID;
        //        problemViewModel.ObjectDefName = inPatientTreatmentClinicApp.ObjectDef.Name;
        //        TreatmentDischargeProblemList.Add(problemViewModel);
        //    }
        //}

        //public void AddDrugOrderProblemToViewModel(List<TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList, TreatmentDischarge treatmentDischarge)
        //{
        //    GetReturnDetails details = DrugReturnActionNewFormViewModel.GetReturnableDrugsOnPatient(treatmentDischarge.Episode.ObjectID);// Changed By Murat Date : 30/05/2018

        //    TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischargeProblemViewModel();
        //    problemViewModel.IsRequired = true;
        //    if (details.IsThereAnyReturnableDrugs)
        //    {
        //        problemViewModel.ProblemString = TTUtils.CultureService.GetText("M25858", "Hastanın Üzerinde Uygulanmamış İlaç Bulunmaktadır.");
        //        problemViewModel.IsOk = false;
        //        var nursingApplications = treatmentDischarge.InPatientTreatmentClinicApp.NursingApplications[0];
        //        problemViewModel.ObjectId = nursingApplications.ObjectID;
        //        problemViewModel.ObjectDefName = nursingApplications.ObjectDef.Name;
        //    }
        //    else
        //    {
        //        problemViewModel.ProblemString = "Hastanın Uygulanmamış İlaçı Bulunmamaktadır.";
        //        problemViewModel.IsOk = true;
        //    }

        //    TreatmentDischargeProblemList.Add(problemViewModel);
        //}


        //public void AddPhysiotherapyProblemToViewModel(List<TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList, TreatmentDischarge treatmentDischarge)
        //{
        //    var uncompletedPhysiotherapyRequest = treatmentDischarge.Episode.PhysiotherapyRequests.FirstOrDefault(dr => dr.CurrentStateDef.Status == StateStatusEnum.Uncompleted);


        //    TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischargeProblemViewModel();
        //    problemViewModel.IsRequired = true;
        //    if (uncompletedPhysiotherapyRequest!= null)
        //    {
        //        problemViewModel.ProblemString = "Hastanın '" + uncompletedPhysiotherapyRequest.CurrentStateDef.DisplayText + "' adımında  FTR Tedavisi bulunmaktadır.";
        //        problemViewModel.IsOk = false;
        //        problemViewModel.ObjectId = uncompletedPhysiotherapyRequest.ObjectID;
        //        problemViewModel.ObjectDefName = uncompletedPhysiotherapyRequest.ObjectDef.Name;
        //    }
        //    else
        //    {
        //        problemViewModel.ProblemString = TTUtils.CultureService.GetText("M30114", "Hastanın devam eden FTR Tedavisi yoktur");
        //        problemViewModel.IsOk = true;
        //    }

        //    TreatmentDischargeProblemList.Add(problemViewModel);
        //}


        ////public void AddUnCompletedProcedureProblemToViewModel(List<TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList, TreatmentDischarge treatmentDischarge) 
        ////{
        ////    BindingList<AccountTransaction.GetToBeNewTrxsByEpisode_Class> getToBeNewTrxsByEpisode_ClassList = AccountTransaction.GetToBeNewTrxsByEpisode(treatmentDischarge.ObjectContext, treatmentDischarge.Episode.ObjectID);
        ////    foreach (AccountTransaction.GetToBeNewTrxsByEpisode_Class tahakkuk in getToBeNewTrxsByEpisode_ClassList)
        ////    {
        ////       tahakkuk.TransactionDate + "'-" + tahakkuk.Description + " \r\n";
        ////        count++;
        ////    }
        ////    if (message != "")
        ////    {
        ////        message += "işlemleri uygulandıysa tamamlanmalı, uygulanmadı ise iptal edilmelidir.\r\n";
        ////    }
        ////    return message;
        ////}
        ////[HttpGet]
        ////public DynamicComponentInfoDVO GetDynamicComponentInfo([FromUri]string ObjectId)
        ////{
        ////    DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
        ////    using (TTObjectContext objectContext = new TTObjectContext(false))
        ////    {
        ////        TTObject obj = objectContext.GetObject(new Guid(ObjectId), typeof(EpisodeAction));
        ////        var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
        ////        var folderPath = string.Join("/", subFolders.Reverse());
        ////        var moduleName = obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
        ////        var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
        ////        dynamicComponentInfo.ComponentName = obj.CurrentStateDef.FormDef.CodeName;
        ////        dynamicComponentInfo.ModuleName = moduleName;
        ////        dynamicComponentInfo.ModulePath = modulePath;
        ////        dynamicComponentInfo.objectID = ObjectId;
        ////        objectContext.FullPartialllyLoadedObjects();
        ////        return dynamicComponentInfo;
        ////    }
        ////}
    }
}

namespace Core.Models
{

    public partial class TreatmentDischargeFormViewModel
    {
        public List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList = new List<TreatmentDischarge.TreatmentDischargeProblemViewModel>();
        public bool IsAllRequiredProblemsOk;
        public bool isSGKSubEpisode;
        public string ProcedureDoctorFilterExpression;
        public DischargeTypeDefinition TransferToOtherClinicDischargeTypeDefinition;
        public DischargeTypeDefinition TransferToOtherHospitalDischargeTypeDefinition;
        public string DischargeTypeFilterExpression;
        //Eklendi
        public DateTime? ClinicInpatientDate;
        public string MasterActionObjectDefName;
        public MorgueExDischargeFormViewModel _MorgueViewModel = new MorgueExDischargeFormViewModel();
        public TTObjectClasses.SKRSCikisSekli[] SKRSCikisSeklis { get; set; }
        public bool HasMorgue = false;
        public DischargeTypeDefinition DeathDefinition = new DischargeTypeDefinition();
        public DispatchToOtherHospitalFormViewModel _DispatchToOtherHospitalFormViewModel;
        public string SubepisodeID { get; set; }
        public string ProcedureDoctorObjectIDForOBS;

        public bool advanceToDischarge = false;// discharge butonuna basılıp basılmadığını  Client'dan taşıyan property // discharge 'a geçecekmi yoksa predischargeda mı kalacak bilgisini aftercontexsave methoduna taşıyan property

    }

    // WebApilerdede kullanılabilmesi için TreatmentDischarge Classına taşındı
    //public partial class TreatmentDischargeProblemViewModel
    //{
    //    public string ProblemString;
    //    public bool IsOk;
    //    public bool IsRequired;
    //    public Guid? ObjectId;
    //    public string ObjectDefName;
    //    public Guid? FormDefId;
    //}

    //public partial class TreatmentDischargeDefaultActionViewModel
    //{
    //    public Guid? ObjectId;
    //    public string ObjectDefName;
    //    public string ApplicationName;
    //    public Guid? FormDefId;
    //    public Object InputParam;
    //}
}