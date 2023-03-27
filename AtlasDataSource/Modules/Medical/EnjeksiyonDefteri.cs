using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;
using System.Collections.Generic;

namespace AtlasDataSource.Controllers
{
    public class EnjeksiyonDefteri
    {
        public static EnjeksiyonDefteriList GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<EnjeksiyonDefteriList>(parameters, "GetEnjeksiyonDefteriData");
        }
        public static EnjeksiyonDefteriList GetEnjeksiyonDefteriData(string parameters)
        {
            EnjeksiyonDefteriList list = new EnjeksiyonDefteriList();
            list.EnjeksiyonDefteriData = new List<EnjeksiyonDefteriData>();
            list.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");

            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<EnjeksiyonDefteriParameters>(parameters.ToString());

                    //BindingList<PatientExamination.GetPolyclinicBookByDate_Class> reportDataList = PatientExamination.GetPolyclinicBookByDate(param.BitisTarihi, param.Birim, param.BaslangicTarihi);
                    List<string> sutCodeList = new List<string>();
                    sutCodeList.Add("530140");
                    sutCodeList.Add("530150");
                    BindingList<SubActionProcedure.GetInjectionList_Class> dataList = SubActionProcedure.GetInjectionList(param.BaslangicTarihi, param.BitisTarihi, sutCodeList);
                    foreach (SubActionProcedure.GetInjectionList_Class item in dataList)
                    {
                        EnjeksiyonDefteriData data = new EnjeksiyonDefteriData();
                        data.TCKimlikNo = item.UniqueRefNo == null ? "" : item.UniqueRefNo.ToString();
                        data.AdSoyad = item.Name == null ? "" : item.Name + " " + item.Surname;
                        data.DogumTarihi = item.BirthDate;
                        data.KabulNo = item.ProtocolNo;
                        data.GelisSebebi = item.Comingreason == null ? "" : item.Comingreason.ToString();
                        data.SosyalGuvenlikKurumu = item.Payername == null ? "" : item.Payername.ToString();
                        data.Birimi = item.Resource == null ? "" : item.Resource.ToString();
                        data.KabulTarihi = item.OpeningDate;
                        data.Doktor = item.ProcedureDoctor == null ? "" : item.ProcedureDoctor.ToString();
                        data.Hemsire = "";
                        data.Telefon = item.Phonenumber == null ? "" : item.Phonenumber.ToString();

                        var diagnosisList = DiagnosisGrid.GetBySubEpisode(objectContext, item.Subepisodeobjectid.ToString());
                        data.Tanilar = new List<EnjeksiyonDiagnosisData>();
                        foreach (DiagnosisGrid d in diagnosisList)
                        {
                            EnjeksiyonDiagnosisData tani = new EnjeksiyonDiagnosisData();
                            tani.TaniKodu = d.Diagnose.Code;
                            tani.TaniAdi = d.Diagnose.Name;
                            data.Tanilar.Add(tani);
                        }

                        data.VerilenIlaclar = new List<EnjeksiyonMedicineData>();
                        string injectionSqlTreatmentMaterial = string.Empty;
                        injectionSqlTreatmentMaterial = " AND MATERIAL.OBJECTDEFID='65a2337c-bc3c-4c6b-9575-ad47fa7a9a89'  AND EPISODEACTION.SUBEPISODE= '" + item.Subepisodeobjectid.ToString() + "'";
                        BindingList<BaseTreatmentMaterial.GetTreatmentMatByParameter_Class> baseTreatmentList = BaseTreatmentMaterial.GetTreatmentMatByParameter(injectionSqlTreatmentMaterial);
                        foreach (BaseTreatmentMaterial.GetTreatmentMatByParameter_Class medicine in baseTreatmentList)
                        {
                            EnjeksiyonMedicineData mData = new EnjeksiyonMedicineData();
                            mData.Ilac = medicine.Drugname == null ? "" : medicine.Drugname.ToString();
                            data.VerilenIlaclar.Add(mData);
                        }

                        list.EnjeksiyonDefteriData.Add(data);

                    }

                }

            }
            return list;
        }
    }

    [Serializable]
    public class EnjeksiyonDefteriParameters
    {
        [DataMember]
        public DateTime BaslangicTarihi { get; set; }
        [DataMember]
        public DateTime BitisTarihi { get; set; }

    }
    [Serializable]
    public class EnjeksiyonDefteriList
    {
        [DataMember]
        public string HastahaneAdi { get; set; }
        [DataMember]
        public List<EnjeksiyonDefteriData> EnjeksiyonDefteriData { get; set; }
    }

    [Serializable]
    public class EnjeksiyonDefteriData
    {
        [DataMember]
        public string TCKimlikNo { get; set; }
        [DataMember]
        public string AdSoyad { get; set; }
        [DataMember]
        public DateTime? DogumTarihi { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public string GelisSebebi { get; set; }
        [DataMember]
        public string Birimi { get; set; }
        [DataMember]
        public string SosyalGuvenlikKurumu { get; set; }
        [DataMember]
        public DateTime? KabulTarihi { get; set; }
        [DataMember]
        public string Telefon { get; set; }
        [DataMember]
        public string Doktor { get; set; }
        [DataMember]
        public string Hemsire { get; set; }
        //Tanılar
        [DataMember]
        public List<EnjeksiyonDiagnosisData> Tanilar { get; set; }
    
        [DataMember]
        public List<EnjeksiyonMedicineData> VerilenIlaclar { get; set; }

        [DataMember]
        public List<EnjeksiyonVaccineData> Asilar { get; set; }

    }

    [Serializable]
    public class EnjeksiyonDiagnosisData
    {
        [DataMember]
        public string TaniKodu { get; set; }
        [DataMember]
        public string TaniAdi { get; set; }
    }
    [Serializable]
    public class EnjeksiyonMedicineData
    {
        [DataMember]
        public string Ilac { get; set; }
    }
    [Serializable]
    public class EnjeksiyonVaccineData
    {
        [DataMember]
        public string AsiAdi { get; set; }
    }
}
