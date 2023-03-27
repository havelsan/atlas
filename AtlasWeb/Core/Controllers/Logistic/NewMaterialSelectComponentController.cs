using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Models;
using Core.Services;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTObjectClasses.DTOs;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class NewMaterialSelectComponentController : Controller
    {

        [HttpPost]
        public List<NewMaterialSelectDTO> GetMaterials(MaterialPropertyRequestDTO model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<NewMaterialSelectDTO> output = new List<NewMaterialSelectDTO>();
                Material material = (Material)objectContext.GetObject(model.MaterialIds[0], typeof(Material));
                NewMaterialSelectDTO dto = new NewMaterialSelectDTO();
                dto.Material = material;
                dto.StockCard = material.StockCard;
                dto.StockLevelType = StockLevelType.NewStockLevel;
                if (model.Store.HasValue)
                {
                    Store store = (Store)objectContext.GetObject(model.Store.Value, typeof(Store));
                    dto.StoreStock = material.StockInheld(store, StockLevelType.NewStockLevel);
                }
                else
                    dto.StoreStock = 0;
                if (model.DestinationStore.HasValue)
                {
                    Store destinationStore = (Store)objectContext.GetObject(model.DestinationStore.Value, typeof(Store));
                    dto.DestinationStoreStock = material.StockInheld(destinationStore, StockLevelType.NewStockLevel);
                    dto.DestinationStoreMaxLevel = destinationStore.GetStock(material).MaximumLevel.Value;
                }
                else
                {
                    dto.DestinationStoreStock = 0;
                    dto.DestinationStoreMaxLevel = 0;
                }
                dto.VatRate = GetVatRate(material.ObjectID, model.Date.Value);
                output.Add(dto);
                objectContext.FullPartialllyLoadedObjects();
                return output;

            }
        }

        [HttpGet]
        public double? GetVatRate(Guid materialId, DateTime date)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                var materialVatRates = context.MaterialVatRate.Where(p => p.MaterialRef == materialId && p.StartDate <= date && p.EndDate >= date).FirstOrDefault();
                return materialVatRates?.VatRate;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]

        public LoadResult GetMaterialList([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] MKYS_EMalzemeGrupEnum materialGroup, [FromQuery] TransactionTypeEnum transactionType, [FromQuery] Guid storeID)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef;
                if (transactionType == TransactionTypeEnum.In)
                {
                    if (materialGroup == MKYS_EMalzemeGrupEnum.ilac)
                        queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetNewDrugInListQuery"];
                    else
                        queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetNewMaterialInListQuery"];
                }
                else
                    queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetNewMaterialOutListQuery"];


                var paramList = new Dictionary<string, object>();
                var injection = string.Empty;
                paramList = GetFilter(paramList, materialGroup, ref injection);
                if (transactionType == TransactionTypeEnum.Out)
                    injection = injection + "STOCKS.STORE =" + TTConnectionManager.ConnectionManager.GuidToString(storeID) + " AND STOCKS.INHELD > 0";

                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        public LoadResult GetTreatmentMaterialList([FromBody] DataSourceLoadOptions loadOptions,  [FromQuery] string filterExpretion)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetAllowedDrugAndMaterialListQuery"];

                var paramList = new Dictionary<string, object>();
                var injection = filterExpretion;
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        private Dictionary<string, object> GetFilter(Dictionary<string, object> filter, MKYS_EMalzemeGrupEnum materialGroup, ref string injection)
        {
            if (materialGroup == MKYS_EMalzemeGrupEnum.tibbiSarf)
            {
                filter.Add("OBJECTDEFID", "58d34696-808e-47de-87e0-1f001d0928a7");
            }
            if (materialGroup == MKYS_EMalzemeGrupEnum.ilac)
            {
                filter.Add("OBJECTDEFID", "65a2337c-bc3c-4c6b-9575-ad47fa7a9a89");
            }
            if (materialGroup == MKYS_EMalzemeGrupEnum.tibbiCihaz)
            {
                filter.Add("OBJECTDEFID", "f38f2111-0ee4-4b9f-9707-a63ac02d29f4");
            }
            return filter;
        }
    }
}