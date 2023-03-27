
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
    /// Enfeksiyon Onay
    /// </summary>
    public partial class KScheduleInfectionForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            KScheduleMaterials.CellValueChanged += new TTGridCellEventDelegate(KScheduleMaterials_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            KScheduleMaterials.CellValueChanged -= new TTGridCellEventDelegate(KScheduleMaterials_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void KScheduleMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region KScheduleInfectionForm_KScheduleMaterials_CellValueChanged
   KScheduleMaterial kScheduleMaterial = ((KScheduleMaterial)this.KScheduleMaterials.Rows[rowIndex].TTObject); ;
            double amount = 0;
            foreach (KScheduleMaterial detail in _KSchedule.StockActionOutDetails)
            {
                if (detail.Material == kScheduleMaterial.Material)
                {
                    amount = amount + (double)detail.Amount;
                }
            }
            for (int i = 0; i < this.InfectionDrugs.Rows.Count; i++)
            {
                if (((Guid)this.InfectionDrugs.Rows[i].Cells["TDrug"].Value) == kScheduleMaterial.Material.ObjectID)
                {
                    this.InfectionDrugs.Rows[i].Cells["TAmount"].Value = amount;
                }
            }
#endregion KScheduleInfectionForm_KScheduleMaterials_CellValueChanged
        }

        protected override void PreScript()
        {
#region KScheduleInfectionForm_PreScript
    base.PreScript();
            
            KSchedule kSchedule = _KSchedule;
            Dictionary<Guid, object> drugsHashtable = new Dictionary<Guid, object>();
            foreach (KScheduleMaterial kScheduleMaterial in _KSchedule.StockActionOutDetails)
            {
                if (((DrugDefinition)kScheduleMaterial.Material).InfectionApproval.HasValue)
                {
                    if ((bool)((DrugDefinition)kScheduleMaterial.Material).InfectionApproval)
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
                }
            }

            foreach (KeyValuePair<Guid, object> drugDetails in drugsHashtable)
            {
                Material material = (Material)kSchedule.ObjectContext.GetObject(new Guid(drugDetails.Key.ToString()), "MATERIAL");
                KSchedule.KScheduleTotalMaterial kScheduleTotalMaterial = ((KSchedule.KScheduleTotalMaterial)drugDetails.Value);
                ITTGridRow addedRow = InfectionDrugs.Rows.Add();
                addedRow.Cells[0].Value = material.ObjectID;
                addedRow.Cells[1].Value = kScheduleTotalMaterial.TotalAmount;
                addedRow.Cells[2].Value = Convert.ToString(kScheduleTotalMaterial.QuarantinaNo);
            }
            
            if (this.KScheduleMaterials.Rows.Count > 0)
            {
                for (int i = 0; i < this.KScheduleMaterials.Rows.Count; i++)
                {
                    if (this.KScheduleMaterials.Rows[i].TTObject != null)
                    {
                        KScheduleMaterial kmaterial = (KScheduleMaterial)this.KScheduleMaterials.Rows[i].TTObject;
                        DrugDefinition dd = ((DrugDefinition)kmaterial.Material);
                        if (dd.InfectionApproval.HasValue)
                        {
                            if ((bool)dd.InfectionApproval)
                            {
                                ((TTGrid)this.KScheduleMaterials).Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
            }
#endregion KScheduleInfectionForm_PreScript

            }
            
#region KScheduleInfectionForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null && transDef.ToStateDefID == KSchedule.States.RequestFulfilled)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _KSchedule.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KScheduleReport), true, 1, parameter);
            }
        }
        
#endregion KScheduleInfectionForm_Methods
    }
}