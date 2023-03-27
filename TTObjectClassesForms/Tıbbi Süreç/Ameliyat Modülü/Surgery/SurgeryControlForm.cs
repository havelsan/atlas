
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
    /// Ameliyat
    /// </summary>
    public partial class SurgeryControlForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridSurgeryProcedures.UserDeletedRow += new TTGridRowEventDelegate(GridSurgeryProcedures_UserDeletedRow);
            GridSurgeryProcedures.CellContentClick += new TTGridCellEventDelegate(GridSurgeryProcedures_CellContentClick);
            GridSurgeryProcedures.CellValueChanged += new TTGridCellEventDelegate(GridSurgeryProcedures_CellValueChanged);
            GridSurgeryExpends.CellValueChanged += new TTGridCellEventDelegate(GridSurgeryExpends_CellValueChanged);
            GridSurgeryPersonnels.CellValueChanged += new TTGridCellEventDelegate(GridSurgeryPersonnels_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridSurgeryProcedures.UserDeletedRow -= new TTGridRowEventDelegate(GridSurgeryProcedures_UserDeletedRow);
            GridSurgeryProcedures.CellContentClick -= new TTGridCellEventDelegate(GridSurgeryProcedures_CellContentClick);
            GridSurgeryProcedures.CellValueChanged -= new TTGridCellEventDelegate(GridSurgeryProcedures_CellValueChanged);
            GridSurgeryExpends.CellValueChanged -= new TTGridCellEventDelegate(GridSurgeryExpends_CellValueChanged);
            GridSurgeryPersonnels.CellValueChanged -= new TTGridCellEventDelegate(GridSurgeryPersonnels_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GridSurgeryProcedures_UserDeletedRow()
        {
#region SurgeryControlForm_GridSurgeryProcedures_UserDeletedRow
   this._Surgery.SetMedulaAyniFarkliKesiOfSurgeryProcedures();
#endregion SurgeryControlForm_GridSurgeryProcedures_UserDeletedRow
        }

        private void GridSurgeryProcedures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryControlForm_GridSurgeryProcedures_CellContentClick
   if(rowIndex < this.GridSurgeryProcedures.Rows.Count && rowIndex > -1)
            {
                if( columnIndex == 11)
                {
                    try
                    {
                        SurgeryProcedure surgeryProcedure = (SurgeryProcedure)((ITTGridRow)this.GridSurgeryProcedures.Rows[rowIndex]).TTObject;
                        if (surgeryProcedure != null)
                        {

                                
                                if (surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
                                {
                                    //TODO ShowEdit!
                                    //    BaseSurgeryProcedureToothSchema frm = new BaseSurgeryProcedureToothSchema();
                                    //    frm.ShowEdit(this.FindForm(), surgeryProcedure, true);

                                    this.GridSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = string.Empty;
                                if (!string.IsNullOrEmpty(surgeryProcedure.ToothNumber))
                                {
                                    string toothNumberNames = string.Empty;
                                    string[] toothNumbers = surgeryProcedure.ToothNumber.Split(',');
                                    foreach (string toothNumber in toothNumbers)
                                    {
                                        string enumDisplayText = Common.GetDisplayTextOfEnumValue("ToothNumberEnum", Int32.Parse(toothNumber));
                                        toothNumberNames += enumDisplayText + ",";
                                    }

                                    if (!string.IsNullOrEmpty(toothNumberNames))
                                        this.GridSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = toothNumberNames.Substring(0, toothNumberNames.Length - 1);
                                    }
                                }
                            else
                                    InfoBox.Show("Sadece diş ameliyatları için diş şeması açılabilir.", MessageIconEnum.InformationMessage);
                            }
                    }
                    catch (System.Exception ex)
                    {
                        InfoBox.Show(ex);
                    }
                }
            }
#endregion SurgeryControlForm_GridSurgeryProcedures_CellContentClick
        }

        private void GridSurgeryProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryControlForm_GridSurgeryProcedures_CellValueChanged
   // Ameliyat veya Kesi Bilgisi değiştirilirse
            if (((ITTGrid)this.GridSurgeryProcedures).Columns[columnIndex].Name == "CAProcedureObject" || ((ITTGrid)this.GridSurgeryProcedures).Columns[columnIndex].Name == "IncisionType")
                this._Surgery.SetMedulaAyniFarkliKesiOfSurgeryProcedures();
            
            // Diş ameliyatı için gerekli diş bilgisi alanları enable/disable edilir
            if (GridSurgeryProcedures.CurrentCell != null && GridSurgeryProcedures.CurrentCell.OwningColumn != null && GridSurgeryProcedures.CurrentCell.OwningColumn.Name == "CAProcedureObject")
            {
                SurgeryProcedure surgeryProcedure = (SurgeryProcedure)this.GridSurgeryProcedures.CurrentCell.OwningRow.TTObject;
                if (surgeryProcedure != null && surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
                {
                    this.GridSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothSchema"].ReadOnly = false;
                    this.GridSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothNumber"].ReadOnly = true;
                    this.GridSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothAnomaly"].ReadOnly = false;
                    this.GridSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothCommitmentNumber"].ReadOnly = false;
                }
                else
                {
                    surgeryProcedure.ToothNumber = string.Empty;
                    surgeryProcedure.ToothAnomaly = null;
                    surgeryProcedure.ToothCommitmentNumber = null;
                    this.GridSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothSchema"].ReadOnly = true;
                    this.GridSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothNumber"].ReadOnly = true;
                    this.GridSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = string.Empty;
                    this.GridSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothAnomaly"].ReadOnly = true;
                    this.GridSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothCommitmentNumber"].ReadOnly = true;
                }
            }
#endregion SurgeryControlForm_GridSurgeryProcedures_CellValueChanged
        }

        private void GridSurgeryExpends_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryControlForm_GridSurgeryExpends_CellValueChanged
   ITTGridRow enteredRow = GridSurgeryExpends.Rows[rowIndex];

            if (enteredRow != null)
            {
                SurgeryExpend currentSurgeryExpend = enteredRow.TTObject as SurgeryExpend;
                if (currentSurgeryExpend != null && currentSurgeryExpend.Store != null)
                    CAMaterial.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(currentSurgeryExpend.Store.ObjectID);
            }
#endregion SurgeryControlForm_GridSurgeryExpends_CellValueChanged
        }

        private void GridSurgeryPersonnels_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region SurgeryForm_GridSurgeryPersonnels_CellValueChanged
            if (rowIndex < this.GridSurgeryPersonnels.Rows.Count && rowIndex > -1)
            {
                SurgeryPersonnel surgeryPersonel = (SurgeryPersonnel)((ITTGridRow)this.GridSurgeryPersonnels.Rows[rowIndex]).TTObject;

                if (surgeryPersonel.Personnel != null && surgeryPersonel.Role != null)
                {
                    if (surgeryPersonel.Personnel.UserType == UserTypeEnum.Technician)
                    {
                        return;
                    }
                    else
                    {
                        if (surgeryPersonel.Personnel.UserType != UserTypeEnum.Dentist && surgeryPersonel.Personnel.UserType != UserTypeEnum.Doctor)
                            InfoBox.Show(surgeryPersonel.Personnel.Name.ToString() + "kullanıcısı doktor değildir lütfen rolünü kontrol ediniz");
                    }
                }
            }
            #endregion SurgeryForm_GridSurgeryPersonnels_CellValueChanged
        }
        protected override void PreScript()
    {
        #region SurgeryControlForm_PreScript
        base.PreScript();


        ArrangeToothColumnsOfSurgeryGrid();
        #endregion SurgeryControlForm_PreScript

    }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryControlForm_PostScript
    base.PostScript(transDef);
            if (this._Surgery.AnesthesiaAndReanimation != null)
            {
                if (this._Surgery.AnesthesiaAndReanimation.AnesthesiaEndDateTime == null || this._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime == null)
                {
                    throw new Exception("'Anestezi Başlama Tarihi' ve  'Anestezi Bitiş Tarihi' alanları boş geçilemez");
                }
                else if (this._Surgery.SurgeryEndTime == null || this._Surgery.SurgeryStartTime == null)
                {
                    throw new Exception("'Ameliyat Başlama Tarihi' ve  'Ameliyat Bitiş Tarihi' alanları boş geçilemez");

                }
                else
                {
                    if (Common.DateDiffV2(0, Convert.ToDateTime(this._Surgery.SurgeryEndTime), Convert.ToDateTime(this._Surgery.SurgeryStartTime), false) < 0)
                    {
                        throw new Exception("'Ameliyat Başlama Tarihi' , 'Ameliyat Bitiş Tarihinden' sonra olamaz. ");
                    }

                    if (Common.DateDiffV2(0, Convert.ToDateTime(this._Surgery.SurgeryStartTime), Convert.ToDateTime(this._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime), false) < 0)
                    {
                        throw new Exception("'Anestezi Başlama Tarihi' , 'Ameliyat Başlama Tarihinden' sonra olamaz. ");
                    }

                    if (Common.DateDiffV2(0, Convert.ToDateTime(this._Surgery.AnesthesiaAndReanimation.AnesthesiaEndDateTime), Convert.ToDateTime(this._Surgery.SurgeryEndTime), false) < 0)
                    {
                        throw new Exception("'Anestezi Bitiş Tarihi' , 'Ameliyat Bitiş Tarihinden' önce olamaz. ");
                    }
                }
            }
