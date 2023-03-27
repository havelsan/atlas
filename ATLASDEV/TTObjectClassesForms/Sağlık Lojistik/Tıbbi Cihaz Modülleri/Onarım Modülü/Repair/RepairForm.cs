
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
    /// Onarım
    /// </summary>
    public partial class RepairForm : RepairBaseForm
    {
        override protected void BindControlEvents()
        {
            RepairConsumedMaterials.CellValueChanged += new TTGridCellEventDelegate(RepairConsumedMaterials_CellValueChanged);
            tttoolstrip2.ItemClicked += new TTToolStripItemClicked(tttoolstrip2_ItemClicked);
            cmdForkDemand.Click += new TTControlEventDelegate(cmdForkDemand_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            RepairConsumedMaterials.CellValueChanged -= new TTGridCellEventDelegate(RepairConsumedMaterials_CellValueChanged);
            tttoolstrip2.ItemClicked -= new TTToolStripItemClicked(tttoolstrip2_ItemClicked);
            cmdForkDemand.Click -= new TTControlEventDelegate(cmdForkDemand_Click);
            base.UnBindControlEvents();
        }

        private void RepairConsumedMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region RepairForm_RepairConsumedMaterials_CellValueChanged
   if (RepairConsumedMaterials.CurrentCell.OwningColumn.Name == "Material")
            {
                int CurRow = RepairConsumedMaterials.CurrentCell.RowIndex;
                if (RepairConsumedMaterials.CurrentCell.Value != null)
                {
                    Material mat = (Material)_Repair.ObjectContext.GetObject((Guid)RepairConsumedMaterials.CurrentCell.Value, "MATERIAL");
                    RepairConsumedMaterials.Rows[CurRow].Cells["SparePartMaterialDescription"].Value = mat.Name;
                    RepairConsumedMaterials.Rows[CurRow].Cells["SparePartMaterialDescription"].ReadOnly = true;
                }
                else
                {
                    RepairConsumedMaterials.Rows[CurRow].Cells["SparePartMaterialDescription"].Value = null;
                    RepairConsumedMaterials.Rows[CurRow].Cells["SparePartMaterialDescription"].ReadOnly = false;
                }
            }
#endregion RepairForm_RepairConsumedMaterials_CellValueChanged
        }

        private void tttoolstrip2_ItemClicked(ITTToolStripItem item)
        {
#region RepairForm_tttoolstrip2_ItemClicked
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
#endregion RepairForm_tttoolstrip2_ItemClicked
        }

        private void cmdForkDemand_Click()
        {
#region RepairForm_cmdForkDemand_Click
   if (_Repair.DetailDescription != null)
            {
                Demand demand = new Demand(_Repair.ObjectContext);
                demand.Description = _Repair.FixedAssetMaterialDefinition.Mark.ToString() + " Marka " + _Repair.FixedAssetMaterialDefinition.Model.ToString() + " Model " + _Repair.FixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString() + " Cihaz için Hizmet Alımı";
                demand.DemandType = DemandTypeEnum.ServicePurchase;
                demand.DemandDate = DateTime.Now.Date;
                demand.MasterResource = _Repair.Section as ResSection;
                demand.CurrentStateDefID = Demand.States.New;
                DemandDetail demandDetail = new DemandDetail(_Repair.ObjectContext);
                demandDetail.Demand = demand;
                demandDetail.PurchaseItemDef = _Repair.PurchaseItemDef;
                demandDetail.DetailDescription = this.DetailDescription.Text;
                demandDetail.RequestAmount = 1;
                _Repair.Demand = demand;
                this.DropStateButton(Repair.States.Supply_Of_Materials);
                this.DropStateButton(Repair.States.HEK);
                this.DropStateButton(Repair.States.LastControl);
                this.DropStateButton(Repair.States.MobileTeam);
                this.DropStateButton(Repair.States.PreControl);
                this.DropStateButton(Repair.States.UpperStage);
                this.AddStateButton(Repair.States.FirmRepair);
                this.cmdOK.Visible = false;
                this.cmdForkDemand.Enabled = false;
                this.PurchaseItem.Enabled = false;
                this.DetailDescription.Enabled = false;
                //                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                //                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                //                objectID.Add("VALUE", _Repair.ObjectID.ToString());
                //                parameter.Add("TTOBJECTID", objectID);
                //                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HizmetAlimiTalepFisi), true, 1, parameter);
            }
            else
            {
                string message = SystemMessage.GetMessage(54);
                throw new TTUtils.TTException(message);
            }
#endregion RepairForm_cmdForkDemand_Click
        }

        protected override void PreScript()
        {
#region RepairForm_PreScript
    _Repair.StartDate = Common.RecTime();

            this.DropStateButton(Repair.States.FirmRepair);
            this.DropStateButton(Repair.States.Cancelled);
            this.DropStateButton(Repair.States.PreControl);
            foreach (ITTGridRow row in RepairConsumedMaterials.Rows)
            {
                if (row.Cells["Material"].Value != null)
                    row.Cells["SparePartMaterialDescription"].ReadOnly = true;
                if (_Repair.PrevState != null)
                {
                    if (_Repair.PrevState.StateDefID == Repair.States.Supply_Of_Materials)
                    {
                        row.Cells["Material"].ReadOnly = true;
                        row.Cells["RequestAmount"].ReadOnly = true;
                        row.Cells["SparePartMaterialDescription"].ReadOnly = true;

                    }
                }

            }

            if ((bool)_Repair.IsUnderGuaranty())
            {
                GuaranyStatuslabel.Text = "GARANTİ KAPSAMINDA - Garanti Bitiş Tarihi:" + _Repair.FixedAssetMaterialDefinition.GuarantyEndDate.Value.ToString();
                this.DropStateButton(Repair.States.Supply_Of_Materials);
                this.DropStateButton(Repair.States.LastControl);
                this.DropStateButton(Repair.States.HEK);
                this.DropStateButton(Repair.States.UpperStage);
                this.DropStateButton(Repair.States.FirmRepair);
                this.DemandTabPage.ReadOnly = true;
            }
            else
            {
                GuaranyStatuslabel.ForeColor = System.Drawing.Color.Red;
                GuaranyStatuslabel.Text = "GARANTİ DIŞI";
            }
            if(_Repair.FixedAssetMaterialDefinition != null)
            {
                _Repair.SenderAccountancy = _Repair.FixedAssetMaterialDefinition.Accountancy;
            }
            if (_Repair.UpperStage == null)
            {
                this.DropStateButton(Repair.States.MobileTeam);
                this.DropStateButton(Repair.States.UpperStage);
            }
            
            
            if(_Repair.UnitWorkLoadPrice == null)
            {
                IList loadPrices = _Repair.ObjectContext.QueryObjects("WORKLOADPRICEDEFINITION",string.Empty);
                if(loadPrices.Count > 0)
                {
                    WorkLoadPriceDefinition workLoadPriceDefinition = (WorkLoadPriceDefinition)loadPrices[0];
                    if(_Repair.ResponsibleUser.UserType == UserTypeEnum.BiomedicalEngineer)
                        _Repair.UnitWorkLoadPrice = workLoadPriceDefinition.EngineerWorkLoadPrice;
                    else
                        _Repair.UnitWorkLoadPrice = workLoadPriceDefinition.TechnicianWorkLoadPrice;
                }
            }
#endregion RepairForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RepairForm_PostScript
    base.PostScript(transDef);
#endregion RepairForm_PostScript

            }
            
#region RepairForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            //_Repair.RequestCMRAction.ObjectID  
            base.AfterContextSavedScript(transDef);
            Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            
            objectID.Add("VALUE", _Repair.RequestCMRAction.ObjectID.ToString());
            parameter.Add("TTOBJECTID", objectID);
            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_UnitMaintenanceReport), true, 1, parameter);
        }
        
#endregion RepairForm_Methods
    }
}