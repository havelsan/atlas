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
    public partial class StoreInTotalReportServiceController : Controller
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
        public List<StoreInTotalOutputDTO> GetStockInList(StoreInTotalInputDTO input)
        {
            List<StoreInTotalOutputDTO> storeInTotalOutputDTO = new List<StoreInTotalOutputDTO>();
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

            string filterEx = " AND THIS.STOCKTRANSACTIONDEFINITION.ISTOTALSTOCKINREPORT = 1 "; 

            storeInTotalOutputDTO = StockTransaction.TotalInOutStockReportQuery(budgettypeflag, input.budgettypeID, input.materialID, storeIDList, materialflag, input.StartDate, input.EndDate, TransactionTypeEnum.In, filterEx).Select(item => new StoreInTotalOutputDTO()
            {
                MaterialObjectDefID = item.Materialobjectdefid.Value,
                MaterialObjectId = item.Materialobjectid.Value,
                Amount = Double.Parse(item.Amount.ToString()),
                Barcode = item.Materialbarcode,
                BudgetTypeName = item.Budgettypedefinition,
                DistributionType = item.DistributionType,
                MaterialName = item.Materialname,
                StockCardNo = item.Materialnsn,
                StoreName = item.Storename,
                UnitePrice = Double.Parse(item.UnitPrice.ToString()),
                TotalPrice = Double.Parse(item.Amount.ToString()) * Double.Parse(item.UnitPrice.ToString())

            }).ToList();

            if (input.drugSpecificationList.Count > 0)
            {
                List<StoreInTotalOutputDTO> drugSelectedSpe = new List<StoreInTotalOutputDTO>();
                List<StoreInTotalOutputDTO> drugdefinitionList = storeInTotalOutputDTO.Where(x => x.MaterialObjectDefID == new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89")).ToList();
                foreach (StoreInTotalOutputDTO item in drugdefinitionList)
                {
                    BindingList<DrugSpecifications.GetTypeOfDrugDefinition_Class> speDrugList = DrugSpecifications.GetTypeOfDrugDefinition(item.MaterialObjectId);
                    foreach (DrugSpecifications.GetTypeOfDrugDefinition_Class spe in speDrugList)
                    {
                        if (input.drugSpecificationList.Contains((int)spe.DrugSpecification))
                        {
                            drugSelectedSpe.Add(item);
                        }
                    }
                }
                return drugSelectedSpe;
            }
            else
            {
                return storeInTotalOutputDTO;
            }
        }
    }

}

namespace Core.Models
{

    public class StoreInTotalInputDTO
    {
        public List<string> storeIDList { get; set; }
        public Guid materialID { get; set; }
        public Guid budgettypeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> drugSpecificationList { get; set; }
    }

    public class StoreInTotalOutputDTO
    {
        public Guid MaterialObjectDefID { get; set; }
        public Guid MaterialObjectId { get; set; }
        public string MaterialName { get; set; }
        public string Barcode { get; set; }
        public string StockCardNo { get; set; }
        public Double Amount { get; set; }
        public Double UnitePrice { get; set; }
        public Double TotalPrice { get; set; }

        public string StoreName { get; set; }
        public string BudgetTypeName { get; set; }
        public string DistributionType { get; set; }
    }
}
