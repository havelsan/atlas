
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
    /// Hiperbarik Oksijen Tedavisi İstek
    /// </summary>
    public partial class HyperbarikOxygenTreatmentForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            chkDisXXXXXXRaporu.CheckedChanged += new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            chkDisXXXXXXRaporu.CheckedChanged -= new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void chkDisXXXXXXRaporu_CheckedChanged()
        {
#region HyperbarikOxygenTreatmentForm_chkDisXXXXXXRaporu_CheckedChanged
   if (((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked)
            {
                
                if(this._HyperbarikOxygenTreatmentRequest.Episode.Patient.UniqueRefNo == null && this._HyperbarikOxygenTreatmentRequest.Episode.Patient.YUPASSNO == null)
                {
                    InfoBox.Show("Kişinin Sistemde Tanımlı Bir Kimlik Numarası Yoktur. İşlem Yapmadan Önce Kimlik Bilgilerini Güncelleyiniz!!!");
                    ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
                    return;
                }
                
                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                //TODO : MEDULA20140501
                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                
                _raporOkuTCKimlikNodanDVO.raporTuru="1";
                
                if(this._HyperbarikOxygenTreatmentRequest.Episode.Patient.YUPASSNO != null)
                    _raporOkuTCKimlikNodanDVO.tckimlikNo = this._HyperbarikOxygenTreatmentRequest.Episode.Patient.YUPASSNO.Value.ToString();
                else
                    _raporOkuTCKimlikNodanDVO.tckimlikNo = this._HyperbarikOxygenTreatmentRequest.Episode.Patient.UniqueRefNo.Value.ToString();
                
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
                            MultiSelectForm multiSelectForm = new MultiSelectForm();
                            foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                            {
                                if (item.tedaviRapor != null)
                                {
                                    string raporBilgileri = string.Empty;
                                    if(item.tedaviRapor.tedaviRaporTuru==2  )
                                    {
                                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                        {
                                            raporBilgileri += " Seans Sayısı :" +tedaviIslemBilgisiDVO.hotRaporBilgisi.seansSayi.ToString() + " Tedavi Süresi : " + tedaviIslemBilgisiDVO.hotRaporBilgisi.tedaviSuresi.ToString();
                                        }
                                        isValid=true;
                                        multiSelectForm.AddMSItem("Rapor Takip Numarası : " +item.raporTakipNo.ToString() +" Rapor Tarihi : "+ item.tedaviRapor.raporDVO.raporBilgisi.tarih + raporBilgileri,item.raporTakipNo.ToString());
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
                                
                                foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                                {
                                    if (mkey == item.raporTakipNo.ToString())
                                    {
                                        _HyperbarikOxygenTreatmentRequest.ReportNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                        {
                                            MedulaRaporBilgileri.Text  +=" Rapor No :" + item.tedaviRapor.raporDVO.raporBilgisi.no.ToString() + " Seans Sayısı :" +tedaviIslemBilgisiDVO.hotRaporBilgisi.seansSayi.ToString() + " Tedavi Süresi :" + tedaviIslemBilgisiDVO.hotRaporBilgisi.tedaviSuresi.ToString();
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
                            InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
                            ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
                            return;
                        }
                    }
                }
            }
            else
            {
                _HyperbarikOxygenTreatmentRequest.ReportNo = null;
                MedulaRaporTakipNo.Visible=false;
                labelMedulaRaporTakipNo.Visible=false;
                lblRaporBilgileri.Visible=false;
                MedulaRaporBilgileri.Visible=false;
                MedulaRaporTakipNo.Text="";
                MedulaRaporBilgileri.Text = "";
            }
#endregion HyperbarikOxygenTreatmentForm_chkDisXXXXXXRaporu_CheckedChanged
        }

        protected override void PreScript()
        {
#region HyperbarikOxygenTreatmentForm_PreScript
    base.PreScript();

            if (this.History.Text.Equals("")) {
                this.History.Text+= "COHb                             : " + System.Environment.NewLine;
                this.History.Text+= "GEBELİK DURUMU       : " + System.Environment.NewLine;
                this.History.Text+= "NÖROLOJİK DURUM    :  SENKOP : " + System.Environment.NewLine;
                this.History.Text+= "                                          KOOPERASYON : " + System.Environment.NewLine;
                this.History.Text+= "                                          ORYANTASYON  " + System.Environment.NewLine;
                this.History.Text+= "EKG                               : " + System.Environment.NewLine;
                this.History.Text+= "KARDİAK ENZİMLER    :  CK-MB : " + System.Environment.NewLine;
                this.History.Text+= "                                          TROPONIN T : " + System.Environment.NewLine;
                this.History.Text+= "AKCİĞER MUAYENESİ : " + System.Environment.NewLine;
            }

            if (this._HyperbarikOxygenTreatmentRequest.CurrentStateDefID == HyperbarikOxygenTreatmentRequest.States.Request)
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
            
            
            //DP isleri icin SetProcedureDoctorAsCurrentResource kullanildi, asagidaki blok commentlendi.
            //if (this.ProcedureDoctor.SelectedObject == null)
            //    if (Common.CurrentResource.UserType == UserTypeEnum.Doctor)
            //    this.ProcedureDoctor.SelectedObject = Common.CurrentResource;
            
           this.SetProcedureDoctorAsCurrentResource();
            
            // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
#endregion HyperbarikOxygenTreatmentForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HyperbarikOxygenTreatmentForm_PostScript
    base.PostScript(transDef);

           this.CheckDiagnosisOzelDurums();
            
            if (transDef != null && transDef.ToStateDefID != HyperbarikOxygenTreatmentRequest.States.Cancelled)
            {
                if (_HyperbarikOxygenTreatmentRequest.Episode.Diagnosis.Count <= 0)
                {
                    if (_HyperbarikOxygenTreatmentRequest.Diagnosis.Count <= 0)
                        throw new Exception(SystemMessage.GetMessage(635));
                }
            }
#endregion HyperbarikOxygenTreatmentForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HyperbarikOxygenTreatmentForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if (string.IsNullOrEmpty(_HyperbarikOxygenTreatmentRequest.MedulaRaporTakipNo))
            {
                string result = "";
                result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Hiperbarik Oksijen Tedavisi İstek", "Hastanın Hiperbarik Oksijen Tedavisi Raporunu Eklemediniz. Devam Etmek İstiyor musunuz?");
                if (result == "H")
                {
                    throw new Exception("İşlemden Vazgeçildi.");
                }
            }
#endregion HyperbarikOxygenTreatmentForm_ClientSidePostScript

        }

#region HyperbarikOxygenTreatmentForm_Methods
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
                    //                    medulaReportResult.ReportNumber =  "";
                    //                    medulaReportResult.ReportRowNumber = 0;
                    //                    medulaReportResult.ReportChasingNo = MedulaRaporTakipNo.Text;
                    //                    medulaReportResult.SendReportDate = DateTime.Now;
                    //                    medulaReportResult.ResultCode="0";
                    //                    medulaReportResult.ResultExplanation = "Rapor Takip Numarası Dış XXXXXX Tarafından Verilmiştir!!!";
                    //                    medulaReportResult.HOTOrder = this._HyperbarikOxygenTreatmentRequest.HyperbaricOxygenTreatmentOrders[0];
                    //                    context.Save();
                    if (this._HyperbarikOxygenTreatmentRequest.SubEpisode != null && this._HyperbarikOxygenTreatmentRequest.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._HyperbarikOxygenTreatmentRequest.SubEpisode.SGKSEP.MedulaTakipNo))
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(MedulaRaporTakipNo.Text))
                            {
                                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                                //TODO : MEDULA20140501
                                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                _raporOkuTCKimlikNodanDVO.raporTuru = "1";
                                _raporOkuTCKimlikNodanDVO.tckimlikNo = this._HyperbarikOxygenTreatmentRequest.Episode.Patient.UniqueRefNo.Value.ToString();
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
                                                    if (raporCevapDVO.tedaviRapor != null && raporCevapDVO.raporTuru == "1" && raporCevapDVO.tedaviRapor.tedaviRaporTuru == 2 )
                                                    {
                                                        if (raporCevapDVO.raporTakipNo.ToString() == MedulaRaporTakipNo.Text)
                                                        {
                                                            TTObjectContext context = new TTObjectContext(false);
                                                            MedulaReportResult medulaReportResult = new MedulaReportResult(context);
                                                            medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                                                            medulaReportResult.ReportNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.no.ToString();
                                                            medulaReportResult.ReportRowNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                                            medulaReportResult.ReportChasingNo = raporCevapDVO.raporTakipNo.ToString() ;
                                                            medulaReportResult.SendReportDate = Convert.ToDateTime(raporCevapDVO.tedaviRapor.raporDVO.baslangicTarihi);
                                                            medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                                            medulaReportResult.HOTOrder = this._HyperbarikOxygenTreatmentRequest.HyperbaricOxygenTreatmentOrders[0];
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
            
            Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> reportNoParam = new TTReportTool.PropertyCache<object>();
            reportNoParam.Add("VALUE", this._HyperbarikOxygenTreatmentRequest.ObjectID);
            parameter.Add("TTOBJECTID", reportNoParam);
            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HyperbaricOxygenRequestReport), true, 1, parameter);
        }
        
#endregion HyperbarikOxygenTreatmentForm_Methods
    }
}