
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
    /// Ameliyat Sonrası Derleme
    /// </summary>
    public partial class IntensiveCareAfterSurgeryPostOpForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat Sonrası  Derlenme İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.IntensiveCareAfterSurgery _IntensiveCareAfterSurgery
        {
            get { return (TTObjectClasses.IntensiveCareAfterSurgery)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage EstimatingTab;
        protected ITTGrid IntensiveCareEstimatings;
        protected ITTDateTimePickerColumn DateTime;
        protected ITTEnumComboBoxColumn Activite;
        protected ITTEnumComboBoxColumn Respiration;
        protected ITTEnumComboBoxColumn Circulation;
        protected ITTEnumComboBoxColumn Wakefulness;
        protected ITTEnumComboBoxColumn Color;
        protected ITTTextBoxColumn TotalScore;
        protected ITTTabPage NursingProcedureTab;
        protected ITTGrid NursingProceduresGrid;
        protected ITTDateTimePickerColumn npActionDate;
        protected ITTListBoxColumn npProcedureObject;
        protected ITTTextBoxColumn npResult;
        protected ITTTextBoxColumn ntNote;
        protected ITTTextBox ProtocolNo;
        protected ITTObjectListBox TreatmentClinic;
        protected ITTLabel labelTreatmentClinic;
        protected ITTRichTextBoxControl TTRichTextBoxUserControl;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelActionDate;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage MaterialEntry;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn MNotes;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f6682ab9-6522-446b-9941-afe865b345c6"));
            EstimatingTab = (ITTTabPage)AddControl(new Guid("db4a669d-655b-4da9-8b2b-d6acc7fa4c39"));
            IntensiveCareEstimatings = (ITTGrid)AddControl(new Guid("62b67931-5fca-4452-8846-ded13784d5c8"));
            DateTime = (ITTDateTimePickerColumn)AddControl(new Guid("ba2fc972-404b-4f9a-ad94-c9ebf3aefd42"));
            Activite = (ITTEnumComboBoxColumn)AddControl(new Guid("49b98f81-739f-4cd5-83c9-a3b5c88c6e46"));
            Respiration = (ITTEnumComboBoxColumn)AddControl(new Guid("ae9d8321-73d8-4e3f-a14f-bd7ec483078f"));
            Circulation = (ITTEnumComboBoxColumn)AddControl(new Guid("efcc7c50-33f1-436e-832c-4e5444ec38f1"));
            Wakefulness = (ITTEnumComboBoxColumn)AddControl(new Guid("c4e6b6ea-4ddf-4b4a-83ca-20a52f673ddd"));
            Color = (ITTEnumComboBoxColumn)AddControl(new Guid("18f3b67a-696e-41e6-88ab-ffae1c1fcfc7"));
            TotalScore = (ITTTextBoxColumn)AddControl(new Guid("2c17b025-e525-4794-ad8c-8bb140376a9e"));
            NursingProcedureTab = (ITTTabPage)AddControl(new Guid("7a7061c6-c9af-44f4-975f-33c547cec50c"));
            NursingProceduresGrid = (ITTGrid)AddControl(new Guid("ea6a47b9-6196-4b56-9bcf-c3e121f328df"));
            npActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("6795791f-50bf-40cd-a0cc-850157049eb1"));
            npProcedureObject = (ITTListBoxColumn)AddControl(new Guid("56f05b4f-14b9-44f2-b917-b0c8b328f66b"));
            npResult = (ITTTextBoxColumn)AddControl(new Guid("fc2f72ce-a1e8-4f32-b5a1-697fa04b9b9d"));
            ntNote = (ITTTextBoxColumn)AddControl(new Guid("ff4b38e2-fd23-4a89-9378-e5328f8dbf74"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("4d84fd4e-306e-47c3-b8ee-af367b2b1e6d"));
            TreatmentClinic = (ITTObjectListBox)AddControl(new Guid("91272833-d0ed-4e3c-870e-cd01290c8787"));
            labelTreatmentClinic = (ITTLabel)AddControl(new Guid("2b32a3f4-b6c1-4ff3-a623-97ab890ceaf0"));
            TTRichTextBoxUserControl = (ITTRichTextBoxControl)AddControl(new Guid("c77e47b2-04f6-4ddf-8636-849fa294ab54"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("ee822968-c9e2-44a9-bdc8-071751552c33"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("035d07a5-2e0b-468e-aec1-e187d79bad91"));
            labelActionDate = (ITTLabel)AddControl(new Guid("0a13690a-a9fe-4e14-81ec-8423f8696164"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("038dfa62-b1a7-4c95-a8b1-ae144eef16be"));
            MaterialEntry = (ITTTabPage)AddControl(new Guid("11626889-ab81-47a4-8048-b38b830578f6"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("49644545-3492-4338-9dc8-eeb6fca3f9aa"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("7631133c-d5f2-40f6-85fd-9dcee48d5ed8"));
            Material = (ITTListBoxColumn)AddControl(new Guid("abf3f981-2f32-4f7a-959f-c8b6b1e3e1b5"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("efa19c74-e2f8-4731-a256-aa585fafa412"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("0a404ba1-adaf-451d-a43a-dcf831086116"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("1661ecf3-1926-445d-af5e-411850dbc5ea"));
            MNotes = (ITTTextBoxColumn)AddControl(new Guid("60604a3f-9c08-474b-8e6f-ace4672ffc30"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("6a22f708-5465-4620-bc68-bbe5d8de1ba3"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("2c9f87a3-94e0-4099-a2e0-7491f75bd700"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("f570c311-0f85-4b0c-ad0d-76d49c47e0a6"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("96d58cf7-2ba1-4c58-8faf-69f346a76c77"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("906128ed-fce2-4c92-a8a5-4e9c31c83f0e"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("d9f61663-29ac-406f-a466-6f174648a1ca"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d162db1a-8d73-4f08-99da-ff2b4b10564a"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("a86f1236-3b8e-48ed-bed5-e3b5e8ab5aeb"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("dc31878a-4b3c-458a-8592-a387d0947948"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("dbfb0853-3ddc-4630-9845-938c587e5217"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("14c182f3-5d3e-48fe-a067-4fde90204610"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("4dd6610b-9a03-4bb0-bc6d-8a7217249e60"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fb9fb0e2-0298-4c45-9b35-cf146dc601c2"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("9fcc4b58-5fae-4f28-800e-0b078fe69615"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5f7f21c6-e5dc-40ae-b7d0-4c51a506eb21"));
            base.InitializeControls();
        }

        public IntensiveCareAfterSurgeryPostOpForm() : base("INTENSIVECAREAFTERSURGERY", "IntensiveCareAfterSurgeryPostOpForm")
        {
        }

        protected IntensiveCareAfterSurgeryPostOpForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}