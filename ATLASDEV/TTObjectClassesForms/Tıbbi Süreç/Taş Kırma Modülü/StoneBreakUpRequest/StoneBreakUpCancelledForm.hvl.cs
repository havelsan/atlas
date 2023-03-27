
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
    /// Taş Kırma
    /// </summary>
    public partial class StoneBreakUpCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Taş Kırma
    /// </summary>
        protected TTObjectClasses.StoneBreakUpRequest _StoneBreakUpRequest
        {
            get { return (TTObjectClasses.StoneBreakUpRequest)_ttObject; }
        }

        protected ITTRichTextBoxControl Report;
        protected ITTRichTextBoxControl Note;
        protected ITTRichTextBoxControl Symptom;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage CancelTab;
        protected ITTTextBox tttextbox1;
        protected ITTTabPage StoneBreakUp;
        protected ITTGrid StoneBreakUpProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn PartOfStone;
        protected ITTTextBoxColumn StoneDimension;
        protected ITTTextBoxColumn NumberOfProcedure;
        protected ITTEnumComboBoxColumn ZoneOfStone;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn MaterialNote;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Age;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTDateTimePicker ProcessDate;
        protected ITTLabel labelProcedureDate;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTDateTimePicker RequestDate;
        protected ITTCheckBox Urgent;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox Sex;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            Report = (ITTRichTextBoxControl)AddControl(new Guid("cb901a21-aecb-4584-a08a-1906bfd34664"));
            Note = (ITTRichTextBoxControl)AddControl(new Guid("b62e0b6c-5b03-47eb-8e42-f0b0d505d1db"));
            Symptom = (ITTRichTextBoxControl)AddControl(new Guid("56b1fde7-3662-49d9-8f31-982679afa4ef"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("cd1d22c5-210a-4452-9a50-7aadbba7d0a3"));
            CancelTab = (ITTTabPage)AddControl(new Guid("f50912ed-7710-4aff-bfc6-eb5e2396c965"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c5d74fac-b88b-4a1c-aa8d-6487c96e961b"));
            StoneBreakUp = (ITTTabPage)AddControl(new Guid("30d747e7-2905-4d06-9449-ce832954673f"));
            StoneBreakUpProcedures = (ITTGrid)AddControl(new Guid("1fcc69d2-011d-44f0-a5a2-631e87b5de6e"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("2ffd1612-3a69-413b-ad8f-4224626a8558"));
            PartOfStone = (ITTListBoxColumn)AddControl(new Guid("829b357a-fb47-4c7d-acda-0e61e21ee6c2"));
            StoneDimension = (ITTTextBoxColumn)AddControl(new Guid("7112121b-ab66-46f4-923f-b5cd3e224ad7"));
            NumberOfProcedure = (ITTTextBoxColumn)AddControl(new Guid("98227cc0-b497-471f-9b75-256a93199a2c"));
            ZoneOfStone = (ITTEnumComboBoxColumn)AddControl(new Guid("489b7c12-7768-4ada-a425-8475447e0b48"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("8023c3cd-00de-45f3-980d-04122fc59583"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("798b4ff0-f985-4c96-a29f-9af26a527a9f"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("17ffcd8a-d44c-4326-8384-e3a70763eefe"));
            Material = (ITTListBoxColumn)AddControl(new Guid("43006ef2-cfc7-47e4-910c-f1375584c47c"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("50f4d85a-dd2c-4367-b07f-6331cb156394"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("9872b8f3-4993-485a-a1cb-2d12e94b3246"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("589a12a9-8314-4d99-90a1-87364789ee71"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("7c6239bb-b60a-460e-b170-b878ef39c541"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("9607f523-ae66-4e23-9529-7fefce63e469"));
            Age = (ITTTextBox)AddControl(new Guid("737bfe8f-86b8-431f-94ab-e0d320c5f658"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("2043501e-75a5-42ab-bd42-df66fa08f730"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("c8bff240-6974-45ec-9a34-09df284091ce"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("edf1219d-a56a-4e4d-9611-7eb9568770f1"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("a3e3f8ac-242c-43d6-8a45-635bc66292cb"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ac58f945-3ffa-43d7-8227-9b1aee097451"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d9541c3d-05a2-4146-82c2-46c517e22ac0"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("974d4474-da87-42c6-830b-7c97c75584d9"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("6703881d-3812-46fe-9d6e-70fd5e0204b0"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("0c5cdbb2-63dc-4752-b628-5fca527f8b12"));
            labelProcedureDate = (ITTLabel)AddControl(new Guid("559d98da-174f-48f6-8831-28ac2994c919"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("92da3afa-c977-4c40-be5f-3c98d2908a17"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("831ec9c2-d44d-45ad-9dde-20aae964c0eb"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("cbb4e933-9012-4859-a382-ee2c28bebafb"));
            Urgent = (ITTCheckBox)AddControl(new Guid("dc8a7faf-068c-4d6c-a58d-f1f680cf0950"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("fb07ac08-8c12-4e57-8769-60133fd48bb2"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("0b525162-5b6c-4d65-b641-e458d05ee5d2"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("9cd90105-715d-4186-9833-18597367d337"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b39548de-6ca4-42e0-8e54-07830a0daafa"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("1cd92660-878a-41dc-a396-892a1b84eb7e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("044cb2a8-734a-453d-91f5-6f7d12c6664b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("48ffc7d6-620f-4f41-ad96-ca35f1248548"));
            base.InitializeControls();
        }

        public StoneBreakUpCancelledForm() : base("STONEBREAKUPREQUEST", "StoneBreakUpCancelledForm")
        {
        }

        protected StoneBreakUpCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}