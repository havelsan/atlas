
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
    public partial class InvoiceCollectionSearchForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            InvoiceCollectionGrid.CellContentClick += new TTGridCellEventDelegate(InvoiceCollectionGrid_CellContentClick);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            cbInvoiceCollectionState.SelectedIndexChanged += new TTControlEventDelegate(cbInvoiceCollectionState_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            InvoiceCollectionGrid.CellContentClick -= new TTGridCellEventDelegate(InvoiceCollectionGrid_CellContentClick);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            cbInvoiceCollectionState.SelectedIndexChanged -= new TTControlEventDelegate(cbInvoiceCollectionState_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void InvoiceCollectionGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region InvoiceCollectionSearchForm_InvoiceCollectionGrid_CellContentClick
   TTObjectContext objectcontext = new TTObjectContext(true);
                var invoiceCollectionObjectID = InvoiceCollectionGrid.Rows[rowIndex].Cells["ObjectID"].Value;
                
                loadInvoiceCollectionDetailGrid((Guid)invoiceCollectionObjectID);
               
                objectcontext.Dispose();
                
                tbProcedureTotalPrice.Text = InvoiceCollectionGrid.Rows[rowIndex].Cells["gcName"].Value.ToString();
                tbMedicineTotalPrice.Text = InvoiceCollectionGrid.Rows[rowIndex].Cells["gcDate"].Value.ToString();
                tbMaterialTotalPrice.Text = InvoiceCollectionGrid.Rows[rowIndex].Cells["gcState"].Value.ToString();
#endregion InvoiceCollectionSearchForm_InvoiceCollectionGrid_CellContentClick
        }

        private void ttbutton2_Click()
        {
#region InvoiceCollectionSearchForm_ttbutton2_Click
   //            InvoiceCollectionForm icf = new InvoiceCollectionForm();
//            
//            icf.Show();
#endregion InvoiceCollectionSearchForm_ttbutton2_Click
        }

        private void ttbutton1_Click()
        {
#region InvoiceCollectionSearchForm_ttbutton1_Click
   System.Diagnostics.Debugger.Break();
 
           
            Guid? InvoiceTermP = null, InvoiceCollectionStateP = null;

            if (cbInvoiceTerm.SelectedItem != null)
                InvoiceTermP = (Guid)cbInvoiceTerm.SelectedItem.Value;
//
//            if (cbInvoiceCollectionState.SelectedItem != null)
//                InvoiceCollectionStateP = (Guid)cbInvoiceTerm.SelectedItem.Value;
//             
//             var z = Convert.ToDateTime(dtpInvoiceCollectionFirstDate.Text);
//             var t = Convert.ToDateTime(dtpInvoiceCollectionLastDate.Text);
//             var q = cbTedaviTuru.SelectedItem.Value;
//             var xy = tbInvoiceCollectionFirstPrice.Text;
//             var xz = tbInvoiceCollectionLastPrice.Text;
//             var xt = tbInvoiceCollectionNo.Text;
//             var xq = lbPayerDefinition.SelectedObject.ObjectID;
//             var xx = Convert.ToDateTime(dtpInvoiceCollectionStateFirstDate.Text);
//             var yx = Convert.ToDateTime(dtpInvoiceCollectionStateLastDate.Text);
//             var yy = tbInvoiceCollectionSendNo.Text;
//             
//            search(InvoiceTermP, InvoiceCollectionStateP, Convert.ToDateTime(dtpInvoiceCollectionFirstDate.Text)
//                   ,Convert.ToDateTime(dtpInvoiceCollectionLastDate.Text),cbTedaviTuru.SelectedItem.Value,tbInvoiceCollectionFirstPrice.Text,tbInvoiceCollectionLastPrice.Text
//                   ,tbInvoiceCollectionNo.Text,lbPayerDefinition.SelectedObject.ObjectID,Convert.ToDateTime(dtpInvoiceCollectionSendFirstDate.Text),Convert.ToDateTime(dtpInvoiceCollectionSendLastDate.Text)
//                   , tbInvoiceCollectionSendNo.Text);
             
search(InvoiceTermP);
#endregion InvoiceCollectionSearchForm_ttbutton1_Click
        }

        private void cbInvoiceCollectionState_SelectedIndexChanged()
        {
#region InvoiceCollectionSearchForm_cbInvoiceCollectionState_SelectedIndexChanged
   dateLabel.Visible = true;
            dtpInvoiceCollectionStateFirstDate.Visible = true;
            dtpInvoiceCollectionStateLastDate.Visible = true;
            
            if((int)cbInvoiceCollectionState.SelectedItem.Value == (int)InvoiceCollectionStateEnum.Send)
                dateLabel.Text = (Common.GetEnumValueDefOfEnumValue((Enum)InvoiceCollectionStateEnum.Send)).DisplayText + " Tarihi";
            else if((int)cbInvoiceCollectionState.SelectedItem.Value == (int)InvoiceCollectionStateEnum.Delivered)
                dateLabel.Text = (Common.GetEnumValueDefOfEnumValue((Enum)InvoiceCollectionStateEnum.Delivered)).DisplayText + " Tar.";
            else
            {
                dateLabel.Visible = false;
                dtpInvoiceCollectionStateFirstDate.Visible = false;
                dtpInvoiceCollectionStateLastDate.Visible = false;
            }
#endregion InvoiceCollectionSearchForm_cbInvoiceCollectionState_SelectedIndexChanged
        }

#region InvoiceCollectionSearchForm_Methods
        //        private void search(object value1, object value2, DateTime dateTime1, DateTime dateTime2, object value3, string text1, string text2, string text3, Guid objectID, DateTime dateTime3, DateTime dateTime4,string InvoiceCollectionSendNo)
        //        {
        //            throw new NotImplementedException();
        //        }
        private void search(Guid? InvoiceTerm)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            string injection = string.Empty;

            InvoiceCollectionGrid.Rows.Clear();
               
            if (!string.IsNullOrEmpty(InvoiceTerm.ToString()))
            {
                injection += " AND INVOICETERM = '"+ InvoiceTerm.ToString()+ "'";
            }

            BindingList<InvoiceCollection.GetInvoiceCollectionByInjection_Class> invCollection = InvoiceCollection.GetInvoiceCollectionByInjection(objectcontext, injection);
            
            foreach (var item in invCollection)
            {
                ITTGridRow row = InvoiceCollectionGrid.Rows.Add();
                row.Cells[0].Value = item.Name;
                row.Cells[1].Value = item.Date;
                row.Cells[2].Value = item.Statedisplaytext;
                row.Cells[3].Value = "";
                row.Cells[4].Value = "";
                row.Cells[5].Value = item.ObjectID;
            }
        }
        
        private void loadInvoiceCollectionDetailGrid(Guid InvoiceCollectionObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            InvoiceCollection ic = (InvoiceCollection)objectcontext.GetObject(InvoiceCollectionObjectID, typeof(InvoiceCollection));
            BindingList<InvoiceCollectionDetail> icd = ic.InvoiceCollectionDetails.Select("");
            loadInvoiceCollectionDetail(icd);
        }
        
        private void loadInvoiceCollectionDetail(BindingList<InvoiceCollectionDetail> icd)
        {
            InvoiceCollectionDetailGrid.Rows.Clear();
            foreach(InvoiceCollectionDetail item in icd)
            {
               ITTGridRow row = InvoiceCollectionDetailGrid.Rows.Add();
               row.Cells[0].Value = item.CreateDate;
                
            }
        }
        
#endregion InvoiceCollectionSearchForm_Methods
    }
}