using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz268_HekimPuanBilgisi
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
                messageType.code = "268";
                messageType.value = "Hekim Puan Bilgisi";
            }
        }
        public class recordData
        {
            public HEKIM_PUAN_BILGILERI HEKIM_PUAN_BILGILERI = new HEKIM_PUAN_BILGILERI();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI;
        }

        public class HEKIM_PUAN_BILGILERI
        {
            public KAYIT_YERI KAYIT_YERI;
            [System.Xml.Serialization.XmlElement("PUAN_BILGILERI", Type = typeof(PUAN_BILGILERI))]
            public List<PUAN_BILGILERI> PUAN_BILGILERI = new List<PUAN_BILGILERI>();
        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class PUAN_BILGILERI
        {
            public GERCEKLESME_ZAMANI GERCEKLESME_ZAMANI = new GERCEKLESME_ZAMANI();
            public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
            public EDINILEN_ISLEM_PUANI EDINILEN_ISLEM_PUANI = new EDINILEN_ISLEM_PUANI();
            public OZELLIKLI_ISLEM_DURUMU OZELLIKLI_ISLEM_DURUMU =new OZELLIKLI_ISLEM_DURUMU();
            public ISLEM_ADEDI ISLEM_ADEDI = new ISLEM_ADEDI();
            public TIBBI_ISLEM_PUAN_BILGISI TIBBI_ISLEM_PUAN_BILGISI = new TIBBI_ISLEM_PUAN_BILGISI();
        }

        public static SYSMessage Get(Guid subepisodeID,Guid termID)
        {
            recordData _recordData = new recordData();

            using(var objectContext = new TTObjectContext(true))
            {
                SubEpisode se = objectContext.GetObject<SubEpisode>(subepisodeID) as SubEpisode;
                _recordData.HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
                if (se != null)
                {   
                    if (se.SYSTakipNo == null)
                        throw new Exception("SubEpisode a ait SYSTakipNo bulunamadı.");
                    else
                        _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = se.SYSTakipNo;

                    _recordData.HEKIM_PUAN_BILGILERI = new HEKIM_PUAN_BILGILERI();
                    _recordData.HEKIM_PUAN_BILGILERI.PUAN_BILGILERI = new List<PUAN_BILGILERI>();
                    BindingList<DPDetail>  tempDetailList  = DPDetail.getDPDetailWithSEAndTerm(objectContext, termID, subepisodeID);
                    foreach (var item in tempDetailList)
                    {
                        BindingList<SendToENabiz.GetCountOfSuccesPackage_Class> tempList = SendToENabiz.GetCountOfSuccesPackage(objectContext, item.SubActionProcedure.ObjectID, "102");
                        if (tempList.Count > 0)
                        {
                            PUAN_BILGILERI PUAN_BILGILERI = new PUAN_BILGILERI();
                            PUAN_BILGILERI.OZELLIKLI_ISLEM_DURUMU.value = "0"; //Sonradan özellikli işlem veritabanında tutulduğu zaman eklenecek.
                            PUAN_BILGILERI.EDINILEN_ISLEM_PUANI.value = item.CalcPoint.HasValue ? item.CalcPoint.Value.ToString() : "0";
                            PUAN_BILGILERI.GERCEKLESME_ZAMANI.value = item.PerformedDate.Value.ToString("yyyyMMddHHmm");
                            PUAN_BILGILERI.HEKIM_KIMLIK_NUMARASI.value = item.DPMaster.Doctor.UniqueNo;
                            PUAN_BILGILERI.ISLEM_ADEDI.value = "1";
                            PUAN_BILGILERI.ISLEM_REFERANS_NUMARASI.value = item.SubActionProcedure.ObjectID.ToString();
                            PUAN_BILGILERI.TIBBI_ISLEM_PUAN_BILGISI = new TIBBI_ISLEM_PUAN_BILGISI(item.GILCode, item.GILPoint.HasValue ? item.GILPoint.Value.ToString() : "0");
                            _recordData.HEKIM_PUAN_BILGILERI.PUAN_BILGILERI.Add(PUAN_BILGILERI);
                        }
                    }
                    SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

                    if (myTesisSKRSKurumlarDefinition == null)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
                    }
                    if (myTesisSKRSKurumlarDefinition != null)
                    {
                        _recordData.HEKIM_PUAN_BILGILERI.KAYIT_YERI = new KAYIT_YERI(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);//?? Semp Policlinikleri için düzenlenmeli
                    }
                }
                else
                {
                    throw new Exception("Subepisode bulunamadı.");
                }
            }

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            if (_sYSMessage.recordData.HEKIM_PUAN_BILGILERI.PUAN_BILGILERI.Count == 0)
                _sYSMessage = null;
            return _sYSMessage;
        }

    }
}
