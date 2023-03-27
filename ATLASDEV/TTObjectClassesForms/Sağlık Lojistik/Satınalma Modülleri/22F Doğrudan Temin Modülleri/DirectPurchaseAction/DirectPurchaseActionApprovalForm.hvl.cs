
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
    /// Doğrudan Temin İşlemi
    /// </summary>
    public partial class DirectPurchaseActionApprovalForm : BaseDirectPurchaseActionForm
    {
    /// <summary>
    /// 22F Doğrudan Temin İşlemi
    /// </summary>
        protected TTObjectClasses.DirectPurchaseAction _DirectPurchaseAction
        {
            get { return (TTObjectClasses.DirectPurchaseAction)_ttObject; }
        }

        protected ITTMaskedTextBox FinancialYear;
        protected ITTLabel lblFinancialYear;
        protected ITTTabControl tabDirectPurchaseActionDetails;
        protected ITTTabPage tabPageDirectPurchaseActionDetails;
        protected ITTGrid DirectPurchaseActionDetailsGrid;
        protected ITTListBoxColumn SUTCode;
        protected ITTTextBoxColumn SUTPrice;
        protected ITTTextBoxColumn SUTName;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn DistributionType;
        protected ITTTabPage tabPageDPARadioPharmaceuticals;
        protected ITTGrid DPARadioPharmaCeuticalsGrid;
        protected ITTListBoxColumn ProcedureSUTCode;
        protected ITTTextBoxColumn ProcedureSUTPrice;
        protected ITTListBoxColumn RadioPharmaceuticalMaterial;
        protected ITTTextBoxColumn RPAmount;
        protected ITTListBoxColumn RPDistributionType;
        protected ITTTabPage tabPageCodelessMaterial;
        protected ITTGrid DPACodelessMaterialGrid;
        protected ITTListBoxColumn CodelessMaterialName;
        protected ITTTextBoxColumn CDAmount;
        protected ITTListBoxColumn CDDistributionType;
        protected ITTTabControl tabCommisionMembers;
        protected ITTTabPage tabPageCommissionMembers;
        protected ITTGrid CommissionMembersGrid;
        protected ITTTextBoxColumn CommisionOrderNo;
        protected ITTEnumComboBoxColumn MemberTitle;
        protected ITTTextBoxColumn MemberRank;
        protected ITTListBoxColumn MemberName;
        protected ITTEnumComboBoxColumn MemberDuty;
        protected ITTCheckBoxColumn PrimeBackup;
        protected ITTTextBox Description;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelBudget;
        protected ITTObjectListBox Budget;
        protected ITTLabel labelProcurementType;
        protected ITTEnumComboBox ProcurementType;
        protected ITTLabel labelAccountancy;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelTenderOfficer;
        protected ITTObjectListBox TenderOfficer;
        protected ITTLabel labelCoordinatorChief;
        protected ITTObjectListBox CoordinatorChief;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelExpenser;
        protected ITTObjectListBox Expenser;
        protected ITTLabel labelClinicChief;
        protected ITTObjectListBox ClinicChief;
        protected ITTLabel labelPatient;
        protected ITTObjectListBox Patient;
        protected ITTLabel lblRequesterDoctor;
        protected ITTObjectListBox RequesterDoctor;
        protected ITTLabel labelDescription;
        protected ITTEnumComboBox cmbDirectPurchaseActionType;
        protected ITTLabel lblActionType;
        override protected void InitializeControls()
        {
            FinancialYear = (ITTMaskedTextBox)AddControl(new Guid("880ceecb-2c67-41fa-aaee-5fac308767d3"));
            lblFinancialYear = (ITTLabel)AddControl(new Guid("eb00b8ba-dd3c-47e3-9edb-8947a56b920a"));
            tabDirectPurchaseActionDetails = (ITTTabControl)AddControl(new Guid("315da804-1c82-487b-a664-3ae254dfdcf1"));
            tabPageDirectPurchaseActionDetails = (ITTTabPage)AddControl(new Guid("b1e1b4d2-900a-4d7e-8047-0096b31267fa"));
            DirectPurchaseActionDetailsGrid = (ITTGrid)AddControl(new Guid("ffb645c4-ab2e-4628-a3b8-ede8a3d49465"));
            SUTCode = (ITTListBoxColumn)AddControl(new Guid("9913c6ca-2209-4281-bfc6-570bb610b73e"));
            SUTPrice = (ITTTextBoxColumn)AddControl(new Guid("d29bebfb-9221-4300-a43f-20af472e6b66"));
            SUTName = (ITTTextBoxColumn)AddControl(new Guid("ca0d4fb7-36a5-480a-85f3-fdcc2fe455f2"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("7fd0b77d-8dd7-4e09-8861-334920a85c20"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("52cc5ee2-3d7b-43e4-8a9e-bb430bb4894b"));
            tabPageDPARadioPharmaceuticals = (ITTTabPage)AddControl(new Guid("41390199-ee2c-4284-8ef4-e0f1cd1a62e7"));
            DPARadioPharmaCeuticalsGrid = (ITTGrid)AddControl(new Guid("00cea92b-56ab-444b-9965-994baf42620f"));
            ProcedureSUTCode = (ITTListBoxColumn)AddControl(new Guid("376e2e43-0f48-4a1c-ac9f-f014462c3afa"));
            ProcedureSUTPrice = (ITTTextBoxColumn)AddControl(new Guid("a591dc1a-1a23-4a38-b7eb-b49957a9e7de"));
            RadioPharmaceuticalMaterial = (ITTListBoxColumn)AddControl(new Guid("d617cb53-ce64-41ba-b631-06f6bc6e0717"));
            RPAmount = (ITTTextBoxColumn)AddControl(new Guid("473b5c04-eded-4331-8441-d45986b7509a"));
            RPDistributionType = (ITTListBoxColumn)AddControl(new Guid("f5377ef2-e137-4029-8192-0db1b94ae6f8"));
            tabPageCodelessMaterial = (ITTTabPage)AddControl(new Guid("4ec96a1f-7f12-446e-84ed-998779d9cef8"));
            DPACodelessMaterialGrid = (ITTGrid)AddControl(new Guid("ef8d8f35-4920-40d9-99a8-996627edd451"));
            CodelessMaterialName = (ITTListBoxColumn)AddControl(new Guid("407d460c-1029-4d22-aa16-961abd025cfd"));
            CDAmount = (ITTTextBoxColumn)AddControl(new Guid("daa75050-9511-41ca-9af2-fde0db81ad75"));
            CDDistributionType = (ITTListBoxColumn)AddControl(new Guid("7c4f89f2-09a8-454a-82e4-49a17e3a3a49"));
            tabCommisionMembers = (ITTTabControl)AddControl(new Guid("41c3754e-ae9f-4b32-88a9-2cbcc953e7e6"));
            tabPageCommissionMembers = (ITTTabPage)AddControl(new Guid("63fdfa67-6abd-4f98-a950-e75aebe93739"));
            CommissionMembersGrid = (ITTGrid)AddControl(new Guid("298f3f7a-4c38-4cdb-b023-037568f78abb"));
            CommisionOrderNo = (ITTTextBoxColumn)AddControl(new Guid("22759a8b-3ce2-4114-a5a1-af15ae3e527c"));
            MemberTitle = (ITTEnumComboBoxColumn)AddControl(new Guid("10b934fe-3869-424d-b5ea-05e34672e31a"));
            MemberRank = (ITTTextBoxColumn)AddControl(new Guid("82531136-95e8-49f5-b2cc-9bd4c19386b8"));
            MemberName = (ITTListBoxColumn)AddControl(new Guid("080cabad-d7c1-4acb-9c14-f1fb584bd703"));
            MemberDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("1cdcffb3-901e-4d37-a31b-dc4a76b87f97"));
            PrimeBackup = (ITTCheckBoxColumn)AddControl(new Guid("7c373993-fd29-4824-8ce7-f7b5ac13f6a6"));
            Description = (ITTTextBox)AddControl(new Guid("c36fb887-db2d-4490-b5ed-8c48fef11311"));
            labelActionDate = (ITTLabel)AddControl(new Guid("e63b2021-03ec-4b6f-bfcb-004f516b2116"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("6e19152c-07de-4190-8210-428a7a037795"));
            labelBudget = (ITTLabel)AddControl(new Guid("34e1dff8-5b34-4232-942c-2c47596a2515"));
            Budget = (ITTObjectListBox)AddControl(new Guid("63d856eb-a95a-43cd-aa2f-7b4e7da5d547"));
            labelProcurementType = (ITTLabel)AddControl(new Guid("2ee41a44-7ddf-4791-a45d-d2693fc89c24"));
            ProcurementType = (ITTEnumComboBox)AddControl(new Guid("01438b5e-c24e-4306-b7c1-b09291063156"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("d0ad74a0-c214-41ee-8542-7ed52ec971fb"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("106d4857-af90-4c55-8347-ee73d94ca89b"));
            labelTenderOfficer = (ITTLabel)AddControl(new Guid("ce825eb4-74dd-4106-8eb8-75909949ff87"));
            TenderOfficer = (ITTObjectListBox)AddControl(new Guid("83c818e6-0ff4-48da-a0bd-9130c4d76785"));
            labelCoordinatorChief = (ITTLabel)AddControl(new Guid("b79c0129-ca72-4bf0-a3cc-c2da8807cdc6"));
            CoordinatorChief = (ITTObjectListBox)AddControl(new Guid("1b6e25b0-3618-41da-bc28-07fd8b5c9810"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("3e92aaee-0823-4649-a42d-c508ed3fca70"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("508e0be9-0c28-4592-b32f-e6aa59241253"));
            labelExpenser = (ITTLabel)AddControl(new Guid("8336a2de-d658-4306-a0d0-2169ff2019eb"));
            Expenser = (ITTObjectListBox)AddControl(new Guid("d84e00a1-23df-4036-ae50-7769bebdf9d3"));
            labelClinicChief = (ITTLabel)AddControl(new Guid("833d6fab-2f4e-4ed6-983e-37c9044f8bc6"));
            ClinicChief = (ITTObjectListBox)AddControl(new Guid("1045e081-70f3-4f04-8d4d-e92c81da98d3"));
            labelPatient = (ITTLabel)AddControl(new Guid("4e4340d1-6555-4166-bfb1-f72c6155c32d"));
            Patient = (ITTObjectListBox)AddControl(new Guid("c421e123-01d9-4512-a3a1-1d94252501fa"));
            lblRequesterDoctor = (ITTLabel)AddControl(new Guid("80bbc478-7f4f-497a-9b9f-52a46238c211"));
            RequesterDoctor = (ITTObjectListBox)AddControl(new Guid("609c4898-b6b9-44d7-88b8-f53456ecec7a"));
            labelDescription = (ITTLabel)AddControl(new Guid("bfd60693-cafe-46ff-ba59-17794f500165"));
            cmbDirectPurchaseActionType = (ITTEnumComboBox)AddControl(new Guid("75a2eec7-c346-4b56-aefa-670963f777a3"));
            lblActionType = (ITTLabel)AddControl(new Guid("b491d38d-4bcc-44bf-a067-a5334449d515"));
            base.InitializeControls();
        }

        public DirectPurchaseActionApprovalForm() : base("DIRECTPURCHASEACTION", "DirectPurchaseActionApprovalForm")
        {
        }

        protected DirectPurchaseActionApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}