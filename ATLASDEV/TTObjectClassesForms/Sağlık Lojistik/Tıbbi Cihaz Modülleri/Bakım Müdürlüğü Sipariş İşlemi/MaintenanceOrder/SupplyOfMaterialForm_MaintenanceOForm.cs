
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
    /// Malzeme Temini
    /// </summary>
    public partial class SupplyOfMaterialForm_MaintenanceO : TTForm
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
#region SupplyOfMaterialForm_MaintenanceO_cmdUsedStore_Click
   foreach (Maintenance_ConsumedMaterial maintenanceMaterial in _MaintenanceOrder.Maintenance_ConsumedMaterials)
            {
                if (maintenanceMaterial.SuppliedAmount != null)
                {
                    if (maintenanceMaterial.StoreInheld >= maintenanceMaterial.RequestAmount)
                    {
                        maintenanceMaterial.SuppliedAmount = maintenanceMaterial.RequestAmount;
                    }
                    else
                    {
                        throw new TTException(SystemMessage.GetMessage(1220));
                    }
                }
            }
#endregion SupplyOfMaterialForm_MaintenanceO_cmdUsedStore_Click
        }

        private void cmdSectionRequirement_Click()
        {
#region SupplyOfMaterialForm_MaintenanceO_cmdSectionRequirement_Click
   SectionRequirement sectionRequirement = new SectionRequirement(_MaintenanceOrder.ObjectContext);
            sectionRequirement.CurrentStateDefID = SectionRequirement.States.New;

            IList mainStores = MainStoreDefinition.GetAllMainStores(_MaintenanceOrder.ObjectContext);
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
            sectionRequirement.DestinationStore = _MaintenanceOrder.WorkShop.Store;
            sectionRequirement.CMRAction = _MaintenanceOrder;


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
                stockActionSignDetail.SignUser = _MaintenanceOrder.ResponsibleUser;

                stockActionSignDetail = sectionRequirement.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.KısımAmiri;
                stockActionSignDetail.SignUser = (ResUser)Common.CurrentUser.UserObject ;


                foreach (TTObjectState objectState in _MaintenanceOrder.GetStateHistory())
                {
                    if (objectState.StateDefID == MaintenanceOrder.States.DivisionChiefApproval)
                    {
                        stockActionSignDetail = sectionRequirement.StockActionSignDetails.AddNew();
                        stockActionSignDetail.SignUserType = SignUserTypeEnum.BölümAmiri;
                        stockActionSignDetail.SignUser = (ResUser)objectState.User.UserObject;
                    }

                }
            }
            
            switch (_MaintenanceOrder.MaintenanceOrderType.TypeCode)
            {
                case "IS":
                    sectionRequirement.OrderName = _MaintenanceOrder.OrderName ;
                    sectionRequirement.OrderAmount = _MaintenanceOrder.ManufacturingAmount ;
                    break;
                case "OS":
                    sectionRequirement.OrderName = _MaintenanceOrder.OrderName;
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "KS":
                    sectionRequirement.OrderName = _MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "YS":
                    sectionRequirement.OrderName = _MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "MS":
                    sectionRequirement.OrderName = _MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "BS":
                    sectionRequirement.OrderName = _MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "FS":
                    sectionRequirement.OrderName = _MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                default:
                    break;
            }
            sectionRequirement.Update();

            foreach (Maintenance_ConsumedMaterial orderMaterial in _MaintenanceOrder.Maintenance_ConsumedMaterials )
            {
                SectionRequirementMaterial sectionRequirementMaterial = sectionRequirement.SectionRequirementMaterials.AddNew();
                sectionRequirementMaterial.Material = orderMaterial.Material;
                sectionRequirementMaterial.AcceptedAmount = orderMaterial.RequestAmount;
                sectionRequirementMaterial.Amount = orderMaterial.RequestAmount ;
                sectionRequirementMaterial.StockLevelType = StockLevelType.NewStockLevel ;
            }

            SectionRequirementNewStateForm sectionRequirementNewStateForm = new SectionRequirementNewStateForm();
            sectionRequirementNewStateForm.ShowEdit(this.FindForm(), sectionRequirement, false);
            this.cmdSectionRequirement.Enabled = false ;
            this.DropStateButton(MaintenanceOrder.States.Repair);
            this.DropStateButton(MaintenanceOrder.States.Manufacturing);
            this.DropStateButton(MaintenanceOrder.States.SpecialWork);
