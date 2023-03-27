//$C22B4271
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
    public MorgueExDischargeFormViewModel MorgueExDischargeForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MorgueExDischargeFormLoadInternal(input);
    }

    [HttpPost]
    public MorgueExDischargeFormViewModel MorgueExDischargeFormLoad(FormLoadInput input)
    {
        return MorgueExDischargeFormLoadInternal(input);
    }

    private MorgueExDischargeFormViewModel MorgueExDischargeFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("6325dfb2-290a-494e-89bd-1d877a1fd3d3");
        var objectDefID = Guid.Parse("adeb7bb4-e9fb-49a1-9506-2731d759c54b");
        var viewModel = new MorgueExDischargeFormViewModel();
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
                PreScript_MorgueExDischargeForm(viewModel, viewModel._Morgue, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Morgue = new Morgue(objectContext);
                var entryStateID = Guid.Parse("9ad0a2cc-4016-43b2-8c8b-69cbe3c949f2");
                viewModel._Morgue.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Morgue, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Morgue, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Morgue);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Morgue);
                PreScript_MorgueExDischargeForm(viewModel, viewModel._Morgue, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MorgueExDischargeForm(MorgueExDischargeFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("6325dfb2-290a-494e-89bd-1d877a1fd3d3");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSOlumSeklis);
            objectContext.AddToRawObjectList(viewModel.SKRSICDs);
            objectContext.AddToRawObjectList(viewModel.SKRSOlumNedeniTurus);
            objectContext.AddToRawObjectList(viewModel.SKRSYaralanmaninYeris);
            objectContext.AddToRawObjectList(viewModel.SKRSOlumYeris);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.MernisDeathReasonDefinitions);
            objectContext.AddToRawObjectList(viewModel.MorgueDeathTypeGridList);
            objectContext.AddToRawObjectList(viewModel.DeathReasonDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel._Morgue);
            objectContext.ProcessRawObjects();
            var morgue = (Morgue)objectContext.GetLoadedObject(viewModel._Morgue.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(morgue, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Morgue, formDefID);
            if (viewModel.MorgueDeathTypeGridList != null)
            {
                foreach (var item in viewModel.MorgueDeathTypeGridList)
                {
                    var morgueDeathTypeImported = (MorgueDeathType)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)morgueDeathTypeImported).IsDeleted)
                        continue;
                    morgueDeathTypeImported.Morgue = morgue;
                }
            }

            if (viewModel.DeathReasonDiagnosisGridList != null)
            {
                foreach (var item in viewModel.DeathReasonDiagnosisGridList)
                {
                    var deathReasonDiagnosisImported = (DeathReasonDiagnosis)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)deathReasonDiagnosisImported).IsDeleted)
                        continue;
                    deathReasonDiagnosisImported.Morgue = morgue;
                }
            }

            var transDef = morgue.TransDef;
            PostScript_MorgueExDischargeForm(viewModel, morgue, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(morgue);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(morgue);
            AfterContextSaveScript_MorgueExDischargeForm(viewModel, morgue, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_MorgueExDischargeForm(MorgueExDischargeFormViewModel viewModel, Morgue morgue, TTObjectContext objectContext);
    partial void PostScript_MorgueExDischargeForm(MorgueExDischargeFormViewModel viewModel, Morgue morgue, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MorgueExDischargeForm(MorgueExDischargeFormViewModel viewModel, Morgue morgue, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MorgueExDischargeFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MorgueDeathTypeGridList = viewModel._Morgue.MorgueDeathType.OfType<MorgueDeathType>().ToArray();
        viewModel.DeathReasonDiagnosisGridList = viewModel._Morgue.DeathReasonDiagnosis.OfType<DeathReasonDiagnosis>().ToArray();
        viewModel.SKRSOlumSeklis = objectContext.LocalQuery<SKRSOlumSekli>().ToArray();
        viewModel.Morgues = objectContext.LocalQuery<Morgue>().ToArray();
        viewModel.SKRSICDs = objectContext.LocalQuery<SKRSICD>().ToArray();
        viewModel.SKRSOlumNedeniTurus = objectContext.LocalQuery<SKRSOlumNedeniTuru>().ToArray();
        viewModel.SKRSYaralanmaninYeris = objectContext.LocalQuery<SKRSYaralanmaninYeri>().ToArray();
        viewModel.SKRSOlumYeris = objectContext.LocalQuery<SKRSOlumYeri>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.MernisDeathReasonDefinitions = objectContext.LocalQuery<MernisDeathReasonDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOlumSekliList", viewModel.SKRSOlumSeklis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSICDList", viewModel.SKRSICDs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOlumNedeniTuruList", viewModel.SKRSOlumNedeniTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSYaralanmaninYeriList", viewModel.SKRSYaralanmaninYeris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOlumYeriList", viewModel.SKRSOlumYeris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicNurseListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MernisDeathReasonDefinitionList", viewModel.MernisDeathReasonDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class MorgueExDischargeFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Morgue _Morgue { get; set; }
        public TTObjectClasses.MorgueDeathType[] MorgueDeathTypeGridList { get; set; }
        public TTObjectClasses.DeathReasonDiagnosis[] DeathReasonDiagnosisGridList { get; set; }
        public TTObjectClasses.SKRSOlumSekli[] SKRSOlumSeklis { get; set; }
        public TTObjectClasses.Morgue[] Morgues { get; set; }
        public TTObjectClasses.SKRSICD[] SKRSICDs { get; set; }
        public TTObjectClasses.SKRSOlumNedeniTuru[] SKRSOlumNedeniTurus { get; set; }
        public TTObjectClasses.SKRSYaralanmaninYeri[] SKRSYaralanmaninYeris { get; set; }
        public TTObjectClasses.SKRSOlumYeri[] SKRSOlumYeris { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.MernisDeathReasonDefinition[] MernisDeathReasonDefinitions { get; set; }
    }
}
