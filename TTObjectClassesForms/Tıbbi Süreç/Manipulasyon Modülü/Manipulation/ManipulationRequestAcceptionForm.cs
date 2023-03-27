
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
    /// Tıbbi/Cerrahi Uygulamaları
    /// </summary>
    public partial class ManipulationRequestAcceptionForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GunuBirlikTakip.CheckedChanged += new TTControlEventDelegate(GunuBirlikTakip_CheckedChanged);
            btnMedulayaKaydet.Click += new TTControlEventDelegate(btnMedulayaKaydet_Click);
            MedulaReportResults.CellContentClick += new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GunuBirlikTakip.CheckedChanged -= new TTControlEventDelegate(GunuBirlikTakip_CheckedChanged);
            btnMedulayaKaydet.Click -= new TTControlEventDelegate(btnMedulayaKaydet_Click);
            MedulaReportResults.CellContentClick -= new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            base.UnBindControlEvents();
        }

        private void GunuBirlikTakip_CheckedChanged()
        {
            #region ManipulationRequestAcceptionForm_GunuBirlikTakip_CheckedChanged
            if (this.GunuBirlikTakip.Value == true)
            {
                //this._Manipulation.CreateSubEpisode = true;
                this.TabSubaction.ShowTabPage(MedulaTakipBilgileriTabPage);
                this.tedaviTipi.Required = true;
                this.takipTipi.Required = true;
                this.bransKodu.Required = true;
                //TODO Medula!
                //if (this._Manipulation.MedulaProvision == null)
                //{
                //    MedulaProvision _medulaProvision = new MedulaProvision(this._Manipulation.ObjectContext);
                //    this._Manipulation.SetMedulaProvisionInitalProperties(_medulaProvision);
                //    this._Manipulation.MedulaProvision = _medulaProvision;
                //}

            }
            else
            {
                //this._Manipulation.CreateSubEpisode = false;
                this.TabSubaction.HideTabPage(MedulaTakipBilgileriTabPage);
                this.tedaviTipi.Required = false;
                this.takipTipi.Required = false;
                this.bransKodu.Required = false;
            }
            #endregion ManipulationRequestAcceptionForm_GunuBirlikTakip_CheckedChanged
        }

        private void btnMedulayaKaydet_Click()
        {
            #region ManipulationRequestAcceptionForm_btnMedulayaKaydet_Click
            //            try
            //            {
            //                RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();
            //
            //                if (this._Manipulation.ManipulationRequest.SubEpisode == null || this._Manipulation.ManipulationRequest.SubEpisode.SGKSEP == null)
            //                {
            //                    InfoBox.Show("Hastaya ait provizyon bilgisi mevcut değildir.!!!");
            //                    return;
            //                }
            //
            //                if (this._Manipulation.ManipulationRequest.Episode != null && this._Manipulation.ManipulationRequest.Episode.SubEpisodes[0] != null && this._Manipulation.ManipulationRequest.Episode.SubEpisodes[0].SGKSEP != null && this._Manipulation.ManipulationRequest.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo != null)
            //                {
            //                    if (this._Manipulation.MedulaReportResults != null)
            //                    {
            //                        if (this._Manipulation.MedulaReportResults[0] != null)
            //                        {
            //                            if (!string.IsNullOrEmpty(this._Manipulation.MedulaReportResults[0].ReportChasingNo))
            //                            {
            //                                InfoBox.Show("Medulaya kayıt etmek istediğiniz rapor bilgisi daha önce kayıt edilmiştir!!!");
            //                                return;
            //                            }
            //                        }
            //
            //                    }
            //
            //                    raporGirisDVO.ilacRapor = null;
            //TODO : MEDULA20140501
            //                    raporGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                    raporGirisDVO.isgoremezlikRapor = null;
            //                    RaporIslemleri.tedaviRaporDVO _tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
            //                    _tedaviRaporDVO.tedaviRaporTuru = 4;
            //                    List<RaporIslemleri.tedaviIslemBilgisiDVO> _tedaviIslemBilgisiDVOList = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();
            //
            //
            //                    RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();
            //                    _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
            //                    _tedaviIslemBilgisiDVO.eswlRaporBilgisi = null;
            //                    _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
            //                    _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
            //                    _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = null;
            //                    _tedaviIslemBilgisiDVO.hotRaporBilgisi = null;
            //
            //                    RaporIslemleri.tupBebekRaporBilgisiDVO tupBebekRaporBilgisiDVO = new RaporIslemleri.tupBebekRaporBilgisiDVO();
            //                    tupBebekRaporBilgisiDVO.butKodu = "";
            //                    tupBebekRaporBilgisiDVO.tupBebekRaporTuru = this._Manipulation.ManipulationRequest.TestTubeBabyType != null ? Convert.ToInt32(this._Manipulation.ManipulationRequest.TestTubeBabyType) : 0;
            //
            //                    _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = tupBebekRaporBilgisiDVO;
            //                    _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);
            //
            //
            //                    _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();
            //
            //
            //
            //                    RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();
            //
            //                    _raporDVO.aciklama = "";
            //
            //
            //                    _raporDVO.baslangicTarihi = ReportStartDateManipulationRequest.Text;
            //                    _raporDVO.bitisTarihi = ReportEndDateManipulationRequest.Text;
            //                    _raporDVO.durum = "";
            //                    _raporDVO.duzenlemeTuru = "2";
            //                    _raporDVO.klinikTani = "";
            //                    _raporDVO.protokolNo = this._Manipulation.ManipulationRequest.Episode.HospitalProtocolNo.ToString();
            //                    _raporDVO.protokolTarihi = this._Manipulation.ManipulationRequest.SubEpisode.PatientAdmission.ActionDate != null ? this._Manipulation.ManipulationRequest.SubEpisode.PatientAdmission.ActionDate.Value.ToString("dd.MM.yyyy") : "";
            //
            //                    List<RaporIslemleri.taniBilgisiDVO> _taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
            //                    foreach (DiagnosisGrid diagnosis in this._Manipulation.ManipulationRequest.Episode.Diagnosis)
            //                    {
            //                        RaporIslemleri.taniBilgisiDVO _taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
            //                        _taniBilgisiDVO.taniKodu = diagnosis.DiagnoseCode;
            //                        _taniBilgisiDVOList.Add(_taniBilgisiDVO);
            //
            //                    }
            //                    if (_taniBilgisiDVOList.Count > 0)
            //                        _raporDVO.tanilar = _taniBilgisiDVOList.ToArray();
            //
            //                    _raporDVO.turu = "1";
            //                    _raporDVO.takipNo = this._Manipulation.ManipulationRequest.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo;
            //
            //
            //
            //
            //                    List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
            //                    RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
            //                    _doktorBilgisiDVO.drAdi = this._Manipulation.ManipulationRequest.ProcedureDoctor.Person.Name;
            //                    _doktorBilgisiDVO.drBransKodu = this._Manipulation.ManipulationRequest.ProcedureDoctor.GetSpeciality() != null ? this._Manipulation.ManipulationRequest.ProcedureDoctor.GetSpeciality().Code : "";
            //                    _doktorBilgisiDVO.drSoyadi = this._Manipulation.ManipulationRequest.ProcedureDoctor.Person.Surname;
            //                    _doktorBilgisiDVO.drTescilNo = this._Manipulation.ManipulationRequest.ProcedureDoctor.DiplomaRegisterNo;
            //                    _doktorBilgisiDVO.tipi = "2";
            //                    _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
            //                    _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();
            //
            //                    _raporDVO.hakSahibi = null;
            //
            //                    RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
            //                    _raporBilgisiDVO.AVakaTKaza = 3;
            //                    _raporBilgisiDVO.no = this._Manipulation.ManipulationRequest.ReportNo.Value.ToString();
            //                    _raporBilgisiDVO.raporSiraNo = 0;
            //                    _raporBilgisiDVO.raporTakipNo = "";
            //                    _raporBilgisiDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                    _raporBilgisiDVO.tarih = ReportStartDateManipulationRequest.Text;
            //                    _raporDVO.raporBilgisi = _raporBilgisiDVO;
            //                    _raporDVO.teshisler = null;
            //
            //                    _tedaviRaporDVO.raporDVO = _raporDVO;
            //
            //                    raporGirisDVO.tedaviRapor = _tedaviRaporDVO;
            //
            //                    TTObjectContext dContext = _Manipulation.ObjectContext;
            //                    ManipulationRequest manipulationRequest = (ManipulationRequest)dContext.GetObject(this._Manipulation.ManipulationRequest.ObjectID, typeof(ManipulationRequest));
            //                    manipulationRequest.ReportStartDate = Convert.ToDateTime(ReportStartDateManipulationRequest.Text);
            //                    manipulationRequest.ReportEndDate = Convert.ToDateTime(ReportEndDateManipulationRequest.Text);
            //                    dContext.Save();
            //
            //
            //
            //                    RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.takipNoileRaporBilgisiKaydetSync(Sites.SiteLocalHost, raporGirisDVO);
            //                    if (response != null)
            //                    {
            //                        if (response.sonucKodu != null)
            //                        {
            //                            if (response.sonucKodu.Equals(0))
            //                            {
            //                                TTObjectContext context = _Manipulation.ObjectContext;
            //
            //                                MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._Manipulation.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
            //                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
            //                                medulaReportResult.ReportNumber = this._Manipulation.ManipulationRequest.ReportNo.ToString();
            //                                medulaReportResult.ReportRowNumber = response.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
            //                                medulaReportResult.ReportChasingNo = response.raporTakipNo != null ? response.raporTakipNo.ToString() : "";
            //                                medulaReportResult.SendReportDate = Convert.ToDateTime(response.tedaviRapor.raporDVO.raporBilgisi.tarih);
            //                                medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                                medulaReportResult.Manipulation = this._Manipulation;
            //                                context.Save();
            //                            }
            //                            else
            //                            {
            //                                TTObjectContext context = _Manipulation.ObjectContext;
            //                                MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._Manipulation.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
            //
            //                                medulaReportResult.ResultCode = response.sonucKodu.ToString();
            //                                medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //
            //                                medulaReportResult.Manipulation = this._Manipulation;
            //                                medulaReportResult.SendReportDate = DateTime.Now;
            //                                context.Save();
            //
            //                                InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi + " Rapor Takip Numarası Alınamamıştır.!!!");
            //                                return;
            //                            }
            //                        }
            //                        else
            //                        {
            //                            if (!string.IsNullOrEmpty(response.sonucAciklamasi))
            //                            {
            //                                throw new TTException("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
            //                            }
            //
            //                        }
            //                    }
            //
            //                }
            //                else
            //                {
            //                    InfoBox.Show("Hastaya ait provizyon bulunmadığından dolayı raporu  medulaya kayıt edemezsiniz");
            //                }
            //
            //            }
            //            catch (Exception)
            //            {
            //
            //                throw;
            //            }
            //
            #endregion ManipulationRequestAcceptionForm_btnMedulayaKaydet_Click
        }

        private void MedulaReportResults_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region ManipulationRequestAcceptionForm_MedulaReportResults_CellContentClick
            //            if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
            //            {
            //                if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnMeduladanSil"))
            //                {
            //                    ITTGridCell currentCell = MedulaReportResults.CurrentCell;
            //                    if (currentCell != null)
            //                    {
            //                        ITTGridRow currentRow = currentCell.OwningRow;
            //                        if (currentRow != null)
            //                        {
            //                            MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
            //                            if (currentMedulaReportResult != null)
            //                            {
            //
            //                                if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
            //                                {
            //                                    DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
            //                                    if (dialogResult == DialogResult.OK)
            //                                    {
            //                                        try
            //                                        {
            //                                            RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
            //TODO : MEDULA20140501
            //                                            raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //
            //                                            RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
            //                                            _raporOkuDVO.no = currentMedulaReportResult.ReportNumber;
            //                                            _raporOkuDVO.raporSiraNo = currentMedulaReportResult.ReportRowNumber.ToString();
            //                                            _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //                                            _raporOkuDVO.tarih = currentMedulaReportResult.SendReportDate.Value.ToString("dd.MM.yyyy");
            //                                            _raporOkuDVO.turu = "1";
            //                                            raporSorguDVO.raporBilgisi = _raporOkuDVO;
            //
            //                                            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
            //                                            if (response != null)
            //                                            {
            //                                                if (response.sonucKodu != null)
            //                                                {
            //                                                    if (response.sonucKodu.Equals(0))
            //                                                    {
            //
            //                                                        MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
            //                                                        //medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Canceled;
            //                                                        medulaReportResult.ResultCode = response.sonucKodu.ToString();
            //                                                        medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                                                        medulaReportResult.ReportChasingNo = "";
            //                                                        medulaReportResult.ReportNumber = "";
            //                                                        medulaReportResult.ReportRowNumber = null;
            //                                                    }
            //                                                    else
            //                                                    {
            //                                                        if (!string.IsNullOrEmpty(response.sonucAciklamasi))
            //                                                        {
            //                                                            MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
            //                                                            medulaReportResult.ResultCode = response.sonucKodu.ToString();
            //                                                            medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                                                            InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
            //                                                        }
            //
            //                                                    }
            //                                                }
            //
            //                                            }
            //                                        }
            //                                        catch (Exception ex)
            //                                        {
            //
            //                                        }
            //
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    InfoBox.Show("Medulaya Kayıtdı Yapılmamış Bir Hiperbarik Oksijen Tedavi  Raporunu Meduladan Silemezsiniz!!!");
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            var a = 1;
            #endregion ManipulationRequestAcceptionForm_MedulaReportResults_CellContentClick
        }

        protected override void PreScript()
        {
            #region ManipulationRequestAcceptionForm_PreScript
            //MinorManiplation için lazım oldu
            this.DropStateButton(Manipulation.States.Completed);
            base.PreScript();
            if (MedulaReportResults.Rows.Count > 0)
                this.TabSubaction.ShowTabPage(MedulaRaporBilgileriTabPage);
            else
                this.TabSubaction.HideTabPage(MedulaRaporBilgileriTabPage);

            Guid Doctor = new Guid("9431A69C-1A2A-4DCF-B1D3-6B1368318F89"); // Uzman Doktor
            Guid Secretary = new Guid("db5c91e1-2179-4b3e-9b9b-c418b2dee02f");
            Guid Technician = new Guid("992625fd-0883-4854-bcef-9291619bae0a");

            bool doctorProcedureDroped = false;
            bool technicianProcedureDroped = false;

            if (!(Common.CurrentUser.HasRole(Doctor) || Common.CurrentUser.HasRole(Technician)))
            {
                this.DropStateButton(Manipulation.States.RequestingDoctorFromAcception);
            }
            // TODO pnlButton!
            //foreach (Control button in this.pnlButtons.Controls)
            //{
            //    TTObjectStateTransitionDef myTransDef = (TTObjectStateTransitionDef)button.Tag;
            //    if (myTransDef != null)
            //    {
            //        string buttonNo = button.Text.Substring(0, 3);
            //        /*Ekran Sekreter tarafından kullanılacaksa ?Prosedüre Al (Teknsyen)? ve ?Prosedüre Al(Doktor)? butonları yerine, ?Teknisyene Gönder? ve ?Hekime Gönder? butonları olacak .*/
            //        if ((!(Common.CurrentUser.HasRole(Doctor) || Common.CurrentUser.HasRole(Technician))) || Common.CurrentUser.IsSuperUser)
            //        {
            //            //if(ttButton.Tag == Manipulation.States.DoctorProcedure )
            //            if (myTransDef.ToStateDefID == Manipulation.States.DoctorProcedure)
            //            {
            //                button.Text = buttonNo + "Hekime Gönder";
            //            }
            //            else if (myTransDef.ToStateDefID == Manipulation.States.TechnicianProcedure)
            //            {
            //                button.Text = buttonNo + "Teknisyene Gönder";
            //            }
            //        }

            //        /*Ekran Doktor tarafından kullanıacaksa, ?Prosedüre Al(Doktor)? butonları yerine "İşleme Al" buttonları konulup, ?Prosedüre Al (Teknisyen)? buttonu drop edilmeli*/
            //        else if (Common.CurrentUser.HasRole(Doctor))
            //        {
            //            if (!technicianProcedureDroped)
            //            {
            //                this.DropStateButton(Manipulation.States.TechnicianProcedure);
            //                technicianProcedureDroped = true;
            //            }
            //            if (myTransDef.ToStateDefID == Manipulation.States.DoctorProcedure)
            //            {
            //                button.Text = buttonNo + "İşleme Al";
            //            }
            //        }

            //        /*Ekran Teknisyen tarafından kullanıacaksa, ?Prosedüre Al(Teknisyen)? butonları yerine "İşleme Al" buttonları konulup, ?Prosedüre Al (Doktor)? buttonu drop edilmeli*/
            //        else if (Common.CurrentUser.HasRole(Technician))
            //        {
            //            if (!doctorProcedureDroped)
            //            {
            //                this.DropStateButton(Manipulation.States.DoctorProcedure);
            //                doctorProcedureDroped = true;
            //            }
            //            if (myTransDef.ToStateDefID == Manipulation.States.TechnicianProcedure)
            //            {
            //                button.Text = buttonNo + "İşleme Al";
            //            }
            //        }

            //    }
            //}
            
            // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
            //if (this._Manipulation.Episode.PatientStatus == PatientStatusEnum.Outpatient && this._Manipulation.SubEpisode.IsSGK == true && this.IsMedulaProvisionNecessaryProcedureExists() == true)
            //{
            //    this.GunuBirlikTakip.Value = true;
            //    Patient patient = this._Manipulation.ObjectContext.GetObject(this._Manipulation.Episode.Patient.ObjectID, typeof(Patient)) as Patient;
            //    DateTime startDate = Common.RecTime().Date;
            //    DateTime endDate = Common.RecTime().Date.AddDays(1);

            //    List<SubEpisodeProtocol> sepList = patient.GetActiveSGKSEPs(startDate, endDate);
            //    foreach (SubEpisodeProtocol sep in sepList)
            //    {
            //        if (!string.IsNullOrEmpty(sep.MedulaTakipNo) && sep.MedulaTedaviTuru.tedaviTuruKodu.Equals("G"))
            //        {
            //            //this._Manipulation.CreateSubEpisode = false;
            //            this.GunuBirlikTakip.Value = false;
            //        }
            //    }

            //    //TODO Medula!
            //    //if (this.GunuBirlikTakip.Value == true)
            //    //{
            //    //    if (this._Manipulation.MedulaProvision == null)
            //    //    {
            //    //        MedulaProvision _medulaProvision = new MedulaProvision(this._Manipulation.ObjectContext);
            //    //        this._Manipulation.SetMedulaProvisionInitalProperties(_medulaProvision);
            //    //        this._Manipulation.MedulaProvision = _medulaProvision;
            //    //    }
            //    //}
            //}
            //else
            //{
            //    //this._Manipulation.CreateSubEpisode = false;
            //    this.TabSubaction.HideTabPage(MedulaTakipBilgileriTabPage);
            //    this.tedaviTipi.Required = false;
            //    this.takipTipi.Required = false;
            //    this.bransKodu.Required = false;
            //    this.GunuBirlikTakip.Visible = false;
            //    this.GunuBirlikTakip.Required = false;
            //}

            /*************/
            /*Ön bilgi ekranına Manip. Req. ekranındaki Önbilgi */
            #endregion ManipulationRequestAcceptionForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region ManipulationRequestAcceptionForm_PostScript
            base.PostScript(transDef);
            if (transDef != null)
            {
                foreach (SubActionProcedure proc in _Manipulation.SubactionProcedures)
                {
                    if (proc.ProcedureDoctor == null && transDef.ToStateDefID != Manipulation.States.TechnicianProcedure && transDef.ToStateDefID != Manipulation.States.NursingProcedure && transDef.ToStateDefID != Manipulation.States.RequestingDoctorFromAcception)
                    {
                        throw new Exception(SystemMessage.GetMessage(1133));
                    }
                }

                //TODO Sequence!
                //if (transDef.ToStateDef.StateDefID == Manipulation.States.DoctorProcedure || transDef.ToStateDef.StateDefID == Manipulation.States.Appointment || transDef.ToStateDef.StateDefID == Manipulation.States.TechnicianProcedure)
                //{
                //    System.Reflection.PropertyInfo propInfo = this._EpisodeAction.GetType().GetProperty("ProtocolNo");
                //    if (propInfo != null && propInfo.PropertyType == typeof(TTSequence))
                //    {
                //        TTSequence protocolNo = propInfo.GetValue(this._EpisodeAction, null) as TTSequence;
                //        if (protocolNo.Value == null)
                //            protocolNo.GetNextValue(this._EpisodeAction.MasterResource.ObjectID.ToString(), Common.RecTime().Year);
                //    }
                //}
                var a = 1;
            }
            #endregion ManipulationRequestAcceptionForm_PostScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region ManipulationRequestAcceptionForm_ClientSidePostScript
            base.ClientSidePostScript(transDef);
            if (transDef != null)
            {

                if (transDef.ToStateDef.StateDefID == Manipulation.States.RequestingDoctorFromDoctorProcedure)
                {
                    StringEntryForm frm = new StringEntryForm();
                    ManipulationReturnReasonsGrid mrg = new ManipulationReturnReasonsGrid(_Manipulation.ObjectContext);
                    mrg.ReturnReason = frm.ShowAndGetStringForm("İade Sebebi").ToString();
                    _Manipulation.ManipulationReturnReasons.Add(mrg);
                }

                if (transDef.ToStateDef.StateDefID == Manipulation.States.NursingProcedure || transDef.ToStateDef.StateDefID == Manipulation.States.DoctorProcedure || transDef.ToStateDef.StateDefID == Manipulation.States.Appointment || transDef.ToStateDef.StateDefID == Manipulation.States.TechnicianProcedure)
                {
                    bool askUser = false;

                    foreach (ManipulationProcedure manProc in _Manipulation.ManipulationProcedures)
                    {
                        if (manProc.ProcedureObject != null && manProc.ProcedureObject.OnamFormuIste != null && ((SurgeryDefinition)manProc.ProcedureObject).OnamFormuIste == true)
                        {
                            askUser = true;
                        }
                    }

                    if (askUser)
                    {
                        _Manipulation.IsPatientApprovalFormGiven = this.GetIfPatientApprovalFormIsGiven(_Manipulation.IsPatientApprovalFormGiven);
                    }
                }

                //TODO Medula!
                //if ((transDef.ToStateDef.StateDefID == Manipulation.States.DoctorProcedure || transDef.ToStateDef.StateDefID == Manipulation.States.TechnicianProcedure ||
                //     transDef.ToStateDef.StateDefID == Manipulation.States.NursingProcedure) && transDef.FromStateDefID == Manipulation.States.RequestAcception)
                //{
                //    // Medula Takip İşlemleri
                //    if (_Manipulation.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(_Manipulation.Episode) == true && this.IsMedulaProvisionNecessaryProcedureExists() == true)
                //    {
                //        if (_Manipulation.IsGunubirlikTakip == true)
                //        {

                //            if (_Manipulation.MedulaProvision == null)
                //            {
                //                MedulaProvision _medulaProvision = new MedulaProvision(_Manipulation.ObjectContext);
                //                _Manipulation.SetMedulaProvisionInitalProperties(_medulaProvision);
                //                _Manipulation.MedulaProvision = _medulaProvision;
                //            }
                //            _Manipulation.GetManipulationMedulaTakip();
                //        }
                //        else
                //        {
                //            string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Uyarı", "Günübirlik Takip Al alanı işaretlenmediğinden takip alınmadan işleme devam edilecektir.Devam Etmek İstiyor Musunuz?");
                //            if (result == "V")
                //                throw new TTUtils.TTException("İşlemden vazgeçildi.");
                //            else
                //                _Manipulation.CreateSubEpisode = false;
                //        }
                //    }
                //}
                var a = 1;
            }
            #endregion ManipulationRequestAcceptionForm_ClientSidePostScript

        }
    }
}