using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;
using TTObjectClasses;

namespace AtlasDataSource.Modules.Medical
{
    class DogumBilgileriRaporu
    {
        public static DogumBilgileriListeData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<DogumBilgileriListeData>(parameters, "GetDogumBilgileriListeData");
        }
        public static DogumBilgileriListeData GetDogumBilgileriListeData(string parameters)
        {
            DogumBilgileriListeData DogumBilgileriListesi = new DogumBilgileriListeData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<DogumBilgileriRaporuParam>(parameters.ToString());
                string filter = String.Empty;
                if(param.DogumYontemi != null)
                {
                    filter += " AND THIS.BIRTHTYPE.OBJECTID IN (";

                    foreach (Guid item in param.DogumYontemi)
                    {
                        filter += "'" + item.ToString() + "', ";
                    }
                 filter = filter.Remove(filter.LastIndexOf(',')) + ")";

                }
                BindingList<BabyObstetricInformation.BirthInfoReportNQL_Class> informationList = BabyObstetricInformation.BirthInfoReportNQL(param.BaslangicTarihi, param.BitisTarihi,filter);
                using (var objectContext = new TTObjectContext(false))
                {
                    foreach (BabyObstetricInformation.BirthInfoReportNQL_Class nqlData in informationList)
                    {
                        DogumBilgisiData dogumBilgisi = new DogumBilgisiData();
                        dogumBilgisi.HastaAdiSoyadi = nqlData.Mothername + " " + nqlData.Mothersurname;
                        dogumBilgisi.HastaTCKimlikNo = nqlData.Motheruniquerefno;
                        dogumBilgisi.Servis = nqlData.Masterresource;
                        dogumBilgisi.Doktor = nqlData.Doctorname;
                        dogumBilgisi.DogumYontemi = nqlData.Birthtype;
                        dogumBilgisi.DogumYaptigiTarih = nqlData.Birthdate;
                        dogumBilgisi.BebekAgirligi = nqlData.Weigth;
                        dogumBilgisi.BebekBasCevresi = nqlData.HeadCircumference;
                        dogumBilgisi.BebekCinsiyeti = nqlData.Sex;

                        DogumBilgileriListesi.DogumBilgileriList.Add(dogumBilgisi);
                    }
                }
            }
            return DogumBilgileriListesi;
        }
    }

    [Serializable]
    public class DogumBilgileriRaporuParam
    {
        [DataMember]
        public DateTime BaslangicTarihi { get; set; }
        [DataMember]
        public DateTime BitisTarihi { get; set; }
        [DataMember]
        public Guid[] DogumYontemi { get; set; }

    }
    [Serializable]
    public class DogumBilgileriListeData
    {
        [DataMember]
        public List<DogumBilgisiData> DogumBilgileriList { get; set; }
    }

    [Serializable]
    public class DogumBilgisiData
    {
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public long? HastaTCKimlikNo { get; set; }
        [DataMember]
        public string Servis { get; set; }
        [DataMember]
        public string Doktor { get; set; }
        [DataMember]
        public DateTime? DogumYaptigiTarih { get; set; }
        [DataMember]
        public string DogumYontemi { get; set; }
        [DataMember]
        public string BebekCinsiyeti { get; set; } //?
        [DataMember]
        public int? BebekBasCevresi { get; set; }
        [DataMember]
        public int? BebekAgirligi { get; set; }

    }
}
