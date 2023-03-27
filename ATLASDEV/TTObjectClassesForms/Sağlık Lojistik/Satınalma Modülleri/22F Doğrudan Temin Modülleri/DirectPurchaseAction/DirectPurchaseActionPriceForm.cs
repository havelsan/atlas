
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
    /// Piyasa Fiyat Araştırma, Mal Muayene Kabul ve Kullanım Tutanağı
    /// </summary>
    public partial class DirectPurchaseActionPriceForm : BaseDirectPurchaseActionForm
    {
        override protected void BindControlEvents()
        {
            grdFirms.CellContentClick += new TTGridCellEventDelegate(grdFirms_CellContentClick);
            grdFirms.CellValueChanged += new TTGridCellEventDelegate(grdFirms_CellValueChanged);
            DirectPurchaseActionDetailsGrid.CellContentClick += new TTGridCellEventDelegate(DirectPurchaseActionDetailsGrid_CellContentClick);
            DPARadioPharmaCeuticalDetGrid.CellContentClick += new TTGridCellEventDelegate(DPARadioPharmaCeuticalDetGrid_CellContentClick);
            DPAUBBCodelessGrid.CellContentClick += new TTGridCellEventDelegate(DPAUBBCodelessGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            grdFirms.CellContentClick -= new TTGridCellEventDelegate(grdFirms_CellContentClick);
            grdFirms.CellValueChanged -= new TTGridCellEventDelegate(grdFirms_CellValueChanged);
            DirectPurchaseActionDetailsGrid.CellContentClick -= new TTGridCellEventDelegate(DirectPurchaseActionDetailsGrid_CellContentClick);
            DPARadioPharmaCeuticalDetGrid.CellContentClick -= new TTGridCellEventDelegate(DPARadioPharmaCeuticalDetGrid_CellContentClick);
            DPAUBBCodelessGrid.CellContentClick -= new TTGridCellEventDelegate(DPAUBBCodelessGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void grdFirms_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseActionPriceForm_grdFirms_CellContentClick
   if (grdFirms.CurrentCell == null)
                return;

            switch (grdFirms.CurrentCell.OwningColumn.Name)
            {
                case "btnProposals":
                    DirectPurchaseFirmProposalForm frm = new DirectPurchaseFirmProposalForm();
                    if(this._DirectPurchaseAction.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                        frm.ShowEdit(this.FindForm(),(DirectPurchaseFirmProposal)grdFirms.CurrentCell.OwningRow.TTObject);
                    else
                        frm.ShowReadOnly(this.FindForm(),(DirectPurchaseFirmProposal)grdFirms.CurrentCell.OwningRow.TTObject);
                    break;
                default:
                    break;

            }
#endregion DirectPurchaseActionPriceForm_grdFirms_CellContentClick
        }

        private void grdFirms_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseActionPriceForm_grdFirms_CellValueChanged
   switch (grdFirms.Rows[rowIndex].Cells[columnIndex].OwningColumn.Name)
            {
                case "Firm":
                    {
                        DirectPurchaseFirmProposal firmProposal = (DirectPurchaseFirmProposal)grdFirms.Rows[rowIndex].TTObject;
                        foreach(DPADetailFirmPriceOffer priceOffer in firmProposal.DPADetailFirmPriceOffers)
                        {
                            if(grdFirms.Rows[rowIndex].Cells[columnIndex].Value != null)
                                priceOffer.Firm = firmProposal.Firm;//(FirmDefinition)grdFirms.Rows[rowIndex].Cells[columnIndex].Value;
                            else
                                priceOffer.Firm = null;
                        }
                    }
                    break;

                default:
                    break;
            }
            // A
#endregion DirectPurchaseActionPriceForm_grdFirms_CellValueChanged
        }

        private void DirectPurchaseActionDetailsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseActionPriceForm_DirectPurchaseActionDetailsGrid_CellContentClick
   if(DirectPurchaseActionDetailsGrid.CurrentCell == null)
                return;
            
            if (DirectPurchaseActionDetailsGrid.CurrentCell.OwningColumn.Name == DirectPurchaseActionDetailsGrid.Columns[Offers.Name].Name)
            {
                DPADetailFirmOffersForm frm = new DPADetailFirmOffersForm();
                if(this._DirectPurchaseAction.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    frm.ShowEdit(this.FindForm(), (DirectPurchaseActionDetail)DirectPurchaseActionDetailsGrid.CurrentCell.OwningRow.TTObject);
                else
                    frm.ShowReadOnly(this.FindForm(), (DirectPurchaseActionDetail)DirectPurchaseActionDetailsGrid.CurrentCell.OwningRow.TTObject);
            }
#endregion DirectPurchaseActionPriceForm_DirectPurchaseActionDetailsGrid_CellContentClick
        }

        private void DPARadioPharmaCeuticalDetGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseActionPriceForm_DPARadioPharmaCeuticalDetGrid_CellContentClick
   if(DPARadioPharmaCeuticalDetGrid.CurrentCell == null)
                return;
            
            if (DPARadioPharmaCeuticalDetGrid.CurrentCell.OwningColumn.Name == DPARadioPharmaCeuticalDetGrid.Columns[RPCOffers.Name].Name)
            {
                DPADetailFirmOffersForm frm = new DPADetailFirmOffersForm();
                if(this._DirectPurchaseAction.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    frm.ShowEdit(this.FindForm(), (DirectPurchaseActionDetail)DPARadioPharmaCeuticalDetGrid.CurrentCell.OwningRow.TTObject);
                else
                    frm.ShowReadOnly(this.FindForm(), (DirectPurchaseActionDetail)DPARadioPharmaCeuticalDetGrid.CurrentCell.OwningRow.TTObject);
            }
#endregion DirectPurchaseActionPriceForm_DPARadioPharmaCeuticalDetGrid_CellContentClick
        }

        private void DPAUBBCodelessGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseActionPriceForm_DPAUBBCodelessGrid_CellContentClick
   if(DPAUBBCodelessGrid.CurrentCell == null)
                return;
            
            if (DPAUBBCodelessGrid.CurrentCell.OwningColumn.Name == DPAUBBCodelessGrid.Columns[UBBCodelessOffers.Name].Name)
            {
                DPADetailFirmOffersForm frm = new DPADetailFirmOffersForm();
                if(this._DirectPurchaseAction.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    frm.ShowEdit(this.FindForm(), (DirectPurchaseActionDetail)DPAUBBCodelessGrid.CurrentCell.OwningRow.TTObject);
                else
                    frm.ShowReadOnly(this.FindForm(), (DirectPurchaseActionDetail)DPAUBBCodelessGrid.CurrentCell.OwningRow.TTObject);
            }
#endregion DirectPurchaseActionPriceForm_DPAUBBCodelessGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region DirectPurchaseActionPriceForm_PreScript
    base.PreScript();
            if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Titubb)
            {
                this.tabDirectPurchaseActionDetails.ShowTabPage(tabPageDirectPurchaseActionDetails);
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTName"].Required = true;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["KDV"].Required = true;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["Amount"].Required = true;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["CertainAmount"].Required = true;
                
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDPARadioPharmaDetails);
                ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RadioPharmaCeuticalMaterial"].Required = false;
                ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RPCAmount"].Required = false;
                ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RPCKDV"].Required = false;
                ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RPCCertainAmount"].Required = false;
                
                 this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDPAUBBCodelessDetails);
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["DPA22FCodelessMaterialDirectPurchaseActionDetail"].Required = false;
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["AmountDirectPurchaseActionDetail"].Required = false;
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["KDVDirectPurchaseActionDetail"].Required = false;
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["CertainAmountDirectPurchaseActionDetail"].Required = false;
            }
            else if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDirectPurchaseActionDetails);
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTName"].Required = false;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["KDV"].Required = false;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["Amount"].Required = false;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["CertainAmount"].Required = false;
                
                this.tabDirectPurchaseActionDetails.ShowTabPage(tabPageDPARadioPharmaDetails);
                 ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RadioPharmaCeuticalMaterial"].Required = true;
                ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RPCAmount"].Required = true;
                ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RPCKDV"].Required = true;
                ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RPCCertainAmount"].Required = true;
                
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDPAUBBCodelessDetails);
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["DPA22FCodelessMaterialDirectPurchaseActionDetail"].Required = false;
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["AmountDirectPurchaseActionDetail"].Required = false;
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["KDVDirectPurchaseActionDetail"].Required = false;
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["CertainAmountDirectPurchaseActionDetail"].Required = false;
            }
            else if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
            {
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDirectPurchaseActionDetails);
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTName"].Required = false;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["KDV"].Required = false;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["Amount"].Required = false;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["CertainAmount"].Required = false;
                
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDPARadioPharmaDetails);
                 ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RadioPharmaCeuticalMaterial"].Required = false;
                ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RPCAmount"].Required = false;
                ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RPCKDV"].Required = false;
                ((ITTGrid)this.DPARadioPharmaCeuticalDetGrid).Columns["RPCCertainAmount"].Required = false;
                
                this.tabDirectPurchaseActionDetails.ShowTabPage(tabPageDPAUBBCodelessDetails);
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["DPA22FCodelessMaterialDirectPurchaseActionDetail"].Required = true;
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["AmountDirectPurchaseActionDetail"].Required = true;
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["KDVDirectPurchaseActionDetail"].Required = true;
                ((ITTGrid)this.DPAUBBCodelessGrid).Columns["CertainAmountDirectPurchaseActionDetail"].Required = true;
            }
#endregion DirectPurchaseActionPriceForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DirectPurchaseActionPriceForm_PostScript
    base.PostScript(transDef);
            
            if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Titubb)
            {
                if(this.DirectPurchaseActionDetailsGrid.Rows.Count <= 0)
                    throw new Exception("'Teklif Değerlendirme' alanı boş geçilemez");
            }
            else if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                if(this.DPARadioPharmaCeuticalDetGrid.Rows.Count <= 0)
                    throw new Exception("'Teklif Değerlendirme' alanı boş geçilemez");
            }
            else if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
            {
                if(this.DPAUBBCodelessGrid.Rows.Count <= 0)
                    throw new Exception("'Teklif Değerlendirme' alanı boş geçilemez");
            }
            
            
            string materialName;
            if(transDef != null && transDef.ToStateDefID == DirectPurchaseAction.States.Completed)
            {
                foreach(DirectPurchaseActionDetail directPurchaseActionDetail in this._DirectPurchaseAction.DirectPurchaseActionDetails)
                {
                    materialName = null;
                    if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Titubb)
                        materialName = directPurchaseActionDetail.SUTName.ToString();
                    else if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
                        materialName = directPurchaseActionDetail.RadioPharmaceuticalMaterial.Name;
                    else if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
                        materialName = directPurchaseActionDetail.DPA22FCodelessMaterial.MaterialName;
                    
                    if(directPurchaseActionDetail.Cancelled.HasValue == true && directPurchaseActionDetail.Cancelled.Value != true)
                    {
                        if(directPurchaseActionDetail.FirmPriceOffers.Count == 0)
                        {
                            
                            throw new Exception("'" + materialName  + "' malzemesi için teklif değerlendirmesi yapılmamıştır. İşlem tamamlanamaz.");
                        }
                        else
                        {
                            bool approvedFound = false;
                            foreach(DPADetailFirmPriceOffer priceOffer in directPurchaseActionDetail.FirmPriceOffers)
                            {
                                if(priceOffer.Approved.HasValue == true && priceOffer.Approved.Value == true)
                                {
                                    approvedFound = true;
                                    if(priceOffer.DirectPurchaseFirmProposal != null)
                                    {
                                        if(priceOffer.DirectPurchaseFirmProposal.InvoiceDate.HasValue == false || String.IsNullOrEmpty(priceOffer.DirectPurchaseFirmProposal.InvoiceNumber) || priceOffer.DirectPurchaseFirmProposal.DeliveryDate.HasValue == false || String.IsNullOrEmpty(priceOffer.DirectPurchaseFirmProposal.DeliveryNumber))
                                            throw new Exception("Teklifi kabul edilen '"+ priceOffer.DirectPurchaseFirmProposal.Firm.Name +"' firması için Fatura Tarihi, Fatura Sayısı, İrsaliye Tarihi ve İrsaliye Numarası bilgilerinin girilmesi zorunludur. ");
                                    }
                                }
                                
                            }
                            if(!approvedFound)
                                throw new Exception("'" + materialName  + "' malzemesinin teklif değerlendirmesinde uygun bulunan teklif işaretlenmemiştir. İşlem tamamlanamaz.");
                        }
                    }
                }
                
                int examChiefCount = 0;
                int examMemberCount = 0;
                
                foreach (DirectPurchaseCommisionMember commisionMember in  this._DirectPurchaseAction.CommissionMembers)
                {
                    if(commisionMember.MemberDuty.HasValue && commisionMember.MemberDuty.Value.ToString() == DPACommisionMemberDutyEnum.Chief.ToString() && commisionMember.PrintOnMatInspection.HasValue == true && commisionMember.PrintOnMatInspection.Value == true)
                        examChiefCount++;
                    
                    
                    if(commisionMember.MemberDuty.HasValue && commisionMember.MemberDuty.Value.ToString() == DPACommisionMemberDutyEnum.Member.ToString() && commisionMember.PrintOnMatInspection.HasValue == true && commisionMember.PrintOnMatInspection.Value == true)
                        examMemberCount++;
                }
                if(examChiefCount == 0 && examMemberCount == 0)
                    throw new TTException("Komisyon üyeleri arasında, muayene kabulünü gerçekleştiren 1 başkan ve 2 üye seçilmelidir.");
                if(examChiefCount != 1)
                    throw new TTException("Komisyon üyeleri arasında, muayene kabulünü gerçekleştiren 1 başkan olmalıdır.");
                if(examMemberCount != 2)
                    throw new TTException("Komisyon üyeleri arasında, muayene kabulünü gerçekleştiren 2 üye olmalıdır.");
            }
#endregion DirectPurchaseActionPriceForm_PostScript

            }
            
#region DirectPurchaseActionPriceForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == DirectPurchaseAction.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _DirectPurchaseAction.ObjectID.ToString());
                parameters.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MaterialInspectionAndReceivingReport),true,1,parameters);
            }
        }
        
#endregion DirectPurchaseActionPriceForm_Methods
    }
}