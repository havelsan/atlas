//$3395A476
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class PsychologyBasedObjectServiceController
    {
        partial void PreScript_OldPsychologyObjectForm(OldPsychologyObjectFormViewModel viewModel, PsychologyBasedObject psychologyBasedObject, TTObjectContext objectContext)
        {
            viewModel.DoctorName = psychologyBasedObject.RequestDoctor.Name;
            viewModel.DoctorStatement = psychologyBasedObject.DoctorStatement;
            if (psychologyBasedObject.ImportantNoteAboutApplication != null)
                viewModel.ImportantNoteAboutApp = psychologyBasedObject.ImportantNoteAboutApplication.Value.ToString();
            viewModel.InformationFromParent = psychologyBasedObject.InformationTakenFromParent;
            if(psychologyBasedObject.TherapyReport != null)
                viewModel.TherapyReport = TTReportTool.TTReport.HTMLtoText(psychologyBasedObject.TherapyReport.ToString());
            viewModel.AppliedTest = psychologyBasedObject.PsychologicExamination.PsychologyTests[0].ProcedureObject.Name.ToString();
            viewModel.IsAuthorized = psychologyBasedObject.isUserAuthorizedForPsychologyBasedObject(psychologyBasedObject);
        }
    }
}

namespace Core.Models
{
    public partial class OldPsychologyObjectFormViewModel
    {
        public string DoctorName { get; set; }
        public string DoctorStatement { get; set; }
        public string ImportantNoteAboutApp { get; set; }
        public string InformationFromParent { get; set; }
        public string TherapyReport { get; set; }
        public string AppliedTest { get; set; }
        public Boolean IsAuthorized { get; set; }
    }
}
