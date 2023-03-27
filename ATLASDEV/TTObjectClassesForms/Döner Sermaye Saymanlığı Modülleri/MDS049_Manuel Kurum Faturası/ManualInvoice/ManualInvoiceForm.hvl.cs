
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
    /// Manuel Kurum Faturası
    /// </summary>
    public partial class ManualInvoiceForm : TTForm
    {
    /// <summary>
    /// Manuel Kurum Faturası
    /// </summary>
        protected TTObjectClasses.ManualInvoice _ManualInvoice
        {
            get { return (TTObjectClasses.ManualInvoice)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage TabProcedure;
        protected ITTGrid GRIDInvoiceProcedures;
        protected ITTDateTimePickerColumn PACTIONDATE;
        protected ITTTextBoxColumn PPROCEDURE;
        protected ITTTextBoxColumn PAMOUNT;
        protected ITTTextBoxColumn PUNITPRICE;
        protected ITTTextBoxColumn PTOTALPRICE;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox DOCUMENTNO;
        protected ITTTextBox SENDINGNO;
        protected ITTTextBox PATIENTNAME;
        protected ITTTextBox DESCRIPTION;
        protected ITTTextBox ACCOUNTANTNAME;
        protected ITTTextBox ACCOUNTANTTITLE;
        protected ITTTextBox TOTALPRICE;
        protected ITTTextBox KDVRATE;
        protected ITTTextBox TOTALPRICEWITHOUTKDV;
        protected ITTObjectListBox PAYERNAME;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker SENDINGDATE;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel15;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("8578c446-ffb3-4af0-816a-dc042296da27"));
            TabProcedure = (ITTTabPage)AddControl(new Guid("f10c8a1e-de5e-417b-8c05-839c94964ea0"));
            GRIDInvoiceProcedures = (ITTGrid)AddControl(new Guid("de5dcc05-ce57-4f11-9a44-dc344639c23d"));
            PACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("d7d67c8a-bb1a-4d72-9329-789b52f276da"));
            PPROCEDURE = (ITTTextBoxColumn)AddControl(new Guid("2cc2c5d8-0ac4-4128-b37c-405cb59628e2"));
            PAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("a368708a-e5a8-4c8f-b2ef-01366b03b22e"));
            PUNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("0915c368-16c4-4341-af6d-208c3bd123e4"));
            PTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("37869d3c-0756-4f33-8b6e-3fafe93ab6d0"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("846ad25d-844e-4dbf-ad25-f7251d163a98"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("51f5a0ea-3b62-4b0a-8499-b806b02cd82d"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("f412d72a-db88-4138-9b2c-012dcfdfc705"));
            DOCUMENTNO = (ITTTextBox)AddControl(new Guid("dde070c0-44a3-4f62-987f-0c633b02e793"));
            SENDINGNO = (ITTTextBox)AddControl(new Guid("78df98fd-9abf-4519-9920-4a396dfc69f0"));
            PATIENTNAME = (ITTTextBox)AddControl(new Guid("103928a0-8801-4223-9aaa-7f46f480de1f"));
            DESCRIPTION = (ITTTextBox)AddControl(new Guid("c30e80e1-fb15-42cd-af55-d7b5df1c3261"));
            ACCOUNTANTNAME = (ITTTextBox)AddControl(new Guid("af2b8f3c-a58d-44ee-b527-e295c821fcc6"));
            ACCOUNTANTTITLE = (ITTTextBox)AddControl(new Guid("12dbc505-0da9-41a8-8915-b9fbedad9650"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("d9758894-868b-4bc7-abdb-d48afe482a18"));
            KDVRATE = (ITTTextBox)AddControl(new Guid("fe2969e8-b4b0-4d0e-b4ab-d3d56afd28b4"));
            TOTALPRICEWITHOUTKDV = (ITTTextBox)AddControl(new Guid("524ed012-ad91-4062-9480-306d1639a1fb"));
            PAYERNAME = (ITTObjectListBox)AddControl(new Guid("57c755da-5f12-42ff-8cf7-9e1bd5a32f66"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("39912a03-7681-46c9-b33a-2664e44ff50a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f9708114-11a2-456c-89e3-1294008d4d71"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7f274e42-1fd5-4e85-a924-621925cff739"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("fa3ad94f-5389-4674-ab93-76f89c2bbaf6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3da9d0d4-5e75-400b-b0de-e4af58336672"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("2d49711c-f67b-42ba-9289-36f3862b53db"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("c585fb7e-6895-4f49-900e-8cd56b653af0"));
            SENDINGDATE = (ITTDateTimePicker)AddControl(new Guid("394e4289-04d3-463f-b6c3-0e2816c1fde8"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("b0b7f3ab-de09-4530-a21e-48bec32df351"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("05e45872-ae8b-43ff-a54e-54ec33386642"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("9c305a35-e2a9-481d-be58-7179596ce52c"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("c0d291ef-b240-4ed6-8898-5b46b765a777"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("11750415-6312-4f06-943e-074287179608"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("5cb888ea-86bd-40c5-aa39-12f972246852"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("42e4e6e8-61b8-48a8-8180-039a0f927337"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("1cc4ad33-72e6-46ae-8be0-6b6f9965637b"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("d4fda15d-9109-4da2-ad51-52d8361cd451"));
            base.InitializeControls();
        }

        public ManualInvoiceForm() : base("MANUALINVOICE", "ManualInvoiceForm")
        {
        }

        protected ManualInvoiceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}