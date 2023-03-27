//$DD176317
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
    public partial class DispatchToOtherHospitalServiceController : Controller
{
    [HttpGet]
    public DispatchToOtherHospitalFormViewModel DispatchToOtherHospitalForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DispatchToOtherHospitalFormLoadInternal(input);
    }

    [HttpPost]
    public DispatchToOtherHospitalFormViewModel DispatchToOtherHospitalFormLoad(FormLoadInput input)
    {
        return DispatchToOtherHospitalFormLoadInternal(input);
    }

    private DispatchToOtherHospitalFormViewModel DispatchToOtherHospitalFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a00af0a1-7d03-4c83-bd38-c01c42ed266f");
        var objectDefID = Guid.Parse("11e3d6ee-37f5-465d-9df1-db88c4d570b1");
        var viewModel = new DispatchToOtherHospitalFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DispatchToOtherHospital = objectContext.GetObject(id.Value, objectDefID) as DispatchToOtherHospital;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DispatchToOtherHospital, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DispatchToOtherHospital, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DispatchToOtherHospital);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DispatchToOtherHospital);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DispatchToOtherHospitalForm(viewModel, viewModel._DispatchToOtherHospital, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DispatchToOtherHospital = new DispatchToOtherHospital(objectContext);
                var entryStateID = Guid.Parse("856b02a7-399e-4366-bb3f-8cd7c38c4d4e");
                viewModel._DispatchToOtherHospital.CurrentStateDefID = entryStateID;
                viewModel.ttgridSevkEdenDoktorlarGridList = new TTObjectClasses.DoctorGrid[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DispatchToOtherHospital, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DispatchToOtherHospital, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DispatchToOtherHospital);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DispatchToOtherHospital);
                PreScript_DispatchToOtherHospitalForm(viewModel, viewModel._DispatchToOtherHospital, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DispatchToOtherHospitalForm(DispatchToOtherHospitalFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return DispatchToOtherHospitalFormInternal(viewModel, objectContext, true);
        }
    }

    internal BaseViewModel DispatchToOtherHospitalFormInternal(DispatchToOtherHospitalFormViewModel viewModel, TTObjectContext objectContext, bool SaveContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("a00af0a1-7d03-4c83-bd38-c01c42ed266f");
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.SevkTedaviTipis);
        objectContext.AddToRawObjectList(viewModel.SevkVasitasis);
        objectContext.AddToRawObjectList(viewModel.SevkNedenis);
        objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
        objectContext.AddToRawObjectList(viewModel.ExternalHospitalDefinitions);
        objectContext.AddToRawObjectList(viewModel.Citys);
        objectContext.AddToRawObjectList(viewModel.ReferableHospitals);
        objectContext.AddToRawObjectList(viewModel.Sitess);
        objectContext.AddToRawObjectList(viewModel.ReferableResources);
        objectContext.AddToRawObjectList(viewModel.ttgridSevkEdenDoktorlarGridList);
        var entryStateID = Guid.Parse("856b02a7-399e-4366-bb3f-8cd7c38c4d4e");
        objectContext.AddToRawObjectList(viewModel._DispatchToOtherHospital, entryStateID);
        objectContext.ProcessRawObjects(false);
        var dispatchToOtherHospital = (DispatchToOtherHospital)objectContext.GetLoadedObject(viewModel._DispatchToOtherHospital.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(dispatchToOtherHospital, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DispatchToOtherHospital, formDefID);
        if (viewModel.ttgridSevkEdenDoktorlarGridList != null)
        {
            foreach (var item in viewModel.ttgridSevkEdenDoktorlarGridList)
            {
                var doctorsGridImported = (DoctorGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)doctorsGridImported).IsDeleted)
                    continue;
                doctorsGridImported.DispatchToOtherHospital = dispatchToOtherHospital;
            }
        }

        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(dispatchToOtherHospital);
        PostScript_DispatchToOtherHospitalForm(viewModel, dispatchToOtherHospital, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        if (SaveContext)
            objectContext.Save();
        else
            objectContext.Update();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dispatchToOtherHospital);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dispatchToOtherHospital);
        AfterContextSaveScript_DispatchToOtherHospitalForm(viewModel, dispatchToOtherHospital, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_DispatchToOtherHospitalForm(DispatchToOtherHospitalFormViewModel viewModel, DispatchToOtherHospital dispatchToOtherHospital, TTObjectContext objectContext);
    partial void PostScript_DispatchToOtherHospitalForm(DispatchToOtherHospitalFormViewModel viewModel, DispatchToOtherHospital dispatchToOtherHospital, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DispatchToOtherHospitalForm(DispatchToOtherHospitalFormViewModel viewModel, DispatchToOtherHospital dispatchToOtherHospital, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DispatchToOtherHospitalFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ttgridSevkEdenDoktorlarGridList = viewModel._DispatchToOtherHospital.DoctorsGrid.OfType<DoctorGrid>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SevkTedaviTipis = objectContext.LocalQuery<SevkTedaviTipi>().ToArray();
        viewModel.SevkVasitasis = objectContext.LocalQuery<SevkVasitasi>().ToArray();
        viewModel.SevkNedenis = objectContext.LocalQuery<SevkNedeni>().ToArray();
        viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
        viewModel.ExternalHospitalDefinitions = objectContext.LocalQuery<ExternalHospitalDefinition>().ToArray();
        viewModel.Citys = objectContext.LocalQuery<City>().ToArray();
        viewModel.ReferableHospitals = objectContext.LocalQuery<ReferableHospital>().ToArray();
        viewModel.Sitess = objectContext.LocalQuery<Sites>().ToArray();
        viewModel.ReferableResources = objectContext.LocalQuery<ReferableResource>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SevkTedaviTipiListDefinition", viewModel.SevkTedaviTipis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SevkVasitasiListDefinition", viewModel.SevkVasitasis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SevkNedeniListDefinition", viewModel.SevkNedenis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ExternalHospitalListDefinition", viewModel.ExternalHospitalDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSILKodlariList", viewModel.Citys);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ReferableHospitalListDefinition", viewModel.ReferableHospitals);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SiteListDefinition", viewModel.Sitess);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ReferableResourceListDefinition", viewModel.ReferableResources);
    }
}
}


namespace Core.Models
{
    public partial class DispatchToOtherHospitalFormViewModel
    {
        public TTObjectClasses.DispatchToOtherHospital _DispatchToOtherHospital
        {
            get;
            set;
        }

        public TTObjectClasses.DoctorGrid[] ttgridSevkEdenDoktorlarGridList
        {
            get;
            set;
        }


        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.SevkTedaviTipi[] SevkTedaviTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SevkVasitasi[] SevkVasitasis
        {
            get;
            set;
        }

        public TTObjectClasses.SevkNedeni[] SevkNedenis
        {
            get;
            set;
        }

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ExternalHospitalDefinition[] ExternalHospitalDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.City[] Citys
        {
            get;
            set;
        }

        public TTObjectClasses.ReferableHospital[] ReferableHospitals
        {
            get;
            set;
        }

        public TTObjectClasses.Sites[] Sitess
        {
            get;
            set;
        }

        public TTObjectClasses.ReferableResource[] ReferableResources
        {
            get;
            set;
        }

    }
}
