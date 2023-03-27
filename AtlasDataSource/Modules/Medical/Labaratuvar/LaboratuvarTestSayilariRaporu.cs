using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;
using System.Collections.Generic;
using System.Data.Common;
using TTConnectionManager;
using System.Data;

namespace AtlasDataSource.Controllers
{
    public class LaboratuvarTestSayilariRaporu
    {
        public static LaboratuvarTestSayilariRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<LaboratuvarTestSayilariRaporuData>(parameters, "GetLaboratuvarTestSayilariRaporuData");
        }
        public static LaboratuvarTestSayilariRaporuData GetLaboratuvarTestSayilariRaporuData(string parameters)
        {
            LaboratuvarTestSayilariRaporuData data = new LaboratuvarTestSayilariRaporuData();
            if(parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<LaboratuvarTestSayilariParameters>(parameters.ToString());
                data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                data.RaporBasilmaTarihi = DateTime.Now;
                data.BaslangicTarihi = param.ReportStartDate;
                data.BitisTarihi = param.ReportEndDate;
                data.HastaListesi = new List<YatanHastaTestInfo>();

                string procedureTreeObjectIDs = "";
                foreach(SelectedProcedureTreeObject selectedProcedure in param.SelectedProcedureTree)
                {
                    if(procedureTreeObjectIDs =="")
                        procedureTreeObjectIDs = "'" + selectedProcedure.ObjectID +"'";
                    else
                        procedureTreeObjectIDs += ",'" + selectedProcedure.ObjectID + "'";
                }


                DbConnection dbConnection = ConnectionManager.CreateConnection();

                dbConnection.Open();
                try
                {
                    string sql = "select l.creationdate as IstemTarihi, se.protocolno as KabulNo, pat.uniquerefno as HastaTCNo, pat.name || ' ' || pat.surname as HastaAdı, p.code || '-' || p.name as TetkikAdı,  res.name as IsteyenBirim, spec.name as IsteyenBrans "+
                                " from laboratoryprocedure_v l, labtestdef_v p, subepisode_v se, episode_v e, patient_v pat, resource_v res, RESOURCESPECIALITYGRID_v resspec, SPECIALITYDEFINITION_v spec "+
                                " where l.creationdate between to_date('"+Convert.ToDateTime(param.ReportStartDate).ToString("dd.MM.yyyy 00:00:00") +"', 'dd.MM.yyyy hh24:mi:ss') and to_date('"+Convert.ToDateTime(param.ReportEndDate).ToString("dd.MM.yyyy 23:59:59")+"','dd.MM.yyyy hh24.mi:ss') " +
                                " and l.currentstatedefid = 'a52a30e0-6ac7-4224-aa58-a994397c22f6' "+
                                " and l.procedureobject = p.objectid "+
                                " and p.proceduretree in ("+procedureTreeObjectIDs+")" +
                                " and l.subepisode = se.objectid "+
                                " and se.episode = e.objectid "+
                                " and e.patient = pat.objectid "+
                                " and l.fromresource = res.objectid "+
                                " and resspec.\"RESOURCE\" = res.objectid "+
                                " and resspec.speciality = spec.objectid "+
                                " order by 1";


                    DbCommand cmd = ConnectionManager.CreateCommand(sql, dbConnection);
                    DbDataAdapter adap = ConnectionManager.CreateDataAdapter(cmd);
                    DataSet ds = new DataSet("DataSet");
                    adap.Fill(ds);
                    if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            YatanHastaTestInfo info = new YatanHastaTestInfo();
                            info.IstemTarihi = Convert.ToDateTime(row.ItemArray[0]).ToString("dd/MM/yyyy");
                            info.KabulNo = row.ItemArray[1].ToString();
                            info.KimlikNo = row.ItemArray[2].ToString();
                            info.HastaAdiSoyadi = row.ItemArray[3].ToString();
                            info.TetkikAdi = row.ItemArray[4].ToString();
                            info.IsteyenBirim = row.ItemArray[5].ToString();
                            info.IsteyenBrans = row.ItemArray[6].ToString();
                            data.HastaListesi.Add(info);
                        }
                    }

                }
                catch
                {

                }


            }

            return data;
        }
    }

    [Serializable]
    public class LaboratuvarTestSayilariRaporuData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }
        [DataMember]
        public DateTime RaporBasilmaTarihi { get; set; }
        [DataMember]
        public DateTime BaslangicTarihi { get; set; }
        [DataMember]
        public DateTime BitisTarihi { get; set; }
        [DataMember]
        public List<YatanHastaTestInfo> HastaListesi { get; set; }
    }

    [Serializable]
    public class LaboratuvarTestSayilariParameters
    {
        [DataMember]
        public DateTime ReportStartDate { get; set; }
        [DataMember]
        public DateTime ReportEndDate { get; set; }
        [DataMember]
        public List<SelectedProcedureTreeObject> SelectedProcedureTree { get; set; }

    }
    [Serializable]
    public class SelectedProcedureTreeObject
    {
        public string ObjectID { get; set; }
        public string Name { get; set; }
    }

    [Serializable]
    public class YatanHastaTestInfo
    {
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string KimlikNo { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public string IstemTarihi { get; set; }
        [DataMember]
        public string TetkikAdi { get; set; }
        [DataMember]
        public string IsteyenBirim { get; set; }
        [DataMember]
        public string IsteyenBrans { get; set; }
      
    }
}
