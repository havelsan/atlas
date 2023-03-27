
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
    /// Medula Rapor İşlemleri
    /// </summary>
    public partial class MedulaRaporIslemleri : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            gridFtrRaporlari.CellContentClick += new TTGridCellEventDelegate(gridFtrRaporlari_CellContentClick);
            gridEswlRaporlari.CellContentClick += new TTGridCellEventDelegate(gridEswlRaporlari_CellContentClick);
            gridDiyalizRaporlari.CellContentClick += new TTGridCellEventDelegate(gridDiyalizRaporlari_CellContentClick);
            gridEvHemodiyalizRaporlari.CellContentClick += new TTGridCellEventDelegate(gridEvHemodiyalizRaporlari_CellContentClick);
            gridTupBebekRaporlari.CellContentClick += new TTGridCellEventDelegate(gridTupBebekRaporlari_CellContentClick);
            gridHOTRaporlari.CellContentClick += new TTGridCellEventDelegate(gridHOTRaporlari_CellContentClick);
            btnFtrIstek.Click += new TTControlEventDelegate(btnFtrIstek_Click);
            gridFizyoTerapiIslemleri.CellContentClick += new TTGridCellEventDelegate(gridFizyoTerapiIslemleri_CellContentClick);
            gridFizyoTerapiIslemleri.CellValueChanged += new TTGridCellEventDelegate(gridFizyoTerapiIslemleri_CellValueChanged);
            gridTani.CellValueChanged += new TTGridCellEventDelegate(gridTani_CellValueChanged);
            btnRaporKaydet.Click += new TTControlEventDelegate(btnRaporKaydet_Click);
            btnSearchTCKNo.Click += new TTControlEventDelegate(btnSearchTCKNo_Click);
            btnSearchChasing.Click += new TTControlEventDelegate(btnSearchChasing_Click);
            btnSearchReportInfo.Click += new TTControlEventDelegate(btnSearchReportInfo_Click);
            chkFtrHeyetRaporu.CheckedChanged += new TTControlEventDelegate(chkFtrHeyetRaporu_CheckedChanged);
            btnRaporArama.Click += new TTControlEventDelegate(btnRaporArama_Click);
            cmbRaporTuru.SelectedIndexChanged += new TTControlEventDelegate(cmbRaporTuru_SelectedIndexChanged);
            gridHastaAktifTakipleri.SelectionChanged += new TTControlEventDelegate(gridHastaAktifTakipleri_SelectionChanged);
            chkRaporKaydet.CheckedChanged += new TTControlEventDelegate(chkRaporKaydet_CheckedChanged);
            chkSearchReportInfo.CheckedChanged += new TTControlEventDelegate(chkSearchReportInfo_CheckedChanged);
            chkSearchChasing.CheckedChanged += new TTControlEventDelegate(chkSearchChasing_CheckedChanged);
            chkSearchTCKNo.CheckedChanged += new TTControlEventDelegate(chkSearchTCKNo_CheckedChanged);
            cmdSearchPatient.Click += new TTControlEventDelegate(cmdSearchPatient_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            gridFtrRaporlari.CellContentClick -= new TTGridCellEventDelegate(gridFtrRaporlari_CellContentClick);
            gridEswlRaporlari.CellContentClick -= new TTGridCellEventDelegate(gridEswlRaporlari_CellContentClick);
            gridDiyalizRaporlari.CellContentClick -= new TTGridCellEventDelegate(gridDiyalizRaporlari_CellContentClick);
            gridEvHemodiyalizRaporlari.CellContentClick -= new TTGridCellEventDelegate(gridEvHemodiyalizRaporlari_CellContentClick);
            gridTupBebekRaporlari.CellContentClick -= new TTGridCellEventDelegate(gridTupBebekRaporlari_CellContentClick);
            gridHOTRaporlari.CellContentClick -= new TTGridCellEventDelegate(gridHOTRaporlari_CellContentClick);
            btnFtrIstek.Click -= new TTControlEventDelegate(btnFtrIstek_Click);
            gridFizyoTerapiIslemleri.CellContentClick -= new TTGridCellEventDelegate(gridFizyoTerapiIslemleri_CellContentClick);
            gridFizyoTerapiIslemleri.CellValueChanged -= new TTGridCellEventDelegate(gridFizyoTerapiIslemleri_CellValueChanged);
            gridTani.CellValueChanged -= new TTGridCellEventDelegate(gridTani_CellValueChanged);
            btnRaporKaydet.Click -= new TTControlEventDelegate(btnRaporKaydet_Click);
            btnSearchTCKNo.Click -= new TTControlEventDelegate(btnSearchTCKNo_Click);
            btnSearchChasing.Click -= new TTControlEventDelegate(btnSearchChasing_Click);
            btnSearchReportInfo.Click -= new TTControlEventDelegate(btnSearchReportInfo_Click);
            chkFtrHeyetRaporu.CheckedChanged -= new TTControlEventDelegate(chkFtrHeyetRaporu_CheckedChanged);
            btnRaporArama.Click -= new TTControlEventDelegate(btnRaporArama_Click);
            cmbRaporTuru.SelectedIndexChanged -= new TTControlEventDelegate(cmbRaporTuru_SelectedIndexChanged);
            gridHastaAktifTakipleri.SelectionChanged -= new TTControlEventDelegate(gridHastaAktifTakipleri_SelectionChanged);
            chkRaporKaydet.CheckedChanged -= new TTControlEventDelegate(chkRaporKaydet_CheckedChanged);
            chkSearchReportInfo.CheckedChanged -= new TTControlEventDelegate(chkSearchReportInfo_CheckedChanged);
            chkSearchChasing.CheckedChanged -= new TTControlEventDelegate(chkSearchChasing_CheckedChanged);
            chkSearchTCKNo.CheckedChanged -= new TTControlEventDelegate(chkSearchTCKNo_CheckedChanged);
            cmdSearchPatient.Click -= new TTControlEventDelegate(cmdSearchPatient_Click);
            base.UnBindControlEvents();
        }

        private void gridFtrRaporlari_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaRaporIslemleri_gridFtrRaporlari_CellContentClick
   if (gridFtrRaporlari.Rows.Count > 0 && gridFtrRaporlari.CurrentCell != null)
            {
                if ((((ITTGridCell)gridFtrRaporlari.CurrentCell).OwningColumn != null) && (((ITTGridCell)gridFtrRaporlari.CurrentCell).OwningColumn.Name == "raporSil"))
                {
                    ITTGridCell currentCell = gridFtrRaporlari.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            if (currentRow.Cells[0].Value != null && currentRow.Cells[1].Value != null && currentRow.Cells[2].Value != null && currentRow.Cells[5].Value != null)
                            {   
//                                IList physiotherapyReportList=PhysiotherapyRequest.GetPhysiotherapyReport(currentRow.Cells[1].Value.ToString());
//                                bool physioteraphyContol = false;
//                                foreach (PhysiotherapyRequest.GetPhysiotherapyReport_Class item in physiotherapyReportList)
//                                {
//                                    if (item.CurrentStateDefID != PhysiotherapyRequest.States.Cancelled)
//                                        physioteraphyContol = true;
//                                }
//
//                                if (physiotherapyReportList.Count == 0 || physioteraphyContol ==false)
//                                {
                                    InfoBox.Show("Seçili Rapor Meduladan Silinecektir!! ",MessageIconEnum.InformationMessage);
                                   // DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                    //if (dialogResult == DialogResult.OK)
                                    //{
                                        try
                                        {
                                            RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
                                            raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                                            RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
                                            _raporOkuDVO.no = currentRow.Cells[1].Value.ToString();
                                            _raporOkuDVO.raporSiraNo = currentRow.Cells[2].Value.ToString();
                                            _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                            _raporOkuDVO.tarih = currentRow.Cells[5].Value.ToString();
                                            _raporOkuDVO.turu = "1";
                                            raporSorguDVO.raporBilgisi = _raporOkuDVO;

                                            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
                                            if (response != null)
                                            {                                                
                                                    if (response.sonucKodu.Equals(0))
                                                    {
                                                        currentRow.Cells[0].Value = "";
                                                        currentRow.Cells[1].Value = "";
                                                        currentRow.Cells[2].Value = "";
                                                        currentRow.Cells[3].Value = "";
                                                        currentRow.Cells[4].Value = "";
                                                        currentRow.Cells[5].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                                                        {
                                                            InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                                                            return;
                                                        }
                                                    }                                                
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                    //}
                              // }
//                                else
//                                {
//                                    InfoBox.Show("Bu Raporun Fizyoterapi Hizmeti Var Silemezsiniz!!!");
//                                    return;
//                                }
                            }
                            else
                            {
                                InfoBox.Show("Medulaya Kaydı Yapılmamış Bir Fizik Tedavi Raporunu Meduladan Silemezsiniz!!!");
                            }
                        }
                    }
                }
            }
#endregion MedulaRaporIslemleri_gridFtrRaporlari_CellContentClick
        }

        private void gridEswlRaporlari_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaRaporIslemleri_gridEswlRaporlari_CellContentClick
   if (gridEswlRaporlari.Rows.Count > 0 && gridEswlRaporlari.CurrentCell != null)
            {
                if ((((ITTGridCell)gridEswlRaporlari.CurrentCell).OwningColumn != null) && (((ITTGridCell)gridEswlRaporlari.CurrentCell).OwningColumn.Name == "raporSilEswl"))
                {
                    ITTGridCell currentCell = gridEswlRaporlari.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            if (currentRow.Cells[0].Value != null && currentRow.Cells[1].Value  != null  && currentRow.Cells[2].Value != null  && currentRow.Cells[3].Value != null )
                            {
//                                IList stoneBreakUpList = StoneBreakUpRequest.GetStoneBreakUpQuery(currentRow.Cells[1].Value.ToString());
//                                bool stoneBreakUpControl = false;
//                                foreach (StoneBreakUpRequest.GetStoneBreakUpQuery_Class item in stoneBreakUpList)
//                                {
//                                    if (item.CurrentStateDefID != StoneBreakUpRequest.States.Cancelled)
//                                        stoneBreakUpControl = true;
//                                }
//
//                                if (stoneBreakUpList.Count == 0 || stoneBreakUpControl == false)
//                                {
                                    InfoBox.Show("Seçili Rapor Meduladan Silinecektir!! ",MessageIconEnum.InformationMessage);
                                    //DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                    //if (dialogResult == DialogResult.OK)
                                    //{
                                        try
                                        {
                                            RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
                                            raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                                            RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
                                            _raporOkuDVO.no = currentRow.Cells[1].Value.ToString();
                                            _raporOkuDVO.raporSiraNo = currentRow.Cells[2].Value.ToString();
                                            _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                            _raporOkuDVO.tarih = currentRow.Cells[3].Value.ToString();
                                            _raporOkuDVO.turu = "1";
                                            raporSorguDVO.raporBilgisi = _raporOkuDVO;

                                            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
                                            if (response != null)
                                            {
                                                    if (response.sonucKodu.Equals(0))
                                                    {
                                                        currentRow.Cells[0].Value = "";
                                                        currentRow.Cells[1].Value = "";
                                                        currentRow.Cells[2].Value = "";
                                                        currentRow.Cells[3].Value = "";
                                                        currentRow.Cells[4].Value = "";
                                                        currentRow.Cells[5].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                                                        {
                                                            InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                                                            return;
                                                        }
                                                    }                                                
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                    //}
//                                }
//                                else
//                                {
//                                    InfoBox.Show("Bu Raporun Taş Kırma Hizmeti Var, Silemezsiniz!!!");
//                                    return;
//                                }
                            }
                            else
                            {
                                InfoBox.Show("Medulaya Kaydı Yapılmamış Bir Taş Kırma Raporunu Meduladan Silemezsiniz!!!");
                            }
                        }
                    }
                }
            }
#endregion MedulaRaporIslemleri_gridEswlRaporlari_CellContentClick
        }

        private void gridDiyalizRaporlari_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaRaporIslemleri_gridDiyalizRaporlari_CellContentClick
   if (gridDiyalizRaporlari.Rows.Count > 0 && gridDiyalizRaporlari.CurrentCell != null)
            {
                if ((((ITTGridCell)gridDiyalizRaporlari.CurrentCell).OwningColumn != null) && (((ITTGridCell)gridDiyalizRaporlari.CurrentCell).OwningColumn.Name == "raporSilDiyaliz"))
                {
                    ITTGridCell currentCell = gridDiyalizRaporlari.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            if (currentRow.Cells[0].Value != null && currentRow.Cells[1].Value  != null  && currentRow.Cells[2].Value != null  && currentRow.Cells[3].Value != null )
                            {
//                                IList dialysisList =DialysisRequest.GetDialysisRequestQuery(currentRow.Cells[1].Value.ToString());
//                                bool dialysisControl = false;
//                                foreach (DialysisRequest.GetDialysisRequestQuery_Class item in dialysisList)
//                                {
//                                    if (item.CurrentStateDefID != DialysisRequest.States.Cancelled)
//                                        dialysisControl = true;
//                                }
//
//                                if (dialysisList.Count == 0 || dialysisControl == false)
//                                {
                                    InfoBox.Show("Seçili Rapor Meduladan Silinecektir!! ",MessageIconEnum.InformationMessage);
                                    //DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                    //if (dialogResult == DialogResult.OK)
                                   // {
                                        try
                                        {
                                            RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
                                            raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                                            RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
                                            _raporOkuDVO.no = currentRow.Cells[1].Value.ToString();
                                            _raporOkuDVO.raporSiraNo = currentRow.Cells[2].Value.ToString();
                                            _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                            _raporOkuDVO.tarih = currentRow.Cells[3].Value.ToString();
                                            _raporOkuDVO.turu = "1";
                                            raporSorguDVO.raporBilgisi = _raporOkuDVO;

                                            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
                                            if (response != null)
                                            {                                                
                                                    if (response.sonucKodu.Equals(0))
                                                    {
                                                        currentRow.Cells[0].Value = "";
                                                        currentRow.Cells[1].Value = "";
                                                        currentRow.Cells[2].Value = "";
                                                        currentRow.Cells[3].Value = "";
                                                        currentRow.Cells[4].Value = "";
                                                        currentRow.Cells[5].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                                                        {
                                                            InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                                                            return;
                                                        }
                                                    }                                                
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                   // }
//                                }
//                               else
//                                {
//                                    InfoBox.Show("Bu Raporun Diyaliz Hizmeti Var, Silemezsiniz!!!");
//                                    return;
//                                }
                            }
                            else
                            {
                                InfoBox.Show("Medulaya Kaydı Yapılmamış Bir Diyaliz Raporunu Meduladan Silemezsiniz!!!");
                            }
                        }
                    }
                }
            }
#endregion MedulaRaporIslemleri_gridDiyalizRaporlari_CellContentClick
        }

        private void gridEvHemodiyalizRaporlari_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaRaporIslemleri_gridEvHemodiyalizRaporlari_CellContentClick
   if (gridEvHemodiyalizRaporlari.Rows.Count > 0 && gridEvHemodiyalizRaporlari.CurrentCell != null)
            {
                if ((((ITTGridCell)gridEvHemodiyalizRaporlari.CurrentCell).OwningColumn != null) && (((ITTGridCell)gridEvHemodiyalizRaporlari.CurrentCell).OwningColumn.Name == "raporSilEvHemodiyaliz"))
                {
                    ITTGridCell currentCell = gridEvHemodiyalizRaporlari.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            if (currentRow.Cells[0].Value != null && currentRow.Cells[1].Value  != null  && currentRow.Cells[2].Value != null  && currentRow.Cells[3].Value != null )
                            {
//                                IList dialysisList =DialysisRequest.GetDialysisRequestQuery(currentRow.Cells[1].Value.ToString());
//                                bool dialysisControl = false;
//                                foreach (DialysisRequest.GetDialysisRequestQuery_Class item in dialysisList)
//                                {
//                                    if (item.CurrentStateDefID != DialysisRequest.States.Cancelled)
//                                        dialysisControl = true;
//                                }
//
//                                if (dialysisList.Count == 0 || dialysisControl == false)
//                                {
                                    InfoBox.Show("Seçili Rapor Meduladan Silinecektir!! ",MessageIconEnum.InformationMessage);                                    
                                   // DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                   // if (dialogResult == DialogResult.OK)
                                  //  {
                                        try
                                        {
                                            RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
                                            raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                                            RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
                                            _raporOkuDVO.no = currentRow.Cells[1].Value.ToString();
                                            _raporOkuDVO.raporSiraNo = currentRow.Cells[2].Value.ToString();
                                            _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                            _raporOkuDVO.tarih = currentRow.Cells[3].Value.ToString();
                                            _raporOkuDVO.turu = "1";
                                            raporSorguDVO.raporBilgisi = _raporOkuDVO;

                                            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
                                            if (response != null)
                                            {
                                                   if (response.sonucKodu.Equals(0))
                                                    {
                                                        currentRow.Cells[0].Value = "";
                                                        currentRow.Cells[1].Value = "";
                                                        currentRow.Cells[2].Value = "";
                                                        currentRow.Cells[3].Value = "";
                                                        currentRow.Cells[4].Value = "";
                                                        currentRow.Cells[5].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                                                        {
                                                            InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                                                            return;
                                                        }
                                                    }                                                
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                    //}
//                                }
//                               else
//                                {
//                                    InfoBox.Show("Bu Raporun Diyaliz Hizmeti Var, Silemezsiniz!!!");
//                                    return;
//                                }
                            }
                            else
                            {
                                InfoBox.Show("Medulaya Kaydı Yapılmamış Bir Ev Hemodiyaliz Raporunu Meduladan Silemezsiniz!!!");
                            }
                        }
                    }
                }
            }
#endregion MedulaRaporIslemleri_gridEvHemodiyalizRaporlari_CellContentClick
        }

        private void gridTupBebekRaporlari_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaRaporIslemleri_gridTupBebekRaporlari_CellContentClick
   if (gridTupBebekRaporlari.Rows.Count > 0 && gridTupBebekRaporlari.CurrentCell != null)
            {
                if ((((ITTGridCell)gridTupBebekRaporlari.CurrentCell).OwningColumn != null) && (((ITTGridCell)gridTupBebekRaporlari.CurrentCell).OwningColumn.Name == "raporSilTupBebek"))
                {
                    ITTGridCell currentCell = gridTupBebekRaporlari.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            if (currentRow.Cells[0].Value != null && currentRow.Cells[1].Value  != null  && currentRow.Cells[2].Value != null  && currentRow.Cells[3].Value != null )
                            {
//                                IList manipulationRequestList =ManipulationRequest.GetManipulationRequestQuery(currentRow.Cells[1].Value.ToString());
//                                bool manipulationControl = false;
//                                foreach (ManipulationRequest.GetManipulationRequestQuery_Class item in manipulationRequestList)
//                                {
//                                    IList manipulationList = Manipulation.GetManipulationsbyRequest(item.ObjectID.Value);
//                                    foreach (Manipulation.GetManipulationsbyRequest_Class item2 in manipulationList)
//                                    {
//                                        if (item2.CurrentStateDefID != Manipulation.States.Cancelled)
//                                            manipulationControl = true;
//                                    }
//                                }
//                                if (manipulationRequestList.Count == 0 || manipulationControl == false)
//                                {
                                    InfoBox.Show("Seçili Rapor Meduladan Silinecektir!! ",MessageIconEnum.InformationMessage);
                                    //DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                    //if (dialogResult == DialogResult.OK)
                                    //{
                                        try
                                        {
                                            RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
                                            raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                                            RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
                                            _raporOkuDVO.no = currentRow.Cells[1].Value.ToString();
                                            _raporOkuDVO.raporSiraNo = currentRow.Cells[2].Value.ToString();
                                            _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                            _raporOkuDVO.tarih = currentRow.Cells[3].Value.ToString();
                                            _raporOkuDVO.turu = "1";
                                            raporSorguDVO.raporBilgisi = _raporOkuDVO;

                                            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
                                            if (response != null)
                                            {
                                                    if (response.sonucKodu.Equals(0))
                                                    {
                                                        currentRow.Cells[0].Value = "";
                                                        currentRow.Cells[1].Value = "";
                                                        currentRow.Cells[2].Value = "";
                                                        currentRow.Cells[3].Value = "";
                                                        currentRow.Cells[4].Value = "";
                                                        currentRow.Cells[5].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                                                        {
                                                            InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                                                            return;
                                                        }
                                                    }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                   // }
//                                }
//                               else
//                                {
//                                    InfoBox.Show("Bu Raporun Hiperbarik Oksijen Hizmeti Var, Silemezsiniz!!!");
//                                    return;
//                                }
                            }
                            else
                            {
                                InfoBox.Show("Medulaya Kaydı Yapılmamış Bir Hiperbarik Oksijen Raporunu Meduladan Silemezsiniz!!!");
                            }
                        }
                    }
                }
            }
#endregion MedulaRaporIslemleri_gridTupBebekRaporlari_CellContentClick
        }

        private void gridHOTRaporlari_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaRaporIslemleri_gridHOTRaporlari_CellContentClick
   if (gridHOTRaporlari.Rows.Count > 0 && gridHOTRaporlari.CurrentCell != null)
            {
                if ((((ITTGridCell)gridHOTRaporlari.CurrentCell).OwningColumn != null) && (((ITTGridCell)gridHOTRaporlari.CurrentCell).OwningColumn.Name == "raporSilHOT"))
                {
                    ITTGridCell currentCell = gridHOTRaporlari.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            if (currentRow.Cells[0].Value != null && currentRow.Cells[1].Value  != null  && currentRow.Cells[2].Value != null  && currentRow.Cells[3].Value != null )
                            {
//                                IList hOTList =HyperbarikOxygenTreatmentRequest.GetHOTRequestQuery(currentRow.Cells[1].Value.ToString());
//                                bool hOTControl = false;
//                                foreach (HyperbarikOxygenTreatmentRequest.GetHOTRequestQuery_Class item in hOTList)
//                                {
//                                    if (item.CurrentStateDefID != HyperbarikOxygenTreatmentRequest.States.Cancelled)
//                                        hOTControl = true;
//                                }
//
//                                if (hOTList.Count == 0 || hOTControl == false)
//                                {
                                     InfoBox.Show("Seçili Rapor Meduladan Silinecektir!! ",MessageIconEnum.InformationMessage);
                                    //DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                    //if (dialogResult == DialogResult.OK)
                                    //{
                                        try
                                        {
                                            RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
                                            raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                                            RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
                                            _raporOkuDVO.no = currentRow.Cells[1].Value.ToString();
                                            _raporOkuDVO.raporSiraNo = currentRow.Cells[2].Value.ToString();
                                            _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                            _raporOkuDVO.tarih = currentRow.Cells[3].Value.ToString();
                                            _raporOkuDVO.turu = "1";
                                            raporSorguDVO.raporBilgisi = _raporOkuDVO;

                                            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
                                            if (response != null)
                                            {
                                                    if (response.sonucKodu.Equals(0))
                                                    {
                                                        currentRow.Cells[0].Value = "";
                                                        currentRow.Cells[1].Value = "";
                                                        currentRow.Cells[2].Value = "";
                                                        currentRow.Cells[3].Value = "";
                                                        currentRow.Cells[4].Value = "";
                                                        currentRow.Cells[5].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                                                        {
                                                            InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                                                            return;
                                                        }
                                                    }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                   // }
//                                }
//                               else
//                                {
//                                    InfoBox.Show("Bu Raporun Hiperbarik Oksijen Hizmeti Var, Silemezsiniz!!!");
//                                    return;
//                                }
                            }
                            else
                            {
                                InfoBox.Show("Medulaya Kaydı Yapılmamış Bir Hiperbarik Oksijen Raporunu Meduladan Silemezsiniz!!!");
                            }
                        }
                    }
                }
            }
#endregion MedulaRaporIslemleri_gridHOTRaporlari_CellContentClick
        }

        private void btnFtrIstek_Click()
        {
#region MedulaRaporIslemleri_btnFtrIstek_Click
   //
//   string objectDefName = "PHYSIOTHERAPYREQUEST";
//   TTObjectDef objDef = null;
//   TTObjectDefManager.Instance.ObjectDefs.TryGetValue(objectDefName, out objDef);
//            if (TTObjectDefManager.Instance.ObjectDefs.ContainsKey(objectDefName) == false)
//            {
//                string[] parameters = new string[] { objectDefName };
//                InfoBox.Show(SystemMessage.GetMessage(355, parameters));
//                return;
//            }
//
//            TTObjectContext objectContext = new TTObjectContext(false);
//            try
//            {
//                EpisodeAction newAction = (EpisodeAction)objectContext.CreateObject(objectDefName);
//                Episode ep = (Episode)objectContext.GetObject((Guid)episodeID, typeof(Episode));
//                
//                newAction.Episode = ep;
//                String error = ((ITTObject)newAction).Error;
//                if (!String.IsNullOrEmpty(error))// setEpisode'da alınan hatalar için
//                    throw new Exception(error);
//
//
//                if (TTObjectDefManager.Instance.ObjectDefs.ContainsKey(objectDefName) == true)
//                {
//                    foreach (TTObjectStateDef StateDef in objDef.StateDefs)
//                    {
//                        if (StateDef.IsEntry == true)
//                            newAction.CurrentStateDef = StateDef;
//                    }
//                }
//
//
//                TTForm frm = TTForm.GetEditForm(newAction);
//                if (frm == null)
//                {
//                    InfoBox.Show(objectDefName + " isimli işlem için form tanımlanmamış.");
//                    return;
//                }
//               // frm.ObjectUpdated += new ObjectUpdatedDelegate(Action_ObjectUpdated);
//              //  frm.GetTemplates = TTHospital.PatientFolderControl.Utility.FillRTFTemplates;
//              //  frm.SaveTemplate = TTHospital.PatientFolderControl.Utility.SaveRTFTemplate;
//               // frm.TemplateSelected = TTHospital.PatientFolderControl.Utility.SelectRTFTemplate;
//                frm.ShowEdit(this.ParentForm, newAction);
//
//            }
//            catch (System.Exception ex)
//            {
//                InfoBox.Show(ex);
//            }
//            finally
//            {
//                objectContext.Dispose();
//            }
#endregion MedulaRaporIslemleri_btnFtrIstek_Click
        }

        private void gridFizyoTerapiIslemleri_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaRaporIslemleri_gridFizyoTerapiIslemleri_CellContentClick
   //            if(gridFizyoTerapiIslemleri.CurrentCell != null)
//            {
//                if(gridFizyoTerapiIslemleri.CurrentCell.OwningRow.Cells[TedaviTuru.Name].Value == null)
//                {
//                    if (gridHastaAktifTakipleri.CurrentCell != null && gridHastaAktifTakipleri.CurrentCell.RowIndex >= 0)
//                    {
//                        ITTGridRow selectedRow = gridHastaAktifTakipleri.CurrentCell.OwningRow;
//                        if (selectedRow != null )
//                        {
//                            gridFizyoTerapiIslemleri.CurrentCell.OwningRow.Cells[TedaviTuru.Name].Value = selectedRow.Cells[7].Value.ToString();
//                        }
//                    }
//                }
//            }            
//
#endregion MedulaRaporIslemleri_gridFizyoTerapiIslemleri_CellContentClick
        }

        private void gridFizyoTerapiIslemleri_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaRaporIslemleri_gridFizyoTerapiIslemleri_CellValueChanged
   if(gridFizyoTerapiIslemleri.CurrentCell != null)
            {
                if(gridFizyoTerapiIslemleri.CurrentCell.OwningRow.Cells[TedaviTuru.Name].Value == null)
                {
                    if (gridHastaAktifTakipleri.CurrentCell != null)
                    {
                        ITTGridRow selectedRow = gridHastaAktifTakipleri.CurrentCell.OwningRow;
                        if (selectedRow != null )
                        {
                            gridFizyoTerapiIslemleri.CurrentCell.OwningRow.Cells[TedaviTuru.Name].Value = TTObjectClasses.TedaviTuru.GetTedaviTuru(selectedRow.Cells[7].Value.ToString()).ObjectID;
                        }
                    }
                }
            }
#endregion MedulaRaporIslemleri_gridFizyoTerapiIslemleri_CellValueChanged
        }

        private void gridTani_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaRaporIslemleri_gridTani_CellValueChanged
   ITTGridRow rowGridTani= this.gridTani.Rows [this.gridTani.CurrentCell.RowIndex];
            if(this.gridTani.Rows.Count > 0 && rowGridTani.Cells[0].Value != null)
            {
                TTObjectContext context = new TTObjectContext(true);
                DiagnosisDefinition dgDef = (DiagnosisDefinition)context.GetObject((Guid)rowGridTani.Cells[0].Value, typeof(DiagnosisDefinition).Name);
                rowGridTani.Cells[1].Value = dgDef.FtrDiagnoseGroup != null ? dgDef.FtrDiagnoseGroup.Value.ToString() : null;
            }
