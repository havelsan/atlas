using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz230_IntiharGirisimiveKrizTespitVeriSeti
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
                messageType.code = "230";
                messageType.value = "Intihar Girisimi ve Kriz Tespit Veri Seti";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public INTIHAR_GIRISIMI_VE_KRIZ_TESPIT INTIHAR_GIRISIMI_VE_KRIZ_TESPIT = new INTIHAR_GIRISIMI_VE_KRIZ_TESPIT();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class INTIHAR_GIRISIMI_VE_KRIZ_TESPIT
        {
            public AILESINDE_INTIHAR_GIRISIMI AILESINDE_INTIHAR_GIRISIMI;
            public AILESINDE_PSIKIYATRIK_VAKA AILESINDE_PSIKIYATRIK_VAKA = new AILESINDE_PSIKIYATRIK_VAKA();        //zorunlu
            public INTIHAR_GIRISIMI_GECMISI INTIHAR_GIRISIMI_GECMISI;
            public INTIHAR_KRIZ_VAKA_TURU INTIHAR_KRIZ_VAKA_TURU = new INTIHAR_KRIZ_VAKA_TURU();                //zorunlu
            public OLAY_ZAMANI OLAY_ZAMANI;
            public PSIKIYATRIK_TEDAVI_GECMISI PSIKIYATRIK_TEDAVI_GECMISI;
            [System.Xml.Serialization.XmlElement("INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI", Type = typeof(INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI))]
            public List<INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI> INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI = new List<INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI>();    //zorunlu
            [System.Xml.Serialization.XmlElement("INTIHAR_GIRISIMI_YONTEMI_BILGISI", Type = typeof(INTIHAR_GIRISIMI_YONTEMI_BILGISI))]
            public List<INTIHAR_GIRISIMI_YONTEMI_BILGISI> INTIHAR_GIRISIMI_YONTEMI_BILGISI;
            [System.Xml.Serialization.XmlElement("INTIHAR_KRIZ_VAKA_SONUCU_BILGISI", Type = typeof(INTIHAR_KRIZ_VAKA_SONUCU_BILGISI))]
            public List<INTIHAR_KRIZ_VAKA_SONUCU_BILGISI> INTIHAR_KRIZ_VAKA_SONUCU_BILGISI = new List<INTIHAR_KRIZ_VAKA_SONUCU_BILGISI>();      //zorunlu
            [System.Xml.Serialization.XmlElement("PSIKIYATRIK_TANI_GECMISI_BILGISI", Type = typeof(PSIKIYATRIK_TANI_GECMISI_BILGISI))]
            public List<PSIKIYATRIK_TANI_GECMISI_BILGISI> PSIKIYATRIK_TANI_GECMISI_BILGISI;
        }

        public class INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI
        {
            public INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI;
        }

        public class INTIHAR_GIRISIMI_YONTEMI_BILGISI
        {
            public INTIHAR_GIRISIMI_YONTEMI INTIHAR_GIRISIMI_YONTEMI;
        }

        public class INTIHAR_KRIZ_VAKA_SONUCU_BILGISI
        {
            public INTIHAR_KRIZ_VAKA_SONUCU INTIHAR_KRIZ_VAKA_SONUCU;
        }

        public class PSIKIYATRIK_TANI_GECMISI_BILGISI
        {
            public PSIKIYATRIK_TANI_GECMISI PSIKIYATRIK_TANI_GECMISI;
        }

        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                IntiharGirisimKrizVeriSeti intiharGirisimKrizVeriSeti = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as IntiharGirisimKrizVeriSeti;
                if (intiharGirisimKrizVeriSeti == null)
                    throw new Exception("'230' paketini göndermek için " + InternalObjectId + " ObjectId'li IntiharGirisimKrizVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                if (intiharGirisimKrizVeriSeti.SKRSAilesindeIntiharGirisimi != null)
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.AILESINDE_INTIHAR_GIRISIMI = new AILESINDE_INTIHAR_GIRISIMI(intiharGirisimKrizVeriSeti.SKRSAilesindeIntiharGirisimi.KODU, intiharGirisimKrizVeriSeti.SKRSAilesindeIntiharGirisimi.ADI);

                if (intiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka != null)
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.AILESINDE_PSIKIYATRIK_VAKA = new AILESINDE_PSIKIYATRIK_VAKA(intiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka.KODU, intiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka.ADI);

                if (intiharGirisimKrizVeriSeti.SKRSIntiharGirisimiGecmisi != null)
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_GIRISIMI_GECMISI = new INTIHAR_GIRISIMI_GECMISI(intiharGirisimKrizVeriSeti.SKRSIntiharGirisimiGecmisi.KODU, intiharGirisimKrizVeriSeti.SKRSIntiharGirisimiGecmisi.ADI);

                if (intiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru != null)
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_KRIZ_VAKA_TURU = new INTIHAR_KRIZ_VAKA_TURU(intiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru.KODU, intiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru.ADI);

                if (intiharGirisimKrizVeriSeti.SKRSPsikiyatrikTedaviGecmisi != null)
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.PSIKIYATRIK_TEDAVI_GECMISI = new PSIKIYATRIK_TEDAVI_GECMISI(intiharGirisimKrizVeriSeti.SKRSPsikiyatrikTedaviGecmisi.KODU, intiharGirisimKrizVeriSeti.SKRSPsikiyatrikTedaviGecmisi.ADI);
                
                if (intiharGirisimKrizVeriSeti.OlayZamani != null)
                {
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.OLAY_ZAMANI = new OLAY_ZAMANI(); 
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.OLAY_ZAMANI.value = ((DateTime)intiharGirisimKrizVeriSeti.OlayZamani).ToString("yyyyMMddHHmm");
                }



                if (intiharGirisimKrizVeriSeti.IntiharGirisimiKrizNedeni != null)
                {
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI = new List<INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI>();
                    foreach (IntiharGirisimiKrizNedeni krizNedeni in intiharGirisimKrizVeriSeti.IntiharGirisimiKrizNedeni)
                    {
                        INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI krizNedeniBilgisi = new INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI();
                       krizNedeniBilgisi.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI = new INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI(krizNedeni.SKRSIntiharGirisimKrizNeden.KODU, krizNedeni.SKRSIntiharGirisimKrizNeden.ADI);
                        _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI.Add(krizNedeniBilgisi);
                    }
                }

                if (intiharGirisimKrizVeriSeti.IntiharGirisimiVakaSonucu != null)
                {
                    foreach (IntiharGirisimiVakaSonucu vakaSonucu in intiharGirisimKrizVeriSeti.IntiharGirisimiVakaSonucu)
                    {
                        INTIHAR_KRIZ_VAKA_SONUCU_BILGISI vakaSonucuBilgisi = new INTIHAR_KRIZ_VAKA_SONUCU_BILGISI();
                        vakaSonucuBilgisi.INTIHAR_KRIZ_VAKA_SONUCU = new INTIHAR_KRIZ_VAKA_SONUCU(vakaSonucu.SKRSIntiharKrizVakaSonucu.KODU, vakaSonucu.SKRSIntiharKrizVakaSonucu.ADI);
                        _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_KRIZ_VAKA_SONUCU_BILGISI.Add(vakaSonucuBilgisi);
                    }
                }

                if (intiharGirisimKrizVeriSeti.IntiharGirisimiYontemi != null)
                {
                    foreach (IntiharGirisimiYontemi girisimYontemi in intiharGirisimKrizVeriSeti.IntiharGirisimiYontemi)
                    {
                        INTIHAR_GIRISIMI_YONTEMI_BILGISI girisimYontemiBilgisi = new INTIHAR_GIRISIMI_YONTEMI_BILGISI();
                        girisimYontemiBilgisi.INTIHAR_GIRISIMI_YONTEMI = new INTIHAR_GIRISIMI_YONTEMI(girisimYontemi.SKRSIntiharGirisimiYontemiICD.KODU, girisimYontemi.SKRSIntiharGirisimiYontemiICD.ADI);
                        _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_GIRISIMI_YONTEMI_BILGISI.Add(girisimYontemiBilgisi);
                    }
                }

                if (intiharGirisimKrizVeriSeti.IntiharGirisimPsikiyatTani != null)
                {
                    foreach (IntiharGirisimPsikiyatTani psikiyatrikTani in intiharGirisimKrizVeriSeti.IntiharGirisimPsikiyatTani)
                    {
                        PSIKIYATRIK_TANI_GECMISI_BILGISI psikiyatrikTaniGecmisiBilgisi = new PSIKIYATRIK_TANI_GECMISI_BILGISI();
                        psikiyatrikTaniGecmisiBilgisi.PSIKIYATRIK_TANI_GECMISI = new PSIKIYATRIK_TANI_GECMISI(psikiyatrikTani.PsikiyatrikTaniGecmisi.KODU, psikiyatrikTani.PsikiyatrikTaniGecmisi.ADI);
                        _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.PSIKIYATRIK_TANI_GECMISI_BILGISI.Add(psikiyatrikTaniGecmisiBilgisi);
                    }
                }

                if (intiharGirisimKrizVeriSeti.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = intiharGirisimKrizVeriSeti.SubEpisode.SYSTakipNo;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }

        public static SYSMessage GetDummy()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                IntiharGirisimKrizVeriSeti intiharGirisimKrizVeriSeti = objectContext.GetObject(new Guid("b6700e03-26be-4189-a8a3-1d28c7d75ac0"), "INTIHARGIRISIMKRIZVERISETI") as IntiharGirisimKrizVeriSeti;
                if (intiharGirisimKrizVeriSeti == null)
                    throw new Exception("'230' paketini göndermek için " + "b6700e03-26be-4189-a8a3-1d28c7d75ac0" + " ObjectId'li IntiharGirisimKrizVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                if (intiharGirisimKrizVeriSeti.SKRSAilesindeIntiharGirisimi != null)
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.AILESINDE_INTIHAR_GIRISIMI = new AILESINDE_INTIHAR_GIRISIMI(intiharGirisimKrizVeriSeti.SKRSAilesindeIntiharGirisimi.KODU, intiharGirisimKrizVeriSeti.SKRSAilesindeIntiharGirisimi.ADI);

                if (intiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka != null)
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.AILESINDE_PSIKIYATRIK_VAKA = new AILESINDE_PSIKIYATRIK_VAKA(intiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka.KODU, intiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka.ADI);

                if (intiharGirisimKrizVeriSeti.SKRSIntiharGirisimiGecmisi != null)
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_GIRISIMI_GECMISI = new INTIHAR_GIRISIMI_GECMISI(intiharGirisimKrizVeriSeti.SKRSIntiharGirisimiGecmisi.KODU, intiharGirisimKrizVeriSeti.SKRSIntiharGirisimiGecmisi.ADI);

                if (intiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru != null)
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_KRIZ_VAKA_TURU = new INTIHAR_KRIZ_VAKA_TURU(intiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru.KODU, intiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru.ADI);

                if (intiharGirisimKrizVeriSeti.SKRSPsikiyatrikTedaviGecmisi != null)
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.PSIKIYATRIK_TEDAVI_GECMISI = new PSIKIYATRIK_TEDAVI_GECMISI(intiharGirisimKrizVeriSeti.SKRSPsikiyatrikTedaviGecmisi.KODU, intiharGirisimKrizVeriSeti.SKRSPsikiyatrikTedaviGecmisi.ADI);

                if (intiharGirisimKrizVeriSeti.OlayZamani != null)
                {
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.OLAY_ZAMANI = new OLAY_ZAMANI();
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.OLAY_ZAMANI.value = ((DateTime)intiharGirisimKrizVeriSeti.OlayZamani).ToString("yyyyMMddHHmm");
                }



                if (intiharGirisimKrizVeriSeti.IntiharGirisimiKrizNedeni != null)
                {
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI = new List<INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI>();
                    foreach (IntiharGirisimiKrizNedeni krizNedeni in intiharGirisimKrizVeriSeti.IntiharGirisimiKrizNedeni)
                    {
                        INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI krizNedeniBilgisi = new INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI();
                        krizNedeniBilgisi.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI = new INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI(krizNedeni.SKRSIntiharGirisimKrizNeden.KODU, krizNedeni.SKRSIntiharGirisimKrizNeden.ADI);
                        _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI.Add(krizNedeniBilgisi);
                    }
                }

                if (intiharGirisimKrizVeriSeti.IntiharGirisimiVakaSonucu != null)
                {
                    foreach (IntiharGirisimiVakaSonucu vakaSonucu in intiharGirisimKrizVeriSeti.IntiharGirisimiVakaSonucu)
                    {
                        INTIHAR_KRIZ_VAKA_SONUCU_BILGISI vakaSonucuBilgisi = new INTIHAR_KRIZ_VAKA_SONUCU_BILGISI();
                        vakaSonucuBilgisi.INTIHAR_KRIZ_VAKA_SONUCU = new INTIHAR_KRIZ_VAKA_SONUCU(vakaSonucu.SKRSIntiharKrizVakaSonucu.KODU, vakaSonucu.SKRSIntiharKrizVakaSonucu.ADI);
                        _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_KRIZ_VAKA_SONUCU_BILGISI.Add(vakaSonucuBilgisi);
                    }
                }

                if (intiharGirisimKrizVeriSeti.IntiharGirisimiYontemi != null)
                {
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_GIRISIMI_YONTEMI_BILGISI = new List<INTIHAR_GIRISIMI_YONTEMI_BILGISI>();
                    foreach (IntiharGirisimiYontemi girisimYontemi in intiharGirisimKrizVeriSeti.IntiharGirisimiYontemi)
                    {
                        INTIHAR_GIRISIMI_YONTEMI_BILGISI girisimYontemiBilgisi = new INTIHAR_GIRISIMI_YONTEMI_BILGISI();
                        girisimYontemiBilgisi.INTIHAR_GIRISIMI_YONTEMI = new INTIHAR_GIRISIMI_YONTEMI(girisimYontemi.SKRSIntiharGirisimiYontemiICD.KODU, girisimYontemi.SKRSIntiharGirisimiYontemiICD.ADI);
                        _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.INTIHAR_GIRISIMI_YONTEMI_BILGISI.Add(girisimYontemiBilgisi);
                    }
                }

                if (intiharGirisimKrizVeriSeti.IntiharGirisimPsikiyatTani != null)
                {
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.PSIKIYATRIK_TANI_GECMISI_BILGISI = new List<PSIKIYATRIK_TANI_GECMISI_BILGISI>();
                    foreach (IntiharGirisimPsikiyatTani psikiyatrikTani in intiharGirisimKrizVeriSeti.IntiharGirisimPsikiyatTani)
                    {
                        PSIKIYATRIK_TANI_GECMISI_BILGISI psikiyatrikTaniGecmisiBilgisi = new PSIKIYATRIK_TANI_GECMISI_BILGISI();
                        psikiyatrikTaniGecmisiBilgisi.PSIKIYATRIK_TANI_GECMISI = new PSIKIYATRIK_TANI_GECMISI(psikiyatrikTani.PsikiyatrikTaniGecmisi.KODU, psikiyatrikTani.PsikiyatrikTaniGecmisi.ADI);
                        _recordData.INTIHAR_GIRISIMI_VE_KRIZ_TESPIT.PSIKIYATRIK_TANI_GECMISI_BILGISI.Add(psikiyatrikTaniGecmisiBilgisi);
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
