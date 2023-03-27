//$EA9582F7
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
    public partial class BaseHCExaminationDynamicObjectServiceController
    {
        partial void PreScript_BaseHCExaminationDynamicObjectForm(BaseHCExaminationDynamicObjectFormViewModel viewModel, BaseHCExaminationDynamicObject baseHCExaminationDynamicObject, TTObjectContext objectContext)
        {

        }

    }
}

namespace Core.Models
{
    public partial class BaseHCExaminationDynamicObjectFormViewModel: BaseViewModel
    {

        public virtual void AddBaseHCExaminationDynamicObjectFormViewModelToContext(TTObjectContext objectContext)
        {
            throw new Exception("AddBaseHCExaminationDynamicObjectFormViewModelToContext methodu override edilmeden Saðlýk Kurulu Ek alanlarý Kaydedilemez");
        }

    }
}
