using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraPrinting.Native.WebClientUIControl;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Native.ClientControls;
using Infrastructure.Helpers;
using ReportClasses.Controllers.DynamicReporting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TTInstanceManagement;
using TTObjectClasses;

namespace ReportClasses.Controllers
{
    public class ReportResolver
    {
        public static Dictionary<string, object> GetDataSources(ReportParameters parameters)
        {

            var type = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies().Where(x => x.Name.Contains("AtlasDataSource")).Select(System.Reflection.Assembly.Load).SelectMany(x => x.DefinedTypes).Where(p => p.Name == parameters.ReportClassName).FirstOrDefault();

            var dataSources = new Dictionary<string, object>();
            ObjectDataSource dataSource = new ObjectDataSource();
            dataSource.DataSource = type;
            dataSource.DataMember = "GetReportData";
            dataSource.Parameters.Add(new Parameter("parameters", typeof(string), Newtonsoft.Json.JsonConvert.SerializeObject(parameters)));
            dataSources.Add(type.Name + "Data", dataSource);
            return dataSources;
        }

        public static byte[] GetReportOutput(string code, ReportParameters reportParameters)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var dynamicReport = _context.QueryObjects<DynamicReport>("Code = '" + code + "' AND Enabled = 1").FirstOrDefault();

                var revision = _context.QueryObjects<DynamicReportRevision>("DynamicReport = '" + dynamicReport.ObjectID + "' and Enabled = 1 and IsMain = 1").FirstOrDefault();

                var xtraReport = GetXtraReport(revision.ObjectID.ToString(), reportParameters);

                byte[] result = null;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    xtraReport.ExportToPdf(memoryStream);

                    result = memoryStream.ToByteArray();

                    //using (FileStream file = new FileStream("test2.pdf", FileMode.Create, System.IO.FileAccess.Write))
                    //{
                    //    memoryStream.WriteTo(file);
                    //}
                }
                return result;
            }

        }

        public static XtraReport GetXtraReport(string reportGuid, ReportParameters parameters)
        {
            string json = string.Empty;
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var jsonData = _context.QueryObjects<DynamicReportRevision>("ObjectID = '" + reportGuid + "'").Select(x => x.ReportJSONContent).FirstOrDefault();

                if (jsonData != null)
                {
                    json = jsonData.ToString();
                }
                else
                {
                    return new XtraReport();
                }
            }


            XtraReport report;
            var jsonByte = JsonConverter.JsonToXml(json, false);
            using (MemoryStream memoryStream = new MemoryStream(jsonByte))
            {
                XtraReport streamReport = XtraReport.FromStream(memoryStream, false);
                memoryStream.Position = (long)0;
                ReportLayoutJsonSerializer.LoadReportLayoutFromXml(streamReport, memoryStream);
                report = streamReport;

                var oldDataSource = report.DataSource as ObjectDataSource;

                if (oldDataSource.Parameters.Count > 0)
                {
                    oldDataSource.Parameters[0].Value = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
                }

                report.DataSource = oldDataSource;

            }


            return report;
            //return new XtraReport();
        }
    }
}
