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
    public class XXXXXXSevkRaporu
    {
        public static XXXXXXSevkRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<XXXXXXSevkRaporuData>(parameters, "GetHastaSevkRaporData");
        }

        public static XXXXXXSevkRaporuData GetHastaSevkRaporData(string parameters)
        {
            XXXXXXSevkRaporuData returnData = new XXXXXXSevkRaporuData();
            if (parameters == null)
            {
                XXXXXXSevkRaporuParam aa = new XXXXXXSevkRaporuParam();
                aa.ObjectID = new Guid();
                parameters = Newtonsoft.Json.JsonConvert.SerializeObject(aa);
            }

            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false)) //RTF alanların texti nqlde alınamadığı için eklendi.
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<XXXXXXSevkRaporuParam>(parameters.ToString());


                    BindingList<DispatchToOtherHospital.GetDispatchInfoForNewReport_Class> yatanHastaListesis = DispatchToOtherHospital.GetDispatchInfoForNewReport(param.ObjectID);
                    if (yatanHastaListesis.Count > 0)
                    {
                        returnData.SevkTarihi = yatanHastaListesis[0].Sevktarihi;
                        returnData.SevkYapanBirim = yatanHastaListesis[0].Sevkyapanbirim;
                        returnData.HastaAdi = yatanHastaListesis[0].Name + " " + yatanHastaListesis[0].Surname;
                        returnData.DogumTarihi = yatanHastaListesis[0].BirthDate;
                        returnData.DogumYeri = yatanHastaListesis[0].BirthPlace;
                        returnData.DosyaNo = yatanHastaListesis[0].Dosyano.ToString();
                        returnData.KimlikNo = yatanHastaListesis[0].Refno != null ? yatanHastaListesis[0].Refno.ToString() : "";
                        returnData.KabulNo = yatanHastaListesis[0].ProtocolNo;
                        returnData.sevkAdi = yatanHastaListesis[0].Sevkadi;
                        returnData.SevBrans = yatanHastaListesis[0].Dispatchedspecialityname;
                        returnData.GidecegiSehir = yatanHastaListesis[0].Gidecegisehir;
                        returnData.SevkVasitasi = yatanHastaListesis[0].Sevkvasitasi;
                        returnData.RefakatciGerekce = yatanHastaListesis[0].Refakatcigerekcesi;
                        returnData.SevkGerekce = yatanHastaListesis[0].Sevkgerekcesi;
                        returnData.SevkEdilenXXXXXX = yatanHastaListesis[0].XXXXXX;

                        returnData.MedulaSevkTakipNo = yatanHastaListesis[0].Takipno;

                        //foreach (var item in yatanHastaListesis)
                        //{
                            returnData.SevkEdenHekim = yatanHastaListesis[0].Doktor;
                        //}

                        returnData.XXXXXXAd = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");

                        DispatchToOtherHospital dispatch = objectContext.GetObject<DispatchToOtherHospital>(param.ObjectID);

                        foreach (var item in dispatch.Diagnosis)
                        {
                            returnData.Tani += item.DiagnoseCode + " - " + item.Diagnose.Name + "\n";
                        }

                    }
                }

            }
            return returnData;
        }
    }

    [Serializable]
    public class XXXXXXSevkRaporuParam
    {
        [DataMember]
        public Guid ObjectID { get; set; }


    }

    [Serializable]
    public class XXXXXXSevkRaporuData
    {
        [DataMember]
        public Guid ObjectID { get; set; }
        [DataMember]
        public string XXXXXXAd { get; set; }
        [DataMember]
        public DateTime? SevkTarihi { get; set; }
        [DataMember]
        public string SevkYapanBirim { get; set; }
        [DataMember]
        public string HastaAdi { get; set; }
        [DataMember]
        public DateTime? DogumTarihi { get; set; }
        [DataMember]
        public string DogumYeri { get; set; }
        [DataMember]
        public string DosyaNo { get; set; }
        [DataMember]
        public string KimlikNo { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public string Tani { get; set; }
        [DataMember]
        public string SevkGerekce { get; set; }
        [DataMember]
        public string SevBrans { get; set; }
        [DataMember]
        public string GidecegiSehir { get; set; }
        [DataMember]
        public string SevkVasitasi { get; set; }
        [DataMember]
        public string RefakatciGerekce { get; set; }
        [DataMember]
        public string SevkEdenHekim { get; set; }
        [DataMember]
        public string SevkEdilenXXXXXX { get; set; }
        [DataMember]
        public string MedulaSevkTakipNo { get; set; }
        [DataMember]
        public string sevkAdi { get; set; }

    }

}
