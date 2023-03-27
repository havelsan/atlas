//$CC92F591
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
    public partial class ProcedureResultInfoServiceController
    {
    }
}

namespace Core.Models
{
    public partial class ProcedureResultInfoFormViewModel: BaseAdditionalInfoFormViewModel
    {
        public override BaseAdditionalInfo AddViewModelToContext(TTObjectContext objectContext)
        {
            var procedureResultInfoFormService = new ProcedureResultInfoServiceController();
            procedureResultInfoFormService.ProcedureResultInfoFormInternal(this, objectContext);
            return (ProcedureResultInfo)objectContext.GetObject(this._ProcedureResultInfo.ObjectID, "ProcedureResultInfo");
        }
    }
}
