
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
    /// Fatura Gönderme
    /// </summary>
    public partial class InvoicePostingForm : TTForm
    {
    /// <summary>
    /// Fatura Gönderme İşlemi
    /// </summary>
        protected TTObjectClasses.InvoicePosting _InvoicePosting
        {
            get { return (TTObjectClasses.InvoicePosting)_ttObject; }
        }

        protected ITTButton CheckAll;
        protected ITTTextBox PAYERCODEEND;
        protected ITTTextBox POSTINGNUMBER;
        protected ITTTextBox PAYERCODESTART;
        protected ITTTextBox ID;
        protected ITTTextBox TotalPrice;
        protected ITTTextBox InvoiceDocumentNoEnd;
        protected ITTTextBox InvoiceDocumentNoStart;
        protected ITTGrid GRIDInvoiceLists;
        protected ITTTextBoxColumn PAYERNAME;
        protected ITTTextBoxColumn HOSPITALPROTOCOLNO;
        protected ITTTextBoxColumn PATIENTNO;
        protected ITTTextBoxColumn PATIENTNAME;
        protected ITTTextBoxColumn PATIENTSURNAME;
        protected ITTDateTimePickerColumn INVOICEDATE;
        protected ITTTextBoxColumn INVOICEDOCUMENTNO;
        protected ITTTextBoxColumn INVOICETOTALPRICE;
        protected ITTCheckBoxColumn SEND;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker STARTDATE;
        protected ITTDateTimePicker ENDDATE;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelPostingNumber;
        protected ITTButton ListButton;
        protected ITTLabel labelTotalPrice;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox Active;
        protected ITTLabel labelPatientStatus;
        protected ITTLabel labelEndDate;
        protected ITTEnumComboBox PATIENTSTATUS;
        protected ITTCheckBox CANCELLED;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox PAYER;
        protected ITTEnumComboBox INVOICETYPE;
        protected ITTLabel labelInvoiceType;
        protected ITTLabel labelInvoiceDocumentNoStart;
        protected ITTLabel labelInvoiceDocumentNoEnd;
        protected ITTButton UncheckAll;
        override protected void InitializeControls()
        {
            CheckAll = (ITTButton)AddControl(new Guid("6b8cad55-eef1-49cc-93b4-5af68120ca5e"));
            PAYERCODEEND = (ITTTextBox)AddControl(new Guid("79312909-9fa6-46bb-89b5-0c3e4cce60a1"));
            POSTINGNUMBER = (ITTTextBox)AddControl(new Guid("95c72c2f-767e-441f-ac21-2066b3a51df8"));
            PAYERCODESTART = (ITTTextBox)AddControl(new Guid("f99a749d-4ffe-42a8-90dc-464271720643"));
            ID = (ITTTextBox)AddControl(new Guid("462b89c0-4b25-4386-b5af-8cfb6c964e39"));
            TotalPrice = (ITTTextBox)AddControl(new Guid("fbd45723-e847-4e69-99d9-db7da86a17af"));
            InvoiceDocumentNoEnd = (ITTTextBox)AddControl(new Guid("a73ec2b9-7b2b-4e83-aa3e-83d8345d353c"));
            InvoiceDocumentNoStart = (ITTTextBox)AddControl(new Guid("77b2b7a9-9421-4aff-a6cc-a61251cb5c25"));
            GRIDInvoiceLists = (ITTGrid)AddControl(new Guid("ab12f88d-a456-4fca-aa72-160253bff386"));
            PAYERNAME = (ITTTextBoxColumn)AddControl(new Guid("1c20a208-c15c-456c-91a7-2498a816172b"));
            HOSPITALPROTOCOLNO = (ITTTextBoxColumn)AddControl(new Guid("23dabd04-bd72-4f38-bbcf-4fe2e2c3a8a5"));
            PATIENTNO = (ITTTextBoxColumn)AddControl(new Guid("8fd7ffb0-2c49-4a82-abf7-bd9e71cd0921"));
            PATIENTNAME = (ITTTextBoxColumn)AddControl(new Guid("45cf29fd-5e04-4804-b74c-ea46c864c50f"));
            PATIENTSURNAME = (ITTTextBoxColumn)AddControl(new Guid("61a10292-408e-4b0d-b9ae-bb16b47acfaa"));
            INVOICEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("b731c84a-5598-43cd-90c3-a41184bbb1f6"));
            INVOICEDOCUMENTNO = (ITTTextBoxColumn)AddControl(new Guid("8a466e7e-da58-42e7-b0d8-05f0c0ed4ad2"));
            INVOICETOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("30914b09-98bf-4420-a29a-2284f923dbcb"));
            SEND = (ITTCheckBoxColumn)AddControl(new Guid("e6db889f-95af-41b5-ab50-343862ff92b2"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("420ccbd7-96e0-4891-98de-29b448296003"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5d8d1782-f64e-4ecd-9112-43892571d284"));
            STARTDATE = (ITTDateTimePicker)AddControl(new Guid("add9ec8d-4b1e-4fc0-9c08-43a5d6affbab"));
            ENDDATE = (ITTDateTimePicker)AddControl(new Guid("bac22ecb-6d5d-471a-9cc2-5d1308be1bf6"));
            labelStartDate = (ITTLabel)AddControl(new Guid("fa6835c8-d954-4969-bf60-5d98a541ce78"));
            labelPostingNumber = (ITTLabel)AddControl(new Guid("c6fba188-9237-4467-8cf1-63e76fb5db26"));
            ListButton = (ITTButton)AddControl(new Guid("f2330197-c9a3-4cc9-845f-652dc94a78ec"));
            labelTotalPrice = (ITTLabel)AddControl(new Guid("3adc4140-3571-4d19-a694-6d3ef79889f6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5165838b-2f4e-465a-8951-7399d4076779"));
            Active = (ITTCheckBox)AddControl(new Guid("9ccf2116-cb4d-4d35-8200-9a9ef1003782"));
            labelPatientStatus = (ITTLabel)AddControl(new Guid("da7ab241-4617-481b-805b-accc738cb008"));
            labelEndDate = (ITTLabel)AddControl(new Guid("92a40123-1398-498b-8c7f-bf23caf4b550"));
            PATIENTSTATUS = (ITTEnumComboBox)AddControl(new Guid("c3234612-fd57-45bb-a1f3-c3f8d5bf8e50"));
            CANCELLED = (ITTCheckBox)AddControl(new Guid("b96ec5aa-a1b9-4cac-b376-c4d7ddfcf2b4"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("adb4999a-6c83-4095-ba06-e3cf21724558"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("35cfe9a9-892b-4b70-b26a-e4342f8d5e2c"));
            PAYER = (ITTObjectListBox)AddControl(new Guid("3fa8f875-acb3-4793-acac-e5f586af73fe"));
            INVOICETYPE = (ITTEnumComboBox)AddControl(new Guid("2bb8ac26-e686-46f8-86f8-8186362c0af3"));
            labelInvoiceType = (ITTLabel)AddControl(new Guid("c4700f20-5c08-4079-804f-dce04fce9b08"));
            labelInvoiceDocumentNoStart = (ITTLabel)AddControl(new Guid("d5dbb030-1a3b-4c3a-a3f4-6cc822e54cad"));
            labelInvoiceDocumentNoEnd = (ITTLabel)AddControl(new Guid("8fa316b2-43c8-462c-b25e-928f5ed03e24"));
            UncheckAll = (ITTButton)AddControl(new Guid("be4eb75e-0a68-4be7-b147-a3b9af089ad8"));
            base.InitializeControls();
        }

        public InvoicePostingForm() : base("INVOICEPOSTING", "InvoicePostingForm")
        {
        }

        protected InvoicePostingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}