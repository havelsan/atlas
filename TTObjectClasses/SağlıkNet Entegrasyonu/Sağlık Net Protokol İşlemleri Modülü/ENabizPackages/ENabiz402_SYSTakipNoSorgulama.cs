using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class ENabiz402_SYSTakipNoSorgulama
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
                messageType.code = "402";
                messageType.value = "SYS Takip No Sorgulama";
            }
        }
        public class healthcareProvider : CodeBase
        {
            public healthcareProvider()
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";

            }

            public healthcareProvider(string Code, string Value)
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";
                code = Code;
                value = Value;

            }
        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
          
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public static SYSMessage Get(string SYSTakipNo)
        {
            recordData _recordData = new recordData();
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = SYSTakipNo;
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
