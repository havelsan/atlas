using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

//Hasta Kayıt Veri Seti
namespace TTObjectClasses
{
    public class ENabiz101_HastaKayit
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
                messageType.code = "101";
                messageType.value = TTUtils.CultureService.GetText("M25792", "Hasta Kayıt");
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
            public HASTA_KIMLIK_BILGILERI HASTA_KIMLIK_BILGILERI = new HASTA_KIMLIK_BILGILERI();
            public HASTA_BASVURU_BILGILERI HASTA_BASVURU_BILGILERI = new HASTA_BASVURU_BILGILERI();
        }
        public class HASTA_BASVURU_BILGILERI
        {

            public AMBULANS_TAKIP_NUMARASI AMBULANS_TAKIP_NUMARASI = new AMBULANS_TAKIP_NUMARASI();
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI = new PAKETE_AIT_ISLEM_ZAMANI();
            public HIZMET_SUNUCU HIZMET_SUNUCU = new HIZMET_SUNUCU();
            public KAYIT_YERI KAYIT_YERI = new KAYIT_YERI();
            public PROTOKOL_NUMARASI PROTOKOL_NUMARASI = new PROTOKOL_NUMARASI();
            public XXXXXX_REFERANS_NUMARASI XXXXXX_REFERANS_NUMARASI = new XXXXXX_REFERANS_NUMARASI();
            public SGK_TAKIP_NUMARASI SGK_TAKIP_NUMARASI = new SGK_TAKIP_NUMARASI();
            public KABUL_ZAMANI KABUL_ZAMANI = new KABUL_ZAMANI();
            public KLINIK_KODU KLINIK_KODU = new KLINIK_KODU();
            public SOSYAL_GUVENCE_DURUMU SOSYAL_GUVENCE_DURUMU = new SOSYAL_GUVENCE_DURUMU();
            public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
            public VAKA_TURU VAKA_TURU = new VAKA_TURU();
            public MHRS_RANDEVU_NUMARASI MHRS_RANDEVU_NUMARASI = new MHRS_RANDEVU_NUMARASI();
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
            public TRIAJ TRIAJ;
            public YATIS_BILGISI YATIS_BILGISI = new YATIS_BILGISI();


        }
        public class HASTA_KIMLIK_BILGILERI
        {

            public BABA_KIMLIK_NUMARASI BABA_KIMLIK_NUMARASI; //Yenidoğanlar için
            public GELDIGI_ULKE GELDIGI_ULKE;
            public TELEFON_NUMARASI TELEFON_NUMARASI;
            public RANDEVU_ZAMANI RANDEVU_ZAMANI = new RANDEVU_ZAMANI();
            public HASTA_KIMLIK_NUMARASI HASTA_KIMLIK_NUMARASI = new HASTA_KIMLIK_NUMARASI();
            public AD AD = new AD();
            public SOYAD SOYAD = new SOYAD();
            public DOGUM_TARIHI DOGUM_TARIHI = new DOGUM_TARIHI();
            public CINSIYET CINSIYET = new CINSIYET();
            public UYRUK UYRUK = new UYRUK();
            public ANNE_KIMLIK_NUMARASI ANNE_KIMLIK_NUMARASI = new ANNE_KIMLIK_NUMARASI();
            public DOGUM_SIRASI DOGUM_SIRASI = new DOGUM_SIRASI();
            public YABANCI_HASTA_KIMLIK_NUMARASI YABANCI_HASTA_KIMLIK_NUMARASI = new YABANCI_HASTA_KIMLIK_NUMARASI();
            public PASAPORT_NO PASAPORT_NO = new PASAPORT_NO();
            public KIMLIKSIZ_HASTA_BILGISI KIMLIKSIZ_HASTA_BILGISI = new KIMLIKSIZ_HASTA_BILGISI();
            public BEYAN_DOGUM_TARIHI BEYAN_DOGUM_TARIHI = new BEYAN_DOGUM_TARIHI();
            public HASTA_TIPI HASTA_TIPI = new HASTA_TIPI();
            public YABANCI_HASTA_TURU YABANCI_HASTA_TURU;
            public ADRES_BILGISI ADRES_BILGISI = new ADRES_BILGISI();
            public YUPASS_NO YUPASS_NO;
            public DONOR_ALICI_KIMLIK_NUMARASI DONOR_ALICI_KIMLIK_NUMARASI;
        }
        public class YATIS_BILGISI
        {
            public YATIS_KABUL_ZAMANI YATIS_KABUL_ZAMANI = new YATIS_KABUL_ZAMANI();
            public YATAK_NO YATAK_NO = new YATAK_NO();
            public YATIS_GUNUBIRLIK_MI YATIS_GUNUBIRLIK_MI = new YATIS_GUNUBIRLIK_MI();
            public YATISIN_ACILIYETI YATISIN_ACILIYETI = new YATISIN_ACILIYETI();
        }
        public class ADRES_BILGISI
        {
            public ADRES_KODU_SEVIYESI ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI();
            public ADRES_KODU ADRES_KODU = new ADRES_KODU();
            public ACIK_ADRES ACIK_ADRES = new ACIK_ADRES();
            //public ACIK_ADRES_IL ACIK_ADRES_IL = new ACIK_ADRES_IL(); Kaldırılmış
            public ACIK_ADRES_ILCE ACIK_ADRES_ILCE = new ACIK_ADRES_ILCE();
        }
        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            //InternalObjectGuid bu objec için SubEpisodedur
            TTObjectContext objectContext = new TTObjectContext(true);
            SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(InternalObjectId, InternalObjectDefName);
            if (subEpisode == null)
                throw new Exception("'101' peketini göndermek için " + InternalObjectId + " ObjectId'li SubEpisode Objesi bulunamadı");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();

            Episode episode = subEpisode.Episode;
            PatientAdmission patientAdmission = subEpisode.PatientAdmission;
            Patient patient = episode.Patient;
            #region MAVI KARTLILARI TURK GİBİ GÖNDER
            string tempNationality = string.Empty;
            bool? tempForeign = false;
            #endregion
            if (patient.Nationality != null)
            {
                //kimlik numarası 99 ile başamıyor ise turk diye gönder
                if (patient.Nationality.Kodu != "TR" && patient.UniqueRefNo != null && !patient.UniqueRefNo.ToString().StartsWith("99"))
                {
                    tempNationality = "TR";
                    tempForeign = false;
                }
                else
                {
                    tempNationality = patient.Nationality.Kodu;
                    tempForeign = patient.Foreign == null ? false : patient.Foreign.Value;
                }
            }
                



            //HASTA_KIMLIK_BILGILERI
            if (patient.Nationality != null && tempNationality == "TR")
            {
                if (patient.Privacy == true)
                {
                    if(patient.PrivacyUniqueRefNo != null)
                        _recordData.HASTA_KIMLIK_BILGILERI.HASTA_KIMLIK_NUMARASI.value = patient.PrivacyUniqueRefNo.ToString();
                }
                else
                {
                    if (patient.UniqueRefNo != null)
                        _recordData.HASTA_KIMLIK_BILGILERI.HASTA_KIMLIK_NUMARASI.value = patient.UniqueRefNo.ToString();
                }
            }
            else
            {
                _recordData.HASTA_KIMLIK_BILGILERI.HASTA_KIMLIK_NUMARASI.value = string.Empty;// Boş olursa karşısı hata verir
            }
            _recordData.HASTA_KIMLIK_BILGILERI.AD.value = patient.Name;
            _recordData.HASTA_KIMLIK_BILGILERI.SOYAD.value = patient.Surname;
            _recordData.HASTA_KIMLIK_BILGILERI.DOGUM_TARIHI.value = patient.BirthDate.HasValue ? patient.BirthDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

            if (patient.Sex != null)
            {
                //var sKRSCinsiyet = BaseSKRSDefinition.GetByEnumValue("SKRSCinsiyet", Convert.ToInt16(patient.Sex.KODU));
                //if (sKRSCinsiyet != null)
                    _recordData.HASTA_KIMLIK_BILGILERI.CINSIYET = new CINSIYET(patient.Sex.KODU, patient.Sex.ADI);
            }

            if (patient.Nationality != null)
            {
                _recordData.HASTA_KIMLIK_BILGILERI.UYRUK = new UYRUK(patient.Nationality.MernisKodu, patient.Nationality.Adi);
            }
            else// eski hastalarda Nationality yoksa diye
            {
                if (patient.CountryOfBirth != null)
                {
                    var sKRSUlkeKodlari = patient.CountryOfBirth.GetSKRSDefinition();
                    if (sKRSUlkeKodlari != null)
                        _recordData.HASTA_KIMLIK_BILGILERI.UYRUK = new UYRUK(((SKRSUlkeKodlari)sKRSUlkeKodlari).Kodu, (((SKRSUlkeKodlari)sKRSUlkeKodlari)).Adi);
                }
            }

            if (patient.YUPASSNO != null)
            {
                _recordData.HASTA_KIMLIK_BILGILERI.YUPASS_NO = new YUPASS_NO();
                _recordData.HASTA_KIMLIK_BILGILERI.YUPASS_NO.value = patient.YUPASSNO.ToString();
             
            }
            if (tempForeign == true || patient.UnIdentified == true)
            {
                bool found = false;
                
                if (patient.UniqueRefNo != null)// Yabacı Hasta No yoksa
                {
                    _recordData.HASTA_KIMLIK_BILGILERI.YABANCI_HASTA_KIMLIK_NUMARASI.value = patient.UniqueRefNo.ToString();
                    found = true;
                }
                if (patient.PassportNo != null)
                {
                    _recordData.HASTA_KIMLIK_BILGILERI.PASAPORT_NO.value = patient.PassportNo.ToString();
                    found = true;
                }
                if (!found && episode.IsNewBorn != true)//yeni doğanlarda kimliksiz yollamaması için
                {
                    if (myTesisSKRSKurumlarDefinition != null)
                        _recordData.HASTA_KIMLIK_BILGILERI.KIMLIKSIZ_HASTA_BILGISI.value = myTesisSKRSKurumlarDefinition.KODU + "_" + patient.ID.ToString();
                }
            }

            if (episode.IsNewBorn == true) // yeni doğanın adresi annesinden alınır
            {

                _recordData.HASTA_KIMLIK_BILGILERI.DOGUM_SIRASI.value = patient.BirthOrder != null ? Convert.ToInt32(patient.BirthOrder.KODU).ToString() : string.Empty;
                var mother = patient.Mother;
                if (mother != null)
                {
                    _recordData.HASTA_KIMLIK_BILGILERI.ANNE_KIMLIK_NUMARASI.value = mother.UniqueRefNo != null ? mother.UniqueRefNo.ToString() :
                                                                                    mother.PassportNo != null ? mother.PassportNo : string.Empty;
                    _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ACIK_ADRES.value = mother.PatientAddress.HomeAddress ?? string.Empty;
                    _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ACIK_ADRES_ILCE.value = mother.PatientAddress.SKRSAcikAdresIlce ?? string.Empty;
                    _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU.value = mother.PatientAddress.SKRSAdresKodu ?? string.Empty;  /// TEST İÇİ:"1585604570"

                    if (mother.PatientAddress.SKRSAdresKoduSeviyesi != null)
                        _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI(mother.PatientAddress.SKRSAdresKoduSeviyesi.KODU, mother.PatientAddress.SKRSAdresKoduSeviyesi.KODTIPIADI);
                    else
                        _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI("8", "İÇ KAPI");/// Default Değer // MERNISDEN GELMEZSE
                }

            }
            else
            {

                _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ACIK_ADRES.value = patientAdmission.PA_Address.HomeAddress ?? string.Empty;
                _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ACIK_ADRES_ILCE.value = patientAdmission.PA_Address.SKRSAcikAdresIlce ?? string.Empty;
                _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU.value = patientAdmission.PA_Address.SKRSAdresKodu ?? string.Empty;  /// TEST İÇİ:"1585604570"

                if (patientAdmission.PA_Address.SKRSAdresKoduSeviyesi != null)
                    _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI(patientAdmission.PA_Address.SKRSAdresKoduSeviyesi.KODU, patientAdmission.PA_Address.SKRSAdresKoduSeviyesi.KODTIPIADI);
                else
                    _recordData.HASTA_KIMLIK_BILGILERI.ADRES_BILGISI.ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI("8", "İÇ KAPI");/// Default Değer // MERNISDEN GELMEZSE

            }

            if (patientAdmission.Donor != null && patientAdmission.Donor == true && patient.DonorUniqueRefNo != null)
            {
                _recordData.HASTA_KIMLIK_BILGILERI.DONOR_ALICI_KIMLIK_NUMARASI = new DONOR_ALICI_KIMLIK_NUMARASI();
                _recordData.HASTA_KIMLIK_BILGILERI.DONOR_ALICI_KIMLIK_NUMARASI.value = patient.DonorUniqueRefNo.ToString();
            }


            //HASTA_BASVURU_BILGILERI
            if (myTesisSKRSKurumlarDefinition != null)
            {
                _recordData.HASTA_BASVURU_BILGILERI.HIZMET_SUNUCU = new HIZMET_SUNUCU(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);
                _recordData.HASTA_BASVURU_BILGILERI.KAYIT_YERI = new KAYIT_YERI(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);//?? Semp Policlinikleri için düzenlenmeli
            }
            _recordData.HASTA_BASVURU_BILGILERI.PROTOKOL_NUMARASI.value = episode.HospitalProtocolNo.ToString();
            _recordData.HASTA_BASVURU_BILGILERI.XXXXXX_REFERANS_NUMARASI.value = subEpisode.ObjectID.ToString();

            SubEpisodeProtocol sep = subEpisode.SGKSEP;
            if (sep != null && sep.MedulaTakipNo != null)
                _recordData.HASTA_BASVURU_BILGILERI.SGK_TAKIP_NUMARASI.value = sep.MedulaTakipNo;

            _recordData.HASTA_BASVURU_BILGILERI.KABUL_ZAMANI.value = subEpisode.OpeningDate.Value.ToString("yyyyMMddHHmm");

            _recordData.HASTA_KIMLIK_BILGILERI.BEYAN_DOGUM_TARIHI.value = patient.BirthDate.HasValue ? patient.BirthDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

            //sıralama önemli önce Isnewbor istiyor
            if (episode.IsNewBorn == true)
                _recordData.HASTA_KIMLIK_BILGILERI.HASTA_TIPI = new HASTA_TIPI("4", "YENIDOĞAN_KAYIT");            
            else if (patient.Nationality != null && tempNationality != "TR")
                _recordData.HASTA_KIMLIK_BILGILERI.HASTA_TIPI = new HASTA_TIPI("2", "YABANCI_KAYIT");
            else if (patient.UnIdentified == true)
                _recordData.HASTA_KIMLIK_BILGILERI.HASTA_TIPI = new HASTA_TIPI("6", "KİMLİKSİZ");
            else
                _recordData.HASTA_KIMLIK_BILGILERI.HASTA_TIPI = new HASTA_TIPI("1", "VATANDAŞ_KAYIT");

            if (subEpisode.ResSection != null)
            {
                SKRSKlinikler mySKRSKlinikler = subEpisode.ResSection.GetMySKRSKlinikler();
                if (mySKRSKlinikler != null)
                    _recordData.HASTA_BASVURU_BILGILERI.KLINIK_KODU = new KLINIK_KODU(mySKRSKlinikler.KODU, mySKRSKlinikler.ADI);
            }

            var sKRSSosyalGuvenceDurumu = subEpisode.LastSubEpisodeProtocol.Payer.Type.GetSKRSDefinition();
            if (sKRSSosyalGuvenceDurumu != null)
                _recordData.HASTA_BASVURU_BILGILERI.SOSYAL_GUVENCE_DURUMU = new SOSYAL_GUVENCE_DURUMU(((SKRSSosyalGuvenceDurumu)sKRSSosyalGuvenceDurumu).KODU, ((SKRSSosyalGuvenceDurumu)sKRSSosyalGuvenceDurumu).ADI);

            var starterEpisodeAction = subEpisode.StarterEpisodeAction;
            if (starterEpisodeAction != null)
            {

                var procedureDoctor = starterEpisodeAction.ProcedureDoctor;
                if (procedureDoctor != null && procedureDoctor.Person != null)
                    _recordData.HASTA_BASVURU_BILGILERI.HEKIM_KIMLIK_NUMARASI.value = procedureDoctor.Person.UniqueRefNo != null ? procedureDoctor.Person.UniqueRefNo.ToString() : string.Empty;

                if (starterEpisodeAction.PatientAdmission != null && starterEpisodeAction.PatientAdmission.AdmissionAppointment != null)
                {
                    foreach (Appointment appointment in starterEpisodeAction.PatientAdmission.AdmissionAppointment.Appointments)
                    {
                        if (!string.IsNullOrEmpty(appointment.MHRSRandevuHrn))
                        {
                            _recordData.HASTA_BASVURU_BILGILERI.MHRS_RANDEVU_NUMARASI.value = appointment.MHRSRandevuHrn;
                            break;
                        }
                    }
                }

                if (starterEpisodeAction is EmergencyIntervention)
                {
                    _recordData.HASTA_BASVURU_BILGILERI.TRIAJ = new TRIAJ("0", "BELIRTILMEMIŞ");
                    if (starterEpisodeAction.PatientAdmission.Emergency112RefNo != null)
                        _recordData.HASTA_BASVURU_BILGILERI.AMBULANS_TAKIP_NUMARASI.value = starterEpisodeAction.PatientAdmission.Emergency112RefNo;
                }

                if (starterEpisodeAction is InPatientTreatmentClinicApplication)
                {
                    InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication = (InPatientTreatmentClinicApplication)starterEpisodeAction;
                    _recordData.HASTA_BASVURU_BILGILERI.YATIS_BILGISI.YATIS_KABUL_ZAMANI.value = inPatientTreatmentClinicApplication.ClinicInpatientDate.HasValue ? inPatientTreatmentClinicApplication.ClinicInpatientDate.Value.ToString("yyyyMMddHHmm") : string.Empty;
                    if (inPatientTreatmentClinicApplication.BaseInpatientAdmission != null)
                    {
                        if (inPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed != null)
                            _recordData.HASTA_BASVURU_BILGILERI.YATIS_BILGISI.YATAK_NO.value = inPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.Name;


                        SKRSYatisinAciliyeti sKRSYatisinAciliyeti = SKRSYatisinAciliyeti.GetSKRSYatisinAciliyetiByEmergencyValue(objectContext, inPatientTreatmentClinicApplication.BaseInpatientAdmission.Emergency);
                        if (sKRSYatisinAciliyeti != null)
                            _recordData.HASTA_BASVURU_BILGILERI.YATIS_BILGISI.YATISIN_ACILIYETI = new YATISIN_ACILIYETI(sKRSYatisinAciliyeti.KODU, sKRSYatisinAciliyeti.ADI);

                    }
                }

                _recordData.HASTA_BASVURU_BILGILERI.YATIS_BILGISI.YATIS_GUNUBIRLIK_MI.value = subEpisode.GetPatientStatusForENabiz();
                if(_recordData.HASTA_BASVURU_BILGILERI.YATIS_BILGISI.YATIS_GUNUBIRLIK_MI.value == "1")
                {
                    _recordData.HASTA_BASVURU_BILGILERI.YATIS_BILGISI.YATIS_KABUL_ZAMANI.value = ((DateTime)subEpisode.OpeningDate).ToString("yyyyMMddHHmm");
                }
            }
            if (patientAdmission.SKRSVakaTuru != null)
                _recordData.HASTA_BASVURU_BILGILERI.VAKA_TURU = new VAKA_TURU(patientAdmission.SKRSVakaTuru.KODU, patientAdmission.SKRSVakaTuru.ADI);
            else
                _recordData.HASTA_BASVURU_BILGILERI.VAKA_TURU = new VAKA_TURU("1", "NORMAL");
            _recordData.HASTA_BASVURU_BILGILERI.SYSTakipNo.value = subEpisode.SYSTakipNo ?? String.Empty;

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
