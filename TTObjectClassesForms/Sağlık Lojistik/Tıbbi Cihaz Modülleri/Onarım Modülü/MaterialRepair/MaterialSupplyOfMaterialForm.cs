
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
    public partial class MaterialSupplyOfMaterialForm : RepairBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdUsedStore.Click += new TTControlEventDelegate(cmdUsedStore_Click);
            cmdSectionRequirement.Click += new TTControlEventDelegate(cmdSectionRequirement_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdUsedStore.Click -= new TTControlEventDelegate(cmdUsedStore_Click);
            cmdSectionRequirement.Click -= new TTControlEventDelegate(cmdSectionRequirement_Click);
            base.UnBindControlEvents();
        }

        private void cmdUsedStore_Click()
        {
#region MaterialSupplyOfMaterialForm_cmdUsedStore_Click
   foreach (RepairConsumedMaterial repairMaterial in _MaterialRepair.RepairConsumedMaterials)
            {
                if(repairMaterial.SuppliedAmount != null)
                {
                    repairMaterial.SuppliedAmount = repairMaterial.RequestAmount ;
                }
            }
#endregion MaterialSupplyOfMaterialForm_cmdUsedStore_Click
        }

        private void cmdSectionRequirement_Click()
        {
#region MaterialSupplyOfMaterialForm_cmdSectionRequirement_Click
   MainStoreDefinition mainStore = CommonForm.SelectAllMainStoreDefinition(this);
            if (mainStore == null)
                throw new Exception(SystemMessage.GetMessage(988));

            SectionRequirement sectionRequirement = new SectionRequirement(_MaterialRepair.ObjectContext);
            sectionRequirement.CurrentStateDefID = SectionRequirement.States.New;
            sectionRequirement.Store = mainStore;
            sectionRequirement.DestinationStore = _MaterialRepair.WorkShop.Store;
            sectionRequirement.CMRAction = _MaterialRepair;
            sectionRequirement.OrderName = _MaterialRepair.FixedAssetDefinition.Name.ToString();
            sectionRequirement.OrderAmount = _MaterialRepair.FixedAssetMaterialAmount;


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
                stockActionSignDetail.SignUser = _Repair.ResponsibleUser;

                stockActionSignDetail = sectionRequirement.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.KısımAmiri;
                stockActionSignDetail.SignUser = (ResUser)Common.CurrentUser.UserObject;


                foreach (TTObjectState objectState in _MaterialRepair.GetStateHistory())
                {
                    if (objectState.StateDefID == MaterialRepair.States.PreControl)
                    {
                        stockActionSignDetail = sectionRequirement.StockActionSignDetails.AddNew();
                        stockActionSignDetail.SignUserType = SignUserTypeEnum.BölümAmiri;
                        stockActionSignDetail.SignUser = (ResUser)objectState.User.UserObject;
                    }

                }
            }
            
            sectionRequirement.Update();

            foreach (RepairConsumedMaterial repairMaterial in _MaterialRepair.RepairConsumedMaterials)
            {
                SectionRequirementMaterial sectionRequirementMaterial = sectionRequirement.SectionRequirementMaterials.AddNew();
                sectionRequirementMaterial.Material = repairMaterial.Material;
                sectionRequirementMaterial.AcceptedAmount = repairMaterial.RequestAmount;
                sectionRequirementMaterial.Amount = repairMaterial.RequestAmount;
                sectionRequirementMaterial.StockLevelType = StockLevelType.NewStockLevel;
            }
            sectionRequirement.CurrentStateDefID = SectionRequirement.States.Approval;
            this.cmdSectionRequirement.Enabled = false;
            this.DropStateButton(MaterialRepair.States.Repair);
#endregion MaterialSupplyOfMaterialForm_cmdSectionRequirement_Click
        }

        protected override void PreScript()
        {
#region MaterialSupplyOfMaterialForm_PreScript
    base.PreScript();
            
            bool completeSectionRe = true;
            
            foreach (RepairConsumedMaterial consumedMaterial in _MaterialRepair.RepairConsumedMaterials)
            {

                consumedMaterial.StoreInheld = consumedMaterial.Material.StockInheld(_MaterialRepair.WorkShop.Store);
            }
            foreach (SectionRequirement sectionRequirement in _MaterialRepair.SectionRequirements)
            {
                if (sectionRequirement.CurrentStateDefID != SectionRequirement.States.Completed && sectionRequirement.CurrentStateDefID != SectionRequirement.States.Cancelled)
                {
                    this.DropStateButton(MaterialRepair.States.Repair);
                    this.DropStateButton(MaterialRepair.States.MobileTeam);
                    this.cmdSectionRequirement.Enabled = false;
                    completeSectionRe = false;
                }
                else if (sectionRequirement.CurrentStateDefID == SectionRequirement.States.Completed)
                {
                    completeSectionRe = true;
                    foreach (SectionRequirementMaterial sectionRequirementMaterial in sectionRequirement.SectionRequirementMaterials)
                    {
                        foreach (RepairConsumedMaterial consumedMaterial in _MaterialRepair.RepairConsumedMaterials)
                        {
                            if (consumedMaterial.Material == sectionRequirementMaterial.Material)
                            {
                                consumedMaterial.SuppliedAmount = sectionRequirementMaterial.Amount;
                            }
                        }
                    }
                }
            }
            if (completeSectionRe)
            {
                if (_Repair.PrevState.StateDefID == MaterialRepair.States.MobileTeam)
                {
                    this.DropStateButton(MaterialRepair.States.Repair);
                }
                else if (_Repair.PrevState.StateDefID == MaterialRepair.States.Repair)
                {
                    this.DropStateButton(MaterialRepair.States.MobileTeam);
                }
            }
#endregion MaterialSupplyOfMaterialForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MaterialSupplyOfMaterialForm_PostScript
    base.PostScript(transDef);

            foreach (ITTGridRow row in RepairConsumedMaterials.Rows)
            {
                if (row.Cells["Material"].Value == null && row.Cells["SparePartMaterialDescription"].Value != null)
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(989,new string[] { row.Cells["SparePartMaterialDescription"].Value.ToString()}));
                if (Convert.ToDouble(row.Cells["SuppliedAmount"].Value) > Convert.ToDouble(row.Cells["RequestAmount"].Value))
                    throw new TTUtils.TTException(SystemMessage.GetMessage(990));
            }
#endregion MaterialSupplyOfMaterialForm_PostScript

            }
            
#region MaterialSupplyOfMaterialForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                foreach (RepairConsumedMaterial consumed in _MaterialRepair.RepairConsumedMaterials)
                {
                    if (consumed.SuppliedAmount > 0)
                    {
                        UsedConsumedMaterail usedConsumedMaterail = _MaterialRepair.UsedConsumedMaterails.AddNew();
                        usedConsumedMaterail.Material = consumed.Material;
                        usedConsumedMaterail.RequestAmount = consumed.RequestAmount;
                        usedConsumedMaterail.SuppliedAmount = consumed.SuppliedAmount;
                        usedConsumedMaterail.Amount = consumed.UsedAmount;
                        usedConsumedMaterail.Store = _MaterialRepair.WorkShop.Store;
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.New;
                    }
                }
                _MaterialRepair.RepairConsumedMaterials.DeleteChildren();
                _MaterialRepair.ObjectContext.Save();
            }

        }
        
#endregion MaterialSupplyOfMaterialForm_Methods
    }
}