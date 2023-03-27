
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
    public partial class DirectPurchaseActionForm : BaseDirectPurchaseActionForm
    {
    /// <summary>
    /// 22F Doğrudan Temin İşlemi
    /// </summary>
        protected TTObjectClasses.DirectPurchaseAction _DirectPurchaseAction
        {
            get { return (TTObjectClasses.DirectPurchaseAction)_ttObject; }
        }

        protected ITTEnumComboBox cmbDirectPurchaseActionType;
        protected ITTLabel lblActionType;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
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
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelExpenser;
        protected ITTObjectListBox Expenser;
        protected ITTLabel labelClinicChief;
        protected ITTObjectListBox ClinicChief;
        protected ITTLabel labelPatient;
        protected ITTObjectListBox Patient;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel lblRequesterDoctor;
        protected ITTObjectListBox RequesterDoctor;
        override protected void InitializeControls()
        {
            cmbDirectPurchaseActionType = (ITTEnumComboBox)AddControl(new Guid("944e7554-0e82-444b-a0e4-c7f7883237b6"));
            lblActionType = (ITTLabel)AddControl(new Guid("acb3b2a7-2403-4dcd-8372-a1d92aaf84de"));
            labelDescription = (ITTLabel)AddControl(new Guid("9075e10d-9410-4e55-8215-d09b32a1ee2f"));
            Description = (ITTTextBox)AddControl(new Guid("2ae67e1f-4e5c-4da2-8168-102c45b0eaf1"));
            tabDirectPurchaseActionDetails = (ITTTabControl)AddControl(new Guid("9bdde5d9-5be2-4df5-be65-1e83a89f8d7c"));
            tabPageDirectPurchaseActionDetails = (ITTTabPage)AddControl(new Guid("fdd0c011-c7f9-482b-a4c9-f8e71d558d8d"));
            DirectPurchaseActionDetailsGrid = (ITTGrid)AddControl(new Guid("787ad9de-9e87-4c4c-aa80-922e9d4be5ec"));
            SUTCode = (ITTListBoxColumn)AddControl(new Guid("671f9238-34a3-49c0-8dec-257903355af7"));
            SUTPrice = (ITTTextBoxColumn)AddControl(new Guid("51ab8388-bdc5-4579-851a-823bb3f69eba"));
            SUTName = (ITTTextBoxColumn)AddControl(new Guid("fc54dc5e-93ca-4219-a4f0-2ddd805d8739"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("fbe7563a-4611-4d9d-b711-87b240bdec3d"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("5539f55d-fc34-461c-bc68-d1151037e927"));
            tabPageDPARadioPharmaceuticals = (ITTTabPage)AddControl(new Guid("976700a0-7724-4905-8535-558b97fedd9c"));
            DPARadioPharmaCeuticalsGrid = (ITTGrid)AddControl(new Guid("a6b1dd4e-beb6-4843-b911-ae93e163104f"));
            ProcedureSUTCode = (ITTListBoxColumn)AddControl(new Guid("f658fb91-e59c-4636-8dbb-ebae209dbfeb"));
            ProcedureSUTPrice = (ITTTextBoxColumn)AddControl(new Guid("67263a54-bb62-4477-af79-6a68bcc99f75"));
            RadioPharmaceuticalMaterial = (ITTListBoxColumn)AddControl(new Guid("442ab4c0-fc13-4fe8-9150-191987052ed7"));
            RPAmount = (ITTTextBoxColumn)AddControl(new Guid("93394072-f8f3-41d7-99c9-06e4df866604"));
            RPDistributionType = (ITTListBoxColumn)AddControl(new Guid("92d4c819-6246-4c27-a42c-e3700019e0f5"));
            tabPageCodelessMaterial = (ITTTabPage)AddControl(new Guid("491b8fcb-2eff-4ff6-a620-bc69ce0f82ae"));
            DPACodelessMaterialGrid = (ITTGrid)AddControl(new Guid("b6a94e04-6868-4f0e-aa15-6806fd29c033"));
            CodelessMaterialName = (ITTListBoxColumn)AddControl(new Guid("a56f8193-7c9f-44d8-ac27-2e34eccb96ab"));
            CDAmount = (ITTTextBoxColumn)AddControl(new Guid("0185505b-0067-4eb6-bb91-22617fae4776"));
            CDDistributionType = (ITTListBoxColumn)AddControl(new Guid("2e579366-0256-43eb-b9aa-d1c6efb7f695"));
            tabCommisionMembers = (ITTTabControl)AddControl(new Guid("5dc2b61b-0353-40fb-9233-eddd837d14bf"));
            tabPageCommissionMembers = (ITTTabPage)AddControl(new Guid("ad9c5349-e40b-4259-bd97-9761beb51559"));
            CommissionMembersGrid = (ITTGrid)AddControl(new Guid("ae16113a-c408-42da-b434-3c2490b5d3aa"));
            CommisionOrderNo = (ITTTextBoxColumn)AddControl(new Guid("9e44d67f-860c-4c95-b6ad-f47fb99a79c1"));
            MemberTitle = (ITTEnumComboBoxColumn)AddControl(new Guid("1de2712e-32d6-4641-af7a-898297ecfc04"));
            MemberRank = (ITTTextBoxColumn)AddControl(new Guid("e9b8c578-e7e2-4d07-aa7b-52d61d6476ce"));
            MemberName = (ITTListBoxColumn)AddControl(new Guid("6e9cb25a-afb3-4dd4-bf1b-1b483f530b9b"));
            MemberDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("cbb44fb4-b51a-4c9e-b0fd-c6893d5a8dbd"));
            PrimeBackup = (ITTCheckBoxColumn)AddControl(new Guid("f16e6eb9-66e0-4c83-9dea-ddd11f88eece"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("2ea4b8ec-b3cd-41a9-b5c9-431d777891f2"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("e5fdafad-7fbe-4b5d-be62-9c2db0b98711"));
            labelExpenser = (ITTLabel)AddControl(new Guid("a0bb7148-0e72-4bc6-a271-7a39c1655f32"));
            Expenser = (ITTObjectListBox)AddControl(new Guid("00ca116d-cd5c-47a2-8261-1d0bdbb2a61f"));
            labelClinicChief = (ITTLabel)AddControl(new Guid("a6cc7a0c-c420-4739-8836-5f544c127a85"));
            ClinicChief = (ITTObjectListBox)AddControl(new Guid("8c6fb489-6ba7-4dff-8fe5-8f9b789fb724"));
            labelPatient = (ITTLabel)AddControl(new Guid("4a36a502-dda5-4076-aaa8-3403c9722958"));
            Patient = (ITTObjectListBox)AddControl(new Guid("79b1a267-9283-414b-b193-723863341a25"));
            labelActionDate = (ITTLabel)AddControl(new Guid("989d8597-e697-42ca-a781-ff4409d69d92"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("4deb73fd-b500-4ea1-844b-2e935fbf3b6c"));
            lblRequesterDoctor = (ITTLabel)AddControl(new Guid("49e63d6c-115d-472d-a9da-9dafeaf39fbc"));
            RequesterDoctor = (ITTObjectListBox)AddControl(new Guid("cf8e5c06-9fe3-40c1-8e93-0f6fdd687a55"));
            base.InitializeControls();
        }

        public DirectPurchaseActionForm() : base("DIRECTPURCHASEACTION", "DirectPurchaseActionForm")
        {
        }

        protected DirectPurchaseActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}