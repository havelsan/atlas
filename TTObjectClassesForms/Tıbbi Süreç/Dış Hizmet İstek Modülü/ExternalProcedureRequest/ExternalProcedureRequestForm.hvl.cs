
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
    /// Dış XXXXXX Hizmet İstek
    /// </summary>
    public partial class ExternalProcedureRequestForm : TTForm
    {
    /// <summary>
    /// Dış Hizmet İstek
    /// </summary>
        protected TTObjectClasses.ExternalProcedureRequest _ExternalProcedureRequest
        {
            get { return (TTObjectClasses.ExternalProcedureRequest)_ttObject; }
        }

        protected ITTObjectListBox RequestedExternalHospital;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTTextBox tttextbox1;
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
        protected ITTEnumComboBoxColumn TreatmentToothPosition;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            RequestedExternalHospital = (ITTObjectListBox)AddControl(new Guid("c476ac98-5871-4d5d-b61f-c6308612d14b"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("a17f18c5-4a16-4648-ae76-84aaa70c0559"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("82868d02-6dd0-4152-af5a-169dc111328e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("eb874465-a30f-4149-bbde-b835d64ca2ec"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("b6fdf6f2-4e49-456d-abc7-dff2b06c50c3"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("5f8a33a1-2c96-4c17-a240-d8fa4a7f9c8a"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("d963deb3-3ec6-409a-8f2f-4afe00c4b407"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("b290f140-bbb0-4286-a04e-2a62057a2e17"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("25450359-82fc-4f35-8721-8286758fa6e2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c9e986b5-2e05-4f11-88d2-29b6d327cf86"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("a59f8c99-4924-4537-bed7-2a427af52732"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("0807118a-b054-4649-994b-4d63197b5441"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("5425dde7-0d40-4078-988d-d130c5af0403"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b68e6fec-af6d-4415-ae0f-d761c6eb7613"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("46c0fbcf-33e2-4f13-8a94-a9d0dbd67cb6"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("5a0506ba-93c2-4234-8d70-d81929e97eb0"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("07cd25bc-b45c-4afc-8ba3-2c2482091049"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("3abdd898-4866-46a8-8efb-5e82422e9787"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("4a246846-ee6f-40c4-8624-89951c831595"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("21ddd6c7-2b8e-4129-9e20-a1db5cb13f02"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("090796c2-f5af-46bf-9a71-a23e83dda4e1"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("b21602f6-7833-4ee7-9957-9320d5d9efa4"));
            ProcedureGrid = (ITTGrid)AddControl(new Guid("e8ca4777-534d-49b7-95ef-ead674f68366"));
            ProcedureDefinition = (ITTListBoxColumn)AddControl(new Guid("1268e578-afa4-478c-bf7c-1a6377a000f8"));
            TreatmentToothPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("313b2e4b-8306-4a0b-8f79-31803a1cf9b2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e2aa5bf8-fce7-4be0-89d0-78471f0731c3"));
            base.InitializeControls();
        }

        public ExternalProcedureRequestForm() : base("EXTERNALPROCEDUREREQUEST", "ExternalProcedureRequestForm")
        {
        }

        protected ExternalProcedureRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}