//$18378A7E
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class MainStoreDistributionDocServiceController : Controller
    {
        [HttpGet]
        public MainStoreDistDocNewFormViewModel MainStoreDistDocNewForm(Guid? id)
        {
            var formDefID = Guid.Parse("4e3aad66-32c2-4ddc-8a86-bf378f18da16");
            var objectDefID = Guid.Parse("6adf5d47-8523-4995-9a0b-dfbb97e880b8");
            var viewModel = new MainStoreDistDocNewFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MainStoreDistributionDoc = objectContext.GetObject(id.Value, objectDefID) as MainStoreDistributionDoc;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MainStoreDistributionDoc, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainStoreDistributionDoc, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MainStoreDistributionDoc);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MainStoreDistributionDoc);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_MainStoreDistDocNewForm(viewModel, viewModel._MainStoreDistributionDoc, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MainStoreDistributionDoc = new MainStoreDistributionDoc(objectContext);
                    var entryStateID = Guid.Parse("30c8c1e7-59a4-405c-9b4b-4a5b1ad74a67");
                    viewModel._MainStoreDistributionDoc.CurrentStateDefID = entryStateID;
                    viewModel.MainStoreDistDocDetailsGridList = new TTObjectClasses.MainStoreDistDocDetail[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MainStoreDistributionDoc, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainStoreDistributionDoc, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MainStoreDistributionDoc);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MainStoreDistributionDoc);
                    PreScript_MainStoreDistDocNewForm(viewModel, viewModel._MainStoreDistributionDoc, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel MainStoreDistDocNewForm(MainStoreDistDocNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return MainStoreDistDocNewFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel MainStoreDistDocNewFormInternal(MainStoreDistDocNewFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("4e3aad66-32c2-4ddc-8a86-bf378f18da16");
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.MainStoreDistDocDetailsGridList);
            var entryStateID = Guid.Parse("30c8c1e7-59a4-405c-9b4b-4a5b1ad74a67");
            objectContext.AddToRawObjectList(viewModel._MainStoreDistributionDoc, entryStateID);
            objectContext.ProcessRawObjects(false);

            var mainStoreDistributionDoc = (MainStoreDistributionDoc)objectContext.GetLoadedObject(viewModel._MainStoreDistributionDoc.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(mainStoreDistributionDoc, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainStoreDistributionDoc, formDefID);

            if (viewModel.MainStoreDistDocDetailsGridList != null)
            {
                foreach (var item in viewModel.MainStoreDistDocDetailsGridList)
                {
                    var mainStoreDistDocDetailsImported = (MainStoreDistDocDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)mainStoreDistDocDetailsImported).IsDeleted)
                        continue;
                    mainStoreDistDocDetailsImported.MainStoreDistributionDoc = mainStoreDistributionDoc;
                }
            }
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(mainStoreDistributionDoc);
            PostScript_MainStoreDistDocNewForm(viewModel, mainStoreDistributionDoc, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(mainStoreDistributionDoc);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(mainStoreDistributionDoc);
            AfterContextSaveScript_MainStoreDistDocNewForm(viewModel, mainStoreDistributionDoc, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_MainStoreDistDocNewForm(MainStoreDistDocNewFormViewModel viewModel, MainStoreDistributionDoc mainStoreDistributionDoc, TTObjectContext objectContext);
        partial void PostScript_MainStoreDistDocNewForm(MainStoreDistDocNewFormViewModel viewModel, MainStoreDistributionDoc mainStoreDistributionDoc, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_MainStoreDistDocNewForm(MainStoreDistDocNewFormViewModel viewModel, MainStoreDistributionDoc mainStoreDistributionDoc, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(MainStoreDistDocNewFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.MainStoreDistDocDetailsGridList = viewModel._MainStoreDistributionDoc.MainStoreDistDocDetails.OfType<MainStoreDistDocDetail>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SubStoreList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        }
    }
}


namespace Core.Models
{
    public partial class MainStoreDistDocNewFormViewModel
    {
        public TTObjectClasses.MainStoreDistributionDoc _MainStoreDistributionDoc
        {
            get;
            set;
        }

        public TTObjectClasses.MainStoreDistDocDetail[] MainStoreDistDocDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Store[] Stores
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.StockCard[] StockCards
        {
            get;
            set;
        }

        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions
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
