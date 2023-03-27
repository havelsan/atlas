
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
    /// <summary>
    /// Hasta Bilgileri
    /// </summary>
    public partial class PatientForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdQueryFromMernisForForeign.Click += new TTControlEventDelegate(cmdQueryFromMernisForForeign_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            cmdQueryFromMernis.Click += new TTControlEventDelegate(cmdQueryFromMernis_Click);
            ttbuttonAnneAra.Click += new TTControlEventDelegate(ttbuttonAnneAra_Click);
            Foreign.CheckedChanged += new TTControlEventDelegate(Foreign_CheckedChanged);
            UnIdentified.CheckedChanged += new TTControlEventDelegate(UnIdentified_CheckedChanged);
            CountryOfBirth.SelectedObjectChanged += new TTControlEventDelegate(CountryOfBirth_SelectedObjectChanged);
            BDYearOnly.CheckedChanged += new TTControlEventDelegate(BDYearOnly_CheckedChanged);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdQueryFromMernisForForeign.Click -= new TTControlEventDelegate(cmdQueryFromMernisForForeign_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            cmdQueryFromMernis.Click -= new TTControlEventDelegate(cmdQueryFromMernis_Click);
            ttbuttonAnneAra.Click -= new TTControlEventDelegate(ttbuttonAnneAra_Click);
            Foreign.CheckedChanged -= new TTControlEventDelegate(Foreign_CheckedChanged);
            UnIdentified.CheckedChanged -= new TTControlEventDelegate(UnIdentified_CheckedChanged);
            CountryOfBirth.SelectedObjectChanged -= new TTControlEventDelegate(CountryOfBirth_SelectedObjectChanged);
            BDYearOnly.CheckedChanged -= new TTControlEventDelegate(BDYearOnly_CheckedChanged);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            base.UnBindControlEvents();
        }

        private void cmdQueryFromMernisForForeign_Click()
        {
#region PatientForm_cmdQueryFromMernisForForeign_Click
   try
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("KIMLIKNOILEADRESSORGUPARAM", "FALSE") == "TRUE")
                {                 
                    if (_Patient.ForeignUniqueRefNo != null)
                    {
                        KPSServis.KPSServisSonucuYabanciKisiBilgisi response = KPSServis.WebMethods.YabanciTcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(_Patient.ForeignUniqueRefNo.Value));

                        if (string.IsNullOrEmpty(response.Hata))
                        {
                            if (string.IsNullOrEmpty(response.Sonuc.Hata))
                            {
                                _Patient.IsTrusted = true;

                                _Patient.FatherName = response.Sonuc.BabaAd;
                                _Patient.Name = response.Sonuc.Ad;
                                _Patient.Surname = response.Sonuc.Soyad;

                                //if (!string.IsNullOrEmpty(response.Sonuc.Cinsiyet) && response.Sonuc.Cinsiyet == "Erkek")
                                //    _Patient.Sex = SexEnum.Male;
                                //else
                                //    _Patient.Sex = SexEnum.Female;

                                if (!string.IsNullOrEmpty(response.Sonuc.DogumTarih))
                                {
                                    _Patient.BirthDate = Convert.ToDateTime(response.Sonuc.DogumTarih);                               
                                    BirthDate.Text = _Patient.BirthDate.Value.ToString("dd/MM/yyyy");
                                }
                                
                                if (!string.IsNullOrEmpty(response.Sonuc.UlkeKod))
                                {
                                    var sKRSUlkeKodlariList = SKRSUlkeKodlari.GetByMernisKodu(this._Patient.ObjectContext, response.Sonuc.UlkeKod);
                                    _Patient.Nationality = sKRSUlkeKodlariList[0];                                }


                                if (!string.IsNullOrEmpty(response.Sonuc.OlumTarihi))                                
                                    _Patient.ExDate = Convert.ToDateTime(response.Sonuc.OlumTarihi);
                                

                                var acikAdres = "";
                                if (!string.IsNullOrEmpty(response.Sonuc.IkametAdres))
                                    acikAdres = response.Sonuc.IkametAdres;
                                else if(!string.IsNullOrEmpty(response.Sonuc.Ulke))
                                {
                                    acikAdres = response.Sonuc.Ulke;
                                    if(!string.IsNullOrEmpty(response.Sonuc.DogumYer))
                                        acikAdres += response.Sonuc.DogumYer;
                                }  
                                _Patient.PatientAddress.HomeAddress = acikAdres;
  
                            }
                            else
                            {
                                InfoBox.Show(response.Sonuc.Hata);
                                return;
                            }
                        }
                        else
                        {
                            InfoBox.Show(response.Hata);
                            return;
                        }
                    }
                }
                else
                {
                    KPSYbKisiSorgulaYbKimlikNoServis.YbKisiSorgulaYbKimlikNoSorguKriteri kriter = new KPSYbKisiSorgulaYbKimlikNoServis.YbKisiSorgulaYbKimlikNoSorguKriteri();
                    kriter.KimlikNo = Convert.ToInt64(_Patient.ForeignUniqueRefNo);

                    KPSYbKisiSorgulaYbKimlikNoServis.YbKimlikNoIleYbKisiBilgisiSonucu sonuc =
                        KPSYbKisiSorgulaYbKimlikNoServis.WebMethods.ListeleCokluSync(Sites.SiteLocalHost, kriter);

                    KPSYbKisiSorgulaYbKimlikNoServis.YbKimlikNoIleYbKisiBilgisi kisiBilgisi = sonuc.SorguSonucu[0];
                    if (kisiBilgisi == null)
                    {
                        InfoBox.Show("Kişinin MERNİS bilgilerine ulaşılamadı.");
                        return;
                    }
                    else
                    {
                        _Patient.IsTrusted = true;

                        _Patient.FatherName = kisiBilgisi.BabaAd;
                        _Patient.Name = kisiBilgisi.Ad;
                        _Patient.Surname = kisiBilgisi.Soyad;

                        //if (kisiBilgisi.Cinsiyet != null && kisiBilgisi.Cinsiyet.Kod != null && kisiBilgisi.Cinsiyet.Kod == 1)
                        //    _Patient.Sex = SexEnum.Male;
                        //else
                        //    _Patient.Sex = SexEnum.Female;

                        _Patient.BirthDate = new DateTime(kisiBilgisi.DogumTarih.Yil ?? 0, kisiBilgisi.DogumTarih.Ay ?? 1, kisiBilgisi.DogumTarih.Gun ?? 1);

                        BirthDate.Text = _Patient.BirthDate.Value.ToString("dd/MM/yyyy");

                        if (kisiBilgisi.OlumTarih != null)
                        {
                            if (kisiBilgisi.OlumTarih.Gun != null && kisiBilgisi.OlumTarih.Ay != null && kisiBilgisi.OlumTarih.Yil != null)
                                _Patient.ExDate = Convert.ToDateTime(kisiBilgisi.OlumTarih.Gun.ToString() + "." + kisiBilgisi.OlumTarih.Ay.ToString() + "." + kisiBilgisi.OlumTarih.Yil.ToString());
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new TTUtils.TTException(ex.Message);
            }
#endregion PatientForm_cmdQueryFromMernisForForeign_Click
        }

        private void ttbutton1_Click()
        {
#region PatientForm_ttbutton1_Click
   TTObjectContext objectContext = new TTObjectContext(false);
            IList patientList = Patient.GetAllPatients(objectContext);
            Guid savePointGuid = objectContext.BeginSavePoint();
            try
            {
                foreach (Patient p in patientList)
                {
                    p.NameIsUpdated = true;
                    p.SurnameIsUpdated = true;
                    if (p.BirthDate == null)
                        p.BirthDate = Convert.ToDateTime("01.01.2000 00:00:00");
                    if (p.BDYearOnly == null)
                        p.BDYearOnly = false;
                    if (p.UnIdentified == null)
                        p.UnIdentified = false;
                 /*   if (p.WarVetera == null)
                        p.WarVetera = false;*/
                    if (p.Name == null)
                        p.Name = "KİMLİKSİZ";
                    if (p.Surname == null)
                        p.Surname = "HASTA";
                    if (p.Foreign == null)
                        p.Foreign = false;
                    p.CreatePatientTokens();
                    p.NameIsUpdated = false;
                    p.SurnameIsUpdated = false;
                }
                objectContext.Save();
                objectContext.Dispose();
                InfoBox.Show("Bitti");
            }
            catch (Exception ex)
            {
                objectContext.RollbackSavePoint(savePointGuid);
                throw ex;
            }
#endregion PatientForm_ttbutton1_Click
        }

        private void cmdQueryFromMernis_Click()
        {
#region PatientForm_cmdQueryFromMernis_Click
   try
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("KIMLIKNOILEADRESSORGUPARAM", "FALSE") == "TRUE")
                {
                    //Yabanci Kimlik no ile Birleştirildi BG.
                    if (_Patient.Foreign == true && _Patient.ForeignUniqueRefNo != null)
                    {
                        KPSServis.KPSServisSonucuYabanciKisiBilgisi  response = KPSServis.WebMethods.YabanciTcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost,Convert.ToInt64(_Patient.ForeignUniqueRefNo.Value));
                        
                        if (string.IsNullOrEmpty(response.Hata))
                        {
                            if (string.IsNullOrEmpty(response.Sonuc.Hata))
                            {
                                _Patient.IsTrusted = true;

                                _Patient.FatherName = response.Sonuc.BabaAd;
                                _Patient.Name = response.Sonuc.Ad;
                                _Patient.Surname = response.Sonuc.Soyad;

                                //if (!string.IsNullOrEmpty(response.Sonuc.Cinsiyet) && response.Sonuc.Cinsiyet == "Erkek")
                                //    _Patient.Sex = SexEnum.Male;
                                //else
                                //    _Patient.Sex = SexEnum.Female;
                                
                                if(!string.IsNullOrEmpty(response.Sonuc.DogumTarih))
                                {
                                    _Patient.BirthDate = Convert.ToDateTime(response.Sonuc.DogumTarih);
                                    BirthDate.Text = _Patient.BirthDate.Value.ToString("dd/MM/yyyy");
                                }

                                if (!string.IsNullOrEmpty(response.Sonuc.UlkeKod))
                                {
                                    var sKRSUlkeKodlariList = SKRSUlkeKodlari.GetByMernisKodu(this._Patient.ObjectContext, response.Sonuc.UlkeKod);
                                    _Patient.Nationality = sKRSUlkeKodlariList[0];
                                }
                                
                                if (!string.IsNullOrEmpty(response.Sonuc.OlumTarihi))
                                    _Patient.ExDate = Convert.ToDateTime(response.Sonuc.OlumTarihi);
                                

                                var acikAdres = "";
                                if (!string.IsNullOrEmpty(response.Sonuc.IkametAdres))
                                    acikAdres = response.Sonuc.IkametAdres;
                                else if(!string.IsNullOrEmpty(response.Sonuc.Ulke))
                                {
                                    acikAdres = response.Sonuc.Ulke;
                                    if(!string.IsNullOrEmpty(response.Sonuc.DogumYer))
                                        acikAdres += response.Sonuc.DogumYer;
                                }
                                _Patient.PatientAddress.HomeAddress = acikAdres;
                            }
                            else
                            {
                                InfoBox.Show(response.Sonuc.Hata);
                                return;
                            }
                        }
                        else
                        {
                            InfoBox.Show(response.Hata);
                            return;
                        }
                    }
                    else if (_Patient.UniqueRefNo != null)
                    {
                        KPSServis.KPSServisSonucuKisiTemelBilgisi response = KPSServis.WebMethods.TcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost, _Patient.UniqueRefNo.Value);
                        if (string.IsNullOrEmpty(response.Hata))
                        {
                            if (string.IsNullOrEmpty(response.Sonuc.Hata))
                            {
                                _Patient.IsTrusted = true;

                                _Patient.FatherName = response.Sonuc.BabaAd;
                                _Patient.Name = response.Sonuc.Ad;
                                _Patient.Surname = response.Sonuc.Soyad;

                                //if (!string.IsNullOrEmpty(response.Sonuc.Cinsiyet) && response.Sonuc.Cinsiyet == "Erkek")
                                //    _Patient.Sex = SexEnum.Male;
                                //else
                                //    _Patient.Sex = SexEnum.Female;

                                if(!string.IsNullOrEmpty(response.Sonuc.DogumTarihi))
                                {
                                    _Patient.BirthDate = Convert.ToDateTime(response.Sonuc.DogumTarihi);
                                    BirthDate.Text = _Patient.BirthDate.Value.ToString("dd/MM/yyyy");
                                }

                                if (response.Sonuc.OlumTarih != "0.0.0" && !string.IsNullOrEmpty(response.Sonuc.OlumTarih))                                
                                    _Patient.ExDate = Convert.ToDateTime(response.Sonuc.OlumTarih);
                                
                                                              
                                if (!string.IsNullOrEmpty(response.Sonuc.IlceAd))
                                    _Patient.PatientAddress.SKRSAcikAdresIlce = response.Sonuc.IlceAd;
                                
                                
                                KPSServis.KPSServisSonucuKisiAdresBilgisi res = KPSServis.WebMethods.TcKimlikNoIleAdresBilgisiSorgulaSync(Sites.SiteLocalHost, _Patient.UniqueRefNo.Value);

                                if (string.IsNullOrEmpty(res.Hata))
                                {
                                    if (string.IsNullOrEmpty(res.Sonuc.Hata))
                                    {
                                        _Patient.PatientAddress.SKRSCsbmKodu.KODU = res.Sonuc.CsbmKodu;
                                        _Patient.PatientAddress.SKRSCsbmKodu.ADI = res.Sonuc.Csbm;

                                        var adresKodu = (!string.IsNullOrEmpty(res.Sonuc.IcKapiNo) ? "8" : (!string.IsNullOrEmpty(res.Sonuc.Csbm) ? "6" :
                                                                                                            (!string.IsNullOrEmpty(res.Sonuc.MahalleKodu) ? "5" : (!string.IsNullOrEmpty(res.Sonuc.KoyKodu) ? "4" : (!string.IsNullOrEmpty(res.Sonuc.DisKapiNo) ? "7" : (""))))));

                                        _Patient.PatientAddress.SKRSAdresKodu = adresKodu;

                                        BindingList<SKRSAdresKoduSeviyesi> adreskoduSeviyesiList = SKRSAdresKoduSeviyesi.GetSKRSAdresKoduSByKodu(_Patient.ObjectContext, adresKodu);
                                        if (adreskoduSeviyesiList.Count > 0)
                                            _Patient.PatientAddress.SKRSAdresKoduSeviyesi = adreskoduSeviyesiList[0];
                                        else
                                            _Patient.PatientAddress.SKRSAdresKoduSeviyesi = new SKRSAdresKoduSeviyesi();
                                        
                                    }
                                    else
                                    {
                                        InfoBox.Show(response.Sonuc.Hata);
                                        return;
                                    }
                                }
                                else
                                {
                                    InfoBox.Show(response.Hata);
                                    return;
                                }
                            }
                            else
                            {
                                InfoBox.Show(response.Sonuc.Hata);
                                return;
                            }
                        }
                        else
                        {
                            InfoBox.Show(response.Hata);
                            return;
                        }
                    }
                }
                else
                {
                    KPSKisiSorgulaKimlikNoServis.KisiSorgulaTCKimlikNoSorguKriteri kriter = new KPSKisiSorgulaKimlikNoServis.KisiSorgulaTCKimlikNoSorguKriteri();
                    kriter.TCKimlikNo = _Patient.UniqueRefNo;
                    
                    KPSKisiSorgulaKimlikNoServis.KisiBilgisiSonucu sonuc =
                        KPSKisiSorgulaKimlikNoServis.WebMethods.ListeleCokluSync(Sites.SiteLocalHost, kriter);
                    
                    KPSKisiSorgulaKimlikNoServis.KisiBilgisi kisiBilgisi = sonuc.SorguSonucu[0];
                    if (kisiBilgisi == null)
                    {
                        InfoBox.Show("Kişinin MERNİS bilgilerine ulaşılamadı.");
                        return;
                    }
                    else
                    {
                        _Patient.IsTrusted = true;

                        _Patient.FatherName = kisiBilgisi.TemelBilgisi.BabaAd;
                        _Patient.Name = kisiBilgisi.TemelBilgisi.Ad;
                        _Patient.Surname = kisiBilgisi.TemelBilgisi.Soyad;
                        
                        //if(kisiBilgisi.TemelBilgisi.Cinsiyet != null && kisiBilgisi.TemelBilgisi.Cinsiyet.Kod != null && kisiBilgisi.TemelBilgisi.Cinsiyet.Kod == 1)
                        //    _Patient.Sex =  SexEnum.Male;
                        //else
                        //    _Patient.Sex =  SexEnum.Female;
                        
                        _Patient.BirthDate = new DateTime(kisiBilgisi.TemelBilgisi.DogumTarih.Yil ?? 0, kisiBilgisi.TemelBilgisi.DogumTarih.Ay ?? 1, kisiBilgisi.TemelBilgisi.DogumTarih.Gun ?? 1  );
                        
                        BirthDate.Text = _Patient.BirthDate.Value.ToString("dd/MM/yyyy");

                        IBindingList townsOfRegistry = _Patient.ObjectContext.QueryObjects(typeof(TownDefinitions).Name, "MERNISCODE = " + kisiBilgisi.KayitYeriBilgisi.Ilce.Kod);
                        if (townsOfRegistry.Count == 1)
                        {
                            //TownDefinitions townOfRegistry = (TownDefinitions)townsOfRegistry[0];
                            //_Patient.TownOfRegistry = townOfRegistry;
                            //_Patient.CityOfRegistry = townOfRegistry.City;
                        }
                        else if (townsOfRegistry.Count == 0)
                            InfoBox.Show("Bu MERNİS koduna sahip bir şehir tanımı bulunamadı.\r\n" + kisiBilgisi.KayitYeriBilgisi.Ilce.Kod);
                        else
                            InfoBox.Show("Bu MERNİS koduna sahip mükerrer şehir tanımları bulundu.\r\n" + kisiBilgisi.KayitYeriBilgisi.Ilce.Kod);

                        IBindingList citiesOfBirth = _Patient.ObjectContext.QueryObjects(typeof(City).Name, "MERNISCODE = " + kisiBilgisi.KayitYeriBilgisi.Il.Kod);
                        //if (citiesOfBirth.Count == 1)
                        //    _Patient.CityOfBirth = (City)citiesOfBirth[0];
                        //else if (citiesOfBirth.Count == 0)
                        //    InfoBox.Show("Bu MERNİS koduna sahip bir şehir tanımı bulunamadı.\r\n" + kisiBilgisi.TemelBilgisi.DogumYer);
                        //else
                        //    InfoBox.Show("Bu MERNİS koduna sahip mükerrer şehir tanımları bulundu.\r\n" + kisiBilgisi.TemelBilgisi.DogumYer);

                        if (kisiBilgisi.DurumBilgisi.OlumTarih != null)
                        {
                            if (kisiBilgisi.DurumBilgisi.OlumTarih.Gun != null && kisiBilgisi.DurumBilgisi.OlumTarih.Ay != null && kisiBilgisi.DurumBilgisi.OlumTarih.Yil != null)
                                _Patient.ExDate = Convert.ToDateTime(kisiBilgisi.DurumBilgisi.OlumTarih.Gun.ToString() + "." + kisiBilgisi.DurumBilgisi.OlumTarih.Ay.ToString() + "." + kisiBilgisi.DurumBilgisi.OlumTarih.Yil.ToString());
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new TTUtils.TTException(ex.Message);
            }
#endregion PatientForm_cmdQueryFromMernis_Click
        }

        private void ttbuttonAnneAra_Click()
        {
#region PatientForm_ttbuttonAnneAra_Click

#endregion PatientForm_ttbuttonAnneAra_Click
        }

        private void Foreign_CheckedChanged()
        {
#region PatientForm_Foreign_CheckedChanged
   string turkey = TTObjectClasses.SystemParameter.GetParameterValue("TURKEYCOUNTRYOBJECTID", "27ff15c1-c50d-4b9a-bff8-b010939c39d6");
            Guid turkeyID = new Guid(turkey);
            if (this.Foreign.Value == true)
            {
                this.UniqueRefNo.Text = string.Empty;
                this.ForeignUniqueNo.ReadOnly = false;
                // this.ForeignUniqueNo.Required=true;
                ((ITTControl)this.ForeignUniqueNo).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
                this.UniqueRefNo.ReadOnly = true;
                //this.UniqueRefNo.Required=false;
                ((ITTControl)this.UniqueRefNo).BackColor = System.Drawing.Color.White;
                this.cmdQueryFromMernis.Enabled = false; 
                this.cmdQueryFromMernisForForeign.Enabled = true;
                //                if (this.CountryOfBirth.SelectedObjectID.HasValue)
                //                {
                //                    if (this.CountryOfBirth.SelectedObjectID.Value.Equals(turkeyID))
                //                    {
                //                        this.CountryOfBirth.SelectedObject = null;
                //                        this.CityOfBirth.SelectedObject = null;
                //                        this.TownOfBirth.SelectedObject = null;
                //                        this.CountryOfBirth.ReadOnly = false;
                //
                //                    }
                //                }
                //this.CityOfBirth.ReadOnly = true;
                //this.CityOfBirth.Required=false;
                //((ITTControl)this.CityOfBirth).BackColor = System.Drawing.Color.White;
                //this.TownOfBirth.ReadOnly = true;
                // this.TownOfBirth.Required=false;
                //((ITTControl)this.TownOfBirth).BackColor = System.Drawing.Color.White;
            }
            else
            {
                this.ForeignUniqueNo.Text = string.Empty;
                this.ForeignUniqueNo.ReadOnly = true;
                //this.ForeignUniqueNo.Required=false;
                ((ITTControl)this.ForeignUniqueNo).BackColor = System.Drawing.Color.White;

                this.UniqueRefNo.ReadOnly = false;
                //this.UniqueRefNo.Required=true;
                ((ITTControl)this.UniqueRefNo).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
                this.cmdQueryFromMernis.Enabled = true; 
                this.cmdQueryFromMernisForForeign.Enabled = false;

                //this.CountryOfBirth.SelectedObject = this._Patient.ObjectContext.GetObject(turkeyID, "COUNTRY");
                //this.CountryOfBirth.ReadOnly = true; // Yabancı doğumlu Turk hasta olabilir
                //this.CityOfBirth.ReadOnly = false;
                //this.CityOfBirth.Required=true;
                //((ITTControl)this.CityOfBirth).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);

                //this.TownOfBirth.ReadOnly = false;
                //this.TownOfBirth.Required=true;
                //((ITTControl)this.TownOfBirth).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);

            }
#endregion PatientForm_Foreign_CheckedChanged
        }

  

        private void UnIdentified_CheckedChanged()
        {
#region PatientForm_UnIdentified_CheckedChanged
   /// Kimlik Bilgileri biliniyor checki işaretli ise tüm alanları enablenı kaldırır
            /// 
            if (this.UnIdentified.Value == true)
            {
               /* for (int i = 0; i < (this.Controls.Count); i++)
                {
                    if (this.Controls[i].Name.ToString() != "pnlButtons")
                    {
                        for (int k = 0; k < (this.Controls[i].Controls.Count); k++)//Tab
                        {
                            for (int j= 0; j< (this.Controls[i].Controls[k].Controls.Count); j++)//TabPage
                            {
                                for (int l= 0; l< (this.Controls[i].Controls[k].Controls[j].Controls.Count); l++)//Controls
                                {
                                    if (this.Controls[i].Controls[k].Controls[j].Controls[l].Name.ToString() != "UnIdentified" && this.Controls[i].Controls[k].Controls[j].Controls[l].Name.ToString() != "Sex")
                                    {
                                        this.Controls[i].Controls[k].Controls[j].Controls[l].Enabled = false;
                                        //                                if(this.Controls[i].Controls[k] is TTTextBox)
                                        //                                    ((TTVisual.TTTextBox)this.Controls[i].Controls[k]).Required = false;
                                    }
                                }
                            }
                        }
                    }
                }*/

                if (string.IsNullOrEmpty(this._Patient.Name))
                    this._Patient.Name = "Kimliği";
                if (string.IsNullOrEmpty(this._Patient.Surname))
                    this._Patient.Surname = "Bilinmiyor";
                //if (this._Patient.BloodGroup == null)
                //    this._Patient.BloodGroup = BloodGroupEnum.Unknown;
            }
            else
            {
                for (int i = 0; i < (this.Controls.Count); i++)
                {
                    if (this.Controls[i].Name.ToString() != "pnlButtons")
                    {
                        for (int k = 0; k < (this.Controls[i].Controls.Count); k++)//Tab
                        {
                            for (int j= 0; j< (this.Controls[i].Controls[k].Controls.Count); j++)//TabPage
                            {
                                for (int l= 0; l< (this.Controls[i].Controls[k].Controls[j].Controls.Count); l++)//Controls
                                {
                                    this.Controls[i].Controls[k].Controls[j].Controls[l].Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
#endregion PatientForm_UnIdentified_CheckedChanged
        }

        private void CountryOfBirth_SelectedObjectChanged()
        {
#region PatientForm_CountryOfBirth_SelectedObjectChanged
   //            if (this.CountryOfBirth.SelectedObjectID.HasValue)
            //            {
            //                string turkey = TTObjectClasses.SystemParameter.GetParameterValue("TURKEYCOUNTRYOBJECTID", "27ff15c1-c50d-4b9a-bff8-b010939c39d6");
            //                Guid turkeyID = new Guid(turkey);
            //                if (this.CountryOfBirth.SelectedObjectID.Value.Equals(turkeyID))
            //                {
            //                    this.ForeignUniqueNo.Text = string.Empty;
            //                    this.ForeignUniqueNo.ReadOnly = true;
            //                    //this.ForeignUniqueNo.Required = false;
            //                    ((ITTControl)this.ForeignUniqueNo).BackColor = System.Drawing.Color.White;
            //
            //                    this.UniqueRefNo.Text = string.Empty;
            //                    this.UniqueRefNo.ReadOnly = false;
            //                    //this.UniqueRefNo.Required = true;
            //                    ((ITTControl)this.UniqueRefNo).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
            //
            //                    this.Foreign.Value = false;
            //                }
            //                else
            //                {
            //                    this.UniqueRefNo.Text = string.Empty;
            //                    this.ForeignUniqueNo.ReadOnly = false;
            //                    //this.ForeignUniqueNo.Required = true;
            //                    ((ITTControl)this.ForeignUniqueNo).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
            //
            //                    this.UniqueRefNo.ReadOnly = true;
            //                    //this.UniqueRefNo.Required = false;
            //                    ((ITTControl)this.UniqueRefNo).BackColor = System.Drawing.Color.White;
            //                    this.Foreign.Value = true;
            //                }
            //
            //            }
            string turkey = TTObjectClasses.SystemParameter.GetParameterValue("TURKEYCOUNTRYOBJECTID", "27ff15c1-c50d-4b9a-bff8-b010939c39d6");
            Guid turkeyID = new Guid(turkey);

            if (this.CountryOfBirth.SelectedObject != null && (!this.CountryOfBirth.SelectedObjectID.Value.Equals(turkeyID)))
            {
                this.CityOfBirth.ReadOnly = true;
                ((ITTControl)this.CityOfBirth).BackColor = System.Drawing.Color.White;

                this.TownOfBirth.ReadOnly = true;
                ((ITTControl)this.TownOfBirth).BackColor = System.Drawing.Color.White;
            }
            else
            {
                this.CityOfBirth.ReadOnly = false;
                ((ITTControl)this.CityOfBirth).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);

                this.TownOfBirth.ReadOnly = false;
                ((ITTControl)this.TownOfBirth).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
            }
#endregion PatientForm_CountryOfBirth_SelectedObjectChanged
        }

        private void BDYearOnly_CheckedChanged()
        {
#region PatientForm_BDYearOnly_CheckedChanged
   if (this.UnIdentified.Value != true)
            {
                if (this.BDYearOnly.Value == true)
                {
                    if (this.BirthDate.Text.Length > 6)
                        this.BirthDate.Text = this.BirthDate.Text.Substring(6);
                    this.BirthDate.Mask = "0000";
                }
                else
                {
                    this.BirthDate.Mask = "00/00/0000";
                    if (this.BirthDate.Text.Trim() != ".  .")
                    {
                        if (this.BirthDate.Text.Length > 0)
                            this.BirthDate.Text = "0101" + this.BirthDate.Text;
                    }
                }
            }
#endregion PatientForm_BDYearOnly_CheckedChanged
        }

        private void ttbutton2_Click()
        {
#region PatientForm_ttbutton2_Click
   AddPicture();
#endregion PatientForm_ttbutton2_Click
        }

        protected override void PreScript()
        {
#region PatientForm_PreScript
    string turkey = TTObjectClasses.SystemParameter.GetParameterValue("TURKEYCOUNTRYOBJECTID", "27ff15c1-c50d-4b9a-bff8-b010939c39d6");
            Guid turkeyID = new Guid(turkey);
            this.CityOfRegistry.ListFilterExpression = "COUNTRY='" + turkeyID.ToString() + "'";

            if (this._Patient.BirthDate != null)
            {
                string birthDate = (Convert.ToDateTime(this._Patient.BirthDate)).ToString("dd/MM/yyyy");
                if (this.BDYearOnly.Value == true)
                {
                    if (this.BirthDate.Text.Length > 6)
                        this.BirthDate.Text = birthDate.Substring(6);
                    this.BirthDate.Mask = "0000";
                }
                else
                {
                    this.BirthDate.Mask = "00/00/0000";
                    this.BirthDate.Text = birthDate;
                }

            }

            //if (this._Patient.BloodGroup == null)
            //    this._Patient.BloodGroup = BloodGroupEnum.Unknown;

            //this.BloodGroup.Required = true;


            ((ITTControl)this.Name).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
            ((ITTControl)this.Surname).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
        //    ((ITTControl)this.Sex).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
            ((ITTControl)this.FatherName).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
            ((ITTControl)this.BirthDate).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
            ((ITTControl)this.CountryOfBirth).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);

            if (Common.CurrentResource.IsEmergencyUser)
                this.UnIdentified.Visible = true;
            else
                this.UnIdentified.Visible = false;

            if (this._Patient.Foreign == true)
            {
                this.ForeignUniqueNo.ReadOnly = false;
                ((ITTControl)this.ForeignUniqueNo).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);

                this.UniqueRefNo.ReadOnly = true;
                ((ITTControl)this.UniqueRefNo).BackColor = System.Drawing.Color.White;

                this.CountryOfBirth.ReadOnly = false;
                this.CityOfBirth.ReadOnly = true;
                ((ITTControl)this.CityOfBirth).BackColor = System.Drawing.Color.White;

                this.TownOfBirth.ReadOnly = true;
                ((ITTControl)this.TownOfBirth).BackColor = System.Drawing.Color.White;
                
                this.cmdQueryFromMernis.Enabled = false;
                this.cmdQueryFromMernisForForeign.Enabled = true;
            }
            else
            {
                this.ForeignUniqueNo.ReadOnly = true;
                ((ITTControl)this.ForeignUniqueNo).BackColor = System.Drawing.Color.White;
                
                ((ITTControl)this.UniqueRefNo).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
                
                if (this._Patient.Nationality == null)// Hasta ilk açılıyorsa default TÜRKİYE gelsin
                {
                    var sKRSUlkeKodlariList = SKRSUlkeKodlari.GetByMernisKodu(this._Patient.ObjectContext,"9980");
                    this._Patient.Nationality = sKRSUlkeKodlariList[0];
                }
                if (this._Patient.CountryOfBirth == null)// HAsta ilk açılıyorsa default turkiye gelsin
                {

               //     this._Patient.CountryOfBirth = (Country)this._Patient.ObjectContext.GetObject(turkeyID, "COUNTRY");
                    // this.CountryOfBirth.ReadOnly = true; // Yabancı doğumlu Turk hasta olabilir
                }
                this.CityOfBirth.ReadOnly = false;
                ((ITTControl)this.CityOfBirth).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);

                this.TownOfBirth.ReadOnly = false;
                ((ITTControl)this.TownOfBirth).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
                
                this.cmdQueryFromMernis.Enabled = true;
                this.cmdQueryFromMernisForForeign.Enabled = false;
            }
            if (((ITTObject)this._Patient).IsNew)
                DrawSearchButton();
            else
                this.UnIdentified.Value = false;

            if (this._Patient.ForeignUniqueRefNo != null || this._Patient.UniqueRefNo != null)
                this.UnIdentified.Enabled = false;

            this.BirthDate.ReadOnly = false;
            if (this.CountryOfBirth.SelectedObjectID != null)
            {
                if (!this.CountryOfBirth.SelectedObjectID.Value.Equals(turkeyID))
                {
                    this.CityOfBirth.ReadOnly = true;
                    ((ITTControl)this.CityOfBirth).BackColor = System.Drawing.Color.White;

                    this.TownOfBirth.ReadOnly = true;
                    ((ITTControl)this.TownOfBirth).BackColor = System.Drawing.Color.White;
                }
                else
                {
                    this.CityOfBirth.ReadOnly = false;
                    ((ITTControl)this.CityOfBirth).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);

                    this.TownOfBirth.ReadOnly = false;
                    ((ITTControl)this.TownOfBirth).BackColor = System.Drawing.Color.FromArgb(255, 255, 180);
                }
            }
            

            if (!Common.CurrentUser.IsPowerUser && !Common.CurrentUser.IsSuperUser)
            {
                if (UniqueRefNo.Text == "" && ForeignUniqueNo.Text == "" && Foreign.Value == false)
                {
                    UniqueRefNo.ReadOnly = false;
                    ForeignUniqueNo.ReadOnly = false;
                    Foreign.ReadOnly = false;
                }

                else if (UniqueRefNo.Text != "")
                {
                    UniqueRefNo.ReadOnly = true;
                    ForeignUniqueNo.ReadOnly = true;
                    Foreign.ReadOnly = true;
                    Foreign.Value = false;

                }
                else if (ForeignUniqueNo.Text != "")
                {
                    ForeignUniqueNo.ReadOnly = true;
                    Foreign.Value = true;
                    Foreign.ReadOnly = true;
                    UniqueRefNo.ReadOnly = true;
                }
            }
            else
            {
                ForeignUniqueNo.ReadOnly = false;
                Foreign.ReadOnly = false;
                UniqueRefNo.ReadOnly = false;
            }
            
                 
            if(this._Patient.Privacy.HasValue == false || this._Patient.IsPatientPrivacy == false)
                this._Patient.Privacy = false;

            if(Common.CurrentUser.HasRole(Common.TibbiKayitMemuruRoleID))
            {
                tabpagePrivacy.Visible = true;
                tabpagePrivacy.ReadOnly = false;
            }
            else if(this._Patient.IsPatientPrivacy == true)
            {
                tabpagePrivacy.Visible = true;
                tabpagePrivacy.ReadOnly = true;
            }
            else
                tabpagePrivacy.Visible = false;
            
            if((this.Privacy.Value == true && Common.CurrentUser.HasRole(Common.IzoleHastaKayitRoleID)) ||this.Privacy.Value == false)
            {
                Privacy.ReadOnly = false;
                RumuzAd.ReadOnly = false;
                RumuzSoyad.ReadOnly = false;
                PrivacyEndDate.ReadOnly = false;
                PrivacyReason.ReadOnly = false;
            }
            else if(this.Privacy.Value == true && !Common.CurrentUser.HasRole(Common.IzoleHastaKayitRoleID))
            {
                Privacy.ReadOnly = true;
                RumuzAd.ReadOnly = true;
                RumuzSoyad.ReadOnly = true;
                PrivacyEndDate.ReadOnly = true;
                PrivacyReason.ReadOnly = true;
            }
#endregion PatientForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PatientForm_PostScript
    bool isNewPatient = (((ITTObject)this._Patient).IsNew);
            
            SetBirthDateIfFormatTrue();
            if(this._Patient.UniqueRefNo != null)
            {
                if (!(this._Patient.UniqueRefNo == null))
                    CheckIfPatientExists();
                CheckRequiredProperties();
            }
            this._Patient.Update();
            if (isNewPatient || this.Owner is PatientForm)
            {
                AskAndFireNewPatientAdmission(this._Patient, true);
            }
            
             
            if(this._Patient.UnIdentified ==  true || this._Patient.Foreign == true)
                this._Patient.IsTrusted = true;
            
            ControlPrivacyPatientInfo(this._Patient.Privacy);
#endregion PatientForm_PostScript

            }
            
#region PatientForm_Methods
        public void CheckRequiredProperties()
        {
            Patient.IsAllRequiredPropertiesExists(true,this._Patient);
        }

        /// <summary>
        /// Hasta aramada Kullanılacak SQL sorgusunu oluşturur
        /// </summary>
        /// <returns>string olarak SQL sorgusu</returns>
        public string GetFilterExpressionOfPatientSearch()
        {
            string filterExpression = null;
            string opr = null;
            string injection = null;
            bool criteriaEntered = false;

            TTObjectContext objectContext = new TTObjectContext(true);
            //TC Kimlik No
            if (UniqueRefNo.Text.Length > 0 && Common.IsNumeric(UniqueRefNo.Text))
            {
                criteriaEntered = true;
                if (filterExpression != null)
                {
                    filterExpression += " AND ";
                }
                filterExpression += "(UNIQUEREFNO = " + UniqueRefNo.Text.ToString() + " )";
                return filterExpression;
            }

            //Kimlik/Sigorta No (Yabancı Hastalar)
            if (ForeignUniqueNo.Text.Length > 0 && Common.IsNumeric(ForeignUniqueNo.Text))
            {
                criteriaEntered = true;
                if (filterExpression != null)
                {
                    filterExpression += " AND ";
                }
                filterExpression += "(FOREIGNUNIQUEREFNO = " + ForeignUniqueNo.Text.ToString() + " )";
                return filterExpression;
            }

            //UnIdentified
            if (UnIdentified.ControlValue != null)
            {
                criteriaEntered = true;
                if (Convert.ToBoolean(UnIdentified.ControlValue))
                {
                    filterExpression = "(1=0)"; //Acilde kimliği bilinmeyen hasta kabul edilmek istendiğinde yavaşlığa sebep olduğu için 1=0 döndürüldü.
                    return filterExpression;
                }
            }

            Name.Text = Name.Text.Trim();
            Surname.Text = Surname.Text.Trim();
            if (Name.Text.Length > 0 && Surname.Text.Length > 0)
            {
                List<Guid> MatchedIDs = new List<Guid>();
                ArrayList NameTokens = new ArrayList();
                NameTokens = Common.Tokenize(searchString, true);

                if (NameTokens.Count > 1)
                {
                    for (int i = 0; i <= NameTokens.Count - 1; i++)
                    {
                        string s = NameTokens[i].ToString();

                        if (i > 0)
                        {
                            injection += " OR (";
                            if (s.IndexOf('%') != -1 && (TTObjectClasses.SystemParameter.GetParameterValue("PatientSearchWithAmpersand", "False").ToUpper() == "TRUE"))
                                opr = "LIKE";
                            else
                                opr = "=";
                            injection += "TOKEN " + opr + " '" + s + "' ";
                            if (i == NameTokens.Count - 1)
                                injection += "AND TOKENTYPE = 1)";
                            else
                                injection += "AND TOKENTYPE = 0)";
                        }
                        else
                        {
                            injection += " AND ((";
                            if (s.IndexOf('%') != -1)
                                opr = "LIKE";
                            else
                                opr = "=";
                            injection += "TOKEN " + opr + " '" + s + "' ";
                            injection += "AND TOKENTYPE = 0)";
                        }
                    }
                    injection += ") GROUP BY PATIENT HAVING Count(*) >= " + NameTokens.Count.ToString();

                    if (injection != null)
                    {
                        BindingList<PatientToken.GetPatientByInjection_Class> tokenList = PatientToken.GetPatientByInjection(injection);
                        foreach (PatientToken.GetPatientByInjection_Class t in tokenList)
                        {
                            MatchedIDs.Add(t.Patient.Value);
                        }
                        if (MatchedIDs.Count > 0)
                        {
                            filterExpression = CreateFilterExpressionOfGuidList(filterExpression, MatchedIDs);
                        }
                    }
                }
            }

            if (filterExpression != null)
            {
                //Baba Adı
                if (FatherName.Text.Length > 0)
                {
                    criteriaEntered = true;
                    if (filterExpression != null)
                    {
                        filterExpression += " AND ";
                    }
                    if (FatherName.Text.ToString().IndexOf('%') != -1)
                        filterExpression += "(FATHERNAME LIKE '" + FatherName.Text + "%')";
                    else
                        filterExpression += "(FATHERNAME = '" + FatherName.Text + "')";
                }


                if (BirthDate.ControlValue != null && BirthDate.ControlValue.ToString().Trim() != ".  ." && BirthDate.ControlValue.ToString().Trim() != "")
                {
                    criteriaEntered = true;
                    //string firstDate = "01.01." + (Convert.ToDateTime(GetBirthDate()).Date).ToString("yyyy") + " 00:00:00";
                    //string lastDate = "31.12." + (Convert.ToDateTime(GetBirthDate()).Date).ToString("yyyy") + " 23:59:59";

                    ////                    string filter = "(BIRTHDATE >= '" + (Convert.ToDateTime(firstDate).Date).ToString("yyyy-MM-dd HH:mm") + "' AND";
                    ////                    filter += " BIRTHDATE <= '" + (Convert.ToDateTime(lastDate).Date).ToString("yyyy-MM-dd HH:mm") + "')";
                    //string filter = "(BIRTHDATE >= TODATE('" + (Convert.ToDateTime(firstDate).Date).ToString("yyyy-MM-dd HH:mm") + "') AND";
                    //filter += " BIRTHDATE <= TODATE('" + (Convert.ToDateTime(lastDate).Date).ToString("yyyy-MM-dd HH:mm") + "'))";
                    //if (filterExpression == null)
                    //    filterExpression = "(" + filter + ")";
                    //else
                    //    filterExpression += " AND (" + filter + ")";
                }

                //Ülke
                if (CountryOfBirth.SelectedObjectID != null)
                {
                    criteriaEntered = true;
                    string filter = "(COUNTRYOFBIRTH = '" + CountryOfBirth.SelectedObjectID.ToString() + "')";
                    if (filterExpression == null)
                        filterExpression = "(" + filter + ")";
                    else
                        filterExpression += " AND (" + filter + ")";
                }

                //İl
                if (CityOfBirth.SelectedObjectID != null)
                {
                    criteriaEntered = true;
                    string filter = "(CITYOFBIRTH = '" + CityOfBirth.SelectedObjectID.ToString() + "')";
                    if (filterExpression == null)
                        filterExpression = "(" + filter + ")";
                    else
                        filterExpression += " AND (" + filter + ")";
                }

            }

            if (filterExpression == null)
                filterExpression = "1=0";

            return filterExpression;
        }


        private string searchString = "";
        public string SearchString
        {
            get
            {
                return searchString;
            }
        }

        /// <summary>
        ///  Hasta aramada kullanılacak searchString SQL sorgusunu oluşturur.
        /// </summary>
        public void SetSearchString()
        {
            searchString = "";
            if (UniqueRefNo.Text.Length > 0 && Common.IsNumeric(UniqueRefNo.Text))
            {
                searchString = UniqueRefNo.Text.ToString();
            }
            else if (ForeignUniqueNo.Text.Length > 0 && Common.IsNumeric(ForeignUniqueNo.Text))//Kimlik/Sigorta No (Yabancı Hastalar)
            {
                searchString = ForeignUniqueNo.Text.ToString();
            }
            else
            {
                if (Name.Text.Length > 0)
                    searchString += Name.Text.ToString() + " ";
                if (Surname.Text.Length > 0)
                    searchString += Surname.Text.ToString();
            }
        }
        /// <summary>
        /// Verilen SQL parçasınına uygun Hastayı bulur(seçtirir).
        /// </summary>
        /// <param name="form">Methodun çağırıldığı Form</param>
        /// <param name="searchString">SQL parçası</param>
        /// <returns></returns>

        /// <summary>
        /// searchString 'i kullanarak Hasta Arama yapar
        /// </summary>
        /// <returns></returns>
        public Patient SearchIfPatientExists()
        {
            SetSearchString();
            return PatientAdmission.GetPatientBySearch( SearchString);
        }
        /// <summary>
        /// searchString 'i kullanarak Hastanın olup olmadığını kontrol eder
        /// </summary>
        public void CheckIfPatientExists()
        {
            SetSearchString();
            string filter = " Where " + GetFilterExpressionOfPatientSearch();// Where ?imdilik konuldu Coredaki problem geçene kadar
            BindingList<Patient.GetPatientByInjection_Class> patientList = Patient.GetPatientByInjection(filter);
            int count = 1;
            if (((ITTObject)this._Patient).IsNew)
            {

                count = 0;

            }
            if (patientList.Count > count)
            {
                if (this.ForeignUniqueNo.Text.Length > 0)
                {
                    string[] hataParamList = new string[] { ForeignUniqueNo.Text };
                    String message = SystemMessage.GetMessageV3(102, hataParamList);
                    throw new TTUtils.TTException(message);
                    //throw new Exception(ForeignUniqueNo.Text + " Kimlik/Sigorta nolu hasta zaten mevcuttur.\n Hastanın Kimlik/Sigorta Nosunu kontrol ediniz.");
                }
                else if (this.UniqueRefNo.Text.Length > 0)
                {
                    string[] hataParamList = new string[] { UniqueRefNo.Text };
                    String message = SystemMessage.GetMessageV3(103, hataParamList);
                    throw new TTUtils.TTException(message);
                    //throw new Exception(UniqueRefNo.Text + " T.C. Kimlik nolu hasta zaten mevcuttur.\n Hastanın  T.C. Kimlik Nosunu kontrol ediniz.");
                }
                else
                {
                    if (this.UnIdentified.Value != true)
                    {
                        String message = SystemMessage.GetMessage(104);
                        throw new TTUtils.TTException(message);
                        //throw new Exception("Bu bilgilere sahip hasta zaten mevcuttur.\n Hastanın  kimlik bilgilerini kontrol ediniz.");
                    }
                }

            }

        }
        /// <summary>
        /// F11 ile Hasta Arama
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.F11:
                    btnSearch_Click(this, EventArgs.Empty);
                    break;
            }
        }

        //private Button btnSearch;
        public void DrawSearchButton()
        {
           // this.AddManualStepButton("Ara [F11]", new EventHandler(btnSearch_Click));
        }

        
        /// <summary>
        /// Doğum Günü Formatını kontrol eder
        /// </summary>
        private void SetBirthDateIfFormatTrue()
        {
            if (this.BirthDate != null && this.BirthDate.Text.Trim() != ".  ." && this.BirthDate.Text.Trim() != "")
            {
                try
                {
                  //  this._Patient.BirthDate = GetBirthDate();
                }
                catch (Exception ex)
                {
                    String message = SystemMessage.GetMessage(109);
                    throw new TTUtils.TTException(message);
                    //throw new Exception("Geçersiz doğum tarihi girdiniz.");
                }
            }
        }
        /// <summary>
        /// Doğum gününü düzenler
        /// </summary>
        /// <returns></returns>


        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            //SITEID ye bagli olarak kontrol yapilmis, istenirse sistem parametresine bagli olarak PACS a patient bilgisi gonderilebilir.
            Patient.SendPatientToPACS(this._Patient);
        }
        private string CreateFilterExpressionOfGuidList(string filterExpression, List<Guid> guidList)
        {
            List<StringBuilder> criteriaList = new List<StringBuilder>();
            StringBuilder sbObjIDs = new StringBuilder();
            int i = 0;
            foreach (Guid ID in guidList)
            {
                i++;
                if (sbObjIDs.Length > 0)
                    sbObjIDs.Append(',');
                sbObjIDs.Append(ConnectionManager.GuidToString(ID));
                if (i == 1000)
                {
                    i = 0;
                    criteriaList.Add(sbObjIDs);
                    sbObjIDs = new StringBuilder();
                }
            }
            if (i > 0 && i < 1000)
                criteriaList.Add(sbObjIDs);

            if (filterExpression != null)
                filterExpression += " AND ";

            i = 1;
            foreach (StringBuilder ids in criteriaList)
            {
                if (i == 1)
                    filterExpression += "(";

                filterExpression += "OBJECTID IN (" + ids + ")";

                if (i < criteriaList.Count)
                    filterExpression += " OR ";
                if (i == criteriaList.Count)
                    filterExpression += ")";
                i++;
            }
            return filterExpression;
        }
        public void CoverPatientInformation(bool? isPrivacy)
        {
            Patient.CoverPatientInformation(isPrivacy,_Patient);
            
        }
        public void ControlPrivacyPatientInfo(bool? isPrivacy)
        {
            if (((TTVisual.TTCheckBox)(Privacy)).Checked)
            {
                if(this.PrivacyEndDate == null)
                    throw new Exception("Gizli hastalarda Gizlilik Geçerlilik Tarihi dolu ve bugünün tarihinden sonra olmalıdır!");
                else if (Convert.ToDateTime(this.PrivacyEndDate.ControlValue).Date <= Common.RecTime().Date)
                    throw new Exception("Gizli hastalarda Gizlilik Geçerlilik Tarihi dolu ve bugünün tarihinden sonra olmalıdır!");

                /*if(this.PrivacyReason.ControlValue ==null)
                    throw new Exception("Gizli hastalarda Gizlilik Sebebi alanı dolu olmalıdır!");*/
                //if(this._Patient.Privacy.HasValue == false || this._Patient.IsPatientPrivacy == false)
                //if(this._Patient.Privacy == null)
                if(this._Patient.PrivacyPatient == null)
                {
                    //Patient Objesi PrivacyPatient objesine set edilecek
             
                    PrivacyPatient pPatient = new PrivacyPatient(this._Patient.ObjectContext);
                    pPatient.Email = _Patient.EMail;
                    pPatient.FatherName = _Patient.FatherName;
                    pPatient.HomeAddress = _Patient.PatientAddress.HomeAddress;
                    pPatient.HomePhone = _Patient.PatientAddress.HomePhone;
                    pPatient.MobilePhone = _Patient.PatientAddress.MobilePhone;
                    pPatient.MotherName = _Patient.MotherName;
                    pPatient.Name = _Patient.Name;
                    pPatient.Photo = _Patient.Photo;
                    pPatient.Surname = _Patient.Surname;
                    pPatient.UniqueRefNo = _Patient.UniqueRefNo;
                    pPatient.ForeignUniqueRefNo = _Patient.ForeignUniqueRefNo;
                    pPatient.YUPASSNO = _Patient.YUPASSNO;
                    //pPatient.PrivacyCityOfBirth = _Patient.CityOfBirth;
                   // pPatient.PrivacyCityOfRegistry = _Patient.CityOfRegistry;
                  //  pPatient.PrivacyCountryOfBirth = _Patient.CountryOfBirth;
                    pPatient.PrivacyTownOfBirth = _Patient.TownOfBirth;
                    pPatient.PrivacyTownOfRegistry = _Patient.TownOfRegistry;
                    pPatient.PrivacyHomeCity = _Patient.PatientAddress.HomeCity;
                    pPatient.PrivacyHomeCountry = _Patient.PatientAddress.HomeCountry;
                    //pPatient.PrivacyHomeTown = _Patient.PatientAddress.HomeTown;

                    _Patient.PrivacyPatient = pPatient;
                    
                    //Patient objesindeki belirlenmiş alanlar kriptolanacak
                    _Patient.EMail = "********";
                    _Patient.FatherName = "********";
                    _Patient.PatientAddress.HomeAddress = "********";
                    _Patient.PatientAddress.HomePhone = "********";
                    _Patient.PatientAddress.MobilePhone = "********";
                    _Patient.MotherName = "********";
                    _Patient.Name = "********";
                    _Patient.Photo = "********";
                    _Patient.Surname = "********";
                    _Patient.UniqueRefNo = null;
                    _Patient.ForeignUniqueRefNo = null;
                    _Patient.YUPASSNO = null;
                    _Patient.CityOfBirth = null;
                    _Patient.CityOfRegistry = null;
                    _Patient.CountryOfBirth = null;
                    _Patient.TownOfBirth = null;
                    _Patient.TownOfRegistry = null;
                    _Patient.PatientAddress.HomeCity = null;
                    _Patient.PatientAddress.HomeCountry = null;
                    _Patient.PatientAddress.HomeTown = null;

                    UniqueRefNo.Text = "********";
                    if(_Patient.Foreign == true)
                    {
                        YupasNo.Text = "*******";
                        ForeignUniqueNo.Text = "********";
                    }
                    Patient.CoverPatientInformation(true, _Patient);
                 
                    
                }
            }
            else if((!((TTVisual.TTCheckBox)(Privacy)).Checked && this._Patient.Privacy == true) && TTUser.CurrentUser.HasRole(TTObjectClasses.Common.IzoleHastaKayitRoleID))//Hastanın gizliliği kaldırılırsa Patient bilgileri geri set edilmeli
            {
       
                PrivacyPatient pPatient = this._Patient.PrivacyPatient;
                _Patient.EMail = pPatient.Email;
                _Patient.FatherName = pPatient.FatherName;
                _Patient.PatientAddress.HomeAddress = pPatient.HomeAddress;
                _Patient.PatientAddress.HomePhone = pPatient.HomePhone;
                _Patient.PatientAddress.MobilePhone = pPatient.MobilePhone;
                _Patient.MotherName = pPatient.MotherName;
                _Patient.Name = pPatient.Name;
                _Patient.Photo = pPatient.Photo;
                _Patient.Surname = pPatient.Surname;
                _Patient.UniqueRefNo = pPatient.UniqueRefNo;
                _Patient.ForeignUniqueRefNo = pPatient.ForeignUniqueRefNo;
                _Patient.YUPASSNO = pPatient.YUPASSNO;
                //_Patient.CityOfBirth = pPatient.PrivacyCityOfBirth;
                //_Patient.CityOfRegistry = pPatient.PrivacyCityOfRegistry;
                //_Patient.CountryOfBirth = pPatient.PrivacyCountryOfBirth;
                _Patient.TownOfBirth = pPatient.PrivacyTownOfBirth;
                _Patient.TownOfRegistry = pPatient.PrivacyTownOfRegistry;
                _Patient.PatientAddress.HomeCity = pPatient.PrivacyHomeCity;
                _Patient.PatientAddress.HomeCountry = pPatient.PrivacyHomeCountry;
               // _Patient.PatientAddress.HomeTown = pPatient.PrivacyHomeTown;
                                
                Patient.CoverPatientInformation(false, _Patient);
                _Patient.PrivacyPatient= null;
                
            }
        }
        
