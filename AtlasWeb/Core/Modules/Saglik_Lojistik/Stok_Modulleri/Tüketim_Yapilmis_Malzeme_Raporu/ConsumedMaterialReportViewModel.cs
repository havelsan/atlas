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
    public partial class ConsumedMaterialReportServiceController : Controller
    {

        [HttpPost]
        public List<ConsumedMaterialReportOutputDTO> GetConsumedMaterial(ConsumedMaterialReportInputDTO input)
        {
            List<ConsumedMaterialReportOutputDTO> storeOutTotalOutputDTO = new List<ConsumedMaterialReportOutputDTO>();
            string injectionSQL = string.Empty;
            bool budgettypeflag = false;

            IList<string> storeIDList = input.storeIDList;

            if (input.budgettypeID != Guid.Empty)
            {
                budgettypeflag = true;
            }


            storeOutTotalOutputDTO = StockTransaction.ConsumedMaterialReportQuery(budgettypeflag, input.budgettypeID, input.EndDate, input.StartDate, storeIDList).Select(item => new ConsumedMaterialReportOutputDTO()
            {
                UnitePrice = Double.Parse(item.Uniteprice.ToString()),
                Amount = Double.Parse(item.Amount.ToString()),
                StockCardClassCode = item.Stockcardclasscode,
                BudgetTypeName = item.Budgettypedefinition,
                StockCardClassName = item.Stockcardclassname,
                StoreName = item.Storename,
            }).ToList();


            return storeOutTotalOutputDTO;
        }
    }

}

namespace Core.Models
{

    public class ConsumedMaterialReportInputDTO
    {
        public List<string> storeIDList { get; set; }
        public Guid budgettypeID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class ConsumedMaterialReportOutputDTO
    {
        public string StoreName { get; set; }
        public string StockCardClassCode { get; set; }
        public string StockCardClassName { get; set; }
        public string BudgetTypeName { get; set; }
        public Double Amount { get; set; }
        public Double UnitePrice { get; set; }
    }
}
