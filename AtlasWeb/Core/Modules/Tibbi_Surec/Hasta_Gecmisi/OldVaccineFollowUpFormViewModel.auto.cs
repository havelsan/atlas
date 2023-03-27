//$9663FF60
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
    public partial class VaccineFollowUpServiceController : Controller
{
    [HttpGet]
    public OldVaccineFollowUpFormViewModel OldVaccineFollowUpForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldVaccineFollowUpFormLoadInternal(input);
    }

    [HttpPost]
    public OldVaccineFollowUpFormViewModel OldVaccineFollowUpFormLoad(FormLoadInput input)
    {
        return OldVaccineFollowUpFormLoadInternal(input);
    }

    private OldVaccineFollowUpFormViewModel OldVaccineFollowUpFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a48da320-ae18-4a0c-abe9-b5d68a77b8ed");
        var objectDefID = Guid.Parse("d36320bd-8295-482b-8cbc-7bfadb52d524");
        var viewModel = new OldVaccineFollowUpFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._VaccineFollowUp = objectContext.GetObject(id.Value, objectDefID) as VaccineFollowUp;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._VaccineFollowUp, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VaccineFollowUp, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._VaccineFollowUp);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._VaccineFollowUp);
                PreScript_OldVaccineFollowUpForm(viewModel, viewModel._VaccineFollowUp, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldVaccineFollowUpForm(OldVaccineFollowUpFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("a48da320-ae18-4a0c-abe9-b5d68a77b8ed");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.VaccineDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._VaccineFollowUp);
            objectContext.ProcessRawObjects();
            var vaccineFollowUp = (VaccineFollowUp)objectContext.GetLoadedObject(viewModel._VaccineFollowUp.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(vaccineFollowUp, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VaccineFollowUp, formDefID);
            if (viewModel.VaccineDetailsGridList != null)
            {
                foreach (var item in viewModel.VaccineDetailsGridList)
                {
                    var vaccineDetailsImported = (VaccineDetails)objectContext.GetLoadedObject(item.ObjectID);
                    vaccineDetailsImported.VaccineFollowUp = vaccineFollowUp;
                }
            }

            var transDef = vaccineFollowUp.TransDef;
            PostScript_OldVaccineFollowUpForm(viewModel, vaccineFollowUp, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldVaccineFollowUpForm(viewModel, vaccineFollowUp, transDef, objectContext);
        }
    }

    partial void PreScript_OldVaccineFollowUpForm(OldVaccineFollowUpFormViewModel viewModel, VaccineFollowUp vaccineFollowUp, TTObjectContext objectContext);
    partial void PostScript_OldVaccineFollowUpForm(OldVaccineFollowUpFormViewModel viewModel, VaccineFollowUp vaccineFollowUp, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldVaccineFollowUpForm(OldVaccineFollowUpFormViewModel viewModel, VaccineFollowUp vaccineFollowUp, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldVaccineFollowUpFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.VaccineDetailsGridList = viewModel._VaccineFollowUp.VaccineDetails.OfType<VaccineDetails>().ToArray();
    }
}
}

namespace Core.Models
{
    public partial class OldVaccineFollowUpFormViewModel : BaseViewModel
    {
        public TTObjectClasses.VaccineFollowUp _VaccineFollowUp
        {
            get;
            set;
        }

        public TTObjectClasses.VaccineDetails[] VaccineDetailsGridList
        {
            get;
            set;
        }
    }
}