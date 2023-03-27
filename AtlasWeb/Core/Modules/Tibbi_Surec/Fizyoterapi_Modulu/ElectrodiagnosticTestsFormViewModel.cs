//$B8D220EA
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
    public partial class ElectrodiagnosticTestsServiceController
    {
    }
}

namespace Core.Models
{
    public partial class ElectrodiagnosticTestsFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var electrodiagnosticTestsService = new ElectrodiagnosticTestsServiceController();
            electrodiagnosticTestsService.ElectrodiagnosticTestsFormInternal(this, objectContext);
            return (ElectrodiagnosticTests)objectContext.GetObject(this._ElectrodiagnosticTests.ObjectID, "ElectrodiagnosticTests");
        }
    }
}
