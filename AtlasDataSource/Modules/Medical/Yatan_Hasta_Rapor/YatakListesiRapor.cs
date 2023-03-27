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
    public class YatakListesiRapor 
    {
        public static List<YatakListesiRaporData> GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<List<YatakListesiRaporData>>(parameters, "GetYatakListesiRaporData");
        }

        public static List<YatakListesiRaporData> GetYatakListesiRaporData(string parameters)
        {
            List<YatakListesiRaporData> returnData = new List<YatakListesiRaporData>();

            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false)) //RTF alanların texti nqlde alınamadığı için eklendi.
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<YatakListesiRaporParam>(parameters.ToString());
                    string filter = " AND Room.RoomGroup.Ward.OBJECTID IN ( '1'";

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

                    BindingList<ResBed.GetAllBedUsingInfo_Class> getAllBedUsingInfo_ClassList = ResBed.GetAllBedUsingInfo(filter);
                    if (getAllBedUsingInfo_ClassList.Count > 0)
                    {
                        foreach (ResBed.GetAllBedUsingInfo_Class item in getAllBedUsingInfo_ClassList)
                        {
                            YatakListesiRaporData yatakListesiRaporData = new YatakListesiRaporData();

                            yatakListesiRaporData.ObjectID = item.ObjectID.Value;
                            yatakListesiRaporData.Yatak = item.Name;
                            yatakListesiRaporData.Oda = item.Room;
                            yatakListesiRaporData.OdaGrup = item.Roomgroup;
                            yatakListesiRaporData.Klinik = item.Clinic;
                            yatakListesiRaporData.KlinikID = item.Clinic != null ? item.Clinicid.Value : Guid.Empty;
                            yatakListesiRaporData.YatakIslemi = item.Islem;
                            yatakListesiRaporData.Dolu = item.Procedureobjectid == null ? false : true;
                            yatakListesiRaporData.SolunumIzolasyonu = item.Solunumizolasyon == null ? false : true;
                            yatakListesiRaporData.DamlacikIzolasyonu = item.Damlacikizolasyon == null ? false : true;
                            yatakListesiRaporData.TemasIzolasyonu = item.Temasizolasyon == null ? false : true;
                            yatakListesiRaporData.SikiTemasIzolasyonu = item.Sikitemasizolasyon == null ? false : true;

                            returnData.Add(yatakListesiRaporData);
                        }

                    }
                }

            }
            return returnData;
        }
    }

    [Serializable]
    public class YatakListesiRaporParam
    {
        [DataMember]
        public bool AllClinics { get; set; }
        [DataMember]
        public List<string> SelectedClinicList { get; set; }

    }

    //[Serializable]
    //public class AcilMusahedeIstatistikListesi
    //{
    //    [DataMember]
    //    public  List<AcilMusahedeIstatistikInfo> AcilMusahedeIstatistikInfo { get; set; }

    //    [DataMember]
    //    public string Deneme { get; set; }
    //}

    [Serializable]
    public class YatakListesiRaporData
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
        [DataMember]
        public Guid KlinikID { get; set; }
        [DataMember]
        public string YatakIslemi { get; set; }
        [DataMember]
        public bool Dolu{ get; set; }
        [DataMember]
        public bool SolunumIzolasyonu { get; set; }
        [DataMember]
        public bool DamlacikIzolasyonu { get; set; }
        [DataMember]
        public bool TemasIzolasyonu { get; set; }
        [DataMember]
        public bool SikiTemasIzolasyonu { get; set; }


    }

}
