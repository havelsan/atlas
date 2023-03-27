
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
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
    public partial class MaterialCalibrationSupplyMaterialForm : CalibrationBaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region MaterialCalibrationSupplyMaterialForm_PreScript
    base.PreScript();
            
            if(_MaterialCalibration.WorkShop.Store == null)
                throw new TTException ( _MaterialCalibration.WorkShop.Name + " deposu bulunmamaktadır.");
            
            foreach (CalibrationConsumedMat  consumedMaterial in _MaterialCalibration.CalibrationConsumedMaterials)
                consumedMaterial.StoreInheld = consumedMaterial.Material.StockInheld(_MaterialCalibration.WorkShop.Store);
#endregion MaterialCalibrationSupplyMaterialForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MaterialCalibrationSupplyMaterialForm_PostScript
    base.PostScript(transDef);
            
            foreach (ITTGridRow row in CalibrationConsumedMaterials.Rows)
            {
                if (row.Cells["MaterialCalibrationConsumedMat"].Value == null && row.Cells["SparePartMaterialDescriptionCalibrationConsumedMat"].Value != null)
                    throw new TTUtils.TTException(SystemMessage.GetMessageV2(989, row.Cells["SparePartMaterialDescriptionCalibrationConsumedMat"].Value.ToString()));
                if (Convert.ToDouble(row.Cells["SuppliedAmountCalibrationConsumedMat"].Value) > Convert.ToDouble(row.Cells["RequestAmountCalibrationConsumedMat"].Value))
                    throw new TTUtils.TTException(SystemMessage.GetMessage(990));
            }
#endregion MaterialCalibrationSupplyMaterialForm_PostScript

            }
            
#region MaterialCalibrationSupplyMaterialForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                foreach (CalibrationConsumedMat consumed in _MaterialCalibration.CalibrationConsumedMaterials)
                {
                    if (consumed.SuppliedAmount > 0)
                    {
                        UsedConsumedMaterail usedConsumedMaterail = _MaterialCalibration.UsedConsumedMaterails.AddNew();
                        usedConsumedMaterail.Material = consumed.Material;
                        usedConsumedMaterail.RequestAmount = consumed.RequestAmount;
                        usedConsumedMaterail.SuppliedAmount = consumed.SuppliedAmount;
                        usedConsumedMaterail.Amount = consumed.UsedAmount;
                        usedConsumedMaterail.Store = _MaterialCalibration.WorkShop.Store;
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.New;
                    }
                }
                _MaterialCalibration.CalibrationConsumedMaterials.DeleteChildren();
                _MaterialCalibration.ObjectContext.Save();
            }

        }
        
#endregion MaterialCalibrationSupplyMaterialForm_Methods
    }
}