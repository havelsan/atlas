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
    public partial class StoreInheldReportServiceController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LoadResult GetMaterialList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialListQuery"];
                var paramList = new Dictionary<string, object>();
                var injection = "MKYSMALZEMEKODU IS NOT NULL";
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        [HttpPost]
        public List<StockInheld> GetStockInheldList(StockInheldInputDTO input)
        {
            List<StockInheld> stockInheldList = new List<StockInheld>();
            string injectionSQL = string.Empty;
            bool materialflag = false;
            bool budgettypeflag = false;

            IList<string> storeIDList = input.storeIDList;

            if (input.budgettypeID != Guid.Empty)
            {
                budgettypeflag = true;
            }
            if (input.materialID != Guid.Empty)
            {
                materialflag = true;
            }

            stockInheldList = StockTransaction.GetStockInheldReportQuery(input.budgettypeID, storeIDList, input.materialID, budgettypeflag, materialflag).Select(item => new StockInheld()
            {
                MaterialObjectId = item.Materialobjectid.Value,
                Barcode = item.Barkod,
                BudgetTypeName = item.Budgettypedefinition,
                DistributionType = item.DistributionType,
                Inheld = Double.Parse(item.Restamount.ToString()),
                MaterialName = item.Materialname,
                StockCardNo = item.Stockcardnsn,
                StoreName = item.Storename
            }).ToList();

            return stockInheldList;
        }
    }

}

namespace Core.Models
{

    public class StockInheldInputDTO
    {
        public List<string> storeIDList { get; set; }
        public Guid materialID { get; set; }
        public Guid budgettypeID { get; set; }
    }

    public class StockInheld
    {
        public Guid MaterialObjectId { get; set; }
        public string MaterialName { get; set; }
        public string Barcode { get; set; }
        public string StockCardNo { get; set; }
        public Double Inheld { get; set; }

        public string StoreName { get; set; }
        public string BudgetTypeName { get; set; }
        public string DistributionType { get; set; }
    }
}
