
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
    /// Piyasa Fiyat Araştırma, Mal Muayene Kabul ve Kullanım Tutanağı
    /// </summary>
    public partial class DirectPurchaseActionPriceForm : BaseDirectPurchaseActionForm
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
        protected ITTTabPage tabFirms;
        protected ITTGrid grdFirms;
        protected ITTListBoxColumn Firm;
        protected ITTTextBoxColumn FirmAddress;
        protected ITTButtonColumn btnProposals;
        protected ITTDateTimePickerColumn InvoiceDate;
        protected ITTTextBoxColumn InvoiceNumber;
        protected ITTDateTimePickerColumn DeliveryDate;
        protected ITTTextBoxColumn DeliveryNumber;
        protected ITTTabPage tabPageDirectPurchaseActionDetails;
        protected ITTGrid DirectPurchaseActionDetailsGrid;
        protected ITTListBoxColumn SUTCode;
        protected ITTTextBoxColumn SUTPrice;
        protected ITTTextBoxColumn SUTName;
        protected ITTTextBoxColumn Amount;
        protected ITTEnumComboBoxColumn KDV;
        protected ITTTextBoxColumn CertainAmount;
        protected ITTListBoxColumn DistributionType;
        protected ITTButtonColumn Offers;
        protected ITTCheckBoxColumn Cancelled;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage tabPageDPARadioPharmaDetails;
        protected ITTGrid DPARadioPharmaCeuticalDetGrid;
        protected ITTListBoxColumn RPCSutCode;
        protected ITTTextBoxColumn RPCSutPrice;
        protected ITTListBoxColumn RadioPharmaCeuticalMaterial;
        protected ITTTextBoxColumn RPCAmount;
        protected ITTEnumComboBoxColumn RPCKDV;
        protected ITTTextBoxColumn RPCCertainAmount;
        protected ITTListBoxColumn RPCDistributionType;
        protected ITTButtonColumn RPCOffers;
        protected ITTCheckBoxColumn RPCCancelled;
        protected ITTTextBoxColumn RPCDescription;
        protected ITTTabPage tabPageDPAUBBCodelessDetails;
        protected ITTGrid DPAUBBCodelessGrid;
        protected ITTListBoxColumn DPA22FCodelessMaterialDirectPurchaseActionDetail;
        protected ITTTextBoxColumn AmountDirectPurchaseActionDetail;
        protected ITTEnumComboBoxColumn KDVDirectPurchaseActionDetail;
        protected ITTTextBoxColumn CertainAmountDirectPurchaseActionDetail;
        protected ITTListBoxColumn DistributionTypeDirectPurchaseActionDetail;
        protected ITTButtonColumn UBBCodelessOffers;
        protected ITTCheckBoxColumn CancelledDirectPurchaseActionDetail;
        protected ITTTextBoxColumn DescriptionDirectPurchaseActionDetail;
        protected ITTTabControl tabCommisionMembers;
        protected ITTTabPage tabPageCommissionMembers;
        protected ITTGrid CommissionMembersGrid;
        protected ITTTextBoxColumn CommisionOrderNo;
        protected ITTEnumComboBoxColumn MemberTitle;
        protected ITTTextBoxColumn MemberRank;
        protected ITTListBoxColumn MemberName;
        protected ITTEnumComboBoxColumn MemberDuty;
        protected ITTCheckBoxColumn PrimeBackup;
        protected ITTCheckBoxColumn PrintOnMatInspection;
        protected ITTTextBox TenderNumber;
        protected ITTTextBox PatientProtocolNo;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelTenderNumber;
        protected ITTLabel labelTenderDate;
        protected ITTDateTimePicker TenderDate;
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
        protected ITTLabel labelPatientProtocolNo;
        protected ITTLabel lblRequesterDoctor;
        protected ITTObjectListBox RequesterDoctor;
        protected ITTEnumComboBox cmbDirectPurchaseActionType;
        protected ITTLabel lblActionType;
        override protected void InitializeControls()
        {
            FinancialYear = (ITTMaskedTextBox)AddControl(new Guid("f0c5221d-4d98-484d-8b97-17800556cb42"));
            lblFinancialYear = (ITTLabel)AddControl(new Guid("f58ff935-7963-41f5-9693-73a7d02bab73"));
            tabDirectPurchaseActionDetails = (ITTTabControl)AddControl(new Guid("7d1b8919-ba5a-4f9f-bd38-bb59b7ca6ee7"));
            tabFirms = (ITTTabPage)AddControl(new Guid("f3bb0952-b80b-4a91-85d9-1afe46db070f"));
            grdFirms = (ITTGrid)AddControl(new Guid("0b500b80-268e-4d54-9c04-32f06d256a11"));
            Firm = (ITTListBoxColumn)AddControl(new Guid("72ae33b8-f889-4215-985a-30a243f14b6b"));
            FirmAddress = (ITTTextBoxColumn)AddControl(new Guid("fb62cacd-7d4b-47c4-9f67-96118259e4d4"));
            btnProposals = (ITTButtonColumn)AddControl(new Guid("31e7b20d-d291-4310-89b5-8eb10fd584ae"));
            InvoiceDate = (ITTDateTimePickerColumn)AddControl(new Guid("ceeb5905-9be7-4d1f-b665-671976d0f1f2"));
            InvoiceNumber = (ITTTextBoxColumn)AddControl(new Guid("7282440f-60ee-44e4-9aba-1752e33d1518"));
            DeliveryDate = (ITTDateTimePickerColumn)AddControl(new Guid("b25c2b96-26af-4157-86be-1da109d08139"));
            DeliveryNumber = (ITTTextBoxColumn)AddControl(new Guid("3fec3515-5b93-44cd-a078-3502fbd626b3"));
            tabPageDirectPurchaseActionDetails = (ITTTabPage)AddControl(new Guid("1fed5b55-610f-43f2-b112-e3b85a5b9ec7"));
            DirectPurchaseActionDetailsGrid = (ITTGrid)AddControl(new Guid("84fd694c-12d9-42a1-bddf-0871c4f1710e"));
            SUTCode = (ITTListBoxColumn)AddControl(new Guid("443e46b8-930c-45ab-8541-6d5d5c0e4010"));
            SUTPrice = (ITTTextBoxColumn)AddControl(new Guid("496267a8-7cb0-44eb-8f5c-11c44465852a"));
            SUTName = (ITTTextBoxColumn)AddControl(new Guid("856ec1a9-bafd-4888-866a-b8bd99dff584"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6bba0b92-bc3f-4938-b2ee-3e39ffe0e361"));
            KDV = (ITTEnumComboBoxColumn)AddControl(new Guid("20defc5d-aaf7-42a7-b10b-79c31028d98f"));
            CertainAmount = (ITTTextBoxColumn)AddControl(new Guid("1f4ca698-c0f4-4306-8a7b-5e9319eaf045"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("dac984c0-6628-42c5-ae7a-2e772f099e14"));
            Offers = (ITTButtonColumn)AddControl(new Guid("8ae2a679-4f57-4575-9941-7a8c98382bc6"));
            Cancelled = (ITTCheckBoxColumn)AddControl(new Guid("be4ef05c-bc97-42b0-8f43-37bfbc3c7780"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("42074c98-08c7-4931-91ff-bd5af8078f3a"));
            tabPageDPARadioPharmaDetails = (ITTTabPage)AddControl(new Guid("c6a51f92-b11b-4221-843a-f7d32d1ecb49"));
            DPARadioPharmaCeuticalDetGrid = (ITTGrid)AddControl(new Guid("1129eeb7-1070-425a-a561-a8a7856a90fa"));
            RPCSutCode = (ITTListBoxColumn)AddControl(new Guid("793ed011-fc0b-4f9f-be12-ac0374fd4d41"));
            RPCSutPrice = (ITTTextBoxColumn)AddControl(new Guid("3b82a871-e07e-423f-bb68-644e433ec13c"));
            RadioPharmaCeuticalMaterial = (ITTListBoxColumn)AddControl(new Guid("942d555a-6c7f-47e0-93e5-eab7ac43e6ea"));
            RPCAmount = (ITTTextBoxColumn)AddControl(new Guid("99e6b13d-35dc-48fb-aa36-af964e51d068"));
            RPCKDV = (ITTEnumComboBoxColumn)AddControl(new Guid("bb4132ff-9943-47f3-a242-0f433e8a4d3e"));
            RPCCertainAmount = (ITTTextBoxColumn)AddControl(new Guid("4172503d-b3ba-4708-912e-7eba515eec37"));
            RPCDistributionType = (ITTListBoxColumn)AddControl(new Guid("2bee08e2-8fe7-458b-bebd-06161bba93de"));
            RPCOffers = (ITTButtonColumn)AddControl(new Guid("6817ebe8-91db-4486-bf3b-a0b1a544bb3b"));
            RPCCancelled = (ITTCheckBoxColumn)AddControl(new Guid("e0a87440-9ea3-4180-92ab-18e7ff1b49da"));
            RPCDescription = (ITTTextBoxColumn)AddControl(new Guid("8d5aac3c-9df9-4729-8f3d-574fbef567ac"));
            tabPageDPAUBBCodelessDetails = (ITTTabPage)AddControl(new Guid("ae658bf4-e043-46c4-add7-9ab31a3ad4f8"));
            DPAUBBCodelessGrid = (ITTGrid)AddControl(new Guid("300f2b1a-b82b-4693-afb0-ddc14191022f"));
            DPA22FCodelessMaterialDirectPurchaseActionDetail = (ITTListBoxColumn)AddControl(new Guid("0630552f-056b-4678-bf33-416dc600ad58"));
            AmountDirectPurchaseActionDetail = (ITTTextBoxColumn)AddControl(new Guid("2a9afbfd-8925-40bd-83bc-87d7e09fc838"));
            KDVDirectPurchaseActionDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("4890f7a3-1324-4354-94d7-745cd80b3568"));
            CertainAmountDirectPurchaseActionDetail = (ITTTextBoxColumn)AddControl(new Guid("bd22029b-7375-411b-ad76-0145704b5f92"));
            DistributionTypeDirectPurchaseActionDetail = (ITTListBoxColumn)AddControl(new Guid("3a85049d-6bcf-4002-bf29-29fb5340ca10"));
            UBBCodelessOffers = (ITTButtonColumn)AddControl(new Guid("109779f1-b1b2-4a47-9915-133a01c40258"));
            CancelledDirectPurchaseActionDetail = (ITTCheckBoxColumn)AddControl(new Guid("afffce8a-515b-4735-b4dd-11fc24ede299"));
            DescriptionDirectPurchaseActionDetail = (ITTTextBoxColumn)AddControl(new Guid("f1141101-536f-4e99-a46b-6fc80fe32f14"));
            tabCommisionMembers = (ITTTabControl)AddControl(new Guid("6e882a6f-975e-45d6-985b-a5e010ee1105"));
            tabPageCommissionMembers = (ITTTabPage)AddControl(new Guid("3b13b2e5-1379-4e5d-ba94-eba1c1ee8a52"));
            CommissionMembersGrid = (ITTGrid)AddControl(new Guid("c12fa0d6-7fec-4e84-b201-cb9b1a009ec6"));
            CommisionOrderNo = (ITTTextBoxColumn)AddControl(new Guid("8732c610-380a-4ddf-8a99-88b1dff1cf72"));
            MemberTitle = (ITTEnumComboBoxColumn)AddControl(new Guid("f356117e-b561-4a8e-8e4a-cc2b66496edb"));
            MemberRank = (ITTTextBoxColumn)AddControl(new Guid("64ab8170-5820-46b3-a043-fc4745eccd2e"));
            MemberName = (ITTListBoxColumn)AddControl(new Guid("cf0279d7-1dc4-4791-8131-9c415301cb85"));
            MemberDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("7f865026-1162-45fd-8698-9dfb1fd85c72"));
            PrimeBackup = (ITTCheckBoxColumn)AddControl(new Guid("168772d8-efeb-4874-b797-56600de8afcb"));
            PrintOnMatInspection = (ITTCheckBoxColumn)AddControl(new Guid("04a9299a-8850-40b5-ad63-cf01c4394db6"));
            TenderNumber = (ITTTextBox)AddControl(new Guid("5931ba6a-4490-4107-b55f-3dc0633d5901"));
            PatientProtocolNo = (ITTTextBox)AddControl(new Guid("4ff08a45-4958-41f4-93a9-45ed590133e9"));
            labelActionDate = (ITTLabel)AddControl(new Guid("eb9052a9-1971-4c6d-9f41-74b2f982d3be"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("31c13e28-eea8-404b-bb1c-c5953b84c760"));
            labelTenderNumber = (ITTLabel)AddControl(new Guid("b17cb436-081f-4435-ba7d-c19ed7cfbd99"));
            labelTenderDate = (ITTLabel)AddControl(new Guid("1e303679-67b2-439e-9283-359b979f05a2"));
            TenderDate = (ITTDateTimePicker)AddControl(new Guid("339d6dd7-cd57-45d2-8925-47fef0b6e696"));
            labelBudget = (ITTLabel)AddControl(new Guid("a214151e-1575-4d86-b75d-999825df50d2"));
            Budget = (ITTObjectListBox)AddControl(new Guid("db1d44f5-d135-4293-8006-6c2033bd1210"));
            labelProcurementType = (ITTLabel)AddControl(new Guid("e582d008-9f62-4b54-9c76-ff6d9f20b0af"));
            ProcurementType = (ITTEnumComboBox)AddControl(new Guid("e095005a-06eb-4efd-8d3e-bcc8cff3a5e1"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("213f1b44-1261-4e04-8598-16ad2101959c"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("d95f6c14-7988-4627-abb5-d22503497c8e"));
            labelTenderOfficer = (ITTLabel)AddControl(new Guid("caf49e75-aced-449a-bcd1-8e12d05f4cc0"));
            TenderOfficer = (ITTObjectListBox)AddControl(new Guid("19d3e993-018d-4a89-88a6-f57f9c249291"));
            labelCoordinatorChief = (ITTLabel)AddControl(new Guid("65b11766-6c4d-4b6b-a21f-36f882d836d0"));
            CoordinatorChief = (ITTObjectListBox)AddControl(new Guid("1b6a9bee-1a5a-4c5f-9602-4d2d65d99836"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("755ccea1-cdd6-48a5-be51-3118c139525b"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("f140a342-c887-4b3f-991a-bdc1173c7044"));
            labelExpenser = (ITTLabel)AddControl(new Guid("ac46f024-923a-4291-b4a7-119db169006c"));
            Expenser = (ITTObjectListBox)AddControl(new Guid("b9e60f82-7f56-4045-aee0-34462d2ee106"));
            labelClinicChief = (ITTLabel)AddControl(new Guid("1e009113-a886-4c84-baed-5fa05ce788af"));
            ClinicChief = (ITTObjectListBox)AddControl(new Guid("05ef6f22-b693-474e-8c91-7cb60f6738c3"));
            labelPatient = (ITTLabel)AddControl(new Guid("effb2238-3db0-4eb5-bbf5-af6e5d5f89c3"));
            Patient = (ITTObjectListBox)AddControl(new Guid("1f961424-fffc-4b42-ab71-f938d76797e1"));
            labelPatientProtocolNo = (ITTLabel)AddControl(new Guid("17ddf1b0-2f41-42b9-b7f1-315bef0e428a"));
            lblRequesterDoctor = (ITTLabel)AddControl(new Guid("684134f3-27a6-4982-92b3-4bf3978349a2"));
            RequesterDoctor = (ITTObjectListBox)AddControl(new Guid("6c3def82-2bad-49cc-a252-400c5afc6c77"));
            cmbDirectPurchaseActionType = (ITTEnumComboBox)AddControl(new Guid("4a9abe4d-e07a-4f6e-9422-1ac5a365f5c0"));
            lblActionType = (ITTLabel)AddControl(new Guid("3813b71e-4613-4394-9ebb-42b9579ffe4a"));
            base.InitializeControls();
        }

        public DirectPurchaseActionPriceForm() : base("DIRECTPURCHASEACTION", "DirectPurchaseActionPriceForm")
        {
        }

        protected DirectPurchaseActionPriceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}