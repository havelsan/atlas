
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
    public partial class PatientAdmissionForm : ActionForm
    {
        private string searchString = "";
        public string SearchString
        {
            get
            {
                return searchString;
            }
        }

        override protected void BindControlEvents()
        {
            btnSearchList.Click += new TTControlEventDelegate(btnSearchList_Click);
            btnSorgula.Click += new TTControlEventDelegate(btnSorgula_Click);           
            btnPatientAdmissionSave.Click += new TTControlEventDelegate(btnPatientAdmissionSave_Click);
            PatientlistView.DoubleClick += new TTControlEventDelegate(PatientlistView_DoubleClick);
            PatientHistoryListView.DoubleClick += new TTControlEventDelegate(PatientHistoryListView_DoubleClick);
            Building.SelectedObjectChanged += new TTControlEventDelegate(Building_SelectedObjectChanged);
            AdmissionType.SelectedIndexChanged += new TTControlEventDelegate(provizyonTipi_SelectedIndexChanged);
            DispatchType.SelectedIndexChanged += new TTControlEventDelegate(DispatchType_SelectedIndexChanged);
            bransKodu.SelectedObjectChanged += new TTControlEventDelegate(bransKodu_SelectedObjectChanged);
            HCRequestReason.SelectedObjectChanged += new TTControlEventDelegate(HCRequestReason_SelectedObjectChanged);
            tedaviTipi.SelectedIndexChanged += new TTControlEventDelegate(tedaviTipi_SelectedIndexChanged);
            btnClearPatientListPanel.Click += new TTControlEventDelegate(btnClearPatientListPanel_Click);
            base.BindControlEvents();
        }



        override protected void UnBindControlEvents()
        {
            btnSearchList.Click -= new TTControlEventDelegate(btnSearchList_Click);
            btnSorgula.Click -= new TTControlEventDelegate(btnSorgula_Click);
            btnPatientAdmissionSave.Click -= new TTControlEventDelegate(btnPatientAdmissionSave_Click);
            PatientlistView.DoubleClick -= new TTControlEventDelegate(PatientlistView_DoubleClick);
            PatientHistoryListView.DoubleClick -= new TTControlEventDelegate(PatientHistoryListView_DoubleClick);
            Building.SelectedObjectChanged -= new TTControlEventDelegate(Building_SelectedObjectChanged);
            AdmissionType.SelectedIndexChanged -= new TTControlEventDelegate(provizyonTipi_SelectedIndexChanged);
            DispatchType.SelectedIndexChanged -= new TTControlEventDelegate(DispatchType_SelectedIndexChanged);
            bransKodu.SelectedObjectChanged -= new TTControlEventDelegate(bransKodu_SelectedObjectChanged);
            HCRequestReason.SelectedObjectChanged -= new TTControlEventDelegate(HCRequestReason_SelectedObjectChanged);
            tedaviTipi.SelectedIndexChanged -= new TTControlEventDelegate(tedaviTipi_SelectedIndexChanged);
            btnClearPatientListPanel.Click -= new TTControlEventDelegate(btnClearPatientListPanel_Click);
            base.UnBindControlEvents();
        }
        private void btnDetailedSearch_Click()//Detaylı Arama
        {
            //TODO : Converterda sorun çıkardığı için şimdilik kapatıldı. BB
            //TTList _ttList = TTList.NewList("PatientSearchList", null);

            //IList list = _ttList.GetObjectListByExpression(GetFilterExpression());
            //lblNoPatientFound.Visible = true;
            //if (list.Count > 100)
            //{
            //    lblNoPatientFound.Text = "100'den fazla kayıt var. T.C. Kimlik No ile arama yapınız!";                
            //}
            //else
            //{
            //    lblNoPatientFound.Text = "Girdiğiniz kriterlere uygun sonuç bulunamadı!";
            //}
        }

        private void btnPatientAdmissionSave_Click()//Arşiv + Kabul Kaydı
        {
            try
            { 
                this.SetPatientDetailedInfo();
                this.SetAdmissionStatusAndType();

                PatientAdmission.SavePatientAdmission(this._PatientAdmission,1,false);
               
            }
            catch (Exception ex)
            {
                TTVisual.InfoBox.Show(this,"Hata",ex);
            }

}
        private void btnClearPatientListPanel_Click()
        {
            AllPatientAdmissions.Value = false;
            PoliclinicSearchList.SelectedValue = null;
            StartDate.Text = null;
            EndDate.Text = null;
        }

        private void PatientlistView_DoubleClick()
        {
            //this.LoadForm(PatientlistView.SelectedItems[1].Tag);
            string filterExpression = null;
            IBindingList historyPatientAdmission = null;
            IBindingList patientInfo = null;

            if (!String.IsNullOrEmpty(SearchPatient.Text))
            {
                IList patientSearchList = Patient.Search(PatientlistView.SelectedItems[0].Tag.ToString())?.FoundList;

                if (patientSearchList != null && patientSearchList.Count > 0)
                {
                    List<Guid> patientObjectIDs = new List<Guid>();

                    foreach (Patient patient in patientSearchList)
                    {
                        patientObjectIDs.Add(patient.ObjectID);
                    }
                    filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression, "PATIENT", patientObjectIDs);

                    //DEMOGRAFİK BİLGİLER
                    patientInfo = Patient.GetPatientIdentityAddress(filterExpression);
                    this.LoadIdentityInfo(patientInfo);

               
                    //TEDAVİ GEÇMİŞİ       
                   /* historyPatientAdmission = PatientAdmission.GetPatientAdmissionBySearchPatient(" WHERE " + filterExpression);
                    this.LoadPatientAdmissionHistory(historyPatientAdmission, this._PatientAdmission.Episode.Patient.ObjectID);*/




                }

            }
        }
        private void PatientHistoryListView_DoubleClick()
        {
            //KABUL BİLGİLERİ     
           // this.LoadForm(PatientHistoryListView.SelectedItems[0].SubItems[1].Tag);

            this.LoadRegistrationForm(PatientHistoryListView.SelectedItems[0].SubItems[0].Tag.ToString());

            //if (this.CheckUnpaidDebt())//Eğer hastanın borcu varsa,süreç engellenmeli - Acil kabuller hariç
            {
                //alert
                //Sadece acil birimler yüklenmeli
            }
        }
        private void btnSearchList_Click()
        {
            #region btnSearchList_Click

            PatientlistView.Items.Clear();

            IBindingList patientPatientAdmission = null;
            DateTime startDate = Convert.ToDateTime(Convert.ToDateTime(StartDate.Text).ToShortDateString() + " 00:00:00");
            DateTime endDate = Convert.ToDateTime(Convert.ToDateTime(EndDate.Text).ToShortDateString() + " 23:59:59");
            /*patientPatientAdmission = PatientAdmission.GetAllPatientAndPAInfosByDate(startDate, endDate);
  


            foreach (PatientAdmission.GetAllPatientAndPAInfosByDate_Class patientlist in patientPatientAdmission)
            {
                ITTListViewItem item = PatientlistView.Items.Add(patientlist.Fullname.ToString());
                item.SubItems.Add(patientlist.PatientAdmissionNumber);
                item.SubItems.Add(patientlist.ActionDate);
                item.SubItems.Add(patientlist.Payer);
                item.SubItems.Add(patientlist.ProvisionNo);
                item.SubItems.Add(patientlist.AdmissionStatus);
            }*/

            


            #endregion btnSearchList_Click
        }

        private void btnSorgula_Click()
        {
            #region btnSorgula_Click
            
            //string filterExpression = null;
            //IBindingList historyPatientAdmission = null;
            //IBindingList patientInfo = null;

            //if (!String.IsNullOrEmpty(SearchPatient.Text))
            //{
            //   // var lst = PatientAdmission.LoadPatientAdmission(SearchPatient.Text);          

            //   // this.__ttObject = lst[0];
            //    //this._PatientAdmission.PA_Address = (PatientIdentityAndAddress) lst[1];
            //    //this._PatientAdmission.SubEpisodeProtocol = (SubEpisodeProtocol)lst[3];
            //    //SubEpisode subEpisode = (SubEpisode)lst[2];
            ////   this._PatientAdmission.SubEpisodeProtocol.SubEpisode = subEpisode;
            ////    this.DoBindings(__ttObject);



            //    List<Guid> patientObjectIDs= new List<Guid>();//doldur
            //    this.LoadPatientAdmissionHistory(historyPatientAdmission, this._PatientAdmission.Episode.Patient.ObjectID);
            //    string admissionSpecOrResOfCurrentDayEpisodes = PatientAdmission.GetAdmissionSpecOrResOfCurrentDayEpisodes(this._PatientAdmission.Episode.Patient);
            //    if (admissionSpecOrResOfCurrentDayEpisodes != "")
            //    {
            //        string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Hastanın bugün " + admissionSpecOrResOfCurrentDayEpisodes + " kabulü yapılmıştır.Hasta Kabul işlemine devam etmek istiyormusunuz?");
            //        if (result == "H")
            //            throw new Exception(SystemMessage.GetMessage(695));
            //    }

            //    this.LoadAppointmentInfo();
            //    this.LoadIdentityInfo(patientInfo);
            //}

            #endregion btnSorgula_Click
        }


        private void Building_SelectedObjectChanged()
        {
            #region PatientAdmissionForm_Building_SelectedObjectChanged
            if (this.Building.SelectedObject != null)
            {
                string polObjectIDs = null;
                List<Guid> polObjectIDList = new List<Guid>();
                ResBuilding resBuilding = (ResBuilding)this.Building.SelectedObject;
                foreach (ResDepartment resDepartment in resBuilding.Departments)
                {
                    foreach (ResPoliclinic resPoliclinic in resDepartment.Policlinics)
                    {
                        polObjectIDList.Add(resPoliclinic.ObjectID);
                    }
                }
               // polObjectIDs = CommonHelper.CreateFilterExpressionO(polObjectIDs, " RESOURCESPECIALITIES(RESOURCE  ", polObjectIDList);
                this.Branch.ListFilterExpression = polObjectIDs + ".EXISTS) ";
            }
            #endregion PatientAdmissionForm_Building_SelectedObjectChanged
        }

        private void AdresBilgisisorgula_Click()
        {
            #region PatientAdmissionForm_AdresBilgisisorgula_Click
            try
            {
                if (_PatientAdmission.Episode.Patient.UniqueRefNo != null)
                {
                    KPSServis.KPSServisSonucuKisiAdresBilgisi response = KPSServis.WebMethods.TcKimlikNoIleAdresBilgisiSorgulaSync(Sites.SiteLocalHost, _PatientAdmission.Episode.Patient.UniqueRefNo.Value);

                    if (string.IsNullOrEmpty(response.Hata))
                    {
                        if (string.IsNullOrEmpty(response.Sonuc.Hata))
                        {

                            _PatientAdmission.PA_Address.SKRSBucakKodu.KODU = response.Sonuc.BucakKodu;
                            _PatientAdmission.PA_Address.SKRSBucakKodu.ADI = response.Sonuc.Csbm;
                            _PatientAdmission.PA_Address.DisKapi = response.Sonuc.DisKapiNo;
                            _PatientAdmission.PA_Address.IcKapi = response.Sonuc.IcKapiNo;

                            _PatientAdmission.PA_Address.SKRSAcikAdresIlce = response.Sonuc.Ilce;

                            BindingList<SKRSKoyKodlari> koyKodlari = SKRSKoyKodlari.GetSKRSKoyKodlariByKodu(_PatientAdmission.ObjectContext, Convert.ToInt32(response.Sonuc.KoyKodu));
                            if (koyKodlari.Count > 0)
                                _PatientAdmission.PA_Address.SKRSKoyKodlari = koyKodlari[0];
                            else
                                _PatientAdmission.PA_Address.SKRSKoyKodlari = new SKRSKoyKodlari();

                            BindingList<SKRSMahalleKodlari> mahalleKodlari = SKRSMahalleKodlari.GetSKRSMahalleKodlariByKodu(_PatientAdmission.ObjectContext, Convert.ToInt32(response.Sonuc.MahalleKodu));
                            if (mahalleKodlari.Count > 0)
                                _PatientAdmission.PA_Address.SKRSMahalleKodlari = mahalleKodlari[0];
                            else
                                _PatientAdmission.PA_Address.SKRSMahalleKodlari = new SKRSMahalleKodlari();

                            BindingList<SKRSILKodlari> ilKodlariList = SKRSILKodlari.GetSKRSIlKodlariByKodu(_PatientAdmission.ObjectContext, Convert.ToInt32(response.Sonuc.IlKodu));
                            if (ilKodlariList.Count > 0)
                                _PatientAdmission.PA_Address.SKRSILKodlari = ilKodlariList[0];
                            else
                                _PatientAdmission.PA_Address.SKRSILKodlari = new SKRSILKodlari();

                            BindingList<SKRSIlceKodlari> ilceKodlariList = SKRSIlceKodlari.GetSKRSIlceKodlariByKodu(_PatientAdmission.ObjectContext, Convert.ToInt32(response.Sonuc.IlceKodu));
                            if (ilceKodlariList.Count > 0)
                                _PatientAdmission.PA_Address.SKRSIlceKodlari = ilceKodlariList[0];
                            else
                                _PatientAdmission.PA_Address.SKRSIlceKodlari = new SKRSIlceKodlari();


                            _PatientAdmission.Episode.Patient.PatientAddress.SKRSAcikAdresIlce = response.Sonuc.Ilce;

                            var adresKodu = (response.Sonuc.IcKapiNo != null ? "8" : (response.Sonuc.Csbm != null ? "6" :
                                                                                      (response.Sonuc.MahalleKodu != null ? "5" : (response.Sonuc.KoyKodu != null ? "4" :
                                                                                                                                   (response.Sonuc.DisKapiNo != null ? "7" : (""))))));

                            _PatientAdmission.PA_Address.SKRSAdresKodu = adresKodu;
                            BindingList<SKRSAdresKoduSeviyesi> adreskoduSeviyesiList = SKRSAdresKoduSeviyesi.GetSKRSAdresKoduSByKodu(_PatientAdmission.ObjectContext, adresKodu);
                            if (adreskoduSeviyesiList.Count > 0)
                                _PatientAdmission.PA_Address.SKRSAdresKoduSeviyesi = adreskoduSeviyesiList[0];
                            else
                                _PatientAdmission.PA_Address.SKRSAdresKoduSeviyesi = new SKRSAdresKoduSeviyesi();

                            var acikAdres = "";

                            if (!string.IsNullOrEmpty(response.Sonuc.YabanciAdres))
                            {
                                acikAdres = response.Sonuc.YabanciAdres;
                            }
                            else
                            {
                                acikAdres = response.Sonuc.Mahalle + " " + response.Sonuc.BinaSiteAdi + " " + response.Sonuc.BinaBlokAdi + " " + response.Sonuc.Csbm + " Dış Kapı no : "
                                    + response.Sonuc.DisKapiNo + " İç Kapı no : " + response.Sonuc.IcKapiNo + " " + response.Sonuc.Ilce + " " + response.Sonuc.Il;

                                var sKRSUlkeKodlariList = SKRSUlkeKodlari.GetByMernisKodu(this._PatientAdmission.ObjectContext, "9980");
                                if (sKRSUlkeKodlariList.Count > 0)
                                {
                                    _PatientAdmission.Episode.Patient.Nationality = sKRSUlkeKodlariList[0];
                                }
                            }

                            _PatientAdmission.PA_Address.HomeAddress = acikAdres;

                            if (!string.IsNullOrEmpty(response.Sonuc.IlceKodu))
                            {
                                IBindingList townsOfRegistry = _PatientAdmission.ObjectContext.QueryObjects(typeof(TownDefinitions).Name, "MERNISCODE = " + response.Sonuc.IlceKodu);
                                if (townsOfRegistry.Count == 1)
                                {
                                    TownDefinitions townOfRegistry = (TownDefinitions)townsOfRegistry[0];
                                   // _PatientAdmission.PA_Address.HomeTown = townOfRegistry;
                                    if (townOfRegistry.City != null)
                                        _PatientAdmission.PA_Address.HomeCity = townOfRegistry.City;
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(response.Sonuc.IlKodu))
                                        {
                                            IBindingList homeCity = _PatientAdmission.ObjectContext.QueryObjects(typeof(City).Name, "MERNISCODE = " + response.Sonuc.IlKodu);
                                            if (homeCity.Count == 1)
                                                _PatientAdmission.PA_Address.HomeCity = (City)homeCity[0];
                                            else if (homeCity.Count == 0)
                                                InfoBox.Show("Bu MERNİS koduna sahip bir şehir tanımı bulunamadı.\r\n" + response.Sonuc.IlKodu);
                                            else
                                                InfoBox.Show("Bu MERNİS koduna sahip mükerrer şehir tanımları bulundu.\r\n" + response.Sonuc.IlKodu);
                                        }
                                    }
                                }
                                else if (townsOfRegistry.Count == 0)
                                    InfoBox.Show("Bu MERNİS koduna sahip bir ilçe tanımı bulunamadı.\r\n" + response.Sonuc.IlceKodu);
                                else
                                    InfoBox.Show("Bu MERNİS koduna sahip mükerrer ilçe tanımları bulundu.\r\n" + response.Sonuc.IlceKodu);
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
            catch (Exception ex)
            {
                throw new TTUtils.TTException(ex.Message);
            }
            #endregion PatientAdmissionForm_AdresBilgisisorgula_Click
        }

        private void BaseHomeCountry_SelectedObjectChanged()
        {
            #region PatientAdmissionForm_BaseHomeCountry_SelectedObjectChanged

            #endregion PatientAdmissionForm_BaseHomeCountry_SelectedObjectChanged
        }

        private void provizyonTipi_SelectedIndexChanged()
        {
            #region PatientAdmissionForm_provizyonTipi_SelectedIndexChanged
            if (this.AdmissionType.SelectedItem != null && this.AdmissionType.SelectedItem.Value != null && this.AdmissionType.SelectedItem.Value.Equals("T"))
            {
                this.plakaNo.Required = true;
            }
            else
                this.plakaNo.Required = false;
            #endregion PatientAdmissionForm_provizyonTipi_SelectedIndexChanged
        }

        private void DispatchType_SelectedIndexChanged()
        {
            #region PatientAdmissionForm_DispatchType_SelectedIndexChanged
            if (this._PatientAdmission.DispatchType == DispatchTypeEnum.Consultation)
            {
                labelDispatchedConsultationDef.Visible = true;
                labelDispatchedConsultationDef.Required = true;
                DispatchedConsultationDef.Visible = true;
                DispatchedConsultationDef.Required = true;

                //NE: tetkik İstem paneli ve tanı giriş paneli kapatılacak

                tetkikIstemPaneli.Visible = false;
                taniSecimPaneli.Visible = false;
            }
            else
            {
                labelDispatchedConsultationDef.Visible = false;
                labelDispatchedConsultationDef.Required = false;
                DispatchedConsultationDef.Visible = false;
                DispatchedConsultationDef.Required = false;

                //NE: tetkik İstem paneli ve tanı giriş paneli açılacak
                tetkikIstemPaneli.Visible = true;
                taniSecimPaneli.Visible = true;
            }
            #endregion PatientAdmissionForm_DispatchType_SelectedIndexChanged
        }


        private void bransKodu_SelectedObjectChanged()
        {
            #region PatientAdmissionForm_bransKodu_SelectedObjectChanged
            ///ne
            List<string> disBransKodlari = new List<string>();
            disBransKodlari.Add("5100");
            disBransKodlari.Add("5150");
            disBransKodlari.Add("5700");
            disBransKodlari.Add("5400");
            disBransKodlari.Add("5300");
            disBransKodlari.Add("5500");
            disBransKodlari.Add("5600");
            disBransKodlari.Add("5200");
            if ( _PatientAdmission.SEP != null && _PatientAdmission.SEP.Brans != null)
            {
                if (disBransKodlari.Contains(_PatientAdmission.SEP.Brans.Code) || _PatientAdmission.SEP.Brans.Code == "3200")
                {
                    if (_PatientAdmission.SEP.Brans.Code == "3200")   // radyasyon onkolojisi ise
                        this.tedaviTipi.ListFilterExpression = "TEDAVITIPIKODU IN (14)";
                    else
                        this.tedaviTipi.ListFilterExpression = "TEDAVITIPIKODU IN (13,20,9)";
                    ITTComboBoxItem seciliTedaviTipi = null;
                    if (this.tedaviTipi.SelectedItem != null)
                    {
                        BindingList<TedaviTipi.GetTedaviTipiNql_Class> getTedaviTipi = TedaviTipi.GetTedaviTipiNql();
                        foreach (TedaviTipi.GetTedaviTipiNql_Class item in getTedaviTipi)
                        {
                            if (_PatientAdmission.SEP.Brans.Code == "3200")
                            {
                                if (item.tedaviTipiKodu == "14")
                                {
                                    if (this.tedaviTipi.SelectedItem.Value.ToString() == item.ObjectID.ToString())
                                        seciliTedaviTipi = this.tedaviTipi.SelectedItem;
                                }
                            }
                            else if (item.tedaviTipiKodu == "13" || item.tedaviTipiKodu == "20" || item.tedaviTipiKodu == "9")
                            {
                                if (this.tedaviTipi.SelectedItem.Value.ToString() == item.ObjectID.ToString())
                                    seciliTedaviTipi = this.tedaviTipi.SelectedItem;
                            }
                        }
                    }
                    this.tedaviTipi.RefreshItems();
                    if (seciliTedaviTipi != null)
                    {
                        foreach (ITTComboBoxItem item in this.tedaviTipi.Items)
                        {
                            if (item.Value.ToString() == seciliTedaviTipi.Value.ToString())
                                this.tedaviTipi.SelectedItem = item;
                        }
                    }
                }
                else
                {
                    if (this.tedaviTipi.ListFilterExpression != null)
                    {
                        this.tedaviTipi.ListFilterExpression = null;
                        this.tedaviTipi.RefreshItems();
                    }
                }
            }
            else
            {
                if (this.tedaviTipi.ListFilterExpression != null)
                {
                    this.tedaviTipi.ListFilterExpression = null;
                    this.tedaviTipi.RefreshItems();
                }
            }

            ////////
            #endregion PatientAdmissionForm_bransKodu_SelectedObjectChanged
        }
        private void HCRequestReason_SelectedObjectChanged()
        {
            #region PatientAdmissionForm_HCRequestReason_SelectedObjectChanged

            if (_PatientAdmission.HCRequestReason != null && _PatientAdmission.HCRequestReason.ReasonForExamination != null && _PatientAdmission.HCRequestReason.ReasonForExamination.HospitalsUnits != null)
            {
                foreach (HospitalsUnitsDefinitionGrid hospitalsUnitsDef in _PatientAdmission.HCRequestReason.ReasonForExamination.HospitalsUnits)
                {
                    PatientAdmissionResourcesToBeReferred patientAdmissionResourcesToBeReferred = new PatientAdmissionResourcesToBeReferred(this._PatientAdmission.ObjectContext);
                    patientAdmissionResourcesToBeReferred.ProcedureDoctorToBeReferred = hospitalsUnitsDef.ProcedureDoctor;
                    patientAdmissionResourcesToBeReferred.Resource = hospitalsUnitsDef.Policklinic;
                    //patientAdmissionResourcesToBeReferred.Speciality = hospitalsUnitsDef.Speciality;
                    this._PatientAdmission.ResourcesToBeReferred.Add(patientAdmissionResourcesToBeReferred);
                }
            }

            #endregion PatientAdmissionForm_HCRequestReason_SelectedObjectChanged
        }


        private void tedaviTipi_SelectedIndexChanged()
        {
            #region PatientAdmissionForm_tedaviTipi_SelectedIndexChanged
            ////ne
            List<string> tedaviTipiList = new List<string>();
            tedaviTipiList.Add("13");
            tedaviTipiList.Add("20");
            tedaviTipiList.Add("9");

            List<string> disBransKodlari = new List<string>();
            disBransKodlari.Add("5100");
            disBransKodlari.Add("5150");
            disBransKodlari.Add("5700");
            disBransKodlari.Add("5400");
            disBransKodlari.Add("5300");
            disBransKodlari.Add("5500");
            disBransKodlari.Add("5600");
            disBransKodlari.Add("5200");
            /*
                        //tedavi tipi diş tedavisi, ortodontik tedavi, ağız protez tedavisi
                        if (_PatientAdmission.MedulaProvision.TedaviTipi != null)
                        {
                            if (tedaviTipiList.Contains(_PatientAdmission.MedulaProvision.TedaviTipi.tedaviTipiKodu))
                            {
                                ITTListView lvwRelatedResourceTumu = new TTListView();
                                lvwRelatedResourceTumu = lvwRelatedResource;
                                foreach (TTListViewItem item in ((ListView)lvwRelatedResource).Items)
                                {
                                    TTListViewItem q = new TTListViewItem();
                                    ResPoliclinic resPoliclinic = null;
                                    if ((item.SubItems[1]).Tag is ReasonForAdmissionRelatedResources)
                                    {
                                        if (((ReasonForAdmissionRelatedResources)(item.SubItems[1]).Tag).Resource is ResPoliclinic)
                                            resPoliclinic = (ResPoliclinic)((ReasonForAdmissionRelatedResources)(item.SubItems[1]).Tag).Resource;
                                    }
                                    else if ((item.SubItems[1]).Tag is ResPoliclinic)
                                        resPoliclinic = (ResPoliclinic)(item.SubItems[1]).Tag;

                                    if (resPoliclinic != null)
                                    {
                                        if (resPoliclinic.Brans != null)
                                        {
                                            if (!disBransKodlari.Contains(resPoliclinic.Brans.Code))//tedavi tipi dişle ilgili ise
                                            {
                                                item.Remove();
                                            }
                                        }
                                        else
                                            item.Remove();
                                    }
                                }
                            }
                            else
                            {
                                TTListViewItem selectedItem = null;
                                if (((ListView)this.lvwRelatedResource).SelectedItems.Count > 0)
                                {
                                    selectedItem = (TTListViewItem)((ListView)this.lvwRelatedResource).SelectedItems[0];
                                    if (selectedItem.Checked == false)
                                        this.FilllvwRelatedResourceByReasounForAdmission();
                                }
                                else
                                {
                                    int disKontrol = 0;
                                    foreach (TTListViewItem item in ((ListView)lvwRelatedResource).Items)
                                    {
                                        ResPoliclinic resPoliclinic = null;
                                        if ((item.SubItems[1]).Tag is ReasonForAdmissionRelatedResources)
                                        {
                                            if (((ReasonForAdmissionRelatedResources)(item.SubItems[1]).Tag).Resource is ResPoliclinic)
                                                resPoliclinic = (ResPoliclinic)((ReasonForAdmissionRelatedResources)(item.SubItems[1]).Tag).Resource;
                                        }
                                        else if ((item.SubItems[1]).Tag is ResPoliclinic)
                                            resPoliclinic = (ResPoliclinic)(item.SubItems[1]).Tag;

                                        if (resPoliclinic != null)
                                        {
                                            if (resPoliclinic.Brans != null)
                                            {
                                                if (!disBransKodlari.Contains(resPoliclinic.Brans.Code))
                                                {
                                                    disKontrol++;
                                                }
                                            }
                                            else
                                            {
                                                disKontrol++;
                                            }
                                        }
                                    }
                                    if (disKontrol == 0)
                                        this.FilllvwRelatedResourceByReasounForAdmission();
                                }
                            }
                        }*/
            //////
            #endregion PatientAdmissionForm_tedaviTipi_SelectedIndexChanged
        }

        protected override void PreScript()
        {
            #region PatientAdmissionForm_PreScript
            base.PreScript();

            #endregion PatientAdmissionForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region PatientAdmissionForm_PostScript
            base.PostScript(transDef);

          

            /*todo bg
            if (this._PatientAdmission.AdmissionType == AdmissionTypeEnum.NewBorn)
            {
                if (this._PatientAdmission.Episode.Patient.BDYearOnly == true)
                {
                    DateTime? birthDate = InputForm.GetDateTime("Yenidoğan kabulü için tarihi gg/aa/yyyy formatında giriniz.", Common.RecTime(), "dd/mm/yyyy", true);

                    if (birthDate != null)
                    {
                        this._PatientAdmission.Episode.Patient.BirthDate = birthDate;
                        if (Common.DateDiff(0, Convert.ToDateTime(birthDate), Common.RecTime(), true) >= 31)
                            throw new Exception(SystemMessage.GetMessage(704));
                    }
                }
            }*/


            /*todo bg
            if (transDef != null && transDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
            {
                CloneObjectBasedOnInitialObject();

            }*/

            //            /// NE (07.07.14) Kabul Sebebi Acil ise Öncelik Sebebinin acil olması sağlandı
            //            if (this._PatientAdmission.ReasonForAdmission.Type == AdmissionTypeEnum.Emergency)
            //                SetPCSSystemPriority(QueuePrioritySystemEnum.Emergency, true);

            ///NE (17.08.2015) sivil sevkli ve sivil emekli ise sevk belgesi için uyarı eklendi
            ///


       
            #endregion PatientAdmissionForm_PostScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region PatientAdmissionForm_ClientSidePostScript
            base.ClientSidePostScript(transDef);
            #endregion PatientAdmissionForm_ClientSidePostScript

        }

        #region PatientAdmissionForm_Methods
        private bool check = true;      


        public string FiredActionStatus(TTObject ob)
        {
            if (ob.CurrentStateDef != null)
            {
                if (ob.IsCancelled)
                {
                    return "İptal Edildi";
                }
                else if (ob.CurrentStateDef.IsEntry == true)
                {
                    return "Yeni";
                }
                else if (ob.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    return "Devam Ediyor";
                }
                else if (ob.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                {
                    return "Tamamlandı";
                }
                else if (ob.CurrentStateDef.Status == StateStatusEnum.CompletedUnsuccessfully)
                {
                    return "Başarısız Tamamlandı";
                }
                return "";
            }
            else
            {
                return "";
            }
        }


 



        protected override void OnUpdateError(Exception ex)
        {
            this._PatientAdmission.ResourcesToBeReferred.DeleteChildren();
        }

        protected void CheckPayerAndProtocol()
        {
            //if (_PatientAdmission is PA_CivilianConsignment || _PatientAdmission is PA_PrimeMinistry || _PatientAdmission is PA_TemporaryVillageSecurity || _PatientAdmission is PA_PatientWithGreenCard)
            //            if (_PatientAdmission is PA_CivilianConsignment)
            //            {
            //                if (this._PatientAdmission.Payer == null)
            //                    throw new Exception(SystemMessage.GetMessage(707));
            //                if (this._PatientAdmission.Protocol == null)
            //                    throw new Exception(SystemMessage.GetMessage(708));
            //            }
        }

        public String GetMedulaFilterOfReasonForAdmission()
        {
            String MedulaString = "";
            if (this._PatientAdmission.PatientMedulaHastaKabul != null)
            {
                if (this._PatientAdmission.PatientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO != null)
                {
                    if (this._PatientAdmission.PatientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.provizyonTipi != null)
                    {
                        //N : Normal
                        //I : İş kazası
                        //A : Acil
                        //T : Trafik kazası
                        //V : Adli Vaka
                        //M : Meslek hastalığı
                        switch (this._PatientAdmission.PatientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.provizyonTipi)
                        {
                            case "A":
                                MedulaString += (MedulaString == "" ? "" : ",") + "11";//Acil
                                break;
                            case "V":
                                MedulaString += (MedulaString == "" ? "" : ",") + "12,16,15";//12 Alkol - Darp Muayenesi -16 Adli Gözetim- 15 Tutuklu
                                break;

                        }
                    }

                    if (this._PatientAdmission.PatientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.provizyonTipi != null)
                    {
                        //0, "Normal Sorgu"
                        //1, "Diyaliz"
                        //2, "Fiziksel tedavi ve rehabilitasyon"
                        //4, "Kemik iliği"
                        //5, "Kök hücre nakli"
                        //6, "Ekstrakorporeal fotoferez tedavisi"
                        //7, "Hiperbarik oksijen tedavisi"
                        //8, "ESWL"
                        //9, "Ağız Protez tedavisi"
                        //10, "Ketem"
                        //11, "Tüp Bebek 1"
                        //12, "Tüp Bebek 2"
                        //13, "Diş Tedavisi"
                        //14, ?Onkolojik Tedavi?
                        //15, ?Plazmaferez Tedavisi?
                        //16, ?ESWT?
                        //donorTCKimlikNo Donörün TC Kimlik
                        //Numarası
                        //String 11 Hayır Alınmak istenen takip
                        switch (this._PatientAdmission.PatientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.tedaviTipi)
                        {
                            //Aşağıdaki tiplerde mutlaka muayen yapılıyor olmalı
                            case "1"://1, "Diyaliz"
                            case "2"://2, "Fiziksel tedavi ve rehabilitasyon"
                            case "7"://7, "Hiperbarik oksijen tedavisi"
                            case "8"://8, "ESWL"
                            case "9"://9, "Ağız Protez tedavisi"
                                MedulaString += (MedulaString == "" ? "" : ",") + "0";//Normal Muayene
                                break;

                        }
                    }
                }
            }
            return MedulaString;
        }

        private void ArrangeWarVeteraCardNo()
        {
            //            if (this.cbWarVetera.Value == true || this.DisabledWarvetera.Value == true)
            //            {
            //                this.tWarVeteraCardNo.ReadOnly = false;
            //                this.tWarVeteraCardNo.Required = true;
            //            }
            //            else
            //            {
            //                this.tWarVeteraCardNo.ReadOnly = true;
            //                this.tWarVeteraCardNo.Required = false;
            //                this.tWarVeteraCardNo.Text = "";
            //            }
        }

        protected bool deleteDEMOBILIZATIONTIME = true;//Terhis Tarihi	DEMOBILIZATIONTIME
        protected bool deleteCONSCRIPTIONPERIOD = true;//Tertip	CONSCRIPTIONPERIOD
        protected bool deleteMILITARYACCEPTANCETIME = true;//XXXXXXe Giriş Tarihi	MILITARYACCEPTANCETIME
        protected bool deleteEMPLOYMENTRECORDID = true;//Sicil No	EMPLOYMENTRECORDID
        protected bool deleteWARVETERA = true;//Gazi	WARVETERA
        protected bool deleteRETIREMENTFUNDID = true;//EmeklI Sandığı Sicil No	RETIREMENTFUNDID
        protected bool deleteHEALTSLIPNUMBER = true;//Sağlık Fişi No	HEALTSLIPNUMBER
        protected bool deleteMILITARYNO = true;//XXXXXXlik No	MILITARYNO

        protected bool deleteRANK = true;//Rütbe RANK
        protected bool deleteFORCESCOMMAND = true;//Kuvvet	FORCESCOMMAND
        protected bool deleteMILITARYUNIT = true;//Birlik	MILITARYUNIT
        protected bool deleteMILITARYCLASS = true;//XXXXXXlik Sınıfı	MILITARYCLASS
        protected bool deleteRELATIONSHIP = true;//Yakınlık Derecesi	RELATIONSHIP
        protected bool deleteMILITARYOFFICER = true;//XXXXXXlik Şubesi	MILITARYOFICCER
        protected bool deleteSENDERCHAIR = true;//Muayeneye Gönderen Makam	SENDERCHAIR

        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null && transDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
            {
                this.SendFiredLaboratoryActions();


                //ayaktan hasta etiketi basılsın mı basılacaksa kaç tane
                if (this._PatientAdmission.Episode.EpisodeActions.Count > 0)
                {
                    if (this._PatientAdmission.Episode.EpisodeActions[0].MasterResource.IsEtiquettePrinted == true)
                    {
                        if (this._PatientAdmission.Episode.EpisodeActions[0].MasterResource.EtiquetteCount != null)
                        {
                            for (int i = 0; i < this._PatientAdmission.Episode.EpisodeActions[0].MasterResource.EtiquetteCount; i++)
                            {
                                PrintOutPatientEtiquetteReport();
                            }
                        }
                    }
                }

            }

            //Sivil sevkli hasta'nın kurumu SGK değilse ve bu medula provizyon aynı tesisi kodlu başka bir XXXXXXden gönderilmedi ise  medula provizyon nesnesini siliyoruz.
            // MedulaProvizyon objesi artık kullanılmayacağı için kapatıldı (MDZ)
            //if (!Episode.IsMedulaEpisode(_PatientAdmission.Episode))
            //{
            //    if (_PatientAdmission.MedulaProvision != null)
            //    {
            //        TTObjectContext context = new TTObjectContext(false);
            //        MedulaProvision mp = (MedulaProvision)context.GetObject(_PatientAdmission.MedulaProvision.ObjectID, typeof(MedulaProvision).Name);
            //        //                    if (_PatientAdmission.IsFiresFromPACorrection != null)
            //        //                    {
            //        //                        if ((bool)_PatientAdmission.IsFiresFromPACorrection)
            //        //                            mp.CurrentStateDefID = MedulaProvision.States.Cancelled;
            //        //                        else
            //        //                        {
            //        PatientAdmission pa = (PatientAdmission)context.GetObject(_PatientAdmission.ObjectID, typeof(PatientAdmission).Name);
            //        pa.MedulaProvision = null;
            //        ((ITTObject)mp).Delete();
            //        //                        }
            //        context.Save();
            //        //                    }
            //    }
            //}
        }
        public void PrintOutPatientEtiquetteReport()
        {
            try
            {
                /*  Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                  TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                  objectID.Add("VALUE", this._PatientAdmission.ObjectID.ToString());
                  parameters.Add("TTOBJECTID", objectID);
                  TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_OutPatientEtiquetteReport), false, 1, parameters);*/
                var a = 1;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void SendFiredLaboratoryActions()
        {
            foreach (EpisodeAction ea in this._PatientAdmission.FiredEpisodeActions)
            {
                if (ea is LaboratoryRequest)
                {
                    //  Cursor current = Cursor.Current;
                    // Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        LaboratoryRequest labRequest = ea as LaboratoryRequest;
                        if (labRequest != null && labRequest.ID.Value.HasValue) //Action'ın ID'sinin boş olduğu zamanlar oluyor. Sebebi tespit edilmeli
                        {
                            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
                            if (sysparam == "TRUE")
                            {
                                if (labRequest.IsRequestSent != true)
                                {
                                    Guid messageID = LaboratoryRequest.SendToLabASync(labRequest); //Entegrasyon için.
                                    TTObjectContext context = new TTObjectContext(false);
                                    LaboratoryRequest request = (LaboratoryRequest)context.GetObject(labRequest.ObjectID, "LaboratoryRequest");
                                    request.MessageID = messageID.ToString();
                                    request.IsRequestSent = true;
                                    context.Save();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        //      Cursor.Current = current;
                    }
                }
            }
        }

        private void CloneObjectBasedOnInitialObject()
        {
            if (this._PatientAdmission.AdmissionAppointment != null)
            {
                Guid savePointGuid = this._PatientAdmission.ObjectContext.BeginSavePoint();
                //todo bg
                //TTObjectContext _editableObjectContext = new TTObjectContext(false);
               /* try
                {
                    foreach (Appointment app in this._PatientAdmission.AdmissionAppointment.Appointments)
                    {
                        if (app.CurrentStateDef.Status != StateStatusEnum.Cancelled && app.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully && app.InitialObjectID != null)
                        {
                            Episode episode = null;
                            TTObjectDef episodeActionDef = TTObjectDefManager.Instance.GetObjectDef(typeof(EpisodeAction));
                            EpisodeAction ea = null;
                            try
                            {
                                ea = (EpisodeAction)this._PatientAdmission.ObjectContext.GetObject(new Guid(app.InitialObjectID), episodeActionDef, false);
                            }
                            catch { }
                            if (ea != null)
                            {
                                episode = ea.Episode;
                                if (ea is NuclearMedicine)
                                {
                                    NuclearMedicine originalNuclearMedicine = (NuclearMedicine)this._PatientAdmission.ObjectContext.GetObject(ea.ObjectID, "NUCLEARMEDICINE");
                                    NuclearMedicineTest originalNuclearMedicineTest = (NuclearMedicineTest)this._PatientAdmission.ObjectContext.GetObject(originalNuclearMedicine.NuclearMedicineTests[0].ObjectID, "NUCLEARMEDICINETEST");
                                    NuclearMedicine cloneNuclearMedicine = (NuclearMedicine)originalNuclearMedicine.Clone();
                                    NuclearMedicineTest cloneNuclearMedicineTest = (NuclearMedicineTest)originalNuclearMedicineTest.Clone();

                                    TTSequence.allowSetSequenceValue = true;
                                    cloneNuclearMedicine.ID.SetSequenceValue(0);
                                    cloneNuclearMedicine.ID.GetNextValue();
                                    TTSequence.allowSetSequenceValue = true;
                                    cloneNuclearMedicineTest.ID.SetSequenceValue(0);
                                    cloneNuclearMedicineTest.ID.GetNextValue();
                                    cloneNuclearMedicine.Episode = this._PatientAdmission.Episode;
                                    cloneNuclearMedicine.PatientAdmission = this._PatientAdmission;
                                    cloneNuclearMedicine.ClonedObjectID = (Guid?)originalNuclearMedicine.ObjectID;
                                    cloneNuclearMedicine.CurrentStateDefID = NuclearMedicine.States.Request;

                                    foreach (PatientExamination patientExamination in originalNuclearMedicine.Episode.PatientExaminations)
                                    {
                                        foreach (PatientExamination newPatientExamination in this._PatientAdmission.Episode.PatientExaminations)
                                        {
                                            if (newPatientExamination.MasterResource == patientExamination.MasterResource)
                                            {
                                                newPatientExamination.PhysicalExamination = patientExamination.PhysicalExamination;
                                                newPatientExamination.ContinuousDrugs = patientExamination.ContinuousDrugs;
                                                newPatientExamination.PatientFamilyHistory = patientExamination.PatientFamilyHistory;
                                                newPatientExamination.ExaminationSummary = patientExamination.ExaminationSummary;
                                                newPatientExamination.SystemQuery = patientExamination.SystemQuery;
                                                newPatientExamination.Complaint = patientExamination.Complaint;
                                                newPatientExamination.ProcedureDoctor = patientExamination.ProcedureDoctor;
                                                BindingList<OzelDurum> ozelDurum = TTObjectClasses.OzelDurum.GetOzelDurumByKod(_PatientAdmission.ObjectContext, "1");
                                                if (ozelDurum != null && ozelDurum.Count > 0)
                                                    newPatientExamination.OzelDurum = ozelDurum[0];
                                                this._PatientAdmission.ObjectContext.Update();

                                                //                                                foreach(PatientExaminationProcedure patientExaminationProcedure in newPatientExamination.PatientExaminationProcedures)
                                                //                                                {
                                                //                                                    patientExaminationProcedure.Eligible = false;
                                                //                                                }

                                                foreach (DiagnosisGrid dg in patientExamination.Diagnosis)
                                                {
                                                    DiagnosisGrid newdg = new DiagnosisGrid(this._PatientAdmission.ObjectContext);
                                                    newdg.EpisodeAction = newPatientExamination;
                                                    newdg.AddToHistory = dg.AddToHistory;
                                                    newdg.Diagnose = dg.Diagnose;
                                                    newdg.FreeDiagnosis = dg.FreeDiagnosis;
                                                    newdg.IsMainDiagnose = dg.IsMainDiagnose;
                                                    newdg.ResponsibleUser = dg.ResponsibleUser;
                                                    newdg.DiagnoseDate = dg.DiagnoseDate;
                                                    newdg.Episode = this._PatientAdmission.Episode;
                                                    newdg.DiagnosisType = dg.DiagnosisType;
                                                }

                                            }
                                        }
                                    }

                                    cloneNuclearMedicineTest.Episode = this._PatientAdmission.Episode;
                                    cloneNuclearMedicineTest.NuclearMedicine = cloneNuclearMedicine;
                                    this._PatientAdmission.ObjectContext.Update();
                                    foreach (SubActionProcedure subActionProcedure in cloneNuclearMedicine.AccountableSubActionProcedures)
                                    {
                                        subActionProcedure.ActionDate = TTObjectDefManager.ServerTime;
                                        subActionProcedure.PricingDate = TTObjectDefManager.ServerTime;
                                    }
                                    cloneNuclearMedicine.CurrentStateDefID = NuclearMedicine.States.RequestAcception;
                                    this._PatientAdmission.ObjectContext.Update();
                                    cloneNuclearMedicine.CurrentStateDefID = NuclearMedicine.States.Preparation;
                                    this._PatientAdmission.Episode.MainSpeciality = originalNuclearMedicine.Episode.MainSpeciality;
                                    this._PatientAdmission.ObjectContext.Update();

                                    // this._PatientAdmission.ObjectContext.Update();
                                }
                            }
                            else
                            {
                                SubActionProcedure sa = null;
                                TTObjectDef subActionProcedureDef = TTObjectDefManager.Instance.GetObjectDef(typeof(SubActionProcedure));
                                try
                                {
                                    sa = (SubActionProcedure)this._PatientAdmission.ObjectContext.GetObject(new Guid(app.InitialObjectID), subActionProcedureDef, false);
                                }
                                catch { }
                                if (sa != null)
                                {

                                    if (sa is RadiologyTest)
                                    {
                                        RadiologyTest originalRadiologyTest = (RadiologyTest)this._PatientAdmission.ObjectContext.GetObject(sa.ObjectID, "RADIOLOGYTEST");
                                        Radiology originalRadiology = (Radiology)this._PatientAdmission.ObjectContext.GetObject(originalRadiologyTest.Radiology.ObjectID, "RADIOLOGY");
                                        RadiologyTest cloneRadiologyTest = (RadiologyTest)originalRadiologyTest.Clone();
                                        Radiology cloneRadiology = (Radiology)originalRadiology.Clone();

                                        TTSequence.allowSetSequenceValue = true;
                                        cloneRadiologyTest.ID.SetSequenceValue(0);
                                        cloneRadiologyTest.ID.GetNextValue();
                                        cloneRadiologyTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
                                        cloneRadiologyTest.Episode = this._PatientAdmission.Episode;
                                        cloneRadiologyTest.Radiology = cloneRadiology;
                                        foreach (PatientExamination patientExamination in originalRadiology.Episode.PatientExaminations)
                                        {
                                            foreach (PatientExamination newPatientExamination in this._PatientAdmission.Episode.PatientExaminations)
                                            {
                                                if (newPatientExamination.MasterResource == patientExamination.MasterResource)
                                                {
                                                    newPatientExamination.PhysicalExamination = patientExamination.PhysicalExamination;
                                                    newPatientExamination.ContinuousDrugs = patientExamination.ContinuousDrugs;
                                                    newPatientExamination.PatientFamilyHistory = patientExamination.PatientFamilyHistory;
                                                    newPatientExamination.ExaminationSummary = patientExamination.ExaminationSummary;
                                                    newPatientExamination.SystemQuery = patientExamination.SystemQuery;
                                                    newPatientExamination.Complaint = patientExamination.Complaint;
                                                    newPatientExamination.ProcedureDoctor = patientExamination.ProcedureDoctor;
                                                    BindingList<OzelDurum> ozelDurum = TTObjectClasses.OzelDurum.GetOzelDurumByKod(_PatientAdmission.ObjectContext, "1");
                                                    if (ozelDurum != null && ozelDurum.Count > 0)
                                                        newPatientExamination.OzelDurum = ozelDurum[0];
                                                    this._PatientAdmission.ObjectContext.Update();
                                                    //


                                                    foreach (DiagnosisGrid dg in patientExamination.Diagnosis)
                                                    {
                                                        DiagnosisGrid newdg = new DiagnosisGrid(this._PatientAdmission.ObjectContext);
                                                        newdg.EpisodeAction = newPatientExamination;
                                                        newdg.AddToHistory = dg.AddToHistory;
                                                        newdg.Diagnose = dg.Diagnose;
                                                        newdg.FreeDiagnosis = dg.FreeDiagnosis;
                                                        newdg.IsMainDiagnose = dg.IsMainDiagnose;
                                                        newdg.ResponsibleUser = dg.ResponsibleUser;
                                                        newdg.DiagnoseDate = dg.DiagnoseDate;
                                                        newdg.Episode = this._PatientAdmission.Episode;
                                                        newdg.DiagnosisType = dg.DiagnosisType;
                                                    }


                                                }
                                            }
                                        }

                                        TTSequence.allowSetSequenceValue = true;
                                        cloneRadiologyTest.ID.SetSequenceValue(0);
                                        cloneRadiologyTest.ID.GetNextValue();
                                        cloneRadiologyTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
                                        cloneRadiologyTest.Episode = this._PatientAdmission.Episode;
                                        cloneRadiologyTest.Radiology = cloneRadiology;
                                        TTSequence.allowSetSequenceValue = true;
                                        cloneRadiology.ID.SetSequenceValue(0);
                                        cloneRadiology.ID.GetNextValue();
                                        cloneRadiology.Episode = this._PatientAdmission.Episode;
                                        cloneRadiology.ClonedObjectID = (Guid?)originalRadiology.ObjectID;
                                        cloneRadiology.PatientAdmission = this._PatientAdmission;
                                        foreach (SubActionProcedure subActionProcedure in cloneRadiology.AccountableSubActionProcedures)
                                        {
                                            subActionProcedure.ActionDate = TTObjectDefManager.ServerTime;
                                            subActionProcedure.PricingDate = TTObjectDefManager.ServerTime;
                                        }

                                        this._PatientAdmission.Episode.MainSpeciality = originalRadiology.Episode.MainSpeciality;
                                        this._PatientAdmission.ObjectContext.Update();

                                    }
                                }
                            }
                        }
                    }
                    //_editableObjectContext.Save();
                }
                catch (Exception ex)
                {
                    this._PatientAdmission.ObjectContext.RollbackSavePoint(savePointGuid);
                    throw ex;
                }*/
            }

        }


        // Sivil Sevkli Hastalarda SGK'lı olma durumu Patient'ın bağlı olduğu Kurum ve hasta kabul sebeplerinden alanından kontrol edildi.
        public void ShowOrHideMedulaTabByPatientPayerAndReasonForAdmission()
        {
            //_PatientAdmission.CreateMedulaProvision();       
        }



        //////////////////////////////////////MODÜL YARDIMCI ARACLARI//////
        /////Birim değiştirme
        private void ChangeResource()
        {

        }

        public void LoadRegistrationForm(string PatientAdmissionNumber)
        {
           
        }
        public void ClearRegistrationForm()
        {
        }
        public void LoadIdentityInfo(IBindingList patientList)
        {

        }
        

        /// <summary>
        /// patientform.cs 
        /// </summary>
        /// <returns></returns>
        public DateTime GetBirthDate()
        {
            if (this.BDYearOnly.Value == true)
                return Convert.ToDateTime("01/01/" + this.BirthDate.Text);
            else
                return Convert.ToDateTime(this.BirthDate.Text);
        }
        public void SetSearchString()
        {
            searchString = "";
            if (UniqueRefNo.Text.Length > 0)
            {
                searchString = UniqueRefNo.Text.ToString();
            }
            else if (ForeignUniqueNo.Text.Length > 0)
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
        /// searchString 'i kullanarak Hastanın olup olmadığını kontrol eder
        /// </summary>
        public void CheckIfPatientExists()
        {
            SetSearchString();
            string filter = " Where " + GetFilterExpressionOfPatientSearch();// Where ?imdilik konuldu Coredaki problem geçene kadar
            BindingList<Patient.GetPatientByInjection_Class> patientList = Patient.GetPatientByInjection(filter);
            int count = 1;
            if (((ITTObject)this._PatientAdmission.Episode.Patient).IsNew)
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
                }
                else if (this.UniqueRefNo.Text.Length > 0)
                {
                    string[] hataParamList = new string[] { UniqueRefNo.Text };
                    String message = SystemMessage.GetMessageV3(103, hataParamList);
                    throw new TTUtils.TTException(message);
                }
                else
                {
                    if (this.UnIdentified.Value != true)
                    {
                        String message = SystemMessage.GetMessage(104);
                        throw new TTUtils.TTException(message);
                    }
                }
            }
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
            if (UniqueRefNo.Text.Length > 0)
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
            if (ForeignUniqueNo.Text.Length > 0)
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
            if (UnIdentified.Value != null)
            {
                criteriaEntered = true;
                if (Convert.ToBoolean(UnIdentified.Value))
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
                /*NameTokens = Common.Tokenize(searchString, true);

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
                }*/
                    var a = 1;
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


                if (BirthDate.Text != null && BirthDate.Text.ToString().Trim() != ".  ." && BirthDate.Text.ToString().Trim() != "")
                {
                    criteriaEntered = true;
                    string firstDate = "01.01." + (Convert.ToDateTime(GetBirthDate()).Date).ToString("yyyy") + " 00:00:00";
                    string lastDate = "31.12." + (Convert.ToDateTime(GetBirthDate()).Date).ToString("yyyy") + " 23:59:59";

                    string filter = "(BIRTHDATE >= TODATE('" + (Convert.ToDateTime(firstDate).Date).ToString("yyyy-MM-dd HH:mm") + "') AND";
                    filter += " BIRTHDATE <= TODATE('" + (Convert.ToDateTime(lastDate).Date).ToString("yyyy-MM-dd HH:mm") + "'))";
                    if (filterExpression == null)
                        filterExpression = "(" + filter + ")";
                    else
                        filterExpression += " AND (" + filter + ")";
                }
                     
                //İl
                //if (CityOfBirth.SelectedObjectID != null)
                //{
                //    criteriaEntered = true;
                //    string filter = "(CITYOFBIRTH = '" + CityOfBirth.SelectedObjectID.ToString() + "')";
                //    if (filterExpression == null)
                //        filterExpression = "(" + filter + ")";
                //    else
                //        filterExpression += " AND (" + filter + ")";
                //}

            }

            if (filterExpression == null)
                filterExpression = "1=0";

            return filterExpression;
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
        /// <summary>
        /// Zorunlu Hasta bilgilerini kontrol eder
        /// </summary>
        public bool IsAllRequiredPropertiesExists(bool throwException)
        {
            if (this.UnIdentified.Value != true)
            {
                if (!(this.Foreign.Value == true))
                {
                    if (this.UniqueRefNo == null)
                    {
                        if (throwException)
                        {
                            String message = SystemMessage.GetMessage(92);
                            throw new TTUtils.TTException(message);
                        }
                        else
                            return false;
                    }
                    if (this.UniqueRefNo.Text.Length != 11)
                    {
                        if (throwException)
                        {
                            String message = SystemMessage.GetMessage(93);
                            throw new TTUtils.TTException(message);
                        }
                        else
                            return false;
                    }
                    if (!this.CheckMernisNumber())
                    {
                        string[] hataParamList = new string[] { this.UniqueRefNo.ToString() };
                        String message = SystemMessage.GetMessageV3(94, hataParamList);
                        throw new TTUtils.TTException(message);
                    }
                }
                else if (this.Foreign.Value == true)
                {
                    if (this.ForeignUniqueNo == null)
                    {
                        if (throwException)
                        {
                            string[] hataParamList = new string[] { "Yabancı hastalar için 'Kimlik Sigorta No'" };
                            String message = SystemMessage.GetMessageV3(95, hataParamList);
                            throw new TTUtils.TTException(message);
                        }
                        else
                            return false;
                    }
                }
                if (this.Name == null)
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Adı'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                    }
                    else
                        return false;
                }
                if (this.Surname == null)
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Soyadı'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                    }
                    else
                        return false;

                }

                if (this.FatherName == null)
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Baba Adı'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                    }
                    else
                        return false;

                }

                if (this.BirthDate == null || (this.BirthDate + "").ToString().Trim() == ".  ." || (this.BirthDate + "").ToString().Trim() == "")
                {
                    if (throwException)
                    {
                        string[] hataParamList = new string[] { "'Doğum Tarihi'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                    }
                    else
                        return false;
                }

                //if (Convert.ToDateTime(this.BirthDate) < Convert.ToDateTime("02.01.1800"))
                //{
                //    if (throwException)
                //    {
                //        throw new TTException(SystemMessage.GetMessage(982));
                //    }
                //    else
                //        return false;
                //}

                //if (Common.DateDiff(0, Convert.ToDateTime(Common.RecTime()), Convert.ToDateTime(this.BirthDate), false) < 0)
                //{
                //    if (throwException)
                //    {
                //        String message = SystemMessage.GetMessage(96);
                //        throw new TTUtils.TTException(message);
                //    }
                //    else
                //        return false;
                //}

                
                //if (this.BirthDate == null || (this.BirthDate + "").ToString().Trim() == ".  ." || (this.BirthDate + "").ToString().Trim() == "")
                //{
                //    if (throwException)
                //    {
                //        string[] hataParamList = new string[] { "'Doğum Tarihi'" };
                //        String message = SystemMessage.GetMessage(95, hataParamList);
                //        throw new TTUtils.TTException(message);
                //    }
                //    else
                //        return false;
                //}

                //if (Convert.ToDateTime(this.BirthDate) < Convert.ToDateTime("02.01.1800"))
                //{
                //    if (throwException)
                //    {
                //        throw new TTException(SystemMessage.GetMessage(982));
                //    }
                //    else
                //        return false;
                //}
            }

            //if (this.Sex == null)
            //{
            //    if (throwException)
            //    {
            //        string[] hataParamList = new string[] { "'Cinsiyeti'" };
            //        String message = SystemMessage.GetMessageV3(95, hataParamList);
            //        throw new TTUtils.TTException(message);
            //    }
            //    else
            //        return false;
            //}


            if (this.Privacy != null)
            {
                if (this.Privacy.Value == true)
                {
                    if (throwException && (this.PrivacyName == null || this.PrivacySurname == null))
                    {
                        string[] hataParamList = new string[] { "'Rumuz Ad ya da Rumuz Soyad'" };
                        String message = SystemMessage.GetMessageV3(95, hataParamList);
                        throw new TTUtils.TTException(message);
                    }
                    else
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// TC Kimlik Numarasının Mernis standartlarına uygunluğunu test eder
        /// </summary>
        /// <returns>bool</returns>
        public bool CheckMernisNumber()
        {
            String uniqueRefNo =this.UniqueRefNo.Text;
            if (uniqueRefNo.Substring(0, 2) == "99" || uniqueRefNo.Substring(0, 2) == "98") //Yabancı olan hastalar(Suriyeli vb)
                return true;

            while (uniqueRefNo.Length < 11)
                uniqueRefNo = "0" + uniqueRefNo;
            bool retVal = false;
            Int32 checkSum = Convert.ToInt32(uniqueRefNo.Substring(9, 2));
            Int32 oddDigSum = Convert.ToInt32(uniqueRefNo.Substring(8, 1)) + Convert.ToInt32(uniqueRefNo.Substring(6, 1)) + Convert.ToInt32(uniqueRefNo.Substring(4, 1)) + Convert.ToInt32(uniqueRefNo.Substring(2, 1)) + Convert.ToInt32(uniqueRefNo.Substring(0, 1));
            Int32 oddDigSum_temp = oddDigSum;
            Int32 evenDigSum = Convert.ToInt32(uniqueRefNo.Substring(7, 1)) + Convert.ToInt32(uniqueRefNo.Substring(5, 1)) + Convert.ToInt32(uniqueRefNo.Substring(3, 1)) + Convert.ToInt32(uniqueRefNo.Substring(1, 1));
            Int32 total = oddDigSum * 3 + evenDigSum;
            Int32 addTo1 = (10 - (total % 10)) % 10;
            oddDigSum = addTo1 + evenDigSum;
            evenDigSum = oddDigSum_temp;
            total = oddDigSum * 3 + evenDigSum;
            Int32 addTo2 = (10 - (total % 10)) % 10;
            total = addTo1 * 10 + addTo2;
            if (total == checkSum)
                retVal = true;
            return retVal;
        }
        public void ControlPrivacyPatientInfo(bool? isPrivacy)
        {
            //if (((TTVisual.TTCheckBox)(Privacy)).Checked)
            //{
            //    //if (this.PrivacyEndDate == null)
            //    //    throw new Exception("Gizli hastalarda Gizlilik Geçerlilik Tarihi dolu ve bugünün tarihinden sonra olmalıdır!");
            //    //else if (Convert.ToDateTime(this.PrivacyEndDate.Text).Date <= Common.RecTime().Date)
            //    //    throw new Exception("Gizli hastalarda Gizlilik Geçerlilik Tarihi dolu ve bugünün tarihinden sonra olmalıdır!");

            //    ///*if(this.PrivacyReason.Value ==null)
            //    //    throw new Exception("Gizli hastalarda Gizlilik Sebebi alanı dolu olmalıdır!");*/
            //    ////if(this._PatientAdmission.Episode.Patient.Privacy.HasValue == false || this._PatientAdmission.Episode.Patient.IsPatientPrivacy == false)
            //    ////if(this._PatientAdmission.Episode.Patient.Privacy == null)
            //    //if (this._PatientAdmission.Episode.Patient.PrivacyPatient == null)
            //    //{
            //    //    //Patient Objesi PrivacyPatient objesine set edilecek

            //    //    PrivacyPatient pPatient = new PrivacyPatient(this._PatientAdmission.Episode.Patient.ObjectContext);
            //    //    pPatient.Email = _PatientAdmission.Episode.Patient.EMail;
            //    //    pPatient.FatherName = _PatientAdmission.Episode.Patient.FatherName;
            //    //    pPatient.HomeAddress = _PatientAdmission.Episode.Patient.PatientAddress.HomeAddress;
            //    //    pPatient.HomePhone = _PatientAdmission.Episode.Patient.PatientAddress.HomePhone;
            //    //    pPatient.MobilePhone = _PatientAdmission.Episode.Patient.PatientAddress.MobilePhone;
            //    //    pPatient.MotherName = _PatientAdmission.Episode.Patient.MotherName;
            //    //    pPatient.Name = _PatientAdmission.Episode.Patient.Name;
            //    //    pPatient.Photo = _PatientAdmission.Episode.Patient.Photo;
            //    //    pPatient.Surname = _PatientAdmission.Episode.Patient.Surname;
            //    //    pPatient.UniqueRefNo = _PatientAdmission.Episode.Patient.UniqueRefNo;
            //    //    pPatient.ForeignUniqueRefNo = _PatientAdmission.Episode.Patient.ForeignUniqueRefNo;
            //    //    pPatient.YUPASSNO = _PatientAdmission.Episode.Patient.YUPASSNO;
            //    // //   pPatient.PrivacyCityOfBirth = _PatientAdmission.Episode.Patient.CityOfBirth;
            //    //    //pPatient.PrivacyCityOfRegistry = _PatientAdmission.Episode.Patient.CityOfRegistry;
            //    //    //pPatient.PrivacyCountryOfBirth = _PatientAdmission.Episode.Patient.CountryOfBirth;
            //    //    pPatient.PrivacyTownOfBirth = _PatientAdmission.Episode.Patient.TownOfBirth;
            //    //    pPatient.PrivacyTownOfRegistry = _PatientAdmission.Episode.Patient.TownOfRegistry;
            //    //    pPatient.PrivacyHomeCity = _PatientAdmission.Episode.Patient.PatientAddress.HomeCity;
            //    //    pPatient.PrivacyHomeCountry = _PatientAdmission.Episode.Patient.PatientAddress.HomeCountry;
            //    //    //pPatient.PrivacyHomeTown = _PatientAdmission.Episode.Patient.PatientAddress.HomeTown;

            //    //    _PatientAdmission.Episode.Patient.PrivacyPatient = pPatient;

            //    //   // _PatientAdmission.Episode.Patient.PatientAddress.HomeTown = null;

            //    //    UniqueRefNo.Text = "********";
            //    //    if (_PatientAdmission.Episode.Patient.Foreign == true)
            //    //    {
            //    //        YupasNo.Text = "*******";
            //    //        ForeignUniqueNo.Text = "********";
            //    //    }
                    
            //        Patient.CoverPatientInformation(true, this._PatientAdmission.Episode.Patient);

            //    }
            //}
            ////else if ((!((TTVisual.TTCheckBox)(Privacy)).Checked && this._PatientAdmission.Episode.Patient.Privacy == true) && TTUser.CurrentUser.HasRole(TTObjectClasses.Common.IzoleHastaKayitRoleID))//Hastanın gizliliği kaldırılırsa Patient bilgileri geri set edilmeli
            ////{

            ////    PrivacyPatient pPatient = this._PatientAdmission.Episode.Patient.PrivacyPatient;
            ////    _PatientAdmission.Episode.Patient.EMail = pPatient.Email;
            ////    _PatientAdmission.Episode.Patient.FatherName = pPatient.FatherName;
            ////    _PatientAdmission.Episode.Patient.PatientAddress.HomeAddress = pPatient.HomeAddress;
            ////    _PatientAdmission.Episode.Patient.PatientAddress.HomePhone = pPatient.HomePhone;
            ////    _PatientAdmission.Episode.Patient.PatientAddress.MobilePhone = pPatient.MobilePhone;
            ////    _PatientAdmission.Episode.Patient.MotherName = pPatient.MotherName;
            ////    _PatientAdmission.Episode.Patient.Name = pPatient.Name;
            ////    _PatientAdmission.Episode.Patient.Photo = pPatient.Photo;
            ////    _PatientAdmission.Episode.Patient.Surname = pPatient.Surname;
            ////    _PatientAdmission.Episode.Patient.UniqueRefNo = pPatient.UniqueRefNo;
            ////    _PatientAdmission.Episode.Patient.ForeignUniqueRefNo = pPatient.ForeignUniqueRefNo;
            ////    _PatientAdmission.Episode.Patient.YUPASSNO = pPatient.YUPASSNO;
            ////    //todo bg
            //////    _PatientAdmission.Episode.Patient.CityOfBirth = pPatient.PrivacyCityOfBirth;
            ////    //_PatientAdmission.Episode.Patient.CityOfRegistry = pPatient.PrivacyCityOfRegistry;
            ////    //_PatientAdmission.Episode.Patient.CountryOfBirth = pPatient.PrivacyCountryOfBirth;
            ////    _PatientAdmission.Episode.Patient.TownOfBirth = pPatient.PrivacyTownOfBirth;
            ////    _PatientAdmission.Episode.Patient.TownOfRegistry = pPatient.PrivacyTownOfRegistry;
            ////    _PatientAdmission.Episode.Patient.PatientAddress.HomeCity = pPatient.PrivacyHomeCity;
            ////    _PatientAdmission.Episode.Patient.PatientAddress.HomeCountry = pPatient.PrivacyHomeCountry;
            ////    //_PatientAdmission.Episode.Patient.PatientAddress.HomeTown = pPatient.PrivacyHomeTown;

            ////    Patient.CoverPatientInformation(false, this._PatientAdmission.Episode.Patient);

            ////    _PatientAdmission.Episode.Patient.PrivacyPatient = null;

            //}
        }
        private PatientAdmission AskAndFireNewPatientAdmission(Patient patient)
        {
            return PatientAdmissionForm.FireNewPatientAdmission(patient, null, null, this._PatientAdmission.Episode.Patient.MyAdmissionAppointment);
        }



        public void LoadAppointmentInfo()
        {
            if (this._PatientAdmission.AdmissionAppointment == null) // kafa randevusundan kabul yapılmadıysa randevusu var mı bakılır
            {
                Appointment app = this.SelectAppointment(this._PatientAdmission.ObjectContext, this._PatientAdmission.Episode.Patient, false);
                if (app != null)
                {
                    if (app.Action != null)
                    {
                        this._PatientAdmission.AdmissionAppointment = (AdmissionAppointment)app.Action;
                        if (this._PatientAdmission.AdmissionType == null)
                        {

                            if (this._PatientAdmission.AdmissionAppointment != null)
                            {
                                this._PatientAdmission.AdmissionType = ProvizyonTipi.GetProvizyonTipi("N");
                            }
                        }
                        if (((AdmissionAppointment)app.Action).CurrentStateDefID == AdmissionAppointment.States.New)
                            ((AdmissionAppointment)app.Action).CurrentStateDefID = AdmissionAppointment.States.Appointment;
                        ((AdmissionAppointment)app.Action).CurrentStateDefID = AdmissionAppointment.States.Completed;
                    }
                }
            }
        }
        public void SetAdmissionStatusAndType()
        {
           // this._PatientAdmission.AdmissionType = AdmissionTypeEnum.Examination;todo bg
            this._PatientAdmission.AdmissionStatus = AdmissionStatusEnum.Normal;
            /*
            if (this.Death.Value == true)
            {
                this._PatientAdmission.AdmissionType = AdmissionTypeEnum.DeathSuspicion;
                this._PatientAdmission.AdmissionStatus = AdmissionStatusEnum.OluKabul;
            }
            //else if ()//kontrol
            //{ }
            else if (this.AdmissionType.SelectedValue.Equals(AdmissionTypeEnum.Daily.ToString()))
            {
                this._PatientAdmission.AdmissionType = AdmissionTypeEnum.Daily;
                this._PatientAdmission.AdmissionStatus = AdmissionStatusEnum.Gunubirlik;
            }
            else if (this.AdmissionType.SelectedValue.Equals(AdmissionTypeEnum.NewBorn.ToString()))
            {
                this._PatientAdmission.AdmissionType = AdmissionTypeEnum.NewBorn;
                this._PatientAdmission.AdmissionStatus = AdmissionStatusEnum.Yenidogan;
            }
            else if (this.DispatchHospitalList.SelectedObject != null)// TODO BG sevkli tetkik ile dısarıdan gelen konsültasyon ayrımı yapılmalı
            {
                this._PatientAdmission.AdmissionType = AdmissionTypeEnum.ConsultationFromOtherHospitalRequestAcception;
                this._PatientAdmission.AdmissionStatus = AdmissionStatusEnum.HizmetProtokol;
            }
            */
          if (this.HCRequestReason.SelectedObject != null)
            {
                //this._PatientAdmission.AdmissionType = AdmissionTypeEnum.HealthCommitteeExamination;
                this._PatientAdmission.AdmissionStatus = AdmissionStatusEnum.SaglikKurulu;
            }/*
            else if (this.Branch.SelectedObject != null && ((SpecialityDefinition)this.Branch.SelectedObject).Code == "4400")//ACIL
            {
                this._PatientAdmission.AdmissionType = AdmissionTypeEnum.Emergency;
                this._PatientAdmission.AdmissionStatus = AdmissionStatusEnum.Acil;
            }
            else if (this.Branch.SelectedObject != null && (((SpecialityDefinition)this.Branch.SelectedObject).Code == "5400" || ((SpecialityDefinition)this.Branch.SelectedObject).Code == "5700"))//AĞIZ VE DIS SAGLIGI
            {
                this._PatientAdmission.AdmissionType = AdmissionTypeEnum.Examination;//TODO TOOTHEXAMINATION
                this._PatientAdmission.AdmissionStatus = AdmissionStatusEnum.DisKabulu;
            }
            else
            {
                this._PatientAdmission.AdmissionType = AdmissionTypeEnum.Examination;
                this._PatientAdmission.AdmissionStatus = AdmissionStatusEnum.Normal;
            }*/
        }
        public void SetPatientDetailedInfo()
        {
            //this._PatientAdmission.Episode.Patient.BirthDate = GetBirthDate();

            this.IsAllRequiredPropertiesExists(true);
          

            if (this._PatientAdmission.Episode.Patient.UnIdentified.Value == true || this._PatientAdmission.Episode.Patient.Foreign == true)
                this._PatientAdmission.Episode.Patient.IsTrusted = true;

            this.ControlPrivacyPatientInfo(this._PatientAdmission.Episode.Patient.Privacy);

           // this.Alive.Value = !this._PatientAdmission.Episode.Patient.Alive;

            if (this._PatientAdmission.Episode.Patient.Episodes.Count > 1 && this._PatientAdmission.IsNewBorn == true)
                this._PatientAdmission.IsNewBorn = false;
                        
            if (_PatientAdmission.Payer.Type.PayerType == PayerTypeEnum.Official)
            {
                if (_PatientAdmission.IsNewBorn == false)
                    InfoBox.Show("Seçilen hasta grubu sevk veya sağlık yardımı müstahaklık belgesi beyanına tabidir.\r\nLütfen evrak aldığınızdan emin olunuz ! ", MessageIconEnum.InformationMessage);
            }
        }
        public void SetPatientAdmissionRerquiredInfo()
        {
            //Mernisten ölü dönen kişinin kaydının engellemesi
            if (_PatientAdmission.Episode.Patient.UniqueRefNo != null)
            {
                KPSServis.KPSServisSonucuKisiTemelBilgisi response = KPSServis.WebMethods.TcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost, _PatientAdmission.Episode.Patient.UniqueRefNo.Value);
                if (string.IsNullOrEmpty(response.Hata))
                {
                    if (string.IsNullOrEmpty(response.Sonuc.Hata))
                    {
                        if (response.Sonuc.OlumTarih != "0.0.0" && !string.IsNullOrEmpty(response.Sonuc.OlumTarih))
                            throw new TTUtils.TTException("Bu TC Kimlik no'ya sahip kişi MERNİS'te ex gözüktüğü için hasta kaydı yapamazsınız!.");
                    }
                }
            }
            else if (_PatientAdmission.Episode.Patient.Foreign == true && _PatientAdmission.Episode.Patient.ForeignUniqueRefNo != null)
            {
                KPSServis.KPSServisSonucuYabanciKisiBilgisi response = KPSServis.WebMethods.YabanciTcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(_PatientAdmission.Episode.Patient.ForeignUniqueRefNo.Value));

                if (string.IsNullOrEmpty(response.Hata))
                {
                    if (string.IsNullOrEmpty(response.Sonuc.Hata))
                    {
                        if (!string.IsNullOrEmpty(response.Sonuc.OlumTarihi))
                            throw new TTUtils.TTException("Bu Kimlik no'ya sahip kişi MERNİS'te ex gözüktüğü için hasta kaydı yapamazsınız!.");
                    }
                }
            }
            ////SGK lı hastalar dışında günübirlik kontrolü yok
            //if (_PatientAdmission.Episode.IsMedulaEpisode())
            //{//todo bg  && _PatientAdmission.AdmissionType.Value != AdmissionTypeEnum.Daily
            //    if ( _PatientAdmission.SEP != null && "G".Equals(_PatientAdmission.SEP.MedulaTedaviTuru.tedaviTuruKodu))
            //        throw new TTException("Günübirlik tedavi türünde kabul sebebi Günübirlik olmalıdır!");
            //}

        }
      
        ///////////////////////////////////////////////////////////////////

        #endregion PatientAdmissionForm_Methods

        #region PatientAdmissionForm_ClientSideMethods
        /// <summary>
        /// PatientAdmissionObjectDef null yollanırsa Kullanıcıya seçtirilir,Episode nul olarak yollanırsa yeni oluşdurulur,AdmissionAppointment null yollanırsa hastanın kafa randevularını bulur.
        /// </summary>
        public static PatientAdmission FireNewPatientAdmission(Patient patient, TTObjectDef PatientAdmissionObjectDef, Episode episode, AdmissionAppointment admissionAppointment)
        {
            return null;
            //Guid savePointGuid = patient.ObjectContext.BeginSavePoint();

            //try
            //{
            //    PatientAdmission firedAction = null;
            //    firedAction = (PatientAdmission)patient.ObjectContext.CreateObject("PatientAdmission");


            //    BindingList<TTObjectStateDef> states = (BindingList<TTObjectStateDef>)((ITTObject)firedAction).GetNextStateDefs();
            //    if (states.Count > 0)
            //    {
            //        firedAction.CurrentStateDef = (TTObjectStateDef)states[0];
            //    }
            //    firedAction.ActionDate = Common.RecTime();

            //    if (episode != null)
            //    {
            //        //bool isPatientGroupChange = (firedAction.PatientGroup != episode.PatientAdmission.PatientGroup);
            //        firedAction.Episode = episode;
            //        if (episode.LastSubEpisode.PatientAdmission != null)
            //        {
            //            foreach (TTObjectPropertyDef propDef in episode.LastSubEpisode.PatientAdmission.ObjectDef.AllPropertyDefs)
            //            {
            //                try
            //                {
            //                    if (propDef.Name != "PATIENTGROUP" & propDef.Name != "ID" & propDef.Name != "ISFIRESFROMPACORRECTION" & propDef.Name != "ISCORRECTED")
            //                        firedAction[propDef.Name] = episode.LastSubEpisode.PatientAdmission[propDef.Name];

            //                }
            //                catch (Exception e)
            //                {
            //                    // Hatalı Durmda Çalışmasın Hata de vermesin
            //                }
            //            }
            //            foreach (TTObjectRelationDef relDef in episode.LastSubEpisode.PatientAdmission.ObjectDef.AllParentRelationDefs)
            //            {
            //                try
            //                {
            //                    if (relDef.ParentName != "ADMISSIONAPPOINTMENT")
            //                    {
            //                        if (!(relDef.ParentName == "PROTOCOL" || relDef.ParentName == "PAYER"))
            //                        {
            //                            firedAction[relDef.ParentName] = episode.LastSubEpisode.PatientAdmission[relDef.ParentName];
            //                        }
            //                    }
            //                }
            //                catch (Exception e)
            //                {
            //                    // Hatalı Durmda Çalışmasın Hata de vermesin
            //                }
            //            }
            //        }
            //    }
            //    firedAction.Patient = patient;
            //    if (admissionAppointment == null && episode == null)
            //    {
            //        firedAction.AdmissionAppointment = patient.MyAdmissionAppointment;//??????? Kafa Randevusu için yeterli mi?
            //    }
            //    else if (admissionAppointment != null)
            //    {
            //        firedAction.AdmissionAppointment = admissionAppointment;
            //    }

            //    return firedAction;
            //}
            //catch (Exception ex)
            //{
            //    if (patient.ObjectContext.HasSavePoint(savePointGuid))
            //        patient.ObjectContext.RollbackSavePoint(savePointGuid);
            //    throw ex;

            //}
        }
        #endregion
    }
}