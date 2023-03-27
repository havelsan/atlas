using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;
namespace TTObjectClasses
{
    public class ENabiz235_KronikHastaliklarVeriSeti
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
                messageType.code = "235";
                messageType.value = TTUtils.CultureService.GetText("M26345", "Kronik Hastaliklar Veri Seti");
            }

        }

        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public KRONIK_HASTALIKLAR KRONIK_HASTALIKLAR = new KRONIK_HASTALIKLAR();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class KRONIK_HASTALIKLAR
        {
            public ILK_TANI_TARIHI ILK_TANI_TARIHI = new ILK_TANI_TARIHI();
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI = new PAKETE_AIT_ISLEM_ZAMANI();
            public SPIROMETRI SPIROMETRI; 
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            KronikHastaliklarVeriSeti kronikHastaliklar = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as KronikHastaliklarVeriSeti;
            if (kronikHastaliklar == null)
                throw new Exception("'235' paketini göndermek için " + InternalObjectId + " ObjectId'li KronikHastaliklarVeriSeti Objesi bulunamadı");

            recordData _recordData = new recordData();
            
            _recordData.KRONIK_HASTALIKLAR.PAKETE_AIT_ISLEM_ZAMANI.value = kronikHastaliklar.PaketeAitIslemZamani.HasValue ? kronikHastaliklar.PaketeAitIslemZamani.Value.ToString("yyyyMMddHHmm") : string.Empty;
            _recordData.KRONIK_HASTALIKLAR.ILK_TANI_TARIHI.value = kronikHastaliklar.IlkTaniTarihi.HasValue ? kronikHastaliklar.IlkTaniTarihi.Value.ToString("yyyyMMddHHmm") : string.Empty;

            if (kronikHastaliklar.SKRSSpirometri != null)
                _recordData.KRONIK_HASTALIKLAR.SPIROMETRI = new TTObjectClasses.SPIROMETRI(kronikHastaliklar.SKRSSpirometri.KODU, kronikHastaliklar.SKRSSpirometri.ADI);

            if (kronikHastaliklar.SubEpisode.SYSTakipNo == null)
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = kronikHastaliklar.SubEpisode.SYSTakipNo;


            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
