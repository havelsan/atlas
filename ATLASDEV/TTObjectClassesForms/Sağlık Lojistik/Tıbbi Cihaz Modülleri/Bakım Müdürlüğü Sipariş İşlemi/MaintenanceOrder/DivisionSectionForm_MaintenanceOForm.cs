
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
    /// Sipariş Açma
    /// </summary>
    public partial class DivisionSectionForm_MaintenanceO : TTForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            ttenumcombobox1.SelectedIndexChanged += new TTControlEventDelegate(ttenumcombobox1_SelectedIndexChanged);
            WorkShop.SelectedObjectChanged += new TTControlEventDelegate(WorkShop_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            ttenumcombobox1.SelectedIndexChanged -= new TTControlEventDelegate(ttenumcombobox1_SelectedIndexChanged);
            WorkShop.SelectedObjectChanged -= new TTControlEventDelegate(WorkShop_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region DivisionSectionForm_MaintenanceO_tttoolstrip1_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
            switch (item.Name)
            {
                case "SiparisEmri":
                    pc.Add("VALUE", _MaintenanceOrder.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SiparisEmri), true, 1, parameters);
                    break;
                default:
                    break;
            }
#endregion DivisionSectionForm_MaintenanceO_tttoolstrip1_ItemClicked
        }

        private void ttenumcombobox1_SelectedIndexChanged()
        {
#region DivisionSectionForm_MaintenanceO_ttenumcombobox1_SelectedIndexChanged
   if( _MaintenanceOrder.ReferType != null)
                if( _MaintenanceOrder.ReferType == ReferTypeEnum.TeamRequest)
                  this.DropStateButton(Maintenance.States.Calibration);
#endregion DivisionSectionForm_MaintenanceO_ttenumcombobox1_SelectedIndexChanged
        }

        private void WorkShop_SelectedObjectChanged()
        {
#region DivisionSectionForm_MaintenanceO_WorkShop_SelectedObjectChanged
   this.ResponsibleUser.ListFilterExpression = " USERRESOURCES(RESOURCE='" + this.WorkShop.SelectedObject.ObjectID.ToString() + "').EXISTS";
#endregion DivisionSectionForm_MaintenanceO_WorkShop_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region DivisionSectionForm_MaintenanceO_PreScript
    switch (_MaintenanceOrder.MaintenanceOrderType.TypeCode)
            {
                case "IS":
                    this.DropStateButton(MaintenanceOrder.States.Repair);
                    this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                    this.DropStateButton(MaintenanceOrder.States.Calibration);
                    break;
                case "OS":
                    this.DropStateButton(MaintenanceOrder.States.Repair);
                    this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                    this.DropStateButton(MaintenanceOrder.States.Calibration);
                    break;
                case "KS":
                    this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                    this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                    this.DropStateButton(MaintenanceOrder.States.Repair);
                    break;
                case "YS":
                    this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                    this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                    this.DropStateButton(MaintenanceOrder.States.Calibration);
                    break;
                case "MS":
                    this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                    this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                    this.DropStateButton(MaintenanceOrder.States.Calibration);
                    break;
                case "BS":
                    this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                    this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                    this.DropStateButton(MaintenanceOrder.States.Calibration);
                    break;
                case "FS":
                    this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                    this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                    this.DropStateButton(MaintenanceOrder.States.Calibration);
                    break;
                default:
                    break;
            }
#endregion DivisionSectionForm_MaintenanceO_PreScript

            }
            
#region DivisionSectionForm_MaintenanceO_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == MaintenanceOrder.States.Repair)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _MaintenanceOrder.ObjectID.ToString());
                parameters.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SiparisEmri), true, 1, parameters);
            }
        }
        
#endregion DivisionSectionForm_MaintenanceO_Methods
    }
}