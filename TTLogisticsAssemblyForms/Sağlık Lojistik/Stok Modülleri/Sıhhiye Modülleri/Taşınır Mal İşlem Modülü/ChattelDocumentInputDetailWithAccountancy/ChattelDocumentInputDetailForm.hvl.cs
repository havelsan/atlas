
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
        protected TTObjectClasses.ChattelDocumentInputDetailWithAccountancy _ChattelDocumentInputDetailWithAccountancy
        {
            get { return (TTObjectClasses.ChattelDocumentInputDetailWithAccountancy)_ttObject; }
        }

        protected ITTTabPage InvoiceTabPage;
        protected ITTLabel ttlabel12;
        protected ITTButton cmdGetInvoiceDetail;
        protected ITTTextBox RANo;
        protected ITTLabel ttlabel10;
        protected ITTDateTimePicker invoiceDateTimePicker;
        protected ITTLabel ttlabel9;
        protected ITTPictureBoxControl invoicePictureBox;
        protected ITTDateTimePicker auctionDate;
        protected ITTLabel ttlabel11;
        override protected void InitializeControls()
        {
            InvoiceTabPage = (ITTTabPage)AddControl(new Guid("d2441cfb-a5d4-47bb-a6d1-4b6d92ffbe9a"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("4ee51c62-7b86-488a-8023-a5b8e2c4f6f7"));
            cmdGetInvoiceDetail = (ITTButton)AddControl(new Guid("af7eb48c-a7c2-4361-9815-190417603750"));
            RANo = (ITTTextBox)AddControl(new Guid("44747448-1372-4271-a72b-c5da34522c8e"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("a4ade33b-db05-4902-a428-f4013fa4ce6e"));
            invoiceDateTimePicker = (ITTDateTimePicker)AddControl(new Guid("16357edb-b429-44f2-a755-d4e3afec753f"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("db5a5bff-e2bc-41e6-aec8-e871519a9e56"));
            invoicePictureBox = (ITTPictureBoxControl)AddControl(new Guid("28b78299-4160-42fc-a9a3-0983bc58b949"));
            auctionDate = (ITTDateTimePicker)AddControl(new Guid("65e90e33-177c-4063-b86a-956bcebfcba2"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("dc6f2c04-7b27-49e5-b461-76024bc344ac"));
            base.InitializeControls();
        }

        public ChattelDocumentInputDetailForm() : base("CHATTELDOCUMENTINPUTDETAILWITHACCOUNTANCY", "ChattelDocumentInputDetailForm")
        {
        }

        protected ChattelDocumentInputDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}