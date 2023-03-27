//$DA572BEB
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
    public partial class MedicalOncologyServiceController : Controller
    {
        [HttpGet]
        public MedicalOncologySpecialityFormViewModel MedicalOncologySpecialityForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return MedicalOncologySpecialityFormInternal(input);
        }

        [HttpPost]
        public MedicalOncologySpecialityFormViewModel MedicalOncologySpecialityFormLoad(FormLoadInput input)
        {
            return MedicalOncologySpecialityFormInternal(input);
        }
        [HttpGet]
        public MedicalOncologySpecialityFormViewModel MedicalOncologySpecialityFormInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("b152a049-624e-46c8-aa52-d92ac5b27ac0");
            var objectDefID = Guid.Parse("8819f383-8798-4c49-8075-e95f68822406");
            var viewModel = new MedicalOncologySpecialityFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MedicalOncology = objectContext.GetObject(id.Value, objectDefID) as MedicalOncology;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalOncology, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalOncology, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MedicalOncology);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MedicalOncology);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_MedicalOncologySpecialityForm(viewModel, viewModel._MedicalOncology, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MedicalOncology = new MedicalOncology(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalOncology, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalOncology, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MedicalOncology);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MedicalOncology);
                    PreScript_MedicalOncologySpecialityForm(viewModel, viewModel._MedicalOncology, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel MedicalOncologySpecialityForm(MedicalOncologySpecialityFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return MedicalOncologySpecialityFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel MedicalOncologySpecialityFormInternal(MedicalOncologySpecialityFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("b152a049-624e-46c8-aa52-d92ac5b27ac0");
            objectContext.AddToRawObjectList(viewModel._MedicalOncology);
            objectContext.ProcessRawObjects();

            var medicalOncology = (MedicalOncology)objectContext.GetLoadedObject(viewModel._MedicalOncology.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(medicalOncology, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalOncology, formDefID);
            var transDef = medicalOncology.TransDef;
            PostScript_MedicalOncologySpecialityForm(viewModel, medicalOncology, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(medicalOncology);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(medicalOncology);
            AfterContextSaveScript_MedicalOncologySpecialityForm(viewModel, medicalOncology, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_MedicalOncologySpecialityForm(MedicalOncologySpecialityFormViewModel viewModel, MedicalOncology medicalOncology, TTObjectContext objectContext);
        partial void PostScript_MedicalOncologySpecialityForm(MedicalOncologySpecialityFormViewModel viewModel, MedicalOncology medicalOncology, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_MedicalOncologySpecialityForm(MedicalOncologySpecialityFormViewModel viewModel, MedicalOncology medicalOncology, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(MedicalOncologySpecialityFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class MedicalOncologySpecialityFormViewModel: BaseViewModel
    {
        public TTObjectClasses.MedicalOncology _MedicalOncology
        {
            get;
            set;
        }
    }
}
