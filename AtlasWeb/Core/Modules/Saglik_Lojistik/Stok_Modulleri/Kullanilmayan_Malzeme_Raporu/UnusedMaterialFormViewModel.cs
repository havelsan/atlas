using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using TTInstanceManagement;

namespace Core.Models
{
    public class UnusedMaterialFormViewModel
    {
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

        public Guid StoreID
        {
            get;
            set;
        }
        public List<Guid> OutStoreIDList
        {
            get;
            set;
        }

        //public List<Material> MaterialList
        //{
        //    get;
        //    set;
        //}

        //public List<MaterialModel> SelectedMaterialList
        //{
        //    get;
        //    set;
        //}

        public Guid SelectedFilterStore
        {
            get;
            set;
        }

        public List<string> StoresName
        {
            get;
            set;
        }

        public List<Guid> SelectedStockOutTypeList
        {
            get;
            set;
        }

        public bool showUnused
        {
            get;
            set;
        }
        public int filterAmount
        {
            get;
            set;
        }
        public Guid DoctorID
        {
            get;
            set;
        }
        public int DayQueryNumber
        {
            get;
            set;
        }

        public List<int> VademecumList
        {
            get;
            set;
        }
        public Boolean getEHU
        {
            get;
            set;
        }
        public Guid OutStoreID
        {
            get;
            set;
        }


    }

    public class UnusedResultModel
    {

        public int InAmount { get; set; } //giris miktari
        public int OutAmount { get; set; } //cikis miktari
        public int RestAmount { get; set; } // kalan miktar
        public string FirstMaterialName { get; set; }
        public string NatoStockNO { get; set; } //tasinir kod
        public string Barcode { get; set; }

    }
}
namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class UnusedMaterialServiceController : Controller
    {
        public List<UnusedResultModel> GetUnusedMaterials(UnusedMaterialFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<UnusedResultModel> stockactionlist = new List<UnusedResultModel>();

                DateTime date = viewModel.EndDate;
                DateTime givenDate = date.AddDays((-1) * viewModel.DayQueryNumber);

                BindingList<Stock.GetUnusedStockWithDay_Class> unusedStocks = Stock.GetUnusedStockWithDay(viewModel.StoreID, givenDate, date, viewModel.filterAmount); 
                Dictionary<Guid, UnusedResultModel> outputDic = new Dictionary<Guid, UnusedResultModel>();
                foreach (Stock.GetUnusedStockWithDay_Class stock in unusedStocks)
                {
                    BindingList<StockTransaction.RestLIFOStockTransactionsRQ_Class> outtableTRx = StockTransaction.RestLIFOStockTransactionsRQ(stock.ObjectID.Value);
                    foreach (StockTransaction.RestLIFOStockTransactionsRQ_Class t in outtableTRx)
                    {
                        StockTransaction intrx = objectContext.GetObject<StockTransaction>(t.ObjectID.Value);
                        if (outputDic.ContainsKey(intrx.Stock.ObjectID) == false)
                        {
                            UnusedResultModel result = new UnusedResultModel();
                            result.RestAmount = Convert.ToInt32(t.Restamount);
                            result.FirstMaterialName = intrx.StockActionDetail.Material.Name;
                            result.OutAmount = Convert.ToInt32(t.Usedamount);
                            result.InAmount = (int)intrx.Amount;
                            result.NatoStockNO = intrx.Stock.Material.StockCard.NATOStockNO;
                            result.Barcode = intrx.StockActionDetail.Material.Barcode;
                            outputDic.Add(intrx.Stock.ObjectID, result);
                        }
                        else
                        {
                            outputDic[intrx.Stock.ObjectID].RestAmount = outputDic[intrx.Stock.ObjectID].RestAmount + Convert.ToInt32(t.Restamount);
                            outputDic[intrx.Stock.ObjectID].OutAmount = outputDic[intrx.Stock.ObjectID].OutAmount + Convert.ToInt32(t.Usedamount);
                            outputDic[intrx.Stock.ObjectID].InAmount = outputDic[intrx.Stock.ObjectID].InAmount + (int)intrx.Amount;
                        }
                    }
                }
                foreach (KeyValuePair<Guid, UnusedResultModel> output in outputDic)
                    stockactionlist.Add(output.Value);

                return stockactionlist;
            }
        }

        public BindingList<MaterialModel> GetMaterialsBySelectedStores(UnusedMaterialFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                string filter = "WHERE STOCKS.STORE =  ";

                if (viewModel.SelectedFilterStore != null && viewModel.SelectedFilterStore.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    filter += "'" + viewModel.SelectedFilterStore.ToString() + "' ";
                }
                else
                {
                    filter += "'" + viewModel.StoreID + "' ";
                }

                BindingList<Material.GetMaterialsForMultiSelectForm_Class> resultList = new BindingList<Material.GetMaterialsForMultiSelectForm_Class>();
                BindingList<Material.GetMaterialsForMultiSelectForm_Class> materialList = Material.GetMaterialsForMultiSelectForm(objectContext, filter);
                BindingList<MaterialModel> result = new BindingList<MaterialModel>();

                foreach (Material.GetMaterialsForMultiSelectForm_Class material in materialList)
                {
                    MaterialModel model = new MaterialModel();
                    model.Name = material.Name;
                    model.ID = material.ObjectID;

                    result.Add(model);
                }
                return result;
            }
        }

        [HttpPost]
        public List<ResUser.ClinicDoctorListNQL_Class> FillDataSources()
        {
            List<ResUser.ClinicDoctorListNQL_Class> DoctorList = ResUser.ClinicDoctorListNQL(null).ToList();
            return DoctorList;
        }

        [HttpPost]
        public List<SubStoreDefinition.GetSubStoreDefinition_Class> FillStoreDataSources()
        {
            string filter = "WHERE THIS.ISACTIVE = 1";
            List<SubStoreDefinition.GetSubStoreDefinition_Class> OutStoreList = SubStoreDefinition.GetSubStoreDefinition(filter).ToList();
            return OutStoreList;
        }
    }
}