using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportClasses.Controllers.ReportModels;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using ReportClasses.ReportUtils;
using static TTObjectClasses.Surgery;

namespace AtlasDataSource.Modules.Medical.Ameliyathane_Rapor
{
    public class AmeliyatRapor
    {
        public static AmeliyatRaporData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<AmeliyatRaporData>(parameters, "GetAmeliyatRaporData");
        }

        public static AmeliyatRaporData GetAmeliyatRaporData(string parameters)
        {
            AmeliyatRaporData ameliyatRaporData = new AmeliyatRaporData();
            if (parameters == null)
            {
                AmeliyatRaporParam aa = new AmeliyatRaporParam();
                aa.ObjectID = new Guid();

                parameters = Newtonsoft.Json.JsonConvert.SerializeObject(aa);
            }

            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false)) //RTF alanların texti nqlde alınamadığı için eklendi.
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<AmeliyatRaporParam>(parameters.ToString());


                    BindingList<Surgery.GetSurgeryInfoByID_Class> ameliyat = Surgery.GetSurgeryInfoByID(param.ObjectID.ToString());
                    if (ameliyat.Count > 0)
                    {
                        Surgery.GetSurgeryInfoByID_Class item = ameliyat[0];

                        ameliyatRaporData.ObjectID = item.ObjectID.Value;
                        ameliyatRaporData.Ameliyathane = item.Name;
                        ameliyatRaporData.Oda = item.Room;
                        ameliyatRaporData.Masa = item.Masa;
                        ameliyatRaporData.HastaAdi = item.Patientname + ' ' + item.Surname;
                        ameliyatRaporData.AmeliyatBaslamaTarihi = item.SurgeryStartTime.HasValue ? item.SurgeryStartTime : null;
                        ameliyatRaporData.AmeliyatBitisTarihi = item.SurgeryEndTime.HasValue ? item.SurgeryEndTime : null;
                        ameliyatRaporData.AmeliyatPlanTarihi = item.PlannedSurgeryDate.HasValue ? item.PlannedSurgeryDate : null;
                        ameliyatRaporData.KimlikNumarasi = item.UniqueRefNo == null ? "" : item.UniqueRefNo.ToString();
                        ameliyatRaporData.KabulNumarası = item.ProtocolNo;

                        Surgery surgery = objectContext.GetObject<Surgery>(param.ObjectID);
                        if (surgery.SurgeryReport != null)
                            ameliyatRaporData.AmeliyatNotu = TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(surgery.SurgeryReport.ToString());
                        else
                            ameliyatRaporData.AmeliyatNotu = "";

                        BindingList<SurgeryProcedure.GetSurgeryProceduresBySurgery_Class> surgeryProcedures = SurgeryProcedure.GetSurgeryProceduresBySurgery(param.ObjectID.ToString());

                        ameliyatRaporData.ameliyatIslemleri = new List<AmeliyatIslemleri>();

                        foreach (SurgeryProcedure.GetSurgeryProceduresBySurgery_Class procedure in surgeryProcedures)
                        {
                            AmeliyatIslemleri ameliyatIslemleri = new AmeliyatIslemleri();

                            ameliyatIslemleri.ObjectID = procedure.ObjectID.Value;
                            ameliyatIslemleri.IslemAdi = procedure.Name;
                            ameliyatIslemleri.IslemKodu = procedure.Code;
                            ameliyatIslemleri.KomplikasyonDurumu = (procedure.IsComplicationSurgery.HasValue && procedure.IsComplicationSurgery.Value ) ? "Komplikasyon Var" : "Komplikasyon Yok";
                            ameliyatIslemleri.Komplikasyon = procedure.ComplicationDescription;

                            ameliyatRaporData.ameliyatIslemleri.Add(ameliyatIslemleri);

                        }

                    }
                }

            }
            return ameliyatRaporData;
        }
    }

    [Serializable]
    public class AmeliyatRaporParam
    {
        [DataMember]
        public Guid ObjectID { get; set; }
    }

    [Serializable]
    public class AmeliyatRaporData
    {
        [DataMember]
        public Guid ObjectID { get; set; }
        [DataMember]
        public string Ameliyathane { get; set; }
        [DataMember]
        public string Oda { get; set; }
        [DataMember]
        public string Masa { get; set; }
        [DataMember]
        public DateTime? AmeliyatBaslamaTarihi { get; set; }
        [DataMember]
        public DateTime? AmeliyatBitisTarihi { get; set; }
        [DataMember]
        public DateTime? AmeliyatPlanTarihi { get; set; }
        [DataMember]
        public string AmeliyatNotu { get; set; }
        [DataMember]
        public string KimlikNumarasi { get; set; }
        [DataMember]
        public string HastaAdi { get; set; }
        [DataMember]
        public string KabulNumarası { get; set; }
        [DataMember]
        public List<AmeliyatIslemleri> ameliyatIslemleri { get; set; }

    }

    [Serializable]
    public class AmeliyatIslemleri
    {
        [DataMember]
        public Guid ObjectID { get; set; }
        [DataMember]
        public string IslemAdi { get; set; }
        [DataMember]
        public string IslemKodu { get; set; }
        [DataMember]
        public string Komplikasyon { get; set; }
        [DataMember]
        public string KomplikasyonDurumu { get; set; }

    }


}
