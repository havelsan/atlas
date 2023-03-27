
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
    /// Kalibrasyon
    /// </summary>
    public partial class CalibrationSupplyMaterialForm : CalibrationBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdUsedStore.Click += new TTControlEventDelegate(cmdUsedStore_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdUsedStore.Click -= new TTControlEventDelegate(cmdUsedStore_Click);
            base.UnBindControlEvents();
        }

        private void cmdUsedStore_Click()
        {
#region CalibrationSupplyMaterialForm_cmdUsedStore_Click
   foreach (CalibrationConsumedMat calibrationConsumedMat in _Calibration.CalibrationConsumedMaterials)
            {
                if (calibrationConsumedMat.SuppliedAmount != null)
                {
                    calibrationConsumedMat.SuppliedAmount = calibrationConsumedMat.RequestAmount;
                }
            }
#endregion CalibrationSupplyMaterialForm_cmdUsedStore_Click
        }

        protected override void PreScript()
        {
#region CalibrationSupplyMaterialForm_PreScript
    base.PreScript();

            if(_Calibration.WorkShop.Store == null)
                throw new TTException ( _Calibration.WorkShop.Name + " deposu bulunmamaktadır.");
            
            foreach (CalibrationConsumedMat  consumedMaterial in _Calibration.CalibrationConsumedMaterials)
                consumedMaterial.StoreInheld = consumedMaterial.Material.StockInheld(_Calibration.WorkShop.Store);
#endregion CalibrationSupplyMaterialForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CalibrationSupplyMaterialForm_PostScript
    base.PostScript(transDef);
            
            foreach (ITTGridRow row in CalibrationConsumedMaterials.Rows)
            {
                if (row.Cells["MaterialCalibrationConsumedMat"].Value == null && row.Cells["SparePartMaterialDescriptionCalibrationConsumedMat"].Value != null)
                    throw new TTUtils.TTException(SystemMessage.GetMessageV2(989, row.Cells["SparePartMaterialDescriptionCalibrationConsumedMat"].Value.ToString()));
                if (Convert.ToDouble(row.Cells["SuppliedAmountCalibrationConsumedMat"].Value) > Convert.ToDouble(row.Cells["RequestAmountCalibrationConsumedMat"].Value))
                    throw new TTUtils.TTException(SystemMessage.GetMessage(990));
            }
#endregion CalibrationSupplyMaterialForm_PostScript

            }
            
#region CalibrationSupplyMaterialForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                foreach (CalibrationConsumedMat consumed in _Calibration.CalibrationConsumedMaterials)
                {
                    if (consumed.SuppliedAmount > 0)
                    {
                        UsedConsumedMaterail usedConsumedMaterail = _Calibration.UsedConsumedMaterails.AddNew();
                        usedConsumedMaterail.Material = consumed.Material;
                        usedConsumedMaterail.RequestAmount = consumed.RequestAmount;
                        usedConsumedMaterail.SuppliedAmount = consumed.SuppliedAmount;
                        usedConsumedMaterail.Amount = consumed.UsedAmount;
                        usedConsumedMaterail.Store = _Calibration.WorkShop.Store;
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.New;
                    }
                }
                _Calibration.CalibrationConsumedMaterials.DeleteChildren();
                _Calibration.ObjectContext.Save();
            }

        }
        
#endregion CalibrationSupplyMaterialForm_Methods
    }
}