
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class DirectPurchaseFirmProposalForm : TTForm
    {
        override protected void BindControlEvents()
        {
            DPADetailFirmPriceOffers.CellValueChanged += new TTGridCellEventDelegate(DPADetailFirmPriceOffers_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DPADetailFirmPriceOffers.CellValueChanged -= new TTGridCellEventDelegate(DPADetailFirmPriceOffers_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void DPADetailFirmPriceOffers_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseFirmProposalForm_DPADetailFirmPriceOffers_CellValueChanged
   switch (DPADetailFirmPriceOffers.Rows[rowIndex].Cells[columnIndex].OwningColumn.Name)
            {
                case "OfferedUBB":
                    {
                        if(DPADetailFirmPriceOffers.CurrentCell.Value != null)
                        {
                            ProductDefinition productDefinition = (ProductDefinition)this._DirectPurchaseFirmProposal.ObjectContext.GetObject((Guid)DPADetailFirmPriceOffers.CurrentCell.Value,typeof(ProductDefinition));
                            if(productDefinition != null)
                            {
                                bool foundMatchedSutCode = false;
                                if(productDefinition.ProductSUTMatchs.Count>0)
                                {
                                    DPADetailFirmPriceOffer priceOffer = (DPADetailFirmPriceOffer)DPADetailFirmPriceOffers.Rows[rowIndex].TTObject;
                                    if(priceOffer != null)
                                    {
                                        foreach(ProductSUTMatchDefinition sutMatch in productDefinition.ProductSUTMatchs)
                                        {
                                            if(priceOffer.DirectPurchaseActionDetail.SUTCode != null && sutMatch.SUTCode == priceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode)
                                            {
                                                DPADetailFirmPriceOffers.Rows[rowIndex].Cells["OfferedSUTCode"].Value = sutMatch.ObjectID;
                                                foundMatchedSutCode = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                            DPADetailFirmPriceOffers.Rows[rowIndex].Cells["OfferedSUTCode"].Value = null;
                    }
                    break;

                default:
                    break;
            }
#endregion DirectPurchaseFirmProposalForm_DPADetailFirmPriceOffers_CellValueChanged
        }

        protected override void PreScript()
        {
#region DirectPurchaseFirmProposalForm_PreScript
    base.PreScript();
            
            if(this._DirectPurchaseFirmProposal.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Titubb)
            {
                this.tabControlFirmProposal.ShowTabPage(tabPageFirmProposalUBB);
                this.tabControlFirmProposal.HideTabPage(tabPageFirmProposalRadioPharma);
                this.tabControlFirmProposal.HideTabPage(tabPageFirmProposalCodeless);
            }
            else if(this._DirectPurchaseFirmProposal.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                this.tabControlFirmProposal.HideTabPage(tabPageFirmProposalUBB);
                this.tabControlFirmProposal.ShowTabPage(tabPageFirmProposalRadioPharma);
                this.tabControlFirmProposal.HideTabPage(tabPageFirmProposalCodeless);
            }
              else if(this._DirectPurchaseFirmProposal.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
            {
                this.tabControlFirmProposal.HideTabPage(tabPageFirmProposalUBB);
                this.tabControlFirmProposal.HideTabPage(tabPageFirmProposalRadioPharma);
                this.tabControlFirmProposal.ShowTabPage(tabPageFirmProposalCodeless);
            }
            
            if(this._DirectPurchaseFirmProposal.DPADetailFirmPriceOffers.Count == 0)
            {
                foreach(DirectPurchaseActionDetail dpaDetail in  this._DirectPurchaseFirmProposal.DirectPurchaseAction.DirectPurchaseActionDetails)
                {
                    DPADetailFirmPriceOffer dpaDetailFirmOffer = new DPADetailFirmPriceOffer(this._DirectPurchaseFirmProposal.ObjectContext);
                    dpaDetailFirmOffer.DirectPurchaseActionDetail = dpaDetail;
                    dpaDetailFirmOffer.Firm = this._DirectPurchaseFirmProposal.Firm;
                    dpaDetailFirmOffer.DirectPurchaseFirmProposal = this._DirectPurchaseFirmProposal;
                }
            }
#endregion DirectPurchaseFirmProposalForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DirectPurchaseFirmProposalForm_PostScript
    base.PostScript(transDef);
            List<DPADetailFirmPriceOffer> removeRow = new List<DPADetailFirmPriceOffer>();
            if(this._DirectPurchaseFirmProposal.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Titubb)
            {
                string errorMsg = "Firmanın teklif ettiği \r\n";
                bool errorFound = false;
                foreach(ITTGridRow row in this.DPADetailFirmPriceOffers.Rows)
                {
                    DPADetailFirmPriceOffer priceOffer = (DPADetailFirmPriceOffer)row.TTObject;
                    if(row.Cells["OfferedUBB"].Value != null && priceOffer.DirectPurchaseActionDetail.SUTCode != null)
                    {
                        if(priceOffer.OfferedSUTCode == null || priceOffer.OfferedSUTCode.SUTCode != priceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode)
                        {
                            errorMsg += priceOffer.OfferedUBB.Name + "\r\n";
                            errorFound = true;
                        }
                    }
                }
                if(errorFound)
                    throw new Exception(errorMsg + " malzeme(ler)i için SUT kodu boş olmamalı ve talep edilen malzemenin SUT kodu ile aynı olmalıdır.");
                
                foreach(ITTGridRow row in this.DPADetailFirmPriceOffers.Rows)
                {
                    DPADetailFirmPriceOffer priceOffer = (DPADetailFirmPriceOffer)row.TTObject;
                    if(row.Cells["OfferedUBB"].Value == null)
                        removeRow.Add((DPADetailFirmPriceOffer)row.TTObject);
                }
                
                foreach(DPADetailFirmPriceOffer index in removeRow)
                {
                    ((ITTObject)index).Delete();
                }
            }
            else if(this._DirectPurchaseFirmProposal.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                foreach(ITTGridRow row in this.DPARadioPharmaFirmPriceOffersGrid.Rows)
                {
                    DPADetailFirmPriceOffer priceOffer = (DPADetailFirmPriceOffer)row.TTObject;
                    if(row.Cells["RPCUnitPrice"].Value == null)
                        removeRow.Add((DPADetailFirmPriceOffer)row.TTObject);
                }
                
                foreach(DPADetailFirmPriceOffer index in removeRow)
                {
                    ((ITTObject)index).Delete();
                }
            }
             else if(this._DirectPurchaseFirmProposal.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
            {
                foreach(ITTGridRow row in this.CodelessMaterialGrid.Rows)
                {
                    DPADetailFirmPriceOffer priceOffer = (DPADetailFirmPriceOffer)row.TTObject;
                    if(row.Cells["CodelessUnitPrice"].Value == null)
                        removeRow.Add((DPADetailFirmPriceOffer)row.TTObject);
                }
                
                foreach(DPADetailFirmPriceOffer index in removeRow)
                {
                    ((ITTObject)index).Delete();
                }
            }
#endregion DirectPurchaseFirmProposalForm_PostScript

            }
                }
}