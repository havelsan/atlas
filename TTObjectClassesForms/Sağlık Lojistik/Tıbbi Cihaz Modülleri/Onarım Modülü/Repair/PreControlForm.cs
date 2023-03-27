
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
    /// Ön Kontrol / Onay
    /// </summary>
    public partial class PreControlForm : RepairBaseForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip2.ItemClicked += new TTToolStripItemClicked(tttoolstrip2_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip2.ItemClicked -= new TTToolStripItemClicked(tttoolstrip2_ItemClicked);
            base.UnBindControlEvents();
        }

        private void tttoolstrip2_ItemClicked(ITTToolStripItem item)
        {
#region PreControlForm_tttoolstrip2_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
            switch (item.Name)
            {
                case "BirlikSeviyesiBakimFormu":
                    pc.Add("VALUE", _Repair.ObjectID.ToString());
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_UnitMaintenanceReport), true, 1, parameters);
                    break;

                case "HasarveDurumTespitRaporu":
                    pc.Add("VALUE", _Repair.ObjectID.ToString());
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HasarveDurumTespitRaporu1), true, 1, parameters);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HasarveDurumTespitRaporu2), true, 1, parameters);
                    break;
            }
#endregion PreControlForm_tttoolstrip2_ItemClicked
        }

        protected override void PreScript()
        {
#region PreControlForm_PreScript
    if ((bool)_Repair.IsUnderGuaranty())
            {
                GuaranyStatuslabel.Text = "GARANTİ KAPSAMINDA - Garanti Bitiş Tarihi:" + _Repair.FixedAssetMaterialDefinition.GuarantyEndDate.Value.ToString();
                this.DropStateButton(Repair.States.Repair);
            }
            else
            {
                GuaranyStatuslabel.ForeColor = System.Drawing.Color.Red;
                GuaranyStatuslabel.Text = "GARANTİ DIŞI";
                this.DropStateButton(Repair.States.GuarantyRepair);
            }
#endregion PreControlForm_PreScript

            }
            
#region PreControlForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null && transDef.ToStateDefID == Repair.States.Repair)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _Repair.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_UnitMaintenanceReport), true, 1, parameter);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HasarveDurumTespitRaporu1), true, 1, parameter);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HasarveDurumTespitRaporu2), true, 1, parameter);
            }
        }
        
#endregion PreControlForm_Methods
    }
}