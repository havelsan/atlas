
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
    public partial class MaterialCalibrationForm : CalibrationBaseForm
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
#region MaterialCalibrationForm_PreScript
    base.PreScript();
                    //_Calibration.ResponsibleWorkShopUser = _Calibration.ResponsibleUser;
            if (_MaterialCalibration.PrevState == null)
            {
                this.FullCalibration.Value = false;
                this.LimitedCalibration.Value = false;
                this.NoNeedCalibration.Value = false;
                this.NotCalibration.Value = false;
                this.NotCalibreReason1.Value = false;
                this.NotCalibreReason2.Value = false;
                this.NotCalibreReason3.Value = false;
                this.NotCalibreReason4.Value = false;
                this.NotCalibreReason5.Value = false;


                foreach (CalibrationProcedure procedure in _MaterialCalibration.FixedAssetDefinition.CalibrationProcedures)
                {
                    CalibrationTest calibrationTest = new CalibrationTest(_MaterialCalibration.ObjectContext);
                    calibrationTest.CalibrationTestDefinition = (CalibrationTestDefinition)procedure.CalibrationTestDefinition;
                    calibrationTest.MeasurementReport = procedure.CalibrationTestDefinition.Report;
                    calibrationTest.Calibration = _Calibration;
                }

                if (_MaterialCalibration.FixedAssetMaterialDefinition != null)
                {
                    CalibrationStatusLabel.Text = _MaterialCalibration.FixedAssetMaterialDefinition.DecodeCalibrationStatus();
                }
                if (_MaterialCalibration.MaintenanceOrderObjectID != null)
                {
                    this.DropStateButton(MaterialCalibration.States.ToRepair);
                    this.DropStateButton(MaterialCalibration.States.Completed);
                }
            }
            else if (_MaterialCalibration.PrevState.StateDefID != MaterialCalibration.States.ChiefApproval)
            {
                this.FullCalibration.Value = false;
                this.LimitedCalibration.Value = false;
                this.NoNeedCalibration.Value = false;
                this.NotCalibration.Value = false;
                this.NotCalibreReason1.Value = false;
                this.NotCalibreReason2.Value = false;
                this.NotCalibreReason3.Value = false;
                this.NotCalibreReason4.Value = false;
                this.NotCalibreReason5.Value = false;

                foreach (CalibrationProcedure procedure in _MaterialCalibration.FixedAssetDefinition.CalibrationProcedures)
                {
                    CalibrationTest calibrationTest = new CalibrationTest(_MaterialCalibration.ObjectContext);
                    calibrationTest.CalibrationTestDefinition = procedure.CalibrationTestDefinition;
                    calibrationTest.MeasurementReport = procedure.CalibrationTestDefinition.Report;
                    calibrationTest.Calibration = _Calibration;
                }

                if (_MaterialCalibration.FixedAssetMaterialDefinition != null)
                {
                    CalibrationStatusLabel.Text = _MaterialCalibration.FixedAssetMaterialDefinition.DecodeCalibrationStatus();
                }
                if (_MaterialCalibration.MaintenanceOrderObjectID != null)
                {
                    this.DropStateButton(MaterialCalibration.States.ToRepair);
                    this.DropStateButton(MaterialCalibration.States.Completed);
                }
                
            }
            
            if(this.NotCalibration.Value == false)
            {
                this.TemperatureDeviationText.Required = true;
                this.TemperatureText.Required = true;
                this.HumidityDeviationText.Required = true;
                this.RelativeHumidityText.Required = true;
                this.CalibrationTests.Required = true;
            }
#endregion MaterialCalibrationForm_PreScript

            }
                }
}