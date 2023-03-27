//$493D328A
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class PsychologicExaminationServiceController
    {
        partial void PreScript_PsychologicExaminationForm(PsychologicExaminationFormViewModel viewModel, PsychologicExamination psychologicExamination, TTObjectContext objectContext)
        {
            foreach (var psychologyBasedObject in psychologicExamination.PsychologyBasedObjects)
            {
                viewModel.PsychologyBasedObjectId = psychologyBasedObject.ObjectID;
                viewModel.DoctorStatement = psychologicExamination.PsychologyTests[0].Description;
                viewModel.AppliedTest = psychologicExamination.PsychologyTests[0].ProcedureObject.Name;
                viewModel.RequestByDoctorName = psychologicExamination.PsychologyTests[0].RequestedByUser.ToString();
                viewModel.RequestDate = ((DateTime)psychologicExamination.PsychologyTests[0].ActionDate).ToString("dd-MM-yyyy");
                break;
            }
            if (psychologicExamination.ProcedureByUser != null)
            {
                if (Common.CurrentResource.ObjectID == psychologicExamination.ProcedureByUser.ObjectID)
                {
                    viewModel.isAuthorized = true;
                }
                else
                {
                    viewModel.isAuthorized = false;
                }
            }
            else
            {
                throw new TTException(TTUtils.CultureService.GetText("M26157", "İstem Yapılırken Psikolog Seçil(e)mediği için bu ekran açılamamaktadır."), new Exception("ObjectId = " + psychologicExamination.ObjectID));
            }

        }

        partial void PostScript_PsychologicExaminationForm(PsychologicExaminationFormViewModel viewModel, PsychologicExamination psychologicExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            psychologicExamination.WorkListDate = Common.RecTime();
            if (viewModel.psychologyBasedObjectFormViewModel != null)
            {
                viewModel.psychologyBasedObjectFormViewModel.AddSpecialityBasedObjectViewModelToContext(objectContext);
            }
        }
    }
}

namespace Core.Models
{
    public partial class PsychologicExaminationFormViewModel
    {
        public PsychologyBasedObjectFormViewModel psychologyBasedObjectFormViewModel;
        public Guid PsychologyBasedObjectId;
        public string DoctorStatement;
        public string AppliedTest;
        public string RequestByDoctorName;
        public string RequestDate;
        public bool isAuthorized;
    }
}