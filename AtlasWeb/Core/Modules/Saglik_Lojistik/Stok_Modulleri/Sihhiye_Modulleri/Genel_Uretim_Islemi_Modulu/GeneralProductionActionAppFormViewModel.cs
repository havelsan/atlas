//$FBEE8A12
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class GeneralProductionActionServiceController
    {
        partial void AfterContextSaveScript_GeneralProductionActionAppForm(GeneralProductionActionAppFormViewModel viewModel, GeneralProductionAction generalProductionAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = "";
            if (viewModel._GeneralProductionAction.CurrentStateDefID == GeneralProductionAction.States.Completed)
            {

                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {
                    if (generalProductionAction.OutMkysControl == null || generalProductionAction.OutMkysControl == false)
                    {
                        sonucMesaji = generalProductionAction.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                        if (generalProductionAction.InMkysControl == null || generalProductionAction.InMkysControl == false)
                        {
                            sonucMesaji += generalProductionAction.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                    else if (generalProductionAction.InMkysControl == null || generalProductionAction.InMkysControl == false)
                    {
                        sonucMesaji = generalProductionAction.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                    }

                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class GeneralProductionActionAppFormViewModel
    {
    }
}