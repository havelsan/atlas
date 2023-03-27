//$864FD440
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Core.Controllers;

namespace Core.Controllers
{
    public partial class MuscleTestFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class MuscleTestFormViewModel: BaseAdditionalInfoFormViewModel
    {

        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
           var muscleTestFormService = new MuscleTestFormServiceController();
           muscleTestFormService.MuscleTestFormInternal(this, objectContext);
           return (MuscleTestForm)objectContext.GetObject(this._MuscleTestForm.ObjectID, "MuscleTestForm");
        }
    }
}
