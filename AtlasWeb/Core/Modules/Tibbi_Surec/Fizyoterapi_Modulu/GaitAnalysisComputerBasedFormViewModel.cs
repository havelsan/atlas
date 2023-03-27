//$A07203FF
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
    public partial class GaitAnalysisComputerBasedFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class GaitAnalysisComputerBasedFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var gaitAnalysisComputerBasedFormService = new GaitAnalysisComputerBasedFormServiceController();
            gaitAnalysisComputerBasedFormService.GaitAnalysisComputerBasedFormInternal(this, objectContext);
            return (GaitAnalysisComputerBasedForm)objectContext.GetObject(this._GaitAnalysisComputerBasedForm.ObjectID, "GaitAnalysisComputerBasedForm");
        }
    }
}
