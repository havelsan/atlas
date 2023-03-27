
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
    /// Fizyoterapi İstek
    /// </summary>
    public partial class PhysiotherapyForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ttButtonRaporSorgu.Click += new TTControlEventDelegate(ttButtonRaporSorgu_Click);
            cmbTedaviTuru.SelectedIndexChanged += new TTControlEventDelegate(cmbTedaviTuru_SelectedIndexChanged);
            chkDisXXXXXXRaporu.CheckedChanged += new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            chkInPatientBed.CheckedChanged += new TTControlEventDelegate(chkInPatientBed_CheckedChanged);
            Physiotherapies.CellValueChanged += new TTGridCellEventDelegate(Physiotherapies_CellValueChanged);
            GridEpisodeDiagnosis.RowEnter += new TTGridCellEventDelegate(GridEpisodeDiagnosis_RowEnter);
            btnSelectTemplate.Click += new TTControlEventDelegate(btnSelectTemplate_Click);
            btnCreateTemplate.Click += new TTControlEventDelegate(btnCreateTemplate_Click);
            btnEditTemplate.Click += new TTControlEventDelegate(btnEditTemplate_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttButtonRaporSorgu.Click -= new TTControlEventDelegate(ttButtonRaporSorgu_Click);
            cmbTedaviTuru.SelectedIndexChanged -= new TTControlEventDelegate(cmbTedaviTuru_SelectedIndexChanged);
            chkDisXXXXXXRaporu.CheckedChanged -= new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            chkInPatientBed.CheckedChanged -= new TTControlEventDelegate(chkInPatientBed_CheckedChanged);
            Physiotherapies.CellValueChanged -= new TTGridCellEventDelegate(Physiotherapies_CellValueChanged);
            GridEpisodeDiagnosis.RowEnter -= new TTGridCellEventDelegate(GridEpisodeDiagnosis_RowEnter);
            btnSelectTemplate.Click -= new TTControlEventDelegate(btnSelectTemplate_Click);
            btnCreateTemplate.Click -= new TTControlEventDelegate(btnCreateTemplate_Click);
            btnEditTemplate.Click -= new TTControlEventDelegate(btnEditTemplate_Click);
            base.UnBindControlEvents();
        }

        private void ttButtonRaporSorgu_Click()
        {
#region PhysiotherapyForm_ttButtonRaporSorgu_Click
   MedulaRaporIslemleri medulaRaporIslemleri = new MedulaRaporIslemleri(this._EpisodeAction.GetCurrentAction().Episode.Patient);
            medulaRaporIslemleri.Show();
#endregion PhysiotherapyForm_ttButtonRaporSorgu_Click
        }

        private void cmbTedaviTuru_SelectedIndexChanged()
        {
#region PhysiotherapyForm_cmbTedaviTuru_SelectedIndexChanged
   if(cmbTedaviTuru.SelectedItem != null)
            {
                if(cmbTedaviTuru.SelectedItem.Value != null)
                {
                    string tur =((ITTComboBox)((TTVisual.TTComboBox)(cmbTedaviTuru))).SelectedItem.Value.ToString();
                    
                    if(cmbTedaviTuru.SelectedItem.Text.Equals(TreatmentQueryReportTypeEnum.FTR.ToString()) == true)
                    {
                        
                        if(this._PhysiotherapyRequest.Episode.Patient.UniqueRefNo == null && this._PhysiotherapyRequest.Episode.Patient.YUPASSNO == null)
                        {
                            InfoBox.Show("Kişinin Sistemde Tanımlı Bir Kimlik Numarası Yoktur. İşlem Yapmadan Önce Kimlik Bilgilerini Güncelleyiniz!!!");
                            ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
                            return;
                        }
                        
                        RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                        //TODO : MEDULA20140501
                        _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                        _raporOkuTCKimlikNodanDVO.raporTuru="1";
                        
                        if(this._PhysiotherapyRequest.Episode.Patient.YUPASSNO != null)
                            _raporOkuTCKimlikNodanDVO.tckimlikNo = this._PhysiotherapyRequest.Episode.Patient.YUPASSNO.Value.ToString();
                        else
                            _raporOkuTCKimlikNodanDVO.tckimlikNo = this._PhysiotherapyRequest.Episode.Patient.UniqueRefNo.Value.ToString();
                        
                        RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
                        
                        if (response != null)
                        {
                            if (!response.sonucKodu.Equals(0))
                            {
                                InfoBox.Show("Sonuc Açıklaması : " + response.sonucAciklamasi + " Sonuç Kodu :" + response.sonucKodu);
                                return;
                            }
                            if (response.raporlar ==null)
                            {
                                InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
                                ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
                                return;
                            }
                            if(response.sonucKodu.Equals(0))
                            {
                                if(response.raporlar!=null && response.raporlar.Length>0)
                                {
                                    bool isValid=false;
                                    string raporTuru = string.Empty;
                                    IList fTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesiQuery();
                                    MultiSelectForm multiSelectForm = new MultiSelectForm();
                                    foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                                    {
                                        if (item.tedaviRapor != null)
                                        {
                                            if(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu ==  Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX")))
                                            {
                                                string raporBilgileri = string.Empty;
                                                if(tur=="1")
                                                {
                                                    if(item.tedaviRapor.tedaviRaporTuru==5 || item.tedaviRapor.tedaviRaporTuru==7)
                                                    {
                                                        isValid=true;
                                                        
                                                        // List<RaporIslemleri.ftrRaporBilgisiDVO> fTRRaporBilgisiDVO = new List<RaporIslemleri.ftrRaporBilgisiDVO>();
                                                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                                        {
                                                            raporTuru = item.tedaviRapor.raporDVO.duzenlemeTuru == "1" ? "Heyet Raporu" : "Tek Hekim Raporu";
                                                            foreach (FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class fTRVucutBolgesi in fTRVucutBolgesiList)
                                                            {
                                                                if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedaviIslemBilgisiDVO.ftrRaporBilgisi.ftrVucutBolgesiKodu)
                                                                    raporBilgileri +=" Vücut Bölgesi :" + fTRVucutBolgesi.ftrVucutBolgesiAdi.ToString() + " Kür :" +tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansSayi.ToString() ;
                                                            }
                                                        }
                                                        //fTRRaporBilgisiDVO.Add(tedaviIslemBilgisiDVO.ftrRaporBilgisi);
                                                        if(item.tedaviRapor.tedaviRaporTuru==7)
                                                            multiSelectForm.AddMSItem("(Trafik Kazası) Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih + " Rapor Türü : " + raporTuru + raporBilgileri, item.raporTakipNo.ToString());
                                                        else
                                                            multiSelectForm.AddMSItem("Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih + " Rapor Türü : " + raporTuru + raporBilgileri, item.raporTakipNo.ToString());
                                                    }
                                                }
                                                else
                                                {
                                                    if(item.tedaviRapor.tedaviRaporTuru==3  )
                                                    {
                                                        isValid=true;
                                                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                                        {
                                                            foreach (FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class fTRVucutBolgesi in fTRVucutBolgesiList)
                                                            {
                                                                if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedaviIslemBilgisiDVO.ftrRaporBilgisi.ftrVucutBolgesiKodu)
                                                                    raporBilgileri += " Vücut Bölgesi :" + fTRVucutBolgesi.ftrVucutBolgesiAdi.ToString() + " Kür :" + tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansSayi.ToString();
                                                            }
                                                        }
                                                        if(item.tedaviRapor.tedaviRaporTuru==7)
                                                            multiSelectForm.AddMSItem("(Trafik Kazası) Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih, item.raporTakipNo.ToString());
                                                        else
                                                            multiSelectForm.AddMSItem("Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih, item.raporTakipNo.ToString());
                                                    }
                                                }
                                                
                                            }
                                        }
                                    }
                                    string mkey = multiSelectForm.GetMSItem(null, "İlgili Raporu Seçiniz", true);
                                    if(isValid)
                                    {
                                        if (string.IsNullOrEmpty(mkey))
                                        {
                                            InfoBox.Show("İlgili raporu seçmeden işleme devam edemezsiniz.");
                                            return;
                                        }
                                        string raporTakipNo = multiSelectForm.MSSelectedItemObject as string;
                                    }
                                    else
                                    {
                                        InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
                                        ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
                                        return;
                                    }
                                    if(!string.IsNullOrEmpty(mkey))
                                    {
                                        MedulaRaporTakipNo.Visible=true;
                                        labelMedulaRaporTakipNo.Visible=true;
                                        lblRaporBilgileri.Visible=true;
                                        MedulaRaporBilgileri.Visible=true;
                                        MedulaRaporTakipNo.Text=mkey;
                                        ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =true;
                                        
                                        foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                                        {
                                            if (mkey == item.raporTakipNo.ToString())
                                            {
                                                _PhysiotherapyRequest.ReportNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                                foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                                {
                                                    raporTuru = item.tedaviRapor.raporDVO.duzenlemeTuru == "1" ? "Heyet Raporu" : "Tek Hekim Raporu";
                                                    foreach (FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class fTRVucutBolgesi in fTRVucutBolgesiList)
                                                    {
                                                        if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedaviIslemBilgisiDVO.ftrRaporBilgisi.ftrVucutBolgesiKodu)
                                                        {
                                                            if(item.tedaviRapor.tedaviRaporTuru ==7)
                                                                MedulaRaporBilgileri.Text += "(Tarfik Kazası) Vücut Bölgesi :" + fTRVucutBolgesi.ftrVucutBolgesiAdi.ToString() + " Kür :" + tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansSayi.ToString() + " Rapor Türü : " + raporTuru;
                                                            else
                                                                MedulaRaporBilgileri.Text += "Vücut Bölgesi :" + fTRVucutBolgesi.ftrVucutBolgesiAdi.ToString() + " Kür :" + tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansSayi.ToString() + " Rapor Türü : " + raporTuru;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MedulaRaporTakipNo.Visible=false;
                                        labelMedulaRaporTakipNo.Visible=false;
                                        lblRaporBilgileri.Visible=false;
                                        MedulaRaporBilgileri.Visible=false;
                                        MedulaRaporTakipNo.Text="";
                                        MedulaRaporBilgileri.Text = "";
                                    }
                                }
                                else{
                                    InfoBox.Show("Kişinin Rapor Bilgisi Bulunamamıştır. Lütfen Önce Rapor Oluşturunuz !");
                                    ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
                                    return;
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        _PhysiotherapyRequest.ReportNo = null;
                        MedulaRaporTakipNo.Visible=false;
                        labelMedulaRaporTakipNo.Visible=false;
                        lblRaporBilgileri.Visible=false;
                        MedulaRaporBilgileri.Visible=false;
                        MedulaRaporTakipNo.Text="";
                        MedulaRaporBilgileri.Text = "";
                    }
                    
                }
                else
                {
                    _PhysiotherapyRequest.ReportNo = null;
                    MedulaRaporTakipNo.Visible=false;
                    labelMedulaRaporTakipNo.Visible=false;
                    lblRaporBilgileri.Visible=false;
                    MedulaRaporBilgileri.Visible=false;
                    MedulaRaporTakipNo.Text="";
                    MedulaRaporBilgileri.Text = "";
                    
                }
            }
            else
            {
                _PhysiotherapyRequest.ReportNo = null;
                MedulaRaporTakipNo.Visible=false;
                labelMedulaRaporTakipNo.Visible=false;
                lblRaporBilgileri.Visible=false;
                MedulaRaporBilgileri.Visible=false;
                MedulaRaporTakipNo.Text="";
                MedulaRaporBilgileri.Text = "";
                ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
            }
#endregion PhysiotherapyForm_cmbTedaviTuru_SelectedIndexChanged
        }

        private void chkDisXXXXXXRaporu_CheckedChanged()
        {
#region PhysiotherapyForm_chkDisXXXXXXRaporu_CheckedChanged
   //
//            if (((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked)
//            {
//                string tur=string.Empty;
//                if(this._PhysiotherapyRequest.Episode.Patient.UniqueRefNo == null && this._PhysiotherapyRequest.Episode.Patient.YUPASSNO == null)
//                {
//                    InfoBox.Show("Kişinin Sistemde Tanımlı Bir Kimlik Numarası Yoktur. İşlem Yapmadan Önce Kimlik Bilgilerini Güncelleyiniz!!!");
//                    ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
//                    return;
//                }
//                
//                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
//                //TODO : MEDULA20140501
//                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
//                
//                
//                if(((ITTComboBox)((TTVisual.TTComboBox)(cmbTedaviTuru))).SelectedItem==null)
//                {
//                    InfoBox.Show("Tedavi Türünü Seçiniz");
//                    ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
//                    return;
//                }
//                if (!string.IsNullOrEmpty(((ITTComboBox)((TTVisual.TTComboBox)(cmbTedaviTuru))).SelectedItem.Value.ToString()))
//                {
//                    tur =((ITTComboBox)((TTVisual.TTComboBox)(cmbTedaviTuru))).SelectedItem.Value.ToString();
//                    _raporOkuTCKimlikNodanDVO.raporTuru="1";
//                }
//                
//                if(this._PhysiotherapyRequest.Episode.Patient.UniqueRefNo != null)
//                    _raporOkuTCKimlikNodanDVO.tckimlikNo = this._PhysiotherapyRequest.Episode.Patient.UniqueRefNo.Value.ToString();
//                else
//                    _raporOkuTCKimlikNodanDVO.tckimlikNo = this._PhysiotherapyRequest.Episode.Patient.YUPASSNO.Value.ToString();
//                
//                RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
//                
//                if (response != null)
//                {
//                    if (!response.sonucKodu.Equals(0))
//                    {
//                        InfoBox.Show("Sonuc Açıklaması : " + response.sonucAciklamasi + " Sonuç Kodu :" + response.sonucKodu);
//                        return;
//                    }
//                    if (response.raporlar ==null)
//                    {
//                        InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
//                        ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
//                        return;
//                    }
//                    if(response.sonucKodu.Equals(0))
//                    {
//                        if(response.raporlar!=null && response.raporlar.Length>0)
//                        {
//                            bool isValid=false;
//                            string raporTuru = string.Empty;
//                            IList fTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesiQuery();
//                            MultiSelectForm multiSelectForm = new MultiSelectForm();
//                            foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
//                            {
//                                if (item.tedaviRapor != null)
//                                {
//                                    if(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu ==  Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX")))
//                                    {
//                                        string raporBilgileri = string.Empty;
//                                        if(tur=="1")
//                                        {
//                                            if(item.tedaviRapor.tedaviRaporTuru==5 || item.tedaviRapor.tedaviRaporTuru==7)
//                                            {
//                                                isValid=true;
//                                                
//                                                // List<RaporIslemleri.ftrRaporBilgisiDVO> fTRRaporBilgisiDVO = new List<RaporIslemleri.ftrRaporBilgisiDVO>();
//                                                foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
//                                                {
//                                                    raporTuru = item.tedaviRapor.raporDVO.duzenlemeTuru == "1" ? "Heyet Raporu" : "Tek Hekim Raporu";
//                                                    foreach (FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class fTRVucutBolgesi in fTRVucutBolgesiList)
//                                                    {
//                                                        if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedaviIslemBilgisiDVO.ftrRaporBilgisi.ftrVucutBolgesiKodu)
//                                                            raporBilgileri +=" Vücut Bölgesi :" + fTRVucutBolgesi.ftrVucutBolgesiAdi.ToString() + " Kür :" +tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansSayi.ToString() ;
//                                                    }
//                                                }
//                                                //fTRRaporBilgisiDVO.Add(tedaviIslemBilgisiDVO.ftrRaporBilgisi);
//                                                if(item.tedaviRapor.tedaviRaporTuru==7)
//                                                    multiSelectForm.AddMSItem("(Trafik Kazası) Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih + " Rapor Türü : " + raporTuru + raporBilgileri, item.raporTakipNo.ToString());
//                                                else
//                                                    multiSelectForm.AddMSItem("Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih + " Rapor Türü : " + raporTuru + raporBilgileri, item.raporTakipNo.ToString());
//                                            }
//                                        }
//                                        else
//                                        {
//                                            if(item.tedaviRapor.tedaviRaporTuru==3  )
//                                            {
//                                                isValid=true;
//                                                foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
//                                                {
//                                                    foreach (FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class fTRVucutBolgesi in fTRVucutBolgesiList)
//                                                    {
//                                                        if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedaviIslemBilgisiDVO.ftrRaporBilgisi.ftrVucutBolgesiKodu)
//                                                            raporBilgileri += " Vücut Bölgesi :" + fTRVucutBolgesi.ftrVucutBolgesiAdi.ToString() + " Kür :" + tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansSayi.ToString();
//                                                    }
//                                                }
//                                                if(item.tedaviRapor.tedaviRaporTuru==7)
//                                                    multiSelectForm.AddMSItem("(Trafik Kazası) Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih, item.raporTakipNo.ToString());
//                                                else
//                                                    multiSelectForm.AddMSItem("Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih, item.raporTakipNo.ToString());
//                                            }
//                                        }
//                                        
//                                    }
//                                }
//                            }
//                            string mkey = multiSelectForm.GetMSItem(null, "İlgili Raporu Seçiniz", true);
//                            if(isValid)
//                            {
//                                if (string.IsNullOrEmpty(mkey))
//                                {
//                                    InfoBox.Show("İlgili raporu seçmeden işleme devam edemezsiniz.");
//                                    return;
//                                }
//                                string raporTakipNo = multiSelectForm.MSSelectedItemObject as string;
//                            }
//                            else
//                            {
//                                InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
//                                ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
//                                return;
//                            }
//                            if(!string.IsNullOrEmpty(mkey))
//                            {
//                                MedulaRaporTakipNo.Visible=true;
//                                labelMedulaRaporTakipNo.Visible=true;
//                                lblRaporBilgileri.Visible=true;
//                                MedulaRaporBilgileri.Visible=true;
//                                MedulaRaporTakipNo.Text=mkey;
//                                
//                                foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
//                                {
//                                    if (mkey == item.raporTakipNo.ToString())
//                                    {
//                                        _PhysiotherapyRequest.ReportNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
//                                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
//                                        {
//                                            raporTuru = item.tedaviRapor.raporDVO.duzenlemeTuru == "1" ? "Heyet Raporu" : "Tek Hekim Raporu";
//                                            foreach (FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class fTRVucutBolgesi in fTRVucutBolgesiList)
//                                            {
//                                                if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedaviIslemBilgisiDVO.ftrRaporBilgisi.ftrVucutBolgesiKodu)
//                                                {
//                                                    if(item.tedaviRapor.tedaviRaporTuru ==7)
//                                                        MedulaRaporBilgileri.Text += "(Tarfik Kazası) Vücut Bölgesi :" + fTRVucutBolgesi.ftrVucutBolgesiAdi.ToString() + " Kür :" + tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansSayi.ToString() + " Rapor Türü : " + raporTuru;
//                                                    else
//                                                        MedulaRaporBilgileri.Text += "Vücut Bölgesi :" + fTRVucutBolgesi.ftrVucutBolgesiAdi.ToString() + " Kür :" + tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansSayi.ToString() + " Rapor Türü : " + raporTuru;
//                                                }
//                                            }
//                                        }
//                                    }
//                                }
//                            }
//                            else
//                            {
//                                MedulaRaporTakipNo.Visible=false;
//                                labelMedulaRaporTakipNo.Visible=false;
//                                lblRaporBilgileri.Visible=false;
//                                MedulaRaporBilgileri.Visible=false;
//                                MedulaRaporTakipNo.Text="";
//                                MedulaRaporBilgileri.Text = "";
//                            }
//                        }
//                        else{
//                            InfoBox.Show("Kişinin Rapor Bilgisi Bulunamamıştır. Lütfen Önce Rapor Oluşturunuz !");
//                            ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
//                            return;
//                        }
//                    }
//                }
//            }
//            else
//            {
//                _PhysiotherapyRequest.ReportNo = null;
//                MedulaRaporTakipNo.Visible=false;
//                labelMedulaRaporTakipNo.Visible=false;
//                lblRaporBilgileri.Visible=false;
//                MedulaRaporBilgileri.Visible=false;
//                MedulaRaporTakipNo.Text="";
//                MedulaRaporBilgileri.Text = "";
//            }
#endregion PhysiotherapyForm_chkDisXXXXXXRaporu_CheckedChanged
        }

        private void chkInPatientBed_CheckedChanged()
        {
#region PhysiotherapyForm_chkInPatientBed_CheckedChanged
   this.FillInpatientLists(this.chkInPatientBed.Value);
#endregion PhysiotherapyForm_chkInPatientBed_CheckedChanged
        }

        private void Physiotherapies_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PhysiotherapyForm_Physiotherapies_CellValueChanged
   if (this.Physiotherapies.CurrentCell.OwningColumn.Name == "ProcedureObject")
            {
                if (rowIndex < this.Physiotherapies.Rows.Count && rowIndex > -1)
                {
                    PhysiotherapyOrder physiOrder = (PhysiotherapyOrder)((ITTGridRow)Physiotherapies.Rows[rowIndex]).TTObject;
                    if (physiOrder.ProcedureObject != null)
                    {
                        if (((PhysiotherapyDefinition)physiOrder.ProcedureObject).TreatmentUnits.Count == 1)
                        {
                            physiOrder.TreatmentDiagnosisUnit = ((PhysiotherapyTreatmentUnitGrid)((PhysiotherapyDefinition)physiOrder.ProcedureObject).TreatmentUnits[0]).TreatmentDiagnosisUnit;
                        }
                    }
                }
            }
#endregion PhysiotherapyForm_Physiotherapies_CellValueChanged
        }

        private void GridEpisodeDiagnosis_RowEnter(Int32 rowIndex, Int32 columnIndex)
        {
#region PhysiotherapyForm_GridEpisodeDiagnosis_RowEnter
   string taniGrubu= string.Empty;
            foreach(DiagnosisGrid item in this._PhysiotherapyRequest.Episode.Diagnosis)
            {
                
                DiagnosisDefinition d = item.Diagnose != null ? item.Diagnose : null;
                if(d.FtrDiagnoseGroup != null && d.FtrDiagnoseGroup.ToString() != null)
                    taniGrubu = d.FtrDiagnoseGroup.ToString();
            }
            if(!string.IsNullOrEmpty(taniGrubu))
               this._PhysiotherapyRequest.DiagnosisGroup = taniGrubu;
#endregion PhysiotherapyForm_GridEpisodeDiagnosis_RowEnter
        }

        private void btnSelectTemplate_Click()
        {
#region PhysiotherapyForm_btnSelectTemplate_Click
   TTObjectContext objectContext = new TTObjectContext(true);
            PhysiotherapyRequestTemplateDefinition selectedTemplate = (PhysiotherapyRequestTemplateDefinition)this.SelectTemplate(objectContext, typeof(PhysiotherapyRequestTemplateDefinition).Name, false);
            if (selectedTemplate != null)
            {
                // Fizyoterapi template tanımındaki templateDetailler baz alınarak yeni PhysiotherapyOrderlar oluşturulur.
                foreach (PhysiotherapyRequestTemplateDetail pRTDetail in selectedTemplate.PhysiotherapyRequestTemplateDetails)
                {
                    PhysiotherapyOrder pOrder = new PhysiotherapyOrder(this._EpisodeAction.ObjectContext);
                    pOrder.PhysiotherapyRequest = this._PhysiotherapyRequest;
                    pOrder.ProcedureObject = pRTDetail.ProcedureObject;
                    pOrder.Amount = pRTDetail.Amount;
                    pOrder.TreatmentDiagnosisUnit = pRTDetail.TreatmentDiagnosisUnit;
                    pOrder.ApplicationArea = pRTDetail.ApplicationArea;
                    pOrder.Duration = pRTDetail.Duration;
                    pOrder.FTRApplicationAreaDef = pRTDetail.FTRApplicationAreaDef;
                    pOrder.TreatmentProperties = pRTDetail.TreatmentProperties;
                }
            }
#endregion PhysiotherapyForm_btnSelectTemplate_Click
        }

        private void btnCreateTemplate_Click()
        {
#region PhysiotherapyForm_btnCreateTemplate_Click
   // if(this._LaboratoryRequest.LaboratoryRequestTemplate == null)
            //            {

            if (this._PhysiotherapyRequest.PhysiotherapyOrders.Count > 0)
            {
                try
                {
                    string description = InputForm.GetText("Şablon Açıklaması");
                    if (!string.IsNullOrEmpty(description))
                    {
                        TTObjectContext objectContext = new TTObjectContext(false);
                        PhysiotherapyRequestTemplateDefinition template = new PhysiotherapyRequestTemplateDefinition(objectContext);
                        if (!Common.CurrentUser.IsSuperUser)// süper userların tanımladığı şablonlar genel şablonlar olur User ataması yapılmaz
                            template.ResUser = Common.CurrentResource;
                        template.Name = description;
                        foreach (PhysiotherapyOrder pO in this._PhysiotherapyRequest.PhysiotherapyOrders)
                        {
                            if (pO.Duration == null || pO.TreatmentDiagnosisUnit == null || pO.ProcedureObject == null)//
                                throw new Exception(SystemMessage.GetMessage(1158));//

                            PhysiotherapyRequestTemplateDetail templateDetail = new PhysiotherapyRequestTemplateDetail(objectContext);
                            templateDetail.Amount = Convert.ToInt64(pO.Amount);
                            templateDetail.ApplicationArea = pO.ApplicationArea;
                            templateDetail.Duration = pO.Duration;
                            templateDetail.ProcedureObject = pO.ProcedureObject;
                            templateDetail.TreatmentDiagnosisUnit = pO.TreatmentDiagnosisUnit;
                            templateDetail.FTRApplicationAreaDef = pO.FTRApplicationAreaDef;
                            templateDetail.TreatmentProperties = pO.TreatmentProperties;
                            template.PhysiotherapyRequestTemplateDetails.Add(templateDetail);
                        }
                        objectContext.Save();
                    }
                }
                catch (Exception ex)
                {
                    InfoBox.Show(ex);
                }
            }
#endregion PhysiotherapyForm_btnCreateTemplate_Click
        }

        private void btnEditTemplate_Click()
        {
            #region PhysiotherapyForm_btnEditTemplate_Click
            //TODO:ShowEdit!
            //try
            //         {
            //             TTObjectContext objectContext = new TTObjectContext(false);
            //             PhysiotherapyRequestTemplateDefinition selectedTemplate = (PhysiotherapyRequestTemplateDefinition)this.SelectTemplate(objectContext, typeof(PhysiotherapyRequestTemplateDefinition).Name, true);
            //             if (selectedTemplate != null)
            //             {
            //                 ShowTempleteForm(selectedTemplate, "PhysiotherapyRequestTemplateDefinitionList");
            //             }
            //             objectContext.Save();

            //         }
            //         catch (Exception ex)
            //         {
            //             InfoBox.Show(ex);
            //         }
            var a = 1;
            #endregion PhysiotherapyForm_btnEditTemplate_Click
        }

        protected override void PreScript()
        {
#region PhysiotherapyForm_PreScript
    base.PreScript();

            if (_PhysiotherapyRequest.Episode.Diagnosis.Count == 0)
                throw new TTUtils.TTException("Bu işlem herhangi bir tanısı olmayan epizotlarda başlatılamaz.");

            //if (this._PhysiotherapyRequest.CurrentStateDefID == PhysiotherapyRequest.States.Request)
            //{
            //    this.labelProtocolNo.Visible = false;
            //    this.ProtocolNo.Visible = false;
            //}
            //else
            //{
            //    this.labelProtocolNo.Visible = true;
            //    this.ProtocolNo.Visible = true;
            //}

            this.SetProcedureDoctorAsCurrentResource();
            //this.cmdOK.Visible = false;

            if (this._PhysiotherapyRequest.Episode.Patient.InpatientEpisode == null && this._PhysiotherapyRequest.InPatientsBed == false)
            {
                this.chkInPatientBed.Visible = false;
                this.labelPhysicalStateClinic.Visible = false;
                this.PhysicalStateClinic.Visible = false;
                this.labelRoomGroup.Visible = false;
                this.RoomGroup.Visible = false;
                this.labelRoom.Visible = false;
                this.Room.Visible = false;
                this.labelBed.Visible = false;
                this.Bed.Visible = false;
            }
            else
            {
                this.chkInPatientBed.Visible = true;
                this.labelPhysicalStateClinic.Visible = true;
                this.PhysicalStateClinic.Visible = true;
                this.labelRoomGroup.Visible = true;
                this.RoomGroup.Visible = true;
                this.labelRoom.Visible = true;
                this.Room.Visible = true;
                this.labelBed.Visible = true;
                this.Bed.Visible = true;
            }
            this.FillInpatientLists(this.chkInPatientBed.Value);

            //Klinik Bulgular
            Episode episode = this._PhysiotherapyRequest.Episode;
            String conResultAndOffers = "";
            Guid EPISODE = new Guid();
            EPISODE = this._PhysiotherapyRequest.Episode.ObjectID;
            string CODE = "1800";
            int consultationCount = 1;
            TTObjectContext ctx = new TTObjectContext(true);
            IBindingList specialityList = SpecialityDefinition.GetSpecialityByCode(ctx, CODE);
            IBindingList consultationList = ConsultationProcedure.GetConsultationProcedureByEpisode(ctx, EPISODE);


            string klinikBulgular = "";
            if (episode.Complaint != null)
                klinikBulgular += "ŞİKAYETİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.Complaint.ToString()) + "\r\n";
            if (episode.PatientHistory != null)
                klinikBulgular += "HİKAYESİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.PatientHistory.ToString()) + "\r\n";
            if (episode.PhysicalExamination != null)
                klinikBulgular += "FİZİK MUAYENE : " + TTObjectClasses.Common.GetTextOfRTFString(episode.PhysicalExamination.ToString()) + "\r\n";
            if (episode.ExaminationSummary != null)
                klinikBulgular += "MUAYENE ÖZETİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.ExaminationSummary.ToString()) + "\r\n";


            foreach (ConsultationProcedure consultation in consultationList)
            {
                string scode = "";
                string speCode = "";
                if (consultation.Consultation.ConsultationResultAndOffers != null)
                {
                    conResultAndOffers = Convert.ToString(consultation.Consultation.ConsultationResultAndOffers);
                    if (consultationCount == 1)
                    {
                        klinikBulgular += "KONSÜLTASYON SONUÇ VE ÖNERİLERİ : ";
                        consultationCount++;
                    }


                    foreach (ResourceSpecialityGrid resSpeciality in consultation.Consultation.MasterResource.ResourceSpecialities)
                    {

                        foreach (SpecialityDefinition specialityDef in specialityList)
                        {
                            if (specialityDef.Name != null)
                                speCode = (specialityDef.Name).ToString();
                        }

                        if (resSpeciality.Speciality != null)
                            scode = (resSpeciality.Speciality).ToString();
                        if (speCode.Equals(scode))
                            klinikBulgular += TTObjectClasses.Common.GetTextOfRTFString(conResultAndOffers) + "\r\n";

                    }
                }
            }
            if (klinikBulgular != null && klinikBulgular != "")
                this.ClinicInfoRTF.Text = klinikBulgular;
            //ClinicFindings.Text = klinikBulgular;
            
            
            if(Common.CurrentUser.Status == UserStatusEnum.SuperUser)
                MedulaRaporTakipNo.ReadOnly = false;
            else
                MedulaRaporTakipNo.ReadOnly = true;
            
            string taniGrubu= string.Empty;
            foreach(DiagnosisGrid item in this._PhysiotherapyRequest.Episode.Diagnosis)
            {
                DiagnosisDefinition d = item.Diagnose != null ? item.Diagnose : null;
                if(d.FtrDiagnoseGroup != null && d.FtrDiagnoseGroup.ToString() != null)
                    taniGrubu = d.FtrDiagnoseGroup.ToString();
            }
            if(!string.IsNullOrEmpty(taniGrubu))
                this._PhysiotherapyRequest.DiagnosisGroup = taniGrubu;
#endregion PhysiotherapyForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PhysiotherapyForm_PostScript
    base.PostScript(transDef);
            
            //INC013176-INC013175 Robotik Rehabilitasyon
            if(this._PhysiotherapyRequest.PhysiotherapyOrders != null)
            {
                foreach (PhysiotherapyOrder pOrder in this._PhysiotherapyRequest.PhysiotherapyOrders)
                {
                    if (pOrder.ProcedureObject != null && pOrder.ProcedureObject.ID != null)
                    {
                        // Hizmet Robotik Rehabilitasyon
                        if (pOrder.ProcedureObject.ID.Value != null && pOrder.ProcedureObject.ID.Value == 11084)
                        {
                            if (pOrder.Amount + PhysiotherapyRequest.GetTotalRoboticOrdersCount(_PhysiotherapyRequest.Episode.Patient.ObjectID) > 30)
                                throw new TTException("Robotik rehabilitasyon seansları yılda otuz seansı geçemez!");
                            
                            if (Episode.HasAnyEpisodePhysiotherapyOrderWithoutRobotikRehabilitasyon(this._PhysiotherapyRequest.Episode))
                                throw new TTException("Aynı Episode içerisinde Fizyoterapi işlemi olduğundan Robotik Rehabilitasyon hizmeti başlatılamaz!");
                        }
                        // Hizmet Robotik Rehabilitasyon haricindekiler
                        else
                        {
                            if (Episode.HasAnyEpisodeRobotikRehabilitasyon(this._PhysiotherapyRequest.Episode))
                                throw new TTException("Aynı Episode içerisinde Robotik Rehabilitasyon hizmeti olduğundan Fizyoterapi hizmeti başlatılamaz!");
                        }
                    }
                }
            }
#endregion PhysiotherapyForm_PostScript

            }
            
#region PhysiotherapyForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                //if(!string.IsNullOrEmpty(MedulaRaporTakipNo.Text))
                //{
                //    TTObjectContext context = new TTObjectContext(false);
                //    MedulaReportResult medulaReportResult = new MedulaReportResult(context);
                //    medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                //    medulaReportResult.ReportNumber =  "";
                //    medulaReportResult.ReportRowNumber = 0;
                //    medulaReportResult.ReportChasingNo = MedulaRaporTakipNo.Text;
                //    medulaReportResult.SendReportDate = DateTime.Now;
                //    medulaReportResult.ResultCode="0";
                //    medulaReportResult.ResultExplanation = "Rapor Takip Numarası Dış XXXXXX Tarafından Verilmiştir!!!";
                //    medulaReportResult.PhysiotherapyOrder = this._PhysiotherapyRequest.PhysiotherapyOrders[0];
                //    context.Save();
                //}
                //else
                //{

                if (this._PhysiotherapyRequest.SubEpisode != null && this._PhysiotherapyRequest.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._PhysiotherapyRequest.SubEpisode.SGKSEP.MedulaTakipNo))
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(MedulaRaporTakipNo.Text))
                        {
                            RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                            //TODO : MEDULA20140501
                            _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                            _raporOkuTCKimlikNodanDVO.raporTuru = "1";
                            _raporOkuTCKimlikNodanDVO.tckimlikNo = this._PhysiotherapyRequest.Episode.Patient.UniqueRefNo.Value.ToString();
                            RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);

                            //        RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.takipNoileRaporBilgisiKaydetSync(Sites.SiteLocalHost, this._PhysiotherapyRequest.GetTakipNoileRaporBilgisiKaydet(_PhysiotherapyRequest));
                            if (response != null)
                            {
                                //if (response.sonucKodu != null)
                                {
                                    if (response.sonucKodu.Equals(0))
                                    {
                                        if(response.raporlar!=null && response.raporlar.Length>0)
                                        {
                                            foreach (RaporIslemleri.raporCevapDVO raporCevapDVO in response.raporlar)
                                            {
                                                if (raporCevapDVO.tedaviRapor != null && raporCevapDVO.raporTuru == "1" && raporCevapDVO.tedaviRapor.tedaviRaporTuru == 5 || raporCevapDVO.tedaviRapor.tedaviRaporTuru == 7 || raporCevapDVO.tedaviRapor.tedaviRaporTuru == 3)
                                                {   
                                                        //if (raporCevapDVO.tedaviRapor.tedaviRaporTuru == 5 || raporCevapDVO.tedaviRapor.tedaviRaporTuru == 7 || raporCevapDVO.tedaviRapor.tedaviRaporTuru == 3)
                                                        //{
                                                            if (raporCevapDVO.raporTakipNo.ToString() == MedulaRaporTakipNo.Text)
                                                            {

                                                                TTObjectContext context = new TTObjectContext(false);
                                                                MedulaReportResult medulaReportResult = new MedulaReportResult(context);
                                                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                                                                medulaReportResult.ReportNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.no.ToString();
                                                                medulaReportResult.ReportRowNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                                                medulaReportResult.ReportChasingNo =  raporCevapDVO.raporTakipNo.ToString() ;
                                                                medulaReportResult.SendReportDate = Convert.ToDateTime(raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.tarih);
                                                                medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                                                medulaReportResult.PhysiotherapyOrder = this._PhysiotherapyRequest.PhysiotherapyOrders[0];
                                                                context.Save();
                                                            }
                                                       // }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                   {

                           throw;
                   }
                }
            }
        }
                    //                else
                    //                {
                    //                    TTObjectContext context = new TTObjectContext(false);
                    //                    MedulaReportResult medulaReportResult = new MedulaReportResult(context);
                    //                    medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                    //                    medulaReportResult.ResultCode = response.sonucKodu.ToString();
                    //                    medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                    //                    medulaReportResult.ReportNumber = "0";
                    //                    medulaReportResult.PhysiotherapyOrder = this._PhysiotherapyRequest.PhysiotherapyOrders[0];
                    //                    medulaReportResult.SendReportDate = DateTime.Now;
                    //                    context.Save();

                    //                    InfoBox.Alert("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi + " Rapor Takip Numarası Alınamamıştır. Raporunuzu servisten gelen sonuç mesajına göre düzeltiniz veya bir sonraki adımda düzenleyerek rapor servisine yeniden gönderiniz!!!");
                    //                    return;
                    //                }
                    //            }
                    //            else
                    //            {
                    //                if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                    //                {
                    //                    throw new TTException("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                    //                }

                    //            }
                    //        }
                    //    }
                    //    catch (Exception)
                    //    {

                    //        throw;
                    //    }
                    //}
                //}
            ///}
        //}           
        
        protected void FillInpatientLists(bool? ifCheckedInPatientsBed)
        {
            if (ifCheckedInPatientsBed == true)
            {
                Episode e = this._PhysiotherapyRequest.Episode.Patient.InpatientEpisode;
                if (e != null)
                {
                    this.Bed.SelectedObject = e.Bed;
                    if (e.Bed != null)
                    {
                        if (this._PhysiotherapyRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            this._PhysiotherapyRequest.InpatientBed = e.Bed;
                        this.Room.SelectedObject = e.Bed.Room;
                        if (e.Bed.Room != null)
                        {
                            this.RoomGroup.SelectedObject = e.Bed.Room.RoomGroup;
                            if (e.Bed.Room.RoomGroup != null)
                            {
                                this.PhysicalStateClinic.SelectedObject = e.Bed.Room.RoomGroup.Ward;
                                if (e.Bed.Room.RoomGroup.Ward != null)
                                {
                                    if (this._PhysiotherapyRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        this._PhysiotherapyRequest.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this._PhysiotherapyRequest.InpatientBed != null)
                        {
                            this.Bed.SelectedObject = this._PhysiotherapyRequest.InpatientBed;
                            this.Room.SelectedObject = this._PhysiotherapyRequest.InpatientBed.Room;
                            this.RoomGroup.SelectedObject = this._PhysiotherapyRequest.InpatientBed.Room.RoomGroup;
                            this.PhysicalStateClinic.SelectedObject = this._PhysiotherapyRequest.InpatientBed.Room.RoomGroup.Ward;
                        }
                    }
                }
                else
                {
                    if (this._PhysiotherapyRequest.InpatientBed != null)
                    {
                        this.Bed.SelectedObject = this._PhysiotherapyRequest.InpatientBed;
                        this.Room.SelectedObject = this._PhysiotherapyRequest.InpatientBed.Room;
                        this.RoomGroup.SelectedObject = this._PhysiotherapyRequest.InpatientBed.Room.RoomGroup;
                        this.PhysicalStateClinic.SelectedObject = this._PhysiotherapyRequest.InpatientBed.Room.RoomGroup.Ward;
                    }
                }
            }
            else
            {
                this.Bed.SelectedObject = null;
                this.Room.SelectedObject = null;
                this.RoomGroup.SelectedObject = null;
                this.PhysicalStateClinic.SelectedObject = null;
                this._PhysiotherapyRequest.SecondaryMasterResource = null;
                this._PhysiotherapyRequest.InpatientBed = null;

            }
        }
        
#endregion PhysiotherapyForm_Methods
    }
}