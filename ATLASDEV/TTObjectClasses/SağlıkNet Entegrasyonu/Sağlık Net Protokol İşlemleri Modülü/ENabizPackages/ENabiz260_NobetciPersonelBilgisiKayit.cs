using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class ENabiz260_NobetciPersonelBilgisiKayit
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
                messageType.code = "260";
                messageType.value = TTUtils.CultureService.GetText("M26591", "Nöbetci Personel Bilgisi Kayıt");
            }

        }
        public class recordData
        {
            public NOBETCI_PERSONEL_BILGISI NOBETCI_PERSONEL_BILGISI = new NOBETCI_PERSONEL_BILGISI();
        }

        public class NOBETCI_PERSONEL_BILGISI
        {
            public KAYIT_YERI KAYIT_YERI = new KAYIT_YERI();
            public Tarih Tarih = new Tarih();
            [System.Xml.Serialization.XmlElement("NOBETCI_PERSONEL_BILGILERI", Type = typeof(NOBETCI_PERSONEL_BILGILERI))]
            public List<NOBETCI_PERSONEL_BILGILERI> NOBETCI_PERSONEL_BILGILERI = new List<NOBETCI_PERSONEL_BILGILERI>();
        }

        public class NOBETCI_PERSONEL_BILGILERI
        {
            public PERSONEL_KIMLIK_NUMARASI PERSONEL_KIMLIK_NUMARASI = new PERSONEL_KIMLIK_NUMARASI();
            public KLINIK_KODU KLINIK_KODU = new KLINIK_KODU();
            public GOREV_TURU GOREV_TURU = new GOREV_TURU();
            public PERSONEL_GOREV_KODU PERSONEL_GOREV_KODU = new PERSONEL_GOREV_KODU();
            public NOBET_BASLANGIC_TARIHI NOBET_BASLANGIC_TARIHI = new NOBET_BASLANGIC_TARIHI();
            public NOBET_BITIS_TARIHI NOBET_BITIS_TARIHI = new NOBET_BITIS_TARIHI();
            public TELEFON_NUMARASI TELEFON_NUMARASI = new TELEFON_NUMARASI();
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            recordData _recordData = new recordData();

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;

        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            _recordData.NOBETCI_PERSONEL_BILGISI.KAYIT_YERI = myTesisSKRSKurumlarDefinition != null ? new KAYIT_YERI(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI) : null;
            _recordData.NOBETCI_PERSONEL_BILGISI.Tarih.value = "201801010100";
            NOBETCI_PERSONEL_BILGILERI personel = new NOBETCI_PERSONEL_BILGILERI();
            personel.KLINIK_KODU = new KLINIK_KODU("196", "ÜROLOJI");
            personel.GOREV_TURU = new GOREV_TURU("1", "NÖBET");
            personel.NOBET_BASLANGIC_TARIHI.value = "201801010000";
            personel.NOBET_BITIS_TARIHI.value = "201801012359";
            personel.PERSONEL_GOREV_KODU = new PERSONEL_GOREV_KODU("4", "HEKIM");
            personel.PERSONEL_KIMLIK_NUMARASI.value = "10000000000";
            personel.TELEFON_NUMARASI.value = "055533644889";
            _recordData.NOBETCI_PERSONEL_BILGISI.NOBETCI_PERSONEL_BILGILERI.Add(personel);


            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

    }
}
