
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
    /// Test İstek Formu
    /// </summary>
    public partial class DPT_RequestForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdControl.Click += new TTControlEventDelegate(cmdControl_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdControl.Click -= new TTControlEventDelegate(cmdControl_Click);
            base.UnBindControlEvents();
        }

        private void cmdControl_Click()
        {
#region DPT_RequestForm_cmdControl_Click
   string checkString = _DrugProductionTest.SetParentProductionProcedure(SerialNo.Text);
            if (String.IsNullOrEmpty(checkString) == false)
                InfoBox.Show(checkString, MessageIconEnum.InformationMessage);
#endregion DPT_RequestForm_cmdControl_Click
        }

        protected override void PreScript()
        {
#region DPT_RequestForm_PreScript
    if (this._DrugProductionTest.FromMilitaryDrugProductionProcedure)
            {
                this.SerialNo.ReadOnly = true;
                this.cmdControl.Enabled = false;
            }
#endregion DPT_RequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DPT_RequestForm_PostScript
    base.PostScript(transDef);

            if (_DrugProductionTest.DrugProductionProcedure == null)
                InfoBox.Alert("İlgili üretim işlemi seçilmeden önce işlem devam ettirilemez.");
#endregion DPT_RequestForm_PostScript

            }
            
#region DPT_RequestForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> newParameterItem = new TTReportTool.PropertyCache<object>();
            newParameterItem.Add("Value", this._DrugProductionTest.ObjectID.ToString(), "T", "TTOBJECTID");
            parameters.Add("TTOBJECTID", newParameterItem);
            
            if (this._DrugProductionTest.FromMilitaryDrugProductionProcedure == false)
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_OnAnalizKontrolFormu), true, 0, parameters);
        }
        
#endregion DPT_RequestForm_Methods
    }
}