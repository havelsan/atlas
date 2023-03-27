//$D941E902
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
    public partial class PostureAnalysisFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class PostureAnalysisFormViewModel : BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var postureAnalysisFormService = new PostureAnalysisFormServiceController();
            postureAnalysisFormService.PostureAnalysisFormInternal(this, objectContext);
            return (PostureAnalysisForm)objectContext.GetObject(this._PostureAnalysisForm.ObjectID, "PostureAnalysisForm");
        }
    }
}
