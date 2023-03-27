
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
    /// Hizmet Karşılığı Kurum Faturası
    /// </summary>
    public partial class GeneralInvoiceForm : TTForm
    {
    /// <summary>
    /// Hizmet Karşılığı Kurum Faturası
    /// </summary>
        protected TTObjectClasses.GeneralInvoice _GeneralInvoice
        {
            get { return (TTObjectClasses.GeneralInvoice)_ttObject; }
        }

        protected ITTLabel labelCommunityHealthPayer;
        protected ITTLabel ttlabel11;
        protected ITTTextBox DOCUMENTNO;
        protected ITTTextBox TAXOFFICE;
        protected ITTTextBox TAXNUMBER;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox PAYERADDRESS;
        protected ITTTextBox Description;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox CASHIERNAME;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox Payer;
        protected ITTLabel labelCashOfficeName;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel1;
        protected ITTTabControl TabProcedureMaterialPackage;
        protected ITTTabPage TabProcedure;
        protected ITTGrid GRIDInvoiceProcedures;
        protected ITTDateTimePickerColumn PACTIONDATE;
        protected ITTListBoxColumn PPROCEDURE;
        protected ITTTextBoxColumn PAMOUNT;
        protected ITTTextBoxColumn PUNITPRICE;
        protected ITTTextBoxColumn PTOTALPRICE;
        protected ITTTextBox TOTALPRICE;
        protected ITTLabel ttlabel14;
        protected ITTObjectListBox CommunityHealthPayer;
        override protected void InitializeControls()
        {
            labelCommunityHealthPayer = (ITTLabel)AddControl(new Guid("7fd4a0b8-7630-4978-b077-59c78a3bbb9d"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("44566aa3-cb26-4a09-92ad-e32c8b7f3ba7"));
            DOCUMENTNO = (ITTTextBox)AddControl(new Guid("7db3e186-08a8-4d24-a2da-85a57c6f3301"));
            TAXOFFICE = (ITTTextBox)AddControl(new Guid("f72f90ab-3ba7-4513-96fc-6145cdd8d19a"));
            TAXNUMBER = (ITTTextBox)AddControl(new Guid("da259f5d-3b82-442a-aad3-11ad96223eeb"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("98c496d1-8ced-4da1-a684-b45dc77ef565"));
            PAYERADDRESS = (ITTTextBox)AddControl(new Guid("e738c3fd-851c-4b86-961c-960e01f06f82"));
            Description = (ITTTextBox)AddControl(new Guid("d8d3f506-0659-41ae-88f2-ff7ad73130ec"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("bae362e8-38ed-45b0-aed8-a26fe0121110"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("aacedfdf-870d-41c7-a7a5-17c86db1658a"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("65030356-e304-49d2-84a5-847601a1261d"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("551a082f-7a85-414f-82bc-66834d042361"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("92428364-fe25-4866-a747-dd8414ed43bb"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("eb935f8e-5a11-4a01-afdf-6c55f1fc3f59"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9726b86c-be6f-46f9-b142-f794e4522da5"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("4540585f-f826-4484-a485-495c092e764a"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("29c31ee5-92fa-4834-aadf-d191dba93767"));
            Payer = (ITTObjectListBox)AddControl(new Guid("950ac142-b656-438e-99ca-8b8d1718a3f9"));
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("ebf087a5-4308-4188-a34b-168575062cda"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("f2cade77-72c6-4755-8f40-a299b80936af"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("14ea0b86-68a3-406f-b8a2-ca4778c6a0eb"));
            TabProcedureMaterialPackage = (ITTTabControl)AddControl(new Guid("3362d90c-4dbc-4b0f-9d31-1834006d4e8b"));
            TabProcedure = (ITTTabPage)AddControl(new Guid("37605219-aa0f-4c25-a2fb-f847f707761e"));
            GRIDInvoiceProcedures = (ITTGrid)AddControl(new Guid("2b830fd4-e0f9-4388-b891-0ffe2c101968"));
            PACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("dcd1b79c-f9bc-40fb-8b2b-2257a59af9c2"));
            PPROCEDURE = (ITTListBoxColumn)AddControl(new Guid("49e714bd-85bd-4096-a3ba-415914e735bf"));
            PAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("89a02998-0e31-480c-80fc-e2072e30c6fc"));
            PUNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("af72dd95-dd72-4574-a973-4dd46035adf8"));
            PTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("ed16441e-7ba1-4f27-9734-69995f9aee7a"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("e702397a-a73d-42c8-b62e-a3abb9cdfc6a"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("b4837672-c5b2-45a1-aaae-e58464b14586"));
            CommunityHealthPayer = (ITTObjectListBox)AddControl(new Guid("838c95c6-a8b2-472f-a62f-b927358debb6"));
            base.InitializeControls();
        }

        public GeneralInvoiceForm() : base("GENERALINVOICE", "GeneralInvoiceForm")
        {
        }

        protected GeneralInvoiceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}