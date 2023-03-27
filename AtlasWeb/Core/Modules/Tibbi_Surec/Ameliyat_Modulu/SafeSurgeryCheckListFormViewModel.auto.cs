//$8A974B16
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
    public partial class SafeSurgeryCheckListServiceController : Controller
    {

        [HttpGet]
        public SafeSurgeryCheckListFormViewModel SafeSurgeryCheckListForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return SafeSurgeryCheckListFormLoadInternal(input);
        }

        [HttpPost]
        public SafeSurgeryCheckListFormViewModel SafeSurgeryCheckListFormLoad(FormLoadInput input)
        {
            return SafeSurgeryCheckListFormLoadInternal(input);
        }

        [HttpGet]
        public SafeSurgeryCheckListFormViewModel SafeSurgeryCheckListFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("633786d4-8b36-4c4c-8998-8ce2e04fcd3b");
            var objectDefID = Guid.Parse("86fe974a-c3a5-4347-a71e-0decc3f912c3");
            var viewModel = new SafeSurgeryCheckListFormViewModel();
            viewModel.ActiveIDsModel = input.Model;

            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SafeSurgeryCheckList = objectContext.GetObject(id.Value, objectDefID) as SafeSurgeryCheckList;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SafeSurgeryCheckList, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SafeSurgeryCheckList, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SafeSurgeryCheckList);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SafeSurgeryCheckList);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_SafeSurgeryCheckListForm(viewModel, viewModel._SafeSurgeryCheckList, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel SafeSurgeryCheckListForm(SafeSurgeryCheckListFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return SafeSurgeryCheckListFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel SafeSurgeryCheckListFormInternal(SafeSurgeryCheckListFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("633786d4-8b36-4c4c-8998-8ce2e04fcd3b");
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel._SafeSurgeryCheckList);
            objectContext.ProcessRawObjects();

            var safeSurgeryCheckList = (SafeSurgeryCheckList)objectContext.GetLoadedObject(viewModel._SafeSurgeryCheckList.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(safeSurgeryCheckList, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SafeSurgeryCheckList, formDefID);
            var transDef = safeSurgeryCheckList.TransDef;
            PostScript_SafeSurgeryCheckListForm(viewModel, safeSurgeryCheckList, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(safeSurgeryCheckList);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(safeSurgeryCheckList);
            AfterContextSaveScript_SafeSurgeryCheckListForm(viewModel, safeSurgeryCheckList, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_SafeSurgeryCheckListForm(SafeSurgeryCheckListFormViewModel viewModel, SafeSurgeryCheckList safeSurgeryCheckList, TTObjectContext objectContext);
        partial void PostScript_SafeSurgeryCheckListForm(SafeSurgeryCheckListFormViewModel viewModel, SafeSurgeryCheckList safeSurgeryCheckList, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_SafeSurgeryCheckListForm(SafeSurgeryCheckListFormViewModel viewModel, SafeSurgeryCheckList safeSurgeryCheckList, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(SafeSurgeryCheckListFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicNurseListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicDoctorListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NurseListDefinition", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class SafeSurgeryCheckListFormViewModel
    {
        public TTObjectClasses.SafeSurgeryCheckList _SafeSurgeryCheckList
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {  
            get;
            set;
        }
    }
}
