//$07E0202E
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
    public partial class ManipulationProcedureServiceController
    {
    }
}

namespace Core.Models
{
    public partial class ManipulationProcedureRequestInfoViewModel : BaseViewModel
    {
        public string ProcedureName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
