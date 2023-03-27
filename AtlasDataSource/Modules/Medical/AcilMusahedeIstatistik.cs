using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
 
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using ReportClasses.Controllers.DynamicReporting;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{

    public class AcilMusahedeIstatistik   
    {
        public static AcilMusahedeIstatistikListesi  GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<AcilMusahedeIstatistikListesi>(parameters, "GetAcilMusahedeIstatistikListesi")   ;
        }

        public static AcilMusahedeIstatistikListesi GetAcilMusahedeIstatistikListesi(string parameters)
        {
            AcilMusahedeIstatistikListesi list = new AcilMusahedeIstatistikListesi();

            //if (parameters == null)
            //{
            //    AcilMusahedeParam test = new AcilMusahedeParam();
            //    test.BaslangicTarihi = DateTime.Now.AddMonths(-5);
            //    test.BitisTarihi = DateTime.Now;

            //    parameters = Newtonsoft.Json.JsonConvert.SerializeObject(test);
            //}

            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<AcilMusahedeParam>(parameters.ToString());

                BindingList<EmergencyIntervention.GetEmergenvyInterventionStatistic_Class> staticReport = EmergencyIntervention.GetEmergenvyInterventionStatistic(param.BitisTarihi, param.BaslangicTarihi);

                list.AcilMusahedeIstatistikData = new List<AcilMusahedeIstatistikData>();

                foreach (EmergencyIntervention.GetEmergenvyInterventionStatistic_Class item in staticReport)
                {
                    AcilMusahedeIstatistikData _data = new AcilMusahedeIstatistikData();

                    _data.SiraNo = item.Sirano.ToString();
                    _data.HastaAdi = item.Ad + " " + item.Soyad;
                    _data.MusahedeAlinis = item.Musahedealinis.HasValue ? item.Musahedealinis : null;
                    _data.MusahedeCikis = item.Musahedecikis.HasValue ? item.Musahedecikis : null;
                    _data.KabulNo = item.Kabulno;
                    _data.KabulTarihi = item.Kabultarihi;
                    _data.Cinsiyet = item.Cinsiyet;
                    _data.Yas = item.Dogumtarihi.HasValue ? Common.DateDiff(Common.DateIntervalEnum.Year, TTDefinitionManagement.TTObjectDefManager.ServerTime, item.Dogumtarihi.Value).ToString() : "";
                    _data.Doktor = item.Doktor;

                    list.AcilMusahedeIstatistikData.Add(_data);
                }

            }
            return list;

        }
        
    }

    [Serializable]
    public class AcilMusahedeParam
    {
        [DataMember]
        public DateTime BaslangicTarihi { get; set; }
        [DataMember]
        public DateTime BitisTarihi { get; set; }

    }

    [Serializable]
    public class AcilMusahedeIstatistikListesi
    {
        [DataMember]
        public List<AcilMusahedeIstatistikData> AcilMusahedeIstatistikData { get; set; }
    }

    [Serializable]
    public class AcilMusahedeIstatistikData
    {
        [DataMember]
        public string SiraNo { get; set; }
        [DataMember]
        public string HastaAdi { get; set; }
        [DataMember]
        public DateTime? MusahedeAlinis { get; set; }
        [DataMember]
        public DateTime? MusahedeCikis { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public DateTime? KabulTarihi { get; set; }
        [DataMember]
        public string Cinsiyet { get; set; }
        [DataMember]
        public string Yas { get; set; }
        [DataMember]
        public string Doktor { get; set; }


    }

}
