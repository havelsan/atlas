
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
    /// Yatan Hasta Reçetesi
    /// </summary>
    public partial class InpatientPrescriptionInfectionApprovalForm : InpatientPrescriptionBaseForm
    {
    /// <summary>
    /// Yatan Hasta Reçetesi
    /// </summary>
        protected TTObjectClasses.InpatientPrescription _InpatientPrescription
        {
            get { return (TTObjectClasses.InpatientPrescription)_ttObject; }
        }

        protected ITTButton cmdUpdate;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage DiagTabPage;
        protected ITTGrid SPTSDiagnosises;
        protected ITTTextBoxColumn CodeDiagnosisForPresc;
        protected ITTTextBoxColumn NameDiagnosisForPresc;
        protected ITTTabPage EReceteTabPage;
        protected ITTTextBox EReceteDescription;
        protected ITTLabel ttlabel3;
        protected ITTTextBox EReceteNo;
        protected ITTLabel labelEReceteNo;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage InfectionTabPage;
        protected ITTGrid InfectionApprovalDrugOrder;
        protected ITTListBoxColumn InpatientDrugOrderInfectionApprovalDrugOrder;
        protected ITTEnumComboBoxColumn FrequencyInfectionApprovalDrugOrder;
        protected ITTTextBoxColumn DoseAmountInfectionApprovalDrugOrder;
        protected ITTTextBoxColumn DayInfectionApprovalDrugOrder;
        protected ITTTextBoxColumn PackageAmountInfectionApprovalDrugOrder;
        protected ITTTextBoxColumn UsageNoteInfectionApprovalDrugOrder;
        protected ITTTabPage DrugTabPage;
        protected ITTGrid InpatientDrugOrders;
        protected ITTListBoxColumn Drug;
        protected ITTEnumComboBoxColumn Frequency;
        protected ITTTextBoxColumn DoseAmount;
        protected ITTTextBoxColumn Day;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UsageNote;
        protected ITTEnumComboBoxColumn DescriptionType;
        protected ITTTextBoxColumn Description;
        protected ITTTextBox QuarantineProtocolNo;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ID;
        protected ITTTextBox PatientFullName;
        protected ITTLabel labelPatientGroup;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox FromResource;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelID;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelMasterResource;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelQuarantineProtocolNo;
        protected ITTLabel labelReasonForAdmission;
        protected ITTEnumComboBox PrescriptionType;
        protected ITTLabel labelPrescriptionType;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox PrescriptionPaper;
        protected ITTLabel labelPrescriptionNO;
        override protected void InitializeControls()
        {
            cmdUpdate = (ITTButton)AddControl(new Guid("f2dddc9d-51fc-4ba1-9020-615fe49bc2e4"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("f40286ce-6edb-47ad-9274-6f098e270f68"));
            DiagTabPage = (ITTTabPage)AddControl(new Guid("13d6b2c4-c7d0-4746-a150-354950050c39"));
            SPTSDiagnosises = (ITTGrid)AddControl(new Guid("71774d11-870a-43f2-b333-14f6090f7c03"));
            CodeDiagnosisForPresc = (ITTTextBoxColumn)AddControl(new Guid("61ca726a-3ece-4a47-bd75-72168138af6d"));
            NameDiagnosisForPresc = (ITTTextBoxColumn)AddControl(new Guid("a7b0f626-fddc-4de4-b9e9-e7f6191d9b93"));
            EReceteTabPage = (ITTTabPage)AddControl(new Guid("577d765f-17a7-47aa-b618-e8d6d022ddd0"));
            EReceteDescription = (ITTTextBox)AddControl(new Guid("473e9482-3291-4475-a371-5e715428539f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("fa560b07-ce01-4946-b9e2-019441351062"));
            EReceteNo = (ITTTextBox)AddControl(new Guid("578ada3a-100a-4de8-a549-5460b7fa8382"));
            labelEReceteNo = (ITTLabel)AddControl(new Guid("a9651651-d15b-4c28-ae04-27223c6ba013"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("46e2ff79-ccfd-440d-9287-990a88d87114"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ed902f3c-5a93-425c-b50b-7d75e0bd6c71"));
            InfectionTabPage = (ITTTabPage)AddControl(new Guid("8686aa46-b553-49a2-af0a-1748d7f32dc7"));
            InfectionApprovalDrugOrder = (ITTGrid)AddControl(new Guid("d57e6a5b-fd22-4fd9-94ee-383f8bb82518"));
            InpatientDrugOrderInfectionApprovalDrugOrder = (ITTListBoxColumn)AddControl(new Guid("e41c2802-7a65-44c6-96e8-551b6b2557f9"));
            FrequencyInfectionApprovalDrugOrder = (ITTEnumComboBoxColumn)AddControl(new Guid("e2ef8433-72a3-40ba-aa0f-e2aea9bc588d"));
            DoseAmountInfectionApprovalDrugOrder = (ITTTextBoxColumn)AddControl(new Guid("d9c757ab-c2ed-4411-b987-f5c743d92763"));
            DayInfectionApprovalDrugOrder = (ITTTextBoxColumn)AddControl(new Guid("7dc9dc23-aca5-4a50-b4e6-d129a380ca86"));
            PackageAmountInfectionApprovalDrugOrder = (ITTTextBoxColumn)AddControl(new Guid("1a4c5c05-8ec0-422c-9782-0c230dd72604"));
            UsageNoteInfectionApprovalDrugOrder = (ITTTextBoxColumn)AddControl(new Guid("736481e2-1c55-4f36-a00a-9989c7207009"));
            DrugTabPage = (ITTTabPage)AddControl(new Guid("558bfbc8-e78e-495d-a180-2e0fa7b91ed9"));
            InpatientDrugOrders = (ITTGrid)AddControl(new Guid("e6e9b4ce-108e-4274-bd97-121ecfc0bcef"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("71d1af51-df78-4c97-8ebf-098d985b22be"));
            Frequency = (ITTEnumComboBoxColumn)AddControl(new Guid("2872cff1-062f-4371-a108-725b270d098c"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("5fd4389f-e754-4d42-842e-ab6d3bf1bf3c"));
            Day = (ITTTextBoxColumn)AddControl(new Guid("8e7cbdac-d085-459b-873f-cadd0a6ea13c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("46adef73-b532-4837-8907-2d29e77553ae"));
            UsageNote = (ITTTextBoxColumn)AddControl(new Guid("c5b74171-08cc-458c-8d50-1e400d95a836"));
            DescriptionType = (ITTEnumComboBoxColumn)AddControl(new Guid("5b0bd3f4-2f76-49b2-8946-6f403e2996f4"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("fdae4c34-76b7-4116-bc40-aa9248c636ce"));
            QuarantineProtocolNo = (ITTTextBox)AddControl(new Guid("3841d132-9622-4321-a4a9-de5187ab9445"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("1ca6537c-d585-48f7-8e76-b28714f0008d"));
            ID = (ITTTextBox)AddControl(new Guid("f244606f-86a9-4657-b80a-505a7c88e82c"));
            PatientFullName = (ITTTextBox)AddControl(new Guid("760c9542-5b21-4391-b140-34280ce51e85"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("e45858ab-932b-4028-9652-5eb1451cb78d"));
            labelActionDate = (ITTLabel)AddControl(new Guid("95244d45-0d5e-4eb0-a9f5-ae6319b7095d"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("7a367c75-8acd-4fff-8773-55eb3e1ac312"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("1be33713-a2cc-44b7-ad1c-b388803a39c7"));
            labelID = (ITTLabel)AddControl(new Guid("320ec299-b42c-4983-9307-b3c7fd29bbe2"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("19250cbf-bf97-4dab-8f71-90effd946ae5"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("85a5c651-da72-4aee-b726-312dc7e0534e"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("fdd200d1-4859-4555-8c65-b4819d0449a1"));
            labelQuarantineProtocolNo = (ITTLabel)AddControl(new Guid("6f158bf3-34d4-45fc-87df-a027dfd00fe8"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("7e9c9c40-aaaa-4b32-9838-7cf5bd1fabb7"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("6e6a3a93-f7ad-4833-8b48-d11fd11ff722"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("5f5c00ec-90ca-4e8e-8399-3e52af6d580c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("38aae54b-d095-4682-a4a1-9dbe57bd0ab0"));
            PrescriptionPaper = (ITTObjectListBox)AddControl(new Guid("60fe7738-fcf4-4ae2-b88f-076785575d20"));
            labelPrescriptionNO = (ITTLabel)AddControl(new Guid("56407ee9-7b44-4d06-8bbd-011aa847f8f2"));
            base.InitializeControls();
        }

        public InpatientPrescriptionInfectionApprovalForm() : base("INPATIENTPRESCRIPTION", "InpatientPrescriptionInfectionApprovalForm")
        {
        }

        protected InpatientPrescriptionInfectionApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}