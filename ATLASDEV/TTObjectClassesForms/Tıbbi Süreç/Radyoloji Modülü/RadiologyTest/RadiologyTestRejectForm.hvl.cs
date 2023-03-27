
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
    /// Radyoloji Red Formu
    /// </summary>
    public partial class RadiologyTestRejectForm : TTForm
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
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel15;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTLabel ttlabel16;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTValueListBox ttvaluelistbox1;
        protected ITTLabel ttlabel8;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("dfe5b56b-50de-4de0-8dde-10302ebc676b"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("1c2f5ca6-9867-469b-993a-d664be759a00"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("868d0e9e-5118-4018-bb7d-fd6b6225f0bc"));
            Description = (ITTTextBox)AddControl(new Guid("2be72704-e333-4454-b8bf-a3af3f8399ee"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("15f4f474-c15c-4d3c-a708-659402260bb5"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("c30dc893-9e19-4d34-b8a3-7c6a8d276ace"));
            Equipment = (ITTObjectListBox)AddControl(new Guid("2b3e4cd7-99d0-4f20-b8db-8ce61d177903"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("64938666-24af-4d54-8489-552501f70d2d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("2fc5c213-caa6-4422-94d7-bf55c9181667"));
            Deparment = (ITTObjectListBox)AddControl(new Guid("85790ed0-f905-4bfb-bd5a-ddc8f26f352b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("59a527e2-6c54-4302-b619-8c239a6eaab5"));
            TestTechnicianNote = (ITTTextBox)AddControl(new Guid("822c9676-95b5-4fdb-8d61-ed7e7e0c4e99"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("aa3decbb-b39c-4a8d-bd4e-fe8b526630f1"));
            Materials = (ITTGrid)AddControl(new Guid("87f0fd24-54bd-41e3-b4d1-390e5602fe01"));
            Material = (ITTListBoxColumn)AddControl(new Guid("b5e5a9a4-2c18-4b1d-bd89-fc317264229c"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("cb94002d-8a57-4f58-a364-caeb9fb0d149"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("156aeef8-cc91-43bc-9be6-0dd5663e80f9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("58520306-a00c-43e3-ba49-b8a82b6b0b04"));
            OwnerType = (ITTTextBox)AddControl(new Guid("7c6de8dc-b562-425e-8c7f-85972871925d"));
            CommonDescription = (ITTTextBox)AddControl(new Guid("6e09b0e1-7104-4f26-b7ef-96b7417071ee"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("67fa1c6c-70ff-4188-ac15-146c79b3951c"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("1005154d-17df-4636-9d60-c55f41487612"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("a8a019b9-dd4c-4609-9405-6f076d7bdf53"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("22a81e9a-0c53-4e56-9568-589eb2aab2db"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("096daa24-eecc-4f79-bb76-fea45756648d"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("02b6a969-781b-4b82-bfa1-24de05be2bca"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("5ab0a99e-dd02-4527-846e-fd5b3a296149"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("968d1d7c-3a6f-4351-aba6-701170d590d0"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("8308edcb-b723-4116-9cc5-447b840a7aa1"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("5e60172f-ac3d-4fb3-a868-34a19f04e77d"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("632b3e59-19b1-4ae2-adbd-f8e660c13fec"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("82efcfd9-d813-4cfe-bb32-d3278e90f074"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("90a90a54-dc20-4940-86a9-2830c2ab958f"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("f521009e-cef3-404c-86b9-d974da32398a"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("1e559b45-44cd-453f-aa97-19679c05c3cc"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("8b425018-7a53-43ea-a2ba-a695376af787"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("9352999d-32ce-40b3-949b-7ea6667d54f2"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("27dc6fa4-67cb-4fe0-97cc-5695f47e5147"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("f3459b77-c6c5-4763-934a-2eb4aa3a884f"));
            ttvaluelistbox1 = (ITTValueListBox)AddControl(new Guid("d515c381-b370-488f-8761-8fb9b979c99d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("85e276e6-a514-470e-80c7-497d78f1958e"));
            base.InitializeControls();
        }

        public RadiologyTestRejectForm() : base("RADIOLOGYTEST", "RadiologyTestRejectForm")
        {
        }

        protected RadiologyTestRejectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}