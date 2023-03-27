//$74CE491B
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
    public partial class RangeOfMotionMeasurementFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class RangeOfMotionMeasurementFormViewModel : BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var rangeOfMotionMeasurementFormService = new RangeOfMotionMeasurementFormServiceController();
            rangeOfMotionMeasurementFormService.RangeOfMotionMeasurementFormInternal(this, objectContext);
            return (RangeOfMotionMeasurementForm)objectContext.GetObject(this._RangeOfMotionMeasurementForm.ObjectID, "RangeOfMotionMeasurementForm");
        }
    }
}
