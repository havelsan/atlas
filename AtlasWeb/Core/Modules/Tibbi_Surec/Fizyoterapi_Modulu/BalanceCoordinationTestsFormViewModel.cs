//$FA487AB1
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
    public partial class BalanceCoordinationTestsFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class BalanceCoordinationTestsFormViewModel : BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var balanceCoordinationTestsFormService = new BalanceCoordinationTestsFormServiceController();
            balanceCoordinationTestsFormService.BalanceCoordinationTestsFormInternal(this, objectContext);
            return (BaseAdditionalInfo)objectContext.GetObject(this._BalanceCoordinationTestsForm.ObjectID, "BalanceCoordinationTestsForm");
        }
    }
}
