//$565AECFD
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
    public partial class LowerExtremityServiceController
    {
    }
}

namespace Core.Models
{
    public partial class LowerExtremityFormViewModel: BaseHCExaminationDynamicObjectFormViewModel
    {

        public override void AddBaseHCExaminationDynamicObjectFormViewModelToContext(TTObjectContext objectContext)
        {
            LowerExtremityServiceController lowerExtremityServiceController = new LowerExtremityServiceController();
            lowerExtremityServiceController.LowerExtremityFormInternal(this,  objectContext);
        }

        public bool IsReadOnly { get; set; }
    }
}
