
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
    /// Ayaktan Hasta Reçetesi
    /// </summary>
    public partial class OutPatientPrescriptionApprovalForm : OutPatientPrescriptionBaseForm
    {
    /// <summary>
    /// Ayaktan Hasta Reçetesi
    /// </summary>
        protected TTObjectClasses.OutPatientPrescription _OutPatientPrescription
        {
            get { return (TTObjectClasses.OutPatientPrescription)_ttObject; }
        }

        protected ITTTextBox ProtocolNoSubEpisode;
        protected ITTTextBox PatientFullName;
        protected ITTLabel labelProtocolNoSubEpisode;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage DrugTabPage;
        protected ITTGrid OutPatientDrugOrders;
        protected ITTButtonColumn cmdChangeDrug;
        protected ITTButtonColumn cmdChangeDrugFull;
        protected ITTButtonColumn cmdSelectBarcodeLevel;
        protected ITTListBoxColumn PhysicianDrug;
        protected ITTListBoxColumn Drug;
        protected ITTTextBoxColumn BarcodeLevel;
        protected ITTEnumComboBoxColumn Frequency;
        protected ITTTextBoxColumn DoseAmount;
        protected ITTTextBoxColumn Day;
        protected ITTTextBoxColumn RequiredAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn PackageAmount;
        protected ITTTextBoxColumn StoreInheld;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Price;
        protected ITTTextBoxColumn ReceivedPrice;
        protected ITTTextBoxColumn UsageNote;
        protected ITTCheckBoxColumn Report;
        protected ITTCheckBoxColumn TenDaily;
        protected ITTEnumComboBoxColumn DrugSupply;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelID;
        protected ITTLabel labelReasonForAdmission;
        protected ITTEnumComboBox PrescriptionType;
        protected ITTLabel labelPrescriptionType;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel labelPatientGroup;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage1;
        protected ITTGrid SPTSDiagnosises;
        protected ITTTextBoxColumn Code;
        protected ITTTextBoxColumn Name;
        protected ITTTabPage tttabpage2;
        protected ITTGrid SPTSDiagnosisInfos;
        protected ITTListBoxColumn Diagnose;
        protected ITTTabPage tttabpage3;
        protected ITTTextBox DiscriptionOfPharmacist;
        protected ITTCheckBox Emergency;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ProtocolNoSubEpisode = (ITTTextBox)AddControl(new Guid("71c3726c-936f-4417-819e-62ad368a1e31"));
            PatientFullName = (ITTTextBox)AddControl(new Guid("216ed5a8-4635-4598-8e11-f524e8064c1b"));
            labelProtocolNoSubEpisode = (ITTLabel)AddControl(new Guid("a202f338-f225-429d-afb8-01587c4b5b9c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("9fba23f7-2944-4151-b0e2-eb4460ef084e"));
            DrugTabPage = (ITTTabPage)AddControl(new Guid("9bec5a3d-03d5-4f17-b103-379a1c450a35"));
            OutPatientDrugOrders = (ITTGrid)AddControl(new Guid("bc406f9f-9d6f-40a3-97fe-423c003858db"));
            cmdChangeDrug = (ITTButtonColumn)AddControl(new Guid("ad9d6e64-daf1-4010-a4e5-2fce89a1c07b"));
            cmdChangeDrugFull = (ITTButtonColumn)AddControl(new Guid("a4d810ee-9abb-4ca0-9003-86baf703127b"));
            cmdSelectBarcodeLevel = (ITTButtonColumn)AddControl(new Guid("14cf2110-f837-4747-b1d8-892f733b0ea7"));
            PhysicianDrug = (ITTListBoxColumn)AddControl(new Guid("a160288e-c1c7-440f-93a1-1b23433dc88b"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("7786381a-5c48-481c-bff3-fe12419852b2"));
            BarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("5c14522b-8456-4fe5-9bf3-c96c2117abad"));
            Frequency = (ITTEnumComboBoxColumn)AddControl(new Guid("49e211ee-989b-4c35-957b-a07a5fcc537b"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("c94355f7-6b37-4fa7-8d68-314395a3477d"));
            Day = (ITTTextBoxColumn)AddControl(new Guid("34b79361-2327-4f94-bd57-416aa80d4e89"));
            RequiredAmount = (ITTTextBoxColumn)AddControl(new Guid("26553f0c-19eb-49e1-8ea8-78b283ec4aab"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("5c52cdef-3430-4cb2-b0e1-f17d4a2396a1"));
            PackageAmount = (ITTTextBoxColumn)AddControl(new Guid("bea7cca4-ee34-426d-9908-735be0772778"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("a9358ae5-0e69-44c4-bfeb-d8cec65da81e"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("415bcae7-29b9-4ebd-9c54-72999985e939"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("dd3a7942-02ac-42f4-b924-ac0707345e16"));
            ReceivedPrice = (ITTTextBoxColumn)AddControl(new Guid("a3666e53-1ea3-4f92-b9ad-a751984be22a"));
            UsageNote = (ITTTextBoxColumn)AddControl(new Guid("e857a3b5-4ff7-41ad-8b9b-804c54de68d1"));
            Report = (ITTCheckBoxColumn)AddControl(new Guid("cd7479a9-3e7d-4807-92c8-7f8cc4115a21"));
            TenDaily = (ITTCheckBoxColumn)AddControl(new Guid("d0c8b6b6-c734-48fc-9d23-3a9df6f70039"));
            DrugSupply = (ITTEnumComboBoxColumn)AddControl(new Guid("5847c90d-732d-4348-89c0-dc3224d005b8"));
            ID = (ITTTextBox)AddControl(new Guid("f01db2f7-73a0-4be1-a36d-be7e3b444b37"));
            labelActionDate = (ITTLabel)AddControl(new Guid("a1bd8cac-5f85-4e49-871f-1b3432dc7bd1"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("5d60e074-a454-480a-99a6-5fb7f20ff7a7"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("460d435e-ac43-4e87-9234-72304a6e8f07"));
            labelID = (ITTLabel)AddControl(new Guid("bfc8715e-505c-44a4-8ba8-99461be436d7"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("993ed452-99f6-4555-be27-e4850f3bfe80"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("c064bdba-58ca-441a-ae62-cd5c7a68a456"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("14aa0230-6f43-4c1d-a91b-ed4656d1bdd3"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("7253f3ee-3eac-4fc8-bad9-c375a566471e"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("08459e64-f764-4599-b664-18de32787197"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("e5bf6462-f39c-4799-a2aa-ab8a72541037"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("18d1328e-2ea3-47de-aca2-43af137f8e02"));
            SPTSDiagnosises = (ITTGrid)AddControl(new Guid("5971b318-797d-45b4-9e64-69f475b0b308"));
            Code = (ITTTextBoxColumn)AddControl(new Guid("196e3387-7353-4f44-b3f8-fe86b1eab5dd"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("f8524eee-c068-48da-ae1a-900059ad48ce"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("225d9b69-0e51-4b9b-9dd1-70adca553aff"));
            SPTSDiagnosisInfos = (ITTGrid)AddControl(new Guid("3411534a-2494-4f29-a7e4-22b7a1f5d533"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("77bbda8d-0f71-4461-a3a5-3d29764ccf84"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("2d62cd4a-0242-4fc5-8e3a-f116cc741106"));
            DiscriptionOfPharmacist = (ITTTextBox)AddControl(new Guid("20b6229d-7f50-4828-a53e-e478be50ddfa"));
            Emergency = (ITTCheckBox)AddControl(new Guid("9a4d4e3c-598c-4e2f-9ddf-d2594e898855"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9113f40b-f0f8-477a-9cf2-d414b463cd84"));
            base.InitializeControls();
        }

        public OutPatientPrescriptionApprovalForm() : base("OUTPATIENTPRESCRIPTION", "OutPatientPrescriptionApprovalForm")
        {
        }

        protected OutPatientPrescriptionApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}