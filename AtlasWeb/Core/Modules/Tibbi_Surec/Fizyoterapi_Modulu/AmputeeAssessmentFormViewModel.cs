//$BFC4833D
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
    public partial class AmputeeAssessmentFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class AmputeeAssessmentFormViewModel : BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var amputeeAssessmentFormService = new AmputeeAssessmentFormServiceController();
            amputeeAssessmentFormService.AmputeeAssessmentFormInternal(this, objectContext);
            return (AmputeeAssessmentForm)objectContext.GetObject(this._AmputeeAssessmentForm.ObjectID, "AmputeeAssessmentForm");
        }
    }
}
