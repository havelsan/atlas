//$54985417
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
        partial void AfterContextSaveScript_GeneralProductionActionCompForm(GeneralProductionActionCompFormViewModel viewModel, GeneralProductionAction generalProductionAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = "";
            if (viewModel._GeneralProductionAction.CurrentStateDefID == GeneralProductionAction.States.Cancelled)
            {
                if (generalProductionAction.InMkysControl != null || generalProductionAction.InMkysControl != false)
                {
                    if (generalProductionAction.MKYS_AyniyatMakbuzIDGiris != null)
                    {
                        //sonucMesaji = generalProductionAction.SendDeleteMessageToMkys(false, generalProductionAction.MKYS_AyniyatMakbuzIDGiris.Value);
                        //if (generalProductionAction.OutMkysControl != null || generalProductionAction.OutMkysControl != false)
                        //{
                        //    sonucMesaji += generalProductionAction.SendDeleteMessageToMkys(true, generalProductionAction.MKYS_AyniyatMakbuzID.Value);
                        //}
                    }
                }

                TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
            }
        }
    }
}

namespace Core.Models
{
    public partial class GeneralProductionActionCompFormViewModel
    {
    }
}