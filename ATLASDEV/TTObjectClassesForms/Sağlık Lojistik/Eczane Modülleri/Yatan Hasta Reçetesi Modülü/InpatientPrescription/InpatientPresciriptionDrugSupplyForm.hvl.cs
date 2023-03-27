
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
    public partial class InpatientPresciriptionDrugSupplyForm : InpatientPrescriptionBaseForm
    {
    /// <summary>
    /// Yatan Hasta Reçetesi
    /// </summary>
        protected TTObjectClasses.InpatientPrescription _InpatientPrescription
        {
            get { return (TTObjectClasses.InpatientPrescription)_ttObject; }
        }

        protected ITTLabel labelDistributioınNo;
        protected ITTTextBox DistributionNo;
        protected ITTTextBox EReceteNo;
        protected ITTTextBox tttextbox1;
        protected ITTButton btnEReceteNoInQuiry;
        protected ITTLabel labelEReceteNo;
        protected ITTLabel ttlabel1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid InpatientDrugOrders;
        protected ITTListBoxColumn Drug;
        protected ITTTextBoxColumn BarcodeLevel;
        protected ITTEnumComboBoxColumn Frequency;
        protected ITTTextBoxColumn DoseAmount;
        protected ITTTextBoxColumn Day;
        protected ITTTextBoxColumn PackageAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UsageNote;
        protected ITTStateComboBoxColumn State;
        protected ITTButtonColumn cmdSelectBarcodeLevel;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox QuarantineProtocolNo;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox PatientFullName;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelExternalPharmacy;
        protected ITTObjectListBox ExternalPharmacy;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelQuarantineProtocolNo;
        protected ITTLabel labelPatientGroup;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelReasonForAdmission;
        protected ITTEnumComboBox PrescriptionType;
        protected ITTLabel labelPrescriptionType;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox PrescriptionPaper;
        protected ITTLabel labelPrescriptionNO;
        protected ITTButton cmdAddDetail;
        override protected void InitializeControls()
        {
            labelDistributioınNo = (ITTLabel)AddControl(new Guid("277e0799-8cf1-446f-b6a7-8c648a905bbb"));
            DistributionNo = (ITTTextBox)AddControl(new Guid("b57b179d-c37e-44fd-8088-1d09de2e83d9"));
            EReceteNo = (ITTTextBox)AddControl(new Guid("288c8f67-08c5-4bf1-a8a4-fda8dcae3f7e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("48612ecd-c9f2-4b2c-ad06-ab47ff21a799"));
            btnEReceteNoInQuiry = (ITTButton)AddControl(new Guid("7406d3b7-33a7-487a-9e91-da2878292f4e"));
            labelEReceteNo = (ITTLabel)AddControl(new Guid("01fe4d9c-294a-418b-bb27-d1cc9c9b8be1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f6f28ea0-81dc-4b11-ab72-ced5ebd93599"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4e3998b0-fb0c-467e-95a2-9932fa3ae203"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("6888b556-17b2-4086-99e9-ac53d2d54c49"));
            InpatientDrugOrders = (ITTGrid)AddControl(new Guid("bee7c716-faff-4777-99df-1d0e329b8bef"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("7d50ff4a-92e5-4904-b0fb-56ae979dc481"));
            BarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("b191e2fb-928f-4f1f-98ae-0e5f31c1c7ae"));
            Frequency = (ITTEnumComboBoxColumn)AddControl(new Guid("0c19369e-a316-46d9-abc0-079c1a8b5fdf"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("c49a13c3-2edb-44d7-a411-e3aae47d8555"));
            Day = (ITTTextBoxColumn)AddControl(new Guid("a89fb3ae-3a0a-4396-9255-7aa5b0912108"));
            PackageAmount = (ITTTextBoxColumn)AddControl(new Guid("f7f79ab5-c647-4bc6-b5fd-9ec9afc6e437"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("08128a36-c50d-4e07-9191-d75540ebb240"));
            UsageNote = (ITTTextBoxColumn)AddControl(new Guid("26d9a5a2-e1a6-46c7-a042-bc3049ca5169"));
            State = (ITTStateComboBoxColumn)AddControl(new Guid("d330d262-aba7-466a-b00e-a7db3a918c3f"));
            cmdSelectBarcodeLevel = (ITTButtonColumn)AddControl(new Guid("7cb887fa-7b42-4a29-bab9-a6b1bc534a6b"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("1c6bf257-4dbb-49fd-831f-7ed13fa6b959"));
            QuarantineProtocolNo = (ITTTextBox)AddControl(new Guid("e32dfdc4-70d4-4b64-9e44-5f9216843403"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("47f5ed90-c0d5-49ba-bfa8-eada04af7580"));
            PatientFullName = (ITTTextBox)AddControl(new Guid("66a8ecf7-ab56-4c12-90d3-03c74150116c"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("0d15f641-3855-4527-b963-89a8aa3fe923"));
            labelExternalPharmacy = (ITTLabel)AddControl(new Guid("e4b85a71-5a3d-4f30-8279-c8905218f75f"));
            ExternalPharmacy = (ITTObjectListBox)AddControl(new Guid("dffddf9b-5fa5-48d6-9d2d-3f68a4d4f369"));
            labelID = (ITTLabel)AddControl(new Guid("e14e8098-1463-417a-92c8-5052e54d6f3d"));
            labelActionDate = (ITTLabel)AddControl(new Guid("364fb635-1211-448c-abc0-7da7d25fd37f"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("03fb2500-e8b6-4956-b70b-b03461995bf2"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("28b6d96d-6287-44b4-90b5-4f3ed7a3c3fa"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("e966b1d2-a2dc-42e5-b9b2-fcbe5d81da9d"));
            labelQuarantineProtocolNo = (ITTLabel)AddControl(new Guid("ebe02fb8-1a06-4280-a563-d2d37c2c546e"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("a47bbf85-1f94-4beb-ab1c-3f56500a6040"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("20cc73d8-982d-4165-acfd-fc1b4ac8a730"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("97222781-63ac-4e07-8b32-5ae565c035dc"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("16bf63aa-c219-4121-94ee-69da5fa63505"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("98f7a5ce-c30d-4e67-b325-52d69be2b918"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("b6a401d0-a267-4238-922f-902e42e1c5cb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4ff21d9c-0e05-4b81-b9a3-459fbbdf2f50"));
            PrescriptionPaper = (ITTObjectListBox)AddControl(new Guid("6dd9cda4-0108-49f1-901a-4c5ed86fc7fb"));
            labelPrescriptionNO = (ITTLabel)AddControl(new Guid("9abbb9aa-cba7-4bbd-bd07-e2e58c5d0a1c"));
            cmdAddDetail = (ITTButton)AddControl(new Guid("a19c5d61-7235-42e8-ba29-b937180c66ec"));
            base.InitializeControls();
        }

        public InpatientPresciriptionDrugSupplyForm() : base("INPATIENTPRESCRIPTION", "InpatientPresciriptionDrugSupplyForm")
        {
        }

        protected InpatientPresciriptionDrugSupplyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}