//$3700963E
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
    public partial class GaitAnalysisFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class GaitAnalysisFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var gaitAnalysisFormService = new GaitAnalysisFormServiceController();
            gaitAnalysisFormService.GaitAnalysisFormInternal(this, objectContext);
            return (GaitAnalysisForm)objectContext.GetObject(this._GaitAnalysisForm.ObjectID, "GaitAnalysisForm");
        }
    }
}
