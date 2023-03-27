//$A2DCB18A
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ResourceServiceController : Controller
    {
        public class GetStore_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone, TTRoleNames.Hasta_Muayenesi_Hasta_Gelmedi, TTRoleNames.Hasta_Muayenesi_Muayene_R, TTRoleNames.Hasta_Muayenesi_Muayene, TTRoleNames.Hasta_Muayenesi_Tamamlandi, TTRoleNames.Hasta_Muayenesi_Muayene_w, TTRoleNames.Hasta_Muayenesi_Tamamlandi_R, TTRoleNames.Hasta_Muayenesi_Tamamlandi_W, TTRoleNames.Hasta_Muayenesi_Hemsirelik_Uygulamalari, TTRoleNames.Hasta_Muayenesi_Iptal_Etme, TTRoleNames.SorumluDoktorTamamlanmisIslemGorme, TTRoleNames.Hasta_Muayenesi_Geri_Alma, TTRoleNames.Hasta_Muayenesi_Iptal_Edildi, TTRoleNames.Hasta_Muayenesi_Randevu, TTRoleNames.Hasta_Muayenesi_Yeni)]
        public TTObjectClasses.Store GetStore(GetStore_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.OBJECTID != null)
                {
                    Resource resource = (Resource)objectContext.GetObject(new Guid(input.OBJECTID), typeof (Resource));
                    var ret = resource.Store;
                    objectContext.FullPartialllyLoadedObjects();
                    return ret;
                }

                return null;
            }
        }

        public class GetResource_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Resource> GetResource(GetResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Resource.GetResource(objectContext, input.OBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetResources_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Resource> GetResources(GetResources_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Resource.GetResources(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetResourcesForQueueInDate_Input
        {
            public Guid QUEUE
            {
                get;
                set;
            }

            public DateTime WORKDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Resource> GetResourcesForQueueInDate(GetResourcesForQueueInDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Resource.GetResourcesForQueueInDate(objectContext, input.QUEUE, input.WORKDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetResourceByStore_Input
        {
            public Guid STOREID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Resource> GetResourceByStore(GetResourceByStore_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Resource.GetResourceByStore(objectContext, input.STOREID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}