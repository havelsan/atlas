using ReportClasses.ReportUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace AtlasDataSource.Controllers
{
    class SaglikKuruluPursaklar
    {
        public static SaglikKuruluPursaklarData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<SaglikKuruluPursaklarData>(parameters, "GetSaglikKuruluPursaklarData");
        }

        public static SaglikKuruluPursaklarData GetSaglikKuruluPursaklarData(string parameters)
        {
            SaglikKuruluPursaklarData data = new SaglikKuruluPursaklarData();

            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<SaglikKuruluReportParameters>(parameters.ToString());

                BindingList<HealthCommittee.GetHealthCommitteeByObjectID_Class> HC_Report = HealthCommittee.GetHealthCommitteeByObjectID(param.ObjectID);
                if (HC_Report.Count > 0)
                {
                    HealthCommittee.GetHealthCommitteeByObjectID_Class report = HC_Report[0];
                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.HastahaneIL = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    data.HastahaneAltBaslik = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSUBNAME", "");

                    data.RaporNumarasi = (report != null ? Globals.ToStringCore(report.BookNumber) : "") + @" / " + (report != null ? Globals.ToStringCore(report.Raporno) : "");
                    data.Ad = (report != null ? Globals.ToStringCore(report.Pname) : "");
                    data.Soyad = (report != null ? Globals.ToStringCore(report.Psurname) : "");
                    data.MuayeneTarihi = (report != null ? report.Muayenetarihi : null);
                    data.BabaAdi = (report != null ? Globals.ToStringCore(report.FatherName) : "");
                    data.RaporTarihi = (report != null ? report.Raportarihi : null);
                    data.KimlikNumarasi = (report != null ? Globals.ToStringCore(report.Tcno) : "");
                    data.DogumYeri = (report != null ? Globals.ToStringCore(report.Dyeri) : "");
                    data.DogumTarihi = (report != null ? report.Dtarihi : null);
                    data.CepTelefonu = (report != null ? Globals.ToStringCore(report.Ceptel) : "");
                    data.IstekSebebi = (report != null ? Globals.ToStringCore(report.Sksebebi) : "");
                    data.Kurum = (report != null ? Globals.ToStringCore(report.Kurum) : "");                    
                    data.RaporNumarasi = (report != null ? Globals.ToStringCore(report.ID) : "");
                    data.Boy = (report != null ? Globals.ToStringCore(report.Heyetboy) : "");
                    data.Kilo = (report != null ? Globals.ToStringCore(report.Heyetkilo) : "");

                    using (var objectContext = new TTObjectContext(false)) //RTF alanların texti nqlde alınamadığı için eklendi.
                    {
                        HealthCommittee p = (HealthCommittee)objectContext.GetObject(report.Healthcommitteeobjectid.Value, "HealthCommittee");
                        data.Kurum = p.SubEpisode.LastSubEpisodeProtocol.Payer.Name;
                        data.Tanilar = GetTaniList(p);
                        data.Doktorlar = GetTDoctorImza(p);

                        data.KurulBaskani = p.HCRequestReason.ReasonForExamination.MemberOfHealthCommittee.MasterOfHealthCommittee2.SignatureBlockWDiplomaInfo.Replace("\r", "");//boşluklar gitsin;


                        if (p.ClinicalFindings != null)
                        {
                            data.Bulgular = Common.GetTextOfRTFString(p.ClinicalFindings.ToString());
                        }

                        if (p.Definition != null)
                        {
                            data.Aciklama = Common.GetTextOfRTFString(p.Definition.ToString());
                        }

                        if (p.HealthCommitteeDecision != null)
                        {
                            data.Karar = Common.GetTextOfRTFString(p.HealthCommitteeDecision.ToString());
                        }

                    }

                }
            }
            return data;

        }

        private static List<string> GetTDoctorImza(HealthCommittee p)
        {
            List<string> doctorList = new List<string>();

            foreach (BaseHealthCommittee_ExtDoctorGrid doctors in p.ExternalDoctors)
            {
                string dr1 = doctors.ExternalDoctorName + "\n" + (doctors.Speciality != null ? doctors.Speciality.Name : "")
                     + "\nDip.Tes.No:" + doctors.ExternalDoctorRegNumber + " Uzm.Tes.No:" + doctors.ExternalDoctorSpecialityRegNo;
                if (doctors.Reject.HasValue && doctors.Reject.Value)
                    dr1 = "\nŞerh düşülmüştür.Nedeni;\n" + doctors.Description;

                doctorList.Add(dr1);
            }

            foreach (var member in p.Members)
            {
                string dr1 = member.MemberDoctor.Name + "\n" + (member.Speciality != null ? member.Speciality.Name : "")
                    + "\nDip.Tes.No:" + member.MemberDoctor.DiplomaRegisterNo + " Uzm.Tes.No:" + member.MemberDoctor.SpecialityRegistryNo;
                if (member.Reject.HasValue && member.Reject.Value)
                    dr1 = "\nŞerh düşülmüştür.Nedeni;\n" + member.Description;

                doctorList.Add(dr1);
            }

            return doctorList;
        }

        private static List<string> GetTaniList(HealthCommittee p)
        {
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(p);
            DiagnosisGrid dg = null;
            List<string> codeArray = new List<string>();
            List<string> taniListesi = new List<string>();
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is PatientExamination && ((PatientExamination)eaction).PatientExaminationType == PatientExaminationEnum.HealthCommittee && !eaction.IsCancelled && eaction.CurrentStateDefID != PatientExamination.States.PatientNoShown)
                {
                    PatientExamination exam = (PatientExamination)eaction;
                    if (exam.CurrentStateDefID.Equals(PatientExamination.States.Completed) && exam.Diagnosis != null)
                    {
                        for (int i = 0; i < exam.Diagnosis.Count; i++)
                        {
                            dg = exam.Diagnosis[i];
                            if (!codeArray.Contains(dg.Diagnose.Code))
                            {
                                codeArray.Add(dg.Diagnose.Code);
                                taniListesi.Add(dg.Diagnose.Code + "-" + dg.Diagnose.Name);
                            }
                        }
                    }
                }
            }
            return taniListesi;
        }

        [Serializable]
        public class SaglikKuruluReportParameters
        {
            [DataMember]
            public Guid ObjectID { get; set; } //

        }

        [Serializable]
        public class SaglikKuruluPursaklarData
        {
            [DataMember]
            public string HastahaneAdi { get; set; }
            [DataMember]
            public string HastahaneIL { get; set; }
            [DataMember]
            public string HastahaneAltBaslik { get; set; }

            [DataMember]
            public string MedulaTakipNo { get; set; }

            [DataMember]
            public string KimlikNumarasi { get; set; }

            [DataMember]
            public string Ad { get; set; }
            [DataMember]
            public string Soyad { get; set; }
            [DataMember]
            public string BabaAdi { get; set; }

            [DataMember]
            public string DogumYeri { get; set; }
            [DataMember]
            public DateTime? DogumTarihi { get; set; }
            [DataMember]
            public string Kurum { get; set; }
            [DataMember]
            public string IstekSebebi { get; set; }
            [DataMember]
            public DateTime? RaporTarihi { get; set; }
            [DataMember]
            public DateTime? MuayeneTarihi { get; set; }
            [DataMember]
            public string DefterNumarasi { get; set; }
            [DataMember]
            public string RaporNumarasi { get; set; }
            [DataMember]
            public string KabulNumarasi { get; set; }
            [DataMember]
            public string Boy { get; set; }
            [DataMember]
            public string Kilo { get; set; }
            [DataMember]
            public string CepTelefonu { get; set; }
            [DataMember]
            public List<string> Tanilar { get; set; }
            [DataMember]
            public List<string> Doktorlar { get; set; }
            [DataMember]
            public string KurulBaskani { get; set; }
            [DataMember]
            public string Bulgular { get; set; }
            [DataMember]
            public string Aciklama { get; set; }
            [DataMember]
            public string Karar { get; set; }
        }
    }
}
