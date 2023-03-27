//$7DF23C7B
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
    public partial class ChildGrowthVisitsServiceController : Controller
{
    [HttpGet]
    public OldVisitDetailsFormViewModel OldVisitDetailsForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldVisitDetailsFormLoadInternal(input);
    }

    [HttpPost]
    public OldVisitDetailsFormViewModel OldVisitDetailsFormLoad(FormLoadInput input)
    {
        return OldVisitDetailsFormLoadInternal(input);
    }

    private OldVisitDetailsFormViewModel OldVisitDetailsFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("ffbd3bf7-4d1c-4d5a-b0b2-c7ae9772e79f");
        var objectDefID = Guid.Parse("27cdfb0a-64ca-4466-ad10-86bee55e67d4");
        var viewModel = new OldVisitDetailsFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ChildGrowthVisits = objectContext.GetObject(id.Value, objectDefID) as ChildGrowthVisits;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChildGrowthVisits, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChildGrowthVisits, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ChildGrowthVisits);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ChildGrowthVisits);
                PreScript_OldVisitDetailsForm(viewModel, viewModel._ChildGrowthVisits, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ChildGrowthVisits = new ChildGrowthVisits(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChildGrowthVisits, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChildGrowthVisits, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ChildGrowthVisits);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ChildGrowthVisits);
                PreScript_OldVisitDetailsForm(viewModel, viewModel._ChildGrowthVisits, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldVisitDetailsForm(OldVisitDetailsFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("ffbd3bf7-4d1c-4d5a-b0b2-c7ae9772e79f");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._ChildGrowthVisits);
            objectContext.ProcessRawObjects();
            var childGrowthVisits = (ChildGrowthVisits)objectContext.GetLoadedObject(viewModel._ChildGrowthVisits.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(childGrowthVisits, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChildGrowthVisits, formDefID);
            var transDef = childGrowthVisits.TransDef;
            PostScript_OldVisitDetailsForm(viewModel, childGrowthVisits, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldVisitDetailsForm(viewModel, childGrowthVisits, transDef, objectContext);
        }
    }

    partial void PreScript_OldVisitDetailsForm(OldVisitDetailsFormViewModel viewModel, ChildGrowthVisits childGrowthVisits, TTObjectContext objectContext);
    partial void PostScript_OldVisitDetailsForm(OldVisitDetailsFormViewModel viewModel, ChildGrowthVisits childGrowthVisits, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldVisitDetailsForm(OldVisitDetailsFormViewModel viewModel, ChildGrowthVisits childGrowthVisits, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldVisitDetailsFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}

namespace Core.Models
{
    public partial class OldVisitDetailsFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ChildGrowthVisits _ChildGrowthVisits
        {
            get;
            set;
        }
    }
}