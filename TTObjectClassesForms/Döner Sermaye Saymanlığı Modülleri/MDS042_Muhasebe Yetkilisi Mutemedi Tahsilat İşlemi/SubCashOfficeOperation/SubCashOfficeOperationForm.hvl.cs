
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
    /// Muhasebe Yetkilisi Mutemedi Tahsilat İşlemi
    /// </summary>
    public partial class SubCashOfficeOperationForm : TTForm
    {
    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Tahsilat İşlemi
    /// </summary>
        protected TTObjectClasses.SubCashOfficeOperation _SubCashOfficeOperation
        {
            get { return (TTObjectClasses.SubCashOfficeOperation)_ttObject; }
        }

        protected ITTLabel labelCashOfficeName;
        protected ITTTextBox RECEIPTNO;
        protected ITTTextBox CASHIERNAME;
        protected ITTLabel ttlabel3;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel7;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox MONEYRECEIVEDTYPE;
        protected ITTTextBox CASHIERLOGID;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel1;
        protected ITTTextBox RECEIPTSPECIALNO;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTTextBox PAYEENAME;
        protected ITTLabel ttlabel4;
        protected ITTTextBox PAYEEADDRESS;
        protected ITTLabel ttlabel5;
        protected ITTMaskedTextBox PAYEEUNIQUEREFNO;
        protected ITTLabel ttlabel12;
        protected ITTTextBox TOTALPRICE;
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
        protected ITTLabel ttlabel8;
        protected ITTTextBox CREDITCARDDOCUMENTNO;
        protected ITTLabel ttlabel13;
        override protected void InitializeControls()
        {
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("f570f457-7ba9-481c-91b7-05e1287bb2b1"));
            RECEIPTNO = (ITTTextBox)AddControl(new Guid("f3a2cffa-9e08-4005-a23d-ff603238617a"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("017b4d57-3b05-4538-aa5c-4d338d10e035"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("52d775fa-9f98-449d-a2fa-f56d1713d32e"));
            Description = (ITTTextBox)AddControl(new Guid("cd2a601b-1019-4ff4-96a6-0299be371ea5"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("85bf92f7-79ce-4315-beaf-3da600be4739"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("7cbb34f9-c9b5-49fe-b355-c771326b54e5"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("f8004282-8cd8-4f96-b696-a034d4cc641d"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("c66ed0f5-0916-4fbd-b6b0-867c0e2e3a4b"));
            MONEYRECEIVEDTYPE = (ITTObjectListBox)AddControl(new Guid("bd0b3336-5342-4ca0-a970-89b625f4538f"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("8b56a169-0053-4fd0-a4c1-14a0271989b1"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("b25100cf-6101-4df3-946f-5c0ebd7aa06c"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("2ac33fcc-7380-4d86-bf8a-4fe8b3a16aec"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("67d38313-3da2-4232-ade4-f4ebe9d6ba87"));
            RECEIPTSPECIALNO = (ITTTextBox)AddControl(new Guid("71d1740d-474d-45cf-b74d-36ae49fe5851"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("acc920ed-c4f2-413c-8d79-e05f01cc3e67"));
            PAYEENAME = (ITTTextBox)AddControl(new Guid("8619a822-55fe-417f-9f59-e1a2f113d1de"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e3792a24-e75a-4c8d-b41f-2876238cb277"));
            PAYEEADDRESS = (ITTTextBox)AddControl(new Guid("f35f8c9d-b3a5-4df6-8cf1-19bcd6639180"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("60bb75bd-578f-4dc3-a380-84c1c3f1fda4"));
            PAYEEUNIQUEREFNO = (ITTMaskedTextBox)AddControl(new Guid("d4f73845-1739-4e56-89e8-f51493d82d89"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("3a1bbae9-9b26-4a21-a152-0b83dd39aaaa"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("480d429c-3de1-4d08-b41c-3250f8ad30ed"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6605d796-8cc1-4568-9b4b-ad4f9929dcab"));
            TabPaymentInfo = (ITTTabControl)AddControl(new Guid("57ee5cfe-cb29-4698-a4fe-c16adef757c4"));
            TabCash = (ITTTabPage)AddControl(new Guid("1f9ea775-33a5-4964-9fc6-96c719532c5c"));
            GRIDCashs = (ITTGrid)AddControl(new Guid("5ad258c8-ea0a-4c24-bd4c-f562c4a6a3e0"));
            CASHPRICE = (ITTTextBoxColumn)AddControl(new Guid("ea8af3ab-47ad-4aee-ab39-511f6bad809f"));
            CURRENCYTYPE = (ITTListBoxColumn)AddControl(new Guid("c7a7b8e5-1256-4ae3-a0bd-ce3c7c4bde02"));
            TabCreditCard = (ITTTabPage)AddControl(new Guid("8312a2e8-1c4e-4534-b17c-cbaa5ce8000f"));
            GRIDCreditCards = (ITTGrid)AddControl(new Guid("911547c7-8ff1-4e76-9c86-f105fcefb582"));
            OWNER = (ITTTextBoxColumn)AddControl(new Guid("f4996e5f-6e85-4fc1-9d64-d3a31f1f921d"));
            PHONENO = (ITTTextBoxColumn)AddControl(new Guid("22c4f12d-b909-4a94-8ccc-01e13ff1064f"));
            CARDNO = (ITTTextBoxColumn)AddControl(new Guid("db8437c3-eb64-4690-8d67-982694f731f3"));
            VALIDDATE = (ITTDateTimePickerColumn)AddControl(new Guid("743b76d8-0838-4d9b-b1ca-cde3ede58cb1"));
            BANKNAME = (ITTListBoxColumn)AddControl(new Guid("ba9485b1-0862-469d-97af-e05e2cc01961"));
            CARDTYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("1ec5cf43-94f5-42ae-ab64-330c68d232fa"));
            CREDITPRICE = (ITTTextBoxColumn)AddControl(new Guid("26e59dca-f436-4e39-be68-7b48f7b7fce9"));
            CREDITCARDSPECIALNO = (ITTTextBox)AddControl(new Guid("96cb0d21-f406-4f72-bd24-cb3611bdc158"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("572681f6-98d4-4d97-b4e8-eba970debb0d"));
            CREDITCARDDOCUMENTNO = (ITTTextBox)AddControl(new Guid("24124e3e-136a-4e24-a0ba-dc6e2bb5592d"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("6bbf1f10-0688-4670-a013-4328eae09f8b"));
            base.InitializeControls();
        }

        public SubCashOfficeOperationForm() : base("SUBCASHOFFICEOPERATION", "SubCashOfficeOperationForm")
        {
        }

        protected SubCashOfficeOperationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}