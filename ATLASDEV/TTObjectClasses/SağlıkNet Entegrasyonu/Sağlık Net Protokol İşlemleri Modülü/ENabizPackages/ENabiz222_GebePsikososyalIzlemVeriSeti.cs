using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz222_GebePsikososyalIzlemVeriSeti
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
                messageType.code = "222";
                messageType.value = "Gebe Psikososyal Izlem Veri Seti";
            }
        }
        public class recordData
        {
            public GEBE_PSIKOSOSYAL_IZLEM GEBE_PSIKOSOSYAL_IZLEM = new GEBE_PSIKOSOSYAL_IZLEM();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class GEBE_PSIKOSOSYAL_IZLEM
        {
            [System.Xml.Serialization.XmlElement("BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER", Type = typeof(BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER))]
            public List<BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER> BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER = new List<BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER>();
            [System.Xml.Serialization.XmlElement("BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER", Type = typeof(BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER))]
            public List<BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER> BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER;
            [System.Xml.Serialization.XmlElement("GEBEDE_RISK_FAKTORLERINE_YAPILAN_MUDAHALE", Type = typeof(GEBEDE_RISK_FAKTORLERINE_YAPILAN_MUDAHALE))]
            public List<GEBEDE_RISK_FAKTORLERINE_YAPILAN_MUDAHALE> GEBEDE_RISK_FAKTORLERINE_YAPILAN_MUDAHALE;
            [System.Xml.Serialization.XmlElement("BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER", Type = typeof(GEBEDE_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI))]
            public List<GEBEDE_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI> GEBEDE_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER risk = new BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER("1", "AİLENİN DÜZENLİ GELİRİNİN BULUNMAMASI");
            _recordData.GEBE_PSIKOSOSYAL_IZLEM.BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER.Add(risk);
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

    }


}
