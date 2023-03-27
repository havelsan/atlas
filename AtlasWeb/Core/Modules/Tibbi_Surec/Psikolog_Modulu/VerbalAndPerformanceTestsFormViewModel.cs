//$434E0AFD
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class VerbalAndPerformanceTestsServiceController
    {
        partial void PreScript_VerbalAndPerformanceTestsForm(VerbalAndPerformanceTestsFormViewModel viewModel, VerbalAndPerformanceTests verbalAndPerformanceTests, TTObjectContext objectContext)
        {
            if (verbalAndPerformanceTests.PsychologyBasedObject != null)
            {
                viewModel.isUserAuthorized = verbalAndPerformanceTests.PsychologyBasedObject.isUserAuthorized(verbalAndPerformanceTests);
            }
            else
            {
                viewModel.isUserAuthorized = true;
            }

            if (verbalAndPerformanceTests.AddedUser == null)
            {
                verbalAndPerformanceTests.AddedUser = Common.CurrentResource;
                ContextToViewModel(viewModel, objectContext);
            }
        }

        partial void PostScript_VerbalAndPerformanceTestsForm(VerbalAndPerformanceTestsFormViewModel viewModel, VerbalAndPerformanceTests verbalAndPerformanceTests, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (verbalAndPerformanceTests.AddedDate == null)
            {
                verbalAndPerformanceTests.AddedDate = Common.RecTime();
            }
        }
    }
}

namespace Core.Models
{
    public partial class VerbalAndPerformanceTestsFormViewModel
    {
        public Boolean isUserAuthorized;
    }
}