//$1A34F4D1
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
    public partial class PsychologyTestServiceController
    {
    }
}

namespace Core.Models
{
    public partial class PsychologyTestRequestInfoFormViewModel
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
