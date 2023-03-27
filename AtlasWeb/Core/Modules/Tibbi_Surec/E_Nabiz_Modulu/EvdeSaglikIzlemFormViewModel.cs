//$35B46D9F
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class EvdeSaglikIzlemVeriSetiServiceController
    {
    }
}

namespace Core.Models
{
    public partial class EvdeSaglikIzlemFormViewModel: BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._EvdeSaglikIzlemVeriSeti);
        }
    }
}