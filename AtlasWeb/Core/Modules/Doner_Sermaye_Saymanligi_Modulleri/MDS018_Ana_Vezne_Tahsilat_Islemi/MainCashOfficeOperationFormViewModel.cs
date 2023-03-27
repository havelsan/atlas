//$DC6D59E9
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using TTDefinitionManagement;

namespace Core.Controllers
{
    public partial class MainCashOfficeOperationServiceController
    {
        partial void PreScript_MainCashOfficeOperationForm(MainCashOfficeOperationFormViewModel viewModel, MainCashOfficeOperation mainCashOfficeOperation, TTObjectContext objectContext)
        {
            if (((ITTObject)mainCashOfficeOperation).IsNew)
            {
                viewModel._MainCashOfficeOperation.PrepareNewMainCashOfficeOperation();
                ContextToViewModel(viewModel, objectContext);
            }
        }
    }
}

namespace Core.Models
{
    public partial class MainCashOfficeOperationFormViewModel
    {
    }
}