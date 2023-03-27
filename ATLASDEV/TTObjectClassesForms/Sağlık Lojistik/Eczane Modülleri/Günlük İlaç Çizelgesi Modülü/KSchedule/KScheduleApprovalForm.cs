
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
    /// K-Çizelgesi İstek Hazırlama
    /// </summary>
    public partial class KScheduleApprovalForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            StockActionOutDetails.CellValueChanged += new TTGridCellEventDelegate(StockActionOutDetails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionOutDetails.CellValueChanged -= new TTGridCellEventDelegate(StockActionOutDetails_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void StockActionOutDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region KScheduleApprovalForm_StockActionOutDetails_CellValueChanged
   KScheduleMaterial kScheduleMaterial = ((KScheduleMaterial)this.StockActionOutDetails.Rows[rowIndex].TTObject); ;
            double amount = 0;
            foreach (KScheduleMaterial detail in _KSchedule.StockActionOutDetails)
            {
                if (detail.Material == kScheduleMaterial.Material)
                {
                    amount = amount + (double)detail.Amount;
                }
            }
            for (int i = 0; i < this.Drugs.Rows.Count; i++)
            {
                if (((Guid)this.Drugs.Rows[i].Cells["TDrug"].Value) == kScheduleMaterial.Material.ObjectID)
                {
                    this.Drugs.Rows[i].Cells["TAmount"].Value = amount;
                }
            }
#endregion KScheduleApprovalForm_StockActionOutDetails_CellValueChanged
        }

        protected override void PreScript()
        {
#region KScheduleApprovalForm_PreScript
    if ( _KSchedule is KScheduleDaily )
            {
                this.DropCurrentStateReport(typeof(TTReportClasses.I_KScheduleReport));
                this.DropCurrentStateReport(typeof(TTReportClasses.I_KScheduleBarcodeReport));
            }
            else
            {
                this.DropCurrentStateReport(typeof(TTReportClasses.I_KScheduleDailyReport));
            }
            
            KSchedule kSchedule = _KSchedule;
            Dictionary<Guid, object> drugsHashtable = new Dictionary<Guid, object>();
            foreach (KScheduleMaterial kScheduleMaterial in _KSchedule.StockActionOutDetails)
            {
                BindingList<Stock> stocks = Stock.GetStoreMaterial(kSchedule.ObjectContext, kSchedule.Store.ObjectID, kScheduleMaterial.Material.ObjectID);
                if (stocks.Count > 0)
                {
                    Stock stock = stocks[0];
                    kScheduleMaterial.StoreInheld = stock.Inheld;
                }
                if (drugsHashtable.ContainsKey(kScheduleMaterial.Material.ObjectID))
                {
                    KSchedule.KScheduleTotalMaterial material = ((KSchedule.KScheduleTotalMaterial)drugsHashtable[kScheduleMaterial.Material.ObjectID]);
                    material.QuarantinaNo = Convert.ToString(material.QuarantinaNo) + "," + Convert.ToString(kScheduleMaterial.QuarantinaNO);
                    material.TotalAmount = (double)material.TotalAmount + (double)kScheduleMaterial.Amount;
                    drugsHashtable[kScheduleMaterial.Material.ObjectID] = material;
                }
                else
                {
                    KSchedule.KScheduleTotalMaterial kScheludeTotalMaterial = new KSchedule.KScheduleTotalMaterial();
                    kScheludeTotalMaterial.QuarantinaNo = Convert.ToString(kScheduleMaterial.QuarantinaNO);
                    kScheludeTotalMaterial.TotalAmount = (double)kScheduleMaterial.Amount;
                    drugsHashtable.Add(kScheduleMaterial.Material.ObjectID, kScheludeTotalMaterial);
                }

            }

            bool infection = false;
            foreach (KeyValuePair<Guid, object> drugDetails in drugsHashtable)
            {
                Material material = (Material)kSchedule.ObjectContext.GetObject(new Guid(drugDetails.Key.ToString()), "MATERIAL");
                KSchedule.KScheduleTotalMaterial kScheduleTotalMaterial = ((KSchedule.KScheduleTotalMaterial)drugDetails.Value);
                ITTGridRow addedRow = Drugs.Rows.Add();
                addedRow.Cells[0].Value = material.ObjectID;
                addedRow.Cells[1].Value = kScheduleTotalMaterial.TotalAmount;
                addedRow.Cells[2].Value = Convert.ToString(kScheduleTotalMaterial.QuarantinaNo);
                if (((DrugDefinition)material).InfectionApproval.HasValue)
                {
                    if ((bool)((DrugDefinition)material).InfectionApproval)
                    {
                        infection = true;
                    }
                }
            }
            if (infection)
            {
                this.DropStateButton(KSchedule.States.RequestPreparation);
            }
            else
            {
                this.DropStateButton(KSchedule.States.InfectionApproval);
            }
#endregion KScheduleApprovalForm_PreScript

            }
            
#region KScheduleApprovalForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == KSchedule.States.RequestFulfilled)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                    objectID.Add("VALUE", _KSchedule.ObjectID.ToString());
                    parameter.Add("TTOBJECTID", objectID);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KScheduleReport), true, 1, parameter);
                    
                    
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameterBarcode = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> objectIDBARCODE = new TTReportTool.PropertyCache<object>();
                    objectIDBARCODE.Add("VALUE", _KSchedule.ObjectID.ToString());
                    parameterBarcode.Add("TTOBJECTID", objectIDBARCODE);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KScheduleBarcodeReport), true, 1, parameterBarcode);
                    
                    
                }
            }
        }
        
#endregion KScheduleApprovalForm_Methods
    }
}