using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz409_RadyolojiSonucKayitPaketi
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
                messageType.code = "409";
                messageType.value = "Radyoloji Sonuç Kayıt Paketi";
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
            public RADYOLOJI_SONUC_KAYIT RADYOLOJI_SONUC_KAYIT = new RADYOLOJI_SONUC_KAYIT();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class RADYOLOJI_BILGISI
        {
            public RADYOLOJI_LOINC RADYOLOJI_LOINC;
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
            public RAPOR_ONAYLANMA_ZAMANI RAPOR_ONAYLANMA_ZAMANI = new RAPOR_ONAYLANMA_ZAMANI();
            public RAPOR_SONUC_BILGISI RAPOR_SONUC_BILGISI = new RAPOR_SONUC_BILGISI();
        }

        public class RADYOLOJI_SONUC_KAYIT
        {
            [System.Xml.Serialization.XmlElement("RADYOLOJI_BILGISI", Type = typeof(RADYOLOJI_BILGISI))]
            public List<RADYOLOJI_BILGISI> RADYOLOJI_BILGISI = new List<RADYOLOJI_BILGISI>();
        }

        public class RAPOR_SONUC_BILGISI
        {
            public SONUC_BASLIK SONUC_BASLIK = new SONUC_BASLIK();
            public SONUC_ACIKLAMA SONUC_ACIKLAMA = new SONUC_ACIKLAMA();
        }
        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                
                recordData _recordData = new recordData();
                
                SubActionProcedure sp = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as SubActionProcedure;
                if (sp != null)
                {
                    if (!sp.IsCancelled)
                    {
                        if (sp.SubEpisode.SYSTakipNo == null)
                            throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                        else
                            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sp.SubEpisode.SYSTakipNo;

                        RADYOLOJI_BILGISI RADYOLOJI_BILGISI = new RADYOLOJI_BILGISI();
                        RADYOLOJI_BILGISI.ISLEM_REFERANS_NUMARASI.value = sp.ObjectID.ToString();
                        if (sp.ProcedureObject.SKRSLoincKodu != null)
                        {
                            RADYOLOJI_BILGISI.RADYOLOJI_LOINC = new RADYOLOJI_LOINC();
                            RADYOLOJI_BILGISI.RADYOLOJI_LOINC = new RADYOLOJI_LOINC(sp.ProcedureObject.SKRSLoincKodu.LOINCNUMARASI, sp.ProcedureObject.SKRSLoincKodu.LOINCTURKCEKARSILIGI.ToString());
                        }
                        RADYOLOJI_BILGISI.RAPOR_ONAYLANMA_ZAMANI.value = (((RadiologyTest)sp).ReportDate).Value.ToString("yyyyMMddHHmm");

                        RAPOR_SONUC_BILGISI RAPOR_SONUC_BILGISI = new RAPOR_SONUC_BILGISI();
                        RAPOR_SONUC_BILGISI.SONUC_BASLIK.value = "RADYOLOJİ SONUÇ RAPORU";
                        RAPOR_SONUC_BILGISI.SONUC_ACIKLAMA.value = ((RadiologyTest)sp).ReportTxt.ToString();
                        RADYOLOJI_BILGISI.RAPOR_SONUC_BILGISI = RAPOR_SONUC_BILGISI;

                        RADYOLOJI_SONUC_KAYIT RADYOLOJI_SONUC_KAYIT = new RADYOLOJI_SONUC_KAYIT();
                        RADYOLOJI_SONUC_KAYIT.RADYOLOJI_BILGISI = new List<RADYOLOJI_BILGISI>();
                        RADYOLOJI_SONUC_KAYIT.RADYOLOJI_BILGISI.Add(RADYOLOJI_BILGISI);

                        _recordData.RADYOLOJI_SONUC_KAYIT = RADYOLOJI_SONUC_KAYIT;
                    }
                }

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }

    }
}
