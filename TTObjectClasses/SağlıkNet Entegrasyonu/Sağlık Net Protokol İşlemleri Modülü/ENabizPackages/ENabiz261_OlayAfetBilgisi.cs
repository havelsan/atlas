using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz261_OlayAfetBilgisi
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
                messageType.code = "261";
                messageType.value = TTUtils.CultureService.GetText("M26632", "Olay Afet Bilgisi");
            }

        }

        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public OLAY_AFET_BILGILERI OLAY_AFET_BILGILERI = new OLAY_AFET_BILGILERI();

        }

        public class OLAY_AFET_BILGILERI
        {
            public AFET_OLAY_VATANDAS_TIPI AFET_OLAY_VATANDAS_TIPI = new AFET_OLAY_VATANDAS_TIPI();
            public OLAY_ID OLAY_ID = new OLAY_ID();
            public HAYATI_TEHLIKE_DURUMU HAYATI_TEHLIKE_DURUMU = new HAYATI_TEHLIKE_DURUMU();
            public GLASGOW_KOMA_SKALASI GLASGOW_KOMA_SKALASI = new GLASGOW_KOMA_SKALASI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }


        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            //InternalObjectGuid bu object için OlayAfetBilgisi
            TTObjectContext objectContext = new TTObjectContext(true);
            OlayAfetBilgisi olayAfetBilgisi = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as OlayAfetBilgisi;
            if (olayAfetBilgisi == null)
                throw new Exception("'261' paketini göndermek için " + InternalObjectId + " ObjectId'li OlayAfetBilgisi Objesi bulunamadı.");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }
            recordData _recordData = new recordData();
            _recordData.OLAY_AFET_BILGILERI.GLASGOW_KOMA_SKALASI.value = olayAfetBilgisi.GlasgowKomaSkalasi.HasValue ? olayAfetBilgisi.GlasgowKomaSkalasi.Value.ToString() : string.Empty;
            if (olayAfetBilgisi.SKRSAFETOLAYVATANDASTIPI != null)
                _recordData.OLAY_AFET_BILGILERI.AFET_OLAY_VATANDAS_TIPI = new AFET_OLAY_VATANDAS_TIPI(olayAfetBilgisi.SKRSAFETOLAYVATANDASTIPI.KODU, olayAfetBilgisi.SKRSAFETOLAYVATANDASTIPI.ADI);
            if (olayAfetBilgisi.SKRSOlayAfetBilgisi != null)
                _recordData.OLAY_AFET_BILGILERI.OLAY_ID = new  OLAY_ID(olayAfetBilgisi.SKRSOlayAfetBilgisi.OLAYNO.ToString(), olayAfetBilgisi.SKRSOlayAfetBilgisi.OLAYISMI);
            if (olayAfetBilgisi.SKRSHayatiTehlikeDurumu != null)
                _recordData.OLAY_AFET_BILGILERI.HAYATI_TEHLIKE_DURUMU = new HAYATI_TEHLIKE_DURUMU(olayAfetBilgisi.SKRSHayatiTehlikeDurumu.KODU, olayAfetBilgisi.SKRSHayatiTehlikeDurumu.ADI);

            if (olayAfetBilgisi.SubEpisode.SYSTakipNo == null)
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = olayAfetBilgisi.SubEpisode.SYSTakipNo;

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }


        public static SYSMessage GetDummy()
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            OlayAfetBilgisi olayAfetBilgisi = objectContext.GetObject(new Guid("f159b915-f705-4f49-8954-56da22c5fbd4"), "OLAYAFETBILGISI") as OlayAfetBilgisi;
            if (olayAfetBilgisi == null)
                throw new Exception("'261' paketini göndermek için " + "f159b915-f705-4f49-8954-56da22c5fbd4" + " ObjectId'li OlayAfetBilgisi Objesi bulunamadı.");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }
            recordData _recordData = new recordData();
            _recordData.OLAY_AFET_BILGILERI.GLASGOW_KOMA_SKALASI.value = olayAfetBilgisi.GlasgowKomaSkalasi.HasValue ? olayAfetBilgisi.GlasgowKomaSkalasi.Value.ToString() : string.Empty;
            if (olayAfetBilgisi.SKRSAFETOLAYVATANDASTIPI != null)
                _recordData.OLAY_AFET_BILGILERI.AFET_OLAY_VATANDAS_TIPI = new AFET_OLAY_VATANDAS_TIPI(olayAfetBilgisi.SKRSAFETOLAYVATANDASTIPI.KODU, olayAfetBilgisi.SKRSAFETOLAYVATANDASTIPI.ADI);
            if (olayAfetBilgisi.SKRSOlayAfetBilgisi != null)
                _recordData.OLAY_AFET_BILGILERI.OLAY_ID = new OLAY_ID(olayAfetBilgisi.SKRSOlayAfetBilgisi.OLAYNO.ToString(), olayAfetBilgisi.SKRSOlayAfetBilgisi.OLAYISMI);
            if (olayAfetBilgisi.SKRSHayatiTehlikeDurumu != null)
                _recordData.OLAY_AFET_BILGILERI.HAYATI_TEHLIKE_DURUMU = new HAYATI_TEHLIKE_DURUMU(olayAfetBilgisi.SKRSHayatiTehlikeDurumu.KODU, olayAfetBilgisi.SKRSHayatiTehlikeDurumu.ADI);

            
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }


}
