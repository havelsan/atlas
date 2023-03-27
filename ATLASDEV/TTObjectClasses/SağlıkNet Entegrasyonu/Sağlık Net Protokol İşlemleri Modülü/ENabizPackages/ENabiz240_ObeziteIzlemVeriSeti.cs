using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz240_ObeziteIzlemVeriSeti
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
                messageType.code = "240";
                messageType.value = TTUtils.CultureService.GetText("M26604", "Obezite Izlem Veri Seti");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public OBEZITE_IZLEM OBEZITE_IZLEM = new OBEZITE_IZLEM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class OBEZITE_IZLEM
        {
            public BEL_CEVRESI BEL_CEVRESI = new BEL_CEVRESI();
            public DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI = new DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI();
            public ILK_TANI_TARIHI ILK_TANI_TARIHI = new ILK_TANI_TARIHI();
            public KALCA_CEVRESI KALCA_CEVRESI = new KALCA_CEVRESI();
            public MORBID_OBEZ_HASTA_LENFATIK_ODEM_VARLIGI MORBID_OBEZ_HASTA_LENFATIK_ODEM_VARLIGI = new MORBID_OBEZ_HASTA_LENFATIK_ODEM_VARLIGI();
            public OBEZITE_ILAC_TEDAVISI OBEZITE_ILAC_TEDAVISI = new OBEZITE_ILAC_TEDAVISI();
            [System.Xml.Serialization.XmlElement("EGZERSIZ_BILGISI", Type = typeof(EGZERSIZ_BILGISI))]
            public List<EGZERSIZ_BILGISI> EGZERSIZ_BILGISI;
            public BOY_KILO_BILGILERI BOY_KILO_BILGILERI = new BOY_KILO_BILGILERI();
            public PSIKOLOJIK_TEDAVI PSIKOLOJIK_TEDAVI = new PSIKOLOJIK_TEDAVI();
            [System.Xml.Serialization.XmlElement("BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI", Type = typeof(BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI))]
            public List<BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI> BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI; //ICD Kodu
        }

        public class EGZERSIZ_BILGISI
        {
            public EGZERSIZ EGZERSIZ = new EGZERSIZ();
        }

        public class BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI
        {
            public BIRLIKTE_GORULEN_EK_HASTALIKLAR BIRLIKTE_GORULEN_EK_HASTALIKLAR = new BIRLIKTE_GORULEN_EK_HASTALIKLAR();
        }
        public class BOY_KILO_BILGILERI
        {
            public BOY BOY;
            public KILO KILO;
        }
        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            //InternalObjectGuid bu object için ObeziteIzlemVeriSeti
            TTObjectContext objectContext = new TTObjectContext(true);
            ObeziteIzlemVeriSeti obezite = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as ObeziteIzlemVeriSeti;
            if (obezite == null)
                throw new Exception("'240' paketini göndermek için " + InternalObjectId + " ObjectId'li ObeziteIzlemVeriSeti Objesi bulunamadı.");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }
            recordData _recordData = new recordData();

            _recordData.OBEZITE_IZLEM.ILK_TANI_TARIHI.value = obezite.IlkTaniTarihi.HasValue ? obezite.IlkTaniTarihi.Value.ToString("yyyyMMddHHmm") : string.Empty;
            _recordData.OBEZITE_IZLEM.BEL_CEVRESI.value = obezite.BelCevresi.HasValue ? obezite.BelCevresi.Value.ToString() : string.Empty;
            _recordData.OBEZITE_IZLEM.KALCA_CEVRESI.value = obezite.KalcaCevresi.HasValue ? obezite.KalcaCevresi.Value.ToString() : string.Empty;
            _recordData.OBEZITE_IZLEM.BOY_KILO_BILGILERI = new BOY_KILO_BILGILERI();
            _recordData.OBEZITE_IZLEM.BOY_KILO_BILGILERI.BOY.value = obezite.Boy.HasValue ? obezite.Boy.ToString() : string.Empty;
            _recordData.OBEZITE_IZLEM.BOY_KILO_BILGILERI.KILO.value = obezite.Kilo.HasValue ? obezite.Kilo.ToString() : string.Empty;

            if (obezite.DiyetTibbiBeslenmeTedavisi != null)
                _recordData.OBEZITE_IZLEM.DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI = new DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI(obezite.DiyetTibbiBeslenmeTedavisi.KODU, obezite.DiyetTibbiBeslenmeTedavisi.ADI);
            if (obezite.OdemVarligi != null)
                _recordData.OBEZITE_IZLEM.MORBID_OBEZ_HASTA_LENFATIK_ODEM_VARLIGI = new MORBID_OBEZ_HASTA_LENFATIK_ODEM_VARLIGI(obezite.OdemVarligi.KODU, obezite.OdemVarligi.ADI);
            if (obezite.SKRSObeziteIlacTedavisi != null)
                _recordData.OBEZITE_IZLEM.OBEZITE_ILAC_TEDAVISI = new OBEZITE_ILAC_TEDAVISI(obezite.SKRSObeziteIlacTedavisi.KODU, obezite.SKRSObeziteIlacTedavisi.ADI);
            if (obezite.SKRSPsikolojikTedavi != null)
                _recordData.OBEZITE_IZLEM.PSIKOLOJIK_TEDAVI = new PSIKOLOJIK_TEDAVI(obezite.SKRSPsikolojikTedavi.KODU, obezite.SKRSPsikolojikTedavi.ADI);

            EGZERSIZ_BILGISI egzersizBilgisi = new EGZERSIZ_BILGISI();
            foreach (ObeziteEgzersiz egzersiz in obezite.ObeziteEgzersiz)
            {
                egzersizBilgisi = new EGZERSIZ_BILGISI();
                egzersizBilgisi.EGZERSIZ = new EGZERSIZ(egzersiz.SKRSEgzersiz.KODU, egzersiz.SKRSEgzersiz.ADI);
                _recordData.OBEZITE_IZLEM.EGZERSIZ_BILGISI.Add(egzersizBilgisi);
            }

            BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI ekHastaliklar = new BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI();
            foreach (ObeziteEkHastalik hastalik in obezite.ObeziteEkHastalik)
            {
                ekHastaliklar = new BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI();
                ekHastaliklar.BIRLIKTE_GORULEN_EK_HASTALIKLAR = new BIRLIKTE_GORULEN_EK_HASTALIKLAR(hastalik.SKRSICD.KODU, hastalik.SKRSICD.ADI);
                _recordData.OBEZITE_IZLEM.BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI.Add(ekHastaliklar);
            }

            if (obezite.SubEpisode.SYSTakipNo == null)
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = obezite.SubEpisode.SYSTakipNo;

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }



        public static SYSMessage GetDummy()
        {
            //InternalObjectGuid bu object için ObeziteIzlemVeriSeti
            TTObjectContext objectContext = new TTObjectContext(true);
            ObeziteIzlemVeriSeti obezite = objectContext.GetObject(new Guid("9a2702ba-c8c2-40fd-a3c9-7a01505e1a4c"), "OBEZITEIZLEMVERISETI") as ObeziteIzlemVeriSeti;
            if (obezite == null)
                throw new Exception("'240' paketini göndermek için " + "7816ebff-fadb-4ef6-8e4c-6adada435f66" + " ObjectId'li ObeziteIzlemVeriSeti Objesi bulunamadı.");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }
            recordData _recordData = new recordData();

            _recordData.OBEZITE_IZLEM.ILK_TANI_TARIHI.value = obezite.IlkTaniTarihi.HasValue ? obezite.IlkTaniTarihi.Value.ToString("yyyyMMddHHmm") : string.Empty;
            _recordData.OBEZITE_IZLEM.BEL_CEVRESI.value = obezite.BelCevresi.HasValue ? obezite.BelCevresi.Value.ToString() : string.Empty;
            _recordData.OBEZITE_IZLEM.KALCA_CEVRESI.value = obezite.KalcaCevresi.HasValue ? obezite.KalcaCevresi.Value.ToString() : string.Empty;
            _recordData.OBEZITE_IZLEM.BOY_KILO_BILGILERI = new BOY_KILO_BILGILERI();
            _recordData.OBEZITE_IZLEM.BOY_KILO_BILGILERI.BOY = new BOY();
            _recordData.OBEZITE_IZLEM.BOY_KILO_BILGILERI.BOY.value = obezite.Boy.HasValue ? obezite.Boy.ToString() : string.Empty;
            _recordData.OBEZITE_IZLEM.BOY_KILO_BILGILERI.KILO = new KILO();
            _recordData.OBEZITE_IZLEM.BOY_KILO_BILGILERI.KILO.value = obezite.Kilo.HasValue ? obezite.Kilo.ToString() : string.Empty;

            if (obezite.DiyetTibbiBeslenmeTedavisi != null)
                _recordData.OBEZITE_IZLEM.DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI = new DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI(obezite.DiyetTibbiBeslenmeTedavisi.KODU, obezite.DiyetTibbiBeslenmeTedavisi.ADI);
            if (obezite.OdemVarligi != null)
                _recordData.OBEZITE_IZLEM.MORBID_OBEZ_HASTA_LENFATIK_ODEM_VARLIGI = new MORBID_OBEZ_HASTA_LENFATIK_ODEM_VARLIGI(obezite.OdemVarligi.KODU, obezite.OdemVarligi.ADI);
            if (obezite.SKRSObeziteIlacTedavisi != null)
                _recordData.OBEZITE_IZLEM.OBEZITE_ILAC_TEDAVISI = new OBEZITE_ILAC_TEDAVISI(obezite.SKRSObeziteIlacTedavisi.KODU, obezite.SKRSObeziteIlacTedavisi.ADI);
            if (obezite.SKRSPsikolojikTedavi != null)
                _recordData.OBEZITE_IZLEM.PSIKOLOJIK_TEDAVI = new PSIKOLOJIK_TEDAVI(obezite.SKRSPsikolojikTedavi.KODU, obezite.SKRSPsikolojikTedavi.ADI);
            _recordData.OBEZITE_IZLEM.EGZERSIZ_BILGISI = new List<EGZERSIZ_BILGISI>();
            EGZERSIZ_BILGISI egzersizBilgisi = new EGZERSIZ_BILGISI();
            foreach (ObeziteEgzersiz egzersiz in obezite.ObeziteEgzersiz)
            {
                egzersizBilgisi = new EGZERSIZ_BILGISI();
                egzersizBilgisi.EGZERSIZ = new EGZERSIZ(egzersiz.SKRSEgzersiz.KODU, egzersiz.SKRSEgzersiz.ADI);
                _recordData.OBEZITE_IZLEM.EGZERSIZ_BILGISI.Add(egzersizBilgisi);
            }
            _recordData.OBEZITE_IZLEM.BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI = new List<BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI>();
            BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI ekHastaliklar = new BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI();
            foreach (ObeziteEkHastalik hastalik in obezite.ObeziteEkHastalik)
            {
                ekHastaliklar = new BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI();
                ekHastaliklar.BIRLIKTE_GORULEN_EK_HASTALIKLAR = new BIRLIKTE_GORULEN_EK_HASTALIKLAR(hastalik.SKRSICD.KODU, hastalik.SKRSICD.ADI);
                _recordData.OBEZITE_IZLEM.BIRLIKTE_GORULEN_EK_HASTALIK_BILGISI.Add(ekHastaliklar);
            }

            
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
