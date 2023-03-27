
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
    public partial class StoneBreakUpProcedureForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnRaporuMedulayaKaydet.Click += new TTControlEventDelegate(btnRaporuMedulayaKaydet_Click);
            TTListBoxDrAnesteziTescilNo.SelectedObjectChanged += new TTControlEventDelegate(TTListBoxDrAnesteziTescilNo_SelectedObjectChanged);
            MedulaReportResults.CellContentClick += new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnRaporuMedulayaKaydet.Click -= new TTControlEventDelegate(btnRaporuMedulayaKaydet_Click);
            TTListBoxDrAnesteziTescilNo.SelectedObjectChanged -= new TTControlEventDelegate(TTListBoxDrAnesteziTescilNo_SelectedObjectChanged);
            MedulaReportResults.CellContentClick -= new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            base.UnBindControlEvents();
        }

        private void btnRaporuMedulayaKaydet_Click()
        {
#region StoneBreakUpProcedureForm_btnRaporuMedulayaKaydet_Click
   try
            {
                RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();
                
                if (this._StoneBreakUpRequest.SubEpisode ==null || this._StoneBreakUpRequest.SubEpisode.SGKSEP == null )
                {
                    InfoBox.Show("Hastaya ait provizyon bilgisi mevcut değildir.!!!");
                    return;
                }
                
                if (this._StoneBreakUpRequest.Episode != null && this._StoneBreakUpRequest.Episode.SubEpisodes[0] != null && this._StoneBreakUpRequest.Episode.SubEpisodes[0].SGKSEP != null && this._StoneBreakUpRequest.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo != null)
                {
                    if(this._StoneBreakUpRequest.MedulaReportResults!=null)
                    {
                        if(this._StoneBreakUpRequest.MedulaReportResults[0]!=null)
                        {
                            if(!string.IsNullOrEmpty(this._StoneBreakUpRequest.MedulaReportResults[0].ReportChasingNo))
                            {
                                InfoBox.Show("Medulaya kayıt etmek istediğiniz rapor bilgisi daha önce kayıt edilmiştir!!!");
                                return;
                            }
                        }
                        
                    }
                    raporGirisDVO.ilacRapor = null;
                    //TODO : MEDULA20140501
                    raporGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                    raporGirisDVO.isgoremezlikRapor = null;

                    RaporIslemleri.tedaviRaporDVO _tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
                    _tedaviRaporDVO.tedaviRaporTuru=6;
                    List<RaporIslemleri.tedaviIslemBilgisiDVO> _tedaviIslemBilgisiDVOList = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();
                    foreach (StoneBreakUpProcedure item in this._StoneBreakUpRequest.StoneBreakUpProcedures)
                    {
                        RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();

                        RaporIslemleri.eswlRaporBilgisiDVO _eSWLRaporBilgisiDVO = new RaporIslemleri.eswlRaporBilgisiDVO();
                        
                        if(item.ZoneOfStone!=null)
                        {
                            switch ((int)item.ZoneOfStone.Value)
                            {
                                case 3:
                                case 4:
                                case 5:
                                    case 8: _eSWLRaporBilgisiDVO.bobrekBilgisi = 1;
                                    break;
                                case 2:
                                case 6:
                                case 7:
                                    case 9: _eSWLRaporBilgisiDVO.bobrekBilgisi = 2;
                                    break;
                                default:
                                    break;
                            }
                        }
                        _eSWLRaporBilgisiDVO.butKodu = item.ProcedureObject.Code;
                        _eSWLRaporBilgisiDVO.eswlRaporuSeansSayisi = item.NumberOfProcedure!=null ?item.NumberOfProcedure.Value:0;//Rapora Ait Seans Sayısı
                        _eSWLRaporBilgisiDVO.eswlRaporuTasSayisi=item.NumberOfStone!=null ?item.NumberOfStone.Value:0;//Rapora ait Ta? Sayısı
                        
                        List<RaporIslemleri.eswlTasBilgisiDVO> _eSWLTasBilgisiDVOList = new List<RaporIslemleri.eswlTasBilgisiDVO>();
                        RaporIslemleri.eswlTasBilgisiDVO _eSWLTasBilgisiDVO = new RaporIslemleri.eswlTasBilgisiDVO();
                        _eSWLTasBilgisiDVO.tasBoyutu = item.StoneDimension;
                        if(item.PartOfStone.PartOfStone.Contains("brek"))
                        {
                            _eSWLTasBilgisiDVO.tasLokalizasyonKodu =4;
                        }
                        if(item.PartOfStone.PartOfStone.Contains("esane"))
                        {
                            _eSWLTasBilgisiDVO.tasLokalizasyonKodu =2;
                        }
                        
                        _eSWLTasBilgisiDVOList.Add(_eSWLTasBilgisiDVO);
                        
                        _eSWLRaporBilgisiDVO.eswlRaporuTasBilgileri = _eSWLTasBilgisiDVOList.ToArray() ;
                        _tedaviIslemBilgisiDVO.eswlRaporBilgisi = _eSWLRaporBilgisiDVO;

                        
                        _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.hotRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
                        
                        _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);
                    }

                    _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();

                    
                    
                    RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();

                    _raporDVO.aciklama = "";
                    _raporDVO.baslangicTarihi = this._StoneBreakUpRequest.ReportStartDate.Value.ToString("dd.MM.yyyy");
                    _raporDVO.bitisTarihi = this._StoneBreakUpRequest.ReportEndDate.Value.ToString("dd.MM.yyyy");
                    _raporDVO.durum = "";
                    _raporDVO.duzenlemeTuru = "2";
                    _raporDVO.klinikTani="";
                    _raporDVO.protokolNo = this._StoneBreakUpRequest.Episode.HospitalProtocolNo.ToString();
                    _raporDVO.protokolTarihi = this._StoneBreakUpRequest.SubEpisode.PatientAdmission.ActionDate != null ? this._StoneBreakUpRequest.SubEpisode.PatientAdmission.ActionDate.Value.ToString("dd.MM.yyyy") : "";
                    
                    List<RaporIslemleri.taniBilgisiDVO> _taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
                    foreach (DiagnosisGrid diagnosis in this._StoneBreakUpRequest.Episode.Diagnosis)
                    {
                        RaporIslemleri.taniBilgisiDVO _taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
                        _taniBilgisiDVO.taniKodu = diagnosis.DiagnoseCode;
                        _taniBilgisiDVOList.Add(_taniBilgisiDVO);

                    }
                    if(_taniBilgisiDVOList.Count>0)
                        _raporDVO.tanilar = _taniBilgisiDVOList.ToArray();
                    
                    _raporDVO.turu = "1";
                    _raporDVO.takipNo = this._StoneBreakUpRequest.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo;

                    
                    List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
                    RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
                    if(this._StoneBreakUpRequest.ProcedureDoctor==null || this._StoneBreakUpRequest.ProcedureDoctor.Person==null)
                    {
                        throw new TTException("Doktor Bilgisi Boş Olamaz");
                    }
                    _doktorBilgisiDVO.drAdi = this._StoneBreakUpRequest.ProcedureDoctor.Person.Name;
                    _doktorBilgisiDVO.drBransKodu = SpecialityDefinition.GetSpecialityByResUser(this._StoneBreakUpRequest.ProcedureDoctor) != null ? SpecialityDefinition.GetSpecialityByResUser(this._StoneBreakUpRequest.ProcedureDoctor).Code : "";
                    _doktorBilgisiDVO.drSoyadi = this._StoneBreakUpRequest.ProcedureDoctor.Person.Surname;
                    _doktorBilgisiDVO.drTescilNo = this._StoneBreakUpRequest.ProcedureDoctor.DiplomaRegisterNo;
                    _doktorBilgisiDVO.tipi = "2";
                    _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
                    _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();
                    
                    _raporDVO.hakSahibi = null;
                    
                    RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
                    _raporBilgisiDVO.aVakaTKaza = 3;
                   // _raporBilgisiDVO.no =  this._StoneBreakUpRequest.ReportNo.Value.ToString();
                    _raporBilgisiDVO.raporSiraNo = 0;
                    _raporBilgisiDVO.raporTakipNo = "";
                    _raporBilgisiDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                    _raporBilgisiDVO.tarih = this._StoneBreakUpRequest.ReportStartDate.Value.ToString("dd.MM.yyyy");
                    _raporDVO.raporBilgisi = _raporBilgisiDVO;
                    _raporDVO.teshisler = null;
                    
                    _tedaviRaporDVO.raporDVO = _raporDVO;
                    
                    raporGirisDVO.tedaviRapor = _tedaviRaporDVO;
                    
                    RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.takipNoileRaporBilgisiKaydetSync(Sites.SiteLocalHost, raporGirisDVO);
                    if (response != null)
                    {
                        //if (response.sonucKodu != null)
                        {
                            if (response.sonucKodu.Equals(0))
                            {
                                TTObjectContext context = _StoneBreakUpRequest.ObjectContext;
                                
                                MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._StoneBreakUpRequest.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                                medulaReportResult.ReportNumber = this._StoneBreakUpRequest.ReportNo.ToString();
                                medulaReportResult.ReportRowNumber = response.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                medulaReportResult.ReportChasingNo = response.raporTakipNo.ToString();
                                medulaReportResult.SendReportDate = Convert.ToDateTime(response.tedaviRapor.raporDVO.raporBilgisi.tarih);
                                medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                medulaReportResult.StoneBreakUpRequest = this._StoneBreakUpRequest;
                                context.Save();
                            }
                            else
                            {
                                TTObjectContext context = _StoneBreakUpRequest.ObjectContext;
                                MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._StoneBreakUpRequest.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                medulaReportResult.ResultCode = response.sonucKodu.ToString();
                                medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                medulaReportResult.StoneBreakUpRequest = this._StoneBreakUpRequest;
                                medulaReportResult.SendReportDate=DateTime.Now;
                                context.Save();
                                
                                InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : "+response.sonucAciklamasi +" Rapor Takip Numarası Alınamamıştır.!!!");
                                return;
                            }
                        }
                        //else
                        //{
                        //    if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                        //    {
                        //        throw new TTException("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                        //    }

                        //}
                    }
                }
                else{
                    InfoBox.Show("Hastaya ait provizyon bulunmadığından dolayı raporu  medulaya kayıt edemezsiniz");
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
#endregion StoneBreakUpProcedureForm_btnRaporuMedulayaKaydet_Click
        }

        private void TTListBoxDrAnesteziTescilNo_SelectedObjectChanged()
        {
#region StoneBreakUpProcedureForm_TTListBoxDrAnesteziTescilNo_SelectedObjectChanged
   if(this.TTListBoxDrAnesteziTescilNo.SelectedObject != null){
                ResUser resUser=(ResUser) this.TTListBoxDrAnesteziTescilNo.SelectedObject;
                _StoneBreakUpRequest.DrAnesteziTescilNo= (resUser.DiplomaRegisterNo == null)? null : resUser.DiplomaRegisterNo.ToString();
                //_DentalExamination.DrAnesteziTescilNo = _DentalExamination.ResUser.DiplomaRegisterNo.ToString();
            }
#endregion StoneBreakUpProcedureForm_TTListBoxDrAnesteziTescilNo_SelectedObjectChanged
        }

        private void MedulaReportResults_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region StoneBreakUpProcedureForm_MedulaReportResults_CellContentClick
   if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
            {
                if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnMedulaRaporSil"))
                {
                    ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
                            
                            
                            if (currentMedulaReportResult != null)
                            {
                                if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                {
                                    DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                    if (dialogResult == DialogResult.OK)
                                    {
                                        try{
                                            RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
                                            //TODO : MEDULA20140501
                                            raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));//Zorunlu Raporu veren tesisin kodu

                                            RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
                                            _raporOkuDVO.no = currentMedulaReportResult.ReportNumber;
                                            _raporOkuDVO.raporSiraNo = currentMedulaReportResult.ReportRowNumber.ToString();
                                            _raporOkuDVO.raporTesisKodu =Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));//Zorunlu Raporu veren tesisin kodu;//Zorunlu Raporu veren tesisin kodu
                                            _raporOkuDVO.tarih = currentMedulaReportResult.SendReportDate.Value.ToString("dd.MM.yyyy");
                                            _raporOkuDVO.turu = "1";
                                            raporSorguDVO.raporBilgisi = _raporOkuDVO;

                                            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
                                            if (response != null)
                                            {
                                                //if (response.sonucKodu != null)
                                                {
                                                    if (response.sonucKodu.Equals(0))
                                                    {
                                                        
                                                        MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                       // medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Canceled;
                                                        medulaReportResult.ResultCode = response.sonucKodu.ToString();
                                                        medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                                        medulaReportResult.ReportChasingNo="";
                                                        medulaReportResult.ReportNumber="";
                                                        medulaReportResult.ReportRowNumber=null;
                                                    }
                                                    else
                                                    {
                                                        if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                                                        {
                                                            MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                            medulaReportResult.ResultCode = response.sonucKodu.ToString();
                                                            medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                                            InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                                                        }

                                                    }
                                                }
                                                
                                            }
                                        }
                                        catch(Exception ex)
                                        {
                                            
                                        }

                                    }
                                }
                                else
                                {
                                    InfoBox.Show("Medulaya Kayıtdı Yapılmamış Bir Taş Kırma Raporunu Meduladan Silemezsiniz!!!");
                                }
                            }
                        }
                    }
                }
            }
