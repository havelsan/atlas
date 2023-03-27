//$EF3AD080
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
    public partial class DentalLaboratoryProcedureServiceController
    {
        partial void PreScript_DentalLaboratoryForm(DentalLaboratoryFormViewModel viewModel, DentalLaboratoryProcedure dentalLaboratoryProcedure, TTObjectContext objectContext)
        {
            // SARF GRIDINDE Cancelledlar gelmemesi  i�in  Bu koddan sonra ContextToViewModel �al��mamal�
            viewModel.TreatmentMaterialsGridList = viewModel.TreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
        }
    }
}

namespace Core.Models
{
    public partial class DentalLaboratoryFormViewModel
    {
    }
}

