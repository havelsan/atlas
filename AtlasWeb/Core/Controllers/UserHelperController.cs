using Infrastructure.Filters;
using System;
using System.Collections.Generic;

using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class UserHelperController : Controller
    {
        [HttpGet]
        public ResUser CurrentResource()
        {
            ResUser resUser = Common.CurrentResource;
            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return resUser;
        }

        [HttpGet]
        public ResSection SelectedInPatientResource()
        {
            ResSection resSection = Common.CurrentResource.SelectedInPatientResource;
            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return resSection;
        }

        [HttpGet]
        public ResSection SelectedOutPatientResource()
        {
            ResSection resSection = Common.CurrentResource.SelectedOutPatientResource;
            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return resSection;
        }

        [HttpGet]
        public ResSection SelectedSecMasterResource()
        {
            ResSection resSection = Common.CurrentResource.SelectedSecMasterResource;
            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return resSection;
        }

        [HttpGet]
        public List<UserResource> UserResources()
        {
            List<UserResource> userResources = Common.CurrentResource.UserResources.ToList();
            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return userResources;
        }

        [HttpGet]
        public Store Store()
        {
            Store store = Common.CurrentResource.Store;
            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return store;
        }

        [HttpGet]
        public List<TentativeStoreDefinition> UseTentativeStoreResources()
        {
            List<TentativeStoreDefinition> selectableTentativeStores = new List<TentativeStoreDefinition>();
            foreach (UserResource resource in Common.CurrentResource.UserResources)
            {
                if (resource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || resource.Resource.EnabledType == ResourceEnableType.InPatient || resource.Resource.EnabledType == ResourceEnableType.OutPatient || resource.Resource.EnabledType == ResourceEnableType.Secmaster)
                    if (resource.Resource.Store != null && resource.Resource.Store is TentativeStoreDefinition)
                        if (selectableTentativeStores.Contains((TentativeStoreDefinition)resource.Resource.Store) == false)
                            selectableTentativeStores.Add((TentativeStoreDefinition)resource.Resource.Store);
            }

            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return selectableTentativeStores;
        }

        [HttpGet]
        public List<MainStoreDefinition> UseMainStoreResources()
        {
            List<MainStoreDefinition> selectableMainStores = new List<MainStoreDefinition>();
            foreach (UserResource resource in Common.CurrentResource.UserResources)
            {
                if (resource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || resource.Resource.EnabledType == ResourceEnableType.InPatient || resource.Resource.EnabledType == ResourceEnableType.OutPatient || resource.Resource.EnabledType == ResourceEnableType.Secmaster)
                    if (resource.Resource.Store != null && resource.Resource.Store is MainStoreDefinition)
                        if (selectableMainStores.Contains((MainStoreDefinition)resource.Resource.Store) == false)
                            selectableMainStores.Add((MainStoreDefinition)resource.Resource.Store);
            }

            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();

            List<MainStoreDefinition> SortedList = selectableMainStores.OrderBy(o => o.Name).ToList();

            return SortedList;
        }

        [HttpGet]
        public List<Store> UseUserResourcesStores()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                List<Store> selectableStores = new List<Store>();
                foreach (UserResource resource in Common.CurrentResource.UserResources)
                {
                    if (resource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || resource.Resource.EnabledType == ResourceEnableType.InPatient || resource.Resource.EnabledType == ResourceEnableType.OutPatient || resource.Resource.EnabledType == ResourceEnableType.Secmaster)
                        if (resource.Resource.Store != null)
                        {
                            if (resource.Resource.Store.IsActive == true)
                            {
                                var store = objectContext.GetObject<Store>(resource.Resource.Store.ObjectID);
                                if (selectableStores.Contains(store) == false)
                                    selectableStores.Add(store);
                            }
                        }
                }

                objectContext.FullPartialllyLoadedObjects();
                List<Store> SortedList = selectableStores.OrderBy(o => o.Name).ToList();

                return SortedList;
            }
        }

        [HttpGet]
        public List<Store> UseInPatientUserResourceStores()
        {
            List<Store> selectableStores = new List<Store>();
            foreach (UserResource resource in Common.CurrentResource.UserResources)
            {
                if (resource.Resource.EnabledType == ResourceEnableType.InPatient)
                    if (resource.Resource.Store != null)
                        selectableStores.Add(resource.Resource.Store);
            }

            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return selectableStores;
        }

        [HttpGet]
        public List<Store> UseOutPatientUserResourceStores()
        {
            List<Store> selectableStores = new List<Store>();
            foreach (UserResource resource in Common.CurrentResource.UserResources)
            {
                if (resource.Resource.EnabledType == ResourceEnableType.OutPatient)
                    if (resource.Resource.Store != null)
                        selectableStores.Add(resource.Resource.Store);
            }

            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return selectableStores;
        }

        [HttpGet]
        public List<Store> UseSecMasterUserResourceStores()
        {
            List<Store> selectableStores = new List<Store>();
            foreach (UserResource resource in Common.CurrentResource.UserResources)
            {
                if (resource.Resource.EnabledType == ResourceEnableType.Secmaster)
                    if (resource.Resource.Store != null)
                        selectableStores.Add(resource.Resource.Store);
            }

            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return selectableStores;
        }

        [HttpGet]
        public Store SelectedInPatientResourceStore()
        {
            Store selectableStore = Common.CurrentResource.SelectedInPatientResource.Store;
            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return selectableStore;
        }

        [HttpGet]
        public Store SelectedOutPatientResourceStore()
        {
            Store selectableStore = Common.CurrentResource.SelectedOutPatientResource.Store;
            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return selectableStore;
        }

        [HttpGet]
        public Store SelectedSecMasterResourceStore()
        {
            Store selectableStore = Common.CurrentResource.SelectedSecMasterResource.Store;
            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return selectableStore;
        }

        [HttpGet]
        public List<Store> UseRoomStores()
        {
            List<Store> selectableRoomStores = new List<Store>();
            foreach (UserResource userResource in Common.CurrentResource.UserResources)
            {
                if (userResource.Resource.Store is RoomStoreDefinition)
                {
                    if (selectableRoomStores.Contains((Store)userResource.Resource.Store) == false)
                    {
                        selectableRoomStores.Add((Store)userResource.Resource.Store);
                    }
                }

                if (userResource.Resource.Store is PharmacyStoreDefinition)
                {
                    if (((PharmacyStoreDefinition)userResource.Resource.Store).UnitStoreDefinition != null)
                    {
                        if (selectableRoomStores.Contains((Store)userResource.Resource.Store) == false)
                        {
                            selectableRoomStores.Add((Store)userResource.Resource.Store);
                        }
                    }
                }
            }

            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return selectableRoomStores;
        }

        [HttpGet]
        public List<Store> UseRoomStoreParentSubStore()
        {
            List<Store> selectableParentStore = new List<Store>();
            foreach (UserResource userResource in Common.CurrentResource.UserResources)
            {
                if (userResource.Resource.Store is RoomStoreDefinition)
                {
                    Store sStore = ((Store)((RoomStoreDefinition)userResource.Resource.Store).ParentStore);
                    if (sStore != null)
                    {
                        if (selectableParentStore.Contains(sStore) == false)
                            selectableParentStore.Add(sStore);
                    }
                }

                if (userResource.Resource.Store is PharmacyStoreDefinition)
                {
                    if (((PharmacyStoreDefinition)userResource.Resource.Store).UnitStoreDefinition != null)
                    {
                        Store sStore = ((Store)((PharmacyStoreDefinition)userResource.Resource.Store).UnitStoreDefinition);
                        if (sStore != null)
                        {
                            if (selectableParentStore.Contains(sStore) == false)
                                selectableParentStore.Add(sStore);
                        }
                    }
                }
            }

            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return selectableParentStore;
        }

        [HttpGet]
        public List<UnitStoreDefinition> UseUnitStoreResources()
        {
            List<UnitStoreDefinition> selectableUnitStores = new List<UnitStoreDefinition>();
            foreach (UserResource userResource in Common.CurrentResource.UserResources)
            {
                if (userResource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || userResource.Resource.EnabledType == ResourceEnableType.InPatient || userResource.Resource.EnabledType == ResourceEnableType.OutPatient || userResource.Resource.EnabledType == ResourceEnableType.Secmaster)
                    if (userResource.Resource.Store != null && userResource.Resource.Store is UnitStoreDefinition)
                        if (selectableUnitStores.Contains((UnitStoreDefinition)userResource.Resource.Store) == false)
                            selectableUnitStores.Add((UnitStoreDefinition)userResource.Resource.Store);
            }

            Common.CurrentResource.ObjectContext.FullPartialllyLoadedObjects();
            return selectableUnitStores;
        }

        public List<Store> UserUsableStores()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                List<Store> selectableStores = new List<Store>();
                foreach (ResUserUsableStore usableStore in Common.CurrentResource.ResUserUsableStores)
                {
                    if (selectableStores.Contains(usableStore.Store) == false)
                        selectableStores.Add(usableStore.Store);
                }
                objectContext.FullPartialllyLoadedObjects();
                List<Store> SortedList = selectableStores.OrderBy(o => o.Name).ToList();
                return SortedList;
            }
        }

        public List<Store> UserUsableSubStores()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                List<Store> selectableStores = new List<Store>();
                foreach (UserResource userResource in Common.CurrentResource.UserResources)
                {
                    if(userResource.Resource.Store != null && userResource.Resource.Store is SubStoreDefinition)
                    {
                        if (selectableStores.Contains(userResource.Resource.Store) == false)
                            selectableStores.Add(userResource.Resource.Store);
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                List<Store> SortedList = selectableStores.OrderBy(o => o.Name).ToList();
                return SortedList;
            }
        }
    }
}