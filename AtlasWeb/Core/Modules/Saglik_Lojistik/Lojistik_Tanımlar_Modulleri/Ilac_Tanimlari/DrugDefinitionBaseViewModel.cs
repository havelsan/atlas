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
    public partial class DrugDefinitionBaseViewModelServiceController : Controller
    {

        [HttpPost]
        public DrugDefinitionBaseViewModel WorkListQuery(QueryFilter param)
        {

            TTObjectContext context = new TTObjectContext(false);
            DrugDefinitionBaseViewModel viewModel = new DrugDefinitionBaseViewModel();
            string filterExpression = "WHERE 1=1";
          
            if (param.IsActive == 1)
                filterExpression += " AND THIS.IsActive = 1";
            else if (param.IsActive == 0)
                filterExpression += " AND THIS.IsActive = 0";

            if (param.ShowZeroOnDrugOrder == 1)
                filterExpression += " AND THIS.ShowZeroOnDrugOrder = 1";
            else if (param.ShowZeroOnDrugOrder == 0)
                filterExpression += " AND THIS.ShowZeroOnDrugOrder = 0";

            if (param.DrugSpecs.Length != 0)
            {
                filterExpression += " AND " + Common.CreateFilterExpressionOfIntegerList("", "THIS.DRUGSPECIFICATIONS.DRUGSPECIFICATION  ", param.DrugSpecs.ToList());
            }
            if (param.DrugShape.Length != 0)
            {
                filterExpression += " AND " + Common.CreateFilterExpressionOfIntegerList("", "THIS.DRUGSHAPETYPE ", param.DrugShape.ToList());

            }

            if (param.IsInheld == 1)
                filterExpression += " AND THIS.Stocks.Store = '" + param.StoreID + "' AND THIS.Stocks.Inheld IS NOT NULL AND THIS.Stocks.Inheld <> 0";
            else if (param.IsInheld == 0)
                filterExpression += " AND THIS.Stocks.Store = '" + param.StoreID + "' AND THIS.Stocks.Inheld IS NOT NULL AND THIS.Stocks.Inheld <> 1";

            if (param.ShowZeroDistributionInfo == 1)
                filterExpression += " AND THIS.ShowZeroOnDistributionInfo = 1";
            else if (param.ShowZeroDistributionInfo == 0)
                filterExpression += " AND THIS.ShowZeroOnDistributionInfo = 1";

            if (param.ActionStatus == 1)
                filterExpression += " AND " + Common.CreateFilterExpressionOfGuidList("", "THIS.OBJECTID", Stock.GetMaterialForOutVoucherForm("").Select(x => new Guid(x.Material.ToString())).ToList());
            else if (param.ActionStatus == 0)
                filterExpression += " AND " + Common.CreateFilterExpressionOfGuidList("", "THIS.OBJECTID <>", Stock.GetMaterialForOutVoucherForm("").Select(x => new Guid(x.Material.ToString())).ToList());


            viewModel.GridDataSource = DrugDefinition.GetDrugDefinitionGrid(context, filterExpression).ToList();
            return viewModel;
        }

    }
}

namespace Core.Models
{
    public class DrugDefinitionBaseViewModel
    {
        public QueryFilter QueryModel { get; set; }
        public List<DrugDefinition.GetDrugDefinitionGrid_Class> GridDataSource = new List<DrugDefinition.GetDrugDefinitionGrid_Class>();
    }

    public class DrugDefinitionQueryFilter
    {
        public string StoreID { get; set; }
        public int IsActive { get; set; }
        public int ShowZeroOnDrugOrder { get; set; }
        // public int []DrugSpecifications { get; set; }
        public int IsInheld { get; set; }
        public int ShowZeroDistributionInfo { get; set; }
        public int ActionStatus { get; set; }
        public bool AllDrugSpecifications { get; set; }
        public bool AllDrugShapeType { get; set; }
        public int[] DrugShape { get; set; }
        public int[] DrugSpecs { get; set; }
        // public int [] DrugShapeTypeList { get; set; }
    }

    public class DrugDefinitionEnumItem
    {
        public int Code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int ordinal { get; set; }
    }
}