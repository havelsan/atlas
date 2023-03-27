//$C91D0284
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class PostpartumFollowUpServiceController
    {
        partial void PreScript_PostpartumFollowUpForm(PostpartumFollowUpFormViewModel viewModel, PostpartumFollowUp postpartumFollowUp, TTObjectContext objectContext)
        {
            if(postpartumFollowUp.WomanSpecialityObject.Count != 0 && postpartumFollowUp.WomanSpecialityObject.FirstOrDefault().PregnancyFollow != null && postpartumFollowUp.WomanSpecialityObject.FirstOrDefault().PregnancyFollow.Pregnancy != null && postpartumFollowUp.WomanSpecialityObject.FirstOrDefault().PregnancyFollow.Pregnancy.BirthTerminationDate != null)
            {
                viewModel._PostpartumFollowUp.PregnancyDueDate = postpartumFollowUp.WomanSpecialityObject.FirstOrDefault().PregnancyFollow.Pregnancy.BirthTerminationDate;
            }
           
        }
        
    }
}

namespace Core.Models
{
    public partial class PostpartumFollowUpFormViewModel
    {
    }
}
