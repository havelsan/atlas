//$84D7351D
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class StockActionDetailServiceController : Controller
    {
        [HttpGet]
        public BaseStockActionDetailFormViewModel BaseStockActionDetailForm(Guid? id)
        {
            var FormDefID = Guid.Parse("6cd75e91-ef3b-4297-af76-3745ffec51dd");
            var ObjectDefID = Guid.Parse("df97bda3-0d42-4ff4-81f3-d92eb10906d4");
            var viewModel = new BaseStockActionDetailFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._StockActionDetail = objectContext.GetObject(id.Value, ObjectDefID) as StockActionDetail;
                    viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
                    viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
            //using (var objectContext = new TTObjectContext(false))
            //{
            //    viewModel._StockActionDetail = new StockActionDetail(objectContext);
            //}
            }

            return viewModel;
        }

        [HttpPost]
        public void BaseStockActionDetailForm(BaseStockActionDetailFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var stockActionDetail = (StockActionDetail)objectContext.AddObject(viewModel._StockActionDetail);
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class BaseStockActionDetailFormViewModel
    {
        public TTObjectClasses.StockActionDetail _StockActionDetail
        {
            get;
            set;
        }

        public TTObjectClasses.StockLevelType[] StockLevelTypes
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }
    }
}