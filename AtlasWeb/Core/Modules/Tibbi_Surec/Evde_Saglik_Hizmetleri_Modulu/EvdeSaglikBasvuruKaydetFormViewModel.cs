//$DFB9DC4D
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using TTDefinitionManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class EvdeSaglikHizmetleriServiceController : Controller
    {
        public class InputObject
        {
            public DateTime StartDate
            {
                get;
                set;
            }

            public DateTime EndDate
            {
                get;
                set;
            }
        }

        [HttpGet]
        public EvdeSaglikBasvuruKaydetFormViewModel EvdeSaglikBasvuruKaydetForm(Guid? id)
        {
            var FormDefID = Guid.Parse("31f1ceaf-f818-413a-9e3b-c104a3b2bbb5");
            var ObjectDefID = Guid.Parse("f124a2b1-9479-463a-a0ef-f8d4bfdf8548");
            var viewModel = new EvdeSaglikBasvuruKaydetFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._EvdeSaglikHizmetleri = objectContext.GetObject(id.Value, ObjectDefID) as EvdeSaglikHizmetleri;
                    viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void EvdeSaglikBasvuruKaydetForm(EvdeSaglikBasvuruKaydetFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var evdeSaglikHizmetleri = (EvdeSaglikHizmetleri)objectContext.AddObject(viewModel._EvdeSaglikHizmetleri);
                objectContext.Save();
            }
        }

        [HttpPost]
        public string SaveApplication(EvdeSaglikBasvuruKaydetFormViewModel viewModel)
        {
            // var objectContext = new TTObjectContext(true);
            string res = "";
            var evdeSaglikObjectContext = new TTObjectContext(false);
            var evdeSaglikHizmetleri = (EvdeSaglikHizmetleri)evdeSaglikObjectContext.AddObject(viewModel._EvdeSaglikHizmetleri);
            evdeSaglikHizmetleri.BasvuruID.GetNextValue(); //Sequencelerde kaydetmeden değeri almıyor.
            evdeSaglikHizmetleri.CurrentStateDefID = EvdeSaglikHizmetleri.States.New;
            evdeSaglikObjectContext.Save();
            HSBSServis.EVDESAGLIK_BASVURUSU input = new HSBSServis.EVDESAGLIK_BASVURUSU();
            input.BasvuranTelefon = Convert.ToInt64(evdeSaglikHizmetleri.BasvuranTel);
            input.BasvuranAd = evdeSaglikHizmetleri.BasvuranAd;
            input.BasvuranSoyad = evdeSaglikHizmetleri.BasvuranSoyad;
            input.BasvuranTC = Convert.ToInt64(evdeSaglikHizmetleri.BasvuranTC);
            input.BasvuranAciklamasi = evdeSaglikHizmetleri.BasvuranAciklamasi;
            input.AlinanNotlar = evdeSaglikHizmetleri.AlinanNotlar;
            input.HastaBilgileri = new HSBSServis.EVDESAGLIK_HASTABILGILERI();
            input.HastaBilgileri.BasvuruId = Convert.ToInt32(evdeSaglikHizmetleri.BasvuruID.Value);
            input.HastaBilgileri.HastaTc = Convert.ToInt64(evdeSaglikHizmetleri.HastaTC);
            input.HastaBilgileri.HastaAd = evdeSaglikHizmetleri.HastaAd;
            input.HastaBilgileri.HastaSoyAd = evdeSaglikHizmetleri.HastaSoyad;
            input.HastaBilgileri.HastaAdres = evdeSaglikHizmetleri.HastaAdres;
            input.HastaBilgileri.HizmetEmriTarihi = Convert.ToDateTime(evdeSaglikHizmetleri.HizmetEmriTarihi);
            input.User = new HSBSServis.USER();
            if (evdeSaglikHizmetleri.ResponsibleDoctor.Person.UniqueRefNo == null)
                throw new Exception(TTUtils.CultureService.GetText("M25526", "Doktor TC Kimlik Numarası Bulunamadı."));
            input.User.UserTC = Convert.ToInt64(evdeSaglikHizmetleri.ResponsibleDoctor.Person.UniqueRefNo);
            input.User.Ad = evdeSaglikHizmetleri.ResponsibleDoctor.Person.Name;
            input.User.SoyAd = evdeSaglikHizmetleri.ResponsibleDoctor.Person.Surname;
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            if (myTesisSKRSKurumlarDefinition != null)
                input.User.KurumId = Convert.ToInt32(myTesisSKRSKurumlarDefinition.KODU); //İşlemin yapıldığı kurum veya birim ÇKYS kodu alanıdır.
            else
                throw new Exception(TTUtils.CultureService.GetText("M26365", "Kurum Kodu Bulunamadı."));
            input.User.UygulamaKodu = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX"); //Firma erişim kodu
            string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string hex = BitConverter.ToString(sha.ComputeHash(enc.GetBytes(password)));
            hex = hex.Replace("-", "");
            input.User.Sifre = hex;
            ResHospital hospital = new ResHospital();
            hospital = Common.GetCurrentHospital(evdeSaglikObjectContext);
            input.User.Il = Convert.ToInt32(hospital.SKRSILKodlari.KODU);
            input.User.Ilce = Convert.ToInt32(hospital.SKRSIlceKodlari.KODU);
            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            HSBSServis.SONUC_EVDESAGLIK_ISLEMLER result = HSBSServis.WebMethods.EvdeSaglikBasvuruKaydetSync(siteIDGuid, input);
            if (result.IslemSonucu.Basarili) //başarılı olursa statei kaydedildi olarak set edilir
            {
                evdeSaglikHizmetleri.CurrentStateDefID = EvdeSaglikHizmetleri.States.Save;
                evdeSaglikObjectContext.Save();
                res = TTUtils.CultureService.GetText("M26175", "İşlem Başarılı.");
            }
            else
            {
                evdeSaglikHizmetleri.HataKodu = result.IslemSonucu.Hatakodu;
                evdeSaglikHizmetleri.HataAciklamasi = result.IslemSonucu.Hata;
                evdeSaglikHizmetleri.CurrentStateDefID = EvdeSaglikHizmetleri.States.New;
                evdeSaglikObjectContext.Save();
                res = "Hata: " + result.IslemSonucu.Hatakodu + " - " + result.IslemSonucu.Hata;
            }

            return res;
        }

        [HttpPost]
        public HomeCarePatientsModel[] GetHomeCarePatients(InputObject obj)
        {
            IList<HomeCarePatientsModel> resultList = new List<HomeCarePatientsModel>();
            var objectContext = new TTObjectContext(true);
            GetHomeCarePatientsByDateNQL_Input input = new GetHomeCarePatientsByDateNQL_Input();
            input.STARTDATE = obj.StartDate;
            input.ENDDATE = obj.EndDate;
            BindingList<EvdeSaglikHizmetleri> patientList = GetHomeCarePatientsByDateNQL(input);
            foreach (var patient in patientList.OrderBy(p => p.HastaAd))
            {
                HomeCarePatientsModel p = new HomeCarePatientsModel();
                p.ObjectID = patient.ObjectID;
                p.ApplicationID = Convert.ToInt32(patient.BasvuruID.Value);
                p.PatientName = patient.HastaAd;
                p.PatientSurname = patient.HastaSoyad;
                p.PatientTC = patient.HastaTC.ToString();
                p.IsDeleted = Convert.ToBoolean(patient.IsDeleted);
                if (patient.CurrentStateDefID == EvdeSaglikHizmetleri.States.Save)
                    p.IsSaved = true;
                else
                    p.IsSaved = false;
                if (patient.CurrentStateDefID == EvdeSaglikHizmetleri.States.New)
                    p.IsNew = true;
                else
                    p.IsNew = false;
                resultList.Add(p);
            }

            return resultList.ToArray();
        }

        [HttpGet]
        public void DeleteApplication(int BasvuruID)
        {
            var objectContext = new TTObjectContext(false);
            BindingList<EvdeSaglikHizmetleri> evdeSaglikHizmeti = EvdeSaglikHizmetleri.GetHomeCarePatientByBasvuruIDNQL(objectContext, BasvuruID);
            if (evdeSaglikHizmeti.Count > 0)
            {
                HSBSServis.USER user = new HSBSServis.USER();
                user.UserTC = Convert.ToInt64(evdeSaglikHizmeti[0].ResponsibleDoctor.Person.UniqueRefNo);
                user.Ad = evdeSaglikHizmeti[0].ResponsibleDoctor.Person.Name;
                user.SoyAd = evdeSaglikHizmeti[0].ResponsibleDoctor.Person.Surname;
                SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
                if (myTesisSKRSKurumlarDefinition != null)
                    user.KurumId = Convert.ToInt32(myTesisSKRSKurumlarDefinition.KODU); //İşlemin yapıldığı kurum veya birim ÇKYS kodu alanıdır.
                user.UygulamaKodu = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX"); //Firma erişim kodu
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
                System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                string hex = BitConverter.ToString(sha.ComputeHash(enc.GetBytes(password)));
                hex = hex.Replace("-", "");
                user.Sifre = hex;
                ResHospital hospital = new ResHospital();
                hospital = Common.GetCurrentHospital(objectContext);
                user.Il = Convert.ToInt32(hospital.SKRSILKodlari.KODU);
                user.Ilce = Convert.ToInt32(hospital.SKRSIlceKodlari.KODU);
                Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                HSBSServis.SONUC_EVDESAGLIK_ISLEMLER result = HSBSServis.WebMethods.EvdeSaglikBasvuruSilSync(siteIDGuid, user, BasvuruID, true);
                if (result.IslemSonucu.Basarili)
                {
                    evdeSaglikHizmeti[0].IsDeleted = true;
                    evdeSaglikHizmeti[0].CurrentStateDefID = EvdeSaglikHizmetleri.States.Save;
                    objectContext.Save();
                }
            }
        }

        [HttpGet]
        public void GetApplication(int BasvuruID)
        {
            var objectContext = new TTObjectContext(false);
            BindingList<EvdeSaglikHizmetleri> evdeSaglikHizmeti = EvdeSaglikHizmetleri.GetHomeCarePatientByBasvuruIDNQL(objectContext, BasvuruID);
            if (evdeSaglikHizmeti.Count > 0)
            {
                HSBSServis.USER user = new HSBSServis.USER();
                user.UserTC = Convert.ToInt32(evdeSaglikHizmeti[0].ResponsibleDoctor.Person.UniqueRefNo);
                user.Ad = evdeSaglikHizmeti[0].ResponsibleDoctor.Person.Name;
                user.SoyAd = evdeSaglikHizmeti[0].ResponsibleDoctor.Person.Surname;
                SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
                if (myTesisSKRSKurumlarDefinition != null)
                    user.KurumId = Convert.ToInt32(myTesisSKRSKurumlarDefinition.KODU); //İşlemin yapıldığı kurum veya birim ÇKYS kodu alanıdır.
                user.UygulamaKodu = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX"); //Firma erişim kodu
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
                System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                string hex = BitConverter.ToString(sha.ComputeHash(enc.GetBytes(password)));
                hex = hex.Replace("-", "");
                user.Sifre = hex;
                ResHospital hospital = new ResHospital();
                hospital = Common.GetCurrentHospital(objectContext);
                user.Il = Convert.ToInt32(hospital.SKRSILKodlari.KODU);
                user.Ilce = Convert.ToInt32(hospital.SKRSIlceKodlari.KODU);
                Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                HSBSServis.SONUC_EVDESAGLIK_ISLEMLER result = HSBSServis.WebMethods.EvdeSaglikBasvuruSorgulaSync(siteIDGuid, user, BasvuruID, true);
            //Sorgulayınca ne yapılacak?
            }
        }

        [HttpGet]
        public listboxObject[] GetResponsibleDoctors()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = ResUser.DoctorListNQL(objectContext, "");
                var query =
                    from i in ttList
                    select new listboxObject{ObjectID = i.ObjectID, Name = i.Name, Code = ""};
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        public void GetHomeCarePatientOrders(Guid DoctorID, string Date)
        {
            var objectContext = new TTObjectContext(true);
            ResUser doctor = (ResUser)objectContext.GetObject(DoctorID, TTObjectDefManager.Instance.GetObjectDef(typeof (ResUser)));
            HSBSServis.USER user = new HSBSServis.USER();
            user.UserTC = Convert.ToInt32(doctor.Person.UniqueRefNo);
            user.Ad = doctor.Person.Name;
            user.SoyAd = doctor.Person.Surname;
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            if (myTesisSKRSKurumlarDefinition != null)
                user.KurumId = Convert.ToInt32(myTesisSKRSKurumlarDefinition.KODU); //İşlemin yapıldığı kurum veya birim ÇKYS kodu alanıdır.
            user.UygulamaKodu = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX"); //Firma erişim kodu
            string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string hex = BitConverter.ToString(sha.ComputeHash(enc.GetBytes(password)));
            hex = hex.Replace("-", "");
            user.Sifre = hex;
            ResHospital hospital = new ResHospital();
            hospital = Common.GetCurrentHospital(objectContext);
            user.Il = Convert.ToInt32(hospital.SKRSILKodlari.KODU);
            user.Ilce = Convert.ToInt32(hospital.SKRSIlceKodlari.KODU);
            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            HSBSServis.HIZMET_EMIRLERI result = HSBSServis.WebMethods.EvdeSaglikHizmetEmirlerimSync(siteIDGuid, user, Convert.ToDateTime(Date), true);
            if (result.IslemSonucu.Basarili)
            {
            //result.HizmetEmriBilgileri  -> Listeyi döndür
            }
        }
    }
}

namespace Core.Models
{
    public class EvdeSaglikBasvuruKaydetFormViewModel
    {
        public TTObjectClasses.EvdeSaglikHizmetleri _EvdeSaglikHizmetleri
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
    }

    public class EvdeSaglikBasvuruSorgulaSilViewModel
    {
        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }
    }

    public class HomeCarePatientsModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string PatientTC
        {
            get;
            set;
        }

        public string PatientName
        {
            get;
            set;
        }

        public string PatientSurname
        {
            get;
            set;
        }

        public int ApplicationID
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public bool IsSaved
        {
            get;
            set;
        }

        public bool IsNew
        {
            get;
            set;
        }
    }

    public class EvdeSaglikHizmetEmirleriViewModel
    {
        public DateTime Date
        {
            get;
            set;
        }

        public Guid ResponsibleDoctor
        {
            get;
            set;
        }
    }
}