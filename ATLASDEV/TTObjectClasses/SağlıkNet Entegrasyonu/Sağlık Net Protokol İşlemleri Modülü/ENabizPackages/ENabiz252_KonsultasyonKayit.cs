using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz252_KonsultasyonKayit
    {
        public class SYSSendMessage
        {
            public input input = new input();
        }
        public class input
        {
            public SYSMessage SYSMessage = new SYSMessage();
        }
        public class SYSMessage
        {
            public messageGuid messageGuid = new messageGuid();
            public messageType messageType = new messageType();
            public documentGenerationTime documentGenerationTime = new documentGenerationTime();
            public author author = new author();
            public firmaKodu firmaKodu = new firmaKodu();

            public recordData recordData = new recordData();

            public SYSMessage()
            {
                messageType.code = "252";
                messageType.value = "Konsültasyon Kayit";
            }
        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public HASTA_KONSULTASYON_BILGILERI HASTA_KONSULTASYON_BILGILERI = new HASTA_KONSULTASYON_BILGILERI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();

        }
        public class HASTA_KONSULTASYON_BILGILERI
        {
            [System.Xml.Serialization.XmlElement("KONSULTASYON_BILGISI", Type = typeof(KONSULTASYON_BILGISI))]
            public List<KONSULTASYON_BILGISI> KONSULTASYON_BILGISI = new List<KONSULTASYON_BILGISI>();
        }
        public class KONSULTASYON_BILGISI
        {
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
            public KONSULTASYON_BASLAMA_ZAMANI KONSULTASYON_BASLAMA_ZAMANI = new KONSULTASYON_BASLAMA_ZAMANI();
            public KONSULTASYON_BITIS_ZAMANI KONSULTASYON_BITIS_ZAMANI = new KONSULTASYON_BITIS_ZAMANI();
            public KONSULTASYON_TALEBINI_YAPAN_HEKIM_KIMLIK_NUMARASI KONSULTASYON_TALEBINI_YAPAN_HEKIM_KIMLIK_NUMARASI = new KONSULTASYON_TALEBINI_YAPAN_HEKIM_KIMLIK_NUMARASI();
            public KONSULTASYON_TALEBINE_CEVAP_VEREN_HEKIM_KIMLIK_NUMARASI KONSULTASYON_TALEBINE_CEVAP_VEREN_HEKIM_KIMLIK_NUMARASI = new KONSULTASYON_TALEBINE_CEVAP_VEREN_HEKIM_KIMLIK_NUMARASI();

            [System.Xml.Serialization.XmlElement("TANI_BILGISI", Type = typeof(TANI_BILGISI))]
            public List<TANI_BILGISI> TANI_BILGISI = new List<TANI_BILGISI>();

            [System.Xml.Serialization.XmlElement("KONSULTASYON_NOTU_BILGISI", Type = typeof(KONSULTASYON_NOTU_BILGISI))]
            public List<KONSULTASYON_NOTU_BILGISI> KONSULTASYON_NOTU_BILGISI = new List<KONSULTASYON_NOTU_BILGISI>();
        }
        public class TANI_BILGISI
        {
            public TANI_TURU TANI_TURU = new TANI_TURU();
            public ICD10 ICD10 = new ICD10();
        }
        public class KONSULTASYON_NOTU_BILGISI
        {
            public KONSULTASYON_NOTU_BASLIK KONSULTASYON_NOTU_BASLIK = new KONSULTASYON_NOTU_BASLIK();
            public KONSULTASYON_NOTU_ACIKLAMA KONSULTASYON_NOTU_ACIKLAMA = new KONSULTASYON_NOTU_ACIKLAMA();
        }
        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
        {
            //InternalObjectGuid bu paket için SubEpisodedur
            TTObjectContext objectContext = new TTObjectContext(true);
            SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);
            if (subEpisode == null)
                throw new Exception("'252' paketini göndermek için '" + InternalObjectGuid + "' ObjectId'li " + InternalObjectDefName + " Objesi bulunamadı");

            recordData _recordData = new recordData();

            //HASTA_TAKIP_BILGISI
            _recordData.HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = subEpisode.SYSTakipNo;

            //HASTA_KONSULTASYON_BILGILERI
            BindingList<ConsultationProcedure> ConsultationProcedureList = ConsultationProcedure.GetCompletedBySubEpisode(objectContext, subEpisode.ObjectID);
            foreach (ConsultationProcedure consultationProcedure in ConsultationProcedureList)
            {
                KONSULTASYON_BILGISI KONSULTASYON_BILGISI = new KONSULTASYON_BILGISI();
                KONSULTASYON_BILGISI.ISLEM_REFERANS_NUMARASI.value = consultationProcedure.ObjectID.ToString();
                KONSULTASYON_BILGISI.KONSULTASYON_BASLAMA_ZAMANI.value = consultationProcedure.Consultation.ProcessDate.Value.ToString("yyyyMMddHHmm");//TODO
                KONSULTASYON_BILGISI.KONSULTASYON_BITIS_ZAMANI.value = consultationProcedure.Consultation.LastState.BranchDate.ToString("yyyyMMddHHmm");//TODO
                if (consultationProcedure.Consultation.RequesterDoctor != null && consultationProcedure.Consultation.RequesterDoctor.Person != null && consultationProcedure.Consultation.RequesterDoctor.Person.UniqueRefNo != null)
                    KONSULTASYON_BILGISI.KONSULTASYON_TALEBINI_YAPAN_HEKIM_KIMLIK_NUMARASI.value = consultationProcedure.Consultation.RequesterDoctor.Person.UniqueRefNo.ToString();

                if (consultationProcedure.Consultation.ProcedureDoctor != null && consultationProcedure.Consultation.ProcedureDoctor.Person != null && consultationProcedure.Consultation.ProcedureDoctor.Person.UniqueRefNo != null)
                    KONSULTASYON_BILGISI.KONSULTASYON_TALEBINE_CEVAP_VEREN_HEKIM_KIMLIK_NUMARASI.value = consultationProcedure.Consultation.ProcedureDoctor.UniqueNo.ToString();

                foreach (DiagnosisGrid dg in consultationProcedure.Consultation.Diagnosis)
                {
                    TANI_BILGISI TANI_BILGISI = new TANI_BILGISI();
                    TerminologyManagerDef skrsDiagnose = dg.Diagnose.GetSKRSDefinition();
                    if (skrsDiagnose != null)
                    {
                        TANI_BILGISI.ICD10 = new ICD10(((SKRSICD)skrsDiagnose).KODU, ((SKRSICD)skrsDiagnose).ADI);
                        if (dg.IsMainDiagnose == true)
                            TANI_BILGISI.TANI_TURU = new TANI_TURU("1", "ANA TANI");
                        else
                            TANI_BILGISI.TANI_TURU = new TANI_TURU("2", "EK TANI");
                        KONSULTASYON_BILGISI.TANI_BILGISI.Add(TANI_BILGISI);
                    }
                }

                if (consultationProcedure.Consultation.ConsultationResultAndOffers != null)
                {
                    KONSULTASYON_NOTU_BILGISI KONSULTASYON_NOTU_BILGISI = new KONSULTASYON_NOTU_BILGISI();
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_BASLIK.value = "KONSÜLTASYON SONUCU VE ÖNERİLER";
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_ACIKLAMA.value = Common.GetTextOfRTFString(consultationProcedure.Consultation.ConsultationResultAndOffers.ToString());
                    KONSULTASYON_BILGISI.KONSULTASYON_NOTU_BILGISI.Add(KONSULTASYON_NOTU_BILGISI);
                }
                if (consultationProcedure.Consultation.PatientHistory != null)
                {
                    KONSULTASYON_NOTU_BILGISI KONSULTASYON_NOTU_BILGISI = new KONSULTASYON_NOTU_BILGISI();
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_BASLIK.value = "HİKAYESİ";
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_ACIKLAMA.value = Common.GetTextOfRTFString(consultationProcedure.Consultation.PatientHistory.ToString());
                    KONSULTASYON_BILGISI.KONSULTASYON_NOTU_BILGISI.Add(KONSULTASYON_NOTU_BILGISI);
                }
                if (consultationProcedure.Consultation.Complaint != null)
                {
                    KONSULTASYON_NOTU_BILGISI KONSULTASYON_NOTU_BILGISI = new KONSULTASYON_NOTU_BILGISI();
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_BASLIK.value = "ŞİKAYETİ";
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_ACIKLAMA.value = Common.GetTextOfRTFString(consultationProcedure.Consultation.Complaint.ToString());
                    KONSULTASYON_BILGISI.KONSULTASYON_NOTU_BILGISI.Add(KONSULTASYON_NOTU_BILGISI);
                }
                if (consultationProcedure.Consultation.PhysicalExamination != null)
                {
                    KONSULTASYON_NOTU_BILGISI KONSULTASYON_NOTU_BILGISI = new KONSULTASYON_NOTU_BILGISI();
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_BASLIK.value = "FİZİK MUAYENESİ";
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_ACIKLAMA.value = Common.GetTextOfRTFString(consultationProcedure.Consultation.PhysicalExamination.ToString());
                    KONSULTASYON_BILGISI.KONSULTASYON_NOTU_BILGISI.Add(KONSULTASYON_NOTU_BILGISI);
                }
                _recordData.HASTA_KONSULTASYON_BILGILERI.KONSULTASYON_BILGISI.Add(KONSULTASYON_BILGISI);
            }
            //objectContext.QueryObjects<AnesthesiaConsultationProcedure>().Where(p => p.SubEpisode.ObjectID.Equals(subEpisode.ObjectID) && p.CurrentStateDefID == AnesthesiaConsultationProcedure.States.Completed).ToArray();//
            BindingList<AnesthesiaConsultationProcedure> AnesthesiaConsultationProcedureList = AnesthesiaConsultationProcedure.GetCompletedBySubEpisode(objectContext, subEpisode.ObjectID);
            foreach (AnesthesiaConsultationProcedure aConsultationProcedure in AnesthesiaConsultationProcedureList)
            {
                KONSULTASYON_BILGISI KONSULTASYON_BILGISI = new KONSULTASYON_BILGISI();
                KONSULTASYON_BILGISI.ISLEM_REFERANS_NUMARASI.value = aConsultationProcedure.ObjectID.ToString();
                KONSULTASYON_BILGISI.KONSULTASYON_BASLAMA_ZAMANI.value = aConsultationProcedure.Consultation.ProcessDate.Value.ToString("yyyyMMddHHmm");//TODO
                KONSULTASYON_BILGISI.KONSULTASYON_BITIS_ZAMANI.value = aConsultationProcedure.Consultation.LastState.BranchDate.ToString("yyyyMMddHHmm");//TODO
                if (aConsultationProcedure.Consultation.RequesterDoctor != null && aConsultationProcedure.Consultation.RequesterDoctor.Person != null && aConsultationProcedure.Consultation.RequesterDoctor.Person.UniqueRefNo != null)
                    KONSULTASYON_BILGISI.KONSULTASYON_TALEBINI_YAPAN_HEKIM_KIMLIK_NUMARASI.value = aConsultationProcedure.Consultation.RequesterDoctor.Person.UniqueRefNo.ToString();

                if (aConsultationProcedure.Consultation.ProcedureDoctor != null && aConsultationProcedure.Consultation.ProcedureDoctor.Person != null && aConsultationProcedure.Consultation.ProcedureDoctor.Person.UniqueRefNo != null)
                    KONSULTASYON_BILGISI.KONSULTASYON_TALEBINE_CEVAP_VEREN_HEKIM_KIMLIK_NUMARASI.value = aConsultationProcedure.Consultation.ProcedureDoctor.UniqueNo.ToString();

                foreach (DiagnosisGrid dg in aConsultationProcedure.Consultation.Diagnosis)
                {
                    TANI_BILGISI TANI_BILGISI = new TANI_BILGISI();
                    TerminologyManagerDef skrsDiagnose = dg.Diagnose.GetSKRSDefinition();
                    if (skrsDiagnose != null)
                    {
                        TANI_BILGISI.ICD10 = new ICD10(((SKRSICD)skrsDiagnose).KODU, ((SKRSICD)skrsDiagnose).ADI);
                        if (dg.IsMainDiagnose == true)
                            TANI_BILGISI.TANI_TURU = new TANI_TURU("1", "ANA TANI");
                        else
                            TANI_BILGISI.TANI_TURU = new TANI_TURU("2", "EK TANI");
                        KONSULTASYON_BILGISI.TANI_BILGISI.Add(TANI_BILGISI);
                    }
                }

                if (aConsultationProcedure.Consultation.ConsultationResultAndOffers != null)
                {
                    KONSULTASYON_NOTU_BILGISI KONSULTASYON_NOTU_BILGISI = new KONSULTASYON_NOTU_BILGISI();
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_BASLIK.value = "KONSÜLTASYON SONUCU VE ÖNERİLER";
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_ACIKLAMA.value = Common.GetTextOfRTFString(aConsultationProcedure.Consultation.ConsultationResultAndOffers.ToString());
                    KONSULTASYON_BILGISI.KONSULTASYON_NOTU_BILGISI.Add(KONSULTASYON_NOTU_BILGISI);
                }
                if (aConsultationProcedure.Consultation.PatientHistory != null)
                {
                    KONSULTASYON_NOTU_BILGISI KONSULTASYON_NOTU_BILGISI = new KONSULTASYON_NOTU_BILGISI();
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_BASLIK.value = "HİKAYESİ";
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_ACIKLAMA.value = Common.GetTextOfRTFString(aConsultationProcedure.Consultation.PatientHistory.ToString());
                    KONSULTASYON_BILGISI.KONSULTASYON_NOTU_BILGISI.Add(KONSULTASYON_NOTU_BILGISI);
                }
                if (aConsultationProcedure.Consultation.Complaint != null)
                {
                    KONSULTASYON_NOTU_BILGISI KONSULTASYON_NOTU_BILGISI = new KONSULTASYON_NOTU_BILGISI();
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_BASLIK.value = "ŞİKAYETİ";
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_ACIKLAMA.value = Common.GetTextOfRTFString(aConsultationProcedure.Consultation.Complaint.ToString());
                    KONSULTASYON_BILGISI.KONSULTASYON_NOTU_BILGISI.Add(KONSULTASYON_NOTU_BILGISI);
                }
                if (aConsultationProcedure.Consultation.PhysicalExamination != null)
                {
                    KONSULTASYON_NOTU_BILGISI KONSULTASYON_NOTU_BILGISI = new KONSULTASYON_NOTU_BILGISI();
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_BASLIK.value = "FİZİK MUAYENESİ";
                    KONSULTASYON_NOTU_BILGISI.KONSULTASYON_NOTU_ACIKLAMA.value = Common.GetTextOfRTFString(aConsultationProcedure.Consultation.PhysicalExamination.ToString());
                    KONSULTASYON_BILGISI.KONSULTASYON_NOTU_BILGISI.Add(KONSULTASYON_NOTU_BILGISI);
                }
                _recordData.HASTA_KONSULTASYON_BILGILERI.KONSULTASYON_BILGISI.Add(KONSULTASYON_BILGISI);
            }


            SYSMessage _SYSMessage = new SYSMessage();
            _SYSMessage.recordData = _recordData;
            return _SYSMessage;
        }
    }
}
