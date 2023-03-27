//$B5D8EF14
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ReviewActionServiceController
    {
        partial void AfterContextSaveScript_ReviewActionNewForm(ReviewActionNewFormViewModel viewModel, ReviewAction reviewAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (reviewAction.CurrentStateDefID == ReviewAction.States.Completed)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                        reviewAction.SendMkysOutputDocumentForReviewAction(Common.CurrentResource.MkysPassword);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class ReviewActionNewFormViewModel
    {
    }
}