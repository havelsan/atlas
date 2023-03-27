//$04F0F22A
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
    public partial class MuscleStrengthMeasuringFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class MuscleStrengthMeasuringFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var muscleStrengthMeasuringFormService = new MuscleStrengthMeasuringFormServiceController();
            muscleStrengthMeasuringFormService.MuscleStrengthMeasuringFormInternal(this, objectContext);
            return (MuscleStrengthMeasuringForm)objectContext.GetObject(this._MuscleStrengthMeasuringForm.ObjectID, "MuscleStrengthMeasuringForm");
        }
    }
}
