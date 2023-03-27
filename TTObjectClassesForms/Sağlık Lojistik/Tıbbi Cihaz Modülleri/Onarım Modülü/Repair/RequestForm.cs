
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
    /// Onarım İstek
    /// </summary>
    public partial class RequestForm : RepairBaseForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip2.ItemClicked += new TTToolStripItemClicked(tttoolstrip2_ItemClicked);
            FixedAsset.SelectedObjectChanged += new TTControlEventDelegate(FixedAsset_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip2.ItemClicked -= new TTToolStripItemClicked(tttoolstrip2_ItemClicked);
            FixedAsset.SelectedObjectChanged -= new TTControlEventDelegate(FixedAsset_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void tttoolstrip2_ItemClicked(ITTToolStripItem item)
        {
#region RequestForm_tttoolstrip2_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
            switch (item.Name)
            {
                case "IsIstekveIsEmri":
                    pc.Add("VALUE", _Repair.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_IsIstekveIsEmri), true, 1, parameters);
                    break;
                default:
                    break;
            }
#endregion RequestForm_tttoolstrip2_ItemClicked
        }

        private void FixedAsset_SelectedObjectChanged()
        {
#region RequestForm_FixedAsset_SelectedObjectChanged
   _Repair.FillEquipments();
#endregion RequestForm_FixedAsset_SelectedObjectChanged
        }
    }
}