using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz219_EvdeSaglikHizmetiIlkIzlem
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
                messageType.code = "219";
                messageType.value = "Evde Saglik Hizmeti Ilk Izlem Veri Seti";
            }

        }
        public class recordData
        {
            public EVDE_SAGLIK_HIZMETI_ILK_IZLEM EVDE_SAGLIK_HIZMETI_ILK_IZLEM = new EVDE_SAGLIK_HIZMETI_ILK_IZLEM();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class EVDE_SAGLIK_HIZMETI_ILK_IZLEM
        {
            public AGRI AGRI = new AGRI();
            public AYDINLATMA AYDINLATMA = new AYDINLATMA();
            public BAKIM_VE_DESTEK_IHTIYACI BAKIM_VE_DESTEK_IHTIYACI = new BAKIM_VE_DESTEK_IHTIYACI();
            public BASI_DEGERLENDIRMESI BASI_DEGERLENDIRMESI = new BASI_DEGERLENDIRMESI();
            public BASVURU_TURU BASVURU_TURU = new BASVURU_TURU();
            public BESLENME BESLENME = new BESLENME();
            public BIR_SONRAKI_HIZMET_IHTIYACI BIR_SONRAKI_HIZMET_IHTIYACI = new BIR_SONRAKI_HIZMET_IHTIYACI();
            public EVDE_SAGLIK_HIZMETINE_ESAS_HASTALIK_GRUBU EVDE_SAGLIK_HIZMETINE_ESAS_HASTALIK_GRUBU = new EVDE_SAGLIK_HIZMETINE_ESAS_HASTALIK_GRUBU();
            public EV_HIJYENI EV_HIJYENI = new EV_HIJYENI();
            public GUVENLIK GUVENLIK = new GUVENLIK();
            public ISINMA ISINMA = new ISINMA();
            public KISISEL_BAKIM KISISEL_BAKIM = new KISISEL_BAKIM();
            public KISISEL_HIJYEN KISISEL_HIJYEN = new KISISEL_HIJYEN();
            public KONUT_TIPI KONUT_TIPI = new KONUT_TIPI();
            public KULLANILAN_HELA_TIPI KULLANILAN_HELA_TIPI = new KULLANILAN_HELA_TIPI();
            public YATAGA_BAGIMLILIK YATAGA_BAGIMLILIK = new YATAGA_BAGIMLILIK();

            [XmlElement("KULLANDIGI_YARDIMCI_ARACLAR_BILGISI", Type = typeof(KULLANDIGI_YARDIMCI_ARACLAR_BILGISI))]
            public List<KULLANDIGI_YARDIMCI_ARACLAR_BILGISI> KULLANDIGI_YARDIMCI_ARACLAR_BILGISI = new List<ENabiz219_EvdeSaglikHizmetiIlkIzlem.KULLANDIGI_YARDIMCI_ARACLAR_BILGISI>();

            public PSIKOLOJIK_DURUM_DEGERLENDIRMESI_BILGISI PSIKOLOJIK_DURUM_DEGERLENDIRMESI_BILGISI = new PSIKOLOJIK_DURUM_DEGERLENDIRMESI_BILGISI();
            public VERILEN_EGITIMLER_BILGISI VERILEN_EGITIMLER_BILGISI =new VERILEN_EGITIMLER_BILGISI();

        }

        public class KULLANDIGI_YARDIMCI_ARACLAR_BILGISI
        {
            public  KULLANDIGI_YARDIMCI_ARACLAR KULLANDIGI_YARDIMCI_ARACLAR;
        }
        public class PSIKOLOJIK_DURUM_DEGERLENDIRMESI_BILGISI
        {
            [XmlElement("PSIKOLOJIK_DURUM_DEGERLENDIRMESI", Type = typeof(PSIKOLOJIK_DURUM_DEGERLENDIRMESI))]
            public List<PSIKOLOJIK_DURUM_DEGERLENDIRMESI> PSIKOLOJIK_DURUM_DEGERLENDIRMESI;
        }
        public class VERILEN_EGITIMLER_BILGISI
        {
            [XmlElement("VERILEN_EGITIMLER", Type = typeof(VERILEN_EGITIMLER))]
            public List<VERILEN_EGITIMLER> VERILEN_EGITIMLER;
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            //InternalObjectGuid bu objec için EvdeSaglikIlkIzlemVeriSeti
            TTObjectContext objectContext = new TTObjectContext(true);
            EvdeSaglikIlkIzlemVeriSeti evdeSaglik = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as EvdeSaglikIlkIzlemVeriSeti;
            if (evdeSaglik == null)
                throw new Exception("'219' paketini göndermek için " + InternalObjectId + " ObjectId'li EvdeSaglikIlkIzlemVeriSeti Objesi bulunamadı");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();

            //Patient patient = bulasiciHastalik.Episode.Patient;

            //EVDE SAGLIK ILK IZLEM
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.AGRI = new AGRI(evdeSaglik.SKRSAgri.KODU,evdeSaglik.SKRSAgri.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.AYDINLATMA = new AYDINLATMA(evdeSaglik.SKRSAydinlatma.KODU, evdeSaglik.SKRSAydinlatma.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.BAKIM_VE_DESTEK_IHTIYACI = new BAKIM_VE_DESTEK_IHTIYACI(evdeSaglik.SKRSBakimveDestekIhtiyaci.KODU, evdeSaglik.SKRSBakimveDestekIhtiyaci.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.BASI_DEGERLENDIRMESI = new BASI_DEGERLENDIRMESI(evdeSaglik.SKRSBasiDegerlendirmesi.KODU, evdeSaglik.SKRSBasiDegerlendirmesi.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.BASVURU_TURU = new BASVURU_TURU(evdeSaglik.SKRSBasvuruTuru.KODU, evdeSaglik.SKRSBasvuruTuru.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.BESLENME = new BESLENME(evdeSaglik.SKRSBeslenme.KODU, evdeSaglik.SKRSBeslenme.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.BIR_SONRAKI_HIZMET_IHTIYACI = new BIR_SONRAKI_HIZMET_IHTIYACI(evdeSaglik.SKRSBirSonrakiHizmetIhtiyaci.KODU, evdeSaglik.SKRSBirSonrakiHizmetIhtiyaci.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.EVDE_SAGLIK_HIZMETINE_ESAS_HASTALIK_GRUBU = new EVDE_SAGLIK_HIZMETINE_ESAS_HASTALIK_GRUBU(evdeSaglik.SKRSICD.KODU, evdeSaglik.SKRSICD.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.EV_HIJYENI = new EV_HIJYENI(evdeSaglik.SKRSEvHijyeni.KODU, evdeSaglik.SKRSEvHijyeni.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.GUVENLIK = new GUVENLIK(evdeSaglik.SKRSGuvenlik.KODU, evdeSaglik.SKRSGuvenlik.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.ISINMA = new ISINMA(evdeSaglik.SKRSIsinma.KODU, evdeSaglik.SKRSIsinma.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.KISISEL_BAKIM = new KISISEL_BAKIM(evdeSaglik.SKRSKisiselBakim.KODU, evdeSaglik.SKRSKisiselBakim.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.KISISEL_HIJYEN = new KISISEL_HIJYEN(evdeSaglik.SKRSKisiselHijyen.KODU, evdeSaglik.SKRSKisiselHijyen.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.KONUT_TIPI = new KONUT_TIPI(evdeSaglik.SKRSKonutTipi.KODU, evdeSaglik.SKRSKonutTipi.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.KULLANILAN_HELA_TIPI = new KULLANILAN_HELA_TIPI(evdeSaglik.SKRSKullanilanHelaTipi.KODU, evdeSaglik.SKRSKullanilanHelaTipi.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.YATAGA_BAGIMLILIK = new YATAGA_BAGIMLILIK(evdeSaglik.SKRSYatagaBagimlilik.KODU, evdeSaglik.SKRSYatagaBagimlilik.ADI);

            KULLANDIGI_YARDIMCI_ARACLAR yardimciAraclar = new KULLANDIGI_YARDIMCI_ARACLAR();
            KULLANDIGI_YARDIMCI_ARACLAR_BILGISI yardimciAraclarBilgisi = new KULLANDIGI_YARDIMCI_ARACLAR_BILGISI();


            foreach (KullandigiYardimciAraclar arac in evdeSaglik.KullandigiYardimciAraclar)
            {
                yardimciAraclarBilgisi = new KULLANDIGI_YARDIMCI_ARACLAR_BILGISI();
                yardimciAraclar = new KULLANDIGI_YARDIMCI_ARACLAR(arac.SKRSKullandigiYardimciAraclar.KODU,arac.SKRSKullandigiYardimciAraclar.ADI);
                yardimciAraclarBilgisi.KULLANDIGI_YARDIMCI_ARACLAR = yardimciAraclar;
                _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.KULLANDIGI_YARDIMCI_ARACLAR_BILGISI.Add(yardimciAraclarBilgisi);
            }
            PSIKOLOJIK_DURUM_DEGERLENDIRMESI psikolojikdurum = new PSIKOLOJIK_DURUM_DEGERLENDIRMESI();
            List<PSIKOLOJIK_DURUM_DEGERLENDIRMESI> psikolojikDurumList = new List<PSIKOLOJIK_DURUM_DEGERLENDIRMESI>();
            foreach (PsikolojikDurum durum in evdeSaglik.PsikolojikDurum)
            {
                
                psikolojikdurum = new PSIKOLOJIK_DURUM_DEGERLENDIRMESI(durum.SKRSPsikolojikDurum.KODU, durum.SKRSPsikolojikDurum.ADI);
                psikolojikDurumList.Add(psikolojikdurum);
               
            }

            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.PSIKOLOJIK_DURUM_DEGERLENDIRMESI_BILGISI.PSIKOLOJIK_DURUM_DEGERLENDIRMESI = psikolojikDurumList;

            VERILEN_EGITIMLER verilenEgitimler = new VERILEN_EGITIMLER();
            List<VERILEN_EGITIMLER> verilenEgitimlerList = new List<VERILEN_EGITIMLER>();
            foreach (VerilenEgitimler egitim in evdeSaglik.VerilenEgitimler)
            {
                verilenEgitimler = new VERILEN_EGITIMLER(egitim.SKRSVerilenEgitimler.KODU, egitim.SKRSVerilenEgitimler.ADI);
                verilenEgitimlerList.Add(verilenEgitimler);
            }

            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.VERILEN_EGITIMLER_BILGISI.VERILEN_EGITIMLER = verilenEgitimlerList;

            if (evdeSaglik.SubEpisode.SYSTakipNo == null)
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = evdeSaglik.SubEpisode.SYSTakipNo;

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            //InternalObjectGuid bu objec için EvdeSaglikIlkIzlemVeriSeti
            TTObjectContext objectContext = new TTObjectContext(true);
            EvdeSaglikIlkIzlemVeriSeti evdeSaglik = objectContext.GetObject(new Guid("2400a67c-15f3-45d0-ba93-45372f15fb86"), "EVDESAGLIKILKIZLEMVERISETI") as EvdeSaglikIlkIzlemVeriSeti;
            if (evdeSaglik == null)
                throw new Exception("'219' paketini göndermek için \"2400a67c-15f3-45d0-ba93-45372f15fb86\" ObjectId'li EvdeSaglikIlkIzlemVeriSeti Objesi bulunamadı");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();

            //Patient patient = bulasiciHastalik.Episode.Patient;

            //EVDE SAGLIK ILK IZLEM
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.AGRI = new AGRI(evdeSaglik.SKRSAgri.KODU, evdeSaglik.SKRSAgri.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.AYDINLATMA = new AYDINLATMA(evdeSaglik.SKRSAydinlatma.KODU, evdeSaglik.SKRSAydinlatma.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.BAKIM_VE_DESTEK_IHTIYACI = new BAKIM_VE_DESTEK_IHTIYACI(evdeSaglik.SKRSBakimveDestekIhtiyaci.KODU, evdeSaglik.SKRSBakimveDestekIhtiyaci.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.BASI_DEGERLENDIRMESI = new BASI_DEGERLENDIRMESI(evdeSaglik.SKRSBasiDegerlendirmesi.KODU, evdeSaglik.SKRSBasiDegerlendirmesi.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.BASVURU_TURU = new BASVURU_TURU(evdeSaglik.SKRSBasvuruTuru.KODU, evdeSaglik.SKRSBasvuruTuru.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.BESLENME = new BESLENME(evdeSaglik.SKRSBeslenme.KODU, evdeSaglik.SKRSBeslenme.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.BIR_SONRAKI_HIZMET_IHTIYACI = new BIR_SONRAKI_HIZMET_IHTIYACI(evdeSaglik.SKRSBirSonrakiHizmetIhtiyaci.KODU, evdeSaglik.SKRSBirSonrakiHizmetIhtiyaci.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.EVDE_SAGLIK_HIZMETINE_ESAS_HASTALIK_GRUBU = new EVDE_SAGLIK_HIZMETINE_ESAS_HASTALIK_GRUBU(evdeSaglik.SKRSICD.KODU, evdeSaglik.SKRSICD.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.EV_HIJYENI = new EV_HIJYENI(evdeSaglik.SKRSEvHijyeni.KODU, evdeSaglik.SKRSEvHijyeni.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.GUVENLIK = new GUVENLIK(evdeSaglik.SKRSGuvenlik.KODU, evdeSaglik.SKRSGuvenlik.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.ISINMA = new ISINMA(evdeSaglik.SKRSIsinma.KODU, evdeSaglik.SKRSIsinma.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.KISISEL_BAKIM = new KISISEL_BAKIM(evdeSaglik.SKRSKisiselBakim.KODU, evdeSaglik.SKRSKisiselBakim.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.KISISEL_HIJYEN = new KISISEL_HIJYEN(evdeSaglik.SKRSKisiselHijyen.KODU, evdeSaglik.SKRSKisiselHijyen.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.KONUT_TIPI = new KONUT_TIPI(evdeSaglik.SKRSKonutTipi.KODU, evdeSaglik.SKRSKonutTipi.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.KULLANILAN_HELA_TIPI = new KULLANILAN_HELA_TIPI(evdeSaglik.SKRSKullanilanHelaTipi.KODU, evdeSaglik.SKRSKullanilanHelaTipi.ADI);
            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.YATAGA_BAGIMLILIK = new YATAGA_BAGIMLILIK(evdeSaglik.SKRSYatagaBagimlilik.KODU, evdeSaglik.SKRSYatagaBagimlilik.ADI);

            KULLANDIGI_YARDIMCI_ARACLAR yardimciAraclar = new KULLANDIGI_YARDIMCI_ARACLAR();
            KULLANDIGI_YARDIMCI_ARACLAR_BILGISI yardimciAraclarBilgisi = new KULLANDIGI_YARDIMCI_ARACLAR_BILGISI();


            foreach (KullandigiYardimciAraclar arac in evdeSaglik.KullandigiYardimciAraclar)
            {
                yardimciAraclarBilgisi = new KULLANDIGI_YARDIMCI_ARACLAR_BILGISI();
                yardimciAraclar = new KULLANDIGI_YARDIMCI_ARACLAR(arac.SKRSKullandigiYardimciAraclar.KODU, arac.SKRSKullandigiYardimciAraclar.ADI);
                yardimciAraclarBilgisi.KULLANDIGI_YARDIMCI_ARACLAR = yardimciAraclar;
                _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.KULLANDIGI_YARDIMCI_ARACLAR_BILGISI.Add(yardimciAraclarBilgisi);
            }
            PSIKOLOJIK_DURUM_DEGERLENDIRMESI psikolojikdurum = new PSIKOLOJIK_DURUM_DEGERLENDIRMESI();
            List<PSIKOLOJIK_DURUM_DEGERLENDIRMESI> psikolojikDurumList = new List<PSIKOLOJIK_DURUM_DEGERLENDIRMESI>();
            foreach (PsikolojikDurum durum in evdeSaglik.PsikolojikDurum)
            {

                psikolojikdurum = new PSIKOLOJIK_DURUM_DEGERLENDIRMESI(durum.SKRSPsikolojikDurum.KODU, durum.SKRSPsikolojikDurum.ADI);
                psikolojikDurumList.Add(psikolojikdurum);

            }

            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.PSIKOLOJIK_DURUM_DEGERLENDIRMESI_BILGISI.PSIKOLOJIK_DURUM_DEGERLENDIRMESI = psikolojikDurumList;

            VERILEN_EGITIMLER verilenEgitimler = new VERILEN_EGITIMLER();
            List<VERILEN_EGITIMLER> verilenEgitimlerList = new List<VERILEN_EGITIMLER>();
            foreach (VerilenEgitimler egitim in evdeSaglik.VerilenEgitimler)
            {
                verilenEgitimler = new VERILEN_EGITIMLER(egitim.SKRSVerilenEgitimler.KODU, egitim.SKRSVerilenEgitimler.ADI);
                verilenEgitimlerList.Add(verilenEgitimler);
            }

            _recordData.EVDE_SAGLIK_HIZMETI_ILK_IZLEM.VERILEN_EGITIMLER_BILGISI.VERILEN_EGITIMLER = verilenEgitimlerList;

            
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }


    }
}
