//$F471286A
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
    public partial class PathologyServiceController : Controller
    {
        public class CheckUncompletedSpecialProcedures_Input
        {
            public TTObjectClasses.Pathology pathology
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CheckUncompletedSpecialProcedures(CheckUncompletedSpecialProcedures_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pathology != null)
                    input.pathology = (TTObjectClasses.Pathology)objectContext.AddObject(input.pathology);
                Pathology.CheckUncompletedSpecialProcedures(input.pathology);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class PathologyTestReqStateInfoNQL_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.PathologyTestReqStateInfoNQL_Class> PathologyTestReqStateInfoNQL(PathologyTestReqStateInfoNQL_Input input)
        {
            var ret = Pathology.PathologyTestReqStateInfoNQL(input.PARAMOBJID);
            return ret;
        }

        public class PathologyTestRequestInfoStickerNQL_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.PathologyTestRequestInfoStickerNQL_Class> PathologyTestRequestInfoStickerNQL(PathologyTestRequestInfoStickerNQL_Input input)
        {
            var ret = Pathology.PathologyTestRequestInfoStickerNQL(input.PARAMOBJID);
            return ret;
        }

        public class PathologyTestReportQuery_Input
        {
            public string PARAMPATOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.PathologyTestReportQuery_Class> PathologyTestReportQuery(PathologyTestReportQuery_Input input)
        {
            var ret = Pathology.PathologyTestReportQuery(input.PARAMPATOBJID);
            return ret;
        }

        public class PathologyTestResultPatientInfoReportQuery_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.PathologyTestResultPatientInfoReportQuery_Class> PathologyTestResultPatientInfoReportQuery(PathologyTestResultPatientInfoReportQuery_Input input)
        {
            var ret = Pathology.PathologyTestResultPatientInfoReportQuery(input.PARAMOBJID);
            return ret;
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
        public BindingList<Pathology> WorkListNQL(WorkListNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Pathology.WorkListNQL(objectContext, input.STARTDATE, input.ENDDATE, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class PathologyTestResultReportQuery_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.PathologyTestResultReportQuery_Class> PathologyTestResultReportQuery(PathologyTestResultReportQuery_Input input)
        {
            var ret = Pathology.PathologyTestResultReportQuery(input.PARAMOBJID);
            return ret;
        }

        public class GetPatTestByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology> GetPatTestByEpisode(GetPatTestByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Pathology.GetPatTestByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPathologyStatisticsByInjection_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.GetPathologyStatisticsByInjection_Class> GetPathologyStatisticsByInjection(GetPathologyStatisticsByInjection_Input input)
        {
            var ret = Pathology.GetPathologyStatisticsByInjection(input.injectionSQL);
            return ret;
        }

        public class GetPathologyTestByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.GetPathologyTestByEpisode_Class> GetPathologyTestByEpisode(GetPathologyTestByEpisode_Input input)
        {
            var ret = Pathology.GetPathologyTestByEpisode(input.EPISODE);
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
        public BindingList<Pathology> GetByWLFilterExpression(GetByWLFilterExpression_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Pathology.GetByWLFilterExpression(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByPatTestFilterExpressionReport_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.GetByPatTestFilterExpressionReport_Class> GetByPatTestFilterExpressionReport(GetByPatTestFilterExpressionReport_Input input)
        {
            var ret = Pathology.GetByPatTestFilterExpressionReport(input.injectionSQL);
            return ret;
        }

        public class GetByPatTestWorklistDateReport_Input
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
        public BindingList<Pathology.GetByPatTestWorklistDateReport_Class> GetByPatTestWorklistDateReport(GetByPatTestWorklistDateReport_Input input)
        {
            var ret = Pathology.GetByPatTestWorklistDateReport(input.STARTDATE, input.ENDDATE, input.injectionSQL);
            return ret;
        }

        public class GetPathologyTestBySubEpisode_Input
        {
            public string SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.GetPathologyTestBySubEpisode_Class> GetPathologyTestBySubEpisode(GetPathologyTestBySubEpisode_Input input)
        {
            var ret = Pathology.GetPathologyTestBySubEpisode(input.SUBEPISODE);
            return ret;
        }

        public class GetPatTestBySubEpisode_Input
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
        public BindingList<Pathology> GetPatTestBySubEpisode(GetPatTestBySubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Pathology.GetPatTestBySubEpisode(objectContext, input.SUBEPISODE, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPathologyStatisticsNewNQL_Input
        {
            public string ASSISTANTDOCTOR
            {
                get;
                set;
            }

            public int ASSISTANTDOCTOR_FLG
            {
                get;
                set;
            }

            public string MATPRTNO
            {
                get;
                set;
            }

            public int MATPRTNO_FLG
            {
                get;
                set;
            }

            public string RESPONSIBLEDOCTOR
            {
                get;
                set;
            }

            public int RESPONSIBLEDOCTOR_FLG
            {
                get;
                set;
            }

            public string SPECIALDOCTOR
            {
                get;
                set;
            }

            public int SPECIALDOCTOR_FLG
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public int TESTCATEGORY_FLG
            {
                get;
                set;
            }

            public string UNIQUEREFNO
            {
                get;
                set;
            }

            public int UNIQUEREFNO_FLG
            {
                get;
                set;
            }

            public int TEST_FLG
            {
                get;
                set;
            }

            public string SNOMEDDIAGNOSIS
            {
                get;
                set;
            }

            public int SNOMEDDIAGNOSIS_FLG
            {
                get;
                set;
            }

            public string DIAGNOSIS
            {
                get;
                set;
            }

            public int DIAGNOSIS_FLG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.GetPathologyStatisticsNewNQL_Class> GetPathologyStatisticsNewNQL(GetPathologyStatisticsNewNQL_Input input)
        {
            var ret = Pathology.GetPathologyStatisticsNewNQL(input.ASSISTANTDOCTOR, input.ASSISTANTDOCTOR_FLG, input.MATPRTNO, input.MATPRTNO_FLG, input.RESPONSIBLEDOCTOR, input.RESPONSIBLEDOCTOR_FLG, input.SPECIALDOCTOR, input.SPECIALDOCTOR_FLG, input.ENDDATE, input.STARTDATE, input.TESTCATEGORY_FLG, input.UNIQUEREFNO, input.UNIQUEREFNO_FLG, input.TEST_FLG, input.SNOMEDDIAGNOSIS, input.SNOMEDDIAGNOSIS_FLG, input.DIAGNOSIS, input.DIAGNOSIS_FLG);
            return ret;
        }

        public class OLAP_GetPathologyTest_Input
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
        public BindingList<Pathology.OLAP_GetPathologyTest_Class> OLAP_GetPathologyTest(OLAP_GetPathologyTest_Input input)
        {
            var ret = Pathology.OLAP_GetPathologyTest(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetCancelledPathologyTest_Input
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
        public BindingList<Pathology.OLAP_GetCancelledPathologyTest_Class> OLAP_GetCancelledPathologyTest(OLAP_GetCancelledPathologyTest_Input input)
        {
            var ret = Pathology.OLAP_GetCancelledPathologyTest(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetByFilterExpression_Input
        {
            public DateTime BIRTHDAYMIN
            {
                get;
                set;
            }

            public DateTime BIRTHDAYMAX
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
        public BindingList<Pathology> GetByFilterExpression(GetByFilterExpression_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Pathology.GetByFilterExpression(objectContext, input.BIRTHDAYMIN, input.BIRTHDAYMAX, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPathologyStatisticsNQL_Input
        {
            public string CARDNO
            {
                get;
                set;
            }

            public string MATPRTNO
            {
                get;
                set;
            }

            public string DIAGNOSIS
            {
                get;
                set;
            }

            public string SNOMEDDIAGNOSIS
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

            public string RESPONSIBLEDOCTOR
            {
                get;
                set;
            }

            public string SPECIALDOCTOR
            {
                get;
                set;
            }

            public string ASSISTANTDOCTOR
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.GetPathologyStatisticsNQL_Class> GetPathologyStatisticsNQL(GetPathologyStatisticsNQL_Input input)
        {
            var ret = Pathology.GetPathologyStatisticsNQL(input.CARDNO, input.MATPRTNO, input.DIAGNOSIS, input.SNOMEDDIAGNOSIS, input.STARTDATE, input.ENDDATE, input.RESPONSIBLEDOCTOR, input.SPECIALDOCTOR, input.ASSISTANTDOCTOR);
            return ret;
        }

        public class PathologyTestRequestBarcodeNQL_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Pathology.PathologyTestRequestBarcodeNQL_Class> PathologyTestRequestBarcodeNQL(PathologyTestRequestBarcodeNQL_Input input)
        {
            var ret = Pathology.PathologyTestRequestBarcodeNQL(input.PARAMOBJID);
            return ret;
        }

        public class GetPathologyTestStatisticsByFilter_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Pathology.GetPathologyTestStatisticsByFilter_Class> GetPathologyTestStatisticsByFilter(GetPathologyTestStatisticsByFilter_Input input)
        {
            var ret = Pathology.GetPathologyTestStatisticsByFilter(input.injectionSQL);
            return ret;
        }


        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public PathologySubepisodeInfo[] GetPathologyReportsByPatientID(string PatientObjectID)
        {
            List<PathologySubepisodeInfo> result = new List<PathologySubepisodeInfo>();
    
            List<Pathology.GetPathologySubepisodesByPatientID_Class> subepisodes = Pathology.GetPathologySubepisodesByPatientID(new Guid(PatientObjectID)).ToList();
            foreach(Pathology.GetPathologySubepisodesByPatientID_Class se in subepisodes)
            {
                PathologySubepisodeInfo subepisodeInfo = new PathologySubepisodeInfo();
                subepisodeInfo.SubepisodeID = se.Subepisodeobjectid.ToString();
                subepisodeInfo.ProtocolNo = se.ProtocolNo.ToString();
                subepisodeInfo.SubepisodeOpeningDate = se.OpeningDate == null ? "" : Convert.ToDateTime(se.OpeningDate).ToString("yyyy.MM.dd HH:mm");
                subepisodeInfo.RessectionName = se.Ressectionname;
                subepisodeInfo.DoctorName = se.Doctorname;

                List<Pathology.GetPathologiesBySubepisodeID_Class> pathologies = Pathology.GetPathologiesBySubepisodeID(new Guid(se.Subepisodeobjectid.ToString())).ToList();
                foreach(Pathology.GetPathologiesBySubepisodeID_Class p in pathologies)
                {
                    PathologyInfo pInfo = new PathologyInfo();
                    pInfo.PathologyProtocolNo = p.MatPrtNoString;
                    pInfo.ApproveDate = p.ApproveDate == null ? "" : Convert.ToDateTime(p.ApproveDate).ToString("yyyy.MM.dd HH:mm");
                    pInfo.ReportDate = p.ReportDate == null ? "" : Convert.ToDateTime(p.ReportDate).ToString("yyyy.MM.dd HH:mm");
                    pInfo.PathologyID = p.Pathologyid.ToString();
                    pInfo.CurrentStateName = p.DisplayText;
                    pInfo.CurrentStateID = p.CurrentStateDefID.ToString();
                    pInfo.PatDoctorName = p.Patdoctorname;
                    if (p.CurrentStateDefID == Pathology.States.Approvement)
                    {
                        pInfo.IsApproved = true;
                        pInfo.IsReported = false;
                    }
                    else if (p.CurrentStateDefID == Pathology.States.Report)
                    {
                        pInfo.IsApproved = true;
                        pInfo.IsReported = true;
                    }

                    subepisodeInfo.pathologyInfos.Add(pInfo);
                }
           

                result.Add(subepisodeInfo);
            }
            return result.ToArray();
        }

        public class PathologySubepisodeInfo
        {
            public string SubepisodeID { get; set; }
            public string ProtocolNo { get; set; }
            public string SubepisodeOpeningDate { get; set; }
            public string RessectionName { get; set; }
            public string DoctorName { get; set; }
            public List<PathologyInfo> pathologyInfos = new List<PathologyInfo>();
            
        }

        public class PathologyInfo
        {
            public string PathologyProtocolNo { get; set; }
            public string ApproveDate { get; set; }
            public string ReportDate { get; set; }
            public string PathologyID { get; set; }
            public string CurrentStateName { get; set; }
            public string CurrentStateID { get; set; }
            public string PatDoctorName { get; set; }
            public bool IsApproved { get; set; }
            public bool IsReported { get; set; }

        }

    }
}