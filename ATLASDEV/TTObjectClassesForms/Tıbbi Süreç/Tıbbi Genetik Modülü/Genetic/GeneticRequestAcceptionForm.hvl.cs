
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
    /// Materyal Kabul
    /// </summary>
    public partial class GeneticRequestAcceptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Genetik İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Genetic _Genetic
        {
            get { return (TTObjectClasses.Genetic)_ttObject; }
        }

        protected ITTObjectListBox TestToStudyTTListBox;
        protected ITTGrid GridEquipments;
        protected ITTListBoxColumn Equipment;
        protected ITTButton PrintBarcodeBtn;
        protected ITTTextBox MaterialResponsible;
        protected ITTTextBox SendenMaterial;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox PatientAge;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTTextBoxColumn EntryActionType;
        protected ITTObjectListBox RequestDoctor;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox PatientClinic;
        protected ITTEnumComboBox PatientSexEnum;
        protected ITTObjectListBox PatientRoom;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox RepeatReason;
        protected ITTLabel ttlabel6;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox ttcheckbox1;
        protected ITTGrid grdGeneticTests;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn Amount;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox RequestDescription;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox PreDiagnosis;
        protected ITTTabPage TabDescription;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel12;
        override protected void InitializeControls()
        {
            TestToStudyTTListBox = (ITTObjectListBox)AddControl(new Guid("da213e88-c001-4a83-a1ac-813cecf02571"));
            GridEquipments = (ITTGrid)AddControl(new Guid("5a1368d8-7af1-4cdb-899f-fd066618c2d6"));
            Equipment = (ITTListBoxColumn)AddControl(new Guid("2daee1d4-0769-4d4a-8930-6af96863814d"));
            PrintBarcodeBtn = (ITTButton)AddControl(new Guid("4aeac8ee-33d4-4273-873a-468a40adc6b1"));
            MaterialResponsible = (ITTTextBox)AddControl(new Guid("cced4af7-1b3e-4acf-b91f-1bf2202a9a13"));
            SendenMaterial = (ITTTextBox)AddControl(new Guid("a0cf885c-8439-4f7c-a5d0-586e1733766a"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("d9910723-dad8-4397-a95d-d6734f9088c8"));
            PatientAge = (ITTTextBox)AddControl(new Guid("30ccaaca-98b9-4623-a2eb-c2a738d98a2b"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("98523205-f149-42df-b7c1-129f02c8a191"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("2a68be2b-6d13-4bd4-b022-858c4ce94126"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("890e771e-278d-4502-b517-60b64690037e"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b4be43f1-2471-4240-bf75-b609b45f5825"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("44d64db1-2fd0-49f2-b0fb-0dd15b68b00c"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("19ca32e9-28df-486b-9e71-8abec866e70e"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("fb4f2e2c-b0eb-4386-955a-e4326c7a2623"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("359fa4a1-b25d-4205-bcae-d666e1e3e880"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("a1aac317-a88d-42e7-b49f-1acdf680b3b4"));
            EntryActionType = (ITTTextBoxColumn)AddControl(new Guid("01317f35-78bf-426e-a0d1-c458ffe68b96"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("025f3fe2-eb60-4b3f-883f-1da2bfc6fb4f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("afffa6a3-8ca9-4755-8445-7ddc32cfd7ea"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("96605633-de2b-4647-a578-ddccf222e62a"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("bf28eb19-79c2-4550-a6b8-351cc406a832"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("88319370-537f-4402-8f00-ec68bbe19bf6"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("d019fffd-45d8-4744-a975-bc979c863019"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("c5547f65-adcd-454e-ab11-c7f42331b506"));
            PatientClinic = (ITTObjectListBox)AddControl(new Guid("62039c2c-1d94-4152-a0b9-8c9e514e9e71"));
            PatientSexEnum = (ITTEnumComboBox)AddControl(new Guid("80fd145b-c87f-4cb4-9e4f-54f151209c2b"));
            PatientRoom = (ITTObjectListBox)AddControl(new Guid("12a8f048-893e-483d-b1d2-f2ad98da35ee"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("bebb67f3-4eea-4c9d-98f9-38cd7605de4f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f0eb6e7a-4dcf-47ea-b6f0-dbc72357e011"));
            RepeatReason = (ITTObjectListBox)AddControl(new Guid("2eba047c-c8fa-43d7-8099-43885c7c54f0"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("f6ccecd9-9924-46aa-8554-ba7ec43f67c0"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("e50d0643-5a5a-4508-a9f4-5a62fe529805"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("c877f764-08b8-4735-80e4-e7e157005d00"));
            grdGeneticTests = (ITTGrid)AddControl(new Guid("9e6bffaf-f360-4c39-b854-b41bf60d82f8"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("1d03dc77-d55c-4bab-a076-a6979793dc76"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("cc211226-ab50-42b4-ac33-4acaf3259b0d"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("53749860-746c-4980-8eb6-d2ba4dad2c60"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("9dc42d09-9d8a-44b2-8cef-34fb0cb749c7"));
            RequestDescription = (ITTTextBox)AddControl(new Guid("af0b8b96-2ce4-40ba-ac95-bbddb32f5dc1"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("8a2d96dc-c5b7-4b5c-867a-3e958b24186d"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("470e96fe-b36f-4dce-a267-489541a457f9"));
            TabDescription = (ITTTabPage)AddControl(new Guid("c9a65125-3094-48a1-820a-e3361a4627e1"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("b5acbdb0-44e6-4e91-8f5d-c970e0cdf8d3"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("f4a52131-5df2-40fa-8ff8-ef4902bb49b1"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("fa158914-dfbf-418b-8265-08cce6f001f0"));
            base.InitializeControls();
        }

        public GeneticRequestAcceptionForm() : base("GENETIC", "GeneticRequestAcceptionForm")
        {
        }

        protected GeneticRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}