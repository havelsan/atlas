
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
    /// Nükleer Tıp Radyofarmasi Formu
    /// </summary>
    public partial class NuclearMedicineRadioPharmacyForm : EpisodeActionForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel11;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel12;
        protected ITTButton PrintBarcodeButton;
        protected ITTTextBox tttextbox4;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel1;
        protected ITTTabControl TABNuclearMedicine;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox RADIOPHARMACYDESC;
        protected ITTTabPage tttabpage3;
        protected ITTGrid GridNuclearMedicineMaterial;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Note;
        protected ITTTabPage tttabpage4;
        protected ITTGrid GridRadPharmMaterials;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTCheckBoxColumn IsInjection;
        protected ITTTextBoxColumn tttextboxcolumn3;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTListBoxColumn Units;
        protected ITTTextBox nucMedSelectedTesttxt;
        protected ITTCheckBox IsPregnant;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox3;
        protected ITTObjectListBox InjectedBy;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox REQUESTDOCTOR;
        protected ITTCheckBox IsEmergency;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel ttlabel7;
        protected ITTTextBox REQUESTDOCTORPHONE;
        protected ITTTextBox PatientPhone;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTTextBox PATIENTWEIGHT;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelProcessTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("f325a0fd-13c3-4a5a-917f-879cf85218a0"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("22d125d5-e8a9-454a-b8f9-5a96584e9929"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("bac14024-20f2-4786-abe0-a5fbf01bc7fe"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("07d81a4c-5537-4f88-a0b2-1a7ca7a05812"));
            PrintBarcodeButton = (ITTButton)AddControl(new Guid("33cd8fbe-1fd7-4758-a17a-d8ab085fd92c"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("7e1d9938-c13e-44e0-b40b-702dd49c8919"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("dad64dfb-729c-49cc-be4c-5fbdea82b69e"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("2dc33a00-bf3e-4fbc-ba9f-a9dcc48a56a1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7378527c-b524-4a00-8f31-8d0378506708"));
            TABNuclearMedicine = (ITTTabControl)AddControl(new Guid("31d5598b-9558-4eaf-a672-440a3ab6ad81"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("48cd07b6-32a5-420e-83b7-de56f359df89"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("baee3576-1b46-42c4-a3fb-b44b16e9382c"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("632dd357-1401-43be-a62c-58d698587088"));
            RADIOPHARMACYDESC = (ITTTextBox)AddControl(new Guid("ba2746ba-1018-4c0f-913f-845d7837bb74"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("ccd4a410-6906-47d4-a1a2-f9027c4d573a"));
            GridNuclearMedicineMaterial = (ITTGrid)AddControl(new Guid("19b9c800-2969-4aba-b424-63e169db910e"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("a558c9ff-9c1f-40d9-b739-a31926edcb6e"));
            Material = (ITTListBoxColumn)AddControl(new Guid("f6eef7e9-4bc2-49cb-a51d-ba84e4f58256"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("17f080e0-6fe5-4573-8f53-59156aa4ceed"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("d130ad0a-4f4a-42f1-8a71-0bcf97fc9885"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("3a299417-40f1-4f26-836c-a686c33a4f90"));
            GridRadPharmMaterials = (ITTGrid)AddControl(new Guid("8460fad8-7c02-49da-b592-a754fbd58f83"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("43bcb2d8-01c2-4bc5-bf8b-ae01b4cae1ae"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("30b7d902-7a6a-43d9-a335-5be09f568ab7"));
            IsInjection = (ITTCheckBoxColumn)AddControl(new Guid("91ac9153-b3e6-421c-b780-ba0aae36e96a"));
            tttextboxcolumn3 = (ITTTextBoxColumn)AddControl(new Guid("c75c3f54-7e5b-4182-ba7f-0e4d4eccff6c"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("5eacaf2e-f105-439a-a208-960fab2be401"));
            Units = (ITTListBoxColumn)AddControl(new Guid("161f5f5e-403b-43e9-90ae-a66a84284325"));
            nucMedSelectedTesttxt = (ITTTextBox)AddControl(new Guid("36f73d19-0e64-4492-921e-5d8a4d1ad4ee"));
            IsPregnant = (ITTCheckBox)AddControl(new Guid("b71f006e-de51-4b1f-b68c-571ef190c112"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("856af5a4-68c6-45be-bf11-e0c846c3fa8d"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("428704af-a59b-4f18-9988-fdc0c9264948"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("6885f243-489d-4bd1-8cdf-050180b2d09c"));
            InjectedBy = (ITTObjectListBox)AddControl(new Guid("d1289133-2b1a-4f44-a8ef-c0b4e05abe4a"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("eac17f5a-a488-4e60-8ade-12658dcd0589"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("09329305-107b-46f8-afc8-becbfe3f669a"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("14a714c1-66f1-4e3c-a1f2-2bb031729eb3"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("d23635ab-b47a-42db-b41d-5c99bb08d197"));
            IsEmergency = (ITTCheckBox)AddControl(new Guid("129c2295-5f5e-47bd-9645-caf6fd5299e1"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("45e0371a-dc99-48ad-be8b-f78f9d5e0876"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("83cf8b7a-3d5f-4c34-a714-85038d7fc02e"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("6d8f3ed6-1248-4efc-8483-5b3cee1b134d"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("35940bb1-ccf1-4f81-8e52-83f4e80cf945"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("930c894c-23ef-4964-ae9d-c3bdd1cbc9cf"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("1507f784-42b9-40e4-80e4-427f291afe08"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("e50463d6-edb9-4da5-9736-d0eeeb991830"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("7ed46e1a-5f70-4872-ad6b-496c8a8fe714"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("4a93226e-9f7d-4cab-840b-df87ad30e0be"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("b5cfafe3-596b-455b-817d-50f6378d70a2"));
            REQUESTDOCTORPHONE = (ITTTextBox)AddControl(new Guid("77ddfc2a-f828-456f-bef8-4e42d0b177d2"));
            PatientPhone = (ITTTextBox)AddControl(new Guid("1f19435a-4a1b-4103-88cc-cdc0d72f532b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("2295ae25-444d-4e64-a0c1-fda8fffb28cd"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("3437f148-9d9c-4c4c-a23b-b14f5aa9e510"));
            PATIENTWEIGHT = (ITTTextBox)AddControl(new Guid("dd5f12b0-6c3f-4f99-b568-0b71c5503050"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("a6f50faa-2314-4219-b6d8-bda18bfdbf1b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("97cdafb0-4052-40b6-ba98-2cf6c7175e92"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("d44ec736-7e47-45f6-976e-1acba7256997"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("0f63ba6a-f16d-47c4-9f89-55e813c93f0c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("98e0bdec-acf2-4e2e-9b9c-a63f9154d43c"));
            base.InitializeControls();
        }

        public NuclearMedicineRadioPharmacyForm() : base("NUCLEARMEDICINE", "NuclearMedicineRadioPharmacyForm")
        {
        }

        protected NuclearMedicineRadioPharmacyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}