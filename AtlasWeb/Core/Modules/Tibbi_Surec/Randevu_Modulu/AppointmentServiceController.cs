//$C42ECA98
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
    public partial class AppointmentServiceController : Controller
    {
        public class GetAppointmentListReportNQL_Input
        {
            public IList<string> OBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment.GetAppointmentListReportNQL_Class> GetAppointmentListReportNQL(GetAppointmentListReportNQL_Input input)
        {
            var ret = Appointment.GetAppointmentListReportNQL(input.OBJECTIDS);
            return ret;
        }

        public class GetByPatientAndAppDate_Input
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

            public string PATIENT
            {
                get;
                set;
            }

            public DateTime APPDATE
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetByPatientAndAppDate(GetByPatientAndAppDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetByPatientAndAppDate(objectContext, input.STARTTIME, input.ENDTIME, input.PATIENT, input.APPDATE, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetBySubActionProcedureAndState_Input
        {
            public string SUBACTIONPROCEDURE
            {
                get;
                set;
            }

            public string STATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetBySubActionProcedureAndState(GetBySubActionProcedureAndState_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetBySubActionProcedureAndState(objectContext, input.SUBACTIONPROCEDURE, input.STATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByStartTimeAndResource_Input
        {
            public DateTime APPDATE
            {
                get;
                set;
            }

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

            public DateTime ENDTIME
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetByStartTimeAndResource(GetByStartTimeAndResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetByStartTimeAndResource(objectContext, input.APPDATE, input.STARTTIME, input.RESOURCE, input.ENDTIME, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByInjection_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetByInjection(GetByInjection_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetByInjection(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByActionAndState_Input
        {
            public string ACTION
            {
                get;
                set;
            }

            public string STATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetByActionAndState(GetByActionAndState_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetByActionAndState(objectContext, input.ACTION, input.STATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByPatientByDateByResource_Input
        {
            public string PATIENT
            {
                get;
                set;
            }

            public DateTime APPDATE
            {
                get;
                set;
            }

            public string MASTERRESOURCE
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
        public BindingList<Appointment> GetByPatientByDateByResource(GetByPatientByDateByResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetByPatientByDateByResource(objectContext, input.PATIENT, input.APPDATE, input.MASTERRESOURCE, input.RESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByAppDateAndResource_Input
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

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetByAppDateAndResource(GetByAppDateAndResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetByAppDateAndResource(objectContext, input.STARTTIME, input.ENDTIME, input.RESOURCE, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByAppDate_Input
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

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetByAppDate(GetByAppDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetByAppDate(objectContext, input.STARTDATE, input.ENDDATE, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAppointmentByPatientExaminationID_Input
        {
            public string PATIENTEXAMINATIONOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment.GetAppointmentByPatientExaminationID_Class> GetAppointmentByPatientExaminationID(GetAppointmentByPatientExaminationID_Input input)
        {
            var ret = Appointment.GetAppointmentByPatientExaminationID(input.PATIENTEXAMINATIONOBJECTID);
            return ret;
        }

        public class GetAppointmentsForAppViewer_Input
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

            public IList<string> MASTERRESOURCEOBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment.GetAppointmentsForAppViewer_Class> GetAppointmentsForAppViewer(GetAppointmentsForAppViewer_Input input)
        {
            var ret = Appointment.GetAppointmentsForAppViewer(input.STARTDATE, input.ENDDATE, input.MASTERRESOURCEOBJECTIDS);
            return ret;
        }

        public class GetPatientAppointmentsByDate_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }

            public DateTime APPSTARTDATE
            {
                get;
                set;
            }

            public DateTime APPENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetPatientAppointmentsByDate(GetPatientAppointmentsByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetPatientAppointmentsByDate(objectContext, input.PATIENT, input.APPSTARTDATE, input.APPENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMinNumaratorAppointmentResource_Input
        {
            public Guid MASTERRESOURCE
            {
                get;
                set;
            }

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
        public BindingList<Appointment.GetMinNumaratorAppointmentResource_Class> GetMinNumaratorAppointmentResource(GetMinNumaratorAppointmentResource_Input input)
        {
            var ret = Appointment.GetMinNumaratorAppointmentResource(input.MASTERRESOURCE, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetAppointmentByResourceAndPatient_Input
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

            public Guid RESOURCE
            {
                get;
                set;
            }

            public Guid PATIENT
            {
                get;
                set;
            }

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment.GetAppointmentByResourceAndPatient_Class> GetAppointmentByResourceAndPatient(GetAppointmentByResourceAndPatient_Input input)
        {
            var ret = Appointment.GetAppointmentByResourceAndPatient(input.STARTTIME, input.ENDTIME, input.RESOURCE, input.PATIENT, input.MASTERRESOURCE);
            return ret;
        }

        public class GetByMHRSRandevuHrn_Input
        {
            public string MHRSRANDEVUHRN
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetByMHRSRandevuHrn(GetByMHRSRandevuHrn_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetByMHRSRandevuHrn(objectContext, input.MHRSRANDEVUHRN);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientComeToMHRSAppointment_Input
        {
            public DateTime STARTTIME
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetPatientComeToMHRSAppointment(GetPatientComeToMHRSAppointment_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetPatientComeToMHRSAppointment(objectContext, input.STARTTIME);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetBySchedule_Input
        {
            public string SCHEDULE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetBySchedule(GetBySchedule_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetBySchedule(objectContext, input.SCHEDULE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetMHRSAppointment_Input
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

            public Guid RESOURCE
            {
                get;
                set;
            }

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment.GetMHRSAppointment_Class> GetMHRSAppointment(GetMHRSAppointment_Input input)
        {
            var ret = Appointment.GetMHRSAppointment(input.STARTTIME, input.ENDTIME, input.RESOURCE, input.MASTERRESOURCE);
            return ret;
        }

        public class GetBreakAppointmentListReportNQL_Input
        {
            public IList<string> OBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment.GetBreakAppointmentListReportNQL_Class> GetBreakAppointmentListReportNQL(GetBreakAppointmentListReportNQL_Input input)
        {
            var ret = Appointment.GetBreakAppointmentListReportNQL(input.OBJECTIDS);
            return ret;
        }

        public class GetByFirstAvailableAppoinmentResource_Input
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

            public DateTime ENDTIME
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetByFirstAvailableAppoinmentResource(GetByFirstAvailableAppoinmentResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetByFirstAvailableAppoinmentResource(objectContext, input.STARTTIME, input.RESOURCE, input.ENDTIME, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAppointmentBySchedule_Input
        {
            public Guid SCHEDULE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment.GetAppointmentBySchedule_Class> GetAppointmentBySchedule(GetAppointmentBySchedule_Input input)
        {
            var ret = Appointment.GetAppointmentBySchedule(input.SCHEDULE);
            return ret;
        }

        public class GetByEpisodeActionAndState_Input
        {
            public string EPISODEACTION
            {
                get;
                set;
            }

            public string STATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetByEpisodeActionAndState(GetByEpisodeActionAndState_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetByEpisodeActionAndState(objectContext, input.EPISODEACTION, input.STATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<Appointment.VEM_RANDEVU_Class> VEM_RANDEVU()
        {
            var ret = Appointment.VEM_RANDEVU();
            return ret;
        }

        [HttpPost]
        public BindingList<Appointment> GetPatientComeToMHRSApp()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetPatientComeToMHRSApp(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientAdmissionAppointmentsByID_Input
        {
            public DateTime APPENDDATE
            {
                get;
                set;
            }

            public DateTime APPSTARTDATE
            {
                get;
                set;
            }

            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment> GetPatientAdmissionAppointmentsByID(GetPatientAdmissionAppointmentsByID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetPatientAdmissionAppointmentsByID(objectContext, input.APPENDDATE, input.APPSTARTDATE, input.OBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientAppointmentByID_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment.GetPatientAppointmentByID_Class> GetPatientAppointmentByID(GetPatientAppointmentByID_Input input)
        {
            var ret = Appointment.GetPatientAppointmentByID(input.OBJECTID);
            return ret;
        }

        public class GetAppointmentByDateAndPatient_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }

            public DateTime APPSTARTDATE
            {
                get;
                set;
            }

            public DateTime APPENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Appointment.GetAppointmentByDateAndPatient_Class> GetAppointmentByDateAndPatient(GetAppointmentByDateAndPatient_Input input)
        {
            var ret = Appointment.GetAppointmentByDateAndPatient(input.PATIENT, input.APPSTARTDATE, input.APPENDDATE);
            return ret;
        }

        public class GetPatientAdmissionAppointmentsByDate_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }

            public DateTime APPSTARTDATE
            {
                get;
                set;
            }

            public DateTime APPENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Appointment> GetPatientAdmissionAppointmentsByDate(GetPatientAdmissionAppointmentsByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Appointment.GetPatientAdmissionAppointmentsByDate(objectContext, input.PATIENT, input.APPSTARTDATE, input.APPENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}