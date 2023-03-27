
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
    /// Dış Eczane Tanımı
    /// </summary>
    public partial class ExternalPharmacyForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            ExternalPharmacyStatuses.CellValueChanged += new TTGridCellEventDelegate(ExternalPharmacyStatuses_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ExternalPharmacyStatuses.CellValueChanged -= new TTGridCellEventDelegate(ExternalPharmacyStatuses_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void ExternalPharmacyStatuses_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ExternalPharmacyForm_ExternalPharmacyStatuses_CellValueChanged
   //            if(this.AccountingTerm.StartDate.Value.Year != this.TransactionDate.Value.Year )
//                //if (this.AccountingTerm.StartDate > this.TransactionDate.Value || this.TransactionDate.Value > this.AccountingTerm.EndDate)
//                throw new TTUtils.TTException("İşlem tarihi,hesap dönemi ile aynı dönemde değil");

            DateTime nowDate = DateTime.Now.Date;
            if (ExternalPharmacyStatuses.CurrentCell.OwningColumn.Name == "EndDate")
            {
                int currentRow = ExternalPharmacyStatuses.CurrentCell.RowIndex;
//                if(ExternalPharmacyStatuses.Rows[currentRow].Cells["EndDate"].Value < nowDate)
//                    ExternalPharmacyStatuses.Rows[currentRow].Cells["EndDate"].ReadOnly = true;
                //                if (ExternalPharmacyStatuses.CurrentCell.Value != null)
                //                {
                //                    if(ExternalPharmacyStatuses.Rows[currentRow].Cells["EndDate"].Value < nowDate)
                //                    ExternalPharmacyStatuses.Rows[currentRow].Cells["EndDate"].ReadOnly = true;
                //                }
                //                else
                //                {
                //                    ExternalPharmacyStatuses.Rows[currentRow].Cells["EndDate"].Value = null;
                //                    ExternalPharmacyStatuses.Rows[currentRow].Cells["EndDate"].ReadOnly = false;
                //                }
            }
#endregion ExternalPharmacyForm_ExternalPharmacyStatuses_CellValueChanged
        }

        protected override void PreScript()
        {
#region ExternalPharmacyForm_PreScript
    base.PreScript();
            double price = 0 ;
            ExternalPharmacyDistributionTerm term = null;
            IList openTerms = ExternalPharmacyDistributionTerm.GetOpenDistributionTerm(_ExternalPharmacy.ObjectContext);
            if (openTerms.Count == 1)
            {
                term = (ExternalPharmacyDistributionTerm)openTerms[0];
            }
            else
            {
                throw new TTException(SystemMessage.GetMessage(1273));
            }
           
            foreach(ExternalPharmacyPrescriptionTransaction prescriptionTransaction in _ExternalPharmacy.PrescriptionTransactions)
            {
                if (prescriptionTransaction.DistributionTerm == term)
                {
                    price += (double)prescriptionTransaction.Price;
                }
            }
            this.TotalBalance.Text = price.ToString();
            for (int i = 0; i < this.ExternalPharmacyStatuses.Rows.Count; i++)
            {
                if (DateTime.Now > ((DateTime)this.ExternalPharmacyStatuses.Rows[i].Cells[1].Value))
                {
                    this.ExternalPharmacyStatuses.Rows[i].ReadOnly = true;
                }
            }
#endregion ExternalPharmacyForm_PreScript

            }
                }
}