//$0A814A98
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
    public partial class MorgueServiceController : Controller
{
    [HttpGet]
    public OutMorgueRequestFormViewModel OutMorgueRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OutMorgueRequestFormLoadInternal(input);
    }

    [HttpPost]
    public OutMorgueRequestFormViewModel OutMorgueRequestFormLoad(FormLoadInput input)
    {
        return OutMorgueRequestFormLoadInternal(input);
    }

    private OutMorgueRequestFormViewModel OutMorgueRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d510e88f-6bd5-466a-81a0-c2b8667b8bd6");
        var objectDefID = Guid.Parse("adeb7bb4-e9fb-49a1-9506-2731d759c54b");
        var viewModel = new OutMorgueRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Morgue = objectContext.GetObject(id.Value, objectDefID) as Morgue;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Morgue, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Morgue, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Morgue);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Morgue);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_OutMorgueRequestForm(viewModel, viewModel._Morgue, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Morgue = new Morgue(objectContext);
                var entryStateID = Guid.Parse("0322d40c-300d-43e9-94ba-bc3bfbf56e69");
                viewModel._Morgue.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Morgue, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Morgue, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Morgue);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Morgue);
                PreScript_OutMorgueRequestForm(viewModel, viewModel._Morgue, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OutMorgueRequestForm(OutMorgueRequestFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("d510e88f-6bd5-466a-81a0-c2b8667b8bd6");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSOlumYeris);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.MernisDeathReasonDefinitions);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.SKRSCinsiyets);
            objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
            var entryStateID = Guid.Parse("0322d40c-300d-43e9-94ba-bc3bfbf56e69");
            objectContext.AddToRawObjectList(viewModel._Morgue, entryStateID);
            objectContext.ProcessRawObjects(false);
            var morgue = (Morgue)objectContext.GetLoadedObject(viewModel._Morgue.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(morgue, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Morgue, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(morgue);
            PostScript_OutMorgueRequestForm(viewModel, morgue, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(morgue);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(morgue);
            AfterContextSaveScript_OutMorgueRequestForm(viewModel, morgue, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_OutMorgueRequestForm(OutMorgueRequestFormViewModel viewModel, Morgue morgue, TTObjectContext objectContext);
    partial void PostScript_OutMorgueRequestForm(OutMorgueRequestFormViewModel viewModel, Morgue morgue, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OutMorgueRequestForm(OutMorgueRequestFormViewModel viewModel, Morgue morgue, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OutMorgueRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SKRSOlumYeris = objectContext.LocalQuery<SKRSOlumYeri>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.MernisDeathReasonDefinitions = objectContext.LocalQuery<MernisDeathReasonDefinition>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOlumYeriList", viewModel.SKRSOlumYeris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MernisDeathReasonList", viewModel.MernisDeathReasonDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CityListDefinition", viewModel.SKRSILKodlaris);
    }
}
}


namespace Core.Models
{
    public partial class OutMorgueRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Morgue _Morgue { get; set; }
        public TTObjectClasses.SKRSOlumYeri[] SKRSOlumYeris { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.MernisDeathReasonDefinition[] MernisDeathReasonDefinitions { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.SKRSCinsiyet[] SKRSCinsiyets { get; set; }
        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris { get; set; }
    }
}
