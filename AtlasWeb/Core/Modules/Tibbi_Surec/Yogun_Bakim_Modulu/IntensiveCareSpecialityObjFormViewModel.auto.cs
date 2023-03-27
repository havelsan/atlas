//$8E044BB5
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
    public partial class IntensiveCareSpecialityObjServiceController : Controller
    {
        [HttpGet]
        public IntensiveCareSpecialityObjFormViewModel IntensiveCareSpecialityObjForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return IntensiveCareSpecialityObjFormLoadInternal(input);
        }

        [HttpPost]
        public IntensiveCareSpecialityObjFormViewModel IntensiveCareSpecialityObjFormLoad(FormLoadInput input)
        {
            return IntensiveCareSpecialityObjFormLoadInternal(input);
        }

        private IntensiveCareSpecialityObjFormViewModel IntensiveCareSpecialityObjFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("bf7f9f34-f251-4f32-ba2a-26795eb138d5");
            var objectDefID = Guid.Parse("a6e9c802-f6b6-4137-a5ce-f139b89c185f");
            var viewModel = new IntensiveCareSpecialityObjFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._IntensiveCareSpecialityObj = objectContext.GetObject(id.Value, objectDefID) as IntensiveCareSpecialityObj;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._IntensiveCareSpecialityObj, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IntensiveCareSpecialityObj, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._IntensiveCareSpecialityObj);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._IntensiveCareSpecialityObj);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_IntensiveCareSpecialityObjForm(viewModel, viewModel._IntensiveCareSpecialityObj, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._IntensiveCareSpecialityObj = new IntensiveCareSpecialityObj(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._IntensiveCareSpecialityObj, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IntensiveCareSpecialityObj, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._IntensiveCareSpecialityObj);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._IntensiveCareSpecialityObj);
                    PreScript_IntensiveCareSpecialityObjForm(viewModel, viewModel._IntensiveCareSpecialityObj, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel IntensiveCareSpecialityObjForm(IntensiveCareSpecialityObjFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return IntensiveCareSpecialityObjFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel IntensiveCareSpecialityObjFormInternal(IntensiveCareSpecialityObjFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("bf7f9f34-f251-4f32-ba2a-26795eb138d5");
            objectContext.AddToRawObjectList(viewModel.SKRSDurums);
            objectContext.AddToRawObjectList(viewModel._IntensiveCareSpecialityObj);
            objectContext.ProcessRawObjects();
            var intensiveCareSpecialityObj = (IntensiveCareSpecialityObj)objectContext.GetLoadedObject(viewModel._IntensiveCareSpecialityObj.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(intensiveCareSpecialityObj, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IntensiveCareSpecialityObj, formDefID);
            var transDef = intensiveCareSpecialityObj.TransDef;
            PostScript_IntensiveCareSpecialityObjForm(viewModel, intensiveCareSpecialityObj, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(intensiveCareSpecialityObj);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(intensiveCareSpecialityObj);
            AfterContextSaveScript_IntensiveCareSpecialityObjForm(viewModel, intensiveCareSpecialityObj, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

        partial void PreScript_IntensiveCareSpecialityObjForm(IntensiveCareSpecialityObjFormViewModel viewModel, IntensiveCareSpecialityObj intensiveCareSpecialityObj, TTObjectContext objectContext);
        partial void PostScript_IntensiveCareSpecialityObjForm(IntensiveCareSpecialityObjFormViewModel viewModel, IntensiveCareSpecialityObj intensiveCareSpecialityObj, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_IntensiveCareSpecialityObjForm(IntensiveCareSpecialityObjFormViewModel viewModel, IntensiveCareSpecialityObj intensiveCareSpecialityObj, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(IntensiveCareSpecialityObjFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.SKRSDurums = objectContext.LocalQuery<SKRSDurum>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDurumList", viewModel.SKRSDurums);
        }
    }
}


namespace Core.Models
{
    public partial class IntensiveCareSpecialityObjFormViewModel : BaseViewModel
    {
        public TTObjectClasses.IntensiveCareSpecialityObj _IntensiveCareSpecialityObj { get; set; }

        public TTObjectClasses.SKRSDurum[] SKRSDurums { get; set; }
    }
}