#endregion SurgeryControlForm_PostScript

            }
            
#region SurgeryControlForm_Methods
        // Diş ameliyatı için gerekli diş bilgisi alanları enable/disable edilir, Diş ameliyatı ise Diş Numarası doldurulur
        public void ArrangeToothColumnsOfSurgeryGrid()
        {
            foreach (ITTGridRow row in GridSurgeryProcedures.Rows)
            {
                SurgeryProcedure surgeryProcedure = (SurgeryProcedure)row.TTObject;
                if (surgeryProcedure != null && surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
                {
                    row.Cells["ToothSchema"].ReadOnly = false;
                    row.Cells["ToothNumber"].ReadOnly = true;
                    row.Cells["ToothAnomaly"].ReadOnly = false;
                    row.Cells["ToothCommitmentNumber"].ReadOnly = false;
                    
                    if(!string.IsNullOrEmpty(surgeryProcedure.ToothNumber))
                    {
                        string toothNumberNames = string.Empty;
                        string[] toothNumbers = surgeryProcedure.ToothNumber.Split(',');
                        foreach (string toothNumber in toothNumbers)
                        {
                            string enumDisplayText = Common.GetDisplayTextOfEnumValue("ToothNumberEnum", Int32.Parse(toothNumber));
                            toothNumberNames += enumDisplayText + ",";
                        }

                        if (!string.IsNullOrEmpty(toothNumberNames))
                            row.Cells["ToothNumber"].Value = toothNumberNames.Substring(0, toothNumberNames.Length - 1);
                    }
                }
                else
                {
                    row.Cells["ToothSchema"].ReadOnly = true;
                    row.Cells["ToothNumber"].ReadOnly = true;
                    row.Cells["ToothAnomaly"].ReadOnly = true;
                    row.Cells["ToothCommitmentNumber"].ReadOnly = true;
                }
            }
        }


        public void SetMedulaAyniFarkliKesiOfSurgeryProcedures(Surgery surgery)
        {
            foreach (SurgeryProcedure surgeryProcedure in surgery.SurgeryProcedures)
            {
                /*
                     1 Aynı seans + aynı kesi
                     2 Farklı seans + farklı kesi
                     3 Aynı seansta + farklı kesi
                     4 Aynı seansta + farklı kesi + farklı klinik kod
                     5 Aynı seansta + aynı kesi + farklı klinik kod

                     Ameliyatları hep içinde bulundukları action daki ameliyatlar ile karşılaştırıp kesi bilgisine ulaştığımız için
                     hiç (2 Farklı seans + farklı kesi) göndermiyoruz Medulaya. 1, 3, 4 ve 5 gönderiyoruz.
                 */
                surgeryProcedure.AyniFarkliKesi = null;

                SurgeryProcedure bigSurgeryProcedure = null;
                double bigSurgeryPoint = 0;
                bool procedureObjectNotFound = false;

                foreach (SurgeryProcedure sp in surgeryProcedure.Surgery.SurgeryProcedures)
                {
                    if (sp.ProcedureObject != null)
                    {
                        //                    if (sp.ProcedureObject.GetSUTPoint() != null)
                        {
                            if ((double)sp.ProcedureObject.GetSUTPoint() > bigSurgeryPoint)
                            {
                                bigSurgeryProcedure = sp;
                                bigSurgeryPoint = (double)sp.ProcedureObject.GetSUTPoint();
                            }
                        }
                    }
                    else
                    {
                        procedureObjectNotFound = true;
                        break;
                    }
                }

                if (bigSurgeryProcedure != null && procedureObjectNotFound == false)
                {
                    // En büyük puanlı ameliyatın AyniFarkliKesi bilgisi null olmalı
                    if (!surgeryProcedure.ObjectID.Equals(bigSurgeryProcedure.ObjectID))
                    {
                        SpecialityDefinition thisSpeciality = null;
                        SpecialityDefinition bigSpeciality = null;

                        // bu SurgeryProcedure in klinik kodu bulunur
                        if (surgeryProcedure is MainSurgeryProcedure)
                            thisSpeciality = ((MainSurgeryProcedure)surgeryProcedure).MainSurgery.ProcedureSpeciality;
                        else if (surgeryProcedure is SubSurgeryProcedure)
                            thisSpeciality = ((SubSurgeryProcedure)surgeryProcedure).SubSurgery.ProcedureSpeciality;
                        else
                            thisSpeciality = null;

                        // en büyük puanlı SurgeryProcedure in klinik kodu bulunur
                        if (bigSurgeryProcedure is MainSurgeryProcedure)
                            bigSpeciality = ((MainSurgeryProcedure)bigSurgeryProcedure).MainSurgery.ProcedureSpeciality;
                        else if (bigSurgeryProcedure is SubSurgeryProcedure)
                            bigSpeciality = ((SubSurgeryProcedure)bigSurgeryProcedure).SubSurgery.ProcedureSpeciality;
                        else
                            bigSpeciality = null;

                        if (surgeryProcedure.IncisionType == bigSurgeryProcedure.IncisionType)   // Aynı Kesi
                        {
                            if (thisSpeciality != null && bigSpeciality != null && thisSpeciality.ObjectID.Equals(bigSpeciality.ObjectID))
                                surgeryProcedure.AyniFarkliKesi = TTObjectClasses.AyniFarkliKesi.GetAyniFarkliKesi("1");    // Aynı seans + Aynı Kesi
                            else
                                surgeryProcedure.AyniFarkliKesi = TTObjectClasses.AyniFarkliKesi.GetAyniFarkliKesi("5");    // Aynı seans + Aynı Kesi + Farklı Klinik Kod
                        }
                        else   // Farklı Kesi
                        {
                            if (thisSpeciality != null && bigSpeciality != null && thisSpeciality.ObjectID.Equals(bigSpeciality.ObjectID))
                                surgeryProcedure.AyniFarkliKesi = TTObjectClasses.AyniFarkliKesi.GetAyniFarkliKesi("3");    // Aynı seans + Farklı Kesi
                            else
                                surgeryProcedure.AyniFarkliKesi = TTObjectClasses.AyniFarkliKesi.GetAyniFarkliKesi("4");    // Aynı seans + Farklı Kesi + Farklı Klinik Kod
                        }
                    }
                }
            }
        }


        #endregion SurgeryControlForm_Methods
    }
}