
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
    public partial class DivisionForm_MaintenanceO : TTForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            OrderTypeList.SelectedObjectChanged += new TTControlEventDelegate(OrderTypeList_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            OrderTypeList.SelectedObjectChanged -= new TTControlEventDelegate(OrderTypeList_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region DivisionForm_MaintenanceO_tttoolstrip1_ItemClicked
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
#endregion DivisionForm_MaintenanceO_tttoolstrip1_ItemClicked
        }

        private void OrderTypeList_SelectedObjectChanged()
        {
#region DivisionForm_MaintenanceO_OrderTypeList_SelectedObjectChanged
   OrderNO.Text = OrderNO.Text.Substring(0, 2).ToString() + "-" + _MaintenanceOrder.MaintenanceOrderType.TypeCode.ToString() + "-0000";
#endregion DivisionForm_MaintenanceO_OrderTypeList_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region DivisionForm_MaintenanceO_PreScript
    if (_MaintenanceOrder.RelatedReferToUpperLevel == null) //Manuel Başlatılmış
            {
                this.OrderNO.ReadOnly = false;
                this.RequestDate.ReadOnly = false;
                MilitaryUnit.SelectedObject = Common.GetCurrentMilitaryUnit(_MaintenanceOrder.ObjectContext);
            }
            else //Üst Kademeye Sevkten Gelmiş
            {
                this.OrderNO.ReadOnly = true;
                this.RequestDate.ReadOnly = true;
            }
            
//            string txtSeq = _MaintenanceOrder.RequestNoSeq.Value.ToString();
//            if (txtSeq.Length == 1)
//            {
//                txtSeq = "000" + txtSeq.ToString();
//            }
//            if (txtSeq.Length == 2)
//            {
//                txtSeq = "00" + txtSeq.ToString();
//            }
//            if (txtSeq.Length == 3)
//            {
//                txtSeq = "0" + txtSeq.ToString();
//            }
//            _MaintenanceOrder.RequestNo = _MaintenanceOrder.RequestNo.Substring(0, 6).ToString() + txtSeq.ToString();
#endregion DivisionForm_MaintenanceO_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DivisionForm_MaintenanceO_PostScript
    base.PostScript(transDef);
#endregion DivisionForm_MaintenanceO_PostScript

            }
                }
}