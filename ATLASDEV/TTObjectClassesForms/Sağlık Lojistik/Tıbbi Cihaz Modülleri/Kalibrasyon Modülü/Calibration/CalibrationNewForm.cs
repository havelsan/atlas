
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
    public partial class CalibrationNewForm : CalibrationBaseForm
    {
        override protected void BindControlEvents()
        {
            objFixedAssetMaterial.SelectedObjectChanged += new TTControlEventDelegate(objFixedAssetMaterial_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            objFixedAssetMaterial.SelectedObjectChanged -= new TTControlEventDelegate(objFixedAssetMaterial_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void objFixedAssetMaterial_SelectedObjectChanged()
        {
#region CalibrationNewForm_objFixedAssetMaterial_SelectedObjectChanged
   if (_Calibration.FixedAssetMaterialDefinition != null)
            {
                //_Calibration.FillEquipments();
                _Calibration.CalibrationStatus = _Calibration.FixedAssetMaterialDefinition.DecodeCalibrationStatus();
            }
#endregion CalibrationNewForm_objFixedAssetMaterial_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region CalibrationNewForm_PreScript
    if (_Calibration.FixedAssetMaterialDefinition != null)
            {
                CalibrationStatusLabel.Text = _Calibration.FixedAssetMaterialDefinition.DecodeCalibrationStatus();
            }
#endregion CalibrationNewForm_PreScript

            }
                }
}