//$FB946FF7
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
    public partial class NeurophysiologicalAssessmentFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class NeurophysiologicalAssessmentFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var neurophysiologicalAssessmentFormService = new NeurophysiologicalAssessmentFormServiceController();
            neurophysiologicalAssessmentFormService.NeurophysiologicalAssessmentFormInternal(this, objectContext);
            return (NeurophysiologicalAssessmentForm)objectContext.GetObject(this._NeurophysiologicalAssessmentForm.ObjectID, "NeurophysiologicalAssessmentForm");
        }
    }
}
