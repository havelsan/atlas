using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz209_BebekCocukIzlemVeriSeti
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
                messageType.code = "209";
                messageType.value = TTUtils.CultureService.GetText("M25262", "Bebek / Cocuk Izlem Veri Seti");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public BEBEK_COCUK_IZLEM_VERI_SETI BEBEK_COCUK_IZLEM_VERI_SETI = new BEBEK_COCUK_IZLEM_VERI_SETI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class BEBEK_COCUK_IZLEM_VERI_SETI
        {
            //public AGIZDAN_SIVI_TEDAVISI AGIZDAN_SIVI_TEDAVISI;
            public BAS_CEVRESI BAS_CEVRESI;
            public DEMIR_LOJISTIGI_VE_DESTEGI DEMIR_LOJISTIGI_VE_DESTEGI = new DEMIR_LOJISTIGI_VE_DESTEGI();//Zorunlu
            public DOGUM_AGIRLIGI DOGUM_AGIRLIGI;
            public D_VITAMINI_LOJISTIGI_VE_DESTEGI D_VITAMINI_LOJISTIGI_VE_DESTEGI = new D_VITAMINI_LOJISTIGI_VE_DESTEGI();//Zorunlu
            public HEMATOKRIT HEMATOKRIT;
            public HEMOGLOBIN HEMOGLOBIN;
            public KACINCI_IZLEM KACINCI_IZLEM = new KACINCI_IZLEM();//Zorunlu
            //public TOPUK_KANI TOPUK_KANI;
            //public TOPUK_KANI_ALINMA_ZAMANI TOPUK_KANI_ALINMA_ZAMANI;
            //public IZLEMIN_YAPILDIGI_YER IZLEMIN_YAPILDIGI_YER;
            //public ISLEM_YAPAN ISLEM_YAPAN;
            //public BILGI_ALINAN_KISI_ADI_SOYADI BILGI_ALINAN_KISI_ADI_SOYADI;
            //public BILGI_ALINAN_KISI_TEL BILGI_ALINAN_KISI_TEL;
            //public BEBEKTE_RISK_FAKTORLERI_BILGISI BEBEKTE_RISK_FAKTORLERI_BILGISI = new BEBEKTE_RISK_FAKTORLERI_BILGISI(); //Zorunlu
            //public TARAMA_SONUCU_BILGISI TARAMA_SONUCU_BILGISI;
            public BOY_KILO_BILGILERI BOY_KILO_BILGILERI;
            public GKD_TARAMA_SONUCU GKD_TARAMA_SONUCU;
            public GORME_TARAMA_SONUCU GORME_TARAMA_SONUCU;
            public BEBEGIN_BESLENME_DURUMU BEBEGIN_BESLENME_DURUMU;
            public NTP_TAKIP_BILGISI NTP_TAKIP_BILGISI;
            public IZLEM_ISLEM_TURU IZLEM_ISLEM_TURU;//Zorunlu
        

        }

        public class BEBEKTE_RISK_FAKTORLERI_BILGISI
        {
            [System.Xml.Serialization.XmlElement("BEBEKTE_RISK_FAKTORLERI", Type = typeof(BEBEKTE_RISK_FAKTORLERI))]
            public List<BEBEKTE_RISK_FAKTORLERI>  BEBEKTE_RISK_FAKTORLERI = new List<BEBEKTE_RISK_FAKTORLERI>();
        }
        public class TARAMA_SONUCU_BILGISI
        {
            public TARAMA_SONUCU TARAMA_SONUCU; //Dokumanda 3 adet var
        }

        public class BOY_KILO_BILGILERI
        {
            public BOY BOY = new BOY();
            public KILO KILO = new KILO();

        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName, Guid SubEpisodeObjectId)
        {
            //TODO Lohusa ekranları yapıldıktan sonra eklenecek
            //GKD Tarama
            //Görme Tarama
            //Bebeğin beslenme durumu  durumu
            //ntp takip
            //izlem işlem durumu alanlar ekrana eklendikten sonra pakede eklenecektir.
            using (var objectContext = new TTObjectContext(false))
            {

                recordData _recordData = new recordData();

                ChildGrowthVisits childGrowth = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as ChildGrowthVisits;
                if (childGrowth != null)
                {
                    if (!childGrowth.IsCancelled)
                    {
                        SubEpisode se = (SubEpisode)objectContext.GetObject(SubEpisodeObjectId, "SUBEPISODE");
                        if (se != null)
                        {
                            if (se.SYSTakipNo == null)
                                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                            else
                                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = se.SYSTakipNo;


                            BEBEK_COCUK_IZLEM_VERI_SETI BEBEK_COCUK_IZLEM_VERI_SETI = new BEBEK_COCUK_IZLEM_VERI_SETI();

                            if (childGrowth.IronSupplementationInfo != null)
                            {
                                DEMIR_LOJISTIGI_VE_DESTEGI demirLojistigi = new DEMIR_LOJISTIGI_VE_DESTEGI(childGrowth.IronSupplementationInfo.KODU, childGrowth.IronSupplementationInfo.ADI);
                                BEBEK_COCUK_IZLEM_VERI_SETI.DEMIR_LOJISTIGI_VE_DESTEGI = demirLojistigi;
                            }

                            if (childGrowth.VitaminDSupplementationInfo != null)
                            {
                                D_VITAMINI_LOJISTIGI_VE_DESTEGI dVitaminiLojistigi = new D_VITAMINI_LOJISTIGI_VE_DESTEGI(childGrowth.VitaminDSupplementationInfo.KODU, childGrowth.VitaminDSupplementationInfo.ADI);
                                BEBEK_COCUK_IZLEM_VERI_SETI.D_VITAMINI_LOJISTIGI_VE_DESTEGI = dVitaminiLojistigi;
                            }

                            //TODO: Ekranda bununla ılgılı alan olmadıgı ıcın 96 PERFORMANS DISI IZLEM degerı gonderıldı sımdılık.
                            
                            BEBEK_COCUK_IZLEM_VERI_SETI.KACINCI_IZLEM = new KACINCI_IZLEM("96", "PERFORMANS DIŞI İZLEM");


                            BEBEKTE_RISK_FAKTORLERI_BILGISI riskFaktorleriBilgisi = new BEBEKTE_RISK_FAKTORLERI_BILGISI();
                            foreach (InfantRiskFactors riskFactor in childGrowth.InfantRiskFactors)
                            {
                                BEBEKTE_RISK_FAKTORLERI riskFaktorleri = new BEBEKTE_RISK_FAKTORLERI(riskFactor.SKRSBebekteRiskFaktorleri.KODU, riskFactor.SKRSBebekteRiskFaktorleri.ADI);
                                riskFaktorleriBilgisi.BEBEKTE_RISK_FAKTORLERI.Add(riskFaktorleri);
                            }

                            //BEBEK_COCUK_IZLEM_VERI_SETI.BEBEKTE_RISK_FAKTORLERI_BILGISI = riskFaktorleriBilgisi;

                            _recordData.BEBEK_COCUK_IZLEM_VERI_SETI = BEBEK_COCUK_IZLEM_VERI_SETI;
                        }
                    }

                }

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }

            
        }

        public static SYSMessage GetDummy()
        {
            //TODO Lohusa ekranları yapıldıktan sonra eklenecek

            using (var objectContext = new TTObjectContext(false))
            {

                recordData _recordData = new recordData();

                ChildGrowthVisits childGrowth = objectContext.GetObject(new Guid("693ef65e-9edb-4801-9d30-40bbb9edf234"), "CHILDGROWTHVISITS") as ChildGrowthVisits;
                if (childGrowth != null)
                {
                    if (!childGrowth.IsCancelled)
                    {
                       
                            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";


                        BEBEK_COCUK_IZLEM_VERI_SETI BEBEK_COCUK_IZLEM_VERI_SETI = new BEBEK_COCUK_IZLEM_VERI_SETI();

                            if (childGrowth.IronSupplementationInfo != null)
                            {
                                DEMIR_LOJISTIGI_VE_DESTEGI demirLojistigi = new DEMIR_LOJISTIGI_VE_DESTEGI(childGrowth.IronSupplementationInfo.KODU, childGrowth.IronSupplementationInfo.ADI);
                                BEBEK_COCUK_IZLEM_VERI_SETI.DEMIR_LOJISTIGI_VE_DESTEGI = demirLojistigi;
                            }

                            if (childGrowth.VitaminDSupplementationInfo != null)
                            {
                                D_VITAMINI_LOJISTIGI_VE_DESTEGI dVitaminiLojistigi = new D_VITAMINI_LOJISTIGI_VE_DESTEGI(childGrowth.VitaminDSupplementationInfo.KODU, childGrowth.VitaminDSupplementationInfo.ADI);
                                BEBEK_COCUK_IZLEM_VERI_SETI.D_VITAMINI_LOJISTIGI_VE_DESTEGI = dVitaminiLojistigi;
                            }

                            //TODO: Ekranda bununla ılgılı alan olmadıgı ıcın 96 PERFORMANS DISI IZLEM degerı gonderıldı sımdılık.

                            BEBEK_COCUK_IZLEM_VERI_SETI.KACINCI_IZLEM = new KACINCI_IZLEM("96", "PERFORMANS DIŞI İZLEM");


                            BEBEKTE_RISK_FAKTORLERI_BILGISI riskFaktorleriBilgisi = new BEBEKTE_RISK_FAKTORLERI_BILGISI();
                            foreach (InfantRiskFactors riskFactor in childGrowth.InfantRiskFactors)
                            {
                                BEBEKTE_RISK_FAKTORLERI riskFaktorleri = new BEBEKTE_RISK_FAKTORLERI(riskFactor.SKRSBebekteRiskFaktorleri.KODU, riskFactor.SKRSBebekteRiskFaktorleri.ADI);
                                riskFaktorleriBilgisi.BEBEKTE_RISK_FAKTORLERI.Add(riskFaktorleri);
                            }

                            //BEBEK_COCUK_IZLEM_VERI_SETI.BEBEKTE_RISK_FAKTORLERI_BILGISI = riskFaktorleriBilgisi;

                            _recordData.BEBEK_COCUK_IZLEM_VERI_SETI = BEBEK_COCUK_IZLEM_VERI_SETI;
                        
                    }

                }

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }


        }
    }
}
