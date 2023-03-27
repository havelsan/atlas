
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
    public partial class ManufacturingForm_Maintenance0 : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdForkWorkStep.Click += new TTControlEventDelegate(cmdForkWorkStep_Click);
            chkOrderCompleted.CheckedChanged += new TTControlEventDelegate(chkOrderCompleted_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdForkWorkStep.Click -= new TTControlEventDelegate(cmdForkWorkStep_Click);
            chkOrderCompleted.CheckedChanged -= new TTControlEventDelegate(chkOrderCompleted_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void cmdForkWorkStep_Click()
        {
#region ManufacturingForm_Maintenance0_cmdForkWorkStep_Click
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
#endregion ManufacturingForm_Maintenance0_cmdForkWorkStep_Click
        }

        private void chkOrderCompleted_CheckedChanged()
        {
#region ManufacturingForm_Maintenance0_chkOrderCompleted_CheckedChanged
   this.SetStateButtons((bool)chkOrderCompleted.Value);
#endregion ManufacturingForm_Maintenance0_chkOrderCompleted_CheckedChanged
        }

        protected override void PreScript()
        {
#region ManufacturingForm_Maintenance0_PreScript
    base.PreScript();
            this.SetStateButtons((bool)chkOrderCompleted.Value);
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
#endregion ManufacturingForm_Maintenance0_PreScript

            }
            
#region ManufacturingForm_Maintenance0_Methods
        public void DropAllStateButtons()
        {
            this.DropStateButton(MaintenanceOrder.States.LastControl);
            this.DropStateButton(MaintenanceOrder.States.SupplyOfMaterial);
        }

        public void SetStateButtons(bool orderCompleted)
        {
            DropAllStateButtons();
            if (orderCompleted)
            {
                this.AddStateButton(MaintenanceOrder.States.LastControl);
            }
            else
            {
                this.AddStateButton(MaintenanceOrder.States.SupplyOfMaterial);
            }
        }
        
#endregion ManufacturingForm_Maintenance0_Methods
    }
}