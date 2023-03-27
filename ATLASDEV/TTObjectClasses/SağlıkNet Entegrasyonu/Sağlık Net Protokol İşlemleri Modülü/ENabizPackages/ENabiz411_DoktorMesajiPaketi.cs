using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{ 
    public class ENabiz411_DoktorMesajiPaketi
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
                messageType.code = "411";
                messageType.value = "Doktor Mesajı Paketi";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public DOKTOR_MESAJI_VERI_SETI DOKTOR_MESAJI_VERI_SETI = new DOKTOR_MESAJI_VERI_SETI();

        }

        public class DOKTOR_MESAJI_VERI_SETI
        {
            public HASTA_MESAJLARI_TURU HASTA_MESAJLARI_TURU;
            public MESAJ_DETAYI MESAJ_DETAYI = new MESAJ_DETAYI();
            public MESAJ_TARIHI MESAJ_TARIHI = new MESAJ_TARIHI();
        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            recordData _recordData = new recordData();

            using(var objectContext=new TTObjectContext(true))
            {
                SendMessageToPatient sendMessage = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as SendMessageToPatient;
                if (sendMessage == null)
                    throw new Exception("'411' paketini göndermek için " + InternalObjectId + " ObjectId'li SendMessageToPatient Objesi bulunamadı");
                if(sendMessage.SKRSHastaMesajlari != null)
                    _recordData.DOKTOR_MESAJI_VERI_SETI.HASTA_MESAJLARI_TURU = new HASTA_MESAJLARI_TURU(sendMessage.SKRSHastaMesajlari.KODU, sendMessage.SKRSHastaMesajlari.ADI);

                if (sendMessage.MessageDate != null)
                    _recordData.DOKTOR_MESAJI_VERI_SETI.MESAJ_TARIHI.value = ((DateTime)sendMessage.MessageDate).ToString("yyyyMMddHHmm");
                if (sendMessage.MessageInfo != null)
                    _recordData.DOKTOR_MESAJI_VERI_SETI.MESAJ_DETAYI.value = sendMessage.MessageInfo.ToString();
                if (sendMessage.SubEpisode.SYSTakipNo != null)
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sendMessage.SubEpisode.SYSTakipNo.ToString();
                else
                    throw new Exception(sendMessage.SubEpisode.ProtocolNo.ToString()+" Protokol numaralı SubEpisode a ait SYSTakipNo bulunamadı.");
            }


            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
