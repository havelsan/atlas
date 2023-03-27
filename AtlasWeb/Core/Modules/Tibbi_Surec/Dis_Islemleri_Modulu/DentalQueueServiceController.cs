//$157279BC
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class DentalQueueServiceController : Controller
    {
        public class GetDentalQueueById_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalQueue> GetDentalQueueById(GetDentalQueueById_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DentalQueue.GetDentalQueueById(objectContext, input.OBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class DentalQueueItems_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }

            public DateTime QUEUEENDDATE
            {
                get;
                set;
            }

            public DateTime QUEUESTARTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalQueue> DentalQueueItems(DentalQueueItems_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DentalQueue.DentalQueueItems(objectContext, input.PATIENT, input.QUEUEENDDATE, input.QUEUESTARTDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class DentalQueueItemsAll_Input
        {
            public DateTime QUEUESTARTDATE
            {
                get;
                set;
            }

            public DateTime QUEUEENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalQueue> DentalQueueItemsAll(DentalQueueItemsAll_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DentalQueue.DentalQueueItemsAll(objectContext, input.QUEUESTARTDATE, input.QUEUEENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class DentalQueueItemsByProcedure_Input
        {
            public DateTime QUEUESTARTDATE
            {
                get;
                set;
            }

            public DateTime QUEUEENDDATE
            {
                get;
                set;
            }

            public Guid PROCEDUREDEFINITION
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DentalQueue> DentalQueueItemsByProcedure(DentalQueueItemsByProcedure_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DentalQueue.DentalQueueItemsByProcedure(objectContext, input.QUEUESTARTDATE, input.QUEUEENDDATE, input.PROCEDUREDEFINITION);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}