
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
    /// Tıbbi Genetik Tamamlandı Formu
    /// </summary>
    public partial class GeneticCompletedForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Genetik İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Genetic _Genetic
        {
            get { return (TTObjectClasses.Genetic)_ttObject; }
        }

        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTTextBoxColumn EntryActionType;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox TestToStudyTTListBox;
        protected ITTRichTextBoxControl ReportRTF;
        protected ITTCheckBox ttcheckbox1;
        protected ITTTabControl TabTextInfos;
        protected ITTTabPage TabPageRequestDesc;
        protected ITTTextBox RequestDescription;
        protected ITTTabPage TabPagePrediagnosis;
        protected ITTTextBox PreDiagnosis;
        protected ITTTabPage TabPageDescription;
        protected ITTTextBox Description;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox ApprovementDescription;
        protected ITTTabPage TabPageHidden;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel15;
        protected ITTObjectListBox RepeatReason;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox RejectReason;
        protected ITTLabel ttlabel3;
        protected ITTTextBox MaterialResponsible;
        protected ITTLabel ttlabel8;
        protected ITTTabControl TabTests;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridGeneticMaterials;
        protected ITTDateTimePickerColumn MACTIONDATE;
        protected ITTListBoxColumn MATERIAL;
        protected ITTTextBoxColumn AMOUNT;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTabPage TabPageEquipment;
        protected ITTGrid GridEquipments;
        protected ITTListBoxColumn Equipment;
        protected ITTTextBox SendenMaterial;
        protected ITTTextBox PatientAge;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox RequestDoctor;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox PatientRoom;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox PatientClinic;
        protected ITTEnumComboBox PatientSexEnum;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel13;
        protected ITTGrid grdGeneticTests;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTLabel ttlabel11;
        protected ITTObjectListBox ApprovedBy;
        override protected void InitializeControls()
        {
            GridDiagnosis = (ITTGrid)AddControl(new Guid("08a43695-c700-49bb-89af-323b96f0a805"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9353b8b0-d70d-4f23-9c5b-6a2e52aad580"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("d3aebead-bf53-4165-90cf-22db1dc9f63a"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("28d55631-6738-42d6-abae-29e561f0afd5"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("aa0039a7-bc3b-43c4-9264-9610b00f4668"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("810b93f9-2f68-419e-a7d7-deb1850e8ea2"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("5cdc01e5-d000-42cc-9a16-eebd3c05f399"));
            EntryActionType = (ITTTextBoxColumn)AddControl(new Guid("4c70f3af-8aab-4311-a286-c0b776fb0347"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("198c8af4-996d-4297-b507-80ad233d4ba9"));
            TestToStudyTTListBox = (ITTObjectListBox)AddControl(new Guid("57844cde-9764-4ede-8b37-135aa436c893"));
            ReportRTF = (ITTRichTextBoxControl)AddControl(new Guid("453c0d55-75ad-40a2-bb86-93c80e45d8dd"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("60b943b5-2e22-4243-8872-c6e1dc46f7aa"));
            TabTextInfos = (ITTTabControl)AddControl(new Guid("2e1ebcca-c811-4c1d-96e7-01544b7e9ebe"));
            TabPageRequestDesc = (ITTTabPage)AddControl(new Guid("ce576749-ea0a-4f1a-9362-1f3cc262e268"));
            RequestDescription = (ITTTextBox)AddControl(new Guid("96902241-f4b6-49a1-a388-761132ba0855"));
            TabPagePrediagnosis = (ITTTabPage)AddControl(new Guid("9c7c8ad7-c37b-4abc-a96a-c8677686516d"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("c40e0be2-b9e3-4d30-b594-246776b46f69"));
            TabPageDescription = (ITTTabPage)AddControl(new Guid("5c5ab845-a1be-4500-b934-a0f4ab06902f"));
            Description = (ITTTextBox)AddControl(new Guid("8393ad1f-708e-4e1d-8bc8-f78a5e7d80e7"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("b2c07e93-d9c0-4a7f-9655-2c55107ddb0e"));
            ApprovementDescription = (ITTTextBox)AddControl(new Guid("197ad147-7856-4745-902c-ad29cd437dae"));
            TabPageHidden = (ITTTabPage)AddControl(new Guid("c56ff5b3-7bf9-4b50-8b93-ed1392b5756f"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("f46399df-5940-4d1e-a664-00d877ff65c4"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("68281031-a175-4673-bebc-093daa0af5bf"));
            RepeatReason = (ITTObjectListBox)AddControl(new Guid("f50ac5ac-c6c9-4596-8f20-33b8a8e33fac"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("5b167743-0819-48b7-99b8-c5b8674b03da"));
            RejectReason = (ITTObjectListBox)AddControl(new Guid("20170ca6-5dc6-4490-b0d0-661f64018dcf"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d761bae3-dda2-4a03-8f5f-ddb7e4e852db"));
            MaterialResponsible = (ITTTextBox)AddControl(new Guid("ec1a7735-d86f-45c4-b2e1-f3a31acc6c7e"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("7ada4a52-1297-4493-810b-639b760d2946"));
            TabTests = (ITTTabControl)AddControl(new Guid("b9608853-d4ce-436f-93ad-9ba1bc231b1d"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("d61dddd5-90bc-4118-9528-7b5ecbd40950"));
            GridGeneticMaterials = (ITTGrid)AddControl(new Guid("a1264cd8-f410-453f-8e7b-482c729f158e"));
            MACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("b7f2b28d-ffcd-40fa-9fda-63d16fc44a79"));
            MATERIAL = (ITTListBoxColumn)AddControl(new Guid("e574c19f-839b-4b53-9ba7-9b8dc2439938"));
            AMOUNT = (ITTTextBoxColumn)AddControl(new Guid("1914134e-c610-4ee6-b61c-2e3dce725fab"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("ed260787-37a7-4587-8683-4acfe52e65ee"));
            TabPageEquipment = (ITTTabPage)AddControl(new Guid("8eb13d95-b3ce-4db9-9fc1-c23a122d4ffa"));
            GridEquipments = (ITTGrid)AddControl(new Guid("fa2e5bf0-c065-4b90-aa5e-e29dfdb376ce"));
            Equipment = (ITTListBoxColumn)AddControl(new Guid("78e14bc3-5093-4358-9b28-ba3bdb43b994"));
            SendenMaterial = (ITTTextBox)AddControl(new Guid("e2d24144-128c-4078-9c46-0a084b9efaea"));
            PatientAge = (ITTTextBox)AddControl(new Guid("997821fd-bbf8-4b6a-87bf-8e76b0a67c4d"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("030a140a-900d-424b-b13a-50e07478ccae"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("9a3a18a4-b43c-4c22-9aa7-6f56b4b959eb"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("9a4913a0-0e96-4e28-838f-8b6c5d486df3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e806453b-bab1-44d9-babe-4eece77a9eee"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("77dc2434-6c77-45c5-b1ac-940112a66937"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("31a982b9-814f-4472-98c2-145365bb1ce0"));
            PatientRoom = (ITTObjectListBox)AddControl(new Guid("4d540eb0-2916-4fa6-a258-94ca3fa67ea6"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("9c85ea66-e470-46e6-a8bc-813a80fdf84c"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("2db5e890-5463-46c0-834e-26ada8b02cb6"));
            PatientClinic = (ITTObjectListBox)AddControl(new Guid("30c1cfec-b823-432c-ab19-7bda71a2d963"));
            PatientSexEnum = (ITTEnumComboBox)AddControl(new Guid("02a48da7-7df7-4397-adff-986522ff77b9"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("aa5229b9-1a41-42a3-aa00-9eb83150b328"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2de554ff-3dbb-4b05-815e-780618627839"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("a9b90614-c949-4fac-aff8-f13cb153a458"));
            grdGeneticTests = (ITTGrid)AddControl(new Guid("ac2d15aa-206c-4176-8f0d-80f10e39f86f"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("68c9bf1e-d07e-4298-8714-364492ab331b"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("24cc3c0a-be0c-4894-acd4-8b6a4c9a40cd"));
            ApprovedBy = (ITTObjectListBox)AddControl(new Guid("7d694404-cc72-4a41-9179-6808d0ae5861"));
            base.InitializeControls();
        }

        public GeneticCompletedForm() : base("GENETIC", "GeneticCompletedForm")
        {
        }

        protected GeneticCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}