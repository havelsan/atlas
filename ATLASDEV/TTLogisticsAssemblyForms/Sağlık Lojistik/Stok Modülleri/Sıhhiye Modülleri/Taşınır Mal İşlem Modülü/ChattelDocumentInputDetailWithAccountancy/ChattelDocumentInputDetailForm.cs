
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
    /// Malzeme Detayları
    /// </summary>
    public partial class ChattelDocumentInputDetailForm : BaseStockActionDetailInForm
    {
        override protected void BindControlEvents()
        {
            cmdGetInvoiceDetail.Click += new TTControlEventDelegate(cmdGetInvoiceDetail_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdGetInvoiceDetail.Click -= new TTControlEventDelegate(cmdGetInvoiceDetail_Click);
            base.UnBindControlEvents();
        }

        private void cmdGetInvoiceDetail_Click()
        {
#region ChattelDocumentInputDetailForm_cmdGetInvoiceDetail_Click
   if (_ChattelDocumentInputDetailWithAccountancy.InvoiceDetails.Count > 0)
            {
                InvoiceDetail invoiceDetail = _ChattelDocumentInputDetailWithAccountancy.InvoiceDetails[0];

                //TODO
                //this.invoicePictureBox.Image = (Image)invoiceDetail.InvoicePicture;

                this.invoiceDateTimePicker.NullableValue = invoiceDetail.InvoiceDate;
                this.auctionDate.NullableValue= invoiceDetail.AuctionDate;
                this.RANo.Text  = invoiceDetail.RegistrationAuctionNo ;
            }
            else
                InfoBox.Show("Fatura bilgileri bulunamadı.", MessageIconEnum.ErrorMessage);
#endregion ChattelDocumentInputDetailForm_cmdGetInvoiceDetail_Click
        }

        protected override void PreScript()
        {
#region ChattelDocumentInputDetailForm_PreScript
    base.PreScript();
#endregion ChattelDocumentInputDetailForm_PreScript

            }
                }
}