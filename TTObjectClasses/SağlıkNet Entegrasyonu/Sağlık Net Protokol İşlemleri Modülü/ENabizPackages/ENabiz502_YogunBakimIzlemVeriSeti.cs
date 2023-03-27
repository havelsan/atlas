using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz502_YogunBakimIzlemVeriSeti
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
                messageType.code = "502";
                messageType.value = "Yoğun Bakım Izlem Veri Seti";
            }
        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public YOGUN_BAKIM_IZLEM_BILGILERI YOGUN_BAKIM_IZLEM_BILGILERI;

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class YOGUN_BAKIM_IZLEM_BILGILERI
        {
            public YOGUN_BAKIM_YATIS_TARIHI YOGUN_BAKIM_YATIS_TARIHI = new YOGUN_BAKIM_YATIS_TARIHI(); //Zorunlu
            public YOGUN_BAKIM_TIPI YOGUN_BAKIM_TIPI = new YOGUN_BAKIM_TIPI(); //Zorunlu-SKRS Objesi

            [System.Xml.Serialization.XmlElement("IZLEM_BILGISI", Type = typeof(IZLEM_BILGISI))]
            public List<IZLEM_BILGISI> IZLEM_BILGISI = new List<IZLEM_BILGISI>();

        }
        public class IZLEM_BILGISI
        {
            public VENTILASYON_DURUMU VENTILASYON_DURUMU; //SKRS Objesi
            public IZLEM_ZAMANI IZLEM_ZAMANI;
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI; //Bu alana ilgili yoğun bakım hizmetine ait 102 Nolu Hizmet kayit paketinde göndermis oldugunuz Islem Referans Numarasini göndermelisiniz.
            public GUNLUK_IZLEM_NOTU GUNLUK_IZLEM_NOTU;
            public SEPTIK_SOK SEPTIK_SOK; //SKRS Objesi
            public SEPSIS_DURUMU SEPSIS_DURUMU; //SKRS Objesi
            public YOGUN_BAKIM_SEVIYE_BILGISI YOGUN_BAKIM_SEVIYE_BILGISI; //SKRS Objesi
            [System.Xml.Serialization.XmlElement("APACHE_II_SKOR_BILGISI", Type = typeof(APACHE_II_SKOR_BILGISI))]
            public List<APACHE_II_SKOR_BILGISI> APACHE_II_SKOR_BILGISI;
            [System.Xml.Serialization.XmlElement("SNAP_II_SKOR_BILGISI", Type = typeof(SNAP_II_SKOR_BILGISI))]
            public List<SNAP_II_SKOR_BILGISI> SNAP_II_SKOR_BILGISI;
            [System.Xml.Serialization.XmlElement("GLASGOW_SKALASI", Type = typeof(GLASGOW_SKALASI))]
            public List<GLASGOW_SKALASI> GLASGOW_SKALASI;
            [System.Xml.Serialization.XmlElement("PRISM_SKOR_BILGISI", Type = typeof(PRISM_SKOR_BILGISI))]
            public List<PRISM_SKOR_BILGISI> PRISM_SKOR_BILGISI;

        }

        public class APACHE_II_SKOR_BILGISI
        {
            public TOPLAM_APACHE_SKORU TOPLAM_APACHE_SKORU;
            public BEKLENEN_OLUM_ORANI BEKLENEN_OLUM_ORANI;
            public BEKLENEN_OLUM_ORANI_DUZELTILMIS BEKLENEN_OLUM_ORANI_DUZELTILMIS;
            public OLCUM_ZAMANI OLCUM_ZAMANI;

        }
        public class SNAP_II_SKOR_BILGISI
        {
            public SNAP_II_SKORU SNAP_II_SKORU;
            public SNAP_PE_II_SKORU SNAP_PE_II_SKORU;
            public OLCUM_ZAMANI OLCUM_ZAMANI;
        }

        public class GLASGOW_SKALASI
        {
            public GOZLER GOZLER;
            public SOZEL SOZEL;
            public MOTOR MOTOR;
        }

        public class PRISM_SKOR_BILGISI
        {
            public TOPLAM_PRISM_SKORU TOPLAM_PRISM_SKORU;
            public BEKLENEN_OLUM_ORANI BEKLENEN_OLUM_ORANI;
            public OLCUM_ZAMANI OLCUM_ZAMANI;
        }
        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            recordData _recordData = new recordData();
            using (var objectContext = new TTObjectContext(true))
            {
                //InternalObjectId bu paket için BaseBedProcedure'dur
                BedProcedure bedProcedure = (BedProcedure)objectContext.GetObject(InternalObjectId, InternalObjectDefName);
                BaseBedProcedure baseBedProcedure = bedProcedure.BaseBedProcedure;
                DateTime izlemZamani = bedProcedure.PricingDate.Value;

                if (baseBedProcedure.InPatientTreatmentClinicApp != null && baseBedProcedure.InPatientTreatmentClinicApp.InPatientPhysicianApplication.Count > 0)
                {
                    var subEpisode = baseBedProcedure.InPatientTreatmentClinicApp.SubEpisode;

                    //HASTA_TAKIP_BILGISI
                    _recordData.HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = subEpisode.SYSTakipNo;

                    //YOGUN_BAKIM_IZLEM_BILGILERI
                    _recordData.YOGUN_BAKIM_IZLEM_BILGILERI = new YOGUN_BAKIM_IZLEM_BILGILERI();

                    //YOGUN_BAKIM_YATIS_TARIHI
                    _recordData.YOGUN_BAKIM_IZLEM_BILGILERI.YOGUN_BAKIM_YATIS_TARIHI = new YOGUN_BAKIM_YATIS_TARIHI();
                    _recordData.YOGUN_BAKIM_IZLEM_BILGILERI.YOGUN_BAKIM_YATIS_TARIHI.value = baseBedProcedure.InPatientTreatmentClinicApp.ClinicInpatientDate.HasValue ? baseBedProcedure.InPatientTreatmentClinicApp.ClinicInpatientDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

                    var physicianApplication = baseBedProcedure.InPatientTreatmentClinicApp.InPatientPhysicianApplication.FirstOrDefault() as PhysicianApplication;
                    if (physicianApplication != null && physicianApplication.SpecialityBasedObject.Count > 0)
                    {

                        var speciality = physicianApplication.SpecialityBasedObject.FirstOrDefault();
                        IntensiveCareSpecialityObj intensiveCareSpecialityObj = (IntensiveCareSpecialityObj)objectContext.GetObject(speciality.ObjectID, speciality.ObjectDef);

                        //YOGUN_BAKIM_TIPI
                        if (intensiveCareSpecialityObj.IntensiveCareType == IntensiveCareTypeEnum.AdultIntensiveCare)
                        {
                            _recordData.YOGUN_BAKIM_IZLEM_BILGILERI.YOGUN_BAKIM_TIPI = new YOGUN_BAKIM_TIPI("1", "ERİŞKİN");// todo SKRS Yoğun Bakım Hasta Tipi !!!!!!!!!!!!!!!!!!!!!
                        }
                        else if (intensiveCareSpecialityObj.IntensiveCareType == IntensiveCareTypeEnum.ChildIntensiveCare)
                        {
                            _recordData.YOGUN_BAKIM_IZLEM_BILGILERI.YOGUN_BAKIM_TIPI = new YOGUN_BAKIM_TIPI("2", "ÇOCUK");// todo SKRS Yoğun Bakım Hasta Tipi !!!!!!!!!!!!!!!!!!!!!
                        }
                        else if (intensiveCareSpecialityObj.IntensiveCareType == IntensiveCareTypeEnum.AdultIntensiveCare)
                        {
                            _recordData.YOGUN_BAKIM_IZLEM_BILGILERI.YOGUN_BAKIM_TIPI = new YOGUN_BAKIM_TIPI("3", "YENIDOĞAN");// todo SKRS Yoğun Bakım Hasta Tipi !!!!!!!!!!!!!!!!!!!!!
                        }

                        if (intensiveCareSpecialityObj != null)
                        {
                            //IZLEM_BILGISI
                            IZLEM_BILGISI IZLEM_BILGISI = new IZLEM_BILGISI();

                            //VENTILASYON_DURUMU
                            if ((physicianApplication as InPatientPhysicianApplication).VentilatorStatus != null)
                            {
                                IZLEM_BILGISI.VENTILASYON_DURUMU = new VENTILASYON_DURUMU((physicianApplication as InPatientPhysicianApplication).VentilatorStatus.KODU, (physicianApplication as InPatientPhysicianApplication).VentilatorStatus.ADI);
                            }

                            //IZLEM_ZAMANI
                            IZLEM_BILGISI.IZLEM_ZAMANI = new IZLEM_ZAMANI();
                            IZLEM_BILGISI.IZLEM_ZAMANI.value = izlemZamani.ToString("yyyyMMddHHmm");

                            //ISLEM_REFERANS_NUMARASI
                            IZLEM_BILGISI.ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
                            IZLEM_BILGISI.ISLEM_REFERANS_NUMARASI.value = bedProcedure.ObjectID.ToString();// todo hangi obje atanacak? !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                            //SEPSIS_DURUMU
                            if (intensiveCareSpecialityObj.SepsisStatus != null)
                            {
                                //TerminologyManagerDef skrsSepsisStatus = intensiveCareSpecialityObj.SepsisStatus.KODU.GetSKRSDefinition();
                                //if (skrsSepsisStatus != null)
                                //{
                                IZLEM_BILGISI.SEPSIS_DURUMU = new SEPSIS_DURUMU(intensiveCareSpecialityObj.SepsisStatus.KODU, intensiveCareSpecialityObj.SepsisStatus.ADI);
                                //}
                            }

                            if (intensiveCareSpecialityObj.SepticShock != null)
                            {
                                //SEPTIK_SOK
                                //TerminologyManagerDef skrsSepticShock = intensiveCareSpecialityObj.SepticShock.GetSKRSDefinition();
                                //if (skrsSepticShock != null)
                                //{
                                IZLEM_BILGISI.SEPTIK_SOK = new SEPTIK_SOK(intensiveCareSpecialityObj.SepticShock.KODU, intensiveCareSpecialityObj.SepticShock.ADI);
                                //}
                            }

                            //GUNLUK_IZLEM_NOTU
                            var izlemNotu = physicianApplication.InPatientPhysicianProgresses.Where(x => x.ProgressDate.Value.Date == izlemZamani.Date);
                            if (izlemNotu.Count() == 0)
                            {
                                izlemNotu = physicianApplication.InPatientPhysicianProgresses.OrderByDescending(c => c.ProgressDate.Value);
                            }
                            IZLEM_BILGISI.GUNLUK_IZLEM_NOTU = new GUNLUK_IZLEM_NOTU();
                            IZLEM_BILGISI.GUNLUK_IZLEM_NOTU.value = izlemNotu.Count() > 0 ? izlemNotu.FirstOrDefault().Description.ToString() : "";//skorlama yapılan gün girilen klinik seyir izlem notu olarak gönderiliyor.


                            //YOGUN_BAKIM_SEVIYE_BILGISI
                            var inPatientTreatmentClinicApp = ((InPatientPhysicianApplication)intensiveCareSpecialityObj.PhysicianApplication).InPatientTreatmentClinicApp;
                            if (inPatientTreatmentClinicApp != null)
                            {
                                var baseInpatientAddmission = inPatientTreatmentClinicApp.BaseInpatientAdmission;
                                if (baseInpatientAddmission.Bed != null)
                                {
                                    //P552001 Birinci basamak yoğun bakım hastası
                                    //P552002 İkinci basamak yoğun bakım hastası
                                    //P552003 Üçüncü basamak yoğun bakım hastası
                                    var sKRSYogunBakimSeviyeBilgisi = baseInpatientAddmission.Bed.GetSKRSYogunBakimSeviyeBilgisi();
                                    if (sKRSYogunBakimSeviyeBilgisi != null)//YOGUN_BAKIM_SEVIYE_BILGISI
                                    {
                                        IZLEM_BILGISI.YOGUN_BAKIM_SEVIYE_BILGISI = new YOGUN_BAKIM_SEVIYE_BILGISI(sKRSYogunBakimSeviyeBilgisi.KODU, sKRSYogunBakimSeviyeBilgisi.ADI);
                                    }
                                    else if (intensiveCareSpecialityObj.IntensiveCareStep != null)
                                    {
                                        sKRSYogunBakimSeviyeBilgisi = SKRSYogunBakimSeviyeBilgisi.GetByKodu(objectContext, ((int)intensiveCareSpecialityObj.IntensiveCareStep.Value).ToString()).FirstOrDefault();
                                        IZLEM_BILGISI.YOGUN_BAKIM_SEVIYE_BILGISI = new YOGUN_BAKIM_SEVIYE_BILGISI(sKRSYogunBakimSeviyeBilgisi.KODU, sKRSYogunBakimSeviyeBilgisi.ADI);
                                    }
                                    else
                                    {
                                        throw new Exception("Hastanın Yattığı yatak bir yoğun bakım yatağı değildir");
                                    }
                                }
                            }

                            //APACHE_II_SKOR_BILGISI
                            IZLEM_BILGISI.APACHE_II_SKOR_BILGISI = new List<APACHE_II_SKOR_BILGISI>();
                            foreach (var apacheScore in intensiveCareSpecialityObj.PhysicianApplication.ApacheScores)
                            {
                                APACHE_II_SKOR_BILGISI APACHE_II_SKOR_BILGISI = new APACHE_II_SKOR_BILGISI();

                                APACHE_II_SKOR_BILGISI.TOPLAM_APACHE_SKORU = new TOPLAM_APACHE_SKORU();
                                APACHE_II_SKOR_BILGISI.TOPLAM_APACHE_SKORU.value = apacheScore.ApacheIITotal != null ? apacheScore.ApacheIITotal.ToString() : string.Empty;
                                if (apacheScore.ExpectedMortalityRate != null)
                                {
                                    APACHE_II_SKOR_BILGISI.BEKLENEN_OLUM_ORANI = new BEKLENEN_OLUM_ORANI();
                                    APACHE_II_SKOR_BILGISI.BEKLENEN_OLUM_ORANI.value = apacheScore.ExpectedMortalityRate.ToString();
                                    APACHE_II_SKOR_BILGISI.BEKLENEN_OLUM_ORANI_DUZELTILMIS = new BEKLENEN_OLUM_ORANI_DUZELTILMIS();
                                    APACHE_II_SKOR_BILGISI.BEKLENEN_OLUM_ORANI_DUZELTILMIS.value = apacheScore.ExpectedMortalityRate.ToString();
                                }
                                APACHE_II_SKOR_BILGISI.OLCUM_ZAMANI = new OLCUM_ZAMANI();
                                APACHE_II_SKOR_BILGISI.OLCUM_ZAMANI.value = apacheScore.EntryDate.HasValue ? apacheScore.EntryDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

                                IZLEM_BILGISI.APACHE_II_SKOR_BILGISI.Add(APACHE_II_SKOR_BILGISI);

                            }

                            //SNAP_II_SKOR_BILGISI
                            IZLEM_BILGISI.SNAP_II_SKOR_BILGISI = new List<SNAP_II_SKOR_BILGISI>();
                            foreach (var snappeScore in intensiveCareSpecialityObj.PhysicianApplication.SnappeScores)
                            {
                                SNAP_II_SKOR_BILGISI SNAP_II_SKOR_BILGISI = new SNAP_II_SKOR_BILGISI();

                                SNAP_II_SKOR_BILGISI.SNAP_II_SKORU = new SNAP_II_SKORU();
                                SNAP_II_SKOR_BILGISI.SNAP_II_SKORU.value = snappeScore.TotalSnapScore != null ? snappeScore.TotalSnapScore.ToString() : string.Empty;
                                SNAP_II_SKOR_BILGISI.SNAP_PE_II_SKORU = new SNAP_PE_II_SKORU();
                                SNAP_II_SKOR_BILGISI.SNAP_PE_II_SKORU.value = snappeScore.TotalScore != null ? snappeScore.TotalScore.ToString() : string.Empty;

                                SNAP_II_SKOR_BILGISI.OLCUM_ZAMANI = new OLCUM_ZAMANI();
                                SNAP_II_SKOR_BILGISI.OLCUM_ZAMANI.value = snappeScore.EntryDate.HasValue ? snappeScore.EntryDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

                                IZLEM_BILGISI.SNAP_II_SKOR_BILGISI.Add(SNAP_II_SKOR_BILGISI);

                            }

                            //GLASGOW_SKALASI
                            IZLEM_BILGISI.GLASGOW_SKALASI = new List<GLASGOW_SKALASI>();
                            foreach (var glaskow in intensiveCareSpecialityObj.PhysicianApplication.GlaskowScores)
                            {
                                GLASGOW_SKALASI GLASGOW_SKALASI = new GLASGOW_SKALASI();

                                GLASGOW_SKALASI.GOZLER = new GOZLER();
                                GLASGOW_SKALASI.GOZLER.value = glaskow.Eyes.Score.ToString();

                                GLASGOW_SKALASI.SOZEL = new SOZEL();
                                GLASGOW_SKALASI.SOZEL.value = glaskow.OralAnswer.Score.ToString();

                                GLASGOW_SKALASI.MOTOR = new MOTOR();
                                GLASGOW_SKALASI.MOTOR.value = glaskow.MotorAnswer.Score.ToString();

                                IZLEM_BILGISI.GLASGOW_SKALASI.Add(GLASGOW_SKALASI);
                            }
                            _recordData.YOGUN_BAKIM_IZLEM_BILGILERI.IZLEM_BILGISI.Add(IZLEM_BILGISI);

                            //PRISM_SKOR_BILGISI
                            IZLEM_BILGISI.PRISM_SKOR_BILGISI = new List<PRISM_SKOR_BILGISI>();
                            foreach (var prismScore in intensiveCareSpecialityObj.PhysicianApplication.Prisms)
                            {
                                PRISM_SKOR_BILGISI PRISM_SKOR_BILGISI = new PRISM_SKOR_BILGISI();

                                PRISM_SKOR_BILGISI.TOPLAM_PRISM_SKORU = new TOPLAM_PRISM_SKORU();
                                PRISM_SKOR_BILGISI.TOPLAM_PRISM_SKORU.value = prismScore.TotalScore != null ? prismScore.TotalScore.ToString() : string.Empty;
                                PRISM_SKOR_BILGISI.BEKLENEN_OLUM_ORANI = new BEKLENEN_OLUM_ORANI();
                                PRISM_SKOR_BILGISI.BEKLENEN_OLUM_ORANI.value = prismScore.MortalityRate.ToString();
                                PRISM_SKOR_BILGISI.OLCUM_ZAMANI = new OLCUM_ZAMANI();
                                PRISM_SKOR_BILGISI.OLCUM_ZAMANI.value = prismScore.EntryDate.HasValue ? prismScore.EntryDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

                                IZLEM_BILGISI.PRISM_SKOR_BILGISI.Add(PRISM_SKOR_BILGISI);

                            }
                        }

                        SYSMessage _sYSMessage = new SYSMessage();
                        _sYSMessage.recordData = _recordData;
                        return _sYSMessage;
                    }
                    else
                    {
                        throw new Exception("'501' peketini göndermek için '" + InternalObjectId + "' ObjectId'li " + InternalObjectDefName + " Objenin uzmanlığı bulunamadı");
                    }
                }
                else
                {
                    throw new Exception("'501' peketini göndermek için '" + InternalObjectId + "' ObjectId'li " + InternalObjectDefName + " Objesi bulunamadı");
                }
            }
        }
    }
}
