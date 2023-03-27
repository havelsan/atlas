//$63EDC916
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
    public partial class AdditionalReportServiceController
    {
    }
}

namespace Core.Models
{
    public partial class AdditionalReportFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var additionalReportFormService = new AdditionalReportServiceController();
            additionalReportFormService.AdditionalReportFormInternal(this, objectContext);
            return (AdditionalReport)objectContext.GetObject(this._AdditionalReport.ObjectID, "AdditionalReport");
        }
    }
}
