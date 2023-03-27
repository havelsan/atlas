using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz227_GETATVeriSeti
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
                messageType.code = "227";
                messageType.value = "Geleneksel ve Tamamlayıcı Tıp Uygulamaları Veri Seti";
            }
        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public GELENEKSEL_VE_TAMAMLAYICI_TIP_BILGILERI GELENEKSEL_VE_TAMAMLAYICI_TIP_BILGILERI = new GELENEKSEL_VE_TAMAMLAYICI_TIP_BILGILERI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class GELENEKSEL_VE_TAMAMLAYICI_TIP_BILGILERI
        {
            public GETAT_UYGULAMA_BIRIMI UYGULAMA_BIRIMI = new GETAT_UYGULAMA_BIRIMI();
            [System.Xml.Serialization.XmlElement("UYGULAMA_BILGILERI", Type = typeof(UYGULAMA_BILGILERI))]
            public List<UYGULAMA_BILGILERI> UYGULAMA_BILGILERI = new List<UYGULAMA_BILGILERI>();
        }

        public class UYGULAMA_BILGILERI
        {
            public GERI_BILDIRIMI_MECBURI_OLAN_KOMPLIKASYON GERI_BILDIRIMI_MECBURI_OLAN_KOMPLIKASYON;
            public UYGULAMA_TURU UYGULAMA_TURU;
            public TEDAVI_SONUCU TEDAVI_SONUCU;
            [System.Xml.Serialization.XmlElement("UYGULANDIGI_DURUM_BILGILERI", Type = typeof(UYGULANDIGI_DURUM_BILGILERI))]
            public List<UYGULANDIGI_DURUM_BILGILERI> UYGULANDIGI_DURUM_BILGILERI = new List<UYGULANDIGI_DURUM_BILGILERI>();
            [System.Xml.Serialization.XmlElement("UYGULAMA_BOLGESI_BILGILERI", Type = typeof(UYGULAMA_BOLGESI_BILGILERI))]
            public List<UYGULAMA_BOLGESI_BILGILERI> UYGULAMA_BOLGESI_BILGILERI = new List<UYGULAMA_BOLGESI_BILGILERI>();
        }

        public class UYGULANDIGI_DURUM_BILGILERI
        {
            public UYGULANDIGI_DURUM UYGULANDIGI_DURUM;
        }
        public class UYGULAMA_BOLGESI_BILGILERI
        {
            public UYGULAMA_BOLGESI UYGULAMA_BOLGESI;
        }


        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            recordData _recordData = new recordData();

            using (var objectContext = new TTObjectContext(false))
            {

                TraditionalMedicine traditionalMedicineObject = objectContext.GetObject<TraditionalMedicine>(InternalObjectId, false);
                if (traditionalMedicineObject == null)
                    throw new Exception("'227' paketini göndermek için " + InternalObjectId + " ObjectId'li TraditionalMedicine Objesi bulunamadı.");
                _recordData.GELENEKSEL_VE_TAMAMLAYICI_TIP_BILGILERI = new GELENEKSEL_VE_TAMAMLAYICI_TIP_BILGILERI();
                if (traditionalMedicineObject.GetatApplicationUnit != null)
                    _recordData.GELENEKSEL_VE_TAMAMLAYICI_TIP_BILGILERI.UYGULAMA_BIRIMI = new GETAT_UYGULAMA_BIRIMI(traditionalMedicineObject.GetatApplicationUnit.KODU, traditionalMedicineObject.GetatApplicationUnit.ADI);

                //  if()
                _recordData.GELENEKSEL_VE_TAMAMLAYICI_TIP_BILGILERI.UYGULAMA_BILGILERI = new List<UYGULAMA_BILGILERI>();
                UYGULAMA_BILGILERI uygulamaBilgileri = new UYGULAMA_BILGILERI();
                if (traditionalMedicineObject.GetatApplicationType != null)
                    uygulamaBilgileri.UYGULAMA_TURU = new UYGULAMA_TURU(traditionalMedicineObject.GetatApplicationType.KODU, traditionalMedicineObject.GetatApplicationType.ADI);
                if (traditionalMedicineObject.GetatExaminationResult != null)
                    uygulamaBilgileri.TEDAVI_SONUCU = new TEDAVI_SONUCU(traditionalMedicineObject.GetatExaminationResult.KODU, traditionalMedicineObject.GetatExaminationResult.ADI);
                if (traditionalMedicineObject.TraditionalMedAppCases.Count > 0)
                {
                    uygulamaBilgileri.UYGULANDIGI_DURUM_BILGILERI = new List<UYGULANDIGI_DURUM_BILGILERI>();
                    foreach (var durumBilgisi in traditionalMedicineObject.TraditionalMedAppCases)
                    {
                        UYGULANDIGI_DURUM_BILGILERI uygulandigiDurumBilgileri = new UYGULANDIGI_DURUM_BILGILERI();
                        uygulandigiDurumBilgileri.UYGULANDIGI_DURUM = new UYGULANDIGI_DURUM(durumBilgisi.SKRSGetatAppliedCases.KODU.ToString(), durumBilgisi.SKRSGetatAppliedCases.UYGULANACAKDURUMLAR);
                        uygulamaBilgileri.UYGULANDIGI_DURUM_BILGILERI.Add(uygulandigiDurumBilgileri);
                    }
                   
                }
                if (traditionalMedicineObject.TraditionalMedAppRegion.Count > 0)
                {
                    uygulamaBilgileri.UYGULAMA_BOLGESI_BILGILERI = new List<UYGULAMA_BOLGESI_BILGILERI>();
                    foreach (var bolgeBilgisi in traditionalMedicineObject.TraditionalMedAppRegion)
                    {
                        UYGULAMA_BOLGESI_BILGILERI uygulandigiBolgeBilgileri = new UYGULAMA_BOLGESI_BILGILERI();
                        uygulandigiBolgeBilgileri.UYGULAMA_BOLGESI = new UYGULAMA_BOLGESI(bolgeBilgisi.SKRSGetatApplicationRegion.KODU.ToString(), bolgeBilgisi.SKRSGetatApplicationRegion.ADI);
                        uygulamaBilgileri.UYGULAMA_BOLGESI_BILGILERI.Add(uygulandigiBolgeBilgileri);
                    }

                }
                _recordData.GELENEKSEL_VE_TAMAMLAYICI_TIP_BILGILERI.UYGULAMA_BILGILERI.Add(uygulamaBilgileri);

                //HASTA_TAKIP_BILGISI
                _recordData.HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = traditionalMedicineObject.PhysicianApplication.SubEpisode.SYSTakipNo;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }
        }
    }
}
