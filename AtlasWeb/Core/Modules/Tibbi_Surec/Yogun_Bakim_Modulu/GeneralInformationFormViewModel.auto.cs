//$DF5EAEC7
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
    public partial class GeneralInformationServiceController : Controller
    {
        [HttpGet]
        public GeneralInformationFormViewModel GeneralInformationForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return GeneralInformationFormLoadInternal(input);
        }

        [HttpPost]
        public GeneralInformationFormViewModel GeneralInformationFormLoad(FormLoadInput input)
        {
            return GeneralInformationFormLoadInternal(input);
        }

        private GeneralInformationFormViewModel GeneralInformationFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("3c049ba8-6a1d-4d63-9fa7-2d09c7648421");
            var objectDefID = Guid.Parse("398ac595-ffbb-440f-95f5-ec9ebc88b422");
            var viewModel = new GeneralInformationFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._GeneralInformation = objectContext.GetObject(id.Value, objectDefID) as GeneralInformation;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GeneralInformation, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GeneralInformation, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._GeneralInformation);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._GeneralInformation);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_GeneralInformationForm(viewModel, viewModel._GeneralInformation, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._GeneralInformation = new GeneralInformation(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GeneralInformation, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GeneralInformation, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._GeneralInformation);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._GeneralInformation);
                    PreScript_GeneralInformationForm(viewModel, viewModel._GeneralInformation, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel GeneralInformationForm(GeneralInformationFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return GeneralInformationFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel GeneralInformationFormInternal(GeneralInformationFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("3c049ba8-6a1d-4d63-9fa7-2d09c7648421");
            objectContext.AddToRawObjectList(viewModel._GeneralInformation);
            objectContext.ProcessRawObjects();

            var generalInformation = (GeneralInformation)objectContext.GetLoadedObject(viewModel._GeneralInformation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(generalInformation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GeneralInformation, formDefID);
            var transDef = generalInformation.TransDef;
            PostScript_GeneralInformationForm(viewModel, generalInformation, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(generalInformation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(generalInformation);
            AfterContextSaveScript_GeneralInformationForm(viewModel, generalInformation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_GeneralInformationForm(GeneralInformationFormViewModel viewModel, GeneralInformation generalInformation, TTObjectContext objectContext);
        partial void PostScript_GeneralInformationForm(GeneralInformationFormViewModel viewModel, GeneralInformation generalInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_GeneralInformationForm(GeneralInformationFormViewModel viewModel, GeneralInformation generalInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(GeneralInformationFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class GeneralInformationFormViewModel
    {
        public TTObjectClasses.GeneralInformation _GeneralInformation
        {
            get;
            set;
        }
    }
}
