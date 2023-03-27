//$2FE9A379
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class EyeExaminationServiceController
    {
        partial void PreScript_OldEyeExaminationForm(OldEyeExaminationFormViewModel viewModel, EyeExamination eyeExamination, TTObjectContext objectContext)
        {
            viewModel.NoGlassVisSharpLeftVal = viewModel._EyeExamination.NoGlassVisSharpLeftVal != null ? viewModel._EyeExamination.NoGlassVisSharpLeftVal.SharpnessValue : "";
            viewModel.NoGlassVisSharpRightVal = viewModel._EyeExamination.NoGlassVisSharpRightVal != null ? viewModel._EyeExamination.NoGlassVisSharpRightVal.SharpnessValue : "";
            viewModel.GlassVisSharpLeftVal = viewModel._EyeExamination.GlassVisSharpLeftVal != null ? viewModel._EyeExamination.GlassVisSharpLeftVal.SharpnessValue : "";
            viewModel.GlassVisSharpRightVal = viewModel._EyeExamination.GlassVisSharpRightVal != null ? viewModel._EyeExamination.GlassVisSharpRightVal.SharpnessValue : "";
        }
    }
}

namespace Core.Models
{
    public partial class OldEyeExaminationFormViewModel
    {
        public string NoGlassVisSharpLeftVal { get; set; }
        public string NoGlassVisSharpRightVal { get; set; }
        public string GlassVisSharpLeftVal { get; set; }
        public string GlassVisSharpRightVal { get; set; }
    }
}
