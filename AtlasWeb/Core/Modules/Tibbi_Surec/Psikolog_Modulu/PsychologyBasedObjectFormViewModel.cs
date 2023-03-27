//$8DFAA1F4
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class PsychologyBasedObjectServiceController
    {
        partial void PreScript_PsychologyBasedObjectForm(PsychologyBasedObjectFormViewModel viewModel, PsychologyBasedObject psychologyBasedObject, TTObjectContext objectContext)
        {
            viewModel.EpisodeId = psychologyBasedObject.PsychologicExamination.Episode.ObjectID;
            if (psychologyBasedObject != null)
            {
                viewModel.isUserAuthorized = psychologyBasedObject.isUserAuthorizedForPsychologyBasedObject(psychologyBasedObject);
            }
            else
            {
                viewModel.isUserAuthorized = true;
            }
            //viewModel.isUserAuthorized = true;
            if (TTObjectClasses.SystemParameter.GetParameterValue("PSIKOLOGFORMLARIAKTIF", "FALSE").ToUpper() == "FALSE") { 
                viewModel.PsychologyFormActive = false;
            }
            else
            {
                viewModel.PsychologyFormActive = true;
            }
            if (psychologyBasedObject.PsychologicExamination.PsychologyTests != null)
            {
                viewModel.PsychologyBasedObjects[0].DoctorStatement = psychologyBasedObject.PsychologicExamination.PsychologyTests[0].Description;
                psychologyBasedObject.DoctorStatement = psychologyBasedObject.PsychologicExamination.PsychologyTests[0].Description;
            }
        }
      
    }
}

namespace Core.Models
{
    public partial class PsychologyBasedObjectFormViewModel : ISpecialityBasedObjectViewModel
    {
        public Guid EpisodeId
        {
            get;
            set;
        }

        public bool isUserAuthorized;
        public bool PsychologyFormActive;

        public void AddSpecialityBasedObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddToRawObjectList(this.ResUsers);
            objectContext.AddToRawObjectList(this.SKRSOgrenimDurumus);
            objectContext.AddToRawObjectList(this.SKRSMesleklers);
            objectContext.AddToRawObjectList(this.IQIntelligenceTestReportGridList);
            objectContext.AddToRawObjectList(this.VerbalAndPerformanceTestsGridList);
            objectContext.AddToRawObjectList(this.ttgrid1GridList);
            objectContext.AddToRawObjectList(this.PsychologyAuthorizedUsersGridList);
            objectContext.AddToRawObjectList(this.PsychologicEvaluationGridList);
            objectContext.AddToRawObjectList(this._PsychologyBasedObject);
            objectContext.ProcessRawObjects();

            var psychologyBasedObject = (PsychologyBasedObject)objectContext.GetLoadedObject(this._PsychologyBasedObject.ObjectID);
            
            if (this.PsychologyAuthorizedUsersGridList != null)
            {
                foreach (var item in this.PsychologyAuthorizedUsersGridList)
                {
                    var psychologyAuthorizedUser = (PsychologyAuthorizedUser)objectContext.GetLoadedObject(item.ObjectID);
                    psychologyAuthorizedUser.PsychologyBasedObject = psychologyBasedObject;
                }
            }

            if (this.IQIntelligenceTestReportGridList != null)
            {
                foreach (var item in this.IQIntelligenceTestReportGridList)
                {
                    var iQIntelligenceTestReportImported = (IQIntelligenceTestReport)objectContext.GetLoadedObject(item.ObjectID);
                    iQIntelligenceTestReportImported.PsychologyBasedObject = psychologyBasedObject;
                }
            }

            if (this.VerbalAndPerformanceTestsGridList != null)
            {
                foreach (var item in this.VerbalAndPerformanceTestsGridList)
                {
                    var verbalAndPerformanceTestsImported = (VerbalAndPerformanceTests)objectContext.GetLoadedObject(item.ObjectID);
                    verbalAndPerformanceTestsImported.PsychologyBasedObject = psychologyBasedObject;
                }
            }

            if (this.ttgrid1GridList != null)
            {
                foreach (var item in this.ttgrid1GridList)
                {
                    var cognitiveEvaluationImported = (CognitiveEvaluation)objectContext.GetLoadedObject(item.ObjectID);
                    cognitiveEvaluationImported.PsychologyBasedObject = psychologyBasedObject;
                }
            }

            if (this.PsychologicEvaluationGridList != null)
            {
                foreach (var item in this.PsychologicEvaluationGridList)
                {
                    var psychologicEvaluationImported = (PsychologicEvaluation)objectContext.GetLoadedObject(item.ObjectID);
                    psychologicEvaluationImported.PsychologyBasedObject = psychologyBasedObject;
                }
            }
        }
    }
}