#endregion StoneBreakUpProcedureForm_MedulaReportResults_CellContentClick
        }

        protected override void PreScript()
        {
#region StoneBreakUpProcedureForm_PreScript
    base.PreScript();
            if(this._StoneBreakUpRequest.Equipment!=null){
                this.Equipment.ReadOnly=false;      
            }
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
            this.SetProcedureDoctorAsCurrentResource();
#endregion StoneBreakUpProcedureForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region StoneBreakUpProcedureForm_PostScript
    base.PostScript(transDef);
            // prosedüre geçiş aşamasına taşındı
            //            if(transDef!=null)
            //            {
            //                if(transDef.ToStateDefID==StoneBreakUpRequest.States.ResultEntry)
            //                {
            //                    foreach(StoneBreakUpProcedure stoneBreakUpProcedure in this._StoneBreakUpRequest.StoneBreakUpProcedures)
            //                    {
            //                        stoneBreakUpProcedure.ApplyProcedure();
            //                    }
            //                }
            //            }
#endregion StoneBreakUpProcedureForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region StoneBreakUpProcedureForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef!=null)
            {
                if(transDef.ToStateDefID==StoneBreakUpRequest.States.ReturnedToRequester)
                {
                    StringEntryForm frm = new StringEntryForm();
                    this._StoneBreakUpRequest.ReasonOfReturn=frm.ShowAndGetStringForm("İade Sebebi");
                }
            }
#endregion StoneBreakUpProcedureForm_ClientSidePostScript

        }
    }
}