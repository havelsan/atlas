
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
    /// Vezne Alındı Numarası Tanımlama
    /// </summary>
    public partial class ReceiptCashOfficeForm : TTDefinitionForm
    {
    /// <summary>
    /// Sayman Mutemetliği / Vezne Alındı Numarası Tanımlama
    /// </summary>
        protected TTObjectClasses.ReceiptCashOfficeDefinition _ReceiptCashOfficeDefinition
        {
            get { return (TTObjectClasses.ReceiptCashOfficeDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel10;
        protected ITTTextBox txtCashOfficeOrderNo;
        protected ITTTextBox txtCREDITCARDENDNUMBER;
        protected ITTTextBox RECEIPTSTARTNUMBER;
        protected ITTTextBox CURRENTRECEIPTNUMBER;
        protected ITTTextBox txtCREDITCARDSTARTNUMBER;
        protected ITTTextBox txtCURRENTCREDITCARDNUMBER;
        protected ITTTextBox RECEIPTSERIESNO;
        protected ITTTextBox txtCREDITCARDSERIESNO;
        protected ITTTextBox RECEIPTENDNUMBER;
        protected ITTCheckBox chxCreditCardPayment;
        protected ITTCheckBox cbxActive;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox CASHOFFICE;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel8;
        override protected void InitializeControls()
        {
            ttlabel10 = (ITTLabel)AddControl(new Guid("db141f3f-1fac-46a9-bed0-b8c117a777bc"));
            txtCashOfficeOrderNo = (ITTTextBox)AddControl(new Guid("db8305a1-6b24-44f4-adbc-5d6e35e637f3"));
            txtCREDITCARDENDNUMBER = (ITTTextBox)AddControl(new Guid("5c87c852-a4e9-4121-99a5-3b03bd72480b"));
            RECEIPTSTARTNUMBER = (ITTTextBox)AddControl(new Guid("c7e0d959-5184-408f-9861-57c16abbf68c"));
            CURRENTRECEIPTNUMBER = (ITTTextBox)AddControl(new Guid("857691d4-e10d-4c8f-9c90-6d560083efd0"));
            txtCREDITCARDSTARTNUMBER = (ITTTextBox)AddControl(new Guid("165ec28c-788b-4880-ab42-a630a71ee5f1"));
            txtCURRENTCREDITCARDNUMBER = (ITTTextBox)AddControl(new Guid("e47da1a5-5342-4880-a64e-a732b6f9eac1"));
            RECEIPTSERIESNO = (ITTTextBox)AddControl(new Guid("9680762a-ed7d-463c-b96a-c0e64f56843f"));
            txtCREDITCARDSERIESNO = (ITTTextBox)AddControl(new Guid("5cbc0e72-ffa6-4249-95cd-df6ec20b3ef0"));
            RECEIPTENDNUMBER = (ITTTextBox)AddControl(new Guid("72df7c49-a5b8-4fce-b817-f0a87f530d83"));
            chxCreditCardPayment = (ITTCheckBox)AddControl(new Guid("17efb527-1cbe-4fba-8a55-2e8ca8bd6b20"));
            cbxActive = (ITTCheckBox)AddControl(new Guid("b8e6dbb8-2f04-4afd-ad97-f8e83fde1066"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f0ac2193-0c8c-41e2-8eb3-1f3357c1ae50"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("34e95812-4ba7-45d6-a879-2c8d405be03e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("bf487c57-421a-4ef7-9c4e-4004cc709888"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("37ce33cb-9061-4161-9583-503856c2a93a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ed04b98d-9c40-451f-85e6-5f03454b892f"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("0bfb8f1f-9ffe-4c8d-aedf-72a290479828"));
            CASHOFFICE = (ITTObjectListBox)AddControl(new Guid("451f4256-4fc9-4dab-910f-74c8b858e1e2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d7c30edd-ebf6-40f6-ac8b-9739c16a3b1e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6723195a-a8d8-450b-bbd4-9a3ac5cc8d1e"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("f4866cee-7549-437f-b82c-b8db5d64583f"));
            base.InitializeControls();
        }

        public ReceiptCashOfficeForm() : base("RECEIPTCASHOFFICEDEFINITION", "ReceiptCashOfficeForm")
        {
        }

        protected ReceiptCashOfficeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}