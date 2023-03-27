//$CB13B88A
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class GrantMaterialServiceController
    {
        partial void AfterContextSaveScript_GrantMaterialCompletedForm(GrantMaterialCompletedFormViewModel viewModel, GrantMaterial grantMaterial, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
            {
                if (grantMaterial.CurrentStateDefID == GrantMaterial.States.Cancelled)
                {
                    if (grantMaterial.MKYS_AyniyatMakbuzID != null)
                    {
                        var sonucMesaji = grantMaterial.SendDeleteMessageToMkys(false, grantMaterial.MKYS_AyniyatMakbuzID.Value, Common.CurrentResource.MkysPassword);
                        TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                    }
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class GrantMaterialCompletedFormViewModel
    {
    }
}