
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
    /// Hasta Faturası
    /// </summary>
    public partial class PatientInvoiceForm : TTForm
    {
    /// <summary>
    /// Hasta Faturası İşlemi
    /// </summary>
        protected TTObjectClasses.PatientInvoice _PatientInvoice
        {
            get { return (TTObjectClasses.PatientInvoice)_ttObject; }
        }

        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox PATIENTADDRESS;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox Description;
        protected ITTTextBox TOTALPRICE;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelCashOfficeName;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel14;
        protected ITTTabControl TabProcedureMaterial;
        protected ITTTabPage TabProcedure;
        protected ITTGrid GRIDPatientInvoiceProcedures;
        protected ITTDateTimePickerColumn PACTIONDATE;
        protected ITTTextBoxColumn PEXTERNALCODE;
        protected ITTTextBoxColumn PDESCRIPTION;
        protected ITTTextBoxColumn PAMOUNT;
        protected ITTTextBoxColumn PUNITPRICE;
        protected ITTTextBoxColumn PTOTALPRICE;
        protected ITTCheckBoxColumn PPAID;
        protected ITTTabPage TabMaterial;
        protected ITTGrid GRIDPatientInvoiceMaterials;
        protected ITTDateTimePickerColumn MACTIONDATE;
        protected ITTTextBoxColumn MEXTERNALCODE;
        protected ITTTextBoxColumn MDESCRIPTION;
        protected ITTTextBoxColumn MAMOUNT;
        protected ITTTextBoxColumn MUNITPRICE;
        protected ITTTextBoxColumn MTOTALPRICE;
        protected ITTCheckBoxColumn MPAID;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox DOCUMENTNO;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel13;
        override protected void InitializeControls()
        {
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("fc15a55a-eb0b-4366-99c8-0006f96bf766"));
            PATIENTADDRESS = (ITTTextBox)AddControl(new Guid("bed92d6b-f2bd-42d3-8333-13a7fced627f"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("04cbfc3a-e87a-449c-b9e1-32bfaf153554"));
            Description = (ITTTextBox)AddControl(new Guid("9cb5bc05-f71e-4e66-bea3-4c7feaeb22d0"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("1f8e1058-f125-44c7-881f-56126bafefa0"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d4fc3cbb-06b4-4771-ae7d-0c8faf395bf2"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("f78712be-7d5a-4b44-ba54-19bfda0ccace"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("9d52967f-bf5f-439a-8657-21c6bc1d253d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("ad04ef3f-1b82-48e8-8648-34cb6b784f42"));
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("9de9a946-48a1-4d1e-bb61-3ad8b9ff68cf"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("b88b81ce-66c3-47b8-8b10-41e487f7d639"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("4ff39fd8-5199-4981-83aa-5240358a679f"));
            TabProcedureMaterial = (ITTTabControl)AddControl(new Guid("4257fc57-b8a8-4e17-bbc3-8296e7947a01"));
            TabProcedure = (ITTTabPage)AddControl(new Guid("6988887b-6fe0-4444-9493-67623469db20"));
            GRIDPatientInvoiceProcedures = (ITTGrid)AddControl(new Guid("e51ddac5-dd92-4f5c-99ad-86ee4774aceb"));
            PACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("869280a3-809f-41eb-a73e-29cc7563f166"));
            PEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("03b9c09c-7992-449e-a12c-c6ec7bdfa455"));
            PDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("03410de8-9a58-46a8-8284-e8bd1d8f662c"));
            PAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("cdedf584-b2ad-4806-b18c-c7cccd11e7cc"));
            PUNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("abe48ee2-751d-4033-afff-536cea0bfd91"));
            PTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("8d45ffcc-c4b7-4e56-8d56-0c4e692cf4b5"));
            PPAID = (ITTCheckBoxColumn)AddControl(new Guid("3e785e8d-bc8b-4435-9b91-67247dc77f2f"));
            TabMaterial = (ITTTabPage)AddControl(new Guid("d13834ef-bd9b-400a-bc0b-df855118b160"));
            GRIDPatientInvoiceMaterials = (ITTGrid)AddControl(new Guid("cf4049a9-c4de-471f-84c9-0d9b09e7f867"));
            MACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("a83456b2-309c-4b0d-aa94-4ca7623ec31f"));
            MEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("64fb4280-a974-4eb1-a33b-1d926753f70c"));
            MDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("9e4f2ff3-9653-4771-b60d-d8e95e2cc8a0"));
            MAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("ee484310-c08f-42e5-b687-b59171e6b5bd"));
            MUNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("4b0991e0-55f4-4dd0-b689-a45ed07d0d54"));
            MTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("95931c6d-a89c-4d95-943a-177fdafd7f9b"));
            MPAID = (ITTCheckBoxColumn)AddControl(new Guid("e1ab55c9-a4fe-445f-bb32-c74cd5c05f94"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("e36a183d-0f51-4a90-b89f-8d6c1cdabcb3"));
            DOCUMENTNO = (ITTTextBox)AddControl(new Guid("5d903085-694c-4711-b87a-a57077847c63"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("1ec53594-6f6c-4a66-8f26-8e14f5ea9226"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("5c5c2f61-9566-4499-97ee-8f0491e34ad0"));
            base.InitializeControls();
        }

        public PatientInvoiceForm() : base("PATIENTINVOICE", "PatientInvoiceForm")
        {
        }

        protected PatientInvoiceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}