
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
    /// Hiperbarik Oksijen Tedavi Planlama Formu
    /// </summary>
    public partial class HyperbaricOxygenTreatmentPlanForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnMedulayaKaydet.Click += new TTControlEventDelegate(btnMedulayaKaydet_Click);
            MedulaReportResults.CellContentClick += new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnMedulayaKaydet.Click -= new TTControlEventDelegate(btnMedulayaKaydet_Click);
            MedulaReportResults.CellContentClick -= new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            base.UnBindControlEvents();
        }

        private void btnMedulayaKaydet_Click()
        {
            #region HyperbaricOxygenTreatmentPlanForm_btnMedulayaKaydet_Click
            //try
            //         {
            //             RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();

            //             if (this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.SubEpisode == null || this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.SubEpisode.SGKSEP == null  )
            //             {
            //                 InfoBox.Show("Hastaya ait provizyon bilgisi mevcut değildir.!!!");
            //                 return;
            //             }

            //             if (this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.Episode != null && this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.Episode.SubEpisodes[0] != null && this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.Episode.SubEpisodes[0].SGKSEP != null && this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo != null)
            //             {
            //                 if (this._HyperbaricOxygenTreatmentOrder.MedulaReportResults != null)
            //                 {
            //                     if (this._HyperbaricOxygenTreatmentOrder.MedulaReportResults[0] != null)
            //                     {
            //                         if (!string.IsNullOrEmpty(this._HyperbaricOxygenTreatmentOrder.MedulaReportResults[0].ReportChasingNo))
            //                         {
            //                             InfoBox.Show("Medulaya kayıt etmek istediğiniz rapor bilgisi daha önce kayıt edilmiştir!!!");
            //                             return;
            //                         }
            //                     }

            //                 }

            //                 raporGirisDVO.ilacRapor = null;
            //TODO : MEDULA20140501
            //                 raporGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                 raporGirisDVO.isgoremezlikRapor = null;
            //                 RaporIslemleri.tedaviRaporDVO _tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
            //                 _tedaviRaporDVO.tedaviRaporTuru = 2;
            //                 List<RaporIslemleri.tedaviIslemBilgisiDVO> _tedaviIslemBilgisiDVOList = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();


            //                 RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();
            //                 _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
            //                 _tedaviIslemBilgisiDVO.eswlRaporBilgisi = null;
            //                 _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
            //                 _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
            //                 _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = null;
            //                 _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = null;

            //                 RaporIslemleri.HOTRaporBilgisiDVO _hOTRaporBilgisiDVO = new RaporIslemleri.HOTRaporBilgisiDVO();
            //                 _hOTRaporBilgisiDVO.tedaviSuresi = this._HyperbaricOxygenTreatmentOrder.Duration != null ? Convert.ToInt32(this._HyperbaricOxygenTreatmentOrder.Duration.Value) : 0;
            //                 _hOTRaporBilgisiDVO.seansGun = this._HyperbaricOxygenTreatmentOrder.TreatmentPeriod != null ? Convert.ToInt32(this._HyperbaricOxygenTreatmentOrder.TreatmentPeriod.Value) : 0;
            //                 _hOTRaporBilgisiDVO.seansSayi = this._HyperbaricOxygenTreatmentOrder.Amount != null ? Convert.ToInt32(this._HyperbaricOxygenTreatmentOrder.Amount.Value) : 0;
            //                 _tedaviIslemBilgisiDVO.hotRaporBilgisi = _hOTRaporBilgisiDVO;
            //                 _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);


            //                 _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();



            //                 RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();

            //                 _raporDVO.aciklama = "";


            //                 _raporDVO.baslangicTarihi = ReportStartDateHyperbarikOxygenTreatmentRequest.Text;
            //                 _raporDVO.bitisTarihi = ReportEndDateHyperbarikOxygenTreatmentRequest.Text;
            //                 _raporDVO.durum = "";
            //                 _raporDVO.duzenlemeTuru = "1";
            //                 _raporDVO.klinikTani = "";
            //                 _raporDVO.protokolNo = this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.Episode.HospitalProtocolNo.ToString();
            //                 _raporDVO.protokolTarihi = this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.SubEpisode.PatientAdmission.ActionDate != null ? this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.SubEpisode.PatientAdmission.ActionDate.Value.ToString("dd.MM.yyyy") : "";

            //                 List<RaporIslemleri.taniBilgisiDVO> _taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
            //                 foreach (DiagnosisGrid diagnosis in this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.Episode.Diagnosis)
            //                 {
            //                     RaporIslemleri.taniBilgisiDVO _taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
            //                     _taniBilgisiDVO.taniKodu = diagnosis.DiagnoseCode;
            //                     _taniBilgisiDVOList.Add(_taniBilgisiDVO);

            //                 }
            //                 if (_taniBilgisiDVOList.Count > 0)
            //                     _raporDVO.tanilar = _taniBilgisiDVOList.ToArray();

            //                 _raporDVO.turu = "1";
            //                 _raporDVO.takipNo = this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo;




            //                 List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
            //                 RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
            //                 _doktorBilgisiDVO.drAdi = this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.ProcedureDoctor.Person.Name;
            //                 _doktorBilgisiDVO.drBransKodu = this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.ProcedureDoctor.GetSpeciality() != null ? this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.ProcedureDoctor.GetSpeciality().Code : "";
            //                 _doktorBilgisiDVO.drSoyadi = this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.ProcedureDoctor.Person.Surname;
            //                 _doktorBilgisiDVO.drTescilNo = this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.ProcedureDoctor.DiplomaRegisterNo;
            //                 _doktorBilgisiDVO.tipi = "2";
            //                 _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
            //                 _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();

            //                 _raporDVO.hakSahibi = null;

            //                 RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
            //                 _raporBilgisiDVO.AVakaTKaza = 3;
            //                 _raporBilgisiDVO.no = this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.ReportNo.Value.ToString();
            //                 _raporBilgisiDVO.raporSiraNo = 0;
            //                 _raporBilgisiDVO.raporTakipNo = "";
            //                 _raporBilgisiDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                 _raporBilgisiDVO.tarih = ReportStartDateHyperbarikOxygenTreatmentRequest.Text;
            //                 _raporDVO.raporBilgisi = _raporBilgisiDVO;
            //                 _raporDVO.teshisler = null;

            //                 _tedaviRaporDVO.raporDVO = _raporDVO;

            //                 raporGirisDVO.tedaviRapor = _tedaviRaporDVO;

            //                 TTObjectContext dContext = _HyperbaricOxygenTreatmentOrder.ObjectContext;
            //                 HyperbarikOxygenTreatmentRequest hyperbarikOxygenTreatmentRequest = (HyperbarikOxygenTreatmentRequest)dContext.GetObject(this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.ObjectID, typeof(HyperbarikOxygenTreatmentRequest));
            //                 hyperbarikOxygenTreatmentRequest.ReportStartDate = Convert.ToDateTime(ReportStartDateHyperbarikOxygenTreatmentRequest.Text);
            //                 hyperbarikOxygenTreatmentRequest.ReportEndDate = Convert.ToDateTime(ReportEndDateHyperbarikOxygenTreatmentRequest.Text);
            //                 dContext.Save();



            //                 RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.takipNoileRaporBilgisiKaydetSync(Sites.SiteLocalHost, raporGirisDVO);
            //                 if (response != null)
            //                 {
            //                     if (response.sonucKodu != null)
            //                     {
            //                         if (response.sonucKodu.Equals(0))
            //                         {
            //                             TTObjectContext context =_HyperbaricOxygenTreatmentOrder.ObjectContext;

            //                             MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._HyperbaricOxygenTreatmentOrder.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
            //                             medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
            //                            medulaReportResult.ReportNumber = this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.ReportNo.ToString();
            //                             medulaReportResult.ReportRowNumber =response.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
            //                             medulaReportResult.ReportChasingNo = response.raporTakipNo!=null?response.raporTakipNo.ToString():"";
            //                             medulaReportResult.SendReportDate = Convert.ToDateTime(response.tedaviRapor.raporDVO.raporBilgisi.tarih);
            //                             medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                             medulaReportResult.HOTOrder = this._HyperbaricOxygenTreatmentOrder;
            //                             context.Save();
            //                         }
            //                         else
            //                         {
            //                             TTObjectContext context =_HyperbaricOxygenTreatmentOrder.ObjectContext;
            //                             MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._HyperbaricOxygenTreatmentOrder.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));

            //                             medulaReportResult.ResultCode = response.sonucKodu.ToString();
            //                             medulaReportResult.ResultExplanation = response.sonucAciklamasi;

            //                             medulaReportResult.HOTOrder = this._HyperbaricOxygenTreatmentOrder;
            //                             medulaReportResult.SendReportDate = DateTime.Now;
            //                             context.Save();

            //                             InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi + " Rapor Takip Numarası Alınamamıştır.!!!");
            //                             return;
            //                         }
            //                     }
            //                     else
            //                     {
            //                         if (!string.IsNullOrEmpty(response.sonucAciklamasi))
            //                         {
            //                             throw new TTException("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
            //                         }

            //                     }
            //                 }

            //             }
            //             else
            //             {
            //                 InfoBox.Show("Hastaya ait provizyon bulunmadığından dolayı raporu  medulaya kayıt edemezsiniz");
            //             }

            //         }
            //         catch (Exception)
            //         {

            //             throw;
            //         }
            #endregion HyperbaricOxygenTreatmentPlanForm_btnMedulayaKaydet_Click
        }

        private void MedulaReportResults_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region HyperbaricOxygenTreatmentPlanForm_MedulaReportResults_CellContentClick
            //TODO:ShowEdit!
            //if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
            //         {
            //             if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnMeduladanSil"))
            //             {
            //                 ITTGridCell currentCell = MedulaReportResults.CurrentCell;
            //                 if (currentCell != null)
            //                 {
            //                     ITTGridRow currentRow = currentCell.OwningRow;
            //                     if (currentRow != null)
            //                     {
            //                         MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
            //                         if (currentMedulaReportResult != null)
            //                         {

            //                             if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
            //                             {
            //                                 DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
            //                                 if (dialogResult == DialogResult.OK)
            //                                 {
            //                                     try
            //                                     {
            //                                         RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
            //                                         //TODO : MEDULA20140501
            //                                         raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

            //                                         RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
            //                                         _raporOkuDVO.no = currentMedulaReportResult.ReportNumber;
            //                                         _raporOkuDVO.raporSiraNo = currentMedulaReportResult.ReportRowNumber.ToString();
            //                                         _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                                         _raporOkuDVO.tarih = currentMedulaReportResult.SendReportDate.Value.ToString("dd.MM.yyyy");
            //                                         _raporOkuDVO.turu = "1";
            //                                         raporSorguDVO.raporBilgisi = _raporOkuDVO;

            //                                         RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
            //                                         if (response != null)
            //                                         {
            //                                            if (response.sonucKodu.Equals(0))
            //                                                 {

            //                                                     MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
            //                                                     //medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Canceled;
            //                                                     medulaReportResult.ResultCode = response.sonucKodu.ToString();
            //                                                     medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                                                     medulaReportResult.ReportChasingNo="";
            //                                                     medulaReportResult.ReportNumber="";
            //                                                     medulaReportResult.ReportRowNumber=null;
            //                                                 }
            //                                                 else
            //                                                 {
            //                                                     if (!string.IsNullOrEmpty(response.sonucAciklamasi))
            //                                                     {
            //                                                         MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
            //                                                         medulaReportResult.ResultCode = response.sonucKodu.ToString();
            //                                                         medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                                                         InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
            //                                                     }

            //                                                 }
            //                                         }
            //                                     }
            //                                     catch (Exception ex)
            //                                     {
            //                                         throw ex;
            //                                     }
            //                                 }
            //                             }
            //                             else
            //                             {
            //                                 InfoBox.Show("Medulaya Kayıtdı Yapılmamış Bir Hiperbarik Oksijen Tedavi  Raporunu Meduladan Silemezsiniz!!!");
            //                             }
            //                         }
            //                     }
            //                 }
            //             }
            //         }
            var a = 1;
            #endregion HyperbaricOxygenTreatmentPlanForm_MedulaReportResults_CellContentClick
        }

        protected override void PreScript()
        {
#region HyperbaricOxygenTreatmentPlanForm_PreScript
    base.PreScript();
            if (this._HyperbaricOxygenTreatmentOrder.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
            {
                this.labelReasonOfRejection.Visible = false;
                this.ReasonOfRejection.Visible = false;
            }
            
            //DP gelistirme, DialysisRequest teki ProcedureDoctor alani  set edilecek.
            if ( this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.ProcedureDoctor != null )
                this.ProcedureDoctor.SelectedObject = this._HyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest.ProcedureDoctor;
#endregion HyperbaricOxygenTreatmentPlanForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HyperbaricOxygenTreatmentPlanForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef != null)
            {
                if(transDef.ToStateDefID == HyperbaricOxygenTreatmentOrder.States.AutomaticPlan)
                {
                    string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Hiperbarik Oksijen Tedavisi Planlama","Hiperbarik Oksijen Tedavisi Uygulamalarını, planlama yapmadan oluşturmak istediğinize emin misiniz?");
                    if(result == "H")
                        throw new Exception("İşlemden vazgeçildi.");
                    if(this._HyperbaricOxygenTreatmentOrder.TreatmentEquipment == null || this._HyperbaricOxygenTreatmentOrder.TreatmentStartDateTime == null)
                        throw new Exception("'Tedavi Cihazı' ve 'Tedavi Başlangıç Tarih Saati' ni seçiniz.");
                    result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Hiperbarik Oksijen Tedavisi Planlama","Hiperbarik Oksijen Tedavisi Uygulamaları," + this._HyperbaricOxygenTreatmentOrder.TreatmentStartDateTime.Value.ToString("dd.MM.yyyy HH:mm") +" tarihinden itibaren " + this._HyperbaricOxygenTreatmentOrder.Amount.ToString() + " gün boyunca oluşturulacak.\r\nİşlemi onaylıyor musunuz?");
                    if(result == "H")
                        throw new Exception("İşlemden vazgeçildi.");
                }
            }
#endregion HyperbaricOxygenTreatmentPlanForm_ClientSidePostScript

        }

#region HyperbaricOxygenTreatmentPlanForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            
                bool setCurrentStateToTherapy = false;
                if(transDef != null)
                {
                    if (transDef.ToStateDefID == HyperbaricOxygenTreatmentOrder.States.AutomaticPlan)
                        setCurrentStateToTherapy = true;
                }
                else if(this._HyperbaricOxygenTreatmentOrder.CurrentStateDefID == HyperbaricOxygenTreatmentOrder.States.AutomaticPlan)
                    setCurrentStateToTherapy = true;

                if(setCurrentStateToTherapy == true)
                {
                    this._HyperbaricOxygenTreatmentOrder.CurrentStateDefID = HyperbaricOxygenTreatmentOrder.States.Therapy;
                    this._HyperbaricOxygenTreatmentOrder.ObjectContext.Save();
                }
        }
        
#endregion HyperbaricOxygenTreatmentPlanForm_Methods
    }
}