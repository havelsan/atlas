//$60F64C68
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
        partial void PostScript_GrantMaterialApprovalForm(GrantMaterialApprovalFormViewModel viewModel, GrantMaterial grantMaterial, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (grantMaterial.CurrentStateDefID == GrantMaterial.States.Approved)
            {
                foreach (GrantMaterialDetail det in grantMaterial.GrantMaterialDetails)
                {
                    if (det.UnitPrice == null)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M25281", "Birim fiyat girmeden işleme devam edilemez."));
                    }
                    if (det.NotDiscountedUnitPrice == null)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26084", "İndirimsiz fiyat girmeden işleme devam edilemez."));
                    }

                    if (det.UnitPrice <= 0)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M25280", "Birim fiyat 0 dan küçük ya da eşit olamaz."));
                    }
                    if (det.NotDiscountedUnitPrice <= 0)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26083", "İndirimsiz fiyat 0 dan küçük ya da eşit olamaz."));
                    }
                }
            }
        }

        partial void AfterContextSaveScript_GrantMaterialApprovalForm(GrantMaterialApprovalFormViewModel viewModel, GrantMaterial grantMaterial, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (grantMaterial.CurrentStateDefID == GrantMaterial.States.Completed)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {
                    var sonucMesaji = grantMaterial.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class GrantMaterialApprovalFormViewModel
    {
    }
}