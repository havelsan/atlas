
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
    /// Mesaj İçerik
    /// </summary>
    public partial class UserMessageReadingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdSwitchToAction.Click += new TTControlEventDelegate(cmdSwitchToAction_Click);
            cmdSwitchToFolder.Click += new TTControlEventDelegate(cmdSwitchToFolder_Click);
            ViewReportButton.Click += new TTControlEventDelegate(ViewReportButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdSwitchToAction.Click -= new TTControlEventDelegate(cmdSwitchToAction_Click);
            cmdSwitchToFolder.Click -= new TTControlEventDelegate(cmdSwitchToFolder_Click);
            ViewReportButton.Click -= new TTControlEventDelegate(ViewReportButton_Click);
            base.UnBindControlEvents();
        }

        private void cmdSwitchToAction_Click()
        {
#region UserMessageReadingForm_cmdSwitchToAction_Click
   _UserMessage.OpenForm = true;
            this.Close();
#endregion UserMessageReadingForm_cmdSwitchToAction_Click
        }

        private void cmdSwitchToFolder_Click()
        {
#region UserMessageReadingForm_cmdSwitchToFolder_Click
   _UserMessage.OpenForm = true;
            this.Close();
#endregion UserMessageReadingForm_cmdSwitchToFolder_Click
        }

        private void ViewReportButton_Click()
        {
#region UserMessageReadingForm_ViewReportButton_Click
   if (this._UserMessage.ReportDefID.HasValue)
            {
                TTReportDef reportDef = TTObjectDefManager.Instance.ReportDefs[this._UserMessage.ReportDefID.Value];
                
                //Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

                //TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                //cache.Add("VALUE", _OutputSendingDocument.ObjectID.ToString());

                //parameters.Add("TTOBJECTID", cache);
                TTReportTool.TTReport.PrintReport(this, reportDef, true, 1, new Dictionary<string, TTReportTool.PropertyCache<object>>());
            }
#endregion UserMessageReadingForm_ViewReportButton_Click
        }

        protected override void PreScript()
        {
#region UserMessageReadingForm_PreScript
    if (this._UserMessage.ReportDefID.HasValue)
                ViewReportButton.Visible = true;
            else
                ViewReportButton.Visible = false;
            
            if(_UserMessage.BaseAction != null)
                cmdSwitchToAction.Visible = true;
            else
            {
                if(_UserMessage.Patient != null)
                    cmdSwitchToFolder.Visible = true;
            }
#endregion UserMessageReadingForm_PreScript

            }
                }
}