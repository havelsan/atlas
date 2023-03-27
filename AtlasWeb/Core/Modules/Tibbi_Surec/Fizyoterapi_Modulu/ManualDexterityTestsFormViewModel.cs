//$4F8E3A90
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
    public partial class ManualDexterityTestsFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class ManualDexterityTestsFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var manualDexterityTestsFormService = new ManualDexterityTestsFormServiceController();
            manualDexterityTestsFormService.ManualDexterityTestsFormInternal(this, objectContext);
            return (ManualDexterityTestsForm)objectContext.GetObject(this._ManualDexterityTestsForm.ObjectID, "ManualDexterityTestsForm");
        }
    }
}
