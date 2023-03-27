using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using ReportClasses.ReportUtils;
using TTInstanceManagement;

namespace AtlasDataSource.Controllers
{
    public class RadyolojiIstatistikRaporu
    {
        public static List<RadiologyStatisticReportData> GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<List<RadiologyStatisticReportData>>(parameters, "GetRadiologyStatisticReportData");
        }
        public static List<RadiologyStatisticReportData> GetRadiologyStatisticReportData(string parameters)
        {
            List<RadiologyStatisticReportData> list = new List<RadiologyStatisticReportData>();
            using (var objectContext = new TTObjectContext(false))
            {

                if (parameters != null)
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<RadiologyStatisticReportParameters>(parameters.ToString());
       
                    string _filter = " WHERE 1=1 ";

                    if (param.RequestStartDate != null && param.RequestEndDate != null)
                    {
                        _filter += " AND REQUESTDATE BETWEEN TODATE('" + Convert.ToDateTime(param.RequestStartDate).ToString("yyyy-MM-dd HH:mm:ss") + "') " +
                                    " AND TODATE('" + Convert.ToDateTime(param.RequestEndDate).ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                    if (param.ReportStartDate != null && param.ReportEndDate != null)
                    {
                        _filter += " AND ReportDate BETWEEN TODATE('" + Convert.ToDateTime(param.ReportStartDate).ToString("yyyy-MM-dd HH:mm:ss") + "') " +
                                    " AND TODATE('" + Convert.ToDateTime(param.ReportEndDate).ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    }

                    if (param.RadiologyTestDefObjectID != null)
                    {
                        _filter += " AND this.ProcedureObject.OBJECTID ='" + param.RadiologyTestDefObjectID + "'";
                    }

                    if (param.Gender != null)
                    {
                        _filter += " AND THIS.SubEpisode.Episode.Patient.Sex.OBJECTID = '" + param.Gender.ObjectID + "'";
                    }

                    if (param.Payer != null)
                    {
                        _filter += " AND THIS.SubEpisode.PatientAdmission.Payer.OBJECTID ='" + param.Payer.ObjectID + "'";
                    }
                    if (param.ResourceObjectID != null)
                    {
                        _filter += " AND THIS.MasterResource.OBJECTID ='" + param.ResourceObjectID.ObjectID + "'";

                    }

                    if (param.Equipment != null)
                    {
                        _filter += " AND THIS.Equipment.OBJECTID ='" + param.Equipment.ObjectID + "'";
                    }

                    if (param.ProcedureDoctor != null)
                    {
                        _filter += " AND THIS.ProcedureDoctor.OBJECTID ='" + param.ProcedureDoctor.ObjectID + "'";
                    }

                    List<RadiologyTest> radiologyTestList = RadiologyTest.GetByFilterExpressionStatistics(objectContext,_filter).ToList();

                    foreach (RadiologyTest radiologyTest in radiologyTestList)
                    {
                        Patient patient = radiologyTest.SubEpisode.Episode.Patient;
                        if (param.MinAge != null && param.MaxAge != null)
                        {
                            if (patient.Age >= Convert.ToInt32(param.MinAge) && patient.Age <= Convert.ToInt32(param.MaxAge))
                            {
                                RadiologyStatisticReportData data = new RadiologyStatisticReportData();
                                data.TetkikAdi = radiologyTest.ProcedureObject.Name;
                                data.TetkikKodu = radiologyTest.ProcedureObject.Code;
                                data.Kurumu = radiologyTest.SubEpisode.PatientAdmission.Payer == null ? "" : radiologyTest.SubEpisode.PatientAdmission.Payer.Name;
                                data.IstemiYapanDoktor = radiologyTest.RequestedByUser.Name;
                                data.IstemiYapanBirim = radiologyTest.FromResource.Name;
                                data.İslemiYapanDoktor = radiologyTest.ProcedureDoctor == null ? "" : radiologyTest.ProcedureDoctor.Name;
                                data.Cihaz = radiologyTest.Equipment == null ? "" : radiologyTest.Equipment.Name;
                                data.HastaninAdiSoyadi = patient.Name + " " + patient.Surname;
                                data.KabulNo = radiologyTest.SubEpisode.ProtocolNo;
                                data.IstekTarihi = Convert.ToDateTime(radiologyTest.RequestDate).ToString("dd.MM.yyyy HH:mm");
                                data.RaporTarihi = radiologyTest.ReportDate == null ? "" : Convert.ToDateTime(radiologyTest.ReportDate).ToString("dd.MM.yyyy HH:mm");
                                list.Add(data);
                            }
                        }
                        else
                        {
                            RadiologyStatisticReportData data = new RadiologyStatisticReportData();
                            data.TetkikAdi = radiologyTest.ProcedureObject.Name;
                            data.TetkikKodu = radiologyTest.ProcedureObject.Code;
                            data.Kurumu = radiologyTest.SubEpisode.PatientAdmission.Payer == null ? "" : radiologyTest.SubEpisode.PatientAdmission.Payer.Name;
                            data.IstemiYapanDoktor = radiologyTest.RequestedByUser.Name;
                            data.IstemiYapanBirim = radiologyTest.FromResource.Name;
                            data.İslemiYapanDoktor = radiologyTest.ProcedureDoctor == null ? "" : radiologyTest.ProcedureDoctor.Name;
                            data.Cihaz = radiologyTest.Equipment == null ? "" : radiologyTest.Equipment.Name;
                            data.HastaninAdiSoyadi = patient.Name + " " + patient.Surname;
                            data.KabulNo = radiologyTest.SubEpisode.ProtocolNo;
                            data.IstekTarihi = Convert.ToDateTime(radiologyTest.RequestDate).ToString("dd.MM.yyyy HH:mm");
                            data.RaporTarihi = radiologyTest.ReportDate == null ? "" : Convert.ToDateTime(radiologyTest.ReportDate).ToString("dd.MM.yyyy HH:mm");
                            list.Add(data);
                        }
                    }
                }
            }
            return list;
        }
    }

    [Serializable]
    public class RadiologyStatisticReportParameters
    {
        [DataMember]
        public DateTime RequestStartDate { get; set; }
        [DataMember]
        public DateTime RequestEndDate { get; set; }
        [DataMember]
        public DateTime ReportStartDate { get; set; }
        [DataMember]
        public DateTime ReportEndDate { get; set; }
        [DataMember]
        public RadiologyStatisticBaseObject TestType { get; set; }
        [DataMember]
        public RadiologyStatisticBaseObject RadiologyTestDefObjectID { get; set; }
        [DataMember]
        public RadiologyStatisticBaseObject Gender { get; set; }
        [DataMember]
        public RadiologyStatisticBaseObject Payer { get; set; }
        [DataMember]
        public RadiologyStatisticBaseObject ResourceObjectID { get; set; }
        [DataMember]
        public RadiologyStatisticBaseObject Equipment { get; set; }
        [DataMember]
        public RadiologyStatisticBaseObject ProcedureDoctor { get; set; }
        [DataMember]
        public bool HasAppointment { get; set; }
        [DataMember]
        public string MinAge { get; set; }
        [DataMember]
        public string MaxAge { get; set; }

       

    }

    [Serializable]
    public class RadiologyStatisticBaseObject
    {

        [DataMember]
        public string ObjectID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [Serializable]
    public class RadiologyStatisticReportData {
        [DataMember]
        public string TetkikAdi { get; set; }
        [DataMember]
        public string TetkikKodu { get; set; }
        [DataMember]
        public string Kurumu { get; set; }
        [DataMember]
        public string IstemiYapanDoktor { get; set; }
        [DataMember]
        public string IstemiYapanBirim { get; set; }
        [DataMember]
        public string İslemiYapanDoktor { get; set; }
        [DataMember]
        public string Cihaz { get; set; }
        [DataMember]
        public string HastaninAdiSoyadi { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public string IstekTarihi { get; set; }
        [DataMember]
        public string RaporTarihi { get; set; }

    }
}
