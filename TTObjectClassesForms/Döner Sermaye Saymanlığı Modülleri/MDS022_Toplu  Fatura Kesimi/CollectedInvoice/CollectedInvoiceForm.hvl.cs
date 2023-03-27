
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
    /// Toplu Fatura
    /// </summary>
    public partial class CollectedInvoiceForm : TTForm
    {
    /// <summary>
    /// Toplu Fatura İşlemi
    /// </summary>
        protected TTObjectClasses.CollectedInvoice _CollectedInvoice
        {
            get { return (TTObjectClasses.CollectedInvoice)_ttObject; }
        }

        protected ITTCheckBox LISTTYPE;
        protected ITTGrid GRIDResourceList;
        protected ITTListBoxColumn RESOURCENAME;
        protected ITTLabel ttlabel8;
        protected ITTGrid GRIDPayerList;
        protected ITTListBoxColumn PAYERNAME;
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox PatientStatusEnum;
        protected ITTDateTimePicker ENDDATE;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel ttlabel5;
        protected ITTButton LISTBUTTON;
        protected ITTTextBox TotalPrice;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox DOCUMENTNO;
        protected ITTTextBox CASHIERLOGID;
        protected ITTLabel ttlabel6;
        protected ITTGrid GRIDPATIENTLIST;
        protected ITTDateTimePickerColumn OPENINGDATE;
        protected ITTTextBoxColumn PPAYERNAME;
        protected ITTTextBoxColumn TCKIMLIKNO;
        protected ITTTextBoxColumn HOSPITALPROTOCOLNO;
        protected ITTTextBoxColumn PATIENTNAME;
        protected ITTTextBoxColumn PATIENTSURNAME;
        protected ITTTextBoxColumn PTOTALPRICE;
        protected ITTCheckBoxColumn PINVOICED;
        protected ITTLabel ttlabel7;
        protected ITTDateTimePicker STARTDATE;
        protected ITTEnumComboBox PROCEDUREGROUP;
        protected ITTLabel ttlabel11;
        protected ITTLabel labelInvoiceDateEnd;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelTotalPrice;
        protected ITTLabel labelInvoiceDocumentNo;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelInvoiceDateStart;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox PAYER;
        protected ITTLabel ttlabel9;
        protected ITTButton ONDOKUM;
        protected ITTButton UnSelectAllButton;
        protected ITTButton SelectAllButton;
        protected ITTButton GETREADY;
        protected ITTButton UnSelectResSectionsButton;
        protected ITTCheckBox TOOTHINVOICE;
        override protected void InitializeControls()
        {
            LISTTYPE = (ITTCheckBox)AddControl(new Guid("298b4221-bda5-4aec-b927-218529f5c0da"));
            GRIDResourceList = (ITTGrid)AddControl(new Guid("714f265d-b81e-44e8-ae0f-295bae0b8a62"));
            RESOURCENAME = (ITTListBoxColumn)AddControl(new Guid("4f8c2077-08ad-42e9-8961-e713a6a52e22"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("971c287a-dc9e-4cdd-a483-b44ab5c5236b"));
            GRIDPayerList = (ITTGrid)AddControl(new Guid("b05b8db6-94ae-47cc-8120-ea11bef073ff"));
            PAYERNAME = (ITTListBoxColumn)AddControl(new Guid("dac1d8bd-8209-4748-8c1e-bb1887d89c7d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("fc787c59-159b-4cf2-ac9e-3becb80cd285"));
            PatientStatusEnum = (ITTEnumComboBox)AddControl(new Guid("978e59b2-f8d7-4479-adc3-ddec9043e468"));
            ENDDATE = (ITTDateTimePicker)AddControl(new Guid("b6974cfe-40ea-49b5-9409-00bc15e259e7"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("de75c3a6-9729-49fb-99b5-21d2957ea931"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("18964858-906e-4412-9775-321e8f31b6f0"));
            LISTBUTTON = (ITTButton)AddControl(new Guid("34da6cde-97dc-4d7d-9b69-38bafdbfe638"));
            TotalPrice = (ITTTextBox)AddControl(new Guid("28821b44-b156-4712-baa8-3f9ecd270e75"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("6c24d6b7-2d46-4730-8c77-79c90f259562"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("14f582c2-f8ba-4ea8-9250-7daafeca41ce"));
            DOCUMENTNO = (ITTTextBox)AddControl(new Guid("9ea09078-5860-4eab-b4ec-cbb661f29a8b"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("5d74e803-6662-40e2-8bec-f56c603ef1b7"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d596d997-9674-45be-a85d-463160693c1a"));
            GRIDPATIENTLIST = (ITTGrid)AddControl(new Guid("f5fc8fb7-a7b4-40e0-9ed7-5c421d7112c3"));
            OPENINGDATE = (ITTDateTimePickerColumn)AddControl(new Guid("382414f6-56db-4749-bcbf-954e975c96b8"));
            PPAYERNAME = (ITTTextBoxColumn)AddControl(new Guid("598f70c5-e16f-4de1-bdcf-e071cca04558"));
            TCKIMLIKNO = (ITTTextBoxColumn)AddControl(new Guid("bad5b36d-53fb-43bc-ad11-489362d887e7"));
            HOSPITALPROTOCOLNO = (ITTTextBoxColumn)AddControl(new Guid("86f76354-4492-439a-9599-1531fffdb80b"));
            PATIENTNAME = (ITTTextBoxColumn)AddControl(new Guid("6d332f6b-57ec-4b48-bfbe-2806bd50d006"));
            PATIENTSURNAME = (ITTTextBoxColumn)AddControl(new Guid("e9ac25d6-122c-46ac-8cfc-54747d1dc97d"));
            PTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("3aee9a3f-8671-49a7-b34e-09cf76405500"));
            PINVOICED = (ITTCheckBoxColumn)AddControl(new Guid("f5091489-67cc-4ecd-a56c-be285f68f94a"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("7392ab95-a3ae-41e7-83a7-5dda9bef7acc"));
            STARTDATE = (ITTDateTimePicker)AddControl(new Guid("38419d83-daab-4297-8977-8f544499c65b"));
            PROCEDUREGROUP = (ITTEnumComboBox)AddControl(new Guid("389787a7-d928-46be-b3cc-9114d5e1a503"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("2da86e93-35f3-405a-98bd-922919cad5f4"));
            labelInvoiceDateEnd = (ITTLabel)AddControl(new Guid("f1de7363-8d63-49ce-b070-946a6d6d3e85"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("217b6257-fdfe-4bec-a845-95e93a3133b8"));
            labelTotalPrice = (ITTLabel)AddControl(new Guid("b815b98d-1d5d-47db-9ec7-9ee4f92d233f"));
            labelInvoiceDocumentNo = (ITTLabel)AddControl(new Guid("d542fd5d-6c18-479c-82a0-b338d3d16d38"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a29ccc03-09e9-49e7-9693-b50305ea4b14"));
            labelInvoiceDateStart = (ITTLabel)AddControl(new Guid("ed70bfad-5c2f-437e-b777-c9dc61552bd5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f4e1fc51-e4c2-411f-8c54-ea0123d64256"));
            PAYER = (ITTObjectListBox)AddControl(new Guid("c52edb52-a95d-4037-a881-02851e436405"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("a1c770ea-63c7-4c66-b705-5cabf13a2db1"));
            ONDOKUM = (ITTButton)AddControl(new Guid("ccfa10c6-8394-4eeb-baa4-addf1ca5ae06"));
            UnSelectAllButton = (ITTButton)AddControl(new Guid("58994378-5536-43a7-9b3d-adab13d03803"));
            SelectAllButton = (ITTButton)AddControl(new Guid("a7d24113-a5cf-49c2-909a-c7f0d3a5a00b"));
            GETREADY = (ITTButton)AddControl(new Guid("725c34c2-eca1-4626-9524-678fdccce3f0"));
            UnSelectResSectionsButton = (ITTButton)AddControl(new Guid("75a07d3a-196d-44f7-953b-77f030c4359c"));
            TOOTHINVOICE = (ITTCheckBox)AddControl(new Guid("73e02bbd-a818-46cd-8c5f-038b64bd35e6"));
            base.InitializeControls();
        }

        public CollectedInvoiceForm() : base("COLLECTEDINVOICE", "CollectedInvoiceForm")
        {
        }

        protected CollectedInvoiceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}