
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
    public partial class InvoiceCollectionSearchForm : TTUnboundForm
    {
        protected ITTGrid InvoiceCollectionDetailGrid;
        protected ITTTextBoxColumn datagridviewcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn tttextboxcolumn3;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTTextBoxColumn tttextboxcolumn5;
        protected ITTGrid InvoiceCollectionGrid;
        protected ITTTextBoxColumn gcName;
        protected ITTTextBoxColumn gcDate;
        protected ITTTextBoxColumn gcState;
        protected ITTTextBoxColumn gcTotalPrice;
        protected ITTTextBoxColumn gcPayer;
        protected ITTTextBoxColumn ObjectID;
        protected ITTPanel Info;
        protected ITTButton ttbutton3;
        protected ITTButton ttbutton2;
        protected ITTTextBox tbMaterialTotalPrice;
        protected ITTLabel ttlabel11;
        protected ITTTextBox tbMedicineTotalPrice;
        protected ITTLabel ttlabel5;
        protected ITTTextBox tbProcedureTotalPrice;
        protected ITTLabel ttlabel10;
        protected ITTPanel Search;
        protected ITTListDefComboBox cbTedaviTuru;
        protected ITTDateTimePicker dtpInvoiceCollectionLastDate;
        protected ITTDateTimePicker dtpInvoiceCollectionFirstDate;
        protected ITTDateTimePicker dtpInvoiceCollectionStateFirstDate;
        protected ITTButton ttbutton1;
        protected ITTListDefComboBox cbInvoiceTerm;
        protected ITTDateTimePicker dtpInvoiceCollectionStateLastDate;
        protected ITTEnumComboBox cbInvoiceCollectionState;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel8;
        protected ITTTextBox tbInvoiceCollectionFirstPrice;
        protected ITTTextBox tbInvoiceCollectionSendNo;
        protected ITTTextBox tbInvoiceCollectionNo;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTTextBox tbInvoiceCollectionLastPrice;
        protected ITTLabel dateLabel;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox lbPayerDefinition;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            InvoiceCollectionDetailGrid = (ITTGrid)AddControl(new Guid("364acfd0-0ff4-4eb1-8ecf-561cd6ee3b00"));
            datagridviewcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("55d10ad5-798b-467d-a49e-a14cc8a93512"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("1af40612-c364-477e-a14c-543c3f41c460"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("4789222f-dbb4-4407-8e68-6c47428cd06d"));
            tttextboxcolumn3 = (ITTTextBoxColumn)AddControl(new Guid("1fd0bcc1-6bf3-4941-9e9c-9df4e653a368"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("448992a1-8242-458e-9070-bf21f331b9e6"));
            tttextboxcolumn5 = (ITTTextBoxColumn)AddControl(new Guid("56654c48-7c98-459d-bf58-46351968aa8b"));
            InvoiceCollectionGrid = (ITTGrid)AddControl(new Guid("58527f6c-39fa-49b3-9ea3-6f3ee6a39990"));
            gcName = (ITTTextBoxColumn)AddControl(new Guid("f1449897-5b94-4c5c-b351-455c45165a0c"));
            gcDate = (ITTTextBoxColumn)AddControl(new Guid("bccff453-6675-4e46-89c4-5fb28c5cdafc"));
            gcState = (ITTTextBoxColumn)AddControl(new Guid("63b4aadf-908e-4bcd-956a-5bda004bb155"));
            gcTotalPrice = (ITTTextBoxColumn)AddControl(new Guid("4fc645dc-3458-4c00-b2ad-8b798db79d79"));
            gcPayer = (ITTTextBoxColumn)AddControl(new Guid("0f0f8416-85de-4978-a56d-5c1a3cf04ebd"));
            ObjectID = (ITTTextBoxColumn)AddControl(new Guid("2df54452-4c5e-442f-b005-db8544709f83"));
            Info = (ITTPanel)AddControl(new Guid("349f3faf-ff1f-49f7-be86-64a9e1926884"));
            ttbutton3 = (ITTButton)AddControl(new Guid("275d3ae8-e6fa-4fb1-a6f0-1582e2726b1e"));
            ttbutton2 = (ITTButton)AddControl(new Guid("9938e513-045f-452b-b17a-46fd7b581032"));
            tbMaterialTotalPrice = (ITTTextBox)AddControl(new Guid("2499c7b5-2fd0-496c-a27a-51744d148fdd"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("fbd32b1b-bbb5-49ff-9c99-f8c20e9c47c6"));
            tbMedicineTotalPrice = (ITTTextBox)AddControl(new Guid("e4503ce9-fbfa-40a6-b24e-9c3b9c7a6006"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("fdbad6e6-21ed-4f29-b825-6692af3a1fdf"));
            tbProcedureTotalPrice = (ITTTextBox)AddControl(new Guid("f4d7764d-9d99-4d5f-8905-bcade92c1c9a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("db69a0f3-c38d-4387-a0df-899a7e94c833"));
            Search = (ITTPanel)AddControl(new Guid("fa261804-2f9b-43b4-9bb5-11149b52930f"));
            cbTedaviTuru = (ITTListDefComboBox)AddControl(new Guid("3cbf439a-9a1e-4573-8d33-684f5cc3ce78"));
            dtpInvoiceCollectionLastDate = (ITTDateTimePicker)AddControl(new Guid("edf19d78-5beb-4125-be1a-efabbdfa787a"));
            dtpInvoiceCollectionFirstDate = (ITTDateTimePicker)AddControl(new Guid("8e9f90a7-684d-4999-8575-680049d13089"));
            dtpInvoiceCollectionStateFirstDate = (ITTDateTimePicker)AddControl(new Guid("a11015e1-ef6d-4177-8758-88a2fd2daf84"));
            ttbutton1 = (ITTButton)AddControl(new Guid("993e652b-7764-4e2f-99cf-19151661b535"));
            cbInvoiceTerm = (ITTListDefComboBox)AddControl(new Guid("5ac18f60-86a8-4e15-8e65-ba5e120fbede"));
            dtpInvoiceCollectionStateLastDate = (ITTDateTimePicker)AddControl(new Guid("27d1e547-1b71-4c15-87c7-25fa5dec55c3"));
            cbInvoiceCollectionState = (ITTEnumComboBox)AddControl(new Guid("4d003309-f23a-402c-a9ef-21cb4fbc10e8"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("d98705a7-db54-4f15-b7c7-a7be751d4e85"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("90d2e9b5-b4a7-46bc-893b-75fb4d13d3e3"));
            tbInvoiceCollectionFirstPrice = (ITTTextBox)AddControl(new Guid("ab520038-aaef-4e24-a508-227b5ddb1690"));
            tbInvoiceCollectionSendNo = (ITTTextBox)AddControl(new Guid("2aa901e0-f2b0-4705-9384-a4e3837f751b"));
            tbInvoiceCollectionNo = (ITTTextBox)AddControl(new Guid("1e66886a-37ed-438a-8a32-bf616afebc23"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("4fad5b8d-e3a9-4003-b647-860316177059"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("4326c6ed-48db-4c14-a84d-13e22bb32eb2"));
            tbInvoiceCollectionLastPrice = (ITTTextBox)AddControl(new Guid("d348c987-62a3-42e9-8658-3379dbf1f836"));
            dateLabel = (ITTLabel)AddControl(new Guid("889c7b33-1efe-442d-94bf-884e7bf30101"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("8371520e-746a-46bf-91cf-ac5e3ab275d4"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("dba583aa-8607-4c31-ab72-b9150c2cdc47"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("69b97f7e-4394-4ad6-8aa8-abe4deed9158"));
            lbPayerDefinition = (ITTObjectListBox)AddControl(new Guid("6cdc1998-43af-42f5-bdcb-ec9ea53d3c99"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3e4a3b33-40dd-46b6-b939-6dc8e0802ffe"));
            base.InitializeControls();
        }

        public InvoiceCollectionSearchForm() : base("InvoiceCollectionSearchForm")
        {
        }

        protected InvoiceCollectionSearchForm(string formDefName) : base(formDefName)
        {
        }
    }
}