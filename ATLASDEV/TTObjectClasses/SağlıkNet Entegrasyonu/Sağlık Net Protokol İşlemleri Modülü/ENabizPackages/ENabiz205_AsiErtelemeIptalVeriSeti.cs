using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz205_AsiErtelemeIptalVeriSeti
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
                messageType.code = "205";
                messageType.value = "Asi Erteleme / Iptal Veri Seti";
            }
        }

        public class recordData
        {
            public ASI_ERTELEME_IPTAL ASI_ERTELEME_IPTAL = new ASI_ERTELEME_IPTAL();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class ASI_ERTELEME_IPTAL
        {
            [XmlElement("ASI_ERTELEME_IPTAL_BILGISI", Type = typeof(ASI_ERTELEME_IPTAL_BILGISI))]
            public List<ASI_ERTELEME_IPTAL_BILGISI> ASI_ERTELEME_IPTAL_BILGISI;
        }

        public class ASI_ERTELEME_IPTAL_BILGISI
        {
            public ASI ASI;
            public ASININ_DOZU ASININ_DOZU;
            public ASI_ERTELEME_SURESI ASI_ERTELEME_SURESI;
            public ASI_YAPILMAMA_DURUMU ASI_YAPILMAMA_DURUMU;
            public ASI_YAPILMAMA_NEDENI ASI_YAPILMAMA_NEDENI;
            public ASI_YAPILMA_ZAMANI ASI_YAPILMA_ZAMANI;
        }

        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
        {
            TTObjectContext objectContext = new TTObjectContext(true);

            recordData _recordData = new recordData();
            VaccineDetails vaccine = (VaccineDetails)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);
            if (vaccine != null)
            {
                if (vaccine.VaccineFollowUp.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = vaccine.VaccineFollowUp.SubEpisode.SYSTakipNo;

                _recordData.ASI_ERTELEME_IPTAL = new ASI_ERTELEME_IPTAL();

                ASI_ERTELEME_IPTAL_BILGISI ASI_ERTELEME_IPTAL_BILGISI = new ASI_ERTELEME_IPTAL_BILGISI();
                ASI_ERTELEME_IPTAL_BILGISI.ASI = new ASI(vaccine.SKRSAsiKodu.KODU.ToString(),vaccine.SKRSAsiKodu.ADI);
                ASI_ERTELEME_IPTAL_BILGISI.ASININ_DOZU = new ASININ_DOZU(vaccine.SKRSAsininDozu.KODU,vaccine.SKRSAsininDozu.ADI);
                ASI_ERTELEME_IPTAL_BILGISI.ASI_ERTELEME_SURESI.value = vaccine.VaccinePostponeTime.ToString();
                ASI_ERTELEME_IPTAL_BILGISI.ASI_YAPILMAMA_DURUMU = new ASI_YAPILMAMA_DURUMU(vaccine.SKRSAsiYapilmamaDurumu.KODU,vaccine.SKRSAsiYapilmamaDurumu.ADI);
                ASI_ERTELEME_IPTAL_BILGISI.ASI_YAPILMAMA_NEDENI = new ASI_YAPILMAMA_NEDENI(vaccine.SKRSAsiYapilmamaNedeni.KODU,vaccine.SKRSAsiYapilmamaNedeni.ADI);

                _recordData.ASI_ERTELEME_IPTAL.ASI_ERTELEME_IPTAL_BILGISI = new List<ASI_ERTELEME_IPTAL_BILGISI>();
                _recordData.ASI_ERTELEME_IPTAL.ASI_ERTELEME_IPTAL_BILGISI.Add(ASI_ERTELEME_IPTAL_BILGISI);

            }

             SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";
            _recordData.ASI_ERTELEME_IPTAL.ASI_ERTELEME_IPTAL_BILGISI = new List<ASI_ERTELEME_IPTAL_BILGISI>();
            ASI_ERTELEME_IPTAL_BILGISI iptalBilgisi = new ASI_ERTELEME_IPTAL_BILGISI();
            iptalBilgisi.ASI = new ASI("1", "BİVALAN OPA (ORAL POLİO AŞISI)");
            iptalBilgisi.ASININ_DOZU = new ASININ_DOZU("1", "AŞININ BİRİNCİ DOZU");
            iptalBilgisi.ASI_YAPILMAMA_DURUMU = new ASI_YAPILMAMA_DURUMU("2", "İPTAL EDİLDİ");
            iptalBilgisi.ASI_YAPILMAMA_NEDENI = new ASI_YAPILMAMA_NEDENI("10", "HASTALIĞI GEÇIRMIŞ (SU ÇIÇEĞI)");
            iptalBilgisi.ASI_ERTELEME_SURESI = new ASI_ERTELEME_SURESI();
            iptalBilgisi.ASI_YAPILMA_ZAMANI = new ASI_YAPILMA_ZAMANI();
            iptalBilgisi.ASI_YAPILMA_ZAMANI.value = "201801020000";
            _recordData.ASI_ERTELEME_IPTAL.ASI_ERTELEME_IPTAL_BILGISI.Add(iptalBilgisi);
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
