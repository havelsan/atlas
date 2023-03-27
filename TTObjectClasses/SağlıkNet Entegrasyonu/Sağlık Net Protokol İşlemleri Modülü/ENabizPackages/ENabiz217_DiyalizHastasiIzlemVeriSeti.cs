using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz217_DiyalizHastasiIzlemVeriSeti
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
                messageType.code = "217";
                messageType.value = "Diyaliz Hastasi Izlem Veri Seti";
            }

        }

        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public DIYALIZ_HASTASI_IZLEM DIYALIZ_HASTASI_IZLEM = new DIYALIZ_HASTASI_IZLEM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class DIYALIZ_HASTASI_IZLEM
        {
            public ANTIHIPERTANSIF_ILAC_KULLANIM_DURUMU ANTIHIPERTANSIF_ILAC_KULLANIM_DURUMU;       //zorunlu
            public DAMAR_ERISIM_YOLU DAMAR_ERISIM_YOLU;
            public DIYALIZE_GIRME_SIKLIGI DIYALIZE_GIRME_SIKLIGI;
            public DIYALIZOR_ALANI DIYALIZOR_ALANI;
            public DIYALIZOR_TIPI DIYALIZOR_TIPI;
            public KAN_AKIM_HIZI KAN_AKIM_HIZI;
            public KULLANILAN_DIYALIZ_TEDAVISI KULLANILAN_DIYALIZ_TEDAVISI;                 //zorunlu
            public PERITONEAL_GECIRGENLIK PERITONEAL_GECIRGENLIK;
            public PERITON_DIYALIZI_KACINCI_KATETER PERITON_DIYALIZI_KACINCI_KATETER;
            public PERITON_DIYALIZI_KATETER_TIPI PERITON_DIYALIZI_KATETER_TIPI;
            public PERITON_DIYALIZ_KATETER_YERLESTIRME_YONTEMI PERITON_DIYALIZ_KATETER_YERLESTIRME_YONTEMI;
            public PERITON_DIYALIZ_TUNEL_YONU PERITON_DIYALIZ_TUNEL_YONU;
            public SEANS_SURESI SEANS_SURESI;
            public SINEKALSET SINEKALSET;                                       //zorunlu
            public TEDAVININ_SEYRI TEDAVININ_SEYRI;                             //zorunlu
            [System.Xml.Serialization.XmlElement("AGIRLIK_BILGISI", Type = typeof(AGIRLIK_BILGISI))]
            public List<AGIRLIK_BILGISI> AGIRLIK_BILGISI;
            [System.Xml.Serialization.XmlElement("AKTIF_VITAMIN_D_KULLANIMI_BILGISI", Type = typeof(AKTIF_VITAMIN_D_KULLANIMI_BILGISI))]
            public List<AKTIF_VITAMIN_D_KULLANIMI_BILGISI> AKTIF_VITAMIN_D_KULLANIMI_BILGISI = new List<AKTIF_VITAMIN_D_KULLANIMI_BILGISI>();       //zorunlu
            [System.Xml.Serialization.XmlElement("ANEMI_TEDAVISI_YONTEMI_BILGISI", Type = typeof(ANEMI_TEDAVISI_YONTEMI_BILGISI))]
            public List<ANEMI_TEDAVISI_YONTEMI_BILGISI> ANEMI_TEDAVISI_YONTEMI_BILGISI = new List<ANEMI_TEDAVISI_YONTEMI_BILGISI>();                //zorunlu
            [System.Xml.Serialization.XmlElement("FOSFOR_BAGLAYICI_AJAN_BILGISI", Type = typeof(FOSFOR_BAGLAYICI_AJAN_BILGISI))]
            public List<FOSFOR_BAGLAYICI_AJAN_BILGISI> FOSFOR_BAGLAYICI_AJAN_BILGISI = new List<FOSFOR_BAGLAYICI_AJAN_BILGISI>();               //zorunlu
            [System.Xml.Serialization.XmlElement("PERITON_DIYALIZI_KOMPLIKASYON_BILGISI", Type = typeof(PERITON_DIYALIZI_KOMPLIKASYON_BILGISI))]
            public List<PERITON_DIYALIZI_KOMPLIKASYON_BILGISI> PERITON_DIYALIZI_KOMPLIKASYON_BILGISI;
        }
        public class AGIRLIK_BILGISI
        {
            public AGIRLIK AGIRLIK;
            public AGIRLIK_OLCUM_ZAMANI AGIRLIK_OLCUM_ZAMANI;
        }

        public class AKTIF_VITAMIN_D_KULLANIMI_BILGISI
        {
            public AKTIF_VITAMIN_D_KULLANIMI AKTIF_VITAMIN_D_KULLANIMI;
        }

        public class ANEMI_TEDAVISI_YONTEMI_BILGISI
        {
            public ANEMI_TEDAVISI_YONTEMI ANEMI_TEDAVISI_YONTEMI;
        }

        public class FOSFOR_BAGLAYICI_AJAN_BILGISI
        {
            public FOSFOR_BAGLAYICI_AJAN FOSFOR_BAGLAYICI_AJAN;
        }

        public class PERITON_DIYALIZI_KOMPLIKASYON_BILGISI
        {
            public PERITON_DIYALIZI_KOMPLIKASYON PERITON_DIYALIZI_KOMPLIKASYON;
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
            _recordData.DIYALIZ_HASTASI_IZLEM.ANTIHIPERTANSIF_ILAC_KULLANIM_DURUMU = new ANTIHIPERTANSIF_ILAC_KULLANIM_DURUMU("1", "KULLANMIYOR");
            _recordData.DIYALIZ_HASTASI_IZLEM.KULLANILAN_DIYALIZ_TEDAVISI = new KULLANILAN_DIYALIZ_TEDAVISI("1", "HEMODİYALİZ(STANDART)");
            _recordData.DIYALIZ_HASTASI_IZLEM.SINEKALSET = new SINEKALSET("1", "KULLANIYOR");
            _recordData.DIYALIZ_HASTASI_IZLEM.TEDAVININ_SEYRI = new TEDAVININ_SEYRI("3", "TRANSPLANTASYONA GİTTİ");

            AKTIF_VITAMIN_D_KULLANIMI_BILGISI dVit = new AKTIF_VITAMIN_D_KULLANIMI_BILGISI();
            dVit.AKTIF_VITAMIN_D_KULLANIMI = new AKTIF_VITAMIN_D_KULLANIMI("1", "İHTİYACI YOK");
            _recordData.DIYALIZ_HASTASI_IZLEM.AKTIF_VITAMIN_D_KULLANIMI_BILGISI.Add(dVit);
            ANEMI_TEDAVISI_YONTEMI_BILGISI anemiTedavisi = new ANEMI_TEDAVISI_YONTEMI_BILGISI();
            anemiTedavisi.ANEMI_TEDAVISI_YONTEMI = new ANEMI_TEDAVISI_YONTEMI("1", "TEDAVİ İHTİYACI YOK");
            _recordData.DIYALIZ_HASTASI_IZLEM.ANEMI_TEDAVISI_YONTEMI_BILGISI.Add(anemiTedavisi);
            FOSFOR_BAGLAYICI_AJAN_BILGISI fosforAjan = new FOSFOR_BAGLAYICI_AJAN_BILGISI();
            fosforAjan.FOSFOR_BAGLAYICI_AJAN = new FOSFOR_BAGLAYICI_AJAN("1", "KALSİYUM ASETAT");
            _recordData.DIYALIZ_HASTASI_IZLEM.FOSFOR_BAGLAYICI_AJAN_BILGISI.Add(fosforAjan);
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
