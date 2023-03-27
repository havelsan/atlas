//$8001D759
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
    public partial class SubEpisodeServiceController : Controller
    {
        public class GetActiveSubEpisodeProtocol_Input
        {
            public TTObjectClasses.SubEpisode subEpisode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.SubEpisodeProtocol GetActiveSubEpisodeProtocol(GetActiveSubEpisodeProtocol_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.subEpisode != null)
                    input.subEpisode = (TTObjectClasses.SubEpisode)objectContext.AddObject(input.subEpisode);
                var ret = SubEpisode.GetOpenSubEpisodeProtocol(input.subEpisode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class MyAddress_Input
        {
            public TTObjectClasses.SubEpisode subEpisode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string MyAddress(MyAddress_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.subEpisode != null)
                    input.subEpisode = (TTObjectClasses.SubEpisode)objectContext.AddObject(input.subEpisode);
                var ret = SubEpisode.MyAddress(input.subEpisode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class MyDocumentNumber_Input
        {
            public TTObjectClasses.SubEpisode subEpisode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string MyDocumentNumber(MyDocumentNumber_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.subEpisode != null)
                    input.subEpisode = (TTObjectClasses.SubEpisode)objectContext.AddObject(input.subEpisode);
                var ret = SubEpisode.MyDocumentNumber(input.subEpisode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class MyDocumentDate_Input
        {
            public TTObjectClasses.SubEpisode subEpisode
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public System.DateTime? MyDocumentDate(MyDocumentDate_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.subEpisode != null)
                    input.subEpisode = (TTObjectClasses.SubEpisode)objectContext.AddObject(input.subEpisode);
                var ret = SubEpisode.MyDocumentDate(input.subEpisode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetNotDiagnosisExistsByPatientGroup_Input
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

            public int RESOURCEFLAG
            {
                get;
                set;
            }

            public IList<string> RESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisode.GetNotDiagnosisExistsByPatientGroup_Class> GetNotDiagnosisExistsByPatientGroup(GetNotDiagnosisExistsByPatientGroup_Input input)
        {
            var ret = SubEpisode.GetNotDiagnosisExistsByPatientGroup(input.STARTDATE, input.ENDDATE, input.RESOURCEFLAG, input.RESOURCE);
            return ret;
        }

        public class GetPatientInformationBySubepisodeid_Input
        {
            public string SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisode.GetPatientInformationBySubepisodeid_Class> GetPatientInformationBySubepisodeid(GetPatientInformationBySubepisodeid_Input input)
        {
            var ret = SubEpisode.GetPatientInformationBySubepisodeid(input.SUBEPISODE);
            return ret;
        }

        public class GetInpatientAndDischargeByEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisode> GetInpatientAndDischargeByEpisode(GetInpatientAndDischargeByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubEpisode.GetInpatientAndDischargeByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByEpisodeAndStarterEpisodeAction_Input
        {
            public string EPISODE
            {
                get;
                set;
            }

            public string STARTEREPISODEACTION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisode> GetByEpisodeAndStarterEpisodeAction(GetByEpisodeAndStarterEpisodeAction_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubEpisode.GetByEpisodeAndStarterEpisodeAction(objectContext, input.EPISODE, input.STARTEREPISODEACTION);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMaxProtocolNo_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisode.GetMaxProtocolNo_Class> GetMaxProtocolNo(GetMaxProtocolNo_Input input)
        {
            var ret = SubEpisode.GetMaxProtocolNo(input.EPISODE);
            return ret;
        }

        public class GetByEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisode> GetByEpisode(GetByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubEpisode.GetByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByDateAndPatientGroupAndDepartment_Input
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

            public int PATIENTSTATUS1
            {
                get;
                set;
            }

            public int PATIENTSTATUS2
            {
                get;
                set;
            }

            public int PATIENTSTATUS3
            {
                get;
                set;
            }

            public IList<string> RESOURCE
            {
                get;
                set;
            }

            public int RESOURCEFLAG
            {
                get;
                set;
            }

            public int PATIENTSTATUS4
            {
                get;
                set;
            }

            public int INPATIENTSTATUSFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisode.GetByDateAndPatientGroupAndDepartment_Class> GetByDateAndPatientGroupAndDepartment(GetByDateAndPatientGroupAndDepartment_Input input)
        {
            var ret = SubEpisode.GetByDateAndPatientGroupAndDepartment(input.STARTDATE, input.ENDDATE, input.PATIENTSTATUS1, input.PATIENTSTATUS2, input.PATIENTSTATUS3, input.RESOURCE, input.RESOURCEFLAG, input.PATIENTSTATUS4, input.INPATIENTSTATUSFLAG);
            return ret;
        }

        public class GetSubEpisodeExceptCancelled_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisode.GetSubEpisodeExceptCancelled_Class> GetSubEpisodeExceptCancelled(GetSubEpisodeExceptCancelled_Input input)
        {
            var ret = SubEpisode.GetSubEpisodeExceptCancelled(input.injectionSQL);
            return ret;
        }

        public class GetSpecialityBySubEpisodeFilter_Input
        {
            public string EPISODE
            {
                get;
                set;
            }

            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisode> GetSpecialityBySubEpisodeFilter(GetSpecialityBySubEpisodeFilter_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubEpisode.GetSpecialityBySubEpisodeFilter(objectContext, input.EPISODE, input.OBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<SubEpisode.VEM_HASTA_BASVURU_Class> VEM_HASTA_BASVURU()
        {
            var ret = SubEpisode.VEM_HASTA_BASVURU();
            return ret;
        }

        public class GetByObjectId_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<SubEpisode> GetByObjectId(GetByObjectId_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubEpisode.GetByObjectId(objectContext, input.OBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}