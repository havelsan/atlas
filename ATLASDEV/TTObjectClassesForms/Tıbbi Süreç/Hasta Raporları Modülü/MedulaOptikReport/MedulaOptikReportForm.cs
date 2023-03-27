
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
    public partial class MedulaOptikReportForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnRaporSorgula.Click += new TTControlEventDelegate(btnRaporSorgula_Click);
            btnRaporGiris.Click += new TTControlEventDelegate(btnRaporGiris_Click);
            ProcedureDoctor.SelectedObjectChanged += new TTControlEventDelegate(ProcedureDoctor_SelectedObjectChanged);
            gridRaporlar.CellContentClick += new TTGridCellEventDelegate(gridRaporlar_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnRaporSorgula.Click -= new TTControlEventDelegate(btnRaporSorgula_Click);
            btnRaporGiris.Click -= new TTControlEventDelegate(btnRaporGiris_Click);
            ProcedureDoctor.SelectedObjectChanged -= new TTControlEventDelegate(ProcedureDoctor_SelectedObjectChanged);
            gridRaporlar.CellContentClick -= new TTGridCellEventDelegate(gridRaporlar_CellContentClick);
            base.UnBindControlEvents();
        }

        private void btnRaporSorgula_Click()
        {
#region MedulaOptikReportForm_btnRaporSorgula_Click
   if(this._MedulaOptikReport.ProcedureDoctor == null)
            {
                throw new Exception("Raporu yazan doktor alanı boş olamaz!");
            }
            
            gridRaporlar.Rows.Clear();
            OptikRaporIslemleri.eraporListeSorguIstekDVO _eraporListeSorguIstekDVO = new OptikRaporIslemleri.eraporListeSorguIstekDVO();
            _eraporListeSorguIstekDVO.doktorTcKimlikNo = this._MedulaOptikReport.ProcedureDoctor.UniqueNo;
            _eraporListeSorguIstekDVO.hastaTcKimlikNo = this._MedulaOptikReport.Episode.Patient.UniqueRefNo.Value.ToString();
            _eraporListeSorguIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();

            OptikRaporIslemleri.eraporListeSorguCevapDVO response = OptikRaporIslemleri.WebMethods.eraporListeSorgula(Sites.SiteLocalHost, this._MedulaOptikReport.ProcedureDoctor.UniqueNo, this._MedulaOptikReport.ERecetePassword, _eraporListeSorguIstekDVO);
            if (response != null && response.sonucKodu != null)
            {
                if (response.sonucKodu.Equals("0"))
                {
                    if(response.eraporListesi != null && response.eraporListesi.Length > 0)
                    {
                        foreach (OptikRaporIslemleri.raporTesisDVO _raporTesisDVO in response.eraporListesi)
                        {
                            ITTGridRow newRow = gridRaporlar.Rows.Add();
                            newRow.Cells[raporBaslangicTarihi.Name].Value = _raporTesisDVO.raporBaslangicTarih;
                            newRow.Cells[raporBitisTarihi.Name].Value = _raporTesisDVO.raporBitisTarih;
                            newRow.Cells[raporTeshis.Name].Value = _raporTesisDVO.raporTeshis;
                            newRow.Cells[drTCKNo.Name].Value = _raporTesisDVO.doktorTcKimlikNo;
                            newRow.Cells[raporNoTesis.Name].Value = _raporTesisDVO.raporNoTesis;
                            newRow.Cells[raporTip.Name].Value = _raporTesisDVO.tip;
                            newRow.Cells[raporTakipNo.Name].Value = _raporTesisDVO.takipNo;
                            newRow.Cells[raporTarihi.Name].Value = _raporTesisDVO.raporTarih;
                            newRow.Cells[protokolNo.Name].Value = _raporTesisDVO.protokolNo;
                            newRow.Cells[raporDuzenlenmeTuru.Name].Value = string.IsNullOrEmpty(_raporTesisDVO.raporDuzenlemeTuru) == false ? Common.GetEnumValueDefOfEnumValueV2("MedulaOptikRaporDuzenlenmeTuruEnum",Convert.ToInt32(_raporTesisDVO.raporDuzenlemeTuru)) : null;
                            newRow.Cells[kayitSekli.Name].Value = string.IsNullOrEmpty(_raporTesisDVO.raporKayitSekli) == false ? Common.GetEnumValueDefOfEnumValueV2("MedulaOptikRaporKayitSekliEnum", Convert.ToInt32(_raporTesisDVO.raporKayitSekli)) : null;
                            newRow.Cells[durum.Name].Value = _raporTesisDVO.durum;
                            newRow.Cells[raporSonucKodu.Name].Value = response.sonucKodu;
                            newRow.Cells[raporSonucMesaji.Name].Value = response.sonucMesaji;
                            newRow.Cells[raporUyariMesaji.Name].Value = response.uyariMesaji;
                            newRow.Cells[objectID.Name].Value = this._MedulaOptikReport.ObjectID.ToString();
                        }
                    }
                }
            }
#endregion MedulaOptikReportForm_btnRaporSorgula_Click
        }

        private void btnRaporGiris_Click()
        {
#region MedulaOptikReportForm_btnRaporGiris_Click
   if (this._MedulaOptikReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._MedulaOptikReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                try
                {
                    if(this._MedulaOptikReport.raporId != null)
                    {
                        throw new Exception("Rapor zaten Medula' da kayıtlıdır.");
                    }
                    else
                    {
                        this.SonucKodu.Text = "";
                        this.SonucMesaji.Text = "";
                        this.UyariMesaji.Text = "";
                    }
                    
                    CheckRequiredFields("eRaporGiris");
                    this._MedulaOptikReport.ObjectContext.Save();
                    OptikRaporIslemleri.raporTesisDVO raporTesisDVO = new OptikRaporIslemleri.raporTesisDVO();
                    raporTesisDVO.sigortaliTckNo = this._MedulaOptikReport.Episode.Patient.UniqueRefNo.ToString();
                    raporTesisDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();
                    raporTesisDVO.raporBaslangicTarih = (this._MedulaOptikReport.RaporBaslangicTarih.Value.Date.ToString("dd.MM.yyyy"));
                    raporTesisDVO.raporBitisTarih = (this._MedulaOptikReport.RaporBitisTarih.Value.Date.ToString("dd.MM.yyyy"));
                    raporTesisDVO.raporTeshis = this._MedulaOptikReport.DiagnosisDefinition.Name;
                    //TTNebulaServices.ApplicationService appSrv = TTNebulaServices.ApplicationService.Instance;
                    //long value = appSrv.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["OptikRaporSequence"].DataTypeID , null, null);
                    //raporTesisDVO.raporNoTesis = value.ToString();//this._MedulaOptikReport.RaporSequenceNo.ToString();
                    raporTesisDVO.raporNoTesis = this._MedulaOptikReport.RaporSequenceNo.ToString();
                    raporTesisDVO.doktorTcKimlikNo = this._MedulaOptikReport.ProcedureDoctor.UniqueNo;
                    // raporTesisDVO.dr1TckNo = raporTesisDVO.doktorTcKimlikNo;
                    int i = 0;
                    int count = _MedulaOptikReport.OptikDoctorsGrid.Count;
                    while(i<count)
                    {
                        raporTesisDVO.dr1TckNo = this._MedulaOptikReport.ProcedureDoctor.UniqueNo;
                        if(i == 0)
                            raporTesisDVO.dr2TckNo = _MedulaOptikReport.OptikDoctorsGrid[i].ResUser.UniqueNo;
                        if(i == 1)
                            raporTesisDVO.dr3TckNo = _MedulaOptikReport.OptikDoctorsGrid[i].ResUser.UniqueNo;
                        if(i == 2)
                            raporTesisDVO.dr4TckNo = _MedulaOptikReport.OptikDoctorsGrid[i].ResUser.UniqueNo;
                        if(i == 3)
                            raporTesisDVO.dr5TckNo = _MedulaOptikReport.OptikDoctorsGrid[i].ResUser.UniqueNo;
                        if(i == 4)
                            raporTesisDVO.dr6TckNo = _MedulaOptikReport.OptikDoctorsGrid[i].ResUser.UniqueNo;
                        i++;
                    }
                    raporTesisDVO.tip = Common.GetDescriptionOfDataTypeEnum(this._MedulaOptikReport.RaporTipi.Value);
                    raporTesisDVO.aciklama = this._MedulaOptikReport.RaporAciklama;
                    raporTesisDVO.takipNo = this._MedulaOptikReport.SubEpisode.SGKSEP.MedulaTakipNo;
                    raporTesisDVO.raporTarih = this._MedulaOptikReport.RequestDate.Value.Date.ToString("dd.MM.yyyy");
                    raporTesisDVO.protokolNo = this._MedulaOptikReport.Episode.HospitalProtocolNo.ToString();
                    raporTesisDVO.raporDuzenlemeTuru = Common.GetDescriptionOfDataTypeEnum(this._MedulaOptikReport.RaporDuzenlemeTuru.Value);
                    raporTesisDVO.raporKayitSekli = Common.GetDescriptionOfDataTypeEnum(this._MedulaOptikReport.RaporKayitSekli.Value);
                    raporTesisDVO.durum = null;
                    
                    //List<OptikRaporIslemleri.eraporTaniDVO> _eraporTaniDVOList = new List<OptikRaporIslemleri.eraporTaniDVO>();
                    OptikRaporIslemleri.eraporTaniDVO _eraporTaniDVO = new OptikRaporIslemleri.eraporTaniDVO();
                    foreach (DiagnosisGrid diagnosis in this._MedulaOptikReport.SecDiagnosis)
                    {
                        
                        _eraporTaniDVO.taniKodu = diagnosis.Diagnose.Code;
                        _eraporTaniDVO.taniAdi = diagnosis.Diagnose.Name;
                        break;
                        // _eraporTaniDVOList.Add(_eraporTaniDVO);

                    }
                    raporTesisDVO.eraporTaniListesi = _eraporTaniDVO;// _eraporTaniDVOList.ToArray();
                    string eRecetePwd = null;
                    if(this._MedulaOptikReport.ProcedureDoctor.ErecetePassword != null)
                    {
                        eRecetePwd = this._MedulaOptikReport.ProcedureDoctor.ErecetePassword;
                        this._MedulaOptikReport.ERecetePassword = eRecetePwd;
                    }
                    else
                        eRecetePwd = this._MedulaOptikReport.ERecetePassword;
                    
                    OptikRaporIslemleri.eRaporSonucDVO response = OptikRaporIslemleri.WebMethods.eraporGiris(Sites.SiteLocalHost,this._MedulaOptikReport.ProcedureDoctor.UniqueNo,eRecetePwd, raporTesisDVO);
                    if (response != null && response.sonucKodu != null)
                    {
                        _MedulaOptikReport.SonucKodu = response.sonucKodu.ToString();
                        _MedulaOptikReport.SonucMesaji = response.sonucMesaji;
                        _MedulaOptikReport.UyariMesaji = response.uyariMesaji;
                        
                        //                        if (response.sonucKodu.Equals("0000"))
                        //                        {
                        _MedulaOptikReport.raporId = response.raporId;
                        _MedulaOptikReport.RaporTakipNo = raporTesisDVO.takipNo;
                        _MedulaOptikReport.Durum = response.raporTesisDVO != null ? response.raporTesisDVO.durum : "";
                        // _MedulaOptikReport.RaporSequenceNo = Convert.ToInt32(response.raporTesisDVO.raporNoTesis);
                        //                        ITTGridRow newRow = gridRaporlar.Rows.Add();
                        //                        if(response.raporTesisDVO != null)
                        //                        {
                        //                            newRow.Cells[raporBaslangicTarihi.Name].Value = response.raporTesisDVO.raporBaslangicTarih;
                        //                            newRow.Cells[raporBitisTarihi.Name].Value = response.raporTesisDVO.raporBitisTarih;
                        //                            newRow.Cells[raporTeshis.Name].Value = response.raporTesisDVO.raporTeshis;
                        //                            newRow.Cells[drTCKNo.Name].Value = response.raporTesisDVO.doktorTcKimlikNo;
                        //                            newRow.Cells[raporNo.Name].Value = response.raporId;
                        //                            newRow.Cells[raporNoTesis.Name].Value = _MedulaOptikReport.RaporSequenceNo != null ? _MedulaOptikReport.RaporSequenceNo.ToString() : "";
                        //                            newRow.Cells[raporTip.Name].Value = response.raporTesisDVO.tip;
                        //                            newRow.Cells[raporTakipNo.Name].Value = response.raporTesisDVO.takipNo;
                        //                            newRow.Cells[raporTarihi.Name].Value = response.raporTesisDVO.raporTarih;
                        //                            newRow.Cells[protokolNo.Name].Value = response.raporTesisDVO.protokolNo;
                        //                            newRow.Cells[raporDuzenlenmeTuru.Name].Value = string.IsNullOrEmpty(response.raporTesisDVO.raporDuzenlemeTuru) == false ? Common.GetEnumValueDefOfEnumValue("MedulaOptikRaporDuzenlenmeTuruEnum", Convert.ToInt32(response.raporTesisDVO.raporDuzenlemeTuru)) : null;
                        //                            newRow.Cells[kayitSekli.Name].Value = string.IsNullOrEmpty(response.raporTesisDVO.raporKayitSekli) == false ? Common.GetEnumValueDefOfEnumValue("MedulaOptikRaporKayitSekliEnum", Convert.ToInt32(response.raporTesisDVO.raporKayitSekli)) : null;
                        //                            newRow.Cells[durum.Name].Value = response.raporTesisDVO.durum;
                        //                        }
                        //                        newRow.Cells[raporSonucKodu.Name].Value =  response.sonucKodu.ToString();
                        //                        newRow.Cells[raporSonucMesaji.Name].Value = response.sonucMesaji;
                        //                        newRow.Cells[raporUyariMesaji.Name].Value =response.uyariMesaji;
                        //                        newRow.Cells[objectID.Name].Value = this._MedulaOptikReport.ObjectID.ToString();
//
                        // }
                    }
                    else
                    {
                        _MedulaOptikReport.SonucMesaji = "Meduladan cevap alınamadı!";
                        throw new TTUtils.TTException("Meduladan cevap alınamadı!");
                    }
                }
                catch(Exception)
                {
                    throw;
                }
            }
            else
                InfoBox.Show("Hastaya ait aktif bir medula provizyon bilgisi bulunamamıştır. Öncelik olarak hastaya medula provizyon alınız!!!");
#endregion MedulaOptikReportForm_btnRaporGiris_Click
        }

        private void ProcedureDoctor_SelectedObjectChanged()
        {
#region MedulaOptikReportForm_ProcedureDoctor_SelectedObjectChanged
   if(this.ProcedureDoctor.SelectedObject != null)
            {
                if(((ResUser)this.ProcedureDoctor.SelectedObject).UniqueNo == null)
                {
                    InfoBox.Show(((ResUser)this.ProcedureDoctor.SelectedObject).Name + " isimli doktorun TC Kimlik numarası tanımlanmamış. Lütfen Kullanıcı Tanımları ekranından tanımlatınız.");
                    this.ProcedureDoctor.SelectedObject = null;
                    return;
                }
                bool gozDoktoru = false;
                foreach (ResourceSpecialityGrid sp in ((ResUser)this.ProcedureDoctor.SelectedObject).ResourceSpecialities)
                {
                    if(sp.Speciality.Code == "2900") // Göz hastalıkları branş kodu
                    {
                        gozDoktoru = true;
                        break;
                    }
                }
                if(!gozDoktoru)
                {
                    InfoBox.Show(((ResUser)this.ProcedureDoctor.SelectedObject).Name + " isimli doktorun uzmanlık dalları arasında Göz Hastalıkları branşı bulunmamaktadır.");
                    this.ProcedureDoctor.SelectedObject = null;
                    return;
                }
                
                if(((ResUser)this.ProcedureDoctor.SelectedObject).ErecetePassword != null)
                    this._MedulaOptikReport.ERecetePassword = ((ResUser)this.ProcedureDoctor.SelectedObject).ErecetePassword;
            }
#endregion MedulaOptikReportForm_ProcedureDoctor_SelectedObjectChanged
        }

        private void gridRaporlar_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaOptikReportForm_gridRaporlar_CellContentClick
   try
            {
                if (gridRaporlar.Rows.Count > 0 && gridRaporlar.CurrentCell != null)
                {
                    if ((((ITTGridCell)gridRaporlar.CurrentCell).OwningColumn != null) && (((ITTGridCell)gridRaporlar.CurrentCell).OwningColumn.Name == "raporSil"))
                    {
                        //                        if(gridRaporlar.CurrentCell.OwningRow.Cells[raporNo.Name].Value == null)
                        //                        {
                        //                            InfoBox.Show("Rapor Numarası boş olan rapor silinemez.");
                        //                            return;
                        //                        }
                        
                        if(gridRaporlar.CurrentCell.OwningRow.Cells[raporTakipNo.Name].Value == null)
                        {
                            InfoBox.Show("Rapor Takip Numarası boş olan rapor silinemez.");
                            return;
                        }
                        
                        string result = "";
                        
                        result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Medula Optik Rapor Sil", gridRaporlar.CurrentCell.OwningRow.Cells[raporTakipNo.Name].Value.ToString() + " nolu raporu Medula'dan silmek istediğinize emin misiniz?");
                        if ("H".Equals(result))
                        {
                            InfoBox.Show("İşlemden Vazgeçildi.");
                            return;
                        }
                        else
                        {
                            OptikRaporIslemleri.eraporSilDVO _eraporSilDVO = new OptikRaporIslemleri.eraporSilDVO();
                            _eraporSilDVO.doktorTcKimlikNo = this._MedulaOptikReport.ProcedureDoctor.UniqueNo;
                            _eraporSilDVO.raporNoTesis = gridRaporlar.CurrentCell.OwningRow.Cells[raporNoTesis.Name].Value.ToString();
                            _eraporSilDVO.takipNo = gridRaporlar.CurrentCell.OwningRow.Cells[raporTakipNo.Name].Value.ToString();
                            _eraporSilDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();
                            
                            string eRecetePwd = null;
                            if(this._MedulaOptikReport.ProcedureDoctor.ErecetePassword != null)
                            {
                                eRecetePwd = this._MedulaOptikReport.ProcedureDoctor.ErecetePassword;
                                this._MedulaOptikReport.ERecetePassword = eRecetePwd;
                            }
                            else
                                eRecetePwd = this._MedulaOptikReport.ERecetePassword;
                            OptikRaporIslemleri.eRaporSonucDVO response = OptikRaporIslemleri.WebMethods.eraporSil(Sites.SiteLocalHost, this._MedulaOptikReport.ProcedureDoctor.UniqueNo, eRecetePwd, _eraporSilDVO);
                            if (response != null && response.sonucKodu != null)
                            {
                                gridRaporlar.CurrentCell.OwningRow.Cells[raporSonucKodu.Name].Value = response.sonucKodu.ToString();
                                gridRaporlar.CurrentCell.OwningRow.Cells[raporSonucMesaji.Name].Value = response.sonucMesaji;
                                gridRaporlar.CurrentCell.OwningRow.Cells[durum.Name].Value = response.raporTesisDVO != null ? response.raporTesisDVO.durum : "";
                                this._MedulaOptikReport.raporId = null;
                                _MedulaOptikReport.RaporTakipNo = null;
                            }
                            else
                            {
                                gridRaporlar.CurrentCell.OwningRow.Cells[raporSonucMesaji.Name].Value = "Meduladan cevap alınamadı!";
                                throw new TTUtils.TTException("Meduladan cevap alınamadı!");
                            }
                        }
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
#endregion MedulaOptikReportForm_gridRaporlar_CellContentClick
        }

        protected override void PreScript()
        {
#region MedulaOptikReportForm_PreScript
    base.PreScript();
            if(this._MedulaOptikReport.CurrentStateDefID == MedulaOptikReport.States.New)
            {
                if (this._MedulaOptikReport.SubEpisode.SGKSEP == null || string.IsNullOrEmpty(this._MedulaOptikReport.SubEpisode.SGKSEP.MedulaTakipNo))
                {
                    throw new Exception("Takip no alınmamış vakalarda 'Medula Optik Raporu' işlemi başlatılamaz.");
                }
                
              
                
                this.SetProcedureDoctorAsCurrentResource();
//                if(this._MedulaOptikReport.ProcedureDoctor == null)
//                {
//                     throw new Exception("Uzmanlık dalınız tanımlı olmadığı için optik raporu yazamazsınız.");
//                }
//                
//                OptikRaporIslemleri.eraporListeSorguIstekDVO _eraporListeSorguIstekDVO = new OptikRaporIslemleri.eraporListeSorguIstekDVO();
//                _eraporListeSorguIstekDVO.doktorTcKimlikNo = this._MedulaOptikReport.ProcedureDoctor.UniqueNo;
//                _eraporListeSorguIstekDVO.hastaTcKimlikNo = this._MedulaOptikReport.Episode.Patient.UniqueRefNo.Value.ToString();
//                _eraporListeSorguIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();
//
//                OptikRaporIslemleri.eraporListeSorguCevapDVO response = OptikRaporIslemleri.WebMethods.eraporListeSorgula(Sites.SiteLocalHost, this._MedulaOptikReport.ProcedureDoctor.UniqueNo, this._MedulaOptikReport.ERecetePassword, _eraporListeSorguIstekDVO);
//                if (response != null && response.sonucKodu != null)
//                {
//                    //                    if (response.sonucKodu.Equals("0000"))
//                    //                    {
//                    if(response.eraporListesi != null)
//                    {
//                        foreach (OptikRaporIslemleri.raporTesisDVO _raporTesisDVO in response.eraporListesi)
//                        {
//                            ITTGridRow newRow = gridRaporlar.Rows.Add();
//                            newRow.Cells[raporBaslangicTarihi.Name].Value = _raporTesisDVO.raporBaslangicTarih;
//                            newRow.Cells[raporBitisTarihi.Name].Value = _raporTesisDVO.raporBitisTarih;
//                            newRow.Cells[raporTeshis.Name].Value = _raporTesisDVO.raporTeshis;
//                            newRow.Cells[drTCKNo.Name].Value = _raporTesisDVO.doktorTcKimlikNo;
//                            newRow.Cells[raporNoTesis.Name].Value = _raporTesisDVO.raporNoTesis;
//                            newRow.Cells[raporTip.Name].Value = _raporTesisDVO.tip;
//                            newRow.Cells[raporTakipNo.Name].Value = _raporTesisDVO.takipNo;
//                            newRow.Cells[raporTarihi.Name].Value = _raporTesisDVO.raporTarih;
//                            newRow.Cells[protokolNo.Name].Value = _raporTesisDVO.protokolNo;
//                            newRow.Cells[raporDuzenlenmeTuru.Name].Value = string.IsNullOrEmpty(_raporTesisDVO.raporDuzenlemeTuru) == false ? Common.GetEnumValueDefOfEnumValue("MedulaOptikRaporDuzenlenmeTuruEnum",Convert.ToInt32(_raporTesisDVO.raporDuzenlemeTuru)) : null;
//                            newRow.Cells[kayitSekli.Name].Value = string.IsNullOrEmpty(_raporTesisDVO.raporKayitSekli) == false ? Common.GetEnumValueDefOfEnumValue("MedulaOptikRaporKayitSekliEnum", Convert.ToInt32(_raporTesisDVO.raporKayitSekli)) : null;
//                            newRow.Cells[durum.Name].Value = _raporTesisDVO.durum;
//                            newRow.Cells[raporSonucKodu.Name].Value = response.sonucKodu;
//                            newRow.Cells[raporSonucMesaji.Name].Value = response.sonucMesaji;
//                            newRow.Cells[raporUyariMesaji.Name].Value = response.uyariMesaji;
//                            newRow.Cells[objectID.Name].Value = this._MedulaOptikReport.ObjectID.ToString();
//                        }
//                        // }
//                    }
//                }
                
                
            }
#endregion MedulaOptikReportForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region MedulaOptikReportForm_ClientSidePreScript
    base.ClientSidePreScript();
            
              ResUser currentUser = Common.CurrentResource;
                ((ITTObject)currentUser).Refresh();
                if (string.IsNullOrEmpty(currentUser.ErecetePassword))
                {
                    TTVisual.TTForm eRecetePasswordForm = new TTFormClasses.MedulaOptikPasswordForm();
                    eRecetePasswordForm.ShowEdit(this.FindForm(), _MedulaOptikReport, true);
                }
                else
                    _MedulaOptikReport.ERecetePassword = currentUser.ErecetePassword;
                bool gozDoktoru = false;
                if (currentUser.ResourceSpecialities.Count > 0)
                {
                    foreach (ResourceSpecialityGrid sGrid in currentUser.ResourceSpecialities)
                    {
                        if (sGrid.Speciality.Code == "2900")//Göz Hastalıkları
                        {
                            gozDoktoru = true;
                            break;
                        }
                    }
                    if(!gozDoktoru)
                        throw new Exception("Uzmanlık dallarınız arasında 'Göz Hastalıkları' uzmanlık dalı tanımlı olmadığı için optik raporu yazamazsınız.");
                }
                else
                    throw new Exception("Uzmanlık dalınız tanımlı olmadığı için optik raporu yazamazsınız.");
#endregion MedulaOptikReportForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MedulaOptikReportForm_PostScript
    base.PostScript(transDef);
            if(this._MedulaOptikReport.TransDef != null )
            {
                if(this._MedulaOptikReport.TransDef.ToStateDefID == MedulaOptikReport.States.Approval)
                {
                    if (string.IsNullOrEmpty(this._MedulaOptikReport.RaporTakipNo))
                    {
                        throw new Exception("Raporu Medula'ya kaydetmeden Onay adımına geçemezsiniz.");
                    }
                }
            }
#endregion MedulaOptikReportForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region MedulaOptikReportForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if(transDef != null && transDef.ToStateDefID == MedulaOptikReport.States.Cancelled)
            {
                if(this._MedulaOptikReport.eReceteNo != null && this._MedulaOptikReport.RaporSequenceNo != null)
                {
                    string result = "";
                    result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Medula Optik Rapor Sil", this._MedulaOptikReport.RaporSequenceNo.ToString() + " nolu raporu Medula'dan silmek istediğinize emin misiniz?");
                    if ("H".Equals(result))
                    {
                        throw new Exception("İşlemden Vazgeçildi.");
                    }
                }
            }
#endregion MedulaOptikReportForm_ClientSidePostScript

        }

#region MedulaOptikReportForm_Methods
        public override void SetProcedureDoctorAsCurrentResource()
        {
            if(this._MedulaOptikReport.ProcedureDoctor == null)
            {
                if (Common.CurrentResource.UserType == UserTypeEnum.Doctor)
                {
                    bool gozDoktoru = false;
                    foreach (ResourceSpecialityGrid sp in Common.CurrentResource.ResourceSpecialities)
                    {
                        if(sp.Speciality.Code == "2900") //Göz hastalıkları branş kodu
                        {
                            gozDoktoru = true;
                            break;
                        }
                    }
                    if(gozDoktoru)
                    {
                        this._MedulaOptikReport.ProcedureDoctor = Common.CurrentResource;
                    }
                }
                
                if (((ITTObject)this._MedulaOptikReport).HasErrors == true)
                    throw new Exception(((ITTObject)this._MedulaOptikReport).GetErrors());
            }
        }
        
        private void CheckRequiredFields(string methodName)
        {
            switch(methodName)
            {
                case "eRaporGiris":
                    if(_MedulaOptikReport.RequestDate.HasValue == false)
                        throw new Exception("Rapor Tarihi boş olamaz.");
                    
                    if(_MedulaOptikReport.RaporBaslangicTarih.HasValue == false)
                        throw new Exception("Rapor Başlangıç Tarihi boş olamaz.");
                    
                    if(_MedulaOptikReport.RaporBitisTarih.HasValue == false)
                        throw new Exception("Rapor Bitiş Tarihi boş olamaz.");
                    
                    if(_MedulaOptikReport.DiagnosisDefinition == null)
                        throw new Exception("Raporun Teşhisi boş olamaz.");
                    
                    if(_MedulaOptikReport.ProcedureDoctor == null)
                        throw new Exception("Raporu Yazan Doktor boş olamaz.");
                    
                    if(_MedulaOptikReport.RaporTipi.HasValue == false)
                        throw new Exception("Rapor Tipi boş olamaz.");
                    
                    if(_MedulaOptikReport.RaporDuzenlemeTuru.HasValue == false)
                        throw new Exception("Rapor Düzenlenme Türü boş olamaz.");
                    
                    if(_MedulaOptikReport.RaporKayitSekli.HasValue == false)
                        throw new Exception("Rapor Kayıt Şekli boş olamaz.");
                    
                    if(_MedulaOptikReport.SecDiagnosis.Count == 0)
                        throw new Exception("Raporun Tanıları boş olamaz.");
                    
                    if(_MedulaOptikReport.RaporDuzenlemeTuru.HasValue == false)
                        throw new Exception("Rapor Düzenlenme Türü boş olamaz.");
                    
                    if(String.IsNullOrEmpty(_MedulaOptikReport.RaporAciklama))
                        throw new Exception("Açıklama boş olamaz.");

                    if (_MedulaOptikReport.OptikDoctorsGrid.Count < 3 || _MedulaOptikReport.OptikDoctorsGrid.Count > 5)
                        throw new Exception("İşlemi yapan doktor sayısı en az 3 en fazla 5 olmalıdır.");
                    break;
                default:
                    break;
            }
        }
        
#endregion MedulaOptikReportForm_Methods
    }
}