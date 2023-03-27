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
    public partial class DrugAtcReportServiceController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LoadResult GetAtcDefList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                TTList ttList = TTList.NewList(objectContext, listDef, string.Empty);

                result = DevexpressLoader.Load(objectContext, ttList, loadOptions, new Dictionary<string, object>(), searchText);
            }

            return result;
        }

        public List<DrugList> GetDrugList(DrugListInputDTO input)
        {
            List<DrugList> drugLists = new List<DrugList>();
            using (var context = new TTObjectContext(false))
            {
                string injectionSQL = string.Empty;
                if (input.atcID != Guid.Empty)
                {
                    injectionSQL = " AND THIS.DRUGATCS.ATC = " + TTConnectionManager.ConnectionManager.GuidToString(input.atcID);
                }
                BindingList<DrugDefinition.GetDrugDefListByATC_Class> getDrugs = DrugDefinition.GetDrugDefListByATC(input.storeID, injectionSQL);
                foreach (DrugDefinition.GetDrugDefListByATC_Class item in getDrugs)
                {
                    DrugList drugList = new DrugList();
                    drugList.ATCName = item.Atcname;
                    drugList.DrugObjectID = item.ObjectID.Value;
                    drugList.AtcObjectID = item.Atcobjectid.Value;
                    drugList.DrugName = item.Name;
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
    public class DrugList
    {
        public Guid DrugObjectID { get; set; }
        public Guid AtcObjectID { get; set; }
        public string ATCName { get; set; }
        public string DrugName { get; set; }
        public Currency Inheld { get; set; }
        public string Barcode { get; set; }
    }

    public class DrugListInputDTO
    {
        public string storeID { get; set; }
        public Guid atcID { get; set; }
    }
}
