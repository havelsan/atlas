//$8C3C3E1A
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using TTStorageManager.Security;

namespace Core.Controllers
{
    public partial class HealthCommitteeServiceController
    {
        partial void PreScript_HCExaminationForm(HCExaminationFormViewModel viewModel, HealthCommittee healthCommittee, TTObjectContext objectContext)
        {
            //if (viewModel._HealthCommittee.Ration == null)
            //    viewModel._HealthCommittee.Ration = PositiveNegativeEnum.Positive;
            if (viewModel._HealthCommittee.HCRequestReason != null && viewModel._HealthCommittee.HCRequestReason.ReasonForExamination != null && viewModel._HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition != null)
            {
                viewModel.IsDisabled = viewModel._HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true ? true : false;
            }

            if (viewModel.IsDisabled)
            {
                double? ratio = HealthCommittee.CalculateFunctionRatio(viewModel._HealthCommittee);
                if (ratio != null)
                    viewModel._HealthCommittee.FunctionRatio = ratio;
            }

            if (HealthCommittee.UnCompletedExaminationExists(viewModel._HealthCommittee))
                viewModel.UnCompletedExaminationExists = true;
            else
                viewModel.UnCompletedExaminationExists = false;
            if (HealthCommittee.CheckIfAllCancelledOrNotExists(viewModel._HealthCommittee))
                throw new TTUtils.TTException(SystemMessage.GetMessage(486));
            viewModel.IntendedUseEvaluationParameter = TTObjectClasses.SystemParameter.GetParameterValue("HCREPORTINTENDEDUSEEVALUATION", null);
            if (viewModel._HealthCommittee.ReportDiagnosis == null)
            {
                IList diagnosisCodeList = new List<string>();
                foreach (DiagnosisGrid diagnose in healthCommittee.Episode.Diagnosis)
                {
                    if (diagnose.DiagnoseCode.Trim() != "Z13.9") // Z13.9 tanısı gride eklenmeyecek
                    {
                        if (!diagnosisCodeList.Contains(diagnose.Diagnose.Code)) // Gridde olan tanılar tekrar eklenmeyecek
                        {
                            viewModel._HealthCommittee.ReportDiagnose += "(" + diagnose.EpisodeAction.MasterResource.ToString() + ")" + diagnose.Diagnose.Code + "." + diagnose.Diagnose.Name + "<br /> ";
                            diagnosisCodeList.Add(diagnose.Diagnose.Code);
                        }
                    }
                }
            }

            if (viewModel._HealthCommittee.SystemForHealthCommitteeGrid.Count == 0)
            {
                viewModel.SystemForHealthCommitteList = new List<SystemForHealthCommitteeGridListViewModel>();
                ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(healthCommittee);
                string _tempDecision = string.Empty;
                foreach (EpisodeAction eaction in arrList)
                {
                    if (eaction is PatientExamination && ((PatientExamination)eaction).PatientExaminationType == PatientExaminationEnum.HealthCommittee && !eaction.IsCancelled && eaction.CurrentStateDefID != PatientExamination.States.PatientNoShown)
                    {
                        PatientExamination exam = (PatientExamination)eaction;
                        if (!exam.CurrentStateDefID.Equals(PatientExamination.States.PatientNoShown))
                        {
                            if (viewModel.IsDisabled)
                            {
                                IList<SystemForDisabledReportDefinition> sdrList = SystemForDisabledReportDefinition.GetAllSystemForDisabledReportDef(healthCommittee.ObjectContext);
                                foreach (SystemForDisabledReportDefinition sdr in sdrList)
                                {
                                    foreach (DisabledReportSpecialGrid disabledReportSpecial in sdr.DisabledReport)
                                    {
                                        if (disabledReportSpecial.Speciality.ObjectID == exam.ProcedureSpeciality.ObjectID)
                                        {
                                            SystemForHealthCommitteeGridListViewModel system = new SystemForHealthCommitteeGridListViewModel();
                                            system.DisabledOfferDecision = exam.HCExaminationComponent.OfferOfDecision;
                                            system.DisabledRatio = exam.HCExaminationComponent.DisabledRatio;
                                            system.SystemForDisabled = sdr.Name;
                                            system.SystemForDisabledID = sdr.ObjectID;
                                            viewModel.SystemForHealthCommitteList.Add(system);
                                        }
                                    }
                                }
                            }

                            if (exam.HCExaminationComponent.OfferOfDecision != null)
                            {
                                _tempDecision += "<b>" + exam.MasterResource.Name + " / " + exam.ProcedureDoctor.Name + "</b><br />";
                                _tempDecision += "&emsp;" + exam.HCExaminationComponent.OfferOfDecision + "<br /><br />";
                            }

                            if (exam.HCExaminationComponent.ClinicalInfo != null && viewModel._HealthCommittee.ClinicalFindings == null)
                                viewModel._HealthCommittee.ClinicalFindings += exam.HCExaminationComponent.ClinicalInfo + "\n";
                        }
                    }
                }
                if (viewModel._HealthCommittee.HealthCommitteeDecision == null)
                    viewModel._HealthCommittee.HealthCommitteeDecision += _tempDecision;
            }
            else
            {
                viewModel.SystemForHealthCommitteList = new List<SystemForHealthCommitteeGridListViewModel>();
                foreach (SystemForHealthCommitteeGrid systemForHealthCommittee in viewModel._HealthCommittee.SystemForHealthCommitteeGrid)
                {
                    SystemForHealthCommitteeGridListViewModel system = new SystemForHealthCommitteeGridListViewModel();
                    system.DisabledOfferDecision = systemForHealthCommittee.DisabledOfferDecision;
                    system.DisabledRatio = systemForHealthCommittee.DisabledRatio != null ? Convert.ToDouble(systemForHealthCommittee.DisabledRatio) : 0;
                    system.SystemForDisabled = systemForHealthCommittee.SystemForDisabled.Name;
                    system.SystemForDisabledID = systemForHealthCommittee.SystemForDisabled.ObjectID;
                    viewModel.SystemForHealthCommitteList.Add(system);
                }
            }

            viewModel.SpecialityDefinitionsList = SpecialityDefinition.GetSpecialityDefByLastUpdateDate(objectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).OrderBy(x => x.Name).ToArray();

            if (viewModel.Patients[0].Weight != null)
                healthCommittee.HCWeight = viewModel.Patients[0].Weight;
            if (viewModel.Patients[0].Heigth != null)
                healthCommittee.HCHeight = viewModel.Patients[0].Heigth;

            if (healthCommittee.HCWeight != null && healthCommittee.HCHeight != null)
            {
                healthCommittee.BodyMassIndex = Math.Round((decimal)(healthCommittee.HCWeight / (healthCommittee.HCHeight * healthCommittee.HCHeight)*10000),2).ToString();

            }

            //Sağlık Kurulu Ek Alanlar 
            viewModel.HCExaminationInfoList = new List<HCExaminationInfo>();
            foreach (var _patientExamination in healthCommittee.LinkedActions)
            {
                if (_patientExamination is PatientExamination && _patientExamination.CurrentStateDefID != PatientExamination.States.Cancelled)
                {
                    foreach (var _baseHCEDynamics in ((PatientExamination)_patientExamination).BaseHCEDynamics)
                    {
                        HCExaminationInfo _hCExaminationInfo = new HCExaminationInfo
                        {
                            ObjectId = _baseHCEDynamics.ObjectID,
                            ObjectDefName = _baseHCEDynamics.ObjectDef!=null?_baseHCEDynamics.ObjectDef.Name:"",
                            MasterResource = _baseHCEDynamics.PatientExamination.MasterResource!=null?_baseHCEDynamics.PatientExamination.MasterResource.Name:"",
                            ProcedureDoctor = _baseHCEDynamics.PatientExamination.ProcedureDoctor!=null?_baseHCEDynamics.PatientExamination.ProcedureDoctor.Name:"",
                            ExaminationDate = _baseHCEDynamics.PatientExamination.ProcessDate!=null?_baseHCEDynamics.PatientExamination.ProcessDate.Value.ToShortDateString():""
                        };
                        if (_baseHCEDynamics.CurrentStateDef != null && _baseHCEDynamics.CurrentStateDef.FormDefID != null)
                        {
                            _hCExaminationInfo.FormDefId = _baseHCEDynamics.CurrentStateDef.FormDefID.ToString();
                        }
                        else
                        {
                            if (_baseHCEDynamics.ObjectDef.FormDefs != null)
                            {
                                _hCExaminationInfo.FormDefId = _baseHCEDynamics.ObjectDef.FormDefs.Values.FirstOrDefault().FormDefID.ToString();
                            }
                            else
                            {
                                //throw Exception;
                            }
                        }
                        if (((PatientExamination)_patientExamination).HCExaminationComponent.ObjectID != null)
                        {
                            HCExaminationComponent _hCExaminationComponent = objectContext.GetObject<HCExaminationComponent>(((PatientExamination)_patientExamination).HCExaminationComponent.ObjectID);
                            _hCExaminationInfo.OfferOfDecision = _hCExaminationComponent.OfferOfDecision;
                            _hCExaminationInfo.TreatmentInfo = _hCExaminationComponent.TreatmentInfo;
                            _hCExaminationInfo.ClinicalInfo = _hCExaminationComponent.ClinicalInfo;
                            _hCExaminationInfo.RadiologicalInfo = _hCExaminationComponent.RadiologicalInfo;
                            _hCExaminationInfo.LabrotoryInfo = _hCExaminationComponent.LaboratoryInfo;
                        }

                        viewModel.HCExaminationInfoList.Add(_hCExaminationInfo);
                    }
                }
            }

            //Konsultasyon
            viewModel.HCConsultationInfoList = new List<ConsultationInfo>();

            var tempList = Consultation.GetConsultationResultByHCID(objectContext, viewModel._HealthCommittee.ObjectID);
            foreach (var temp in tempList)
            {
                ConsultationInfo ci = new ConsultationInfo();

                ci.ObjectId = temp.ObjectID.Value;
                ci.MasterResource = temp.Masterresource;
                ci.ProcedureDoctor = temp.Proceduredoctor;
                ci.ConsultationResult = objectContext.GetObject<Consultation>(ci.ObjectId).ConsultationResultAndOffers;
                //ci.ConsultationResultSummary = ci.ConsultationResult.Length > 100 ? ci.ConsultationResult.Substring(0, 100) : ci.ConsultationResult;
                ci.ProcessDate = temp.ProcessDate != null ? temp.ProcessDate.Value.ToString("dd.MM.yyy") : "";

                viewModel.HCConsultationInfoList.Add(ci);

            }

            if (viewModel._HealthCommittee.CurrentStateDefID == HealthCommittee.States.Completed)
            {
                viewModel.hasUndoTransRight = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Saglik_Kurulu_Tamamlanan_Islem_Geri_Alma);
            }
            else
                viewModel.hasUndoTransRight = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Saglik_Kurulu_Islem_Geri_Alma);

