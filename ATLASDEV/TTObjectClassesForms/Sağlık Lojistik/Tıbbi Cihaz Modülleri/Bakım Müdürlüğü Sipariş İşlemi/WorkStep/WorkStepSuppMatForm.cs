
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
    /// Malzeme Temin
    /// </summary>
    public partial class WorkStepSuppMatForm : TTForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            cmdSectionRequirement.Click += new TTControlEventDelegate(cmdSectionRequirement_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            cmdSectionRequirement.Click -= new TTControlEventDelegate(cmdSectionRequirement_Click);
            base.UnBindControlEvents();
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region WorkStepSuppMatForm_tttoolstrip1_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            objectID.Add("VALUE", _WorkStep.ObjectID.ToString());
            parameters.Add("TTOBJECTID", objectID);
            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_WorkCard), true, 1, parameters);
#endregion WorkStepSuppMatForm_tttoolstrip1_ItemClicked
        }

        private void cmdSectionRequirement_Click()
        {
#region WorkStepSuppMatForm_cmdSectionRequirement_Click
   SectionRequirement sectionRequirement = new SectionRequirement(_WorkStep.ObjectContext);
            sectionRequirement.CurrentStateDefID = SectionRequirement.States.New;
            IList mainStores = MainStoreDefinition.GetAllMainStores(_WorkStep.ObjectContext);
            if (mainStores.Count == 0)
                throw new TTException(SystemMessage.GetMessage(372));
            if (mainStores.Count == 1)
            {
                sectionRequirement.Store = (MainStoreDefinition)mainStores[0];
            }
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (MainStoreDefinition mainStore in mainStores)
                    mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.ToString(), mainStore);

                string mkey = mSelectForm.GetMSItem(this, "İlgili Ana Depoyu Seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                    throw new TTException(SystemMessage.GetMessage(372));
                sectionRequirement.Store = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
            }
            sectionRequirement.DestinationStore = _WorkStep.WorkShop.Store;
            sectionRequirement.CMRAction = _WorkStep;

            if (sectionRequirement.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = sectionRequirement.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                if (sectionRequirement.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)sectionRequirement.Store).GoodsAccountant;

                stockActionSignDetail = sectionRequirement.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                if (sectionRequirement.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)sectionRequirement.Store).GoodsResponsible;

                stockActionSignDetail = sectionRequirement.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalzemeyiKullanan;
                stockActionSignDetail.SignUser = _WorkStep.ResponsibleUser;

                stockActionSignDetail = sectionRequirement.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.KısımAmiri;
                stockActionSignDetail.SignUser = (ResUser)Common.CurrentUser.UserObject;


                foreach (TTObjectState objectState in _WorkStep.GetStateHistory())
                {
                    if (objectState.StateDefID == WorkStep.States.WorkshopApproval)
                    {
                        stockActionSignDetail = sectionRequirement.StockActionSignDetails.AddNew();
                        stockActionSignDetail.SignUserType = SignUserTypeEnum.BölümAmiri;
                        stockActionSignDetail.SignUser = (ResUser)objectState.User.UserObject;
                    }

                }
            }

            switch (_WorkStep.MaintenanceOrder.MaintenanceOrderType.TypeCode)
            {
                case "IS":
                    sectionRequirement.OrderName = _WorkStep.MaintenanceOrder.OrderName ;
                    sectionRequirement.OrderAmount = _WorkStep.MaintenanceOrder.ManufacturingAmount ;
                    break;
                case "OS":
                    sectionRequirement.OrderName = _WorkStep.MaintenanceOrder.OrderName;
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "KS":
                    sectionRequirement.OrderName = _WorkStep.MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "YS":
                    sectionRequirement.OrderName = _WorkStep.MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "MS":
                    sectionRequirement.OrderName = _WorkStep.MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "BS":
                    sectionRequirement.OrderName = _WorkStep.MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "FS":
                    sectionRequirement.OrderName = _WorkStep.MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                default:
                    break;
            }
            sectionRequirement.Update();

            foreach (WorkStepConsumedMaterial orderMaterial in _WorkStep.WorkStepConsumedMaterials)
            {
                SectionRequirementMaterial sectionRequirementMaterial = sectionRequirement.SectionRequirementMaterials.AddNew();
                sectionRequirementMaterial.Material = orderMaterial.Material;
                sectionRequirementMaterial.AcceptedAmount = orderMaterial.RequestAmount ;
                sectionRequirementMaterial.Amount = orderMaterial.RequestAmount ;
                sectionRequirementMaterial.StockLevelType = StockLevelType.NewStockLevel ;
            }
            SectionRequirementNewStateForm sectionRequirementNewStateForm = new SectionRequirementNewStateForm();
            sectionRequirementNewStateForm.ShowEdit(this.FindForm(), sectionRequirement, false);
            this.cmdSectionRequirement.Enabled = false ;
            this.DropStateButton(WorkStep.States.WorkStepRepair);
#endregion WorkStepSuppMatForm_cmdSectionRequirement_Click
        }

        protected override void PreScript()
        {
#region WorkStepSuppMatForm_PreScript
    base.PreScript();
            foreach (SectionRequirement sectionRequirement in _WorkStep.SectionRequirements)
            {
                if (sectionRequirement.CurrentStateDefID != SectionRequirement.States.Completed && sectionRequirement.CurrentStateDefID != SectionRequirement.States.Cancelled)
                {
                    this.DropStateButton(WorkStep.States.WorkStepRepair);
                    this.cmdSectionRequirement.Enabled = false;
                }
                else if(sectionRequirement.CurrentStateDefID == SectionRequirement.States.Completed)
                {
                    foreach (SectionRequirementMaterial sectionRequirementMaterial in sectionRequirement.SectionRequirementMaterials)
                    {
                        foreach (WorkStepConsumedMaterial workStepConsumedMaterial in _WorkStep.WorkStepConsumedMaterials)
                        {
                            if (sectionRequirementMaterial.Material == workStepConsumedMaterial.Material)
                            {
                                workStepConsumedMaterial.SuppliedAmount = sectionRequirementMaterial.Amount;
                            }
                        }

                    }
                }
            }
#endregion WorkStepSuppMatForm_PreScript

            }
            
#region WorkStepSuppMatForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                foreach (WorkStepConsumedMaterial consumed in _WorkStep.WorkStepConsumedMaterials )
                {
                    if (consumed.SuppliedAmount > 0)
                    {
                        UsedConsumedMaterail usedConsumedMaterail = _WorkStep.UsedConsumedMaterails.AddNew();
                        usedConsumedMaterail.Material = consumed.Material;
                        usedConsumedMaterail.RequestAmount = consumed.RequestAmount;
                        usedConsumedMaterail.SuppliedAmount = consumed.SuppliedAmount;
                        usedConsumedMaterail.Amount = consumed.UsedAmount;
                        usedConsumedMaterail.Store = _WorkStep.WorkShop.Store;
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.New;
                    }
                }
                _WorkStep.WorkStepConsumedMaterials.DeleteChildren();
                _WorkStep.ObjectContext.Save();
            }

        }
        
#endregion WorkStepSuppMatForm_Methods
    }
}