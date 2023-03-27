//$D07E0DA5
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
    public partial class ResUserServiceController : Controller
{
    [HttpGet]
    public ResUserFormViewModel ResUserForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ResUserFormLoadInternal(input);
    }

    [HttpPost]
    public ResUserFormViewModel ResUserFormLoad(FormLoadInput input)
    {
        return ResUserFormLoadInternal(input);
    }

    private ResUserFormViewModel ResUserFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e7e68594-6213-4e77-a5ea-39918b00d92e");
        var objectDefID = Guid.Parse("299c1e6d-dd23-4c09-8e60-b6c448c9a32e");
        var viewModel = new ResUserFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ResUser = objectContext.GetObject(id.Value, objectDefID) as ResUser;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ResUser, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResUser, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ResUser);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ResUser);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ResUserForm(viewModel, viewModel._ResUser, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ResUser = new ResUser(objectContext);
                viewModel.ResourceSpecialitiesGridList = new TTObjectClasses.ResourceSpecialityGrid[]{};
                viewModel.ResUserUsableStoresGridList = new TTObjectClasses.ResUserUsableStore[]{};
                viewModel.UserResourcesGridList = new TTObjectClasses.UserResource[]{};
                viewModel.ResUserPatientGroupMatchesGridList = new TTObjectClasses.ResUserPatientGroupMatch[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ResUser, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResUser, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ResUser);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ResUser);
                PreScript_ResUserForm(viewModel, viewModel._ResUser, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ResUserForm(ResUserFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ResUserFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ResUserFormInternal(ResUserFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e7e68594-6213-4e77-a5ea-39918b00d92e");
        objectContext.AddToRawObjectList(viewModel.Persons);
        objectContext.AddToRawObjectList(viewModel.TownDefinitionss);
        objectContext.AddToRawObjectList(viewModel.SKRSCinsiyets);
        objectContext.AddToRawObjectList(viewModel.SKRSUlkeKodlaris);
        objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
        objectContext.AddToRawObjectList(viewModel.ForcesCommands);
        objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
        objectContext.AddToRawObjectList(viewModel.RankDefinitionss);
        objectContext.AddToRawObjectList(viewModel.MilitaryClassDefinitionss);
        objectContext.AddToRawObjectList(viewModel.Stores);
        objectContext.AddToRawObjectList(viewModel.ResSections);
        objectContext.AddToRawObjectList(viewModel.PatientGroupDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResourceSpecialitiesGridList);
        objectContext.AddToRawObjectList(viewModel.ResUserUsableStoresGridList);
        objectContext.AddToRawObjectList(viewModel.UserResourcesGridList);
        objectContext.AddToRawObjectList(viewModel.ResUserPatientGroupMatchesGridList);
        objectContext.AddToRawObjectList(viewModel._ResUser);
        objectContext.ProcessRawObjects();
        var resUser = (ResUser)objectContext.GetLoadedObject(viewModel._ResUser.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(resUser, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResUser, formDefID);
        if (viewModel.ResourceSpecialitiesGridList != null)
        {
            foreach (var item in viewModel.ResourceSpecialitiesGridList)
            {
                var resourceSpecialitiesImported = (ResourceSpecialityGrid)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)resourceSpecialitiesImported).IsDeleted)
                    continue;
                resourceSpecialitiesImported.Resource = resUser;
            }
        }

        if (viewModel.ResUserUsableStoresGridList != null)
        {
            foreach (var item in viewModel.ResUserUsableStoresGridList)
            {
                var resUserUsableStoresImported = (ResUserUsableStore)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)resUserUsableStoresImported).IsDeleted)
                    continue;
                resUserUsableStoresImported.ResUser = resUser;
            }
        }

        if (viewModel.UserResourcesGridList != null)
        {
            foreach (var item in viewModel.UserResourcesGridList)
            {
                var userResourcesImported = (UserResource)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)userResourcesImported).IsDeleted)
                    continue;
                userResourcesImported.User = resUser;
            }
        }

        if (viewModel.ResUserPatientGroupMatchesGridList != null)
        {
            foreach (var item in viewModel.ResUserPatientGroupMatchesGridList)
            {
                var resUserPatientGroupMatchesImported = (ResUserPatientGroupMatch)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)resUserPatientGroupMatchesImported).IsDeleted)
                    continue;
                resUserPatientGroupMatchesImported.ResUser = resUser;
            }
        }

        var transDef = resUser.TransDef;
        PostScript_ResUserForm(viewModel, resUser, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(resUser);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(resUser);
        AfterContextSaveScript_ResUserForm(viewModel, resUser, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ResUserForm(ResUserFormViewModel viewModel, ResUser resUser, TTObjectContext objectContext);
    partial void PostScript_ResUserForm(ResUserFormViewModel viewModel, ResUser resUser, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ResUserForm(ResUserFormViewModel viewModel, ResUser resUser, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ResUserFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResourceSpecialitiesGridList = viewModel._ResUser.ResourceSpecialities.OfType<ResourceSpecialityGrid>().ToArray();
        viewModel.ResUserUsableStoresGridList = viewModel._ResUser.ResUserUsableStores.OfType<ResUserUsableStore>().ToArray();
        viewModel.UserResourcesGridList = viewModel._ResUser.UserResources.OfType<UserResource>().ToArray();
        viewModel.ResUserPatientGroupMatchesGridList = viewModel._ResUser.ResUserPatientGroupMatches.OfType<ResUserPatientGroupMatch>().ToArray();
        viewModel.Persons = objectContext.LocalQuery<Person>().ToArray();
        viewModel.TownDefinitionss = objectContext.LocalQuery<TownDefinitions>().ToArray();
        viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
        viewModel.SKRSUlkeKodlaris = objectContext.LocalQuery<SKRSUlkeKodlari>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        viewModel.ForcesCommands = objectContext.LocalQuery<ForcesCommand>().ToArray();
        viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
        viewModel.RankDefinitionss = objectContext.LocalQuery<RankDefinitions>().ToArray();
        viewModel.MilitaryClassDefinitionss = objectContext.LocalQuery<MilitaryClassDefinitions>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.PatientGroupDefinitions = objectContext.LocalQuery<PatientGroupDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TownListDefinition", viewModel.TownDefinitionss);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCinsiyetList", viewModel.SKRSCinsiyets);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CountryListDefinition", viewModel.SKRSUlkeKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSILKodlariList", viewModel.SKRSILKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ForcesCommandListDefinition", viewModel.ForcesCommands);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RankListDefinition", viewModel.RankDefinitionss);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MilitaryClassListDefinition", viewModel.MilitaryClassDefinitionss);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SubStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PatientGroupList", viewModel.PatientGroupDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class ResUserFormViewModel
    {
        public TTObjectClasses.ResUser _ResUser
        {
            get;
            set;
        }

        public TTObjectClasses.ResourceSpecialityGrid[] ResourceSpecialitiesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResUserUsableStore[] ResUserUsableStoresGridList
        {
            get;
            set;
        }

        public TTObjectClasses.UserResource[] UserResourcesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResUserPatientGroupMatch[] ResUserPatientGroupMatchesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Person[] Persons
        {
            get;
            set;
        }

        public TTObjectClasses.TownDefinitions[] TownDefinitionss
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSCinsiyet[] SKRSCinsiyets
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSUlkeKodlari[] SKRSUlkeKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.ForcesCommand[] ForcesCommands
        {
            get;
            set;
        }

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.RankDefinitions[] RankDefinitionss
        {
            get;
            set;
        }

        public TTObjectClasses.MilitaryClassDefinitions[] MilitaryClassDefinitionss
        {
            get;
            set;
        }

        public TTObjectClasses.Store[] Stores
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.PatientGroupDefinition[] PatientGroupDefinitions
        {
            get;
            set;
        }
    }
}
