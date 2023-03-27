
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
    public partial class SurgeryReportForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridMainSurgeryProcedures.CellContentClick += new TTGridCellEventDelegate(GridMainSurgeryProcedures_CellContentClick);
            GridMainSurgeryProcedures.UserDeletedRow += new TTGridRowEventDelegate(GridMainSurgeryProcedures_UserDeletedRow);
            GridMainSurgeryProcedures.CellValueChanged += new TTGridCellEventDelegate(GridMainSurgeryProcedures_CellValueChanged);
            GridSurgeryExpends.CellValueChanged += new TTGridCellEventDelegate(GridSurgeryExpends_CellValueChanged);
            GridSurgeryPersonnels.CellValueChanged += new TTGridCellEventDelegate(GridSurgeryPersonnels_CellValueChanged);
            GridSurgeryExpends.RowEnter += new TTGridCellEventDelegate(GridSurgeryExpends_RowEnter);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridMainSurgeryProcedures.CellContentClick -= new TTGridCellEventDelegate(GridMainSurgeryProcedures_CellContentClick);
            GridMainSurgeryProcedures.UserDeletedRow -= new TTGridRowEventDelegate(GridMainSurgeryProcedures_UserDeletedRow);
            GridMainSurgeryProcedures.CellValueChanged -= new TTGridCellEventDelegate(GridMainSurgeryProcedures_CellValueChanged);
            GridSurgeryExpends.CellValueChanged -= new TTGridCellEventDelegate(GridSurgeryExpends_CellValueChanged);
            GridSurgeryPersonnels.CellValueChanged -= new TTGridCellEventDelegate(GridSurgeryPersonnels_CellValueChanged);
            GridSurgeryExpends.RowEnter -= new TTGridCellEventDelegate(GridSurgeryExpends_RowEnter);
            base.UnBindControlEvents();
        }

        private void GridMainSurgeryProcedures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryReportForm_GridMainSurgeryProcedures_CellContentClick
   if(rowIndex < this.GridMainSurgeryProcedures.Rows.Count && rowIndex > -1)
            {
                if( columnIndex == 9)
                {
                    try
                    {
                        SurgeryProcedure surgeryProcedure = (SurgeryProcedure)((ITTGridRow)this.GridMainSurgeryProcedures.Rows[rowIndex]).TTObject;
                        if (surgeryProcedure != null)
                        {

                                if(surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
                                {

                                    //TODO ShowEdit!
                                    //BaseSurgeryProcedureToothSchema frm = new BaseSurgeryProcedureToothSchema();
                                    //frm.ShowEdit(this.FindForm(), surgeryProcedure, true);

                                    this.GridMainSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = string.Empty;
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
                                            this.GridMainSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = toothNumberNames.Substring(0, toothNumberNames.Length - 1);
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
#endregion SurgeryReportForm_GridMainSurgeryProcedures_CellContentClick
        }

        private void GridMainSurgeryProcedures_UserDeletedRow()
        {
#region SurgeryReportForm_GridMainSurgeryProcedures_UserDeletedRow
   this._Surgery.SetMedulaAyniFarkliKesiOfSurgeryProcedures();
#endregion SurgeryReportForm_GridMainSurgeryProcedures_UserDeletedRow
        }

        private void GridMainSurgeryProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryReportForm_GridMainSurgeryProcedures_CellValueChanged
   // Ameliyat veya Kesi Bilgisi değiştirilirse
            if (((ITTGrid)this.GridMainSurgeryProcedures).Columns[columnIndex].Name == "MSProcedureObject" || ((ITTGrid)this.GridMainSurgeryProcedures).Columns[columnIndex].Name == "MSIncisionType")
                this._Surgery.SetMedulaAyniFarkliKesiOfSurgeryProcedures();
            
            // Diş ameliyatı için gerekli diş bilgisi alanları enable/disable edilir
            if (GridMainSurgeryProcedures.CurrentCell != null && GridMainSurgeryProcedures.CurrentCell.OwningColumn != null && GridMainSurgeryProcedures.CurrentCell.OwningColumn.Name == "MSProcedureObject")
            {
                SurgeryProcedure surgeryProcedure = (SurgeryProcedure)this.GridMainSurgeryProcedures.CurrentCell.OwningRow.TTObject;
                if (surgeryProcedure != null && surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
                {
                    this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothSchema"].ReadOnly = false;
                    this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothNumber"].ReadOnly = true;
                    this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothAnomaly"].ReadOnly = false;
                    this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothCommitmentNumber"].ReadOnly = false;
                }
                else
                {
                    surgeryProcedure.ToothNumber = string.Empty;
                    surgeryProcedure.ToothAnomaly = null;
                    surgeryProcedure.ToothCommitmentNumber = null;
                    this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothSchema"].ReadOnly = true;
                    this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothNumber"].ReadOnly = true;
                    this.GridMainSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = string.Empty;
                    this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothAnomaly"].ReadOnly = true;
                    this.GridMainSurgeryProcedures.CurrentCell.OwningRow.Cells["ToothCommitmentNumber"].ReadOnly = true;
                }
            }
#endregion SurgeryReportForm_GridMainSurgeryProcedures_CellValueChanged
        }

        private void GridSurgeryExpends_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryReportForm_GridSurgeryExpends_CellValueChanged
   ITTGridRow enteredRow = GridSurgeryExpends.Rows[rowIndex];

            if (enteredRow != null && GridSurgeryExpends.CurrentCell.OwningColumn.Name == CAStore.Name)
            {
                SurgeryExpend currentSurgeryExpend = enteredRow.TTObject as SurgeryExpend;
                if (currentSurgeryExpend != null && currentSurgeryExpend.Store != null)
                    CAMaterial.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(currentSurgeryExpend.Store.ObjectID);
            }
#endregion SurgeryReportForm_GridSurgeryExpends_CellValueChanged
        }

        private void GridSurgeryExpends_RowEnter(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryReportForm_GridSurgeryExpends_RowEnter
   ITTGridRow enteredRow = GridSurgeryExpends.Rows[rowIndex];

            if (enteredRow != null)
            {
                SurgeryExpend currentSurgeryExpend = enteredRow.TTObject as SurgeryExpend;
                if (currentSurgeryExpend != null && currentSurgeryExpend.Store != null)
                    CAMaterial.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(currentSurgeryExpend.Store.ObjectID);
            }
#endregion SurgeryReportForm_GridSurgeryExpends_RowEnter
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
#region SurgeryReportForm_PreScript
    base.PreScript();
            if (this._Surgery.CurrentStateDefID == Surgery.States.Surgery)
            {

                bool HasUncompleteSubSurgery = false;
                foreach (SubSurgery subSurgery in this._Surgery.SubSurgeries)
                {
                    if (subSurgery.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    {
                        HasUncompleteSubSurgery = true;
                        break;
                    }
                }
                if (this._Surgery.AnesthesiaAndReanimation != null)
                {
                    if (this._Surgery.AnesthesiaAndReanimation.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    {
                        HasUncompleteSubSurgery = true;
                    }
                }
                if (HasUncompleteSubSurgery == false)//Tüm Ek Ameliyatlar ve Anestezi tamamlandıysa ControlSubSurgeries'e harici butonlar kalkmalı
                {
                    this.DropStateButton(Surgery.States.WaitingForSubSurgeries);
                }
                else//Tüm Ek Ameliyatlar ve Anestezi tamamlandıysa WaitingForSubSurgeries'e harici butonlar kalkmalı
                {
                    this.DropStateButton(Surgery.States.Completed);
                }

            }
            else if (this._Surgery.CurrentStateDefID == Surgery.States.WaitingForSubSurgeries)//WaitingForSubsurgeries stepi kullanıcı tarafından  ControlSubSurgeries'e  gönderilmesin diye kaldırıldı
            {
                this.DropStateButton(Surgery.States.Completed);
            }

            if (this._Surgery.SurgeryReportDate == null)
            {
                this._Surgery.SurgeryReportDate = Common.RecTime();
            }
            
            CAMaterial.ListFilterExpression = " 1=2 ";

            string storeObjectId = "";
            foreach (UserResource userResource in Common.CurrentResource.UserResources)
            {
                if (userResource.Resource.Store != null)
                {
                    storeObjectId = storeObjectId + ConnectionManager.GuidToString(userResource.Resource.Store.ObjectID);
                    storeObjectId = storeObjectId + ",";
                }
            }
            if (storeObjectId.Length > 0)
            {
                storeObjectId = storeObjectId.Substring(0, storeObjectId.Length - 1);
                CAStore.ListFilterExpression = "OBJECTID IN (" + storeObjectId + ")";
            }
            
            ArrangeToothColumnsOfSurgeryGrid();
#endregion SurgeryReportForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryReportForm_PostScript
    base.PostScript(transDef);
            this.SurgeryPersonnelIsResquired();
            if (this._Surgery.MainSurgeryProcedures.Count < 1)
            {
                throw new Exception(SystemMessage.GetMessage(619));
            }
            if (this._Surgery.SurgeryEndTime == null || this._Surgery.SurgeryStartTime == null)
            {
                throw new Exception("'Ameliyat Başlama Tarihi' ve  'Ameliyat Bitiş Tarihi' alanları boş geçilemez");

            }
            else if (Common.DateDiffV2(0, Convert.ToDateTime(this._Surgery.SurgeryEndTime), Convert.ToDateTime(this._Surgery.SurgeryStartTime), false) < 0)
            {
                throw new Exception("'Ameliyat Başlama Tarihi' , 'Ameliyat Bitiş Tarihinden' sonra olamaz. ");
            }

          
            //
            if (transDef != null)
            {
                if ( transDef.ToStateDefID  == Surgery.States.WaitingForSubSurgeries)
                    this.MakingDirectPurchaseHasUsed();
            }
#endregion SurgeryReportForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryReportForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
              CheckCesareanAndFireBirthReport();
#endregion SurgeryReportForm_ClientSidePostScript

        }

#region SurgeryReportForm_Methods
        // Diş ameliyatı için gerekli diş bilgisi alanları enable/disable edilir, Diş ameliyatı ise Diş Numarası doldurulur
        public void ArrangeToothColumnsOfSurgeryGrid()
        {
            foreach (ITTGridRow row in GridMainSurgeryProcedures.Rows)
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
        
#endregion SurgeryReportForm_Methods

#region SurgeryReportForm_ClientSideMethods
        public void CheckCesareanAndFireBirthReport()
        {
            bool found = false;
            string cesarean = TTObjectClasses.SystemParameter.GetParameterValue("SezaryenButCode", "619930").Trim();
            string cesareanMultiplePregnancy = TTObjectClasses.SystemParameter.GetParameterValue("SezaryenCogulGebelikButCode", "619929").Trim();
            foreach (SurgeryProcedure sp in this._Surgery.SurgeryProcedures)
            {

                foreach (ProcedurePriceDefinition pp in sp.ProcedureObject.ProcedurePrice)
                {
                    if (pp.PricingDetail != null)
                    {
                        if (pp.PricingDetail.ExternalCode.Trim() == cesarean || pp.PricingDetail.ExternalCode.Trim() == cesareanMultiplePregnancy)
                        {
                            found = true;
                            break;
                        }
                    }
                }
            }
            if (found)
            {
                this._EpisodeAction.CreateNewBirthReportRequest();
            }
        }

        public void SurgeryPersonnelIsResquired()
        {

            string errorString = "";
            foreach (SurgeryProcedure sP in this._Surgery.MainSurgeryProcedures)
            {
                if (sP.ProcedureDoctor == null)
                {
                    errorString = sP.ProcedureObject.Name + " ameliyatı için Sorumlu Cerrah girmediniz \n ";
                }
                if (errorString != "")
                {
                    throw new Exception(errorString);
                }
            }
        }

        #endregion SurgeryReportForm_ClientSideMethods
    }
}