using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz108_TeleTipSonucKayit
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
                messageType.code = "108";
                messageType.value = "TeleTıp Sonuç Kayıt";
            }
        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public TELETIP_SONUC_BILGILERI TELETIP_SONUC_BILGILERI = new TELETIP_SONUC_BILGILERI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class TELETIP_SONUC_BILGILERI
        {
            [System.Xml.Serialization.XmlElement("TELETIP_BILGILERI", Type = typeof(TELETIP_BILGILERI))]
            public List<TELETIP_BILGILERI> TELETIP_BILGILERI = new List<TELETIP_BILGILERI>();
        }

        public class TELETIP_BILGILERI
        {
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
            public TELETIP_SONUC_BILGISI TELETIP_SONUC_BILGISI = new TELETIP_SONUC_BILGISI();
        }

        public class TELETIP_SONUC_BILGISI
        {
            public ACCESSION_NUMBER ACCESSION_NUMBER;
            public CEKIM_ZAMANI CEKIM_ZAMANI;
            public SGK_TAKIP_NUMARASI SGK_TAKIP_NUMARASI;
        }


        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            recordData _recordData = new recordData();

            using (var objectContext = new TTObjectContext(false))
            {

                RadiologyTest radiologyTest = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as RadiologyTest;
                if (radiologyTest != null)
                {
                    if (radiologyTest.IsCancelled != true)
                    {
                        TELETIP_BILGILERI teletipBilgisi = new TELETIP_BILGILERI();
                        teletipBilgisi.ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
                        teletipBilgisi.ISLEM_REFERANS_NUMARASI.value = radiologyTest.ObjectID.ToString();
                        teletipBilgisi.TELETIP_SONUC_BILGISI.ACCESSION_NUMBER = new ACCESSION_NUMBER();
                        teletipBilgisi.TELETIP_SONUC_BILGISI.ACCESSION_NUMBER.value = radiologyTest.AccessionNo?.ToString();
                        teletipBilgisi.TELETIP_SONUC_BILGISI.CEKIM_ZAMANI = new CEKIM_ZAMANI();
                        teletipBilgisi.TELETIP_SONUC_BILGISI.CEKIM_ZAMANI.value = ((DateTime)radiologyTest.TestDate).ToString("yyyyMMddHHmm");
                        SubEpisodeProtocol sep = radiologyTest.SubEpisode.SGKSEPWithProvisionNo;
                        teletipBilgisi.TELETIP_SONUC_BILGISI.SGK_TAKIP_NUMARASI = new SGK_TAKIP_NUMARASI();
                        if (sep != null)
                            teletipBilgisi.TELETIP_SONUC_BILGISI.SGK_TAKIP_NUMARASI.value = sep.MedulaTakipNo;
                        else
                            teletipBilgisi.TELETIP_SONUC_BILGISI.SGK_TAKIP_NUMARASI.value = "";
                        if (radiologyTest.SubEpisode.SYSTakipNo == null)
                            throw new Exception("SubEpisode a ait SYSTakipNo bulunamadı.");
                        else
                            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = radiologyTest.SubEpisode.SYSTakipNo;
                        _recordData.TELETIP_SONUC_BILGILERI.TELETIP_BILGILERI.Add(teletipBilgisi);
                    }
                    else
                        throw new Exception("RadiologyTest iptal edilmiş.");

                }
                else
                    throw new Exception("RadiologyTest Bulunamadı.");





                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }
        }
    }
}