#endregion MedulaRaporIslemleri_gridTani_CellValueChanged
        }

        private void btnRaporKaydet_Click()
        {
#region MedulaRaporIslemleri_btnRaporKaydet_Click
   if (RaporBitisTarihi == null)
            {
                InfoBox.Show("Bitiş Tarihi Boş Geçilemez ! ");
            }
            if (RaporBaslangicTarihi == null)
            {
                InfoBox.Show("Başlangıç Tarihi Boş Geçilemez ! ");
                return;
            }
            if (Convert.ToDateTime((RaporBitisTarihi.NullableValue)) <= Convert.ToDateTime(RaporBaslangicTarihi.NullableValue))
            {
                InfoBox.Show("Bitiş Tarihi, Başlangıç Tarihinden büyük olmalıdır ! ");
                return;
            }
            if (lstTabip.SelectedValue == null)
            {
                InfoBox.Show("Doktor Alanı Boş Geçilemez ! ");
                return;
            }
            if(cmbRaporTuru.SelectedItem ==null)
            {
                InfoBox.Show("Rapor Türü Seçiniz ! ");
                return;
            }
            RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();
            RaporIslemleri.tedaviRaporDVO tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
            RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();
          //  string tedaviTuru = string.Empty;

            raporGirisDVO.isgoremezlikRapor = null;
            //TODO : MEDULA20140501
            raporGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            raporGirisDVO.ilacRapor = null;

            _raporDVO.aciklama = "";
            _raporDVO.baslangicTarihi = Convert.ToDateTime(RaporBaslangicTarihi.NullableValue).ToString("dd.MM.yyyy");
            _raporDVO.bitisTarihi = Convert.ToDateTime(RaporBitisTarihi.NullableValue).ToString("dd.MM.yyyy");
            _raporDVO.durum = "";
            
            if(cmbOzelDurum.SelectedItem == null || cmbOzelDurum.SelectedItem.Value == null)
                _raporDVO.ozelDurum = 0;
            else
                _raporDVO.ozelDurum = Convert.ToInt32(cmbOzelDurum.SelectedItem.Value);
            
            if ((Convert.ToInt32(cmbRaporTuru.SelectedItem.Value)==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.HBT).Value && ((TTVisual.TTCheckBox)(chkFtrHeyetRaporu)).Checked) || ((TTVisual.TTCheckBox)(chkFtrHeyetRaporu)).Checked)
                _raporDVO.duzenlemeTuru = "1";
            else
                _raporDVO.duzenlemeTuru = "2";
            _raporDVO.klinikTani = "";
            _raporDVO.turu = "1";

            List<RaporIslemleri.taniBilgisiDVO> taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();

            TTObjectContext context = new TTObjectContext(true);
            if (gridTani.Rows.Count == 0)
            {
                InfoBox.Show("Tanı Seçmeniz Gerekmektedir ! ");
                return;
            }
            List<string> taniList = new List<string>();
            foreach(ITTGridRow item in gridTani.Rows)
            {
                if (item.Cells[lstTani.Name].Value == null)
                {
                    InfoBox.Show("Tanı Seçmeniz Gerekmektedir ! ");
                    return;
                }
                DiagnosisDefinition tani = (DiagnosisDefinition)context.GetObject((Guid)item.Cells[lstTani.Name].Value, typeof(DiagnosisDefinition));
                taniList.Add(tani.Code);
            }

            taniList = Common.DiagnosesForMedula(taniList);

            foreach (string taniItem in taniList)
            {
                RaporIslemleri.taniBilgisiDVO taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
                taniBilgisiDVO.taniKodu = taniItem;
                taniBilgisiDVOList.Add(taniBilgisiDVO);
            }

            _raporDVO.tanilar = taniBilgisiDVOList.ToArray();
        
            if (gridHastaAktifTakipleri.CurrentCell != null && gridHastaAktifTakipleri.CurrentCell.RowIndex >= 0)
            {
                ITTGridRow selectedRow = gridHastaAktifTakipleri.CurrentCell.OwningRow;
                if (selectedRow != null )
                {
                    _raporDVO.protokolNo = selectedRow.Cells[4].Value.ToString();
                    _raporDVO.protokolTarihi = Convert.ToDateTime(selectedRow.Cells[5].Value).ToString("dd.MM.yyyy");
                    _raporDVO.takipNo = selectedRow.Cells[0].Value.ToString();
                    // tedaviTuru = selectedRow.Cells[7].Value.ToString();
                }
            }
            else
            {
                InfoBox.Show("Hastanın Bu Rapor İçin Geçerli Bir Branşta Takibi Bulunamamktadır ! ");
                return;
            }

            List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
            RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
            ResUser doctor = new ResUser();
            doctor = (ResUser)((TTListBox)this.lstTabip).SelectedObject;
            _doktorBilgisiDVO.drAdi = doctor != null ? doctor.Person.Name : "";
            _doktorBilgisiDVO.drBransKodu = (doctor != null  && SpecialityDefinition.GetSpecialityByResUser(doctor) != null) ? SpecialityDefinition.GetSpecialityByResUser(doctor).Code : "";
            _doktorBilgisiDVO.drSoyadi = doctor != null ? doctor.Person.Surname : "";
            _doktorBilgisiDVO.drTescilNo = doctor != null ? doctor.DiplomaRegisterNo : "";
            _doktorBilgisiDVO.tipi = "2";
            _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
            if ((Convert.ToInt32(cmbRaporTuru.SelectedItem.Value)==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.HBT).Value && ((TTVisual.TTCheckBox)(chkFtrHeyetRaporu)).Checked) || ((TTVisual.TTCheckBox)(chkFtrHeyetRaporu)).Checked)
            {
                if (lstTabip2.SelectedValue == null)
                {
                    InfoBox.Show("2. Doktor Alanı Boş Geçilemez ! ");
                    return;
                }
                if (lstTabip3.SelectedValue == null)
                {
                    InfoBox.Show("3. Doktor Alanı Boş Geçilemez ! ");
                    return;
                }
                
                RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO2 = new RaporIslemleri.doktorBilgisiDVO();
                ResUser doctor2 = new ResUser();
                doctor2 = (ResUser)((TTListBox)this.lstTabip2).SelectedObject;
                _doktorBilgisiDVO2.drAdi = doctor2 != null ? doctor2.Person.Name : "";
                _doktorBilgisiDVO2.drBransKodu = (doctor2 != null  && SpecialityDefinition.GetSpecialityByResUser(doctor2) != null) ? SpecialityDefinition.GetSpecialityByResUser(doctor2).Code : "";
                _doktorBilgisiDVO2.drSoyadi = doctor2 != null ? doctor2.Person.Surname : "";
                _doktorBilgisiDVO2.drTescilNo = doctor2 != null ? doctor2.DiplomaRegisterNo : "";
                _doktorBilgisiDVO2.tipi = "2";
                _doktorBilgisiDVOList.Add(_doktorBilgisiDVO2);
                
                RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO3 = new RaporIslemleri.doktorBilgisiDVO();
                ResUser doctor3 = new ResUser();
                doctor3 = (ResUser)((TTListBox)this.lstTabip3).SelectedObject;
                _doktorBilgisiDVO3.drAdi = doctor3 != null ? doctor3.Person.Name : "";
                _doktorBilgisiDVO3.drBransKodu = (doctor3 != null  && SpecialityDefinition.GetSpecialityByResUser(doctor3) != null) ? SpecialityDefinition.GetSpecialityByResUser(doctor3).Code : "";
                _doktorBilgisiDVO3.drSoyadi = doctor3 != null ? doctor3.Person.Surname : "";
                _doktorBilgisiDVO3.drTescilNo = doctor3 != null ? doctor3.DiplomaRegisterNo : "";
                _doktorBilgisiDVO3.tipi = "2";
                _doktorBilgisiDVOList.Add(_doktorBilgisiDVO3);
            }
            _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();

            _raporDVO.hakSahibi = null;
            long value  = 0;
            RaporIslemleri.raporBilgisiDVO raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
            raporBilgisiDVO.aVakaTKaza = 3;
            
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTR).Value || Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWT).Value || Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTRTRAFIKKAZASI).Value)
                value = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["FTRRaporSequence"] , null, null);
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWL).Value)
                value = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["TasKirmaRaporSequence"], null, null);
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.DIYALIZ).Value || Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.EVHEMODIYALIZI).Value)
                value = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["DiyalizRaporSequence"], null, null);
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.TUPBEBEK).Value)
                value = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["TupBebekRaporSequence"], null, null);
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.HBT).Value)
                value = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["HOTRaporSequence"], null, null);

            raporBilgisiDVO.no = value.ToString();
            raporBilgisiDVO.raporSiraNo = 0;
            raporBilgisiDVO.raporTakipNo = "";
            raporBilgisiDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            raporBilgisiDVO.tarih =  Convert.ToDateTime(RaporBaslangicTarihi.NullableValue).ToString("dd.MM.yyyy");
            _raporDVO.raporBilgisi = raporBilgisiDVO;
            tedaviRaporDVO.raporDVO = _raporDVO;
            
            List<RaporIslemleri.tedaviIslemBilgisiDVO> tedaviIslemBilgisiDVO = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();
            RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisi = new RaporIslemleri.tedaviIslemBilgisiDVO();
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTR).Value || Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTRTRAFIKKAZASI).Value)
            {
                if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTR).Value)
                    tedaviRaporDVO.tedaviRaporTuru = 5;
                else
                    tedaviRaporDVO.tedaviRaporTuru = 7;
                
                if (gridFizyoTerapiIslemleri.Rows.Count == 0)
                {
                    InfoBox.Show("Fizyoterapi İşlemi Seçmeniz Gerekmektedir ! ");
                    return;
                }
                foreach (ITTGridRow item in gridFizyoTerapiIslemleri.Rows)
                {
                    if (item.Cells[FizyoterapiIslemi.Name].Value == null)
                    {
                        InfoBox.Show("Fizyoterapi Rapor Kodu Seçmeniz Gerekmektedir ! ");
                        return;
                    }
                    if (item.Cells[SeansSayisi.Name].Value == null)
                    {
                        InfoBox.Show("Seans Sayısı Girmeniz Gerekmektedir ! ");
                        return;
                    }
                    if (item.Cells[VucutBolgesi.Name].Value == null)
                    {
                        InfoBox.Show("Vücut Bölgesi Seçmeniz Gerekmektedir ! ");
                        return;
                    }
                    if (item.Cells[TedaviTuru.Name].Value == null)
                    {
                        InfoBox.Show("Tedavi Türü Seçmeniz Gerekmektedir ! ");
                        return;
                    }
                    
                    RaporIslemleri.ftrRaporBilgisiDVO fTRRaporBilgisiDVO = new RaporIslemleri.ftrRaporBilgisiDVO();
                    TedaviRaporiIslemKodlari tedaviRaporiIslemKodlari = (TedaviRaporiIslemKodlari)context.GetObject((Guid)item.Cells[FizyoterapiIslemi.Name].Value, typeof(TedaviRaporiIslemKodlari));
                    fTRRaporBilgisiDVO.butKodu = tedaviRaporiIslemKodlari.TedaviRaporuIslemKodu;
                    fTRRaporBilgisiDVO.seansSayi = Convert.ToInt32(item.Cells[SeansSayisi.Name].Value.ToString());
                    FTRVucutBolgesi fTRVucutBolgesi = (FTRVucutBolgesi)context.GetObject((Guid)item.Cells[VucutBolgesi.Name].Value, typeof(FTRVucutBolgesi));
                    fTRRaporBilgisiDVO.ftrVucutBolgesiKodu = Convert.ToInt32(fTRVucutBolgesi.ftrVucutBolgesiKodu);
                    //  TimeSpan sp = Convert.ToDateTime(RaporBitisTarihi.NullableValue).Subtract(Convert.ToDateTime(RaporBaslangicTarihi.NullableValue));
                    fTRRaporBilgisiDVO.seansGun = 365;
                    TedaviTuru tedaviTuru = (TedaviTuru)context.GetObject((Guid)item.Cells[TedaviTuru.Name].Value, typeof(TedaviTuru));
                    fTRRaporBilgisiDVO.tedaviTuru = tedaviTuru.tedaviTuruKodu;
                    fTRRaporBilgisiDVO.robotikRehabilitasyon = ".";
                    tedaviIslemBilgisi.ftrRaporBilgisi = fTRRaporBilgisiDVO;
                    tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
                }
            }
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWT).Value)
            {
                tedaviRaporDVO.tedaviRaporTuru = 3;
                if (gridEswtIslemi.Rows.Count == 0)
                {
                    InfoBox.Show("Fizyoterapi İşlemi Seçmeniz Gerekmektedir ! ");
                    return;
                }
                foreach (ITTGridRow item in gridEswtIslemi.Rows)
                {
                    if (item.Cells[FizyoterapiIslemiESWT.Name].Value == null)
                    {
                        InfoBox.Show("Fizyoterapi Rapor Kodu Seçmeniz Gerekmektedir ! ");
                        return;
                    }
                    if (item.Cells[SeansSayisiESWT.Name].Value == null)
                    {
                        InfoBox.Show("Seans Sayısı Girmeniz Gerekmektedir ! ");
                        return;
                    }
                    if (item.Cells[VucutBolgesiESWT.Name].Value == null)
                    {
                        InfoBox.Show("Vücut Bölgesi Seçmeniz Gerekmektedir ! ");
                        return;
                    }
                    
                    RaporIslemleri.eswtRaporBilgisiDVO eSWTRaporBilgisiDVO = new RaporIslemleri.eswtRaporBilgisiDVO();
                    TedaviRaporiIslemKodlari tedaviRaporiIslemKodlari = (TedaviRaporiIslemKodlari)context.GetObject((Guid)item.Cells[FizyoterapiIslemiESWT.Name].Value, typeof(TedaviRaporiIslemKodlari));
                    eSWTRaporBilgisiDVO.butKodu = tedaviRaporiIslemKodlari.TedaviRaporuIslemKodu;
                    eSWTRaporBilgisiDVO.seansSayi = Convert.ToInt32(item.Cells[SeansSayisiESWT.Name].Value.ToString());
                    FTRVucutBolgesi eSWTVucutBolgesi = (FTRVucutBolgesi)context.GetObject((Guid)item.Cells[VucutBolgesiESWT.Name].Value, typeof(FTRVucutBolgesi));
                    eSWTRaporBilgisiDVO.eswtVucutBolgesiKodu = Convert.ToInt32(eSWTVucutBolgesi.ftrVucutBolgesiKodu);
                    eSWTRaporBilgisiDVO.seansGun = 365;
                    tedaviIslemBilgisi.eswtRaporBilgisi = eSWTRaporBilgisiDVO;
                    tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
                }
            }
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWL).Value)
            {
                tedaviRaporDVO.tedaviRaporTuru = 6;
                List<RaporIslemleri.eswlTasBilgisiDVO> eSWLTasBilgisiDVOList = new List<RaporIslemleri.eswlTasBilgisiDVO>();
                if (lstEswlRaporKodu.SelectedValue == null)
                {
                    InfoBox.Show("ESWL İşlemi Seçmeniz Gerekmektedir ! ");
                    return;
                }
                if (gridTasBilgisi.Rows.Count ==0)
                {
                    InfoBox.Show("Taş Bilgilerini Girmeniz Gerekmektedir ! ");
                    return;
                }
                if (string.IsNullOrEmpty(txtTasSayisi.Text))
                {
                    InfoBox.Show("Taş Sayısını Girmeniz Gerekmektedir ! ");
                    return;
                }
                if (string.IsNullOrEmpty(txtEswlSeansSayisi.Text))
                {
                    InfoBox.Show("Seans Bilgisini Girmeniz Gerekmektedir ! ");
                    return;
                }
                if (lstBobrekBilgisi.SelectedValue == null)
                {
                    InfoBox.Show("Taş Bilgilerini Girmeniz Gerekmektedir ! ");
                    return;
                }
                RaporIslemleri.eswlRaporBilgisiDVO eSWLRaporBilgisiDVO = new RaporIslemleri.eswlRaporBilgisiDVO();
                TedaviRaporiIslemKodlari tedaviRaporiIslemKodlari = (TedaviRaporiIslemKodlari)((TTListBox)this.lstEswlRaporKodu).SelectedObject;
                eSWLRaporBilgisiDVO.butKodu = tedaviRaporiIslemKodlari.TedaviRaporuIslemKodu;
                eSWLRaporBilgisiDVO.eswlRaporuSeansSayisi = Convert.ToInt32(txtEswlSeansSayisi.Text);
                eSWLRaporBilgisiDVO.eswlRaporuTasSayisi = Convert.ToInt32(txtTasSayisi.Text);
                Bobrek bobrek = (Bobrek)((TTListBox)this.lstBobrekBilgisi).SelectedObject;
                eSWLRaporBilgisiDVO.bobrekBilgisi = Convert.ToInt32(bobrek.bobrekKodu);
                foreach (ITTGridRow tasBilgisi in gridTasBilgisi.Rows)
                {

                    if (tasBilgisi.Cells[Lokalizasyon2.Name].Value == null)
                    {
                        InfoBox.Show("Lokalizasyon Seçmeniz Gerekmektedir ! ");
                        return;
                    }
                    if (tasBilgisi.Cells[TasBoyutu2.Name].Value == null)
                    {
                        InfoBox.Show("Taşın Boyutunu Girmeniz Gerekmektedir ! ");
                        return;
                    }
                    RaporIslemleri.eswlTasBilgisiDVO eSWLTasBilgisiDVO = new RaporIslemleri.eswlTasBilgisiDVO();
                    eSWLTasBilgisiDVO.tasBoyutu = tasBilgisi.Cells[TasBoyutu2.Name].Value.ToString();
                    //TasLokalizasyon tasLokalizasyon = (TasLokalizasyon)context.GetObject((Guid)tasBilgisi.Cells[Lokalizasyon1.Name].Value, typeof(TasLokalizasyon));
                    eSWLTasBilgisiDVO.tasLokalizasyonKodu = Convert.ToInt32(tasBilgisi.Cells[Lokalizasyon2.Name].Value);// tasLokalizasyon.tasLokalizasyonKodu != null ? Convert.ToInt32(tasLokalizasyon.tasLokalizasyonKodu.Value.ToString()) : 0;
                    eSWLTasBilgisiDVOList.Add(eSWLTasBilgisiDVO);
                }
                eSWLRaporBilgisiDVO.eswlRaporuTasBilgileri = eSWLTasBilgisiDVOList.ToArray();
                tedaviIslemBilgisi.eswlRaporBilgisi = eSWLRaporBilgisiDVO;
                tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
            }

            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value)  ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.DIYALIZ).Value)
            {
                tedaviRaporDVO.tedaviRaporTuru = 1;
                if (lstDiyalizRaporKodu.SelectedValue == null)
                {
                    InfoBox.Show("Diyaliz İşlemi Seçmeniz Gerekmektedir ! ");
                    return;
                }                
                if (string.IsNullOrEmpty(txtDiyalizSeansSayisi.Text))
                {
                    InfoBox.Show("Seans Bilgisini Girmeniz Gerekmektedir ! ");
                    return;
                }
                if (cmbDiyalizSeansGun.SelectedItem == null)
                {
                    InfoBox.Show("Seans Gün Seçmeniz Gerekmektedir ! ");
                    return;
                }
                RaporIslemleri.diyalizRaporBilgisiDVO diyalizRaporBilgisiDVO = new RaporIslemleri.diyalizRaporBilgisiDVO();
                TedaviRaporiIslemKodlari tedaviRaporiIslemKodlari =(TedaviRaporiIslemKodlari)((TTListBox)this.lstDiyalizRaporKodu).SelectedObject;
                if(chkRefakatVarYok.Value != null)
                    diyalizRaporBilgisiDVO.refakatVarMi =chkRefakatVarYok.Value.ToString() == Boolean.TrueString ? "E" :"H";
                else
                    diyalizRaporBilgisiDVO.refakatVarMi ="H";
                diyalizRaporBilgisiDVO.butKodu = tedaviRaporiIslemKodlari.TedaviRaporuIslemKodu;
                diyalizRaporBilgisiDVO.seansSayi = Convert.ToInt32(txtDiyalizSeansSayisi.Text);
                diyalizRaporBilgisiDVO.seansGun = Convert.ToInt32(cmbDiyalizSeansGun.SelectedItem.Value);
                tedaviIslemBilgisi.diyalizRaporBilgisi = diyalizRaporBilgisiDVO;
                tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
                
            }
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value)  == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.EVHEMODIYALIZI).Value)
            {
                tedaviRaporDVO.tedaviRaporTuru = 8;
                if (lstEvHemodiyalizRaporKodu.SelectedValue == null)
                {
                    InfoBox.Show("Ev Hemodiyaliz İşlemi Seçmeniz Gerekmektedir ! ");
                    return;
                }
                if (string.IsNullOrEmpty(txtEvHemodiyalizSeansSayisi.Text))
                {
                    InfoBox.Show("Seans Bilgisini Girmeniz Gerekmektedir ! ");
                    return;
                }
                //                if (string.IsNullOrEmpty(tttabEvHemoDiyalizRaporKaydet.Text))
                //                {
                //                    InfoBox.Show("Tedavi Süresini Girmeniz Gerekmektedir ! ");
                //                    return;
                //                }
                RaporIslemleri.evHemodiyaliziRaporBilgisiDVO evHemodiyaliziRaporBilgisiDVO = new RaporIslemleri.evHemodiyaliziRaporBilgisiDVO();
                TedaviRaporiIslemKodlari tedaviRaporiIslemKodlari =(TedaviRaporiIslemKodlari)((TTListBox)this.lstEvHemodiyalizRaporKodu).SelectedObject;
                evHemodiyaliziRaporBilgisiDVO.butKodu = tedaviRaporiIslemKodlari.TedaviRaporuIslemKodu;
                evHemodiyaliziRaporBilgisiDVO.seansGun = Convert.ToInt32(cmbEvHemodiyalizSeansGun.SelectedItem.Value);
                evHemodiyaliziRaporBilgisiDVO.seansSayi =Convert.ToInt32(txtEvHemodiyalizSeansSayisi.Text);
                tedaviIslemBilgisi.evHemodiyaliziRaporBilgisi = evHemodiyaliziRaporBilgisiDVO;
                tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
            }

            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.HBT).Value)
            {
                tedaviRaporDVO.tedaviRaporTuru = 2;
                if (string.IsNullOrEmpty(txtHOTSeansSayisi.Text))
                {
                    InfoBox.Show("Seans Bilgisini Girmeniz Gerekmektedir ! ");
                    return;
                }
                if (string.IsNullOrEmpty(txtHOTTedaviSuresi.Text))
                {
                    InfoBox.Show("Tedavi Süresini Girmeniz Gerekmektedir ! ");
                    return;
                }
                RaporIslemleri.hotRaporBilgisiDVO hOTRaporBilgisiDVO = new RaporIslemleri.hotRaporBilgisiDVO();
                hOTRaporBilgisiDVO.seansGun = 365;
                hOTRaporBilgisiDVO.seansSayi =Convert.ToInt32(txtHOTSeansSayisi.Text);
                hOTRaporBilgisiDVO.tedaviSuresi = Convert.ToInt32(txtHOTTedaviSuresi.Text);
                tedaviIslemBilgisi.hotRaporBilgisi = hOTRaporBilgisiDVO;
                tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
            }
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.TUPBEBEK).Value)
            {
                tedaviRaporDVO.tedaviRaporTuru = 4;
                if (lstTupBebekRaporKodu.SelectedValue == null)
                {
                    InfoBox.Show("Ev Hemodiyaliz İşlemi Seçmeniz Gerekmektedir ! ");
                    return;
                }
                if (cmbRaporTuru.SelectedItem == null)
                {
                    InfoBox.Show("Seans Bilgisini Girmeniz Gerekmektedir ! ");
                    return;
                }
                
                RaporIslemleri.tupBebekRaporBilgisiDVO tupBebekRaporBilgisiDVO = new RaporIslemleri.tupBebekRaporBilgisiDVO();
                TedaviRaporiIslemKodlari tedaviRaporiIslemKodlari =(TedaviRaporiIslemKodlari)((TTListBox)this.lstTupBebekRaporKodu).SelectedObject;
                tupBebekRaporBilgisiDVO.butKodu = tedaviRaporiIslemKodlari.TedaviRaporuIslemKodu;
                tupBebekRaporBilgisiDVO.tupBebekRaporTuru = Convert.ToInt32(cmbTupBebekTuru.SelectedItem.Value) + 1;
                tedaviIslemBilgisi.tupBebekRaporBilgisi = tupBebekRaporBilgisiDVO;
                tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
            }
            tedaviRaporDVO.islemler = tedaviIslemBilgisiDVO.ToArray();
            raporGirisDVO.tedaviRapor = tedaviRaporDVO;
            
            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.takipNoileRaporBilgisiKaydetSync(Sites.SiteLocalHost, raporGirisDVO);
            if (response != null)
            {
                if (response.sonucKodu.Equals(0))
                {
                    txtRaporTakipNo.Text = response.raporTakipNo.ToString();
                    InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi, MessageIconEnum.InformationMessage);
                    ////return;
                }
                else
                {
                    InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.sonucAciklamasi + "  Rapor Takip Numarası Alınamamıştır.  !!!");
                    return;
                }
            }
