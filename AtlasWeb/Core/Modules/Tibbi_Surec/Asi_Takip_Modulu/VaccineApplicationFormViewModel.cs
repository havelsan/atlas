//$040CE726
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using TTDefinitionManagement;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class VaccineDetailsServiceController : Controller
    {

        [HttpPost]
        public ATSResult ATSSorgula(ATSSorguInput atsObj)
        {
            ATSBarcodeDetails barcode = new ATSBarcodeDetails();
            barcode = KarekodParseEt(atsObj.karekod);
            ATSResult result = new ATSResult();
            result.SonKullanmaTarihi = Convert.ToDateTime(barcode.SonKullanmaTarihi.Value.ToString("dd.MM.yyyy"));
            result.Barkod = barcode.Barkod;
            result.PartiNo = barcode.PartiNo;
            result.SeriNo = barcode.SeriNo;
            result.Kirilim = barcode.BirimKirilimDegerleri == null ? "" : barcode.BirimKirilimDegerleri;
            var objectContext = new TTObjectContext(true);
            Patient patient = (Patient)objectContext.GetObject(atsObj.patientID, TTObjectDefManager.Instance.GetObjectDef(typeof (Patient)));
            AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuGirdi ats_input = new AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuGirdi();
            ats_input.KullaniciBilgisi = new AsiEntegrasyonServis.KullaniciBilgisi();
            ats_input.KullaniciBilgisi.KullaniciAdi = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string hex = BitConverter.ToString(sha.ComputeHash(enc.GetBytes(password)));
            hex = hex.Replace("-", "");
            ats_input.KullaniciBilgisi.Parola = hex;
            string hastaKimlikNo = "", hekimTC = "";
            AsiEntegrasyonServis.EKisiTipi vatandasTipi = new AsiEntegrasyonServis.EKisiTipi();

            VaccineDetails detail = (VaccineDetails)objectContext.GetObject(atsObj.vaccineDetailObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(VaccineDetails)));

            if (detail.VaccineFollowUp.SubEpisode.PatientAdmission.IsNewBorn == true)
            {
                vatandasTipi = AsiEntegrasyonServis.EKisiTipi.YeniDogan;
                hastaKimlikNo = patient.Mother.UniqueRefNo.ToString();
            }
            else
            {
                if (patient.Foreign == true)
                {
                    vatandasTipi = AsiEntegrasyonServis.EKisiTipi.Yabanci;
                    hastaKimlikNo = patient.UniqueRefNo.ToString();
                }
                else if (patient.UniqueRefNo != null)
                {
                    vatandasTipi = AsiEntegrasyonServis.EKisiTipi.Vatandas;
                    hastaKimlikNo = patient.UniqueRefNo.ToString();
                }
                else
                    vatandasTipi = AsiEntegrasyonServis.EKisiTipi.Vatansiz;
            }
         
            //ResUser procedureDoctor = atsObj.ResponsibleDoctor;

            ResUser procedureDoctor = (ResUser)objectContext.GetObject(atsObj.ResponsibleDoctor.ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(ResUser)));

            if (procedureDoctor != null && procedureDoctor.Person != null)
                hekimTC = procedureDoctor.Person.UniqueRefNo != null ? procedureDoctor.Person.UniqueRefNo.ToString() : string.Empty; //İşlemi gerçekleştiren hekimin T.C. Kimlik bilgisidir.
            ats_input.SorguBilgisi = new AsiEntegrasyonServis.AsiSorguBilgisi();
            ats_input.SorguBilgisi.AsiKodu = atsObj.skrsAsiKodu;
            ats_input.SorguBilgisi.DogumTarihi = Convert.ToDateTime(patient.BirthDate);
            ats_input.SorguBilgisi.DozBilgisi = Convert.ToInt32(atsObj.skrsAsiDozu);
            ats_input.SorguBilgisi.GeziciHizmetMi = atsObj.geziciHizmetMi;
            ats_input.SorguBilgisi.HekimKimlikNo = hekimTC;
            ats_input.SorguBilgisi.KirilimBilgisi = barcode.BirimKirilimDegerleri == null ? "" : barcode.BirimKirilimDegerleri;
            ats_input.SorguBilgisi.OnlineProtokolNo = "";
            ats_input.SorguBilgisi.SonKullanmaTarihi = Convert.ToDateTime(barcode.SonKullanmaTarihi.Value.ToString("dd.MM.yyyy"));
            ats_input.SorguBilgisi.StokBarkod = barcode.Barkod;
            ats_input.SorguBilgisi.StokSeriNo = barcode.SeriNo;
            ats_input.SorguBilgisi.StokPartiNo = barcode.PartiNo;
            ats_input.SorguBilgisi.UygulanacakKisiId = hastaKimlikNo;
            ats_input.SorguBilgisi.UygulanacakKisiTipi = vatandasTipi;
            if(Convert.ToInt32(atsObj.skrsAsiSaglandigiKaynakKod) == 1)
                ats_input.SorguBilgisi.AsininSaglandigiKaynak = AsiEntegrasyonServis.EAsininSaglandigiKaynakTipi.ReceteIleVerilen;
            else
                ats_input.SorguBilgisi.AsininSaglandigiKaynak = AsiEntegrasyonServis.EAsininSaglandigiKaynakTipi.UcretsizVerilenler;
            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuCikti ats_output = AsiEntegrasyonServis.WebMethods.AsiKullanilabilirlikSorgusuSync(siteIDGuid, ats_input);
            result.ats_output_Bilgi = ats_output.Bilgi;
            result.ats_output_KullanilabilirlikDurum = ats_output.SorguKullanilabilirlikDurumu.ToString();
            result.ats_output_SorguNo = ats_output.SorguNumarasi == null ? "" : ats_output.SorguNumarasi;

            return result;
        }

        private static int DozSayisiHesapla(string birimKirilimDegerleri)
        {
            int doz = 1;
            while (birimKirilimDegerleri.Length > 0)
            {
                int step = Convert.ToInt32(birimKirilimDegerleri.Substring(0, 1));
                if (step != -1)
                {
                    int d;
                    if (step == 0)
                    {
                        d = Convert.ToInt32(birimKirilimDegerleri.Substring(1));
                        birimKirilimDegerleri = "";
                    }
                    else
                    {
                        d = Convert.ToInt32(birimKirilimDegerleri.Substring(1, 4));
                        birimKirilimDegerleri = birimKirilimDegerleri.Substring(5);
                    }

                    doz = doz * d;
                }
            }

            return doz;
        }

        private static ATSBarcodeDetails KarekodParseEt(string karekod)
        {
            ATSBarcodeDetails data = new ATSBarcodeDetails();
            bool continueLoop = true;
            const string value = "|";
            data = new ATSBarcodeDetails();

            if (karekod.Length == 68)
            {
                karekod= karekod.Replace("|", "");
                while (continueLoop && karekod.Length > 1)
                {
                    if (karekod.StartsWith(value))
                    {
                        karekod = karekod.Substring(1);
                    }
                    String strItem = karekod.Substring(0, 2);
                    if (strItem.Equals("01"))
                    {
                        string bCode = karekod.Substring(2, 14);
                        karekod = karekod.Substring(16);
                        data.Barkod = bCode;
                    }
                    else if (strItem.Equals("17"))
                    {
                        string skt = karekod.Substring(2, 6);
                        karekod = karekod.Substring(8);
                        const string format = "yyMMdd";
                        data.SonKullanmaTarihi = DateTime.ParseExact(skt, format, null);
                    }
                    else if (strItem.Equals("21"))
                    {
                        string seriNo = null;
                        int step = karekod.IndexOf(value, StringComparison.Ordinal);
                        if (step != 0)
                        {
                            seriNo = karekod.Substring(2, 13);
                            karekod = karekod.Substring(15);
                        }

                        if (seriNo != null)
                        {
                            data.SeriNo = seriNo;
                        }
                        else
                        {
                            data = null;
                            continueLoop = false;
                        }
                    }
                    else if (strItem.Equals("10"))
                    {
                        string partiNo = null;
                        int step = karekod.IndexOf(value, StringComparison.Ordinal);
                        if (step != 0)
                        {
                            partiNo = karekod.Substring(2, 8);
                            karekod = karekod.Substring(10);
                        }
                        else
                        {
                            partiNo = karekod.Substring(2);
                            karekod = "";
                        }

                        data.PartiNo = partiNo;
                    }
                    else if (strItem.Equals("99"))
                    {
                        string hl7Kodu = null;
                        int step = karekod.IndexOf(value, StringComparison.Ordinal);
                        if (step != 0)
                        {
                            hl7Kodu = karekod.Substring(2, 1);
                            karekod = karekod.Substring(3);
                        }

                        if (hl7Kodu != null)
                        {
                            data.Hl7Kodu = hl7Kodu;
                        }
                        else
                        {
                            data = null;
                            continueLoop = false;
                        }
                    }
                    else if (strItem.Equals("97"))
                    {
                        string birimKirilimDegerleri = karekod.Substring(2);
                        data.BirimKirilimDegerleri = birimKirilimDegerleri;
                        string tbtId = birimKirilimDegerleri.Substring(0, 1);
                        ETasimaBirimiTipi tbt = GetTasimaBirimTipi(tbtId);
                        data.TasimaBirimTipi = tbt;
                        int toplamDozSayisi = DozSayisiHesapla(birimKirilimDegerleri);
                        data.Doz = toplamDozSayisi;
                        karekod = "";
                        continueLoop = false;
                        if (data.BirimKirilimDegerleri == "")
                            data.BirimKirilimDegerleri = "1";
                    }
                    else
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26270", "Karekod çözümlenemedi!.."));
                    }
                }
            }
            else { 
            while (continueLoop && karekod.Length > 1)
            {
                if (karekod.StartsWith(value))
                {
                    karekod = karekod.Substring(1);
                }
                String strItem = karekod.Substring(0, 2);
                if (strItem.Equals("01"))
                {
                    string bCode = karekod.Substring(2, 14);
                    karekod = karekod.Substring(16);
                    data.Barkod = bCode;
                }
                else if (strItem.Equals("17"))
                {
                    string skt = karekod.Substring(2, 6);
                    karekod = karekod.Substring(8);
                    const string format = "yyMMdd";
                    data.SonKullanmaTarihi = DateTime.ParseExact(skt, format, null);
                }
                else if (strItem.Equals("21"))
                {
                    string seriNo = null;
                    int step = karekod.IndexOf(value, StringComparison.Ordinal);
                    if (step != -1)
                    {
                        seriNo = karekod.Substring(2, step - 2);
                        karekod = karekod.Substring(step + value.Length);
                    }

                    if (seriNo != null)
                    {
                        data.SeriNo = seriNo;
                    }
                    else
                    {
                        data = null;
                        continueLoop = false;
                    }
                }
                else if (strItem.Equals("10"))
                {
                    string partiNo = null;
                    int step = karekod.IndexOf(value, StringComparison.Ordinal);
                    if (step != -1)
                    {
                        partiNo = karekod.Substring(2, step - 2);
                        karekod = karekod.Substring(step + value.Length);
                    }
                    else
                    {
                        partiNo = karekod.Substring(2);
                        karekod = "";
                    }

                    data.PartiNo = partiNo;
                }
                else if (strItem.Equals("99"))
                {
                    string hl7Kodu = null;
                    int step = karekod.IndexOf(value, StringComparison.Ordinal);
                    if (step != -1)
                    {
                        hl7Kodu = karekod.Substring(2, step - 2);
                        karekod = karekod.Substring(step + value.Length);
                    }

                    if (hl7Kodu != null)
                    {
                        data.Hl7Kodu = hl7Kodu;
                    }
                    else
                    {
                        data = null;
                        continueLoop = false;
                    }
                }
                else if (strItem.Equals("97"))
                {
                    string birimKirilimDegerleri = karekod.Substring(2);
                    data.BirimKirilimDegerleri = birimKirilimDegerleri;
                    string tbtId = birimKirilimDegerleri.Substring(0, 1);
                    ETasimaBirimiTipi tbt = GetTasimaBirimTipi(tbtId);
                    data.TasimaBirimTipi = tbt;
                    int toplamDozSayisi = DozSayisiHesapla(birimKirilimDegerleri);
                    data.Doz = toplamDozSayisi;
                    karekod = "";
                    continueLoop = false;
                    if (data.BirimKirilimDegerleri == "")
                        data.BirimKirilimDegerleri = "1";
                }
                else
                {
                    throw new Exception(TTUtils.CultureService.GetText("M26270", "Karekod çözümlenemedi!.."));
                }
            }
            }
            return data;
        }

        private static ETasimaBirimiTipi GetTasimaBirimTipi(string tbtId)
        {
            ETasimaBirimiTipi value;
            switch (tbtId)
            {
                case "4":
                    value = ETasimaBirimiTipi.Palet;
                    break;
                case "3":
                    value = ETasimaBirimiTipi.Koli;
                    break;
                case "2":
                    value = ETasimaBirimiTipi.Kutu;
                    break;
                case "1":
                    value = ETasimaBirimiTipi.Paket;
                    break;
                case "0":
                    value = ETasimaBirimiTipi.Urun;
                    break;
                default:
                    value = ETasimaBirimiTipi.Urun;
                    break;
            }

            return value;
        }

        [HttpPost]
        public ATSBildirimResult ATSBildirim(VaccineDetails VaccineDetail)
        {
            ATSBildirimResult appResult = new ATSBildirimResult();
            AsiEntegrasyonServis.AsiUygulamaParametre input = new AsiEntegrasyonServis.AsiUygulamaParametre();
            input.KullaniciBilgisi = new AsiEntegrasyonServis.KullaniciBilgisi();
            input.KullaniciBilgisi.KullaniciAdi = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string hex = BitConverter.ToString(sha.ComputeHash(enc.GetBytes(password)));
            hex = hex.Replace("-", "");
            input.KullaniciBilgisi.Parola = hex;
            input.UygulamaSorguBilgisi = new AsiEntegrasyonServis.AsiUygulamaBilgisi();
            input.UygulamaSorguBilgisi.OnlineProtokolNo = "";
            input.UygulamaSorguBilgisi.SorguNumarasi = VaccineDetail.SorguNumarasi;
            input.UygulamaSorguBilgisi.UygulamaZamani = Convert.ToDateTime(VaccineDetail.ApplicationDate);
            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            AsiEntegrasyonServis.AsiUygulamaCikti result = AsiEntegrasyonServis.WebMethods.AsiUygulamaSync(siteIDGuid, input);

            if (result.UygulamaDurum == AsiEntegrasyonServis.EUygulamaDurum.Basarili)
            {
                appResult.IsSuccess = true;
                appResult.ApplicationDate = DateTime.Now;
            }
            else
                appResult.IsSuccess = false;

            string res = result.Bilgi == null?"": result.Bilgi;
            //string res = Enum.GetName(typeof(AsiEntegrasyonServis.EUygulamaDurum), result);
            appResult.Result = res;

       
            return appResult;
        }


        partial void PreScript_VaccineApplicationForm(VaccineApplicationFormViewModel viewModel, VaccineDetails vaccineDetails, TTObjectContext objectContext)
        {
            viewModel._StateName = vaccineDetails.CurrentStateDef.DisplayText;
        }

        [HttpGet]
        public BarcodeShortInfo ParseBarcode(string Barcode)
        {
            BarcodeShortInfo result = new BarcodeShortInfo();
            ATSBarcodeDetails barcodeDetails = new ATSBarcodeDetails();
            barcodeDetails = KarekodParseEt(Barcode);
            result.Barkod = barcodeDetails.Barkod;
            result.SeriNo = barcodeDetails.SeriNo;
            result.PartiNo = barcodeDetails.PartiNo;
            result.SonKullanmaTarihi = barcodeDetails.SonKullanmaTarihi;
            result.BirimKirilimDegerleri = barcodeDetails.BirimKirilimDegerleri;
            return result;

        }

        [HttpPost]
        public void SaveVaccineDetail(VaccineApplicationFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
              
                var vaccineDetailsImported = (VaccineDetails)objectContext.AddObject(viewModel._VaccineDetails);

                Patient patient = (Patient)objectContext.GetObject(vaccineDetailsImported.VaccineFollowUp.Episode.Patient.ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(Patient)));

                vaccineDetailsImported.Patient = patient;

                if (vaccineDetailsImported.CurrentStateDefID == VaccineDetails.States.Completed)
                {
                    TTObjectClasses.SendToENabiz[] nabizArray = TTObjectClasses.SendToENabiz.GetByObjectID(objectContext, vaccineDetailsImported.ObjectID, "207").ToArray(); //Daha önce satır atıldıysa bir daha atılmamalı.
                    if (nabizArray.Length == 0)
                        new SendToENabiz(objectContext, vaccineDetailsImported.VaccineFollowUp.SubEpisode, vaccineDetailsImported.ObjectID, vaccineDetailsImported.ObjectDef.Name, "207", Common.RecTime());
                }


                //SMS
                string smsVaccineActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSVACCINEACTIVE", "FALSE");
                if(smsVaccineActive=="TRUE")
                {
                    if (patient.Age < 2)
                    {
                        VaccineSmsInfo smsInfo = new VaccineSmsInfo(objectContext);
                        smsInfo.VaccineDetail = vaccineDetailsImported;
                        smsInfo.PhoneNumber = patient.MobilePhone;
                        smsInfo.CompletedFlag = false;
                    }

                }

                //        vaccineDetailsImported.Patient = patient;
                objectContext.Save();

                //if (viewModel.VaccineDetailsGridList != null)
                //{
                //    foreach (var item in viewModel.VaccineDetailsGridList)
                //    {
                //        var vaccineDetailsImported = (VaccineDetails)objectContext.AddObject(item);
                //        vaccineDetailsImported.VaccineFollowUp = vaccineFollowUp;
                //        vaccineDetailsImported.Patient = patient;
                //        //if (item.CurrentStateDefID == VaccineDetails.States.Canceled)
                //        //{
                //        //    vaccineDetailsImported.CurrentStateDefID = VaccineDetails.States.New;
                //        //    objectContext.Save();
                //        //    vaccineDetailsImported.CurrentStateDefID = VaccineDetails.States.Canceled;
                //        //}
                //        //if (item.CurrentStateDefID == VaccineDetails.States.Completed)
                //        //{
                //        //    TTObjectClasses.SendToENabiz[] nabizArray = TTObjectClasses.SendToENabiz.GetByObjectID(objectContext, item.ObjectID, "207").ToArray(); //Daha önce satır atıldıysa bir daha atılmamalı.
                //        //    if(nabizArray.Length == 0)
                //        //        new SendToENabiz(objectContext, vaccineDetailsImported.VaccineFollowUp.SubEpisode, vaccineDetailsImported.ObjectID, vaccineDetailsImported.ObjectDef.Name, "207", Common.RecTime());
                //        //}
                //        objectContext.Save();
                //    }
                //}


            }
        }

        

    }
}

