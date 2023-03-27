
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
    /// Diğer XXXXXXden Tetkik İstek Formu
    /// </summary>
    public partial class InternalProcedureRequestForm : TTForm
    {
    /// <summary>
    /// Diğer XXXXXXlerden Tetkik İstek
    /// </summary>
        protected TTObjectClasses.InternalProcedureRequest _InternalProcedureRequest
        {
            get { return (TTObjectClasses.InternalProcedureRequest)_ttObject; }
        }

        protected ITTLabel ttlabel6;
        protected ITTObjectListBox TTListBoxIstekYapanTabip;
        protected ITTLabel ttlabel2;
        protected ITTComboBox cboMasterResource;
        protected ITTLabel lblProcedureDefinition;
        protected ITTLabel lblOtherHospital;
        protected ITTObjectListBox TestMenuDefinition;
        protected ITTObjectListBox OtherHospital;
        protected ITTTextBox PreDiagnosis;
        protected ITTTextBox tttextbox2;
        protected ITTLabel labelPreInformation;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTLabel ttlabel4;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid ProcedureGrid;
        protected ITTListBoxColumn ProcedureDefinition;
        protected ITTButton ShowMessageStatus;
        protected ITTLabel lblMasterResource;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttPreDiagnosisLength;
        protected ITTLabel ttNotesLength;
        override protected void InitializeControls()
        {
            ttlabel6 = (ITTLabel)AddControl(new Guid("6de67c5c-87d7-4ded-900a-9e3466506b1d"));
            TTListBoxIstekYapanTabip = (ITTObjectListBox)AddControl(new Guid("1e7a69b8-59f0-43c3-ba7a-36a0489f27ed"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f52b61aa-4081-4c97-9b93-a5d335746ed6"));
            cboMasterResource = (ITTComboBox)AddControl(new Guid("8549be9d-1c6e-43ff-84c0-33d64b4619cf"));
            lblProcedureDefinition = (ITTLabel)AddControl(new Guid("6cd15c5c-738f-4c17-87c5-7eff772d99cc"));
            lblOtherHospital = (ITTLabel)AddControl(new Guid("d32bf34f-08e4-43c7-b713-8e6a9b71511e"));
            TestMenuDefinition = (ITTObjectListBox)AddControl(new Guid("b85bb21d-7c6c-49f8-acd5-928b4706a797"));
            OtherHospital = (ITTObjectListBox)AddControl(new Guid("35e91274-eb17-493e-a1c2-103200e89cef"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("94673d79-6c77-4d30-8554-9baa8f84caa9"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("ff039e51-8054-468f-84cc-2669caf84a04"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("56709ba4-b1ae-40bf-bd9c-bd37f4458d0e"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("ac6166ae-0dff-432e-b710-3a3190ed970c"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("e4e7661e-fa76-47cf-a06c-ae417af920ad"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9bdb2156-81b2-4a66-99d7-00519b8e4cf6"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("aea86b5d-d242-43da-95e4-27a738ad6fc7"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("47f22fe7-dd8e-4c0e-9c7c-edd4525be482"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("dec8ba93-4cbf-440a-b99b-8739e71b21f5"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("5f8d4f3c-a446-44cc-a7b4-326a11e29f50"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("638553f5-1db7-4d59-9336-99175ecc001c"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("35d8b257-3ba3-43cc-a4f6-22ab03c14d04"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("54144cf9-3bd0-4fe5-8c70-2a1a5d3cca08"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("47b0d815-b75d-43db-9c7e-286bef787fd1"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("3d05dd07-568c-4136-a38c-af2f58cbee43"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("84a062e1-8c46-4f20-862d-13269124b4ab"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("aa8f9069-c7f0-4f49-b7bf-ff0b85930c3e"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("20010db2-8f88-4314-bb7f-0cae4a628857"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("e74214a4-d509-4438-8e42-f09db28902a3"));
            ProcedureGrid = (ITTGrid)AddControl(new Guid("31827572-9b18-4983-a4d5-d1eadcb59a5c"));
            ProcedureDefinition = (ITTListBoxColumn)AddControl(new Guid("ded34ffc-f07b-46c9-8df0-c2af1a7406e6"));
            ShowMessageStatus = (ITTButton)AddControl(new Guid("7d5d81c7-ad26-4325-a830-51b935227913"));
            lblMasterResource = (ITTLabel)AddControl(new Guid("f5d8698b-96c2-4466-8a82-34dbb37f276c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("bc5928f6-872c-4ba5-b49b-49762611804a"));
            ttPreDiagnosisLength = (ITTLabel)AddControl(new Guid("6dd9f1bc-e0c9-45a4-863e-07fba2f060f3"));
            ttNotesLength = (ITTLabel)AddControl(new Guid("8d3ceae4-ab88-4496-829b-f69d17cd40ad"));
            base.InitializeControls();
        }

        public InternalProcedureRequestForm() : base("INTERNALPROCEDUREREQUEST", "InternalProcedureRequestForm")
        {
        }

        protected InternalProcedureRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}