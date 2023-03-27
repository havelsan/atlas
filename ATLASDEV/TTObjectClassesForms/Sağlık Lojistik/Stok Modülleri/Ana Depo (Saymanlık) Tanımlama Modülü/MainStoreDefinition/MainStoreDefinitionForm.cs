
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
    /// Ana Depo(Saymanlık) Tanımları
    /// </summary>
    public partial class MainStoreDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            //MkysStore.CheckedChanged += new TTControlEventDelegate(MkysStore_CheckedChanged);
            cmdInfoCard.Click += new TTControlEventDelegate(cmdInfoCard_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            //MkysStore.CheckedChanged -= new TTControlEventDelegate(MkysStore_CheckedChanged);
            cmdInfoCard.Click -= new TTControlEventDelegate(cmdInfoCard_Click);
            base.UnBindControlEvents();
        }

//        private void MkysStore_CheckedChanged()
//        {
//#region MainStoreDefinitionForm_MkysStore_CheckedChanged
//   if (((TTVisual.TTCheckBox)(MkysStore)).Checked)
//            {
//                this.UnitStoreGetData.Required = true;
//                this.GoodsAccountant.Required = false;
//                this.GoodsResponsible.Required = false;
//                this.AccountManager.Required = false;
                
//            }
//            else
//            {
//                this.UnitStoreGetData.Required = false;
//                this.GoodsAccountant.Required = true;
//                this.GoodsResponsible.Required = true;
//                this.AccountManager.Required = true;
//            }
//#endregion MainStoreDefinitionForm_MkysStore_CheckedChanged
//        }

        private void cmdInfoCard_Click()
        {
#region MainStoreDefinitionForm_cmdInfoCard_Click
   if (_MainStoreDefinition.GoodsResponsible != null)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                //TTReportTool.PropertyCache<object> birlik = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _MainStoreDefinition.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                //birlik.Add("VALUE", _MainStoreDefinition.Accountancy.AccountancyMilitaryUnit.Name.ToString());
                //parameter.Add("BIRLIK",objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_InfoCardReport), true, 1, parameter);
            }
#endregion MainStoreDefinitionForm_cmdInfoCard_Click
        }
    }
}