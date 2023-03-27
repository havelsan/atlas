using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz247_ToplumTabanliKanserTaramaVeriSeti
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
                messageType.code = "247";
                messageType.value = "Toplum Tabanli Kanser Tarama Veri Seti";
            }

        }
        public class recordData
        {
            public TOPLUM_TABANLI_KANSER_TARAMA TOPLUM_TABANLI_KANSER_TARAMA = new TOPLUM_TABANLI_KANSER_TARAMA();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class TOPLUM_TABANLI_KANSER_TARAMA
        {
            public GAITADA_GIZLI_KAN_TESTI GAITADA_GIZLI_KAN_TESTI;
            public HPV_TARAMA_TESTI HPV_TARAMA_TESTI;
            public KENDI_KENDINE_MEME_MUAYENESI KENDI_KENDINE_MEME_MUAYENESI;
            public KLINIK_MEME_MUAYENESI KLINIK_MEME_MUAYENESI;
            public KOLONOSKOPI KOLONOSKOPI;
            public KOLONOSKOPININ_SURESI KOLONOSKOPININ_SURESI;
            public KOLON_GORUNTULEME_YONTEMI KOLON_GORUNTULEME_YONTEMI;
            public KOLPOSKOPI KOLPOSKOPI;
            public MAMOGRAFI MAMOGRAFI;
            public MAMOGRAFI_SONUCU MAMOGRAFI_SONUCU;
            public PAP_SMEAR_TESTI PAP_SMEAR_TESTI;
            public SIGMOIDOSKOPI SIGMOIDOSKOPI;

            [System.Xml.Serialization.XmlElement("HPV_TIPI_BILGISI", Type = typeof(HPV_TIPI_BILGISI))]
            public List<HPV_TIPI_BILGISI> HPV_TIPI_BILGISI;

            [System.Xml.Serialization.XmlElement("KOLONOSKOPI_KALITE_KRITERLERI_BILGISI", Type = typeof(KOLONOSKOPI_KALITE_KRITERLERI_BILGISI))]
            public List<KOLONOSKOPI_KALITE_KRITERLERI_BILGISI> KOLONOSKOPI_KALITE_KRITERLERI_BILGISI;

            [System.Xml.Serialization.XmlElement("KOLOREKTAL_BIYOPSI_SONUCU_BILGISI", Type = typeof(KOLOREKTAL_BIYOPSI_SONUCU_BILGISI))]
            public List<KOLOREKTAL_BIYOPSI_SONUCU_BILGISI> KOLOREKTAL_BIYOPSI_SONUCU_BILGISI;

            [System.Xml.Serialization.XmlElement("MEME_BIYOPSI_BILGISI", Type = typeof(MEME_BIYOPSI_BILGISI))]
            public List<MEME_BIYOPSI_BILGISI> MEME_BIYOPSI_BILGISI;

            [System.Xml.Serialization.XmlElement("SERVIKAL_BIYOPSI_SONUCU_BILGISI", Type = typeof(SERVIKAL_BIYOPSI_SONUCU_BILGISI))]
            public List<SERVIKAL_BIYOPSI_SONUCU_BILGISI> SERVIKAL_BIYOPSI_SONUCU_BILGISI;

            [System.Xml.Serialization.XmlElement("SERVIKAL_SITOLOJI_SONUCU_BILGISI", Type = typeof(SERVIKAL_SITOLOJI_SONUCU_BILGISI))]
            public List<SERVIKAL_SITOLOJI_SONUCU_BILGISI> SERVIKAL_SITOLOJI_SONUCU_BILGISI;

            [System.Xml.Serialization.XmlElement("TARAMA_BILGISI", Type = typeof(TARAMA_BILGISI))]
            public List<TARAMA_BILGISI> TARAMA_BILGISI = new List<TARAMA_BILGISI>();
        }

        public class HPV_TIPI_BILGISI
        {
            public HPV_TIPI HPV_TIPI = new HPV_TIPI();
        }
        public class KOLONOSKOPI_KALITE_KRITERLERI_BILGISI
        {
            public KOLONOSKOPI_KALITE_KRITERLERI KOLONOSKOPI_KALITE_KRITERLERI;
        }
        public class KOLOREKTAL_BIYOPSI_SONUCU_BILGISI
        {
            public KOLOREKTAL_BIYOPSI_SONUCU KOLOREKTAL_BIYOPSI_SONUCU;
        }
        public class MEME_BIYOPSI_BILGISI
        {
            public MEMEDEN_BIYOPSI_ALIMI MEMEDEN_BIYOPSI_ALIMI;
            public MEME_BIYOPSI_SONUCU MEME_BIYOPSI_SONUCU;
        }
        public class SERVIKAL_BIYOPSI_SONUCU_BILGISI
        {
            public SERVIKAL_BIYOPSI_SONUCU SERVIKAL_BIYOPSI_SONUCU;
        }
        public class SERVIKAL_SITOLOJI_SONUCU_BILGISI
        {
            public SERVIKAL_SITOLOJI_SONUCU SERVIKAL_SITOLOJI_SONUCU;
        }

        public class TARAMA_BILGISI
        {
            public TARAMA_TIPI TARAMA_TIPI;
            public TARAMA_TARIHI TARAMA_TARIHI;
            public TARAMA_SONUCLANMA_TARIHI TARAMA_SONUCLANMA_TARIHI;
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            recordData _recordData = new recordData();
            CancerScreening cancerScreening = (CancerScreening)objectContext.GetObject(InternalObjectId, InternalObjectDefName);

            if (cancerScreening != null)
            {
                if (cancerScreening.SubEpisode.SYSTakipNo != null)
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = cancerScreening.SubEpisode.SYSTakipNo;
                else
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            }

            bool isMale = false;
            if (cancerScreening.SubEpisode.Episode.Patient.Sex.KODU == "1")
                isMale = true;
         


            _recordData.TOPLUM_TABANLI_KANSER_TARAMA = new TOPLUM_TABANLI_KANSER_TARAMA();

            if (cancerScreening.SKRSGaitadaGizliKanTesti != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.GAITADA_GIZLI_KAN_TESTI = new GAITADA_GIZLI_KAN_TESTI(cancerScreening.SKRSGaitadaGizliKanTesti.KODU, cancerScreening.SKRSGaitadaGizliKanTesti.ADI);

            if (cancerScreening.SKRSHPVTaramaTesti != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.HPV_TARAMA_TESTI = new HPV_TARAMA_TESTI(cancerScreening.SKRSHPVTaramaTesti.KODU, cancerScreening.SKRSHPVTaramaTesti.ADI);

            if (cancerScreening.SKRSKendiKendineMemeMuayenesi != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KENDI_KENDINE_MEME_MUAYENESI = new KENDI_KENDINE_MEME_MUAYENESI(cancerScreening.SKRSKendiKendineMemeMuayenesi.KODU, cancerScreening.SKRSKendiKendineMemeMuayenesi.ADI);

            if (cancerScreening.SKRSKlinikMemeMuayenesi != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KLINIK_MEME_MUAYENESI = new KLINIK_MEME_MUAYENESI(cancerScreening.SKRSKlinikMemeMuayenesi.KODU, cancerScreening.SKRSKlinikMemeMuayenesi.ADI);

            if (cancerScreening.SKRSKolonoskopi != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLONOSKOPI = new KOLONOSKOPI(cancerScreening.SKRSKolonoskopi.KODU, cancerScreening.SKRSKolonoskopi.ADI);

            if (cancerScreening.SKRSKolonoskopininSuresi != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLONOSKOPININ_SURESI = new KOLONOSKOPININ_SURESI(cancerScreening.SKRSKolonoskopininSuresi.KODU, cancerScreening.SKRSKolonoskopininSuresi.ADI);

            if (cancerScreening.SKRSKolonGoruntulemeYontemi != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLON_GORUNTULEME_YONTEMI = new KOLON_GORUNTULEME_YONTEMI(cancerScreening.SKRSKolonGoruntulemeYontemi.KODU, cancerScreening.SKRSKolonGoruntulemeYontemi.ADI);

            if (cancerScreening.SKRSKolposkopi != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLPOSKOPI = new KOLPOSKOPI(cancerScreening.SKRSKolposkopi.KODU, cancerScreening.SKRSKolposkopi.ADI);

            if (cancerScreening.SKRSMamografi != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.MAMOGRAFI = new MAMOGRAFI(cancerScreening.SKRSMamografi.KODU, cancerScreening.SKRSMamografi.ADI);

            if (cancerScreening.SKRSMamografiSonucu != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.MAMOGRAFI_SONUCU = new MAMOGRAFI_SONUCU(cancerScreening.SKRSMamografiSonucu.KODU, cancerScreening.SKRSMamografiSonucu.ADI);

            if (cancerScreening.SKRSPapSmearTesti != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.PAP_SMEAR_TESTI = new PAP_SMEAR_TESTI(cancerScreening.SKRSPapSmearTesti.KODU, cancerScreening.SKRSPapSmearTesti.ADI);

            if (cancerScreening.SKRSSigmoidoskopi != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.SIGMOIDOSKOPI = new SIGMOIDOSKOPI(cancerScreening.SKRSSigmoidoskopi.KODU, cancerScreening.SKRSSigmoidoskopi.ADI);

            if (cancerScreening.HPVTypeInfo.Count > 0 && !isMale)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.HPV_TIPI_BILGISI = new List<HPV_TIPI_BILGISI>();
                foreach (HPVTypeInfo hpvType in cancerScreening.HPVTypeInfo)
                {
                    HPV_TIPI_BILGISI HPV_TIPI_BILGISI = new HPV_TIPI_BILGISI();
                    HPV_TIPI_BILGISI.HPV_TIPI = new HPV_TIPI(hpvType.SKRSHpvTipi.KODU, hpvType.SKRSHpvTipi.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.HPV_TIPI_BILGISI.Add(HPV_TIPI_BILGISI);
                }
            }
            if (cancerScreening.ColonoscopyQualityCriteria.Count > 0)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLONOSKOPI_KALITE_KRITERLERI_BILGISI = new List<KOLONOSKOPI_KALITE_KRITERLERI_BILGISI>();
                foreach (ColonoscopyQualityCriteria colonoscopyQualityCriteria in cancerScreening.ColonoscopyQualityCriteria)
                {
                    KOLONOSKOPI_KALITE_KRITERLERI_BILGISI KOLONOSKOPI_KALITE_KRITERLERI_BILGISI = new KOLONOSKOPI_KALITE_KRITERLERI_BILGISI();
                    KOLONOSKOPI_KALITE_KRITERLERI_BILGISI.KOLONOSKOPI_KALITE_KRITERLERI = new KOLONOSKOPI_KALITE_KRITERLERI(colonoscopyQualityCriteria.KolonoskopiKaliteKriterleri.KODU, colonoscopyQualityCriteria.KolonoskopiKaliteKriterleri.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLONOSKOPI_KALITE_KRITERLERI_BILGISI.Add(KOLONOSKOPI_KALITE_KRITERLERI_BILGISI);
                }
            }
            if (cancerScreening.ColorectalBiopsyResults.Count > 0)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLOREKTAL_BIYOPSI_SONUCU_BILGISI = new List<KOLOREKTAL_BIYOPSI_SONUCU_BILGISI>();
                foreach (ColorectalBiopsyResults colorectalBiopsyResult in cancerScreening.ColorectalBiopsyResults)
                {
                    KOLOREKTAL_BIYOPSI_SONUCU_BILGISI KOLOREKTAL_BIYOPSI_SONUCU_BILGISI = new KOLOREKTAL_BIYOPSI_SONUCU_BILGISI();
                    KOLOREKTAL_BIYOPSI_SONUCU_BILGISI.KOLOREKTAL_BIYOPSI_SONUCU = new KOLOREKTAL_BIYOPSI_SONUCU(colorectalBiopsyResult.SKRSKolorektalBiyopsiSonucu.KODU, colorectalBiopsyResult.SKRSKolorektalBiyopsiSonucu.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLOREKTAL_BIYOPSI_SONUCU_BILGISI.Add(KOLOREKTAL_BIYOPSI_SONUCU_BILGISI);
                }
            }
            if (cancerScreening.BreastBiopsy.Count > 0)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.MEME_BIYOPSI_BILGISI = new List<MEME_BIYOPSI_BILGISI>();
                foreach (BreastBiopsy breastBiopsyResult in cancerScreening.BreastBiopsy)
                {
                    MEME_BIYOPSI_BILGISI MEME_BIYOPSI_BILGISI = new MEME_BIYOPSI_BILGISI();
                    MEME_BIYOPSI_BILGISI.MEMEDEN_BIYOPSI_ALIMI = new MEMEDEN_BIYOPSI_ALIMI(breastBiopsyResult.SKRSMemedenBiyopsiAlimi.KODU, breastBiopsyResult.SKRSMemedenBiyopsiAlimi.ADI);
                    MEME_BIYOPSI_BILGISI.MEME_BIYOPSI_SONUCU = new MEME_BIYOPSI_SONUCU(breastBiopsyResult.SKRSMemeBiyopsiSonucu.KODU, breastBiopsyResult.SKRSMemeBiyopsiSonucu.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.MEME_BIYOPSI_BILGISI.Add(MEME_BIYOPSI_BILGISI);
                }
            }
            if (cancerScreening.CervicalBiopsyResults.Count > 0 )
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.SERVIKAL_BIYOPSI_SONUCU_BILGISI = new List<SERVIKAL_BIYOPSI_SONUCU_BILGISI>();
                foreach (CervicalBiopsyResults cervicalBiopsyResult in cancerScreening.CervicalBiopsyResults)
                {
                    SERVIKAL_BIYOPSI_SONUCU_BILGISI SERVIKAL_BIYOPSI_SONUCU_BILGISI = new SERVIKAL_BIYOPSI_SONUCU_BILGISI();
                    SERVIKAL_BIYOPSI_SONUCU_BILGISI.SERVIKAL_BIYOPSI_SONUCU = new SERVIKAL_BIYOPSI_SONUCU(cervicalBiopsyResult.SKRSServikalBiyopsiSonucu.KODU, cervicalBiopsyResult.SKRSServikalBiyopsiSonucu.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.SERVIKAL_BIYOPSI_SONUCU_BILGISI.Add(SERVIKAL_BIYOPSI_SONUCU_BILGISI);
                }
            }
            if (cancerScreening.CervicalCytologyResults.Count > 0 && !isMale)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.SERVIKAL_SITOLOJI_SONUCU_BILGISI = new List<SERVIKAL_SITOLOJI_SONUCU_BILGISI>();
                foreach (CervicalCytologyResults cervicalCytologyResult in cancerScreening.CervicalCytologyResults)
                {
                    SERVIKAL_SITOLOJI_SONUCU_BILGISI SERVIKAL_SITOLOJI_SONUCU_BILGISI = new SERVIKAL_SITOLOJI_SONUCU_BILGISI();
                    SERVIKAL_SITOLOJI_SONUCU_BILGISI.SERVIKAL_SITOLOJI_SONUCU = new SERVIKAL_SITOLOJI_SONUCU(cervicalCytologyResult.SKRSServikalSitolojiSonucu.KODU, cervicalCytologyResult.SKRSServikalSitolojiSonucu.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.SERVIKAL_SITOLOJI_SONUCU_BILGISI.Add(SERVIKAL_SITOLOJI_SONUCU_BILGISI);
                }
            }

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            recordData _recordData = new recordData();
            CancerScreening cancerScreening = (CancerScreening)objectContext.GetObject(new Guid("e080b3ac-b2ca-4631-9b37-272cace9be92"), "CANCERSCREENING");

            if (cancerScreening != null)
            {
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            }

            bool isMale = false;
           



            _recordData.TOPLUM_TABANLI_KANSER_TARAMA = new TOPLUM_TABANLI_KANSER_TARAMA();

            if (cancerScreening.SKRSGaitadaGizliKanTesti != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.GAITADA_GIZLI_KAN_TESTI = new GAITADA_GIZLI_KAN_TESTI(cancerScreening.SKRSGaitadaGizliKanTesti.KODU, cancerScreening.SKRSGaitadaGizliKanTesti.ADI);

            if (cancerScreening.SKRSHPVTaramaTesti != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.HPV_TARAMA_TESTI = new HPV_TARAMA_TESTI(cancerScreening.SKRSHPVTaramaTesti.KODU, cancerScreening.SKRSHPVTaramaTesti.ADI);

            if (cancerScreening.SKRSKendiKendineMemeMuayenesi != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KENDI_KENDINE_MEME_MUAYENESI = new KENDI_KENDINE_MEME_MUAYENESI(cancerScreening.SKRSKendiKendineMemeMuayenesi.KODU, cancerScreening.SKRSKendiKendineMemeMuayenesi.ADI);

            if (cancerScreening.SKRSKlinikMemeMuayenesi != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KLINIK_MEME_MUAYENESI = new KLINIK_MEME_MUAYENESI(cancerScreening.SKRSKlinikMemeMuayenesi.KODU, cancerScreening.SKRSKlinikMemeMuayenesi.ADI);

            if (cancerScreening.SKRSKolonoskopi != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLONOSKOPI = new KOLONOSKOPI(cancerScreening.SKRSKolonoskopi.KODU, cancerScreening.SKRSKolonoskopi.ADI);

            if (cancerScreening.SKRSKolonoskopininSuresi != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLONOSKOPININ_SURESI = new KOLONOSKOPININ_SURESI(cancerScreening.SKRSKolonoskopininSuresi.KODU, cancerScreening.SKRSKolonoskopininSuresi.ADI);

            if (cancerScreening.SKRSKolonGoruntulemeYontemi != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLON_GORUNTULEME_YONTEMI = new KOLON_GORUNTULEME_YONTEMI(cancerScreening.SKRSKolonGoruntulemeYontemi.KODU, cancerScreening.SKRSKolonGoruntulemeYontemi.ADI);

            if (cancerScreening.SKRSKolposkopi != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLPOSKOPI = new KOLPOSKOPI(cancerScreening.SKRSKolposkopi.KODU, cancerScreening.SKRSKolposkopi.ADI);

            if (cancerScreening.SKRSMamografi != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.MAMOGRAFI = new MAMOGRAFI(cancerScreening.SKRSMamografi.KODU, cancerScreening.SKRSMamografi.ADI);

            if (cancerScreening.SKRSMamografiSonucu != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.MAMOGRAFI_SONUCU = new MAMOGRAFI_SONUCU(cancerScreening.SKRSMamografiSonucu.KODU, cancerScreening.SKRSMamografiSonucu.ADI);

            if (cancerScreening.SKRSPapSmearTesti != null && !isMale)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.PAP_SMEAR_TESTI = new PAP_SMEAR_TESTI(cancerScreening.SKRSPapSmearTesti.KODU, cancerScreening.SKRSPapSmearTesti.ADI);

            if (cancerScreening.SKRSSigmoidoskopi != null)
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.SIGMOIDOSKOPI = new SIGMOIDOSKOPI(cancerScreening.SKRSSigmoidoskopi.KODU, cancerScreening.SKRSSigmoidoskopi.ADI);

            if (cancerScreening.HPVTypeInfo.Count > 0 && !isMale)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.HPV_TIPI_BILGISI = new List<HPV_TIPI_BILGISI>();
                foreach (HPVTypeInfo hpvType in cancerScreening.HPVTypeInfo)
                {
                    HPV_TIPI_BILGISI HPV_TIPI_BILGISI = new HPV_TIPI_BILGISI();
                    HPV_TIPI_BILGISI.HPV_TIPI = new HPV_TIPI(hpvType.SKRSHpvTipi.KODU, hpvType.SKRSHpvTipi.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.HPV_TIPI_BILGISI.Add(HPV_TIPI_BILGISI);
                }
            }
            if (cancerScreening.ColonoscopyQualityCriteria.Count > 0)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLONOSKOPI_KALITE_KRITERLERI_BILGISI = new List<KOLONOSKOPI_KALITE_KRITERLERI_BILGISI>();
                foreach (ColonoscopyQualityCriteria colonoscopyQualityCriteria in cancerScreening.ColonoscopyQualityCriteria)
                {
                    KOLONOSKOPI_KALITE_KRITERLERI_BILGISI KOLONOSKOPI_KALITE_KRITERLERI_BILGISI = new KOLONOSKOPI_KALITE_KRITERLERI_BILGISI();
                    KOLONOSKOPI_KALITE_KRITERLERI_BILGISI.KOLONOSKOPI_KALITE_KRITERLERI = new KOLONOSKOPI_KALITE_KRITERLERI(colonoscopyQualityCriteria.KolonoskopiKaliteKriterleri.KODU, colonoscopyQualityCriteria.KolonoskopiKaliteKriterleri.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLONOSKOPI_KALITE_KRITERLERI_BILGISI.Add(KOLONOSKOPI_KALITE_KRITERLERI_BILGISI);
                }
            }
            if (cancerScreening.ColorectalBiopsyResults.Count > 0)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLOREKTAL_BIYOPSI_SONUCU_BILGISI = new List<KOLOREKTAL_BIYOPSI_SONUCU_BILGISI>();
                foreach (ColorectalBiopsyResults colorectalBiopsyResult in cancerScreening.ColorectalBiopsyResults)
                {
                    KOLOREKTAL_BIYOPSI_SONUCU_BILGISI KOLOREKTAL_BIYOPSI_SONUCU_BILGISI = new KOLOREKTAL_BIYOPSI_SONUCU_BILGISI();
                    KOLOREKTAL_BIYOPSI_SONUCU_BILGISI.KOLOREKTAL_BIYOPSI_SONUCU = new KOLOREKTAL_BIYOPSI_SONUCU(colorectalBiopsyResult.SKRSKolorektalBiyopsiSonucu.KODU, colorectalBiopsyResult.SKRSKolorektalBiyopsiSonucu.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.KOLOREKTAL_BIYOPSI_SONUCU_BILGISI.Add(KOLOREKTAL_BIYOPSI_SONUCU_BILGISI);
                }
            }
            if (cancerScreening.BreastBiopsy.Count > 0)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.MEME_BIYOPSI_BILGISI = new List<MEME_BIYOPSI_BILGISI>();
                foreach (BreastBiopsy breastBiopsyResult in cancerScreening.BreastBiopsy)
                {
                    MEME_BIYOPSI_BILGISI MEME_BIYOPSI_BILGISI = new MEME_BIYOPSI_BILGISI();
                    MEME_BIYOPSI_BILGISI.MEMEDEN_BIYOPSI_ALIMI = new MEMEDEN_BIYOPSI_ALIMI(breastBiopsyResult.SKRSMemedenBiyopsiAlimi.KODU, breastBiopsyResult.SKRSMemedenBiyopsiAlimi.ADI);
                    MEME_BIYOPSI_BILGISI.MEME_BIYOPSI_SONUCU = new MEME_BIYOPSI_SONUCU(breastBiopsyResult.SKRSMemeBiyopsiSonucu.KODU, breastBiopsyResult.SKRSMemeBiyopsiSonucu.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.MEME_BIYOPSI_BILGISI.Add(MEME_BIYOPSI_BILGISI);
                }
            }
            if (cancerScreening.CervicalBiopsyResults.Count > 0)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.SERVIKAL_BIYOPSI_SONUCU_BILGISI = new List<SERVIKAL_BIYOPSI_SONUCU_BILGISI>();
                foreach (CervicalBiopsyResults cervicalBiopsyResult in cancerScreening.CervicalBiopsyResults)
                {
                    SERVIKAL_BIYOPSI_SONUCU_BILGISI SERVIKAL_BIYOPSI_SONUCU_BILGISI = new SERVIKAL_BIYOPSI_SONUCU_BILGISI();
                    SERVIKAL_BIYOPSI_SONUCU_BILGISI.SERVIKAL_BIYOPSI_SONUCU = new SERVIKAL_BIYOPSI_SONUCU(cervicalBiopsyResult.SKRSServikalBiyopsiSonucu.KODU, cervicalBiopsyResult.SKRSServikalBiyopsiSonucu.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.SERVIKAL_BIYOPSI_SONUCU_BILGISI.Add(SERVIKAL_BIYOPSI_SONUCU_BILGISI);
                }
            }
            if (cancerScreening.CervicalCytologyResults.Count > 0 && !isMale)
            {
                _recordData.TOPLUM_TABANLI_KANSER_TARAMA.SERVIKAL_SITOLOJI_SONUCU_BILGISI = new List<SERVIKAL_SITOLOJI_SONUCU_BILGISI>();
                foreach (CervicalCytologyResults cervicalCytologyResult in cancerScreening.CervicalCytologyResults)
                {
                    SERVIKAL_SITOLOJI_SONUCU_BILGISI SERVIKAL_SITOLOJI_SONUCU_BILGISI = new SERVIKAL_SITOLOJI_SONUCU_BILGISI();
                    SERVIKAL_SITOLOJI_SONUCU_BILGISI.SERVIKAL_SITOLOJI_SONUCU = new SERVIKAL_SITOLOJI_SONUCU(cervicalCytologyResult.SKRSServikalSitolojiSonucu.KODU, cervicalCytologyResult.SKRSServikalSitolojiSonucu.ADI);
                    _recordData.TOPLUM_TABANLI_KANSER_TARAMA.SERVIKAL_SITOLOJI_SONUCU_BILGISI.Add(SERVIKAL_SITOLOJI_SONUCU_BILGISI);
                }
            }

            TARAMA_BILGISI bilgi = new TARAMA_BILGISI();
            bilgi.TARAMA_SONUCLANMA_TARIHI = new TARAMA_SONUCLANMA_TARIHI();
            bilgi.TARAMA_SONUCLANMA_TARIHI.value = "201801010000";
            bilgi.TARAMA_TARIHI = new TARAMA_TARIHI();
            bilgi.TARAMA_TARIHI.value = "201801010000";
            bilgi.TARAMA_TIPI = new TARAMA_TIPI("2", "MEME");
            _recordData.TOPLUM_TABANLI_KANSER_TARAMA.TARAMA_BILGISI.Add(bilgi);


            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
