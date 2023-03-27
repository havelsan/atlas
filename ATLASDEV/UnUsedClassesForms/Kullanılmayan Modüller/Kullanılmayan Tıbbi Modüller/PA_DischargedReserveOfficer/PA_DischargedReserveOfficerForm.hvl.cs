
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
    /// Terhisli Yedek Subay(Özel Statülü) Kabul 
    /// </summary>
    public partial class PA_DischargedReserveOfficerForm : PatientAdmissionForm
    {
    /// <summary>
    /// Terhisli Yedek Subay(Özel Statülü) Kabul 
    /// </summary>
        protected TTObjectClasses.PA_DischargedReserveOfficer _PA_DischargedReserveOfficer
        {
            get { return (TTObjectClasses.PA_DischargedReserveOfficer)_ttObject; }
        }

        protected ITTObjectListBox Rank;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel labelRank;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox HealtSlipNumber;
        protected ITTLabel labelRetirementFundID;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTLabel labelMilitaryAcceptanceTime;
        protected ITTObjectListBox ForcesCommand;
        protected ITTObjectListBox MilitaryOffice;
        protected ITTTextBox ConscriptionPeriod;
        protected ITTTextBox DocumentNumber;
        protected ITTDateTimePicker DemobilizationTime;
        protected ITTLabel labelConscriptionPeriod;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelDocumentNumber;
        protected ITTLabel labelSenderChair;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelMilitaryUnit;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelMilitaryClass;
        protected ITTLabel labelForcesCommand;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelDemobilizationTime;
        protected ITTDateTimePicker MilitaryAcceptanceTime;
        protected ITTLabel labelMilitaryOffice;
        protected ITTLabel labelDocumentDate;
        override protected void InitializeControls()
        {
            Rank = (ITTObjectListBox)AddControl(new Guid("a341db2a-f4bb-4ef0-871a-f9f40bc2d9be"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("4c35792e-1250-4b1c-b2e7-2af9a2ba09e3"));
            labelRank = (ITTLabel)AddControl(new Guid("776fed0f-2ad0-456d-bbb5-1993628c5698"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("7b212fef-bada-4206-92b0-73b9a69639d8"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("a68eed3e-2f2d-4aa0-99ea-c8a2eb995830"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("599ca9fa-d62c-42ee-bc9b-e8f3d8eedcbb"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("dc9a6e96-6618-42d8-abef-c2ba7a942f61"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("9cbfeda4-0d27-43ff-9df3-db2b6ef7b064"));
            labelMilitaryAcceptanceTime = (ITTLabel)AddControl(new Guid("5d47e38c-0ca9-41ef-ab59-175732e66cee"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("f44c6201-0ed1-4bc1-b1ee-184f6ed487b7"));
            MilitaryOffice = (ITTObjectListBox)AddControl(new Guid("10f3819c-c491-4605-a05a-19490f5ab071"));
            ConscriptionPeriod = (ITTTextBox)AddControl(new Guid("5225055d-c854-4cce-9cbb-1a89c59770f1"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("11f9dc3b-0227-4df8-9828-2b7f1e791be9"));
            DemobilizationTime = (ITTDateTimePicker)AddControl(new Guid("066d505b-0db4-4672-820e-2e8cb9263d81"));
            labelConscriptionPeriod = (ITTLabel)AddControl(new Guid("6e47aaec-a428-414f-83a1-33ec448768a2"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("da6f412b-3334-4983-9bc3-448608697616"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("8b07077c-7563-4089-aee3-7854c621688b"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("85df67d5-186f-4907-9abf-7bc22d31265e"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("90636f38-b9ad-4369-93e6-901a6c89ba5b"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("4eed990d-3af1-4667-9bec-a8e81033b1b8"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("7e90f2dd-4ff8-4921-8306-b088a93d13b6"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("6522f079-92af-4859-a006-b626c381344e"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("e6a24293-f948-4d0d-8039-ba4d4ba1bbe4"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("eb4f312a-acc6-408b-bc2d-c9610bdcb7e8"));
            labelDemobilizationTime = (ITTLabel)AddControl(new Guid("0abfdab5-5d50-4afa-9cd8-df963131b0e3"));
            MilitaryAcceptanceTime = (ITTDateTimePicker)AddControl(new Guid("6e7707dd-e855-4954-89db-e04ad4924499"));
            labelMilitaryOffice = (ITTLabel)AddControl(new Guid("47288906-286f-4ef0-94a1-f1be207164b0"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("a257eb77-8b83-49eb-bd9e-fb439d4751e1"));
            base.InitializeControls();
        }

        public PA_DischargedReserveOfficerForm() : base("PA_DISCHARGEDRESERVEOFFICER", "PA_DischargedReserveOfficerForm")
        {
        }

        protected PA_DischargedReserveOfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}