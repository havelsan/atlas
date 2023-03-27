
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
    /// Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı
    /// </summary>
    public partial class GeneralReceiptForm : TTForm
    {
    /// <summary>
    /// Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı
    /// </summary>
        protected TTObjectClasses.GeneralReceipt _GeneralReceipt
        {
            get { return (TTObjectClasses.GeneralReceipt)_ttObject; }
        }

        protected ITTTextBox RECEIPTNO;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox Description;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox RECEIPTSPECIALNO;
        protected ITTTextBox PAYEENAME;
        protected ITTTextBox PAYEEADDRESS;
        protected ITTTextBox TOTALPRICE;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelCashOfficeName;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTMaskedTextBox PAYEEUNIQUEREFNO;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel2;
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
        protected ITTListBoxColumn BANKNAME;
        protected ITTEnumComboBoxColumn CARDTYPE;
        protected ITTTextBoxColumn CREDITPRICE;
        protected ITTTextBox CREDITCARDSPECIALNO;
        protected ITTTextBox CREDITCARDDOCUMENTNO;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel13;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GRIDReceiptProcedures;
        protected ITTDateTimePickerColumn PACTIONDATE;
        protected ITTListBoxColumn PPROCEDURE;
        protected ITTTextBoxColumn PAMOUNT;
        protected ITTTextBoxColumn PUNITPRICE;
        protected ITTTextBoxColumn PTOTALPRICE;
        protected ITTTextBox TOTALPAYMENT;
        protected ITTLabel ttlabel15;
        override protected void InitializeControls()
        {
            RECEIPTNO = (ITTTextBox)AddControl(new Guid("cdcd7b29-2a2a-44a8-b4c9-ddbe1520d647"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("0506b545-e8c8-4595-aa96-606095390aa4"));
            Description = (ITTTextBox)AddControl(new Guid("2816c93e-e84f-45ee-91d7-570a59f793a7"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("e2ad33d4-a6bd-4a8e-b63a-744920878788"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("ecde3b8d-5402-47a8-a128-b70ab5e93a70"));
            RECEIPTSPECIALNO = (ITTTextBox)AddControl(new Guid("217515b2-23f0-4704-828f-2b74db64d892"));
            PAYEENAME = (ITTTextBox)AddControl(new Guid("6235ad86-4ce6-44a8-ab1f-901b58f9daaf"));
            PAYEEADDRESS = (ITTTextBox)AddControl(new Guid("5bb38fa0-64e2-472b-baaf-d3b80100ada5"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("812b4cda-3f61-4998-8876-4124161226b4"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("63ce0c12-5e36-4e39-b6de-082b09cc7f88"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("d7d3f1ef-f6e8-461d-9ebe-950139a26f37"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("be9e2747-0cd0-433f-b356-788a4516845a"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("2a54ed97-083e-4e77-831c-562a0932683f"));
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("e487bbdc-0e07-46b0-9744-0c6513847525"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("17f4f80f-9e7e-471f-958b-d7f786ddd93e"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("57d43fdf-72a6-4029-a52b-bb46755bf637"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("742d8743-ae5c-49aa-8f80-ca996c44e57c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("dd978fe3-6edb-4f05-a450-70d7175fa80a"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("1c69c4c5-13de-4859-b2ff-d95a5ca3d220"));
            PAYEEUNIQUEREFNO = (ITTMaskedTextBox)AddControl(new Guid("a172b6df-ddb0-4d5e-ba94-48e94a0e83cf"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("7ea9677e-eab7-4bff-9eef-70626bee1214"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ab9701a1-a36b-4d62-90fd-301eb6a18201"));
            TabPaymentInfo = (ITTTabControl)AddControl(new Guid("d2f9b81c-b0e9-4445-8521-37a89b298d9c"));
            TabCash = (ITTTabPage)AddControl(new Guid("5ce73fe4-c77a-42c9-bcc5-41b2fcb1c5d7"));
            GRIDCashs = (ITTGrid)AddControl(new Guid("a8845c94-4b01-4864-807e-2690b94eabd8"));
            CASHPRICE = (ITTTextBoxColumn)AddControl(new Guid("15786bc9-f731-4e41-89fc-1e2405b2225c"));
            CURRENCYTYPE = (ITTListBoxColumn)AddControl(new Guid("a213afd9-0756-47a6-a58e-75813ee5685e"));
            TabCreditCard = (ITTTabPage)AddControl(new Guid("aabc99b7-2556-4aa9-aa03-ee871b039e07"));
            GRIDCreditCards = (ITTGrid)AddControl(new Guid("ab4a710b-3eb7-4379-8e3e-9d96f3a4a369"));
            OWNER = (ITTTextBoxColumn)AddControl(new Guid("fbeff8df-e335-45d3-bcfd-9b8448b0e4b4"));
            PHONENO = (ITTTextBoxColumn)AddControl(new Guid("585846f9-41cc-4518-a779-9362514df4a0"));
            CARDNO = (ITTTextBoxColumn)AddControl(new Guid("8062e2e9-9ac8-4fa5-b60e-9a9fca556d54"));
            VALIDDATE = (ITTDateTimePickerColumn)AddControl(new Guid("5a75d4fd-1508-4a0e-8c67-11bf4758389c"));
            BANKNAME = (ITTListBoxColumn)AddControl(new Guid("1cda1515-2382-4a41-b7f5-80c345469fc1"));
            CARDTYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("ccbe447b-c846-4d36-8dc0-3d37d39d4edc"));
            CREDITPRICE = (ITTTextBoxColumn)AddControl(new Guid("30cd7111-69c0-46cd-ae53-9103982c11cf"));
            CREDITCARDSPECIALNO = (ITTTextBox)AddControl(new Guid("117da9b0-c0b7-4f98-b503-d576e504fa66"));
            CREDITCARDDOCUMENTNO = (ITTTextBox)AddControl(new Guid("d1beba71-3f87-4c95-9563-1abdd3354199"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("9f46154f-f795-4d7a-87c8-e84fb8e506f8"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("d459d714-f1b6-4321-b7dd-bbb6bced5162"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a14f0e5d-a924-4c80-818f-7d2ebc5ff980"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("e0dc9cdf-cca5-4360-bab3-f9e052a61a30"));
            GRIDReceiptProcedures = (ITTGrid)AddControl(new Guid("6e4d9fd8-d9b4-4b34-82bc-199c79315295"));
            PACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("2243a10d-2285-4ae6-9239-647a19b548fe"));
            PPROCEDURE = (ITTListBoxColumn)AddControl(new Guid("5e648e17-48e4-48aa-8ca2-7f81e9be9160"));
            PAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("d55d0755-dbe7-4f75-a457-a223ba133ba2"));
            PUNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("e00d6f5e-83b1-494e-91d0-d419a1a1690f"));
            PTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("42360fb3-6dce-43ca-bbb7-3b8e4cb24263"));
            TOTALPAYMENT = (ITTTextBox)AddControl(new Guid("ab82c587-e6ba-4f92-a956-8c891a3f22a4"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("ec3f5558-47cb-4c8d-a027-b1bc09797b89"));
            base.InitializeControls();
        }

        public GeneralReceiptForm() : base("GENERALRECEIPT", "GeneralReceiptForm")
        {
        }

        protected GeneralReceiptForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}