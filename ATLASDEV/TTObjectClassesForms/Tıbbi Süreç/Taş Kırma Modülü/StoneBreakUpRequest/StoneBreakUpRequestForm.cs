
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
    /// Taş Kırma
    /// </summary>
    public partial class StoneBreakUpRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            chkRaporuVar.CheckedChanged += new TTControlEventDelegate(chkRaporuVar_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            chkRaporuVar.CheckedChanged -= new TTControlEventDelegate(chkRaporuVar_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void chkRaporuVar_CheckedChanged()
        {
#region StoneBreakUpRequestForm_chkRaporuVar_CheckedChanged
   if (((TTVisual.TTCheckBox)(chkRaporuVar)).Checked)
            {
                string tur=string.Empty;
                if(this._StoneBreakUpRequest.Episode.Patient.UniqueRefNo == null)
                {
                    InfoBox.Show("Kişinin Sistemde Tanımlı Bir Kimlik Numarası Yoktur. İşlem Yapmadan Önce Kimlik Bilgilerini Güncelleyiniz!!!");
                    ((TTVisual.TTCheckBox)(chkRaporuVar)).Checked = false;
                    return;
                }
                
                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                //TODO : MEDULA20140501
                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _raporOkuTCKimlikNodanDVO.raporTuru="1";
                _raporOkuTCKimlikNodanDVO.tckimlikNo = this._StoneBreakUpRequest.Episode.Patient.UniqueRefNo.Value.ToString();
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
                        ((TTVisual.TTCheckBox)(chkRaporuVar)).Checked =false;
                        return;
                    }
                    if(response.sonucKodu.Equals(0))
                    {
                        if(response.raporlar!=null && response.raporlar.Length>0)
                        {
                            bool isValid=false;
                            
                            IList tasLokalizasyonList =TasLokalizasyon.GetTasLokalizasyonQuery();
                            IList bobrekBilgisiList = Bobrek.GetBobrekQuery();
                            MultiSelectForm multiSelectForm = new MultiSelectForm();
                            foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                            {
                                if (item.tedaviRapor != null)
                                {
                                  //  string raporBilgileri = string.Empty;
                                   
                                        if(item.tedaviRapor.tedaviRaporTuru==6 )
                                        {
                                            isValid=true;
                                            foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                            {
                                                foreach (Bobrek.GetBobrekQuery_Class bobrekBilgisi in bobrekBilgisiList)
                                                {
                                                     string raporBilgileri = string.Empty;
                                                    if (bobrekBilgisi.bobrekKodu == tedaviIslemBilgisiDVO.eswlRaporBilgisi.bobrekBilgisi)
                                                    {
                                                        raporBilgileri +="Böbrek :" + bobrekBilgisi.bobrekAdi.ToString() + " Taş Sayısı :" +tedaviIslemBilgisiDVO.eswlRaporBilgisi.eswlRaporuTasSayisi + " Seans :" + tedaviIslemBilgisiDVO.eswlRaporBilgisi.eswlRaporuSeansSayisi;
                                                        foreach(RaporIslemleri.eswlTasBilgisiDVO eSWLTasBilgisiDVO in tedaviIslemBilgisiDVO.eswlRaporBilgisi.eswlRaporuTasBilgileri)
                                                        {
                                                            foreach(TasLokalizasyon.GetTasLokalizasyonQuery_Class tasLokalizasyon in tasLokalizasyonList)
                                                            {
                                                                if(eSWLTasBilgisiDVO.tasLokalizasyonKodu ==tasLokalizasyon.tasLokalizasyonKodu)
                                                                       raporBilgileri+= " Localizasyon :" +tasLokalizasyon.tasLokalizasyonAdi + "Taş Boyutu :" + eSWLTasBilgisiDVO.tasBoyutu ;
                                                            }
                                                        }
                                                        multiSelectForm.AddMSItem("Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih  + raporBilgileri, item.raporTakipNo.ToString());
                                                    }
                                                }
                                            }
                                          //  multiSelectForm.AddMSItem("Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih  + raporBilgileri, item.raporTakipNo.ToString());
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
                                ((TTVisual.TTCheckBox)(chkRaporuVar)).Checked =false;
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
                                        _StoneBreakUpRequest.ReportNo = item.tedaviRapor.raporDVO.raporBilgisi.no;

                                          foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                            {
                                                foreach (Bobrek.GetBobrekQuery_Class bobrekBilgisi in bobrekBilgisiList)
                                                {
                                                    if (bobrekBilgisi.bobrekKodu == tedaviIslemBilgisiDVO.eswlRaporBilgisi.bobrekBilgisi)
                                                    {
                                                        MedulaRaporBilgileri.Text +="Böbrek :" + bobrekBilgisi.bobrekAdi.ToString() + " Taş Sayısı :" +tedaviIslemBilgisiDVO.eswlRaporBilgisi.eswlRaporuTasSayisi + " Seans :" + tedaviIslemBilgisiDVO.eswlRaporBilgisi.eswlRaporuSeansSayisi;
                                                        foreach(RaporIslemleri.eswlTasBilgisiDVO eSWLTasBilgisiDVO in tedaviIslemBilgisiDVO.eswlRaporBilgisi.eswlRaporuTasBilgileri)
                                                        {
                                                            foreach(TasLokalizasyon.GetTasLokalizasyonQuery_Class tasLokalizasyon in tasLokalizasyonList)
                                                            {
                                                                if(eSWLTasBilgisiDVO.tasLokalizasyonKodu ==tasLokalizasyon.tasLokalizasyonKodu)
                                                                       MedulaRaporBilgileri.Text+= " Localizasyon :" +tasLokalizasyon.tasLokalizasyonAdi + "Taş Boyutu :" + eSWLTasBilgisiDVO.tasBoyutu ;
                                                            }
                                                        }
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
                            InfoBox.Show("Kişinin Dış XXXXXX Rapor Bilgisi Bulunamamıştır.");
                            ((TTVisual.TTCheckBox)(chkRaporuVar)).Checked =false;
                            return;
                        }
                    }
                }
            }
            else
            {
                _StoneBreakUpRequest.ReportNo = null;
                MedulaRaporTakipNo.Visible=false;
                labelMedulaRaporTakipNo.Visible=false;
                lblRaporBilgileri.Visible=false;
                MedulaRaporBilgileri.Visible=false;
                MedulaRaporTakipNo.Text="";
                MedulaRaporBilgileri.Text = "";
            }
#endregion StoneBreakUpRequestForm_chkRaporuVar_CheckedChanged
        }

        protected override void PreScript()
        {
#region StoneBreakUpRequestForm_PreScript
    base.PreScript();     
            this.SetProcedureDoctorAsCurrentResource();
#endregion StoneBreakUpRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region StoneBreakUpRequestForm_PostScript
    base.PostScript(transDef);
            int count=this._StoneBreakUpRequest.StoneBreakUpProcedures.Count;
            
            if(count==0)
                throw new Exception(SystemMessage.GetMessage(973));
            else if(count>1)
                throw new Exception(SystemMessage.GetMessage(974));
            
            foreach(StoneBreakUpProcedure stoneBreakUpProcedure in this._StoneBreakUpRequest.StoneBreakUpProcedures)
            {
                StoneBreakUpProcedure.SetProcedureObject(Common.RecTime(), stoneBreakUpProcedure);
                StoneBreakUpProcedure.CreateStoneBreakUpPackageProcedure(stoneBreakUpProcedure);
            }
            
            if(SubEpisode.IsSGKSubEpisode(_StoneBreakUpRequest.SubEpisode) == true)
            {
                if (string.IsNullOrEmpty(_StoneBreakUpRequest.MedulaRaporTakipNo))
                {
                    throw new Exception("Taş Kırma Raporunu Eklemediniz. Devam Edemezsiniz !!!");
                    
                    //                string result = "";
                    //                result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Taş Kırma İstek", "Taş Kırma Raporunu Eklemediniz. Devam Etmek İstiyor musunuz?");
                    //                if (result == "H")
                    //                {
                    //                    throw new Exception("İşlemden Vazgeçildi.");
                    //                }
                }
            }
#endregion StoneBreakUpRequestForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region StoneBreakUpRequestForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef.ToStateDef.Status!= StateStatusEnum.Cancelled)
            {
                this._StoneBreakUpRequest.IsPatientApprovalFormGiven= this.GetIfPatientApprovalFormIsGiven(this._StoneBreakUpRequest.IsPatientApprovalFormGiven);
            }
#endregion StoneBreakUpRequestForm_ClientSidePostScript

        }

#region StoneBreakUpRequestForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if (this._StoneBreakUpRequest.SubEpisode != null && this._StoneBreakUpRequest.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._StoneBreakUpRequest.SubEpisode.SGKSEP.MedulaTakipNo))
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(MedulaRaporTakipNo.Text))
                        {
                            RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                            //TODO : MEDULA20140501
                            _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                            _raporOkuTCKimlikNodanDVO.raporTuru = "1";
                            _raporOkuTCKimlikNodanDVO.tckimlikNo = this._StoneBreakUpRequest.Episode.Patient.UniqueRefNo.Value.ToString();
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
                                            IList  medulaReportResultList =MedulaReportResult.MedulaRaportResultQuery();
                                            foreach (RaporIslemleri.raporCevapDVO raporCevapDVO in response.raporlar)
                                            {
                                                if (raporCevapDVO.tedaviRapor != null && raporCevapDVO.raporTuru == "1" && raporCevapDVO.tedaviRapor.tedaviRaporTuru == 6)
                                                {
                                                        if (raporCevapDVO.raporTakipNo.ToString() == MedulaRaporTakipNo.Text)
                                                        {
                                                           bool raporEklenmis = false; 
                                                            foreach (MedulaReportResult.MedulaRaportResultQuery_Class medulaReport in medulaReportResultList)
                                                            {
                                                                if (medulaReport.StoneBreakUpRequest == this._StoneBreakUpRequest.ObjectID)
                                                                {
                                                                    TTObjectContext context = _StoneBreakUpRequest.ObjectContext;
                                                                    MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(medulaReport.ObjectID.Value, typeof(MedulaReportResult));
                                                                    medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                                                                    medulaReportResult.ReportNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.no.ToString();
                                                                    medulaReportResult.ReportRowNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                                                    medulaReportResult.ReportChasingNo = raporCevapDVO.raporTakipNo.ToString() ;
                                                                    medulaReportResult.SendReportDate = Convert.ToDateTime(raporCevapDVO.tedaviRapor.raporDVO.baslangicTarihi);
                                                                    medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                                                    medulaReportResult.StoneBreakUpRequest = this._StoneBreakUpRequest;
                                                                    context.Save();
                                                                    raporEklenmis = true;
                                                                }
                                                            }
                                                            if(raporEklenmis ==false)
                                                            {
                                                                    TTObjectContext context = new TTObjectContext(false);
                                                                    MedulaReportResult medulaReportResult = new MedulaReportResult(context);
                                                                    medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                                                                    medulaReportResult.ReportNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.no.ToString();
                                                                    medulaReportResult.ReportRowNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                                                    medulaReportResult.ReportChasingNo = raporCevapDVO.raporTakipNo.ToString() ;
                                                                    medulaReportResult.SendReportDate = Convert.ToDateTime(raporCevapDVO.tedaviRapor.raporDVO.baslangicTarihi);
                                                                    medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                                                    medulaReportResult.StoneBreakUpRequest = this._StoneBreakUpRequest;
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
                    }
                    catch (Exception)
                   {
                           throw;
                   }
                }
            }
        }
        
#endregion StoneBreakUpRequestForm_Methods
    }
}