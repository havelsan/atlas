//$D0DD68D2
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
    public partial class IsokineticTestFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class IsokineticTestFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var isokineticTestFormService = new IsokineticTestFormServiceController();
            isokineticTestFormService.IsokineticTestFormInternal(this, objectContext);
            return (IsokineticTestForm)objectContext.GetObject(this._IsokineticTestForm.ObjectID, "IsokineticTestForm");
        }
    }
}
