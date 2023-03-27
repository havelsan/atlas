//$C72182A0
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
    public partial class CigaretteExaminationServiceController : Controller
    {
        [HttpGet]
        public CigaretteInspectionFormViewModel CigaretteInspectionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return CigaretteInspectionFormLoadInternal(input);
        }

        [HttpPost]
        public CigaretteInspectionFormViewModel CigaretteInspectionFormLoad(FormLoadInput input)
        {
            return CigaretteInspectionFormLoadInternal(input);
        }
  
        public CigaretteInspectionFormViewModel CigaretteInspectionFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("8133adee-f4d1-441f-9b32-a62ed7acb040");
            var objectDefID = Guid.Parse("88544dd9-413f-4312-94cc-c133f960ab5f");
            var viewModel = new CigaretteInspectionFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._CigaretteExamination = objectContext.GetObject(id.Value, objectDefID) as CigaretteExamination;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CigaretteExamination, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CigaretteExamination, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._CigaretteExamination);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._CigaretteExamination);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_CigaretteInspectionForm(viewModel, viewModel._CigaretteExamination, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._CigaretteExamination = new CigaretteExamination(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CigaretteExamination, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CigaretteExamination, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._CigaretteExamination);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._CigaretteExamination);
                    PreScript_CigaretteInspectionForm(viewModel, viewModel._CigaretteExamination, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel CigaretteInspectionForm(CigaretteInspectionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return CigaretteInspectionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel CigaretteInspectionFormInternal(CigaretteInspectionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("8133adee-f4d1-441f-9b32-a62ed7acb040");
            objectContext.AddToRawObjectList(viewModel._CigaretteExamination);
            objectContext.ProcessRawObjects();

            var cigaretteExamination = (CigaretteExamination)objectContext.GetLoadedObject(viewModel._CigaretteExamination.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(cigaretteExamination, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CigaretteExamination, formDefID);
            var transDef = cigaretteExamination.TransDef;
            PostScript_CigaretteInspectionForm(viewModel, cigaretteExamination, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(cigaretteExamination);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(cigaretteExamination);
            AfterContextSaveScript_CigaretteInspectionForm(viewModel, cigaretteExamination, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_CigaretteInspectionForm(CigaretteInspectionFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTObjectContext objectContext);
        partial void PostScript_CigaretteInspectionForm(CigaretteInspectionFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_CigaretteInspectionForm(CigaretteInspectionFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(CigaretteInspectionFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class CigaretteInspectionFormViewModel
    {
        public TTObjectClasses.CigaretteExamination _CigaretteExamination
        {
            get;
            set;
        }
    }
}
