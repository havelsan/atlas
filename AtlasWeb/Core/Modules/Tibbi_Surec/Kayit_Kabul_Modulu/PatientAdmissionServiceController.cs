//$F3A9BE60
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
    public partial class PatientAdmissionServiceController : Controller
    {
        public class CreateEpisode_Input
        {
            public TTObjectClasses.PatientAdmission patientAdmission
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CreateEpisode(CreateEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patientAdmission != null)
                    input.patientAdmission = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.patientAdmission);
                PatientAdmission.FillEpisode(input.patientAdmission);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class PatientHasDebt_Input
        {
            public TTObjectClasses.PatientAdmission pa
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string PatientHasDebt(PatientHasDebt_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pa != null)
                    input.pa = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.pa);
                var ret = PatientAdmission.PatientHasDebt(input.pa);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class ControlAndCreateEpisodeProtocol_Input
        {
            public System.Collections.Generic.List<TTObjectClasses.ResSection> resList
            {
                get;
                set;
            }

            public TTObjectClasses.PatientAdmission patientAdmission
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void ControlAndCreateEpisodeProtocol(ControlAndCreateEpisodeProtocol_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patientAdmission != null)
                    input.patientAdmission = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.patientAdmission);
                PatientAdmission.ControlAndCreateEpisodeProtocol(input.resList, input.patientAdmission);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class FillSEPProperties_Input
        {
            public TTObjectClasses.PatientAdmission patientAdmission
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void FillSEPProperties(FillSEPProperties_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patientAdmission != null)
                    input.patientAdmission = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.patientAdmission);
                PatientAdmission.FillSEPProperties(input.patientAdmission);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class GetPatientBySearch_Input
        {
            public string searchString
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.Patient GetPatientBySearch(GetPatientBySearch_Input input)
        {
            var ret = PatientAdmission.GetPatientBySearch(input.searchString);
            return ret;
        }

        public class SetAdmissionResource_Input
        {
            public TTObjectClasses.PatientAdmission patientAdmission
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SetAdmissionResource(SetAdmissionResource_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patientAdmission != null)
                    input.patientAdmission = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.patientAdmission);
                PatientAdmission.SetEpisodeDetails(input.patientAdmission);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class ControlBulletinProtocol_Input
        {
            public TTObjectClasses.PatientAdmission patientAdmission
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void ControlBulletinProtocol(ControlBulletinProtocol_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patientAdmission != null)
                    input.patientAdmission = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.patientAdmission);
                PatientAdmission.ControlBulletinProtocol(input.patientAdmission);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class ReturnEpisodeWithSameSpecialityInTenDays_Input
        {
            public TTObjectClasses.PatientAdmission patientAdmission
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.Episode ReturnEpisodeWithSameSpecialityInTenDays(ReturnEpisodeWithSameSpecialityInTenDays_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patientAdmission != null)
                    input.patientAdmission = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.patientAdmission);
                var ret = PatientAdmission.ReturnEpisodeWithSameSpecialityInTenDays(input.patientAdmission, input.patientAdmission.Episode.Patient);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class SetProcedureDoctor_Input
        {
            public TTObjectClasses.PatientAdmission pa
            {
                get;
                set;
            }
        }

        public class SetCurrentAdmissionStatus_Input
        {
            public TTObjectClasses.PatientAdmission pa
            {
                get;
                set;
            }
        }

        public class SetAdmissionStatus_Input
        {
            public TTObjectClasses.PatientAdmission pa
            {
                get;
                set;
            }
        }

        public class SavePatientAdmission_Input
        {
            public TTObjectClasses.PatientAdmission pa
            {
                get;
                set;
            }
            public int activeTab
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.PatientAdmission SavePatientAdmission(SavePatientAdmission_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pa != null)
                    input.pa = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.pa);
                var ret = PatientAdmission.SavePatientAdmission(input.pa, input.activeTab, false);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class CancelEpisodeActionAndSubActionProcedure_Input
        {
            public TTObjectClasses.PatientAdmission pa
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CancelEpisodeActionAndSubActionProcedure(CancelEpisodeActionAndSubActionProcedure_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pa != null)
                    input.pa = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.pa);
                PatientAdmission.CancelEpisodeActionAndSubActionProcedure(input.pa);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class FireEpisodeActionAndSubActionProcedure_Input
        {
            public TTObjectClasses.PatientAdmission pa
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void FireEpisodeActionAndSubActionProcedure(FireEpisodeActionAndSubActionProcedure_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pa != null)
                    input.pa = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.pa);
                PatientAdmission.FireEpisodeActionAndSubActionProcedure(input.pa,input.pa.Episode.Patient);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class SelectMedulaHastaKabul_Input
        {
            public TTObjectClasses.PatientAdmission pa
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.PatientMedulaHastaKabul SelectMedulaHastaKabul(SelectMedulaHastaKabul_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pa != null)
                    input.pa = (TTObjectClasses.PatientAdmission)objectContext.AddObject(input.pa);
                var ret = PatientAdmission.SelectMedulaHastaKabul(input.pa);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class LoadPatientAdmission_Input
        {
            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.PatientAdmission LoadPatientAdmission(LoadPatientAdmission_Input input)
        {
            using (var ctx = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)ctx.AddObject(input.patient);
                var ret = PatientAdmission.LoadPatientAdmission(input.patient, ctx);
                ctx.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAdressInfoNotExists_Input
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
        }

        [HttpPost]
        public BindingList<PatientAdmission.GetAdressInfoNotExists_Class> GetAdressInfoNotExists(GetAdressInfoNotExists_Input input)
        {
            var ret = PatientAdmission.GetAdressInfoNotExists(input.STARTDATE, input.ENDDATE, input.RESOURCE, input.RESOURCEFLAG);
            return ret;
        }

        public class GetProvisionNumberNotExists_Input
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
        }

        [HttpPost]
        public BindingList<PatientAdmission.GetProvisionNumberNotExists_Class> GetProvisionNumberNotExists(GetProvisionNumberNotExists_Input input)
        {
            var ret = PatientAdmission.GetProvisionNumberNotExists(input.STARTDATE, input.ENDDATE, input.RESOURCE, input.RESOURCEFLAG);
            return ret;
        }

        public class GetPatientAdmissionsCount_Input
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
        public BindingList<PatientAdmission.GetPatientAdmissionsCount_Class> GetPatientAdmissionsCount(GetPatientAdmissionsCount_Input input)
        {
            var ret = PatientAdmission.GetPatientAdmissionsCount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class CloseDailyAdmisnsAfter24_Input
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
        public BindingList<PatientAdmission> CloseDailyAdmisnsAfter24(CloseDailyAdmisnsAfter24_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PatientAdmission.CloseDailyAdmisnsAfter24(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_AdliVaka_Input
        {
            public DateTime DATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientAdmission.OLAP_AdliVaka_Class> OLAP_AdliVaka(OLAP_AdliVaka_Input input)
        {
            var ret = PatientAdmission.OLAP_AdliVaka(input.DATE);
            return ret;
        }

        public class GetOutPatientEtiquette_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientAdmission.GetOutPatientEtiquette_Class> GetOutPatientEtiquette(GetOutPatientEtiquette_Input input)
        {
            var ret = PatientAdmission.GetOutPatientEtiquette(input.OBJECTID);
            return ret;
        }

        public class GetForeignPatientsNQL_Input
        {
            public DateTime ACTIONSTARTDATE
            {
                get;
                set;
            }

            public DateTime ACTIONENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientAdmission.GetForeignPatientsNQL_Class> GetForeignPatientsNQL(GetForeignPatientsNQL_Input input)
        {
            var ret = PatientAdmission.GetForeignPatientsNQL(input.ACTIONSTARTDATE, input.ACTIONENDDATE);
            return ret;
        }

        public class GetMAPByCountryAndDate_Input
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

            public string MAINSPECIALITY
            {
                get;
                set;
            }

            public int MAINSPECIALITYFLAG
            {
                get;
                set;
            }

            public int INPATIENTFLAG
            {
                get;
                set;
            }

            public int OUTPATIENTFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientAdmission.GetMAPByCountryAndDate_Class> GetMAPByCountryAndDate(GetMAPByCountryAndDate_Input input)
        {
            var ret = PatientAdmission.GetMAPByCountryAndDate(input.STARTDATE, input.ENDDATE, input.MAINSPECIALITY, input.MAINSPECIALITYFLAG, input.INPATIENTFLAG, input.OUTPATIENTFLAG);
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PatientAdmission.VEM_HASTA_ILETISIM_Class> VEM_HASTA_ILETISIM()
        {
            var ret = PatientAdmission.VEM_HASTA_ILETISIM();
            return ret;
        }
    }
}