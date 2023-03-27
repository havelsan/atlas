using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz206_AsiSonrasiIstenmeyenEtkiVeriSeti
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
                messageType.code = "206";
                messageType.value = "Asi Sonrasi Istenmeyen Etki Veri Seti";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public ASI_SONRASI_ISTENMEYEN_ETKI ASI_SONRASI_ISTENMEYEN_ETKI = new ASI_SONRASI_ISTENMEYEN_ETKI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class ASI_SONRASI_ISTENMEYEN_ETKI
        {
            [XmlElement("ASI_ISTENMEYEN_ETKI_BILGISI", Type = typeof(ASI_ISTENMEYEN_ETKI_BILGISI))]
            public List<ASI_ISTENMEYEN_ETKI_BILGISI> ASI_ISTENMEYEN_ETKI_BILGISI;

            [XmlElement("OZET_ADRES_BILGISI", Type = typeof(OZET_ADRES_BILGISI))]
            public List<OZET_ADRES_BILGISI> OZET_ADRES_BILGISI;
        }
        public class ASI_ISTENMEYEN_ETKI_BILGISI
        {
            public ASI ASI;
            public ASIE_ORTAYA_CIKIS_TARIHI ASIE_ORTAYA_CIKIS_TARIHI = new ASIE_ORTAYA_CIKIS_TARIHI();
            public ASININ_DOZU ASININ_DOZU;
            public ASI_UYGULAMA_YERI ASI_UYGULAMA_YERI;
            public BILDIRIMI_ZORUNLU_ASI_SONRASI_ISTENMEYEN_ETKI_NEDENI BILDIRIMI_ZORUNLU_ASI_SONRASI_ISTENMEYEN_ETKI_NEDENI;
        }
        public class OZET_ADRES_BILGISI
        {
            public ACIK_ADRES ACIK_ADRES = new ACIK_ADRES();
            public ADRES_KODU ADRES_KODU = new ADRES_KODU();
            public ADRES_KODU_SEVIYESI ADRES_KODU_SEVIYESI;
            public ADRES_TIPI ADRES_TIPI;

        }
        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
        {
            //InternalObjectGuid bu obje için aşıların idsi
            TTObjectContext objectContext = new TTObjectContext(true);

            recordData _recordData = new recordData();

            VaccineDetails vaccine = (VaccineDetails)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);
            Patient patient = vaccine.VaccineFollowUp.Episode.Patient;
            //TODO
            /*
            if (vaccine != null)
            {
                if (vaccine.VaccineFollowUp.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = vaccine.VaccineFollowUp.SubEpisode.SYSTakipNo;

                _recordData.ASI_SONRASI_ISTENMEYEN_ETKI = new ASI_SONRASI_ISTENMEYEN_ETKI();

                ASI_ISTENMEYEN_ETKI_BILGISI ASI_ISTENMEYEN_ETKI_BILGISI = new ASI_ISTENMEYEN_ETKI_BILGISI();
                ASI_ISTENMEYEN_ETKI_BILGISI.ASI = new ASI(vaccine.SKRSAsiKodu.KODU.ToString(),vaccine.SKRSAsiKodu.ADI);
                ASI_ISTENMEYEN_ETKI_BILGISI.ASIE_ORTAYA_CIKIS_TARIHI.value = "";//enterprisea ekle
                ASI_ISTENMEYEN_ETKI_BILGISI.ASININ_DOZU = new ASININ_DOZU(vaccine.SKRSAsininDozu.KODU,vaccine.SKRSAsininDozu.ADI);
                ASI_ISTENMEYEN_ETKI_BILGISI.ASI_UYGULAMA_YERI = new ASI_UYGULAMA_YERI(vaccine.SKRSAsiUygulamaYeri.KODU,vaccine.SKRSAsiUygulamaYeri.ADI);
                ASI_ISTENMEYEN_ETKI_BILGISI.BILDIRIMI_ZORUNLU_ASI_SONRASI_ISTENMEYEN_ETKI_NEDENI = new BILDIRIMI_ZORUNLU_ASI_SONRASI_ISTENMEYEN_ETKI_NEDENI(vaccine.SKRSAsiSonrasiIstenmeyenEtki.KODU,vaccine.SKRSAsiSonrasiIstenmeyenEtki.ADI);

                _recordData.ASI_SONRASI_ISTENMEYEN_ETKI.ASI_ISTENMEYEN_ETKI_BILGISI = new List<ASI_ISTENMEYEN_ETKI_BILGISI>();
                _recordData.ASI_SONRASI_ISTENMEYEN_ETKI.ASI_ISTENMEYEN_ETKI_BILGISI.Add(ASI_ISTENMEYEN_ETKI_BILGISI);

                OZET_ADRES_BILGISI OZET_ADRES_BILGISI = new OZET_ADRES_BILGISI();
                OZET_ADRES_BILGISI.ACIK_ADRES.value = patient.HomeAddress;
                OZET_ADRES_BILGISI.ADRES_KODU.value = patient.SKRSAdresKodu;
                OZET_ADRES_BILGISI.ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI(patient.SKRSAdresKoduSeviyesi.KODU,patient.SKRSAdresKoduSeviyesi.ADI);
                OZET_ADRES_BILGISI.ADRES_TIPI = new ADRES_TIPI(patient.SKRSAdresTipi.KODU,patient.SKRSAdresTipi.ADI);

                _recordData.ASI_SONRASI_ISTENMEYEN_ETKI.OZET_ADRES_BILGISI = new List<OZET_ADRES_BILGISI>();
                _recordData.ASI_SONRASI_ISTENMEYEN_ETKI.OZET_ADRES_BILGISI.Add(OZET_ADRES_BILGISI);

            }
            */
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();
            ASI_ISTENMEYEN_ETKI_BILGISI istenmeyenEtki = new ASI_ISTENMEYEN_ETKI_BILGISI();
            istenmeyenEtki.ASI = new ASI("1", "BİVALAN OPA (ORAL POLİO AŞISI)");
            istenmeyenEtki.ASIE_ORTAYA_CIKIS_TARIHI = new ASIE_ORTAYA_CIKIS_TARIHI();
            istenmeyenEtki.ASIE_ORTAYA_CIKIS_TARIHI.value = "201801010000";
            istenmeyenEtki.ASININ_DOZU = new ASININ_DOZU("1", "AŞININ BİRİNCİ DOZU");
            istenmeyenEtki.ASI_UYGULAMA_YERI = new ASI_UYGULAMA_YERI("1", "AĞIZ");
            istenmeyenEtki.BILDIRIMI_ZORUNLU_ASI_SONRASI_ISTENMEYEN_ETKI_NEDENI = new BILDIRIMI_ZORUNLU_ASI_SONRASI_ISTENMEYEN_ETKI_NEDENI("1", "AŞI YAN ETKİSİ");
            _recordData.ASI_SONRASI_ISTENMEYEN_ETKI.ASI_ISTENMEYEN_ETKI_BILGISI = new List<ASI_ISTENMEYEN_ETKI_BILGISI>();
            _recordData.ASI_SONRASI_ISTENMEYEN_ETKI.ASI_ISTENMEYEN_ETKI_BILGISI.Add(istenmeyenEtki);

            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

    }
}
