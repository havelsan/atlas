
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
    /// Fatura Tahsilat
    /// </summary>
    public partial class InvoicePaymentForm : TTForm
    {
    /// <summary>
    /// Fatura Tahsilat
    /// </summary>
        protected TTObjectClasses.InvoicePayment _InvoicePayment
        {
            get { return (TTObjectClasses.InvoicePayment)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage PriceList;
        protected ITTGrid GridInvoiceList;
        protected ITTTextBoxColumn PATIENTNO;
        protected ITTTextBoxColumn PATIENTNAME;
        protected ITTDateTimePickerColumn INVOICEDATE;
        protected ITTTextBoxColumn INVOICEDOCUMENTNO;
        protected ITTTextBoxColumn INVOICETOTALPRICE;
        protected ITTTextBoxColumn INVOICECUTOFFPRICE;
        protected ITTCheckBoxColumn PAID;
        protected ITTTabPage CancelledInvoicesTab;
        protected ITTGrid CancelledInvoicesGrid;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTTextBoxColumn tttextboxcolumn3;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTTextBoxColumn CANCELREASON;
        protected ITTTextBox TotalPrice;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox InvoiceDocumentNoStart;
        protected ITTTextBox InvoiceDocumentNoEnd;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox CUTOFFPRICE;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox PAYMENTPRICE;
        protected ITTButton FillPayerButton;
        protected ITTButton CheckAll;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelTotalPrice;
        protected ITTObjectListBox PAYER;
        protected ITTDateTimePicker InvoiceDateEnd;
        protected ITTLabel labelInvoiceDocumentNoStart;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelInvoiceDateEnd;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelInvoiceDateStart;
        protected ITTLabel ttlabel6;
        protected ITTButton ListButon;
        protected ITTDateTimePicker InvoiceDateStart;
        protected ITTLabel labelInvoiceDocumentNoEnd;
        protected ITTTabControl TabPaymentInfo;
        protected ITTTabPage TabCash;
        protected ITTGrid GridCashPayment;
        protected ITTTextBoxColumn PRICE;
        protected ITTListBoxColumn CURRENCYTYPE;
        protected ITTTabPage TabBankDecount;
        protected ITTGrid GridBankDecountPayment;
        protected ITTListBoxColumn BANKACCOUNT;
        protected ITTTextBoxColumn DECOUNTNO;
        protected ITTTextBoxColumn tttextboxcolumn5;
        protected ITTTabPage TabCheque;
        protected ITTGrid GridChequePayment;
        protected ITTTextBoxColumn NO;
        protected ITTTextBoxColumn tttextboxcolumn6;
        protected ITTListBoxColumn BANKNAME;
        protected ITTTabPage TabAdvance;
        protected ITTCheckBox USEADVANCE;
        protected ITTGrid GridAdvancePayment;
        protected ITTDateTimePickerColumn ADVANCEDATE;
        protected ITTTextBoxColumn ADVANCEDECOUNTNO;
        protected ITTTextBoxColumn TOTALADVANCEPRICE;
        protected ITTTextBoxColumn REMAININGPRICE;
        protected ITTTextBoxColumn USEDPRICE;
        protected ITTCheckBoxColumn USED;
        protected ITTTextBox TOTALPAYMENT;
        protected ITTTextBox RemainderCheckbox;
        protected ITTLabel ttlabel7;
        protected ITTButton UncheckAll;
        protected ITTLabel ttlabel8;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("26181407-1fbf-4836-823c-e381cd4b4743"));
            PriceList = (ITTTabPage)AddControl(new Guid("62c40d5e-a28d-4a4a-a805-225fd6f54bf8"));
            GridInvoiceList = (ITTGrid)AddControl(new Guid("32fbf319-5873-41d0-9738-7180e28a0a97"));
            PATIENTNO = (ITTTextBoxColumn)AddControl(new Guid("b439a64e-dfa6-4e14-a54a-dd3b201c2670"));
            PATIENTNAME = (ITTTextBoxColumn)AddControl(new Guid("f9e9d0f5-af2a-456c-ba0d-07f00482083f"));
            INVOICEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("ec525c4c-5c82-46ff-9cec-57413dba665a"));
            INVOICEDOCUMENTNO = (ITTTextBoxColumn)AddControl(new Guid("1c8d11bb-d8ea-4322-8529-82b6b0b3d858"));
            INVOICETOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("80cfa702-0e00-4250-92c5-4973e72c7695"));
            INVOICECUTOFFPRICE = (ITTTextBoxColumn)AddControl(new Guid("8fb5d260-3b92-4f56-98ca-239a1c1ac2b6"));
            PAID = (ITTCheckBoxColumn)AddControl(new Guid("b294e88d-fe17-45dd-a2e8-4fe468a41242"));
            CancelledInvoicesTab = (ITTTabPage)AddControl(new Guid("8cf91b40-3b52-45ca-840f-030b6f0bc3df"));
            CancelledInvoicesGrid = (ITTGrid)AddControl(new Guid("40e5835a-958a-4246-bc25-cc2361daaebe"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("28a1a511-ab3d-4ea8-b2a3-de3a8d9a6c59"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("f35e3562-4b97-4fe6-b32c-d178ee2755de"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("44158993-9a55-452e-8cfc-7eb1126ac9ea"));
            tttextboxcolumn3 = (ITTTextBoxColumn)AddControl(new Guid("62671504-f8f6-4f28-ab85-5254df1576bd"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("5597079c-a5fa-4078-b064-699394c34171"));
            CANCELREASON = (ITTTextBoxColumn)AddControl(new Guid("9f2e3979-b332-42c3-b315-1383b8f04818"));
            TotalPrice = (ITTTextBox)AddControl(new Guid("2344c074-2892-4a64-94e5-243823d42781"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("d2a3a185-f0ec-4f50-8f4e-28ae801e3324"));
            InvoiceDocumentNoStart = (ITTTextBox)AddControl(new Guid("e2d1ecf2-969a-4075-947b-46772987330f"));
            InvoiceDocumentNoEnd = (ITTTextBox)AddControl(new Guid("223ad68c-0962-45db-acd4-590812934d8d"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("489556a0-ec65-42ec-a866-5a6ae1ba7c5e"));
            CUTOFFPRICE = (ITTTextBox)AddControl(new Guid("1192fdde-fb58-458f-9b2c-633afc70d9f5"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("a8f13116-3f48-4f7b-a949-a90466d8bade"));
            PAYMENTPRICE = (ITTTextBox)AddControl(new Guid("b3e55407-fd8e-44cc-a48d-b4386899523f"));
            FillPayerButton = (ITTButton)AddControl(new Guid("28120efe-6c1f-4777-a4c2-3fb9909adaa1"));
            CheckAll = (ITTButton)AddControl(new Guid("bbc8abca-26c8-4223-a958-d8baad8493e1"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("387c1ac6-bc87-423d-af57-042b5f24b17d"));
            labelTotalPrice = (ITTLabel)AddControl(new Guid("b22200cb-b12b-4824-8f81-080386d8a26a"));
            PAYER = (ITTObjectListBox)AddControl(new Guid("0a63c425-6921-4f12-9573-099146580244"));
            InvoiceDateEnd = (ITTDateTimePicker)AddControl(new Guid("775c7f51-4b8e-451a-bb98-1dd7aa385b73"));
            labelInvoiceDocumentNoStart = (ITTLabel)AddControl(new Guid("f7a022fd-e52e-4778-a82d-3f6232f53587"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("9344bf39-37ab-4757-8133-44dd5d435912"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e2660ca5-d1a5-410d-a77a-5875fc2f0f97"));
            labelInvoiceDateEnd = (ITTLabel)AddControl(new Guid("5b68d9fc-fce8-401f-82d4-7e389ff5c5f4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6d1c6c10-4841-44e5-8cd3-8354004c78ae"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b1b0af3d-eb1a-4567-862d-8a62993fcb8e"));
            labelInvoiceDateStart = (ITTLabel)AddControl(new Guid("790f3c53-cc7a-4507-872f-8f4698683ccf"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("a553f703-11d6-465f-a9a2-9be517fce9fc"));
            ListButon = (ITTButton)AddControl(new Guid("f8491bcb-edb9-4938-b2d2-9d3069053b41"));
            InvoiceDateStart = (ITTDateTimePicker)AddControl(new Guid("374dd747-2a7c-4302-983c-dd57770e7b90"));
            labelInvoiceDocumentNoEnd = (ITTLabel)AddControl(new Guid("26de6847-0211-464a-8543-ed51aafe7147"));
            TabPaymentInfo = (ITTTabControl)AddControl(new Guid("bb14c40c-71ba-4bc2-8de6-ee794841057e"));
            TabCash = (ITTTabPage)AddControl(new Guid("a8b9e184-edd0-446b-b319-8dff28e14470"));
            GridCashPayment = (ITTGrid)AddControl(new Guid("f82ecb8b-59ec-473a-9eb6-4cb19428b7c0"));
            PRICE = (ITTTextBoxColumn)AddControl(new Guid("7247c5f1-70c4-4bef-94e3-8697d871635d"));
            CURRENCYTYPE = (ITTListBoxColumn)AddControl(new Guid("a96a55f7-933e-4e89-81fa-328841f02cf0"));
            TabBankDecount = (ITTTabPage)AddControl(new Guid("e96cb523-92f8-46f6-b1f2-d81e963bca19"));
            GridBankDecountPayment = (ITTGrid)AddControl(new Guid("0368aa9b-3160-4af5-a8c4-5b0dc2b043ef"));
            BANKACCOUNT = (ITTListBoxColumn)AddControl(new Guid("55efe0fd-6731-40a7-b25e-16f7ab81582f"));
            DECOUNTNO = (ITTTextBoxColumn)AddControl(new Guid("f94a8919-4209-4f7c-b2f9-3e8cc57feb54"));
            tttextboxcolumn5 = (ITTTextBoxColumn)AddControl(new Guid("2e4e5f60-0a2a-493d-9cca-5383ac5613c5"));
            TabCheque = (ITTTabPage)AddControl(new Guid("fe06e91b-bdf4-4266-a589-2d56a407ed83"));
            GridChequePayment = (ITTGrid)AddControl(new Guid("36e5ca5f-5b86-41ad-ba98-7db9e1185f18"));
            NO = (ITTTextBoxColumn)AddControl(new Guid("bf4e4894-ed4e-46be-9cc6-c2010f0b9bd1"));
            tttextboxcolumn6 = (ITTTextBoxColumn)AddControl(new Guid("5f489fa9-64b0-4a11-b893-a46fdebdee0b"));
            BANKNAME = (ITTListBoxColumn)AddControl(new Guid("d6576a8d-825a-43d7-96c6-ada682c80f19"));
            TabAdvance = (ITTTabPage)AddControl(new Guid("086ebdb1-346f-4c56-a56b-229de9cbe270"));
            USEADVANCE = (ITTCheckBox)AddControl(new Guid("02e42b18-d396-49d3-bea9-99ecc6693678"));
            GridAdvancePayment = (ITTGrid)AddControl(new Guid("b16429a8-9a57-48ee-925d-506f7bf41bd8"));
            ADVANCEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("c84e94c3-1226-4a15-8e12-996f5994617d"));
            ADVANCEDECOUNTNO = (ITTTextBoxColumn)AddControl(new Guid("18cb48bc-13b6-4c7c-8801-6da9ee61bbd1"));
            TOTALADVANCEPRICE = (ITTTextBoxColumn)AddControl(new Guid("32192bbc-fb7c-4cde-ab19-f376bf8f53e8"));
            REMAININGPRICE = (ITTTextBoxColumn)AddControl(new Guid("0be0f07d-b32c-4313-a199-9affe66ce7e5"));
            USEDPRICE = (ITTTextBoxColumn)AddControl(new Guid("7e4709d7-e8e1-4dbd-8108-15d56c26cdd0"));
            USED = (ITTCheckBoxColumn)AddControl(new Guid("c3b4dbfa-745a-453f-9a99-d9e5f96008c5"));
            TOTALPAYMENT = (ITTTextBox)AddControl(new Guid("2629e36f-8d33-43eb-a9bc-d5846716573f"));
            RemainderCheckbox = (ITTTextBox)AddControl(new Guid("50823a82-8d66-478e-b0f1-15ec2f8ac695"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("2f133f13-5799-4a04-9b89-a8a02dee804a"));
            UncheckAll = (ITTButton)AddControl(new Guid("38697929-25f1-47a4-ac63-f9f85d0e8baa"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("ba084d4d-e4a8-4317-9fb1-9ebfb02c5ecd"));
            base.InitializeControls();
        }

        public InvoicePaymentForm() : base("INVOICEPAYMENT", "InvoicePaymentForm")
        {
        }

        protected InvoicePaymentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}