            #region ANAMNESİS
            ArrayList _arrList = EpisodeAction.GetLinkedEpisodeActions(healthCommittee);

            foreach (EpisodeAction eaction in _arrList)
            {
                if (eaction is PatientExamination && ((PatientExamination)eaction).PatientExaminationType == PatientExaminationEnum.HealthCommittee && !eaction.IsCancelled && eaction.CurrentStateDefID != PatientExamination.States.PatientNoShown)
                {
                    PatientExamination exam = (PatientExamination)eaction;

                    viewModel.anamnesisFormViewModel._PhysicianApplication = new PhysicianApplication();
                    viewModel.anamnesisFormViewModel._PhysicianApplication = (PatientExamination)exam;
                    viewModel.anamnesisFormViewModel.vitalSingsViewModel = healthCommittee.GetVitalSingsFormViewModel(objectContext);
                    viewModel.anamnesisFormViewModel.PatientID = healthCommittee.Episode.Patient.ObjectID;

                    break;
                }
            }



            #endregion

            var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, viewModel._HealthCommittee.ObjectDef.ID, "HCExaminationTemplate").ToList();
            viewModel.userTemplateList = new List<UserTemplateModel>();
            foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList)//.Where(t => t.TAObjectID.ToString() != viewModel._HealthCommittee.ObjectID.ToString())
            {
                UserTemplateModel templateModel = new UserTemplateModel();
                templateModel.ObjectID = item.ObjectID;
                templateModel.TAObjectID = item.TAObjectID;
                templateModel.TAObjectDefID = item.TAObjectDefID;
                templateModel.Description = item.Description;
                viewModel.userTemplateList.Add(templateModel);
            }

        }

        partial void PostScript_HCExaminationForm(HCExaminationFormViewModel viewModel, HealthCommittee healthCommittee, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {   if (transDef != null && transDef.FromStateDefID == HealthCommittee.States.Report && transDef.ToStateDefID == HealthCommittee.States.Completed)
                healthCommittee.ReportDate = DateTime.Now;

            if (healthCommittee.SystemForHealthCommitteeGrid.Count == 0 && viewModel.SystemForHealthCommitteList != null && viewModel.SystemForHealthCommitteList.Count > 0)
            {
                foreach (SystemForHealthCommitteeGridListViewModel systemForHealthCommitte in viewModel.SystemForHealthCommitteList)
                {
                    SystemForHealthCommitteeGrid systemForHealthCommitteeGrid = new SystemForHealthCommitteeGrid(healthCommittee.ObjectContext);
                    SystemForDisabledReportDefinition systemForDisabledReportDef = objectContext.GetObject(systemForHealthCommitte.SystemForDisabledID, typeof(SystemForDisabledReportDefinition)) as SystemForDisabledReportDefinition;
                    systemForHealthCommitteeGrid.SystemForDisabled = systemForDisabledReportDef;
                    systemForHealthCommitteeGrid.DisabledOfferDecision = systemForHealthCommitte.DisabledOfferDecision;
                    systemForHealthCommitteeGrid.DisabledRatio = systemForHealthCommitte.DisabledRatio != null ? systemForHealthCommitte.DisabledRatio.ToString() : null;
                    healthCommittee.SystemForHealthCommitteeGrid.Add(systemForHealthCommitteeGrid);
                }
            }
        }

        [HttpGet]
        public bool IsDisabledReport(Guid HCRequestReasonID)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                bool disabled = false;
                HCRequestReason hcRequestReason = context.GetObject(HCRequestReasonID, typeof(HCRequestReason)) as HCRequestReason;
                if (hcRequestReason.ReasonForExamination != null && hcRequestReason.ReasonForExamination.HCReportTypeDefinition != null)
                {
                    disabled = hcRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true ? true : false;
                }

                return disabled;
            }
        }

        [HttpPost]
        public List<UserTemplateModel> SaveHcExaminationtUserTemplate(UserTemplateModel userTemplate)
        {
            List<UserTemplateModel> userTemplatesList = new List<UserTemplateModel>();

            using (var objectContext = new TTObjectContext(false))
            {
                if (userTemplate.ObjectID != null)
                {
                    UserTemplate oldUserTemplate = objectContext.GetObject<UserTemplate>((Guid)userTemplate.ObjectID);
                    oldUserTemplate.FiliterData = "DELETED-HCExaminationTemplate";
                }
                else
                {
                    UserTemplate newUserTemplate = new UserTemplate(objectContext);
                    newUserTemplate.TAObjectDefID = userTemplate.TAObjectDefID;
                    newUserTemplate.TAObjectID = userTemplate.TAObjectID;
                    newUserTemplate.FiliterData = "HCExaminationTemplate";
                    newUserTemplate.ResUser = Common.CurrentResource;
                    newUserTemplate.Description = userTemplate.Description;
                }

                objectContext.Save();
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, (Guid)userTemplate.TAObjectDefID, "HCExaminationTemplate").ToList();
                foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList)
                {
                    UserTemplateModel templateModel = new UserTemplateModel();
                    templateModel.ObjectID = item.ObjectID;
                    templateModel.TAObjectID = item.TAObjectID;
                    templateModel.TAObjectDefID = item.TAObjectDefID;
                    templateModel.Description = item.Description;
                    userTemplatesList.Add(templateModel);
                }
            }
            return userTemplatesList;
        }

        [HttpGet]
        public HealthCommittee GetHCExaminationFormTemplate(string TAObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (!string.IsNullOrEmpty(TAObjectID))
                {
                    HealthCommittee templateHelathCommittee = objectContext.GetObject<HealthCommittee>(new Guid(TAObjectID));

                    //_healthcommittee.HealthCommitteeDecision = templateHelathCommittee.HealthCommitteeDecision;
                    //_healthcommittee

                    //viewModel._HealthCommittee = _healthcommittee;
                    //viewModel._HealthCommittee = templateHelathCommittee;

                    objectContext.FullPartialllyLoadedObjects();

                    return templateHelathCommittee;

                }
                return null;
                    

                
            }
        }



    }
}

