
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
    /// Laboratuvar Sonuç Formu
    /// </summary>
    public partial class LaboratoryRequestResultForm : EpisodeActionForm
    {
    /// <summary>
    /// Laboratuvar
    /// </summary>
        protected TTObjectClasses.LaboratoryRequest _LaboratoryRequest
        {
            get { return (TTObjectClasses.LaboratoryRequest)_ttObject; }
        }

        protected ITTButton ttPrintResultReport;
        protected ITTTabControl tabResults;
        protected ITTTabControl TabControlLabProcedures;
        protected ITTTabPage TabPageLabProcedures;
        protected ITTGrid GridLabProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn LabProcedure;
        protected ITTTextBoxColumn Result;
        protected ITTEnumComboBoxColumn Warning;
        protected ITTTextBoxColumn Reference;
        protected ITTRichTextBoxControlColumn SpecialReference;
        protected ITTTextBoxColumn Unit;
        protected ITTButtonColumn Detail;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn ResultNote;
        protected ITTRichTextBoxControlColumn LongReport;
        protected ITTTabControl TabForInformations;
        protected ITTTabPage tttabpage1;
        protected ITTEnumComboBox PatientGroup;
        protected ITTEnumComboBox PatientSex;
        protected ITTTextBox PatientAge;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTTextBox ReasonForAdmisson;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelPreInformation;
        protected ITTCheckBox Urgent;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTTabPage tttabpage2;
        protected ITTObjectListBox lstApprovedBy;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox requestDoctor;
        protected ITTLabel ttlabel9;
        protected ITTTabPage tttabpage3;
        protected ITTEnumComboBox Gebelik;
        protected ITTDateTimePicker SonAdetTarihi;
        protected ITTLabel labelSonAdetTarihi;
        protected ITTLabel labelGebelik;
        protected ITTTabPage TabPageFutureRequest;
        protected ITTDateTimePicker WorkListDate;
        protected ITTLabel labelProcessTime;
        protected ITTTextBox textBarcode;
        protected ITTLabel ttlabel3drawgradient;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTLabel labelBarcode;
        override protected void InitializeControls()
        {
            ttPrintResultReport = (ITTButton)AddControl(new Guid("1d91a78f-4098-4d6e-b4ec-26ac1fd7861d"));
            tabResults = (ITTTabControl)AddControl(new Guid("c40bb1bf-16a6-432b-8205-8e381cf1fb3b"));
            TabControlLabProcedures = (ITTTabControl)AddControl(new Guid("e6a9c4fa-d8fc-475a-80e3-5dde126d0bd7"));
            TabPageLabProcedures = (ITTTabPage)AddControl(new Guid("fa23d81f-bd10-4eee-a4c6-f61c319157a0"));
            GridLabProcedures = (ITTGrid)AddControl(new Guid("b42cf44a-4942-4fc0-a44a-7f2316451e9a"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("66ee519f-ac01-4d97-a178-7a212b3af707"));
            LabProcedure = (ITTTextBoxColumn)AddControl(new Guid("666490e9-5ab4-439e-9cd6-f620b2dc5666"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("5b5a9456-d8f4-4e95-bd55-5d5cfebf0488"));
            Warning = (ITTEnumComboBoxColumn)AddControl(new Guid("c79d8aff-600d-48a6-b0a7-46ffe25b065c"));
            Reference = (ITTTextBoxColumn)AddControl(new Guid("c96417a5-2c5e-40f7-9cf6-2cc2c249d5a1"));
            SpecialReference = (ITTRichTextBoxControlColumn)AddControl(new Guid("c8d06945-b86e-4903-ba5c-ade0b2717dd7"));
            Unit = (ITTTextBoxColumn)AddControl(new Guid("9178a29d-52f5-49eb-a8b2-d483a0e665d2"));
            Detail = (ITTButtonColumn)AddControl(new Guid("95d97ab3-dc3c-49e0-90df-b6a583798b74"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("611d0e78-77f6-4251-a5bd-23488e5150c1"));
            ResultNote = (ITTTextBoxColumn)AddControl(new Guid("7f36c106-63bd-41a0-b12f-e1b0517177c6"));
            LongReport = (ITTRichTextBoxControlColumn)AddControl(new Guid("f52a1e2f-9d20-47bd-8fdb-703d78dc88a2"));
            TabForInformations = (ITTTabControl)AddControl(new Guid("71897651-aa7d-4c6b-a1e9-4e048fcd5f26"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("3b236999-df7a-4edb-8c1f-40a956add652"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("a2fe07c1-d594-4b79-951d-9bf4a71d9990"));
            PatientSex = (ITTEnumComboBox)AddControl(new Guid("415674cf-091d-4876-8742-b1f9c0ec68fa"));
            PatientAge = (ITTTextBox)AddControl(new Guid("5fe69b37-90a2-4fdb-b16c-f7119bb51703"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("0685c156-ce8c-4ff5-89ff-90b0dc65d81d"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("f045adce-57f2-43d6-bdbd-fe10f32bb4ec"));
            ReasonForAdmisson = (ITTTextBox)AddControl(new Guid("75cfe7c6-74e2-4f3c-a0e0-8bf422acd01b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("8c896088-5f76-44f6-9e89-0e8c09408f3f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e0c9e931-f756-4608-a7cb-007be0887c99"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("06afcfbf-b933-4b2c-abb0-2156cdc08c8b"));
            Urgent = (ITTCheckBox)AddControl(new Guid("de718f0d-3077-4f56-b0db-4e62874bcc5a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ae915abe-a9b7-410a-9b01-5a50cbc806f3"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("7882ed18-f497-443e-8310-c183c01c9b15"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a4b11469-f867-4db7-b5a6-15b55e445b31"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("f2a691bd-565c-4f8f-8889-564c76c39089"));
            lstApprovedBy = (ITTObjectListBox)AddControl(new Guid("ab8919fe-b563-49a9-96f3-08737d62809f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2304f733-9e79-4386-8b6b-fec5cda624a1"));
            requestDoctor = (ITTObjectListBox)AddControl(new Guid("91c36647-4e87-463f-b67a-7314b147c3e9"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("08fb51ef-500e-466a-97b3-f659af29f560"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("6515079a-2032-4034-a0fe-5135f4d5bc8d"));
            Gebelik = (ITTEnumComboBox)AddControl(new Guid("82fc63fc-0b03-4a8b-a813-3e1003ad66a5"));
            SonAdetTarihi = (ITTDateTimePicker)AddControl(new Guid("8926b79a-c850-4f07-a72f-5c6b9cce7aa4"));
            labelSonAdetTarihi = (ITTLabel)AddControl(new Guid("d50a1540-5831-421d-b371-b494e3352727"));
            labelGebelik = (ITTLabel)AddControl(new Guid("5924f27d-4eeb-4c7d-bad7-b09eb1c25000"));
            TabPageFutureRequest = (ITTTabPage)AddControl(new Guid("36e91f5e-ef57-4e21-840b-c2e7a2600f83"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("ed9a875d-ece0-4c98-8fbe-0f2e050c3a69"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("3a6d4f48-18fe-45bc-850d-677f128b839f"));
            textBarcode = (ITTTextBox)AddControl(new Guid("f20a376f-9d1e-4c9e-bdec-08f6c517b032"));
            ttlabel3drawgradient = (ITTLabel)AddControl(new Guid("ce4c3033-6d02-4146-b9cb-f699ee783d55"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("fdebfc7b-26d4-4da7-81cd-b63f6438d29a"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("7de38a73-6fa8-436c-8757-a2ad7a1def62"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("ee738b80-dbde-4c70-9396-69e91b5040d3"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("cf9d3277-fa67-4ef0-ad5c-cba4d35a494c"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("4a8d199b-7be5-43a8-825f-d11a46ff09be"));
            labelBarcode = (ITTLabel)AddControl(new Guid("2e3da378-71dc-49f2-ae8b-48c929375484"));
            base.InitializeControls();
        }

        public LaboratoryRequestResultForm() : base("LABORATORYREQUEST", "LaboratoryRequestResultForm")
        {
        }

        protected LaboratoryRequestResultForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}