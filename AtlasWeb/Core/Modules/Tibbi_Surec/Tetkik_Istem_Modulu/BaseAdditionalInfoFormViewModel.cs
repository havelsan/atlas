//$959EA922
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
    public partial class BaseAdditionalInfoFormServiceController
    {
    }
}

namespace Core.Models
{
    public partial class BaseAdditionalInfoFormViewModel : BaseViewModel
    {
        public virtual BaseAdditionalInfo AddViewModelToContext(TTObjectContext context)
        {
            throw new Exception ("AddViewModelToContext methodunun  overreide edilmesi gerekir");
        }
    }
}
