//$2A605590
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class MedicalOncologyServiceController
    {

        partial void PreScript_MedicalOncologySpecialityForm(MedicalOncologySpecialityFormViewModel viewModel, MedicalOncology medicalOncology, TTObjectContext objectContext)
        {
            viewModel._Patient = viewModel._MedicalOncology.PhysicianApplication.Episode.Patient;
            if (viewModel.actionId == null && viewModel.ActiveIDsModel != null)
                viewModel.actionId = viewModel.ActiveIDsModel.EpisodeActionId.ToString();
            if (viewModel._MedicalOncology.FirstLineTreatment == null)
                viewModel._MedicalOncology.FirstLineTreatment = "";
            if (viewModel._MedicalOncology.Description == null)
                viewModel._MedicalOncology.Description = "";
            if (viewModel._MedicalOncology.SecondLineTreatment == null)
                viewModel._MedicalOncology.SecondLineTreatment = "";
            if (viewModel._MedicalOncology.PreTreatmentStaging == null)
                viewModel._MedicalOncology.PreTreatmentStaging = "";
            if (viewModel._MedicalOncology.Story == null)
                viewModel._MedicalOncology.Story = "";
            if (viewModel._MedicalOncology.Pathology == null)
                viewModel._MedicalOncology.Pathology = "";
            if (viewModel._MedicalOncology.InterimEvaluation == null)
                viewModel._MedicalOncology.InterimEvaluation = "";
            if (viewModel._MedicalOncology.Height != null && viewModel._MedicalOncology.Weight != null)
            {
                viewModel.BMIValue = viewModel._MedicalOncology.Weight / (Math.Pow((Double)(viewModel._MedicalOncology.Height / 100), 2));
                viewModel.BMIValue = Math.Round((Double)viewModel.BMIValue, 2);
            }
            BindingList<DiagnosisGrid> diagnosisGrid = new BindingList<DiagnosisGrid>();
            diagnosisGrid = DiagnosisGrid.GetDiagnoseCancerForOncology(objectContext, viewModel._MedicalOncology.PhysicianApplication.SubEpisode.ObjectID);

            if (diagnosisGrid.Count == 0)
            {
                viewModel.DiagnoseDate = null;
            }
            else
            {
                DateTime? time = Common.RecTime();
                foreach (DiagnosisGrid diagnosis in diagnosisGrid)
                {
                    if (diagnosis.DiagnoseDate < time)
                    {
                        time = diagnosis.DiagnoseDate;
                    }
                }
                viewModel.DiagnoseDate = time;
            }
            PatientExamination masterAction = (PatientExamination)viewModel._MedicalOncology.PhysicianApplication;

            //Daha once yapilmis kemoterapi radyoterapi istegi var mi
            if (masterAction.SubEpisode.EpisodeActions.Where(ea => ea is ChemotherapyRadiotherapy 
            && ((ChemotherapyRadiotherapy)ea).CurrentStateDefID != ChemotherapyRadiotherapy.States.Cancelled
            && ((ChemotherapyRadiotherapy)ea).CurrentStateDefID != ChemotherapyRadiotherapy.States.Completed).FirstOrDefault() != null)
            {
                viewModel.hasChemoRadioRequest = true;
            }
            else
            {
                viewModel.hasChemoRadioRequest = false;
            }

            //tanisi yoksa kemoterapi radyoterapi istegi yapamasin
            if(masterAction.Diagnosis.Count == 0)
            {
                viewModel.hasDiagnosis = false;
            }
            else
            {
                viewModel.hasDiagnosis = true;
            }
            objectContext.FullPartialllyLoadedObjects();
        }

        [HttpGet]
        public List<OncologyGridResultModel> GetAllPatientBasedOncologyForms(Guid patientId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                //List<MedicalOncologySpecialityFormViewModel> OncologyForms = new List<MedicalOncologySpecialityFormViewModel>();
                //BindingList<MedicalOncology.GetAllPatientBasedOncologyForms_Class> oncologyQuery = new BindingList<MedicalOncology.GetAllPatientBasedOncologyForms_Class>();
                //oncologyQuery = MedicalOncology.GetAllPatientBasedOncologyForms(new Guid(input));

                //if (oncologyQuery.Count != 0)
                //{
                //    foreach (MedicalOncology.GetAllPatientBasedOncologyForms_Class oncology in oncologyQuery)
                //    {
                //        OncologyGridResultModel model = new OncologyGridResultModel();
                //        model.OncologyObject = oncology.;
                //    }
                //}

                //return OncologyForms;

                List<MedicalOncology> OncologyForms = new List<MedicalOncology>();
                OncologyForms = MedicalOncology.GetAllPatientBasedOncologyForm(objectContext, patientId).ToList();

                List<OncologyGridResultModel> OncologyGridSource = new List<OncologyGridResultModel>();
                foreach (MedicalOncology oncology in OncologyForms)
                {
                    OncologyGridResultModel model = new OncologyGridResultModel();
                    model.Date = oncology.PhysicianApplication.ActionDate;
                    model.Doctor = oncology.PhysicianApplication.ProcedureDoctor;
                    model.ObjectID = oncology.ObjectID;
                    model.PhysicianApplicationId = oncology.PhysicianApplication.ObjectID.ToString();
                    if (oncology.InterimEvaluation != null)
                        model.InterimEvaluation = oncology.InterimEvaluation.ToString();  
                    if (oncology.Description != null)
                        model.Description = oncology.Description.ToString();
                    if (oncology.Weight != null && oncology.Height != null)
                    {
                        model.BMIValue = oncology.Weight / (Math.Pow((Double)(oncology.Height / 100), 2));
                        model.BMIValue = Math.Round((Double)model.BMIValue, 2);
                    }
                    OncologyGridSource.Add(model);
                }

                return OncologyGridSource;

            }
        }

        [HttpGet]
        public DateTime? GetDiagnoseDate(Guid physicianAppId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction ea = objectContext.GetObject<EpisodeAction>(physicianAppId);
                BindingList<DiagnosisGrid> diagnosisGrid = new BindingList<DiagnosisGrid>();
                diagnosisGrid = DiagnosisGrid.GetDiagnoseCancerForOncology(objectContext, ea.SubEpisode.ObjectID);
                DateTime? time = Common.RecTime();
                foreach(DiagnosisGrid diagnosis in diagnosisGrid)
                {
                    if( diagnosis.DiagnoseDate < time)
                    {
                        time = diagnosis.DiagnoseDate;
                    }
                }

                return time;
            }
        }


        [HttpGet]
        public MedicalOncology GetSelectedOncology(Guid ObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                MedicalOncology oncology = objectContext.GetObject<MedicalOncology>(ObjectID);
                objectContext.FullPartialllyLoadedObjects();
                return oncology;
            }

        }

        [HttpGet]
        public List <UserTemplateModel> CreateProtocolSourceList()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, new Guid("b25d0f3f-18e6-4954-a16a-3ef18a201553"), "ChemoRadioCureProtocolTemplate").ToList();
                List<UserTemplateModel> TemplateList = new List<UserTemplateModel>();
                foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList)
                {
                    UserTemplateModel templateModel = new UserTemplateModel();
                    templateModel.ObjectID = item.ObjectID;
                    templateModel.TAObjectID = item.TAObjectID;
                    templateModel.TAObjectDefID = item.TAObjectDefID; //CHEMORADIOPROTOCOL object id
                    templateModel.Description = item.Description;
                    TemplateList.Add(templateModel);
                }

                return TemplateList;
            }

        }
    }
}

