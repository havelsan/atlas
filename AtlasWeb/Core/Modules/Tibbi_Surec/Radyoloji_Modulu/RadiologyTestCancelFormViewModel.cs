//$BF0ED92C
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class RadiologyTestServiceController
    {

        partial void PreScript_RadiologyTestCancelForm(RadiologyTestCancelFormViewModel viewModel, RadiologyTest radiologyTest, TTObjectContext objectContext)
        {
            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalýþmamalý
            viewModel.MaterialsGridList = viewModel.MaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
        }
    }
}

namespace Core.Models
{
    public partial class RadiologyTestCancelFormViewModel
    {
    }
}