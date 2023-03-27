//$6E917234
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
    public partial class ChemotherapyRadiotherapyServiceController : Controller
    {
        [HttpGet]
        public ChemotherapyRadiotherapyFormViewModel ChemotherapyRadiotherapyForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ChemotherapyRadiotherapyFormInternal(input);
        }

        [HttpPost]
        public ChemotherapyRadiotherapyFormViewModel ChemotherapyRadiotherapyFormLoad(FormLoadInput input)
        {
            return ChemotherapyRadiotherapyFormInternal(input);
        }


        public ChemotherapyRadiotherapyFormViewModel ChemotherapyRadiotherapyFormInternal(FormLoadInput input)
        {
            Guid? id = input.Id;

            var formDefID = Guid.Parse("2ffb9669-e4b1-4aed-a368-e80e94f4643f");
            var objectDefID = Guid.Parse("826e6f52-25ef-414d-84e9-38e7a38f3394");
            var viewModel = new ChemotherapyRadiotherapyFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ChemotherapyRadiotherapy = objectContext.GetObject(id.Value, objectDefID) as ChemotherapyRadiotherapy;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChemotherapyRadiotherapy, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChemotherapyRadiotherapy, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ChemotherapyRadiotherapy);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ChemotherapyRadiotherapy);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_ChemotherapyRadiotherapyForm(viewModel, viewModel._ChemotherapyRadiotherapy, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ChemotherapyRadiotherapy = new ChemotherapyRadiotherapy(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChemotherapyRadiotherapy, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChemotherapyRadiotherapy, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ChemotherapyRadiotherapy);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ChemotherapyRadiotherapy);
                    PreScript_ChemotherapyRadiotherapyForm(viewModel, viewModel._ChemotherapyRadiotherapy, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ChemotherapyRadiotherapyForm(ChemotherapyRadiotherapyFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ChemotherapyRadiotherapyFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ChemotherapyRadiotherapyFormInternal(ChemotherapyRadiotherapyFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("2ffb9669-e4b1-4aed-a368-e80e94f4643f");
            objectContext.AddToRawObjectList(viewModel._ChemotherapyRadiotherapy);
            objectContext.AddToRawObjectList(viewModel.TreatmentMaterialGridList);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.PlannedProcedureRequests);
            objectContext.ProcessRawObjects();

            var chemotherapyRadiotherapy = (ChemotherapyRadiotherapy)objectContext.GetLoadedObject(viewModel._ChemotherapyRadiotherapy.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(chemotherapyRadiotherapy, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChemotherapyRadiotherapy, formDefID);
            var transDef = chemotherapyRadiotherapy.TransDef;

            if (viewModel.TreatmentMaterialGridList != null)
            {
                foreach (var item in viewModel.TreatmentMaterialGridList)
                {
                    var treatmentMaterialImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)treatmentMaterialImported).IsDeleted)
                        continue;
                    treatmentMaterialImported.EpisodeAction = chemotherapyRadiotherapy;
                }
            }

            PostScript_ChemotherapyRadiotherapyForm(viewModel, chemotherapyRadiotherapy, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(chemotherapyRadiotherapy);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(chemotherapyRadiotherapy);
            AfterContextSaveScript_ChemotherapyRadiotherapyForm(viewModel, chemotherapyRadiotherapy, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_ChemotherapyRadiotherapyForm(ChemotherapyRadiotherapyFormViewModel viewModel, ChemotherapyRadiotherapy chemotherapyRadiotherapy, TTObjectContext objectContext);
        partial void PostScript_ChemotherapyRadiotherapyForm(ChemotherapyRadiotherapyFormViewModel viewModel, ChemotherapyRadiotherapy chemotherapyRadiotherapy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ChemotherapyRadiotherapyForm(ChemotherapyRadiotherapyFormViewModel viewModel, ChemotherapyRadiotherapy chemotherapyRadiotherapy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(ChemotherapyRadiotherapyFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.TreatmentMaterialGridList = viewModel._ChemotherapyRadiotherapy.TreatmentMaterials.OfType<ChemoRadiotherapyMaterial>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        }
    }
}


namespace Core.Models
{
    public partial class ChemotherapyRadiotherapyFormViewModel
    {
        public TTObjectClasses.ChemotherapyRadiotherapy _ChemotherapyRadiotherapy
        {
            get;
            set;
        }

    }
}
