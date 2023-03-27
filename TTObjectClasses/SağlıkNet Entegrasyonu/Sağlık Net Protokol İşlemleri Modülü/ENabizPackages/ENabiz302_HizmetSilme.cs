using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz302_HizmetSilme
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
                messageType.code = "302";
                messageType.value = TTUtils.CultureService.GetText("M25959", "Hizmet Silme");
            }
        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public SilinecekHizmetBilgisi SilinecekHizmetBilgisi;

        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class SilinecekHizmetBilgisi
        {
            [System.Xml.Serialization.XmlElement("SilinecekHizmet", Type = typeof(SilinecekHizmet))]
            public List<SilinecekHizmet> SilinecekHizmet = new List<SilinecekHizmet>();
        }

        public class SilinecekHizmet
        {
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
        }

        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName) // InternalObjectGuid İşlem kaydedilirken satıra atılan aynı ID olmalı
        {
            recordData _recordData = new recordData();

            TTObjectContext objectContext = new TTObjectContext(false);

            SubActionProcedure sp = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as SubActionProcedure; //Hizmet ise
            if (sp != null)
            {
                if (sp.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sp.SubEpisode.SYSTakipNo;

                _recordData.SilinecekHizmetBilgisi = new SilinecekHizmetBilgisi();
                _recordData.SilinecekHizmetBilgisi.SilinecekHizmet = new List<SilinecekHizmet>();

                SilinecekHizmet hizmet = new SilinecekHizmet();
                hizmet.ISLEM_REFERANS_NUMARASI.value = sp.ObjectID.ToString();
                _recordData.SilinecekHizmetBilgisi.SilinecekHizmet.Add(hizmet);
            }
            else
            {
                SubActionMaterial sm = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as SubActionMaterial; //Material ise
                if (sm != null)
                {
                    if (sm.SubEpisode.SYSTakipNo == null)
                        throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                    else
                        _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sm.SubEpisode.SYSTakipNo;

                    _recordData.SilinecekHizmetBilgisi = new SilinecekHizmetBilgisi();
                    _recordData.SilinecekHizmetBilgisi.SilinecekHizmet = new List<SilinecekHizmet>();

                    SilinecekHizmet hizmet = new SilinecekHizmet();
                    hizmet.ISLEM_REFERANS_NUMARASI.value = sm.ObjectID.ToString();
                    _recordData.SilinecekHizmetBilgisi.SilinecekHizmet.Add(hizmet);
                }
                else
                {
                    ENabizMaterial eNabizMaterial = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as ENabizMaterial;
                    if(eNabizMaterial != null)
                    {
                        if (eNabizMaterial.SubActionMaterial.SubEpisode.SYSTakipNo == null)
                            throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                        else
                            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = eNabizMaterial.SubActionMaterial.SubEpisode.SYSTakipNo;

                        _recordData.SilinecekHizmetBilgisi = new SilinecekHizmetBilgisi();
                        _recordData.SilinecekHizmetBilgisi.SilinecekHizmet = new List<SilinecekHizmet>();

                        SilinecekHizmet hizmet = new SilinecekHizmet();
                        hizmet.ISLEM_REFERANS_NUMARASI.value = eNabizMaterial.ObjectID.ToString();
                        _recordData.SilinecekHizmetBilgisi.SilinecekHizmet.Add(hizmet);
                    }
                }
            }

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
