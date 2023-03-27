
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
    public partial class GeneticAnalysisForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Genetik İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Genetic _Genetic
        {
            get { return (TTObjectClasses.Genetic)_ttObject; }
        }

        protected ITTTabControl TabTextInfos;
        protected ITTTabPage TabPageRequestDesc;
        protected ITTTextBox RequestDescription;
        protected ITTTabPage TabPagePrediagnosis;
        protected ITTTextBox PreDiagnosis;
        protected ITTTabPage TabPageDescription;
        protected ITTTextBox Description;
        protected ITTTabPage TabPageReport;
        protected ITTRichTextBoxControl rtfReport;
        protected ITTTextBox MaterialResponsible;
        protected ITTTextBox SendenMaterial;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox PatientAge;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel11;
        protected ITTObjectListBox TestToStudyTTListBox;
        protected ITTCheckBox EmergencyCheckBox;
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
        protected ITTObjectListBox PatientRoom;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox PatientClinic;
        protected ITTEnumComboBox PatientSexEnum;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox RepeatReason;
        protected ITTLabel ttlabel12;
        protected ITTButton cmdPrintBarcode;
        protected ITTGrid GridEquipments;
        protected ITTListBoxColumn Equipment;
        protected ITTTabControl TabTests;
        protected ITTTabPage TabPageTests;
        protected ITTGrid grdGeneticTests;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn TestAmount;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridGeneticMaterials;
        protected ITTDateTimePickerColumn MACTIONDATE;
        protected ITTListBoxColumn MATERIAL;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn AMOUNT;
        protected ITTTextBoxColumn UBBCODE;
        override protected void InitializeControls()
        {
            TabTextInfos = (ITTTabControl)AddControl(new Guid("56417d80-b006-401a-acac-8ea4aec0c9c0"));
            TabPageRequestDesc = (ITTTabPage)AddControl(new Guid("530c6af5-8042-45d4-9586-780756828867"));
            RequestDescription = (ITTTextBox)AddControl(new Guid("f811516c-66e2-4f9f-9e61-14477ffef6d1"));
            TabPagePrediagnosis = (ITTTabPage)AddControl(new Guid("08405367-460c-4b61-bdbb-99aba5540bf2"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("14b909f7-864e-40ef-9fe3-e81f3525f50a"));
            TabPageDescription = (ITTTabPage)AddControl(new Guid("e47c8054-36fa-462e-a576-dd17be7d58d6"));
            Description = (ITTTextBox)AddControl(new Guid("3780ae7a-58a3-4f02-afe4-4ed7b46fd057"));
            TabPageReport = (ITTTabPage)AddControl(new Guid("8b8bbe24-bc8e-4fc4-967a-b4b4a214c228"));
            rtfReport = (ITTRichTextBoxControl)AddControl(new Guid("eb8726ab-3ad0-4bbc-9dcb-0c87438aae3c"));
            MaterialResponsible = (ITTTextBox)AddControl(new Guid("2caa175a-5688-4116-868e-39e96064bc9c"));
            SendenMaterial = (ITTTextBox)AddControl(new Guid("c8e63e8e-f2a6-45c1-8e8c-12c4448a9e2b"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("8bc857d8-a63c-43a0-b7a3-85de53b2f9cb"));
            PatientAge = (ITTTextBox)AddControl(new Guid("890d3290-1a91-4bb0-922e-7cd78372bd82"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("29d6555d-12cd-482e-a044-f37ed0c36e4b"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("35f6f2c8-903c-4f2f-b66c-c91f25d3bcd3"));
            TestToStudyTTListBox = (ITTObjectListBox)AddControl(new Guid("be682804-1e18-4dd1-bedc-6a0f639605f7"));
            EmergencyCheckBox = (ITTCheckBox)AddControl(new Guid("8ffa7c6f-a263-4fa3-a48e-efe8e8486006"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("f0f05d73-179c-40f4-a20d-3458c5a08b05"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("43d3d991-bb2d-48a4-a7f9-cbe08da0ec8d"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("7de29f35-433f-41a2-9495-8558f43ea144"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("02fed664-49f3-439e-9d57-cd5c7484f52f"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("12ad5ca3-a090-4bc3-b8e3-8de47524ff6d"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("2148eeaf-5b14-416d-9a84-28ef361fce2b"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("49bd088c-8661-4772-b0f6-e9ef89a7522d"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("902f2b4e-e843-4a0b-b6ab-3967c36c8950"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("a5d7437b-4d07-4500-b6c0-3c683be55c89"));
            EntryActionType = (ITTTextBoxColumn)AddControl(new Guid("930e5054-0baa-48a5-a39c-ef860711db36"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("00d30ee9-6dcb-4f6a-9c73-276c0f871dd5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("27b50c93-817e-46de-b304-23470e5bcddf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cc903bf5-835f-4196-9523-4a4c00a20c6a"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("c0d7b403-4740-4e99-b0ac-e3f560d3f163"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("8175f771-acfe-428b-a854-2bf9156c7012"));
            PatientRoom = (ITTObjectListBox)AddControl(new Guid("56e05879-1351-4943-a708-31ac647bc2b6"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("5e16573e-bf37-4564-b718-c75919fb3fdf"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("d8763c01-e095-42ec-a562-bb34297df167"));
            PatientClinic = (ITTObjectListBox)AddControl(new Guid("9dabb7c2-cfe7-4565-b8e4-eabcd5927497"));
            PatientSexEnum = (ITTEnumComboBox)AddControl(new Guid("bf4df5e8-0b26-4452-860b-19edeed728f2"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("e705f755-a68c-4c76-816c-31f2650673c1"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("680726ff-eb56-4407-8b70-b98e63550ef3"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("0070a9fd-e020-44f2-887f-7ee341a13134"));
            RepeatReason = (ITTObjectListBox)AddControl(new Guid("d719c503-f412-4ea8-ae3f-197bab6cc06c"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("4c543b8d-9b00-4bf2-a970-9e39288cd252"));
            cmdPrintBarcode = (ITTButton)AddControl(new Guid("bfa928e2-d2ee-4a1d-8d09-acb3600de885"));
            GridEquipments = (ITTGrid)AddControl(new Guid("773f9179-9ef6-426c-90c9-90d8ef561f57"));
            Equipment = (ITTListBoxColumn)AddControl(new Guid("afbb051d-8cb8-4f54-a869-5c0783b6c78a"));
            TabTests = (ITTTabControl)AddControl(new Guid("a9cb6fb1-f0d5-47fc-a9ed-bd6ad66fa6b5"));
            TabPageTests = (ITTTabPage)AddControl(new Guid("61c9cdfd-b10c-4dfe-b80c-56ee27b5b38d"));
            grdGeneticTests = (ITTGrid)AddControl(new Guid("c45f9ddc-64dd-44c6-b137-238715ed384a"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("a6485478-26b3-4585-b8dd-1ce648282000"));
            TestAmount = (ITTTextBoxColumn)AddControl(new Guid("3576f0c6-9f4d-47d5-ba12-383de3a62cca"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("218ef6bf-ac0f-45db-b4e1-fdb6b78df353"));
            GridGeneticMaterials = (ITTGrid)AddControl(new Guid("46d9da7e-89b9-4208-8b67-17bae40ea5b2"));
            MACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("f18160e1-e3a8-44f9-b94e-b65515d5703c"));
            MATERIAL = (ITTListBoxColumn)AddControl(new Guid("a8445511-078d-408c-a131-e5aa2c2a8e00"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("a0b1675c-04d9-440b-8c5e-d020778a5175"));
            AMOUNT = (ITTTextBoxColumn)AddControl(new Guid("dcce58f3-374a-4dfa-9f66-5f3a94e39de7"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("996112f1-dd24-4045-b852-bfcdeb2c973d"));
            base.InitializeControls();
        }

        public GeneticAnalysisForm() : base("GENETIC", "GeneticAnalysisForm")
        {
        }

        protected GeneticAnalysisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}