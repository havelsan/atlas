//$4B9FDB33
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
    public partial class SkinPrickTestResultServiceController : Controller
    {
        [HttpGet]
        public SkinPrickTestResultFormViewModel SkinPrickTestResultForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return SkinPrickTestResultFormLoadInternal(input);
        }

        [HttpPost]
        public SkinPrickTestResultFormViewModel SkinPrickTestResultFormLoad(FormLoadInput input)
        {
            return SkinPrickTestResultFormLoadInternal(input);
        }

        [HttpGet]
        public SkinPrickTestResultFormViewModel SkinPrickTestResultFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("12710a44-908e-4eac-9ebe-1ec6062c1c96");
            var objectDefID = Guid.Parse("f4e95e23-873f-485a-a587-e3925fe5fe2c");
            var viewModel = new SkinPrickTestResultFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SkinPrickTestResult = objectContext.GetObject(id.Value, objectDefID) as SkinPrickTestResult;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SkinPrickTestResult, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SkinPrickTestResult, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SkinPrickTestResult);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SkinPrickTestResult);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_SkinPrickTestResultForm(viewModel, viewModel._SkinPrickTestResult, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SkinPrickTestResult = new SkinPrickTestResult(objectContext);
                    viewModel.SkinPrickTestDetailGridList = new TTObjectClasses.SkinPrickTestDetail[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SkinPrickTestResult, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SkinPrickTestResult, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SkinPrickTestResult);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SkinPrickTestResult);
                    PreScript_SkinPrickTestResultForm(viewModel, viewModel._SkinPrickTestResult, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel SkinPrickTestResultForm(SkinPrickTestResultFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return SkinPrickTestResultFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel SkinPrickTestResultFormInternal(SkinPrickTestResultFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("12710a44-908e-4eac-9ebe-1ec6062c1c96");
            objectContext.AddToRawObjectList(viewModel.SkinPrickTestDetailGridList);
            objectContext.AddToRawObjectList(viewModel._SkinPrickTestResult);
            objectContext.ProcessRawObjects();

            var skinPrickTestResult = (SkinPrickTestResult)objectContext.GetLoadedObject(viewModel._SkinPrickTestResult.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(skinPrickTestResult, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SkinPrickTestResult, formDefID);

            if (viewModel.SkinPrickTestDetailGridList != null)
            {
                foreach (var item in viewModel.SkinPrickTestDetailGridList)
                {
                    var skinPrickTestDetailImported = (SkinPrickTestDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)skinPrickTestDetailImported).IsDeleted)
                        continue;
                    skinPrickTestDetailImported.SkinPrickTestResult = skinPrickTestResult;
                }
            }
            var transDef = skinPrickTestResult.TransDef;
            PostScript_SkinPrickTestResultForm(viewModel, skinPrickTestResult, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(skinPrickTestResult);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(skinPrickTestResult);
            AfterContextSaveScript_SkinPrickTestResultForm(viewModel, skinPrickTestResult, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_SkinPrickTestResultForm(SkinPrickTestResultFormViewModel viewModel, SkinPrickTestResult skinPrickTestResult, TTObjectContext objectContext);
        partial void PostScript_SkinPrickTestResultForm(SkinPrickTestResultFormViewModel viewModel, SkinPrickTestResult skinPrickTestResult, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_SkinPrickTestResultForm(SkinPrickTestResultFormViewModel viewModel, SkinPrickTestResult skinPrickTestResult, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(SkinPrickTestResultFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.SkinPrickTestDetailGridList = viewModel._SkinPrickTestResult.SkinPrickTestDetail.OfType<SkinPrickTestDetail>().ToArray();
        }
    }
}


namespace Core.Models
{
    public partial class SkinPrickTestResultFormViewModel
    {
        public TTObjectClasses.SkinPrickTestResult _SkinPrickTestResult
        {
            get;
            set;
        }

        public TTObjectClasses.SkinPrickTestDetail[] SkinPrickTestDetailGridList
        {
            get;
            set;
        }
    }
}
