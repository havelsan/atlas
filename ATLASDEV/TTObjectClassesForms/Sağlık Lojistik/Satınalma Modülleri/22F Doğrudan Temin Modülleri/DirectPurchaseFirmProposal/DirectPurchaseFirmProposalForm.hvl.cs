
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
    public partial class DirectPurchaseFirmProposalForm : TTForm
    {
    /// <summary>
    /// Doğrudan Temin Teklifi Veren Firma
    /// </summary>
        protected TTObjectClasses.DirectPurchaseFirmProposal _DirectPurchaseFirmProposal
        {
            get { return (TTObjectClasses.DirectPurchaseFirmProposal)_ttObject; }
        }

        protected ITTTabControl tabControlFirmProposal;
        protected ITTTabPage tabPageFirmProposalUBB;
        protected ITTGrid DPADetailFirmPriceOffers;
        protected ITTListBoxColumn DirectPurchaseActionDetail;
        protected ITTListBoxColumn OfferedUBB;
        protected ITTListBoxColumn OfferedSUTCode;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage tabPageFirmProposalRadioPharma;
        protected ITTGrid DPARadioPharmaFirmPriceOffersGrid;
        protected ITTListBoxColumn DPARadioPharmaCeuticalMaterials;
        protected ITTListBoxColumn ProcedureSutCode;
        protected ITTTextBoxColumn RPCUnitPrice;
        protected ITTTextBoxColumn RPCDescription;
        protected ITTTabPage tabPageFirmProposalCodeless;
        protected ITTGrid CodelessMaterialGrid;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn CodelessUnitPrice;
        protected ITTTextBoxColumn tttextboxcolumn2;
        override protected void InitializeControls()
        {
            tabControlFirmProposal = (ITTTabControl)AddControl(new Guid("068a9732-5a5a-4b37-bcff-8279a686e1ce"));
            tabPageFirmProposalUBB = (ITTTabPage)AddControl(new Guid("40f9d008-222f-4c59-b704-ca83ca2fd383"));
            DPADetailFirmPriceOffers = (ITTGrid)AddControl(new Guid("6a15527c-b611-408f-af48-4cec0730145c"));
            DirectPurchaseActionDetail = (ITTListBoxColumn)AddControl(new Guid("a13481ac-9cc9-4a00-8556-7ca648a404c0"));
            OfferedUBB = (ITTListBoxColumn)AddControl(new Guid("0e2580a1-2139-44dc-9a28-abc405b6d084"));
            OfferedSUTCode = (ITTListBoxColumn)AddControl(new Guid("2b0f9d2b-71d7-46d3-8fa7-9ce12f651d35"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("7979c011-bf4d-43b2-abc3-83839eb4df76"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("7a979b74-153a-4f89-99aa-ed9c3ca0c8a1"));
            tabPageFirmProposalRadioPharma = (ITTTabPage)AddControl(new Guid("4511e218-808d-4957-ab6a-13ddd8bd1179"));
            DPARadioPharmaFirmPriceOffersGrid = (ITTGrid)AddControl(new Guid("5a4a6baf-2bf7-46a2-aa8c-1e9c30830d5e"));
            DPARadioPharmaCeuticalMaterials = (ITTListBoxColumn)AddControl(new Guid("b7f9eb72-a0dc-44d5-a908-a2ea22fc24a6"));
            ProcedureSutCode = (ITTListBoxColumn)AddControl(new Guid("358c7e79-3cf4-4a87-8b0e-c7d69a75b655"));
            RPCUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("b3fbb989-a64d-4940-9c8e-72d5ef109db9"));
            RPCDescription = (ITTTextBoxColumn)AddControl(new Guid("f8305b15-f6df-4be9-ad83-651d47ea186d"));
            tabPageFirmProposalCodeless = (ITTTabPage)AddControl(new Guid("7062807b-ef69-47db-9e36-6917e506acb6"));
            CodelessMaterialGrid = (ITTGrid)AddControl(new Guid("78eb3f59-322e-4f83-8a3a-f5ba94047edc"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("917f5f9e-8cbe-44c2-8056-4359948f2557"));
            CodelessUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("7e9968e4-5ea4-4c6e-a7a7-78a27f4c9ed8"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("dc65176e-66ac-410d-a61b-7e2b804648e5"));
            base.InitializeControls();
        }

        public DirectPurchaseFirmProposalForm() : base("DIRECTPURCHASEFIRMPROPOSAL", "DirectPurchaseFirmProposalForm")
        {
        }

        protected DirectPurchaseFirmProposalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}