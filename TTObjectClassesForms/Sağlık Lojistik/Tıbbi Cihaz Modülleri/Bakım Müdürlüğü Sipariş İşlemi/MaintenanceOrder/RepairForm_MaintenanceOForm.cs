
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
    /// Sipariş Genel İşlemleri
    /// </summary>
    public partial class RepairForm_MaintenanceO : TTForm
    {
        override protected void BindControlEvents()
        {
            RepairConsumedMaterials.CellValueChanged += new TTGridCellEventDelegate(RepairConsumedMaterials_CellValueChanged);
            cmdForkWorkStep.Click += new TTControlEventDelegate(cmdForkWorkStep_Click);
            cmdAddSignDetail.Click += new TTControlEventDelegate(cmdAddSignDetail_Click);
            cmdForkDemand.Click += new TTControlEventDelegate(cmdForkDemand_Click);
            chkOrderCompleted.CheckedChanged += new TTControlEventDelegate(chkOrderCompleted_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            RepairConsumedMaterials.CellValueChanged -= new TTGridCellEventDelegate(RepairConsumedMaterials_CellValueChanged);
            cmdForkWorkStep.Click -= new TTControlEventDelegate(cmdForkWorkStep_Click);
            cmdAddSignDetail.Click -= new TTControlEventDelegate(cmdAddSignDetail_Click);
            cmdForkDemand.Click -= new TTControlEventDelegate(cmdForkDemand_Click);
            chkOrderCompleted.CheckedChanged -= new TTControlEventDelegate(chkOrderCompleted_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void RepairConsumedMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region RepairForm_MaintenanceO_RepairConsumedMaterials_CellValueChanged
   if (RepairConsumedMaterials.CurrentCell.OwningColumn.Name == "Material")
            {
                int CurRow = RepairConsumedMaterials.CurrentCell.RowIndex;
                if (RepairConsumedMaterials.CurrentCell.Value != null)
                {
                    Material mat = (Material)_MaintenanceOrder.ObjectContext.GetObject((Guid)RepairConsumedMaterials.CurrentCell.Value, "MATERIAL");
                    RepairConsumedMaterials.Rows[CurRow].Cells["SparePartMaterialDescription"].Value = mat.Name;
                    RepairConsumedMaterials.Rows[CurRow].Cells["SparePartMaterialDescription"].ReadOnly = true;
                }
                else
                {
                    RepairConsumedMaterials.Rows[CurRow].Cells["SparePartMaterialDescription"].Value = null;
                    RepairConsumedMaterials.Rows[CurRow].Cells["SparePartMaterialDescription"].ReadOnly = false;
                }
            }
#endregion RepairForm_MaintenanceO_RepairConsumedMaterials_CellValueChanged
        }

        private void cmdForkWorkStep_Click()
        {
#region RepairForm_MaintenanceO_cmdForkWorkStep_Click
   if(_MaintenanceOrder.SenderSection != null && this.tttextbox2.Text !="")
            {
                WorkStep workStep = new WorkStep(_MaintenanceOrder.ObjectContext);
                workStep.StartDate = DateTime.Now.Date;
                workStep.WorkListDate = DateTime.Now.Date;
                workStep.Section = (ResDivisionSection)_MaintenanceOrder.SenderSection;
                workStep.SenderSection = _MaintenanceOrder.Section;
                workStep.FixedAssetMaterialDefinition = _MaintenanceOrder.FixedAssetMaterialDefinition;
                workStep.Description = this.tttextbox2.Text;
                workStep.RequestNo = "####";
                workStep.CurrentStateDefID = WorkStep.States.New;
                _MaintenanceOrder.WorkSteps.Add(workStep);
                _MaintenanceOrder.SenderSection = null;
            }
            else
            {
                string message = SystemMessage.GetMessage(11);
                throw new TTUtils.TTException(message);
            }
#endregion RepairForm_MaintenanceO_cmdForkWorkStep_Click
        }

        private void cmdAddSignDetail_Click()
        {
#region RepairForm_MaintenanceO_cmdAddSignDetail_Click
   this.cmdForkDemand.ReadOnly = false;
            if (_MaintenanceOrder.ServiceProcurementSignDetails.Count == 0)
            {

                CMRActionSignDetail cmrActionSignDetail = _MaintenanceOrder.ServiceProcurementSignDetails.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.Teknisyen;
                if(_MaintenanceOrder.GetState("Repair", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("Repair", true).User.UserObject;
                
                cmrActionSignDetail = _MaintenanceOrder.ServiceProcurementSignDetails.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.KısımAmiri;
                if(_MaintenanceOrder.GetState("DivisionSectionApproval", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("DivisionSectionApproval", true).User.UserObject;
                
                cmrActionSignDetail = _MaintenanceOrder.ServiceProcurementSignDetails.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.BölümAmiri;
                if(_MaintenanceOrder.GetState("DivisionChiefApproval", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("DivisionChiefApproval", true).User.UserObject;
                
                cmrActionSignDetail = _MaintenanceOrder.ServiceProcurementSignDetails.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.TeknikMudur;
                if(_MaintenanceOrder.GetState("TechnicalDirectorApproval", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("TechnicalDirectorApproval", true).User.UserObject;
                
                cmrActionSignDetail = _MaintenanceOrder.ServiceProcurementSignDetails.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                
                cmrActionSignDetail = _MaintenanceOrder.ServiceProcurementSignDetails.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.AtolyeIkmalKisimAmiri;
                if(_MaintenanceOrder.GetState("Approval", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("Approval", true).User.UserObject;
            }
#endregion RepairForm_MaintenanceO_cmdAddSignDetail_Click
        }

        private void cmdForkDemand_Click()
        {
#region RepairForm_MaintenanceO_cmdForkDemand_Click
   if(_MaintenanceOrder.PurchaseItemDef == null)
            {
                throw new TTException (SystemMessage.GetMessage(1221));
            }
            
            if(_MaintenanceOrder.DetailDescription  != null)
            {
                Demand demand = new Demand(_MaintenanceOrder.ObjectContext);
                demand.Description = _MaintenanceOrder.FixedAssetMaterialDefinition.Mark.ToString() + " Marka " + _MaintenanceOrder.FixedAssetMaterialDefinition.Model.ToString() + " Model " + _MaintenanceOrder.FixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString() + " Cihaz için Hizmet Alımı";
                demand.DemandType = DemandTypeEnum.ServicePurchase;
                demand.DemandDate = DateTime.Now.Date;
                demand.MasterResource = _MaintenanceOrder.ResDivision as ResSection;
                demand.CurrentStateDefID = Demand.States.New;
                DemandDetail demandDetail = new DemandDetail(_MaintenanceOrder.ObjectContext);
                demandDetail.Demand = demand;
                demandDetail.PurchaseItemDef = _MaintenanceOrder.PurchaseItemDef;
                demandDetail.DetailDescription = this.DetailDescription.Text ;
                demandDetail.RequestAmount = 1;
                _MaintenanceOrder.Demand = demand;
                this.DropStateButton(MaintenanceOrder.States.SupplyOfMaterial);
                this.AddStateButton(MaintenanceOrder.States.Fieldwork);
                this.cmdOK.Visible = false;
                this.cmdForkDemand.Enabled = false;
                this.PurchaseItem.Enabled = false;
                this.DetailDescription.Enabled = false;

            }
            else
            {
                string message = SystemMessage.GetMessage(12);
                throw new TTUtils.TTException(message);
            }
#endregion RepairForm_MaintenanceO_cmdForkDemand_Click
        }

        private void chkOrderCompleted_CheckedChanged()
        {
#region RepairForm_MaintenanceO_chkOrderCompleted_CheckedChanged
   this.SetStateButtons((bool)chkOrderCompleted.Value);
            if (chkOrderCompleted.Value == true)
            {
                this.RepairWorkLoad.Required = true;
                bool completedWorkStep = true;

                foreach (WorkStep workStep in _MaintenanceOrder.WorkSteps)
                {
                    if (workStep.CurrentStateDefID != WorkStep.States.Completed && workStep.CurrentStateDefID != WorkStep.States.Cancelled)
                    {
                        completedWorkStep = false;
                    }
                }
                if (completedWorkStep == false)
                {
                    string message = SystemMessage.GetMessage(13);
                    throw new TTUtils.TTException(message);
                }
            }
            else if (chkOrderCompleted.Value == false)
            {
                this.RepairWorkLoad.Required = false;
            }
            
         if( _MaintenanceOrder.ReferType != null)
                if( _MaintenanceOrder.ReferType == ReferTypeEnum.TeamRequest)
                  this.DropStateButton(MaintenanceOrder.States.Calibration);
#endregion RepairForm_MaintenanceO_chkOrderCompleted_CheckedChanged
        }

        protected override void PreScript()
        {
#region RepairForm_MaintenanceO_PreScript
    this.SetStateButtons((bool)chkOrderCompleted.Value);
            bool underGuaranty = _MaintenanceOrder.FixedAssetMaterialDefinition.IsUnderGuaranty();
            if (underGuaranty == true)
            {
                PurchaseItem.Enabled = false;
                cmdForkDemand.Enabled = false;
                DetailDescription.Enabled = false;
            }
            
            if(_MaintenanceOrder.ReferType != ReferTypeEnum.TeamRequest)
            {
                this.DropStateButton(MaintenanceOrder.States.SupplyApproval);
            }
            else
            {
                this.DropStateButton(MaintenanceOrder.States.HEK);
                this.DropStateButton(MaintenanceOrder.States.Calibration);
                
            }

            if (_MaintenanceOrder.UsedMaterialWorkSteps.Count > 0)
            {
                ArrayList usedMaterialWorkStepList = new ArrayList();
                foreach (UsedMaterialWorkStep usedMaterialWorkStep in _MaintenanceOrder.UsedMaterialWorkSteps)
                {
                    usedMaterialWorkStepList.Add(usedMaterialWorkStep);
                }
                for (int i = 0; i < usedMaterialWorkStepList.Count; i++)
                {
                    ((ITTObject)usedMaterialWorkStepList[i]).Delete();
                }
            }
            if (_MaintenanceOrder.WorkSteps.Count > 0)
            {
                foreach (WorkStep workStep in _MaintenanceOrder.WorkSteps)
                {
                    if (workStep.UsedConsumedMaterails.Count > 0)
                    {
                        foreach (UsedConsumedMaterail usedMaterial in workStep.UsedConsumedMaterails)
                        {
                            UsedMaterialWorkStep usedMaterialWorkStep = new UsedMaterialWorkStep(_MaintenanceOrder.ObjectContext);
                            usedMaterialWorkStep.Material = usedMaterial.Material;
                            usedMaterialWorkStep.Amount = usedMaterial.Amount;
                            foreach (StockOutMaterial stockOutMaterial in usedMaterial.StockOut.StockOutMaterials)
                            {
                                foreach (StockTransaction stockTransaction in stockOutMaterial.StockTransactions)
                                {
                                    foreach (StockTransactionDetail stockTransactionDetail in stockTransaction.OutStockTransactionDetails)
                                    {
                                        usedMaterialWorkStep.UnitPrice = stockTransactionDetail.InStockTransaction.UnitPrice.Value ;
                                    }
                                }
                            }
                            _MaintenanceOrder.UsedMaterialWorkSteps.Add(usedMaterialWorkStep);
                        }
                    }
                }
            }
#endregion RepairForm_MaintenanceO_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RepairForm_MaintenanceO_PostScript
    //if (objNextWorkShop.SelectedValue != null)
            //        {
            //            if (objNextResponsibleUser.SelectedValue == null)
            //            {
            //                throw new TTUtils.TTException("Gönderilecek Personel Seçilmedi.");
            //            }
            //            else
            //            {
            //                ResDivisionSubSection wsd = (ResDivisionSubSection)((TTListBox)objNextWorkShop).SelectedObject;
            //                WorkShopUserDefinition resp = (WorkShopUserDefinition)((TTListBox)objNextResponsibleUser).SelectedObject;
            //                MaintenanceOrder mo = _MaintenanceOrder;
            //                _MaintenanceOrder.AddWorkStep(mo, wsd, resp);
            //            }
            //        }
            foreach (Maintenance_ConsumedMaterial cm in _MaintenanceOrder.Maintenance_ConsumedMaterials)
            {
                if (_MaintenanceOrder.PrevState.StateDefID == MaintenanceOrder.States.SupplyOfMaterial)
                {
                    if ((double)cm.UsedAmount.Value > (double)cm.SuppliedAmount.Value)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(1222));
                }
                else
                {
                    if ((double)cm.UsedAmount.Value > (double)cm.RequestAmount.Value)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(1223));
                }
            }
#endregion RepairForm_MaintenanceO_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region RepairForm_MaintenanceO_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if(transDef.ToStateDefID == MaintenanceOrder.States.Fieldwork)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _MaintenanceOrder.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HizmetAlimiTalepFisi), true, 1, parameter);
            }
#endregion RepairForm_MaintenanceO_ClientSidePostScript

        }

#region RepairForm_MaintenanceO_Methods
        public void DropAllStateButtons()
        {
            this.DropStateButton(MaintenanceOrder.States.LastControl);
            this.DropStateButton(MaintenanceOrder.States.SupplyOfMaterial);
            this.DropStateButton(MaintenanceOrder.States.Fieldwork);
            this.DropStateButton(MaintenanceOrder.States.Calibration);
            this.DropStateButton(MaintenanceOrder.States.HEK);
        }

        public void SetStateButtons(bool orderCompleted)
        {
            DropAllStateButtons();
            if (orderCompleted)
            {
                if (_MaintenanceOrder.FixedAssetMaterialDefinition != null)
                {
                    if ((bool)_MaintenanceOrder.FixedAssetMaterialDefinition.FixedAssetDefinition.NeedCalibration == false)
                    {
                        this.AddStateButton(MaintenanceOrder.States.LastControl);
                    }
                }
                this.AddStateButton(MaintenanceOrder.States.Calibration);
                this.AddStateButton(MaintenanceOrder.States.HEK);
            }
            else
            {
                this.AddStateButton(MaintenanceOrder.States.SupplyOfMaterial);
            }
        }

        public void CheckWorkSteps(bool orderCompleted, MaintenanceOrder maintenanceOrder)
        {
            if (orderCompleted)
            {
                bool completedWorkStep = true;

                foreach (WorkStep workStep in maintenanceOrder.WorkSteps)
                {
                    if (workStep.CurrentStateDefID != WorkStep.States.Completed && workStep.CurrentStateDefID != WorkStep.States.Cancelled)
                    {
                        completedWorkStep = false;
                    }
                }
                if (completedWorkStep == false)
                {
                    string message = SystemMessage.GetMessage(13);
                    throw new TTUtils.TTException(message);
                }
            }
        }
        
        public void CheckRepairWorkLoad(bool orderCompleted, MaintenanceOrder maintenanceOrder)
        {
            if(maintenanceOrder.RepairWorkLoad == null)
            {
                string message = SystemMessage.GetMessage(14);
                throw new TTUtils.TTException(message);
            }
            
            
        }
        
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            
            if(transDef != null && transDef.ToStateDefID == MaintenanceOrder.States.Calibration)
            {                
                TTObjectContext ctx = new TTObjectContext(true);
                MaintenanceOrder maintenanceOrder = (MaintenanceOrder)ctx.GetObject(_MaintenanceOrder.ObjectID, typeof(MaintenanceOrder));
                if(maintenanceOrder.PrevState.PrevState.StateDefID == MaintenanceOrder.States.LastControl)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                    objectID.Add("VALUE", _MaintenanceOrder.ObjectID.ToString());
                    parameter.Add("TTOBJECTID", objectID);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_OnleyiciDuzelticiFaaliyetRaporu), true, 1, parameter);
                }
            }
        }
        
#endregion RepairForm_MaintenanceO_Methods
    }
}