
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
    /// Diyaliz Planlama Formu
    /// </summary>
    public partial class DialysisPlanForm : BaseDialysisOrderForm
    {
        override protected void BindControlEvents()
        {
            btnRaporuMedulayaGonder.Click += new TTControlEventDelegate(btnRaporuMedulayaGonder_Click);
            MedulaReportResults.CellContentClick += new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnRaporuMedulayaGonder.Click -= new TTControlEventDelegate(btnRaporuMedulayaGonder_Click);
            MedulaReportResults.CellContentClick -= new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            base.UnBindControlEvents();
        }

        private void btnRaporuMedulayaGonder_Click()
        {
            #region DialysisPlanForm_btnRaporuMedulayaGonder_Click
            //try
            //         {
            //             RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();

            //             if (this._DialysisOrder.DialysisRequest.SubEpisode ==null || this._DialysisOrder.DialysisRequest.SubEpisode.SGKSEP == null)
            //             {
            //                 InfoBox.Show("Hastaya ait provizyon bilgisi mevcut değildir.!!!");
            //                 return;
            //             }

            //             if (this._DialysisOrder.DialysisRequest.Episode != null && this._DialysisOrder.DialysisRequest.Episode.SubEpisodes[0] != null && this._DialysisOrder.DialysisRequest.Episode.SubEpisodes[0].SGKSEP != null && this._DialysisOrder.DialysisRequest.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo != null)
            //             {
            //                 if(this._DialysisOrder.MedulaReportResults!=null)
            //                 {
            //                     if(this._DialysisOrder.MedulaReportResults[0]!=null)
            //                     {
            //                         if(!string.IsNullOrEmpty(this._DialysisOrder.MedulaReportResults[0].ReportChasingNo))
            //                         {
            //                             InfoBox.Show("Medulaya kayıt etmek istediğiniz rapor bilgisi daha önce kayıt edilmiştir!!!");
            //                             return;
            //                         }
            //                     }

            //                 }

            //                 raporGirisDVO.ilacRapor = null;
            //TODO : MEDULA20140501
            //                 raporGirisDVO.saglikTesisKodu =  Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                 raporGirisDVO.isgoremezlikRapor = null;

            //                 RaporIslemleri.tedaviRaporDVO _tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
            //                 _tedaviRaporDVO.tedaviRaporTuru = 1;
            //                 List<RaporIslemleri.tedaviIslemBilgisiDVO> _tedaviIslemBilgisiDVOList = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();


            //                 RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();
            //                 _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
            //                 _tedaviIslemBilgisiDVO.eswlRaporBilgisi = null;
            //                 _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
            //                 _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
            //                 _tedaviIslemBilgisiDVO.hotRaporBilgisi = null;
            //                 _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = null;

            //                 RaporIslemleri.diyalizRaporBilgisiDVO _diyalizRaporBilgisiDVO = new RaporIslemleri.diyalizRaporBilgisiDVO();
            //                 _diyalizRaporBilgisiDVO.butKodu = this._DialysisOrder.ProcedureObject.Code;
            //                 _diyalizRaporBilgisiDVO.seansGun = this._DialysisOrder.Duration != null ? Convert.ToInt32(this._DialysisOrder.Duration.Value) : 0;
            //                 _diyalizRaporBilgisiDVO.seansSayi = this._DialysisOrder.Amount != null ? Convert.ToInt32(this._DialysisOrder.Amount.Value) : 0;
            //                 _diyalizRaporBilgisiDVO.refakatVarMi = "H";
            //                 _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = _diyalizRaporBilgisiDVO;

            //                 _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);

            //                 _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();

            //                 RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();

            //                 _raporDVO.aciklama = "";


            //                 _raporDVO.baslangicTarihi =ReportStartDateDialysisRequest.Text;
            //                 _raporDVO.bitisTarihi = ReportEndDateDialysisRequest.Text;
            //                 _raporDVO.durum = "";
            //                 _raporDVO.duzenlemeTuru = "2";
            //                 _raporDVO.klinikTani = "";
            //                 _raporDVO.protokolNo = this._DialysisOrder.DialysisRequest.Episode.HospitalProtocolNo.ToString();
            //                 _raporDVO.protokolTarihi = this._DialysisOrder.DialysisRequest.SubEpisode.PatientAdmission.ActionDate != null ? this._DialysisOrder.DialysisRequest.SubEpisode.PatientAdmission.ActionDate.Value.ToString("dd.MM.yyyy") : "";

            //                 List<RaporIslemleri.taniBilgisiDVO> _taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
            //                 foreach (DiagnosisGrid diagnosis in this._DialysisOrder.DialysisRequest.Episode.Diagnosis)
            //                 {
            //                     RaporIslemleri.taniBilgisiDVO _taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
            //                     _taniBilgisiDVO.taniKodu = diagnosis.DiagnoseCode;
            //                     _taniBilgisiDVOList.Add(_taniBilgisiDVO);

            //                 }
            //                 if (_taniBilgisiDVOList.Count > 0)
            //                     _raporDVO.tanilar = _taniBilgisiDVOList.ToArray();

            //                 _raporDVO.turu = "1";
            //                 _raporDVO.takipNo = this._DialysisOrder.DialysisRequest.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo;




            //                 List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
            //                 RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
            //                 _doktorBilgisiDVO.drAdi = this._DialysisOrder.DialysisRequest.ProcedureDoctor.Person.Name;
            //                 _doktorBilgisiDVO.drBransKodu = this._DialysisOrder.DialysisRequest.ProcedureDoctor.GetSpeciality() != null ? this._DialysisOrder.DialysisRequest.ProcedureDoctor.GetSpeciality().Code : "";
            //                 _doktorBilgisiDVO.drSoyadi = this._DialysisOrder.DialysisRequest.ProcedureDoctor.Person.Surname;
            //                 _doktorBilgisiDVO.drTescilNo = this._DialysisOrder.DialysisRequest.ProcedureDoctor.DiplomaRegisterNo;
            //                 _doktorBilgisiDVO.tipi = "2";
            //                 _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
            //                 _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();

            //                 _raporDVO.hakSahibi = null;

            //                 RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
            //                 _raporBilgisiDVO.AVakaTKaza = 3;
            //                // _raporBilgisiDVO.no = this._DialysisOrder.DialysisRequest.ReportNo.Value.ToString();
            //                 _raporBilgisiDVO.raporSiraNo = 0;
            //                 _raporBilgisiDVO.raporTakipNo = "";
            //                 _raporBilgisiDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                 _raporBilgisiDVO.tarih = ReportStartDateDialysisRequest.Text;
            //                 _raporDVO.raporBilgisi = _raporBilgisiDVO;
            //                 _raporDVO.teshisler = null;

            //                 _tedaviRaporDVO.raporDVO = _raporDVO;

            //                 raporGirisDVO.tedaviRapor = _tedaviRaporDVO;

            //                 TTObjectContext dContext =  _DialysisOrder.ObjectContext;
            //                 DialysisRequest dialysisRequest = (DialysisRequest)dContext.GetObject(this._DialysisOrder.DialysisRequest.ObjectID, typeof(DialysisRequest));
            //                 if(!string.IsNullOrEmpty(ReportStartDateDialysisRequest.Text))
            //                 {
            //                     dialysisRequest.ReportStartDate=  Convert.ToDateTime(ReportStartDateDialysisRequest.Text);
            //                 }
            //                 else
            //                 {
            //                     dialysisRequest.ReportStartDate=DateTime.Now;
            //                 }
            //                 if(!string.IsNullOrEmpty(ReportEndDateDialysisRequest.Text))
            //                 {
            //                     dialysisRequest.ReportEndDate=Convert.ToDateTime(ReportEndDateDialysisRequest.Text);
            //                 }
            //                 else
            //                 {
            //                     dialysisRequest.ReportEndDate=DateTime.Now;
            //                 }

            //                 dContext.Save();



            //                 RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.takipNoileRaporBilgisiKaydetSync(Sites.SiteLocalHost, raporGirisDVO);
            //                 if (response != null)
            //                 {
            //                     if (response.sonucKodu != null)
            //                     {
            //                         if (response.sonucKodu.Equals(0))
            //                         {
            //                             TTObjectContext context = _DialysisOrder.ObjectContext;

            //                             MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._DialysisOrder.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
            //                             medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;

            //                             medulaReportResult.ReportNumber = this._DialysisOrder.DialysisRequest.ReportNo.ToString();
            //                             medulaReportResult.ReportRowNumber =response.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
            //                             medulaReportResult.ReportChasingNo = response.raporTakipNo!=null?response.raporTakipNo.ToString():"";
            //                             medulaReportResult.SendReportDate = Convert.ToDateTime(response.tedaviRapor.raporDVO.raporBilgisi.tarih);
            //                             medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                             medulaReportResult.DialysisOrder = this._DialysisOrder;
            //                             context.Save();
            //                         }
            //                         else
            //                         {
            //                             TTObjectContext context = _DialysisOrder.ObjectContext;
            //                             MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._DialysisOrder.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
            //                             medulaReportResult.ResultCode = response.sonucKodu.ToString();
            //                             medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                             medulaReportResult.DialysisOrder = this._DialysisOrder;
            //                             medulaReportResult.SendReportDate=DateTime.Now;
            //                             context.Save();

            //                             InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : "+response.sonucAciklamasi +" Rapor Takip Numarası Alınamamıştır.!!!");
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
            //             else{
            //                 InfoBox.Show("Hastaya ait provizyon bulunmadığından dolayı raporu  medulaya kayıt edemezsiniz");
            //             }

            //         }
            //         catch (Exception)
            //         {

            //             throw;
            //         }
            var a = 1;
            #endregion DialysisPlanForm_btnRaporuMedulayaGonder_Click
        }

        private void MedulaReportResults_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region DialysisPlanForm_MedulaReportResults_CellContentClick
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
            //                                     try{
            //                                         RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
            //                                         //TODO : MEDULA20140501
            //                                         raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

            //                                         RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
            //                                         _raporOkuDVO.no = currentMedulaReportResult.ReportNumber;
            //                                         _raporOkuDVO.raporSiraNo = currentMedulaReportResult.ReportRowNumber.ToString();
            //                                         _raporOkuDVO.raporTesisKodu =Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                                         _raporOkuDVO.tarih = currentMedulaReportResult.SendReportDate.Value.ToString("dd.MM.yyyy");
            //                                         _raporOkuDVO.turu = "1";
            //                                         raporSorguDVO.raporBilgisi = _raporOkuDVO;

            //                                         RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
            //                                         if (response != null)
            //                                         {
            //                                             //if (response.sonucKodu != null)
            //                                             {
            //                                                 if (response.sonucKodu.Equals(0))
            //                                                 {

            //                                                     MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
            //                                                    // medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Canceled;
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
            //                                             }

            //                                         }
            //                                     }
            //                                     catch(Exception ex)
            //                                     {

            //                                     }

            //                                 }
            //                             }
            //                             else
            //                             {
            //                                 InfoBox.Show("Medulaya Kayıtdı Yapılmamış Bir Diyaliz Raporunu Meduladan Silemezsiniz!!!");
            //                             }
            //                         }
            //                     }
            //                 }
            //             }
            //         }
            var a = 1;
            #endregion DialysisPlanForm_MedulaReportResults_CellContentClick
        }

        protected override void PreScript()
        {
#region DialysisPlanForm_PreScript
    base.PreScript();
            if (this._DialysisOrder.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
            {
                this.labelReasonOfRejection.Visible = false;
                this.ReasonOfRejection.Visible = false;
            }
            
             //DP gelistirme, DialysisRequest teki ProcedureDoctor alani  set edilecek.
            if ( this._DialysisOrder.DialysisRequest.ProcedureDoctor != null )
                this.ProcedureDoctor.SelectedObject = this._DialysisOrder.DialysisRequest.ProcedureDoctor;
#endregion DialysisPlanForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DialysisPlanForm_PostScript
    base.PostScript(transDef);
#endregion DialysisPlanForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region DialysisPlanForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if(transDef!=null)
            {
                if(transDef.FromStateDefID == DialysisOrder.States.RequestAcception && transDef.ToStateDefID == DialysisOrder.States.Therapy)
                {
                    string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Diyaliz Planlama","Diyaliz Uygulamalarını, planlama yapmadan oluşturmak istediğinize emin misiniz?");
                    if(result == "H")
                        throw new Exception("İşlemden vazgeçildi.");
                    if(this._DialysisOrder.TreatmentEquipment == null || this._DialysisOrder.TreatmentStartDateTime == null)
                        throw new Exception("'Tedavi Cihazı' ve 'Tedavi Başlangıç Tarih Saati' ni seçiniz.");
                    result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Diyaliz Planlama","Diyaliz Uygulamaları," + this._DialysisOrder.TreatmentStartDateTime.Value.ToString("dd.MM.yyyy HH:mm") +" tarihinden itibaren " + this._DialysisOrder.Amount.ToString() + " gün boyunca oluşturulacak.\r\nİşlemi onaylıyor musunuz?");
                    if(result == "H")
                        throw new Exception("İşlemden vazgeçildi.");
                    
                }
            }
#endregion DialysisPlanForm_ClientSidePostScript

        }
    }
}