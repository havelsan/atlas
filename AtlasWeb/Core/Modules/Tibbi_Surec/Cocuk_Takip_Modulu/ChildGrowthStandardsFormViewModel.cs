//$51446EEF
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
    public partial class ChildGrowthStandardsServiceController
    {
        partial void PreScript_ChildGrowthStandardsForm(ChildGrowthStandardsFormViewModel viewModel, ChildGrowthStandards childGrowthStandards, TTObjectContext objectContext)
        {
            viewModel._PatientID = childGrowthStandards.PhysicianApplication.Episode.Patient.ObjectID;
           

        }

        partial void PostScript_ChildGrowthStandardsForm(ChildGrowthStandardsFormViewModel viewModel, ChildGrowthStandards childGrowthStandards, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
       
        }

    }
}

namespace Core.Models
{
    public partial class ChildGrowthStandardsFormViewModel: ISpecialityBasedObjectViewModel
    {
        public Guid _PatientID { get; set; }
        public void AddSpecialityBasedObjectViewModelToContext(TTObjectContext objectContext)
        {
           
        }
    }
}
