
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
    /// Firma Fiyat Teklif Formu
    /// </summary>
    public partial class DPADetailFirmOffersForm : TTForm
    {
    /// <summary>
    /// 22F Doğrudan Temin Malzemeler
    /// </summary>
        protected TTObjectClasses.DirectPurchaseActionDetail _DirectPurchaseActionDetail
        {
            get { return (TTObjectClasses.DirectPurchaseActionDetail)_ttObject; }
        }

        protected ITTGroupBox FirmOffersGroupBox;
        protected ITTTabControl tabControlFirmOffers;
        protected ITTTabPage tabPageUBBFirmOffers;
        protected ITTGrid FirmPriceOffers;
        protected ITTCheckBoxColumn Approved;
        protected ITTListBoxColumn Firm;
        protected ITTListBoxColumn OfferedUBB;
        protected ITTListBoxColumn OfferedSUTCode;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn KDV;
        protected ITTTextBoxColumn Price;
        protected ITTTextBoxColumn CertainPrice;
        protected ITTCheckBoxColumn AcceptedRejected;
        protected ITTTextBoxColumn DonorID;
        protected ITTTabPage tabPageRPCFirmOffers;
        protected ITTGrid RPCFirmPriceOffers;
        protected ITTCheckBoxColumn RPCApproved;
        protected ITTListBoxColumn RPCFirm;
        protected ITTListBoxColumn RPCProcedureSutCode;
        protected ITTTextBoxColumn RPCUnitPrice;
        protected ITTTextBoxColumn RPCKDV;
        protected ITTTextBoxColumn RPCPrice;
        protected ITTTextBoxColumn RPCCertainPrice;
        protected ITTCheckBoxColumn RPCAcceptedRejected;
        protected ITTTextBoxColumn RPCDonorID;
        protected ITTTabPage tabPageCodelessOffers;
        protected ITTGrid CodelessFirmPriceOffers;
        protected ITTCheckBoxColumn CodelessApproved;
        protected ITTListBoxColumn CodelessFirm;
        protected ITTTextBoxColumn CodelessUnitPrice;
        protected ITTTextBoxColumn CodelessKDV;
        protected ITTTextBoxColumn CodelessPrice;
        protected ITTTextBoxColumn CodelessCertainPrice;
        protected ITTCheckBoxColumn CodelessAcceptedRejected;
        protected ITTTextBoxColumn CodelessDonorID;
        override protected void InitializeControls()
        {
            FirmOffersGroupBox = (ITTGroupBox)AddControl(new Guid("9492fea1-8366-4385-8e4e-f0c984da04fc"));
            tabControlFirmOffers = (ITTTabControl)AddControl(new Guid("2b380966-3684-45ce-bbc6-dd08dddaee70"));
            tabPageUBBFirmOffers = (ITTTabPage)AddControl(new Guid("f811d0e1-f3a5-4bdd-8ef7-b9405e06a4d4"));
            FirmPriceOffers = (ITTGrid)AddControl(new Guid("492bf717-ce3f-4ce5-9987-fefc0aa7a881"));
            Approved = (ITTCheckBoxColumn)AddControl(new Guid("154efab4-d56a-4716-a30b-f65bdd47bc1d"));
            Firm = (ITTListBoxColumn)AddControl(new Guid("d811a569-e64b-4963-a170-06f26749ca5c"));
            OfferedUBB = (ITTListBoxColumn)AddControl(new Guid("83667dd2-08c5-4e58-a27b-3d0708bf515d"));
            OfferedSUTCode = (ITTListBoxColumn)AddControl(new Guid("44f47b2e-b052-4b77-a70a-1099bd462744"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("5cf67545-18b6-4614-83c6-0912215fffc5"));
            KDV = (ITTTextBoxColumn)AddControl(new Guid("434cd2a0-4406-4b90-aed0-0304128eebf4"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("545141b2-2525-4927-ab5f-4a797bac406c"));
            CertainPrice = (ITTTextBoxColumn)AddControl(new Guid("c92ed957-9f1c-482c-8bca-3cbf5baf035c"));
            AcceptedRejected = (ITTCheckBoxColumn)AddControl(new Guid("42bc581c-3e61-48db-b318-8221eb0bef0b"));
            DonorID = (ITTTextBoxColumn)AddControl(new Guid("ceb75f6b-d696-4713-b76d-b978b3c1252e"));
            tabPageRPCFirmOffers = (ITTTabPage)AddControl(new Guid("ddab07e1-8058-4194-bb1c-ae13c52fc71d"));
            RPCFirmPriceOffers = (ITTGrid)AddControl(new Guid("70d15093-37de-41bc-a0d6-0aea3ec9d6e7"));
            RPCApproved = (ITTCheckBoxColumn)AddControl(new Guid("f624609d-939e-424b-bb85-e7c186558bab"));
            RPCFirm = (ITTListBoxColumn)AddControl(new Guid("e81898f7-9cdb-4e0e-ba34-fd0d2d470770"));
            RPCProcedureSutCode = (ITTListBoxColumn)AddControl(new Guid("2bbb312e-2ef4-46c6-8849-ebce1fb71d5a"));
            RPCUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("ee7111af-6dfe-403a-b502-3b871c51eaf2"));
            RPCKDV = (ITTTextBoxColumn)AddControl(new Guid("c9292762-b998-434e-9f2d-0c9b156b6306"));
            RPCPrice = (ITTTextBoxColumn)AddControl(new Guid("f9261591-ed9f-4a96-b1de-9549ef7762a0"));
            RPCCertainPrice = (ITTTextBoxColumn)AddControl(new Guid("d3ca150c-2e93-40b3-adcb-c1f8b724f517"));
            RPCAcceptedRejected = (ITTCheckBoxColumn)AddControl(new Guid("ebc5dbb0-36bb-485d-b86c-7ea379521558"));
            RPCDonorID = (ITTTextBoxColumn)AddControl(new Guid("691bb477-0e6a-49d4-a6ef-c2ca880b114b"));
            tabPageCodelessOffers = (ITTTabPage)AddControl(new Guid("775bbe97-626f-444c-ae5f-1ee8ddccaf93"));
            CodelessFirmPriceOffers = (ITTGrid)AddControl(new Guid("0b2cdb0a-761d-4184-af5d-20f136e04738"));
            CodelessApproved = (ITTCheckBoxColumn)AddControl(new Guid("25ddc4f7-cbce-4177-811f-81dc2c1b7928"));
            CodelessFirm = (ITTListBoxColumn)AddControl(new Guid("4ca9bf62-8830-4b99-90f5-718a1cf23526"));
            CodelessUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("2f8032bd-1b07-429f-9ad7-7e0941b36e79"));
            CodelessKDV = (ITTTextBoxColumn)AddControl(new Guid("79d52cd2-3574-4bd7-8428-d776722ec29e"));
            CodelessPrice = (ITTTextBoxColumn)AddControl(new Guid("0704924d-17a4-42e5-8804-28e8553c93f6"));
            CodelessCertainPrice = (ITTTextBoxColumn)AddControl(new Guid("df80ff4f-dc3d-4751-9fd1-9deba69006c9"));
            CodelessAcceptedRejected = (ITTCheckBoxColumn)AddControl(new Guid("308838fe-7554-41a2-bf40-97911af22450"));
            CodelessDonorID = (ITTTextBoxColumn)AddControl(new Guid("8008b0bd-26b2-4645-96df-96bd41c23be1"));
            base.InitializeControls();
        }

        public DPADetailFirmOffersForm() : base("DIRECTPURCHASEACTIONDETAIL", "DPADetailFirmOffersForm")
        {
        }

        protected DPADetailFirmOffersForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}