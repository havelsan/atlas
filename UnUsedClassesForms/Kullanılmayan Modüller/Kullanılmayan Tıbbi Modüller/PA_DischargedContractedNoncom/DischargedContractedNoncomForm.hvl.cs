
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
    /// Ayrılmış Sözleşmeli Astsubay
    /// </summary>
    public partial class DischargedContractedNoncomForm : PatientAdmissionForm
    {
    /// <summary>
    /// Ayrılmış Sözleşmeli Astsubay
    /// </summary>
        protected TTObjectClasses.PA_DischargedContractedNoncom _PA_DischargedContractedNoncom
        {
            get { return (TTObjectClasses.PA_DischargedContractedNoncom)_ttObject; }
        }

        protected ITTObjectListBox ttobjectlistboxForcesCommand;
        protected ITTLabel ttlabel2;
        protected ITTTextBox HealtSlipNumber;
        protected ITTDateTimePicker DocumentDate;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelMilitaryUnit;
        protected ITTLabel labelDocumentNumber;
        protected ITTObjectListBox SenderChair;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox RetirementFundID;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelRetirementFundID;
        protected ITTLabel labelMilitaryClass;
        protected ITTLabel labelRank;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelSenderChair;
        protected ITTTextBox EmploymentRecordID;
        override protected void InitializeControls()
        {
            ttobjectlistboxForcesCommand = (ITTObjectListBox)AddControl(new Guid("f0f0fe17-33bf-41dc-ba32-9303a93a32a5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("849432a7-da81-4c40-a681-8bc0e831f3d2"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("9a8fab34-10a9-4148-8005-31c01f895f5a"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("668fb244-2d78-45e5-9dba-6bc3593cfb29"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("2a134608-a448-4c93-b54f-3619fb2b683f"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("bf660d4a-3b67-43ee-bc36-bb8cdfc668b0"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("1f003d1c-afd0-463d-a776-1009b9e3e9db"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("a760670a-0233-4734-85b6-d4ef2a8e6442"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("84673476-edce-4525-94ff-8cbb8688338e"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("34377543-c75a-4205-baa7-6b10e40e33df"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("2ce5034c-0719-4e7f-b6e8-ce133fc485d2"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("2fcfead0-30a4-4f79-bc9e-8aa06f8024c0"));
            Rank = (ITTObjectListBox)AddControl(new Guid("74463eeb-0b0a-41d6-a58a-63a23904a5e0"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("b1c60b7c-437b-4465-8b0f-fc1ccc98ca27"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("b304264c-5ff4-46e1-a646-15867f1e39d3"));
            labelRank = (ITTLabel)AddControl(new Guid("d6a52c99-ef06-40c0-b908-da05bca91ea2"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("89bc3c50-760b-487f-943a-9a6dd98dab05"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("a4b60381-21f5-42a9-90d8-fdfebc35fa0e"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("47103ab8-d34a-4702-9abf-c6555341152e"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("c69cab54-e9e9-4701-8822-d359c7b872c3"));
            base.InitializeControls();
        }

        public DischargedContractedNoncomForm() : base("PA_DISCHARGEDCONTRACTEDNONCOM", "DischargedContractedNoncomForm")
        {
        }

        protected DischargedContractedNoncomForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}