
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
    /// İnceleme
    /// </summary>
    public partial class LBAnalysesForm : LBBaseForm
    {
        override protected void BindControlEvents()
        {
            IBFType.SelectedIndexChanged += new TTControlEventDelegate(IBFType_SelectedIndexChanged);
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IBFType.SelectedIndexChanged -= new TTControlEventDelegate(IBFType_SelectedIndexChanged);
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            base.UnBindControlEvents();
        }

        private void IBFType_SelectedIndexChanged()
        {
#region LBAnalysesForm_IBFType_SelectedIndexChanged
   cmdList.Enabled = true;
#endregion LBAnalysesForm_IBFType_SelectedIndexChanged
        }

        private void cmdList_Click()
        {
#region LBAnalysesForm_cmdList_Click
   if(IBFType.SelectedItem == null || string.IsNullOrEmpty(IBFYear.Text) == true)
            {
                InfoBox.Show(SystemMessage.GetMessage(83));
                return;
            }
            cmdList.Enabled = false;
            byte ibfType = Convert.ToByte(IBFType.SelectedIndex);
            int ibfYear = Convert.ToInt32(IBFYear.Text);
            _LBPurchaseProject.GetAvailableIBFs(true, ibfType, ibfYear);
            _LBPurchaseProject.GetAvailableIBFs(false, ibfType, ibfYear);
            ShowNeededGrids();
#endregion LBAnalysesForm_cmdList_Click
        }

        protected override void PreScript()
        {
#region LBAnalysesForm_PreScript
    base.PreScript();
            
            if(_LBPurchaseProject.IBFType != null)
                cmdList.Enabled = false;
#endregion LBAnalysesForm_PreScript

            }
                }
}