
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
    /// K-Çizelgesi
    /// </summary>
    public partial class KScheduleCompletedForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region KScheduleCompletedForm_PreScript
    base.PreScript();
            
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

            foreach (KeyValuePair<Guid, object> drugDetails in drugsHashtable)
            {
                Material material = (Material)kSchedule.ObjectContext.GetObject(new Guid(drugDetails.Key.ToString()), "MATERIAL");
                KSchedule.KScheduleTotalMaterial kScheduleTotalMaterial = ((KSchedule.KScheduleTotalMaterial)drugDetails.Value);
                ITTGridRow addedRow = Drugs.Rows.Add();
                addedRow.Cells[0].Value = material.ObjectID;
                addedRow.Cells[1].Value = kScheduleTotalMaterial.TotalAmount;
                addedRow.Cells[2].Value = Convert.ToString(kScheduleTotalMaterial.QuarantinaNo);
            }
#endregion KScheduleCompletedForm_PreScript

            }
                }
}