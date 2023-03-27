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
    public class YatanHastaIstatistikRaporu
    {
        public static YatanHastaIstatistikRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<YatanHastaIstatistikRaporuData>(parameters, "GetYatanHastaIstatistikRaporuData");
        }
        public static YatanHastaIstatistikRaporuData GetYatanHastaIstatistikRaporuData(string parameters)
        {
            YatanHastaIstatistikRaporuData data = new YatanHastaIstatistikRaporuData();
            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<YatanHastaIstatisticParameters>(parameters.ToString());
                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.RaporTarihi = DateTime.Now;
                    //data.SecilenTarih = param.SelectedDate;
                    data.HastaListesi = new List<YatanHastaInfo>();

                    List<Guid> clinicList = new List<Guid>();
                    List<Guid> diagnosisParamList = new List<Guid>();
                    List<Guid> procedureList = new List<Guid>();
                    foreach (InpatientClinicModel clinic in param.SelectedClinics)
                    {
                        clinicList.Add(clinic.ObjectID);
                    }

                    foreach (InpatientDiagnosisAndProcedureModel diagnosis in param.DiagnosisList)
                    {
                        diagnosisParamList.Add(diagnosis.ObjectID);
                    }

                    foreach (InpatientDiagnosisAndProcedureModel procedure in param.ProcedureList)
                    {
                        procedureList.Add(procedure.ObjectID);
                    }

                    string injectionSql = "";
                    if (param.InpatientStartDate != null && param.InpatientEndDate != null)
                    {
                        injectionSql += " AND THIS.InPatientTreatmentClinicApp.ClinicInpatientDate BETWEEN " + GetDateAsString(param.InpatientStartDate) + " AND " + GetDateAsString(param.InpatientStartDate);
                    }

                    if (param.DischargeStartDate != null && param.DischargeEndDate != null)
                    {
                        injectionSql += " AND THIS.InPatientTreatmentClinicApp.ClinicDischargeDate BETWEEN " + GetDateAsString(param.DischargeStartDate) + " AND " + GetDateAsString(param.DischargeEndDate);

                    }


                    BindingList<InPatientPhysicianApplication.GetInpatientsByClinic_Class> inpatientList = InPatientPhysicianApplication.GetInpatientsByClinic(clinicList, diagnosisParamList, procedureList, injectionSql);
                    foreach (var inpatient in inpatientList)
                    {
                        YatanHastaInfo i = new YatanHastaInfo();
                        i.HastaAdiSoyadi = inpatient.Patientname + " " + inpatient.Patientsurname;
                        i.KimlikNo = inpatient.UniqueRefNo == null ? "" : inpatient.UniqueRefNo.ToString();
                        i.YatisTarihi = inpatient.ClinicInpatientDate == null ? "" : Convert.ToDateTime(inpatient.ClinicInpatientDate).ToString("dd.MM.yyyy HH:mm");
                        i.CikisTarihi = inpatient.ClinicDischargeDate == null ? "" : Convert.ToDateTime(inpatient.ClinicDischargeDate).ToString("dd.MM.yyyy HH:mm");

                        //yatışın tarihi 

                        if (inpatient.InpatientStatus.Value == InpatientStatusEnum.Discharged || inpatient.InpatientStatus.Value == InpatientStatusEnum.Predischarged)
                        {
                            //hasta taburcu olmuş ise

                            if (inpatient.ClinicDischargeDate != null && inpatient.ClinicInpatientDate != null)//yatış ve taburcu tarihi var ise yatış gün sayısı hesaplama
                            {
                                i.YatisGunu = (inpatient.ClinicDischargeDate.Value - inpatient.ClinicInpatientDate.Value).Days.ToString();
                            }
                        }

                        else if (inpatient.InpatientStatus.Value == InpatientStatusEnum.Inpatient)
                        {
                            //hasta yatan hasta ise
                            if (inpatient.ClinicInpatientDate != null && inpatient.IsDailyOperation != true)
                            {
                                i.YatisGunu = ((DateTime.Now - inpatient.ClinicInpatientDate.Value).Days + 1).ToString();
                            }



                            else if (inpatient.IsDailyOperation == true)
                            {
                                if (inpatient.ClinicDischargeDate != null)
                                    i.YatisGunu = ((inpatient.ClinicDischargeDate.Value - inpatient.ClinicInpatientDate.Value).Days + 1).ToString();
                                else
                                    i.YatisGunu = "0";
                            }
                        }
                        //yatışın tarihi







                        var diagnosisList = DiagnosisGrid.GetBySubEpisode(objectContext, inpatient.Subepisodeid.ToString());
                        i.Tanilar = "";
                        foreach (DiagnosisGrid d in diagnosisList)
                        {
                            if (i.Tanilar == "")
                                i.Tanilar = d.Diagnose.Code + "-" + d.Diagnose.Name;
                            else
                                i.Tanilar += ", " + d.Diagnose.Code + "-" + d.Diagnose.Name;

                        }

                        i.VerilenIlaclar = "";
                        string injectionSqlTreatmentMaterial = string.Empty;
                        injectionSqlTreatmentMaterial = " AND MATERIAL.OBJECTDEFID='65a2337c-bc3c-4c6b-9575-ad47fa7a9a89'  AND EPISODEACTION.SUBEPISODE= '" + inpatient.Subepisodeid.ToString() + "'";
                        BindingList<BaseTreatmentMaterial.GetTreatmentMatByParameter_Class> baseTreatmentList = BaseTreatmentMaterial.GetTreatmentMatByParameter(injectionSqlTreatmentMaterial);
                        foreach (BaseTreatmentMaterial.GetTreatmentMatByParameter_Class medicine in baseTreatmentList)
                        {
                            if (i.Tanilar == "")
                                i.VerilenIlaclar = medicine.Drugname == null ? "" : medicine.Drugname.ToString();
                            else
                                i.VerilenIlaclar += ", " + medicine.Drugname == null ? "" : medicine.Drugname.ToString();

                        }
                        data.HastaListesi.Add(i);

                    }
                }
            }

            return data;
        }

        public static string GetDateAsString(DateTime dateTime)
        {
            return "TODATE('" + Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }
    }

    [Serializable]
    public class YatanHastaIstatisticParameters
    {
        [DataMember]
        public DateTime InpatientStartDate
        {
            get;
            set;
        }
        [DataMember]
        public DateTime InpatientEndDate
        {
            get;
            set;
        }
        [DataMember]
        public DateTime DischargeStartDate
        {
            get;
            set;
        }
        [DataMember]
        public DateTime DischargeEndDate
        {
            get;
            set;
        }
        [DataMember]
        public List<InpatientClinicModel> SelectedClinics;
        [DataMember]
        public List<InpatientDiagnosisAndProcedureModel> DiagnosisList;
        [DataMember]
        public List<InpatientDiagnosisAndProcedureModel> ProcedureList;

    }
    [Serializable]
    public class InpatientClinicModel
    {
        [DataMember]
        public Guid ObjectID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
    [Serializable]
    public class InpatientDiagnosisAndProcedureModel
    {
        [DataMember]
        public Guid ObjectID { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
    [Serializable]
    public class YatanHastaIstatistikRaporuData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }
        [DataMember]
        public DateTime RaporTarihi { get; set; }
        [DataMember]
        public DateTime SecilenTarih { get; set; }
        [DataMember]
        public List<YatanHastaInfo> HastaListesi { get; set; }
    }

    [Serializable]
    public class YatanHastaInfo
    {
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string KimlikNo { get; set; }
        [DataMember]
        public string YatisTarihi { get; set; }
        [DataMember]
        public string CikisTarihi { get; set; }
        [DataMember]
        public string YatisGunu { get; set; }
        [DataMember]
        public string Tanilar { get; set; }
        [DataMember]
        public string VerilenIlaclar { get; set; }
    }
}
