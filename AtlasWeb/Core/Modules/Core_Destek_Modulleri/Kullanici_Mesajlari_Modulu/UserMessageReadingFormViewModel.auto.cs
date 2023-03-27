//$B8B806A5
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
    public partial class UserMessageServiceController : Controller
{
    [HttpGet]
    public UserMessageReadingFormViewModel UserMessageReadingForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return UserMessageReadingFormLoadInternal(input);
    }

    [HttpPost]
    public UserMessageReadingFormViewModel UserMessageReadingFormLoad(FormLoadInput input)
    {
        return UserMessageReadingFormLoadInternal(input);
    }

    private UserMessageReadingFormViewModel UserMessageReadingFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("b40ac20a-68fd-485e-9915-ce7c66d5801a");
        var objectDefID = Guid.Parse("95be9388-ccba-4810-9492-14ed2daddd85");
        var viewModel = new UserMessageReadingFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._UserMessage = objectContext.GetObject(id.Value, objectDefID) as UserMessage;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._UserMessage, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._UserMessage, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._UserMessage);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._UserMessage);
                viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                viewModel.users = ResUser.GetResUser(" AND ISACTIVE = 1").ToArray();
                viewModel.groups = UserMessageGroupDefinition.GetAllMessageGroupDef().ToArray();
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_UserMessageReadingForm(viewModel, viewModel._UserMessage, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._UserMessage = new UserMessage(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._UserMessage, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._UserMessage, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._UserMessage);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._UserMessage);
                viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                viewModel.users = ResUser.GetResUser(" AND ISACTIVE = 1").ToArray();
                viewModel.groups = UserMessageGroupDefinition.GetAllMessageGroupDef().ToArray();
                PreScript_UserMessageReadingForm(viewModel, viewModel._UserMessage, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel UserMessageReadingForm(UserMessageReadingFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("b40ac20a-68fd-485e-9915-ce7c66d5801a");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.UserMessageAttachments);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel._UserMessage);
            objectContext.ProcessRawObjects();
            var userMessage = (UserMessage)objectContext.GetLoadedObject(viewModel._UserMessage.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(userMessage, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._UserMessage, formDefID);
            var transDef = userMessage.TransDef;
            PostScript_UserMessageReadingForm(viewModel, userMessage, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(userMessage);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(userMessage);
            AfterContextSaveScript_UserMessageReadingForm(viewModel, userMessage, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_UserMessageReadingForm(UserMessageReadingFormViewModel viewModel, UserMessage userMessage, TTObjectContext objectContext);
    partial void PostScript_UserMessageReadingForm(UserMessageReadingFormViewModel viewModel, UserMessage userMessage, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_UserMessageReadingForm(UserMessageReadingFormViewModel viewModel, UserMessage userMessage, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(UserMessageReadingFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class UserMessageReadingFormViewModel : BaseViewModel
    {
        public TTObjectClasses.UserMessage _UserMessage { get; set; }
        public TTObjectClasses.UserMessageAttachment[] UserMessageAttachments { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }

        public TTObjectClasses.ResUser.GetResUser_Class[] users
        {
            get;
            set;
        }

        public TTObjectClasses.UserMessageGroupDefinition.GetAllMessageGroupDef_Class[] groups
        {
            get;
            set;
        }
    }
}
