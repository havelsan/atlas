//$8977512B
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
    public partial class TraditionalMedicineServiceController
    {
  
    }
}

namespace Core.Models
{
    public partial class GetatExaminationFormViewModel : ISpecialityBasedObjectViewModel
    {
        public void AddSpecialityBasedObjectViewModelToContext(TTObjectContext objectContext)
        {
            var tradMed = (TraditionalMedicine)objectContext.AddObject(this._TraditionalMedicine);

            if (this.TraditionalMedAppRegionGridList != null)
            {
                foreach (var item in this.TraditionalMedAppRegionGridList)
                {
                    var traditionalMedAppRegionImported = (TraditionalMedAppRegion)objectContext.AddObject(item);
                    if (((ITTObject)traditionalMedAppRegionImported).IsDeleted)
                        continue;
                    traditionalMedAppRegionImported.TraditionalMedicine = tradMed;
                }
            }

            if (this.TraditionalMedAppCasesGridList != null)
            {
                foreach (var item in this.TraditionalMedAppCasesGridList)
                {
                    var traditionalMedAppCasesImported = (TradititionalMedAppCases)objectContext.AddObject(item);
                    if (((ITTObject)traditionalMedAppCasesImported).IsDeleted)
                        continue;
                    traditionalMedAppCasesImported.TraditionalMedicine = tradMed;
                }
            }
        }
    }
}
