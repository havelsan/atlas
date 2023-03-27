//$050D4449
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
        public CigaretteExaminationFormViewModel CigaretteExaminationForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return CigaretteExaminationFormLoadInternal(input);
        }

        [HttpPost]
        public CigaretteExaminationFormViewModel CigaretteExaminationFormLoad(FormLoadInput input)
        {
            return CigaretteExaminationFormLoadInternal(input);
        }
       
        public CigaretteExaminationFormViewModel CigaretteExaminationFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("0f8e1099-471f-4c81-b883-579bbb687986");
            var objectDefID = Guid.Parse("88544dd9-413f-4312-94cc-c133f960ab5f");
            var viewModel = new CigaretteExaminationFormViewModel();
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

                    PreScript_CigaretteExaminationForm(viewModel, viewModel._CigaretteExamination, objectContext);
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
                    PreScript_CigaretteExaminationForm(viewModel, viewModel._CigaretteExamination, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel CigaretteExaminationForm(CigaretteExaminationFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return CigaretteExaminationFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel CigaretteExaminationFormInternal(CigaretteExaminationFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("0f8e1099-471f-4c81-b883-579bbb687986");
            objectContext.AddToRawObjectList(viewModel._CigaretteExamination);
            objectContext.ProcessRawObjects();

            var cigaretteExamination = (CigaretteExamination)objectContext.GetLoadedObject(viewModel._CigaretteExamination.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(cigaretteExamination, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CigaretteExamination, formDefID);
            var transDef = cigaretteExamination.TransDef;
            PostScript_CigaretteExaminationForm(viewModel, cigaretteExamination, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(cigaretteExamination);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(cigaretteExamination);
            AfterContextSaveScript_CigaretteExaminationForm(viewModel, cigaretteExamination, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_CigaretteExaminationForm(CigaretteExaminationFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTObjectContext objectContext);
        partial void PostScript_CigaretteExaminationForm(CigaretteExaminationFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_CigaretteExaminationForm(CigaretteExaminationFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(CigaretteExaminationFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class CigaretteExaminationFormViewModel
    {
        public TTObjectClasses.CigaretteExamination _CigaretteExamination
        {
            get;
            set;
        }
    }
}