namespace Core.Models
{
    public partial class VaccineApplicationFormViewModel: BaseViewModel,IENabizViewModel
    {
        public string _StateName { get; set; }

        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._VaccineDetails);

            //var vaccine = (VaccineDetails)objectContext.GetLoadedObject(this._VaccineDetails.ObjectID);

            //new SendToENabiz(objectContext, vaccine.VaccineFollowUp.SubEpisode, vaccine.ObjectID, vaccine.ObjectDef.Name, "207", Common.RecTime());
        }
    }

    public class ATSBarcodeDetails
    {
        public string Barkod
        {
            get;
            set;
        }

        public string SeriNo
        {
            get;
            set;
        }

        public string PartiNo
        {
            get;
            set;
        }

        public DateTime? SonKullanmaTarihi
        {
            get;
            set;
        }

        public string Hl7Kodu
        {
            get;
            set;
        }

        public string BirimKirilimDegerleri
        {
            get;
            set;
        }

        public ETasimaBirimiTipi? TasimaBirimTipi
        {
            get;
            set;
        }

        public int? Doz
        {
            get;
            set;
        }
    }

    public class BarcodeShortInfo
    {
        public string Barkod
        {
            get;
            set;
        }

        public string SeriNo
        {
            get;
            set;
        }

        public string PartiNo
        {
            get;
            set;
        }

        public DateTime? SonKullanmaTarihi
        {
            get;
            set;
        }

       
        public string BirimKirilimDegerleri
        {
            get;
            set;
        }

       
    }

    public enum ETasimaBirimiTipi
    {
        Palet = 1,
        Koli = 2,
        Kutu = 3,
        Paket = 4,
        Urun = 5
    }



    public class ATSSorguInput
    {
        public string karekod;
        public string skrsAsiKodu;
        public string skrsAsiDozu;
        public string skrsAsiSaglandigiKaynakKod;
        public bool geziciHizmetMi;
        public Guid patientID;
        public VaccineFollowUp vaccineFollowupEA;
        public ResUser ResponsibleDoctor;
        public Guid vaccineDetailObjectID;


    }

    public class ATSResult
    {
        public DateTime SonKullanmaTarihi;
        public string Barkod;
        public string PartiNo;
        public string SeriNo;
        public string Kirilim;
        public string ats_output_Bilgi;
        public string ats_output_KullanilabilirlikDurum;
        public string ats_output_SorguNo;
    }

    public class ATSBildirimResult
    {
        public bool IsSuccess;
        public string Result;
        public DateTime? ApplicationDate;

    }

   
}