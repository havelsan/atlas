
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
    public partial class InpatientPresciriptionForm : InpatientPrescriptionBaseForm
    {
    /// <summary>
    /// Yatan Hasta Reçetesi
    /// </summary>
        protected TTObjectClasses.InpatientPrescription _InpatientPrescription
        {
            get { return (TTObjectClasses.InpatientPrescription)_ttObject; }
        }

        protected ITTButton cmdAddDetail;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage DiagTabPage;
        protected ITTGrid SPTSDiagnosises;
        protected ITTTextBoxColumn CodeDiagnosisForPresc;
        protected ITTTextBoxColumn NameDiagnosisForPresc;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTTabControl tttabcontrol1;
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
        protected ITTToolStrip tttoolstrip1;
        override protected void InitializeControls()
        {
            cmdAddDetail = (ITTButton)AddControl(new Guid("baf68db3-752d-402a-98f2-b7e84672f67e"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("186c1291-8e92-4d27-b9a5-4a4fe7f3e05d"));
            DiagTabPage = (ITTTabPage)AddControl(new Guid("f18f7d45-61a8-4ea2-a84f-1cb16a42d886"));
            SPTSDiagnosises = (ITTGrid)AddControl(new Guid("72bb501e-98d9-426a-a251-c189ab2ef7e0"));
            CodeDiagnosisForPresc = (ITTTextBoxColumn)AddControl(new Guid("96ce73ab-c689-4a86-b2fa-5724a1f9406f"));
            NameDiagnosisForPresc = (ITTTextBoxColumn)AddControl(new Guid("6df6b386-62de-4338-a095-6a3b8cc0e92f"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("ccb56d1c-5112-4d16-9334-9afa8f2a6b28"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("9842d927-8052-4a2d-9fd3-465225e0c529"));
            DrugTabPage = (ITTTabPage)AddControl(new Guid("97766b7c-fbe4-45f0-9ee7-38cfeaef5b89"));
            InpatientDrugOrders = (ITTGrid)AddControl(new Guid("e80e2f7b-53d0-4568-8367-bf2979a469f3"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("c382c0d6-a641-46eb-a858-1d4addc656f9"));
            Frequency = (ITTEnumComboBoxColumn)AddControl(new Guid("70723624-1611-4448-bd95-090549b6d168"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("f8ecaf41-ff9a-4747-b727-859d3e50a8da"));
            Day = (ITTTextBoxColumn)AddControl(new Guid("bc60ceb0-986a-4b95-9c4a-033ca483163a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d2be7c3e-a68c-4c3f-87a5-15931160be95"));
            UsageNote = (ITTTextBoxColumn)AddControl(new Guid("6579c08b-26f0-41d0-91a9-a70898c87396"));
            DescriptionType = (ITTEnumComboBoxColumn)AddControl(new Guid("c4cce030-609f-4713-9136-ba964203955a"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("95deeb47-4875-41ca-b455-a536f1ba1bdc"));
            QuarantineProtocolNo = (ITTTextBox)AddControl(new Guid("81613dac-b425-4875-a280-6b3c2abb625a"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("824f224c-b7af-470e-a46a-8ac122bd0022"));
            ID = (ITTTextBox)AddControl(new Guid("ff21176e-9c5c-4693-b8ee-a7bba2b72993"));
            PatientFullName = (ITTTextBox)AddControl(new Guid("5f65e5d6-5ec8-4718-9f5b-cb98a1c690d4"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("22709574-9d46-4880-b119-06e3afce90d7"));
            labelActionDate = (ITTLabel)AddControl(new Guid("f050ba18-4cd2-4904-a347-144b734c620c"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("4c9808ed-ebb1-4ab7-8c76-49e099152660"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("8dc93292-f347-4582-aeb6-6428e46b98e2"));
            labelID = (ITTLabel)AddControl(new Guid("1ca19c05-45d4-4ca8-8a48-6ac38692757b"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("672576d4-7360-4123-a951-a286fbf0a269"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("94456ba8-6816-4c48-93d9-bd485d8871a7"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("31ecedf7-49e5-4217-bf39-bf543cf4f06c"));
            labelQuarantineProtocolNo = (ITTLabel)AddControl(new Guid("a318cadf-d694-403d-b002-cb9107da24c0"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("fb91e0bb-dd54-4e88-af66-d117fd8537d4"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("39c2a1c8-fa29-462b-9a7e-4e92c06a24eb"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("d2740ce5-3e3d-4494-8dd1-d71b0aee7cb3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5ea40529-bef0-462c-9654-f878ac827cc7"));
            PrescriptionPaper = (ITTObjectListBox)AddControl(new Guid("91e11a57-516b-40c8-9412-ef1abac668c5"));
            labelPrescriptionNO = (ITTLabel)AddControl(new Guid("96a711b5-b0e7-4bd6-b2f0-134b849e6a08"));
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("06359295-ff60-4a06-9821-7b2eef8ea2d6"));
            base.InitializeControls();
        }

        public InpatientPresciriptionForm() : base("INPATIENTPRESCRIPTION", "InpatientPresciriptionForm")
        {
        }

        protected InpatientPresciriptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}