namespace Core.Models
{
    public partial class HCExaminationFormViewModel
    {
        public bool IsDisabled
        {
            get;
            set;
        }

        public bool UnCompletedExaminationExists
        {
            get;
            set;
        }

        public string IntendedUseEvaluationParameter
        {
            get;
            set;
        }

        public List<SystemForHealthCommitteeGridListViewModel> SystemForHealthCommitteList
        {
            get;
            set;
        }

        public SpecialityDefinition[] SpecialityDefinitionsList
        {
            get;
            set;
        }

        public List<HCExaminationInfo> HCExaminationInfoList { get; set; }

        public List<ConsultationInfo> HCConsultationInfoList { get; set; }

        public bool hasUndoTransRight { get; set; }

        public AnamnesisFormViewModel anamnesisFormViewModel = new AnamnesisFormViewModel();

        public List<UserTemplateModel> userTemplateList { get; set; }
        public UserTemplateModel selectedUserTemplate { get; set; }
    }

    public partial class SystemForHealthCommitteeGridListViewModel
    {
        public string DisabledOfferDecision
        {
            get;
            set;
        }

        public double? DisabledRatio
        {
            get;
            set;
        }

        public string SystemForDisabled
        {
            get;
            set;
        }

        public Guid SystemForDisabledID
        {
            get;
            set;
        }
    }

    public class HCExaminationInfo
    {
        public Guid ObjectId { get; set; }
        public string ObjectDefName { get; set; }
        public string FormDefId { get; set; }

        public string MasterResource { get; set; }
        public string ProcedureDoctor { get; set; }
        public string ExaminationDate { get; set; }
        public string OfferOfDecision { get; set; }
        public string TreatmentInfo { get; set; }
        public string ClinicalInfo { get; set; }
        public string RadiologicalInfo { get; set; }
        public string LabrotoryInfo { get; set; }
    }

    public class ConsultationInfo
    {
        public Guid ObjectId { get; set; }

        public string MasterResource { get; set; }

        public string ProcedureDoctor { get; set; }

        public object ConsultationResult { get; set; }

        public string ConsultationResultSummary { get; set; }

        public string ProcessDate { get; set; }
    }

    public class HcExaminationTemplate
    {
        public Guid? _healthCommitteeDecision;
    }

}