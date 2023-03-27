
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
    /// Kurum Avans Tahsilat
    /// </summary>
    public partial class PayerAdvancePaymentForm : TTForm
    {
    /// <summary>
    /// Kurum Avans Tahsilat
    /// </summary>
        protected TTObjectClasses.PayerAdvancePayment _PayerAdvancePayment
        {
            get { return (TTObjectClasses.PayerAdvancePayment)_ttObject; }
        }

        protected ITTObjectListBox PAYER;
        protected ITTLabel ttlabel6;
        protected ITTTabControl TabPaymentInfo;
        protected ITTTabPage TabCash;
        protected ITTGrid GridCashPayment;
        protected ITTTextBoxColumn PRICE;
        protected ITTListBoxColumn CURRENCYTYPE;
        protected ITTTabPage TabBankDecount;
        protected ITTGrid GridBankDecountPayment;
        protected ITTListBoxColumn BANKACCOUNT;
        protected ITTTextBoxColumn DECOUNTNO;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTabPage TabCheque;
        protected ITTGrid GridChequePayment;
        protected ITTTextBoxColumn NO;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTListBoxColumn BANKNAME;
        protected ITTTextBox CASHIERLOGID;
        protected ITTLabel ttlabel11;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox TOTALPRICE;
        protected ITTLabel ttlabel7;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel1;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel10;
        override protected void InitializeControls()
        {
            PAYER = (ITTObjectListBox)AddControl(new Guid("39f7d464-75ec-46b8-a6a2-6437ecfe45e0"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("8e2f4ee0-c3fa-4c02-9970-7f9eda339975"));
            TabPaymentInfo = (ITTTabControl)AddControl(new Guid("688a969b-11b4-401a-95d8-531f691f3964"));
            TabCash = (ITTTabPage)AddControl(new Guid("31a442f4-552f-4580-9d21-944f65621acc"));
            GridCashPayment = (ITTGrid)AddControl(new Guid("9769375f-7807-4133-a077-32afd77c2183"));
            PRICE = (ITTTextBoxColumn)AddControl(new Guid("ab6dc90c-89d2-4d12-a4b0-4790e7763428"));
            CURRENCYTYPE = (ITTListBoxColumn)AddControl(new Guid("ff19cf80-1793-48c8-973d-fed91e5d1fbe"));
            TabBankDecount = (ITTTabPage)AddControl(new Guid("673363f9-f876-4890-b91b-d0c078615f31"));
            GridBankDecountPayment = (ITTGrid)AddControl(new Guid("c91a0825-5aa3-4fee-80f6-f68114c76a94"));
            BANKACCOUNT = (ITTListBoxColumn)AddControl(new Guid("4bc6d5a9-3e58-48b4-bc14-f9310cb0cf64"));
            DECOUNTNO = (ITTTextBoxColumn)AddControl(new Guid("d420d33b-2f0b-4037-bf2f-2e6af7b54bbb"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("b21860d4-4a17-46ec-bdd8-2b0ba0449cce"));
            TabCheque = (ITTTabPage)AddControl(new Guid("ff9a23eb-0709-4f8c-b372-7ac26fd41c87"));
            GridChequePayment = (ITTGrid)AddControl(new Guid("e0d490b1-2bbc-4c11-900f-1e8f25c37837"));
            NO = (ITTTextBoxColumn)AddControl(new Guid("abf81161-422a-4db6-84f3-4f699eed027c"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("0bbd1027-0c1a-4f1b-b9ba-9b150fdeb111"));
            BANKNAME = (ITTListBoxColumn)AddControl(new Guid("eebf6327-835b-463f-aab7-0df1553e94bb"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("4b27879e-619c-4381-b680-8ef5028c7c54"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("3e7de107-3dce-489c-9208-3f852dbdb957"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("6fc4abd1-ad2c-4d3d-92dd-3763d98f93ae"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5bdb4ca5-d6a8-42c2-8b43-3d4ac15661df"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("43688ea9-79fb-474a-96a1-939efebafb4d"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("e0a12f3e-f90e-473e-afc2-a2994c2658ed"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("a7cbe284-37c8-418a-a9d8-1793cf73dbf4"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("9de61c71-957f-4cef-843b-fba41bdc7eae"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("46db6548-f6ee-4d40-8ce9-bf861dcc0217"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d9c43aab-bcd7-418a-8a31-a8f2f97dd5f0"));
            Description = (ITTTextBox)AddControl(new Guid("7505e57f-a89d-486a-94c3-595e7df99f5a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("fd264b4f-8d2c-4303-bceb-f37b61d0efa6"));
            base.InitializeControls();
        }

        public PayerAdvancePaymentForm() : base("PAYERADVANCEPAYMENT", "PayerAdvancePaymentForm")
        {
        }

        protected PayerAdvancePaymentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}