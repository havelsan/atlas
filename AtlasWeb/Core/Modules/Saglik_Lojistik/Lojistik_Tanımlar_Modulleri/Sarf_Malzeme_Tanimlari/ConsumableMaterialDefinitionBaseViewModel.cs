using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using TTConnectionManager;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ConsumableMaterialDefinitionBaseViewModelServiceController : Controller
    {

        [HttpPost]
        public  ConsumableMaterialDefinitionBaseViewModel WorkListQuery(QueryFilter param)
        {

            TTObjectContext context = new TTObjectContext(false);
            ConsumableMaterialDefinitionBaseViewModel viewModel = new ConsumableMaterialDefinitionBaseViewModel();
            string filterExpression = "WHERE 1=1 AND THIS.AllowToGivePatient = 1 "; //SADECE SARF MALZEME GELSİN

            if (param.IsActive == 1){ // durumu
                filterExpression += " AND THIS.IsActive = 1";
            }
            else if (param.IsActive == 0){
                filterExpression += " AND THIS.IsActive = 0";
            }
            if (param.IsInheld == 1){ //mevut
                filterExpression += " AND THIS.Stocks.Store = '" + param.StoreID + "' AND THIS.Stocks.Inheld IS NOT NULL AND THIS.Stocks.Inheld <> 0";
            }
            else if (param.IsInheld == 0){
                filterExpression += " AND THIS.Stocks.Store = '" + param.StoreID + "' AND THIS.Stocks.Inheld IS NOT NULL AND THIS.Stocks.Inheld <> 1";
            }
            if (param.ShowZeroDistributionInfo == 1){ //DAğıtım belgesinde gizlenen
                filterExpression += " AND THIS.ShowZeroOnDistributionInfo = 1";
            }
            else if (param.ShowZeroDistributionInfo == 0){
                filterExpression += " AND THIS.ShowZeroOnDistributionInfo = 1";
            }

            viewModel.GridDataSource = ConsumableMaterialDefinition.GetConsumableMaterialDefinition(context, filterExpression).ToList();
            return viewModel;
        }
    }
}

namespace Core.Models
{
    public class ConsumableMaterialDefinitionBaseViewModel
    {
        public QueryFilter QueryModel { get; set; }
        public List<ConsumableMaterialDefinition.GetConsumableMaterialDefinition_Class> GridDataSource = new List<ConsumableMaterialDefinition.GetConsumableMaterialDefinition_Class>();
    }

    public class ConsumableMaterialDefinitionQueryFilter
    {
        public string StoreID { get; set; }
        public int IsActive { get; set; }
        public int IsInheld { get; set; }
        public int ShowZeroDistributionInfo { get; set; }
        public int ActionStatus { get; set; }
    }

    public class ConsumableMaterialDefinitionEnumItem
    {
        public int Code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int ordinal { get; set; }
    }
}