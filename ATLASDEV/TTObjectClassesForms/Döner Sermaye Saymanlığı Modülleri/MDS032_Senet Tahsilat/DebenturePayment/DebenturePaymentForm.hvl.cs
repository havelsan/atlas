
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
    /// Senet Tahsilat
    /// </summary>
    public partial class DebenturePaymentForm : TTForm
    {
    /// <summary>
    /// Senet Tahsilat
    /// </summary>
        protected TTObjectClasses.DebenturePayment _DebenturePayment
        {
            get { return (TTObjectClasses.DebenturePayment)_ttObject; }
        }

        protected ITTTextBox DESCRIPTION;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel2;
        protected ITTTextBox TOTALPRICE;
        protected ITTLabel ttlabel1;
        protected ITTTextBox PAYMENTPRICE;
        protected ITTTabControl DebentureInfo;
        protected ITTTabPage TabDebenture;
        protected ITTGrid GRIDDebentures;
        protected ITTTextBoxColumn NO;
        protected ITTDateTimePickerColumn DUEDATE;
        protected ITTTextBoxColumn DEBENTUREPRICE;
        protected ITTTextBoxColumn STATUS;
        protected ITTCheckBoxColumn PAID;
        protected ITTButtonColumn GUARANTORINFO;
        protected ITTTabControl TabPaymentInfo;
        protected ITTTabPage TabCash;
        protected ITTGrid GRIDCashs;
        protected ITTTextBoxColumn CASHPRICE;
        protected ITTListBoxColumn CURRENCYTYPE;
        protected ITTTabPage TabCreditCard;
        protected ITTGrid GRIDCreditCards;
        protected ITTTextBoxColumn OWNER;
        protected ITTTextBoxColumn PHONENO;
        protected ITTTextBoxColumn CARDNO;
        protected ITTDateTimePickerColumn VALIDDATE;
        protected ITTEnumComboBoxColumn CARDTYPE;
        protected ITTTextBoxColumn CREDITPRICE;
        protected ITTListBoxColumn BANKNAME;
        protected ITTTextBox CREDITCARDDOCUMENTNO;
        protected ITTLabel ttlabel7;
        protected ITTTextBox CASHIERNAME;
        protected ITTLabel ttlabel5;
        protected ITTTextBox RECEIPTSPECIALNO;
        protected ITTLabel labelCashOfficeName;
        protected ITTLabel ttlabel3;
        protected ITTTextBox CREDITCARDSPECIALNO;
        protected ITTTextBox CASHIERLOGID;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel6;
        protected ITTTextBox RECEIPTNO;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel9;
        override protected void InitializeControls()
        {
            DESCRIPTION = (ITTTextBox)AddControl(new Guid("c505d6c1-e060-414a-97b8-051fea1172c6"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("65f3b187-f62c-4284-80c3-3cb201503d22"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("bfb164a9-5bba-452a-8960-bd260ad38d10"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("2af6aea5-c91b-4c84-8f7e-2a794ec75c2a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b384ddad-ae62-4acc-9072-968c8bcd1505"));
            PAYMENTPRICE = (ITTTextBox)AddControl(new Guid("0480a8d6-b1ec-432c-810a-10ef81a351e4"));
            DebentureInfo = (ITTTabControl)AddControl(new Guid("99f812b1-a0d8-465d-a536-752f7bb0a0b8"));
            TabDebenture = (ITTTabPage)AddControl(new Guid("60ef3fe4-2dda-48be-94bc-a2e2f790c744"));
            GRIDDebentures = (ITTGrid)AddControl(new Guid("ec8eacf2-ff1c-4a2e-90b2-c281d9ada0f7"));
            NO = (ITTTextBoxColumn)AddControl(new Guid("aeb8e477-3edc-4c40-b01e-9c2c93a17f9f"));
            DUEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("26b2febf-9202-4903-bcf2-3a5a13676d23"));
            DEBENTUREPRICE = (ITTTextBoxColumn)AddControl(new Guid("6a7843b2-6d85-48e7-b624-70cac9df3879"));
            STATUS = (ITTTextBoxColumn)AddControl(new Guid("ef74d100-fcb0-47ce-bb26-6cce03a9cbb8"));
            PAID = (ITTCheckBoxColumn)AddControl(new Guid("71a456b3-2de7-4417-86d6-c5772eaa38e1"));
            GUARANTORINFO = (ITTButtonColumn)AddControl(new Guid("813bef08-501f-4c6d-abad-42b8dae27f87"));
            TabPaymentInfo = (ITTTabControl)AddControl(new Guid("913bd572-66f0-4842-977c-66f5ba7575c3"));
            TabCash = (ITTTabPage)AddControl(new Guid("5ff58279-af9a-4123-9b0b-782a7a705e6d"));
            GRIDCashs = (ITTGrid)AddControl(new Guid("2f90677b-8af9-4376-bad8-e32a8e96f408"));
            CASHPRICE = (ITTTextBoxColumn)AddControl(new Guid("df682176-e778-4fc5-95fd-32ff6881ca9f"));
            CURRENCYTYPE = (ITTListBoxColumn)AddControl(new Guid("015aa6d9-b920-48a6-872b-267ddae38f7d"));
            TabCreditCard = (ITTTabPage)AddControl(new Guid("cbd1f6e4-4c72-4df2-bd9f-eefaa8e0bd64"));
            GRIDCreditCards = (ITTGrid)AddControl(new Guid("4a34bf70-ef83-4d83-80b4-f8856089a302"));
            OWNER = (ITTTextBoxColumn)AddControl(new Guid("97000bba-2daa-41e5-bce5-2e5e5ce9b502"));
            PHONENO = (ITTTextBoxColumn)AddControl(new Guid("2728bcfd-bcae-4cf2-9a2f-d7e91bc5c43d"));
            CARDNO = (ITTTextBoxColumn)AddControl(new Guid("0eccc6d0-a2f8-440b-a0dc-7a4f15fc129e"));
            VALIDDATE = (ITTDateTimePickerColumn)AddControl(new Guid("659bb181-933f-4453-a9bc-9e31e222c4aa"));
            CARDTYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("ba624248-f84e-4ca4-8185-8eb6b39ac5e6"));
            CREDITPRICE = (ITTTextBoxColumn)AddControl(new Guid("4c1c1c2d-5517-4c29-aff0-9d50f8888f52"));
            BANKNAME = (ITTListBoxColumn)AddControl(new Guid("bd81b695-befc-449b-b35e-2fc08b201653"));
            CREDITCARDDOCUMENTNO = (ITTTextBox)AddControl(new Guid("3dfc0872-ccec-4b8f-b820-d2bae0c7e79e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("12cdb5f0-1dab-4c96-8fa4-8c9f74f60b65"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("b3306cdf-ca45-4192-8150-8422f10f174b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0f47e348-37e8-427a-a5d4-cdcbfa705344"));
            RECEIPTSPECIALNO = (ITTTextBox)AddControl(new Guid("d75281b2-0317-4e99-86eb-7733a3b24eea"));
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("9c43f6db-9a4e-47ec-baff-643414a377fd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d8b03c13-2d38-4eaa-8b75-51174dec623f"));
            CREDITCARDSPECIALNO = (ITTTextBox)AddControl(new Guid("861c4b29-1139-41dc-86b5-c5ec08d861b1"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("6b3f741b-314a-4cbd-a11d-7b6b44998831"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("139f9e2b-52a8-47cf-aed4-aecc969f2b26"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("ffbceb35-6003-438f-bf41-c0814175a3a0"));
            RECEIPTNO = (ITTTextBox)AddControl(new Guid("06e1b65a-5d8b-4f96-9efe-17100193068a"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("375313e8-c737-4315-9f4d-c62ae1c324c1"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("cc4a38cf-b9a0-4d9b-bde9-072b446439bd"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("65e3c0d6-cd62-48a1-b1ce-6180a876bf32"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("94d7ef16-2de3-4e29-89ee-68a65dfc9378"));
            base.InitializeControls();
        }

        public DebenturePaymentForm() : base("DEBENTUREPAYMENT", "DebenturePaymentForm")
        {
        }

        protected DebenturePaymentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}