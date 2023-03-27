//$BF3682A0
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
    public partial class ZDeneme1ServiceController
    {
        partial void PostScript_ZForm1(ZForm1ViewModel viewModel, ZDeneme1 zDeneme1, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel._ZDeneme1.Name.Substring(0, 1) == "A" && transDef.ObjectDefID == ZDeneme1.States.Approve)
                throw new Exception();
        }
    }
}

namespace Core.Models
{
    public partial class ZForm1ViewModel: BaseViewModel
    {
       

    }
}
