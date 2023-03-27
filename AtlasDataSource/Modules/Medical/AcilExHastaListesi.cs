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
    public class AcilExHastaListesi
    {
        public static AcilExHastaListesiData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<AcilExHastaListesiData>(parameters, "GetAcilExHastaListesiData");
        }

        public static AcilExHastaListesiData GetAcilExHastaListesiData(string parameters)
        {
            AcilExHastaListesiData ExHastaListesi = new AcilExHastaListesiData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<AcilExListeParam>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    string filiter = " WHERE THIS.DIEDCLINIC IN (";
                    List<ResDepartment.GetEmergencyClinicAndPoliclinic_Class> EmergencyDepartmentList = ResDepartment.GetEmergencyClinicAndPoliclinic().ToList();
                    foreach (ResDepartment.GetEmergencyClinicAndPoliclinic_Class section in EmergencyDepartmentList)
                    {
                        filiter += "'" + section.ObjectID + "',";
                    }
                    filiter = filiter.Remove(filiter.Length - 1, 1);
                    filiter = filiter + ")";

                    BindingList<Morgue.GetExPatientInEmergencyClinic_Class> patientList = Morgue.GetExPatientInEmergencyClinic(filiter);
                    ExHastaListesi.AcilExHastaDataList = new List<AcilExHastaData>();

                    foreach (Morgue.GetExPatientInEmergencyClinic_Class patient in patientList)
                    {
                        AcilExHastaData patientData = new AcilExHastaData();
                        patientData.KabulNo = patient.ProtocolNo;
                        patientData.HastaAdiSoyadi = patient.Patientname + patient.Patientsurname;
                        patientData.HastaTCKimlikNo = patient.Patientuniquerefno;
                        ReasonForDeathDefinition deathReason = objectContext.GetObject<ReasonForDeathDefinition>((Guid)patient.Deathreason);
                        patientData.OlumSebebi = deathReason.ReasonForDeath;
                        patientData.OlumSaati = patient.Deathtime;
                        ResSection section = objectContext.GetObject<ResSection>((Guid)patient.DiedClinic);
                        patientData.Birimi = section.Name;
                        patientData.GelisSaati = patient.OpeningDate;
                    }

                }

            }
                return ExHastaListesi;
        }
    }
 

  [Serializable]
public class AcilExListeParam
{
    [DataMember]
    public Guid AcilID { get; set; }

}
[Serializable]
    public class AcilExHastaListesiData
    {
        [DataMember]
        public List<AcilExHastaData> AcilExHastaDataList { get; set; }
    }

    [Serializable]
    public class AcilExHastaData
    {
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public long? HastaTCKimlikNo { get; set; }
        [DataMember]
        public string OlumSebebi { get; set; }
        [DataMember]
        public DateTime? GelisSaati { get; set; }
        [DataMember]
        public DateTime? OlumSaati { get; set; }
        [DataMember]
        public string Birimi { get; set; } //?
        [DataMember]
        public string TedaviSonucu { get; set; }

    }
}
