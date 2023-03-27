
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
    /// SPTS Rapor Giriş
    /// </summary>
    public partial class SPTSReportEntryForm : TTForm
    {
        override protected void BindControlEvents()
        {
            DrugOrderForReports.CellValueChanged += new TTGridCellEventDelegate(DrugOrderForReports_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DrugOrderForReports.CellValueChanged -= new TTGridCellEventDelegate(DrugOrderForReports_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void DrugOrderForReports_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region SPTSReportEntryForm_DrugOrderForReports_CellValueChanged
   ITTGridRow drugOrderRow = DrugOrderForReports.Rows[DrugOrderForReports.CurrentCell.RowIndex];
            if (DrugOrderForReports.CurrentCell == drugOrderRow.Cells["Drug"])
            {
                DrugDefinition drugDefinition = (DrugDefinition)_SPTSReportEntryAction.ObjectContext.GetObject(new Guid(drugOrderRow.Cells["Drug"].Value.ToString()), "DRUGDEFINITION");

                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (MaterialBarcodeLevel barcodeLevel in drugDefinition.MaterialBarcodeLevels)
                {
                    multiSelectForm.AddMSItem(barcodeLevel.Name.ToString(), barcodeLevel.Name.ToString(), barcodeLevel);
                }
                string key = multiSelectForm.GetMSItem(ParentForm, "İlaç Formunu Seçiniz");
                if (!string.IsNullOrEmpty(key))
                {
                    ((DrugOrderForReport)drugOrderRow.TTObject).BarcodeLevel = ((MaterialBarcodeLevel)multiSelectForm.MSSelectedItemObject);
                }
            }
#endregion SPTSReportEntryForm_DrugOrderForReports_CellValueChanged
        }

        protected override void PreScript()
        {
#region SPTSReportEntryForm_PreScript
    base.PreScript();
            if (_SPTSReportEntryAction.PrevState == null)
            {
                _SPTSReportEntryAction.AgeAndSize = false;
                _SPTSReportEntryAction.OralNutrition = false;
                _SPTSReportEntryAction.PathologyReport = false;
                _SPTSReportEntryAction.SchemeOfCure = false;
                _SPTSReportEntryAction.TValue = false;
            }
#endregion SPTSReportEntryForm_PreScript

            }
                }
}