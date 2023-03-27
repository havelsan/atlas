using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using Core.Security;
using TTInstanceManagement;
using TTUtils;
using TTDefinitionManagement;
using TTDataDictionary;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DrugGenericReportServiceController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LoadResult GetDrugGenericList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERICDRUG"].QueryDefs["GetGenericDrugListRQ"];
                var paramList = new Dictionary<string, object>();
                var injection = string.Empty;
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }

            return result;
        }

        public List<DrugListGeneric> GetDrugList(DrugGenericListInputDTO input)
        {
            List<DrugListGeneric> drugLists = new List<DrugListGeneric>();
            using (var context = new TTObjectContext(false))
            {
                string injectionSQL = string.Empty;
                if (input.genericID != Guid.Empty)
                {
                    injectionSQL = " AND THIS.GenericDrug = " + TTConnectionManager.ConnectionManager.GuidToString(input.genericID);
                }
                BindingList<DrugDefinition.GetDrugGenericRQ_Class> getDrugs = DrugDefinition.GetDrugGenericRQ(input.storeID, injectionSQL);
                foreach (DrugDefinition.GetDrugGenericRQ_Class item in getDrugs)
                {
                    DrugListGeneric drugList = new DrugListGeneric();
                    drugList.GenericName = item.Genericdrugname;
                    drugList.DrugObjectID = item.ObjectID.Value;
                    drugList.GenericObjectID = item.Genericdrugobjectid.Value;
                    drugList.DrugName = item.Drugname;
                    drugList.Inheld = item.Inheld.Value;
                    drugList.Barcode = item.Barcode;
                    drugLists.Add(drugList);
                }
            }
            return drugLists;
        }
    }

}

namespace Core.Models
{
    public class DrugListGeneric
    {
        public Guid DrugObjectID { get; set; }
        public Guid GenericObjectID { get; set; }
        public string GenericName { get; set; }
        public string DrugName { get; set; }
        public Currency Inheld { get; set; }
        public string Barcode { get; set; }
    }

    public class DrugGenericListInputDTO
    {
        public string storeID { get; set; }
        public Guid genericID { get; set; }
    }
}
