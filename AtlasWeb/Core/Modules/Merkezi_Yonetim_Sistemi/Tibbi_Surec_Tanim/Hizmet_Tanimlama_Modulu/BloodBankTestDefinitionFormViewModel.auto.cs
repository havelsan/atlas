//$E72CDF07
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
    public partial class BloodBankTestDefinitionServiceController : Controller
    {

        [HttpGet]
        public BloodBankTestDefinitionFormViewModel BloodBankTestDefinitionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return BloodBankTestDefinitionFormInternal(input);
        }

        [HttpPost]
        public BloodBankTestDefinitionFormViewModel BloodBankTestDefinitionFormLoad(FormLoadInput input)
        {
            return BloodBankTestDefinitionFormInternal(input);
        }

        private BloodBankTestDefinitionFormViewModel BloodBankTestDefinitionFormInternal(FormLoadInput input)
        {
            Guid? id = input.Id;

            var formDefID = Guid.Parse("315d5c63-371a-460c-a7df-045c9dab3e16");
            var objectDefID = Guid.Parse("e0a1c9eb-5ab9-44cd-a1d3-6756165c6962");
            var viewModel = new BloodBankTestDefinitionFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._BloodBankTestDefinition = objectContext.GetObject(id.Value, objectDefID) as BloodBankTestDefinition;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BloodBankTestDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BloodBankTestDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BloodBankTestDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BloodBankTestDefinition);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_BloodBankTestDefinitionForm(viewModel, viewModel._BloodBankTestDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._BloodBankTestDefinition = new BloodBankTestDefinition(objectContext);
                    viewModel.GridProceduresGridList = new TTObjectClasses.BloodBankGridProcedureDefinition[] { };
                    viewModel.GridMaterialsGridList = new TTObjectClasses.BloodBankGridMaterialDefinition[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BloodBankTestDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BloodBankTestDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BloodBankTestDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BloodBankTestDefinition);
                    PreScript_BloodBankTestDefinitionForm(viewModel, viewModel._BloodBankTestDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel BloodBankTestDefinitionForm(BloodBankTestDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return BloodBankTestDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel BloodBankTestDefinitionFormInternal(BloodBankTestDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("315d5c63-371a-460c-a7df-045c9dab3e16");
            //objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);//Normalde converterdan gelmemesi lazýmýþ ama geliyor. Ahmet abi ile bakýlacak
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.ProcedureTreeDefinitions);
            objectContext.AddToRawObjectList(viewModel.GridProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.GridMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel._BloodBankTestDefinition);
            objectContext.ProcessRawObjects();

            var bloodBankTestDefinition = (BloodBankTestDefinition)objectContext.GetLoadedObject(viewModel._BloodBankTestDefinition.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(bloodBankTestDefinition, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BloodBankTestDefinition, formDefID);

            if (viewModel.GridProceduresGridList != null)
            {
                foreach (var item in viewModel.GridProceduresGridList)
                {
                    var subProceduresImported = (BloodBankGridProcedureDefinition)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)subProceduresImported).IsDeleted)
                        continue;
                    subProceduresImported.BloodBankTestDefinition = bloodBankTestDefinition;
                }
            }

            if (viewModel.GridMaterialsGridList != null)
            {
                foreach (var item in viewModel.GridMaterialsGridList)
                {
                    var materialsImported = (BloodBankGridMaterialDefinition)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)materialsImported).IsDeleted)
                        continue;
                    materialsImported.BloodBankTestDefinition = bloodBankTestDefinition;
                }
            }
            var transDef = bloodBankTestDefinition.TransDef;
            PostScript_BloodBankTestDefinitionForm(viewModel, bloodBankTestDefinition, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(bloodBankTestDefinition);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(bloodBankTestDefinition);
            AfterContextSaveScript_BloodBankTestDefinitionForm(viewModel, bloodBankTestDefinition, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_BloodBankTestDefinitionForm(BloodBankTestDefinitionFormViewModel viewModel, BloodBankTestDefinition bloodBankTestDefinition, TTObjectContext objectContext);
        partial void PostScript_BloodBankTestDefinitionForm(BloodBankTestDefinitionFormViewModel viewModel, BloodBankTestDefinition bloodBankTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_BloodBankTestDefinitionForm(BloodBankTestDefinitionFormViewModel viewModel, BloodBankTestDefinition bloodBankTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(BloodBankTestDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.GridProceduresGridList = viewModel._BloodBankTestDefinition.SubProcedures.OfType<BloodBankGridProcedureDefinition>().ToArray();
            viewModel.GridMaterialsGridList = viewModel._BloodBankTestDefinition.Materials.OfType<BloodBankGridMaterialDefinition>().ToArray();
            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.ProcedureTreeDefinitions = objectContext.LocalQuery<ProcedureTreeDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TreatmentMaterialListDefinition", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureTreeListDefinition", viewModel.ProcedureTreeDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class BloodBankTestDefinitionFormViewModel
    {
        public TTObjectClasses.BloodBankTestDefinition _BloodBankTestDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.BloodBankGridProcedureDefinition[] GridProceduresGridList
        {
            get;
            set;
        }

        public TTObjectClasses.BloodBankGridMaterialDefinition[] GridMaterialsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureTreeDefinition[] ProcedureTreeDefinitions
        {
            get;
            set;
        }
    }
}
