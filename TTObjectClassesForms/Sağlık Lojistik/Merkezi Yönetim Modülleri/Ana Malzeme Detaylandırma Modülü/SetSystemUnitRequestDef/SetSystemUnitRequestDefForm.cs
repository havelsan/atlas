
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
    /// Set Sistem Ünite Tanımlama Talep Forumu
    /// </summary>
    public partial class SetSystemUnitRequestDefForm : TTForm
    {
        override protected void BindControlEvents()
        {
            NeedMaintenance.CheckedChanged += new TTControlEventDelegate(NeedMaintenance_CheckedChanged);
            NeedCalibration.CheckedChanged += new TTControlEventDelegate(NeedCalibration_CheckedChanged);
            MarkModelStatus.SelectedIndexChanged += new TTControlEventDelegate(MarkModelStatus_SelectedIndexChanged);
            BarcodeStatus.SelectedIndexChanged += new TTControlEventDelegate(BarcodeStatus_SelectedIndexChanged);
            GuarantyStatus.SelectedIndexChanged += new TTControlEventDelegate(GuarantyStatus_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            NeedMaintenance.CheckedChanged -= new TTControlEventDelegate(NeedMaintenance_CheckedChanged);
            NeedCalibration.CheckedChanged -= new TTControlEventDelegate(NeedCalibration_CheckedChanged);
            MarkModelStatus.SelectedIndexChanged -= new TTControlEventDelegate(MarkModelStatus_SelectedIndexChanged);
            BarcodeStatus.SelectedIndexChanged -= new TTControlEventDelegate(BarcodeStatus_SelectedIndexChanged);
            GuarantyStatus.SelectedIndexChanged -= new TTControlEventDelegate(GuarantyStatus_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void NeedMaintenance_CheckedChanged()
        {
#region SetSystemUnitRequestDefForm_NeedMaintenance_CheckedChanged
   if (_SetSystemUnitRequestDef.NeedMaintenance == true)
            {
                this.MaintenancePeriod.ReadOnly = false;
                this.MaintenancePeriod.Required = true;
                
            }
            else
            {
                this.MaintenancePeriod.ReadOnly = true;
                this.MaintenancePeriod.Required = false;
                this._SetSystemUnitRequestDef.MaintenancePeriod = null;
            }
#endregion SetSystemUnitRequestDefForm_NeedMaintenance_CheckedChanged
        }

        private void NeedCalibration_CheckedChanged()
        {
#region SetSystemUnitRequestDefForm_NeedCalibration_CheckedChanged
   if (_SetSystemUnitRequestDef.NeedCalibration == true)
            {
                this.CalibrationPeriod.ReadOnly = false;
                this.CalibrationPeriod.Required = true;
                
            }
            else
            {
                this.CalibrationPeriod.ReadOnly = true;
                this.CalibrationPeriod.Required = false;
                this._SetSystemUnitRequestDef.CalibrationPeriod = null;
            }
#endregion SetSystemUnitRequestDefForm_NeedCalibration_CheckedChanged
        }

        private void MarkModelStatus_SelectedIndexChanged()
        {
#region SetSystemUnitRequestDefForm_MarkModelStatus_SelectedIndexChanged
   if (_SetSystemUnitRequestDef.MarkModelStatus == VarYokGarantiEnum.V)
            {
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.ReferansNo.ReadOnly = false;
               
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;
                this.ReferansNo.Required = true;
            }
            else
            {
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ReferansNo.ReadOnly = true;
               
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.ReferansNo.Required = false;
                
                
                
                this._SetSystemUnitRequestDef.FixedAssetDetailMarkDef = null;
                this._SetSystemUnitRequestDef.FixedAssetDetailModelDef =  null;
                this._SetSystemUnitRequestDef.ReferansNo = null;
            }
#endregion SetSystemUnitRequestDefForm_MarkModelStatus_SelectedIndexChanged
        }

        private void BarcodeStatus_SelectedIndexChanged()
        {
#region SetSystemUnitRequestDefForm_BarcodeStatus_SelectedIndexChanged
   if (_SetSystemUnitRequestDef.BarcodeStatus == VarYokEnum.V)
            {
                this.Barcode.ReadOnly = false;
                this.Barcode.Required = true;
            }
            else
            {
                this.Barcode.ReadOnly = true;
                this.Barcode.Required = false;
            }
#endregion SetSystemUnitRequestDefForm_BarcodeStatus_SelectedIndexChanged
        }

        private void GuarantyStatus_SelectedIndexChanged()
        {
#region SetSystemUnitRequestDefForm_GuarantyStatus_SelectedIndexChanged
   if (_SetSystemUnitRequestDef.GuarantyStatus == VarYokGarantiEnum.V)
            {
                this.GuarantyStartDate.ReadOnly = false;
                this.GuarantiePeriod.ReadOnly = false;
                
                this.GuarantyStartDate.Required = true;
                this.GuarantiePeriod.Required = true;
            }
            else
            {
                this.GuarantyStartDate.ReadOnly = true;
                this.GuarantiePeriod.ReadOnly = true;
                
                this.GuarantyStartDate.Required = false;
                this.GuarantiePeriod.Required = false;
                
                this._SetSystemUnitRequestDef.GuarantyStartDate = null;
                this._SetSystemUnitRequestDef.GuarantiePeriod =  null;
               
            }
#endregion SetSystemUnitRequestDefForm_GuarantyStatus_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region SetSystemUnitRequestDefForm_PreScript
    base.PreScript();
            
            if(this._SetSystemUnitRequestDef.CurrentStateDefID == SetSystemUnitRequestDef.States.StateOne)
            {
                this.UseGoal.ReadOnly = true;
                this.UsePlaces.ReadOnly = true;
                this.IsAdvancedTechnology.ReadOnly = true;
                this.LifePeriod.ReadOnly = true;
                this.NeedCalibration.ReadOnly = true;
                this.NeedMaintenance.ReadOnly = true;

                this.UseGoal.Required = false;
                this.UsePlaces.Required = false;
                this.IsAdvancedTechnology.Required = false;
                this.LifePeriod.Required = false;
                this.NeedCalibration.Required = false;
                this.NeedMaintenance.Required = false;
            }
            if (this._SetSystemUnitRequestDef.CurrentStateDefID == SetSystemUnitRequestDef.States.StateTwo)
            {
                this.DetailSetUnitType.ReadOnly = true;
                this.BarcodeStatus.ReadOnly = true;
                this.Detail.ReadOnly = true;
                this.Producer.ReadOnly = true;
                this.MaterialCategory.ReadOnly = true;
                this.TechnicalSpecificationsNo.ReadOnly = true;
                this.MarkModelStatus.ReadOnly = true;
                this.GuarantyStatus.ReadOnly = true;

                this.Detail.Required = false;
                this.Producer.Required = false;
                this.MaterialCategory.Required = false;
                this.TechnicalSpecificationsNo.Required = false;
                this.MarkModelStatus.Required = false;
                this.GuarantyStatus.Required = false;
            }
            if (this._SetSystemUnitRequestDef.CurrentStateDefID == SetSystemUnitRequestDef.States.StateThree)
            {
                Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                if (siteIDGuid == Sites.SiteMerkezSagKom)
                    {
                            this.Barcode.ReadOnly= false;
                            this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                            this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                            this.ReferansNo.ReadOnly = false;
                            this.GuarantyStartDate.ReadOnly = false;
                            this.GuarantiePeriod.ReadOnly = false;
                            this.CalibrationPeriod.ReadOnly = false;
                            this.MaintenancePeriod.ReadOnly = false;
                    }
                    else
                        throw new TTUtils.TTException(" İşlem Merkezden Devam Ettirilmelidir.");
                }
#endregion SetSystemUnitRequestDefForm_PreScript

            }
                }
}