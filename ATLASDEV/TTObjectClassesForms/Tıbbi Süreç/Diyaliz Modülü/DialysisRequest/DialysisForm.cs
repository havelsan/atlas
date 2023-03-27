
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
    /// Diyaliz İstek
    /// </summary>
    public partial class DialysisForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            chkDisXXXXXXRaporu.CheckedChanged += new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            chkInPatientBed.CheckedChanged += new TTControlEventDelegate(chkInPatientBed_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            chkDisXXXXXXRaporu.CheckedChanged -= new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            chkInPatientBed.CheckedChanged -= new TTControlEventDelegate(chkInPatientBed_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void chkDisXXXXXXRaporu_CheckedChanged()
        {
#region DialysisForm_chkDisXXXXXXRaporu_CheckedChanged
   if (((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked)
            {
                if(this._DialysisRequest.Episode.Patient.UniqueRefNo == null && this._DialysisRequest.Episode.Patient.YUPASSNO == null)
                {
                    InfoBox.Show("Kişinin Sistemde Tanımlı Bir Kimlik Numarası Yoktur. İşlem Yapmadan Önce Kimlik Bilgilerini Güncelleyiniz!!!");
                    ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked=false;
                    return;
                }
                
                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                //TODO : MEDULA20140501
                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                
                if (((TTVisual.TTCheckBox)(HomeDialysis)).Checked)
                {
                    _raporOkuTCKimlikNodanDVO.raporTuru = "1";
                }
                else
                {
                    _raporOkuTCKimlikNodanDVO.raporTuru ="1";
                }
                
                if(this._DialysisRequest.Episode.Patient.YUPASSNO != null)
                    _raporOkuTCKimlikNodanDVO.tckimlikNo = this._DialysisRequest.Episode.Patient.YUPASSNO.Value.ToString();
                else
                    _raporOkuTCKimlikNodanDVO.tckimlikNo = this._DialysisRequest.Episode.Patient.UniqueRefNo.Value.ToString();
                
                RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
                
                if (response != null)
                {
                    if (!response.sonucKodu.Equals(0))
                    {
                        InfoBox.Show("Sonuc Açıklaması : " + response.sonucAciklamasi + " Sonuç Kodu :" + response.sonucKodu);
                        ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked=false;
                        return;
                    }
                    if (response.raporlar ==null)
                    {
                        InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
                        ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked=false;
                        return;
                    }
                    if(response.sonucKodu.Equals(0))
                    {
                        if(response.raporlar!=null && response.raporlar.Length>0)
                        {
                            bool isValid=false;
                            MultiSelectForm multiSelectForm = new MultiSelectForm();
                            int raporAdedi = response.raporlar.Length;
                            for (int i = response.raporlar.Length - 1 ; i >= 0 ; i--)
                            {
                                //                                foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                                //                                {
                                if (response.raporlar[i].tedaviRapor != null)
                                {
                                    string raporBilgileri = string.Empty;
                                    if(response.raporlar[i].tedaviRapor.tedaviRaporTuru==1 || response.raporlar[i].tedaviRapor.tedaviRaporTuru==8)
                                    {
                                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in response.raporlar[i].tedaviRapor.islemler)
                                        {
                                            raporBilgileri += " Seans Sayısı :" +tedaviIslemBilgisiDVO.diyalizRaporBilgisi.seansSayi.ToString();
                                        }
                                        isValid=true;

                                        multiSelectForm.AddMSItem("Rapor Takip Numarası : " +"(" + i + ") " + response.raporlar[i].raporTakipNo.ToString() + " Rapor Tarihi : " + response.raporlar[i].tedaviRapor.raporDVO.raporBilgisi.tarih + raporBilgileri, response.raporlar[i].raporTakipNo.ToString());
                                        // multiSelectForm.AddMSItem("Rapor Takip Numarası : " +item.raporTakipNo.ToString() +" Rapor Tarihi : "+ item.tedaviRapor.raporDVO.raporBilgisi.tarih,item.raporTakipNo.ToString()+":"+item.tedaviRapor.raporDVO.raporBilgisi.no + raporBilgileri);
                                    }
                                }
                                //}
                            }
        
                           string mkey = multiSelectForm.GetMSItem(null, "İlgili Raporu Seçiniz", true);
                            if(isValid)
                            {
                                if (string.IsNullOrEmpty(mkey) && mkey!=":")
                                {
                                    InfoBox.Show("İlgili raporu seçmeden işleme devam edemezsiniz.");
                                    return;
                                }
                                string raporTakipNo = multiSelectForm.MSSelectedItemObject as string;
                            }
                            else
                            {
                                InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
                                ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked=false;
                                return;
                            }
                            if (!string.IsNullOrEmpty(mkey) && mkey != ":")
                            {
                                MedulaRaporTakipNo.Visible=true;
                                labelMedulaRaporTakipNo.Visible=true;
                                lblRaporBilgileri.Visible=true;
                                MedulaRaporBilgileri.Visible=true;
                                MedulaRaporTakipNo.Text=mkey;

                                string[] _values = mkey.Split(':');
                                
                                MedulaRaporTakipNo.Text=_values[0];
                                // this._DialysisRequest.MedulaNo=_values[1]!=null?_values[1]:"";
                                
                                foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                                {
                                    if (mkey == item.raporTakipNo.ToString())
                                    {
                                        _DialysisRequest.ReportNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                        {
                                            MedulaRaporBilgileri.Text  +=" Rapor No :" + item.tedaviRapor.raporDVO.raporBilgisi.no.ToString() + " Seans Sayısı :" +tedaviIslemBilgisiDVO.diyalizRaporBilgisi.seansSayi.ToString();
                                        }
                                        this._DialysisRequest.MedulaNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
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
                            InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
                            ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked=false;
                            return;
                        }
                    }
                }
            }
            else
            {
                _DialysisRequest.ReportNo = null;
                MedulaRaporTakipNo.Visible=false;
                labelMedulaRaporTakipNo.Visible=false;
                lblRaporBilgileri.Visible=false;
                MedulaRaporBilgileri.Visible=false;
                MedulaRaporTakipNo.Text="";
                MedulaRaporBilgileri.Text = "";
            }
#endregion DialysisForm_chkDisXXXXXXRaporu_CheckedChanged
        }

        private void chkInPatientBed_CheckedChanged()
        {
#region DialysisForm_chkInPatientBed_CheckedChanged
   FillInpatientLists(this.chkInPatientBed.Value);
#endregion DialysisForm_chkInPatientBed_CheckedChanged
        }

        protected override void PreScript()
        {
#region DialysisForm_PreScript
    base.PreScript();
    
    ((TTVisual.TTCheckBox)(HomeDialysis)).Checked=false;
    
            if (this._DialysisRequest.CurrentStateDefID == DialysisRequest.States.Request)
            {
                this.labelProtocolNo.Visible = false;
                this.ProtocolNo.Visible = false;
            }
            else
            {
                this.labelProtocolNo.Visible = true;
                this.ProtocolNo.Visible = true;
            }
            this.cmdOK.Visible = false;
            this.SetProcedureDoctorAsCurrentResource();

            if (this._DialysisRequest.Episode.Patient.InpatientEpisode == null && this._DialysisRequest.InPatientsBed == false)
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
            FillInpatientLists(this.chkInPatientBed.Value);
            
            // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
#endregion DialysisForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DialysisForm_PostScript
    base.PostScript(transDef);
           
            // bakilacak CKE
             this.CheckDiagnosisOzelDurums();
            
            if (transDef != null && transDef.ToStateDefID != DialysisRequest.States.Cancelled)
            {

                if (_DialysisRequest.Episode.Diagnosis.Count <= 0)
                {
                    if (_DialysisRequest.Diagnosis.Count <= 0)
                        throw new Exception(SystemMessage.GetMessage(635));
                }

            }
#endregion DialysisForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region DialysisForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(SubEpisode.IsSGKSubEpisode(_DialysisRequest.SubEpisode) ==true)
            {
                bool raporZorunluMu = true;
                if (string.IsNullOrEmpty(_DialysisRequest.MedulaRaporTakipNo))
                {
                    foreach(DiagnosisGrid diagnosisGrid in _DialysisRequest.Episode.Diagnosis)
                    {
                        if (diagnosisGrid.Diagnose.DialysisReportNotMust == true)
                            raporZorunluMu = false;
                    }
                    if(raporZorunluMu == true)
                    {
                        if(_DialysisRequest.Episode.PatientStatus == PatientStatusEnum.Outpatient || _DialysisRequest.Episode.PatientStatus == PatientStatusEnum.Discharge)
                            throw new Exception("Diyaliz Raporu Girmeniz Gerekmektedir ! ");
                        
                        if(_DialysisRequest.Episode.PatientStatus == PatientStatusEnum.Inpatient)
                        {
                            string result = "";
                            result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Diyaliz İstek", "Hastanın Diyaliz Raporunu Eklemediniz. Devam Etmek İstiyor musunuz?");
                            if (result == "H")
                            {
                                throw new Exception("İşlemden Vazgeçildi.");
                            }
                        }
                    }
                }
            }
#endregion DialysisForm_ClientSidePostScript

        }

#region DialysisForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if(!string.IsNullOrEmpty(MedulaRaporTakipNo.Text))
                {
                    //                    TTObjectContext context = new TTObjectContext(false);
                    //                    MedulaReportResult medulaReportResult = new MedulaReportResult(context);
                    //                    medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                    //                    medulaReportResult.ReportNumber =  this._DialysisRequest.MedulaNo;
                    //                    medulaReportResult.ReportRowNumber = 0;
                    //                    medulaReportResult.ReportChasingNo = MedulaRaporTakipNo.Text;
                    //                    medulaReportResult.SendReportDate = DateTime.Now;
                    //                    medulaReportResult.ResultCode="0";
                    //                    medulaReportResult.ResultExplanation = "Rapor Takip Numarası Dış XXXXXX Tarafından Verilmiştir!!!";
                    //                    medulaReportResult.DialysisOrder=this._DialysisRequest.DialysisOrders[0];
                    //                    context.Save();
                    //                }
                    //                else
                    //                {
                    if (this._DialysisRequest.SubEpisode!=null && this._DialysisRequest.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._DialysisRequest.SubEpisode.SGKSEP.MedulaTakipNo))
                    {
                        try
                        {   
                            if (!string.IsNullOrEmpty(MedulaRaporTakipNo.Text))
                            {
                                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                                //TODO : MEDULA20140501
                                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                _raporOkuTCKimlikNodanDVO.raporTuru = "1";
                                _raporOkuTCKimlikNodanDVO.tckimlikNo = (this._DialysisRequest.Episode.Patient.YUPASSNO == null) ? this._DialysisRequest.Episode.Patient.UniqueRefNo.Value.ToString(): this._DialysisRequest.Episode.Patient.YUPASSNO.Value.ToString();
                                RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
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
                                                    if (raporCevapDVO.tedaviRapor != null && raporCevapDVO.raporTuru == "1" && raporCevapDVO.tedaviRapor.tedaviRaporTuru == 1 || raporCevapDVO.tedaviRapor.tedaviRaporTuru == 8)
                                                    {
                                                        if (raporCevapDVO.raporTakipNo.ToString() == MedulaRaporTakipNo.Text)
                                                        {
                                                            TTObjectContext context = new TTObjectContext(false);
                                                            MedulaReportResult medulaReportResult = new MedulaReportResult(context);
                                                            medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                                                            medulaReportResult.ReportNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.no.ToString();
                                                            medulaReportResult.ReportRowNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                                            medulaReportResult.ReportChasingNo = raporCevapDVO.raporTakipNo.ToString();
                                                            medulaReportResult.SendReportDate = Convert.ToDateTime(raporCevapDVO.tedaviRapor.raporDVO.baslangicTarihi);
                                                            medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                                            medulaReportResult.DialysisOrder = this._DialysisRequest.DialysisOrders[0];
                                                            context.Save();
                                                        }
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
        }
        
        protected void FillInpatientLists(bool? ifCheckedInPatientsBed)
        {
            if (ifCheckedInPatientsBed == true)
            {
                Episode e = this._DialysisRequest.Episode.Patient.InpatientEpisode;
                if (e != null)
                {
                    this.Bed.SelectedObject = e.Bed;
                    if (e.Bed != null)
                    {
                        if (this._DialysisRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            this._DialysisRequest.InpatientBed = e.Bed;
                        this.Room.SelectedObject = e.Bed.Room;
                        if (e.Bed.Room != null)
                        {
                            this.RoomGroup.SelectedObject = e.Bed.Room.RoomGroup;
                            if (e.Bed.Room.RoomGroup != null)
                            {
                                this.PhysicalStateClinic.SelectedObject = e.Bed.Room.RoomGroup.Ward;
                                if (e.Bed.Room.RoomGroup.Ward != null)
                                {
                                    if (this._DialysisRequest.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                                        this._DialysisRequest.SecondaryMasterResource = e.Bed.Room.RoomGroup.Ward;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this._DialysisRequest.InpatientBed != null)
                        {
                            this.Bed.SelectedObject = this._DialysisRequest.InpatientBed;
                            this.Room.SelectedObject = this._DialysisRequest.InpatientBed.Room;
                            this.RoomGroup.SelectedObject = this._DialysisRequest.InpatientBed.Room.RoomGroup;
                            this.PhysicalStateClinic.SelectedObject = this._DialysisRequest.InpatientBed.Room.RoomGroup.Ward;
                        }
                    }
                }
                else
                {
                    if (this._DialysisRequest.InpatientBed != null)
                    {
                        this.Bed.SelectedObject = this._DialysisRequest.InpatientBed;
                        this.Room.SelectedObject = this._DialysisRequest.InpatientBed.Room;
                        this.RoomGroup.SelectedObject = this._DialysisRequest.InpatientBed.Room.RoomGroup;
                        this.PhysicalStateClinic.SelectedObject = this._DialysisRequest.InpatientBed.Room.RoomGroup.Ward;
                    }
                }
            }
            else
            {
                this.Bed.SelectedObject = null;
                this.Room.SelectedObject = null;
                this.RoomGroup.SelectedObject = null;
                this.PhysicalStateClinic.SelectedObject = null;
                this._DialysisRequest.SecondaryMasterResource = null;
                this._DialysisRequest.InpatientBed = null;

            }
        }
        
#endregion DialysisForm_Methods
    }
}