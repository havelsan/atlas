//$3049B558
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ReturningDocumentServiceController
    {
        partial void AfterContextSaveScript_ReturningDocumentCompletedForm(ReturningDocumentCompletedFormViewModel viewModel, ReturningDocument returningDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (returningDocument.CurrentStateDefID == ReturningDocument.States.Cancelled)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {
                    if (returningDocument.MKYS_AyniyatMakbuzID != null)
                        returningDocument.SendDeleteMessageToMkys(false, returningDocument.MKYS_AyniyatMakbuzID.Value,Common.CurrentResource.MkysPassword);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class ReturningDocumentCompletedFormViewModel
    {
    }
}