namespace Core.Models
{
    public partial class MedicalOncologySpecialityFormViewModel : ISpecialityBasedObjectViewModel
    {
        public TTObjectClasses.Patient _Patient
        {
            get;
            set;
        }

        public void AddSpecialityBasedObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(_MedicalOncology);
            //objectContext.ProcessRawObjects();
        }

        public string actionId { get; set; }
        public double? BMIValue { get; set; }

        public DateTime? DiagnoseDate { get; set; }
        public List<UserTemplateModel> userTemplateList { get; set; }
        public bool hasDiagnosis { get; set; }
        public bool hasChemoRadioRequest { get; set; }

    }

    public class OncologyGridResultModel
    {
        public Guid? ObjectID { get; set; }
        public ResUser Doctor { get; set; }
        public DateTime? Date { get; set; }
        public MedicalOncology OncologyObject { get; set; }
        public double? BMIValue { get; set; }
        public string FirstLineTreatment { get; set; }
        public string SecondLineTreatment { get; set; }
        public string PreTreatmentStaging { get; set; }
        public string InterimEvaluation { get; set; }
        public string Story { get; set; }
        public string Pathology { get; set; }
        public string Description { get; set; }
        public string PS { get; set; }
        public string TA { get; set; }
        public string NB { get; set; }
        public string M2 { get; set; }
        public string PhysicianApplicationId { get; set; }
    }

}
