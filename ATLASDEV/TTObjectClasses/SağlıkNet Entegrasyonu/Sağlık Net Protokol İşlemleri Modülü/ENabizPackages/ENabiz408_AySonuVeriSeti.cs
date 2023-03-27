using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TTObjectClasses
{
    public class ENabiz408_AySonuVeriSeti
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
                messageType.code = "408";
                messageType.value = "Ay Sonu Veri Seti";
            }
        }
        public class recordData
        {
            public AY_SONU_VERI_SETI AY_SONU_VERI_SETI = new AY_SONU_VERI_SETI();

        }

        public class AY_SONU_VERI_SETI
        {
            public KAYIT_YERI KAYIT_YERI = new KAYIT_YERI();
            public KALITE_YIL KALITE_YIL = new KALITE_YIL();
            public KALITE_AY KALITE_AY = new KALITE_AY();
            [XmlElement("KLINIK_KODU_KALITE_BILGISI")]
            public List<KLINIK_KODU_KALITE_BILGISI> KLINIK_KODU_KALITE_BILGISI = new List<KLINIK_KODU_KALITE_BILGISI>();

        }

        public class KLINIK_KODU_KALITE_BILGISI
        {
            public KLINIK_KODU KLINIK_KODU = new KLINIK_KODU();
            [XmlElement("KLINIK_KALITE_BILGISI")]
            public List<KLINIK_KALITE_BILGISI> KLINIK_KALITE_BILGISI = new List<KLINIK_KALITE_BILGISI>();
         
        }

        public class KLINIK_KALITE_BILGISI
        {
            public KLINIK_KALITE_TANIM KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM();
            public KLINIK_KALITE_SAYI KLINIK_KALITE_SAYI = new KLINIK_KALITE_SAYI();
        }
        public static SYSMessage Get()
        {
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();
            _recordData.AY_SONU_VERI_SETI = new AY_SONU_VERI_SETI();

            _recordData.AY_SONU_VERI_SETI.KAYIT_YERI = new KAYIT_YERI(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);
            _recordData.AY_SONU_VERI_SETI.KALITE_YIL.value ="2017"; 
            _recordData.AY_SONU_VERI_SETI.KALITE_AY.value = "7";
            
            //Klinik kodu skrsdeki klinik kodu bizde specialitydefinionsta skrsklinik
            //hastahanede tanımlı olan tüm birimlerdeki gün sonu özet veri tablosundaki verilerin bir ay içinde yapılma sayıları(birim birim)

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
