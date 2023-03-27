//$695CB4AC
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TTDefinitionManagement;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class ProcedureDefinitionServiceController : Controller
    {
        public class GetProcedurePricingDetail_Input
        {
            public TTObjectClasses.ProcedureDefinition procedureDefinition { get; set; }
            public TTObjectClasses.PricingListDefinition pPricingList { get; set; }
            public DateTime? pDate { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public ArrayList GetProcedurePricingDetail(GetProcedurePricingDetail_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.procedureDefinition != null)
                    input.procedureDefinition = (TTObjectClasses.ProcedureDefinition)objectContext.AddObject(input.procedureDefinition);
                if (input.pPricingList != null)
                    input.pPricingList = (TTObjectClasses.PricingListDefinition)objectContext.AddObject(input.pPricingList);
                var ret = ProcedureDefinition.GetProcedurePricingDetail(input.procedureDefinition, input.pPricingList, input.pDate);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
        public class GetActiveByCode_Input
        {
            public TTObjectContext context { get; set; }
            public string Code { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public TTObjectClasses.ProcedureDefinition GetActiveByCode(GetActiveByCode_Input input)
        {
            var ret = ProcedureDefinition.GetActiveByCode(input.context, input.Code);
            return ret;
        }
        public class GetSUTPointByProcedureObjectId_Input
        {
            public Guid procedureObjId { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public double GetSUTPointByProcedureObjectId(GetSUTPointByProcedureObjectId_Input input)
        {
            var ret = ProcedureDefinition.GetSUTPointByProcedureObjectId(input.procedureObjId);
            return ret;
        }
        public class GetSUTPoint_Input
        {
            public TTObjectClasses.ProcedureDefinition procedureDef { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public double GetSUTPoint(GetSUTPoint_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.procedureDef != null)
                    input.procedureDef = (TTObjectClasses.ProcedureDefinition)objectContext.AddObject(input.procedureDef);
                var ret = ProcedureDefinition.GetSUTPoint(input.procedureDef);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
        public class GetProcedureDefinitionNames_Input
        {
            public TTObjectClasses.ActionTypeEnum actionType { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public string GetProcedureDefinitionNames(GetProcedureDefinitionNames_Input input)
        {
            var ret = ProcedureDefinition.GetProcedureDefinitionNames(input.actionType);
            return ret;
        }

        [HttpPost]
        public MatchingFormViewModel GetStoresForMaterialMatching(Guid ProcedureID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                MatchingFormViewModel viewModel = new MatchingFormViewModel();
                List<Store> StoreList = Store.GetAllStores(objectContext).ToList();
                StoreList = StoreList.Where(store => store.IsActive == true).ToList();
                viewModel.stores = StoreList;
                viewModel.matches = CreateMatchingGridDataSource(objectContext, ProcedureID);
                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LoadResult GetMaterialList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {

                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetAllowedDrugAndMaterialListQuery"];
                var paramList = new Dictionary<string, object>();
                var injection = "MKYSMALZEMEKODU IS NOT NULL";
                loadOptions.Take = Int32.MaxValue;
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }
    }
}