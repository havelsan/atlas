using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;
using System.Collections.Generic;
using DevExpress.XtraRichEdit.API.Native.Implementation;

namespace AtlasDataSource.Controllers
{
    public class AsiTakvimiRaporu
    {
        public static AsiTakvimiData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<AsiTakvimiData>(parameters, "GetAsiTakvimiData");
        }
        public static AsiTakvimiData GetAsiTakvimiData(string parameters)
        {
            AsiTakvimiData data = new AsiTakvimiData();
            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<AsiTakvimiParameters>(parameters.ToString());
                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.RaporTarihi = DateTime.Now;
                    Patient patient = objectContext.GetObject<Patient>(new Guid(param.PatientID));
                    data.HastaAdiSoyadi = patient.Name + " " + patient.Surname;
                    data.DogumTarihi = patient.BirthDate;
                    data.Cinsiyet = patient.Sex.ADI;
                    data.HastaTC = patient.UniqueRefNo.ToString();
                    data.AnneAdi = patient.MotherName == null ? "" : patient.MotherName.ToString();
                    data.BabaAdi = patient.FatherName == null ? "" : patient.FatherName.ToString();
                    data.CepTelefonu = patient.MobilePhone == null ? "" : patient.MobilePhone.ToString();
                    data.Adres = patient.PatientAddress.HomeAddress;
                    data.AsiListesi = new List<AsiInfo>();
                    foreach( VaccineDetails vaccine in patient.VaccineDetails)
                    {
                        AsiInfo info = new AsiInfo();
                        info.AsiAdi = vaccine.SKRSAsiKodu.ADI;
                        info.PeriyotAdi = vaccine.PeriodName;
                        info.PeriyotSuresi = vaccine.PeriodRange.ToString();
                        info.Birim = vaccine.PeriodUnit == null ? "" : Common.GetDisplayTextOfEnumValue("PeriodUnitTypeEnum", Convert.ToInt32(vaccine.PeriodUnit.Value));
                        info.RandevuTarihi = vaccine.ApplicationDate;
                        data.AsiListesi.Add(info);
                    }

                }
            }
            return data;
        }
    }

    [Serializable]
    public class AsiTakvimiParameters
    {
        [DataMember]
        public string PatientID { get; set; }

    }

    [Serializable]
    public class AsiTakvimiData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }
        [DataMember]
        public DateTime RaporTarihi { get; set; }
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string HastaTC { get; set; }
        [DataMember]
        public DateTime? DogumTarihi { get; set; }
        [DataMember]
        public string AnneAdi { get; set; }
        [DataMember]
        public string BabaAdi { get; set; }
        [DataMember]
        public string Cinsiyet { get; set; }
        [DataMember]
        public string CepTelefonu { get; set; }
        [DataMember]
        public string Adres { get; set; }

        [DataMember]
        public List<AsiInfo> AsiListesi { get; set; }
    }

    [Serializable]
    public class AsiInfo
    {
        [DataMember]
        public string AsiAdi { get; set; }
        [DataMember]
        public string PeriyotAdi { get; set; }
        [DataMember]
        public string PeriyotSuresi { get; set; }
        [DataMember]
        public string Birim { get; set; }
        [DataMember]
        public DateTime? RandevuTarihi { get; set; }
    }
}
