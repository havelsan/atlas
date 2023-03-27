
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
    /// Banka Ödeme Fişi Girişi
    /// </summary>
    public partial class BankPaymentDecountForm : TTForm
    {
    /// <summary>
    /// Banka Ödeme Fişi
    /// </summary>
        protected TTObjectClasses.BankPaymentDecount _BankPaymentDecount
        {
            get { return (TTObjectClasses.BankPaymentDecount)_ttObject; }
        }

        protected ITTDateTimePicker dtPickerDecountDate;
        protected ITTLabel lblBankDecountDate;
        protected ITTLabel ttlabel5;
        protected ITTTextBox txtTotalPrice;
        protected ITTTextBox txtCashOffice;
        protected ITTTextBox txtCashierName;
        protected ITTTextBox txtDecountNo;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox BANKACCOUNT;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel10;
        override protected void InitializeControls()
        {
            dtPickerDecountDate = (ITTDateTimePicker)AddControl(new Guid("5be5f857-6cef-4665-ac83-62883a35299e"));
            lblBankDecountDate = (ITTLabel)AddControl(new Guid("21865d45-04f8-4377-84bc-3cd3fd11f069"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("10e220f5-a976-4f45-a3b6-270a33fc741b"));
            txtTotalPrice = (ITTTextBox)AddControl(new Guid("80c8d8f5-edf7-4498-a38a-102ebf70c377"));
            txtCashOffice = (ITTTextBox)AddControl(new Guid("85d1a6f5-9c70-40bb-b6f6-b8d23988147a"));
            txtCashierName = (ITTTextBox)AddControl(new Guid("ca94b58a-b91e-4732-9061-f5d2a529b6e0"));
            txtDecountNo = (ITTTextBox)AddControl(new Guid("4dac8e88-3802-489f-9d37-aff2bd592b59"));
            Description = (ITTTextBox)AddControl(new Guid("726962ce-6fa5-4a7b-a1be-817a3836b714"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2fa3e0fa-a583-4c23-8202-7a17b7ee6754"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("afc36bd8-8ef4-438c-a66d-e0cd210b0b5d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9734bb86-e956-4926-b256-6a93c3795a5b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8c8878c0-f8b5-4777-ae95-2357f5b4e981"));
            BANKACCOUNT = (ITTObjectListBox)AddControl(new Guid("222a1f6e-be2b-4987-b5bb-29642b584d8b"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("f9f999b4-10d7-43f9-8a69-19d6be3298be"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("393c51d0-51f3-40d0-a330-5c5924c821b6"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("eac316ec-0c25-4694-9389-f48624e6fc9e"));
            base.InitializeControls();
        }

        public BankPaymentDecountForm() : base("BANKPAYMENTDECOUNT", "BankPaymentDecountForm")
        {
        }

        protected BankPaymentDecountForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}