using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz250_VeremVeriSeti
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
                messageType.code = "250";
                messageType.value = "Verem Veri Seti";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public VEREM VEREM = new VEREM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class VEREM
        {
            public BCG_SKAR_SAYISI BCG_SKAR_SAYISI;
            public DGT_UYGULAMASINI_YAPAN_KISI DGT_UYGULAMASINI_YAPAN_KISI;
            public DGT_UYGULAMA_YERI DGT_UYGULAMA_YERI;
            public HASTANIN_TEDAVIYE_UYUMU HASTANIN_TEDAVIYE_UYUMU;
            public KULTUR_SONUCU KULTUR_SONUCU;
            public TUBERKULIN_DERI_TESTI_SONUCU TUBERKULIN_DERI_TESTI_SONUCU;
            public VEREM_HASTASI_TEDAVI_YONTEMI VEREM_HASTASI_TEDAVI_YONTEMI = new VEREM_HASTASI_TEDAVI_YONTEMI();
            public VEREM_OLGU_TANIMI VEREM_OLGU_TANIMI;
            public YAYMA_SONUCU YAYMA_SONUCU;
            [System.Xml.Serialization.XmlElement("VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI", Type = typeof(VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI))]
            public List<VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI> VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI; 
            [System.Xml.Serialization.XmlElement("VEREM_HASTASI_KLINIK_ORNEGI_BILGISI", Type = typeof(VEREM_HASTASI_KLINIK_ORNEGI_BILGISI))]
            public List<VEREM_HASTASI_KLINIK_ORNEGI_BILGISI> VEREM_HASTASI_KLINIK_ORNEGI_BILGISI;
            [System.Xml.Serialization.XmlElement("VEREM_ILAC_BILGISI", Type = typeof(VEREM_ILAC_BILGISI))]
            public List<VEREM_ILAC_BILGISI> VEREM_ILAC_BILGISI; 
            [System.Xml.Serialization.XmlElement("VEREM_TEDAVI_SONUCU_BILGISI", Type = typeof(VEREM_TEDAVI_SONUCU_BILGISI))]
            public List<VEREM_TEDAVI_SONUCU_BILGISI> VEREM_TEDAVI_SONUCU_BILGISI; 
        }

        public class VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI
        {
            public VEREM_HASTALIGININ_TUTULUM_YERI VEREM_HASTALIGININ_TUTULUM_YERI;
        }
        public class VEREM_HASTASI_KLINIK_ORNEGI_BILGISI
        {
            public VEREM_HASTASI_KLINIK_ORNEGI VEREM_HASTASI_KLINIK_ORNEGI;
        }
        public class VEREM_ILAC_BILGISI
        {
            public ILAC_ADI_VEREM ILAC_ADI_VEREM;
            public ILAC_DIRENCI_VEREM ILAC_DIRENCI_VEREM;
        }
        public class VEREM_TEDAVI_SONUCU_BILGISI
        {
            public VEREM_TEDAVI_SONUCU VEREM_TEDAVI_SONUCU;
        }

        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                VeremVeriSeti verem = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as VeremVeriSeti;
                if (verem == null)
                    throw new Exception("'250' paketini göndermek için " + InternalObjectId + " ObjectId'li VeremVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                _recordData.VEREM.BCG_SKAR_SAYISI = new BCG_SKAR_SAYISI();
                _recordData.VEREM.BCG_SKAR_SAYISI.value = verem.BcgSkarSayisi != null ? verem.BcgSkarSayisi.ToString() : string.Empty;
                _recordData.VEREM.TUBERKULIN_DERI_TESTI_SONUCU = new TUBERKULIN_DERI_TESTI_SONUCU();
                _recordData.VEREM.TUBERKULIN_DERI_TESTI_SONUCU.value = verem.TuberkulinDeriTestiSonuc!= null ? verem.TuberkulinDeriTestiSonuc.ToString() : string.Empty;

                if (verem.SKRSDGTUygulamasiniYapanKisi != null)
                    _recordData.VEREM.DGT_UYGULAMASINI_YAPAN_KISI = new DGT_UYGULAMASINI_YAPAN_KISI(verem.SKRSDGTUygulamasiniYapanKisi.KODU, verem.SKRSDGTUygulamasiniYapanKisi.ADI);
                if (verem.SKRSDGTUygulamaYeri != null)
                    _recordData.VEREM.DGT_UYGULAMA_YERI = new DGT_UYGULAMA_YERI(verem.SKRSDGTUygulamaYeri.KODU, verem.SKRSDGTUygulamaYeri.ADI);
                if (verem.SKRSHastaninTedaviyeUyumu != null)
                    _recordData.VEREM.HASTANIN_TEDAVIYE_UYUMU = new HASTANIN_TEDAVIYE_UYUMU(verem.SKRSHastaninTedaviyeUyumu.KODU, verem.SKRSHastaninTedaviyeUyumu.ADI);
                if (verem.SKRSKulturSonucu != null)
                    _recordData.VEREM.KULTUR_SONUCU = new KULTUR_SONUCU(verem.SKRSKulturSonucu.KODU, verem.SKRSKulturSonucu.ADI);
                if (verem.SKRSVeremHastasiTedaviYontemi != null)
                    _recordData.VEREM.VEREM_HASTASI_TEDAVI_YONTEMI = new VEREM_HASTASI_TEDAVI_YONTEMI(verem.SKRSVeremHastasiTedaviYontemi.KODU, verem.SKRSVeremHastasiTedaviYontemi.ADI);
                if (verem.SKRSVeremOlguTanimi != null)
                    _recordData.VEREM.VEREM_OLGU_TANIMI = new VEREM_OLGU_TANIMI(verem.SKRSVeremOlguTanimi.KODU, verem.SKRSVeremOlguTanimi.ADI);
                if (verem.SKRSYaymaSonucu != null)
                    _recordData.VEREM.YAYMA_SONUCU = new YAYMA_SONUCU(verem.SKRSYaymaSonucu.KODU, verem.SKRSYaymaSonucu.ADI);

                if (verem.VeremHastalikTutumYeri.Count > 0)
                    _recordData.VEREM.VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI = new List<VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI>();
                foreach(VeremHastalikTutumYeri tutumYeri in verem.VeremHastalikTutumYeri)
                {
                    VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI tutumYeriBilgisi = new VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI();
                    tutumYeriBilgisi.VEREM_HASTALIGININ_TUTULUM_YERI = new VEREM_HASTALIGININ_TUTULUM_YERI(tutumYeri.SKRSVeremHastaligiTutulumYeri.KODU, tutumYeri.SKRSVeremHastaligiTutulumYeri.ADI);
                    _recordData.VEREM.VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI.Add(tutumYeriBilgisi);
                }

                if (verem.VeremIlacBilgisi.Count > 0)
                    _recordData.VEREM.VEREM_ILAC_BILGISI = new List<VEREM_ILAC_BILGISI>();
                foreach (VeremIlacBilgisi ilacBilgisi in verem.VeremIlacBilgisi)
                {
                    VEREM_ILAC_BILGISI veremIlacBilgisi = new VEREM_ILAC_BILGISI();
                    veremIlacBilgisi.ILAC_ADI_VEREM = new ILAC_ADI_VEREM(ilacBilgisi.SKRSIlacAdiVerem.KODU, ilacBilgisi.SKRSIlacAdiVerem.ADI);
                    veremIlacBilgisi.ILAC_DIRENCI_VEREM = new ILAC_DIRENCI_VEREM(ilacBilgisi.SKRSIlacDirenciVerem.KODU, ilacBilgisi.SKRSIlacDirenciVerem.ADI);
                    _recordData.VEREM.VEREM_ILAC_BILGISI.Add(veremIlacBilgisi);
                }

                if (verem.VeremKlinikOrnegi.Count > 0)
                    _recordData.VEREM.VEREM_HASTASI_KLINIK_ORNEGI_BILGISI = new List<VEREM_HASTASI_KLINIK_ORNEGI_BILGISI>();
                foreach (VeremKlinikOrnegi klinikOrnegi in verem.VeremKlinikOrnegi)
                {
                    VEREM_HASTASI_KLINIK_ORNEGI_BILGISI klinikOrnegiBilgisi = new VEREM_HASTASI_KLINIK_ORNEGI_BILGISI();
                    klinikOrnegiBilgisi.VEREM_HASTASI_KLINIK_ORNEGI = new VEREM_HASTASI_KLINIK_ORNEGI(klinikOrnegi.SKRSVeremHastasiKlinikOrnegi.KODU, klinikOrnegi.SKRSVeremHastasiKlinikOrnegi.ADI);
                    _recordData.VEREM.VEREM_HASTASI_KLINIK_ORNEGI_BILGISI.Add(klinikOrnegiBilgisi);
                }

                if (verem.VeremTedaviSonucBilgisi.Count > 0)
                    _recordData.VEREM.VEREM_TEDAVI_SONUCU_BILGISI = new List<VEREM_TEDAVI_SONUCU_BILGISI>();
                foreach (VeremTedaviSonucBilgisi sonucBilgisi in verem.VeremTedaviSonucBilgisi)
                {
                    VEREM_TEDAVI_SONUCU_BILGISI tedaviSonucBilgisi = new VEREM_TEDAVI_SONUCU_BILGISI();
                    tedaviSonucBilgisi.VEREM_TEDAVI_SONUCU = new VEREM_TEDAVI_SONUCU(sonucBilgisi.SKRSVeremTedaviSonucu.KODU, sonucBilgisi.SKRSVeremTedaviSonucu.ADI);
                    _recordData.VEREM.VEREM_TEDAVI_SONUCU_BILGISI.Add(tedaviSonucBilgisi);
                }

                if (verem.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = verem.SubEpisode.SYSTakipNo;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }

        public static SYSMessage GetDummy()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                VeremVeriSeti verem = objectContext.GetObject(new Guid("6eecc716-35bb-4d0b-a18d-6d01420dcf68"), "VEREMVERISETI") as VeremVeriSeti;
                if (verem == null)
                    throw new Exception("'250' paketini göndermek için " + "7971496e-aee6-4aa3-8075-216ea29cbc9f" + " ObjectId'li VeremVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                _recordData.VEREM.BCG_SKAR_SAYISI = new BCG_SKAR_SAYISI();
                _recordData.VEREM.BCG_SKAR_SAYISI.value = verem.BcgSkarSayisi != null ? verem.BcgSkarSayisi.ToString() : string.Empty;
                _recordData.VEREM.TUBERKULIN_DERI_TESTI_SONUCU = new TUBERKULIN_DERI_TESTI_SONUCU();
                _recordData.VEREM.TUBERKULIN_DERI_TESTI_SONUCU.value = verem.TuberkulinDeriTestiSonuc != null ? verem.TuberkulinDeriTestiSonuc.ToString() : string.Empty;

                if (verem.SKRSDGTUygulamasiniYapanKisi != null)
                    _recordData.VEREM.DGT_UYGULAMASINI_YAPAN_KISI = new DGT_UYGULAMASINI_YAPAN_KISI(verem.SKRSDGTUygulamasiniYapanKisi.KODU, verem.SKRSDGTUygulamasiniYapanKisi.ADI);
                if (verem.SKRSDGTUygulamaYeri != null)
                    _recordData.VEREM.DGT_UYGULAMA_YERI = new DGT_UYGULAMA_YERI(verem.SKRSDGTUygulamaYeri.KODU, verem.SKRSDGTUygulamaYeri.ADI);
                if (verem.SKRSHastaninTedaviyeUyumu != null)
                    _recordData.VEREM.HASTANIN_TEDAVIYE_UYUMU = new HASTANIN_TEDAVIYE_UYUMU(verem.SKRSHastaninTedaviyeUyumu.KODU, verem.SKRSHastaninTedaviyeUyumu.ADI);
                if (verem.SKRSKulturSonucu != null)
                    _recordData.VEREM.KULTUR_SONUCU = new KULTUR_SONUCU(verem.SKRSKulturSonucu.KODU, verem.SKRSKulturSonucu.ADI);
                if (verem.SKRSVeremHastasiTedaviYontemi != null)
                    _recordData.VEREM.VEREM_HASTASI_TEDAVI_YONTEMI = new VEREM_HASTASI_TEDAVI_YONTEMI(verem.SKRSVeremHastasiTedaviYontemi.KODU, verem.SKRSVeremHastasiTedaviYontemi.ADI);
                if (verem.SKRSVeremOlguTanimi != null)
                    _recordData.VEREM.VEREM_OLGU_TANIMI = new VEREM_OLGU_TANIMI(verem.SKRSVeremOlguTanimi.KODU, verem.SKRSVeremOlguTanimi.ADI);
                if (verem.SKRSYaymaSonucu != null)
                    _recordData.VEREM.YAYMA_SONUCU = new YAYMA_SONUCU(verem.SKRSYaymaSonucu.KODU, verem.SKRSYaymaSonucu.ADI);

                if (verem.VeremHastalikTutumYeri.Count > 0)
                    _recordData.VEREM.VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI = new List<VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI>();
                foreach (VeremHastalikTutumYeri tutumYeri in verem.VeremHastalikTutumYeri)
                {
                    VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI tutumYeriBilgisi = new VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI();
                    tutumYeriBilgisi.VEREM_HASTALIGININ_TUTULUM_YERI = new VEREM_HASTALIGININ_TUTULUM_YERI(tutumYeri.SKRSVeremHastaligiTutulumYeri.KODU, tutumYeri.SKRSVeremHastaligiTutulumYeri.ADI);
                    _recordData.VEREM.VEREM_HASTALIGININ_TUTULUM_YERI_BILGISI.Add(tutumYeriBilgisi);
                }

                if (verem.VeremIlacBilgisi.Count > 0)
                    _recordData.VEREM.VEREM_ILAC_BILGISI = new List<VEREM_ILAC_BILGISI>();
                foreach (VeremIlacBilgisi ilacBilgisi in verem.VeremIlacBilgisi)
                {
                    VEREM_ILAC_BILGISI veremIlacBilgisi = new VEREM_ILAC_BILGISI();
                    veremIlacBilgisi.ILAC_ADI_VEREM = new ILAC_ADI_VEREM(ilacBilgisi.SKRSIlacAdiVerem.KODU, ilacBilgisi.SKRSIlacAdiVerem.ADI);
                    veremIlacBilgisi.ILAC_DIRENCI_VEREM = new ILAC_DIRENCI_VEREM(ilacBilgisi.SKRSIlacDirenciVerem.KODU, ilacBilgisi.SKRSIlacDirenciVerem.ADI);
                    _recordData.VEREM.VEREM_ILAC_BILGISI.Add(veremIlacBilgisi);
                }

                if (verem.VeremKlinikOrnegi.Count > 0)
                    _recordData.VEREM.VEREM_HASTASI_KLINIK_ORNEGI_BILGISI = new List<VEREM_HASTASI_KLINIK_ORNEGI_BILGISI>();
                foreach (VeremKlinikOrnegi klinikOrnegi in verem.VeremKlinikOrnegi)
                {
                    VEREM_HASTASI_KLINIK_ORNEGI_BILGISI klinikOrnegiBilgisi = new VEREM_HASTASI_KLINIK_ORNEGI_BILGISI();
                    klinikOrnegiBilgisi.VEREM_HASTASI_KLINIK_ORNEGI = new VEREM_HASTASI_KLINIK_ORNEGI(klinikOrnegi.SKRSVeremHastasiKlinikOrnegi.KODU, klinikOrnegi.SKRSVeremHastasiKlinikOrnegi.ADI);
                    _recordData.VEREM.VEREM_HASTASI_KLINIK_ORNEGI_BILGISI.Add(klinikOrnegiBilgisi);
                }

                if (verem.VeremTedaviSonucBilgisi.Count > 0)
                    _recordData.VEREM.VEREM_TEDAVI_SONUCU_BILGISI = new List<VEREM_TEDAVI_SONUCU_BILGISI>();
                foreach (VeremTedaviSonucBilgisi sonucBilgisi in verem.VeremTedaviSonucBilgisi)
                {
                    VEREM_TEDAVI_SONUCU_BILGISI tedaviSonucBilgisi = new VEREM_TEDAVI_SONUCU_BILGISI();
                    tedaviSonucBilgisi.VEREM_TEDAVI_SONUCU = new VEREM_TEDAVI_SONUCU(sonucBilgisi.SKRSVeremTedaviSonucu.KODU, sonucBilgisi.SKRSVeremTedaviSonucu.ADI);
                    _recordData.VEREM.VEREM_TEDAVI_SONUCU_BILGISI.Add(tedaviSonucBilgisi);
                }

                
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }
    }
}
