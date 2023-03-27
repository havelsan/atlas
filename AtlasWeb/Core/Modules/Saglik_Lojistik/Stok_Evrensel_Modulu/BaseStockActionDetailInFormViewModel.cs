//$0899425B
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
    public partial class StockActionDetailInServiceController : Controller
    {
        [HttpGet]
        public BaseStockActionDetailInFormViewModel BaseStockActionDetailInForm(Guid? id)
        {
            var FormDefID = Guid.Parse("908d37ed-7fcb-48fc-94d3-c8e62f9e66c1");
            var ObjectDefID = Guid.Parse("f00404df-0a4a-4247-a43a-47029a35d34e");
            var viewModel = new BaseStockActionDetailInFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._StockActionDetailIn = objectContext.GetObject(id.Value, ObjectDefID) as StockActionDetailIn;
                    viewModel.FixedAssetDetailsGridList = viewModel._StockActionDetailIn.FixedAssetInDetails.OfType<FixedAssetInDetail>().ToArray();
                    viewModel.QRCodeInDetailsGridList = viewModel._StockActionDetailIn.QRCodeInDetails.OfType<QRCodeInDetail>().ToArray();
                    viewModel.Resources = objectContext.LocalQuery<Resource>().ToArray();
                    viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
                    viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                //viewModel._StockActionDetailIn = new StockActionDetailIn(objectContext);
                //viewModel.FixedAssetDetailsGridList = new TTObjectClasses.FixedAssetInDetail[] { };
                //viewModel.QRCodeInDetailsGridList = new TTObjectClasses.QRCodeInDetail[] { };
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void BaseStockActionDetailInForm(BaseStockActionDetailInFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var stockActionDetailIn = (StockActionDetailIn)objectContext.AddObject(viewModel._StockActionDetailIn);
                if (viewModel.FixedAssetDetailsGridList != null)
                {
                    foreach (var item in viewModel.FixedAssetDetailsGridList)
                    {
                        var fixedAssetInDetailsImported = (FixedAssetInDetail)objectContext.AddObject(item);
                        fixedAssetInDetailsImported.StockActionDetail = stockActionDetailIn;
                    }
                }

                if (viewModel.QRCodeInDetailsGridList != null)
                {
                    foreach (var item in viewModel.QRCodeInDetailsGridList)
                    {
                        var qRCodeInDetailsImported = (QRCodeInDetail)objectContext.AddObject(item);
                        qRCodeInDetailsImported.StockActionDetail = stockActionDetailIn;
                    }
                }

                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class BaseStockActionDetailInFormViewModel
    {
        public TTObjectClasses.StockActionDetailIn _StockActionDetailIn
        {
            get;
            set;
        }

        public TTObjectClasses.FixedAssetInDetail[] FixedAssetDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.QRCodeInDetail[] QRCodeInDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Resource[] Resources
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.StockLevelType[] StockLevelTypes
        {
            get;
            set;
        }
    }
}