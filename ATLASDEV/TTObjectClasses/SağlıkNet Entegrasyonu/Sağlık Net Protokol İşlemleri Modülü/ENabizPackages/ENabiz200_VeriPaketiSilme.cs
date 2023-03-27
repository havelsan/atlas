using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz200_VeriPaketiSilme
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
                messageType.code = "200";
                messageType.value = TTUtils.CultureService.GetText("M27187", "Veri Paketi Silme");
            }
        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public VERI_PAKETI_SILME VERI_PAKETI_SILME = new VERI_PAKETI_SILME();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class VERI_PAKETI_SILME
        {
            public SILINECEK_VERI_PAKETI SILINECEK_VERI_PAKETI = new SILINECEK_VERI_PAKETI(); //Silinmek istenen veri paketi tagı gönderilmelidir. örn: "KADIN_IZLEM_15_49_YAS"
        }

        public static SYSMessage Get(Guid SubEpisodeID,string PackageName)  
        {
            recordData _recordData = new recordData();

            TTObjectContext objectContext = new TTObjectContext(false);
          
            SubEpisode subepisode = objectContext.GetObject(SubEpisodeID, "SUBEPISODE") as SubEpisode;
         
            if (subepisode.SYSTakipNo == null)
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = subepisode.SYSTakipNo;

            _recordData.VERI_PAKETI_SILME.SILINECEK_VERI_PAKETI.value = PackageName;
    
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