#endregion SupplyOfMaterialForm_MaintenanceO_cmdSectionRequirement_Click
        }

        protected override void PreScript()
        {
#region SupplyOfMaterialForm_MaintenanceO_PreScript
    base.PreScript();
            bool completeSectionRe = true;
            foreach (Maintenance_ConsumedMaterial consumedMaterial in _MaintenanceOrder.Maintenance_ConsumedMaterials)
            {

                consumedMaterial.StoreInheld = consumedMaterial.Material.StockInheld(_MaintenanceOrder.WorkShop.Store);
            }
            
            foreach (SectionRequirement sectionRequirement in _MaintenanceOrder.SectionRequirements)
            {
                if (sectionRequirement.CurrentStateDefID != SectionRequirement.States.Completed && sectionRequirement.CurrentStateDefID != SectionRequirement.States.Cancelled)
                {
                    this.DropStateButton(MaintenanceOrder.States.Repair);
                    this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                    this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                    this.cmdSectionRequirement.Enabled = false;
                    completeSectionRe = false;
                }
                else if (sectionRequirement.CurrentStateDefID == SectionRequirement.States.Completed)
                {
                    completeSectionRe = true;
                    foreach (SectionRequirementMaterial sectionRequirementMaterial in sectionRequirement.SectionRequirementMaterials)
                    {
                        foreach (Maintenance_ConsumedMaterial consumedMaterial in _MaintenanceOrder.Maintenance_ConsumedMaterials)
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
                switch (_MaintenanceOrder.MaintenanceOrderType.TypeCode)
                {
                    case "IS":
                        this.DropStateButton(MaintenanceOrder.States.Repair);
                        this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                        break;
                    case "OS":
                        this.DropStateButton(MaintenanceOrder.States.Repair);
                        this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                        break;
                    case "KS":
                        this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                        this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                        break;
                    case "YS":
                        this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                        this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                        break;
                    case "MS":
                        this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                        this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                        break;
                    case "BS":
                        this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                        this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                        break;
                    case "FS":
                        this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                        this.DropStateButton(MaintenanceOrder.States.SpecialWork);
                        break;
                    default:
                        break;
                }
            }
#endregion SupplyOfMaterialForm_MaintenanceO_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SupplyOfMaterialForm_MaintenanceO_PostScript
    base.PostScript(transDef);

            foreach (ITTGridRow row in RepairConsumedMaterials.Rows)
            {
                if (row.Cells["Material"].Value == null && row.Cells["SparePartMaterialDescription"].Value != null)
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(989, new string[] {row.Cells["SparePartMaterialDescription"].Value.ToString()}));
            }
#endregion SupplyOfMaterialForm_MaintenanceO_PostScript

            }
            
#region SupplyOfMaterialForm_MaintenanceO_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                foreach (Maintenance_ConsumedMaterial consumed in _MaintenanceOrder.Maintenance_ConsumedMaterials)
                {
                    if (consumed.SuppliedAmount > 0)
                    {
                        UsedConsumedMaterail usedConsumedMaterail = _MaintenanceOrder.UsedConsumedMaterails.AddNew();
                        usedConsumedMaterail.Material = consumed.Material;
                        usedConsumedMaterail.RequestAmount = consumed.RequestAmount;
                        usedConsumedMaterail.SuppliedAmount = consumed.SuppliedAmount;
                        usedConsumedMaterail.Amount = consumed.UsedAmount;
                        usedConsumedMaterail.Store = _MaintenanceOrder.WorkShop.Store;
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.New;
                    }
                }
                _MaintenanceOrder.Maintenance_ConsumedMaterials.DeleteChildren();
                _MaintenanceOrder.ObjectContext.Save();
            }

        }
        
#endregion SupplyOfMaterialForm_MaintenanceO_Methods
    }
}