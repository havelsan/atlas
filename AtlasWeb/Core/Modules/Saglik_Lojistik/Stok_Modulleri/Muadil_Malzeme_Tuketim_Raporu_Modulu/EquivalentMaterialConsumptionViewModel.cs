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
using System.Text;
using TTDefinitionManagement;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class EquivalentMaterialConsumptionServiceController : Controller
    {

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public BindingList<MaterialGridItem> GetMaterialsInfoByExprationDate(MaterialReportByExpirationDateFilter_Input input)
        {

            using (var context = new TTObjectContext(false))
            {
                try
                {
                    int queryDay = input.DayQueryNumber;
                    DateTime start = DateTime.Now;
                    DateTime end = start.AddDays(queryDay);
                    string filterExpression = "";
                    if (input.Materials.Count > 0)
                    {
                        filterExpression += " AND THIS.Stock.Material IN ( ";
                        foreach (var item in input.Materials)
                            filterExpression += "'" + item + "',";
                        filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
                    }
                    if (input.DayQueryNumber != -1)
                    {
                        filterExpression += " AND EXPIRATIONDATE <= '" + (Convert.ToDateTime(end.Date).Date.ToShortDateString()) + "' ";
                    }

                    BindingList<StockTransaction.GetSelectedMaterialInHeldStoreByExpirationDate_Class> list = StockTransaction.GetSelectedMaterialInHeldStoreByExpirationDate(context, new Guid(input.StoreObjectId), input.StartDate, input.EndDate, filterExpression);
                    BindingList<MaterialGridItem> resultList = new BindingList<MaterialGridItem>();
                    foreach (var item in list)
                    {
                        MaterialGridItem materialItem = new MaterialGridItem();
                        materialItem.MaterialObjectID = item?.Materialobjectid?.ToString();
                        materialItem.ExpirationDate = item.ExpirationDate;
                        materialItem.Name = item.Name;
                        materialItem.NATOStockNO = item.NATOStockNO;
                        materialItem.Restamount = item.Restamount.ToString();
                        //    materialItem.MKYSStockTransactionID = item.Mkysstocktransactionid;

                        if (item.ExpirationDate != null)
                        {
                            DateTime now = DateTime.Now;
                            if (now < item.ExpirationDate)
                            {
                                TimeSpan time = item.ExpirationDate.Value.Subtract(now);
                                materialItem.DayLife = (int)time.TotalDays;
                            }
                            else
                            {
                                TimeSpan time = now.Subtract(item.ExpirationDate.Value);
                                materialItem.DayLife = -(int)time.TotalDays;
                            }
                        }
                        resultList.Add(materialItem);
                    }
                    return resultList;
                }
                //catch (ArgumentOutOfRangeException e)
                //{
                //    if (input.Materials.Count > 0)
                //        throw e;
                //    else
                //        throw new TTException("Lütfen materyal seçimi yapınız!");
                //}
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        [HttpPost]
        public List<DrugDefinition.GetDrugDefinitionList_Class> GetMaterialsForFilter(MaterialSearchModel materialSearchModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                Store selectedStore = objectContext.GetObject<Store>(materialSearchModel.StoreObjectID);
                List<DrugDefinition.GetDrugDefinitionList_Class> materialList = new List<DrugDefinition.GetDrugDefinitionList_Class>();
                string filter = "";

                //if (materialSearchModel.IsInheld)
                //{
                //    if (!string.IsNullOrEmpty(materialSearchModel.SearchText))
                //        filter = " NAME_SHADOW like '" + materialSearchModel.SearchText.ToUpperInvariant() + "%' AND STOCKS(INHELD > 0 AND STORE = '" + materialSearchModel.StoreObjectID + "').EXISTS";
                //}
                //else
                //{
                //    if (!string.IsNullOrEmpty(materialSearchModel.SearchText))
                //        filter = " NAME_SHADOW like '" + materialSearchModel.SearchText.ToUpperInvariant() + "%' AND ISACTIVE = 1 AND STOCKS(STORE = '" + materialSearchModel.StoreObjectID + "').EXISTS";
                //}
                //List<DrugDefinition> drugDefinitions = objectContext.QueryObjects<DrugDefinition>(filter).ToList();

                //foreach (DrugDefinition item in drugDefinitions)
                //{
                //    ListMaterialsObject listMaterialsObject = new ListMaterialsObject();
                //    listMaterialsObject.Name = item.Name;
                //    listMaterialsObject.ObjectID = item.ObjectID;
                //    listMaterialsObject.InHeldAmount = item.Stocks.Select("").Sum(x => x.Inheld).ToString();
                //    materialList.Add(listMaterialsObject);
                //}

                materialList = DrugDefinition.GetDrugDefinitionList(filter, null).ToList();
                 
               return materialList;
            }
        }

        public class MaterialSearchModel
        {
            public Guid StoreObjectID { get; set; }
            public bool IsInheld { get; set; }
        }

        public class DataSources
        {
            public List<ListMaterialsObject> MaterialList
            {
                get;
                set;
            }
            public List<ActiveIngredientDefinitionDTO> ActiveIngredientList
            {
                get;
                set;
            }
        }
        public class ListMaterialsObject
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public string InHeldAmount { get; set; }
        }
        public class ActiveIngredientDefinitionDTO
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
        }
        //[HttpPost]
        //public List<ActiveIngredientDefinitionDTO> FillDataSources()
        //{
        //    using (TTObjectContext objectContext = new TTObjectContext(false))
        //    {
        //        List<ActiveIngredientDefinitionDTO> output = new List<ActiveIngredientDefinitionDTO>();
        //        BindingList<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> ActiveIngredientList = ActiveIngredientDefinition.GetActiveIngredientDefinitions("");
        //        foreach (ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class activeIngredientDefinition in ActiveIngredientList)
        //        {
        //            ActiveIngredientDefinitionDTO activeIngredientDefinitionDTO = new ActiveIngredientDefinitionDTO();
        //            activeIngredientDefinitionDTO.ObjectID = activeIngredientDefinition.ObjectID.Value;
        //            activeIngredientDefinitionDTO.Name = activeIngredientDefinition.Name;
        //            output.Add(activeIngredientDefinitionDTO);
        //        }
        //        return output;
        //    }

        //}

        [HttpPost]
        public object FillDataSources(DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            if (loadOptions != null)
            {
                string definitionName = loadOptions.Params.definitionName;
                string searchText = loadOptions.Params.searchText;

                using (var objectContext = new TTObjectContext(true))
                {
                    TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                    TTList ttList = TTList.NewList(objectContext, listDef, string.Empty);

                    result = DevexpressLoader.Load(objectContext, ttList, loadOptions, new Dictionary<string, object>(), searchText);
                }
            }
            return result.data;
        }



        public class EquivalentMaterialConsumptionSearchModel
        {
            public Guid StoreObjectID
            {
                get;
                set;
            }
            public DateTime StartDate
            {
                get;
                set;
            }
            public DateTime EndDate
            {
                get;
                set;
            }
            public List<ListMaterialsObject> SelectedMaterialList
            {
                get;
                set;
            }
            public List<ListMaterialsObject> SelectedDrugActiveIngredients
            {
                get;
                set;
            }
        }

        public class EquivalentMaterialConsumptionFormGridViewModel
        {
            public string Name { get; set; }
            public string BarcodeNo { get; set; }
            public string NatoStockNo { get; set; }
            public string ActiveIngredientName { get; set; }
            public string TotalConsumption { get; set; }
            public Guid MaterialObjectID { get; set; }
            public List<EquivalentMaterialConsumptionFormGridViewModel> EquivalentMaterials = new List<EquivalentMaterialConsumptionFormGridViewModel>();
            public string Inheld { get; set; }

        }

        [HttpPost]
        public List<EquivalentMaterialConsumptionFormGridViewModel> GetEquivalentMaterialConsumption(EquivalentMaterialConsumptionSearchModel searchModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                StringBuilder filter = new StringBuilder();
                Store selectedStore = objectContext.GetObject<Store>(searchModel.StoreObjectID);

                List<EquivalentMaterialConsumptionFormGridViewModel> gridViewModel = new List<EquivalentMaterialConsumptionFormGridViewModel>();
                if (searchModel.SelectedMaterialList != null && searchModel.SelectedMaterialList.Count > 0)
                {
                    filter.Append(Common.CreateFilterExpressionOfGuidList("", "OBJECTID", searchModel.SelectedMaterialList.Select(x => x.ObjectID).ToList()));
                    filter.Append("AND STOCKS(STORE = '" + searchModel.StoreObjectID + "').EXISTS");
                    List<Material> selectedMaterials = objectContext.QueryObjects<Material>(filter.ToString()).ToList();
                    List<DrugDefinition> selectedDrugs = selectedMaterials.Cast<DrugDefinition>().ToList();
                    gridViewModel.AddRange(selectedDrugs.Select(x => new EquivalentMaterialConsumptionFormGridViewModel
                    {
                        //ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + x.ObjectID + "').EXISTS").Select(y => y.Name)
                        ActiveIngredientName = string.Join(",", x.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient.Name)),
                        BarcodeNo = x.Barcode,
                        Name = x.Name,
                        NatoStockNo = x.NATOStockNO,
                        TotalConsumption = StockTransaction.GetTotalEquivalentMaterialConsumption(searchModel.StoreObjectID, searchModel.StartDate, searchModel.EndDate, x.ObjectID)?.ToList()?.FirstOrDefault()?.Usedamount?.ToString(),
                        MaterialObjectID = x.ObjectID,
                        Inheld = Stock.StockInheldByStoreAndMaterial(searchModel.StoreObjectID.ToString(), x.ObjectID.ToString())?.ToList()?.FirstOrDefault()?.Inheld?.ToString()
                    })
                    );
                    foreach (DrugDefinition drugDefinition in selectedDrugs)
                    {
                        filter = filter.Clear();
                        filter.Append(" EquivalentCRC = '" + drugDefinition.EquivalentCRC + "'");
                        filter.Append(" AND OBJECTID <> '" + drugDefinition.ObjectID + "'");
                        List<DrugDefinition> equivalentDrugs = objectContext.QueryObjects<DrugDefinition>(filter.ToString()).ToList();
                        gridViewModel.FirstOrDefault(x => x.MaterialObjectID == drugDefinition.ObjectID).EquivalentMaterials.AddRange(
                        equivalentDrugs.Select(x => new EquivalentMaterialConsumptionFormGridViewModel
                        {
                            Name = x.Name,
                            MaterialObjectID = x.ObjectID,
                            //ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + x.ObjectID + "').EXISTS").Select(y => y.Name)
                            ActiveIngredientName = string.Join(",", x.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient.Name)),
                            BarcodeNo = x.Barcode,
                            NatoStockNo = x.NATOStockNO,
                            TotalConsumption = StockTransaction.GetTotalEquivalentMaterialConsumption(searchModel.StoreObjectID, searchModel.StartDate, searchModel.EndDate, x.ObjectID)?.ToList()?.FirstOrDefault()?.Usedamount?.ToString(),
                            Inheld = Stock.StockInheldByStoreAndMaterial(searchModel.StoreObjectID.ToString(), x.ObjectID.ToString())?.ToList()?.FirstOrDefault()?.Inheld?.ToString()

                        })
                        );
                    }
                }
                else if (searchModel.SelectedDrugActiveIngredients != null && searchModel.SelectedDrugActiveIngredients.Count > 0)
                {

                    string activeIngredientObjectIDs = Common.CreateFilterExpressionOfGuidList("", "ActiveIngredient.OBJECTID", searchModel.SelectedDrugActiveIngredients.Select(x => x.ObjectID).ToList());
                    filter.Append("DrugActiveIngredients(" + activeIngredientObjectIDs + ").EXISTS");
                    filter.Append(" AND STOCKS(STORE = '" + searchModel.StoreObjectID + "').EXISTS");
                    List<DrugDefinition> drugsWithActiveIngredient = objectContext.QueryObjects<DrugDefinition>(filter.ToString()).ToList();
                    gridViewModel.AddRange(drugsWithActiveIngredient.Select(x => new EquivalentMaterialConsumptionFormGridViewModel
                    {
                        // ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + x.ObjectID + "').EXISTS").Select(y => y.Name)
                        ActiveIngredientName = string.Join(",", x.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient.Name)),
                        Name = x.Name,
                        BarcodeNo = x.Barcode,
                        MaterialObjectID = x.ObjectID,
                        NatoStockNo = x.NATOStockNO,
                        TotalConsumption = StockTransaction.GetTotalEquivalentMaterialConsumption(searchModel.StoreObjectID, searchModel.StartDate, searchModel.EndDate, x.ObjectID)?.ToList()?.FirstOrDefault()?.Usedamount?.ToString(),
                        Inheld = Stock.StockInheldByStoreAndMaterial(searchModel.StoreObjectID.ToString(), x.ObjectID.ToString())?.ToList()?.FirstOrDefault()?.Inheld?.ToString()
                    }));

                }
                else
                {
                    List<DrugDefinition> selectedDrugs = objectContext.QueryObjects<DrugDefinition>("STOCKS(STORE = '" + searchModel.StoreObjectID + "').EXISTS").ToList();
                    gridViewModel.AddRange(selectedDrugs.Select(x => new EquivalentMaterialConsumptionFormGridViewModel
                    {
                        //ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + x.ObjectID + "').EXISTS").Select(y => y.Name)
                        ActiveIngredientName = string.Join(",", x.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient.Name)),
                        BarcodeNo = x.Barcode,
                        Name = x.Name,
                        NatoStockNo = x.NATOStockNO,
                        TotalConsumption = StockTransaction.GetTotalEquivalentMaterialConsumption(searchModel.StoreObjectID, searchModel.StartDate, searchModel.EndDate, x.ObjectID)?.ToList()?.FirstOrDefault()?.Usedamount?.ToString(),
                        MaterialObjectID = x.ObjectID,
                        Inheld = Stock.StockInheldByStoreAndMaterial(searchModel.StoreObjectID.ToString(), x.ObjectID.ToString())?.ToList()?.FirstOrDefault()?.Inheld?.ToString()
                    })
                    );
                    foreach (DrugDefinition drugDefinition in selectedDrugs)
                    {
                        filter = filter.Clear();
                        filter.Append("EquivalentCRC = '" + drugDefinition.EquivalentCRC + "'");
                        filter.Append(" AND OBJECTID <> '" + drugDefinition.ObjectID + "'");
                        List<DrugDefinition> equivalentDrugs = objectContext.QueryObjects<DrugDefinition>(filter.ToString()).ToList();
                        gridViewModel.FirstOrDefault(x => x.MaterialObjectID == drugDefinition.ObjectID).EquivalentMaterials.AddRange(
                        equivalentDrugs.Select(x => new EquivalentMaterialConsumptionFormGridViewModel
                        {
                            Name = x.Name,
                            MaterialObjectID = x.ObjectID,
                            //ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + x.ObjectID + "').EXISTS").Select(y => y.Name)
                            ActiveIngredientName = string.Join(",", x.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient.Name)),
                            BarcodeNo = x.Barcode,
                            NatoStockNo = x.NATOStockNO,
                            TotalConsumption = StockTransaction.GetTotalEquivalentMaterialConsumption(searchModel.StoreObjectID, searchModel.StartDate, searchModel.EndDate, x.ObjectID)?.ToList()?.FirstOrDefault()?.Usedamount?.ToString(),
                            Inheld = Stock.StockInheldByStoreAndMaterial(searchModel.StoreObjectID.ToString(), x.ObjectID.ToString())?.ToList()?.FirstOrDefault()?.Inheld?.ToString()
                        }));
                    }
                }

                return gridViewModel.Where(x => x.TotalConsumption != null && ( int.Parse(x.TotalConsumption) > 0 || (x.EquivalentMaterials.Where(y => y.TotalConsumption != null && int.Parse(y.TotalConsumption) > 0)).ToList().Count > 0)).ToList();
            }
        }
    }

}

namespace Core.Models
{
    public class EquivalentMaterialConsumptionViewModel
    {

    }
}
