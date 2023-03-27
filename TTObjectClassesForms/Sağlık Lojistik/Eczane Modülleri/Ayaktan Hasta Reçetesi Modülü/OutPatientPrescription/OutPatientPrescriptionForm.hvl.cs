
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
    public partial class OutPatientPrescriptionForm : OutPatientPrescriptionBaseForm
    {
    /// <summary>
    /// Ayaktan Hasta Reçetesi
    /// </summary>
        protected TTObjectClasses.OutPatientPrescription _OutPatientPrescription
        {
            get { return (TTObjectClasses.OutPatientPrescription)_ttObject; }
        }

        protected ITTButton SendESignedPrescription;
        protected ITTButton cmdAddTemplate;
        protected ITTButton cmdGetTemplate;
        protected ITTButton cmdGetFavoriteDrugs;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage DrugTabPage;
        protected ITTGrid OutPatientDrugOrders;
        protected ITTListBoxColumn PhysicianDrug;
        protected ITTButtonColumn cmdSelectBarcodeLevel;
        protected ITTEnumComboBoxColumn Frequency;
        protected ITTTextBoxColumn DoseAmount;
        protected ITTEnumComboBoxColumn PeriodUnitType;
        protected ITTTextBoxColumn Day;
        protected ITTTextBoxColumn PackageAmount;
        protected ITTEnumComboBoxColumn DrugUsageType;
        protected ITTEnumComboBoxColumn DescriptionType;
        protected ITTTextBoxColumn Description;
        protected ITTTextBoxColumn TreatmentTime;
        protected ITTTextBoxColumn RequiredAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Price;
        protected ITTTextBoxColumn ReceivedPrice;
        protected ITTTextBoxColumn UsageNote;
        protected ITTListBoxColumn Drug;
        protected ITTButtonColumn IlacEtkinMadde;
        protected ITTButtonColumn SUTRules;
        protected ITTLabel ttlabel3;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage1;
        protected ITTButton cmdAddDiagnosis;
        protected ITTLabel labelPrescriptionPaper;
        protected ITTGrid SPTSDiagnosises;
        protected ITTCheckBoxColumn CheckDiagnosisForPresc;
        protected ITTTextBoxColumn CodeDiagnosisForPresc;
        protected ITTTextBoxColumn NameDiagnosisForPresc;
        protected ITTObjectListBox PrescriptionPaper;
        protected ITTButton cmdChangeSpeciality;
        protected ITTLabel labelSpecialityDefinition;
        protected ITTObjectListBox SpecialityDefinition;
        protected ITTTextBox ID;
        protected ITTLabel labelEReceteNo;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox Emergency;
        protected ITTTextBox EReceteNo;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTTextBox PatientFullName;
        protected ITTEnumComboBox PrescriptionType;
        protected ITTLabel labelPrescriptionType;
        protected ITTTabPage tttabpage2;
        protected ITTListView FavoriteDrugListview;
        protected ITTTabPage tttabpage3;
        protected ITTTextBox EReceteDescription;
        protected ITTTabPage tttabpage4;
        protected ITTTextBox DiscriptionOfPharmacist;
        protected ITTListView DrugListview;
        protected ITTTextBox SearchTextbox;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            SendESignedPrescription = (ITTButton)AddControl(new Guid("3c579d5a-8fae-4c2c-adec-1b01ea0c48ad"));
            cmdAddTemplate = (ITTButton)AddControl(new Guid("4e09d967-35bd-427d-b80c-a7a10a8cda0f"));
            cmdGetTemplate = (ITTButton)AddControl(new Guid("c0278eb5-7d5a-4199-83f8-a5cd724611cf"));
            cmdGetFavoriteDrugs = (ITTButton)AddControl(new Guid("3c5f1bff-2538-4c66-aaff-7dc54c191d9f"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("003651b1-1ae4-4c82-963e-79e0e90bfc77"));
            DrugTabPage = (ITTTabPage)AddControl(new Guid("b1efe09b-b2e1-4c43-ac88-b8efbfc41167"));
            OutPatientDrugOrders = (ITTGrid)AddControl(new Guid("76a30167-34bf-47c8-bc8d-7c1cf33a53ce"));
            PhysicianDrug = (ITTListBoxColumn)AddControl(new Guid("2fa112d2-6c5c-449a-8fbd-185e3e529566"));
            cmdSelectBarcodeLevel = (ITTButtonColumn)AddControl(new Guid("70d79815-e433-4249-a7fe-cf006f487821"));
            Frequency = (ITTEnumComboBoxColumn)AddControl(new Guid("5478cab8-ca1f-436d-83ce-d13a51980c81"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("504e067e-1205-4b4d-ad28-a9c63ea3c0bb"));
            PeriodUnitType = (ITTEnumComboBoxColumn)AddControl(new Guid("5c5eb036-0e85-4221-bf8f-807a986f176f"));
            Day = (ITTTextBoxColumn)AddControl(new Guid("fe6aa339-ddfb-41a3-be7e-ae5a4a234411"));
            PackageAmount = (ITTTextBoxColumn)AddControl(new Guid("f71a3bd7-b3c9-4907-a13a-b58a95a59644"));
            DrugUsageType = (ITTEnumComboBoxColumn)AddControl(new Guid("d9ea5d58-39f9-43a7-96b8-c87244f030fc"));
            DescriptionType = (ITTEnumComboBoxColumn)AddControl(new Guid("244964a9-6f03-44fc-8fd7-c88958fc8b0a"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("93bde78b-2714-4025-8625-b442c48fac2d"));
            TreatmentTime = (ITTTextBoxColumn)AddControl(new Guid("946b59aa-52b5-4480-94aa-505d1cd648ef"));
            RequiredAmount = (ITTTextBoxColumn)AddControl(new Guid("2d9af874-244d-4698-aefe-810bfbd723e8"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("8ed2f318-643e-4827-8ab4-b5be914c5c54"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("949e6fea-7b0d-4fb4-b122-0bdcfb0be4d9"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("a590730a-0f24-43e0-b0f9-733953bef91d"));
            ReceivedPrice = (ITTTextBoxColumn)AddControl(new Guid("c206a5e4-5050-4f4e-bd72-342cd31fdf02"));
            UsageNote = (ITTTextBoxColumn)AddControl(new Guid("19c7362e-f2d1-4b0a-8c0a-7e62af1aba5c"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("dec26fcb-ab3d-427a-a3fe-c13d0c32279f"));
            IlacEtkinMadde = (ITTButtonColumn)AddControl(new Guid("53a03999-ba59-47ac-958b-71bf218a33bd"));
            SUTRules = (ITTButtonColumn)AddControl(new Guid("2109b6b1-41ef-4fd1-8089-bfb8a33f3abd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1fa5e146-2812-4084-b763-cdfed8b7a2c5"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("4ad3e3bb-2e92-4d51-9e39-e7b1a8e39941"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("f27c3121-0da7-469c-a2e0-5f7fef89130e"));
            cmdAddDiagnosis = (ITTButton)AddControl(new Guid("8fb85079-616e-478d-8c24-68e6e71ff3b5"));
            labelPrescriptionPaper = (ITTLabel)AddControl(new Guid("511be9a0-e40a-40bd-b700-614721893e44"));
            SPTSDiagnosises = (ITTGrid)AddControl(new Guid("04012b0a-85fc-4729-89ae-9b76d7000cdc"));
            CheckDiagnosisForPresc = (ITTCheckBoxColumn)AddControl(new Guid("8c91984a-233f-4e33-99ad-ce77111426d9"));
            CodeDiagnosisForPresc = (ITTTextBoxColumn)AddControl(new Guid("cf971ed6-11d0-4cb8-92c2-a39f139572b9"));
            NameDiagnosisForPresc = (ITTTextBoxColumn)AddControl(new Guid("6afc3a73-8843-44cb-ae84-fe394bcab9ec"));
            PrescriptionPaper = (ITTObjectListBox)AddControl(new Guid("cd0a23ee-0e23-4f5b-a453-ef38a46a0ddd"));
            cmdChangeSpeciality = (ITTButton)AddControl(new Guid("0541f2e7-1438-474e-89f1-7bbaa056dd29"));
            labelSpecialityDefinition = (ITTLabel)AddControl(new Guid("4bf094ec-eb2a-4b4e-88de-223c4febb834"));
            SpecialityDefinition = (ITTObjectListBox)AddControl(new Guid("ac8bf355-25b0-4287-b1a0-97b309851c61"));
            ID = (ITTTextBox)AddControl(new Guid("467c6390-7cbb-496a-9e61-15a8f6f8d271"));
            labelEReceteNo = (ITTLabel)AddControl(new Guid("7fa721da-be1d-4bf3-ba1b-bec819cb4040"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8510d2c1-784b-4808-b65e-a6aff753a838"));
            Emergency = (ITTCheckBox)AddControl(new Guid("cb1b0e70-6266-4eda-adde-4e8e7306f350"));
            EReceteNo = (ITTTextBox)AddControl(new Guid("474508a7-104d-4879-aa1e-5a4118c6c03d"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("7b7e2a75-0dc8-4f2e-b366-a5088c0b173f"));
            labelID = (ITTLabel)AddControl(new Guid("3fda5e8f-adad-4a8a-ae40-7bd01fb27eeb"));
            labelActionDate = (ITTLabel)AddControl(new Guid("217d2826-e337-4e7f-b30c-08f4f04fd8e2"));
            PatientFullName = (ITTTextBox)AddControl(new Guid("965cdf85-c8e3-4e03-bfad-db0b0b9554b9"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("2f0c3d1a-f068-48ae-a4f8-840f9257b118"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("d191e8ab-7ced-44fb-a5d8-ea7e4dff96e0"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("4368c629-1d86-4395-a813-8ccf710f566d"));
            FavoriteDrugListview = (ITTListView)AddControl(new Guid("be79e2e7-55c2-4416-a95c-1c386131af47"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("0c9d1ed1-d2b1-4d6f-b023-eef4a5ad869d"));
            EReceteDescription = (ITTTextBox)AddControl(new Guid("18f30185-626a-423a-93ef-302055c88d8c"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("b73f8700-fbec-4196-9c3f-433d7772dbc0"));
            DiscriptionOfPharmacist = (ITTTextBox)AddControl(new Guid("b66d0bc3-0115-4ce3-ace2-9938a7fe6cf7"));
            DrugListview = (ITTListView)AddControl(new Guid("cf389e52-f269-43aa-9815-0f1c01ecaa97"));
            SearchTextbox = (ITTTextBox)AddControl(new Guid("80084a81-f2c2-407f-ada3-c989d6f24b89"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3767ffd7-5e12-472b-9d07-e9f5cad87853"));
            base.InitializeControls();
        }

        public OutPatientPrescriptionForm() : base("OUTPATIENTPRESCRIPTION", "OutPatientPrescriptionForm")
        {
        }

        protected OutPatientPrescriptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}