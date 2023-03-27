
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
    /// Ambalajlama İş İstek
    /// </summary>
    public partial class PackagingDepartmentActionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdSectionRequirement.Click += new TTControlEventDelegate(cmdSectionRequirement_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdSectionRequirement.Click -= new TTControlEventDelegate(cmdSectionRequirement_Click);
            base.UnBindControlEvents();
        }

        private void cmdSectionRequirement_Click()
        {
#region PackagingDepartmentActionForm_cmdSectionRequirement_Click
   SectionRequirement sectionRequirement = new SectionRequirement(_PackagingDepartmentAction.ObjectContext);
            sectionRequirement.CurrentStateDefID = SectionRequirement.States.New;
            IList mainStores = MainStoreDefinition.GetAllMainStores(_PackagingDepartmentAction.ObjectContext);
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
                    throw new TTException(SystemMessage.GetMessage(371));
                sectionRequirement.Store = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
            }
            sectionRequirement.DestinationStore = _PackagingDepartmentAction.ResDivision.Store;
            sectionRequirement.CMRAction = _PackagingDepartmentAction ;

            switch (_PackagingDepartmentAction.MaintenanceOrder.MaintenanceOrderType.TypeCode)
            {
                case "IS":
                    sectionRequirement.OrderName = _PackagingDepartmentAction.MaintenanceOrder.OrderName;
                    sectionRequirement.OrderAmount = _PackagingDepartmentAction.MaintenanceOrder.ManufacturingAmount;
                    break;
                case "OS":
                    sectionRequirement.OrderName = _PackagingDepartmentAction.MaintenanceOrder.OrderName;
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "KS":
                    sectionRequirement.OrderName = _PackagingDepartmentAction.MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "YS":
                    sectionRequirement.OrderName = _PackagingDepartmentAction.MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "MS":
                    sectionRequirement.OrderName = _PackagingDepartmentAction.MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "BS":
                    sectionRequirement.OrderName = _PackagingDepartmentAction.MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                case "FS":
                    sectionRequirement.OrderName = _PackagingDepartmentAction.MaintenanceOrder.FixedAssetMaterialDefinition.Description.ToString();
                    sectionRequirement.OrderAmount = 1;
                    break;
                default:
                    break;
            }
            sectionRequirement.Update();

            foreach (PackagingDepConsMaterial orderMaterial in _PackagingDepartmentAction.PackagingDepConsMaterials)
            {
                SectionRequirementMaterial sectionRequirementMaterial = sectionRequirement.SectionRequirementMaterials.AddNew();
                sectionRequirementMaterial.Material = orderMaterial.Material;
                sectionRequirementMaterial.AcceptedAmount = orderMaterial.RequestAmount;
                sectionRequirementMaterial.Amount = orderMaterial.RequestAmount;
                sectionRequirementMaterial.StockLevelType = StockLevelType.NewStockLevel;
            }
            SectionRequirementNewStateForm sectionRequirementNewStateForm = new SectionRequirementNewStateForm();
            sectionRequirementNewStateForm.ShowEdit(this.FindForm(), sectionRequirement, false);
            this.cmdSectionRequirement.Enabled = false;
            this.DropStateButton(PackagingDepartmentAction.States.Completed);
#endregion PackagingDepartmentActionForm_cmdSectionRequirement_Click
        }

        protected override void PreScript()
        {
#region PackagingDepartmentActionForm_PreScript
    base.PreScript();
            foreach (SectionRequirement sectionRequirement in _PackagingDepartmentAction.SectionRequirements)
            {
                if (sectionRequirement.CurrentStateDefID != SectionRequirement.States.Completed && sectionRequirement.CurrentStateDefID != SectionRequirement.States.Cancelled)
                {
                    this.DropStateButton(PackagingDepartmentAction.States.Completed);
                    this.cmdSectionRequirement.Enabled = false;
                }
                else if(sectionRequirement.CurrentStateDefID == SectionRequirement.States.Completed)
                {
                    foreach (SectionRequirementMaterial sectionRequirementMaterial in sectionRequirement.SectionRequirementMaterials)
                    {
                        foreach (UsedConsumedMaterail usedConsumedMaterail in _PackagingDepartmentAction.UsedConsumedMaterails)
                        {
                            if (sectionRequirementMaterial.Material == usedConsumedMaterail.Material)
                            {
                                usedConsumedMaterail.SuppliedAmount = sectionRequirementMaterial.Amount;
                            }
                        }

                    }
                }
            }
#endregion PackagingDepartmentActionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PackagingDepartmentActionForm_PostScript
    base.PostScript(transDef);
#endregion PackagingDepartmentActionForm_PostScript

            }
            
#region PackagingDepartmentActionForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef == null)
            {
                foreach (PackagingDepConsMaterial PackagingDepConsMaterial in _PackagingDepartmentAction.PackagingDepConsMaterials)
                {
                    if (PackagingDepConsMaterial.RequestAmount > 0)
                    {
                        UsedConsumedMaterail usedConsumedMaterail = _PackagingDepartmentAction.UsedConsumedMaterails.AddNew();
                        usedConsumedMaterail.Material = PackagingDepConsMaterial.Material;
                        usedConsumedMaterail.RequestAmount = PackagingDepConsMaterial.RequestAmount;
                        usedConsumedMaterail.SuppliedAmount = PackagingDepConsMaterial.SuppliedAmount;
                        usedConsumedMaterail.Amount = PackagingDepConsMaterial.UsedAmount;
                        usedConsumedMaterail.Store = _PackagingDepartmentAction.ResDivision.Store;
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.New;
                    }
                }
                _PackagingDepartmentAction.PackagingDepConsMaterials.DeleteChildren();
                _PackagingDepartmentAction.ObjectContext.Save();
            }
        }
        
#endregion PackagingDepartmentActionForm_Methods
    }
}