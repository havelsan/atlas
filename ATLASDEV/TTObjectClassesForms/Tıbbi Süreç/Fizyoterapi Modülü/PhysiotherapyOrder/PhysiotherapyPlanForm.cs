
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
    /// Fizyoterapi Planlama Formu
    /// </summary>
    public partial class PhysiotherapyPlanForm : BasePhysiotherapyOrderForm
    {
        override protected void BindControlEvents()
        {
            ttButtonRaporSorgu.Click += new TTControlEventDelegate(ttButtonRaporSorgu_Click);
            chkDisXXXXXXRaporu.CheckedChanged += new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            MedulaReportResults.CellContentClick += new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            TreatmentStartDateTime.ValueChanged += new TTControlEventDelegate(TreatmentStartDateTime_ValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttButtonRaporSorgu.Click -= new TTControlEventDelegate(ttButtonRaporSorgu_Click);
            chkDisXXXXXXRaporu.CheckedChanged -= new TTControlEventDelegate(chkDisXXXXXXRaporu_CheckedChanged);
            MedulaReportResults.CellContentClick -= new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            TreatmentStartDateTime.ValueChanged -= new TTControlEventDelegate(TreatmentStartDateTime_ValueChanged);
            base.UnBindControlEvents();
        }

        private void ttButtonRaporSorgu_Click()
        {
#region PhysiotherapyPlanForm_ttButtonRaporSorgu_Click
   MedulaRaporIslemleri medulaRaporIslemleri = new MedulaRaporIslemleri(this._EpisodeAction.GetCurrentAction().Episode.Patient);
            medulaRaporIslemleri.Show();
#endregion PhysiotherapyPlanForm_ttButtonRaporSorgu_Click
        }

        private void chkDisXXXXXXRaporu_CheckedChanged()
        {
#region PhysiotherapyPlanForm_chkDisXXXXXXRaporu_CheckedChanged
   if (((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked)
            {
                string tur=string.Empty;
                if(_PhysiotherapyOrder.PhysiotherapyRequest.Episode.Patient.UniqueRefNo == null)
                {
                    InfoBox.Show("Kişinin Sistemde Tanımlı Bir Kimlik Numarası Yoktur. İşlem Yapmadan Önce Kimlik Bilgilerini Güncelleyiniz!!!");
                    ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
                    return;
                }
                
                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                //TODO : MEDULA20140501
                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                
                
                if(((ITTComboBox)((TTVisual.TTComboBox)(cmbTedaviTuru))).SelectedItem==null)
                {
                    InfoBox.Show("Tedavi Türünü Seçiniz");
                    ((TTVisual.TTCheckBox)(chkDisXXXXXXRaporu)).Checked =false;
                    return;
                }
                if (!string.IsNullOrEmpty(((ITTComboBox)((TTVisual.TTComboBox)(cmbTedaviTuru))).SelectedItem.Value.ToString()))
                {
                    tur =((ITTComboBox)((TTVisual.TTComboBox)(cmbTedaviTuru))).SelectedItem.Value.ToString();
                    _raporOkuTCKimlikNodanDVO.raporTuru="1";
                }

                _raporOkuTCKimlikNodanDVO.tckimlikNo = _PhysiotherapyOrder.PhysiotherapyRequest.Episode.Patient.UniqueRefNo.Value.ToString();
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
                                                    multiSelectForm.AddMSItem("(Tarfik Kazası) Rapor Takip Numarası : " + item.raporTakipNo.ToString() + " Rapor Tarihi : " + item.tedaviRapor.raporDVO.raporBilgisi.tarih + " Rapor Türü : " + raporTuru + raporBilgileri, item.raporTakipNo.ToString());
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
                            if (!string.IsNullOrEmpty(mkey))
                            {
                                //  MedulaRaporTakipNo.Visible=true;
                                //  labelMedulaRaporTakipNo.Visible=true;
                                lblRaporBilgileri.Visible = true;
                                MedulaRaporBilgileri.Visible = true;
                                MedulaRaporTakipNoPhysiotherapyRequest.Text = mkey;

                                foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                                {
                                    if (mkey == item.raporTakipNo.ToString())
                                    {
                                        _PhysiotherapyOrder.PhysiotherapyRequest.ReportNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                        {
                                            raporTuru = item.tedaviRapor.raporDVO.duzenlemeTuru == "1" ? "Heyet Raporu" : "Tek Hekim Raporu";
                                            foreach (FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class fTRVucutBolgesi in fTRVucutBolgesiList)
                                            {
                                                if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedaviIslemBilgisiDVO.ftrRaporBilgisi.ftrVucutBolgesiKodu)
                                                {
                                                    if (item.tedaviRapor.tedaviRaporTuru == 7)
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
                                //  MedulaRaporTakipNo.Visible=false;
                                //  labelMedulaRaporTakipNo.Visible=false;
                                lblRaporBilgileri.Visible = false;
                                MedulaRaporBilgileri.Visible = false;
                                MedulaRaporTakipNoPhysiotherapyRequest.Text = "";
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
                    _PhysiotherapyOrder.PhysiotherapyRequest.ReportNo = null;
                    // MedulaRaporTakipNo.Visible=false;
                    // labelMedulaRaporTakipNo.Visible=false;
                    lblRaporBilgileri.Visible=false;
                    MedulaRaporBilgileri.Visible=false;
                    MedulaRaporTakipNoPhysiotherapyRequest.Text = "";
                    MedulaRaporBilgileri.Text = "";
                }
#endregion PhysiotherapyPlanForm_chkDisXXXXXXRaporu_CheckedChanged
        }

        private void MedulaReportResults_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region PhysiotherapyPlanForm_MedulaReportResults_CellContentClick

            //TODO:ShowEdit!
            //if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
            //{
            //    if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnMeduladanSil"))
            //    {
            //        ITTGridCell currentCell = MedulaReportResults.CurrentCell;
            //        if (currentCell != null)
            //        {
            //            ITTGridRow currentRow = currentCell.OwningRow;
            //            if (currentRow != null)
            //            {
            //                MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
            //                if (currentMedulaReportResult != null)
            //                {

            //                    if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
            //                    {
            //                        DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
            //                        if (dialogResult == DialogResult.OK)
            //                        {
            //                            try
            //                            {
            //                                RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
            //                                //TODO : MEDULA20140501
            //                                raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

            //                                RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
            //                                _raporOkuDVO.no = currentMedulaReportResult.ReportNumber;
            //                                _raporOkuDVO.raporSiraNo = currentMedulaReportResult.ReportRowNumber.ToString();
            //                                _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                                _raporOkuDVO.tarih = currentMedulaReportResult.SendReportDate.Value.ToString("dd.MM.yyyy");
            //                                _raporOkuDVO.turu = "1";
            //                                raporSorguDVO.raporBilgisi = _raporOkuDVO;

            //                                RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
            //                                if (response != null)
            //                                {
            //                                    //if (response.sonucKodu != null)
            //                                    {
            //                                        if (response.sonucKodu.Equals(0))
            //                                        {

            //                                            MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
            //                                            //medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Canceled;
            //                                            medulaReportResult.ResultCode = response.sonucKodu.ToString();
            //                                            medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                                            medulaReportResult.ReportChasingNo="";
            //                                            medulaReportResult.ReportNumber="";
            //                                            medulaReportResult.ReportRowNumber=null;
            //                                        }
            //                                        else
            //                                        {
            //                                            if (!string.IsNullOrEmpty(response.sonucAciklamasi))
            //                                            {
            //                                                MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
            //                                                medulaReportResult.ResultCode = response.sonucKodu.ToString();
            //                                                medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                                                InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
            //                                            }

            //                                        }
            //                                    }

            //                                }
            //                            }
            //                            catch (Exception ex)
            //                            {

            //                            }

            //                        }
            //                    }
            //                    else
            //                    {
            //                        InfoBox.Show("Medulaya Kayıtdı Yapılmamış Bir Fizik Tedavi Raporunu Meduladan Silemezsiniz!!!");
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            var a = 1;
#endregion PhysiotherapyPlanForm_MedulaReportResults_CellContentClick
        }

        private void TreatmentStartDateTime_ValueChanged()
        {
#region PhysiotherapyPlanForm_TreatmentStartDateTime_ValueChanged
   bool bayramMi = false;
            TTObjectContext context = new TTObjectContext(true);
            WorkDayExceptionDef wde = new WorkDayExceptionDef (context);
            BindingList<WorkDayExceptionDef.GetWorkDayExcesptionsQuery_Class> holidayList = TTObjectClasses.WorkDayExceptionDef.GetWorkDayExcesptionsQuery();
            foreach(WorkDayExceptionDef.GetWorkDayExcesptionsQuery_Class item in holidayList)
            {
                 if (item.Date != null)
                 {
                     if(item.Date.Value == _PhysiotherapyOrder.TreatmentStartDateTime.Value)
                       bayramMi = true;  
                 }
            }
            if(bayramMi)
            {
                _PhysiotherapyOrder.TreatmentStartDateTime = null;
                throw new TTUtils.TTException(_PhysiotherapyOrder.TreatmentStartDateTime.ToString() + " Resmi Tatil Günüdür.");
            }
#endregion PhysiotherapyPlanForm_TreatmentStartDateTime_ValueChanged
        }

        protected override void PreScript()
        {
#region PhysiotherapyPlanForm_PreScript
    base.PreScript();
            if (this._PhysiotherapyOrder.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
            {
                this.labelReasonOfRejection.Visible = false;
                this.ReasonOfRejection.Visible = false;
            }
            
            if(string.IsNullOrEmpty(_PhysiotherapyOrder.PhysiotherapyRequest.MedulaRaporTakipNo))
            {
                lblTedaviTuru.Visible = true;
                cmbTedaviTuru.Visible = true;
                chkDisXXXXXXRaporu.Visible = true;
            }
            
            if(Common.CurrentUser.Status == UserStatusEnum.SuperUser)
                MedulaRaporTakipNoPhysiotherapyRequest.ReadOnly = false;
            else
                MedulaRaporTakipNoPhysiotherapyRequest.ReadOnly = true;
            
            //DP gelistirme, PhysiotherapyRequest teki ProcedureDoctor alani  set edilecek.
            if ( this._PhysiotherapyOrder.PhysiotherapyRequest.ProcedureDoctor != null )
                this.ProcedureDoctor.SelectedObject = this._PhysiotherapyOrder.PhysiotherapyRequest.ProcedureDoctor;
            
//            if(this._PhysiotherapyOrder.SubEpisode.PatientAdmission.PatientGroup == PatientGroupEnum.CivilianConsignment )
//                chkPatientPay.Visible = true;
//            else
                chkPatientPay.Visible = false;
#endregion PhysiotherapyPlanForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region PhysiotherapyPlanForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if (transDef != null)
            {
                //if (transDef.ToStateDefID == PhysiotherapyOrder.States.Plan)
                //{
                //    BindingList<PhysiotherapyOrder> MySiblingObject = PhysiotherapyOrder.GetMySiblingObjectsForAppointment(this._PhysiotherapyOrder.ObjectContext, this._PhysiotherapyOrder.Episode.ObjectID.ToString(), this._PhysiotherapyOrder.ObjectID.ToString());
                //    if (MySiblingObject.Count > 0)
                //    {
                //        string result = "";
                //        if (TTObjectClasses.SystemParameter.GetParameterValue("ASKFORPLANALLORDERS", "TRUE") == "FALSE")
                //            result = "E";
                //        else
                //            result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Fizyoterapi Planlama", "Diğer Fizyoterapi Emirlerini de 'Planlama' adımına almak ister misiniz?");
                //        if (result == "E")
                //        {
                //            foreach (PhysiotherapyOrder physiotherapyOrder in MySiblingObject)
                //            {
                //                if (physiotherapyOrder.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception)
                //                    physiotherapyOrder.CurrentStateDefID = PhysiotherapyOrder.States.Plan;
                //            }
                //        }
                //    }
                //}
                //else if (transDef.FromStateDefID == PhysiotherapyOrder.States.RequestAcception && transDef.ToStateDefID == PhysiotherapyOrder.States.Therapy)
                //{
                //    string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Fizyoterapi Planlama", "Fizyoterapi Uygulamalarını, planlama yapmadan oluşturmak istediğinize emin misiniz?");
                //    if (result == "H")
                //        return;
                //    if (this._PhysiotherapyOrder.TreatmentRoom == null || this._PhysiotherapyOrder.TreatmentStartDateTime == null)
                //        throw new Exception("'Tedavi Odası' ve 'Tedavi Başlangıç Tarih Saati' ni seçiniz.");
                //    result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Fizyoterapi Planlama", "Fizyoterapi Uygulamaları," + this._PhysiotherapyOrder.TreatmentStartDateTime.Value.ToString("dd.MM.yyyy HH:mm") + " tarihinden itibaren " + this._PhysiotherapyOrder.Amount.ToString() + " gün boyunca oluşturulacak.\r\nİşlemi onaylıyor musunuz?");
                //    if (result == "H")
                //        return;
                //}
                
                //if(transDef.ToStateDefID != PhysiotherapyOrder.States.Rejected)
                //    CheckHasReport();
            }
#endregion PhysiotherapyPlanForm_ClientSidePostScript

        }

#region PhysiotherapyPlanForm_ClientSideMethods
        protected void CheckHasReport()
        {
            if (SubEpisode.IsSGKSubEpisode(_PhysiotherapyOrder.SubEpisode) == true)
            {
                if (string.IsNullOrEmpty(this._PhysiotherapyOrder.PhysiotherapyRequest.MedulaRaporTakipNo))
                {
                    if(this._PhysiotherapyOrder.PatientPay == null || this._PhysiotherapyOrder.PatientPay != true)
                    {
                        if(this._PhysiotherapyOrder.PhysiotherapyRequest.Episode.PatientStatus == PatientStatusEnum.Outpatient || this._PhysiotherapyOrder.PhysiotherapyRequest.Episode.PatientStatus == PatientStatusEnum.Discharge)
                            throw new Exception("Raporsuz Bu Adımı İlerletemezsiniz! ");
                        if(this._PhysiotherapyOrder.PhysiotherapyRequest.Episode.PatientStatus == PatientStatusEnum.Inpatient)
                        {
                            string result = "";
                            result = ShowBox.Show(ShowBoxTypeEnum.Message, "&amp;Evet,&amp;Hayır", "E,H", "Uyarı", "Fizyoterapi İstek", "Hastanın FTR Raporunu Eklemediniz. Devam Etmek İstiyor musunuz?");
                            if (result == "H")
                            {
                                throw new Exception("İşlemden Vazgeçildi.");
                            }
                        }
                    }
                }
            }
        }
        
#endregion PhysiotherapyPlanForm_ClientSideMethods
    }
}