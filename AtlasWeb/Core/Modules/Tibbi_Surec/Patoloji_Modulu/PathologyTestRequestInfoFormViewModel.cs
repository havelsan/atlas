//$C965F221
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class PathologyTestProcedureServiceController
    {
    }
}

namespace Core.Models
{
    public partial class PathologyTestRequestInfoFormViewModel
    {
        public string ProcedureName
        {
            get;
            set;
        }

        public string textDescription
        {
            get;
            set;
        }
    }
}
