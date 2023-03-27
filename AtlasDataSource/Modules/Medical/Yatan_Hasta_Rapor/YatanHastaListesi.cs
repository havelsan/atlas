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

namespace AtlasDataSource.Modules.Medical.Yatan_Hasta_Rapor
{
    public class YatanHastaListesi
    {
        public static List<YatanHastaListesiData> GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<List<YatanHastaListesiData>>(parameters, "GetYatanHastaListesiData");
        }

        public static List<YatanHastaListesiData> GetYatanHastaListesiData(string parameters)
        {
            List<YatanHastaListesiData> returnData = new List<YatanHastaListesiData>();
            if (parameters == null)
            {
                YatanHastaListesiParam aa = new YatanHastaListesiParam();
                aa.AllClinics = true;
                aa.SelectedClinicList = new List<string>();
                aa.BaslangicTarihi = DateTime.Now;
                aa.BitisTarihi = DateTime.Now.AddDays(-50);

                parameters = Newtonsoft.Json.JsonConvert.SerializeObject(aa);
            }

            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false)) //RTF alanların texti nqlde alınamadığı için eklendi.
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<YatanHastaListesiParam>(parameters.ToString());
                    string filter = " AND THIS.BASEINPATIENTADMISSION.PHYSICALSTATECLINIC IN ( '1'";

                    if (param.AllClinics != true)
                    {
                        foreach (var item in param.SelectedClinicList)
                        {
                            filter += ",'" + item + "'";
                        }
                        filter += ")";
                    }
                    else
                        filter = string.Empty;

                    BindingList<InPatientTreatmentClinicApplication.GetYatanHastaListesi_Class> yatanHastaListesis = InPatientTreatmentClinicApplication.GetYatanHastaListesi(param.BaslangicTarihi, param.BitisTarihi, filter);
                    if (yatanHastaListesis.Count > 0)
                    {
                        foreach (InPatientTreatmentClinicApplication.GetYatanHastaListesi_Class item in yatanHastaListesis)
                        {
                            YatanHastaListesiData yatakListesiRaporData = new YatanHastaListesiData();

                            yatakListesiRaporData.ObjectID = item.ObjectID.Value;
                            yatakListesiRaporData.Yatak = item.Yatak;
                            yatakListesiRaporData.Oda = item.Oda;
                            yatakListesiRaporData.OdaGrup = item.Odagrubu;
                            yatakListesiRaporData.Klinik = item.Yattigiklinik;
                            yatakListesiRaporData.HastaAdi = item.Hastaadi + ' ' + item.Hastasoyadi;
                            yatakListesiRaporData.YatisTarihi = item.Klinikyatistarihi.HasValue ? item.Klinikyatistarihi : null;
                            yatakListesiRaporData.TaburcuTarihi = item.Kliniktaburcutarihi.HasValue ? item.Kliniktaburcutarihi : null;
                            yatakListesiRaporData.Durumu = item.Statu;

                            returnData.Add(yatakListesiRaporData);
                        }

                    }
                }

            }
            return returnData;
        }
    }

    [Serializable]
    public class YatanHastaListesiParam
    {
        [DataMember]
        public bool AllClinics { get; set; }
        [DataMember]
        public List<string> SelectedClinicList { get; set; }
        [DataMember]
        public DateTime BaslangicTarihi { get; set; }
        [DataMember]
        public DateTime BitisTarihi { get; set; }

    }

    [Serializable]
    public class YatanHastaListesiData
    {
        [DataMember]
        public Guid ObjectID { get; set; }
        [DataMember]
        public string Yatak { get; set; }
        [DataMember]
        public string Oda { get; set; }
        [DataMember]
        public string OdaGrup { get; set; }
        [DataMember]
        public string Klinik { get; set; }
        //public Guid KlinikID { get; set; }
        [DataMember]
        public string HastaAdi { get; set; }
        [DataMember]
        public DateTime? YatisTarihi { get; set; }
        [DataMember]
        public DateTime? TaburcuTarihi { get; set; }
        [DataMember]
        public string Durumu { get; set; }
        //public int Dolu { get; set; }
        //public int Boş { get; set; }

    }

}
