
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
    /// <summary>
    /// Firma Fiyat Teklif Formu
    /// </summary>
    public partial class DPADetailFirmOffersForm : TTForm
    {
        override protected void BindControlEvents()
        {
            FirmPriceOffers.CellValueChanged += new TTGridCellEventDelegate(FirmPriceOffers_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            FirmPriceOffers.CellValueChanged -= new TTGridCellEventDelegate(FirmPriceOffers_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void FirmPriceOffers_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DPADetailFirmOffersForm_FirmPriceOffers_CellValueChanged
   switch (FirmPriceOffers.Rows[rowIndex].Cells[columnIndex].OwningColumn.Name)
            {
                case "Approved":
                    {
                        if (Convert.ToBoolean(FirmPriceOffers.CurrentCell.Value) == true)
                        {
                            foreach (ITTGridRow row in FirmPriceOffers.Rows)
                            {
                                if (row.Index != rowIndex)
                                    row.Cells["Approved"].Value = false;
                            }
                        }
                    }
                    break;
                case "OfferedUBB":
                    {
                        if (FirmPriceOffers.CurrentCell.Value != null)
                        {
                            ProductDefinition productDefinition = (ProductDefinition)this._DirectPurchaseActionDetail.ObjectContext.GetObject((Guid)FirmPriceOffers.CurrentCell.Value, typeof(ProductDefinition));
                            if (productDefinition != null)
                            {
                                if (productDefinition.ProductSUTMatchs.Count > 0)
                                {
                                    FirmPriceOffers.Rows[rowIndex].Cells["OfferedSUTCode"].Value = productDefinition.ProductSUTMatchs[0].ObjectID;
                                }
                            }
                        }
                    }
                    break;

                case "UnitPrice":
                    {
                        if (_DirectPurchaseActionDetail.KDV != null)
                        {
                            if (FirmPriceOffers.CurrentCell.Value != null)
                            {
                                double price = Convert.ToDouble(FirmPriceOffers.CurrentCell.Value) + ((Convert.ToDouble(FirmPriceOffers.CurrentCell.Value) / 100) * Convert.ToDouble(_DirectPurchaseActionDetail.KDVdbl));
                                if (this._DirectPurchaseActionDetail.Amount != null)
                                    FirmPriceOffers.Rows[rowIndex].Cells["Price"].Value = price * Convert.ToDouble(this._DirectPurchaseActionDetail.Amount);

                                if (this._DirectPurchaseActionDetail.CertainAmount != null)
                                    FirmPriceOffers.Rows[rowIndex].Cells["CertainPrice"].Value = price * Convert.ToDouble(this._DirectPurchaseActionDetail.CertainAmount);


                                FirmPriceOffers.Rows[rowIndex].Cells["KDV"].Value = (Convert.ToDouble(FirmPriceOffers.CurrentCell.Value) / 100) * Convert.ToDouble(_DirectPurchaseActionDetail.KDVdbl);
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
#endregion DPADetailFirmOffersForm_FirmPriceOffers_CellValueChanged
        }

        protected override void PreScript()
        {
#region DPADetailFirmOffersForm_PreScript
    base.PreScript();
            
            if(this._DirectPurchaseActionDetail.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Titubb)
            {
                this.tabControlFirmOffers.ShowTabPage(tabPageUBBFirmOffers);
                ((ITTGrid)this.FirmPriceOffers).Columns["Approved"].Required = true;
                ((ITTGrid)this.FirmPriceOffers).Columns["Firm"].Required = true;
                ((ITTGrid)this.FirmPriceOffers).Columns["OfferedUBB"].Required = true;
                ((ITTGrid)this.FirmPriceOffers).Columns["UnitPrice"].Required = true;
                ((ITTGrid)this.FirmPriceOffers).Columns["AcceptedRejected"].Required = true;
                
                this.tabControlFirmOffers.HideTabPage(tabPageRPCFirmOffers);
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCApproved"].Required = false;
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCFirm"].Required = false;
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCUnitPrice"].Required = false;
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCAcceptedRejected"].Required = false;
                
                
                this.tabControlFirmOffers.HideTabPage(tabPageCodelessOffers);
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessApproved"].Required = false;
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessFirm"].Required = false;
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessUnitPrice"].Required = false;
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessAcceptedRejected"].Required = false;
                
                if (this.FirmPriceOffers.Rows.Count > 0)
                {
                    foreach (ITTGridRow row in this.FirmPriceOffers.Rows)
                    {
                        if (row.Cells["UnitPrice"].Value != null)
                        {
                            if (this._DirectPurchaseActionDetail.Amount != null)
                                row.Cells["Price"].Value = (double)this._DirectPurchaseActionDetail.Amount * Convert.ToDouble(row.Cells["UnitPrice"].Value);
                            if (this._DirectPurchaseActionDetail.CertainAmount != null)
                                row.Cells["CertainPrice"].Value = (double)this._DirectPurchaseActionDetail.CertainAmount * Convert.ToDouble(row.Cells["UnitPrice"].Value);
                            if (_DirectPurchaseActionDetail.KDV != null)
                            {
                                row.Cells["KDV"].Value = (Convert.ToDouble(row.Cells["UnitPrice"].Value) / 100) * Convert.ToDouble(_DirectPurchaseActionDetail.KDVdbl);
                            }
                        }
                    }
                }
            }
            else if(this._DirectPurchaseActionDetail.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                this.tabControlFirmOffers.HideTabPage(tabPageUBBFirmOffers);
                ((ITTGrid)this.FirmPriceOffers).Columns["Approved"].Required = false;
                ((ITTGrid)this.FirmPriceOffers).Columns["Firm"].Required = false;
                ((ITTGrid)this.FirmPriceOffers).Columns["OfferedUBB"].Required = false;
                ((ITTGrid)this.FirmPriceOffers).Columns["UnitPrice"].Required = false;
                ((ITTGrid)this.FirmPriceOffers).Columns["AcceptedRejected"].Required = false;
                
                this.tabControlFirmOffers.ShowTabPage(tabPageRPCFirmOffers);
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCApproved"].Required = true;
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCFirm"].Required = true;
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCUnitPrice"].Required = true;
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCAcceptedRejected"].Required = true;
                
                this.tabControlFirmOffers.HideTabPage(tabPageCodelessOffers);
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessApproved"].Required = false;
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessFirm"].Required = false;
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessUnitPrice"].Required = false;
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessAcceptedRejected"].Required = false;
                
                if (this.RPCFirmPriceOffers.Rows.Count > 0)
                {
                    foreach (ITTGridRow row in this.RPCFirmPriceOffers.Rows)
                    {
                        if (row.Cells["RPCUnitPrice"].Value != null)
                        {
                            if (this._DirectPurchaseActionDetail.Amount != null)
                                row.Cells["RPCPrice"].Value = (double)this._DirectPurchaseActionDetail.Amount * Convert.ToDouble(row.Cells["RPCUnitPrice"].Value);
                            if (this._DirectPurchaseActionDetail.CertainAmount != null)
                                row.Cells["RPCCertainPrice"].Value = (double)this._DirectPurchaseActionDetail.CertainAmount * Convert.ToDouble(row.Cells["RPCUnitPrice"].Value);
                            if (_DirectPurchaseActionDetail.KDV != null)
                            {
                                row.Cells["RPCKDV"].Value = (Convert.ToDouble(row.Cells["RPCUnitPrice"].Value) / 100) * Convert.ToDouble(_DirectPurchaseActionDetail.KDVdbl);
                            }
                        }
                    }
                }
            }
            else if(this._DirectPurchaseActionDetail.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
            {
                this.tabControlFirmOffers.HideTabPage(tabPageUBBFirmOffers);
                ((ITTGrid)this.FirmPriceOffers).Columns["Approved"].Required = false;
                ((ITTGrid)this.FirmPriceOffers).Columns["Firm"].Required = false;
                ((ITTGrid)this.FirmPriceOffers).Columns["OfferedUBB"].Required = false;
                ((ITTGrid)this.FirmPriceOffers).Columns["UnitPrice"].Required = false;
                ((ITTGrid)this.FirmPriceOffers).Columns["AcceptedRejected"].Required = false;
                
                this.tabControlFirmOffers.HideTabPage(tabPageRPCFirmOffers);
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCApproved"].Required = false;
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCFirm"].Required = false;
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCUnitPrice"].Required = false;
                ((ITTGrid)this.RPCFirmPriceOffers).Columns["RPCAcceptedRejected"].Required = false;
                                
                 this.tabControlFirmOffers.ShowTabPage(tabPageCodelessOffers);
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessApproved"].Required = true;
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessFirm"].Required = true;
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessUnitPrice"].Required = true;
                ((ITTGrid)this.CodelessFirmPriceOffers).Columns["CodelessAcceptedRejected"].Required = true;
                
                if (this.CodelessFirmPriceOffers.Rows.Count > 0)
                {
                    foreach (ITTGridRow row in this.CodelessFirmPriceOffers.Rows)
                    {
                        if (row.Cells["CodelessUnitPrice"].Value != null)
                        {
                            if (this._DirectPurchaseActionDetail.Amount != null)
                                row.Cells["CodelessPrice"].Value = (double)this._DirectPurchaseActionDetail.Amount * Convert.ToDouble(row.Cells["CodelessUnitPrice"].Value);
                            if (this._DirectPurchaseActionDetail.CertainAmount != null)
                                row.Cells["CodelessCertainPrice"].Value = (double)this._DirectPurchaseActionDetail.CertainAmount * Convert.ToDouble(row.Cells["CodelessUnitPrice"].Value);
                            if (_DirectPurchaseActionDetail.KDV != null)
                            {
                                row.Cells["CodelessKDV"].Value = (Convert.ToDouble(row.Cells["CodelessUnitPrice"].Value) / 100) * Convert.ToDouble(_DirectPurchaseActionDetail.KDVdbl);
                            }
                        }
                    }
                }
            }
#endregion DPADetailFirmOffersForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DPADetailFirmOffersForm_PostScript
    base.PostScript(transDef);
            foreach(DPADetailFirmPriceOffer dpaDetailFirmPriceOffer in this._DirectPurchaseActionDetail.FirmPriceOffers)
            {
                if(dpaDetailFirmPriceOffer.Approved.HasValue == true && dpaDetailFirmPriceOffer.Approved.Value == true)
                {
                    if(dpaDetailFirmPriceOffer.AcceptedRejected.HasValue == false || dpaDetailFirmPriceOffer.AcceptedRejected.Value != true)
                        throw new Exception("Kabul edilen teklifin, 'Teklifi Uygun Bulunanlar' kutucuğu işaretli olmalıdır.");
                }
            }

            foreach (DPADetailFirmPriceOffer dpaDetailFirmPriceOffer in this._DirectPurchaseActionDetail.FirmPriceOffers)
            {
                if (dpaDetailFirmPriceOffer.DirectPurchaseFirmProposal == null)
                {
                    DirectPurchaseFirmProposal directPurchaseFirmProposal = new DirectPurchaseFirmProposal(this._DirectPurchaseActionDetail.ObjectContext);
                    directPurchaseFirmProposal.Firm = dpaDetailFirmPriceOffer.Firm;
                    dpaDetailFirmPriceOffer.DirectPurchaseFirmProposal = directPurchaseFirmProposal;
                }
            }
#endregion DPADetailFirmOffersForm_PostScript

            }
                }
}