using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz501_EriskinYogunBakimSkoru
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
                messageType.code = "501";
                messageType.value = TTUtils.CultureService.GetText("M25601", "Erişkin Yoğun Bakım Skoru");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public ERISKIN_YOGUN_BAKIM_SKORU ERISKIN_YOGUN_BAKIM_SKORU = new ERISKIN_YOGUN_BAKIM_SKORU();

        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class ERISKIN_YOGUN_BAKIM_SKORU
        {
            public YOGUN_BAKIM_SEVIYE_BILGISI YOGUN_BAKIM_SEVIYE_BILGISI = new YOGUN_BAKIM_SEVIYE_BILGISI();        //Zorunlu
            public YOGUN_BAKIM_YATIS_TANISI YOGUN_BAKIM_YATIS_TANISI = new YOGUN_BAKIM_YATIS_TANISI();      //Zorunlu
            public KAYIT_YERI KAYIT_YERI = new KAYIT_YERI();                    //Zorunlu
            public APACHE_II_SKOR_BILGISI APACHE_II_SKOR_BILGISI;
            public SAPS_II_SKOR_BILGISI SAPS_II_SKOR_BILGISI;
            public SOFA_SKOR_BILGISI SOFA_SKOR_BILGISI;
            public CASUS_SKOR_BILGISI CASUS_SKOR_BILGISI;
            public GLASGOW_SKALASI GLASGOW_SKALASI;

        }

        public class GLASGOW_SKALASI
        {
            public GOZLER GOZLER;
            public SOZEL SOZEL;
            public MOTOR MOTOR;

        }
        public class APACHE_II_SKOR_BILGISI
        {
            public TOPLAM_APACHE_SKORU TOPLAM_APACHE_SKORU;
            public BEKLENEN_OLUM_ORANI BEKLENEN_OLUM_ORANI;
            public BEKLENEN_OLUM_ORANI_DUZELTILMIS BEKLENEN_OLUM_ORANI_DUZELTILMIS;
            public OLCUM_ZAMANI OLCUM_ZAMANI;           //.ToString("yyyyMMddHHmm")
        }
        public class SAPS_II_SKOR_BILGISI
        {
            public BEKLENEN_OLUM_ORANI BEKLENEN_OLUM_ORANI;
            public SAPS_II_SKORU SAPS_II_SKORU;
            public SAPS_II_GENISLETILMIS SAPS_II_GENISLETILMIS;
            public OLCUM_ZAMANI OLCUM_ZAMANI;           //.ToString("yyyyMMddHHmm")
        }

        public class SOFA_SKOR_BILGISI
        {
            public SOFA_SKORU SOFA_SKORU;
            public BEKLENEN_OLUM_ORANI BEKLENEN_OLUM_ORANI;
            public OLCUM_ZAMANI OLCUM_ZAMANI;       //.ToString("yyyyMMddHHmm")
        }

        public class CASUS_SKOR_BILGISI
        {
            public CASUS_SKORU CASUS_SKORU;
            public BEKLENEN_OLUM_ORANI BEKLENEN_OLUM_ORANI;
            public OLCUM_ZAMANI OLCUM_ZAMANI;       //.ToString("yyyyMMddHHmm")
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            recordData _recordData = new recordData();
            using (var objectContext = new TTObjectContext(true))
            {
                //InternalObjectGuid bu paket için IntensiveCareSpecialityObj'dur
                IntensiveCareSpecialityObj intensiveCareSpecialityObj = (IntensiveCareSpecialityObj)objectContext.GetObject(InternalObjectId, InternalObjectDefName);
                if (intensiveCareSpecialityObj == null)
                    throw new Exception("'501' peketini göndermek için '" + InternalObjectId + "' ObjectId'li " + InternalObjectDefName + " Objesi bulunamadı");


                var subEpisode = intensiveCareSpecialityObj.PhysicianApplication.SubEpisode;

                //HASTA_TAKIP_BILGISI
                _recordData.HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = subEpisode.SYSTakipNo;


                //ERISKIN_YOGUN_BAKIM_SKORU
                _recordData.ERISKIN_YOGUN_BAKIM_SKORU  = new ERISKIN_YOGUN_BAKIM_SKORU();

                //YOGUN_BAKIM_SEVIYE_BILGISI
                //ERİŞKİN-ÇOCUK YOĞUN BAKIM HİZMETLERİ    
                if(intensiveCareSpecialityObj.PhysicianApplication is InPatientPhysicianApplication )
                {
                    var inPatientTreatmentClinicApp = ((InPatientPhysicianApplication)intensiveCareSpecialityObj.PhysicianApplication).InPatientTreatmentClinicApp;
                    if(inPatientTreatmentClinicApp != null)
                    {
                        var baseInpatientAddmission = inPatientTreatmentClinicApp.BaseInpatientAdmission;
                        if(baseInpatientAddmission.Bed != null )
                        {
                            //P552001 Birinci basamak yoğun bakım hastası
                            //P552002 İkinci basamak yoğun bakım hastası
                            //P552003 Üçüncü basamak yoğun bakım hastası
                            var sKRSYogunBakimSeviyeBilgisi = baseInpatientAddmission.Bed.GetSKRSYogunBakimSeviyeBilgisi();
                            if (sKRSYogunBakimSeviyeBilgisi != null)
                                _recordData.ERISKIN_YOGUN_BAKIM_SKORU.YOGUN_BAKIM_SEVIYE_BILGISI = new YOGUN_BAKIM_SEVIYE_BILGISI(sKRSYogunBakimSeviyeBilgisi.KODU, sKRSYogunBakimSeviyeBilgisi.ADI);
                            else
                                throw new Exception("Hastanın Yattığı yatak bir yoğun bakım yatağı değildir");
                        }
                    }
                }
               


                //YOGUN_BAKIM_YATIS_TANISI  
                BindingList<DiagnosisGrid> subEpisodeDiagnosisList = DiagnosisGrid.GetDiagnosisBySubEpisode_OQ(objectContext, subEpisode.ObjectID.ToString());
                bool found = false;
                foreach (DiagnosisGrid dg in subEpisodeDiagnosisList)
                {
                    if (found == false || dg.IsMainDiagnose == true)
                    {
                        TerminologyManagerDef skrsDiagnose = dg.Diagnose.GetSKRSDefinition();
                        if (skrsDiagnose != null)
                        {
                            _recordData.ERISKIN_YOGUN_BAKIM_SKORU.YOGUN_BAKIM_YATIS_TANISI = new YOGUN_BAKIM_YATIS_TANISI(((SKRSICD)skrsDiagnose).KODU, ((SKRSICD)skrsDiagnose).ADI);
                            found = true;
                            if (dg.IsMainDiagnose == true) // ana tanı varsa Ana tanıyı alır yoksa ilk tanıyı alır
                                break;
                        }

                    }
                }

                //KAYIT_YERI 
                SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
                _recordData.ERISKIN_YOGUN_BAKIM_SKORU.KAYIT_YERI = myTesisSKRSKurumlarDefinition != null ? new KAYIT_YERI(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI) : null;

                //APACHE_II_SKOR_BILGISI  
                var apacheScoreList = ApacheScore.GetDescOrderedApacheScoreByEpisodeAction(objectContext, intensiveCareSpecialityObj.PhysicianApplication.ObjectID.ToString());
                foreach (var apacheScore in apacheScoreList)
                {
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI = new APACHE_II_SKOR_BILGISI();
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI.TOPLAM_APACHE_SKORU = new TOPLAM_APACHE_SKORU();
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI.TOPLAM_APACHE_SKORU.value = apacheScore.ApacheIITotal != null ? apacheScore.ApacheIITotal.ToString() : string.Empty;
                    if (apacheScore.ExpectedMortalityRate != null)
                    {
                        _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI.BEKLENEN_OLUM_ORANI = new BEKLENEN_OLUM_ORANI();
                        _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI.BEKLENEN_OLUM_ORANI.value = apacheScore.ExpectedMortalityRate.ToString();
                        _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI.BEKLENEN_OLUM_ORANI_DUZELTILMIS = new BEKLENEN_OLUM_ORANI_DUZELTILMIS();
                        _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI.BEKLENEN_OLUM_ORANI_DUZELTILMIS.value = apacheScore.ExpectedMortalityRate.ToString();
                    }
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI.OLCUM_ZAMANI = new OLCUM_ZAMANI();
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI.OLCUM_ZAMANI.value = apacheScore.EntryDate.HasValue ? apacheScore.EntryDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

                    break;
                }
                //SAPS_II_SKOR_BILGISI  
                var sapScoreList = SapsScore.GetDescOrderedSapScoreByEpisodeAction(objectContext, intensiveCareSpecialityObj.PhysicianApplication.ObjectID.ToString());
                foreach (var sapScore in sapScoreList)
                {
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.SAPS_II_SKOR_BILGISI = new SAPS_II_SKOR_BILGISI();
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.SAPS_II_SKOR_BILGISI.SAPS_II_SKORU = new SAPS_II_SKORU();
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.SAPS_II_SKOR_BILGISI.SAPS_II_SKORU.value = sapScore.SapsIIPoint != null ? sapScore.SapsIIPoint.ToString() : string.Empty;

                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.SAPS_II_SKOR_BILGISI.SAPS_II_GENISLETILMIS = new SAPS_II_GENISLETILMIS();
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.SAPS_II_SKOR_BILGISI.SAPS_II_GENISLETILMIS.value = sapScore.SapsIIPointDetail != null ? sapScore.SapsIIPointDetail.ToString() : string.Empty;

                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.SAPS_II_SKOR_BILGISI.BEKLENEN_OLUM_ORANI = new BEKLENEN_OLUM_ORANI();
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.SAPS_II_SKOR_BILGISI.BEKLENEN_OLUM_ORANI.value = sapScore.WaitingMortalite != null ? sapScore.WaitingMortalite.ToString() : string.Empty;

                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI.OLCUM_ZAMANI = new OLCUM_ZAMANI();
                    _recordData.ERISKIN_YOGUN_BAKIM_SKORU.APACHE_II_SKOR_BILGISI.OLCUM_ZAMANI.value = sapScore.EntryDate.HasValue ? sapScore.EntryDate.Value.ToString("yyyyMMddHHmm") : string.Empty;
                    break;
                }
                //SOFA_SKOR_BILGISI 
                //Henüz Yok

                //CASUS_SKOR_BILGISI
                //HEnüz Yok




                SYSMessage _SYSMessage = new SYSMessage();
                _SYSMessage.recordData = _recordData;
                return _SYSMessage;

            }

        }


        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();
            _recordData.ERISKIN_YOGUN_BAKIM_SKORU.YOGUN_BAKIM_SEVIYE_BILGISI = new YOGUN_BAKIM_SEVIYE_BILGISI("1", "1. BASAMAK YOĞUN BAKIM");
            _recordData.ERISKIN_YOGUN_BAKIM_SKORU.YOGUN_BAKIM_YATIS_TANISI = new YOGUN_BAKIM_YATIS_TANISI("J98.9", "SOLUNUM BOZUKLUKLARI, TANIMLANMAMIŞ");
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            _recordData.ERISKIN_YOGUN_BAKIM_SKORU.KAYIT_YERI = myTesisSKRSKurumlarDefinition != null ? new KAYIT_YERI(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI) : null;
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
