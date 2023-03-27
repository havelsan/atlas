//$0C0B37A9
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
        public ResUserDefinitionFormViewModel ResUserDefinitionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ResUserDefinitionFormLoadInternal(input);
        }

        [HttpPost]
        public ResUserDefinitionFormViewModel ResUserDefinitionFormLoad(FormLoadInput input)
        {
            return ResUserDefinitionFormLoadInternal(input);
        }

        private ResUserDefinitionFormViewModel ResUserDefinitionFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("c26f36b3-ad20-4787-8176-8fc44ad3f72e");
            var objectDefID = Guid.Parse("299c1e6d-dd23-4c09-8e60-b6c448c9a32e");
            var viewModel = new ResUserDefinitionFormViewModel();
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
                    PreScript_ResUserDefinitionForm(viewModel, viewModel._ResUser, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ResUser = new ResUser(objectContext);
                    viewModel.ResourceSpecialitiesGridList = new TTObjectClasses.ResourceSpecialityGrid[]{};
                    viewModel.UserResourcesGridList = new TTObjectClasses.UserResource[] { };
                    viewModel.ResUserUsableStoresGridList = new TTObjectClasses.ResUserUsableStore[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ResUser, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResUser, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ResUser);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ResUser);
                    PreScript_ResUserDefinitionForm(viewModel, viewModel._ResUser, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ResUserDefinitionForm(ResUserDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ResUserDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ResUserDefinitionFormInternal(ResUserDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("c26f36b3-ad20-4787-8176-8fc44ad3f72e");
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.Persons);
            objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
            objectContext.AddToRawObjectList(viewModel.UserResourcesGridList);
            objectContext.AddToRawObjectList(viewModel.ResUserUsableStoresGridList);
            objectContext.AddToRawObjectList(viewModel.ResourceSpecialitiesGridList);
            objectContext.AddToRawObjectList(viewModel._ResUser);
            objectContext.ProcessRawObjects();
            var resUser = (ResUser)objectContext.GetLoadedObject(viewModel._ResUser.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(resUser, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ResUser, formDefID);

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

            var transDef = resUser.TransDef;
            PostScript_ResUserDefinitionForm(viewModel, resUser, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(resUser);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(resUser);
            AfterContextSaveScript_ResUserDefinitionForm(viewModel, resUser, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

        partial void PreScript_ResUserDefinitionForm(ResUserDefinitionFormViewModel viewModel, ResUser resUser, TTObjectContext objectContext);
        partial void PostScript_ResUserDefinitionForm(ResUserDefinitionFormViewModel viewModel, ResUser resUser, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ResUserDefinitionForm(ResUserDefinitionFormViewModel viewModel, ResUser resUser, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(ResUserDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.UserResourcesGridList = viewModel._ResUser.UserResources.OfType<UserResource>().ToArray();
            viewModel.ResUserUsableStoresGridList = viewModel._ResUser.ResUserUsableStores.OfType<ResUserUsableStore>().ToArray();
            viewModel.ResourceSpecialitiesGridList = viewModel._ResUser.ResourceSpecialities.OfType<ResourceSpecialityGrid>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.Persons = objectContext.LocalQuery<Person>().ToArray();
            viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SubStoreList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class ResUserDefinitionFormViewModel
    {
        public TTObjectClasses.ResUser _ResUser
        {
            get;
            set;
        }

        public TTObjectClasses.UserResource[] UserResourcesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResUserUsableStore[] ResUserUsableStoresGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResourceSpecialityGrid[] ResourceSpecialitiesGridList
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

        public TTObjectClasses.Person[] Persons
        {
            get;
            set;
        }

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }
    }
}
