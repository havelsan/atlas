using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz216_DiyalizHastasiBildirimVeriSeti
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
                messageType.code = "216";
                messageType.value = TTUtils.CultureService.GetText("M25501", "Diyaliz Hastasi Bildirim Veri Seti");
            }

        }

        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public DIYALIZ_HASTASI_BILDIRIM DIYALIZ_HASTASI_BILDIRIM = new DIYALIZ_HASTASI_BILDIRIM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class DIYALIZ_HASTASI_BILDIRIM
        {
            public DIYALIZ_TEDAVISINE_BASLAMA_TARIHI DIYALIZ_TEDAVISINE_BASLAMA_TARIHI;     //zorunlu
            public PRIMER_TANI PRIMER_TANI;     //Zorunlu
            [System.Xml.Serialization.XmlElement("BIRLIKTE_GORULEN_EK_HASTALIKLAR_BILGISI", Type = typeof(BIRLIKTE_GORULEN_EK_HASTALIKLAR_BILGISI))]
            public List<BIRLIKTE_GORULEN_EK_HASTALIKLAR_BILGISI> RISKLI_TEMAS_TIPI_BILGISI = new List<BIRLIKTE_GORULEN_EK_HASTALIKLAR_BILGISI>();
            [System.Xml.Serialization.XmlElement("DIYALIZ_TEDAVISI_YONTEMI_BILGISI", Type = typeof(DIYALIZ_TEDAVISI_YONTEMI_BILGISI))]
            public List<DIYALIZ_TEDAVISI_YONTEMI_BILGISI> DIYALIZ_TEDAVISI_YONTEMI_BILGISI = new List<DIYALIZ_TEDAVISI_YONTEMI_BILGISI>();      //Zorunlu
            [System.Xml.Serialization.XmlElement("HEMODIYALIZE_GECME_NEDENLERI_BILGISI", Type = typeof(HEMODIYALIZE_GECME_NEDENLERI_BILGISI))]
            public List<HEMODIYALIZE_GECME_NEDENLERI_BILGISI> HEMODIYALIZE_GECME_NEDENLERI_BILGISI = new List<HEMODIYALIZE_GECME_NEDENLERI_BILGISI>();
            [System.Xml.Serialization.XmlElement("ONCEKI_RRT_YONTEMI_BILGISI", Type = typeof(ONCEKI_RRT_YONTEMI_BILGISI))]
            public List<ONCEKI_RRT_YONTEMI_BILGISI> ONCEKI_RRT_YONTEMI_BILGISI = new List<ONCEKI_RRT_YONTEMI_BILGISI>();        //Zorunlu
        }
        public class BIRLIKTE_GORULEN_EK_HASTALIKLAR_BILGISI
        {
            public BIRLIKTE_GORULEN_EK_HASTALIKLAR BIRLIKTE_GORULEN_EK_HASTALIKLAR;
        }

        public class DIYALIZ_TEDAVISI_YONTEMI_BILGISI
        {
            public DIYALIZ_TEDAVISI_YONTEMI DIYALIZ_TEDAVISI_YONTEMI;
        }

        public class HEMODIYALIZE_GECME_NEDENLERI_BILGISI
        {
            public HEMODIYALIZE_GECME_NEDENLERI HEMODIYALIZE_GECME_NEDENLERI;
        }

        public class ONCEKI_RRT_YONTEMI_BILGISI
        {
            public ONCEKI_RRT_YONTEMI ONCEKI_RRT_YONTEMI;
        }

        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            
            using (var objectContext = new TTObjectContext(false))
            {
                //Burası Doldurulacak


                /*GlassesReport gozlukRecetesi = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as GlassesReport;
                if (gozlukRecetesi == null)
                    throw new Exception("'226' paketini göndermek için " + InternalObjectId + " ObjectId'li GlassesReport Objesi bulunamadı.");*/

                recordData _recordData = new recordData();
                _recordData.DIYALIZ_HASTASI_BILDIRIM.DIYALIZ_TEDAVISINE_BASLAMA_TARIHI = new DIYALIZ_TEDAVISINE_BASLAMA_TARIHI();
                _recordData.DIYALIZ_HASTASI_BILDIRIM.DIYALIZ_TEDAVISINE_BASLAMA_TARIHI.value = "201801010000";
                _recordData.DIYALIZ_HASTASI_BILDIRIM.PRIMER_TANI = new PRIMER_TANI("J98.9", "SOLUNUM BOZUKLUKLARI, TANIMLANMAMIŞ");
                DIYALIZ_TEDAVISI_YONTEMI_BILGISI tedaviYontemi = new DIYALIZ_TEDAVISI_YONTEMI_BILGISI();
                tedaviYontemi.DIYALIZ_TEDAVISI_YONTEMI = new DIYALIZ_TEDAVISI_YONTEMI("1", "HEMODİYALİZ");
                _recordData.DIYALIZ_HASTASI_BILDIRIM.DIYALIZ_TEDAVISI_YONTEMI_BILGISI.Add(tedaviYontemi);
                ONCEKI_RRT_YONTEMI_BILGISI rrtYontemi = new ONCEKI_RRT_YONTEMI_BILGISI();
                rrtYontemi.ONCEKI_RRT_YONTEMI = new ONCEKI_RRT_YONTEMI("1", "HEMODİYALİZ");
                _recordData.DIYALIZ_HASTASI_BILDIRIM.ONCEKI_RRT_YONTEMI_BILGISI.Add(rrtYontemi);

                /* if (gozlukRecetesi.SubEpisode.SYSTakipNo == null)
                     throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                 else
                     _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = gozlukRecetesi.SubEpisode.SYSTakipNo;*/

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();
            _recordData.DIYALIZ_HASTASI_BILDIRIM.DIYALIZ_TEDAVISINE_BASLAMA_TARIHI = new DIYALIZ_TEDAVISINE_BASLAMA_TARIHI();
            _recordData.DIYALIZ_HASTASI_BILDIRIM.DIYALIZ_TEDAVISINE_BASLAMA_TARIHI.value = "201801010000";
            _recordData.DIYALIZ_HASTASI_BILDIRIM.PRIMER_TANI = new PRIMER_TANI("J98.9", "SOLUNUM BOZUKLUKLARI, TANIMLANMAMIŞ");
            DIYALIZ_TEDAVISI_YONTEMI_BILGISI tedaviYontemi = new DIYALIZ_TEDAVISI_YONTEMI_BILGISI();
            tedaviYontemi.DIYALIZ_TEDAVISI_YONTEMI = new DIYALIZ_TEDAVISI_YONTEMI("1", "HEMODİYALİZ");
            _recordData.DIYALIZ_HASTASI_BILDIRIM.DIYALIZ_TEDAVISI_YONTEMI_BILGISI.Add(tedaviYontemi);
            ONCEKI_RRT_YONTEMI_BILGISI rrtYontemi = new ONCEKI_RRT_YONTEMI_BILGISI();
            rrtYontemi.ONCEKI_RRT_YONTEMI = new ONCEKI_RRT_YONTEMI("1", "HEMODİYALİZ");
            _recordData.DIYALIZ_HASTASI_BILDIRIM.ONCEKI_RRT_YONTEMI_BILGISI.Add(rrtYontemi);
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";
            /* if (gozlukRecetesi.SubEpisode.SYSTakipNo == null)
                 throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
             else
                 _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = gozlukRecetesi.SubEpisode.SYSTakipNo;*/

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

    }
}
