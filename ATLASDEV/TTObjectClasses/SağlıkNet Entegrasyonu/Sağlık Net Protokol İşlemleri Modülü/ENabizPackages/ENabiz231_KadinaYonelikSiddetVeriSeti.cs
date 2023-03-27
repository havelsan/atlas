using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz231_KadinaYonelikSiddetVeriSeti
    {
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
                messageType.code = "231";
                messageType.value = TTUtils.CultureService.GetText("M26256", "Kadina Yonelik Siddet Veri Seti");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public KADINA_YONELIK_SIDDET KADINA_YONELIK_SIDDET = new KADINA_YONELIK_SIDDET();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class KADINA_YONELIK_SIDDET
        {
            [System.Xml.Serialization.XmlElement("KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI", Type = typeof(KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI))]
            public List<KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI> KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI = new List<KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI>();
            [System.Xml.Serialization.XmlElement("SIDDET_TURU_BILGISI", Type = typeof(SIDDET_TURU_BILGISI))]
            public List<SIDDET_TURU_BILGISI> SIDDET_TURU_BILGISI = new List<SIDDET_TURU_BILGISI>();
        }

        public class KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI
        {
            public KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME;
        }

        public class SIDDET_TURU_BILGISI
        {
            public SIDDET_TURU SIDDET_TURU;
        }

        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                KadinaYonelikSiddetVeriSet kadinaYonelikSiddetVeriSet = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as KadinaYonelikSiddetVeriSet;
                if (kadinaYonelikSiddetVeriSet == null)
                    throw new Exception("'231' paketini göndermek için " + InternalObjectId + " ObjectId'li KadinaYonelikSiddetVeriSet Objesi bulunamadı.");

                recordData _recordData = new recordData();

                if(kadinaYonelikSiddetVeriSet.KadinaYonelikSiddetSonuc != null)
                {
                    foreach (KadinaYonelikSiddetSonuc siddetSonucuYonlendirme in kadinaYonelikSiddetVeriSet.KadinaYonelikSiddetSonuc)
                    {
                        KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI siddetSonucuYonlendirmeBilgisi = new KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI();
                        siddetSonucuYonlendirmeBilgisi.KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME = new KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME(siddetSonucuYonlendirme.SKRSYonlendirmeDegerlendirme.KODU, siddetSonucuYonlendirme.SKRSYonlendirmeDegerlendirme.ADI);
                        _recordData.KADINA_YONELIK_SIDDET.KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI.Add(siddetSonucuYonlendirmeBilgisi);
                    }
                }

                if (kadinaYonelikSiddetVeriSet.KadinaYonelikSiddetTuru != null)
                {
                    foreach (KadinaYonelikSiddetTuru siddetTuru in kadinaYonelikSiddetVeriSet.KadinaYonelikSiddetTuru)
                    {
                        SIDDET_TURU_BILGISI siddetTuruBilgisi = new SIDDET_TURU_BILGISI();
                        siddetTuruBilgisi.SIDDET_TURU = new SIDDET_TURU(siddetTuru.SKRSSiddetTuru.KODU, siddetTuru.SKRSSiddetTuru.ADI);
                        _recordData.KADINA_YONELIK_SIDDET.SIDDET_TURU_BILGISI.Add(siddetTuruBilgisi);
                    }
                }

                if (kadinaYonelikSiddetVeriSet.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = kadinaYonelikSiddetVeriSet.SubEpisode.SYSTakipNo;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }

        public static SYSMessage GetDummy()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                KadinaYonelikSiddetVeriSet kadinaYonelikSiddetVeriSet = objectContext.GetObject(new Guid("f6ae5d2b-0326-4fdb-98ce-e81e634f0890"), "KADINAYONELIKSIDDETVERISET") as KadinaYonelikSiddetVeriSet;
                if (kadinaYonelikSiddetVeriSet == null)
                    throw new Exception("'231' paketini göndermek için " + "f6ae5d2b-0326-4fdb-98ce-e81e634f0890" + " ObjectId'li KadinaYonelikSiddetVeriSet Objesi bulunamadı.");

                recordData _recordData = new recordData();

                if (kadinaYonelikSiddetVeriSet.KadinaYonelikSiddetSonuc != null)
                {
                    foreach (KadinaYonelikSiddetSonuc siddetSonucuYonlendirme in kadinaYonelikSiddetVeriSet.KadinaYonelikSiddetSonuc)
                    {
                        KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI siddetSonucuYonlendirmeBilgisi = new KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI();
                        siddetSonucuYonlendirmeBilgisi.KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME = new KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME(siddetSonucuYonlendirme.SKRSYonlendirmeDegerlendirme.KODU, siddetSonucuYonlendirme.SKRSYonlendirmeDegerlendirme.ADI);
                        _recordData.KADINA_YONELIK_SIDDET.KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME_BILGISI.Add(siddetSonucuYonlendirmeBilgisi);
                    }
                }

                if (kadinaYonelikSiddetVeriSet.KadinaYonelikSiddetTuru != null)
                {
                    foreach (KadinaYonelikSiddetTuru siddetTuru in kadinaYonelikSiddetVeriSet.KadinaYonelikSiddetTuru)
                    {
                        SIDDET_TURU_BILGISI siddetTuruBilgisi = new SIDDET_TURU_BILGISI();
                        siddetTuruBilgisi.SIDDET_TURU = new SIDDET_TURU(siddetTuru.SKRSSiddetTuru.KODU, siddetTuru.SKRSSiddetTuru.ADI);
                        _recordData.KADINA_YONELIK_SIDDET.SIDDET_TURU_BILGISI.Add(siddetTuruBilgisi);
                    }
                }

               
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }
    }
}
