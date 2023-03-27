using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz905_EkOdemeKayit
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
                messageType.code = "905";
                messageType.value = TTUtils.CultureService.GetText("M25575", "Ek Ödeme Kayıt");
            }

        }
        public class recordData
        {
            public EkOdemeBilgisi EkOdemeBilgisi = new EkOdemeBilgisi();

        }

        public class EkOdemeBilgisi
        {
            public DonemBaslangicTarihi DonemBaslangicTarihi = new DonemBaslangicTarihi();       // Zorunlu      .ToString("yyyyMMddHHmm")
            public DonemBitisTarihi DonemBitisTarihi = new DonemBitisTarihi();               // Zorunlu      .ToString("yyyyMMddHHmm")
            public ToplamHizmetPuani ToplamHizmetPuani = new ToplamHizmetPuani();             // Zorunlu
            public XXXXXXToplamPuani XXXXXXToplamPuani = new XXXXXXToplamPuani();           // Zorunlu
            public DagitilmasiPlanlananTutar DagitilmasiPlanlananTutar = new DagitilmasiPlanlananTutar();     // Zorunlu
            public DagitilanTutar DagitilanTutar = new DagitilanTutar();                   // Zorunlu
            public Katsayi Katsayi = new Katsayi();                                 // Zorunlu
            public KatkiYapanPersonelSayisi KatkiYapanPersonelSayisi = new KatkiYapanPersonelSayisi();       // Zorunlu
            [System.Xml.Serialization.XmlElement("PersonelOdemeBilgisi", Type = typeof(PersonelOdemeBilgisi))]
            public List<PersonelOdemeBilgisi> PersonelOdemeBilgisi = new List<PersonelOdemeBilgisi>(); // Zorunlu

        }

        public class PersonelOdemeBilgisi
        {
            public PERSONEL_KIMLIK_NUMARASI PERSONEL_KIMLIK_NUMARASI = new PERSONEL_KIMLIK_NUMARASI();              // Zorunlu
            public ToplamHizmetPuani ToplamHizmetPuani = new ToplamHizmetPuani();             // Zorunlu
            public NetPerformansPuani NetPerformansPuani = new NetPerformansPuani();             // Zorunlu
            public TavanEkOdemeTutari TavanEkOdemeTutari = new TavanEkOdemeTutari();             // Zorunlu
            public BrutEkOdeme BrutEkOdeme = new BrutEkOdeme();             // Zorunlu
            public NetEkOdeme NetEkOdeme = new NetEkOdeme();             // Zorunlu
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            recordData _recordData = new recordData();
            using (var objectContext = new TTObjectContext(false))
            {
                // _recordData içerisindeki nesneler burada doldurulacak.
            }





           
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.EkOdemeBilgisi.DonemBaslangicTarihi.value = "201801010000"; ;
            _recordData.EkOdemeBilgisi.DonemBitisTarihi.value = "201802010000";
            _recordData.EkOdemeBilgisi.ToplamHizmetPuani.value = "100";
            _recordData.EkOdemeBilgisi.XXXXXXToplamPuani.value = "100";
            _recordData.EkOdemeBilgisi.DagitilmasiPlanlananTutar.value = "1000";
            _recordData.EkOdemeBilgisi.DagitilanTutar.value = "100";
            _recordData.EkOdemeBilgisi.Katsayi.value = "2";
            _recordData.EkOdemeBilgisi.KatkiYapanPersonelSayisi.value = "10";

            PersonelOdemeBilgisi odemeBilgisi = new PersonelOdemeBilgisi();
            odemeBilgisi.PERSONEL_KIMLIK_NUMARASI.value = "10000000000";
            odemeBilgisi.ToplamHizmetPuani.value = "5";
            odemeBilgisi.NetPerformansPuani.value = "3";
            odemeBilgisi.TavanEkOdemeTutari.value = "20";
            odemeBilgisi.BrutEkOdeme.value = "18";
            odemeBilgisi.NetEkOdeme.value = "15";
            _recordData.EkOdemeBilgisi.PersonelOdemeBilgisi.Add(odemeBilgisi);



            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

    }
}
