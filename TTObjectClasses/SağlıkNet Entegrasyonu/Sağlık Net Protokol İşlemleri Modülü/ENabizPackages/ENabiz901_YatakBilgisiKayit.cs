using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz901_YatakBilgisiKayit
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
                messageType.code = "901";
                messageType.value = TTUtils.CultureService.GetText("M27211", "Yatak Bilgisi Kayıt");
            }

        }
        public class recordData
        {
            public YatakBilgisi YatakBilgisi;

        }
        public class YatakBilgisi
        {
            public Tarih Tarih = new Tarih();
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI = new PAKETE_AIT_ISLEM_ZAMANI();
            public KAYIT_YERI KAYIT_YERI = new KAYIT_YERI();
            [System.Xml.Serialization.XmlElement("YatakDurumBilgisi", Type = typeof(YatakDurumBilgisi))]
            public List<YatakDurumBilgisi> YatakDurumBilgisi = new List<YatakDurumBilgisi>();

        }
        public class YatakDurumBilgisi
        {
            public YATAK_TURU YATAK_TURU = new YATAK_TURU();
            public KLINIK_KODU KLINIK_KODU = new KLINIK_KODU();
            public BOS_YATAK BOS_YATAK = new BOS_YATAK();
            public YOGUN_BAKIM_YATAK_SEVIYE_BILGISI YOGUN_BAKIM_YATAK_SEVIYE_BILGISI; //yatağa ait seviye bilgisi
            public KLINIK_DURUMU KLINIK_DURUMU; //SKRS Objesi Değeri Açık/Kapalı
            public KLINIK_KAPALI_OLMA_NEDENI KLINIK_KAPALI_OLMA_NEDENI;
            public TOPLAM_YATAK TOPLAM_YATAK = new TOPLAM_YATAK();
            public REZERVE_YATAK REZERVE_YATAK = new REZERVE_YATAK();
            public TOPLAM_VENTILATOR TOPLAM_VENTILATOR = new TOPLAM_VENTILATOR();
            public BOS_VENTILATOR BOS_VENTILATOR = new BOS_VENTILATOR();
            public ARIZALI_VENTILATOR ARIZALI_VENTILATOR = new ARIZALI_VENTILATOR();
        }
        public class ClinicWithProcedureItem
        {
            public SKRSKlinikler Clinic { get; set; }
            public ProcedureDefinition BedProcedure { get; set; }

            public int ventilator = 0;
            public int bosVentilator = 0;
            public int toplamYatak = 0;
            public int bosYatak = 0;

        }
        public static SYSMessage Get()
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            SYSMessage _SYSMessage = new SYSMessage();
            recordData _recordData = new recordData();

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }
            _recordData.YatakBilgisi = new YatakBilgisi();
            _recordData.YatakBilgisi.Tarih.value = Common.RecTime().ToString("yyyyMMddHHmm");
            _recordData.YatakBilgisi.PAKETE_AIT_ISLEM_ZAMANI.value = Common.RecTime().ToString("yyyyMMddHHmm");

            if (myTesisSKRSKurumlarDefinition != null)
            {
                _recordData.YatakBilgisi.KAYIT_YERI = new KAYIT_YERI(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);//?? Semp Policlinikleri için düzenlenmeli
            }
            var resclinicList = ResClinic.GetAllActiveClinics(objectContext).OrderBy(dr => dr.ResourceSpecialities[0].Speciality.SKRSKlinik.KODU);

            var clinicProcedureList = new List<ClinicWithProcedureItem>();
            var BedList = ResBed.GetAllActiveBeds(objectContext).Where(t => !String.IsNullOrEmpty(t.BedCodeForMedula));

            foreach (ResBed bed in BedList)
            {
                SKRSKlinikler clinic = bed.Room.RoomGroup.Ward.GetMySKRSKlinikler();
                ProcedureDefinition procedure = bed.BedProcedure;
                bool addedNewItem = false;
                var existClinicProcedure = clinicProcedureList.Where(t => t.Clinic.ObjectID == clinic.ObjectID && t.BedProcedure.ObjectID == procedure.ObjectID).FirstOrDefault();
                if (existClinicProcedure == null)
                {
                    existClinicProcedure = new ClinicWithProcedureItem();
                    existClinicProcedure.Clinic = clinic;
                    existClinicProcedure.BedProcedure = procedure;
                    addedNewItem = true;
                }

                existClinicProcedure.toplamYatak++;

                if(bed.IsVentilator == null || (bed.IsVentilator != null && bed.IsVentilator == false))//Yatakta ventilatör yoksa
                {
                    if(bed.UsedByBedProcedure == null)
                    {
                        existClinicProcedure.bosYatak++;
                    }
                }
                else//Yatakta Ventilatör varsa
                {
                    if (bed.UsedByBedProcedure == null)//Yatakta Ventilatör var ama yatak boşsa
                    {
                        existClinicProcedure.bosYatak++;
                        existClinicProcedure.bosVentilator++;
                    }
                    else
                    {//Yatakta Ventilatör var ve yatak doluysa
                        var inpatient = bed.UsedByBedProcedure.BaseInpatientAdmission.InPatientTreatmentClinicApplications.Where(c => c.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Procedure).FirstOrDefault().InPatientPhysicianApplication.FirstOrDefault();
                        if (inpatient.VentilatorStatus == null || inpatient.VentilatorStatus.KODU == "2")//Ventilatör kullanımı 2 yani hayır olarak işaretlenmişse ya da hiç işaretlenmemişse ventilatör boş olarak değerlendirilecek
                        {
                            existClinicProcedure.bosVentilator++;
                        }
                    }
                    existClinicProcedure.ventilator++;//Yatakta Ventilatör varsa yatak dolu veya boş olsada toplam içinde sayılacak
                }
                /*if (bed.IsVentilator == null && bed.UsedByBedProcedure == null)
                    existClinicProcedure.bosYatak++;
                if (bed.IsVentilator != null)
                    existClinicProcedure.ventilator++;
                if (bed.IsVentilator != null && bed.UsedByBedProcedure == null)
                    existClinicProcedure.bosVentilator++;
                    */


                if (addedNewItem)
                    clinicProcedureList.Add(existClinicProcedure);
            }
            clinicProcedureList = clinicProcedureList.OrderBy(t => t.Clinic.ADI).ToList();
            foreach (ClinicWithProcedureItem clinicWithProcedure in clinicProcedureList)
            {
                CreateYatakDurumBilgisiNew(_recordData, clinicWithProcedure);
            }

            /*
            SKRSKlinikler lastSKRSKlinik = null;

            int ventilator = 0;
            int bosVentilator = 0;
            int toplamYatak = 0;
            int bosYatak = 0;

            int count = 0;

            foreach (ResClinic clinic in resclinicList)
            {
                if (lastSKRSKlinik != null && lastSKRSKlinik.ObjectID != clinic.GetMySKRSKlinikler().ObjectID) /// ilk Clinic için Create etmesin
                {

                    CreateYatakDurumBilgisi(_recordData, lastSKRSKlinik, ventilator, bosVentilator, toplamYatak, bosYatak);
                    ventilator = 0;
                    bosVentilator = 0;
                    toplamYatak = 0;
                    bosYatak = 0;

                }
                lastSKRSKlinik = clinic.GetMySKRSKlinikler();

                foreach (var roomGroup in clinic.RoomGroups)
                {
                    foreach (var room in roomGroup.Rooms)
                    {
                        var bedList = room.Beds.Where(t => t.BedCodeForMedula != null && t.BedCodeForMedula != "");
                        foreach (var bed in bedList)
                        {
                            toplamYatak++;
                            if (bed.IsVentilator == null && bed.UsedByBedProcedure == null)
                                bosYatak++;
                            if (bed.IsVentilator != null)
                                ventilator++;
                            if (bed.IsVentilator != null && bed.UsedByBedProcedure == null)
                                bosVentilator++;
                        }
                    }

                }

                count++;
            }

            if (count > 0)
                CreateYatakDurumBilgisi(_recordData, lastSKRSKlinik, ventilator, bosVentilator, toplamYatak, bosYatak); // Son olan Clinic kaçmasın diye ;*/
            _SYSMessage.recordData = _recordData;

            return _SYSMessage;

        }

        private static void CreateYatakDurumBilgisi(recordData _recordData, SKRSKlinikler sKRSKlinik, int ventilator, int bosVentilator, int toplamYatak, int bosYatak)
        {
            YatakDurumBilgisi _YatakDurumBilgisi = new YatakDurumBilgisi();
            _YatakDurumBilgisi.BOS_YATAK.value = bosYatak.ToString();
            _YatakDurumBilgisi.KLINIK_KODU = new KLINIK_KODU((sKRSKlinik.KODU != null ? sKRSKlinik.KODU : string.Empty), (sKRSKlinik.ADI != null ? sKRSKlinik.ADI : string.Empty));
            _YatakDurumBilgisi.KLINIK_DURUMU = new KLINIK_DURUMU("1", "AÇIK");
            _YatakDurumBilgisi.YATAK_TURU = new YATAK_TURU("1", "STANDART YATAK");
            _YatakDurumBilgisi.REZERVE_YATAK.value = "0";
            _YatakDurumBilgisi.TOPLAM_YATAK.value = toplamYatak.ToString();
            _YatakDurumBilgisi.TOPLAM_VENTILATOR.value = ventilator.ToString();
            _YatakDurumBilgisi.BOS_VENTILATOR.value = bosVentilator.ToString();
            _YatakDurumBilgisi.ARIZALI_VENTILATOR.value = "0";
            _YatakDurumBilgisi.YOGUN_BAKIM_YATAK_SEVIYE_BILGISI = new YOGUN_BAKIM_YATAK_SEVIYE_BILGISI();
            _YatakDurumBilgisi.YOGUN_BAKIM_YATAK_SEVIYE_BILGISI.value = "0";
            _recordData.YatakBilgisi.YatakDurumBilgisi.Add(_YatakDurumBilgisi);

            //if ( oldClinicObjectID != getBedInfoForEnabiz.Clinic)
            //{
            //    YatakDurumBilgisi _YatakDurumBilgisi = new YatakDurumBilgisi();
            //    _YatakDurumBilgisi.BOS_YATAK.value = Bos.ToString();
            //    ResWard rw = (ResWard)objectContext.GetObject(oldClinicObjectID.Value, typeof(ResWard));
            //    _YatakDurumBilgisi.KLINIK_KODU = new KLINIK_KODU((rw.GetMySKRSKlinikler().KODU != null ? rw.GetMySKRSKlinikler().KODU : string.Empty), (rw.GetMySKRSKlinikler().ADI != null ? rw.GetMySKRSKlinikler().ADI : string.Empty));
            //    _YatakDurumBilgisi.YATAK_TURU = new YATAK_TURU("1", "STANDART YATAK");
            //    _YatakDurumBilgisi.REZERVE_YATAK.value = "0";
            //    _YatakDurumBilgisi.TOPLAM_VENTILATOR.value = Ventrator.ToString();
            //    _YatakDurumBilgisi.BOS_VENTILATOR.value = BosVentrator.ToString();
            //    _YatakDurumBilgisi.ARIZALI_VENTILATOR.value = "0";
            //    _recordData.YatakBilgisi.YatakDurumBilgisi.Add(_YatakDurumBilgisi);

            //    oldClinicObjectID = getBedInfoForEnabiz.Clinic;
            //     Ventrator = 0;
            //     BosVentrator = 0;
            //     Toplam = 0;
            //     Bos = 0;
            //}
            //Toplam++;
            //if (getBedInfoForEnabiz.IsVentilator is null && getBedInfoForEnabiz.UsedByBedProcedure is null)
            //    Bos++;
            //if (!getBedInfoForEnabiz.IsVentilator is null)
            //    Ventrator++;
            //if (!getBedInfoForEnabiz.IsVentilator is null && getBedInfoForEnabiz.UsedByBedProcedure is null)
            //    BosVentrator++;
        }

        private static void CreateYatakDurumBilgisiNew(recordData _recordData,ClinicWithProcedureItem clinicWithProcedureItem)
        {
            YatakDurumBilgisi _YatakDurumBilgisi = new YatakDurumBilgisi();
            _YatakDurumBilgisi.BOS_YATAK.value = clinicWithProcedureItem.bosYatak.ToString();
            _YatakDurumBilgisi.KLINIK_KODU = new KLINIK_KODU((clinicWithProcedureItem.Clinic.KODU != null ? clinicWithProcedureItem.Clinic.KODU : string.Empty), (clinicWithProcedureItem.Clinic.ADI != null ? clinicWithProcedureItem.Clinic.ADI : string.Empty));
            _YatakDurumBilgisi.KLINIK_DURUMU = new KLINIK_DURUMU("1", "AÇIK");
            if (clinicWithProcedureItem.BedProcedure.Code == "P552001")
            {
                _YatakDurumBilgisi.YATAK_TURU = new YATAK_TURU("3", "YOĞUN BAKIM YATAĞI");
                _YatakDurumBilgisi.YOGUN_BAKIM_YATAK_SEVIYE_BILGISI = new YOGUN_BAKIM_YATAK_SEVIYE_BILGISI();
                _YatakDurumBilgisi.YOGUN_BAKIM_YATAK_SEVIYE_BILGISI.value = "1";
            }
            else if(clinicWithProcedureItem.BedProcedure.Code == "P552002")
            {
                _YatakDurumBilgisi.YATAK_TURU = new YATAK_TURU("3", "YOĞUN BAKIM YATAĞI");
                _YatakDurumBilgisi.YOGUN_BAKIM_YATAK_SEVIYE_BILGISI = new YOGUN_BAKIM_YATAK_SEVIYE_BILGISI();
                _YatakDurumBilgisi.YOGUN_BAKIM_YATAK_SEVIYE_BILGISI.value = "2";
            }
            else if (clinicWithProcedureItem.BedProcedure.Code == "P552003")
            {
                _YatakDurumBilgisi.YATAK_TURU = new YATAK_TURU("3", "YOĞUN BAKIM YATAĞI");
                _YatakDurumBilgisi.YOGUN_BAKIM_YATAK_SEVIYE_BILGISI = new YOGUN_BAKIM_YATAK_SEVIYE_BILGISI();
                _YatakDurumBilgisi.YOGUN_BAKIM_YATAK_SEVIYE_BILGISI.value = "3";
            }
            else
            {
                _YatakDurumBilgisi.YATAK_TURU = new YATAK_TURU("1", "STANDART YATAK");
                _YatakDurumBilgisi.YOGUN_BAKIM_YATAK_SEVIYE_BILGISI = new YOGUN_BAKIM_YATAK_SEVIYE_BILGISI();
                _YatakDurumBilgisi.YOGUN_BAKIM_YATAK_SEVIYE_BILGISI.value = "0";
            }
            _YatakDurumBilgisi.REZERVE_YATAK.value = "0";
            _YatakDurumBilgisi.TOPLAM_YATAK.value = clinicWithProcedureItem.toplamYatak.ToString();
            _YatakDurumBilgisi.TOPLAM_VENTILATOR.value = clinicWithProcedureItem.ventilator.ToString();
            _YatakDurumBilgisi.BOS_VENTILATOR.value = clinicWithProcedureItem.bosVentilator.ToString();
            _YatakDurumBilgisi.ARIZALI_VENTILATOR.value = "0";
            _recordData.YatakBilgisi.YatakDurumBilgisi.Add(_YatakDurumBilgisi);

            //if ( oldClinicObjectID != getBedInfoForEnabiz.Clinic)
            //{
            //    YatakDurumBilgisi _YatakDurumBilgisi = new YatakDurumBilgisi();
            //    _YatakDurumBilgisi.BOS_YATAK.value = Bos.ToString();
            //    ResWard rw = (ResWard)objectContext.GetObject(oldClinicObjectID.Value, typeof(ResWard));
            //    _YatakDurumBilgisi.KLINIK_KODU = new KLINIK_KODU((rw.GetMySKRSKlinikler().KODU != null ? rw.GetMySKRSKlinikler().KODU : string.Empty), (rw.GetMySKRSKlinikler().ADI != null ? rw.GetMySKRSKlinikler().ADI : string.Empty));
            //    _YatakDurumBilgisi.YATAK_TURU = new YATAK_TURU("1", "STANDART YATAK");
            //    _YatakDurumBilgisi.REZERVE_YATAK.value = "0";
            //    _YatakDurumBilgisi.TOPLAM_VENTILATOR.value = Ventrator.ToString();
            //    _YatakDurumBilgisi.BOS_VENTILATOR.value = BosVentrator.ToString();
            //    _YatakDurumBilgisi.ARIZALI_VENTILATOR.value = "0";
            //    _recordData.YatakBilgisi.YatakDurumBilgisi.Add(_YatakDurumBilgisi);

            //    oldClinicObjectID = getBedInfoForEnabiz.Clinic;
            //     Ventrator = 0;
            //     BosVentrator = 0;
            //     Toplam = 0;
            //     Bos = 0;
            //}
            //Toplam++;
            //if (getBedInfoForEnabiz.IsVentilator is null && getBedInfoForEnabiz.UsedByBedProcedure is null)
            //    Bos++;
            //if (!getBedInfoForEnabiz.IsVentilator is null)
            //    Ventrator++;
            //if (!getBedInfoForEnabiz.IsVentilator is null && getBedInfoForEnabiz.UsedByBedProcedure is null)
            //    BosVentrator++;
        }


    }
}
