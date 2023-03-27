//$EFD372D1
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class SurgeryServiceController : Controller
{
    [HttpGet]
    public OldSurgeryFormViewModel OldSurgeryForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldSurgeryFormLoadInternal(input);
    }

    [HttpPost]
    public OldSurgeryFormViewModel OldSurgeryFormLoad(FormLoadInput input)
    {
        return OldSurgeryFormLoadInternal(input);
    }

    private OldSurgeryFormViewModel OldSurgeryFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("583a4df6-a951-4832-848c-c0caf6a9ada0");
        var objectDefID = Guid.Parse("8dc586f0-14a5-42a3-a7c6-51e1be031ee0");
        var viewModel = new OldSurgeryFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Surgery = objectContext.GetObject(id.Value, objectDefID) as Surgery;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Surgery, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Surgery, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Surgery);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Surgery);
                PreScript_OldSurgeryForm(viewModel, viewModel._Surgery, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldSurgeryForm(OldSurgeryFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("583a4df6-a951-4832-848c-c0caf6a9ada0");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._Surgery);
            objectContext.ProcessRawObjects();
            var surgery = (Surgery)objectContext.GetLoadedObject(viewModel._Surgery.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(surgery, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Surgery, formDefID);
            var transDef = surgery.TransDef;
            PostScript_OldSurgeryForm(viewModel, surgery, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldSurgeryForm(viewModel, surgery, transDef, objectContext);
        }
    }

    partial void PreScript_OldSurgeryForm(OldSurgeryFormViewModel viewModel, Surgery surgery, TTObjectContext objectContext);
    partial void PostScript_OldSurgeryForm(OldSurgeryFormViewModel viewModel, Surgery surgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldSurgeryForm(OldSurgeryFormViewModel viewModel, Surgery surgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldSurgeryFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}

namespace Core.Models
{
    public partial class OldSurgeryFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Surgery _Surgery
        {
            get;
            set;
        }
    }
}