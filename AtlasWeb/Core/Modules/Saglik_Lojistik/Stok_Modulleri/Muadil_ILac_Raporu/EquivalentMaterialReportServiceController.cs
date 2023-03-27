using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.Bond;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;
using Core.Security;
using System.Collections;

namespace Core.Controllers.EquivalentMaterialReport
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class EquivalentMaterialReportServiceController : Controller
    {
        [HttpGet]
        public EquivalentMaterialReportFormViewModel InitEquivalentMaterialReportForm(Guid storeObjectID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                EquivalentMaterialReportFormViewModel equivalentMaterialReportFormViewModel = new EquivalentMaterialReportFormViewModel();
                Store selectedStore = objectContext.GetObject<Store>(storeObjectID);
                if (selectedStore is PharmacyStoreDefinition)
                {
                    equivalentMaterialReportFormViewModel.ActiveIngredientDefinitions = objectContext.QueryObjects<ActiveIngredientDefinition>().Select(x => new ListMaterialsObject { ObjectID = x.ObjectID, Name = x.Name }).OrderBy(x => x.Name).ToList();
                }
                //else
                //    equivalentMaterialReportFormViewModel.MaterialList = objectContext.QueryObjects<ConsumableMaterialDefinition>().Select(x => new ListMaterialsObject { ObjectID = x.ObjectID, Name = x.Name }).ToList();

                return equivalentMaterialReportFormViewModel;
            }
        }

        [HttpPost]
        public List<ListMaterialsObject> GetMaterialsForFilter(MaterialSearchModel materialSearchModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                Store selectedStore = objectContext.GetObject<Store>(materialSearchModel.StoreObjectID);
                List<ListMaterialsObject> materialList = new List<ListMaterialsObject>();
                string filter = "";

                if (materialSearchModel.IsInheld)
                {
                    if (!string.IsNullOrEmpty(materialSearchModel.SearchText))
                        filter = " NAME_SHADOW like '" + materialSearchModel.SearchText.ToUpperInvariant() + "%' AND STOCKS(INHELD > 0 AND STORE = '" + materialSearchModel.StoreObjectID + "').EXISTS";
                }
                else
                {
                    if (!string.IsNullOrEmpty(materialSearchModel.SearchText))
                        filter = " NAME_SHADOW like '" + materialSearchModel.SearchText.ToUpperInvariant() + "%' AND ISACTIVE = 1 AND STOCKS(STORE = '" + materialSearchModel.StoreObjectID + "').EXISTS";
                }

                if (selectedStore is PharmacyStoreDefinition)
                {
                    List<DrugDefinition> drugDefinitions = objectContext.QueryObjects<DrugDefinition>(filter).ToList();

                    foreach (DrugDefinition item in drugDefinitions)
                    {
                        ListMaterialsObject listMaterialsObject = new ListMaterialsObject();
                        listMaterialsObject.Name = item.Name;
                        listMaterialsObject.ObjectID = item.ObjectID;
                        listMaterialsObject.InHeldAmount = item.Stocks.Select("").Sum(x => x.Inheld).ToString();
                        materialList.Add(listMaterialsObject);
                    }
                }
                else
                {
                    List<ConsumableMaterialDefinition> consumableMaterialDefinitions = objectContext.QueryObjects<ConsumableMaterialDefinition>(filter).ToList();
                    foreach (ConsumableMaterialDefinition item in consumableMaterialDefinitions)
                    {
                        ListMaterialsObject listMaterialsObject = new ListMaterialsObject();
                        listMaterialsObject.Name = item.Name;
                        listMaterialsObject.ObjectID = item.ObjectID;
                        listMaterialsObject.InHeldAmount = item.Stocks.Select("").Sum(x => x.Inheld).ToString();
                        materialList.Add(listMaterialsObject);
                    }
                }
                return materialList;
            }
        }

        [HttpPost]
        public List<EquivalentMaterialReportFormGridViewModel> GetEquivalentMaterials(EquivalentMaterialSearchModel searchModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                StringBuilder filter = new StringBuilder();
                Store selectedStore = objectContext.GetObject<Store>(searchModel.StoreObjectID);
                bool isSelectedStorePharmacy = selectedStore is PharmacyStoreDefinition;

                List<EquivalentMaterialReportFormGridViewModel> gridViewModel = new List<EquivalentMaterialReportFormGridViewModel>();
                if (!string.IsNullOrEmpty(searchModel.BarcodeNo))
                {
                    Material selectedMaterial = objectContext.QueryObjects<Material>("BARCODE = '" + searchModel.BarcodeNo + "'").FirstOrDefault();

                    if (isSelectedStorePharmacy)
                    {
                        DrugDefinition selectedDrug = (DrugDefinition)selectedMaterial;
                        //List<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> selectedDrugActiveIngredientDefs = ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + selectedDrug.ObjectID + "').EXISTS").ToList();
                        List<DrugActiveIngredient> selectedDrugActiveIngredientDefs = selectedDrug.DrugActiveIngredients.Select("").ToList();
                        filter.Append("EquivalentCRC = '" + selectedDrug.EquivalentCRC + "'");
                        filter.Append(" AND OBJECTID <> '" + selectedDrug.ObjectID + "'");
                        filter.Append(" AND STOCKS(STORE = '" + searchModel.StoreObjectID + "').EXISTS");
                        List<DrugDefinition> equivalentDrugDefinitions = objectContext.QueryObjects<DrugDefinition>(filter.ToString()).ToList();
                        EquivalentMaterialReportFormGridViewModel equivalentMaterialReportFormGridViewModel = new EquivalentMaterialReportFormGridViewModel
                        {
                            ActiveIngredientName = string.Join(",", selectedDrugActiveIngredientDefs.Select(x => x.ActiveIngredient.Name)),
                            BarcodeNo = selectedDrug.Barcode,
                            Name = selectedDrug.Name,
                            NatoStockNo = selectedDrug.NATOStockNO,
                            StockInheld = selectedDrug.Stocks.Select(" STORE ='" + searchModel.StoreObjectID + "'").Sum(x => x.Inheld).ToString()
                        };

                        foreach (DrugDefinition drugDefinition in equivalentDrugDefinitions)
                        {
                            IEnumerable<string> activeIngredientList = ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + selectedDrug.ObjectID + "').EXISTS").Select(x => x.Name);
                            string activeIngredients = string.Empty;
                            if (activeIngredientList.Count() > 1)
                                activeIngredients = string.Join(",", activeIngredientList);
                            else
                                activeIngredients = activeIngredientList.FirstOrDefault();

                            EquivalentMaterialReportFormGridViewModel equivalentDrug = new EquivalentMaterialReportFormGridViewModel
                            {
                                ActiveIngredientName = activeIngredients,
                                BarcodeNo = drugDefinition.Barcode,
                                Name = drugDefinition.Name,
                                NatoStockNo = drugDefinition.NATOStockNO
                            };
                            equivalentMaterialReportFormGridViewModel.EquivalentMaterials.Add(equivalentDrug);
                        };
                        gridViewModel.Add(equivalentMaterialReportFormGridViewModel);
                    }
                    else
                    {
                        //TODO: Sarf malzeme muadillerin çekilmesi yapılacak
                    }
                }
                else if (searchModel.SelectedMaterialList != null && searchModel.SelectedMaterialList.Count > 0)
                {
                    filter.Append(Common.CreateFilterExpressionOfGuidList("", "OBJECTID", searchModel.SelectedMaterialList.Select(x => x.ObjectID).ToList()));
                    filter.Append("AND STOCKS(STORE = '" + searchModel.StoreObjectID + "').EXISTS");
                    List<Material> selectedMaterials = objectContext.QueryObjects<Material>(filter.ToString()).ToList();
                    if (isSelectedStorePharmacy)
                    {
                        List<DrugDefinition> selectedDrugs = selectedMaterials.Cast<DrugDefinition>().ToList();
                        gridViewModel.AddRange(selectedDrugs.Select(x => new EquivalentMaterialReportFormGridViewModel
                        {
                            //ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + x.ObjectID + "').EXISTS").Select(y => y.Name)
                            ActiveIngredientName = string.Join(",", x.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient.Name)),
                            BarcodeNo = x.Barcode,
                            Name = x.Name,
                            NatoStockNo = x.NATOStockNO,
                            StockInheld = x.Stocks.Select(" STORE ='" + searchModel.StoreObjectID + "'").Sum(y => y.Inheld).ToString(),
                            MaterialObjectID = x.ObjectID
                        })
                        );
                        foreach (DrugDefinition drugDefinition in selectedDrugs)
                        {
                            filter = filter.Clear();
                            filter.Append(" EquivalentCRC = '" + drugDefinition.EquivalentCRC + "'");
                            filter.Append(" AND OBJECTID <> '" + drugDefinition.ObjectID + "'");
                            List<DrugDefinition> equivalentDrugs = objectContext.QueryObjects<DrugDefinition>(filter.ToString()).ToList();
                            gridViewModel.FirstOrDefault(x => x.MaterialObjectID == drugDefinition.ObjectID).EquivalentMaterials.AddRange(
                            equivalentDrugs.Select(x => new EquivalentMaterialReportFormGridViewModel
                            {
                                Name = x.Name,
                                MaterialObjectID = x.ObjectID,
                                //ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + x.ObjectID + "').EXISTS").Select(y => y.Name)
                                ActiveIngredientName = string.Join(",", x.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient.Name)),
                                BarcodeNo = x.Barcode,
                                NatoStockNo = x.NATOStockNO,
                                StockInheld = x.Stocks.Select(" STORE ='" + searchModel.StoreObjectID + "'").Sum(t => t.Inheld).ToString()
                            })
                            );
                        }
                    }
                    else
                    {
                        //TODO: Sarf malzeme muadillerin çekilmesi yapılacak
                    }
                }
                else if (searchModel.SelectedDrugActiveIngredients != null && searchModel.SelectedDrugActiveIngredients.Count > 0)
                {
                    if (isSelectedStorePharmacy)
                    {
                        string activeIngredientObjectIDs = Common.CreateFilterExpressionOfGuidList("", "ActiveIngredient.OBJECTID", searchModel.SelectedDrugActiveIngredients.Select(x => x.ObjectID).ToList());
                        filter.Append("DrugActiveIngredients(" + activeIngredientObjectIDs + ").EXISTS");
                        filter.Append(" AND STOCKS(STORE = '" + searchModel.StoreObjectID + "').EXISTS");
                        List<DrugDefinition> drugsWithActiveIngredient = objectContext.QueryObjects<DrugDefinition>(filter.ToString()).ToList();
                        gridViewModel.AddRange(drugsWithActiveIngredient.Select(x => new EquivalentMaterialReportFormGridViewModel
                        {
                            // ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + x.ObjectID + "').EXISTS").Select(y => y.Name)
                            ActiveIngredientName = string.Join(",", x.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient.Name)),
                            Name = x.Name,
                            BarcodeNo = x.Barcode,
                            MaterialObjectID = x.ObjectID,
                            NatoStockNo = x.NATOStockNO,
                            StockInheld = x.Stocks.Select(" STORE ='" + searchModel.StoreObjectID + "'").Sum(t => t.Inheld).ToString()
                        }));
                    }
                }
                else
                {
                    if (isSelectedStorePharmacy)
                    {
                        List<DrugDefinition> selectedDrugs = objectContext.QueryObjects<DrugDefinition>("STOCKS(STORE = '" + searchModel.StoreObjectID + "').EXISTS").ToList();
                        gridViewModel.AddRange(selectedDrugs.Select(x => new EquivalentMaterialReportFormGridViewModel
                        {
                            //ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + x.ObjectID + "').EXISTS").Select(y => y.Name)
                            ActiveIngredientName = string.Join(",", x.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient.Name)),
                            BarcodeNo = x.Barcode,
                            Name = x.Name,
                            NatoStockNo = x.NATOStockNO,
                            StockInheld = x.Stocks.Select(" STORE ='" + searchModel.StoreObjectID + "'").Sum(y => y.Inheld).ToString(),
                            MaterialObjectID = x.ObjectID
                        })
                        );
                        foreach (DrugDefinition drugDefinition in selectedDrugs)
                        {
                            filter = filter.Clear();
                            filter.Append("EquivalentCRC = '" + drugDefinition.EquivalentCRC + "'");
                            filter.Append(" AND OBJECTID <> '" + drugDefinition.ObjectID + "'");
                            List<DrugDefinition> equivalentDrugs = objectContext.QueryObjects<DrugDefinition>(filter.ToString()).ToList();
                            gridViewModel.FirstOrDefault(x => x.MaterialObjectID == drugDefinition.ObjectID).EquivalentMaterials.AddRange(
                            equivalentDrugs.Select(x => new EquivalentMaterialReportFormGridViewModel
                            {
                                Name = x.Name,
                                MaterialObjectID = x.ObjectID,
                                //ActiveIngredientDefinition.GetActiveIngredientDefinitions(" WHERE DrugActiveIngredients(DrugDefinition.OBJECTID = '" + x.ObjectID + "').EXISTS").Select(y => y.Name)
                                ActiveIngredientName = string.Join(",", x.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient.Name)),
                                BarcodeNo = x.Barcode,
                                NatoStockNo = x.NATOStockNO,
                                StockInheld = x.Stocks.Select(" STORE ='" + searchModel.StoreObjectID + "'").Sum(t => t.Inheld).ToString()
                            })
                            );
                        }
                    }
                    else
                    {
                        //TODO: Sarf malzeme muadillerin çekilmesi yapılacak
                    }
                }

                return gridViewModel;
            }
        }
    }


    //Seçilecek ilaçları arayıp bulan model
    public class MaterialSearchModel
    {
        public Guid StoreObjectID { get; set; }
        public string SearchText { get; set; }
        public bool IsInheld { get; set; }
    }

    //Listeleme için sunucuya gönderilecek olan arama kriterleri
    public class EquivalentMaterialSearchModel
    {
        public List<ListMaterialsObject> SelectedMaterialList = new List<ListMaterialsObject>();
        public List<ListMaterialsObject> SelectedDrugActiveIngredients = new List<ListMaterialsObject>();
        public string BarcodeNo { get; set; }
        public Guid StoreObjectID { get; set; }
    }

    //Filtreleme için dx-list (Malzeme listesi) doldurmak için oluşturulan obje
    public class ListMaterialsObject
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string InHeldAmount { get; set; }
    }

    //Form için oluşturulan viewmodel
    public class EquivalentMaterialReportFormViewModel
    {
        public EquivalentMaterialSearchModel SearchModel = new EquivalentMaterialSearchModel();
        public List<ListMaterialsObject> MaterialList = new List<ListMaterialsObject>();
        public List<ListMaterialsObject> ActiveIngredientDefinitions = new List<ListMaterialsObject>();
        public List<EquivalentMaterialReportFormGridViewModel> GridViewModel = new List<EquivalentMaterialReportFormGridViewModel>();
    }

    public class EquivalentMaterialReportFormGridViewModel
    {
        public string Name { get; set; }
        public string BarcodeNo { get; set; }
        public string NatoStockNo { get; set; }
        public string ActiveIngredientName { get; set; }
        public string StockInheld { get; set; }
        public Guid MaterialObjectID { get; set; }
        public List<EquivalentMaterialReportFormGridViewModel> EquivalentMaterials = new List<EquivalentMaterialReportFormGridViewModel>();
    }
}