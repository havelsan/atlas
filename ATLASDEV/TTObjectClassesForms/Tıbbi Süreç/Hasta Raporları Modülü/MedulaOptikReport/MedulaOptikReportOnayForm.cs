
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
    public partial class MedulaOptikReportOnayForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnBashekimOnay.Click += new TTControlEventDelegate(btnBashekimOnay_Click);
            DoctorsGrid.CellContentClick += new TTGridCellEventDelegate(DoctorsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnBashekimOnay.Click -= new TTControlEventDelegate(btnBashekimOnay_Click);
            DoctorsGrid.CellContentClick -= new TTGridCellEventDelegate(DoctorsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void btnBashekimOnay_Click()
        {
#region MedulaOptikReportOnayForm_btnBashekimOnay_Click
   if(_MedulaOptikReport.RaporTakipNo != null)
            {
                OptikRaporIslemleri.eraporBashekimOnayIstekDVO _eraporBashekimOnayIstekDVO = new OptikRaporIslemleri.eraporBashekimOnayIstekDVO();
                string password = "";
                string basHekimObjectID = TTObjectClasses.SystemParameter.GetParameterValue("KURUMSALYONETICI_OBJECTID", "XXXXXX");
                BindingList<ResUser.GetUserByID_Class> basTabipList = ResUser.GetUserByID(basHekimObjectID);
                if (basTabipList == null || basTabipList.Count == 0)
                {
                    InfoBox.Show("Baş Tabip Boş Olamaz !!!");
                    return;
                }
                else
                {
                    if (!string.IsNullOrEmpty(basTabipList[0].ErecetePassword))
                        password = basTabipList[0].ErecetePassword;
                    else
                    {
                        InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                        return;
                    }
                }
                if (basTabipList[0].Tcno != null)
                    _eraporBashekimOnayIstekDVO.doktorTcKimlikNo = basTabipList[0].Tcno.ToString();
                else
                {
                    InfoBox.Show("Başhekim TC Kimlik Numarası Boş Olamaz");
                    return;
                }
                
                
                //  _eraporBashekimOnayIstekDVO.doktorTcKimlikNo = this.ProcedureDoctor.UniqueNo;//Buraya başhekimin uniqueNo sunu göndermek gerekebilir.
                _eraporBashekimOnayIstekDVO.raporTakipNo = _MedulaOptikReport.RaporTakipNo;
                _eraporBashekimOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();
                
                //                string eRecetePwd = null;
                //                if(this.ProcedureDoctor.ErecetePassword != null)
                //                {
                //                    eRecetePwd = this.ProcedureDoctor.ErecetePassword;
                //                    this.ERecetePassword = eRecetePwd;
                //                }
                //                else
                //                    eRecetePwd = this.ERecetePassword;
                OptikRaporIslemleri.eraporBashekimOnayCevapDVO response = OptikRaporIslemleri.WebMethods.eraporBashekimOnay(Sites.SiteLocalHost, _eraporBashekimOnayIstekDVO.doktorTcKimlikNo , password, _eraporBashekimOnayIstekDVO);
                if (response != null && response.sonucKodu != null)
                {
                    this.SonucKodu.Text = response.sonucKodu.ToString();
                    this.SonucMesaji.Text = response.sonucMesaji;
                    this.UyariMesaji.Text = response.uyariMesaji;
                    if(response.sonucKodu =="0")
                        _MedulaOptikReport.IsHeadDoctorApproved = true ;
                }
                else
                {
                    this.SonucMesaji.Text = "Meduladan cevap alınamadı!";
                    throw new TTUtils.TTException("Meduladan cevap alınamadı!");
                }
            }
            else
            {
                InfoBox.Show("Rapor Takip Numarası boş olamaz ! ");
                return;
            }
#endregion MedulaOptikReportOnayForm_btnBashekimOnay_Click
        }

        private void DoctorsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaOptikReportOnayForm_DoctorsGrid_CellContentClick
   try
            {
                if (DoctorsGrid.Rows.Count > 0 && DoctorsGrid.CurrentCell != null)
                {
                    if ((((ITTGridCell)DoctorsGrid.CurrentCell).OwningColumn != null))
                        
                    {
                        string result = "";
                        if(((ITTGridCell)DoctorsGrid.CurrentCell).OwningColumn.Name == "btnOnay")
                        {
                            result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Medula Optik Rapor Onay", this._MedulaOptikReport.raporId.ToString() + " eRecete nolu raporu onaylamak istediğinize emin misiniz?");
                            if ("H".Equals(result))
                            {
                                InfoBox.Show("İşlemden Vazgeçildi.");
                                return;
                            }
                            else
                            {
                                OptikRaporIslemleri.eraporOnayIstekDVO _eraporOnayIstekDVO = new OptikRaporIslemleri.eraporOnayIstekDVO();
                                TTObjectContext context = new TTObjectContext(true);
                                Guid ruID = new Guid(DoctorsGrid.CurrentCell.OwningRow.Cells[MedulaOptikReportDoctorGrid.Name].Value.ToString());
                                ResUser ru = (ResUser)context.GetObject(ruID, typeof(ResUser));                                
                                _eraporOnayIstekDVO.doktorTcKimlikNo = ru.UniqueNo.ToString();
                                _eraporOnayIstekDVO.raporTakipNo = _MedulaOptikReport.RaporTakipNo;
                                _eraporOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();
                                
                                
                                string eRecetePwd = null;
                                if(ru.ErecetePassword != null)
                                {
                                    eRecetePwd = ru.ErecetePassword ;
                                    this._MedulaOptikReport.ERecetePassword = eRecetePwd;
                                }
                                else
                                {
                                    eRecetePwd = this._MedulaOptikReport.ERecetePassword;
                                }
                                OptikRaporIslemleri.eraporOnayCevapDVO response = OptikRaporIslemleri.WebMethods.eraporOnay(Sites.SiteLocalHost, ru.UniqueNo, eRecetePwd, _eraporOnayIstekDVO);
                                if (response != null && response.sonucKodu != null)
                                {
                                    DoctorsGrid.CurrentCell.OwningRow.Cells[onayRedSonucKodu.Name].Value = response.sonucKodu.ToString();
                                    DoctorsGrid.CurrentCell.OwningRow.Cells[onayRedSonucMesaji.Name].Value = response.sonucMesaji;
                                    DoctorsGrid.CurrentCell.OwningRow.Cells[onayRedUyariMesaji.Name].Value = response.uyariMesaji;
                                    if (response.sonucKodu == "0")
                                        DoctorsGrid.CurrentCell.OwningRow.Cells[IsApproved.Name].Value = true;
                                    this._MedulaOptikReport.ObjectContext.Save();
                                }
                                else
                                {
                                    DoctorsGrid.CurrentCell.OwningRow.Cells[onayRedSonucMesaji.Name].Value = "Meduladan cevap alınamadı!";
                                    //throw new TTUtils.TTException("Meduladan cevap alınamadı!");
                                }
                            }
                        }
                        /*else if(((ITTGridCell)DoctorsGrid.CurrentCell).OwningColumn.Name == "btnRed")
                        {
                            result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Medula Optik Rapor Red", this._MedulaOptikReport.eReceteNo.ToString() + " eRecete nolu raporu reddetmek istediğinize emin misiniz?");
                            if ("H".Equals(result))
                            {
                                InfoBox.Show("İşlemden Vazgeçildi.");
                                return;
                            }
                            else
                            {
                                OptikRaporIslemleri.eraporOnayRedIstekDVO _eraporOnayRedIstekDVO = new OptikRaporIslemleri.eraporOnayRedIstekDVO();
                                _eraporOnayRedIstekDVO.doktorTcKimlikNo = ((ResUser)DoctorsGrid.CurrentCell.OwningRow.Cells[MedulaOptikReportDoctorGrid.Name].Value).UniqueNo.ToString();
                                _eraporOnayRedIstekDVO.raporTakipNo = this._MedulaOptikReport.SubEpisode.SGKSEP.MedulaTakipNo;
                                _eraporOnayRedIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();
                                
                                
                                string eRecetePwd = null;
                                if(this._MedulaOptikReport.ProcedureDoctor.ErecetePassword != null)
                                {
                                    eRecetePwd = this._MedulaOptikReport.ProcedureDoctor.ErecetePassword;
                                    this._MedulaOptikReport.ERecetePassword = eRecetePwd;
                                }
                                else
                                {
                                    eRecetePwd = this._MedulaOptikReport.ERecetePassword;
                                }
                                OptikRaporIslemleri.eraporOnayRedCevapDVO response = OptikRaporIslemleri.WebMethods.eraporOnayRed(Sites.SiteLocalHost, this._MedulaOptikReport.ProcedureDoctor.UniqueNo, eRecetePwd, _eraporOnayRedIstekDVO);
                                if (response != null && response.sonucKodu != null)
                                {
                                    DoctorsGrid.CurrentCell.OwningRow.Cells[onayRedSonucKodu.Name].Value = response.sonucKodu.ToString();
                                    DoctorsGrid.CurrentCell.OwningRow.Cells[onayRedSonucMesaji.Name].Value = response.sonucMesaji;
                                    DoctorsGrid.CurrentCell.OwningRow.Cells[onayRedUyariMesaji.Name].Value = response.uyariMesaji;
                                }
                                else
                                {
                                    DoctorsGrid.CurrentCell.OwningRow.Cells[raporSonucMesaji.Name].Value = "Meduladan cevap alınamadı!";
                                    //throw new TTUtils.TTException("Meduladan cevap alınamadı!");
                                }
                            }
                        }*/
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
#endregion MedulaOptikReportOnayForm_DoctorsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region MedulaOptikReportOnayForm_PreScript
    base.PreScript();
     this.DropStateButton(MedulaOptikReport.States.HeadDoctorApproval);
            Guid HeadDoctor = new Guid("D6694FE4-91CD-4A69-8166-E7362B3E2CD0");
            if(Common.CurrentUser.HasRole(HeadDoctor) == false)
            {
                bool doctorCanOpenForm = false;
                if(Common.CurrentResource.ObjectID.Equals(this._MedulaOptikReport.ProcedureDoctor.ObjectID))
                    doctorCanOpenForm = true;
                if(!doctorCanOpenForm)
                {
                    foreach(OptikDoctorsGrid opd in this._MedulaOptikReport.OptikDoctorsGrid)
                    {
                        if(Common.CurrentResource.ObjectID.Equals(opd.ResUser.ObjectID))
                        {
                            doctorCanOpenForm = true;
                            foreach(TTVisual.ITTGridRow r  in this.DoctorsGrid.Rows )
                            {
                                if (r.TTObject.Equals(opd))
                                {
                                    // r.Cells[btnOnay.Name].ReadOnly = false;
                                    r.IsVisible = true;
                                }
                                else
                                    r.IsVisible = false;
                                     // r.Cells[btnOnay.Name].ReadOnly = true;
                            }
                            break;
                        }
                    }
                }
                if(!doctorCanOpenForm)
                    throw new Exception("Raporu hazırlayan doktorlar arasında olmadığınız için bu adımı görme yetkiniz bulunmamaktadır.");
            }
//            OptikRaporIslemleri.eraporListeSorguIstekDVO _eraporListeSorguIstekDVO = new OptikRaporIslemleri.eraporListeSorguIstekDVO();
//            _eraporListeSorguIstekDVO.doktorTcKimlikNo = this._MedulaOptikReport.ProcedureDoctor.UniqueNo;
//            _eraporListeSorguIstekDVO.hastaTcKimlikNo = this._MedulaOptikReport.Episode.Patient.UniqueRefNo.Value.ToString();
//            _eraporListeSorguIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();
//
//            OptikRaporIslemleri.eraporListeSorguCevapDVO response = OptikRaporIslemleri.WebMethods.eraporListeSorgula(Sites.SiteLocalHost, this._MedulaOptikReport.ProcedureDoctor.UniqueNo, this._MedulaOptikReport.ERecetePassword, _eraporListeSorguIstekDVO);
//            if (response != null && response.sonucKodu != null)
//            {
//                if (response.sonucKodu.Equals("0"))
//                {
//                    foreach (OptikRaporIslemleri.raporTesisDVO _raporTesisDVO in response.eraporListesi)
//                    {
//                        ITTGridRow newRow = gridRaporlar.Rows.Add();
//                        newRow.Cells[raporBaslangicTarihi.Name].Value = _raporTesisDVO.raporBaslangicTarih;
//                        newRow.Cells[raporBitisTarihi.Name].Value = _raporTesisDVO.raporBitisTarih;
//                        newRow.Cells[raporTeshis.Name].Value = _raporTesisDVO.raporTeshis;
//                        newRow.Cells[drTCKNo.Name].Value = _raporTesisDVO.doktorTcKimlikNo;
//                        newRow.Cells[raporNoTesis.Name].Value = _raporTesisDVO.raporNoTesis;
//                        newRow.Cells[raporTip.Name].Value = _raporTesisDVO.tip;
//                        newRow.Cells[raporTakipNo.Name].Value = _raporTesisDVO.takipNo;
//                        newRow.Cells[raporTarihi.Name].Value = _raporTesisDVO.raporTarih;
//                        newRow.Cells[protokolNo.Name].Value = _raporTesisDVO.protokolNo;
//                        newRow.Cells[raporDuzenlenmeTuru.Name].Value = string.IsNullOrEmpty(_raporTesisDVO.raporDuzenlemeTuru) == false ? Common.GetEnumValueDefOfEnumValue("MedulaOptikRaporDuzenlenmeTuruEnum", Convert.ToInt32(_raporTesisDVO.raporDuzenlemeTuru)) : null;
//                        newRow.Cells[kayitSekli.Name].Value = string.IsNullOrEmpty(_raporTesisDVO.raporKayitSekli) == false ? Common.GetEnumValueDefOfEnumValue("MedulaOptikRaporKayitSekliEnum", Convert.ToInt32(_raporTesisDVO.raporKayitSekli)) : null;
//                        newRow.Cells[durum.Name].Value = _raporTesisDVO.durum;
//                        newRow.Cells[raporSonucKodu.Name].Value = response.sonucKodu;
//                        newRow.Cells[raporSonucMesaji.Name].Value = response.sonucMesaji;
//                        newRow.Cells[raporUyariMesaji.Name].Value = response.uyariMesaji;
//                        newRow.Cells[objectID.Name].Value = this._MedulaOptikReport.ObjectID.ToString();
//                    }
//                }
//            }
#endregion MedulaOptikReportOnayForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MedulaOptikReportOnayForm_PostScript
    base.PostScript(transDef);
            bool found = false;
            if(this._MedulaOptikReport.TransDef != null )
            {
                if(this._MedulaOptikReport.TransDef.ToStateDefID == MedulaOptikReport.States.HeadDoctorApproval)
                {
                    foreach(OptikDoctorsGrid opd in this._MedulaOptikReport.OptikDoctorsGrid)
                    {
                        if(opd.IsApproved == null || opd.IsApproved == false)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        throw new Exception("Tüm doktorlar onaylamadan Başhekim Onay adımına geçemezsiniz.");
                    }
                }
            }
#endregion MedulaOptikReportOnayForm_PostScript

            }
                }
}