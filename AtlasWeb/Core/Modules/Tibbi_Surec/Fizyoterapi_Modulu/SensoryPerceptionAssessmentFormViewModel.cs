//$B1F84967
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
    public partial class SensoryPerceptionAssessmentFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class SensoryPerceptionAssessmentFormViewModel : BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var sensoryPerceptionAssessmentFormService = new SensoryPerceptionAssessmentFormServiceController();
            sensoryPerceptionAssessmentFormService.SensoryPerceptionAssessmentFormInternal(this, objectContext);
            return (SensoryPerceptionAssessmentForm)objectContext.GetObject(this._SensoryPerceptionAssessmentForm.ObjectID, "SensoryPerceptionAssessmentForm");
        }
    }
}
