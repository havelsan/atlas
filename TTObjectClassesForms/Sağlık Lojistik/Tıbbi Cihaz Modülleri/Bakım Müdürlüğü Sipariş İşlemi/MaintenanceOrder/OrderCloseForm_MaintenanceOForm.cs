
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
    /// Sipariş Kapatma
    /// </summary>
    public partial class OrderCloseForm_MaintenanceO : TTForm
    {
        override protected void BindControlEvents()
        {
            MaintenanceOrderCosts.CellValueChanged += new TTGridCellEventDelegate(MaintenanceOrderCosts_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MaintenanceOrderCosts.CellValueChanged -= new TTGridCellEventDelegate(MaintenanceOrderCosts_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void MaintenanceOrderCosts_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region OrderCloseForm_MaintenanceO_MaintenanceOrderCosts_CellValueChanged
   Currency LaborCost = 0;
            Currency SharpLaborCost = 0;
            Currency GeneralProcessingCost = 0;
            Currency DepreciationExpense = 0;
            Currency AvarageDirectLaborCost = 0;
            Currency AverageGeneralProcessingCost = 0;
            Currency AverageDepreciationExpense = 0;
            SharpLaborCost = ((Currency)MaintenanceOrderCosts.Rows[rowIndex].Cells["SharpLaborCost"].Value);
            if(MaintenanceOrderCosts.CurrentCell.OwningColumn.Name == "AvarageDirectLaborCost" && columnIndex == 1)
            {
                AvarageDirectLaborCost = ((Currency)MaintenanceOrderCosts.Rows[rowIndex].Cells["AvarageDirectLaborCost"].Value);
                LaborCost = SharpLaborCost * AvarageDirectLaborCost;
                MaintenanceOrderCosts.Rows[rowIndex].Cells["LaborCost"].Value = LaborCost;
            }

            if (MaintenanceOrderCosts.CurrentCell.OwningColumn.Name == "AverageGeneralProcessingCost" && columnIndex == 3)
            {
                AverageGeneralProcessingCost = ((Currency)MaintenanceOrderCosts.Rows[rowIndex].Cells["AverageGeneralProcessingCost"].Value);
                GeneralProcessingCost = SharpLaborCost * AverageGeneralProcessingCost;
                MaintenanceOrderCosts.Rows[rowIndex].Cells["GeneralProcessingCost"].Value = GeneralProcessingCost;
            }

            if (MaintenanceOrderCosts.CurrentCell.OwningColumn.Name == "AverageDepreciationExpense" && columnIndex == 5)
            {
                AverageDepreciationExpense = ((Currency)MaintenanceOrderCosts.Rows[rowIndex].Cells["AverageDepreciationExpense"].Value);
                DepreciationExpense = SharpLaborCost * AverageDepreciationExpense;
                MaintenanceOrderCosts.Rows[rowIndex].Cells["DepreciationExpense"].Value = DepreciationExpense;
            }
#endregion OrderCloseForm_MaintenanceO_MaintenanceOrderCosts_CellValueChanged
        }

        protected override void PreScript()
        {
#region OrderCloseForm_MaintenanceO_PreScript
    double totalMaterialPrice = 0;
            double totalWorkLoad = 0;
            foreach (UsedConsumedMaterail usedConsumedMaterial in _MaintenanceOrder.UsedConsumedMaterails)
            {
                if (usedConsumedMaterial.StockOut != null)
                {
                    foreach (StockOutMaterial stockOutMaterial in usedConsumedMaterial.StockOut.StockOutMaterials)
                    {
                        foreach (StockTransaction stockTransaction in stockOutMaterial.StockTransactions.Select(string.Empty))
                        {
                            foreach (StockTransactionDetail stockTransactionDetail in stockTransaction.OutStockTransactionDetails.Select(string.Empty))
                            {
                                usedConsumedMaterial.UnitPrice = stockTransactionDetail.InStockTransaction.UnitPrice.Value;
                            }
                        }
                    }
                }
                if(usedConsumedMaterial.UnitPrice != null)
                    totalMaterialPrice += (double)usedConsumedMaterial.Amount * (double)usedConsumedMaterial.UnitPrice;
            }

            foreach (UsedMaterialWorkStep usedMaterialWorkStep in _MaintenanceOrder.UsedMaterialWorkSteps)
            {
                totalMaterialPrice += (double)usedMaterialWorkStep.Amount *(double)usedMaterialWorkStep.UnitPrice;
            }

            foreach (WorkStep workStep in _MaintenanceOrder.WorkSteps)
            {
                if (workStep.Workload != null)// mca 
                {
                    totalWorkLoad += (double)workStep.Workload;
                }
            }
            if(_MaintenanceOrder.PreventiveTreatmentWorkLoad != null)
            {
                totalWorkLoad += (double)_MaintenanceOrder.PreventiveTreatmentWorkLoad ;
            }

            _MaintenanceOrder.TotalMaterialPrice = totalMaterialPrice;
            _MaintenanceOrder.TotalWorkLoad = totalWorkLoad + _MaintenanceOrder.RepairWorkLoad ;
            
            if(_MaintenanceOrder.MaintenanceOrderCosts.Count > 0)
            {
                _MaintenanceOrder.MaintenanceOrderCosts.DeleteChildren();
            }
            MaintenanceOrderCost maintenanceOrderCost = _MaintenanceOrder.MaintenanceOrderCosts.AddNew() ;
            maintenanceOrderCost.SharpLaborCost =_MaintenanceOrder.TotalWorkLoad ;
            maintenanceOrderCost.DirectMaterialExpense =  _MaintenanceOrder.TotalMaterialPrice ;
#endregion OrderCloseForm_MaintenanceO_PreScript

            }
            
#region OrderCloseForm_MaintenanceO_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == MaintenanceOrder.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _MaintenanceOrder.ObjectID.ToString());
                parameters.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CostReport), true, 1, parameters);
            }
        }
        
#endregion OrderCloseForm_MaintenanceO_Methods
    }
}