#endregion MedulaRaporIslemleri_btnRaporKaydet_Click
        }

        private void btnSearchTCKNo_Click()
        {
#region MedulaRaporIslemleri_btnSearchTCKNo_Click
   if(((ITTComboBox)((TTVisual.TTComboBox)(cmbReportType))).SelectedItem == null || ((ITTComboBox)((TTVisual.TTComboBox)(cmbReportType))).SelectedItem.Value == null)
            {
                InfoBox.Show("Rapor Türünü Seçiniz");
                return;
            }
            if (!string.IsNullOrEmpty(((ITTComboBox)((TTVisual.TTComboBox)(cmbReportType))).SelectedItem.Value.ToString()))
            {
                txtResult.Visible = false;
                txtResult.Text = "";
                string result = ((ITTComboBox)((TTVisual.TTComboBox)(cmbReportType))).SelectedItem.Value.ToString();
                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                //TODO : MEDULA20140501
                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _raporOkuTCKimlikNodanDVO.raporTuru = result;
                _raporOkuTCKimlikNodanDVO.tckimlikNo = txtTCKNo.Text.Trim();
                RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
                if (response != null)
                {
                    if (!response.sonucKodu.Equals(0))
                    {
                        if(response.sonucKodu.Equals(5005))
                        {
                            txtResult.Visible = true;
                            txtResult.Text = "Bu servis sadece tedavi ve ilaç rapor bilgilerini döndürmektedir";
                            return;
                        }
                        else
                        {
                            txtResult.Visible = true;
                            txtResult.Text = "Sonuc Açıklaması : " + response.sonucAciklamasi + " Sonuç Kodu :" + response.sonucKodu;
                            return;
                        }
                    }
                    if (response.raporlar ==null)
                    {
                        txtResult.Visible = true;
                        txtResult.Text = txtName.Text + " " + txtSurname.Text + " adlı kişinin " + ((ITTComboBox)((TTVisual.TTComboBox)(cmbReportType))).SelectedText+" rapor tipinde rapor bilgisi bulunmamaktadır!!!";
                        return;
                    }

                    string aciklama = response.sonucAciklamasi;
                    int sonucKodu = response.sonucKodu;
                    List<RaporIslemleri.raporCevapDVO> _raporCevapDVOList = new List<RaporIslemleri.raporCevapDVO>();

                    StringBuilder sb = new StringBuilder();


                    foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                    {

                        long raporTakipNo = item.raporTakipNo;
                        string raporTuru = item.raporTuru;
                        string sonucAciklamasi = item.sonucAciklamasi;
                        int sonucKoduu = item.sonucKodu;
                        sb.AppendLine("Rapor Takip Numarası :" + item.raporTakipNo);

                        if (item.analikRapor != null)
                        {
                            sb.AppendLine("-----------------------------ANALIK RAPOR BİLGİSİ------------------------------");
                            sb.AppendLine("-------------------------------------------------------------------------------");
                            #region AnalikIsgoremezlikRaporDVO

                            sb.AppendLine("Bebek Doğum Tarihi :" + item.analikRapor.bebekDogumTarihi);
                            sb.AppendLine("Çocuk Sayısı :" + item.analikRapor.cocukSayisi);
                            sb.AppendLine("Açıklama :" + item.analikRapor.raporDVO.aciklama);
                            sb.AppendLine("Başlangıç Tarihi :" + item.analikRapor.raporDVO.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + item.analikRapor.raporDVO.bitisTarihi);
                            sb.AppendLine("Takip Numarası :" + item.analikRapor.raporDVO.takipNo);
                            sb.AppendLine("Türü :" + item.analikRapor.raporDVO.turu);

                            if (item.analikRapor.raporDVO != null && item.analikRapor.raporDVO.doktorlar != null)
                            {
                                sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");

                                foreach (RaporIslemleri.doktorBilgisiDVO _doktor in item.analikRapor.raporDVO.doktorlar)
                                {
                                    sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                    sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                    
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            if (item.analikRapor.raporDVO != null)
                            {
                                sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                                sb.AppendLine("Klinik Tanı :" + item.analikRapor.raporDVO.klinikTani);
                                sb.AppendLine("Protokol Numarası :" + item.analikRapor.raporDVO.protokolNo);
                                sb.AppendLine("Protokol Tarihi :" + item.analikRapor.raporDVO.protokolTarihi);
                                sb.AppendLine("aVakaTKaza :" + item.analikRapor.raporDVO.raporBilgisi.aVakaTKaza);
                                sb.AppendLine("Rapor Numarası :" + item.analikRapor.raporDVO.raporBilgisi.no);
                                sb.AppendLine("Rapor Sıra Numarası :" + item.analikRapor.raporDVO.raporBilgisi.raporSiraNo);
                                sb.AppendLine("Rapor Takip Numarası :" + item.analikRapor.raporDVO.raporBilgisi.raporTakipNo);
                                sb.AppendLine("Rapor Tesis Kodu :" + item.analikRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.analikRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.analikRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString());
                                sb.AppendLine("Tarih :" + item.analikRapor.raporDVO.raporBilgisi.tarih);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }



                            if (item.analikRapor.raporDVO != null && item.analikRapor.raporDVO.tanilar != null)
                            {
                                sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                RaporIslemleri.taniBilgisiDVO[] _tani = item.analikRapor.raporDVO.tanilar;
                                for (int i = 0; i < _tani.Length; i++)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                                }

                                sb.AppendLine("-----------------------------------------------------------------------------");

                            }

                            if (item.analikRapor.raporDVO != null && item.analikRapor.raporDVO.teshisler != null)
                            {
                                sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.teshisBilgisiDVO _teshis in item.analikRapor.raporDVO.teshisler)
                                {

                                    sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                    sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            if (item.analikRapor.raporDVO != null && item.analikRapor.raporDVO.ilacTeshisler != null)
                            {
                                sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in item.analikRapor.raporDVO.ilacTeshisler)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                    sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                    sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }



                            #endregion
                        }
                        if (item.dogumOncesiCalisabilirRapor != null && item.dogumOncesiCalisabilirRapor.raporDVO != null)
                        {
                            sb.AppendLine("----------------------DOĞUM ÖNCESİ ÇALIŞABİLİR RAPOR BİLGİSİ-------------------");
                            sb.AppendLine("-------------------------------------------------------------------------------");
                            #region DogumOncesiCalisabilirRaporDVO

                            sb.AppendLine("Bebek Doğum Tarihi :" + item.dogumOncesiCalisabilirRapor.bebekDogumTarihi);
                            sb.AppendLine("Doğum İzni Başlangıç Tarihi :" + item.dogumOncesiCalisabilirRapor.dogumIzniBaslangicTarihi);
                            sb.AppendLine("Açıklama :" + item.dogumOncesiCalisabilirRapor.raporDVO.aciklama);
                            sb.AppendLine("Başlangıç Tarihi :" + item.dogumOncesiCalisabilirRapor.raporDVO.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + item.dogumOncesiCalisabilirRapor.raporDVO.bitisTarihi);
                            sb.AppendLine("Takip Numarası :" + item.dogumOncesiCalisabilirRapor.raporDVO.takipNo);
                            sb.AppendLine("Türü :" + item.dogumOncesiCalisabilirRapor.raporDVO.turu);

                            if (item.dogumOncesiCalisabilirRapor.raporDVO.doktorlar != null)
                            {
                                sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                                foreach (RaporIslemleri.doktorBilgisiDVO _doktor in item.dogumOncesiCalisabilirRapor.raporDVO.doktorlar)
                                {
                                    sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                    sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }


                            sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Klinik Tanı :" + item.dogumOncesiCalisabilirRapor.raporDVO.klinikTani);
                            sb.AppendLine("Protokol Numarası :" + item.dogumOncesiCalisabilirRapor.raporDVO.protokolNo);
                            sb.AppendLine("Protokol Tarihi :" + item.dogumOncesiCalisabilirRapor.raporDVO.protokolTarihi);
                            sb.AppendLine("aVakaTKaza :" + item.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.aVakaTKaza);
                            sb.AppendLine("Rapor Numarası :" + item.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.no);
                            sb.AppendLine("Rapor Sıra Numarası :" + item.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporSiraNo);
                            sb.AppendLine("Rapor Takip Numarası :" + item.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporTakipNo);
                            sb.AppendLine("Rapor Tesis Kodu :" + item.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString());
                            sb.AppendLine("Tarih :" + item.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.tarih);
                            sb.AppendLine("-----------------------------------------------------------------------------");

                            if (item.dogumOncesiCalisabilirRapor.raporDVO.tanilar != null)
                            {
                                sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                RaporIslemleri.taniBilgisiDVO[] _tani = item.dogumOncesiCalisabilirRapor.raporDVO.tanilar;
                                for (int i = 0; i < _tani.Length; i++)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                                }

                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }

                            if (item.dogumOncesiCalisabilirRapor.raporDVO.teshisler != null)
                            {
                                sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.teshisBilgisiDVO _teshis in item.dogumOncesiCalisabilirRapor.raporDVO.teshisler)
                                {

                                    sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                    sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            if (item.dogumOncesiCalisabilirRapor.raporDVO.ilacTeshisler != null)
                            {
                                sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in item.dogumOncesiCalisabilirRapor.raporDVO.ilacTeshisler)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                    sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                    sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }


                            #endregion
                        }
                        if (item.dogumRapor != null && item.dogumRapor.raporDVO != null)
                        {
                            sb.AppendLine("-----------------------------DOĞUM RAPOR BİLGİSİ------------------------------");
                            sb.AppendLine("-------------------------------------------------------------------------------");
                            #region DogumRaporDVO

                            sb.AppendLine("Anestezi Tipi :" + item.dogumRapor.anesteziTipi);
                            sb.AppendLine("Bebek Doğum Tarihi :" + item.dogumRapor.bebekDogumTarihi);
                            sb.AppendLine("Canlı Çocuk Sayısı :" + item.dogumRapor.canliCocukSayisi);
                            sb.AppendLine("Çocuk Sayııs :" + item.dogumRapor.cocukSayisi);
                            sb.AppendLine("Doğum Tipi :" + item.dogumRapor.dogumTipi);
                            sb.AppendLine("Epizyotemi :" + item.dogumRapor.epizyotemi);
                            sb.AppendLine("Açıklama :" + item.dogumRapor.raporDVO.aciklama);
                            sb.AppendLine("Başlangıç Tarihi :" + item.dogumRapor.raporDVO.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + item.dogumRapor.raporDVO.bitisTarihi);
                            sb.AppendLine("Takip Numarası :" + item.dogumRapor.raporDVO.takipNo);
                            sb.AppendLine("Türü :" + item.dogumRapor.raporDVO.turu);

                            if (item.dogumRapor.cocuklar != null)
                            {
                                sb.AppendLine("------------------------------Çocuk Bilgisi-------------------------------");
                                foreach (RaporIslemleri.cocukBilgisiDVO _cocuk in item.dogumRapor.cocuklar)
                                {


                                    sb.AppendLine("Cinsiyeti :" + _cocuk.cinsiyet);
                                    sb.AppendLine("Doğum Saati :" + _cocuk.dogumSaati);
                                    sb.AppendLine("Kilo :" + _cocuk.kilo);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                            }

                            if (item.dogumRapor.raporDVO.doktorlar != null)
                            {
                                sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                                foreach (RaporIslemleri.doktorBilgisiDVO _doktor in item.dogumRapor.raporDVO.doktorlar)
                                {
                                    sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                    sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                    
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }



                            sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Klinik Tanı :" + item.dogumRapor.raporDVO.klinikTani);
                            sb.AppendLine("Protokol Numarası :" + item.dogumRapor.raporDVO.protokolNo);
                            sb.AppendLine("Protokol Tarihi :" + item.dogumRapor.raporDVO.protokolTarihi);
                            sb.AppendLine("aVakaTKaza :" + item.dogumRapor.raporDVO.raporBilgisi.aVakaTKaza);
                            sb.AppendLine("Rapor Numarası :" + item.dogumRapor.raporDVO.raporBilgisi.no);
                            sb.AppendLine("Rapor Sıra Numarası :" + item.dogumRapor.raporDVO.raporBilgisi.raporSiraNo);
                            sb.AppendLine("Rapor Takip Numarası :" + item.dogumRapor.raporDVO.raporBilgisi.raporTakipNo);
                            sb.AppendLine("Rapor Tesis Kodu :" + item.dogumRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.dogumRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.dogumRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString());
                            sb.AppendLine("Tarih :" + item.dogumRapor.raporDVO.raporBilgisi.tarih);
                            sb.AppendLine("-----------------------------------------------------------------------------");

                            if (item.dogumRapor.raporDVO.tanilar != null)
                            {
                                sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                RaporIslemleri.taniBilgisiDVO[] _tani = item.dogumRapor.raporDVO.tanilar;
                                for (int i = 0; i < _tani.Length; i++)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                                }

                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }

                            if (item.dogumRapor.raporDVO.teshisler != null)
                            {
                                sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.teshisBilgisiDVO _teshis in item.dogumRapor.raporDVO.teshisler)
                                {

                                    sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                    sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            if (item.dogumRapor.raporDVO.ilacTeshisler != null)
                            {
                                sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in item.dogumRapor.raporDVO.ilacTeshisler)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                    sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                    sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }


                            #endregion
                        }
                        if (item.ilacRapor != null && item.ilacRapor.raporDVO != null)
                        {
                            sb.AppendLine("-----------------------------İLAÇ RAPOR BİLGİSİ------------------------------");
                            sb.AppendLine("-------------------------------------------------------------------------------");
                            #region IlacRaporDVO

                            sb.AppendLine("Takip Formu Numarası :" + item.ilacRapor.takipFormuNo);
                            sb.AppendLine("Açıklama :" + item.ilacRapor.raporDVO.aciklama);
                            sb.AppendLine("Başlangıç Tarihi :" + item.ilacRapor.raporDVO.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + item.ilacRapor.raporDVO.bitisTarihi);
                            sb.AppendLine("Takip Numarası :" + item.ilacRapor.raporDVO.takipNo);
                            sb.AppendLine("Türü :" + item.ilacRapor.raporDVO.turu);

                            if (item.ilacRapor.raporEtkinMaddeler != null)
                            {
                                sb.AppendLine("--------------------------Rapor Etkin Madde Listesi---------------------------");
                                foreach (RaporIslemleri.raporEtkinMaddeDVO _etkinMadde in item.ilacRapor.raporEtkinMaddeler)
                                {

                                    sb.AppendLine("Etkin Madde Kodu :" + _etkinMadde.etkinMaddeKodu);
                                    sb.AppendLine("Kullanım Doz 1 :" + _etkinMadde.kullanimDoz1);
                                    sb.AppendLine("Kullanım Doz 2 :" + _etkinMadde.kullanimDoz2);
                                    sb.AppendLine("Kullanım Doz Birimi :" + _etkinMadde.kullanimDozBirim);
                                    sb.AppendLine("Kullanım Periyot :" + _etkinMadde.kullanimPeriyot);
                                    sb.AppendLine("Kullanım Periyot Birim :" + _etkinMadde.kullanimPeriyotBirim);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                            }

                            if (item.ilacRapor.raporDVO.doktorlar != null)
                            {
                                sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                                foreach (RaporIslemleri.doktorBilgisiDVO _doktor in item.ilacRapor.raporDVO.doktorlar)
                                {
                                    sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                    sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                    
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }

                            }

                            sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Klinik Tanı :" + item.ilacRapor.raporDVO.klinikTani);
                            sb.AppendLine("Protokol Numarası :" + item.ilacRapor.raporDVO.protokolNo);
                            sb.AppendLine("Protokol Tarihi :" + item.ilacRapor.raporDVO.protokolTarihi);
                            sb.AppendLine("aVakaTKaza :" + item.ilacRapor.raporDVO.raporBilgisi.aVakaTKaza);
                            sb.AppendLine("Rapor Numarası :" + item.ilacRapor.raporDVO.raporBilgisi.no);
                            sb.AppendLine("Rapor Sıra Numarası :" + item.ilacRapor.raporDVO.raporBilgisi.raporSiraNo);
                            sb.AppendLine("Rapor Takip Numarası :" + item.ilacRapor.raporDVO.raporBilgisi.raporTakipNo);
                            sb.AppendLine("Rapor Tesis Kodu :" + item.ilacRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.ilacRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.ilacRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString());
                            sb.AppendLine("Tarih :" + item.ilacRapor.raporDVO.raporBilgisi.tarih);
                            sb.AppendLine("-----------------------------------------------------------------------------");


                            if (item.ilacRapor.raporDVO.tanilar != null)
                            {
                                sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                RaporIslemleri.taniBilgisiDVO[] _tani = item.ilacRapor.raporDVO.tanilar;
                                for (int i = 0; i < _tani.Length; i++)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                                }

                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }



                            if (item.ilacRapor.raporDVO.teshisler != null)
                            {
                                sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.teshisBilgisiDVO _teshis in item.ilacRapor.raporDVO.teshisler)
                                {

                                    sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                    sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            if (item.ilacRapor.raporDVO.ilacTeshisler != null)
                            {
                                sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in item.ilacRapor.raporDVO.ilacTeshisler)
                                {
                                    if(_ilacTeshis.ICD10Kodu != null)
                                    {
                                        string taniBilgi = string.Empty;
                                        foreach(RaporIslemleri.taniBilgisiDVO tani in _ilacTeshis.ICD10Kodu)
                                        {
                                            taniBilgi +=  tani.taniKodu ;
                                        }
                                        sb.AppendLine("Tanı Kodu :" + taniBilgi);
                                    }
                                    sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                    sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }



                            #endregion
                        }
                        if (item.isgoremezlikRapor != null && item.isgoremezlikRapor.raporDVO != null)
                        {
                            sb.AppendLine("-----------------------------İŞ GÖREMEZLİK RAPOR BİLGİSİ------------------------------");
                            sb.AppendLine("-------------------------------------------------------------------------------");
                            #region IsgoremezlikRaporDVO

                            sb.AppendLine("Branş Kodu :" + item.isgoremezlikRapor.bransKodu);
                            sb.AppendLine("Devam Durumu :" + item.isgoremezlikRapor.devammi);
                            sb.AppendLine("İş Göremezlik Rapor Türü :" + item.isgoremezlikRapor.isGoremezlikRaporTuru);
                            sb.AppendLine("Karar :" + item.isgoremezlikRapor.karar);
                            sb.AppendLine("Klink Bulgu :" + item.isgoremezlikRapor.klinikBulgu);
                            sb.AppendLine("Ölüm :" + item.isgoremezlikRapor.olum);
                            sb.AppendLine("ronLabBilgileri :" + item.isgoremezlikRapor.ronLabBilgi);
                            sb.AppendLine("Teşhis :" + item.isgoremezlikRapor.teshis);
                            sb.AppendLine("Yatış Durumu :" + item.isgoremezlikRapor.yatisDevam);

                            if (item.isgoremezlikRapor.analikRaporu != null)
                            {
                                sb.AppendLine("------------------------------Analık Raporu--------------------------------");
                                sb.AppendLine("Aktarma Haftası :" + item.isgoremezlikRapor.analikRaporu.aktarmaHaftasi);
                                sb.AppendLine("Analık Rapor Tipi :" + item.isgoremezlikRapor.analikRaporu.analikRaporTipi);
                                sb.AppendLine("Başlangıç Tarihi :" + item.isgoremezlikRapor.analikRaporu.baslangicTarihi);
                                sb.AppendLine("Bebek Doğum Haftası :" + item.isgoremezlikRapor.analikRaporu.bebekDogumHaftasi);
                                sb.AppendLine("Bebek Doğum Tarihi :" + item.isgoremezlikRapor.analikRaporu.bebekDogumTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + item.isgoremezlikRapor.analikRaporu.bitisTarihi);
                                sb.AppendLine("Canlı Çocuk Sayısı :" + item.isgoremezlikRapor.analikRaporu.canliCocukSayisi);
                                sb.AppendLine("Doğan Çocuk Sayısı :" + item.isgoremezlikRapor.analikRaporu.doganCocukSayisi);
                                sb.AppendLine("Gebelik Haftası 1 :" + item.isgoremezlikRapor.analikRaporu.gebelikHaftasi1);
                                sb.AppendLine("Gebelik Haftası 2 :" + item.isgoremezlikRapor.analikRaporu.gebelikHaftasi2);
                                sb.AppendLine("Gebelik Tipi :" + item.isgoremezlikRapor.analikRaporu.gebelikTipi);
                                sb.AppendLine("XXXXXX Çıkış tarihi :" + item.isgoremezlikRapor.analikRaporu.XXXXXXCikisTarihi);
                                sb.AppendLine("XXXXXX Yatış Tarihi :" + item.isgoremezlikRapor.analikRaporu.XXXXXXYatisTarihi);
                                sb.AppendLine("İş-KOntrol Tarihi :" + item.isgoremezlikRapor.analikRaporu.isKontTarihi);
                                sb.AppendLine("Normal Sezeryan Forsebs Dogum Çeşidi :" + item.isgoremezlikRapor.analikRaporu.norSezFor);
                                sb.AppendLine("Rapor Durumu :" + item.isgoremezlikRapor.analikRaporu.raporDurumu);
                                sb.AppendLine("Taburcu Kodu :" + item.isgoremezlikRapor.analikRaporu.taburcuKodu);
                                sb.AppendLine("Taburcu Tarihi :" + item.isgoremezlikRapor.analikRaporu.taburcuTarihi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                            if (item.isgoremezlikRapor.emzirmeRaporu != null)
                            {
                                sb.AppendLine("------------------------------Hastalık Raporu--------------------------------");
                                sb.AppendLine("Anne Kimlik Numarası :" + item.isgoremezlikRapor.emzirmeRaporu.anneTcKimlikNo);
                                sb.AppendLine("Bebek Doğum Tarihi :" + item.isgoremezlikRapor.emzirmeRaporu.bebekDogumTarihi);
                                sb.AppendLine("Canlı Çocuk Sayısı :" + item.isgoremezlikRapor.emzirmeRaporu.canliCocukSayisi);
                                sb.AppendLine("Doğan Çocuk Sayısı :" + item.isgoremezlikRapor.emzirmeRaporu.doganCocukSayisi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                            if (item.isgoremezlikRapor.hastalikRaporu != null)
                            {
                                sb.AppendLine("------------------------------Hastalık Raporu--------------------------------");
                                sb.AppendLine("Başlangıç Tarihi :" + item.isgoremezlikRapor.hastalikRaporu.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + item.isgoremezlikRapor.hastalikRaporu.bitisTarihi);
                                sb.AppendLine("XXXXXX Çıkış Tarihi :" + item.isgoremezlikRapor.hastalikRaporu.XXXXXXCikisTarihi);
                                sb.AppendLine("XXXXXX Yatış Tarihi :" + item.isgoremezlikRapor.hastalikRaporu.XXXXXXYatisTarihi);
                                sb.AppendLine("İş-Kontol Tarihi :" + item.isgoremezlikRapor.hastalikRaporu.isKontTarihi);
                                sb.AppendLine("Nuks :" + item.isgoremezlikRapor.hastalikRaporu.nuks);
                                sb.AppendLine("Rapor Durumu :" + item.isgoremezlikRapor.hastalikRaporu.raporDurumu);
                                sb.AppendLine("Taburcu Kodu :" + item.isgoremezlikRapor.hastalikRaporu.taburcuKodu);
                                sb.AppendLine("Taburcu Tarihi :" + item.isgoremezlikRapor.hastalikRaporu.taburcuTarihi);

                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                            if (item.isgoremezlikRapor.isKazasiRaporu != null)
                            {
                                sb.AppendLine("------------------------------İş Kazası Raporu--------------------------------");
                                sb.AppendLine("Başlangıç Tarihi :" + item.isgoremezlikRapor.isKazasiRaporu.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + item.isgoremezlikRapor.isKazasiRaporu.bitisTarihi);
                                sb.AppendLine("XXXXXX Çıkış Tarihi :" + item.isgoremezlikRapor.isKazasiRaporu.XXXXXXCikisTarihi);
                                sb.AppendLine("XXXXXX Yatış Tarihi :" + item.isgoremezlikRapor.isKazasiRaporu.XXXXXXYatisTarihi);
                                sb.AppendLine("İş Kazası Tarihi :" + item.isgoremezlikRapor.isKazasiRaporu.isKazasiTarihi);
                                sb.AppendLine("İş-Kontol Tarihi :" + item.isgoremezlikRapor.meslekHastaligiRaporu.isKontTarihi);
                                sb.AppendLine("Nuks :" + item.isgoremezlikRapor.isKazasiRaporu.nuks);
                                sb.AppendLine("Rapor Durumu :" + item.isgoremezlikRapor.isKazasiRaporu.raporDurumu);
                                sb.AppendLine("Taburcu Kodu :" + item.isgoremezlikRapor.isKazasiRaporu.taburcuKodu);
                                sb.AppendLine("Taburcu Tarihi :" + item.isgoremezlikRapor.isKazasiRaporu.taburcuTarihi);
                                sb.AppendLine("Yaranın Türü :" + item.isgoremezlikRapor.isKazasiRaporu.yaraninTuru);
                                sb.AppendLine("Yaranın Yeri :" + item.isgoremezlikRapor.isKazasiRaporu.yaraninYeri);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                            if (item.isgoremezlikRapor.meslekHastaligiRaporu != null)
                            {
                                sb.AppendLine("------------------------------Meslek Hastalığı Raporu--------------------------------");
                                sb.AppendLine("Başlangıç Tarihi :" + item.isgoremezlikRapor.meslekHastaligiRaporu.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + item.isgoremezlikRapor.meslekHastaligiRaporu.bitisTarihi);
                                sb.AppendLine("XXXXXX Çıkış Tarihi :" + item.isgoremezlikRapor.meslekHastaligiRaporu.XXXXXXCikisTarihi);
                                sb.AppendLine("XXXXXX Yatış Tarihi :" + item.isgoremezlikRapor.meslekHastaligiRaporu.XXXXXXYatisTarihi);
                                sb.AppendLine("İş-Kontol Tarihi :" + item.isgoremezlikRapor.meslekHastaligiRaporu.isKontTarihi);
                                sb.AppendLine("Nuks :" + item.isgoremezlikRapor.meslekHastaligiRaporu.nuks);
                                sb.AppendLine("Rapor Durumu :" + item.isgoremezlikRapor.meslekHastaligiRaporu.raporDurumu);
                                sb.AppendLine("Taburcu Kodu :" + item.isgoremezlikRapor.meslekHastaligiRaporu.taburcuKodu);
                                sb.AppendLine("Taburcu Tarihi :" + item.isgoremezlikRapor.meslekHastaligiRaporu.taburcuTarihi);
                                sb.AppendLine("Yaranın Türü :" + item.isgoremezlikRapor.meslekHastaligiRaporu.yaraninTuru);
                                sb.AppendLine("Yaranın Yeri :" + item.isgoremezlikRapor.meslekHastaligiRaporu.yaraninYeri);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }

                            sb.AppendLine("Açıklama :" + item.isgoremezlikRapor.raporDVO.aciklama);
                            sb.AppendLine("Başlangıç Tarihi :" + item.isgoremezlikRapor.raporDVO.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + item.isgoremezlikRapor.raporDVO.bitisTarihi);
                            sb.AppendLine("Takip Numarası :" + item.isgoremezlikRapor.raporDVO.takipNo);
                            sb.AppendLine("Türü :" + item.isgoremezlikRapor.raporDVO.turu);

                            if (item.isgoremezlikRapor.raporDVO.doktorlar != null)
                            {
                                sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");

                                foreach (RaporIslemleri.doktorBilgisiDVO _doktor in item.isgoremezlikRapor.raporDVO.doktorlar)
                                {
                                    sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                    sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                    
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }



                            sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Klinik Tanı :" + item.isgoremezlikRapor.raporDVO.klinikTani);
                            sb.AppendLine("Protokol Numarası :" + item.isgoremezlikRapor.raporDVO.protokolNo);
                            sb.AppendLine("Protokol Tarihi :" + item.isgoremezlikRapor.raporDVO.protokolTarihi);
                            sb.AppendLine("aVakaTKaza :" + item.isgoremezlikRapor.raporDVO.raporBilgisi.aVakaTKaza);
                            sb.AppendLine("Rapor Numarası :" + item.isgoremezlikRapor.raporDVO.raporBilgisi.no);
                            sb.AppendLine("Rapor Sıra Numarası :" + item.isgoremezlikRapor.raporDVO.raporBilgisi.raporSiraNo);
                            sb.AppendLine("Rapor Takip Numarası :" + item.isgoremezlikRapor.raporDVO.raporBilgisi.raporTakipNo);
                            sb.AppendLine("Rapor Tesis Kodu :" + item.isgoremezlikRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.isgoremezlikRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.isgoremezlikRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString());
                            sb.AppendLine("Tarih :" + item.isgoremezlikRapor.raporDVO.raporBilgisi.tarih);
                            sb.AppendLine("-----------------------------------------------------------------------------");

                            if (item.isgoremezlikRapor.raporDVO.tanilar != null)
                            {
                                sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                RaporIslemleri.taniBilgisiDVO[] _tani = item.isgoremezlikRapor.raporDVO.tanilar;
                                for (int i = 0; i < _tani.Length; i++)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                                }

                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }

                            if (item.isgoremezlikRapor.raporDVO.teshisler != null)
                            {
                                sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.teshisBilgisiDVO _teshis in item.isgoremezlikRapor.raporDVO.teshisler)
                                {

                                    sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                    sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            if (item.isgoremezlikRapor.raporDVO.ilacTeshisler != null)
                            {
                                sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in item.isgoremezlikRapor.raporDVO.ilacTeshisler)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                    sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                    sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }


                            #endregion

                        }
                        if (item.isgoremezlikRaporEkleri != null)
                        {
                            sb.AppendLine("-----------------------------İŞ GÖREMEZLİK RAPOR EK BİLGİSİ------------------------------");
                            sb.AppendLine("-------------------------------------------------------------------------------");
                            #region IsgoremezlikRaporEkDVO

                            foreach (RaporIslemleri.isgoremezlikRaporEkDVO _ek in item.isgoremezlikRaporEkleri)
                            {

                                sb.AppendLine("Açıklama :" + _ek.aciklama);
                                sb.AppendLine("Bitiş Tarihi:" + _ek.bitisTarihi);
                                if (_ek.doktorlar != null)
                                {
                                    sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                                    foreach (RaporIslemleri.doktorBilgisiDVO _doktor in _ek.doktorlar)
                                    {
                                        sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                        sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                        
                                        sb.AppendLine("-----------------------------------------------------------------------------");
                                    }
                                }

                                sb.AppendLine("Durum :" + _ek.durum);
                                sb.AppendLine("Düzenleme Türü :" + _ek.duzenlemeTuru);
                                sb.AppendLine("Hasta Yatış Varmı :" + _ek.hastaYatisVarMi);
                                sb.AppendLine("Kontrol Mu? :" + _ek.kontrolMu);
                                sb.AppendLine("Kontrol Tarihi :" + _ek.kontrolTarihi);
                                sb.AppendLine("Kullanıcı Tesis Kodu :" + _ek.kullaniciTesisKodu);
                                sb.AppendLine("Protokol Numarası :" + _ek.protokolNo);
                                sb.AppendLine("Protokol tarihi :" + _ek.protokolTarihi);


                                sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                                sb.AppendLine("aVakaTKaza :" + _ek.raporBilgisiDVO.aVakaTKaza);
                                sb.AppendLine("Rapor Numarası :" + _ek.raporBilgisiDVO.no);
                                sb.AppendLine("Rapor Sıra Numarası :" + _ek.raporBilgisiDVO.raporSiraNo);
                                sb.AppendLine("Rapor Takip Numarası :" + _ek.raporBilgisiDVO.raporTakipNo);
                                sb.AppendLine("Rapor Tesis Kodu :" + _ek.raporBilgisiDVO.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(_ek.raporBilgisiDVO.raporTesisKodu.ToString()) : _ek.raporBilgisiDVO.raporTesisKodu.ToString());
                                sb.AppendLine("Tarih :" + _ek.raporBilgisiDVO.tarih);
                                sb.AppendLine("-----------------------------------------------------------------------------");

                                if (_ek.tanilar != null)
                                {
                                    sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                    foreach (RaporIslemleri.taniBilgisiDVO _tani in _ek.tanilar)
                                    {

                                        sb.AppendLine("tanı Kodu :" + _tani.taniKodu);
                                        sb.AppendLine("-----------------------------------------------------------------------------");
                                    }
                                }
                                if (_ek.yatislar != null)
                                {
                                    sb.AppendLine("------------------------------XXXXXX Yatış Bilgisi--------------------------------");
                                    foreach (RaporIslemleri.hastaYatisBilgisiDVO _yatis in _ek.yatislar)
                                    {

                                        sb.AppendLine("Çıkış Tarihi :" + _yatis.cikisTarihi);
                                        sb.AppendLine("Yatiş Tarihi :" + _yatis.yatisTarihi);
                                        sb.AppendLine("-----------------------------------------------------------------------------");
                                    }
                                }

                            }

                            #endregion
                        }
                        if (item.maluliyetRapor != null && item.maluliyetRapor.raporDVO != null)
                        {
                            sb.AppendLine("-----------------------------MALULİYET RAPOR BİLGİSİ------------------------------");
                            sb.AppendLine("-------------------------------------------------------------------------------");
                            #region MaluliyetRaporDVO

                            sb.AppendLine("Açıklama :" + item.maluliyetRapor.aciklama);
                            //sb.AppendLine("Maluliyet Yüzdesi :" + item.maluliyetRapor.maluliyetYuzdesi);
                            sb.AppendLine("Açıklama :" + item.maluliyetRapor.raporDVO.aciklama);
                            sb.AppendLine("Başlangıç Tarihi :" + item.maluliyetRapor.raporDVO.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + item.maluliyetRapor.raporDVO.bitisTarihi);
                            sb.AppendLine("Takip Numarası :" + item.maluliyetRapor.raporDVO.takipNo);
                            sb.AppendLine("Türü :" + item.maluliyetRapor.raporDVO.turu);

                            if (item.maluliyetRapor.bransGorusleri != null)
                            {
                                sb.AppendLine("------------------------------Branş Doktor Bilgisi--------------------------------");
                                foreach (RaporIslemleri.bransGorusBilgisiDVO _bransGorus in item.maluliyetRapor.bransGorusleri)
                                {

                                    sb.AppendLine("Açıklama :" + _bransGorus.aciklama);
                                    sb.AppendLine("Branş Kodu :" + _bransGorus.bransKodu);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                            }


                            if (item.maluliyetRapor.raporDVO.doktorlar != null)
                            {
                                sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                                foreach (RaporIslemleri.doktorBilgisiDVO _doktor in item.maluliyetRapor.raporDVO.doktorlar)
                                {
                                    sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                    sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                    
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }


                            sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Klinik Tanı :" + item.maluliyetRapor.raporDVO.klinikTani);
                            sb.AppendLine("Protokol Numarası :" + item.maluliyetRapor.raporDVO.protokolNo);
                            sb.AppendLine("Protokol Tarihi :" + item.maluliyetRapor.raporDVO.protokolTarihi);
                            sb.AppendLine("aVakaTKaza :" + item.maluliyetRapor.raporDVO.raporBilgisi.aVakaTKaza);
                            sb.AppendLine("Rapor Numarası :" + item.maluliyetRapor.raporDVO.raporBilgisi.no);
                            sb.AppendLine("Rapor Sıra Numarası :" + item.maluliyetRapor.raporDVO.raporBilgisi.raporSiraNo);
                            sb.AppendLine("Rapor Takip Numarası :" + item.maluliyetRapor.raporDVO.raporBilgisi.raporTakipNo);
                            sb.AppendLine("Rapor Tesis Kodu :" + item.maluliyetRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.maluliyetRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.maluliyetRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString());
                            sb.AppendLine("Tarih :" + item.maluliyetRapor.raporDVO.raporBilgisi.tarih);
                            sb.AppendLine("-----------------------------------------------------------------------------");

                            if (item.maluliyetRapor.raporDVO.tanilar != null)
                            {
                                sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                RaporIslemleri.taniBilgisiDVO[] _tani = item.maluliyetRapor.raporDVO.tanilar;
                                for (int i = 0; i < _tani.Length; i++)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                                }

                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }

                            if (item.maluliyetRapor.raporDVO.teshisler != null)
                            {
                                sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.teshisBilgisiDVO _teshis in item.maluliyetRapor.raporDVO.teshisler)
                                {

                                    sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                    sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            if (item.maluliyetRapor.raporDVO.ilacTeshisler != null)
                            {
                                sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in item.maluliyetRapor.raporDVO.ilacTeshisler)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                    sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                    sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            #endregion

                        }
                        if (item.protezRapor != null)
                        {
                            sb.AppendLine("-----------------------------PROTEZ RAPOR BİLGİSİ------------------------------");
                            sb.AppendLine("-------------------------------------------------------------------------------");
                            #region ProtezRaporDVO

                            if (item.protezRapor.malzemeler != null)
                            {
                                sb.AppendLine("------------------------------Mazleme Bilgisi--------------------------------");
                                foreach (RaporIslemleri.malzemeBilgisiDVO _mazleme in item.protezRapor.malzemeler)
                                {

                                    sb.AppendLine("Adet :" + _mazleme.adet);
                                    sb.AppendLine("Mazleme Adı :" + _mazleme.malzemeAdi);
                                    sb.AppendLine("Mazleme Kodu :" + _mazleme.malzemeKodu);
                                    sb.AppendLine("Malzeme Türü :" + _mazleme.malzemeTuru);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                            }

                            sb.AppendLine("Açıklama :" + item.protezRapor.raporDVO.aciklama);
                            sb.AppendLine("Başlangıç Tarihi :" + item.protezRapor.raporDVO.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + item.protezRapor.raporDVO.bitisTarihi);
                            sb.AppendLine("Takip Numarası :" + item.protezRapor.raporDVO.takipNo);
                            sb.AppendLine("Türü :" + item.protezRapor.raporDVO.turu);

                            if (item.protezRapor.raporDVO.doktorlar != null)
                            {
                                sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                                foreach (RaporIslemleri.doktorBilgisiDVO _doktor in item.protezRapor.raporDVO.doktorlar)
                                {
                                    sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                    sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                    
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }


                            sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Klinik Tanı :" + item.protezRapor.raporDVO.klinikTani);
                            sb.AppendLine("Protokol Numarası :" + item.protezRapor.raporDVO.protokolNo);
                            sb.AppendLine("Protokol Tarihi :" + item.protezRapor.raporDVO.protokolTarihi);
                            sb.AppendLine("aVakaTKaza :" + item.protezRapor.raporDVO.raporBilgisi.aVakaTKaza);
                            sb.AppendLine("Rapor Numarası :" + item.protezRapor.raporDVO.raporBilgisi.no);
                            sb.AppendLine("Rapor Sıra Numarası :" + item.protezRapor.raporDVO.raporBilgisi.raporSiraNo);
                            sb.AppendLine("Rapor Takip Numarası :" + item.protezRapor.raporDVO.raporBilgisi.raporTakipNo);
                            sb.AppendLine("Rapor Tesis Kodu :" + item.protezRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.protezRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.protezRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString());
                            sb.AppendLine("Tarih :" + item.protezRapor.raporDVO.raporBilgisi.tarih);
                            sb.AppendLine("-----------------------------------------------------------------------------");

                            if (item.protezRapor.raporDVO.tanilar != null)
                            {
                                sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                RaporIslemleri.taniBilgisiDVO[] _tani = item.protezRapor.raporDVO.tanilar;
                                for (int i = 0; i < _tani.Length; i++)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                                }

                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }

                            if (item.protezRapor.raporDVO.teshisler != null)
                            {
                                sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.teshisBilgisiDVO _teshis in item.protezRapor.raporDVO.teshisler)
                                {

                                    sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                    sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            if (item.protezRapor.raporDVO.ilacTeshisler != null)
                            {
                                sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in item.protezRapor.raporDVO.ilacTeshisler)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                    sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                    sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            #endregion
                        }
                        if (item.tedaviRapor != null)
                        {
                            sb.AppendLine("-----------------------------TEDAVİ RAPOR BİLGİSİ------------------------------");
                            sb.AppendLine("-------------------------------------------------------------------------------");
                            #region TedaviRaporDVO

                            sb.AppendLine("Tedavi Rapor Türü :" + item.tedaviRapor.tedaviRaporTuru);

                            foreach (RaporIslemleri.tedaviIslemBilgisiDVO _tedavi in item.tedaviRapor.islemler)
                            {

                                if (_tedavi.diyalizRaporBilgisi != null)
                                {
                                    sb.AppendLine("------------------------------Diyaliz Rapor Bilgisi--------------------------------");
                                    sb.AppendLine("Tetkik Kodu :" + _tedavi.diyalizRaporBilgisi.butKodu);
                                    sb.AppendLine("Refakat var Mı? :" + _tedavi.diyalizRaporBilgisi.refakatVarMi);
                                    sb.AppendLine("Seans Gün :" + _tedavi.diyalizRaporBilgisi.seansGun);
                                    sb.AppendLine("Seans Sayısı :" + _tedavi.diyalizRaporBilgisi.seansSayi);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                                if (_tedavi.eswlRaporBilgisi != null)
                                {
                                    sb.AppendLine("------------------------------ESWL Rapor Bilgisi--------------------------------");
                                    sb.AppendLine("Böbrek Bilgisi :" + _tedavi.eswlRaporBilgisi.bobrekBilgisi);
                                    sb.AppendLine("Tetkik Kodu :" + _tedavi.eswlRaporBilgisi.butKodu);
                                    sb.AppendLine("ESWL Raporu Seans Sayısı :" + _tedavi.eswlRaporBilgisi.eswlRaporuSeansSayisi);
                                    sb.AppendLine("ESWL Raporu Taş Sayısı :" + _tedavi.eswlRaporBilgisi.eswlRaporuTasSayisi);
                                    if (_tedavi.eswlRaporBilgisi.eswlRaporuTasBilgileri != null)
                                    {
                                        sb.AppendLine("------------------------------ESWL Taş Bilgisi--------------------------------");
                                        foreach (RaporIslemleri.eswlTasBilgisiDVO _tasBilgisi in _tedavi.eswlRaporBilgisi.eswlRaporuTasBilgileri)
                                        {

                                            sb.AppendLine("Taş Boyutu :" + _tasBilgisi.tasBoyutu);
                                            sb.AppendLine("Taş Lokalizasyon Kodu :" + _tasBilgisi.tasLokalizasyonKodu);
                                            sb.AppendLine("-------------------------------------------------------------------------------");
                                        }
                                    }

                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                                if (_tedavi.eswtRaporBilgisi != null)
                                {
                                    sb.AppendLine("------------------------------ESWL Taş Bilgisi--------------------------------");
                                    sb.AppendLine("Tetkik Kodu :" + _tedavi.eswtRaporBilgisi.butKodu);
                                    sb.AppendLine("ESWT Vucut Bölgesi Kodu :" + _tedavi.eswtRaporBilgisi.eswtVucutBolgesiKodu);
                                    sb.AppendLine("Seans Gün Sayısı :" + _tedavi.eswtRaporBilgisi.seansGun);
                                    sb.AppendLine("Seans Sayısı :" + _tedavi.eswtRaporBilgisi.seansSayi);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                                if (_tedavi.evHemodiyaliziRaporBilgisi != null)
                                {
                                    sb.AppendLine("------------------------------Hemodiyaliz Rapor Bilgisi--------------------------------");
                                    sb.AppendLine("Tetkik Kodu :" + _tedavi.evHemodiyaliziRaporBilgisi.butKodu);
                                    sb.AppendLine("Seans Gün Sayısı :" + _tedavi.evHemodiyaliziRaporBilgisi.seansGun);
                                    sb.AppendLine("Seans Sayısı :" + _tedavi.evHemodiyaliziRaporBilgisi.seansSayi);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                                if (_tedavi.ftrRaporBilgisi != null)
                                {
                                    sb.AppendLine("------------------------------FTR Rapor Bilgisi--------------------------------");
                                    sb.AppendLine("Tetkik Kodu :" + _tedavi.ftrRaporBilgisi.butKodu);
                                    sb.AppendLine("FTR Vucut Bölgesi Kodu :" + _tedavi.ftrRaporBilgisi.ftrVucutBolgesiKodu);
                                    sb.AppendLine("Robotik Rehabilitasyon :" + _tedavi.ftrRaporBilgisi.robotikRehabilitasyon);
                                    sb.AppendLine("Seans Gün Sayısı :" + _tedavi.ftrRaporBilgisi.seansGun);
                                    sb.AppendLine("Seans Sayısı :" + _tedavi.ftrRaporBilgisi.seansSayi);
                                    sb.AppendLine("Tedavi Türü :" + _tedavi.ftrRaporBilgisi.tedaviTuru);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                                if (_tedavi.hotRaporBilgisi != null)
                                {
                                    sb.AppendLine("------------------------------HOT Rapor Bilgisi--------------------------------");
                                    sb.AppendLine("Seans Gün Sayısı :" + _tedavi.hotRaporBilgisi.seansGun);
                                    sb.AppendLine("Seans Sayısı :" + _tedavi.hotRaporBilgisi.seansSayi);
                                    sb.AppendLine("Tedavi Süresi :" + _tedavi.hotRaporBilgisi.tedaviSuresi);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                                if (_tedavi.tupBebekRaporBilgisi != null)
                                {
                                    sb.AppendLine("------------------------------Tüp Bebek Rapor Bilgisi--------------------------------");
                                    sb.AppendLine("Tetkik Kodu  :" + _tedavi.tupBebekRaporBilgisi.butKodu);
                                    sb.AppendLine("Tüp Bebek Rapor Türü :" + _tedavi.tupBebekRaporBilgisi.tupBebekRaporTuru);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }

                            }


                            sb.AppendLine("Açıklama :" + item.tedaviRapor.raporDVO.aciklama);
                            sb.AppendLine("Başlangıç Tarihi :" + item.tedaviRapor.raporDVO.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + item.tedaviRapor.raporDVO.bitisTarihi);
                            sb.AppendLine("Takip Numarası :" + item.tedaviRapor.raporDVO.takipNo);
                            sb.AppendLine("Türü :" + item.tedaviRapor.raporDVO.turu);

                            if (item.tedaviRapor.raporDVO.doktorlar != null)
                            {
                                sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                                foreach (RaporIslemleri.doktorBilgisiDVO _doktor in item.tedaviRapor.raporDVO.doktorlar)
                                {
                                    sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                    sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                    
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }


                            sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Klinik Tanı :" + item.tedaviRapor.raporDVO.klinikTani);
                            sb.AppendLine("Protokol Numarası :" + item.tedaviRapor.raporDVO.protokolNo);
                            sb.AppendLine("Protokol Tarihi :" + item.tedaviRapor.raporDVO.protokolTarihi);
                            sb.AppendLine("aVakaTKaza :" + item.tedaviRapor.raporDVO.raporBilgisi.aVakaTKaza);
                            sb.AppendLine("Rapor Numarası :" + item.tedaviRapor.raporDVO.raporBilgisi.no);
                            sb.AppendLine("Rapor Sıra Numarası :" + item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo);
                            sb.AppendLine("Rapor Takip Numarası :" + item.tedaviRapor.raporDVO.raporBilgisi.raporTakipNo);
                            sb.AppendLine("Rapor Tesis Kodu :" +  item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString());
                            sb.AppendLine("Tarih :" + item.tedaviRapor.raporDVO.raporBilgisi.tarih);
                            sb.AppendLine("-----------------------------------------------------------------------------");

                            if (item.tedaviRapor.raporDVO.tanilar != null)
                            {
                                sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                RaporIslemleri.taniBilgisiDVO[] _tani = item.tedaviRapor.raporDVO.tanilar;
                                for (int i = 0; i < _tani.Length; i++)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                                }

                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }

                            if (item.tedaviRapor.raporDVO.teshisler != null)
                            {
                                sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.teshisBilgisiDVO _teshis in item.tedaviRapor.raporDVO.teshisler)
                                {

                                    sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                    sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            if (item.tedaviRapor.raporDVO.ilacTeshisler != null)
                            {
                                sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                                foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in item.tedaviRapor.raporDVO.ilacTeshisler)
                                {
                                    sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                    sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                    sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                    sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }
                            #endregion
                        }
                    }
                    txtResult.Visible = true;
                    txtResult.Text = sb.ToString();
                    if(string.IsNullOrEmpty(txtResult.Text))
                        txtResult.Text="Rapor Bilgisi Mevcut Değildir";
                }
            }
#endregion MedulaRaporIslemleri_btnSearchTCKNo_Click
        }

        private void btnSearchChasing_Click()
        {
#region MedulaRaporIslemleri_btnSearchChasing_Click
   txtResult.Visible = false;
            txtResult.Text = "";
            RaporIslemleri.raporOkuRaporTakipNodanDVO _raporOkuRaporTakipNodanDVO = new RaporIslemleri.raporOkuRaporTakipNodanDVO();
            //TODO : MEDULA20140501
            _raporOkuRaporTakipNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            _raporOkuRaporTakipNodanDVO.raporSiraNo = "";
            _raporOkuRaporTakipNodanDVO.raporTakipNo = txtReportChasing.Text.Trim();
            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiBulRaporTakipNodanSync(Sites.SiteLocalHost, _raporOkuRaporTakipNodanDVO);
            StringBuilder sb = new StringBuilder();
            if (response != null)
            {
                if (!response.sonucKodu.Equals(0))
                {
                    if(response.sonucKodu.Equals(5005))
                    {
                        txtResult.Visible = true;
                        txtResult.Text = "Bu servis sadece tedavi ve ilaç rapor bilgilerini döndürmektedir";
                        return;
                    }
                    else
                    {
                        txtResult.Visible = true;
                        txtResult.Text = "Sonuc Açıklaması : " + response.sonucAciklamasi + " Sonuç Kodu :" + response.sonucKodu;
                        return;
                    }
                }
                if (response.analikRapor == null && response.dogumOncesiCalisabilirRapor== null  && response.dogumRapor==null && response.ilacRapor==null && response.isgoremezlikRapor==null && response.isgoremezlikRaporEkleri==null && response.maluliyetRapor==null && response.protezRapor==null && response.tedaviRapor==null)
                {
                    txtResult.Visible = true;
                    txtResult.Text = txtName.Text + " " + txtSurname.Text + " adlı kişinin rapor bilgisi bulunmamaktadır!!!";
                    return;
                }
                if (response.analikRapor != null)
                {
                    sb.AppendLine("-----------------------------ANALIK RAPOR BİLGİSİ------------------------------");
                    sb.AppendLine("-------------------------------------------------------------------------------");
                    #region AnalikIsgoremezlikRaporDVO

                    sb.AppendLine("Bebek Doğum Tarihi :" + response.analikRapor.bebekDogumTarihi);
                    sb.AppendLine("Çocuk Sayısı :" + response.analikRapor.cocukSayisi);
                    sb.AppendLine("Açıklama :" + response.analikRapor.raporDVO.aciklama);
                    sb.AppendLine("Başlangıç Tarihi :" + response.analikRapor.raporDVO.baslangicTarihi);
                    sb.AppendLine("Bitiş Tarihi :" + response.analikRapor.raporDVO.bitisTarihi);
                    sb.AppendLine("Takip Numarası :" + response.analikRapor.raporDVO.takipNo);
                    sb.AppendLine("Türü :" + response.analikRapor.raporDVO.turu);

                    if (response.analikRapor.raporDVO != null && response.analikRapor.raporDVO.doktorlar != null)
                    {
                        sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");

                        foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.analikRapor.raporDVO.doktorlar)
                        {
                            sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                            sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                          
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    if (response.analikRapor.raporDVO != null)
                    {
                        sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                        sb.AppendLine("Klinik Tanı :" + response.analikRapor.raporDVO.klinikTani);
                        sb.AppendLine("Protokol Numarası :" + response.analikRapor.raporDVO.protokolNo);
                        sb.AppendLine("Protokol Tarihi :" + response.analikRapor.raporDVO.protokolTarihi);
                        sb.AppendLine("aVakaTKaza :" + response.analikRapor.raporDVO.raporBilgisi.aVakaTKaza);
                        sb.AppendLine("Rapor Numarası :" + response.analikRapor.raporDVO.raporBilgisi.no);
                        sb.AppendLine("Rapor Sıra Numarası :" + response.analikRapor.raporDVO.raporBilgisi.raporSiraNo);
                        sb.AppendLine("Rapor Takip Numarası :" + response.analikRapor.raporDVO.raporBilgisi.raporTakipNo);
                        sb.AppendLine("Rapor Tesis Kodu :" + response.analikRapor.raporDVO.raporBilgisi.raporTesisKodu);
                        sb.AppendLine("Tarih :" + response.analikRapor.raporDVO.raporBilgisi.tarih);
                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }



                    if (response.analikRapor.raporDVO != null && response.analikRapor.raporDVO.tanilar != null)
                    {
                        sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                        RaporIslemleri.taniBilgisiDVO[] _tani = response.analikRapor.raporDVO.tanilar;
                        for (int i = 0; i < _tani.Length; i++)
                        {
                            sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                        }

                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }

                    if (response.analikRapor.raporDVO != null && response.analikRapor.raporDVO.teshisler != null)
                    {
                        sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.analikRapor.raporDVO.teshisler)
                        {

                            sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                            sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    if (response.analikRapor.raporDVO != null && response.analikRapor.raporDVO.ilacTeshisler != null)
                    {
                        sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.analikRapor.raporDVO.ilacTeshisler)
                        {
                            sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                            sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                            sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }



                    #endregion
                }
                if (response.dogumOncesiCalisabilirRapor != null && response.dogumOncesiCalisabilirRapor.raporDVO != null)
                {
                    sb.AppendLine("----------------------DOĞUM ÖNCESİ ÇALIŞABİLİR RAPOR BİLGİSİ-------------------");
                    sb.AppendLine("-------------------------------------------------------------------------------");
                    #region DogumOncesiCalisabilirRaporDVO

                    sb.AppendLine("Bebek Doğum Tarihi :" + response.dogumOncesiCalisabilirRapor.bebekDogumTarihi);
                    sb.AppendLine("Doğum İzni Başlangıç Tarihi :" + response.dogumOncesiCalisabilirRapor.dogumIzniBaslangicTarihi);
                    sb.AppendLine("Açıklama :" + response.dogumOncesiCalisabilirRapor.raporDVO.aciklama);
                    sb.AppendLine("Başlangıç Tarihi :" + response.dogumOncesiCalisabilirRapor.raporDVO.baslangicTarihi);
                    sb.AppendLine("Bitiş Tarihi :" + response.dogumOncesiCalisabilirRapor.raporDVO.bitisTarihi);
                    sb.AppendLine("Takip Numarası :" + response.dogumOncesiCalisabilirRapor.raporDVO.takipNo);
                    sb.AppendLine("Türü :" + response.dogumOncesiCalisabilirRapor.raporDVO.turu);

                    if (response.dogumOncesiCalisabilirRapor.raporDVO.doktorlar != null)
                    {
                        sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                        foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.dogumOncesiCalisabilirRapor.raporDVO.doktorlar)
                        {
                            sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                            sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                           
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }


                    sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                    sb.AppendLine("Klinik Tanı :" + response.dogumOncesiCalisabilirRapor.raporDVO.klinikTani);
                    sb.AppendLine("Protokol Numarası :" + response.dogumOncesiCalisabilirRapor.raporDVO.protokolNo);
                    sb.AppendLine("Protokol Tarihi :" + response.dogumOncesiCalisabilirRapor.raporDVO.protokolTarihi);
                    sb.AppendLine("aVakaTKaza :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.aVakaTKaza);
                    sb.AppendLine("Rapor Numarası :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.no);
                    sb.AppendLine("Rapor Sıra Numarası :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporSiraNo);
                    sb.AppendLine("Rapor Takip Numarası :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporTakipNo);
                    sb.AppendLine("Rapor Tesis Kodu :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporTesisKodu);
                    sb.AppendLine("Tarih :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.tarih);
                    sb.AppendLine("-----------------------------------------------------------------------------");

                    if (response.dogumOncesiCalisabilirRapor.raporDVO.tanilar != null)
                    {
                        sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                        RaporIslemleri.taniBilgisiDVO[] _tani = response.dogumOncesiCalisabilirRapor.raporDVO.tanilar;
                        for (int i = 0; i < _tani.Length; i++)
                        {
                            sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                        }

                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }

                    if (response.dogumOncesiCalisabilirRapor.raporDVO.teshisler != null)
                    {
                        sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.dogumOncesiCalisabilirRapor.raporDVO.teshisler)
                        {

                            sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                            sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    if (response.dogumOncesiCalisabilirRapor.raporDVO.ilacTeshisler != null)
                    {
                        sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.dogumOncesiCalisabilirRapor.raporDVO.ilacTeshisler)
                        {
                            sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                            sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                            sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }


                    #endregion
                }
                if (response.dogumRapor != null && response.dogumRapor.raporDVO != null)
                {
                    sb.AppendLine("-----------------------------DOĞUM RAPOR BİLGİSİ------------------------------");
                    sb.AppendLine("-------------------------------------------------------------------------------");
                    #region DogumRaporDVO

                    sb.AppendLine("Anestezi Tipi :" + response.dogumRapor.anesteziTipi);
                    sb.AppendLine("Bebek Doğum Tarihi :" + response.dogumRapor.bebekDogumTarihi);
                    sb.AppendLine("Canlı Çocuk Sayısı :" + response.dogumRapor.canliCocukSayisi);
                    sb.AppendLine("Çocuk Sayııs :" + response.dogumRapor.cocukSayisi);
                    sb.AppendLine("Doğum Tipi :" + response.dogumRapor.dogumTipi);
                    sb.AppendLine("Epizyotemi :" + response.dogumRapor.epizyotemi);
                    sb.AppendLine("Açıklama :" + response.dogumRapor.raporDVO.aciklama);
                    sb.AppendLine("Başlangıç Tarihi :" + response.dogumRapor.raporDVO.baslangicTarihi);
                    sb.AppendLine("Bitiş Tarihi :" + response.dogumRapor.raporDVO.bitisTarihi);
                    sb.AppendLine("Takip Numarası :" + response.dogumRapor.raporDVO.takipNo);
                    sb.AppendLine("Türü :" + response.dogumRapor.raporDVO.turu);

                    if (response.dogumRapor.cocuklar != null)
                    {
                        sb.AppendLine("------------------------------Çocuk Bilgisi-------------------------------");
                        foreach (RaporIslemleri.cocukBilgisiDVO _cocuk in response.dogumRapor.cocuklar)
                        {


                            sb.AppendLine("Cinsiyeti :" + _cocuk.cinsiyet);
                            sb.AppendLine("Doğum Saati :" + _cocuk.dogumSaati);
                            sb.AppendLine("Kilo :" + _cocuk.kilo);
                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }
                    }

                    if (response.dogumRapor.raporDVO.doktorlar != null)
                    {
                        sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                        foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.dogumRapor.raporDVO.doktorlar)
                        {
                            sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                            sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                           
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }



                    sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                    sb.AppendLine("Klinik Tanı :" + response.dogumRapor.raporDVO.klinikTani);
                    sb.AppendLine("Protokol Numarası :" + response.dogumRapor.raporDVO.protokolNo);
                    sb.AppendLine("Protokol Tarihi :" + response.dogumRapor.raporDVO.protokolTarihi);
                    sb.AppendLine("aVakaTKaza :" + response.dogumRapor.raporDVO.raporBilgisi.aVakaTKaza);
                    sb.AppendLine("Rapor Numarası :" + response.dogumRapor.raporDVO.raporBilgisi.no);
                    sb.AppendLine("Rapor Sıra Numarası :" + response.dogumRapor.raporDVO.raporBilgisi.raporSiraNo);
                    sb.AppendLine("Rapor Takip Numarası :" + response.dogumRapor.raporDVO.raporBilgisi.raporTakipNo);
                    sb.AppendLine("Rapor Tesis Kodu :" + response.dogumRapor.raporDVO.raporBilgisi.raporTesisKodu);
                    sb.AppendLine("Tarih :" + response.dogumRapor.raporDVO.raporBilgisi.tarih);
                    sb.AppendLine("-----------------------------------------------------------------------------");

                    if (response.dogumRapor.raporDVO.tanilar != null)
                    {
                        sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                        RaporIslemleri.taniBilgisiDVO[] _tani = response.dogumRapor.raporDVO.tanilar;
                        for (int i = 0; i < _tani.Length; i++)
                        {
                            sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                        }

                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }

                    if (response.dogumRapor.raporDVO.teshisler != null)
                    {
                        sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.dogumRapor.raporDVO.teshisler)
                        {

                            sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                            sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    if (response.dogumRapor.raporDVO.ilacTeshisler != null)
                    {
                        sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.dogumRapor.raporDVO.ilacTeshisler)
                        {
                            sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                            sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                            sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }


                    #endregion
                }
                if (response.ilacRapor != null && response.ilacRapor.raporDVO != null)
                {
                    sb.AppendLine("-----------------------------İLAÇ RAPOR BİLGİSİ------------------------------");
                    sb.AppendLine("-------------------------------------------------------------------------------");
                    #region IlacRaporDVO

                    sb.AppendLine("Takip Formu Numarası :" + response.ilacRapor.takipFormuNo);
                    sb.AppendLine("Açıklama :" + response.ilacRapor.raporDVO.aciklama);
                    sb.AppendLine("Başlangıç Tarihi :" + response.ilacRapor.raporDVO.baslangicTarihi);
                    sb.AppendLine("Bitiş Tarihi :" + response.ilacRapor.raporDVO.bitisTarihi);
                    sb.AppendLine("Takip Numarası :" + response.ilacRapor.raporDVO.takipNo);
                    sb.AppendLine("Türü :" + response.ilacRapor.raporDVO.turu);

                    if (response.ilacRapor.raporEtkinMaddeler != null)
                    {
                        sb.AppendLine("--------------------------Rapor Etkin Madde Listesi---------------------------");
                        foreach (RaporIslemleri.raporEtkinMaddeDVO _etkinMadde in response.ilacRapor.raporEtkinMaddeler)
                        {

                            sb.AppendLine("Etkin Madde Kodu :" + _etkinMadde.etkinMaddeKodu);
                            sb.AppendLine("Kullanım Doz 1 :" + _etkinMadde.kullanimDoz1);
                            sb.AppendLine("Kullanım Doz 2 :" + _etkinMadde.kullanimDoz2);
                            sb.AppendLine("Kullanım Doz Birimi :" + _etkinMadde.kullanimDozBirim);
                            sb.AppendLine("Kullanım Periyot :" + _etkinMadde.kullanimPeriyot);
                            sb.AppendLine("Kullanım Periyot Birim :" + _etkinMadde.kullanimPeriyotBirim);
                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }
                    }

                    if (response.ilacRapor.raporDVO.doktorlar != null)
                    {
                        sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                        foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.ilacRapor.raporDVO.doktorlar)
                        {
                            sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                            sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                           
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }

                    }

                    sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                    sb.AppendLine("Klinik Tanı :" + response.ilacRapor.raporDVO.klinikTani);
                    sb.AppendLine("Protokol Numarası :" + response.ilacRapor.raporDVO.protokolNo);
                    sb.AppendLine("Protokol Tarihi :" + response.ilacRapor.raporDVO.protokolTarihi);
                    sb.AppendLine("aVakaTKaza :" + response.ilacRapor.raporDVO.raporBilgisi.aVakaTKaza);
                    sb.AppendLine("Rapor Numarası :" + response.ilacRapor.raporDVO.raporBilgisi.no);
                    sb.AppendLine("Rapor Sıra Numarası :" + response.ilacRapor.raporDVO.raporBilgisi.raporSiraNo);
                    sb.AppendLine("Rapor Takip Numarası :" + response.ilacRapor.raporDVO.raporBilgisi.raporTakipNo);
                    sb.AppendLine("Rapor Tesis Kodu :" + response.ilacRapor.raporDVO.raporBilgisi.raporTesisKodu);
                    sb.AppendLine("Tarih :" + response.ilacRapor.raporDVO.raporBilgisi.tarih);
                    sb.AppendLine("-----------------------------------------------------------------------------");


                    if (response.ilacRapor.raporDVO.tanilar != null)
                    {
                        sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                        RaporIslemleri.taniBilgisiDVO[] _tani = response.ilacRapor.raporDVO.tanilar;
                        for (int i = 0; i < _tani.Length; i++)
                        {
                            sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                        }

                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }



                    if (response.ilacRapor.raporDVO.teshisler != null)
                    {
                        sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.ilacRapor.raporDVO.teshisler)
                        {

                            sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                            sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    if (response.ilacRapor.raporDVO.ilacTeshisler != null)
                    {
                        sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.ilacRapor.raporDVO.ilacTeshisler)
                        {
                            sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                            sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                            sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }



                    #endregion
                }
                if (response.isgoremezlikRapor != null && response.isgoremezlikRapor.raporDVO != null)
                {
                    sb.AppendLine("-----------------------------İŞ GÖREMEZLİK RAPOR BİLGİSİ------------------------------");
                    sb.AppendLine("-------------------------------------------------------------------------------");
                    #region IsgoremezlikRaporDVO

                    sb.AppendLine("Branş Kodu :" + response.isgoremezlikRapor.bransKodu);
                    sb.AppendLine("Devam Durumu :" + response.isgoremezlikRapor.devammi);
                    sb.AppendLine("İş Göremezlik Rapor Türü :" + response.isgoremezlikRapor.isGoremezlikRaporTuru);
                    sb.AppendLine("Karar :" + response.isgoremezlikRapor.karar);
                    sb.AppendLine("Klink Bulgu :" + response.isgoremezlikRapor.klinikBulgu);
                    sb.AppendLine("Ölüm :" + response.isgoremezlikRapor.olum);
                    sb.AppendLine("ronLabBilgileri :" + response.isgoremezlikRapor.ronLabBilgi);
                    sb.AppendLine("Teşhis :" + response.isgoremezlikRapor.teshis);
                    sb.AppendLine("Yatış Durumu :" + response.isgoremezlikRapor.yatisDevam);

                    if (response.isgoremezlikRapor.analikRaporu != null)
                    {
                        sb.AppendLine("------------------------------Analık Raporu--------------------------------");
                        sb.AppendLine("Aktarma Haftası :" + response.isgoremezlikRapor.analikRaporu.aktarmaHaftasi);
                        sb.AppendLine("Analık Rapor Tipi :" + response.isgoremezlikRapor.analikRaporu.analikRaporTipi);
                        sb.AppendLine("Başlangıç Tarihi :" + response.isgoremezlikRapor.analikRaporu.baslangicTarihi);
                        sb.AppendLine("Bebek Doğum Haftası :" + response.isgoremezlikRapor.analikRaporu.bebekDogumHaftasi);
                        sb.AppendLine("Bebek Doğum Tarihi :" + response.isgoremezlikRapor.analikRaporu.bebekDogumTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.isgoremezlikRapor.analikRaporu.bitisTarihi);
                        sb.AppendLine("Canlı Çocuk Sayısı :" + response.isgoremezlikRapor.analikRaporu.canliCocukSayisi);
                        sb.AppendLine("Doğan Çocuk Sayısı :" + response.isgoremezlikRapor.analikRaporu.doganCocukSayisi);
                        sb.AppendLine("Gebelik Haftası 1 :" + response.isgoremezlikRapor.analikRaporu.gebelikHaftasi1);
                        sb.AppendLine("Gebelik Haftası 2 :" + response.isgoremezlikRapor.analikRaporu.gebelikHaftasi2);
                        sb.AppendLine("Gebelik Tipi :" + response.isgoremezlikRapor.analikRaporu.gebelikTipi);
                        sb.AppendLine("XXXXXX Çıkış tarihi :" + response.isgoremezlikRapor.analikRaporu.XXXXXXCikisTarihi);
                        sb.AppendLine("XXXXXX Yatış Tarihi :" + response.isgoremezlikRapor.analikRaporu.XXXXXXYatisTarihi);
                        sb.AppendLine("İş-KOntrol Tarihi :" + response.isgoremezlikRapor.analikRaporu.isKontTarihi);
                        sb.AppendLine("Normal Sezeryan Forsebs Dogum Çeşidi :" + response.isgoremezlikRapor.analikRaporu.norSezFor);
                        sb.AppendLine("Rapor Durumu :" + response.isgoremezlikRapor.analikRaporu.raporDurumu);
                        sb.AppendLine("Taburcu Kodu :" + response.isgoremezlikRapor.analikRaporu.taburcuKodu);
                        sb.AppendLine("Taburcu Tarihi :" + response.isgoremezlikRapor.analikRaporu.taburcuTarihi);
                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }
                    if (response.isgoremezlikRapor.emzirmeRaporu != null)
                    {
                        sb.AppendLine("------------------------------Hastalık Raporu--------------------------------");
                        sb.AppendLine("Anne Kimlik Numarası :" + response.isgoremezlikRapor.emzirmeRaporu.anneTcKimlikNo);
                        sb.AppendLine("Bebek Doğum Tarihi :" + response.isgoremezlikRapor.emzirmeRaporu.bebekDogumTarihi);
                        sb.AppendLine("Canlı Çocuk Sayısı :" + response.isgoremezlikRapor.emzirmeRaporu.canliCocukSayisi);
                        sb.AppendLine("Doğan Çocuk Sayısı :" + response.isgoremezlikRapor.emzirmeRaporu.doganCocukSayisi);
                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }
                    if (response.isgoremezlikRapor.hastalikRaporu != null)
                    {
                        sb.AppendLine("------------------------------Hastalık Raporu--------------------------------");
                        sb.AppendLine("Başlangıç Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.bitisTarihi);
                        sb.AppendLine("XXXXXX Çıkış Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.XXXXXXCikisTarihi);
                        sb.AppendLine("XXXXXX Yatış Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.XXXXXXYatisTarihi);
                        sb.AppendLine("İş-Kontol Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.isKontTarihi);
                        sb.AppendLine("Nuks :" + response.isgoremezlikRapor.hastalikRaporu.nuks);
                        sb.AppendLine("Rapor Durumu :" + response.isgoremezlikRapor.hastalikRaporu.raporDurumu);
                        sb.AppendLine("Taburcu Kodu :" + response.isgoremezlikRapor.hastalikRaporu.taburcuKodu);
                        sb.AppendLine("Taburcu Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.taburcuTarihi);

                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }
                    if (response.isgoremezlikRapor.isKazasiRaporu != null)
                    {
                        sb.AppendLine("------------------------------İş Kazası Raporu--------------------------------");
                        sb.AppendLine("Başlangıç Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.bitisTarihi);
                        sb.AppendLine("XXXXXX Çıkış Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.XXXXXXCikisTarihi);
                        sb.AppendLine("XXXXXX Yatış Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.XXXXXXYatisTarihi);
                        sb.AppendLine("İş Kazası Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.isKazasiTarihi);
                        sb.AppendLine("İş-Kontol Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.isKontTarihi);
                        sb.AppendLine("Nuks :" + response.isgoremezlikRapor.isKazasiRaporu.nuks);
                        sb.AppendLine("Rapor Durumu :" + response.isgoremezlikRapor.isKazasiRaporu.raporDurumu);
                        sb.AppendLine("Taburcu Kodu :" + response.isgoremezlikRapor.isKazasiRaporu.taburcuKodu);
                        sb.AppendLine("Taburcu Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.taburcuTarihi);
                        sb.AppendLine("Yaranın Türü :" + response.isgoremezlikRapor.isKazasiRaporu.yaraninTuru);
                        sb.AppendLine("Yaranın Yeri :" + response.isgoremezlikRapor.isKazasiRaporu.yaraninYeri);
                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }
                    if (response.isgoremezlikRapor.meslekHastaligiRaporu != null)
                    {
                        sb.AppendLine("------------------------------Meslek Hastalığı Raporu--------------------------------");
                        sb.AppendLine("Başlangıç Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.bitisTarihi);
                        sb.AppendLine("XXXXXX Çıkış Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.XXXXXXCikisTarihi);
                        sb.AppendLine("XXXXXX Yatış Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.XXXXXXYatisTarihi);
                        sb.AppendLine("İş-Kontol Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.isKontTarihi);
                        sb.AppendLine("Nuks :" + response.isgoremezlikRapor.meslekHastaligiRaporu.nuks);
                        sb.AppendLine("Rapor Durumu :" + response.isgoremezlikRapor.meslekHastaligiRaporu.raporDurumu);
                        sb.AppendLine("Taburcu Kodu :" + response.isgoremezlikRapor.meslekHastaligiRaporu.taburcuKodu);
                        sb.AppendLine("Taburcu Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.taburcuTarihi);
                        sb.AppendLine("Yaranın Türü :" + response.isgoremezlikRapor.meslekHastaligiRaporu.yaraninTuru);
                        sb.AppendLine("Yaranın Yeri :" + response.isgoremezlikRapor.meslekHastaligiRaporu.yaraninYeri);
                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }

                    sb.AppendLine("Açıklama :" + response.isgoremezlikRapor.raporDVO.aciklama);
                    sb.AppendLine("Başlangıç Tarihi :" + response.isgoremezlikRapor.raporDVO.baslangicTarihi);
                    sb.AppendLine("Bitiş Tarihi :" + response.isgoremezlikRapor.raporDVO.bitisTarihi);
                    sb.AppendLine("Takip Numarası :" + response.isgoremezlikRapor.raporDVO.takipNo);
                    sb.AppendLine("Türü :" + response.isgoremezlikRapor.raporDVO.turu);

                    if (response.isgoremezlikRapor.raporDVO.doktorlar != null)
                    {
                        sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");

                        foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.isgoremezlikRapor.raporDVO.doktorlar)
                        {
                            sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                            sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                           
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }



                    sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                    sb.AppendLine("Klinik Tanı :" + response.isgoremezlikRapor.raporDVO.klinikTani);
                    sb.AppendLine("Protokol Numarası :" + response.isgoremezlikRapor.raporDVO.protokolNo);
                    sb.AppendLine("Protokol Tarihi :" + response.isgoremezlikRapor.raporDVO.protokolTarihi);
                    sb.AppendLine("aVakaTKaza :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.aVakaTKaza);
                    sb.AppendLine("Rapor Numarası :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.no);
                    sb.AppendLine("Rapor Sıra Numarası :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.raporSiraNo);
                    sb.AppendLine("Rapor Takip Numarası :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.raporTakipNo);
                    sb.AppendLine("Rapor Tesis Kodu :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.raporTesisKodu);
                    sb.AppendLine("Tarih :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.tarih);
                    sb.AppendLine("-----------------------------------------------------------------------------");

                    if (response.isgoremezlikRapor.raporDVO.tanilar != null)
                    {
                        sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                        RaporIslemleri.taniBilgisiDVO[] _tani = response.isgoremezlikRapor.raporDVO.tanilar;
                        for (int i = 0; i < _tani.Length; i++)
                        {
                            sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                        }

                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }

                    if (response.isgoremezlikRapor.raporDVO.teshisler != null)
                    {
                        sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.isgoremezlikRapor.raporDVO.teshisler)
                        {

                            sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                            sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    if (response.isgoremezlikRapor.raporDVO.ilacTeshisler != null)
                    {
                        sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.isgoremezlikRapor.raporDVO.ilacTeshisler)
                        {
                            sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                            sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                            sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }


                    #endregion

                }
                if (response.isgoremezlikRaporEkleri != null)
                {
                    sb.AppendLine("-----------------------------İŞ GÖREMEZLİK RAPOR EK BİLGİSİ------------------------------");
                    sb.AppendLine("-------------------------------------------------------------------------------");
                    #region IsgoremezlikRaporEkDVO

                    foreach (RaporIslemleri.isgoremezlikRaporEkDVO _ek in response.isgoremezlikRaporEkleri)
                    {

                        sb.AppendLine("Açıklama :" + _ek.aciklama);
                        sb.AppendLine("Bitiş Tarihi:" + _ek.bitisTarihi);
                        if (_ek.doktorlar != null)
                        {
                            sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                            foreach (RaporIslemleri.doktorBilgisiDVO _doktor in _ek.doktorlar)
                            {
                                sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                               
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        sb.AppendLine("Durum :" + _ek.durum);
                        sb.AppendLine("Düzenleme Türü :" + _ek.duzenlemeTuru);
                        sb.AppendLine("Hasta Yatış Varmı :" + _ek.hastaYatisVarMi);
                        sb.AppendLine("Kontrol Mu? :" + _ek.kontrolMu);
                        sb.AppendLine("Kontrol Tarihi :" + _ek.kontrolTarihi);
                        sb.AppendLine("Kullanıcı Tesis Kodu :" + _ek.kullaniciTesisKodu);
                        sb.AppendLine("Protokol Numarası :" + _ek.protokolNo);
                        sb.AppendLine("Protokol tarihi :" + _ek.protokolTarihi);


                        sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                        sb.AppendLine("aVakaTKaza :" + _ek.raporBilgisiDVO.aVakaTKaza);
                        sb.AppendLine("Rapor Numarası :" + _ek.raporBilgisiDVO.no);
                        sb.AppendLine("Rapor Sıra Numarası :" + _ek.raporBilgisiDVO.raporSiraNo);
                        sb.AppendLine("Rapor Takip Numarası :" + _ek.raporBilgisiDVO.raporTakipNo);
                        sb.AppendLine("Rapor Tesis Kodu :" + _ek.raporBilgisiDVO.raporTesisKodu);
                        sb.AppendLine("Tarih :" + _ek.raporBilgisiDVO.tarih);
                        sb.AppendLine("-----------------------------------------------------------------------------");

                        if (_ek.tanilar != null)
                        {
                            sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                            foreach (RaporIslemleri.taniBilgisiDVO _tani in _ek.tanilar)
                            {

                                sb.AppendLine("tanı Kodu :" + _tani.taniKodu);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }
                        if (_ek.yatislar != null)
                        {
                            sb.AppendLine("------------------------------XXXXXX Yatış Bilgisi--------------------------------");
                            foreach (RaporIslemleri.hastaYatisBilgisiDVO _yatis in _ek.yatislar)
                            {

                                sb.AppendLine("Çıkış Tarihi :" + _yatis.cikisTarihi);
                                sb.AppendLine("Yatiş Tarihi :" + _yatis.yatisTarihi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                    }

                    #endregion
                }
                if (response.maluliyetRapor != null && response.maluliyetRapor.raporDVO != null)
                {
                    sb.AppendLine("-----------------------------MALULİYET RAPOR BİLGİSİ------------------------------");
                    sb.AppendLine("-------------------------------------------------------------------------------");
                    #region MaluliyetRaporDVO

                    sb.AppendLine("Açıklama :" + response.maluliyetRapor.aciklama);
                    //sb.AppendLine("Maluliyet Yüzdesi :" + response.maluliyetRapor.maluliyetYuzdesi);
                    sb.AppendLine("Açıklama :" + response.maluliyetRapor.raporDVO.aciklama);
                    sb.AppendLine("Başlangıç Tarihi :" + response.maluliyetRapor.raporDVO.baslangicTarihi);
                    sb.AppendLine("Bitiş Tarihi :" + response.maluliyetRapor.raporDVO.bitisTarihi);
                    sb.AppendLine("Takip Numarası :" + response.maluliyetRapor.raporDVO.takipNo);
                    sb.AppendLine("Türü :" + response.maluliyetRapor.raporDVO.turu);

                    if (response.maluliyetRapor.bransGorusleri != null)
                    {
                        sb.AppendLine("------------------------------Branş Doktor Bilgisi--------------------------------");
                        foreach (RaporIslemleri.bransGorusBilgisiDVO _bransGorus in response.maluliyetRapor.bransGorusleri)
                        {

                            sb.AppendLine("Açıklama :" + _bransGorus.aciklama);
                            sb.AppendLine("Branş Kodu :" + _bransGorus.bransKodu);
                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }
                    }


                    if (response.maluliyetRapor.raporDVO.doktorlar != null)
                    {
                        sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                        foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.maluliyetRapor.raporDVO.doktorlar)
                        {
                            sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                            sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                        
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }


                    sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                    sb.AppendLine("Klinik Tanı :" + response.maluliyetRapor.raporDVO.klinikTani);
                    sb.AppendLine("Protokol Numarası :" + response.maluliyetRapor.raporDVO.protokolNo);
                    sb.AppendLine("Protokol Tarihi :" + response.maluliyetRapor.raporDVO.protokolTarihi);
                    sb.AppendLine("aVakaTKaza :" + response.maluliyetRapor.raporDVO.raporBilgisi.aVakaTKaza);
                    sb.AppendLine("Rapor Numarası :" + response.maluliyetRapor.raporDVO.raporBilgisi.no);
                    sb.AppendLine("Rapor Sıra Numarası :" + response.maluliyetRapor.raporDVO.raporBilgisi.raporSiraNo);
                    sb.AppendLine("Rapor Takip Numarası :" + response.maluliyetRapor.raporDVO.raporBilgisi.raporTakipNo);
                    sb.AppendLine("Rapor Tesis Kodu :" + response.maluliyetRapor.raporDVO.raporBilgisi.raporTesisKodu);
                    sb.AppendLine("Tarih :" + response.maluliyetRapor.raporDVO.raporBilgisi.tarih);
                    sb.AppendLine("-----------------------------------------------------------------------------");

                    if (response.maluliyetRapor.raporDVO.tanilar != null)
                    {
                        sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                        RaporIslemleri.taniBilgisiDVO[] _tani = response.maluliyetRapor.raporDVO.tanilar;
                        for (int i = 0; i < _tani.Length; i++)
                        {
                            sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                        }

                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }

                    if (response.maluliyetRapor.raporDVO.teshisler != null)
                    {
                        sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.maluliyetRapor.raporDVO.teshisler)
                        {

                            sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                            sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    if (response.maluliyetRapor.raporDVO.ilacTeshisler != null)
                    {
                        sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.maluliyetRapor.raporDVO.ilacTeshisler)
                        {
                            sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                            sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                            sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    #endregion

                }
                if (response.protezRapor != null)
                {
                    sb.AppendLine("-----------------------------PROTEZ RAPOR BİLGİSİ------------------------------");
                    sb.AppendLine("-------------------------------------------------------------------------------");
                    #region ProtezRaporDVO

                    if (response.protezRapor.malzemeler != null)
                    {
                        sb.AppendLine("------------------------------Mazleme Bilgisi--------------------------------");
                        foreach (RaporIslemleri.malzemeBilgisiDVO _mazleme in response.protezRapor.malzemeler)
                        {

                            sb.AppendLine("Adet :" + _mazleme.adet);
                            sb.AppendLine("Mazleme Adı :" + _mazleme.malzemeAdi);
                            sb.AppendLine("Mazleme Kodu :" + _mazleme.malzemeKodu);
                            sb.AppendLine("Malzeme Türü :" + _mazleme.malzemeTuru);
                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }
                    }

                    sb.AppendLine("Açıklama :" + response.protezRapor.raporDVO.aciklama);
                    sb.AppendLine("Başlangıç Tarihi :" + response.protezRapor.raporDVO.baslangicTarihi);
                    sb.AppendLine("Bitiş Tarihi :" + response.protezRapor.raporDVO.bitisTarihi);
                    sb.AppendLine("Takip Numarası :" + response.protezRapor.raporDVO.takipNo);
                    sb.AppendLine("Türü :" + response.protezRapor.raporDVO.turu);

                    if (response.protezRapor.raporDVO.doktorlar != null)
                    {
                        sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                        foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.protezRapor.raporDVO.doktorlar)
                        {
                            sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                            sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                           
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }


                    sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                    sb.AppendLine("Klinik Tanı :" + response.protezRapor.raporDVO.klinikTani);
                    sb.AppendLine("Protokol Numarası :" + response.protezRapor.raporDVO.protokolNo);
                    sb.AppendLine("Protokol Tarihi :" + response.protezRapor.raporDVO.protokolTarihi);
                    sb.AppendLine("aVakaTKaza :" + response.protezRapor.raporDVO.raporBilgisi.aVakaTKaza);
                    sb.AppendLine("Rapor Numarası :" + response.protezRapor.raporDVO.raporBilgisi.no);
                    sb.AppendLine("Rapor Sıra Numarası :" + response.protezRapor.raporDVO.raporBilgisi.raporSiraNo);
                    sb.AppendLine("Rapor Takip Numarası :" + response.protezRapor.raporDVO.raporBilgisi.raporTakipNo);
                    sb.AppendLine("Rapor Tesis Kodu :" + response.protezRapor.raporDVO.raporBilgisi.raporTesisKodu);
                    sb.AppendLine("Tarih :" + response.protezRapor.raporDVO.raporBilgisi.tarih);
                    sb.AppendLine("-----------------------------------------------------------------------------");

                    if (response.protezRapor.raporDVO.tanilar != null)
                    {
                        sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                        RaporIslemleri.taniBilgisiDVO[] _tani = response.protezRapor.raporDVO.tanilar;
                        for (int i = 0; i < _tani.Length; i++)
                        {
                            sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                        }

                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }

                    if (response.protezRapor.raporDVO.teshisler != null)
                    {
                        sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.protezRapor.raporDVO.teshisler)
                        {

                            sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                            sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    if (response.protezRapor.raporDVO.ilacTeshisler != null)
                    {
                        sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.protezRapor.raporDVO.ilacTeshisler)
                        {
                            sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                            sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                            sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    #endregion
                }
                if (response.tedaviRapor != null)
                {
                    sb.AppendLine("-----------------------------TEDAVİ RAPOR BİLGİSİ------------------------------");
                    sb.AppendLine("-------------------------------------------------------------------------------");
                    #region TedaviRaporDVO

                    sb.AppendLine("Tedavi Rapor Türü :" + response.tedaviRapor.tedaviRaporTuru);

                    foreach (RaporIslemleri.tedaviIslemBilgisiDVO _tedavi in response.tedaviRapor.islemler)
                    {

                        if (_tedavi.diyalizRaporBilgisi != null)
                        {
                            sb.AppendLine("------------------------------Diyaliz Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Tetkik Kodu :" + _tedavi.diyalizRaporBilgisi.butKodu);
                            sb.AppendLine("Refakat var Mı? :" + _tedavi.diyalizRaporBilgisi.refakatVarMi);
                            sb.AppendLine("Seans Gün :" + _tedavi.diyalizRaporBilgisi.seansGun);
                            sb.AppendLine("Seans Sayısı :" + _tedavi.diyalizRaporBilgisi.seansSayi);
                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }
                        if (_tedavi.eswlRaporBilgisi != null)
                        {
                            sb.AppendLine("------------------------------ESWL Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Böbrek Bilgisi :" + _tedavi.eswlRaporBilgisi.bobrekBilgisi);
                            sb.AppendLine("Tetkik Kodu :" + _tedavi.eswlRaporBilgisi.butKodu);
                            sb.AppendLine("ESWL Raporu Seans Sayısı :" + _tedavi.eswlRaporBilgisi.eswlRaporuSeansSayisi);
                            sb.AppendLine("ESWL Raporu Taş Sayısı :" + _tedavi.eswlRaporBilgisi.eswlRaporuTasSayisi);
                            if (_tedavi.eswlRaporBilgisi.eswlRaporuTasBilgileri != null)
                            {
                                sb.AppendLine("------------------------------ESWL Taş Bilgisi--------------------------------");
                                foreach (RaporIslemleri.eswlTasBilgisiDVO _tasBilgisi in _tedavi.eswlRaporBilgisi.eswlRaporuTasBilgileri)
                                {

                                    sb.AppendLine("Taş Boyutu :" + _tasBilgisi.tasBoyutu);
                                    sb.AppendLine("Taş Lokalizasyon Kodu :" + _tasBilgisi.tasLokalizasyonKodu);
                                    sb.AppendLine("-------------------------------------------------------------------------------");
                                }
                            }

                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }
                        if (_tedavi.eswtRaporBilgisi != null)
                        {
                            sb.AppendLine("------------------------------ESWL Taş Bilgisi--------------------------------");
                            sb.AppendLine("Tetkik Kodu :" + _tedavi.eswtRaporBilgisi.butKodu);
                            sb.AppendLine("ESWT Vucut Bölgesi Kodu :" + _tedavi.eswtRaporBilgisi.eswtVucutBolgesiKodu);
                            sb.AppendLine("Seans Gün Sayısı :" + _tedavi.eswtRaporBilgisi.seansGun);
                            sb.AppendLine("Seans Sayısı :" + _tedavi.eswtRaporBilgisi.seansSayi);
                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }
                        if (_tedavi.evHemodiyaliziRaporBilgisi != null)
                        {
                            sb.AppendLine("------------------------------Hemodiyaliz Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Tetkik Kodu :" + _tedavi.evHemodiyaliziRaporBilgisi.butKodu);
                            sb.AppendLine("Seans Gün Sayısı :" + _tedavi.evHemodiyaliziRaporBilgisi.seansGun);
                            sb.AppendLine("Seans Sayısı :" + _tedavi.evHemodiyaliziRaporBilgisi.seansSayi);
                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }
                        if (_tedavi.ftrRaporBilgisi != null)
                        {
                            sb.AppendLine("------------------------------FTR Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Tetkik Kodu :" + _tedavi.ftrRaporBilgisi.butKodu);
                            sb.AppendLine("FTR Vucut Bölgesi Kodu :" + _tedavi.ftrRaporBilgisi.ftrVucutBolgesiKodu);
                            sb.AppendLine("Robotik Rehabilitasyon :" + _tedavi.ftrRaporBilgisi.robotikRehabilitasyon);
                            sb.AppendLine("Seans Gün Sayısı :" + _tedavi.ftrRaporBilgisi.seansGun);
                            sb.AppendLine("Seans Sayısı :" + _tedavi.ftrRaporBilgisi.seansSayi);
                            sb.AppendLine("Tedavi Türü :" + _tedavi.ftrRaporBilgisi.tedaviTuru);
                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }
                        if (_tedavi.hotRaporBilgisi != null)
                        {
                            sb.AppendLine("------------------------------HOT Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Seans Gün Sayısı :" + _tedavi.hotRaporBilgisi.seansGun);
                            sb.AppendLine("Seans Sayısı :" + _tedavi.hotRaporBilgisi.seansSayi);
                            sb.AppendLine("Tedavi Süresi :" + _tedavi.hotRaporBilgisi.tedaviSuresi);
                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }
                        if (_tedavi.tupBebekRaporBilgisi != null)
                        {
                            sb.AppendLine("------------------------------HOT Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Tetkik Kodu  :" + _tedavi.tupBebekRaporBilgisi.butKodu);
                            sb.AppendLine("Tüp Bebek Rapor Türü :" + _tedavi.tupBebekRaporBilgisi.tupBebekRaporTuru);
                            sb.AppendLine("-------------------------------------------------------------------------------");
                        }

                    }


                    sb.AppendLine("Açıklama :" + response.tedaviRapor.raporDVO.aciklama);
                    sb.AppendLine("Başlangıç Tarihi :" + response.tedaviRapor.raporDVO.baslangicTarihi);
                    sb.AppendLine("Bitiş Tarihi :" + response.tedaviRapor.raporDVO.bitisTarihi);
                    sb.AppendLine("Takip Numarası :" + response.tedaviRapor.raporDVO.takipNo);
                    sb.AppendLine("Türü :" + response.tedaviRapor.raporDVO.turu);

                    if (response.tedaviRapor.raporDVO.doktorlar != null)
                    {
                        sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                        foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.tedaviRapor.raporDVO.doktorlar)
                        {
                            sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                            sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                           
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }


                    sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                    sb.AppendLine("Klinik Tanı :" + response.tedaviRapor.raporDVO.klinikTani);
                    sb.AppendLine("Protokol Numarası :" + response.tedaviRapor.raporDVO.protokolNo);
                    sb.AppendLine("Protokol Tarihi :" + response.tedaviRapor.raporDVO.protokolTarihi);
                    sb.AppendLine("aVakaTKaza :" + response.tedaviRapor.raporDVO.raporBilgisi.aVakaTKaza);
                    sb.AppendLine("Rapor Numarası :" + response.tedaviRapor.raporDVO.raporBilgisi.no);
                    sb.AppendLine("Rapor Sıra Numarası :" + response.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo);
                    sb.AppendLine("Rapor Takip Numarası :" + response.tedaviRapor.raporDVO.raporBilgisi.raporTakipNo);
                    sb.AppendLine("Rapor Tesis Kodu :" + response.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu);
                    sb.AppendLine("Tarih :" + response.tedaviRapor.raporDVO.raporBilgisi.tarih);
                    sb.AppendLine("-----------------------------------------------------------------------------");

                    if (response.tedaviRapor.raporDVO.tanilar != null)
                    {
                        sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                        RaporIslemleri.taniBilgisiDVO[] _tani = response.tedaviRapor.raporDVO.tanilar;
                        for (int i = 0; i < _tani.Length; i++)
                        {
                            sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                        }

                        sb.AppendLine("-----------------------------------------------------------------------------");
                    }

                    if (response.tedaviRapor.raporDVO.teshisler != null)
                    {
                        sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.tedaviRapor.raporDVO.teshisler)
                        {

                            sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                            sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }

                    if (response.tedaviRapor.raporDVO.ilacTeshisler != null)
                    {
                        sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                        foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.tedaviRapor.raporDVO.ilacTeshisler)
                        {
                            sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                            sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                            sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                    }
                    #endregion
                }
                txtResult.Visible = true;
                txtResult.Text = sb.ToString();
                if(string.IsNullOrEmpty(txtResult.Text))
                    txtResult.Text="Rapor Bilgisi Mevcut Değildir";
                
            }
#endregion MedulaRaporIslemleri_btnSearchChasing_Click
        }

        private void btnSearchReportInfo_Click()
        {
#region MedulaRaporIslemleri_btnSearchReportInfo_Click
   if (!string.IsNullOrEmpty(((ITTComboBox)((TTVisual.TTComboBox)(cmbRBReportType))).SelectedItem.Value.ToString()))
            {
                txtResult.Visible = false;
                txtResult.Text = "";
                string result = ((ITTComboBox)((TTVisual.TTComboBox)(cmbRBReportType))).SelectedItem.Value.ToString();
                RaporIslemleri.raporSorguDVO _raporSorguDVO = new RaporIslemleri.raporSorguDVO();
                //TODO : MEDULA20140501         
       _raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
                _raporOkuDVO.no = txtRBReportRow.Text.Trim();
                _raporOkuDVO.raporSiraNo =txtRBReportChasing.Text.Trim() ;
                _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _raporOkuDVO.tarih = dtReportDate.Text.Trim();
                _raporOkuDVO.turu = result;
                _raporSorguDVO.raporBilgisi = _raporOkuDVO;
                StringBuilder sb = new StringBuilder();
                RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiBulSync(Sites.SiteLocalHost, _raporSorguDVO);
                if (response != null)
                {
                    if (!response.sonucKodu.Equals(0))
                    {
                        if(response.sonucKodu.Equals(5005))
                        {
                            txtResult.Visible = true;
                            txtResult.Text = "Bu servis sadece tedavi ve ilaç rapor bilgilerini döndürmektedir";
                            return;
                        }
                        else
                        {
                            txtResult.Visible = true;
                            txtResult.Text = "Sonuc Açıklaması : " + response.sonucAciklamasi + " Sonuç Kodu :" + response.sonucKodu;
                            return;
                        }
                    }
                    if (response.analikRapor == null && response.dogumOncesiCalisabilirRapor == null && response.dogumRapor == null && response.ilacRapor == null && response.isgoremezlikRapor == null && response.isgoremezlikRaporEkleri == null && response.maluliyetRapor == null && response.protezRapor == null && response.tedaviRapor == null)
                    {
                        txtResult.Visible = true;
                        txtResult.Text = txtName.Text + " " + txtSurname.Text + " adlı kişinin rapor bilgisi bulunmamaktadır!!!";
                        return;
                    }
                    if (response.analikRapor != null)
                    {
                        sb.AppendLine("-----------------------------ANALIK RAPOR BİLGİSİ------------------------------");
                        sb.AppendLine("-------------------------------------------------------------------------------");
                        #region AnalikIsgoremezlikRaporDVO

                        sb.AppendLine("Bebek Doğum Tarihi :" + response.analikRapor.bebekDogumTarihi);
                        sb.AppendLine("Çocuk Sayısı :" + response.analikRapor.cocukSayisi);
                        sb.AppendLine("Açıklama :" + response.analikRapor.raporDVO.aciklama);
                        sb.AppendLine("Başlangıç Tarihi :" + response.analikRapor.raporDVO.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.analikRapor.raporDVO.bitisTarihi);
                        sb.AppendLine("Takip Numarası :" + response.analikRapor.raporDVO.takipNo);
                        sb.AppendLine("Türü :" + response.analikRapor.raporDVO.turu);

                        if (response.analikRapor.raporDVO != null && response.analikRapor.raporDVO.doktorlar != null)
                        {
                            sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");

                            foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.analikRapor.raporDVO.doktorlar)
                            {
                                sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                sb.AppendLine("Brans Kodu :" + _doktor.drBransKodu);
                                sb.AppendLine("Tescil Numarası :" + _doktor.drTescilNo);
                                sb.AppendLine("Tipi :" + _doktor.tipi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        if (response.analikRapor.raporDVO != null)
                        {
                            sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                            sb.AppendLine("Klinik Tanı :" + response.analikRapor.raporDVO.klinikTani);
                            sb.AppendLine("Protokol Numarası :" + response.analikRapor.raporDVO.protokolNo);
                            sb.AppendLine("Protokol Tarihi :" + response.analikRapor.raporDVO.protokolTarihi);
                            sb.AppendLine("aVakaTKaza :" + response.analikRapor.raporDVO.raporBilgisi.aVakaTKaza);
                            sb.AppendLine("Rapor Numarası :" + response.analikRapor.raporDVO.raporBilgisi.no);
                            sb.AppendLine("Rapor Sıra Numarası :" + response.analikRapor.raporDVO.raporBilgisi.raporSiraNo);
                            sb.AppendLine("Rapor Takip Numarası :" + response.analikRapor.raporDVO.raporBilgisi.raporTakipNo);
                            sb.AppendLine("Rapor Tesis Kodu :" + response.analikRapor.raporDVO.raporBilgisi.raporTesisKodu);
                            sb.AppendLine("Tarih :" + response.analikRapor.raporDVO.raporBilgisi.tarih);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }



                        if (response.analikRapor.raporDVO != null && response.analikRapor.raporDVO.tanilar != null)
                        {
                            sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                            RaporIslemleri.taniBilgisiDVO[] _tani = response.analikRapor.raporDVO.tanilar;
                            for (int i = 0; i < _tani.Length; i++)
                            {
                                sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                            }

                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }

                        if (response.analikRapor.raporDVO != null && response.analikRapor.raporDVO.teshisler != null)
                        {
                            sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.analikRapor.raporDVO.teshisler)
                            {

                                sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        if (response.analikRapor.raporDVO != null && response.analikRapor.raporDVO.ilacTeshisler != null)
                        {
                            sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.analikRapor.raporDVO.ilacTeshisler)
                            {
                                sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }



                        #endregion
                    }
                    if (response.dogumOncesiCalisabilirRapor != null && response.dogumOncesiCalisabilirRapor.raporDVO != null)
                    {
                        sb.AppendLine("----------------------DOĞUM ÖNCESİ ÇALIŞABİLİR RAPOR BİLGİSİ-------------------");
                        sb.AppendLine("-------------------------------------------------------------------------------");
                        #region DogumOncesiCalisabilirRaporDVO

                        sb.AppendLine("Bebek Doğum Tarihi :" + response.dogumOncesiCalisabilirRapor.bebekDogumTarihi);
                        sb.AppendLine("Doğum İzni Başlangıç Tarihi :" + response.dogumOncesiCalisabilirRapor.dogumIzniBaslangicTarihi);
                        sb.AppendLine("Açıklama :" + response.dogumOncesiCalisabilirRapor.raporDVO.aciklama);
                        sb.AppendLine("Başlangıç Tarihi :" + response.dogumOncesiCalisabilirRapor.raporDVO.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.dogumOncesiCalisabilirRapor.raporDVO.bitisTarihi);
                        sb.AppendLine("Takip Numarası :" + response.dogumOncesiCalisabilirRapor.raporDVO.takipNo);
                        sb.AppendLine("Türü :" + response.dogumOncesiCalisabilirRapor.raporDVO.turu);

                        if (response.dogumOncesiCalisabilirRapor.raporDVO.doktorlar != null)
                        {
                            sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                            foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.dogumOncesiCalisabilirRapor.raporDVO.doktorlar)
                            {
                                sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                sb.AppendLine("Brans Kodu :" + _doktor.drBransKodu);
                                sb.AppendLine("Tescil Numarası :" + _doktor.drTescilNo);
                                sb.AppendLine("Tipi :" + _doktor.tipi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }


                        sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                        sb.AppendLine("Klinik Tanı :" + response.dogumOncesiCalisabilirRapor.raporDVO.klinikTani);
                        sb.AppendLine("Protokol Numarası :" + response.dogumOncesiCalisabilirRapor.raporDVO.protokolNo);
                        sb.AppendLine("Protokol Tarihi :" + response.dogumOncesiCalisabilirRapor.raporDVO.protokolTarihi);
                        sb.AppendLine("aVakaTKaza :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.aVakaTKaza);
                        sb.AppendLine("Rapor Numarası :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.no);
                        sb.AppendLine("Rapor Sıra Numarası :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporSiraNo);
                        sb.AppendLine("Rapor Takip Numarası :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporTakipNo);
                        sb.AppendLine("Rapor Tesis Kodu :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.raporTesisKodu);
                        sb.AppendLine("Tarih :" + response.dogumOncesiCalisabilirRapor.raporDVO.raporBilgisi.tarih);
                        sb.AppendLine("-----------------------------------------------------------------------------");

                        if (response.dogumOncesiCalisabilirRapor.raporDVO.tanilar != null)
                        {
                            sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                            RaporIslemleri.taniBilgisiDVO[] _tani = response.dogumOncesiCalisabilirRapor.raporDVO.tanilar;
                            for (int i = 0; i < _tani.Length; i++)
                            {
                                sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                            }

                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }

                        if (response.dogumOncesiCalisabilirRapor.raporDVO.teshisler != null)
                        {
                            sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.dogumOncesiCalisabilirRapor.raporDVO.teshisler)
                            {

                                sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        if (response.dogumOncesiCalisabilirRapor.raporDVO.ilacTeshisler != null)
                        {
                            sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.dogumOncesiCalisabilirRapor.raporDVO.ilacTeshisler)
                            {
                                sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }


                        #endregion
                    }
                    if (response.dogumRapor != null && response.dogumRapor.raporDVO != null)
                    {
                        sb.AppendLine("-----------------------------DOĞUM RAPOR BİLGİSİ------------------------------");
                        sb.AppendLine("-------------------------------------------------------------------------------");
                        #region DogumRaporDVO

                        sb.AppendLine("Anestezi Tipi :" + response.dogumRapor.anesteziTipi);
                        sb.AppendLine("Bebek Doğum Tarihi :" + response.dogumRapor.bebekDogumTarihi);
                        sb.AppendLine("Canlı Çocuk Sayısı :" + response.dogumRapor.canliCocukSayisi);
                        sb.AppendLine("Çocuk Sayııs :" + response.dogumRapor.cocukSayisi);
                        sb.AppendLine("Doğum Tipi :" + response.dogumRapor.dogumTipi);
                        sb.AppendLine("Epizyotemi :" + response.dogumRapor.epizyotemi);
                        sb.AppendLine("Açıklama :" + response.dogumRapor.raporDVO.aciklama);
                        sb.AppendLine("Başlangıç Tarihi :" + response.dogumRapor.raporDVO.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.dogumRapor.raporDVO.bitisTarihi);
                        sb.AppendLine("Takip Numarası :" + response.dogumRapor.raporDVO.takipNo);
                        sb.AppendLine("Türü :" + response.dogumRapor.raporDVO.turu);

                        if (response.dogumRapor.cocuklar != null)
                        {
                            sb.AppendLine("------------------------------Çocuk Bilgisi-------------------------------");
                            foreach (RaporIslemleri.cocukBilgisiDVO _cocuk in response.dogumRapor.cocuklar)
                            {


                                sb.AppendLine("Cinsiyeti :" + _cocuk.cinsiyet);
                                sb.AppendLine("Doğum Saati :" + _cocuk.dogumSaati);
                                sb.AppendLine("Kilo :" + _cocuk.kilo);
                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }
                        }

                        if (response.dogumRapor.raporDVO.doktorlar != null)
                        {
                            sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                            foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.dogumRapor.raporDVO.doktorlar)
                            {
                                sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                sb.AppendLine("Brans Kodu :" + _doktor.drBransKodu);
                                sb.AppendLine("Tescil Numarası :" + _doktor.drTescilNo);
                                sb.AppendLine("Tipi :" + _doktor.tipi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }



                        sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                        sb.AppendLine("Klinik Tanı :" + response.dogumRapor.raporDVO.klinikTani);
                        sb.AppendLine("Protokol Numarası :" + response.dogumRapor.raporDVO.protokolNo);
                        sb.AppendLine("Protokol Tarihi :" + response.dogumRapor.raporDVO.protokolTarihi);
                        sb.AppendLine("aVakaTKaza :" + response.dogumRapor.raporDVO.raporBilgisi.aVakaTKaza);
                        sb.AppendLine("Rapor Numarası :" + response.dogumRapor.raporDVO.raporBilgisi.no);
                        sb.AppendLine("Rapor Sıra Numarası :" + response.dogumRapor.raporDVO.raporBilgisi.raporSiraNo);
                        sb.AppendLine("Rapor Takip Numarası :" + response.dogumRapor.raporDVO.raporBilgisi.raporTakipNo);
                        sb.AppendLine("Rapor Tesis Kodu :" + response.dogumRapor.raporDVO.raporBilgisi.raporTesisKodu);
                        sb.AppendLine("Tarih :" + response.dogumRapor.raporDVO.raporBilgisi.tarih);
                        sb.AppendLine("-----------------------------------------------------------------------------");

                        if (response.dogumRapor.raporDVO.tanilar != null)
                        {
                            sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                            RaporIslemleri.taniBilgisiDVO[] _tani = response.dogumRapor.raporDVO.tanilar;
                            for (int i = 0; i < _tani.Length; i++)
                            {
                                sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                            }

                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }

                        if (response.dogumRapor.raporDVO.teshisler != null)
                        {
                            sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.dogumRapor.raporDVO.teshisler)
                            {

                                sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        if (response.dogumRapor.raporDVO.ilacTeshisler != null)
                        {
                            sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.dogumRapor.raporDVO.ilacTeshisler)
                            {
                                sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }


                        #endregion
                    }
                    if (response.ilacRapor != null && response.ilacRapor.raporDVO != null)
                    {
                        sb.AppendLine("-----------------------------İLAÇ RAPOR BİLGİSİ------------------------------");
                        sb.AppendLine("-------------------------------------------------------------------------------");
                        #region IlacRaporDVO

                        sb.AppendLine("Takip Formu Numarası :" + response.ilacRapor.takipFormuNo);
                        sb.AppendLine("Açıklama :" + response.ilacRapor.raporDVO.aciklama);
                        sb.AppendLine("Başlangıç Tarihi :" + response.ilacRapor.raporDVO.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.ilacRapor.raporDVO.bitisTarihi);
                        sb.AppendLine("Takip Numarası :" + response.ilacRapor.raporDVO.takipNo);
                        sb.AppendLine("Türü :" + response.ilacRapor.raporDVO.turu);

                        if (response.ilacRapor.raporEtkinMaddeler != null)
                        {
                            sb.AppendLine("--------------------------Rapor Etkin Madde Listesi---------------------------");
                            foreach (RaporIslemleri.raporEtkinMaddeDVO _etkinMadde in response.ilacRapor.raporEtkinMaddeler)
                            {

                                sb.AppendLine("Etkin Madde Kodu :" + _etkinMadde.etkinMaddeKodu);
                                sb.AppendLine("Kullanım Doz 1 :" + _etkinMadde.kullanimDoz1);
                                sb.AppendLine("Kullanım Doz 2 :" + _etkinMadde.kullanimDoz2);
                                sb.AppendLine("Kullanım Doz Birimi :" + _etkinMadde.kullanimDozBirim);
                                sb.AppendLine("Kullanım Periyot :" + _etkinMadde.kullanimPeriyot);
                                sb.AppendLine("Kullanım Periyot Birim :" + _etkinMadde.kullanimPeriyotBirim);
                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }
                        }

                        if (response.ilacRapor.raporDVO.doktorlar != null)
                        {
                            sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                            foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.ilacRapor.raporDVO.doktorlar)
                            {
                                sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                sb.AppendLine("Brans Kodu :" + _doktor.drBransKodu);
                                sb.AppendLine("Tescil Numarası :" + _doktor.drTescilNo);
                                sb.AppendLine("Tipi :" + _doktor.tipi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }

                        }

                        sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                        sb.AppendLine("Klinik Tanı :" + response.ilacRapor.raporDVO.klinikTani);
                        sb.AppendLine("Protokol Numarası :" + response.ilacRapor.raporDVO.protokolNo);
                        sb.AppendLine("Protokol Tarihi :" + response.ilacRapor.raporDVO.protokolTarihi);
                        sb.AppendLine("aVakaTKaza :" + response.ilacRapor.raporDVO.raporBilgisi.aVakaTKaza);
                        sb.AppendLine("Rapor Numarası :" + response.ilacRapor.raporDVO.raporBilgisi.no);
                        sb.AppendLine("Rapor Sıra Numarası :" + response.ilacRapor.raporDVO.raporBilgisi.raporSiraNo);
                        sb.AppendLine("Rapor Takip Numarası :" + response.ilacRapor.raporDVO.raporBilgisi.raporTakipNo);
                        sb.AppendLine("Rapor Tesis Kodu :" + response.ilacRapor.raporDVO.raporBilgisi.raporTesisKodu);
                        sb.AppendLine("Tarih :" + response.ilacRapor.raporDVO.raporBilgisi.tarih);
                        sb.AppendLine("-----------------------------------------------------------------------------");


                        if (response.ilacRapor.raporDVO.tanilar != null)
                        {
                            sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                            RaporIslemleri.taniBilgisiDVO[] _tani = response.ilacRapor.raporDVO.tanilar;
                            for (int i = 0; i < _tani.Length; i++)
                            {
                                sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                            }

                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }



                        if (response.ilacRapor.raporDVO.teshisler != null)
                        {
                            sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.ilacRapor.raporDVO.teshisler)
                            {

                                sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        if (response.ilacRapor.raporDVO.ilacTeshisler != null)
                        {
                            sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.ilacRapor.raporDVO.ilacTeshisler)
                            {
                                sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }



                        #endregion
                    }
                    if (response.isgoremezlikRapor != null && response.isgoremezlikRapor.raporDVO != null)
                    {
                        sb.AppendLine("-----------------------------İŞ GÖREMEZLİK RAPOR BİLGİSİ------------------------------");
                        sb.AppendLine("-------------------------------------------------------------------------------");
                        #region IsgoremezlikRaporDVO

                        sb.AppendLine("Branş Kodu :" + response.isgoremezlikRapor.bransKodu);
                        sb.AppendLine("Devam Durumu :" + response.isgoremezlikRapor.devammi);
                        sb.AppendLine("İş Göremezlik Rapor Türü :" + response.isgoremezlikRapor.isGoremezlikRaporTuru);
                        sb.AppendLine("Karar :" + response.isgoremezlikRapor.karar);
                        sb.AppendLine("Klink Bulgu :" + response.isgoremezlikRapor.klinikBulgu);
                        sb.AppendLine("Ölüm :" + response.isgoremezlikRapor.olum);
                        sb.AppendLine("ronLabBilgileri :" + response.isgoremezlikRapor.ronLabBilgi);
                        sb.AppendLine("Teşhis :" + response.isgoremezlikRapor.teshis);
                        sb.AppendLine("Yatış Durumu :" + response.isgoremezlikRapor.yatisDevam);

                        if (response.isgoremezlikRapor.analikRaporu != null)
                        {
                            sb.AppendLine("------------------------------Analık Raporu--------------------------------");
                            sb.AppendLine("Aktarma Haftası :" + response.isgoremezlikRapor.analikRaporu.aktarmaHaftasi);
                            sb.AppendLine("Analık Rapor Tipi :" + response.isgoremezlikRapor.analikRaporu.analikRaporTipi);
                            sb.AppendLine("Başlangıç Tarihi :" + response.isgoremezlikRapor.analikRaporu.baslangicTarihi);
                            sb.AppendLine("Bebek Doğum Haftası :" + response.isgoremezlikRapor.analikRaporu.bebekDogumHaftasi);
                            sb.AppendLine("Bebek Doğum Tarihi :" + response.isgoremezlikRapor.analikRaporu.bebekDogumTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + response.isgoremezlikRapor.analikRaporu.bitisTarihi);
                            sb.AppendLine("Canlı Çocuk Sayısı :" + response.isgoremezlikRapor.analikRaporu.canliCocukSayisi);
                            sb.AppendLine("Doğan Çocuk Sayısı :" + response.isgoremezlikRapor.analikRaporu.doganCocukSayisi);
                            sb.AppendLine("Gebelik Haftası 1 :" + response.isgoremezlikRapor.analikRaporu.gebelikHaftasi1);
                            sb.AppendLine("Gebelik Haftası 2 :" + response.isgoremezlikRapor.analikRaporu.gebelikHaftasi2);
                            sb.AppendLine("Gebelik Tipi :" + response.isgoremezlikRapor.analikRaporu.gebelikTipi);
                            sb.AppendLine("XXXXXX Çıkış tarihi :" + response.isgoremezlikRapor.analikRaporu.XXXXXXCikisTarihi);
                            sb.AppendLine("XXXXXX Yatış Tarihi :" + response.isgoremezlikRapor.analikRaporu.XXXXXXYatisTarihi);
                            sb.AppendLine("İş-KOntrol Tarihi :" + response.isgoremezlikRapor.analikRaporu.isKontTarihi);
                            sb.AppendLine("Normal Sezeryan Forsebs Dogum Çeşidi :" + response.isgoremezlikRapor.analikRaporu.norSezFor);
                            sb.AppendLine("Rapor Durumu :" + response.isgoremezlikRapor.analikRaporu.raporDurumu);
                            sb.AppendLine("Taburcu Kodu :" + response.isgoremezlikRapor.analikRaporu.taburcuKodu);
                            sb.AppendLine("Taburcu Tarihi :" + response.isgoremezlikRapor.analikRaporu.taburcuTarihi);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                        if (response.isgoremezlikRapor.emzirmeRaporu != null)
                        {
                            sb.AppendLine("------------------------------Hastalık Raporu--------------------------------");
                            sb.AppendLine("Anne Kimlik Numarası :" + response.isgoremezlikRapor.emzirmeRaporu.anneTcKimlikNo);
                            sb.AppendLine("Bebek Doğum Tarihi :" + response.isgoremezlikRapor.emzirmeRaporu.bebekDogumTarihi);
                            sb.AppendLine("Canlı Çocuk Sayısı :" + response.isgoremezlikRapor.emzirmeRaporu.canliCocukSayisi);
                            sb.AppendLine("Doğan Çocuk Sayısı :" + response.isgoremezlikRapor.emzirmeRaporu.doganCocukSayisi);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                        if (response.isgoremezlikRapor.hastalikRaporu != null)
                        {
                            sb.AppendLine("------------------------------Hastalık Raporu--------------------------------");
                            sb.AppendLine("Başlangıç Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.bitisTarihi);
                            sb.AppendLine("XXXXXX Çıkış Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.XXXXXXCikisTarihi);
                            sb.AppendLine("XXXXXX Yatış Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.XXXXXXYatisTarihi);
                            sb.AppendLine("İş-Kontol Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.isKontTarihi);
                            sb.AppendLine("Nuks :" + response.isgoremezlikRapor.hastalikRaporu.nuks);
                            sb.AppendLine("Rapor Durumu :" + response.isgoremezlikRapor.hastalikRaporu.raporDurumu);
                            sb.AppendLine("Taburcu Kodu :" + response.isgoremezlikRapor.hastalikRaporu.taburcuKodu);
                            sb.AppendLine("Taburcu Tarihi :" + response.isgoremezlikRapor.hastalikRaporu.taburcuTarihi);

                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                        if (response.isgoremezlikRapor.isKazasiRaporu != null)
                        {
                            sb.AppendLine("------------------------------İş Kazası Raporu--------------------------------");
                            sb.AppendLine("Başlangıç Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.bitisTarihi);
                            sb.AppendLine("XXXXXX Çıkış Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.XXXXXXCikisTarihi);
                            sb.AppendLine("XXXXXX Yatış Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.XXXXXXYatisTarihi);
                            sb.AppendLine("İş Kazası Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.isKazasiTarihi);
                            sb.AppendLine("İş-Kontol Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.isKontTarihi);
                            sb.AppendLine("Nuks :" + response.isgoremezlikRapor.isKazasiRaporu.nuks);
                            sb.AppendLine("Rapor Durumu :" + response.isgoremezlikRapor.isKazasiRaporu.raporDurumu);
                            sb.AppendLine("Taburcu Kodu :" + response.isgoremezlikRapor.isKazasiRaporu.taburcuKodu);
                            sb.AppendLine("Taburcu Tarihi :" + response.isgoremezlikRapor.isKazasiRaporu.taburcuTarihi);
                            sb.AppendLine("Yaranın Türü :" + response.isgoremezlikRapor.isKazasiRaporu.yaraninTuru);
                            sb.AppendLine("Yaranın Yeri :" + response.isgoremezlikRapor.isKazasiRaporu.yaraninYeri);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }
                        if (response.isgoremezlikRapor.meslekHastaligiRaporu != null)
                        {
                            sb.AppendLine("------------------------------Meslek Hastalığı Raporu--------------------------------");
                            sb.AppendLine("Başlangıç Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.baslangicTarihi);
                            sb.AppendLine("Bitiş Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.bitisTarihi);
                            sb.AppendLine("XXXXXX Çıkış Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.XXXXXXCikisTarihi);
                            sb.AppendLine("XXXXXX Yatış Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.XXXXXXYatisTarihi);
                            sb.AppendLine("İş-Kontol Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.isKontTarihi);
                            sb.AppendLine("Nuks :" + response.isgoremezlikRapor.meslekHastaligiRaporu.nuks);
                            sb.AppendLine("Rapor Durumu :" + response.isgoremezlikRapor.meslekHastaligiRaporu.raporDurumu);
                            sb.AppendLine("Taburcu Kodu :" + response.isgoremezlikRapor.meslekHastaligiRaporu.taburcuKodu);
                            sb.AppendLine("Taburcu Tarihi :" + response.isgoremezlikRapor.meslekHastaligiRaporu.taburcuTarihi);
                            sb.AppendLine("Yaranın Türü :" + response.isgoremezlikRapor.meslekHastaligiRaporu.yaraninTuru);
                            sb.AppendLine("Yaranın Yeri :" + response.isgoremezlikRapor.meslekHastaligiRaporu.yaraninYeri);
                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }

                        sb.AppendLine("Açıklama :" + response.isgoremezlikRapor.raporDVO.aciklama);
                        sb.AppendLine("Başlangıç Tarihi :" + response.isgoremezlikRapor.raporDVO.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.isgoremezlikRapor.raporDVO.bitisTarihi);
                        sb.AppendLine("Takip Numarası :" + response.isgoremezlikRapor.raporDVO.takipNo);
                        sb.AppendLine("Türü :" + response.isgoremezlikRapor.raporDVO.turu);

                        if (response.isgoremezlikRapor.raporDVO.doktorlar != null)
                        {
                            sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");

                            foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.isgoremezlikRapor.raporDVO.doktorlar)
                            {
                                sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                sb.AppendLine("Brans Kodu :" + _doktor.drBransKodu);
                                sb.AppendLine("Tescil Numarası :" + _doktor.drTescilNo);
                                sb.AppendLine("Tipi :" + _doktor.tipi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }



                        sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                        sb.AppendLine("Klinik Tanı :" + response.isgoremezlikRapor.raporDVO.klinikTani);
                        sb.AppendLine("Protokol Numarası :" + response.isgoremezlikRapor.raporDVO.protokolNo);
                        sb.AppendLine("Protokol Tarihi :" + response.isgoremezlikRapor.raporDVO.protokolTarihi);
                        sb.AppendLine("aVakaTKaza :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.aVakaTKaza);
                        sb.AppendLine("Rapor Numarası :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.no);
                        sb.AppendLine("Rapor Sıra Numarası :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.raporSiraNo);
                        sb.AppendLine("Rapor Takip Numarası :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.raporTakipNo);
                        sb.AppendLine("Rapor Tesis Kodu :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.raporTesisKodu);
                        sb.AppendLine("Tarih :" + response.isgoremezlikRapor.raporDVO.raporBilgisi.tarih);
                        sb.AppendLine("-----------------------------------------------------------------------------");

                        if (response.isgoremezlikRapor.raporDVO.tanilar != null)
                        {
                            sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                            RaporIslemleri.taniBilgisiDVO[] _tani = response.isgoremezlikRapor.raporDVO.tanilar;
                            for (int i = 0; i < _tani.Length; i++)
                            {
                                sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                            }

                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }

                        if (response.isgoremezlikRapor.raporDVO.teshisler != null)
                        {
                            sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.isgoremezlikRapor.raporDVO.teshisler)
                            {

                                sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        if (response.isgoremezlikRapor.raporDVO.ilacTeshisler != null)
                        {
                            sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.isgoremezlikRapor.raporDVO.ilacTeshisler)
                            {
                                sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }


                        #endregion

                    }
                    if (response.isgoremezlikRaporEkleri != null)
                    {
                        sb.AppendLine("-----------------------------İŞ GÖREMEZLİK RAPOR EK BİLGİSİ------------------------------");
                        sb.AppendLine("-------------------------------------------------------------------------------");
                        #region IsgoremezlikRaporEkDVO

                        foreach (RaporIslemleri.isgoremezlikRaporEkDVO _ek in response.isgoremezlikRaporEkleri)
                        {

                            sb.AppendLine("Açıklama :" + _ek.aciklama);
                            sb.AppendLine("Bitiş Tarihi:" + _ek.bitisTarihi);
                            if (_ek.doktorlar != null)
                            {
                                sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                                foreach (RaporIslemleri.doktorBilgisiDVO _doktor in _ek.doktorlar)
                                {
                                    sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                    sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                    sb.AppendLine("Brans Kodu :" + _doktor.drBransKodu);
                                    sb.AppendLine("Tescil Numarası :" + _doktor.drTescilNo);
                                    sb.AppendLine("Tipi :" + _doktor.tipi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                            sb.AppendLine("Durum :" + _ek.durum);
                            sb.AppendLine("Düzenleme Türü :" + _ek.duzenlemeTuru);
                            sb.AppendLine("Hasta Yatış Varmı :" + _ek.hastaYatisVarMi);
                            sb.AppendLine("Kontrol Mu? :" + _ek.kontrolMu);
                            sb.AppendLine("Kontrol Tarihi :" + _ek.kontrolTarihi);
                            sb.AppendLine("Kullanıcı Tesis Kodu :" + _ek.kullaniciTesisKodu);
                            sb.AppendLine("Protokol Numarası :" + _ek.protokolNo);
                            sb.AppendLine("Protokol tarihi :" + _ek.protokolTarihi);


                            sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                            sb.AppendLine("aVakaTKaza :" + _ek.raporBilgisiDVO.aVakaTKaza);
                            sb.AppendLine("Rapor Numarası :" + _ek.raporBilgisiDVO.no);
                            sb.AppendLine("Rapor Sıra Numarası :" + _ek.raporBilgisiDVO.raporSiraNo);
                            sb.AppendLine("Rapor Takip Numarası :" + _ek.raporBilgisiDVO.raporTakipNo);
                            sb.AppendLine("Rapor Tesis Kodu :" + _ek.raporBilgisiDVO.raporTesisKodu);
                            sb.AppendLine("Tarih :" + _ek.raporBilgisiDVO.tarih);
                            sb.AppendLine("-----------------------------------------------------------------------------");

                            if (_ek.tanilar != null)
                            {
                                sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                foreach (RaporIslemleri.taniBilgisiDVO _tani in _ek.tanilar)
                                {

                                    sb.AppendLine("tanı Kodu :" + _tani.taniKodu);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }
                            if (_ek.yatislar != null)
                            {
                                sb.AppendLine("------------------------------XXXXXX Yatış Bilgisi--------------------------------");
                                foreach (RaporIslemleri.hastaYatisBilgisiDVO _yatis in _ek.yatislar)
                                {

                                    sb.AppendLine("Çıkış Tarihi :" + _yatis.cikisTarihi);
                                    sb.AppendLine("Yatiş Tarihi :" + _yatis.yatisTarihi);
                                    sb.AppendLine("-----------------------------------------------------------------------------");
                                }
                            }

                        }

                        #endregion
                    }
                    if (response.maluliyetRapor != null && response.maluliyetRapor.raporDVO != null)
                    {
                        sb.AppendLine("-----------------------------MALULİYET RAPOR BİLGİSİ------------------------------");
                        sb.AppendLine("-------------------------------------------------------------------------------");
                        #region MaluliyetRaporDVO

                        sb.AppendLine("Açıklama :" + response.maluliyetRapor.aciklama);
                        //sb.AppendLine("Maluliyet Yüzdesi :" + response.maluliyetRapor.maluliyetYuzdesi);
                        sb.AppendLine("Açıklama :" + response.maluliyetRapor.raporDVO.aciklama);
                        sb.AppendLine("Başlangıç Tarihi :" + response.maluliyetRapor.raporDVO.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.maluliyetRapor.raporDVO.bitisTarihi);
                        sb.AppendLine("Takip Numarası :" + response.maluliyetRapor.raporDVO.takipNo);
                        sb.AppendLine("Türü :" + response.maluliyetRapor.raporDVO.turu);

                        if (response.maluliyetRapor.bransGorusleri != null)
                        {
                            sb.AppendLine("------------------------------Branş Doktor Bilgisi--------------------------------");
                            foreach (RaporIslemleri.bransGorusBilgisiDVO _bransGorus in response.maluliyetRapor.bransGorusleri)
                            {

                                sb.AppendLine("Açıklama :" + _bransGorus.aciklama);
                                sb.AppendLine("Branş Kodu :" + _bransGorus.bransKodu);
                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }
                        }


                        if (response.maluliyetRapor.raporDVO.doktorlar != null)
                        {
                            sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                            foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.maluliyetRapor.raporDVO.doktorlar)
                            {
                                sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                sb.AppendLine("Brans Kodu :" + _doktor.drBransKodu);
                                sb.AppendLine("Tescil Numarası :" + _doktor.drTescilNo);
                                sb.AppendLine("Tipi :" + _doktor.tipi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }


                        sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                        sb.AppendLine("Klinik Tanı :" + response.maluliyetRapor.raporDVO.klinikTani);
                        sb.AppendLine("Protokol Numarası :" + response.maluliyetRapor.raporDVO.protokolNo);
                        sb.AppendLine("Protokol Tarihi :" + response.maluliyetRapor.raporDVO.protokolTarihi);
                        sb.AppendLine("aVakaTKaza :" + response.maluliyetRapor.raporDVO.raporBilgisi.aVakaTKaza);
                        sb.AppendLine("Rapor Numarası :" + response.maluliyetRapor.raporDVO.raporBilgisi.no);
                        sb.AppendLine("Rapor Sıra Numarası :" + response.maluliyetRapor.raporDVO.raporBilgisi.raporSiraNo);
                        sb.AppendLine("Rapor Takip Numarası :" + response.maluliyetRapor.raporDVO.raporBilgisi.raporTakipNo);
                        sb.AppendLine("Rapor Tesis Kodu :" + response.maluliyetRapor.raporDVO.raporBilgisi.raporTesisKodu);
                        sb.AppendLine("Tarih :" + response.maluliyetRapor.raporDVO.raporBilgisi.tarih);
                        sb.AppendLine("-----------------------------------------------------------------------------");

                        if (response.maluliyetRapor.raporDVO.tanilar != null)
                        {
                            sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                            RaporIslemleri.taniBilgisiDVO[] _tani = response.maluliyetRapor.raporDVO.tanilar;
                            for (int i = 0; i < _tani.Length; i++)
                            {
                                sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                            }

                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }

                        if (response.maluliyetRapor.raporDVO.teshisler != null)
                        {
                            sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.maluliyetRapor.raporDVO.teshisler)
                            {

                                sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        if (response.maluliyetRapor.raporDVO.ilacTeshisler != null)
                        {
                            sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.maluliyetRapor.raporDVO.ilacTeshisler)
                            {
                                sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        #endregion

                    }
                    if (response.protezRapor != null)
                    {
                        sb.AppendLine("-----------------------------PROTEZ RAPOR BİLGİSİ------------------------------");
                        sb.AppendLine("-------------------------------------------------------------------------------");
                        #region ProtezRaporDVO

                        if (response.protezRapor.malzemeler != null)
                        {
                            sb.AppendLine("------------------------------Mazleme Bilgisi--------------------------------");
                            foreach (RaporIslemleri.malzemeBilgisiDVO _mazleme in response.protezRapor.malzemeler)
                            {

                                sb.AppendLine("Adet :" + _mazleme.adet);
                                sb.AppendLine("Mazleme Adı :" + _mazleme.malzemeAdi);
                                sb.AppendLine("Mazleme Kodu :" + _mazleme.malzemeKodu);
                                sb.AppendLine("Malzeme Türü :" + _mazleme.malzemeTuru);
                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }
                        }

                        sb.AppendLine("Açıklama :" + response.protezRapor.raporDVO.aciklama);
                        sb.AppendLine("Başlangıç Tarihi :" + response.protezRapor.raporDVO.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.protezRapor.raporDVO.bitisTarihi);
                        sb.AppendLine("Takip Numarası :" + response.protezRapor.raporDVO.takipNo);
                        sb.AppendLine("Türü :" + response.protezRapor.raporDVO.turu);

                        if (response.protezRapor.raporDVO.doktorlar != null)
                        {
                            sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                            foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.protezRapor.raporDVO.doktorlar)
                            {
                                sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                sb.AppendLine("Brans Kodu :" + _doktor.drBransKodu);
                                sb.AppendLine("Tescil Numarası :" + _doktor.drTescilNo);
                                sb.AppendLine("Tipi :" + _doktor.tipi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }


                        sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                        sb.AppendLine("Klinik Tanı :" + response.protezRapor.raporDVO.klinikTani);
                        sb.AppendLine("Protokol Numarası :" + response.protezRapor.raporDVO.protokolNo);
                        sb.AppendLine("Protokol Tarihi :" + response.protezRapor.raporDVO.protokolTarihi);
                        sb.AppendLine("aVakaTKaza :" + response.protezRapor.raporDVO.raporBilgisi.aVakaTKaza);
                        sb.AppendLine("Rapor Numarası :" + response.protezRapor.raporDVO.raporBilgisi.no);
                        sb.AppendLine("Rapor Sıra Numarası :" + response.protezRapor.raporDVO.raporBilgisi.raporSiraNo);
                        sb.AppendLine("Rapor Takip Numarası :" + response.protezRapor.raporDVO.raporBilgisi.raporTakipNo);
                        sb.AppendLine("Rapor Tesis Kodu :" + response.protezRapor.raporDVO.raporBilgisi.raporTesisKodu);
                        sb.AppendLine("Tarih :" + response.protezRapor.raporDVO.raporBilgisi.tarih);
                        sb.AppendLine("-----------------------------------------------------------------------------");

                        if (response.protezRapor.raporDVO.tanilar != null)
                        {
                            sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                            RaporIslemleri.taniBilgisiDVO[] _tani = response.protezRapor.raporDVO.tanilar;
                            for (int i = 0; i < _tani.Length; i++)
                            {
                                sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                            }

                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }

                        if (response.protezRapor.raporDVO.teshisler != null)
                        {
                            sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.protezRapor.raporDVO.teshisler)
                            {

                                sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        if (response.protezRapor.raporDVO.ilacTeshisler != null)
                        {
                            sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.protezRapor.raporDVO.ilacTeshisler)
                            {
                                sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        #endregion
                    }
                    if (response.tedaviRapor != null)
                    {
                        sb.AppendLine("-----------------------------TEDAVİ RAPOR BİLGİSİ------------------------------");
                        sb.AppendLine("-------------------------------------------------------------------------------");
                        #region TedaviRaporDVO

                        sb.AppendLine("Tedavi Rapor Türü :" + response.tedaviRapor.tedaviRaporTuru);

                        foreach (RaporIslemleri.tedaviIslemBilgisiDVO _tedavi in response.tedaviRapor.islemler)
                        {

                            if (_tedavi.diyalizRaporBilgisi != null)
                            {
                                sb.AppendLine("------------------------------Diyaliz Rapor Bilgisi--------------------------------");
                                sb.AppendLine("Tetkik Kodu :" + _tedavi.diyalizRaporBilgisi.butKodu);
                                sb.AppendLine("Refakat var Mı? :" + _tedavi.diyalizRaporBilgisi.refakatVarMi);
                                sb.AppendLine("Seans Gün :" + _tedavi.diyalizRaporBilgisi.seansGun);
                                sb.AppendLine("Seans Sayısı :" + _tedavi.diyalizRaporBilgisi.seansSayi);
                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }
                            if (_tedavi.eswlRaporBilgisi != null)
                            {
                                sb.AppendLine("------------------------------ESWL Rapor Bilgisi--------------------------------");
                                sb.AppendLine("Böbrek Bilgisi :" + _tedavi.eswlRaporBilgisi.bobrekBilgisi);
                                sb.AppendLine("Tetkik Kodu :" + _tedavi.eswlRaporBilgisi.butKodu);
                                sb.AppendLine("ESWL Raporu Seans Sayısı :" + _tedavi.eswlRaporBilgisi.eswlRaporuSeansSayisi);
                                sb.AppendLine("ESWL Raporu Taş Sayısı :" + _tedavi.eswlRaporBilgisi.eswlRaporuTasSayisi);
                                if (_tedavi.eswlRaporBilgisi.eswlRaporuTasBilgileri != null)
                                {
                                    sb.AppendLine("------------------------------ESWL Taş Bilgisi--------------------------------");
                                    foreach (RaporIslemleri.eswlTasBilgisiDVO _tasBilgisi in _tedavi.eswlRaporBilgisi.eswlRaporuTasBilgileri)
                                    {

                                        sb.AppendLine("Taş Boyutu :" + _tasBilgisi.tasBoyutu);
                                        sb.AppendLine("Taş Lokalizasyon Kodu :" + _tasBilgisi.tasLokalizasyonKodu);
                                        sb.AppendLine("-------------------------------------------------------------------------------");
                                    }
                                }

                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }
                            if (_tedavi.eswtRaporBilgisi != null)
                            {
                                sb.AppendLine("------------------------------ESWL Taş Bilgisi--------------------------------");
                                sb.AppendLine("Tetkik Kodu :" + _tedavi.eswtRaporBilgisi.butKodu);
                                sb.AppendLine("ESWT Vucut Bölgesi Kodu :" + _tedavi.eswtRaporBilgisi.eswtVucutBolgesiKodu);
                                sb.AppendLine("Seans Gün Sayısı :" + _tedavi.eswtRaporBilgisi.seansGun);
                                sb.AppendLine("Seans Sayısı :" + _tedavi.eswtRaporBilgisi.seansSayi);
                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }
                            if (_tedavi.evHemodiyaliziRaporBilgisi != null)
                            {
                                sb.AppendLine("------------------------------Hemodiyaliz Rapor Bilgisi--------------------------------");
                                sb.AppendLine("Tetkik Kodu :" + _tedavi.evHemodiyaliziRaporBilgisi.butKodu);
                                sb.AppendLine("Seans Gün Sayısı :" + _tedavi.evHemodiyaliziRaporBilgisi.seansGun);
                                sb.AppendLine("Seans Sayısı :" + _tedavi.evHemodiyaliziRaporBilgisi.seansSayi);
                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }
                            if (_tedavi.ftrRaporBilgisi != null)
                            {
                                sb.AppendLine("------------------------------FTR Rapor Bilgisi--------------------------------");
                                sb.AppendLine("Tetkik Kodu :" + _tedavi.ftrRaporBilgisi.butKodu);
                                sb.AppendLine("FTR Vucut Bölgesi Kodu :" + _tedavi.ftrRaporBilgisi.ftrVucutBolgesiKodu);
                                sb.AppendLine("Robotik Rehabilitasyon :" + _tedavi.ftrRaporBilgisi.robotikRehabilitasyon);
                                sb.AppendLine("Seans Gün Sayısı :" + _tedavi.ftrRaporBilgisi.seansGun);
                                sb.AppendLine("Seans Sayısı :" + _tedavi.ftrRaporBilgisi.seansSayi);
                                sb.AppendLine("Tedavi Türü :" + _tedavi.ftrRaporBilgisi.tedaviTuru);
                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }
                            if (_tedavi.hotRaporBilgisi != null)
                            {
                                sb.AppendLine("------------------------------HOT Rapor Bilgisi--------------------------------");
                                sb.AppendLine("Seans Gün Sayısı :" + _tedavi.hotRaporBilgisi.seansGun);
                                sb.AppendLine("Seans Sayısı :" + _tedavi.hotRaporBilgisi.seansSayi);
                                sb.AppendLine("Tedavi Süresi :" + _tedavi.hotRaporBilgisi.tedaviSuresi);
                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }
                            if (_tedavi.tupBebekRaporBilgisi != null)
                            {
                                sb.AppendLine("------------------------------HOT Rapor Bilgisi--------------------------------");
                                sb.AppendLine("Tetkik Kodu  :" + _tedavi.tupBebekRaporBilgisi.butKodu);
                                sb.AppendLine("Tüp Bebek Rapor Türü :" + _tedavi.tupBebekRaporBilgisi.tupBebekRaporTuru);
                                sb.AppendLine("-------------------------------------------------------------------------------");
                            }

                        }


                        sb.AppendLine("Açıklama :" + response.tedaviRapor.raporDVO.aciklama);
                        sb.AppendLine("Başlangıç Tarihi :" + response.tedaviRapor.raporDVO.baslangicTarihi);
                        sb.AppendLine("Bitiş Tarihi :" + response.tedaviRapor.raporDVO.bitisTarihi);
                        sb.AppendLine("Takip Numarası :" + response.tedaviRapor.raporDVO.takipNo);
                        sb.AppendLine("Türü :" + response.tedaviRapor.raporDVO.turu);

                        if (response.tedaviRapor.raporDVO.doktorlar != null)
                        {
                            sb.AppendLine("------------------------------Doktor Bilgisi--------------------------------");
                            foreach (RaporIslemleri.doktorBilgisiDVO _doktor in response.tedaviRapor.raporDVO.doktorlar)
                            {
                                sb.AppendLine("Doktor Adı :" + _doktor.drAdi);
                                sb.AppendLine("Doktor Soyadı :" + _doktor.drSoyadi);
                                sb.AppendLine("Brans Kodu :" + _doktor.drBransKodu);
                                sb.AppendLine("Tescil Numarası :" + _doktor.drTescilNo);
                                sb.AppendLine("Tipi :" + _doktor.tipi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }


                        sb.AppendLine("------------------------------Rapor Bilgisi--------------------------------");
                        sb.AppendLine("Klinik Tanı :" + response.tedaviRapor.raporDVO.klinikTani);
                        sb.AppendLine("Protokol Numarası :" + response.tedaviRapor.raporDVO.protokolNo);
                        sb.AppendLine("Protokol Tarihi :" + response.tedaviRapor.raporDVO.protokolTarihi);
                        sb.AppendLine("aVakaTKaza :" + response.tedaviRapor.raporDVO.raporBilgisi.aVakaTKaza);
                        sb.AppendLine("Rapor Numarası :" + response.tedaviRapor.raporDVO.raporBilgisi.no);
                        sb.AppendLine("Rapor Sıra Numarası :" + response.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo);
                        sb.AppendLine("Rapor Takip Numarası :" + response.tedaviRapor.raporDVO.raporBilgisi.raporTakipNo);
                        sb.AppendLine("Rapor Tesis Kodu :" + response.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu);
                        sb.AppendLine("Tarih :" + response.tedaviRapor.raporDVO.raporBilgisi.tarih);
                        sb.AppendLine("-----------------------------------------------------------------------------");

                        if (response.tedaviRapor.raporDVO.tanilar != null)
                        {
                            sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                            RaporIslemleri.taniBilgisiDVO[] _tani = response.tedaviRapor.raporDVO.tanilar;
                            for (int i = 0; i < _tani.Length; i++)
                            {
                                sb.AppendLine("Tanı Kodu :" + _tani[i].taniKodu);
                            }

                            sb.AppendLine("-----------------------------------------------------------------------------");
                        }

                        if (response.tedaviRapor.raporDVO.teshisler != null)
                        {
                            sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.teshisBilgisiDVO _teshis in response.tedaviRapor.raporDVO.teshisler)
                            {

                                sb.AppendLine("Başlangıç Tarihi :" + _teshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _teshis.bitisTarihi);
                                sb.AppendLine("Teshis Kodu :" + _teshis.teshisKodu);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }

                        if (response.tedaviRapor.raporDVO.ilacTeshisler != null)
                        {
                            sb.AppendLine("------------------------------İlaç Teşhis Bilgisi--------------------------------");
                            foreach (RaporIslemleri.ilacTeshisBilgiDVO _ilacTeshis in response.tedaviRapor.raporDVO.ilacTeshisler)
                            {
                                sb.AppendLine("Tanı Kodu :" + _ilacTeshis.ICD10Kodu);
                                sb.AppendLine("Teşhis Kodu :" + _ilacTeshis.teshisKodu);
                                sb.AppendLine("Başlangıç Tarihi :" + _ilacTeshis.baslangicTarihi);
                                sb.AppendLine("Bitiş Tarihi :" + _ilacTeshis.bitisTarihi);
                                sb.AppendLine("-----------------------------------------------------------------------------");
                            }
                        }
                        #endregion
                    }
                    txtResult.Visible = true;
                    txtResult.Text = sb.ToString();
                    if(string.IsNullOrEmpty(txtResult.Text))
                        txtResult.Text="Rapor Bilgisi Mevcut Değildir";
                }
            }
#endregion MedulaRaporIslemleri_btnSearchReportInfo_Click
        }

        private void chkFtrHeyetRaporu_CheckedChanged()
        {
#region MedulaRaporIslemleri_chkFtrHeyetRaporu_CheckedChanged
   if (((TTVisual.TTCheckBox)(chkFtrHeyetRaporu)).Checked)
            {
                lstTabip3.Visible = true;
                lstTabip2.Visible = true;
                lblTabip3.Visible= true;
                lblTabip2.Visible = true;
            }
            else
            {
                lstTabip3.Visible = false;
                lstTabip2.Visible = false;
                lblTabip3.Visible= false;
                lblTabip2.Visible = false;
            }
#endregion MedulaRaporIslemleri_chkFtrHeyetRaporu_CheckedChanged
        }

        private void btnRaporArama_Click()
        {
#region MedulaRaporIslemleri_btnRaporArama_Click
   gridFtrRaporlari.Rows.Clear();
            gridEswlRaporlari.Rows.Clear();
            gridDiyalizRaporlari.Rows.Clear();
            gridEvHemodiyalizRaporlari.Rows.Clear();
            gridHOTRaporlari.Rows.Clear();
            gridTupBebekRaporlari.Rows.Clear();

            RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
            //TODO : MEDULA20140501
            _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            _raporOkuTCKimlikNodanDVO.raporTuru = "1";
            _raporOkuTCKimlikNodanDVO.tckimlikNo = txtTCKNo.Text.Trim();
            RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
            if (response != null)
            {
                if (response.sonucKodu.Equals(0))
                {
                    int ftrKontrol = 0;
                    int ftrTrafikKazasiKontrol = 0;
                    int eswtKontrol = 0;
                    int eswlKontrol = 0;
                    int diyalizKontrol = 0;
                    int evHemodiyalizKontrol = 0;
                    int hOTKontrol = 0;
                    int tupBebekKontrol = 0;
                    List<RaporIslemleri.raporCevapDVO> _raporCevapDVOList = new List<RaporIslemleri.raporCevapDVO>();
                    if(response.raporlar == null)
                    {
                        InfoBox.Show("Rapor bulunamadı.", MessageIconEnum.InformationMessage);
                        return;
                    }
                    
                    foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                    {
                        if (item.tedaviRapor != null)
                        {
                            foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedavi in item.tedaviRapor.islemler)
                            {
                                if(cmbRaporTuru.SelectedItem !=null)
                                {
                                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTR).Value && tedavi.ftrRaporBilgisi != null)
                                    {
                                        ITTGridRow newRow = gridFtrRaporlari.Rows.Add();
                                        newRow.Cells[raporTakipNo.Name].Value = item.raporTakipNo;//item.ProvisionNo;
                                        newRow.Cells[raporNumarasi.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        newRow.Cells[raporSiraNo.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                        
                                        IList fTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesiQuery();
                                        foreach (FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class fTRVucutBolgesi in fTRVucutBolgesiList)
                                        {
                                            if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedavi.ftrRaporBilgisi.ftrVucutBolgesiKodu)
                                                newRow.Cells[raporVucutBolgesi.Name].Value = fTRVucutBolgesi.ftrVucutBolgesiAdi;
                                        }
                                        newRow.Cells[kur.Name].Value = tedavi.ftrRaporBilgisi.seansSayi;
                                        newRow.Cells[raporGonderimTarihi.Name].Value = item.tedaviRapor.raporDVO.baslangicTarihi;
                                        newRow.Cells[raporTesisi.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                        ftrKontrol++;
                                    }
                                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTRTRAFIKKAZASI).Value && tedavi.ftrRaporBilgisi != null)
                                    {
                                        ITTGridRow newRow = gridFtrRaporlari.Rows.Add();
                                        newRow.Cells[raporTakipNo.Name].Value = item.raporTakipNo;//item.ProvisionNo;
                                        newRow.Cells[raporNumarasi.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        newRow.Cells[raporSiraNo.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                        
                                        IList fTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesiQuery();
                                        foreach (FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class fTRVucutBolgesi in fTRVucutBolgesiList)
                                        {
                                            if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedavi.ftrRaporBilgisi.ftrVucutBolgesiKodu)
                                                newRow.Cells[raporVucutBolgesi.Name].Value = fTRVucutBolgesi.ftrVucutBolgesiAdi;
                                        }
                                        newRow.Cells[kur.Name].Value = tedavi.ftrRaporBilgisi.seansSayi;
                                        newRow.Cells[raporGonderimTarihi.Name].Value = item.tedaviRapor.raporDVO.baslangicTarihi;
                                        newRow.Cells[raporTesisi.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                        ftrTrafikKazasiKontrol++;
                                    }
                                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWT).Value && tedavi.eswtRaporBilgisi != null)
                                    {
                                        ITTGridRow newRow = gridFtrRaporlari.Rows.Add();
                                        newRow.Cells[raporTakipNo.Name].Value = item.raporTakipNo;//item.ProvisionNo;
                                        newRow.Cells[raporNumarasi.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        newRow.Cells[raporSiraNo.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;

                                        IList eSWTVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesiQuery();
                                        foreach (FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class eSWTVucutBolgesi in eSWTVucutBolgesiList)
                                        {
                                            if (eSWTVucutBolgesi.ftrVucutBolgesiKodu == tedavi.eswtRaporBilgisi.eswtVucutBolgesiKodu)
                                                newRow.Cells[raporVucutBolgesi.Name].Value = eSWTVucutBolgesi.ftrVucutBolgesiAdi;
                                        }
                                        newRow.Cells[kur.Name].Value = tedavi.eswtRaporBilgisi.seansSayi;
                                        newRow.Cells[raporGonderimTarihi.Name].Value = item.tedaviRapor.raporDVO.baslangicTarihi;
                                        newRow.Cells[raporTesisi.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                        eswtKontrol++;
                                    }
                                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWL).Value && tedavi.eswlRaporBilgisi != null)
                                    {
                                        ITTGridRow newRow = gridEswlRaporlari.Rows.Add();
                                        newRow.Cells[raporTakipNoEswl.Name].Value = item.raporTakipNo;//item.ProvisionNo;
                                        newRow.Cells[raporNumarasiEswl.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        newRow.Cells[raporSiraNoEswl.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                        newRow.Cells[raporGonderimTarihiEswl.Name].Value = item.tedaviRapor.raporDVO.baslangicTarihi;
                                        newRow.Cells[sonucKoduEswl.Name].Value = response.sonucKodu;
                                        newRow.Cells[sonucMesajiEswl.Name].Value = response.sonucAciklamasi;
                                        newRow.Cells[raporTesisiEswl.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                        eswlKontrol++;
                                    }
                                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.DIYALIZ).Value && tedavi.diyalizRaporBilgisi != null)
                                    {
                                        ITTGridRow newRow = gridDiyalizRaporlari.Rows.Add();
                                        newRow.Cells[raporTakipNoDiyaliz.Name].Value = item.raporTakipNo;
                                        newRow.Cells[raporNumarasiDiyaliz.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        newRow.Cells[raporSiraNoDiyaliz.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                        newRow.Cells[raporGonderimTarihiDiyaliz.Name].Value = item.tedaviRapor.raporDVO.baslangicTarihi;
                                        newRow.Cells[sonucKoduDiyaliz.Name].Value = response.sonucKodu;
                                        newRow.Cells[sonucMesajiDiyaliz.Name].Value = response.sonucAciklamasi;
                                        newRow.Cells[raporTesisiDiyaliz.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                        diyalizKontrol++;
                                    }
                                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.EVHEMODIYALIZI).Value && item.tedaviRapor.tedaviRaporTuru == 8)
                                    {
                                        ITTGridRow newRow = gridEvHemodiyalizRaporlari.Rows.Add();
                                        newRow.Cells[raporTakipNoEvHemodiyaliz.Name].Value = item.raporTakipNo;
                                        newRow.Cells[raporNumarasiEvHemodiyaliz.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        newRow.Cells[raporSiraNoEvHemodiyaliz.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                        newRow.Cells[raporGonderimTarihiEvHemodiyaliz.Name].Value = item.tedaviRapor.raporDVO.baslangicTarihi;
                                        newRow.Cells[sonucKoduEvHemodiyaliz.Name].Value = response.sonucKodu;
                                        newRow.Cells[sonucMesajiEvHemodiyaliz.Name].Value = response.sonucAciklamasi;
                                        newRow.Cells[raporTesisiEvHemodiyaliz.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                        evHemodiyalizKontrol++;
                                    }
                                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.HBT).Value && tedavi.hotRaporBilgisi != null)
                                    {
                                        ITTGridRow newRow = gridHOTRaporlari.Rows.Add();
                                        newRow.Cells[raporTakipNoHOT.Name].Value = item.raporTakipNo;
                                        newRow.Cells[raporNumarasiHOT.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        newRow.Cells[raporSiraNoHOT.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                        newRow.Cells[raporGonderimTarihiHOT.Name].Value = item.tedaviRapor.raporDVO.baslangicTarihi;
                                        newRow.Cells[sonucKoduHOT.Name].Value = response.sonucKodu;
                                        newRow.Cells[sonucMesajiHOT.Name].Value = response.sonucAciklamasi;
                                        newRow.Cells[raporTesisiHOT.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                        hOTKontrol++;
                                    }
                                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.TUPBEBEK).Value && tedavi.tupBebekRaporBilgisi != null)
                                    {
                                        ITTGridRow newRow = gridTupBebekRaporlari.Rows.Add();
                                        newRow.Cells[raporTakipNoTupBebek.Name].Value = item.raporTakipNo;
                                        newRow.Cells[raporNumarasiTupBebek.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                        newRow.Cells[raporSiraNoTupBebek.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                        newRow.Cells[raporGonderimTarihiTupBebek.Name].Value = item.tedaviRapor.raporDVO.baslangicTarihi;
                                        newRow.Cells[sonucKoduTupBebek.Name].Value = response.sonucKodu;
                                        newRow.Cells[sonucMesajiTupBebek.Name].Value = response.sonucAciklamasi;
                                        newRow.Cells[raporTesisiTupBebek.Name].Value = item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0" ? Common.GetSaglikTesisleri(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString()) : item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString();
                                        tupBebekKontrol++;
                                    }
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTR).Value && ftrKontrol == 0)
                    {
                        InfoBox.Show("Hastanın FTR Raporu Bulunmamaktadır ! ");
                        return;
                    }
                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTRTRAFIKKAZASI).Value && ftrTrafikKazasiKontrol == 0)
                    {
                        InfoBox.Show("Hastanın FTR-Tarifik Kazası Raporu Bulunmamaktadır ! ");
                        return;
                    }
                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWT).Value && eswtKontrol == 0)
                    {
                        InfoBox.Show("Hastanın ESWT Raporu Bulunmamaktadır ! ");
                        return;
                    }
                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWL).Value && eswlKontrol == 0)
                    {
                        InfoBox.Show("Hastanın ESWL Raporu Bulunmamaktadır ! ");
                        return;
                    }
                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.DIYALIZ).Value && diyalizKontrol == 0)
                    {
                        InfoBox.Show("Hastanın Diyaliz Raporu Bulunmamaktadır ! ");
                        return;
                    }
                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.EVHEMODIYALIZI).Value && evHemodiyalizKontrol == 0)
                    {
                        InfoBox.Show("Hastanın Ev Hemodiyaliz Raporu Bulunmamaktadır ! ");
                        return;
                    }
                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.HBT).Value && hOTKontrol == 0)
                    {
                        InfoBox.Show("Hastanın HOT Raporu Bulunmamaktadır ! ");
                        return;
                    }
                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.TUPBEBEK).Value && tupBebekKontrol == 0)
                    {
                        InfoBox.Show("Hastanın Tüp Bebek Raporu Bulunmamaktadır ! ");
                        return;
                    }
                }
            }
#endregion MedulaRaporIslemleri_btnRaporArama_Click
        }

        private void cmbRaporTuru_SelectedIndexChanged()
        {
#region MedulaRaporIslemleri_cmbRaporTuru_SelectedIndexChanged
   gridHastaAktifTakipleri.Rows.Clear();

            if (((ITTComboBox)((TTVisual.TTComboBox)(cmbRaporTuru))).SelectedItem != null)
            {
                if (((ITTComboBox)((TTVisual.TTComboBox)(cmbRaporTuru))).SelectedItem.Value != null)
                {
                    string result = ((ITTComboBox)((TTVisual.TTComboBox)(cmbRaporTuru))).SelectedItem.Value.ToString();
                    if (result == "0")
                    {
                        if (Common.CurrentResource.UserType == UserTypeEnum.Doctor)
                        {
                            this.lstTabip.SelectedObject = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                        }
                    }
                }
            }
            
            // if(this.cmbRaporTuru.SelectedItem.Value != null && this.cmbRaporTuru.SelectedItem.Value ==
            
            
            if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTR).Value || (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWT).Value || Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTRTRAFIKKAZASI).Value) && chkRaporKaydet.Value == true)
            {
                List<string> FTRBransKodlari = new List<string>();
                FTRBransKodlari.Add("1800");
                FTRBransKodlari.Add("1855");
                FTRBransKodlari.Add("2600");
                FTRBransKodlari.Add("2679");
                FTRBransKodlari.Add("4000");
                FTRBransKodlari.Add("600");
                
                foreach (ITTGridRow item in gridHastaAktifTumTakipler.Rows)
                {
                    if (FTRBransKodlari.Contains(item.Cells[txtBransKodu2.Name].Value.ToString()))
                    {
                        ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                        newRow.Cells[txtTakipNo1.Name].Value = item.Cells[txtTakipNo2.Name].Value;
                        newRow.Cells[txtBrans1.Name].Value = item.Cells[txtBrans2.Name].Value;
                        newRow.Cells[txtProvizyonTarihi1.Name].Value = item.Cells[txtProvizyonTarihi2.Name].Value;
                        newRow.Cells[txtBagliTakipNo1.Name].Value = item.Cells[txtBagliTakipNo2.Name].Value;
                        newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = item.Cells[txtXXXXXXProtocolNo2.Name].Value;
                        newRow.Cells[txtVakaAcilisTarihi1.Name].Value = item.Cells[txtVakaAcilisTarihi2.Name].Value;
                        newRow.Cells[txtBransKodu1.Name].Value = item.Cells[txtBransKodu2.Name].Value;
                        newRow.Cells[txtTedaviTuru1.Name].Value = item.Cells[txtTedaviTuru2.Name].Value; 
                    }
//                     foreach (ITTGridRow item2 in gridFizyoTerapiIslemleri.Rows)
//                     {
//                        item2.Cells[TedaviTuru.Name].Value = item.Cells[txtTedaviTuru2.Name].Value; 
//                     }
                }
                this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);
                if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTR).Value || Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) ==  Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTRTRAFIKKAZASI).Value)
                {
                    this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabFtrRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                    chkFtrHeyetRaporu.Visible= true;
                    if (((TTVisual.TTCheckBox)(chkFtrHeyetRaporu)).Checked)
                    {
                        lstTabip2.Visible = true;
                        lstTabip3.Visible = true;
                        lblTabip2.Visible = true;
                        lblTabip3.Visible = true;
                    }

                    this.tttabRaporlar.ShowTabPage(tttabFtrRaporlari);
                    foreach (ITTTabPage tabPage in tttabRaporlar.TabPages)
                    {
                        if (tabPage == tttabFtrRaporlari)
                            tabPage.Text = "FTR Raporları";
                    }                    
                }
                if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWT).Value)
                {
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabESWTRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                    this.tttabRaporlar.ShowTabPage(tttabFtrRaporlari);
                    chkFtrHeyetRaporu.Visible= false;
                    lstTabip2.Visible = false;
                    lstTabip3.Visible = false;
                    lblTabip2.Visible = false;
                    lblTabip3.Visible = false;
                    foreach (ITTTabPage tabPage in tttabRaporlar.TabPages)
                    {
                        if (tabPage == tttabFtrRaporlari)
                            tabPage.Text = "ESWT Raporları";
                    }
                }
                this.tttabRaporlar.ShowTabPage(tttabFtrRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTumRaporlar);
                this.tttabRaporlar.HideTabPage(tttabEswlRaporlari);
                this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);
                gridHastaAktifTakipleri.Visible = true;
                lstTabip.Visible = true;
                RaporBaslangicTarihi.Visible = true;
                RaporBitisTarihi.Visible = true;
                lstTabip.Required = true;
                RaporBaslangicTarihi.Required = true;
                RaporBitisTarihi.Required = true;
                FizyoterapiIslemi.Required = true;
                VucutBolgesi.Required = true;
                SeansSayisi.Required = true;
                //TedaviTuru.Required = true;
                lblTabip.Visible = true;
                lblRaporBaslangicTarihi.Visible = true;
                lblRaporBitisTarihi.Visible = true;
                ((TTVisual.TTDateTimePicker)(this.RaporBaslangicTarihi)).Value = Common.RecTime();
                ((TTVisual.TTDateTimePicker)(this.RaporBitisTarihi)).Value = Common.RecTime().AddDays(365);
                
                
                btnRaporArama.Visible = true;
            }
            else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWL).Value && chkRaporKaydet.Value == true)
            {
                List<string> ESWLBransKodlari = new List<string>();
                ESWLBransKodlari.Add("2700");
                ESWLBransKodlari.Add("2781");
                ESWLBransKodlari.Add("2796");
                
                foreach (ITTGridRow item in gridHastaAktifTumTakipler.Rows)
                {
                    if (ESWLBransKodlari.Contains(item.Cells[txtBransKodu2.Name].Value.ToString()))
                    {
                        ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                        newRow.Cells[txtTakipNo1.Name].Value = item.Cells[txtTakipNo2.Name].Value;
                        newRow.Cells[txtBrans1.Name].Value = item.Cells[txtBrans2.Name].Value;
                        newRow.Cells[txtProvizyonTarihi1.Name].Value = item.Cells[txtProvizyonTarihi2.Name].Value;
                        newRow.Cells[txtBagliTakipNo1.Name].Value = item.Cells[txtBagliTakipNo2.Name].Value;
                        newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = item.Cells[txtXXXXXXProtocolNo2.Name].Value;
                        newRow.Cells[txtVakaAcilisTarihi1.Name].Value = item.Cells[txtVakaAcilisTarihi2.Name].Value;
                        newRow.Cells[txtBransKodu1.Name].Value = item.Cells[txtBransKodu2.Name].Value;
                        newRow.Cells[txtTedaviTuru1.Name].Value = item.Cells[txtTedaviTuru2.Name].Value; 
                    }
                }
                this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);

                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabESWLRaporKaydet);
                this.tttabRaporlar.ShowTabPage(tttabEswlRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTumRaporlar);
                this.tttabRaporlar.HideTabPage(tttabFtrRaporlari);
                this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);
                gridHastaAktifTakipleri.Visible = true;
                lstTabip.Visible = true;
                RaporBaslangicTarihi.Visible = true;
                RaporBitisTarihi.Visible = true;
                lstTabip.Required = true;
                RaporBaslangicTarihi.Required = true;
                RaporBitisTarihi.Required = true;
                lblTabip.Visible = true;
                lblRaporBaslangicTarihi.Visible = true;
                lblRaporBitisTarihi.Visible = true;
                
                ((TTVisual.TTDateTimePicker)(this.RaporBaslangicTarihi)).Value = Common.RecTime();
                ((TTVisual.TTDateTimePicker)(this.RaporBitisTarihi)).Value = Common.RecTime().AddDays(365);
                chkFtrHeyetRaporu.Visible= false;
                lstTabip2.Visible = false;
                lstTabip3.Visible = false;
                lblTabip2.Visible = false;
                lblTabip3.Visible = false;
                
                btnRaporArama.Visible = true;
            }
            else if ((Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.DIYALIZ).Value || Convert.ToInt32(cmbRaporTuru.SelectedItem.Value)  == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.EVHEMODIYALIZI).Value) && chkRaporKaydet.Value == true)
            {
                
                List<string> DiyalizBransKodlari = new List<string>();
                DiyalizBransKodlari.Add("1062");

                foreach (ITTGridRow item in gridHastaAktifTumTakipler.Rows)
                {
                    if (DiyalizBransKodlari.Contains(item.Cells[txtBransKodu2.Name].Value.ToString()))
                    {
                        ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                        newRow.Cells[txtTakipNo1.Name].Value = item.Cells[txtTakipNo2.Name].Value;
                        newRow.Cells[txtBrans1.Name].Value = item.Cells[txtBrans2.Name].Value;
                        newRow.Cells[txtProvizyonTarihi1.Name].Value = item.Cells[txtProvizyonTarihi2.Name].Value;
                        newRow.Cells[txtBagliTakipNo1.Name].Value = item.Cells[txtBagliTakipNo2.Name].Value;
                        newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = item.Cells[txtXXXXXXProtocolNo2.Name].Value;
                        newRow.Cells[txtVakaAcilisTarihi1.Name].Value = item.Cells[txtVakaAcilisTarihi2.Name].Value;
                        newRow.Cells[txtBransKodu1.Name].Value = item.Cells[txtBransKodu2.Name].Value;
                        newRow.Cells[txtTedaviTuru1.Name].Value = item.Cells[txtTedaviTuru2.Name].Value; 
                    }
                }
                if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value)  == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.EVHEMODIYALIZI).Value)
                {
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabEvHemoDiyalizRaporKaydet);
                    this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                    this.tttabRaporlar.ShowTabPage(tttabEvHemodiyalizRaporlari);
                }
                else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value)  == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.DIYALIZ).Value)
                {
                    this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabDiyalizRaporKaydet);
                    this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                    this.tttabRaporlar.ShowTabPage(tttabDiyalizRaporlari);
                    this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                }

                this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);
                
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                //this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabDiyalizRaporKaydet);
                //this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                //this.tttabRaporlar.ShowTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEswlRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTumRaporlar);
                this.tttabRaporlar.HideTabPage(tttabFtrRaporlari);
                //this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari)
                this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);
                gridHastaAktifTakipleri.Visible = true;
                lstTabip.Visible = true;
                RaporBaslangicTarihi.Visible = true;
                RaporBitisTarihi.Visible = true;
                lstTabip.Required = true;
                RaporBaslangicTarihi.Required = true;
                RaporBitisTarihi.Required = true;
                lblTabip.Visible = true;
                lblRaporBaslangicTarihi.Visible = true;
                lblRaporBitisTarihi.Visible = true;
                ((TTVisual.TTDateTimePicker)(this.RaporBaslangicTarihi)).Value = Common.RecTime();
                ((TTVisual.TTDateTimePicker)(this.RaporBitisTarihi)).Value = Common.RecTime().AddDays(365);
                chkFtrHeyetRaporu.Visible= false;
                lstTabip2.Visible = false;
                lstTabip3.Visible = false;
                lblTabip2.Visible = false;
                lblTabip3.Visible = false;
                
                btnRaporArama.Visible = true;
                
            }
            else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.TUPBEBEK).Value && chkRaporKaydet.Value == true)
            {

                List<string> TupBebekBransKodlari = new List<string>();
                TupBebekBransKodlari.Add("3000");
                TupBebekBransKodlari.Add("3050");

                foreach (ITTGridRow item in gridHastaAktifTumTakipler.Rows)
                {
                    if (TupBebekBransKodlari.Contains(item.Cells[txtBransKodu2.Name].Value.ToString()))
                    {
                        ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                        newRow.Cells[txtTakipNo1.Name].Value = item.Cells[txtTakipNo2.Name].Value;
                        newRow.Cells[txtBrans1.Name].Value = item.Cells[txtBrans2.Name].Value;
                        newRow.Cells[txtProvizyonTarihi1.Name].Value = item.Cells[txtProvizyonTarihi2.Name].Value;
                        newRow.Cells[txtBagliTakipNo1.Name].Value = item.Cells[txtBagliTakipNo2.Name].Value;
                        newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = item.Cells[txtXXXXXXProtocolNo2.Name].Value;
                        newRow.Cells[txtVakaAcilisTarihi1.Name].Value = item.Cells[txtVakaAcilisTarihi2.Name].Value;
                        newRow.Cells[txtBransKodu1.Name].Value = item.Cells[txtBransKodu2.Name].Value;
                        newRow.Cells[txtTedaviTuru1.Name].Value = item.Cells[txtTedaviTuru2.Name].Value;
                    }
                }
                this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);

                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabTupBebekRaporKaydet);
                this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEswlRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTumRaporlar);
                this.tttabRaporlar.HideTabPage(tttabFtrRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                this.tttabRaporlar.ShowTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);

                gridHastaAktifTakipleri.Visible = true;
                lstTabip.Visible = true;
                RaporBaslangicTarihi.Visible = true;
                RaporBitisTarihi.Visible = true;
                lstTabip.Required = true;
                RaporBaslangicTarihi.Required = true;
                RaporBitisTarihi.Required = true;
                lblTabip.Visible = true;
                lblRaporBaslangicTarihi.Visible = true;
                lblRaporBitisTarihi.Visible = true;
                ((TTVisual.TTDateTimePicker)(this.RaporBaslangicTarihi)).Value = Common.RecTime();
                ((TTVisual.TTDateTimePicker)(this.RaporBitisTarihi)).Value = Common.RecTime().AddDays(365);
                chkFtrHeyetRaporu.Visible= false;
                lstTabip2.Visible = false;
                lstTabip3.Visible = false;
                lblTabip2.Visible = false;
                lblTabip3.Visible = false;

                btnRaporArama.Visible = true;

            }
            else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value)  == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.HBT).Value && chkRaporKaydet.Value == true)
            {
                List<string> HOTBransKodlari = new List<string>();
                HOTBransKodlari.Add("4300");
                HOTBransKodlari.Add("4200");

                foreach (ITTGridRow item in gridHastaAktifTumTakipler.Rows)
                {
                    if (HOTBransKodlari.Contains(item.Cells[txtBransKodu2.Name].Value.ToString()))
                    {
                        ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                        newRow.Cells[txtTakipNo1.Name].Value = item.Cells[txtTakipNo2.Name].Value;
                        newRow.Cells[txtBrans1.Name].Value = item.Cells[txtBrans2.Name].Value;
                        newRow.Cells[txtProvizyonTarihi1.Name].Value = item.Cells[txtProvizyonTarihi2.Name].Value;
                        newRow.Cells[txtBagliTakipNo1.Name].Value = item.Cells[txtBagliTakipNo2.Name].Value;
                        newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = item.Cells[txtXXXXXXProtocolNo2.Name].Value;
                        newRow.Cells[txtVakaAcilisTarihi1.Name].Value = item.Cells[txtVakaAcilisTarihi2.Name].Value;
                        newRow.Cells[txtBransKodu1.Name].Value = item.Cells[txtBransKodu2.Name].Value;
                        newRow.Cells[txtTedaviTuru1.Name].Value = item.Cells[txtTedaviTuru2.Name].Value; 
                    }
                }
                this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);

                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabHOTRaporKaydet);
                this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEswlRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTumRaporlar);
                this.tttabRaporlar.HideTabPage(tttabFtrRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.ShowTabPage(tttabHOTRaporlari);

                gridHastaAktifTakipleri.Visible = true;
                lstTabip.Visible = true;
                RaporBaslangicTarihi.Visible = true;
                RaporBitisTarihi.Visible = true;
                lstTabip.Required = true;
                RaporBaslangicTarihi.Required = true;
                RaporBitisTarihi.Required = true;
                lblTabip.Visible = true;
                lblRaporBaslangicTarihi.Visible = true;
                lblRaporBitisTarihi.Visible = true;
                ((TTVisual.TTDateTimePicker)(this.RaporBaslangicTarihi)).Value = Common.RecTime();
                ((TTVisual.TTDateTimePicker)(this.RaporBitisTarihi)).Value = Common.RecTime().AddDays(365);
                chkFtrHeyetRaporu.Visible= true;
                lstTabip2.Visible = true;
                lstTabip3.Visible = true;
                lblTabip2.Visible = true;
                lblTabip3.Visible = true;

                btnRaporArama.Visible = true;

            }
            else
            {
                foreach (ITTGridRow item in gridHastaAktifTumTakipler.Rows)
                {
                    ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                    newRow.Cells[txtTakipNo1.Name].Value = item.Cells[txtTakipNo2.Name].Value;
                    newRow.Cells[txtBrans1.Name].Value = item.Cells[txtBrans2.Name].Value;
                    newRow.Cells[txtProvizyonTarihi1.Name].Value = item.Cells[txtProvizyonTarihi2.Name].Value;
                    newRow.Cells[txtBagliTakipNo1.Name].Value = item.Cells[txtBagliTakipNo2.Name].Value;
                    newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = item.Cells[txtXXXXXXProtocolNo2.Name].Value;
                    newRow.Cells[txtVakaAcilisTarihi1.Name].Value = item.Cells[txtVakaAcilisTarihi2.Name].Value;
                    newRow.Cells[txtBransKodu1.Name].Value = item.Cells[txtBransKodu2.Name].Value;
                    newRow.Cells[txtTedaviTuru1.Name].Value = item.Cells[txtTedaviTuru2.Name].Value; 
                }
                this.tttabSearchBenchMarks.HideTabPage(tttabReportSave);
                this.tttabRaporlar.HideTabPage(tttabFtrRaporlari);
                this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);
                this.tttabRaporlar.ShowTabPage(tttabTumRaporlar);
                gridHastaAktifTakipleri.Visible = false;
                lstTabip.Visible = false;
                RaporBaslangicTarihi.Visible = false;
                RaporBitisTarihi.Visible = false;
                lstTabip.Required = false;
                RaporBaslangicTarihi.Required = false;
                RaporBitisTarihi.Required = false;
                FizyoterapiIslemi.Required = false;
                VucutBolgesi.Required = false;
                SeansSayisi.Required = false;
               // TedaviTuru.Required = false;
                lblTabip.Visible = false;
                lblRaporBaslangicTarihi.Visible = false;
                lblRaporBitisTarihi.Visible = false;
                chkFtrHeyetRaporu.Visible= false;
                lstTabip2.Visible = false;
                lstTabip3.Visible = false;
                lblTabip2.Visible = false;
                lblTabip3.Visible = false;
                
                btnRaporArama.Visible = false;
            }
#endregion MedulaRaporIslemleri_cmbRaporTuru_SelectedIndexChanged
        }

        private void gridHastaAktifTakipleri_SelectionChanged()
        {
#region MedulaRaporIslemleri_gridHastaAktifTakipleri_SelectionChanged
   if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTR).Value )
            {
                TTObjectContext context = new TTObjectContext(true);
                foreach (ITTGridRow item in gridFizyoTerapiIslemleri.Rows)
                {
                    if(gridHastaAktifTakipleri.CurrentCell != null)
                    {     
                        item.Cells[TedaviTuru.Name].Value =  TTObjectClasses.TedaviTuru.GetTedaviTuru(gridHastaAktifTakipleri.Rows[gridHastaAktifTakipleri.CurrentCell.RowIndex].Cells[txtTedaviTuru1.Name].Value.ToString()).ObjectID;
                    
                    }
                }
            }
#endregion MedulaRaporIslemleri_gridHastaAktifTakipleri_SelectionChanged
        }

        private void chkRaporKaydet_CheckedChanged()
        {
#region MedulaRaporIslemleri_chkRaporKaydet_CheckedChanged
   if (!((TTVisual.TTCheckBox)(chkRaporKaydet)).Checked)
            {
                this.tttabRaporlar.HideTabPage(tttabFtrRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEswlRaporlari);
                this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);
                this.tttabRaporlar.Visible = true;

                txtRBReportRow.Required = false;
                txtRBReportChasing.Required = false;
                cmbRBReportType.Required = false;
                dtReportDate.Required = true;
                cmbReportType.Required = false;
                txtReportRow.Required = false;
                txtReportChasing.Required = false;
                txtResult.Text = "";
                txtResult.Visible = false;
                
            }
            else
            {
                tttabSearchBenchMarks.Visible = true;
                this.tttabSearchBenchMarks.HideTabPage(tttabReportSave);
               
                if(cmbRaporTuru.SelectedItem !=null)
                {
                    
                    if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value)== Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTR).Value)
                    {
                        this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);
                        this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabFtrRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                        this.tttabRaporlar.ShowTabPage(tttabFtrRaporlari);
                        
                    }
                    else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.FTRTRAFIKKAZASI).Value)
                    {
                        this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);
                        this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabFtrRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                        this.tttabRaporlar.ShowTabPage(tttabFtrRaporlari);
                    }
                    else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWT).Value)
                    {
                        this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabESWTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                        this.tttabRaporlar.ShowTabPage(tttabFtrRaporlari);
                    }
                    else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.ESWL).Value)
                    {
                        this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabESWLRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                        this.tttabRaporlar.ShowTabPage(tttabEswlRaporlari);
                    }
                    else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.DIYALIZ).Value)
                    {
                        this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                        this.tttabRaporlar.ShowTabPage(tttabDiyalizRaporlari);
                    }
                    else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value)== Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.EVHEMODIYALIZI).Value)
                    {
                        this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabEvHemoDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                        this.tttabRaporlar.ShowTabPage(tttabEvHemodiyalizRaporlari);
                    }
                    else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.HBT).Value)
                    {
                        this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabHOTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabTupBebekRaporKaydet);
                        this.tttabRaporlar.ShowTabPage(tttabHOTRaporlari);
                    }
                    else if (Convert.ToInt32(cmbRaporTuru.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TedaviRaporTuruEnum.TUPBEBEK).Value)
                    {
                        this.tttabSearchBenchMarks.ShowTabPage(tttabReportSave);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabFtrRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabESWLRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabEvHemoDiyalizRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.HideTabPage(tttabHOTRaporKaydet);
                        this.tttabTedaviRaporlariKaydet.ShowTabPage(tttabTupBebekRaporKaydet);
                        this.tttabRaporlar.ShowTabPage(tttabTupBebekRaporlari);
                    }
                    else
                    {
                        this.tttabRaporlar.HideTabPage(tttabEswlRaporlari);
                        this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                        this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                        this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                        this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);
                    }
                }
                this.tttabRaporlar.HideTabPage(tttabEswlRaporlari);
                this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTumRaporlar);
                this.tttabRaporlar.Visible = true;
                this.ttgroupbox3.Visible = true;
                this.tttabSearchBenchMarks.HideTabPage(tttabSearchTCKNo);
                this.tttabSearchBenchMarks.HideTabPage(tttabSearchReportInfo);
                this.tttabSearchBenchMarks.HideTabPage(tttabSearchChasing);
                // this.tttabRaporlar.ShowTabPage(tttabFtrRaporlari);

                cmbReportType.Required = true;
                ((TTVisual.TTCheckBox)(chkSearchTCKNo)).Checked = false;
                ((TTVisual.TTCheckBox)(chkSearchReportInfo)).Checked = false;
                ((TTVisual.TTCheckBox)(chkSearchChasing)).Checked = false;
            }
#endregion MedulaRaporIslemleri_chkRaporKaydet_CheckedChanged
        }

        private void chkSearchReportInfo_CheckedChanged()
        {
#region MedulaRaporIslemleri_chkSearchReportInfo_CheckedChanged
   if (!((TTVisual.TTCheckBox)(chkSearchReportInfo)).Checked)
            {
                txtRBReportRow.Required = false;
                txtRBReportChasing.Required = false;
                cmbRBReportType.Required = false;
                dtReportDate.Required = true;
                cmbReportType.Required = false;
                txtReportRow.Required = false;
                txtReportChasing.Required = false;
                txtResult.Text = "";
                txtResult.Visible = false;
            }
            else
            {
                tttabSearchBenchMarks.Visible = true;

                this.tttabSearchBenchMarks.ShowTabPage(tttabSearchReportInfo);
                this.tttabSearchBenchMarks.HideTabPage(tttabSearchTCKNo);
                this.tttabSearchBenchMarks.HideTabPage(tttabSearchChasing);
                this.tttabSearchBenchMarks.HideTabPage(tttabReportSave);
                this.tttabRaporlar.Visible = true;
                this.tttabRaporlar.ShowTabPage(tttabTumRaporlar);
                this.tttabRaporlar.HideTabPage(tttabFtrRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEswlRaporlari);
                this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);
                this.ttgroupbox3.Visible = false;

                txtRBReportRow.Required = true;
                txtRBReportChasing.Required = true;
                cmbRBReportType.Required = true;
                dtReportDate.Required = true;
                ((TTVisual.TTCheckBox)(chkSearchTCKNo)).Checked = false;
                ((TTVisual.TTCheckBox)(chkSearchChasing)).Checked = false;
                ((TTVisual.TTCheckBox)(chkRaporKaydet)).Checked = false;
                  
            }
#endregion MedulaRaporIslemleri_chkSearchReportInfo_CheckedChanged
        }

        private void chkSearchChasing_CheckedChanged()
        {
#region MedulaRaporIslemleri_chkSearchChasing_CheckedChanged
   if (!((TTVisual.TTCheckBox)(chkSearchChasing)).Checked)
            {
                txtRBReportRow.Required = false;
                txtRBReportChasing.Required = false;
                cmbRBReportType.Required = false;
                dtReportDate.Required = true;
                cmbReportType.Required = false;
                txtReportRow.Required = false;
                txtReportChasing.Required = false;
                txtResult.Text = "";
                txtResult.Visible = false;
            }
            else
            {
                tttabSearchBenchMarks.Visible = true;

                this.tttabSearchBenchMarks.ShowTabPage(tttabSearchChasing);
                this.tttabSearchBenchMarks.HideTabPage(tttabSearchTCKNo);
                this.tttabSearchBenchMarks.HideTabPage(tttabSearchReportInfo);
                this.tttabSearchBenchMarks.HideTabPage(tttabReportSave);
                this.tttabRaporlar.Visible = true;
                this.tttabRaporlar.ShowTabPage(tttabTumRaporlar);
                this.tttabRaporlar.HideTabPage(tttabFtrRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEswlRaporlari);
                this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);
                this.ttgroupbox3.Visible = false;
                txtReportRow.Required = true;
                txtReportChasing.Required = true;
                ((TTVisual.TTCheckBox)(chkSearchTCKNo)).Checked = false;
                ((TTVisual.TTCheckBox)(chkSearchReportInfo)).Checked = false;
                ((TTVisual.TTCheckBox)(chkRaporKaydet)).Checked = false;
            }
#endregion MedulaRaporIslemleri_chkSearchChasing_CheckedChanged
        }

        private void chkSearchTCKNo_CheckedChanged()
        {
#region MedulaRaporIslemleri_chkSearchTCKNo_CheckedChanged
   if (!((TTVisual.TTCheckBox)(chkSearchTCKNo)).Checked)
            {
                txtRBReportRow.Required = false;
                txtRBReportChasing.Required = false;
                cmbRBReportType.Required = false;
                dtReportDate.Required = true;
                cmbReportType.Required = false;
                txtReportRow.Required = false;
                txtReportChasing.Required = false;
                txtResult.Text = "";
                txtResult.Visible = false;
            }
            else
            {
                tttabSearchBenchMarks.Visible = true;
                if (!string.IsNullOrEmpty(this.txtTCKNo.Text))
                    this.tttabSearchBenchMarks.ShowTabPage(tttabSearchTCKNo);
                else
                    this.tttabSearchBenchMarks.HideTabPage(tttabSearchTCKNo);
                this.tttabSearchBenchMarks.HideTabPage(tttabSearchChasing);
                this.tttabSearchBenchMarks.HideTabPage(tttabSearchReportInfo);
                this.tttabSearchBenchMarks.HideTabPage(tttabReportSave);
                this.tttabRaporlar.Visible = true;
                this.tttabRaporlar.ShowTabPage(tttabTumRaporlar);
                this.tttabRaporlar.HideTabPage(tttabFtrRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEswlRaporlari);
                this.tttabRaporlar.HideTabPage(tttabDiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabEvHemodiyalizRaporlari);
                this.tttabRaporlar.HideTabPage(tttabTupBebekRaporlari);
                this.tttabRaporlar.HideTabPage(tttabHOTRaporlari);
                this.ttgroupbox3.Visible = false;

                cmbReportType.Required = true;

                ((TTVisual.TTCheckBox)(chkSearchChasing)).Checked = false;
                ((TTVisual.TTCheckBox)(chkSearchReportInfo)).Checked = false;
                ((TTVisual.TTCheckBox)(chkRaporKaydet)).Checked = false;
            }
#endregion MedulaRaporIslemleri_chkSearchTCKNo_CheckedChanged
        }

        private void cmdSearchPatient_Click()
        {
#region MedulaRaporIslemleri_cmdSearchPatient_Click
   using (PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();
                List<SubEpisodeProtocol> retList = new List<SubEpisodeProtocol>();
                
                if (patient != null)
                {
                    retList = patient.GetActiveSGKSEPs(Common.RecTime(), Common.RecTime());
                    txtName.Text = patient.Name;
                    txtSurname.Text = patient.Surname;
                    if (patient.YUPASSNO != null)
                    {
                        lblKimlikNo.Text = "YUPASS No";
                        txtTCKNo.Text = patient.YUPASSNO != null ? (patient.YUPASSNO.Value.ToString() + "") : "";
                    }
                    else
                    {
                        lblKimlikNo.Text = "TC Kimlik Numarası";
                        txtTCKNo.Text = patient.UniqueRefNo != null ? patient.UniqueRefNo.Value.ToString() : "";
                    }
                    txtBirthDate.Text = patient.BirthDate != null ? patient.BirthDate.Value.ToString("dd.MM.yyyy") : "";
                    if (patient.Sex != null)
                    {
                        if (patient.Sex.ADI == "KADIN")
                            txtSex.Text = "Kadın";
                        else
                            txtSex.Text = "Erkek";
                    }
                    cmbRaporTuru.ReadOnly=false;
                    chkFtrHeyetRaporu.Visible = false;
                    if(chkSearchTCKNo.Value==true)
                    {
                        tttabSearchBenchMarks.Visible = true;
                        this.tttabSearchBenchMarks.ShowTabPage(tttabSearchTCKNo);
                    }
                }
                else
                {
                    InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
                    txtSex.Text = "";
                    txtBirthDate.Text = "";
                    txtTCKNo.Text = "";
                    txtSurname.Text = "";
                    txtName.Text = "";

                }
                if(retList.Count > 0)
                {
                    for (int i = (retList.Count - 1) ; i >= 0 ; i-- )
                    {
                        //                foreach( MedulaProvision item in  retList)
                        //                {
                        if (retList[i].MedulaTakipNo != null)
                        {
                            ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                            newRow.Cells[txtTakipNo1.Name].Value = retList[i].MedulaTakipNo;
                            newRow.Cells[txtBrans1.Name].Value = retList[i].Brans.Name_Shadow;
                            newRow.Cells[txtProvizyonTarihi1.Name].Value = retList[i].MedulaProvizyonTarihi.ToString();
                            newRow.Cells[txtBagliTakipNo1.Name].Value = retList[i].ParentSEP != null ? retList[i].ParentSEP.MedulaTakipNo : null;
                            newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = retList[i].Episode.HospitalProtocolNo;
                            newRow.Cells[txtVakaAcilisTarihi1.Name].Value  = retList[i].Episode.OpeningDate;
                            newRow.Cells[txtBransKodu1.Name].Value  = retList[i].Brans.Code;
                            newRow.Cells[txtTedaviTuru1.Name].Value  = retList[i].MedulaTedaviTuru.tedaviTuruKodu;
                            
                            ITTGridRow newRow2 = gridHastaAktifTumTakipler.Rows.Add();
                            newRow2.Cells[txtTakipNo2.Name].Value = retList[i].MedulaTakipNo;
                            newRow2.Cells[txtBrans2.Name].Value = retList[i].Brans.Name_Shadow;
                            newRow2.Cells[txtProvizyonTarihi2.Name].Value = retList[i].MedulaProvizyonTarihi.ToString();
                            newRow2.Cells[txtBagliTakipNo2.Name].Value = retList[i].ParentSEP != null ? retList[i].ParentSEP.MedulaTakipNo : null;
                            newRow2.Cells[txtXXXXXXProtocolNo2.Name].Value = retList[i].Episode.HospitalProtocolNo;
                            newRow2.Cells[txtVakaAcilisTarihi2.Name].Value  = retList[i].Episode.OpeningDate;
                            newRow2.Cells[txtBransKodu2.Name].Value  = retList[i].Brans.Code;
                            newRow2.Cells[txtTedaviTuru2.Name].Value = retList[i].MedulaTedaviTuru.tedaviTuruKodu;
                        }
                    }
                }
            }
#endregion MedulaRaporIslemleri_cmdSearchPatient_Click
        }

#region MedulaRaporIslemleri_Methods
        public MedulaRaporIslemleri(Patient patient) : base("MedulaRaporIslemleri") {
            List<SubEpisodeProtocol> retList = new List<SubEpisodeProtocol>();
            
            if (patient != null)
            {
                retList = patient.GetActiveSGKSEPs(Common.RecTime(), Common.RecTime());
                txtName.Text = patient.Name;
                txtSurname.Text = patient.Surname;
                if(patient.YUPASSNO != null)
                {
                    lblKimlikNo.Text = "YUPASS No";
                    txtTCKNo.Text = patient.YUPASSNO != null ? (patient.YUPASSNO.Value.ToString() + "") : "";
                }
                else
                {
                    lblKimlikNo.Text = "TC Kimlik Numarası";
                    txtTCKNo.Text = patient.UniqueRefNo != null ? patient.UniqueRefNo.Value.ToString() : "";
                }
                
                txtBirthDate.Text = patient.BirthDate != null ? patient.BirthDate.Value.ToString("dd.MM.yyyy") : "";
                if (patient.Sex != null)
                {
                    if (patient.Sex.ADI== "KADIN")
                        txtSex.Text = "Kadın";
                    else
                        txtSex.Text = "Erkek";
                    
                }
                cmbRaporTuru.ReadOnly=false;
                chkFtrHeyetRaporu.Visible = false;
                if(chkSearchTCKNo.Value==true)
                {
                    tttabSearchBenchMarks.Visible = true;
                    this.tttabSearchBenchMarks.ShowTabPage(tttabSearchTCKNo);
                }
            }
            else
            {
                InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
                txtSex.Text = "";
                txtBirthDate.Text = "";
                txtTCKNo.Text = "";
                txtSurname.Text = "";
                txtName.Text = "";

            }
            if(retList.Count > 0)
            {
                for (int i = (retList.Count - 1); i >= 0; i--)
                {
                    //                foreach( MedulaProvision item in  retList)
                    //                {
                    if (retList[i].MedulaTakipNo != null)
                    {
                        ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                        newRow.Cells[txtTakipNo1.Name].Value = retList[i].MedulaTakipNo;
                        newRow.Cells[txtBrans1.Name].Value = retList[i].Brans.Name_Shadow;
                        newRow.Cells[txtProvizyonTarihi1.Name].Value = retList[i].MedulaProvizyonTarihi.ToString();
                        newRow.Cells[txtBagliTakipNo1.Name].Value = retList[i].ParentSEP != null ? retList[i].ParentSEP.MedulaTakipNo : null;
                        newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = retList[i].Episode.HospitalProtocolNo;
                        newRow.Cells[txtVakaAcilisTarihi1.Name].Value  = retList[i].Episode.OpeningDate;
                        newRow.Cells[txtBransKodu1.Name].Value  = retList[i].Brans.Code;
                        newRow.Cells[txtTedaviTuru1.Name].Value = retList[i].MedulaTedaviTuru.tedaviTuruKodu;
                        
                        ITTGridRow newRow2 = gridHastaAktifTumTakipler.Rows.Add();
                        newRow2.Cells[txtTakipNo2.Name].Value = retList[i].MedulaTakipNo;
                        newRow2.Cells[txtBrans2.Name].Value = retList[i].Brans.Name_Shadow;
                        newRow2.Cells[txtProvizyonTarihi2.Name].Value = retList[i].MedulaProvizyonTarihi.ToString();
                        newRow2.Cells[txtBagliTakipNo2.Name].Value = retList[i].ParentSEP != null ? retList[i].ParentSEP.MedulaTakipNo : null;
                        newRow2.Cells[txtXXXXXXProtocolNo2.Name].Value = retList[i].Episode.HospitalProtocolNo;
                        newRow2.Cells[txtVakaAcilisTarihi2.Name].Value  = retList[i].Episode.OpeningDate;
                        newRow2.Cells[txtBransKodu2.Name].Value  = retList[i].Brans.Code;
                        newRow2.Cells[txtTedaviTuru2.Name].Value = retList[i].MedulaTedaviTuru.tedaviTuruKodu;
                    }
                }            
        }
        
        chkRaporKaydet.Value = true;
        cmbRaporTuru.SelectedValue = TedaviRaporTuruEnum.FTR;
        cmbRaporTuru.SelectedIndex = 0;
        //cmbRaporTuru.SelectedIndexChanged();
    }
        
#endregion MedulaRaporIslemleri_Methods
    }
}