//$7E5505CB
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class DirectMaterialSupplyActionServiceController
    {
        partial void AfterContextSaveScript_DirectMaterialSupplyNewForm(DirectMaterialSupplyNewFormViewModel viewModel, DirectMaterialSupplyAction directMaterialSupplyAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == DirectMaterialSupplyAction.States.Request)
                {
                    viewModel._DirectMaterialSupplyAction.Send22F_SupplyRequestToXXXXXX(directMaterialSupplyAction);
                }

                //viewModel._DirectMaterialSupplyAction.ObjectContext.Save();
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class DirectMaterialSupplyNewFormViewModel
    {
    }
}