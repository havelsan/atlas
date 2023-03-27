
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
    /// Prosedür
    /// </summary>
    public partial class RadiologyProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Radyoloji
    /// </summary>
        protected TTObjectClasses.Radiology _Radiology
        {
            get { return (TTObjectClasses.Radiology)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GridRadiologyTests;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTStateComboBoxColumn CurrentState;
        protected ITTTextBoxColumn Description;
        protected ITTButtonColumn Cancel;
        protected ITTRichTextBoxControlColumn Report;
        protected ITTCheckBoxColumn Check;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GridMaterial;
        protected ITTListBoxColumn RStore;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Notes;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTCheckBox AllCheck;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelPreInformation;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel8;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTLabel ttlabel9;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTObjectListBox ReasonForAdmission;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("8e3b1f65-6bd8-4e8d-967a-49a717a09808"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("79714237-0406-49a5-a88f-98b68ab6914c"));
            GridRadiologyTests = (ITTGrid)AddControl(new Guid("91b64bfa-8db2-483b-8538-0aedb5cf62fa"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("17850ce4-ced9-455f-b3bf-bb979dd95b18"));
            CurrentState = (ITTStateComboBoxColumn)AddControl(new Guid("28f1acb7-f9da-406e-b09e-b07ab47aa061"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("b262ff4d-930a-4f7e-a00d-9c93a2f20001"));
            Cancel = (ITTButtonColumn)AddControl(new Guid("dc1d7414-4aa1-47d1-88ea-7e2b768145ce"));
            Report = (ITTRichTextBoxControlColumn)AddControl(new Guid("81f2a8f0-3182-478e-aa0b-1294deafea5e"));
            Check = (ITTCheckBoxColumn)AddControl(new Guid("b1693567-1453-4750-995a-4ea3c0f401ca"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("894cecde-eb98-4b77-848b-b24ff1b42003"));
            GridMaterial = (ITTGrid)AddControl(new Guid("df769160-6093-4ebd-bd16-709f7f459573"));
            RStore = (ITTListBoxColumn)AddControl(new Guid("126da24b-7596-4a58-b5ed-49f78c9c1691"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a16be76f-7c35-407a-aba8-379e952c5dae"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("ea335dde-68cf-40a6-bd59-67dbbe4d011d"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("1234c207-0468-418f-85c5-4e829b4cdcca"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("1dad1a60-8c2f-475c-aff6-ecc49d55b527"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("eefdb3c8-cace-48a5-a625-19df9048bba2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("8d22f0bc-efa5-4b5b-b5ca-5f8737dbbd8c"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("e4000ea9-af8e-48a9-b04c-c58565ecc5d6"));
            AllCheck = (ITTCheckBox)AddControl(new Guid("86ee0bac-1498-45c1-bad5-30ad1737677e"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("181d5d32-550e-462b-a0f0-ee55a1dd7a3e"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("8fcd6a31-e999-4f61-994e-59819e69db5c"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("99a3e799-d44c-4651-a379-f8ba44d89815"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("3436e8e2-6825-4c3f-894c-f8785b7cc6c9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e98af337-7ae2-4a26-a34e-dfe4609267d4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3518f70c-5fe9-40ef-b3cf-a51ffe958290"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("fb1c6746-6e08-4e06-81a9-2dba5b33a921"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("264003bf-c593-4f7d-809d-0218252bd481"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("1330a3b2-5686-4022-9b9f-ec53f38e3729"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("627c9af4-e4f2-493c-8dea-23ba8d9747cd"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("c40f7a68-ddd7-4ca1-ab63-065713d031d3"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("7d06731c-ab94-4f8c-be14-ab50c85895c9"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("17ffdde5-e439-4ce9-b568-0dc85f135f22"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("e47da352-a2bd-455e-8b32-ea0a264a00dc"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("3ee07695-b63c-4133-a092-a30b5839624b"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("6e2c462b-0fa5-452a-8a7e-4a3e5a50c2e0"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("42dc7580-ce45-4e71-a0d7-bcb05612ff62"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("01de5691-e058-4779-8d35-3373a77e6975"));
            base.InitializeControls();
        }

        public RadiologyProcedureForm() : base("RADIOLOGY", "RadiologyProcedureForm")
        {
        }

        protected RadiologyProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}