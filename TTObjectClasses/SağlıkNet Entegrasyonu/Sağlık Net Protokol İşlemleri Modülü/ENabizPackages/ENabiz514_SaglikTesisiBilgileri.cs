using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz514_SaglikTesisiBilgileri
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
                messageType.code = "514";
                messageType.value = "Sağlık Tesisi Bilgileri";
            }
        }
        public class recordData
        {
            public SAGLIK_TESISI_BILGILERI SAGLIK_TESISI_BILGILERI = new SAGLIK_TESISI_BILGILERI();

        }

        public class SAGLIK_TESISI_BILGILERI
        {
            public HIZMET_SUNUCU HIZMET_SUNUCU = new HIZMET_SUNUCU();
            public MEDULA_TESIS_KODU MEDULA_TESIS_KODU = new MEDULA_TESIS_KODU();
            public MEDULA_TESIS_ADI MEDULA_TESIS_ADI = new MEDULA_TESIS_ADI();
            [System.Xml.Serialization.XmlElement("KAYIT_YERI_BILGILERI", Type = typeof(KAYIT_YERI_BILGILERI))]
            public List<KAYIT_YERI_BILGILERI> KAYIT_YERI_BILGILERI;
        }

        public class KAYIT_YERI_BILGILERI
        {
            public KAYIT_YERI KAYIT_YERI;
            public MEDULA_TESIS_KODU MEDULA_TESIS_KODU = new MEDULA_TESIS_KODU();
            public MEDULA_TESIS_ADI MEDULA_TESIS_ADI = new MEDULA_TESIS_ADI();
        }

        public static SYSMessage Get()
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            SYSMessage _SYSMessage = new SYSMessage();
            recordData _recordData = new recordData();

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKRS Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            _recordData.SAGLIK_TESISI_BILGILERI.HIZMET_SUNUCU = new HIZMET_SUNUCU(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);

            string saglikTesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");

            _recordData.SAGLIK_TESISI_BILGILERI.MEDULA_TESIS_KODU.value = saglikTesisKodu;

            _SYSMessage.recordData = _recordData;

            return _SYSMessage;

        }
    }
}
