//$3778B63A
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
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class RadiologyTestServiceController : Controller
    {
        public class PrintRadiologyRequestBarcode_Input
        {
            public TTObjectClasses.RadiologyTest radTest
            {
                get;
                set;
            }
        }

        public class SendRadiologyTestToPACS_Input
        {
            public TTObjectClasses.RadiologyTest radTest
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Radyoloji_Test_Islemde, TTRoleNames.Radyoloji_Test_R)]
        public void SendRadiologyTestToPACS(SendRadiologyTestToPACS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.radTest != null)
                    input.radTest = (TTObjectClasses.RadiologyTest)objectContext.AddObject(input.radTest);
                RadiologyTest.SendRadiologyTestToPACS(input.radTest);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class WorkListNQL_Input
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
        public BindingList<RadiologyTest> WorkListNQL(WorkListNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = RadiologyTest.WorkListNQL(objectContext, input.STARTDATE, input.ENDDATE, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTests_Input
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
        public BindingList<RadiologyTest> GetTests(GetTests_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = RadiologyTest.GetTests(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class RadiologyTestAppointmentInfoQuery_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class> RadiologyTestAppointmentInfoQuery(RadiologyTestAppointmentInfoQuery_Input input)
        {
            var ret = RadiologyTest.RadiologyTestAppointmentInfoQuery(input.PARAMOBJID);
            return ret;
        }

        public class GetRadTestByPatientByTestByDate_Input
        {
            public string PATIENTID
            {
                get;
                set;
            }

            public string TESTID
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
        public BindingList<RadiologyTest> GetRadTestByPatientByTestByDate(GetRadTestByPatientByTestByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = RadiologyTest.GetRadTestByPatientByTestByDate(objectContext, input.PATIENTID, input.TESTID, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class RadiologyTestResultReport_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.RadiologyTestResultReport_Class> RadiologyTestResultReport(RadiologyTestResultReport_Input input)
        {
            var ret = RadiologyTest.RadiologyTestResultReport(input.PARAMOBJID);
            return ret;
        }

        public class RadiologyTestPatientInfoReportQuery_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.RadiologyTestPatientInfoReportQuery_Class> RadiologyTestPatientInfoReportQuery(RadiologyTestPatientInfoReportQuery_Input input)
        {
            var ret = RadiologyTest.RadiologyTestPatientInfoReportQuery(input.PARAMOBJID);
            return ret;
        }

        public class OLAP_GetCancelledRadiologyTest_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.OLAP_GetCancelledRadiologyTest_Class> OLAP_GetCancelledRadiologyTest(OLAP_GetCancelledRadiologyTest_Input input)
        {
            var ret = RadiologyTest.OLAP_GetCancelledRadiologyTest(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetByWLFilterExpression_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest> GetByWLFilterExpression(GetByWLFilterExpression_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = RadiologyTest.GetByWLFilterExpression(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class RadiologyTestByObjectIDQuery_Input
        {
            public string PARAMTESTOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.RadiologyTestByObjectIDQuery_Class> RadiologyTestByObjectIDQuery(RadiologyTestByObjectIDQuery_Input input)
        {
            var ret = RadiologyTest.RadiologyTestByObjectIDQuery(input.PARAMTESTOBJID);
            return ret;
        }

        public class GetRadiologyTestByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.GetRadiologyTestByEpisode_Class> GetRadiologyTestByEpisode(GetRadiologyTestByEpisode_Input input)
        {
            var ret = RadiologyTest.GetRadiologyTestByEpisode(input.EPISODE);
            return ret;
        }

        public class GetRadTestByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest> GetRadTestByEpisode(GetRadTestByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = RadiologyTest.GetRadTestByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetRadTestBySubEpisode_Input
        {
            public Guid SUBEPISODE
            {
                get;
                set;
            }

            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest> GetRadTestBySubEpisode(GetRadTestBySubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = RadiologyTest.GetRadTestBySubEpisode(objectContext, input.SUBEPISODE, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetRadiologyTestBySubEpisode_Input
        {
            public string SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.GetRadiologyTestBySubEpisode_Class> GetRadiologyTestBySubEpisode(GetRadiologyTestBySubEpisode_Input input)
        {
            var ret = RadiologyTest.GetRadiologyTestBySubEpisode(input.SUBEPISODE);
            return ret;
        }

        public class GetByRadTestWorklistDateReport_Input
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
        public BindingList<RadiologyTest.GetByRadTestWorklistDateReport_Class> GetByRadTestWorklistDateReport(GetByRadTestWorklistDateReport_Input input)
        {
            var ret = RadiologyTest.GetByRadTestWorklistDateReport( input.injectionSQL);
            return ret;
        }

        public class GetRadiologyTestStatisticsByFilter_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.GetRadiologyTestStatisticsByFilter_Class> GetRadiologyTestStatisticsByFilter(GetRadiologyTestStatisticsByFilter_Input input)
        {
            var ret = RadiologyTest.GetRadiologyTestStatisticsByFilter(input.injectionSQL);
            return ret;
        }

        public class GetByRadTestFilterExpressionReport_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.GetByRadTestFilterExpressionReport_Class> GetByRadTestFilterExpressionReport(GetByRadTestFilterExpressionReport_Input input)
        {
            var ret = RadiologyTest.GetByRadTestFilterExpressionReport(input.injectionSQL);
            return ret;
        }

        public class GetByFilterExpressionStatistics_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest> GetByFilterExpressionStatistics(GetByFilterExpressionStatistics_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = RadiologyTest.GetByFilterExpressionStatistics(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.VEM_RADYOLOJI_SONUC_Class> VEM_RADYOLOJI_SONUC()
        {
            var ret = RadiologyTest.VEM_RADYOLOJI_SONUC();
            return ret;
        }

        public class GetOldInfoForRadiology_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<RadiologyTest.GetOldInfoForRadiology_Class> GetOldInfoForRadiology(GetOldInfoForRadiology_Input input)
        {
            var ret = RadiologyTest.GetOldInfoForRadiology(input.PATIENT);
            return ret;
        }

        public class GetOldInfoCountRadiology_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<RadiologyTest.GetOldInfoCountRadiology_Class> GetOldInfoCountRadiology(GetOldInfoCountRadiology_Input input)
        {
            var ret = RadiologyTest.GetOldInfoCountRadiology(input.PATIENT);
            return ret;
        }

        [HttpGet]
        public List<vmPatientRadiologyTest> GetPatientAllRadiologyTests(string PatientObjectId, int TimeInterval)
        {
          
            List<vmPatientRadiologyTest> patientRadiologyTest = new List<vmPatientRadiologyTest>();
          
            int timeInt = Convert.ToInt16(TimeInterval);
            string sql = "";
            if (timeInt != 0)//Tümü
            {
                DateTime endDate = Common.RecTime();
                DateTime startDate = Convert.ToDateTime(Common.RecTime()).AddMonths(-timeInt);
                sql += " AND REQUESTDATE BETWEEN TODATE('" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd HH:mm:ss") + "') AND TODATE('" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd HH:mm:ss") + "')";

               
            }

            bool isPACSEntegrated = false;

            if (TTObjectClasses.SystemParameter.GetParameterValue("PACSENTEGRATION", "FALSE") == "TRUE")
                isPACSEntegrated = true;

        


            List<RadiologyTest.GetPatientOldRadiologyTestByDate_Class> patientOldRadiologyTests = RadiologyTest.GetPatientOldRadiologyTestByDate(PatientObjectId, sql).ToList();
            foreach (RadiologyTest.GetPatientOldRadiologyTestByDate_Class radTest in patientOldRadiologyTests)
            {
                vmPatientRadiologyTest vmRadTest = new vmPatientRadiologyTest();
                vmRadTest.SubActionProcedureObjectId = (Guid)radTest.Radtestobjid;
                vmRadTest.RequestDate = (DateTime)radTest.RequestDate;
                vmRadTest.ProcedureCode = radTest.Testcode;
                vmRadTest.ProcedureName = radTest.Testname;
                vmRadTest.RequestedByResUser = radTest.Requesteddoctor;
                vmRadTest.ProcedureResUser = radTest.Proceduredoctor;
                vmRadTest.ActionStatus = radTest.DisplayText;
                vmRadTest.FromResourceName = radTest.Fromresourcename;
                vmRadTest.isReportShown = true;

                if (isPACSEntegrated)
                {
                    if (radTest.AccessionNo != null && radTest.AccessionNo.ToString() != "")
                    {
                        vmRadTest.AccessionNo = radTest.AccessionNo.ToString();
                        string accessionNo = "";
                        accessionNo = radTest.AccessionNo.ToString();
                        vmRadTest.isResultShown = true;
                        //vmRadTest.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?an=" + accessionNo + "&usr=extreme";

                        if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "EXTREME")
                        {
                            vmRadTest.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?an=" + accessionNo + "&usr=extreme";

                        }
                        else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "COMPANY1") == "COMPANY2")
                        {
                            TTObjectContext objContext = new TTObjectContext(false);
                            Patient p = (Patient)objContext.GetObject(new Guid(PatientObjectId), "Patient");

                            vmRadTest.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?accession=" + accessionNo + "&patientid=" + p.UniqueRefNo?.ToString() + "&ietab=true";
                        }
                        else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "XXXXXX")
                        {
                            vmRadTest.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "&accession=" + accessionNo+ "&StudyReload=1";

                        }

                    }
                }


                patientRadiologyTest.Add(vmRadTest);

            }
            
                return patientRadiologyTest;
        }
    }
}