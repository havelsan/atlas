//$0A175DFD
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class ConsultationServiceController
    {
        partial void PreScript_ConsultationRequestForm(ConsultationRequestFormViewModel viewModel, Consultation consultation, TTObjectContext objectContext)
        {
            ContextToViewModel(viewModel, objectContext);
        }

    }
}

namespace Core.Models
{
    public partial class ConsultationRequestFormViewModel
    {
    }
}
