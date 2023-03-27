//$B67451A3
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
    public partial class OccupationalAssessmentFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class OccupationalAssessmentFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var occupationalAssessmentFormService = new OccupationalAssessmentFormServiceController();
            occupationalAssessmentFormService.OccupationalAssessmentFormInternal(this, objectContext);
            return (OccupationalAssessmentForm)objectContext.GetObject(this._OccupationalAssessmentForm.ObjectID, "OccupationalAssessmentForm");
        }
    }
}
