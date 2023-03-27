//$346F42B3
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
    public partial class NewBornIntensiveCareServiceController : Controller
    {
        [HttpGet]
        public NewBornIntensiveCareFormViewModel NewBornIntensiveCareForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return NewBornIntensiveCareFormLoadInternal(input);
        }

        [HttpPost]
        public NewBornIntensiveCareFormViewModel NewBornIntensiveCareFormLoad(FormLoadInput input)
        {
            return NewBornIntensiveCareFormLoadInternal(input);
        }

        private NewBornIntensiveCareFormViewModel NewBornIntensiveCareFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("a1c90338-f14d-4bf6-b191-c9b63eef5898");
            var objectDefID = Guid.Parse("d7eb5879-8ccd-4576-b46b-1b2cea89f549");
            var viewModel = new NewBornIntensiveCareFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._NewBornIntensiveCare = objectContext.GetObject(id.Value, objectDefID) as NewBornIntensiveCare;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NewBornIntensiveCare, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NewBornIntensiveCare, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NewBornIntensiveCare);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NewBornIntensiveCare);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_NewBornIntensiveCareForm(viewModel, viewModel._NewBornIntensiveCare, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._NewBornIntensiveCare = new NewBornIntensiveCare(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NewBornIntensiveCare, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NewBornIntensiveCare, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NewBornIntensiveCare);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NewBornIntensiveCare);
                    PreScript_NewBornIntensiveCareForm(viewModel, viewModel._NewBornIntensiveCare, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel NewBornIntensiveCareForm(NewBornIntensiveCareFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return NewBornIntensiveCareFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel NewBornIntensiveCareFormInternal(NewBornIntensiveCareFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("a1c90338-f14d-4bf6-b191-c9b63eef5898");
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel._NewBornIntensiveCare);
            objectContext.ProcessRawObjects();

            var newBornIntensiveCare = (NewBornIntensiveCare)objectContext.GetLoadedObject(viewModel._NewBornIntensiveCare.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(newBornIntensiveCare, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NewBornIntensiveCare, formDefID);
            var transDef = newBornIntensiveCare.TransDef;
            PostScript_NewBornIntensiveCareForm(viewModel, newBornIntensiveCare, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(newBornIntensiveCare);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(newBornIntensiveCare);
            AfterContextSaveScript_NewBornIntensiveCareForm(viewModel, newBornIntensiveCare, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_NewBornIntensiveCareForm(NewBornIntensiveCareFormViewModel viewModel, NewBornIntensiveCare newBornIntensiveCare, TTObjectContext objectContext);
        partial void PostScript_NewBornIntensiveCareForm(NewBornIntensiveCareFormViewModel viewModel, NewBornIntensiveCare newBornIntensiveCare, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_NewBornIntensiveCareForm(NewBornIntensiveCareFormViewModel viewModel, NewBornIntensiveCare newBornIntensiveCare, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(NewBornIntensiveCareFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        }
    }
}


namespace Core.Models
{
    public partial class NewBornIntensiveCareFormViewModel
    {
        public TTObjectClasses.NewBornIntensiveCare _NewBornIntensiveCare
        {
            get;
            set;
        }

        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }
    }
}
