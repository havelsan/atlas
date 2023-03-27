//$75033BE4
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using System.Collections.Generic;
using TTUtils;

namespace Core.Controllers
{
    public partial class DrugOrderDetailServiceController
    {
        partial void PreScript_DrugOrderDetailForm(DrugOrderDetailFormViewModel viewModel, DrugOrderDetail drugOrderDetail, TTObjectContext objectContext)
        {
            viewModel.DrugUsageType = drugOrderDetail.DrugOrder.DrugUsageType;
            ContextToViewModel(viewModel, objectContext);
        }
    }
}

namespace Core.Models
{
    public partial class DrugOrderDetailFormViewModel
    {
        public DrugUsageTypeEnum? DrugUsageType { get; set; }
    }
}