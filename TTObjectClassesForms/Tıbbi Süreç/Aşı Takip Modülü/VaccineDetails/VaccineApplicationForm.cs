
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class VaccineApplicationForm : TTForm
    {
        private string _karekod = "";

        private class BarcodeDetails
        {
            public string Barkod { get; set; }

            public string SeriNo { get; set; }

            public string PartiNo { get; set; }

            public DateTime? SonKullanmaTarihi { get; set; }

            public string Hl7Kodu { get; set; }

            public string BirimKirilimDegerleri { get; set; }

            public ETasimaBirimiTipi? TasimaBirimTipi { get; set; }

            public int? Doz { get; set; }


        }

        private enum ETasimaBirimiTipi
        {
            Palet = 1,
            Koli = 2,
            Kutu = 3,
            Paket = 4,
            Urun = 5
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

        private class ATSSorguInput
        {
            public string AsiKodu;
            public int Doz;
            public bool GezisiHizmetMi;
            public string Kirilim;
            public string SonKullanmaTarihi;
            public string Barkod;
            public string PartiNo;
            public string SeriNo;
        }
        override protected void BindControlEvents()
        {
            ATS_Sorgula.Click += new TTControlEventDelegate(ATS_Sorgula_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ATS_Sorgula.Click -= new TTControlEventDelegate(ATS_Sorgula_Click);
            base.UnBindControlEvents();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            TextBox asiKareKoduText = (TextBox)this.AsiKarekodu;
            asiKareKoduText.KeyDown -= new KeyEventHandler(this.AsiKarekodu_TextChanged);
            asiKareKoduText.KeyDown += new KeyEventHandler(this.AsiKarekodu_TextChanged);

      
        }

        private void AsiKarekodu_TextChanged(object sender, KeyEventArgs e)
        {
            
            if ((e.KeyCode >= (Keys)65 && e.KeyCode < (Keys)90) || (e.KeyCode >= (Keys)48 && e.KeyCode <= (Keys)57)) // A-Z, 0-9
            {

                int unicode = e.KeyValue;
                char character = Convert.ToChar(unicode);
                string value = character.ToString();
                _karekod += value;

            }
            else if (e.KeyCode == (Keys)29 | ((e.KeyCode >= (Keys)100) && e.KeyCode != (Keys)131)) // Group seperator
            {
                _karekod += "|";
            }
        }

        private static BarcodeDetails KarekodParseEt(string karekod)
        {
            //System.Diagnostics.Debugger.Break();
            if (string.IsNullOrEmpty(karekod))
            {
                return null;
            }

            BarcodeDetails data = new BarcodeDetails();

            try
            {
                bool continueLoop = true;
                const string value = "|";

                data = new BarcodeDetails();

                if (karekod.StartsWith(value))
                {
                    karekod = karekod.Substring(1);
                }

                while (continueLoop && karekod.Length > 1)
                {
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
                        throw new Exception("Karekod ��z�mlenemedi!..");
                    }
                }
            }
            catch (Exception e)
            {
                InfoBox.Show(e.Message);
                return null;
            }

            return data;
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
        private void ATS_Sorgula_Click()
        {
           
            if (this._VaccineDetails.SKRSAsiKodu  == null || this._VaccineDetails.SKRSAsiKodu.KODU.ToString() == "")
            {
                InfoBox.Show("Sorgulama Yapmadan �nce L�tfen A�� Se�iniz.");
                return;
            }
            else if (this._VaccineDetails.SKRSAsininDozu == null || this._VaccineDetails.SKRSAsininDozu.KODU.ToString() == "")
            {
                InfoBox.Show("Sorgulama Yapmadan �nce L�tfen A�� Dozunu Se�iniz.");
                return;
            }

            var data = KarekodParseEt(_karekod);
            _karekod = "";
            //VaccineDetails.Rows[rowIndex].Cells["AsiKarekoduVaccineDetails"].Value = ""; //Nedir bak

            if (data != null)
            {
                string result1 = "Barkod: " + data.Barkod + "\nSeri No: " + data.SeriNo + "\nParti No: " + data.PartiNo + "\nHL7 Kodu: " + data.Hl7Kodu + "\nSon Kullanma Tarihi: " + data.SonKullanmaTarihi.Value.ToString("dd.MM.yyyy") + "\nKirilim Bilgisi: " + data.BirimKirilimDegerleri;
                InfoBox.Show(result1);

                this._VaccineDetails.Barkod = data.Barkod;
                this._VaccineDetails.SeriNumarasi = data.SeriNo;
                this._VaccineDetails.PartiNumarasi = data.PartiNo;
                this._VaccineDetails.KirilimBilgisi = data.BirimKirilimDegerleri;

                if (data.SonKullanmaTarihi != null || data.SonKullanmaTarihi.Value.ToString() != "")
                        this._VaccineDetails.AsininSonKullanmaTarihi = Convert.ToDateTime(data.SonKullanmaTarihi.Value);

                ATSSorguInput input = new ATSSorguInput();
                input.AsiKodu = this._VaccineDetails.SKRSAsiKodu.KODU.ToString();
                input.Doz = Convert.ToInt32(this._VaccineDetails.SKRSAsininDozu.KODU);
                input.GezisiHizmetMi = this._VaccineDetails.GeziciHizmetMi == null ? false : Convert.ToBoolean(this._VaccineDetails.GeziciHizmetMi);
                input.Kirilim = data.BirimKirilimDegerleri == null ? "" : data.BirimKirilimDegerleri;
                input.SonKullanmaTarihi = data.SonKullanmaTarihi.Value.ToString("dd.MM.yyyy");
                input.Barkod = data.Barkod;
                input.PartiNo = data.PartiNo;
                input.SeriNo = data.SeriNo;

                AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuCikti result = ATS_Sorgula_Method(input);

                if (result.SorguNumarasi != null)
                    this._VaccineDetails.SorguNumarasi = result.SorguNumarasi;

                InfoBox.Show("Sorgu Kullan�labilirlik Durumu : " + Enum.GetName(typeof(AsiEntegrasyonServis.EKullanilabilirlikDurumu), result.SorguKullanilabilirlikDurumu) + "\nBilgi: " + result.Bilgi);


            }
            
     
        }

        private AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuCikti ATS_Sorgula_Method(ATSSorguInput data)
        {
            AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuCikti result = new AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuCikti();
            return result;

            /* TODO ASLI - EpisodeAction� parametre olarak componente g�nderdikten sonra d�zenlenecek
           var onlineProtolkolNo = OnlineProtokolAl();

           // Online Protokolun g�nderim zorunlulu�u kald�r�ld��� i�in kapat�ld�.
           //if(onlineProtolkolNo == "")
           //    return new AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuCikti();

           AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuGirdi input = new AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuGirdi();
           input.KullaniciBilgisi = new AsiEntegrasyonServis.KullaniciBilgisi();
           input.KullaniciBilgisi.KullaniciAdi = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");

           string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");

           System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
           System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
           string hex = BitConverter.ToString(sha.ComputeHash(enc.GetBytes(password)));
           hex = hex.Replace("-", "");

           input.KullaniciBilgisi.Parola = hex;


           Episode episode = this._EpisodeAction.SubEpisode.Episode;
           Patient patient = episode.Patient;
           SubEpisode subEpisode = this._EpisodeAction.SubEpisode;
           var starterEpisodeAction = subEpisode.StarterEpisodeAction;

           string hastaKimlikNo = "", hekimTC = "";
           AsiEntegrasyonServis.EKisiTipi vatandasTipi = new AsiEntegrasyonServis.EKisiTipi();

           if (patient.IsNewBorn == true)
           {
               vatandasTipi = AsiEntegrasyonServis.EKisiTipi.YeniDogan;
               hastaKimlikNo = patient.Mother.UniqueRefNo.ToString();
           }
           else
           {
               if (patient.Foreign == true)
               {
                   vatandasTipi = AsiEntegrasyonServis.EKisiTipi.Yabanci;
                   hastaKimlikNo = patient.ForeignUniqueRefNo.ToString();
               }
               else if (patient.UniqueRefNo != null)
               {
                   vatandasTipi = AsiEntegrasyonServis.EKisiTipi.Vatandas;
                   hastaKimlikNo = patient.UniqueRefNo.ToString();
               }
               else
                   vatandasTipi = AsiEntegrasyonServis.EKisiTipi.Vatansiz;
           }

           var procedureDoctor = starterEpisodeAction.ProcedureDoctor;
           if (procedureDoctor != null && procedureDoctor.Person != null)
               hekimTC = procedureDoctor.Person.UniqueRefNo != null ? procedureDoctor.Person.UniqueRefNo.ToString() : string.Empty; //��lemi ger�ekle�tiren hekimin T.C. Kimlik bilgisidir.

           input.SorguBilgisi = new AsiEntegrasyonServis.AsiSorguBilgisi();
           input.SorguBilgisi.AsiKodu = data.AsiKodu;
           input.SorguBilgisi.DogumTarihi = Convert.ToDateTime(patient.BirthDate);
           input.SorguBilgisi.DozBilgisi = data.Doz;
           input.SorguBilgisi.GeziciHizmetMi = data.GezisiHizmetMi;
           input.SorguBilgisi.HekimKimlikNo = hekimTC;
           input.SorguBilgisi.KirilimBilgisi = data.Kirilim;
           input.SorguBilgisi.OnlineProtokolNo = onlineProtolkolNo;
           input.SorguBilgisi.SonKullanmaTarihi = Convert.ToDateTime(data.SonKullanmaTarihi);
           input.SorguBilgisi.StokBarkod = data.Barkod;
           input.SorguBilgisi.StokSeriNo = data.SeriNo;
           input.SorguBilgisi.StokPartiNo = data.PartiNo;
           input.SorguBilgisi.UygulanacakKisiId = hastaKimlikNo;
           input.SorguBilgisi.UygulanacakKisiTipi = vatandasTipi;

           Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));

           AsiEntegrasyonServis.AsiKullanilabilirlikSorgusuCikti result = AsiEntegrasyonServis.WebMethods.AsiKullanilabilirlikSorgusuSync(siteIDGuid, input);
           return result;
           */
       }

       private string OnlineProtokolAl()
       {
           return "";
           /* TODO ASLI - EpisodeAction� parametre olarak componente g�nderdikten sonra d�zenlenecek
           if (string.IsNullOrEmpty(TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "")))
           {
               InfoBox.Show("Kurum Bilgisi Bulunamad�. L�tfen Sistem Parametrelerini Kontrol Ediniz.");
               return "";
           }
           Episode episode = this._EpisodeAction.SubEpisode.Episode;
           SubEpisode subEpisode = this._EpisodeAction.SubEpisode;
           PatientAdmission patientAdmission = episode.PatientAdmission;
           Patient patient = episode.Patient;
           var starterEpisodeAction = subEpisode.StarterEpisodeAction;

           if (subEpisode.OnlineProtokolNo != null && subEpisode.OnlineProtokolNo != "")
               return subEpisode.OnlineProtokolNo;

           OnlineProtokolServis.kullanici userInfo = new OnlineProtokolServis.kullanici();
           userInfo.erisimKodu = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
           userInfo.kullaniciAdi = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
           userInfo.kullaniciSifre = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");

           OnlineProtokolServis.protokol input = new OnlineProtokolServis.protokol();

           //TODO BG
           if (patientAdmission.AdmissionType.Code.Equals(ReasonForAdmissionTypeEnum.Emergency))
                input.protokolTipi = 2;// 1-Genel, 2-Acil, 3-Kontrol, 4-Kons
           else
           input.protokolTipi = 1;

           if (subEpisode.ResSection != null)
           {
               SKRSKlinikler mySKRSKlinikler = subEpisode.ResSection.GetMySKRSKlinikler();
               if (mySKRSKlinikler != null)
                   input.klinikKodu = Convert.ToInt32(mySKRSKlinikler.KODU); //SKRS Klinikler

           }

           input.bagliProtokolNo = ""; //Kons ya da kontrol ise ilk muayene protokolu.Zorunlu de�il
           input.USVSPaketId = 0; // USVS kapsam�na giren 7 adet paket numaras� alan�d�r. USVS kapsam d��� olmas� durumunda 0 olarak g�nderilir. 


           input.MHRS = "0";//�lgili i�lemin MHRS kapsam�nda olmas� durumunda HRN ( Hasta Randevu Numaras� ) olarak g�nderilir normal muayeneler 0 olarak g�nderilmelidir. 
           if (starterEpisodeAction != null)
           {
               if (starterEpisodeAction.PatientAdmission != null && starterEpisodeAction.PatientAdmission.AdmissionAppointment != null)
               {
                   foreach (Appointment appointment in starterEpisodeAction.PatientAdmission.AdmissionAppointment.Appointments)
                   {
                       if (!string.IsNullOrEmpty(appointment.MHRSRandevuHrn))
                       {
                           input.MHRS = appointment.MHRSRandevuHrn;
                           break;
                       }
                   }
               }
           }


           SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
           if (myTesisSKRSKurumlarDefinition != null)
               input.kurumKodu = myTesisSKRSKurumlarDefinition.KODU.ToString();//��lemin yap�ld��� kurum veya birim �KYS kodu alan�d�r.

           input.islemTarihi = DateTime.Now.ToString("dd.MM.yyyy HH:mm"); // dd.mm.yyyy ss:dd? olarak doldurulacak i�lem saatidir.
           input.otomasyonKayitId = subEpisode.ObjectID.ToString(); //Kurumda / Otomasyonda kay�t i�in olu�turulmu� Uniqid alan� girilmelidir.  subEpisodeun guidi

           var procedureDoctor = starterEpisodeAction.ProcedureDoctor;
           if (procedureDoctor != null && procedureDoctor.Person != null)
               input.hekimTCK = procedureDoctor.Person.UniqueRefNo != null ? procedureDoctor.Person.UniqueRefNo.ToString() : string.Empty; //��lemi ger�ekle�tiren hekimin T.C. Kimlik bilgisidir.

           input.hastaTipi = 0;//1-Vatanda�, 2-Yabanc�, 3-Vatans�z/M�lteci, 4-Yenido�an, 5-Gizli
           var hastaTC = "";

           if (patient.IsNewBorn == true)
           {
               input.hastaTipi = 4;
               hastaTC = patient.Mother.UniqueRefNo.ToString();
           }
           else
           {
               if (patient.Foreign == true)
               {
                   input.hastaTipi = 2;
                   hastaTC = patient.ForeignUniqueRefNo.ToString();
               }
               else if (patient.UniqueRefNo != null)
               {
                   input.hastaTipi = 1;
                   hastaTC = patient.UniqueRefNo.ToString();
               }
               else
                   input.hastaTipi = 3;
           }

           input.vatandasTCK = hastaTC;//��lem yap�lacak Vatanda��n T.C.Kimlik numaras� belirli ise doldurulur. 

           Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));

           OnlineProtokolServis.cevap result = OnlineProtokolServis.WebMethods.protokolVerSync(siteIDGuid, userInfo, input);
           if (result.cevapKodu == 0)
           {
               this._EpisodeAction.SubEpisode.OnlineProtokolNo = result.protokolNo;
               return result.protokolNo;

           }
           else
           {
               //InfoBox.Show("Cevap Kodu: " + result.cevapKodu.ToString() +" - " + result.cevapAciklama);
               return "";

           }
           */


        }
       protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
       {
            base.ClientSidePostScript(transDef);

            if (_VaccineDetails.DisMerkezMi == true && string.IsNullOrEmpty(_VaccineDetails.DisMerkez))
            {
                InfoBox.Show("L�tfen A��n�n Uyguland��� D�� Merkezi Girin.");
                return;
            }
       }
        private void ATS_Bildirim_Click()
        {
             /* TODO ASLI - EpisodeAction� parametre olarak componente g�nderdikten sonra d�zenlenecek
            if (transDef.ToStateDefID == VaccineFollowUp.States.Completed)
            {
                bool found = false;
                for (int i = 0; i < this._VaccineFollowUp.VaccineDetails.Count; i++)
                {
                    if (this._VaccineFollowUp.VaccineDetails[i].SorguNumarasi == null || this._VaccineFollowUp.VaccineDetails[i].SorguNumarasi == "")
                    {
                        found = true;
                        break;
                    }

                }
                if (found == true)
                {
                    throw new Exception("ATS Sorgusu Yap�lmam�� A��lar�n Bildirimini Yapamazs�n�z.");
                }

                //ATS_Bildirim

                AsiEntegrasyonServis.AsiUygulamaParametre input = new AsiEntegrasyonServis.AsiUygulamaParametre();
                input.KullaniciBilgisi = new AsiEntegrasyonServis.KullaniciBilgisi();
                input.KullaniciBilgisi.KullaniciAdi = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");

                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");

                System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                string hex = BitConverter.ToString(sha.ComputeHash(enc.GetBytes(password)));
                hex = hex.Replace("-", "");

                input.KullaniciBilgisi.Parola = hex;

                string bildirimInfo = "";

                for (int i = 0; i < this._VaccineFollowUp.VaccineDetails.Count; i++)
                {
                    input.UygulamaSorguBilgisi = new AsiEntegrasyonServis.AsiUygulamaBilgisi();
                    input.UygulamaSorguBilgisi.OnlineProtokolNo = this._EpisodeAction.SubEpisode.OnlineProtokolNo;
                    input.UygulamaSorguBilgisi.SorguNumarasi = this._VaccineFollowUp.VaccineDetails[i].SorguNumarasi;
                    input.UygulamaSorguBilgisi.UygulamaZamani = DateTime.Now;

                    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                    AsiEntegrasyonServis.AsiUygulamaCikti result = AsiEntegrasyonServis.WebMethods.AsiUygulamaSync(siteIDGuid, input);

                    string res = Enum.GetName(typeof(AsiEntegrasyonServis.EUygulamaDurum), result);


                    if (bildirimInfo == "")
                        bildirimInfo = "ATS Bildirim Sonucu;\n" + this._VaccineFollowUp.VaccineDetails[i].SKRSAsiKodu + " : " + res + "\n";
                    else
                        bildirimInfo += this._VaccineFollowUp.VaccineDetails[i].SKRSAsiKodu + " : " + res;


                }

                InfoBox.Show(bildirimInfo);

            }
            */
        }
    }
}