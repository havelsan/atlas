
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
    public partial class ProductionForm_MaintenanceO : TTForm
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
#region ProductionForm_MaintenanceO_tttoolstrip1_ItemClicked
   if(_MaintenanceOrder.ObjectID != null)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _MaintenanceOrder.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SiparisEmri), true, 1, parameter);
            }
            else
                throw new Exception(SystemMessage.GetMessage(1224));
#endregion ProductionForm_MaintenanceO_tttoolstrip1_ItemClicked
        }

        private void OrderTypeList_SelectedObjectChanged()
        {
#region ProductionForm_MaintenanceO_OrderTypeList_SelectedObjectChanged
   RequestNo.Text = RequestNo.Text.Substring(0, 2).ToString() + "-" + _MaintenanceOrder.MaintenanceOrderType.TypeCode.ToString() + "-0000";
            
            if (_MaintenanceOrder.MaintenanceOrderType.TypeCode == "IS")
            {
                this.FixedAssetDefinition.ReadOnly = false;
                this.FixedAssetDefinition.Required = true;
                this.ManufacturingAmount.ReadOnly = false;
                this.ManufacturingAmount.Required = true;
            }
            else if (_MaintenanceOrder.MaintenanceOrderType.TypeCode == "OS")
            {
                //this.FixedAssetDefinition.ReadOnly = false;
                //this.FixedAssetDefinition.Required = true;
                this.SpecialWorkAmount.ReadOnly = false;
                this.SpecialWorkAmount.Required = true;
            }
            else
            {
                this.FixedAssetDefinition.ReadOnly = true;
                this.FixedAssetDefinition.Required = false;
                this.ManufacturingAmount.ReadOnly = true;
                this.ManufacturingAmount.Required = false;
            }
            
            if(_MaintenanceOrder.MaintenanceOrderType.TypeCode != "IS" && _MaintenanceOrder.MaintenanceOrderType.TypeCode != "OS")
            {
                if(_MaintenanceOrder.RelatedReferToUpperLevel == null)
                {
                    string message = SystemMessage.GetMessage(15);
                    throw new TTUtils.TTException(message);
                }
            }
            this.OrderTypeList.Enabled = false;
            if(_MaintenanceOrder.MaintenanceOrderType.TypeCode == "MS")
            {
                if(_MaintenanceOrder.FixedAssetMaterialDefinition != null)
                    _MaintenanceOrder.OrderName = _MaintenanceOrder.FixedAssetMaterialDefinition.Description;
            }
#endregion ProductionForm_MaintenanceO_OrderTypeList_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region ProductionForm_MaintenanceO_PreScript
    base.PreScript();
            string curdate = Common.RecTime().ToString();
            if (_MaintenanceOrder.OrderDate == null)
            {
                _MaintenanceOrder.OrderDate = Convert.ToDateTime(curdate);
            }
            if (_MaintenanceOrder.RelatedReferToUpperLevel == null) //Manuel Başlatılmış
            {
                this.OrderNO.ReadOnly = false;
                this.RequestDate.ReadOnly = false;
                //MilitaryUnit.SelectedObject = Common.GetCurrentMilitaryUnit(_MaintenanceOrder.ObjectContext);
            }
            else //Üst Kademeye Sevkten Gelmiş
            {
                this.OrderNO.ReadOnly = true;
                this.RequestDate.ReadOnly = true;
            }

            if (RequestNo.Text == "  -  -  " || RequestNo.Text == "  -  -")
            {
                RequestNo.Text = curdate.Substring(8, 2);
            }
            else
            {
                if(_MaintenanceOrder.RequestNoSeq.Value != null)
                {
                    string txtSeq = _MaintenanceOrder.RequestNoSeq.Value.ToString();
                    if (txtSeq.Length == 1)
                    {
                        txtSeq = "000" + txtSeq.ToString();
                    }
                    if (txtSeq.Length == 2)
                    {
                        txtSeq = "00" + txtSeq.ToString();
                    }
                    if (txtSeq.Length == 3)
                    {
                        txtSeq = "0" + txtSeq.ToString();
                    }
                    _MaintenanceOrder.RequestNo = _MaintenanceOrder.RequestNo.Substring(0, 6).ToString() + txtSeq.ToString();
                }
            }
            
            if(_MaintenanceOrder.OrderStatus == OrderStatusEnum.HEKFromFromExamination )
            {
              this.DropStateButton (MaintenanceOrder.States.Approval);
            }
#endregion ProductionForm_MaintenanceO_PreScript

            }
                }
}