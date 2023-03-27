//$5153FF34
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
    public partial class ScheduleServiceController : Controller
    {
        public class GetByInjection_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Schedule> GetByInjection(GetByInjection_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Schedule.GetByInjection(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetWorkHourSchByDateAndResource_Input
        {
            public DateTime STARTTIME
            {
                get;
                set;
            }

            public string RESOURCE
            {
                get;
                set;
            }

            public string APPDEF
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Schedule> GetWorkHourSchByDateAndResource(GetWorkHourSchByDateAndResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Schedule.GetWorkHourSchByDateAndResource(objectContext, input.STARTTIME, input.RESOURCE, input.APPDEF);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByScheduleDateAndResource_Input
        {
            public DateTime STARTTIME
            {
                get;
                set;
            }

            public DateTime ENDTIME
            {
                get;
                set;
            }

            public string RESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Schedule> GetByScheduleDateAndResource(GetByScheduleDateAndResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Schedule.GetByScheduleDateAndResource(objectContext, input.STARTTIME, input.ENDTIME, input.RESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GrtScheduleByMHRSKesinCetvelID_Input
        {
            public long MHRSKESINCETVELID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Schedule> GrtScheduleByMHRSKesinCetvelID(GrtScheduleByMHRSKesinCetvelID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Schedule.GrtScheduleByMHRSKesinCetvelID(objectContext, input.MHRSKESINCETVELID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetWorkingResourcesForAsal_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Schedule.GetWorkingResourcesForAsal_Class> GetWorkingResourcesForAsal(GetWorkingResourcesForAsal_Input input)
        {
            var ret = Schedule.GetWorkingResourcesForAsal(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetSchedulaForMHRSTask_Input
        {
            public DateTime STARTTIME
            {
                get;
                set;
            }

            public DateTime ENDTIME
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Schedule> GetSchedulaForMHRSTask(GetSchedulaForMHRSTask_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Schedule.GetSchedulaForMHRSTask(objectContext, input.STARTTIME, input.ENDTIME);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GrtScheduleByMHRSTaslakID_Input
        {
            public long TASLAKCETVELID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Schedule> GrtScheduleByMHRSTaslakID(GrtScheduleByMHRSTaslakID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Schedule.GrtScheduleByMHRSTaslakID(objectContext, input.TASLAKCETVELID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetScheduleByResourceAndDate_Input
        {
            public string RESOURCE
            {
                get;
                set;
            }

            public DateTime STARTTIME
            {
                get;
                set;
            }

            public DateTime ENDTIME
            {
                get;
                set;
            }

            public string MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Schedule> GetScheduleByResourceAndDate(GetScheduleByResourceAndDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Schedule.GetScheduleByResourceAndDate(objectContext, input.RESOURCE, input.STARTTIME, input.ENDTIME, input.MASTERRESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetScheduleByMHRSIstisnaID_Input
        {
            public long MHRSISTISNAID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Schedule> GetScheduleByMHRSIstisnaID(GetScheduleByMHRSIstisnaID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Schedule.GetScheduleByMHRSIstisnaID(objectContext, input.MHRSISTISNAID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMHRSSchedules_Input
        {
            public Guid MASTERRESOURCE
            {
                get;
                set;
            }

            public Guid RESOURCE
            {
                get;
                set;
            }

            public DateTime STARTTIME
            {
                get;
                set;
            }

            public DateTime ENDTIME
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Schedule.GetMHRSSchedules_Class> GetMHRSSchedules(GetMHRSSchedules_Input input)
        {
            var ret = Schedule.GetMHRSSchedules(input.MASTERRESOURCE, input.RESOURCE, input.STARTTIME, input.ENDTIME);
            return ret;
        }

        public class GetScheduleForMHRS_Input
        {
            public DateTime STARTTIME
            {
                get;
                set;
            }

            public DateTime ENDTIME
            {
                get;
                set;
            }

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }

            public Guid RESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Schedule> GetScheduleForMHRS(GetScheduleForMHRS_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Schedule.GetScheduleForMHRS(objectContext, input.STARTTIME, input.ENDTIME, input.MASTERRESOURCE, input.RESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}