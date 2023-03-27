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
    public class ReturnFormViewModel
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

    public class ReturnResultModel
    {
        public Guid MaterialObjectId { get; set; }
        public string MaterialName { get; set; }
        public double Amount { get; set; } 
        public double ReturnAmount { get; set; }
        public double Rate { get; set; }

    }
}
namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ReturnServiceController : Controller
    {
        public List<ReturnResultModel> GetReturns(ReturnFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<ReturnResultModel> Result = new List<ReturnResultModel>();

                BindingList<DrugReturnActionDetail.DrugReturnDetailPercent_Class> queryList = DrugReturnActionDetail.DrugReturnDetailPercent(viewModel.StartDate, viewModel.EndDate, viewModel.OutStoreID, viewModel.DoctorID);

                ReturnResultModel tmp;
                foreach (var item in queryList.ToList())
                {
                    tmp = new ReturnResultModel();
                    tmp.MaterialObjectId = item.Material.Value;
                    tmp.MaterialName = objectContext.GetObject<Material>(item.Material.Value).Name;

                    BindingList<StockTransaction> outTrxs = StockTransaction.GetOutputMaterials(objectContext, viewModel.StartDate, viewModel.EndDate, item.Storeid.Value, item.Material.Value);
                    //tmpAmount = item.Amount != null ? item.Amount.Value : 0;
                    tmp.Amount = Convert.ToDouble(outTrxs.Sum(x => x.Amount));
                    tmp.ReturnAmount = ((IConvertible)item.Returnamount).ToDouble(null);
                    tmp.Rate = tmp.Amount > 0 ? tmp.ReturnAmount / tmp.Amount * 100 : 0;
                    Result.Add(tmp);
                }
                return Result;
            }
        }

        public BindingList<MaterialModel> GetMaterialsBySelectedStores(ReturnFormViewModel viewModel)
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