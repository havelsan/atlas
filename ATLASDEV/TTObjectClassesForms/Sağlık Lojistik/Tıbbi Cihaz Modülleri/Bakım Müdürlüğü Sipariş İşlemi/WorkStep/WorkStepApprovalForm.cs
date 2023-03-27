
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
    /// Yardımcı Atölye İş İstek
    /// </summary>
    public partial class WorkStepApprovalForm : TTForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            WorkShop.SelectedObjectChanged += new TTControlEventDelegate(WorkShop_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            WorkShop.SelectedObjectChanged -= new TTControlEventDelegate(WorkShop_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region WorkStepApprovalForm_tttoolstrip1_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            objectID.Add("VALUE", _WorkStep.ObjectID.ToString());
            parameters.Add("TTOBJECTID", objectID);
            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_WorkCard), true, 1, parameters);
#endregion WorkStepApprovalForm_tttoolstrip1_ItemClicked
        }

        private void WorkShop_SelectedObjectChanged()
        {
#region WorkStepApprovalForm_WorkShop_SelectedObjectChanged
   this.ResponsibleUser.ListFilterExpression = " USERRESOURCES(RESOURCE='" + this.WorkShop.SelectedObject.ObjectID.ToString() + "').EXISTS";
#endregion WorkStepApprovalForm_WorkShop_SelectedObjectChanged
        }
    }
}