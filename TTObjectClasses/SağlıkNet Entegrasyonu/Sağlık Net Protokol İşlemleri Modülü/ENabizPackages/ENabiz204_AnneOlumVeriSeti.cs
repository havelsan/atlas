using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class ENabiz204_AnneOlumVeriSeti
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
                messageType.code = "204";
                messageType.value = "Anne Olum Veri Seti";
            }

        }
        public class recordData
        {

            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public ANNE_OLUMU ANNE_OLUMU = new ANNE_OLUMU();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();

        }

        public class ANNE_OLUMU
        {
            public ANNE_OLUM_ZAMANI ANNE_OLUM_ZAMANI;
            public DOGUM_GEBELIK_SONLANMA_HAFTASI DOGUM_GEBELIK_SONLANMA_HAFTASI;
            public DOGUM_YONTEMI DOGUM_YONTEMI;
            public GEBELIK_ARALIGI GEBELIK_ARALIGI;
            public GEBELIK_SONLANMA_TARIHI GEBELIK_SONLANMA_TARIHI;
            public GEBELIK_SONUCU GEBELIK_SONUCU;
            public KACINCI_GEBELIK KACINCI_GEBELIK;
            [System.Xml.Serialization.XmlElement("ANNE_OLUM_NEDENI_BILGISI", Type = typeof(ANNE_OLUM_NEDENI_BILGISI))]
            public List<ANNE_OLUM_NEDENI_BILGISI> ANNE_OLUM_NEDENI_BILGISI = new List<ANNE_OLUM_NEDENI_BILGISI>();
            [System.Xml.Serialization.XmlElement("GEBELIKTE_RISK_FAKTORLERI_BILGISI", Type = typeof(GEBELIKTE_RISK_FAKTORLERI_BILGISI))]
            public List<GEBELIKTE_RISK_FAKTORLERI_BILGISI> GEBELIKTE_RISK_FAKTORLERI_BILGISI = new List<GEBELIKTE_RISK_FAKTORLERI_BILGISI>();
            [System.Xml.Serialization.XmlElement("UC_GECIKME_MODELI_BILGISI", Type = typeof(UC_GECIKME_MODELI_BILGISI))]
            public List<UC_GECIKME_MODELI_BILGISI> UC_GECIKME_MODELI_BILGISI = new List<UC_GECIKME_MODELI_BILGISI>();
        }

        public class UC_GECIKME_MODELI_BILGISI
        {
            public UC_GECIKME_MODELI UC_GECIKME_MODELI;
        }

        public class GEBELIKTE_RISK_FAKTORLERI_BILGISI
        {
            public GEBELIKTE_RISK_FAKTORLERI GEBELIKTE_RISK_FAKTORLERI;
        }

        public class ANNE_OLUM_NEDENI_BILGISI
        {
            public ANNE_OLUM_NEDENI ANNE_OLUM_NEDENI;
        }


        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.ANNE_OLUMU.ANNE_OLUM_ZAMANI = new ANNE_OLUM_ZAMANI("7", "BİLİNMİYOR");
            _recordData.ANNE_OLUMU.DOGUM_GEBELIK_SONLANMA_HAFTASI = new DOGUM_GEBELIK_SONLANMA_HAFTASI();
            _recordData.ANNE_OLUMU.DOGUM_GEBELIK_SONLANMA_HAFTASI.value = "1";
            _recordData.ANNE_OLUMU.GEBELIK_ARALIGI = new GEBELIK_ARALIGI("5", "BİLİNMİYOR");
            _recordData.ANNE_OLUMU.KACINCI_GEBELIK = new KACINCI_GEBELIK();
            _recordData.ANNE_OLUMU.KACINCI_GEBELIK.value = "1";

            ANNE_OLUM_NEDENI_BILGISI olumBilgisi = new ANNE_OLUM_NEDENI_BILGISI();
            olumBilgisi.ANNE_OLUM_NEDENI = new ANNE_OLUM_NEDENI("17", "TANI KONULAMAYANLAR");
            _recordData.ANNE_OLUMU.ANNE_OLUM_NEDENI_BILGISI.Add(olumBilgisi);

            GEBELIKTE_RISK_FAKTORLERI_BILGISI riskFaktorleri = new GEBELIKTE_RISK_FAKTORLERI_BILGISI();
            riskFaktorleri.GEBELIKTE_RISK_FAKTORLERI = new GEBELIKTE_RISK_FAKTORLERI("33", "RİSK YOK");
            _recordData.ANNE_OLUMU.GEBELIKTE_RISK_FAKTORLERI_BILGISI.Add(riskFaktorleri);
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