#endregion PatientForm_Methods

#region PatientForm_ClientSideMethods

        /// <summary>
        /// Kullanıcının Hasta Grubu seçmesini sağlar.
        /// </summary>
        /// <param name="patient">Hasta grubu seçilecek hasta</param>
        /// <returns>Kullanıcı tarafından seçilen hasta grubunun TTObjectDefi</returns>
        public static TTObjectDef SelectPatientAdmissionObjectDef(Patient patient, bool firstTime)
        {
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            if (patient.UnIdentified == true)//kimliği bilinmeyen hastalar için direk Acil dönmeli
                return TTObjectDefManager.Instance.ObjectDefs["PA_Emergency"];

            bool UseMainPatientGroup = false;
            if(Common.GetUserOptionValue(readOnlyContext, Common.CurrentResource, UserOptionType.UseMainPatientGroup) != null)
                UseMainPatientGroup = Common.GetUserOptionValue(readOnlyContext, Common.CurrentResource, UserOptionType.UseMainPatientGroup).ToString().Trim() == "1";
            
            bool AdmitAllPatientGroup = Patient.IsAdmittingAllPatientGroupFromSiteAllowed();//MPVT kullanılmayacak
            bool isEmergencyUser = Common.CurrentResource.IsEmergencyUser;
            bool isMedulaPatient = patient.HasValidMedulaHastaKabul();
            bool isMedulaIntegration = TTObjectClasses.SystemParameter.IsMedulaIntegration;
            int isForeignPatient = patient.Foreign == null ? 0 : Convert.ToInt32(patient.Foreign.Value);
            string hata = "";
            PatientGroupDefinition lastPatientGroupDef = null;

           /* if (patient.PatientGroup != null && firstTime == true)
                lastPatientGroupDef = Common.PatientGroupDefinitionByEnum(readOnlyContext, patient.PatientGroup.Value);
            */
            IList MainPatientGroupList = null;
            IList patientGroupList = null;
            // Ana group Seçme
            bool selectMain = true;
            if (UseMainPatientGroup)
            {
                if (MainPatientGroupList == null || MainPatientGroupList.Count == 0)// mpvtden hasta grubu ve ana hasta grubu boş olarak gelirse XXXXXXden kaydedilmiş gibi davranır
                    MainPatientGroupList = MainPatientGroupDefinition.GetActiveMainPatientGroups(readOnlyContext, AdmitAllPatientGroup, isEmergencyUser, isMedulaIntegration, isForeignPatient);
                if (MainPatientGroupList.Count == 0)
                    UseMainPatientGroup = false;
            }
            while (selectMain)// grup seçerken vazgeçe basarsa ana grubun tekrar açılması için
            {
                if ((!UseMainPatientGroup) || MainPatientGroupList.Count == 1)
                    selectMain = false;// ana group kullanılmayacaksa  yada tek ana grup varsa vazgeçe  bastığında direk çıkmalı

                //Ana grup seçimi
                if (UseMainPatientGroup)
                {
                    MultiSelectForm MainMSItem = new MultiSelectForm();
                    foreach (MainPatientGroupDefinition mainPatientGroup in MainPatientGroupList)
                        MainMSItem.AddMSItem(mainPatientGroup.OrderNo + "-" + mainPatientGroup.Name, mainPatientGroup.ObjectID.ToString(), (object)mainPatientGroup);
                    MainMSItem.AccessType = ListPropertyDefAccessEnum.PartialFull;
                    String mainkey = MainMSItem.GetMSItem(null, "Ana Hasta Grubu Seçiniz", true, true, false, false, false, false);
                    if (string.IsNullOrEmpty(mainkey))
                        return null;
                    else
                        patientGroupList = ((MainPatientGroupDefinition)MainMSItem.MSSelectedItemObject).PatientGroups;
                }
                else
                {
                    patientGroupList = PatientGroupDefinition.GetActivePatientGroups(readOnlyContext, AdmitAllPatientGroup, isEmergencyUser, isMedulaIntegration, isForeignPatient);
                }
                //Alt Grup seçme
                
                
                MultiSelectForm MSItem = new MultiSelectForm();
                if (patientGroupList == null)
                    return null;
                
                foreach (PatientGroupDefinition patientGroup in patientGroupList)
                {
                    if (!(MSItem.IsItemExists(patientGroup.ObjectID.ToString())))
                    {
                        int foreignUsage = (int)(patientGroup.ForeignUsage == null ? PatientGroupForeignUsageEnum.Both : patientGroup.ForeignUsage.Value);
                        if (((!isMedulaIntegration) /*|| isMedulaPatient == patientGroup.RequiredMedulaProvision*/) && isForeignPatient != foreignUsage)
                            MSItem.AddMSItem(patientGroup.OrderNo + "-" + Common.GetEnumValueDefOfEnumValue(patientGroup.PatientGroupEnum.Value).DisplayText, patientGroup.ObjectID.ToString(), (object)patientGroup);
                    }
                }
                
                MSItem.AccessType = ListPropertyDefAccessEnum.PartialFull;
                String key = MSItem.GetMSItem(null, "Hasta Grubu Seçiniz", true, true, false, false, false, false);
                if (!string.IsNullOrEmpty(key))
                {
                    PatientGroupDefinition selectedPGD = (PatientGroupDefinition)MSItem.MSSelectedItemObject;
                    return TTObjectDefManager.Instance.ObjectDefs["PatientAdmission"];
                }
            }
            return null;
        }
        private static void FiredNewAdmission_ObjectUpdated(TTObject ttObject, ref bool contextSaved)
        {
            ttObject.ObjectContext.Save();
            contextSaved = true;
        }
        
        void btnSearch_Click(object sender, EventArgs e)
        {
            SetBirthDateIfFormatTrue();
            Patient patient = null;
            patient = SearchIfPatientExists();
            if (patient != null)
            {
              /*  this._Patient.ChangedPatient = patient;
                TTObjectContext objectContext = new TTObjectContext(false);
                Patient oldPatient = (Patient)objectContext.GetObject(patient.ObjectID, "PATIENT");
                oldPatient.MyAdmissionAppointment = this._Patient.MyAdmissionAppointment;//bu paremetre kafa Randevusundan yapılan kabuller için tutulmaktadır.
                this.Hide();
                bool saveOldPatient = false;
                bool updatePatient = TTUser.CurrentUser.HasRole(TTObjectClasses.Common.UpdatePatientInfoRoleID);
                if (updatePatient)
                {
                    if (Patient.IsAllRequiredPropertiesExists(false, this._Patient))//true ise eksik bilgi yoktur kullanıcının seçimine bırakılabilir değilse
                        updatePatient = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Hasta Kayıt Düzeltme", "Seçilen hastanın kimlik bilgilerini düzeltmek ister misiniz?") == "E";
                    else
                        InfoBox.Alert("Lütfen Hastanın Eksik Kimlik Bilgilerini Giriniz");
                }
                if (updatePatient)
                {
                    PatientForm frm = new PatientForm();
                    if (frm.ShowEdit(this, oldPatient) != DialogResult.Cancel)
                    {
                        saveOldPatient = true;
                    }
                }
                else
                {
                    saveOldPatient = true;
                    AskAndFireNewPatientAdmission(oldPatient, false);
                }
                if (saveOldPatient)
                {
                    objectContext.Save();
                    oldPatient.OpenPatientInfoForm = true;
                    this.OnObjectUpdated(oldPatient);
                    this.Close();
                    //throw new Exception("İşlem " + oldPatient.Name.ToString() + " " + oldPatient.Surname.ToString() + " için Tamamlandı" );
                }
                else
                {
                    this.Show();
                    objectContext.Dispose();
                    //throw new Exception("Seçilen " + oldPatient.Name.ToString() + " " + oldPatient.Surname.ToString() + " adlı hasta için işlemden vazgeçildi");
                }*/
            }
        }



        private PatientAdmission AskAndFireNewPatientAdmission(Patient patient, bool ChangeExceptionsEnabled)
        {
            PatientAdmission pa = null;
            if (ChangeExceptionsEnabled)
                this._Patient.ObjectContext.IsInvalidMemberValueExceptionsEnabled = true;// burada hata verirse ekrana doğru göstermesi için
            pa = PatientAdmissionForm.FireNewPatientAdmission(patient, null, null,this._Patient.MyAdmissionAppointment);
            if (ChangeExceptionsEnabled)
                this._Patient.ObjectContext.IsInvalidMemberValueExceptionsEnabled = false;
            return pa;
        }
        //////////////////////////////////////MODÜL YARDIMCI ARACLARI//////
        
        /////Hasta arşiv barkodu basma
        private void PrintPatientBarcode_Click()
        {
            Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
            cache.Add("VALUE", this._Patient.ObjectID);
            parameters.Add("TTOBJECTID", cache);
            
            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_OutPatientEtiquetteReport), false, 1, parameters);
            
        }
        
        /////Arşiv birleştirme
        private void ArsivBirlestir(Patient patient)
        {
            if (!Common.CurrentUser.IsSuperUser)
            {
                if (!Common.CurrentUser.HasRole(Common.MergePatientsRoleID))
                {
                    String message = SystemMessage.GetMessage(78);
                    throw new TTUtils.TTException(message);
                    //throw new Exception("Hasta dosyası birleştirme için yetkiniz yok.");
                }
            }
            //TODO BG
            
            /*if (this.patientGrid.SelectedRows.Count < 2)
            {
                String message = SystemMessage.GetMessage(79);
                throw new TTUtils.TTException(message);
                //throw new Exception("Hasta dosyası birleştirme için birden fazla hasta seçmelisiniz.");
            }*/

            if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Hasta Dosyası Birleştirme", "Seçilen hastaların dosyaları birleştirilecektir. \r\nDevam etmek istediğinize emin misiniz?") == "H")
            {
                String message = SystemMessage.GetMessage(80);
                throw new TTUtils.TTException(message);
                //throw new Exception("İşlemden vazgeçildi");
            }
            
            MergePatients(patient);
        }
        
        private void MergePatients(Patient patient)
        {
         //   Cursor current = Cursor.Current;
        //    Cursor.Current = Cursors.WaitCursor;
            TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePoint = objectContext.BeginSavePoint();
            try
            {
                MultiSelectForm MSItem = new MultiSelectForm();
                ArrayList selectedPatientList = new ArrayList();
                //TODO
                /*
                foreach (DataGridViewRow row in patientGrid.SelectedRows)
                {
                    selectedPatientList.Add(patient);
                    MSItem.AddMSItem(patient.ID.ToString() + " " + patient.Name + " " + patient.Surname, patient.ObjectID.ToString(), patient);
                }*/
                
                string key = MSItem.GetMSItem(this, "Kayıtların birleşeceği hastayı seçiniz.", false, true, false, false, false, false);
                if (!string.IsNullOrEmpty(key))
                {
                    bool merge = false;
                    Guid targetPatientObjectID = ((Patient)MSItem.MSSelectedItemObject).ObjectID;
                    Patient targetPatient = (Patient)objectContext.GetObject(targetPatientObjectID, "Patient");
                    if (targetPatient.MergedToPatient != null)
                    {
                        Patient mp = (Patient)objectContext.GetObject(targetPatient.MergedToPatient.ObjectID, "Patient");

                        string[] hataParamList = new string[] { "'" + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + "'", "'" + mp.ID.ToString() + " " + mp.Name + " " + mp.Surname + "'" };
                        String message = SystemMessage.GetMessageV3(81, hataParamList);
                        throw new TTUtils.TTException(message);

                    }
                    ArrayList sourcePatientEpisodes;
                    foreach (Patient sourcePatient in selectedPatientList)
                    {
                        if (sourcePatient.ObjectID != targetPatient.ObjectID)
                        {
                            if (sourcePatient.MergedToPatient != null)
                            {
                                Patient mp = (Patient)objectContext.GetObject(sourcePatient.MergedToPatient.ObjectID, "Patient");
                                string[] hataParamList = new string[] { "'" + sourcePatient.ID.ToString() + " " + sourcePatient.Name + " " + sourcePatient.Surname + "'", "'" + mp.ID.ToString() + " " + mp.Name + " " + mp.Surname + "'" };
                                String message = SystemMessage.GetMessageV3(81, hataParamList);
                                throw new TTUtils.TTException(message);
                            }

                            //--
                            string differentProperties = "";
                            string ignoredPrpoerties = ",EHR,ImportantMedicalInformation,InpatientEpisode,MergedToPatient,PatientFolder,Service,";
                            foreach (TTObjectPropertyDef propDef in sourcePatient.ObjectDef.AllPropertyDefs)
                            {
                                if (!(ignoredPrpoerties.Contains("," + propDef.CodeName.ToString() + ",")))
                                {
                                    System.Reflection.PropertyInfo propInfo = sourcePatient.GetType().GetProperty(propDef.CodeName.ToString());
                                    if (propInfo != null)
                                    {
                                        object sourcePatientPropertyObject = propInfo.GetValue(sourcePatient, null);
                                        object targetPatientPropertyObject = propInfo.GetValue(targetPatient, null);
                                        string sourcePatientPropertyValue = sourcePatientPropertyObject == null ? "" : sourcePatientPropertyObject.ToString().Trim();
                                        string targetPatientPropertyValue = targetPatientPropertyObject == null ? "" : targetPatientPropertyObject.ToString().Trim();
                                        if (sourcePatientPropertyValue != targetPatientPropertyValue)
                                        {
                                            string caption = propDef.Caption == null ? propDef.Description : propDef.Caption;
                                            if (String.IsNullOrEmpty(caption))
                                                caption = propDef.CodeName;
                                            differentProperties += " , " + caption;
                                        }
                                    }
                                }
                            }

                            foreach (TTObjectRelationDef relDef in sourcePatient.ObjectDef.AllParentRelationDefs)
                            {
                                if (!(ignoredPrpoerties.Contains("," + relDef.CodeName.ToString() + ",")))
                                {
                                    System.Reflection.PropertyInfo propInfo = sourcePatient.GetType().GetProperty(relDef.CodeName.ToString());
                                    if (propInfo != null)
                                    {
                                        object sourcePatientPropertyObject = propInfo.GetValue(sourcePatient, null);
                                        object targetPatientPropertyObject = propInfo.GetValue(targetPatient, null);
                                        string sourcePatientPropertyValue = sourcePatientPropertyObject == null ? "" : sourcePatientPropertyObject.ToString().Trim();
                                        string targetPatientPropertyValue = targetPatientPropertyObject == null ? "" : targetPatientPropertyObject.ToString().Trim();
                                        if (sourcePatientPropertyValue != targetPatientPropertyValue)
                                        {
                                            string caption = relDef.ParentCaption == null ? relDef.ParentName : relDef.ParentCaption;
                                            differentProperties += " , " + caption;
                                        }
                                    }
                                }
                            }
                            string result = "E";
                            if (!String.IsNullOrEmpty(differentProperties))
                            {
                                result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Birleştirilmek istenen hastalar farklıdır", sourcePatient.ID.ToString() + " " + sourcePatient.Name + " " + sourcePatient.Surname + " Hastasının " + differentProperties + " özellikleri " + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + " hastasından farklıdır.Devam etmek istediğinize emin misiniz?");
                            }
                            if (result == "E")
                            {
                                //--
                                merge = true;
                                sourcePatientEpisodes = new ArrayList();
                                foreach (Episode e in sourcePatient.Episodes)
                                {
                                    sourcePatientEpisodes.Add(e);
                                }
                                foreach (Episode e in sourcePatientEpisodes)
                                {
                                    e.OldPatient = e.Patient; //To save old patient for dismerge.
                                    e.Patient = targetPatient;
                                }
                                sourcePatient.MergedToPatient = targetPatient;
                                sourcePatient.UniqueRefNo = null;
                                sourcePatient.Note = "Hastanın dosyası, " + Common.RecTime().ToShortDateString() + " tarihinde " + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + " hastası ile birleştirilmiştir.";

                                /*Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                                if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid)
                                    SendMergeInfoToPACS(sourcePatient.ObjectID.ToString());*/
                            }
                            else
                            {
                                InfoBox.Alert(sourcePatient.ID.ToString() + " " + sourcePatient.Name + " " + sourcePatient.Surname + " Hastasının, " + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + " hastası ile birleştirilmesinden vazgeçildi.");
                            }
                        }
                    }
                    if (merge)
                    {
                        objectContext.Save();
                        InfoBox.Alert(SystemMessage.GetMessage(82));
                    }
                    //TODO BG task (28057) girildi
                    //OnSearch();
                }
                else
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(80));
                    //throw new Exception("İşlemden vazgeçildi");
                }

            }
            catch (Exception ex)
            {
                objectContext.RollbackSavePoint(savePoint);
                InfoBox.Alert(ex);
            }
            finally
            {
            //    Cursor.Current = current;
            }
        }
        
        /////Fotoğraf Çek
        ///İlgili klasörde hastanın TC Kimlik No ile aynı isimde bir fotoğraf dosyası varsa sağlık kurulu işleminin ve hastanın fotoğraf alanına set edilir
        private void AddPicture()
        {
            string folderPath = TTObjectClasses.SystemParameter.GetParameterValue("RRPHOTOFOLDERPATH", "");
            
            if (!string.IsNullOrEmpty(folderPath))
            {
                if (_Patient.UniqueRefNo != null)
                {
                    string uniqueRefNo = _Patient.UniqueRefNo.ToString();

                    //System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(folderPath);
                    //if (directory.Exists)
                    //{
                    //    System.IO.FileInfo[] photoFiles = directory.GetFiles(uniqueRefNo + ".jpg");
                    //    if (photoFiles.Length == 0)
                    //        photoFiles = directory.GetFiles(uniqueRefNo + ".jpeg");
                    //    if (photoFiles.Length == 0)
                    //        photoFiles = directory.GetFiles(uniqueRefNo + ".jpe");
                    //    if (photoFiles.Length == 0)
                    //        photoFiles = directory.GetFiles(uniqueRefNo + ".jfif");

                    //    if (photoFiles.Length > 0)
                    //    {
                    //        System.IO.FileInfo photoFile = photoFiles[0];
                    //        //this.Picture = Image.FromFile(photoFile.FullName);
                    //        _Patient.Photo = Image.FromFile(photoFile.FullName);
                    //    }
                    //}
                }
            }
        }
        ///////////////////////////////////////////////////////////////////
        
#endregion PatientForm_ClientSideMethods
    }
}