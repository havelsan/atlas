//$261AF458
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
    public partial class VaccineFollowUpServiceController : Controller
{
    [HttpGet]
    public VaccineFollowUpFormViewModel VaccineFollowUpForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return VaccineFollowUpFormLoadInternal(input);
    }

    [HttpPost]
    public VaccineFollowUpFormViewModel VaccineFollowUpFormLoad(FormLoadInput input)
    {
        return VaccineFollowUpFormLoadInternal(input);
    }

    private VaccineFollowUpFormViewModel VaccineFollowUpFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1f9761b5-df2d-4045-8daa-b547ff5c2e9b");
        var objectDefID = Guid.Parse("d36320bd-8295-482b-8cbc-7bfadb52d524");
        var viewModel = new VaccineFollowUpFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._VaccineFollowUp = objectContext.GetObject(id.Value, objectDefID) as VaccineFollowUp;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._VaccineFollowUp, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VaccineFollowUp, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._VaccineFollowUp);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._VaccineFollowUp);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_VaccineFollowUpForm(viewModel, viewModel._VaccineFollowUp, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._VaccineFollowUp = new VaccineFollowUp(objectContext);
                var entryStateID = Guid.Parse("ad3d097b-88ee-43cc-83a1-05146a4e7445");
                viewModel._VaccineFollowUp.CurrentStateDefID = entryStateID;
                viewModel.VaccineDetailsGridList = new TTObjectClasses.VaccineDetails[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._VaccineFollowUp, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VaccineFollowUp, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._VaccineFollowUp);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._VaccineFollowUp);
                PreScript_VaccineFollowUpForm(viewModel, viewModel._VaccineFollowUp, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel VaccineFollowUpForm(VaccineFollowUpFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1f9761b5-df2d-4045-8daa-b547ff5c2e9b");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.VaccineDetailsGridList);
            var entryStateID = Guid.Parse("ad3d097b-88ee-43cc-83a1-05146a4e7445");
            objectContext.AddToRawObjectList(viewModel._VaccineFollowUp, entryStateID);
            objectContext.ProcessRawObjects(false);
            var vaccineFollowUp = (VaccineFollowUp)objectContext.GetLoadedObject(viewModel._VaccineFollowUp.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(vaccineFollowUp, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VaccineFollowUp, formDefID);
            if (viewModel.VaccineDetailsGridList != null)
            {
                foreach (var item in viewModel.VaccineDetailsGridList)
                {
                    var vaccineDetailsImported = (VaccineDetails)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)vaccineDetailsImported).IsDeleted)
                        continue;
                    vaccineDetailsImported.VaccineFollowUp = vaccineFollowUp;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(vaccineFollowUp);
            PostScript_VaccineFollowUpForm(viewModel, vaccineFollowUp, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(vaccineFollowUp);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(vaccineFollowUp);
            AfterContextSaveScript_VaccineFollowUpForm(viewModel, vaccineFollowUp, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_VaccineFollowUpForm(VaccineFollowUpFormViewModel viewModel, VaccineFollowUp vaccineFollowUp, TTObjectContext objectContext);
    partial void PostScript_VaccineFollowUpForm(VaccineFollowUpFormViewModel viewModel, VaccineFollowUp vaccineFollowUp, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_VaccineFollowUpForm(VaccineFollowUpFormViewModel viewModel, VaccineFollowUp vaccineFollowUp, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(VaccineFollowUpFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.VaccineDetailsGridList = viewModel._VaccineFollowUp.VaccineDetails.OfType<VaccineDetails>().ToArray();
    }
}
}


namespace Core.Models
{
    public partial class VaccineFollowUpFormViewModel : BaseViewModel
    {
        public TTObjectClasses.VaccineFollowUp _VaccineFollowUp { get; set; }
        public TTObjectClasses.VaccineDetails[] VaccineDetailsGridList { get; set; }
    }
}
