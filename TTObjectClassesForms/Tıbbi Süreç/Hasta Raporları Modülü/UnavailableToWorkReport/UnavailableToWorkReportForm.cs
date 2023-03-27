
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
    /// İş Göremezlik Belgesi
    /// </summary>
    public partial class UnavailableToWorkReportForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnTCileRaporBul.Click += new TTControlEventDelegate(btnTCileRaporBul_Click);
            txtGun.TextChanged += new TTControlEventDelegate(txtGun_TextChanged);
            btnRaporBilgisiGetir.Click += new TTControlEventDelegate(btnRaporBilgisiGetir_Click);
            btnRaporOnSecim.Click += new TTControlEventDelegate(btnRaporOnSecim_Click);
            btnMedulaSaglikKurulunaSevketIptal.Click += new TTControlEventDelegate(btnMedulaSaglikKurulunaSevketIptal_Click);
            btnMedulaKaydet.Click += new TTControlEventDelegate(btnMedulaKaydet_Click);
            btnMedulaSaglikKurulunaSevket.Click += new TTControlEventDelegate(btnMedulaSaglikKurulunaSevket_Click);
            btnMdedulaSil.Click += new TTControlEventDelegate(btnMdedulaSil_Click);
            btnMedulaRaporGuncelle.Click += new TTControlEventDelegate(btnMedulaRaporGuncelle_Click);
            btnMedulaRapor2Ver.Click += new TTControlEventDelegate(btnMedulaRapor2Ver_Click);
            btnMedulaRapor2Iptal.Click += new TTControlEventDelegate(btnMedulaRapor2Iptal_Click);
            ContinuedHospitalizationType.SelectedIndexChanged += new TTControlEventDelegate(ContinuedHospitalizationType_SelectedIndexChanged);
            ttCmbNuksType.SelectedIndexChanged += new TTControlEventDelegate(ttCmbNuksType_SelectedIndexChanged);
            ttTxtCanliDoganBebekSayisi.TextChanged += new TTControlEventDelegate(ttTxtCanliDoganBebekSayisi_TextChanged);
            ttTxtDoganCocukSayisi.TextChanged += new TTControlEventDelegate(ttTxtDoganCocukSayisi_TextChanged);
            ttCmbPregnancyType.SelectedIndexChanged += new TTControlEventDelegate(ttCmbPregnancyType_SelectedIndexChanged);
            ttCmbMaternityReportType.SelectedIndexChanged += new TTControlEventDelegate(ttCmbMaternityReportType_SelectedIndexChanged);
            NotWorkMother.CheckedChanged += new TTControlEventDelegate(NotWorkMother_CheckedChanged);
            gridRaporlar.CellContentClick += new TTGridCellEventDelegate(gridRaporlar_CellContentClick);
            Excuse.SelectedIndexChanged += new TTControlEventDelegate(Excuse_SelectedIndexChanged);
            ResStartDate.ValueChanged += new TTControlEventDelegate(ResStartDate_ValueChanged);
            ResEndDate.ValueChanged += new TTControlEventDelegate(ResEndDate_ValueChanged);
            DischargeDate.ValueChanged += new TTControlEventDelegate(DischargeDate_ValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnTCileRaporBul.Click -= new TTControlEventDelegate(btnTCileRaporBul_Click);
            txtGun.TextChanged -= new TTControlEventDelegate(txtGun_TextChanged);
            btnRaporBilgisiGetir.Click -= new TTControlEventDelegate(btnRaporBilgisiGetir_Click);
            btnRaporOnSecim.Click -= new TTControlEventDelegate(btnRaporOnSecim_Click);
            btnMedulaSaglikKurulunaSevketIptal.Click -= new TTControlEventDelegate(btnMedulaSaglikKurulunaSevketIptal_Click);
            btnMedulaKaydet.Click -= new TTControlEventDelegate(btnMedulaKaydet_Click);
            btnMedulaSaglikKurulunaSevket.Click -= new TTControlEventDelegate(btnMedulaSaglikKurulunaSevket_Click);
            btnMdedulaSil.Click -= new TTControlEventDelegate(btnMdedulaSil_Click);
            btnMedulaRaporGuncelle.Click -= new TTControlEventDelegate(btnMedulaRaporGuncelle_Click);
            btnMedulaRapor2Ver.Click -= new TTControlEventDelegate(btnMedulaRapor2Ver_Click);
            btnMedulaRapor2Iptal.Click -= new TTControlEventDelegate(btnMedulaRapor2Iptal_Click);
            ContinuedHospitalizationType.SelectedIndexChanged -= new TTControlEventDelegate(ContinuedHospitalizationType_SelectedIndexChanged);
            ttCmbNuksType.SelectedIndexChanged -= new TTControlEventDelegate(ttCmbNuksType_SelectedIndexChanged);
            ttTxtCanliDoganBebekSayisi.TextChanged -= new TTControlEventDelegate(ttTxtCanliDoganBebekSayisi_TextChanged);
            ttTxtDoganCocukSayisi.TextChanged -= new TTControlEventDelegate(ttTxtDoganCocukSayisi_TextChanged);
            ttCmbPregnancyType.SelectedIndexChanged -= new TTControlEventDelegate(ttCmbPregnancyType_SelectedIndexChanged);
            ttCmbMaternityReportType.SelectedIndexChanged -= new TTControlEventDelegate(ttCmbMaternityReportType_SelectedIndexChanged);
            NotWorkMother.CheckedChanged -= new TTControlEventDelegate(NotWorkMother_CheckedChanged);
            gridRaporlar.CellContentClick -= new TTGridCellEventDelegate(gridRaporlar_CellContentClick);
            Excuse.SelectedIndexChanged -= new TTControlEventDelegate(Excuse_SelectedIndexChanged);
            ResStartDate.ValueChanged -= new TTControlEventDelegate(ResStartDate_ValueChanged);
            ResEndDate.ValueChanged -= new TTControlEventDelegate(ResEndDate_ValueChanged);
            DischargeDate.ValueChanged -= new TTControlEventDelegate(DischargeDate_ValueChanged);
            base.UnBindControlEvents();
        }

        private void btnTCileRaporBul_Click()
        {
#region UnavailableToWorkReportForm_btnTCileRaporBul_Click
   if (this._UnavailableToWorkReport.Excuse == null)
            {
                InfoBox.Show("Mazeret Seçiniz! ");
                return;
            }
            gridRaporlar.Rows.Clear();

            BindingList<UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery_Class> getUnavailToWorkRptInfo = UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery(Convert.ToInt64(_UnavailableToWorkReport.Episode.Patient.UniqueRefNo));
            foreach (UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery_Class item in getUnavailToWorkRptInfo)
            {
                if (this._UnavailableToWorkReport.Excuse == item.Excuse && item.ReportDeleted == false)
                {
                    ITTGridRow newRow = gridRaporlar.Rows.Add();
                    newRow.Cells[raporTakipNo.Name].Value = item.MedulaChasingNo;
                    newRow.Cells[raporNo.Name].Value = item.ReportSeqNo;
                    newRow.Cells[raporSiraNo.Name].Value = item.ReportRowNumber;
                    newRow.Cells[raporSonucKodu.Name].Value = "";
                    newRow.Cells[raporSonucAciklama.Name].Value = "";
                    newRow.Cells[raporBaslangicTarihi.Name].Value = item.RestingStartDate;
                    newRow.Cells[raporExcuse.Name].Value = item.Excuse;
                    newRow.Cells[objectID.Name].Value = item.ObjectID;
                }
            }
            if (gridRaporlar.Rows.Count == 0)
            {
                InfoBox.Show("Hastanın Raporu Bulunmamaktadır ! ");
                return;
            }
            else
            {
                InfoBox.Show("Hastanın Raporu Bulundu. Raporlar Tabından Bakabilirsiniz ! ");
                return;
            }
#endregion UnavailableToWorkReportForm_btnTCileRaporBul_Click
        }

        private void txtGun_TextChanged()
        {
#region UnavailableToWorkReportForm_txtGun_TextChanged
   CalculateEndDate();
#endregion UnavailableToWorkReportForm_txtGun_TextChanged
        }

        private void btnRaporBilgisiGetir_Click()
        {
#region UnavailableToWorkReportForm_btnRaporBilgisiGetir_Click
   if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                try
                {
                    IsGormezlikServis.CevapDTO response = IsGormezlikServis.WebMethods.mevcutRaporGetirSync(Sites.SiteLocalHost, this._UnavailableToWorkReport.Episode.Patient.UniqueRefNo.Value.ToString());
                    if (response != null )
                    {
                        if (response.sonucKodu.Equals(0))
                        {
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = "";
                            this.ReportRowNumber.Text = response.raporSiraNo.ToString();
                            this.MedulaChasingNo.Text = response.raporTakipNo.ToString();
                            this._UnavailableToWorkReport.MedulaChasingNo = response.raporTakipNo.ToString();
                            if (response.isgoremezlikRapor != null)
                            {
                                if (response.isgoremezlikRapor.devammi != 0)
                                    this._UnavailableToWorkReport.CarryCase = (CarryCaseTypeEnum)response.isgoremezlikRapor.devammi;
                                if (!string.IsNullOrEmpty(response.isgoremezlikRapor.duzenlemeTuru) && response.isgoremezlikRapor.duzenlemeTuru != "0")
                                    this._UnavailableToWorkReport.EditingTourType = (EditingTourTypeEnum)Convert.ToInt32(response.isgoremezlikRapor.duzenlemeTuru);
                                if (response.isgoremezlikRapor.olum != null)
                                    this._UnavailableToWorkReport.DeathType = (DeathTypeEnum)Convert.ToInt32(response.isgoremezlikRapor.olum);
                                if (response.isgoremezlikRapor.raporDurumu != null && response.isgoremezlikRapor.raporDurumu != "0")
                                    this._UnavailableToWorkReport.Situation = (MedulaReportSituationEnum)Convert.ToInt32(response.isgoremezlikRapor.raporDurumu);
                                if (response.isgoremezlikRapor.teshis != null)
                                {
                                    string teshisKodu = response.isgoremezlikRapor.teshis.Trim();
                                    BindingList<DiagnosisDefinition.GetDiagnosisDefinitionByDiagnosisCode_Class> dg2 = DiagnosisDefinition.GetDiagnosisDefinitionByDiagnosisCode(teshisKodu);
                                    //                                    IList dg = _UnavailableToWorkReport.ObjectContext.QueryObjects(typeof(DiagnosisDefinition).Name, "CODE = " + response.isgoremezlikRapor.teshis.Trim());
                                    //                                    if (dg.Count == 1)
                                    //                                        this._UnavailableToWorkReport.DiagnosisDefinition = (DiagnosisDefinition)dg[0];
                                    if (dg2.Count == 1)
                                    {
                                        TTObjectContext newContext = new TTObjectContext(false);
                                        this._UnavailableToWorkReport.DiagnosisDefinition = (DiagnosisDefinition)newContext.GetObject((dg2[0].ObjectID).GetValueOrDefault(), typeof(DiagnosisDefinition));
                                    }
                                }

                                if (response.isgoremezlikRapor.medulaRapor != null)
                                {
                                    if (response.isgoremezlikRapor.medulaRapor.baslangicTarihi != null)
                                        this._UnavailableToWorkReport.RestingStartDate = response.isgoremezlikRapor.medulaRapor.baslangicTarihi.Value;
                                    if (response.isgoremezlikRapor.medulaRapor.bitisTarihi != null)
                                    {
                                        if (response.isgoremezlikRapor.medulaRapor.bitisTarihi.Value.Year != 1)
                                        {
                                            this._UnavailableToWorkReport.RestingEndDate = response.isgoremezlikRapor.medulaRapor.bitisTarihi.Value;
                                            this._UnavailableToWorkReport.AbsenceEndDate = response.isgoremezlikRapor.medulaRapor.bitisTarihi.Value;
                                            this._UnavailableToWorkReport.SituationDate = response.isgoremezlikRapor.medulaRapor.isKontTarihi.Value;
                                        }
                                    }
                                    if (response.isgoremezlikRapor.medulaRapor.baslangicTarihi != null)
                                        this._UnavailableToWorkReport.AbsenceStartDate = response.isgoremezlikRapor.medulaRapor.baslangicTarihi.Value;
                                    //                                    if (response.isgoremezlikRapor.medulaRapor.bitisTarihi.Value.Year!=1)
                                    //                                        this._UnavailableToWorkReport.AbsenceEndDate = response.isgoremezlikRapor.medulaRapor.bitisTarihi.Value;
                                    //                                    if (response.isgoremezlikRapor.medulaRapor.bitisTarihi.Value.Year!=1)
                                    //                                        this._UnavailableToWorkReport.SituationDate = response.isgoremezlikRapor.medulaRapor.isKontTarihi.Value;
                                    if (response.isgoremezlikRapor.medulaRapor.taburcuKodu != 0)
                                        this._UnavailableToWorkReport.DischargedCodeType = (DischargedCodeTypeEnum)response.isgoremezlikRapor.medulaRapor.taburcuKodu;
                                    if (!string.IsNullOrEmpty(response.isgoremezlikRapor.medulaRapor.yatisDevam) && response.isgoremezlikRapor.medulaRapor.yatisDevam != "0")
                                        this._UnavailableToWorkReport.ContinuedHospitalizationType = (ContinuedHospitalizationTypeEnum)Convert.ToInt32(response.isgoremezlikRapor.medulaRapor.yatisDevam);
                                }
                                this.IsgoremezlikTipineGoreFormuSekillendir(response.isgoremezlikRapor.isGoremezlikRaporTuru.ToString());
                                switch (response.isgoremezlikRapor.isGoremezlikRaporTuru)
                                {

                                    case 1://İşKazası
                                        if (response.isgoremezlikRapor.iskazasiHastalik != null)
                                        {
                                            this._UnavailableToWorkReport.Excuse = "0";
                                            if (response.isgoremezlikRapor.iskazasiHastalik.isKazasiTarihi != null && response.isgoremezlikRapor.iskazasiHastalik.isKazasiTarihi.Value.Year != 1)
                                                this._UnavailableToWorkReport.AccidentDate = response.isgoremezlikRapor.iskazasiHastalik.isKazasiTarihi.Value;
                                            if (!string.IsNullOrEmpty(response.isgoremezlikRapor.iskazasiHastalik.nuks) && response.isgoremezlikRapor.iskazasiHastalik.nuks != "0")
                                                this._UnavailableToWorkReport.NuksType = (NuksTypeEnum)Convert.ToInt32(response.isgoremezlikRapor.iskazasiHastalik.nuks);
                                            //    this._UnavailableToWorkReport.YaraTuru = response.isgoremezlikRapor.iskazasiHastalik.yaraninTuru;
                                            //    this._UnavailableToWorkReport.VucutYeri = response.isgoremezlikRapor.iskazasiHastalik.yaraninYeri;
                                        }
                                        break;
                                    case 2://MeslekHastalığı
                                        if (response.isgoremezlikRapor.iskazasiHastalik != null)
                                        {
                                            this._UnavailableToWorkReport.Excuse = "1";
                                            if (!string.IsNullOrEmpty(response.isgoremezlikRapor.iskazasiHastalik.nuks) && response.isgoremezlikRapor.iskazasiHastalik.nuks != "0")
                                                this._UnavailableToWorkReport.NuksType = (NuksTypeEnum)Convert.ToInt32(response.isgoremezlikRapor.iskazasiHastalik.nuks);
                                            // this._UnavailableToWorkReport.YaraTuru = response.isgoremezlikRapor.iskazasiHastalik.yaraninTuru;
                                            // this._UnavailableToWorkReport.VucutYeri = response.isgoremezlikRapor.iskazasiHastalik.yaraninYeri;
                                        }
                                        break;
                                    case 3://Hastalık
                                        if (response.isgoremezlikRapor.iskazasiHastalik != null)
                                        {
                                            this._UnavailableToWorkReport.Excuse = "2";
                                            if (!string.IsNullOrEmpty(response.isgoremezlikRapor.iskazasiHastalik.nuks) && response.isgoremezlikRapor.iskazasiHastalik.nuks != "0")
                                                this._UnavailableToWorkReport.NuksType = (NuksTypeEnum)Convert.ToInt32(response.isgoremezlikRapor.iskazasiHastalik.nuks);
                                        }
                                        break;
                                    case 4://Analık
                                        if (response.isgoremezlikRapor.analikEmzirme != null)
                                        {
                                            this._UnavailableToWorkReport.Excuse = "3";
                                            //if (response.isgoremezlikRapor.analikEmzirme.aktarmaHaftasi != null)
                                                this._UnavailableToWorkReport.TransferringTheWeek = response.isgoremezlikRapor.analikEmzirme.aktarmaHaftasi;
                                            if (response.isgoremezlikRapor.analikEmzirme.analikRaporTipi != 0)
                                                this._UnavailableToWorkReport.MaternityReportType = (MaternityReportTypeEnum)response.isgoremezlikRapor.analikEmzirme.analikRaporTipi;
                                            //if (response.isgoremezlikRapor.analikEmzirme.bebekDogumHaftasi != null)
                                                this._UnavailableToWorkReport.BabyBirthWeek = response.isgoremezlikRapor.analikEmzirme.bebekDogumHaftasi;
                                            if (response.isgoremezlikRapor.analikEmzirme.bebekDogumTarihi != null && response.isgoremezlikRapor.analikEmzirme.bebekDogumTarihi.Value.Year != 1)
                                                this._UnavailableToWorkReport.BabyBirthDate = response.isgoremezlikRapor.analikEmzirme.bebekDogumTarihi.Value;
                                            //if (response.isgoremezlikRapor.analikEmzirme.canliCocukSayisi != null)
                                                this._UnavailableToWorkReport.LiveBirthsNumber = response.isgoremezlikRapor.analikEmzirme.canliCocukSayisi;
                                            //if (response.isgoremezlikRapor.analikEmzirme.doganCocukSayisi != null)
                                                this._UnavailableToWorkReport.ChildrenBornNumber = response.isgoremezlikRapor.analikEmzirme.doganCocukSayisi;
                                            //if (response.isgoremezlikRapor.analikEmzirme.gebelikHaftasi1 != null)
                                                this._UnavailableToWorkReport.GestationalOne = response.isgoremezlikRapor.analikEmzirme.gebelikHaftasi1;
                                            //if (response.isgoremezlikRapor.analikEmzirme.gebelikHaftasi2 != null)
                                                this._UnavailableToWorkReport.GestationalTwo = response.isgoremezlikRapor.analikEmzirme.gebelikHaftasi2;
                                            if (response.isgoremezlikRapor.analikEmzirme.gebelikTipi != 0)
                                                this._UnavailableToWorkReport.PregnancyType = (PregnancyTypeEnum)response.isgoremezlikRapor.analikEmzirme.gebelikTipi;
                                            if (!string.IsNullOrEmpty(response.isgoremezlikRapor.analikEmzirme.norSezFor) && response.isgoremezlikRapor.analikEmzirme.norSezFor != "0")
                                                this._UnavailableToWorkReport.BirthType = (BirthTypeEnum)Convert.ToInt32(response.isgoremezlikRapor.analikEmzirme.norSezFor);
                                        }
                                        break;
                                    case 5://Emzirme
                                        if (response.isgoremezlikRapor.analikEmzirme != null)
                                        {
                                            this._UnavailableToWorkReport.Excuse = "4";
                                            this._UnavailableToWorkReport.MotherTCNo = response.isgoremezlikRapor.analikEmzirme.anneTCKimlikNo != null ? response.isgoremezlikRapor.analikEmzirme.anneTCKimlikNo : "";
                                            if (response.isgoremezlikRapor.analikEmzirme.bebekDogumTarihi != null && response.isgoremezlikRapor.analikEmzirme.bebekDogumTarihi.Value.Year != 1)
                                                this._UnavailableToWorkReport.BabyBirthDate = response.isgoremezlikRapor.analikEmzirme.bebekDogumTarihi.Value;
                                            //if (response.isgoremezlikRapor.analikEmzirme.canliCocukSayisi != null)
                                                this._UnavailableToWorkReport.LiveBirthsNumber = response.isgoremezlikRapor.analikEmzirme.canliCocukSayisi;
                                            //if (response.isgoremezlikRapor.analikEmzirme.doganCocukSayisi != null)
                                                this._UnavailableToWorkReport.ChildrenBornNumber = response.isgoremezlikRapor.analikEmzirme.doganCocukSayisi;

                                        }
                                        break;

                                }

                            }

                        }
                        else
                        {

                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji;

                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
#endregion UnavailableToWorkReportForm_btnRaporBilgisiGetir_Click
        }

        private void btnRaporOnSecim_Click()
        {
#region UnavailableToWorkReportForm_btnRaporOnSecim_Click
   /*  if (((ITTObject)this._UnavailableToWorkReport).IsNew)
            {
                InfoBox.Show("Meduladan herhangi bir işlem yapılmadan önce verileri sisteme kayıt etmelisiniz!!!");
                return;
            }*/
            if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                try
                {
                    IsGormezlikServis.IsgoremezlikRaporDVO _isgoremezlikRaporDVO = new IsGormezlikServis.IsgoremezlikRaporDVO();

                    _isgoremezlikRaporDVO.devammi = Convert.ToInt32(_UnavailableToWorkReport.CarryCase) == -1 ? 0 : Convert.ToInt32(_UnavailableToWorkReport.CarryCase);

                    if (this._UnavailableToWorkReport.Excuse != null)
                    {
                        _isgoremezlikRaporDVO.isKazasiRaporu = new IsGormezlikServis.IsKazasiRaporDVO();
                        _isgoremezlikRaporDVO.meslekHastaligiRaporu = new IsGormezlikServis.MeslekHastaligiRaporDVO();
                        _isgoremezlikRaporDVO.hastalikRaporu = new IsGormezlikServis.HastalikRaporDVO();
                        _isgoremezlikRaporDVO.analikRaporu = new IsGormezlikServis.AnalikRaporDVO();
                        _isgoremezlikRaporDVO.emzirmeRaporu = new IsGormezlikServis.EmzirmeRaporDVO();

                        switch (Convert.ToInt32(this._UnavailableToWorkReport.Excuse))
                        {
                            case 0:
                                //_isgoremezlikRaporDVO.isKazasiRaporu = new IsGormezlikServis.IsKazasiRaporDVO();
                                _isgoremezlikRaporDVO.isKazasiRaporu.baslangicTarihi = _UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy");
                                _isgoremezlikRaporDVO.isKazasiRaporu.bitisTarihi = _UnavailableToWorkReport.RestingEndDate.Value.ToString("dd.MM.yyyy");
                                _isgoremezlikRaporDVO.isKazasiRaporu.isKontTarihi = _UnavailableToWorkReport.SituationDate.Value.ToString("dd.MM.yyyy");
                                if (_UnavailableToWorkReport.NuksType != null)
                                    _isgoremezlikRaporDVO.isKazasiRaporu.nuks = ((int)_UnavailableToWorkReport.NuksType).ToString();
                                _isgoremezlikRaporDVO.isKazasiRaporu.raporDurumu = ((int)_UnavailableToWorkReport.Situation).ToString();
                                if (this._UnavailableToWorkReport.AccidentDate != null)
                                    _isgoremezlikRaporDVO.isKazasiRaporu.isKazasiTarihi = _UnavailableToWorkReport.AccidentDate.Value.ToString("dd.MM.yyyy");
                                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 1;
                                break;
                            case 1:
                                //_isgoremezlikRaporDVO.meslekHastaligiRaporu = new IsGormezlikServis.MeslekHastaligiRaporDVO();
                                _isgoremezlikRaporDVO.meslekHastaligiRaporu.baslangicTarihi = _UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy");
                                _isgoremezlikRaporDVO.meslekHastaligiRaporu.bitisTarihi = _UnavailableToWorkReport.RestingEndDate.Value.ToString("dd.MM.yyyy");
                                _isgoremezlikRaporDVO.meslekHastaligiRaporu.isKontTarihi = _UnavailableToWorkReport.SituationDate.Value.ToString("dd.MM.yyyy");
                                if (_UnavailableToWorkReport.NuksType != null)
                                    _isgoremezlikRaporDVO.meslekHastaligiRaporu.nuks = ((int)_UnavailableToWorkReport.NuksType).ToString();
                                _isgoremezlikRaporDVO.meslekHastaligiRaporu.raporDurumu = ((int)_UnavailableToWorkReport.Situation).ToString();
                                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 2;
                                break;
                            case 2:
                                //_isgoremezlikRaporDVO.hastalikRaporu = new IsGormezlikServis.HastalikRaporDVO();
                                _isgoremezlikRaporDVO.hastalikRaporu.baslangicTarihi = _UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy");
                                _isgoremezlikRaporDVO.hastalikRaporu.bitisTarihi = _UnavailableToWorkReport.RestingEndDate.Value.ToString("dd.MM.yyyy");
                                _isgoremezlikRaporDVO.hastalikRaporu.isKontTarihi = _UnavailableToWorkReport.SituationDate.Value.ToString("dd.MM.yyyy");
                                if (_UnavailableToWorkReport.NuksType != null)
                                    _isgoremezlikRaporDVO.hastalikRaporu.nuks = ((int)_UnavailableToWorkReport.NuksType).ToString();
                                _isgoremezlikRaporDVO.hastalikRaporu.raporDurumu = ((int)_UnavailableToWorkReport.Situation).ToString();
                                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 3;
                                break;
                            case 3:
                                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 4;
                                IsGormezlikServis.AnalikRaporDVO ana = new IsGormezlikServis.AnalikRaporDVO();
                                if (this._UnavailableToWorkReport.MaternityReportType != null)
                                {
                                    ana.analikRaporTipi = Convert.ToInt32(this._UnavailableToWorkReport.MaternityReportType);
                                }
                                else
                                {
                                    InfoBox.Show("Analık Rapor Tipi Boş Bırakılamaz!!!");
                                    return;

                                }

                                _isgoremezlikRaporDVO.analikRaporu = ana;

                                break;
                            case 4:
                                //_isgoremezlikRaporDVO.emzirmeRaporu = new IsGormezlikServis.EmzirmeRaporDVO();
                                if (!string.IsNullOrEmpty(_UnavailableToWorkReport.MotherTCNo))
                                    _isgoremezlikRaporDVO.emzirmeRaporu.anneTcKimlikNo = _UnavailableToWorkReport.MotherTCNo;
                                if (_UnavailableToWorkReport.BabyBirthDate != null)
                                    _isgoremezlikRaporDVO.emzirmeRaporu.bebekDogumTarihi = _UnavailableToWorkReport.BabyBirthDate.Value.ToString("dd.MM.yyyy");
                                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 5;
                                break;
                        }
                    }
                    else
                    {
                        InfoBox.Show("Mazeret Bilgisi Boş Olamaz!!!");
                        return;
                    }

                    foreach (DoctorGrid doctor in this._UnavailableToWorkReport.DoctorsGrid)
                    {
                        bool ctrl = false;
                        if (doctor.ResUser != null && doctor.ResUser.ResourceSpecialities != null)
                        {
                            foreach (ResourceSpecialityGrid resource in doctor.ResUser.ResourceSpecialities)
                            {
                                if (resource.MainSpeciality != null && resource.MainSpeciality.Equals(true))
                                {
                                    if (resource.Speciality != null && resource.Speciality.Code != null)
                                    {
                                        ctrl = true;
                                        _isgoremezlikRaporDVO.bransKodu = Convert.ToInt32(resource.Speciality.Code);
                                        break;
                                    }
                                }
                            }
                            if (!ctrl)
                            {
                                _isgoremezlikRaporDVO.bransKodu = 0;
                            }
                        }
                        else
                        {
                            _isgoremezlikRaporDVO.bransKodu = 0;
                        }
                    }

                    if (this._UnavailableToWorkReport.ContinuedHospitalizationType == null)
                    {
                        InfoBox.Show("Yatış Devam Durum  Bilgisi Boş Olamaz!!!");
                        return;
                    }
                    if (this._UnavailableToWorkReport.EditingTourType == null)
                    {
                        InfoBox.Show("Düzenleme Türü  Bilgisi Boş Olamaz!!!");
                        return;
                    }



                    _isgoremezlikRaporDVO.yatisDevam = this._UnavailableToWorkReport.ContinuedHospitalizationType != null ? ((int)this._UnavailableToWorkReport.ContinuedHospitalizationType).ToString() : "";
                    _isgoremezlikRaporDVO.duzenlemeTuru = this._UnavailableToWorkReport.EditingTourType != null ? ((int)this._UnavailableToWorkReport.EditingTourType).ToString() : "";

                    _isgoremezlikRaporDVO.protokolNo = this._UnavailableToWorkReport.Episode.HospitalProtocolNo.ToString();
                    _isgoremezlikRaporDVO.protokolTarihi = this._UnavailableToWorkReport.ProtocolDate != null ? this._UnavailableToWorkReport.ProtocolDate.Value.ToString("dd.MM.yyyy") : null;



                    IsGormezlikServis.HakSahibiBilgisiDVO _hakSahibiBilgisiDVO = new IsGormezlikServis.HakSahibiBilgisiDVO();

                    if( _UnavailableToWorkReport.NotWorkMother == true)
                    {
                        if(_UnavailableToWorkReport.FatherTCNo != null)
                            _hakSahibiBilgisiDVO.tckimlikNo = _UnavailableToWorkReport.FatherTCNo;
                        else
                            throw new TTException("Anne çalışmıyor ise baba TC Kimlik Numarası girilmeli!");
                    }
                    else
                        _hakSahibiBilgisiDVO.tckimlikNo = this._UnavailableToWorkReport.Episode.Patient.UniqueRefNo != null ? this._UnavailableToWorkReport.Episode.Patient.UniqueRefNo.Value.ToString() : "00000000000";
                    
                    _hakSahibiBilgisiDVO.sigortaliTuru = "1";
                    _isgoremezlikRaporDVO.hakSahibi = _hakSahibiBilgisiDVO;

                    IsGormezlikServis.RaporBilgisiDVO _raporBilgisiDVO = new IsGormezlikServis.RaporBilgisiDVO();
                    _raporBilgisiDVO.AVakaTKaza = 3;
                    _raporBilgisiDVO.tarih = this._UnavailableToWorkReport.RestingStartDate != null ? this._UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy") : "";
                    _raporBilgisiDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                    _isgoremezlikRaporDVO.raporBilgisi = _raporBilgisiDVO;


                    IsGormezlikServis.CevapDTO response = IsGormezlikServis.WebMethods.raporOnSecimSync(Sites.SiteLocalHost, _isgoremezlikRaporDVO);
                    if (response != null)
                    {
                        if (response.sonucKodu.Equals(0))
                        {
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = "Medula Rapor Bilgisi Kayıt Edebilirsiniz";
                            if (response.raporTakipNo != null)
                            {
                                if (response.raporTakipNo != "0")
                                    this.MedulaChasingNo.Text = response.raporTakipNo.ToString();
                            }
                            //if (response.raporSiraNo != null)
                            {
                                if (response.raporSiraNo != 0)
                                    this.ReportRowNumber.Text = response.raporSiraNo.ToString();
                            }
                        }

                        else
                        {
                            if (response.sonucKodu.Equals(1))
                            {
                                btnRaporBilgisiGetir.Visible = true;

                            }
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji;

                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                InfoBox.Show("Hastaya ait aktif bir medula provizyon bilgisi bulunamamıştır. Öncelik olarak hastaya medula provizyon alınız!!!");
            }
#endregion UnavailableToWorkReportForm_btnRaporOnSecim_Click
        }

        private void btnMedulaSaglikKurulunaSevketIptal_Click()
        {
#region UnavailableToWorkReportForm_btnMedulaSaglikKurulunaSevketIptal_Click
   if (this._UnavailableToWorkReport.SubEpisode.SGKSEP == null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                try
                {
                    if (string.IsNullOrEmpty(this._UnavailableToWorkReport.MedulaChasingNo) || string.IsNullOrEmpty(this._UnavailableToWorkReport.ReportRowNumber))
                    {
                        InfoBox.Show("Rapor Medulaya Kayıt Edilmediğinden Dolayı Sağlık Kuruluna Sevket İptal İşlemi Gerçekleştirilemez!!!");
                        return;

                    }

                    IsGormezlikServis.CevapDTO response = IsGormezlikServis.WebMethods.saglikKurulunaSevkIptalSync(Sites.SiteLocalHost, this._UnavailableToWorkReport.MedulaChasingNo);
                    if (response != null )
                    {
                        if (response.sonucKodu.Equals(0))
                        {
                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.hataMesaji;
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji + " Rapor Bilgisi İptal Edilmiştir";
                            context.Save();
                        }
                        else
                        {
                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji;
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.hataMesaji;
                            context.Save();

                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
#endregion UnavailableToWorkReportForm_btnMedulaSaglikKurulunaSevketIptal_Click
        }

        private void btnMedulaKaydet_Click()
        {
#region UnavailableToWorkReportForm_btnMedulaKaydet_Click
   if (_UnavailableToWorkReport.RestingStartDate == null)
                throw new TTUtils.TTException("İstirahat Başlangıç Tarihini Giriniz!");

            int continuedHospitalizationType = (int)_UnavailableToWorkReport.ContinuedHospitalizationType;
            _UnavailableToWorkReport.ResultCode = null;
            _UnavailableToWorkReport.ResultExplanation = "Medulaya kayıt edilmeye çalışılıyor.";
            //Application.DoEvents();

            SubEpisodeProtocol mySGKSEP = null;
            if (_UnavailableToWorkReport.SubEpisode.SGKSEP == null)
                throw new TTUtils.TTException("Hastanın provizyon bilgilerine ulaşılamıyor!");
            else
                mySGKSEP = _UnavailableToWorkReport.SubEpisode.SGKSEP;

            if (_UnavailableToWorkReport.ContinuedHospitalizationType == null)
                throw new TTUtils.TTException("Yatış devam girmediniz!");

            if (_UnavailableToWorkReport.DischargeDate == null)
            {
                if (continuedHospitalizationType == 3 || continuedHospitalizationType == 4)
                    throw new TTUtils.TTException("Seçtiğiniz yatış durumunda taburcu tarihi zorunludur!");
            }
            
            if((int)this._UnavailableToWorkReport.ContinuedHospitalizationType == 3)
            {               
                _UnavailableToWorkReport.RestingEndDate = ((DateTime)_UnavailableToWorkReport.DischargeDate);
                _UnavailableToWorkReport.SituationDate = ((DateTime)_UnavailableToWorkReport.RestingEndDate).AddDays(1);
            }
           

            if (_UnavailableToWorkReport.DiagnosisDefinition == null)
                throw new TTUtils.TTException("Tanı girişi zorunludur!");

            if (_UnavailableToWorkReport.ReportSeqNo.Value == null)
                _UnavailableToWorkReport.ObjectContext.Save();

            //_UnavailableToWorkReport.ReportSeqNo.GetNextValueFromDatabase(string.Empty, Common.RecTime().Year);

            RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();

            raporGirisDVO.ilacRapor = null;
            //TODO : MEDULA20140501
            raporGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            raporGirisDVO.tedaviRapor = null;

            RaporIslemleri.isgoremezlikRaporDVO _isgoremezlikRaporDVO = new RaporIslemleri.isgoremezlikRaporDVO();

            List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
            foreach (DoctorGrid doctor in _UnavailableToWorkReport.DoctorsGrid)
            {
                RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
                if (doctor.ResUser.DiplomaRegisterNo != null)
                    _doktorBilgisiDVO.drTescilNo = doctor.ResUser.DiplomaRegisterNo;
                else
                    throw new TTUtils.TTException("Doktorun tescil numarası dolu olmalıdır!");

                _doktorBilgisiDVO.drAdi = doctor.ResUser.Person.Name;
                _doktorBilgisiDVO.drSoyadi = doctor.ResUser.Person.Surname;

                if (doctor.ResUser.ResourceSpecialities != null)
                {
                    foreach (ResourceSpecialityGrid resource in doctor.ResUser.ResourceSpecialities)
                    {
                        if (resource.MainSpeciality != null && resource.MainSpeciality.Equals(true))
                        {
                            if (resource.Speciality != null && resource.Speciality.Code != null)
                            {
                                _doktorBilgisiDVO.drBransKodu = resource.Speciality.Code;
                                _isgoremezlikRaporDVO.bransKodu = Convert.ToInt32(resource.Speciality.Code);
                                break;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(_doktorBilgisiDVO.drBransKodu))
                        throw new TTUtils.TTException("Doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
                }

                else
                    throw new TTUtils.TTException(doctor.ResUser.Name + "  doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");

                _doktorBilgisiDVO.tipi = "2";
                _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
            }

            _isgoremezlikRaporDVO.devammi = Convert.ToInt32(_UnavailableToWorkReport.CarryCase) == -1 ? 0 : Convert.ToInt32(_UnavailableToWorkReport.CarryCase);

            if (this._UnavailableToWorkReport.Excuse != null)
                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = Convert.ToInt32(_UnavailableToWorkReport.Excuse) + 1;

            //                if (this._UnavailableToWorkReport.Excuse != null)
            //                {
            //                    switch (Convert.ToInt32(_UnavailableToWorkReport.Excuse))
            //                    {
            //                        case 0:
            //                            _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 1;
            //                            break;
            //                        case 1:
            //                            _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 2;
            //                            break;
            //                        case 2:
            //                            _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 3;
            //                            break;
            //                        case 3:
            //                            _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 4;
            //                            break;
            //                        case 4:
            //                            _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 5;
            //                            break;
            //                    }
            //                }

            if (_UnavailableToWorkReport.DeathType != null)
                _isgoremezlikRaporDVO.olum = ((int)_UnavailableToWorkReport.DeathType).ToString();

            if ((int)_UnavailableToWorkReport.EditingTourType == 1)
                _isgoremezlikRaporDVO.karar = "Uygundur";

            RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();

            if (_UnavailableToWorkReport.EditingTourType != null)
                _raporDVO.duzenlemeTuru = ((int)_UnavailableToWorkReport.EditingTourType).ToString();

            _raporDVO.protokolNo = _UnavailableToWorkReport.Episode.HospitalProtocolNo.ToString();

            if (_UnavailableToWorkReport.ProtocolDate != null)
                _raporDVO.protokolTarihi = _UnavailableToWorkReport.ProtocolDate.Value.ToString("dd.MM.yyyy");

            _raporDVO.turu = "2";

            _raporDVO.takipNo = mySGKSEP.MedulaTakipNo;



            if (_doktorBilgisiDVOList != null && _doktorBilgisiDVOList.Count > 0)
                _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();


            RaporIslemleri.hakSahibiBilgisiDVO _hakSahibiBilgisiDVO = new RaporIslemleri.hakSahibiBilgisiDVO();

            _hakSahibiBilgisiDVO.provizyonTarihi = mySGKSEP.MedulaProvizyonTarihi.Value.ToString("dd.MM.yyyy");
            _hakSahibiBilgisiDVO.provizyonTipi = mySGKSEP.MedulaProvizyonTipi.provizyonTipiKodu;

            _hakSahibiBilgisiDVO.sigortaliTuru = "1";

            if( _UnavailableToWorkReport.NotWorkMother == true)
            {
                if(_UnavailableToWorkReport.FatherTCNo != null)
                    _hakSahibiBilgisiDVO.tckimlikNo = _UnavailableToWorkReport.FatherTCNo;
                else
                     throw new TTException("Anne çalışmıyor ise baba TC Kimlik Numarası girilmeli!");
            }
            else
                _hakSahibiBilgisiDVO.tckimlikNo = _UnavailableToWorkReport.Episode.Patient.UniqueRefNo.Value.ToString();
            _raporDVO.hakSahibi = _hakSahibiBilgisiDVO;

            RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
            _raporBilgisiDVO.aVakaTKaza = 3;

            if (Convert.ToInt32(_UnavailableToWorkReport.Excuse) == 3)
                _raporBilgisiDVO.raporTakipNo = _UnavailableToWorkReport.MedulaChasingNo;

            _raporBilgisiDVO.no = _UnavailableToWorkReport.ReportSeqNo.Value.ToString();

            _raporBilgisiDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

            if (_UnavailableToWorkReport.RestingStartDate != null)
                _raporBilgisiDVO.tarih = _UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy");
            _raporDVO.raporBilgisi = _raporBilgisiDVO;

            _raporDVO.teshisler = null;

            _isgoremezlikRaporDVO.raporDVO = _raporDVO;

            _isgoremezlikRaporDVO.teshis = _UnavailableToWorkReport.DiagnosisDefinition.Code;

            if (_UnavailableToWorkReport.ContinuedHospitalizationType != null)
                _isgoremezlikRaporDVO.yatisDevam = ((int)_UnavailableToWorkReport.ContinuedHospitalizationType).ToString();

            int raporTuru = Convert.ToInt32(_UnavailableToWorkReport.Excuse);

            UnavailableToWorkReport.CheckRequiredFields(_UnavailableToWorkReport);
            switch (raporTuru)
            {
                    //İŞ KAZASI RAPORU______________________
                case 0:
                    RaporIslemleri.isKazasiRaporDVO _isKazasiRaporDVO = new RaporIslemleri.isKazasiRaporDVO();
                    if (continuedHospitalizationType != 3)
                    {
                        if (_UnavailableToWorkReport.RestingStartDate != null && _UnavailableToWorkReport.RestingStartDate.Value != null)
                            _isKazasiRaporDVO.baslangicTarihi = _UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy");

                        if (_UnavailableToWorkReport.RestingEndDate != null && _UnavailableToWorkReport.RestingEndDate.Value != null)
                            _isKazasiRaporDVO.bitisTarihi = _UnavailableToWorkReport.RestingEndDate.Value.ToString("dd.MM.yyyy");
                    }
                    if (_UnavailableToWorkReport.SituationDate != null && _UnavailableToWorkReport.SituationDate.Value != null)
                        _isKazasiRaporDVO.isKontTarihi = _UnavailableToWorkReport.SituationDate.Value.ToString("dd.MM.yyyy");

                    //2 yatış devam 3 taburcu
                    if (continuedHospitalizationType != 1)
                    {
                        if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null)
                            _isKazasiRaporDVO.XXXXXXYatisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToString("dd.MM.yyyy");
                        if (continuedHospitalizationType != 2)
                        {
                            _isKazasiRaporDVO.XXXXXXCikisTarihi = _UnavailableToWorkReport.DischargeDate.Value.ToString("dd.MM.yyyy");
                            _isKazasiRaporDVO.taburcuTarihi = _UnavailableToWorkReport.DischargeDate.Value.ToString("dd.MM.yyyy");
                        }
                    }

                    if (_UnavailableToWorkReport.NuksType != null)
                        _isKazasiRaporDVO.nuks = ((int)_UnavailableToWorkReport.NuksType).ToString();


                    if (this._UnavailableToWorkReport.AccidentDate != null)
                        _isKazasiRaporDVO.isKazasiTarihi = _UnavailableToWorkReport.AccidentDate.Value.ToString("dd.MM.yyyy");
                    else
                        throw new TTUtils.TTException("İş Kazası Tarihi Zorunludur");


                    _isKazasiRaporDVO.raporDurumu = ((int)_UnavailableToWorkReport.Situation).ToString();

                    if (_UnavailableToWorkReport.DischargedCodeType != null)
                        _isKazasiRaporDVO.taburcuKodu = Convert.ToInt32(_UnavailableToWorkReport.DischargedCodeType);

                    if ((int)_UnavailableToWorkReport.ContinuedHospitalizationType == 3)
                        _isKazasiRaporDVO.taburcuTarihi = _UnavailableToWorkReport.DischargeDate.Value.ToString("dd.MM.yyyy");

                    _UnavailableToWorkReport.WoundPosition = _UnavailableToWorkReport.YaraTuru.CodeValueCode;
                    _UnavailableToWorkReport.WoundType = _UnavailableToWorkReport.VucutYeri.CodeValueCode;
                    _isKazasiRaporDVO.yaraninTuru = _UnavailableToWorkReport.WoundPosition;
                    _isKazasiRaporDVO.yaraninYeri = _UnavailableToWorkReport.WoundType;
                    _isgoremezlikRaporDVO.isKazasiRaporu = _isKazasiRaporDVO;
                    break;

                    //MESLEK HASTALIĞI RAPORU________________________
                case 1:
                    RaporIslemleri.meslekHastaligiRaporDVO _meslekHastaligiRaporDVO = new RaporIslemleri.meslekHastaligiRaporDVO();
                    if (continuedHospitalizationType != 3)
                    {
                        if (_UnavailableToWorkReport.RestingStartDate != null && _UnavailableToWorkReport.RestingStartDate.Value != null)
                            _meslekHastaligiRaporDVO.baslangicTarihi = _UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy");

                        if (_UnavailableToWorkReport.RestingEndDate != null && _UnavailableToWorkReport.RestingEndDate.Value != null)
                            _meslekHastaligiRaporDVO.bitisTarihi = _UnavailableToWorkReport.RestingEndDate.Value.ToString("dd.MM.yyyy");
                    }
                    if (_UnavailableToWorkReport.SituationDate != null && _UnavailableToWorkReport.SituationDate.Value != null)
                        _meslekHastaligiRaporDVO.isKontTarihi = _UnavailableToWorkReport.SituationDate.Value.ToString("dd.MM.yyyy");

                    //2 yatış devam 3 taburcu
                    if (continuedHospitalizationType != 1)
                    {
                        if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null)
                            _meslekHastaligiRaporDVO.XXXXXXYatisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToString("dd.MM.yyyy");
                        if (continuedHospitalizationType != 2)
                        {
                            _meslekHastaligiRaporDVO.XXXXXXCikisTarihi = _UnavailableToWorkReport.DischargeDate.Value.ToString("dd.MM.yyyy");
                            _meslekHastaligiRaporDVO.taburcuTarihi = _UnavailableToWorkReport.DischargeDate.Value.ToString("dd.MM.yyyy");
                        }
                    }

                    if (_UnavailableToWorkReport.DischargedCodeType != null)
                        _meslekHastaligiRaporDVO.taburcuKodu = Convert.ToInt32(this._UnavailableToWorkReport.DischargedCodeType);

                    if (_UnavailableToWorkReport.NuksType != null)
                        _meslekHastaligiRaporDVO.nuks = ((int)_UnavailableToWorkReport.NuksType).ToString();

                    _meslekHastaligiRaporDVO.raporDurumu = ((int)_UnavailableToWorkReport.Situation).ToString();

                    if (_UnavailableToWorkReport.DischargedCodeType != null)
                        _meslekHastaligiRaporDVO.taburcuKodu = Convert.ToInt32(this._UnavailableToWorkReport.DischargedCodeType);

                    if ((int)this._UnavailableToWorkReport.ContinuedHospitalizationType == 3)
                    {
                        if (_UnavailableToWorkReport.Episode.PatientStatus != null)
                        {
                            if (_UnavailableToWorkReport.Episode.PatientStatus.Value == PatientStatusEnum.Discharge)
                            {
                                if (_UnavailableToWorkReport.DischargeDate != null)
                                    _meslekHastaligiRaporDVO.taburcuTarihi = _UnavailableToWorkReport.DischargeDate.Value.ToString("dd.MM.yyyy");
                                else
                                    throw new TTUtils.TTException("Yatış Devam Durumu Yatış Var, Taburcu Olmuş Secilmiş İse Taburcu Tarihi Zorunludur ");
                            }
                        }
                    }

                    _UnavailableToWorkReport.WoundPosition = _UnavailableToWorkReport.YaraTuru.CodeValueCode;
                    _UnavailableToWorkReport.WoundType = _UnavailableToWorkReport.VucutYeri.CodeValueCode;
                    _meslekHastaligiRaporDVO.yaraninTuru = _UnavailableToWorkReport.WoundPosition;
                    _meslekHastaligiRaporDVO.yaraninYeri = _UnavailableToWorkReport.WoundType;
                    _isgoremezlikRaporDVO.meslekHastaligiRaporu = _meslekHastaligiRaporDVO;
                    break;

                    //HASTALIK RAPORU______________________________
                case 2:
                    RaporIslemleri.hastalikRaporDVO _hastalikRaporDVO = new RaporIslemleri.hastalikRaporDVO();
                    if (continuedHospitalizationType != 3)
                    {
                        if (_UnavailableToWorkReport.RestingStartDate != null && _UnavailableToWorkReport.RestingStartDate.Value != null)
                            _hastalikRaporDVO.baslangicTarihi = _UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy");

                        if (_UnavailableToWorkReport.RestingEndDate != null && _UnavailableToWorkReport.RestingEndDate.Value != null)
                            _hastalikRaporDVO.bitisTarihi = _UnavailableToWorkReport.RestingEndDate.Value.ToString("dd.MM.yyyy");
                    }
                    if (_UnavailableToWorkReport.SituationDate != null && _UnavailableToWorkReport.SituationDate.Value != null)
                        _hastalikRaporDVO.isKontTarihi = _UnavailableToWorkReport.SituationDate.Value.ToString("dd.MM.yyyy");

                    //2 yatış devam 3 taburcu
                    if (continuedHospitalizationType != 1)
                    {
                        if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null)
                            _hastalikRaporDVO.XXXXXXYatisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToString("dd.MM.yyyy");
                        if (continuedHospitalizationType != 2)
                        {
                            _hastalikRaporDVO.XXXXXXCikisTarihi = _UnavailableToWorkReport.DischargeDate.Value.ToString("dd.MM.yyyy");
                            _hastalikRaporDVO.taburcuTarihi = _UnavailableToWorkReport.DischargeDate.Value.ToString("dd.MM.yyyy");
                        }
                    }

                    if (_UnavailableToWorkReport.NuksType != null)
                        _hastalikRaporDVO.nuks = ((int)_UnavailableToWorkReport.NuksType).ToString();

                    if (_UnavailableToWorkReport.Situation != null)
                        _hastalikRaporDVO.raporDurumu = ((int)_UnavailableToWorkReport.Situation).ToString();

                    if (_UnavailableToWorkReport.DischargedCodeType != null)
                        _hastalikRaporDVO.taburcuKodu = Convert.ToInt32(this._UnavailableToWorkReport.DischargedCodeType);

                    _isgoremezlikRaporDVO.hastalikRaporu = _hastalikRaporDVO;
                    break;

                    //ANALIK RAPORU______________________________
                case 3:
                    RaporIslemleri.analikRaporDVO _analikRaporDVO = new RaporIslemleri.analikRaporDVO();

                    if (_UnavailableToWorkReport.Situation != null)
                        _analikRaporDVO.raporDurumu = Convert.ToInt32(this._UnavailableToWorkReport.Situation).ToString();

                    if (_UnavailableToWorkReport.PregnancyType == null)
                        throw new TTUtils.TTException("Gebelik tipi boş olamaz!");

                    _analikRaporDVO.gebelikTipi = Convert.ToInt32(this._UnavailableToWorkReport.PregnancyType);
                    if (continuedHospitalizationType != 3)
                    {
                        if (_UnavailableToWorkReport.RestingStartDate != null && _UnavailableToWorkReport.RestingStartDate.Value != null)
                            _analikRaporDVO.baslangicTarihi = _UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy");
                    }
                    if (_UnavailableToWorkReport.SituationDate != null)
                    {
                        if (_UnavailableToWorkReport.SituationDate.Value != null)
                            _analikRaporDVO.isKontTarihi = _UnavailableToWorkReport.SituationDate.Value.ToString("dd.MM.yyyy");
                    }

                    if (this._UnavailableToWorkReport.MaternityReportType == TTObjectClasses.MaternityReportTypeEnum.PostNatal)
                    {
                        //2 yatış devam 3 taburcu
                        if (continuedHospitalizationType != 1)
                        {
                            if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null)
                                _analikRaporDVO.XXXXXXYatisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToString("dd.MM.yyyy");

                            if (continuedHospitalizationType != 2)
                            {
                                _analikRaporDVO.XXXXXXCikisTarihi = _UnavailableToWorkReport.DischargeDate.Value.ToString("dd.MM.yyyy");
                                _analikRaporDVO.taburcuTarihi = _UnavailableToWorkReport.DischargeDate.Value.ToString("dd.MM.yyyy");
                            }
                        }

                        if (_UnavailableToWorkReport.LiveBirthsNumber != null && _UnavailableToWorkReport.ChildrenBornNumber != null)
                        {
                            if (Convert.ToInt32(_UnavailableToWorkReport.ChildrenBornNumber) < Convert.ToInt32(_UnavailableToWorkReport.LiveBirthsNumber))
                                throw new TTUtils.TTException("Canlı Çocuk Sayısı Doğan Çocuk Sayısından Büyük Olamaz.");

                            if (Convert.ToInt32(_UnavailableToWorkReport.ChildrenBornNumber) > 1)
                            {
                                if (_UnavailableToWorkReport.PregnancyType == PregnancyTypeEnum.Singular)
                                    throw new TTUtils.TTException("Doğan Çocuk Sayısı 1 den fazla ise Gebelik Tipi Çoğul Seçilmelidir.");
                            }
                        }

                        _analikRaporDVO.analikRaporTipi = 2;

                        if (_UnavailableToWorkReport.BabyBirthWeek != null)
                            _analikRaporDVO.bebekDogumHaftasi = Convert.ToInt32(_UnavailableToWorkReport.BabyBirthWeek);

                        if (_UnavailableToWorkReport.BabyBirthDate != null)
                            _analikRaporDVO.bebekDogumTarihi = _UnavailableToWorkReport.BabyBirthDate.Value.ToString("dd.MM.yyyy");

                        if (_UnavailableToWorkReport.LiveBirthsNumber != null)
                            _analikRaporDVO.canliCocukSayisi = Convert.ToInt32(_UnavailableToWorkReport.LiveBirthsNumber);

                        if (_UnavailableToWorkReport.ChildrenBornNumber != null)
                            _analikRaporDVO.doganCocukSayisi = Convert.ToInt32(_UnavailableToWorkReport.ChildrenBornNumber);

                        if (_UnavailableToWorkReport.BirthType != null)
                            _analikRaporDVO.norSezFor = Convert.ToInt32(_UnavailableToWorkReport.BirthType).ToString();

                        if (_UnavailableToWorkReport.DischargedCodeType != null)
                            _analikRaporDVO.taburcuKodu = Convert.ToInt32(_UnavailableToWorkReport.DischargedCodeType);
                    }
                    else
                    {
                        _analikRaporDVO.analikRaporTipi = 1;

                        _analikRaporDVO.norSezFor = "";
                        _analikRaporDVO.bebekDogumTarihi = "";
                        if (_UnavailableToWorkReport.GestationalOne != null)
                            _analikRaporDVO.gebelikHaftasi1 = Convert.ToInt32(this._UnavailableToWorkReport.GestationalOne);

                        if (_UnavailableToWorkReport.GestationalTwo != null)
                            _analikRaporDVO.gebelikHaftasi2 = Convert.ToInt32(this._UnavailableToWorkReport.GestationalTwo);
                    }
                    _isgoremezlikRaporDVO.analikRaporu = _analikRaporDVO;
                    break;

                    //EMZİRME RAPORU____________________________________
                case 4:
                    RaporIslemleri.emzirmeRaporDVO _emzirmeRaporDVO = new RaporIslemleri.emzirmeRaporDVO();
                    
                    if (!string.IsNullOrEmpty(_UnavailableToWorkReport.MotherTCNo))
                        _emzirmeRaporDVO.anneTcKimlikNo = _UnavailableToWorkReport.MotherTCNo;

                    if (_UnavailableToWorkReport.BabyBirthDate != null)
                        _emzirmeRaporDVO.bebekDogumTarihi = _UnavailableToWorkReport.BabyBirthDate.Value.ToString("dd.MM.yyyy");

                    if (_UnavailableToWorkReport.LiveBirthsNumber != null)
                        _emzirmeRaporDVO.canliCocukSayisi = Convert.ToInt32(this._UnavailableToWorkReport.LiveBirthsNumber);

                    if (_UnavailableToWorkReport.ChildrenBornNumber != null)
                        _emzirmeRaporDVO.doganCocukSayisi = Convert.ToInt32(this._UnavailableToWorkReport.ChildrenBornNumber);
                    _isgoremezlikRaporDVO.emzirmeRaporu = _emzirmeRaporDVO;
                    break;
            }


            raporGirisDVO.isgoremezlikRapor = _isgoremezlikRaporDVO;
            if (raporGirisDVO.isgoremezlikRapor.raporDVO.raporBilgisi.raporSiraNo == null)
                raporGirisDVO.isgoremezlikRapor.raporDVO.raporBilgisi.raporSiraNo = 0;
            if (raporGirisDVO.isgoremezlikRapor.raporDVO.raporBilgisi.raporTakipNo == null)
                raporGirisDVO.isgoremezlikRapor.raporDVO.raporBilgisi.raporTakipNo = "0";

            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.takipNoileRaporBilgisiKaydetSync(Sites.SiteLocalHost, raporGirisDVO);
            if (response != null )
            {
                _UnavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                _UnavailableToWorkReport.ResultExplanation = response.sonucAciklamasi;

                if (_UnavailableToWorkReport.VucutYeri != null)
                    _UnavailableToWorkReport.WoundType = _UnavailableToWorkReport.VucutYeri.CodeValueCode;

                if (_UnavailableToWorkReport.YaraTuru != null)
                    _UnavailableToWorkReport.WoundPosition = _UnavailableToWorkReport.YaraTuru.CodeValueCode;

                if (response.sonucKodu.Equals(0))
                {
                    MedulaChasingNo.Text = response.raporTakipNo.ToString();
                    _UnavailableToWorkReport.MedulaChasingNo = response.raporTakipNo.ToString();
                    _UnavailableToWorkReport.MedulaReportType = response.raporTuru;

                    if (response.isgoremezlikRapor != null && response.isgoremezlikRapor.raporDVO != null && response.isgoremezlikRapor.raporDVO.raporBilgisi != null && response.isgoremezlikRapor.raporDVO.raporBilgisi.raporSiraNo != null)
                    {
                        _UnavailableToWorkReport.ReportRowNumber = response.isgoremezlikRapor.raporDVO.raporBilgisi.raporSiraNo.ToString();
                        ReportRowNumber.Text = response.isgoremezlikRapor.raporDVO.raporBilgisi.raporSiraNo.ToString();
                    }

                    TTObjectContext newContext = new TTObjectContext(false);
                    UnavailToWorkRprtInfo unavailToWorkRprtInfo = new UnavailToWorkRprtInfo(newContext);
                    unavailToWorkRprtInfo.MedulaChasingNo = _UnavailableToWorkReport.MedulaChasingNo;
                    unavailToWorkRprtInfo.ReportSeqNo = _UnavailableToWorkReport.ReportSeqNo.ToString();
                    unavailToWorkRprtInfo.ReportRowNumber = _UnavailableToWorkReport.ReportRowNumber;
                    unavailToWorkRprtInfo.RestingStartDate = _UnavailableToWorkReport.RestingStartDate;
                    unavailToWorkRprtInfo.RestingEndDate = _UnavailableToWorkReport.RestingEndDate;
                    unavailToWorkRprtInfo.Excuse = _UnavailableToWorkReport.Excuse;
                    unavailToWorkRprtInfo.Name = _UnavailableToWorkReport.Episode.Patient.Name;
                    unavailToWorkRprtInfo.Surname = _UnavailableToWorkReport.Episode.Patient.Surname;
                    unavailToWorkRprtInfo.BirthDate = _UnavailableToWorkReport.Episode.Patient.BirthDate;
                    //unavailToWorkRprtInfo.UnIdentified = _UnavailableToWorkReport.Episode.Patient.UnIdentified;
                    unavailToWorkRprtInfo.UniqueRefNo = _UnavailableToWorkReport.Episode.Patient.UniqueRefNo;
                    unavailToWorkRprtInfo.ReportDeleted = false;
                    newContext.Save();
                }
                ResultCode.Text = response.sonucKodu.ToString();
                ResultExplanation.Text = response.sonucAciklamasi;
            }
            else
            {
                ResultExplanation.Text = "Meduladan cevap alınamadı!";
                throw new TTUtils.TTException("Meduladan cevap alınamadı!");
            }
#endregion UnavailableToWorkReportForm_btnMedulaKaydet_Click
        }

        private void btnMedulaSaglikKurulunaSevket_Click()
        {
#region UnavailableToWorkReportForm_btnMedulaSaglikKurulunaSevket_Click
   if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                try
                {
                    if (string.IsNullOrEmpty(this._UnavailableToWorkReport.MedulaChasingNo) || string.IsNullOrEmpty(this._UnavailableToWorkReport.ReportRowNumber))
                    {
                        InfoBox.Show("Rapor Medulaya Kayıt Edilmediğinden Dolayı Sağlık Kuruluna Sevket İşlemi Gerçekleştirilemez!!!");
                        return;

                    }

                    IsGormezlikServis.CevapDTO response = IsGormezlikServis.WebMethods.saglikKurulunaSevketSync(Sites.SiteLocalHost, this._UnavailableToWorkReport.MedulaChasingNo, Convert.ToInt32(this._UnavailableToWorkReport.ReportRowNumber), ((int)this._UnavailableToWorkReport.Situation).ToString());
                    if (response != null )
                    {
                        if (response.sonucKodu.Equals(0))
                        {
                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));

                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = "Medula Sağlık Kuruluna Sevk İşlemi Tamamlanmıştır";

                            unavailableToWorkReport.ReportRowNumber = response.raporSiraNo.ToString();
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.hataMesaji;
                            unavailableToWorkReport.MedulaChasingNo = response.raporTakipNo.ToString();
                            unavailableToWorkReport.ReportRowNumber = response.raporSiraNo.ToString();
                            context.Save();
                        }
                        else
                        {
                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));

                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji;
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.hataMesaji;
                            context.Save();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
#endregion UnavailableToWorkReportForm_btnMedulaSaglikKurulunaSevket_Click
        }

        private void btnMdedulaSil_Click()
        {
#region UnavailableToWorkReportForm_btnMdedulaSil_Click
   if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                try
                {
                    int vakaTuru = 0;

                    if (this._UnavailableToWorkReport.Excuse != null)
                    {
                        switch (Convert.ToInt32(this._UnavailableToWorkReport.Excuse))
                        {
                            case 0:
                                vakaTuru = 1;
                                break;
                            case 1:
                                vakaTuru = 2;
                                break;
                            case 2:
                                vakaTuru = 3;
                                break;
                            case 3:
                                vakaTuru = 4;
                                break;
                            case 4:
                                vakaTuru = 5;
                                break;
                        }
                    }

                    if (string.IsNullOrEmpty(this._UnavailableToWorkReport.MedulaChasingNo) || string.IsNullOrEmpty(this._UnavailableToWorkReport.ReportRowNumber))
                    {
                        InfoBox.Show("Rapor Medulaya Kayıt Edilmediğinden Dolayı Rapor Silme İşlemi Gerçekleştirilemez!!!");
                        return;

                    }

                    IsGormezlikServis.CevapDTO response = IsGormezlikServis.WebMethods.raporSilSync(Sites.SiteLocalHost, this._UnavailableToWorkReport.MedulaChasingNo, Convert.ToInt32(this._UnavailableToWorkReport.ReportRowNumber), vakaTuru, TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                    if (response != null)
                    {
                        if (response.sonucKodu.Equals(0))
                        {
                            BindingList<UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery_Class> getUnavailToWorkRptInfo = UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery(Convert.ToInt64(_UnavailableToWorkReport.Episode.Patient.UniqueRefNo));
                            TTObjectContext newContext = new TTObjectContext(false);
                            foreach (UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery_Class item in getUnavailToWorkRptInfo)
                            {
                                if (item.MedulaChasingNo == this._UnavailableToWorkReport.MedulaChasingNo && item.ReportRowNumber == this._UnavailableToWorkReport.ReportRowNumber)
                                {
                                    UnavailToWorkRprtInfo unavailToWorkRprtInfo = (UnavailToWorkRprtInfo)newContext.GetObject((item.ObjectID).GetValueOrDefault(), typeof(UnavailToWorkRprtInfo));
                                    unavailToWorkRprtInfo.ReportDeleted = true;
                                    newContext.Save();
                                }
                            }

                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = "Rapor Bilgisi Silinmiştir";
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = "Rapor Bilgisi Silinmiştir";
                            unavailableToWorkReport.MedulaChasingNo = "";
                            unavailableToWorkReport.ReportRowNumber = "";
                            unavailableToWorkReport.CarryCase = CarryCaseTypeEnum.No;
                            MedulaChasingNo.Text = "";
                            ReportRowNumber.Text = "";
                            context.Save();

                            InfoBox.Show("Hastanın Raporu Silinmiştir ! ");
                        }
                        else
                        {
                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji;
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.hataMesaji;
                            unavailableToWorkReport.CarryCase = CarryCaseTypeEnum.No;
                            context.Save();

                            InfoBox.Show("Hastanın Raporu Silinememiştir !!! ");
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
#endregion UnavailableToWorkReportForm_btnMdedulaSil_Click
        }

        private void btnMedulaRaporGuncelle_Click()
        {
#region UnavailableToWorkReportForm_btnMedulaRaporGuncelle_Click
   if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                try
                {
                    if (string.IsNullOrEmpty(this._UnavailableToWorkReport.MedulaChasingNo) || string.IsNullOrEmpty(this._UnavailableToWorkReport.ReportRowNumber))
                    {
                        InfoBox.Show("Rapor Medulaya Kayıt Edilmediğinden Dolayı Rapor Güncelleme İşlemi Gerçekleştirilemez!!!");
                        return;

                    }

                    IsGormezlikServis.IsgoremezlikRaporDVO _isgoremezlikRaporDVO = new IsGormezlikServis.IsgoremezlikRaporDVO();
                    foreach (DoctorGrid doctor in this._UnavailableToWorkReport.DoctorsGrid)
                    {
                        bool ctrl = false;
                        if (doctor.ResUser != null && doctor.ResUser.ResourceSpecialities != null)
                        {
                            foreach (ResourceSpecialityGrid resource in doctor.ResUser.ResourceSpecialities)
                            {
                                if (resource.MainSpeciality != null && resource.MainSpeciality.Equals(true))
                                {
                                    if (resource.Speciality != null && resource.Speciality.Code != null)
                                    {
                                        ctrl = true;

                                        _isgoremezlikRaporDVO.bransKodu = Convert.ToInt32(resource.Speciality.Code);
                                        break;
                                    }
                                }
                            }
                            if (!ctrl)
                            {
                                _isgoremezlikRaporDVO.bransKodu = 0;
                            }
                        }
                        else
                        {
                            _isgoremezlikRaporDVO.bransKodu = 0;
                        }
                    }

                    _isgoremezlikRaporDVO.devammi = 0;

                    if (this._UnavailableToWorkReport.Excuse != null)
                    {
                        switch (Convert.ToInt32(this._UnavailableToWorkReport.Excuse))
                        {
                            case 0:
                                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 1;
                                break;
                            case 1:
                                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 2;
                                break;
                            case 2:
                                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 3;
                                break;
                            case 3:
                                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 4;
                                break;
                            case 4:
                                _isgoremezlikRaporDVO.isGoremezlikRaporTuru = 5;
                                break;
                        }
                    }

                    _isgoremezlikRaporDVO.olum = this._UnavailableToWorkReport.DeathType != null ? ((int)this._UnavailableToWorkReport.DeathType).ToString() : "";
                    _isgoremezlikRaporDVO.duzenlemeTuru = this._UnavailableToWorkReport.EditingTourType != null ? ((int)this._UnavailableToWorkReport.EditingTourType).ToString() : "";
                    _isgoremezlikRaporDVO.teshis = this._UnavailableToWorkReport.DiagnosisDefinition.Code;
                    _isgoremezlikRaporDVO.yatisDevam = this._UnavailableToWorkReport.ContinuedHospitalizationType != null ? ((int)this._UnavailableToWorkReport.ContinuedHospitalizationType).ToString() : "";

                    if ((int)this._UnavailableToWorkReport.EditingTourType == 1)
                    {
                        _isgoremezlikRaporDVO.karar = "uygundur";
                    }

                    IsGormezlikServis.RaporBilgisiDVO _raporBilgisiDVO = new IsGormezlikServis.RaporBilgisiDVO();
                    _raporBilgisiDVO.AVakaTKaza = 3;
                    _raporBilgisiDVO.no = this._UnavailableToWorkReport.ReportSeqNo.Value.ToString();
                    _raporBilgisiDVO.raporSiraNo = this._UnavailableToWorkReport.ReportRowNumber != null ? Convert.ToInt32(this._UnavailableToWorkReport.ReportRowNumber) : 0;
                    _raporBilgisiDVO.raporTakipNo = this._UnavailableToWorkReport.MedulaChasingNo;

                    _raporBilgisiDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                    _raporBilgisiDVO.tarih = this._UnavailableToWorkReport.RestingStartDate != null ? this._UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy") : "";

                    _isgoremezlikRaporDVO.raporBilgisi = _raporBilgisiDVO;

                    //List<IsGormezlikServis.DoktorBilgisiDVO> _doktorBilgisiDVOList = new List<IsGormezlikServis.DoktorBilgisiDVO>();
                    //IsGormezlikServis.DoktorBilgisiDVO _doktorBilgisiDVO = new IsGormezlikServis.DoktorBilgisiDVO();
                    //_doktorBilgisiDVO.drAdi = this._UnavailableToWorkReport.ProcedureDoctor.Person.Name;
                    //_doktorBilgisiDVO.drBransKodu = this._UnavailableToWorkReport.ProcedureDoctor.GetSpeciality() != null ? this._UnavailableToWorkReport.ProcedureDoctor.GetSpeciality().Code : "";
                    //_doktorBilgisiDVO.drSoyadi = this._UnavailableToWorkReport.ProcedureDoctor.Person.Surname;
                    //_doktorBilgisiDVO.drTescilNo = this._UnavailableToWorkReport.ProcedureDoctor.DiplomaRegisterNo;
                    //_doktorBilgisiDVO.tipi = "2";
                    //_doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
                    //_isgoremezlikRaporDVO.doktorArr = _doktorBilgisiDVOList.ToArray();

                    List<IsGormezlikServis.DoktorBilgisiDVO> _doktorBilgisiDVOList = new List<IsGormezlikServis.DoktorBilgisiDVO>();
                    foreach (DoctorGrid doctor in this._UnavailableToWorkReport.DoctorsGrid)
                    {
                        IsGormezlikServis.DoktorBilgisiDVO _doktorBilgisiDVO = new IsGormezlikServis.DoktorBilgisiDVO();
                        if (doctor.ResUser != null && doctor.ResUser.DiplomaRegisterNo != null)
                            _doktorBilgisiDVO.drTescilNo = doctor.ResUser.DiplomaRegisterNo;
                        else
                        {
                            if (doctor.ResUser != null)
                            {
                                InfoBox.Show(doctor.ResUser.Name + "  doktorun tescil numarası dolu olmalıdır!");
                                return;
                            }
                            else
                            {
                                InfoBox.Show("doktorun tescil numarası dolu olmalıdır!");
                                return;
                            }
                        }

                        _doktorBilgisiDVO.drAdi = doctor.ResUser.Person != null ? doctor.ResUser.Person.Name : "";
                        _doktorBilgisiDVO.drSoyadi = doctor.ResUser.Person != null ? doctor.ResUser.Person.Surname : "";
                        bool ctrl = false;
                        if (doctor.ResUser != null && doctor.ResUser.ResourceSpecialities != null)
                        {
                            foreach (ResourceSpecialityGrid resource in doctor.ResUser.ResourceSpecialities)
                            {
                                if (resource.MainSpeciality != null && resource.MainSpeciality.Equals(true))
                                {
                                    if (resource.Speciality != null && resource.Speciality.Code != null)
                                    {
                                        ctrl = true;
                                        _doktorBilgisiDVO.drBransKodu = resource.Speciality.Code;
                                    }
                                }
                            }
                            if (!ctrl)
                            {
                                InfoBox.Show(doctor.ResUser.Name + "  doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
                                return;
                            }
                        }

                        else
                        {
                            if (doctor.ResUser != null)
                            {
                                InfoBox.Show(doctor.ResUser.Name + "  doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
                                return;
                            }
                            else
                            {
                                InfoBox.Show(" doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
                                return;
                            }

                        }

                        _doktorBilgisiDVO.tipi = "2";
                        _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
                    }
                    if (_doktorBilgisiDVOList != null && _doktorBilgisiDVOList.Count > 0)
                        _isgoremezlikRaporDVO.doktorArr = _doktorBilgisiDVOList.ToArray();

                    IsGormezlikServis.HakSahibiBilgisiDVO _hakSahibiBilgisiDVO = new IsGormezlikServis.HakSahibiBilgisiDVO();
                    if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null)
                    {
                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaProvizyonTarihi != null)
                        {
                            _hakSahibiBilgisiDVO.provizyonTarihi = this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaProvizyonTarihi.ToString();
                        }
                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaProvizyonTipi != null)
                        {
                            _hakSahibiBilgisiDVO.provizyonTipi = this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu;

                        }
                    }
                    _hakSahibiBilgisiDVO.sigortaliTuru = "1";

                    if( _UnavailableToWorkReport.NotWorkMother == true)
                    {
                        if(_UnavailableToWorkReport.FatherTCNo != null)
                            _hakSahibiBilgisiDVO.tckimlikNo = _UnavailableToWorkReport.FatherTCNo;
                        else
                            throw new TTException("Anne çalışmıyor ise baba TC Kimlik Numarası girilmeli!");
                    }
                    else
                        _hakSahibiBilgisiDVO.tckimlikNo = this._UnavailableToWorkReport.Episode.Patient.UniqueRefNo != null ? this._UnavailableToWorkReport.Episode.Patient.UniqueRefNo.Value.ToString() : "00000000000";
                    
                    _isgoremezlikRaporDVO.hakSahibi = _hakSahibiBilgisiDVO;


                    int raporTuru = Convert.ToInt32(this._UnavailableToWorkReport.Excuse);

                    switch (raporTuru)
                    {
                        case 0:
                            IsGormezlikServis.IsKazasiRaporDVO _isKazasiRaporDVO = new IsGormezlikServis.IsKazasiRaporDVO();
                            _isKazasiRaporDVO.baslangicTarihi = this._UnavailableToWorkReport.RestingStartDate != null ? this._UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                            _isKazasiRaporDVO.bitisTarihi = this._UnavailableToWorkReport.RestingEndDate != null ? this._UnavailableToWorkReport.RestingEndDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                            switch ((int)this._UnavailableToWorkReport.ContinuedHospitalizationType)
                            {
                                case 3:
                                    if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate != null)
                                        _isKazasiRaporDVO.XXXXXXCikisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate.Value.ToString("dd.MM.yyyy");
                                    else
                                        InfoBox.Show("Yatış Devam Durumu Yatış Var, Taburcu Olmuş Secilmiş İse XXXXXX Çıkış Tarihi Zorunludur ");
                                    break;
                                case 2:
                                    if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate != null)
                                        _isKazasiRaporDVO.XXXXXXYatisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToString("dd.MM.yyyy");
                                    else
                                        InfoBox.Show("Yatış Devam Durumu Yatış Devam Ediyor Secilmiş İse XXXXXX Yatış Tarihi Zorunludur");
                                    break;
                                case 1:
                                    _isKazasiRaporDVO.XXXXXXCikisTarihi = string.Empty;
                                    _isKazasiRaporDVO.XXXXXXYatisTarihi = string.Empty;
                                    _isKazasiRaporDVO.isKontTarihi = this._UnavailableToWorkReport.SituationDate != null ? this._UnavailableToWorkReport.SituationDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                                    break;
                            }

                            _isKazasiRaporDVO.nuks = this._UnavailableToWorkReport.NuksType != null ? ((int)this._UnavailableToWorkReport.NuksType).ToString() : "";
                            //
                            if (this._UnavailableToWorkReport.AccidentDate != null)
                            {
                                _isKazasiRaporDVO.isKazasiTarihi = this._UnavailableToWorkReport.AccidentDate.Value.ToString("dd.MM.yyyy");
                            }
                            else
                                InfoBox.Show("İş Kazası Tarihi Zorunludur");

                            _isKazasiRaporDVO.raporDurumu = ((int)this._UnavailableToWorkReport.Situation).ToString();

                            _isKazasiRaporDVO.taburcuKodu = this._UnavailableToWorkReport.DischargedCodeType != null ? Convert.ToInt32(this._UnavailableToWorkReport.DischargedCodeType) : 0;
                            if ((int)this._UnavailableToWorkReport.ContinuedHospitalizationType == 3)
                            {

                                if (this._UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && this._UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate != null)
                                {
                                    _isKazasiRaporDVO.taburcuTarihi = this._UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate.Value.ToString("dd.MM.yyyy");
                                }
                                else
                                    InfoBox.Show("Yatış Devam Durumu Yatış Var, Taburcu Olmuş Secilmiş İse Taburcu Tarihi Zorunludur ");

                            }
                            else
                            {
                                _isKazasiRaporDVO.taburcuTarihi = string.Empty;
                            }
                            _isKazasiRaporDVO.yaraninTuru = "59";
                            _isKazasiRaporDVO.yaraninYeri = "51";
                            _isgoremezlikRaporDVO.analikRaporu = null;
                            _isgoremezlikRaporDVO.emzirmeRaporu = null;
                            _isgoremezlikRaporDVO.hastalikRaporu = null;
                            _isgoremezlikRaporDVO.meslekHastaligiRaporu = null;
                            _isgoremezlikRaporDVO.isKazasiRaporu = _isKazasiRaporDVO;
                            break;
                        case 1:
                            IsGormezlikServis.MeslekHastaligiRaporDVO _meslekHastaligiRaporDVO = new IsGormezlikServis.MeslekHastaligiRaporDVO();
                            _meslekHastaligiRaporDVO.baslangicTarihi = this._UnavailableToWorkReport.RestingStartDate != null ? this._UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                            _meslekHastaligiRaporDVO.bitisTarihi = this._UnavailableToWorkReport.RestingEndDate != null ? this._UnavailableToWorkReport.RestingEndDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                            switch ((int)this._UnavailableToWorkReport.ContinuedHospitalizationType)
                            {
                                case 3:
                                    if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate != null)
                                        _meslekHastaligiRaporDVO.XXXXXXCikisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate.Value.ToString("dd.MM.yyyy");
                                    else
                                        InfoBox.Show("Yatış Devam Durumu Yatış Var, Taburcu Olmuş Secilmiş İse XXXXXX Çıkış Tarihi Zorunludur ");
                                    break;
                                case 2:
                                    if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate != null)
                                        _meslekHastaligiRaporDVO.XXXXXXYatisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToString("dd.MM.yyyy");
                                    else
                                        InfoBox.Show("Yatış Devam Durumu Yatış Devam Ediyor Secilmiş İse XXXXXX Yatış Tarihi Zorunludur");
                                    break;
                                case 1:
                                    _meslekHastaligiRaporDVO.XXXXXXCikisTarihi = string.Empty;
                                    _meslekHastaligiRaporDVO.XXXXXXYatisTarihi = string.Empty;
                                    _meslekHastaligiRaporDVO.isKontTarihi = this._UnavailableToWorkReport.SituationDate != null ? this._UnavailableToWorkReport.SituationDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                                    break;
                            }

                            _meslekHastaligiRaporDVO.taburcuKodu = this._UnavailableToWorkReport.DischargedCodeType != null ? Convert.ToInt32(this._UnavailableToWorkReport.DischargedCodeType) : 0;
                            _meslekHastaligiRaporDVO.nuks = this._UnavailableToWorkReport.NuksType != null ? ((int)this._UnavailableToWorkReport.NuksType).ToString() : "";
                            if (this._UnavailableToWorkReport.Situation != null)
                            {
                                switch ((int)this._UnavailableToWorkReport.Situation)
                                {
                                    case 0:
                                        _meslekHastaligiRaporDVO.raporDurumu = "1";
                                        break;
                                    case 1:
                                        _meslekHastaligiRaporDVO.raporDurumu = "2";
                                        break;
                                }

                            }
                            _meslekHastaligiRaporDVO.taburcuKodu = this._UnavailableToWorkReport.DischargedCodeType != null ? Convert.ToInt32(this._UnavailableToWorkReport.DischargedCodeType) : 0;
                            if ((int)this._UnavailableToWorkReport.ContinuedHospitalizationType == 3)
                            {

                                if (this._UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && this._UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate != null)
                                {
                                    _meslekHastaligiRaporDVO.taburcuTarihi = this._UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate.Value.ToString("dd.MM.yyyy");
                                }
                                else
                                    InfoBox.Show("Yatış Devam Durumu Yatış Var, Taburcu Olmuş Secilmiş İse Taburcu Tarihi Zorunludur ");

                            }
                            else
                            {
                                _meslekHastaligiRaporDVO.taburcuTarihi = string.Empty;
                            }
                            _meslekHastaligiRaporDVO.yaraninTuru = "59";
                            _meslekHastaligiRaporDVO.yaraninYeri = "51";
                            _isgoremezlikRaporDVO.analikRaporu = null;
                            _isgoremezlikRaporDVO.emzirmeRaporu = null;
                            _isgoremezlikRaporDVO.hastalikRaporu = null;
                            _isgoremezlikRaporDVO.isKazasiRaporu = null;
                            _isgoremezlikRaporDVO.meslekHastaligiRaporu = _meslekHastaligiRaporDVO;
                            break;
                        case 2:
                            IsGormezlikServis.HastalikRaporDVO _hastalikRaporDVO = new IsGormezlikServis.HastalikRaporDVO();
                            _hastalikRaporDVO.baslangicTarihi = this._UnavailableToWorkReport.RestingStartDate != null ? this._UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                            _hastalikRaporDVO.bitisTarihi = this._UnavailableToWorkReport.RestingEndDate != null ? this._UnavailableToWorkReport.RestingEndDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");

                            switch ((int)this._UnavailableToWorkReport.ContinuedHospitalizationType)
                            {
                                case 3:
                                    if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate != null)
                                        _hastalikRaporDVO.XXXXXXCikisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate.Value.ToString("dd.MM.yyyy");
                                    else
                                        InfoBox.Show("Yatış Devam Durumu Yatış Var, Taburcu Olmuş Secilmiş İse XXXXXX Çıkış Tarihi Zorunludur ");
                                    break;
                                case 2:
                                    if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate != null)
                                        _hastalikRaporDVO.XXXXXXYatisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToString("dd.MM.yyyy");
                                    else
                                        InfoBox.Show("Yatış Devam Durumu Yatış Devam Ediyor Secilmiş İse XXXXXX Yatış Tarihi Zorunludur");
                                    break;
                                case 1:
                                    _hastalikRaporDVO.XXXXXXCikisTarihi = string.Empty;
                                    _hastalikRaporDVO.XXXXXXYatisTarihi = string.Empty;
                                    _hastalikRaporDVO.isKontTarihi = this._UnavailableToWorkReport.SituationDate != null ? this._UnavailableToWorkReport.SituationDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                                    break;
                            }

                            _hastalikRaporDVO.nuks = "2";
                            _hastalikRaporDVO.raporDurumu = ((int)this._UnavailableToWorkReport.Situation).ToString();


                            _hastalikRaporDVO.taburcuKodu = this._UnavailableToWorkReport.DischargedCodeType != null ? Convert.ToInt32(this._UnavailableToWorkReport.DischargedCodeType) : 0;
                            if ((int)this._UnavailableToWorkReport.ContinuedHospitalizationType == 3)
                            {
                                if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate != null)
                                    _hastalikRaporDVO.taburcuTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate.Value.ToString("dd.MM.yyyy");
                                else
                                    InfoBox.Show("Yatış Devam Durumu Yatış Var, Taburcu Olmuş Secilmiş İse Taburcu Tarihi Zorunludur ");

                            }
                            else
                            {
                                _hastalikRaporDVO.taburcuTarihi = string.Empty;
                            }
                            _isgoremezlikRaporDVO.analikRaporu = null;
                            _isgoremezlikRaporDVO.emzirmeRaporu = null;
                            _isgoremezlikRaporDVO.isKazasiRaporu = null;
                            _isgoremezlikRaporDVO.meslekHastaligiRaporu = null;
                            _isgoremezlikRaporDVO.hastalikRaporu = _hastalikRaporDVO;
                            break;
                        case 3:
                            IsGormezlikServis.AnalikRaporDVO _analikRaporDVO = new IsGormezlikServis.AnalikRaporDVO();
                            if ((int)this._UnavailableToWorkReport.MaternityReportType == 2)
                            {
                                _analikRaporDVO.baslangicTarihi = this._UnavailableToWorkReport.RestingStartDate != null ? this._UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                                _analikRaporDVO.analikRaporTipi = 2;

                                if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate != null)
                                    _analikRaporDVO.XXXXXXCikisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate.Value.ToString("dd.MM.yyyy");
                                else
                                    InfoBox.Show("Yatış Devam Durumu Yatış Var, Taburcu Olmuş Secilmiş İse XXXXXX Çıkış Tarihi Zorunludur ");


                                if (_UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate != null)
                                    _analikRaporDVO.XXXXXXYatisTarihi = _UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToString("dd.MM.yyyy");
                                else
                                    InfoBox.Show("Yatış Devam Durumu Yatış Devam Ediyor Secilmiş İse XXXXXX Yatış Tarihi Zorunludur");

                                if (this._UnavailableToWorkReport.LiveBirthsNumber != null && this._UnavailableToWorkReport.ChildrenBornNumber != null)
                                {
                                    if (Convert.ToInt32(this._UnavailableToWorkReport.ChildrenBornNumber) < Convert.ToInt32(this._UnavailableToWorkReport.LiveBirthsNumber))
                                    {
                                        InfoBox.Show("Canlı Çocuk Sayısı Doğan Çocuk Sayısından Büyük Olamaz."); return;
                                    }
                                    if (Convert.ToInt32(this._UnavailableToWorkReport.ChildrenBornNumber) > 1)
                                    {
                                        if (this._UnavailableToWorkReport.PregnancyType == PregnancyTypeEnum.Singular)
                                        {
                                            InfoBox.Show("Doğan Çocuk Sayısı 1 den fazla ise Gebelik Tipi Çoğul Seçilmelidir."); return;
                                        }
                                    }
                                }

                                _analikRaporDVO.bebekDogumHaftasi = this._UnavailableToWorkReport.BabyBirthWeek != null ? Convert.ToInt32(this._UnavailableToWorkReport.BabyBirthWeek) : 0;
                                _analikRaporDVO.bebekDogumTarihi = this._UnavailableToWorkReport.BabyBirthDate != null ? this._UnavailableToWorkReport.BabyBirthDate.Value.ToString("dd.MM.yyyy") : "";
                                _analikRaporDVO.canliCocukSayisi = this._UnavailableToWorkReport.LiveBirthsNumber != null ? Convert.ToInt32(this._UnavailableToWorkReport.LiveBirthsNumber) : 0;
                                _analikRaporDVO.doganCocukSayisi = this._UnavailableToWorkReport.ChildrenBornNumber != null ? Convert.ToInt32(this._UnavailableToWorkReport.ChildrenBornNumber) : 0;
                                _analikRaporDVO.norSezFor = this._UnavailableToWorkReport.BirthType != null ? Convert.ToInt32(this._UnavailableToWorkReport.BirthType).ToString() : "0";
                                _analikRaporDVO.gebelikTipi = this._UnavailableToWorkReport.PregnancyType != null ? Convert.ToInt32(this._UnavailableToWorkReport.PregnancyType) : 0;
                                _analikRaporDVO.taburcuKodu = this._UnavailableToWorkReport.DischargedCodeType != null ? Convert.ToInt32(this._UnavailableToWorkReport.DischargedCodeType) : 0;
                                _analikRaporDVO.raporDurumu = "12";
                            }
                            else
                            {
                                _analikRaporDVO.baslangicTarihi = this._UnavailableToWorkReport.RestingStartDate != null ? this._UnavailableToWorkReport.RestingStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                                _analikRaporDVO.analikRaporTipi = 1;
                                _analikRaporDVO.gebelikHaftasi1 = this._UnavailableToWorkReport.GestationalOne != null ? Convert.ToInt32(this._UnavailableToWorkReport.GestationalOne) : 0;
                                _analikRaporDVO.gebelikHaftasi2 = this._UnavailableToWorkReport.GestationalTwo != null ? Convert.ToInt32(this._UnavailableToWorkReport.GestationalTwo) : 0;
                                _analikRaporDVO.gebelikTipi = this._UnavailableToWorkReport.PregnancyType != null ? Convert.ToInt32(this._UnavailableToWorkReport.PregnancyType) : 0;
                                _analikRaporDVO.raporDurumu = "10";
                            }
                            _isgoremezlikRaporDVO.meslekHastaligiRaporu = null;
                            _isgoremezlikRaporDVO.emzirmeRaporu = null;
                            _isgoremezlikRaporDVO.isKazasiRaporu = null;
                            _isgoremezlikRaporDVO.meslekHastaligiRaporu = null;
                            _isgoremezlikRaporDVO.analikRaporu = _analikRaporDVO;
                            break;
                        case 4:
                            IsGormezlikServis.EmzirmeRaporDVO _emzirmeRaporDVO = new IsGormezlikServis.EmzirmeRaporDVO();
                            _emzirmeRaporDVO.anneTcKimlikNo = this._UnavailableToWorkReport.MotherTCNo != "" ? this._UnavailableToWorkReport.MotherTCNo : "00000000000";
                            _emzirmeRaporDVO.bebekDogumTarihi = this._UnavailableToWorkReport.BabyBirthDate != null ? this._UnavailableToWorkReport.BabyBirthDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                            _emzirmeRaporDVO.canliCocukSayisi = this._UnavailableToWorkReport.LiveBirthsNumber != null ? Convert.ToInt32(this._UnavailableToWorkReport.LiveBirthsNumber) : 0;
                            _emzirmeRaporDVO.doganCocukSayisi = this._UnavailableToWorkReport.ChildrenBornNumber != null ? Convert.ToInt32(this._UnavailableToWorkReport.ChildrenBornNumber) : 0;
                            _isgoremezlikRaporDVO.meslekHastaligiRaporu = null;
                            _isgoremezlikRaporDVO.analikRaporu = null;
                            _isgoremezlikRaporDVO.isKazasiRaporu = null;
                            _isgoremezlikRaporDVO.meslekHastaligiRaporu = null;
                            _isgoremezlikRaporDVO.emzirmeRaporu = _emzirmeRaporDVO;
                            break;
                    }

                    IsGormezlikServis.CevapDTO response = IsGormezlikServis.WebMethods.raporGuncelleSync(Sites.SiteLocalHost, _isgoremezlikRaporDVO);
                    if (response != null )
                    {
                        if (response.sonucKodu.Equals(0))
                        {
                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji;
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.sonucKodu == 0 ? "İşlem Başarılı" : response.hataMesaji;
                            unavailableToWorkReport.MedulaChasingNo = response.raporTakipNo.ToString();
                            MedulaChasingNo.Text = response.raporTakipNo.ToString();
                            unavailableToWorkReport.ReportRowNumber = response.raporSiraNo.ToString();
                            ReportRowNumber.Text = response.raporSiraNo.ToString();
                            unavailableToWorkReport.WoundPosition = this._UnavailableToWorkReport.YaraTuru != null ? this._UnavailableToWorkReport.YaraTuru.CodeValueCode : "";
                            unavailableToWorkReport.WoundType = this._UnavailableToWorkReport.VucutYeri != null ? this._UnavailableToWorkReport.VucutYeri.CodeValueCode : "";
                            context.Save();
                        }
                        else
                        {

                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji;
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.hataMesaji;
                            unavailableToWorkReport.WoundPosition = this._UnavailableToWorkReport.YaraTuru != null ? this._UnavailableToWorkReport.YaraTuru.CodeValueCode : "";
                            unavailableToWorkReport.WoundType = this._UnavailableToWorkReport.VucutYeri != null ? this._UnavailableToWorkReport.VucutYeri.CodeValueCode : "";
                            context.Save();

                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
#endregion UnavailableToWorkReportForm_btnMedulaRaporGuncelle_Click
        }

        private void btnMedulaRapor2Ver_Click()
        {
#region UnavailableToWorkReportForm_btnMedulaRapor2Ver_Click
   if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                try
                {
                    string durum = ((int)this._UnavailableToWorkReport.Situation).ToString();


                    if (string.IsNullOrEmpty(this._UnavailableToWorkReport.MedulaChasingNo) || string.IsNullOrEmpty(this._UnavailableToWorkReport.ReportRowNumber))
                    {
                        InfoBox.Show("Rapor Medulaya Kayıt Edilmediğinden Dolayı Rapor 2 Ver İşlemi Gerçekleştirilemez!!!");
                        return;
                    }

                    IsGormezlikServis.CevapDTO response = IsGormezlikServis.WebMethods.rapor2VerSync(Sites.SiteLocalHost, this._UnavailableToWorkReport.MedulaChasingNo, Convert.ToInt32(this._UnavailableToWorkReport.ReportRowNumber), durum, ((int)this._UnavailableToWorkReport.EditingTourType).ToString());
                    if (response != null )
                    {
                        if (response.sonucKodu.Equals(0))
                        {
                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));

                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = "Rapor 2 Kayıt Edilmiştir";
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.hataMesaji;
                            unavailableToWorkReport.MedulaChasingNo = response.raporTakipNo.ToString();
                            MedulaChasingNo.Text = response.raporTakipNo.ToString(); ;
                            unavailableToWorkReport.ReportRowNumber = response.raporSiraNo.ToString();
                            ReportRowNumber.Text = response.raporSiraNo.ToString();
                            context.Save();

                        }
                        else
                        {
                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));

                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji;
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.hataMesaji;
                            context.Save();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
#endregion UnavailableToWorkReportForm_btnMedulaRapor2Ver_Click
        }

        private void btnMedulaRapor2Iptal_Click()
        {
#region UnavailableToWorkReportForm_btnMedulaRapor2Iptal_Click
   if (((ITTObject)this._UnavailableToWorkReport).IsNew)
            {
                InfoBox.Show("Meduladan herhangi bir işlem yapılmadan önce verileri sisteme kayıt etmelisiniz!!!");
                return;
            }
            if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                try
                {
                    if (string.IsNullOrEmpty(this._UnavailableToWorkReport.MedulaChasingNo) || string.IsNullOrEmpty(this._UnavailableToWorkReport.ReportRowNumber))
                    {
                        InfoBox.Show("Rapor Medulaya Kayıt Edilmediğinden Dolayı Rapor Silme İşlemi Gerçekleştirilemez!!!");
                        return;

                    }

                    if (this._UnavailableToWorkReport.ReportRowNumber != "2")
                    {
                        InfoBox.Show("Rapor 2 Medulaya Kayıt Edilmediğinden Dolayı Silme İşlemi Gerçekleştirilemez!!!");
                        return;
                    }

                    IsGormezlikServis.CevapDTO response = IsGormezlikServis.WebMethods.rapor2VerIptalSync(Sites.SiteLocalHost, this._UnavailableToWorkReport.MedulaChasingNo);
                    if (response != null )
                    {
                        if (response.sonucKodu.Equals(0))
                        {
                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.hataMesaji;
                            unavailableToWorkReport.ReportRowNumber = response.raporSiraNo.ToString();
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji;
                            context.Save();
                        }
                        else
                        {
                            TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                            UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));
                            this.ResultCode.Text = response.sonucKodu.ToString();
                            this.ResultExplanation.Text = response.hataMesaji;
                            unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                            unavailableToWorkReport.ResultExplanation = response.hataMesaji;
                            context.Save();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
#endregion UnavailableToWorkReportForm_btnMedulaRapor2Iptal_Click
        }

        private void ContinuedHospitalizationType_SelectedIndexChanged()
        {
#region UnavailableToWorkReportForm_ContinuedHospitalizationType_SelectedIndexChanged
   if (this.ContinuedHospitalizationType.SelectedItem != null )
            {
                if( (int)this.ContinuedHospitalizationType.SelectedItem.Value == 1)
                    DischargeDate.Required = false;
                else
                    DischargeDate.Required = true;
                
                 if( (int)this.ContinuedHospitalizationType.SelectedItem.Value == 3)
                    txtGun.Required = false;
                else
                    txtGun.Required = true;
            }
            
            if(this._UnavailableToWorkReport.Episode != null && this._UnavailableToWorkReport.Episode.PatientStatus != null && this._UnavailableToWorkReport.Episode.PatientStatus == PatientStatusEnum.Inpatient)
            {
                if(this.ContinuedHospitalizationType != null && this._UnavailableToWorkReport.ContinuedHospitalizationType != null && this._UnavailableToWorkReport.ContinuedHospitalizationType == ContinuedHospitalizationTypeEnum.NoHospitalization)
                {
                    this.ContinuedHospitalizationType.SelectedItem = null;
                    InfoBox.Show("Yatan hastalarda Yatış Devam alanı 'Yatış Yok' seçilemez !", MessageIconEnum.InformationMessage);
                    
                }
            }
            
            
            
            if(this.ContinuedHospitalizationType != null && this._UnavailableToWorkReport.ContinuedHospitalizationType != null && this._UnavailableToWorkReport.ContinuedHospitalizationType == ContinuedHospitalizationTypeEnum.NoHospitalization)
            {
                this.DischargedCodeType.SelectedItem = null;
                this.DischargedCodeType.ReadOnly = true;
            }
            else
            {
                this.DischargedCodeType.ReadOnly = false;
            }
#endregion UnavailableToWorkReportForm_ContinuedHospitalizationType_SelectedIndexChanged
        }

        private void ttCmbNuksType_SelectedIndexChanged()
        {
#region UnavailableToWorkReportForm_ttCmbNuksType_SelectedIndexChanged
   //
            //            if (((ITTComboBox)((TTVisual.TTComboBox)(ttCmbNuksType))).SelectedItem != null)
            //            {
            //                if (((ITTComboBox)((TTVisual.TTComboBox)(ttCmbNuksType))).SelectedItem.Value != null)
            //                {
            //
            //                    string result = ((ITTComboBox)((TTVisual.TTComboBox)(ttCmbNuksType))).SelectedItem.Value.ToString();
            //                    if (result == "1")
            //                    {
            //                        ttNuksDate.Visible = true;
            //                        ttIsKazasiTarihi.Visible = true;
            //                    }
            //                    else
            //                    {
            //                        ttNuksDate.Visible = false;
            //                        ttIsKazasiTarihi.Visible = false;
            //                    }
            //
            //                }
            //            }
            //
#endregion UnavailableToWorkReportForm_ttCmbNuksType_SelectedIndexChanged
        }

        private void ttTxtCanliDoganBebekSayisi_TextChanged()
        {
#region UnavailableToWorkReportForm_ttTxtCanliDoganBebekSayisi_TextChanged
   if(_UnavailableToWorkReport.ChildrenBornNumber == null || _UnavailableToWorkReport.ChildrenBornNumber == 0)
                _UnavailableToWorkReport.LiveBirthsNumber = 0;
            
            if(_UnavailableToWorkReport.PregnancyType == PregnancyTypeEnum.Singular && _UnavailableToWorkReport.LiveBirthsNumber > 1)
            {
                _UnavailableToWorkReport.LiveBirthsNumber = 1;
                //throw new TTException("Canlı çocuk sayısı doğan çocuk sayısından büyük olamaz !");
            }
            if(_UnavailableToWorkReport.LiveBirthsNumber > _UnavailableToWorkReport.ChildrenBornNumber)
            {
                throw new TTException("Canlı çocuk sayısı doğan çocuk sayısından büyük olamaz !");
            }
#endregion UnavailableToWorkReportForm_ttTxtCanliDoganBebekSayisi_TextChanged
        }

        private void ttTxtDoganCocukSayisi_TextChanged()
        {
#region UnavailableToWorkReportForm_ttTxtDoganCocukSayisi_TextChanged
   if(_UnavailableToWorkReport.ChildrenBornNumber == null || _UnavailableToWorkReport.ChildrenBornNumber == 0)
                _UnavailableToWorkReport.LiveBirthsNumber = 0;
            
            if(_UnavailableToWorkReport.PregnancyType == PregnancyTypeEnum.Singular)
            {
                _UnavailableToWorkReport.ChildrenBornNumber = 1;
                //throw new TTException("Canlı çocuk sayısı doğan çocuk sayısından büyük olamaz !");
            }
            else if(_UnavailableToWorkReport.ChildrenBornNumber < 2)
                 throw new TTException("Çoğul gebelikte doğan çocuk sayısı 2 den küçük olamaz !");
                
            
            if(_UnavailableToWorkReport.PregnancyType != PregnancyTypeEnum.Singular  &&  _UnavailableToWorkReport.LiveBirthsNumber > _UnavailableToWorkReport.ChildrenBornNumber)
            {
                throw new TTException("Canlı çocuk sayısı doğan çocuk sayısından büyük olamaz !");
            }
#endregion UnavailableToWorkReportForm_ttTxtDoganCocukSayisi_TextChanged
        }

        private void ttCmbPregnancyType_SelectedIndexChanged()
        {
#region UnavailableToWorkReportForm_ttCmbPregnancyType_SelectedIndexChanged
   if(_UnavailableToWorkReport.PregnancyType != null)
            {
                if(_UnavailableToWorkReport.PregnancyType == PregnancyTypeEnum.Singular)
                {
                    _UnavailableToWorkReport.ChildrenBornNumber = 1;
                    this.ttTxtDoganCocukSayisi.ReadOnly = true;
                    if(_UnavailableToWorkReport.LiveBirthsNumber > 1)
                        throw new TTException("Canlı çocuk sayısı doğan çocuk sayısından büyük olamaz !");
                }
                else
                {
                    _UnavailableToWorkReport.ChildrenBornNumber = 2;
                    this.ttTxtDoganCocukSayisi.ReadOnly = false;
                }
            }
            else
                this.ttTxtDoganCocukSayisi.ReadOnly = false;
#endregion UnavailableToWorkReportForm_ttCmbPregnancyType_SelectedIndexChanged
        }

        private void ttCmbMaternityReportType_SelectedIndexChanged()
        {
#region UnavailableToWorkReportForm_ttCmbMaternityReportType_SelectedIndexChanged
   if (((ITTComboBox)((TTVisual.TTComboBox)(ttCmbMaternityReportType))).SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(((ITTComboBox)((TTVisual.TTComboBox)(ttCmbMaternityReportType))).SelectedItem.Value.ToString()))
                {
                    string gelenDeger = ((ITTComboBox)((TTVisual.TTComboBox)(ttCmbMaternityReportType))).SelectedItem.Value.ToString();

                    if (gelenDeger == "2")
                    {
                        this.ttCmbBirthType.Required = true;
                        this.ttCmbPregnancyType.Required = true;
                        this.ttTxtCanliDoganBebekSayisi.Required = true;
                        this.ttTxtDoganCocukSayisi.Required = true;
                        this.ttTxtBebekDogumHaftasi.Required = true;
                        this.tttTxtAktarmaHaftasi.Required = false;
                    }
                    if (gelenDeger == "1")
                    {
                        this.ttTxtGebelikHaftasi1.Required = true;
                        this.ttTxtGebelikHaftasi2.Required = true;
                        this.ttCmbPregnancyType.Required = true;


                        this.ttTxtBebekDogumHaftasi.Required = false;
                        this.ttTxtCanliDoganBebekSayisi.Required = false;
                        this.ttTxtDoganCocukSayisi.Required = false;
                    }

                }
            }
#endregion UnavailableToWorkReportForm_ttCmbMaternityReportType_SelectedIndexChanged
        }

        private void NotWorkMother_CheckedChanged()
        {
#region UnavailableToWorkReportForm_NotWorkMother_CheckedChanged
   if (((TTVisual.TTCheckBox)(NotWorkMother)).Checked)
            {                
                FatherTCNo.Visible = true;
                labelFatherTCNo.Visible = true;
            }
            else
            {
                FatherTCNo.Visible = false;
                labelFatherTCNo.Visible = false;
            }
#endregion UnavailableToWorkReportForm_NotWorkMother_CheckedChanged
        }

        private void gridRaporlar_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region UnavailableToWorkReportForm_gridRaporlar_CellContentClick
   if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                if (gridRaporlar.Rows.Count > 0 && gridRaporlar.CurrentCell != null)
                {
                    if ((((ITTGridCell)gridRaporlar.CurrentCell).OwningColumn != null) && (((ITTGridCell)gridRaporlar.CurrentCell).OwningColumn.Name == "raporSil"))
                    {
                        ITTGridCell currentCell = gridRaporlar.CurrentCell;
                        if (currentCell != null)
                        {
                            ITTGridRow currentRow = currentCell.OwningRow;
                            if (currentRow != null)
                            {
                                if (currentRow.Cells[0].Value != null && currentRow.Cells[2].Value != null && currentRow.Cells[8].Value != null)
                                {
                                    InfoBox.Show("Seçili Rapor Meduladan Silinecektir!! ", MessageIconEnum.InformationMessage);
                                    // DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel); 
                                    //if (dialogResult == DialogResult.OK)
                                    //{
                                    try
                                    {
                                        int vakaTuru = 0;
                                        vakaTuru = Convert.ToInt32(currentRow.Cells[8].Value.ToString());
                                        IsGormezlikServis.CevapDTO response = IsGormezlikServis.WebMethods.raporSilSync(Sites.SiteLocalHost, currentRow.Cells[0].Value.ToString(), Convert.ToInt32(currentRow.Cells[2].Value.ToString()), vakaTuru, TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                        if (response != null )
                                        {
                                            if (response.sonucKodu.Equals(0))
                                            {
                                                Guid objectId = new Guid(currentRow.Cells[9].Value.ToString());
                                                TTObjectContext newContext = new TTObjectContext(false);
                                                UnavailToWorkRprtInfo unavailToWorkRprtInfo = (UnavailToWorkRprtInfo)newContext.GetObject(objectId, typeof(UnavailToWorkRprtInfo));
                                                unavailToWorkRprtInfo.ReportDeleted = true;
                                                newContext.Save();

                                                if (_UnavailableToWorkReport.MedulaChasingNo == currentRow.Cells[0].Value.ToString() && _UnavailableToWorkReport.ReportRowNumber == currentRow.Cells[2].Value.ToString())
                                                {
                                                    TTObjectContext context = _UnavailableToWorkReport.ObjectContext;
                                                    UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this._UnavailableToWorkReport.ObjectID, typeof(UnavailableToWorkReport));
                                                    this.ResultCode.Text = response.sonucKodu.ToString();
                                                    this.ResultExplanation.Text = "Rapor Bilgisi Silinmiştir";
                                                    unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                                                    unavailableToWorkReport.ResultExplanation = "Rapor Bilgisi Silinmiştir";
                                                    unavailableToWorkReport.MedulaChasingNo = "";
                                                    unavailableToWorkReport.ReportRowNumber = "";
                                                    MedulaChasingNo.Text = "";
                                                    ReportRowNumber.Text = "";
                                                    context.Save();
                                                }

                                                currentRow.Cells[0].Value = "";
                                                currentRow.Cells[1].Value = "";
                                                currentRow.Cells[2].Value = "";
                                                currentRow.Cells[3].Value = response.sonucKodu;
                                                currentRow.Cells[4].Value = response.hataMesaji;
                                                currentRow.Cells[5].Value = "";

                                                InfoBox.Show("Hastanın Raporu Silinmiştir ! ");
                                            }
                                            else
                                            {
                                                currentRow.Cells[3].Value = response.sonucKodu;
                                                currentRow.Cells[4].Value = response.hataMesaji;

                                                InfoBox.Show("Hastanın Raporu Silinememiştir !!! ");
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    // }
                                }
                                else
                                {
                                    InfoBox.Show("Rapor Medulaya Kayıt Edilmediğinden Dolayı Rapor Silme İşlemi Gerçekleştirilemez!!!");
                                    return;
                                }
                            }
                        }
                    }
                    if ((((ITTGridCell)gridRaporlar.CurrentCell).OwningColumn != null) && (((ITTGridCell)gridRaporlar.CurrentCell).OwningColumn.Name == "raporSec"))
                    {
                        ITTGridCell currentCell = gridRaporlar.CurrentCell;
                        if (currentCell != null)
                        {
                            ITTGridRow currentRow = currentCell.OwningRow;
                            if (currentRow != null)
                            {
                                if (currentRow.Cells[0].Value != null && currentRow.Cells[2].Value != null)
                                {
                                    MedulaChasingNo.Text = currentRow.Cells[0].Value.ToString();
                                    ReportRowNumber.Text = currentRow.Cells[2].Value.ToString();
                                }
                            }
                        }
                    }
                }
            }
#endregion UnavailableToWorkReportForm_gridRaporlar_CellContentClick
        }

        private void Excuse_SelectedIndexChanged()
        {
#region UnavailableToWorkReportForm_Excuse_SelectedIndexChanged
   ttNuksDate.Required = false;
            ttBabyBirthDate.Required = false;
            ttEBabyBirthDate.Required = false;
            ttTransferringDate.Required = false;
            ttCmbHastalikNuksType.Required = false;
            ttCmbHastalikNuksType.Required = false;
            lstBoxWoundPosition.Required = false;
            lstBoxWoundType.Required = false;
            lstBoxMHWoundPosition.Required = false;
            lstBoxMHWoundType.Required = false;
            ttCmbNuksType.Required = false;
            ttCmbMHNuksType.Required = false;
            ttCmbMaternityReportType.Required = false;
            this.ttCmbBirthType.Required = false;
            this.ttCmbPregnancyType.Required = false;
            this.ttTxtCanliDoganBebekSayisi.Required = false;
            this.ttTxtDoganCocukSayisi.Required = false;
            this.ttTxtGebelikHaftasi1.Required = false;
            this.ttTxtGebelikHaftasi2.Required = false;
            this.ttTxtBebekDogumHaftasi.Required = false;
            this.tttTxtAktarmaHaftasi.Required = false;

            string result = ((ITTComboBox)((TTVisual.TTComboBox)(Excuse))).SelectedItem.Value.ToString();

            // <-- Automatically generated part.
            if (!string.IsNullOrEmpty(((ITTComboBox)((TTVisual.TTComboBox)(Excuse))).SelectedItem.Value.ToString()))
            {
                tttabcontrolReportType.Visible = true;
                switch (result)
                {
                    case "0"://İş kazası
                        this.tttabcontrolReportType.ShowTabPage(tttabIsKazasi);
                        this.tttabcontrolReportType.HideTabPage(tttabMeslekHastaligi);
                        this.tttabcontrolReportType.HideTabPage(tttabHastalik);
                        this.tttabcontrolReportType.HideTabPage(tttabAnalik);
                        this.tttabcontrolReportType.HideTabPage(tttabEmzirme);
                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
                            this.Height = 760;
                        else
                            this.Height = 600;
                        ttCmbNuksType.Required = true;
                        lstBoxWoundPosition.Required = true;
                        lstBoxWoundType.Required = true;
                        break;

                    case "1":// Meslek Hastalığı
                        this.tttabcontrolReportType.HideTabPage(tttabIsKazasi);
                        this.tttabcontrolReportType.ShowTabPage(tttabMeslekHastaligi);
                        this.tttabcontrolReportType.HideTabPage(tttabHastalik);
                        this.tttabcontrolReportType.HideTabPage(tttabAnalik);
                        this.tttabcontrolReportType.HideTabPage(tttabEmzirme);
                        ttCmbMHNuksType.Required = true;
                        lstBoxMHWoundPosition.Required = true;
                        lstBoxMHWoundType.Required = true;
                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
                            this.Height = 720;
                        else
                            this.Height = 760;
                        break;

                    case "2"://Hastalık
                        ttCmbHastalikNuksType.Required = true;
                        this.tttabcontrolReportType.HideTabPage(tttabIsKazasi);
                        this.tttabcontrolReportType.HideTabPage(tttabMeslekHastaligi);
                        this.tttabcontrolReportType.ShowTabPage(tttabHastalik);
                        this.tttabcontrolReportType.HideTabPage(tttabAnalik);
                        this.tttabcontrolReportType.HideTabPage(tttabEmzirme);

                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
                            this.Height = 760;
                        else
                            this.Height = 600;
                        break;
                        //CalculateEndDate();

                    case "3"://Analık
                        this.tttabcontrolReportType.HideTabPage(tttabIsKazasi);
                        this.tttabcontrolReportType.HideTabPage(tttabMeslekHastaligi);
                        this.tttabcontrolReportType.HideTabPage(tttabHastalik);
                        this.tttabcontrolReportType.ShowTabPage(tttabAnalik);
                        this.tttabcontrolReportType.HideTabPage(tttabEmzirme);
                        btnRaporBilgisiGetir.Visible = true;
                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
                            this.Height = 760;
                        else
                            this.Height = 600;
                        break;

                    case "4"://Emzirme
                        this.tttabcontrolReportType.HideTabPage(tttabIsKazasi);
                        this.tttabcontrolReportType.HideTabPage(tttabMeslekHastaligi);
                        this.tttabcontrolReportType.HideTabPage(tttabHastalik);
                        this.tttabcontrolReportType.HideTabPage(tttabAnalik);
                        this.tttabcontrolReportType.ShowTabPage(tttabEmzirme);
                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
                            this.Height = 760;
                        else
                            this.Height = 600;
                        this.ttEBabyBirthDate.Required = true;
                        break;
                }
            }
            else
                tttabcontrolReportType.Visible = false;

            if (result == "3")
            {
                SituationDate.ControlValue = null;
                SituationDate.Required = false;
                ResEndDate.ControlValue = null;
                ResEndDate.Required = false;
                txtGun.Required = false;
            }
            else
            {
                SituationDate.Required = true;
                ResEndDate.Required = true;
                txtGun.Required = true;
            }
#endregion UnavailableToWorkReportForm_Excuse_SelectedIndexChanged
        }

        private void ResStartDate_ValueChanged()
        {
#region UnavailableToWorkReportForm_ResStartDate_ValueChanged
   AbsenceStartDate.ControlValue = ResStartDate.ControlValue;
            if (_UnavailableToWorkReport.RestingStartDate != null)
                _UnavailableToWorkReport.DischargeDate = ((DateTime)_UnavailableToWorkReport.RestingStartDate).AddDays(-1);

            CalculateEndDate();
#endregion UnavailableToWorkReportForm_ResStartDate_ValueChanged
        }

        private void ResEndDate_ValueChanged()
        {
#region UnavailableToWorkReportForm_ResEndDate_ValueChanged
   AbsenceEndDate.ControlValue = ResEndDate.ControlValue;
#endregion UnavailableToWorkReportForm_ResEndDate_ValueChanged
        }

        private void DischargeDate_ValueChanged()
        {
#region UnavailableToWorkReportForm_DischargeDate_ValueChanged
   if (_UnavailableToWorkReport.DischargeDate != null)
                _UnavailableToWorkReport.RestingStartDate = ((DateTime)_UnavailableToWorkReport.DischargeDate).AddDays(1);
#endregion UnavailableToWorkReportForm_DischargeDate_ValueChanged
        }

        protected override void PreScript()
        {
#region UnavailableToWorkReportForm_PreScript
    base.PreScript();
            
            this._UnavailableToWorkReport.CheckForDiagnosis();
            
            this.SetProcedureDoctorAsCurrentResource();
            if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                tttabcontrolReportType.Visible = true;
                this.tttabcontrolReportType.HideTabPage(tttabIsKazasi);
                this.tttabcontrolReportType.HideTabPage(tttabMeslekHastaligi);
                this.tttabcontrolReportType.ShowTabPage(tttabHastalik);
                this.tttabcontrolReportType.HideTabPage(tttabAnalik);
                this.tttabcontrolReportType.HideTabPage(tttabEmzirme);
                pnlMedulaSonuc.Visible = true;
                pnlMedulaGonderim.Visible = true;
            }
            else
            {
                tttabcontrolReportType.Visible = false;
                this.tttabcontrolReportType.HideTabPage(tttabHastalik);
                pnlMedulaSonuc.Visible = false;
                pnlMedulaGonderim.Visible = false;
            }




            if (this._UnavailableToWorkReport.FirstOrSecondTenDays != null)
                this.FirstOrSecondTenDays.SelectedIndex = int.Parse(this._UnavailableToWorkReport.FirstOrSecondTenDays);
            if (this._UnavailableToWorkReport.Excuse != null)
                this.Excuse.SelectedIndex = int.Parse(this._UnavailableToWorkReport.Excuse);

            //if (this._UnavailableToWorkReport.Episode.PatientExaminations.Count > 0 || this._UnavailableToWorkReport.Episode.EmergencyInterventions.Count > 0 || this._UnavailableToWorkReport.Episode.DentalExaminations.Count > 0)
            if (this._UnavailableToWorkReport.Episode.PatientExaminations.Count > 0 || this._UnavailableToWorkReport.Episode.EmergencyInterventions.Count > 0)
            {
                foreach (PatientExamination pe in this._UnavailableToWorkReport.Episode.PatientExaminations)
                {
                    if (pe.CurrentStateDefID != PatientExamination.States.Cancelled)
                    {
                        this.PoliclinicSequenceNo.Text = pe.ProtocolNo.ToString();
                        //
                        //                    if (this._UnavailableToWorkReport.FirstOrSecondTenDays != null)
                        //                        this.FirstOrSecondTenDays.SelectedIndex = int.Parse(this._UnavailableToWorkReport.FirstOrSecondTenDays);
                        //                    if (this._UnavailableToWorkReport.Excuse != null)
                        //                        this.Excuse.SelectedIndex = int.Parse(this._UnavailableToWorkReport.Excuse);

                        if (this._UnavailableToWorkReport.RestingStartDate == null)
                            this._UnavailableToWorkReport.RestingStartDate = pe.ProcessDate;
                        if (this._UnavailableToWorkReport.AbsenceStartDate == null)
                            this._UnavailableToWorkReport.AbsenceStartDate = pe.ProcessDate;
                        /*   if (this._UnavailableToWorkReport.Situation != null)
                           ((TTEnumComboBox)this.Situation).SelectedValue = int.Parse(this._UnavailableToWorkReport.Situation);
                       if (this._UnavailableToWorkReport.EditingTourType != null)
                           ((TTEnumComboBox)this.EditingTourType).SelectedValue = int.Parse(this._UnavailableToWorkReport.EditingTourType)-1;
                       if (this._UnavailableToWorkReport.DeathType != null)
                           ((TTEnumComboBox)this.DeathType).SelectedValue = int.Parse(this._UnavailableToWorkReport.DeathType)-1;
                       if (this._UnavailableToWorkReport.CarryCase  != null)
                           ((TTEnumComboBox) this.ttCmbCarryCaseType).SelectedValue = int.Parse(this._UnavailableToWorkReport.CarryCase );
                       if (this._UnavailableToWorkReport.ContinuedHospitalizationType != null)
                           ((TTEnumComboBox) this.ContinuedHospitalizationType).SelectedValue = int.Parse(this._UnavailableToWorkReport.ContinuedHospitalizationType)-1;
                       if (this._UnavailableToWorkReport.NuksType != null)
                       {
                        
                           if (this._UnavailableToWorkReport.Excuse != null)
                           {
                               switch (Convert.ToInt32(this._UnavailableToWorkReport.Excuse))
                               {
                                   case 0:
                                       ((TTEnumComboBox) this.ttCmbNuksType).SelectedValue = int.Parse(this._UnavailableToWorkReport.NuksType);
                                    
                                       break;
                                   case 1:
                                       ((TTEnumComboBox)this.ttCmbMHNuksType).SelectedValue = int.Parse(this._UnavailableToWorkReport.NuksType);
                                       break;
                                   case 2:
                                       ((TTEnumComboBox)this.ttCmbHastalikNuksType).SelectedValue = int.Parse(this._UnavailableToWorkReport.NuksType);
                                       break;
                                    
                               }
                           }
                       }
                    
                       if (this._UnavailableToWorkReport.BirthType != null)
                           ((TTEnumComboBox)this.ttCmbBirthType).SelectedValue = int.Parse(this._UnavailableToWorkReport.BirthType);
                       if (this._UnavailableToWorkReport.MaternityReportType != null)
                           ((TTEnumComboBox)this.ttCmbMaternityReportType).SelectedValue = int.Parse(this._UnavailableToWorkReport.MaternityReportType);
                       if (this._UnavailableToWorkReport.PregnancyType != null)
                           ((TTEnumComboBox)this.ttCmbPregnancyType).SelectedValue = int.Parse(this._UnavailableToWorkReport.PregnancyType);
                      
                       if (this._UnavailableToWorkReport.DischargedCodeType != null)
                           ((TTEnumComboBox)this.DischargedCodeType).SelectedValue = int.Parse(this._UnavailableToWorkReport.DischargedCodeType);
                         */

                    }
                }

                foreach (EmergencyIntervention ei in this._UnavailableToWorkReport.Episode.EmergencyInterventions)
                {
                    if (ei.CurrentStateDefID != EmergencyIntervention.States.Cancelled)
                    {
                        this.PoliclinicSequenceNo.Text = ei.ProtocolNo.ToString();

                        if (this._UnavailableToWorkReport.RestingStartDate == null)
                            this._UnavailableToWorkReport.RestingStartDate = ei.RequestDate;
                        if (this._UnavailableToWorkReport.AbsenceStartDate == null)
                            this._UnavailableToWorkReport.AbsenceStartDate = ei.RequestDate;
                    }
                }

                //foreach (DentalExamination de in this._UnavailableToWorkReport.Episode.DentalExaminations)
                //{
                //    if (de.CurrentStateDefID != DentalExamination.States.Cancelled)
                //    {
                //        this.PoliclinicSequenceNo.Text = de.ProtocolNo.ToString();

                //        if (this._UnavailableToWorkReport.RestingStartDate == null)
                //            this._UnavailableToWorkReport.RestingStartDate = de.ProcessTime;
                //        if (this._UnavailableToWorkReport.AbsenceStartDate == null)
                //            this._UnavailableToWorkReport.AbsenceStartDate = de.ProcessTime;
                //    }
                //}


                if (this._UnavailableToWorkReport.CurrentStateDefID == UnavailableToWorkReport.States.Completed)
                {
                    btnRaporOnSecim.Enabled = false;
                    btnMedulaKaydet.Enabled = false;
                    btnMedulaRaporGuncelle.Enabled = false;
                    btnMedulaRapor2Ver.Enabled = false;
                    btnRaporBilgisiGetir.Enabled = false;
                    btnMdedulaSil.Enabled = false;
                    btnMedulaRapor2Iptal.Enabled = false;
                    btnMedulaSaglikKurulunaSevket.Enabled = false;
                    btnMedulaSaglikKurulunaSevketIptal.Enabled = false;
                }
            }
            if (_UnavailableToWorkReport.ProtocolDate == null)
                _UnavailableToWorkReport.ProtocolDate = _UnavailableToWorkReport.SubEpisode.PatientAdmission.ActionDate != null ? _UnavailableToWorkReport.SubEpisode.PatientAdmission.ActionDate : null;
            if (this._UnavailableToWorkReport.SubEpisode.InpatientAdmission != null && this._UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate != null)
            {
                _UnavailableToWorkReport.DischargeDate = this._UnavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalDischargeDate;
            }

            if (_UnavailableToWorkReport.DischargeDate != null)
                _UnavailableToWorkReport.RestingStartDate = ((DateTime)_UnavailableToWorkReport.DischargeDate).AddDays(1);




            if (Common.CurrentUser.Status == UserStatusEnum.SuperUser)
            {
                foreach (ITTGridRow row in gridRaporlar.Rows)
                {
                    this.gridRaporlar.Rows[row.Index].Cells[raporTakipNo.Name].ReadOnly = false;
                    this.gridRaporlar.Rows[row.Index].Cells[raporNo.Name].ReadOnly = false;
                    this.gridRaporlar.Rows[row.Index].Cells[raporSiraNo.Name].ReadOnly = false;
                    this.gridRaporlar.Rows[row.Index].Cells[raporBaslangicTarihi.Name].ReadOnly = false;
                }
            }
            else
            {
                foreach (ITTGridRow row in gridRaporlar.Rows)
                {
                    this.gridRaporlar.Rows[row.Index].Cells[raporTakipNo.Name].ReadOnly = true;
                    this.gridRaporlar.Rows[row.Index].Cells[raporNo.Name].ReadOnly = true;
                    this.gridRaporlar.Rows[row.Index].Cells[raporSiraNo.Name].ReadOnly = true;
                    this.gridRaporlar.Rows[row.Index].Cells[raporBaslangicTarihi.Name].ReadOnly = true;
                }
            }
#endregion UnavailableToWorkReportForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region UnavailableToWorkReportForm_PostScript
    base.PostScript(transDef);
#endregion UnavailableToWorkReportForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region UnavailableToWorkReportForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if (string.IsNullOrEmpty(_UnavailableToWorkReport.MedulaChasingNo))
            {
                string result = "";
                result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İş Göremezlik İstek", "Raporu SGK ya bildirmediniz. Devam Etmek İstiyor musunuz?");
                if ("H".Equals(result))
                {
                    throw new Exception("İşlemden Vazgeçildi.");
                }
            }
#endregion UnavailableToWorkReportForm_ClientSidePostScript

        }

#region UnavailableToWorkReportForm_Methods
        public override void SetProcedureDoctorAsCurrentResource()
        {
            if (Common.CurrentUser.IsSuperUser != true)
            {
                if (Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist)
                {
                    if (this._UnavailableToWorkReport.DoctorsGrid.Count == 0)
                    {
                        DoctorGrid drGrid = new DoctorGrid(this._UnavailableToWorkReport.ObjectContext);
               
                        drGrid.ResUser = Common.CurrentResource;
                        this._UnavailableToWorkReport.DoctorsGrid.Add(drGrid); 
                        
                        this._UnavailableToWorkReport.ProcedureDoctor =Common.CurrentResource;
                        
                                             
                                              
                         
                    }
                }
            }

            if (((ITTObject)this._UnavailableToWorkReport).HasErrors == true)
                throw new Exception(((ITTObject)this._UnavailableToWorkReport).GetErrors());
        }
        public void IsgoremezlikTipineGoreFormuSekillendir(string raporTipi)
        {
            ttNuksDate.Required = false;
            ttBabyBirthDate.Required = false;
            ttEBabyBirthDate.Required = false;
            ttTransferringDate.Required = false;
            ttCmbHastalikNuksType.Required = false;
            ttCmbHastalikNuksType.Required = false;
            lstBoxWoundPosition.Required = false;
            lstBoxWoundType.Required = false;
            lstBoxMHWoundPosition.Required = false;
            lstBoxMHWoundType.Required = false;
            ttCmbNuksType.Required = false;
            ttCmbMHNuksType.Required = false;
            ttCmbMaternityReportType.Required = false;
            this.ttCmbBirthType.Required = false;
            this.ttCmbPregnancyType.Required = false;
            this.ttTxtCanliDoganBebekSayisi.Required = false;
            this.ttTxtDoganCocukSayisi.Required = false;
            this.ttTxtGebelikHaftasi1.Required = false;
            this.ttTxtGebelikHaftasi2.Required = false;
            this.ttTxtBebekDogumHaftasi.Required = false;
            this.tttTxtAktarmaHaftasi.Required = false;
            // <-- Automatically generated part.
            if (!string.IsNullOrEmpty(raporTipi))
            {
                tttabcontrolReportType.Visible = true;

                switch (raporTipi)
                {
                    case "1"://İş kazası
                        this.tttabcontrolReportType.ShowTabPage(tttabIsKazasi);
                        this.tttabcontrolReportType.HideTabPage(tttabMeslekHastaligi);
                        this.tttabcontrolReportType.HideTabPage(tttabHastalik);
                        this.tttabcontrolReportType.HideTabPage(tttabAnalik);
                        this.tttabcontrolReportType.HideTabPage(tttabEmzirme);
                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
                            this.Height = 760;
                        else
                            this.Height = 600;

                        ttCmbNuksType.Required = true;
                        lstBoxWoundPosition.Required = true;
                        lstBoxWoundType.Required = true;
                        break;

                    case "2":// Meslek Hastalığı
                        this.tttabcontrolReportType.HideTabPage(tttabIsKazasi);
                        this.tttabcontrolReportType.ShowTabPage(tttabMeslekHastaligi);
                        this.tttabcontrolReportType.HideTabPage(tttabHastalik);
                        this.tttabcontrolReportType.HideTabPage(tttabAnalik);
                        this.tttabcontrolReportType.HideTabPage(tttabEmzirme);
                        ttCmbMHNuksType.Required = true;
                        lstBoxMHWoundPosition.Required = true;
                        lstBoxMHWoundType.Required = true;
                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
                            this.Height = 720;
                        else
                            this.Height = 760;
                        break;

                    case "3"://Hastalık
                        ttCmbHastalikNuksType.Required = true;
                        this.tttabcontrolReportType.HideTabPage(tttabIsKazasi);
                        this.tttabcontrolReportType.HideTabPage(tttabMeslekHastaligi);
                        this.tttabcontrolReportType.ShowTabPage(tttabHastalik);
                        this.tttabcontrolReportType.HideTabPage(tttabAnalik);
                        this.tttabcontrolReportType.HideTabPage(tttabEmzirme);

                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
                            this.Height = 760;
                        else
                            this.Height = 600;
                        break;

                    case "4"://Analık
                        this.tttabcontrolReportType.HideTabPage(tttabIsKazasi);
                        this.tttabcontrolReportType.HideTabPage(tttabMeslekHastaligi);
                        this.tttabcontrolReportType.HideTabPage(tttabHastalik);
                        this.tttabcontrolReportType.ShowTabPage(tttabAnalik);
                        this.tttabcontrolReportType.HideTabPage(tttabEmzirme);
                        btnRaporBilgisiGetir.Visible = true;
                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
                            this.Height = 760;
                        else
                            this.Height = 600;
                        break;

                    case "5"://Emzirme
                        this.tttabcontrolReportType.HideTabPage(tttabIsKazasi);
                        this.tttabcontrolReportType.HideTabPage(tttabMeslekHastaligi);
                        this.tttabcontrolReportType.HideTabPage(tttabHastalik);
                        this.tttabcontrolReportType.HideTabPage(tttabAnalik);
                        this.tttabcontrolReportType.ShowTabPage(tttabEmzirme);
                        if (this._UnavailableToWorkReport.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._UnavailableToWorkReport.SubEpisode.SGKSEP.MedulaTakipNo))
                            this.Height = 760;
                        else
                            this.Height = 600;
                        this.ttEBabyBirthDate.Required = true;
                        break;
                }
            }
            else
                tttabcontrolReportType.Visible = false;
        }



        public void CalculateEndDate()
        {
            if (((ITTComboBox)((TTVisual.TTComboBox)(Excuse))).SelectedItem == null)
                return;

            string result = ((ITTComboBox)((TTVisual.TTComboBox)(Excuse))).SelectedItem.Value.ToString();
            if (result == "3")
                return;

            if (_UnavailableToWorkReport.RestingStartDate == null || _UnavailableToWorkReport.DayCount == null)
                return;

            _UnavailableToWorkReport.RestingEndDate = ((DateTime)_UnavailableToWorkReport.RestingStartDate).AddDays(Convert.ToDouble(_UnavailableToWorkReport.DayCount - 1));
            _UnavailableToWorkReport.SituationDate = ((DateTime)_UnavailableToWorkReport.RestingEndDate).AddDays(1);
        }
        
#endregion UnavailableToWorkReportForm_Methods
    }
}