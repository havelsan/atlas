//$C422C148
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
    public partial class DailyActivityTestsFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class DailyActivityTestsFormViewModel : BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var dailyActivityTestsFormService = new DailyActivityTestsFormServiceController();
            dailyActivityTestsFormService.DailyActivityTestsFormInternal(this, objectContext);
            return (DailyActivityTestsForm)objectContext.GetObject(this._DailyActivityTestsForm.ObjectID, "DailyActivityTestsForm");
        }
    }
}
