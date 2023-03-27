using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TTObjectClasses
{
    public class ENabiz220_EvdeSaglikHizmetiIzlemVeriSeti
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
                messageType.code = "220";
                messageType.value = "Evde Saglik Hizmeti Izlem Veri Seti";
            }

        }
        public class recordData
        {
            public EVDE_SAGLIK_HIZMETI_IZLEM EVDE_SAGLIK_HIZMETI_IZLEM = new EVDE_SAGLIK_HIZMETI_IZLEM();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class EVDE_SAGLIK_HIZMETI_IZLEM
        {
            public AGRI AGRI;
            public BASI_DEGERLENDIRMESI BASI_DEGERLENDIRMESI;
            public BESLENME BESLENME ;
            public EVDE_SAGLIK_HIZMETININ_SONLANDIRILMASI EVDE_SAGLIK_HIZMETININ_SONLANDIRILMASI ;
            public EVDE_SAGLIK_HIZMETLERI_HASTA_NAKLI EVDE_SAGLIK_HIZMETLERI_HASTA_NAKLI;
            public IL_KODU HIZMET_ALINACAK_IL;

            [XmlElement("BIR_SONRAKI_HIZMET_IHTIYACI_BILGISI", Type = typeof(BIR_SONRAKI_HIZMET_IHTIYACI_BILGISI))]
            public List<BIR_SONRAKI_HIZMET_IHTIYACI_BILGISI> BIR_SONRAKI_HIZMET_IHTIYACI_BILGISI;

            [XmlElement("PSIKOLOJIK_DURUM_DEGERLENDIRMESI_BILGISI", Type = typeof(PSIKOLOJIK_DURUM_DEGERLENDIRMESI_BILGISI))]
            public List<PSIKOLOJIK_DURUM_DEGERLENDIRMESI_BILGISI> PSIKOLOJIK_DURUM_DEGERLENDIRMESI_BILGISI;

            [XmlElement("VERILEN_EGITIMLER_BILGISI", Type = typeof(VERILEN_EGITIMLER_BILGISI))]
            public List<VERILEN_EGITIMLER_BILGISI> VERILEN_EGITIMLER_BILGISI;

        }

        public class BIR_SONRAKI_HIZMET_IHTIYACI_BILGISI
        {
            public  BIR_SONRAKI_HIZMET_IHTIYACI BIR_SONRAKI_HIZMET_IHTIYACI;
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

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.EVDE_SAGLIK_HIZMETI_IZLEM.AGRI = new AGRI("97", "YOK");
            _recordData.EVDE_SAGLIK_HIZMETI_IZLEM.BASI_DEGERLENDIRMESI = new BASI_DEGERLENDIRMESI("97", "YOK");
            _recordData.EVDE_SAGLIK_HIZMETI_IZLEM.EVDE_SAGLIK_HIZMETLERI_HASTA_NAKLI = new EVDE_SAGLIK_HIZMETLERI_HASTA_NAKLI("97","YOK");
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;

        }
    }
}
