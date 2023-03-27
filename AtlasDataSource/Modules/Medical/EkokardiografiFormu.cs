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
    public class EkokardiografiFormu
    {
        public static EkokardiografiFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<EkokardiografiFormuData>(parameters, "GetEkokardiografiFormuData");
        }
        public static EkokardiografiFormuData GetEkokardiografiFormuData(string parameters)
        {
            EkokardiografiFormuData data = new EkokardiografiFormuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<EkokardiografiFormuParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    EkokardiografiFormObject ekokardiografi = objectContext.GetObject<EkokardiografiFormObject>(param.ObjectID);
                    Episode episode = ekokardiografi.Manipulation.Episode;
                    Patient patient = episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.HastaAdiSoyadi = patient.Name + " " + patient.Surname;
                    data.HastaTC = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                    data.KabulNo = ekokardiografi.Manipulation.SubEpisode.ProtocolNo;
                    data.Boy = ekokardiografi.Boy == null ? "" : ekokardiografi.Boy;
                    data.Kilo = ekokardiografi.Kilo == null ? "" : ekokardiografi.Kilo;
                    data.KalpHizi = ekokardiografi.KalpHizi == null ? "" : ekokardiografi.KalpHizi;
                    data.Ritim = ekokardiografi.Ritim == null ? "" : ekokardiografi.Ritim;
                    data.LVSegmentHareketleri = ekokardiografi.LVSegmentHareket == null ? "" : ekokardiografi.LVSegmentHareket.ToString();
                    data.PerikartOzellikleri = ekokardiografi.PerikartOzellik == null ? "" : ekokardiografi.PerikartOzellik.ToString();
                    data.EkokardiografiSonucu = ekokardiografi.EkoSonuc == null ? "" : ekokardiografi.EkoSonuc.ToString();
                    data.MitralBulgular = new List<BulgularData>();
                    foreach(MitralKapakBulgu mBulgu in ekokardiografi.MitralKapakBulgular)
                    {
                        BulgularData bulgu = new BulgularData();
                        bulgu.TestAdi = mBulgu.MitralKapakTest.ToString();
                        bulgu.TestBulgusu = mBulgu.MitralKapakTestBulgu == null ? "" : mBulgu.MitralKapakTestBulgu.ToString();
                        data.MitralBulgular.Add(bulgu);
                    }

                    data.EkokardiografiBulgular = new List<BulgularData>();
                    foreach (EkokardiografiBulgu eBulgu in ekokardiografi.EkokardiografiBulgular)
                    {
                        BulgularData bulgu = new BulgularData();
                        bulgu.TestAdi = eBulgu.EkokardiografiTest.ToString();
                        bulgu.TestBulgusu = eBulgu.EkokardiografiTestBulgu == null ? "" : eBulgu.EkokardiografiTestBulgu.ToString();
                        data.EkokardiografiBulgular.Add(bulgu);
                    }

                    data.AortKapakBulgular = new List<BulgularData>();
                    foreach (AortKapakBulgu aBulgu in ekokardiografi.AortKapakBulgular)
                    {
                        BulgularData bulgu = new BulgularData();
                        bulgu.TestAdi = aBulgu.AortKapakTest.ToString();
                        bulgu.TestBulgusu = aBulgu.AortKapakTestBulgu == null ? "" : aBulgu.AortKapakTestBulgu.ToString();
                        data.AortKapakBulgular.Add(bulgu);
                    }

                    data.TrikuspitKapakBulgular = new List<BulgularData>();
                    foreach (TrikuspitKapakBulgu tBulgu in ekokardiografi.TrikuspitKapakBulgular)
                    {
                        BulgularData bulgu = new BulgularData();
                        bulgu.TestAdi = tBulgu.TrikuspitKapakTest.ToString();
                        bulgu.TestBulgusu = tBulgu.TrikuspitKapakTestBulgu == null ? "" : tBulgu.TrikuspitKapakTestBulgu.ToString();
                        data.TrikuspitKapakBulgular.Add(bulgu);
                    }

                    data.PulmonerBulgular = new List<BulgularData>();
                    foreach (PulmonerKapakBulgu pBulgu in ekokardiografi.PulmonerKapakBulgular)
                    {
                        BulgularData bulgu = new BulgularData();
                        bulgu.TestAdi = pBulgu.PulmonerKapakTest.ToString();
                        bulgu.TestBulgusu = pBulgu.PulmonerKapakTestBulgu == null ? "" : pBulgu.PulmonerKapakTestBulgu.ToString();
                        data.PulmonerBulgular.Add(bulgu);
                    }

                }
            }
            return data;
        }
    }

    [Serializable]
    public class EkokardiografiFormuParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //EKOKARDIOGRAFIFORMOBJECT'in ObjectIDsi

    }
    [Serializable]
    public class EkokardiografiFormuData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string HastaTC { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public string Boy { get; set; }
        [DataMember]
        public string Kilo { get; set; }
        [DataMember]
        public string KalpHizi { get; set; }
        [DataMember]
        public string Ritim { get; set; }
        [DataMember]
        public string LVSegmentHareketleri { get; set; }
        [DataMember]
        public string PerikartOzellikleri { get; set; }
        [DataMember]
        public string EkokardiografiSonucu { get; set; }
        //Tanılar
        [DataMember]
        public List<BulgularData> MitralBulgular { get; set; }
        [DataMember]
        public List<BulgularData> EkokardiografiBulgular { get; set; }
        [DataMember]
        public List<BulgularData> AortKapakBulgular { get; set; }
        [DataMember]
        public List<BulgularData> TrikuspitKapakBulgular { get; set; }
        [DataMember]
        public List<BulgularData> PulmonerBulgular { get; set; }


    }
    [Serializable]
    public class BulgularData
    {
        [DataMember]
        public string TestAdi { get; set; }
        [DataMember]
        public string TestBulgusu { get; set; }
    }
}
