//$09C36051
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ConvTestServiceController
    {
        partial void AfterContextSaveScript_ConvTestForm2(ConvTestForm2ViewModel viewModel, ConvTest convTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
        }
    }
}

namespace Core.Models
{
    public partial class ConvTestForm2ViewModel
    {
    }
}