
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
    public partial class RadiologyTestCancelForm : TTForm
    {
    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
        protected TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get { return (TTObjectClasses.RadiologyTest)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox Equipment;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox Deparment;
        protected ITTLabel ttlabel1;
        protected ITTTextBox TestTechnicianNote;
        protected ITTTabPage tttabpage2;
        protected ITTGrid Materials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        protected ITTTextBox OwnerType;
        protected ITTTextBox CommonDescription;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTextBox CancelReason;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel7;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ttobjectlistbox1;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("5094f006-5dc6-4f0f-996b-b4d2db521f40"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("114f1628-e70f-4f4e-9ddc-70e3e2fed890"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6bcfd4b8-a13f-4439-85bc-d421944cf7d7"));
            Description = (ITTTextBox)AddControl(new Guid("7583f860-0522-4250-9877-e228d5bd34f0"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("041fe66f-7f88-42c0-b9f8-b77a95d6c5ba"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("e6f390a8-08ec-4776-815b-126ea8ecc891"));
            Equipment = (ITTObjectListBox)AddControl(new Guid("25d90773-f6ee-4976-9b1a-0c50af52ac54"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("9b3b3e57-bcae-47ee-96fd-dc7b78e7fabd"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("c092d0c5-d7b1-4dcc-bdd5-f511f674f72d"));
            Deparment = (ITTObjectListBox)AddControl(new Guid("eb10db4d-1737-46fa-a69a-b64efa72d8b3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5663ee08-5408-4ad5-9274-a3461702b5e4"));
            TestTechnicianNote = (ITTTextBox)AddControl(new Guid("10cab8b2-a63b-4fc2-82aa-e64061754291"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("a5fe48a6-e426-4f3a-98e2-ef3679aa5343"));
            Materials = (ITTGrid)AddControl(new Guid("23e68adf-1a1a-4190-a75a-6288774c9535"));
            Material = (ITTListBoxColumn)AddControl(new Guid("57722737-2f55-4a38-9852-73bb16fc40d6"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("c6be6b7b-c0b6-4975-a4e3-0de5be15cb83"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("325e1992-6601-427f-94cc-b94e8ddf6008"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d11a0cbd-a9a4-4993-869b-effcf85cee3c"));
            OwnerType = (ITTTextBox)AddControl(new Guid("16015585-ae5e-4129-b10a-a38c7b0f36d6"));
            CommonDescription = (ITTTextBox)AddControl(new Guid("6ece9ece-6315-4540-8ce5-2689a109b329"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("5405c66f-1b71-4b8a-b2f7-98d656692607"));
            CancelReason = (ITTTextBox)AddControl(new Guid("487ab534-af5e-4b82-938b-fef94f996e4e"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("30cac1e5-6fa4-45ae-bda9-8bf6c77cdeb4"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("ccc83a7d-111a-4e22-9c80-67e039da037a"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("2990eaf7-cfdb-48ec-86d5-88addd49d73a"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("69259f7a-0463-4a0d-97da-51b7f5c83687"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("f6d523fa-c527-44e8-a5c1-920147191164"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("46de194a-7306-4a26-81f0-993753873f9c"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9d3a8827-6e14-4805-b084-2855aa64f16c"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("4ac9e2cd-aed5-4d00-9627-262c83ea7fb9"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("0582c096-4749-4967-9427-74e4fc4f5d38"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("031122d7-8eee-4874-acd3-8dcafdc16e43"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("c3a5e67b-01b0-481a-833e-ddeceacc59d9"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("92467f73-bb36-45d4-9e1e-d74f07d1e00d"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("21ac7091-cdb2-4969-9af0-b35459ef2a49"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("03c2a0a0-927c-4fc4-8191-6cebbb5a78dd"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("d537da5b-2399-4a0e-919f-eafc343c819c"));
            base.InitializeControls();
        }

        public RadiologyTestCancelForm() : base("RADIOLOGYTEST", "RadiologyTestCancelForm")
        {
        }

        protected RadiologyTestCancelForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}