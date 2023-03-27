//$6AC9966C
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
    public partial class ScoliosisAssessmentFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class ScoliosisAssessmentFormViewModel : BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var scoliosisAssessmentFormService = new ScoliosisAssessmentFormServiceController();
            scoliosisAssessmentFormService.ScoliosisAssessmentFormInternal(this, objectContext);
            return (ScoliosisAssessmentForm)objectContext.GetObject(this._ScoliosisAssessmentForm.ObjectID, "ScoliosisAssessmentForm");
        }
    }
}
