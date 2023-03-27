//$DFAA5801
using System;
using System.Linq;
using System.Net.Http;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class VoucherDistributingDocumentServiceController : Controller
    {
        [HttpGet]
        public BaseVoucherDistributingDocumentFormViewModel BaseVoucherDistributingDocumentForm(Guid? id)
        {
            var FormDefID = Guid.Parse("4f4a6d53-174c-44b9-ac8b-2c18b69e903c");
            var ObjectDefID = Guid.Parse("40ef9785-09fb-4611-b424-1a1ade4ef5cb");
            var viewModel = new BaseVoucherDistributingDocumentFormViewModel();
            if (id.HasValue)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._VoucherDistributingDocument = objectContext.GetObject(id.Value, ObjectDefID) as VoucherDistributingDocument;
                    viewModel.StockActionSignDetailsGridList = viewModel._VoucherDistributingDocument.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
                    viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
                    viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void BaseVoucherDistributingDocumentForm(BaseVoucherDistributingDocumentFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(viewModel._VoucherDistributingDocument);
                if (viewModel._VoucherDistributingDocument.StockActionSignDetails != null)
                {
                    foreach (var item in viewModel._VoucherDistributingDocument.StockActionSignDetails)
                    {
                        objectContext.AddObject(item);
                    }
                }

                objectContext.Save();
            }
        }

        [HttpGet]
        public VoucherDistributingDocumentApprovalFormViewModel VoucherDistributingDocumentApprovalForm(Guid? id)
        {
            var FormDefID = Guid.Parse("da0fe72d-d496-495e-a1bb-e4155cf19a55");
            var ObjectDefID = Guid.Parse("40ef9785-09fb-4611-b424-1a1ade4ef5cb");
            var viewModel = new VoucherDistributingDocumentApprovalFormViewModel();
            if (id.HasValue)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._VoucherDistributingDocument = objectContext.GetObject(id.Value, ObjectDefID) as VoucherDistributingDocument;
                    viewModel.StockActionOutDetailsGridList = viewModel._VoucherDistributingDocument.VoucherDistributingDocumentMaterials.OfType<VoucherDistributingDocumentMaterial>().ToArray();
                    viewModel.StockActionSignDetailsGridList = viewModel._VoucherDistributingDocument.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
                    viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
                    viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
                    viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
                    viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
                    viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
                    viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void VoucherDistributingDocumentApprovalForm(VoucherDistributingDocumentApprovalFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(viewModel._VoucherDistributingDocument);
                if (viewModel._VoucherDistributingDocument.VoucherDistributingDocumentMaterials != null)
                {
                    foreach (var item in viewModel._VoucherDistributingDocument.VoucherDistributingDocumentMaterials)
                    {
                        objectContext.AddObject(item);
                    }
                }

                if (viewModel._VoucherDistributingDocument.StockActionSignDetails != null)
                {
                    foreach (var item in viewModel._VoucherDistributingDocument.StockActionSignDetails)
                    {
                        objectContext.AddObject(item);
                    }
                }

                objectContext.Save();
            }
        }

        [HttpGet]
        public VoucherDistributingDocumentNewFormViewModel VoucherDistributingDocumentNewForm(Guid? id)
        {
            var FormDefID = Guid.Parse("63736da2-113d-4ad6-b6a9-aecfd1049732");
            var ObjectDefID = Guid.Parse("40ef9785-09fb-4611-b424-1a1ade4ef5cb");
            var viewModel = new VoucherDistributingDocumentNewFormViewModel();
            if (id.HasValue)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._VoucherDistributingDocument = objectContext.GetObject(id.Value, ObjectDefID) as VoucherDistributingDocument;
                    var destinationStore = viewModel._VoucherDistributingDocument.DestinationStore;
                    if (destinationStore != null)
                    {
                        viewModel.StocksStockGridList = destinationStore.Stocks.OfType<Stock>().ToArray();
                    }

                    var store = viewModel._VoucherDistributingDocument.Store;
                    if (store != null)
                    {
                        viewModel.StocksStockGridGridList = store.Stocks.OfType<Stock>().ToArray();
                    }

                    viewModel.StockActionOutDetailsGridList = viewModel._VoucherDistributingDocument.VoucherDistributingDocumentMaterials.OfType<VoucherDistributingDocumentMaterial>().ToArray();
                    viewModel.StockActionSignDetailsGridList = viewModel._VoucherDistributingDocument.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
                    viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
                    viewModel.UnitStoreGetDatas = objectContext.LocalQuery<UnitStoreGetData>().ToArray();
                    viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
                    viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
                    viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
                    viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
                    viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void VoucherDistributingDocumentNewForm(VoucherDistributingDocumentNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(viewModel._VoucherDistributingDocument);
                var destinationStore = viewModel._VoucherDistributingDocument.DestinationStore;
                if (destinationStore != null)
                {
                    if (destinationStore.Stocks != null)
                    {
                        foreach (var item in destinationStore.Stocks)
                        {
                            objectContext.AddObject(item);
                        }
                    }
                }

                var store = viewModel._VoucherDistributingDocument.Store;
                if (store != null)
                {
                    if (store.Stocks != null)
                    {
                        foreach (var item in store.Stocks)
                        {
                            objectContext.AddObject(item);
                        }
                    }
                }

                if (viewModel._VoucherDistributingDocument.VoucherDistributingDocumentMaterials != null)
                {
                    foreach (var item in viewModel._VoucherDistributingDocument.VoucherDistributingDocumentMaterials)
                    {
                        objectContext.AddObject(item);
                    }
                }

                if (viewModel._VoucherDistributingDocument.StockActionSignDetails != null)
                {
                    foreach (var item in viewModel._VoucherDistributingDocument.StockActionSignDetails)
                    {
                        objectContext.AddObject(item);
                    }
                }

                objectContext.Save();
            }
        }
    }
}