
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
    public partial class InvoiceTermForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnCloseTerm.Click += new TTControlEventDelegate(btnCloseTerm_Click);
            btnLockTerm.Click += new TTControlEventDelegate(btnLockTerm_Click);
            btnCancelTerm.Click += new TTControlEventDelegate(btnCancelTerm_Click);
            btnAdd.Click += new TTControlEventDelegate(btnAdd_Click);
            gridTerms.RowEnter += new TTGridCellEventDelegate(gridTerms_RowEnter);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnCloseTerm.Click -= new TTControlEventDelegate(btnCloseTerm_Click);
            btnLockTerm.Click -= new TTControlEventDelegate(btnLockTerm_Click);
            btnCancelTerm.Click -= new TTControlEventDelegate(btnCancelTerm_Click);
            btnAdd.Click -= new TTControlEventDelegate(btnAdd_Click);
            gridTerms.RowEnter -= new TTGridCellEventDelegate(gridTerms_RowEnter);
            base.UnBindControlEvents();
        }

        private void btnCloseTerm_Click()
        {
#region InvoiceTermForm_btnCloseTerm_Click
   CloseTerm();
#endregion InvoiceTermForm_btnCloseTerm_Click
        }

        private void btnLockTerm_Click()
        {
#region InvoiceTermForm_btnLockTerm_Click
   LockTerm();
#endregion InvoiceTermForm_btnLockTerm_Click
        }

        private void btnCancelTerm_Click()
        {
#region InvoiceTermForm_btnCancelTerm_Click
   CancelTerm();
#endregion InvoiceTermForm_btnCancelTerm_Click
        }

        private void btnAdd_Click()
        {
#region InvoiceTermForm_btnAdd_Click
   CreateTerm();
#endregion InvoiceTermForm_btnAdd_Click
        }

        private void gridTerms_RowEnter(Int32 rowIndex, Int32 columnIndex)
        {
#region InvoiceTermForm_gridTerms_RowEnter
   if (gridTerms.Rows.Count > 0)
        {
            Guid termGuid = Guid.Parse(gridTerms.Rows[rowIndex].Cells["ObjectId"].Value.ToString());
            SelectedInvoiceTerm = invoiceTermList.FirstOrDefault(x => x.ObjectID == termGuid);
            FillInvoiceCollectionGrid();
        }
#endregion InvoiceTermForm_gridTerms_RowEnter
        }

#region InvoiceTermForm_Methods
        public TTObjectContext context;
        public IList<InvoiceTerm> invoiceTermList;
        private InvoiceTerm _selectedInvoiceTerm;

        public InvoiceTerm SelectedInvoiceTerm
        {
            get { return _selectedInvoiceTerm; }
            set { _selectedInvoiceTerm = value; }
        }

        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FillTermGrid();
        }

        public InvoiceTerm CreateTerm()
        {
            context = new TTObjectContext(false);
            InvoiceTerm newInvoiceTerm = InvoiceTerm.Create(context);
            FillTermGrid();
            SelectedInvoiceTerm = newInvoiceTerm;
            FillInvoiceCollectionGrid();
            return newInvoiceTerm;
        }

        

        public void CloseTerm()
        {
            if (SelectedInvoiceTerm != null)
            {
                context = new TTObjectContext(false);
                InvoiceTerm invoiceTerm = (InvoiceTerm)context.GetObject(_selectedInvoiceTerm.ObjectID,typeof(InvoiceTerm));
                invoiceTerm.Close();
                context.Save();
                FillTermGrid();
            }
        }

        public void LockTerm()
        {
            if (SelectedInvoiceTerm != null)
            {
                context = new TTObjectContext(false);
                InvoiceTerm invoiceTerm = (InvoiceTerm)context.GetObject(_selectedInvoiceTerm.ObjectID,typeof(InvoiceTerm));
                invoiceTerm.Lock();
                context.Save();
                FillTermGrid();
            }
        }

        public void CancelTerm()
        {
            if (SelectedInvoiceTerm != null)
            {
                context = new TTObjectContext(false);
                InvoiceTerm invoiceTerm = (InvoiceTerm)context.GetObject(_selectedInvoiceTerm.ObjectID, typeof(InvoiceTerm));
                invoiceTerm.Cancel();
                context.Save();
                FillTermGrid();
            }
        }
        
        public void FillInvoiceCollectionGrid()
        {
            gridInvoiceCollection.Rows.Clear();
            context = new TTObjectContext(false);
            InvoiceTerm invoiceTerm = (InvoiceTerm)context.GetObject(_selectedInvoiceTerm.ObjectID, typeof(InvoiceTerm));
            foreach (InvoiceCollection item in invoiceTerm.InvoiceCollections.Select(""))
            {
                ITTGridRow row = gridInvoiceCollection.Rows.Add();
                row.Cells["Name"].Value = item.Name;
                row.Cells["No"].Value = item.No;
                row.Cells["Date"].Value = item.Date;
                row.Cells["State"].Value = item.LastState.StateDef.DisplayText;
                row.Cells["TotalPrice"].Value = "";
                row.Cells["ServicePrice"].Value = "";
                row.Cells["MedicinePrice"].Value = "";
                row.Cells["ConsumptionPrice"].Value = "";
                row.Cells["Capacity"].Value = item.Capacity;
            }
        }

        public void FillTermGrid()
        {
            gridTerms.Rows.Clear();
            context = new TTObjectContext(false);
            List<Guid> states = new List<Guid>();
            states.Add(InvoiceTerm.States.Open);
            states.Add(InvoiceTerm.States.Closed);
            states.Add(InvoiceTerm.States.Locked);
            states.Add(InvoiceTerm.States.Cancelled);
            invoiceTermList = new List<InvoiceTerm>();
            invoiceTermList = InvoiceTerm.GetAllTerms(context, states.ToArray());
            if (invoiceTermList != null && invoiceTermList.Count > 0)
            {
                foreach (InvoiceTerm item in invoiceTermList)
                {
                    ITTGridRow row = gridTerms.Rows.Add();

                    row.Cells["TermName"].Value = item.Name;
                    row.Cells["TermStartDate"].Value = item.StartDate;
                    row.Cells["TermEndDate"].Value = item.EndDate;
                    row.Cells["TermLastState"].Value = item.LastState.StateDef.DisplayText;
                    row.Cells["ObjectId"].Value = item.ObjectID;
                }
            }
        }
        
#endregion InvoiceTermForm_Methods
    }
}