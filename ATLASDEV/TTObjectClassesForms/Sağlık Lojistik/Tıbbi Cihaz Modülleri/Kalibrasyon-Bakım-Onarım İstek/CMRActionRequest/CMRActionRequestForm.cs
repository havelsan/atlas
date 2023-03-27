
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
    /// İş İstek
    /// </summary>
    public partial class CMRActionRequestForm : CMRActionBaseForm
    {
        override protected void BindControlEvents()
        {
            FixedAssetMaterialDefinition.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetMaterialDefinition_SelectedObjectChanged);
            DeviceUser.SelectedObjectChanged += new TTControlEventDelegate(DeviceUser_SelectedObjectChanged);
            FixedAssetDefinition.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDefinition_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            FixedAssetMaterialDefinition.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetMaterialDefinition_SelectedObjectChanged);
            DeviceUser.SelectedObjectChanged -= new TTControlEventDelegate(DeviceUser_SelectedObjectChanged);
            FixedAssetDefinition.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDefinition_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void FixedAssetMaterialDefinition_SelectedObjectChanged()
        {
#region CMRActionRequestForm_FixedAssetMaterialDefinition_SelectedObjectChanged
   if (this.FixedAssetMaterialDefinition.SelectedObject != null)
            {
                _CMRActionRequest.FillEquipments();
                _CMRActionRequest.FiilUserParameter();

                bool inGuaranty = false;
                DateTime GuarantyEndDate = new DateTime();
                if (((FixedAssetMaterialDefinition)this.FixedAssetMaterialDefinition.SelectedObject).GuarantyEndDate.HasValue)
                {
                    GuarantyEndDate = ((FixedAssetMaterialDefinition)this.FixedAssetMaterialDefinition.SelectedObject).GuarantyEndDate.Value;
                }
                else
                {
                    inGuaranty = false;
                    TTVisual.InfoBox.Show("Cihazin Garanti Bitiş Tarihi girilmediği için Garanti Dışı olarak işlem yapılacaktır.", MessageIconEnum.InformationMessage);
                }
                if (DateTime.Compare(GuarantyEndDate, DateTime.Now) > 0)
                {
                    inGuaranty = true;
                }
                if (inGuaranty)
                {
                    GuaranyStatuslabel.ForeColor = System.Drawing.Color.Blue;
                    GuaranyStatuslabel.Text = "GARANTİ KAPSAMINDA - Garanti Bitiş Tarihi:" + ((FixedAssetMaterialDefinition)this.FixedAssetMaterialDefinition.SelectedObject).GuarantyEndDate.Value.ToString();
                }
                else
                {
                    GuaranyStatuslabel.ForeColor = System.Drawing.Color.Red;
                    GuaranyStatuslabel.Text = "GARANTİ DIŞI";
                }
                _CMRActionRequest.DeviceUser = ((FixedAssetMaterialDefinition)this.FixedAssetMaterialDefinition.SelectedObject).ResUser;

                if (((FixedAssetMaterialDefinition)this.FixedAssetMaterialDefinition.SelectedObject).ResUser != null)
                {
                    ResUser user = ((FixedAssetMaterialDefinition)this.FixedAssetMaterialDefinition.SelectedObject).ResUser;
                    if (String.IsNullOrEmpty(user.PhoneNumber) == false)
                    {
                        _CMRActionRequest.UserTel = user.PhoneNumber;
                    }
                }
            }
#endregion CMRActionRequestForm_FixedAssetMaterialDefinition_SelectedObjectChanged
        }

        private void DeviceUser_SelectedObjectChanged()
        {
#region CMRActionRequestForm_DeviceUser_SelectedObjectChanged
   if (this.DeviceUser.SelectedObject != null)
            {
                _CMRActionRequest.UserTel = ((ResUser)this.DeviceUser.SelectedObject).PhoneNumber;
            }
#endregion CMRActionRequestForm_DeviceUser_SelectedObjectChanged
        }

        private void FixedAssetDefinition_SelectedObjectChanged()
        {
#region CMRActionRequestForm_FixedAssetDefinition_SelectedObjectChanged
   if (this.FixedAssetDefinition.SelectedObject != null)
            {
                this.FixedAssetMaterialDefinition.SelectedObject = null;
                this.DeviceUser.SelectedObject  = null;
                this.UserTel.Text = string.Empty ;
                this.FixedAssetMaterialAmount.Text = string.Empty ;
                this.FaultDescription.Text = string.Empty ;
                FixedAssetDefinition fixedAssetDefinition = ((FixedAssetDefinition)this.FixedAssetDefinition.SelectedObject);
                IList stocks = Stock.GetStoreMaterial(_CMRActionRequest.ObjectContext, _CMRActionRequest.SenderSection.Store.ObjectID, fixedAssetDefinition.ObjectID);
                Stock fixedAssetStock = null;
                if (stocks.Count == 1)
                {
                    fixedAssetStock = (Stock)stocks[0];
                }
                else
                {
                    throw new TTException(SystemMessage.GetMessage(943));
                }
                if (fixedAssetDefinition.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                {
                    this.FixedAssetMaterialDefinition.ReadOnly = false;
                    this.FixedAssetMaterialDefinition.Required = true;
                    //this.DeviceUser.ReadOnly = false;
                    //this.DeviceUser.Required = true;
                    //this.UserTel.ReadOnly = false;
                    //this.UserTel.Required = true;
                    this.FixedAssetMaterialAmount.ReadOnly = true;
                    _CMRActionRequest.FixedAssetType = FixedAssetTypeEnum.SerialNO;
                    this.FixedAssetMaterialDefinition.ListFilterExpression = "STOCK = " + ConnectionManager.GuidToString(fixedAssetStock.ObjectID);
                }
                if (fixedAssetDefinition.StockCard.StockMethod == StockMethodEnum.StockNumbered)
                {
                    this.FixedAssetMaterialAmount.ReadOnly = false;
                    this.FixedAssetMaterialAmount.Required = true;
                    this.FixedAssetMaterialDefinition.ReadOnly = true;
                     this.FixedAssetMaterialDefinition.Required = false;
                    //this.DeviceUser.ReadOnly = true;
                    //this.UserTel.ReadOnly = true;
                    _CMRActionRequest.FixedAssetType = FixedAssetTypeEnum.StockNO;

                }
            }
#endregion CMRActionRequestForm_FixedAssetDefinition_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region CMRActionRequestForm_PreScript
    base.PreScript();
            
            if (((ITTObject)_CMRActionRequest).IsNew && _CMRActionRequest.CurrentStateDefID == CMRActionRequest.States.Request)
            {
                _CMRActionRequest.RequestNo = DateTime.Now.Year.ToString() + "-" + "####";
                if(this._CMRActionRequest.SenderSection.Store != null)
                    this.FixedAssetDefinition.ListFilterExpression = "OBJECTDEFID='f38f2111-0ee4-4b9f-9707-a63ac02d29f4' AND STOCKS.STORE = " + ConnectionManager.GuidToString(this._CMRActionRequest.SenderSection.Store.ObjectID) + " AND STOCKS.INHELD > 0";
                else
                    throw new Exception("Seçtiğiniz birimin deposu bulunmamaktadır.");
            }
#endregion CMRActionRequestForm_PreScript

            }
            
#region CMRActionRequestForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == CMRActionRequest.States.ClinicApproval)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _CMRActionRequest.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_IsIstekveIsEmri), true, 1, parameter);

                if(_CMRActionRequest.FixedAssetType == FixedAssetTypeEnum.SerialNO)
                   TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_UserMaintenanceReport), true, 1, parameter);
            }
        }
        
#endregion CMRActionRequestForm_Methods
    }
}