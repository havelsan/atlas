using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz215_DiyabetVeriSeti
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
                messageType.code = "215";
                messageType.value = TTUtils.CultureService.GetText("M25500", "Diyabet Veri Seti");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public DIYABET DIYABET = new DIYABET();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class DIYABET
        {
            public DIYABET_EGITIMI DIYABET_EGITIMI;
            public ILK_TANI_TARIHI ILK_TANI_TARIHI = new ILK_TANI_TARIHI();
            [System.Xml.Serialization.XmlElement("DIYABET_KOMPLIKASYONLARI_BILGISI", Type = typeof(DIYABET_KOMPLIKASYONLARI_BILGISI))]
            public List<DIYABET_KOMPLIKASYONLARI_BILGISI> DIYABET_KOMPLIKASYONLARI_BILGISI = new List<DIYABET_KOMPLIKASYONLARI_BILGISI>();
            public BOY_KILO_BILGILERI BOY_KILO_BILGILERI = new BOY_KILO_BILGILERI();
        }

        public class DIYABET_KOMPLIKASYONLARI_BILGISI
        {
            public DIYABET_KOMPLIKASYONLARI DIYABET_KOMPLIKASYONLARI = new DIYABET_KOMPLIKASYONLARI();
        }

        public class BOY_KILO_BILGILERI
        {
            public BOY BOY = new BOY();
            public KILO KILO = new KILO();

        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {  
            //InternalObjectGuid bu object için DiyabetVeriSeti
            TTObjectContext objectContext = new TTObjectContext(true);
            DiyabetVeriSeti diyabet = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as DiyabetVeriSeti;
            if (diyabet == null)
                throw new Exception("'215' peketini göndermek için " + InternalObjectId + " ObjectId'li DiyabetVeriSeti Objesi bulunamadı");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();

            if (diyabet.SKRSDiyabetEgitimi != null)
            {
               
                _recordData.DIYABET.DIYABET_EGITIMI = new TTObjectClasses.DIYABET_EGITIMI(diyabet.SKRSDiyabetEgitimi.KODU, diyabet.SKRSDiyabetEgitimi.ADI);
            }
            _recordData.DIYABET.ILK_TANI_TARIHI.value = diyabet.IlkTaniTarihi.HasValue ? diyabet.IlkTaniTarihi.Value.ToString("yyyyMMddHHmm") : string.Empty;
            _recordData.DIYABET.BOY_KILO_BILGILERI = new BOY_KILO_BILGILERI();

            _recordData.DIYABET.BOY_KILO_BILGILERI.BOY.value = diyabet.Boy.HasValue ? diyabet.Boy.ToString() : string.Empty;
            _recordData.DIYABET.BOY_KILO_BILGILERI.KILO.value = diyabet.Kilo.HasValue ? diyabet.Kilo.ToString() : string.Empty;

            DIYABET_KOMPLIKASYONLARI_BILGISI diyabetKomplikasyonlariBilgisi = new DIYABET_KOMPLIKASYONLARI_BILGISI();
            if (diyabet.DiyabetKompBilgisi.Count > 0)
            {

                foreach (DiyabetKompBilgisi komplikasyon in diyabet.DiyabetKompBilgisi)
                {
                    diyabetKomplikasyonlariBilgisi = new DIYABET_KOMPLIKASYONLARI_BILGISI();
                    diyabetKomplikasyonlariBilgisi.DIYABET_KOMPLIKASYONLARI = new DIYABET_KOMPLIKASYONLARI(komplikasyon.SKRSDiyabetKomplikasyonlari.KODU, komplikasyon.SKRSDiyabetKomplikasyonlari.ADI);
                    _recordData.DIYABET.DIYABET_KOMPLIKASYONLARI_BILGISI.Add(diyabetKomplikasyonlariBilgisi);
                }
            }
            else
            {
                diyabetKomplikasyonlariBilgisi = new DIYABET_KOMPLIKASYONLARI_BILGISI();
                diyabetKomplikasyonlariBilgisi.DIYABET_KOMPLIKASYONLARI = new DIYABET_KOMPLIKASYONLARI("99", "BELİRTİLMEDİ");
                _recordData.DIYABET.DIYABET_KOMPLIKASYONLARI_BILGISI.Add(diyabetKomplikasyonlariBilgisi);
            }


            if (diyabet.SubEpisode.SYSTakipNo == null)
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = diyabet.SubEpisode.SYSTakipNo;

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
