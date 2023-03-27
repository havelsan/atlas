
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
    /// Set Detayları
    /// </summary>
    public partial class SetMaterialDetailDefForm : TTForm
    {
        override protected void BindControlEvents()
        {
            IsAdvancedTechnology.SelectedIndexChanged += new TTControlEventDelegate(IsAdvancedTechnology_SelectedIndexChanged);
            CalibrationPeriod.SelectedIndexChanged += new TTControlEventDelegate(CalibrationPeriod_SelectedIndexChanged);
            CalibrationStatus.SelectedIndexChanged += new TTControlEventDelegate(CalibrationStatus_SelectedIndexChanged);
            MaintenancePeriod.SelectedIndexChanged += new TTControlEventDelegate(MaintenancePeriod_SelectedIndexChanged);
            MaintanenceStatus.SelectedIndexChanged += new TTControlEventDelegate(MaintanenceStatus_SelectedIndexChanged);
            GuarantyStatus.SelectedIndexChanged += new TTControlEventDelegate(GuarantyStatus_SelectedIndexChanged);
            OtherLenght.CheckedChanged += new TTControlEventDelegate(OtherLenght_CheckedChanged);
            OtherModel.CheckedChanged += new TTControlEventDelegate(OtherModel_CheckedChanged);
            OtherEdge.CheckedChanged += new TTControlEventDelegate(OtherEdge_CheckedChanged);
            OtherBody.CheckedChanged += new TTControlEventDelegate(OtherBody_CheckedChanged);
            OtherMark.CheckedChanged += new TTControlEventDelegate(OtherMark_CheckedChanged);
            OtherMainClass.CheckedChanged += new TTControlEventDelegate(OtherMainClass_CheckedChanged);
            DetailType.SelectedIndexChanged += new TTControlEventDelegate(DetailType_SelectedIndexChanged);
            FixedAssetDetailEdgeDef.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailEdgeDef_SelectedObjectChanged);
            IsDemoded.SelectedIndexChanged += new TTControlEventDelegate(IsDemoded_SelectedIndexChanged);
            cmdFind.Click += new TTControlEventDelegate(cmdFind_Click);
            FixedAssetDetailBodyDef.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailBodyDef_SelectedObjectChanged);
            OperationStatus.SelectedIndexChanged += new TTControlEventDelegate(OperationStatus_SelectedIndexChanged);
            FixedAssetDetailMarkDef.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailMarkDef_SelectedObjectChanged);
            MarkModelStatus.SelectedIndexChanged += new TTControlEventDelegate(MarkModelStatus_SelectedIndexChanged);
            FixedAssetDetailMainClass.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailMainClass_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IsAdvancedTechnology.SelectedIndexChanged -= new TTControlEventDelegate(IsAdvancedTechnology_SelectedIndexChanged);
            CalibrationPeriod.SelectedIndexChanged -= new TTControlEventDelegate(CalibrationPeriod_SelectedIndexChanged);
            CalibrationStatus.SelectedIndexChanged -= new TTControlEventDelegate(CalibrationStatus_SelectedIndexChanged);
            MaintenancePeriod.SelectedIndexChanged -= new TTControlEventDelegate(MaintenancePeriod_SelectedIndexChanged);
            MaintanenceStatus.SelectedIndexChanged -= new TTControlEventDelegate(MaintanenceStatus_SelectedIndexChanged);
            GuarantyStatus.SelectedIndexChanged -= new TTControlEventDelegate(GuarantyStatus_SelectedIndexChanged);
            OtherLenght.CheckedChanged -= new TTControlEventDelegate(OtherLenght_CheckedChanged);
            OtherModel.CheckedChanged -= new TTControlEventDelegate(OtherModel_CheckedChanged);
            OtherEdge.CheckedChanged -= new TTControlEventDelegate(OtherEdge_CheckedChanged);
            OtherBody.CheckedChanged -= new TTControlEventDelegate(OtherBody_CheckedChanged);
            OtherMark.CheckedChanged -= new TTControlEventDelegate(OtherMark_CheckedChanged);
            OtherMainClass.CheckedChanged -= new TTControlEventDelegate(OtherMainClass_CheckedChanged);
            DetailType.SelectedIndexChanged -= new TTControlEventDelegate(DetailType_SelectedIndexChanged);
            FixedAssetDetailEdgeDef.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailEdgeDef_SelectedObjectChanged);
            IsDemoded.SelectedIndexChanged -= new TTControlEventDelegate(IsDemoded_SelectedIndexChanged);
            cmdFind.Click -= new TTControlEventDelegate(cmdFind_Click);
            FixedAssetDetailBodyDef.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailBodyDef_SelectedObjectChanged);
            OperationStatus.SelectedIndexChanged -= new TTControlEventDelegate(OperationStatus_SelectedIndexChanged);
            FixedAssetDetailMarkDef.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailMarkDef_SelectedObjectChanged);
            MarkModelStatus.SelectedIndexChanged -= new TTControlEventDelegate(MarkModelStatus_SelectedIndexChanged);
            FixedAssetDetailMainClass.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailMainClass_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void IsAdvancedTechnology_SelectedIndexChanged()
        {
#region SetMaterialDetailDefForm_IsAdvancedTechnology_SelectedIndexChanged
   CheckProperty(stateGet);
#endregion SetMaterialDetailDefForm_IsAdvancedTechnology_SelectedIndexChanged
        }

        private void CalibrationPeriod_SelectedIndexChanged()
        {
#region SetMaterialDetailDefForm_CalibrationPeriod_SelectedIndexChanged
   CheckProperty(stateGet);
#endregion SetMaterialDetailDefForm_CalibrationPeriod_SelectedIndexChanged
        }

        private void CalibrationStatus_SelectedIndexChanged()
        {
#region SetMaterialDetailDefForm_CalibrationStatus_SelectedIndexChanged
   CheckProperty(stateGet);
#endregion SetMaterialDetailDefForm_CalibrationStatus_SelectedIndexChanged
        }

        private void MaintenancePeriod_SelectedIndexChanged()
        {
#region SetMaterialDetailDefForm_MaintenancePeriod_SelectedIndexChanged
   CheckProperty(stateGet);
#endregion SetMaterialDetailDefForm_MaintenancePeriod_SelectedIndexChanged
        }

        private void MaintanenceStatus_SelectedIndexChanged()
        {
#region SetMaterialDetailDefForm_MaintanenceStatus_SelectedIndexChanged
   CheckProperty(stateGet);
#endregion SetMaterialDetailDefForm_MaintanenceStatus_SelectedIndexChanged
        }

        private void GuarantyStatus_SelectedIndexChanged()
        {
#region SetMaterialDetailDefForm_GuarantyStatus_SelectedIndexChanged
   CheckProperty(stateGet);
#endregion SetMaterialDetailDefForm_GuarantyStatus_SelectedIndexChanged
        }

        private void OtherLenght_CheckedChanged()
        {
#region SetMaterialDetailDefForm_OtherLenght_CheckedChanged
   if (this._SetMaterialDetailDef.OtherLenght != null)
            {
                if (this._SetMaterialDetailDef.OtherLenght == true)
                {
                    this.Length.Required = false;
                    
            
                }
                else
                {
                    this.Length.Required = true;
                    
               
                }
            }
#endregion SetMaterialDetailDefForm_OtherLenght_CheckedChanged
        }

        private void OtherModel_CheckedChanged()
        {
#region SetMaterialDetailDefForm_OtherModel_CheckedChanged
   if (this._SetMaterialDetailDef.OtherModel != null)
            {
                if (this._SetMaterialDetailDef.OtherModel == true)
                {
                    this.FixedAssetDetailModelDef.Required = false;
                
                }
                 else
                {
                    this.FixedAssetDetailModelDef.Required = true;
                    
                
                }
            }
#endregion SetMaterialDetailDefForm_OtherModel_CheckedChanged
        }

        private void OtherEdge_CheckedChanged()
        {
#region SetMaterialDetailDefForm_OtherEdge_CheckedChanged
   if (this._SetMaterialDetailDef.OtherEdge != null)
            {
                if (this._SetMaterialDetailDef.OtherEdge == true)
                { 
                    this.FixedAssetDetailEdgeDef.Required = false;
                 
                }
                 else
                {
                    this.FixedAssetDetailEdgeDef.Required = true;
                    
                  
                }
            }
#endregion SetMaterialDetailDefForm_OtherEdge_CheckedChanged
        }

        private void OtherBody_CheckedChanged()
        {
#region SetMaterialDetailDefForm_OtherBody_CheckedChanged
   if (this._SetMaterialDetailDef.OtherBody != null)
            {
                if (this._SetMaterialDetailDef.OtherBody == true)
                {
                    this.FixedAssetDetailBodyDef.Required = false;
                    
                 
                }
                else
                {
                    this.FixedAssetDetailBodyDef.Required = true;
                    
                 
                }
            }
#endregion SetMaterialDetailDefForm_OtherBody_CheckedChanged
        }

        private void OtherMark_CheckedChanged()
        {
#region SetMaterialDetailDefForm_OtherMark_CheckedChanged
   if (this._SetMaterialDetailDef.OtherMark != null)
            {
                if (this._SetMaterialDetailDef.OtherMark == true)
                {
                    this.FixedAssetDetailMarkDef.Required = false;
                    
                 
                }
                 else
                {
                    this.FixedAssetDetailMarkDef.Required = true;
                    
                   
                }
            }
#endregion SetMaterialDetailDefForm_OtherMark_CheckedChanged
        }

        private void OtherMainClass_CheckedChanged()
        {
#region SetMaterialDetailDefForm_OtherMainClass_CheckedChanged
   if (this._SetMaterialDetailDef.OtherMainClass != null)
            {
                if (this._SetMaterialDetailDef.OtherMainClass == true)
                {
                    this.FixedAssetDetailMainClass.Required = false;
                    
                
                }
                   else
                {
                    this.FixedAssetDetailMainClass.Required = true;
                    
                  
                }
            }
#endregion SetMaterialDetailDefForm_OtherMainClass_CheckedChanged
        }

        private void DetailType_SelectedIndexChanged()
        {
#region SetMaterialDetailDefForm_DetailType_SelectedIndexChanged
   CheckProperty(stateGet);

            if(this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.Other)
            {
                this.Description.ReadOnly= false;
                this.Description.Required = false;
            }
            else
            {
                this.Description.ReadOnly= false;
                this.Description.Required = false;
            }
#endregion SetMaterialDetailDefForm_DetailType_SelectedIndexChanged
        }

        private void FixedAssetDetailEdgeDef_SelectedObjectChanged()
        {
#region SetMaterialDetailDefForm_FixedAssetDetailEdgeDef_SelectedObjectChanged
   this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            if(this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef != null)
                Length.ListFilterExpression = "FIXEDASSETDETAILEDGEDEF = " + ConnectionManager.GuidToString(this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef.ObjectID);
            
            
            if(this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef != null)
            {
                this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            }
#endregion SetMaterialDetailDefForm_FixedAssetDetailEdgeDef_SelectedObjectChanged
        }

        private void IsDemoded_SelectedIndexChanged()
        {
#region SetMaterialDetailDefForm_IsDemoded_SelectedIndexChanged
   CheckProperty(stateGet);
#endregion SetMaterialDetailDefForm_IsDemoded_SelectedIndexChanged
        }

        private void cmdFind_Click()
        {
#region SetMaterialDetailDefForm_cmdFind_Click
   if (string.IsNullOrEmpty(this._SetMaterialDetailDef.ReferansNo) == false)
            {
                IList referanslar = this._SetMaterialDetailDef.ObjectContext.QueryObjects("FIXEDASSETDETAILREFDEF", "REFERANCE ='" + this._SetMaterialDetailDef.ReferansNo + "'");
                if (referanslar.Count > 0)
                {
                    FixedAssetDetailRefDef fadRef = (FixedAssetDetailRefDef)referanslar[0];

                    if (fadRef.FixedAssetDetailMainClass != null)
                        this._SetMaterialDetailDef.FixedAssetDetailMainClass = fadRef.FixedAssetDetailMainClass;

                    if (fadRef.FixedAssetDetailMarkDef != null)
                        this._SetMaterialDetailDef.FixedAssetDetailMarkDef = fadRef.FixedAssetDetailMarkDef;

                    if (fadRef.FixedAssetDetailModelDef != null)
                        this._SetMaterialDetailDef.FixedAssetDetailModelDef = fadRef.FixedAssetDetailModelDef;

                    if (fadRef.FixedAssetDetailBodyDef != null)
                        this._SetMaterialDetailDef.FixedAssetDetailBodyDef = fadRef.FixedAssetDetailBodyDef;

                    if (fadRef.FixedAssetDetailEdgeDef != null)
                        this._SetMaterialDetailDef.FixedAssetDetailEdgeDef = fadRef.FixedAssetDetailEdgeDef;

                    if (fadRef.FixedAssetDetailLengthDef != null)
                        this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = fadRef.FixedAssetDetailLengthDef;
                    

                }
                else
                    InfoBox.Show("İlgili Referans No lu kayıt bulunamadı", MessageIconEnum.InformationMessage);
            }
            else
                InfoBox.Show("Referans No boş olamaz", MessageIconEnum.ErrorMessage);
#endregion SetMaterialDetailDefForm_cmdFind_Click
        }

        private void FixedAssetDetailBodyDef_SelectedObjectChanged()
        {
#region SetMaterialDetailDefForm_FixedAssetDetailBodyDef_SelectedObjectChanged
   if(this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef != null)
            {
                this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            }
            if(this._SetMaterialDetailDef.FixedAssetDetailEdgeDef != null)
            {
                this._SetMaterialDetailDef.FixedAssetDetailEdgeDef = null;
            }
#endregion SetMaterialDetailDefForm_FixedAssetDetailBodyDef_SelectedObjectChanged
        }

        private void OperationStatus_SelectedIndexChanged()
        {
#region SetMaterialDetailDefForm_OperationStatus_SelectedIndexChanged
   CheckProperty(stateGet);
#endregion SetMaterialDetailDefForm_OperationStatus_SelectedIndexChanged
        }

        private void FixedAssetDetailMarkDef_SelectedObjectChanged()
        {
#region SetMaterialDetailDefForm_FixedAssetDetailMarkDef_SelectedObjectChanged
   if(this._SetMaterialDetailDef.FixedAssetDetailModelDef != null)
            {
                this._SetMaterialDetailDef.FixedAssetDetailModelDef = null;
            }
#endregion SetMaterialDetailDefForm_FixedAssetDetailMarkDef_SelectedObjectChanged
        }

        private void MarkModelStatus_SelectedIndexChanged()
        {
#region SetMaterialDetailDefForm_MarkModelStatus_SelectedIndexChanged
   CheckProperty(stateGet);
#endregion SetMaterialDetailDefForm_MarkModelStatus_SelectedIndexChanged
        }

        private void FixedAssetDetailMainClass_SelectedObjectChanged()
        {
#region SetMaterialDetailDefForm_FixedAssetDetailMainClass_SelectedObjectChanged
   this._SetMaterialDetailDef.FixedAssetDetailMarkDef = null;
            if(this._SetMaterialDetailDef.FixedAssetDetailMainClass != null)
                FixedAssetDetailMarkDef.ListFilterExpression = "FIXEDASSETDETAILMAINCLASS = " + ConnectionManager.GuidToString(this._SetMaterialDetailDef.FixedAssetDetailMainClass.ObjectID);

            
            this._SetMaterialDetailDef.FixedAssetDetailBodyDef = null;
            if(this._SetMaterialDetailDef.FixedAssetDetailMainClass != null)
                FixedAssetDetailBodyDef.ListFilterExpression = "FIXEDASSETDETAILMAINCLASS = " + ConnectionManager.GuidToString(this._SetMaterialDetailDef.FixedAssetDetailMainClass.ObjectID);
            
            
            if(this._SetMaterialDetailDef.FixedAssetDetailBodyDef != null)
            {
                this._SetMaterialDetailDef.FixedAssetDetailBodyDef = null;
            }
            if(this._SetMaterialDetailDef.FixedAssetDetailEdgeDef != null)
            {
                this._SetMaterialDetailDef.FixedAssetDetailEdgeDef = null;
            }
            if(this._SetMaterialDetailDef.FixedAssetDetailMarkDef != null)
            {
                this._SetMaterialDetailDef.FixedAssetDetailMarkDef = null;
            }
            if(this._SetMaterialDetailDef.FixedAssetDetailModelDef != null)
            {
                this._SetMaterialDetailDef.FixedAssetDetailModelDef = null;
            }
            
            if(this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef != null)
            {
                this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            }
#endregion SetMaterialDetailDefForm_FixedAssetDetailMainClass_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region SetMaterialDetailDefForm_PreScript
    base.PreScript();
            
            
            stateGet = 0;
            bool ssd = true;
            if(this._SetMaterialDetailDef.IsDemoded == null)
                this._SetMaterialDetailDef.IsDemoded = YesNoEnum.No;
            if(this._SetMaterialDetailDef.OperationStatus == null)
                this._SetMaterialDetailDef.OperationStatus = FixeAssetOperationStatusEnum.InOperation;
            if(this._SetMaterialDetailDef.DetailType == null)
                this._SetMaterialDetailDef.DetailType = FixedAssetDetailTypeEnum.Device;
            if(this._SetMaterialDetailDef.MarkModelStatus == null)
                this._SetMaterialDetailDef.MarkModelStatus = VarYokGarantiEnum.V;
            
            
            if(this._SetMaterialDetailDef.MarkModelStatus == VarYokGarantiEnum.V)
            {
                this.MarkModelReason.ReadOnly = true;
                this.MarkModelReason.Required = false;
                this._SetMaterialDetailDef.MarkModelReason = null;
            }
            if(this._SetMaterialDetailDef.MarkModelStatus == VarYokGarantiEnum.Y)
            {
                this.MarkModelReason.ReadOnly = false;
                this.MarkModelReason.Required = true;
            }
            
            
            BindingList<FixedAssetMaterialDefinition.GetSetMaterialDetail_Class> fixedAssetMatDef = FixedAssetMaterialDefinition.GetSetMaterialDetail(this._SetMaterialDetailDef.FixedAssetMaterialDefDetail.ObjectID);
            if (fixedAssetMatDef.Count > 0)
            {
                BindingList<FixedAssetDetailActionDet.GetFixedAssetDetailActDet_Class> fixedAssetDetailActionDet = FixedAssetDetailActionDet.GetFixedAssetDetailActDet((Guid)fixedAssetMatDef[0].ObjectID);
                if (fixedAssetDetailActionDet.Count > 0)
                {
                    FixedAssetDetailActionDet fixedAssetDetailActionDet2 = (FixedAssetDetailActionDet)_SetMaterialDetailDef.ObjectContext.GetObject((Guid)fixedAssetDetailActionDet[0].ObjectID,"FIXEDASSETDETAILACTIONDET");
                    //1.Aşama
                    if( fixedAssetDetailActionDet2.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageOne)
                    {
                        stateGet = 1;
                        
                        this.PhysicalBarcode.ReadOnly = false;
                        this.IsDemoded.ReadOnly = false;
                        this.IsDemoded.Required = true;
                        this.OperationStatus.ReadOnly = false;
                        this.OperationStatus.Required = true;
                        this.DetailType.ReadOnly = false;
                        this.DetailType.Required = true;
                        this.MarkModelStatus.ReadOnly =false ;
                        this.MarkModelStatus.Required =true ;
                        this.MarkModelReason.ReadOnly = false;
                        this.MarkModelReason.Required =true ;
                        this.FixedAssetDetailMainClass.ReadOnly = false;
                        this.FixedAssetDetailMainClass.Required = true;
                        this.FixedAssetDetailMarkDef.ReadOnly = false;
                        this.FixedAssetDetailMarkDef.Required =true ;
                        this.FixedAssetDetailModelDef.ReadOnly = false;
                        this.FixedAssetDetailModelDef.Required =true ;
                        this.FixedAssetDetailBodyDef.ReadOnly = false;
                        this.FixedAssetDetailBodyDef.Required =true ;
                        this.FixedAssetDetailEdgeDef.ReadOnly = false;
                        this.FixedAssetDetailEdgeDef.Required = true;
                        this.ReferansNo.ReadOnly =false ;
                        this.ReferansNo.Required = true;
                        this.SerialNumber.ReadOnly = false;
                        this.SerialNumber.Required = true;
                        this.Length.ReadOnly =false ;
                        this.Length.Required = true;
                        this.Picture.ReadOnly =false ;
                        this.Picture.Required =true ;
                        this.ProductionDate.ReadOnly =false ;
                        this.Description.ReadOnly = false;
                        this.cmdFind.ReadOnly = false;
                        this.OtherBody.ReadOnly = false;
                        this.OtherEdge.ReadOnly = false;
                        this.OtherLenght.ReadOnly = false;
                        this.OtherMainClass.ReadOnly = false;
                        this.OtherMark.ReadOnly = false;
                        this.OtherModel.ReadOnly = false;


                        //2.Aşama Kapalı Taraf
                        this.UseStartDate.ReadOnly = true;
                        this.UseStartDate.Required = false;
                        this.ProposedNATOStockNo.ReadOnly = true;
                        this.ProposedNATOStockNo.Required = false;
                        this.ProposedStockcardName.ReadOnly = true;
                        this.ProposedStockcardName.Required = false;
                        this.IntendedUse.ReadOnly = true;
                        this.IntendedUse.Required = false;
                        this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                        this.IsAdvancedTechnology.ReadOnly = true;
                        this.IsAdvancedTechnology.Required = false;
                        this.GuarantiePeriod.ReadOnly = true;
                        this.GuarantiePeriod.Required = false;
                        this.GuarantyStartDate.ReadOnly = true;
                        this.GuarantyStartDate.Required = false;
                        this.GuarantyStatus.ReadOnly = true;
                        this.GuarantyStatus.Required = false;
                        this.CalibrationPeriod.ReadOnly = true;
                        this.CalibrationPeriod.Required = false;
                        this.CalibrationStatus.ReadOnly = true;
                        this.CalibrationStatus.Required=false;
                        this.LastCalibrationDate.ReadOnly = true;
                        this.LastCalibrationDate.Required = false;
                        this.MaintanenceStatus.ReadOnly = true;
                        this.MaintanenceStatus.Required = false;
                        this.MaintenancePeriod.ReadOnly = true;
                        this.MaintenancePeriod.Required = false;
                        this.LastMaintenanceDate.ReadOnly = true;
                        this.LastMaintenanceDate.Required = false;
                        this.Power.ReadOnly = true;
                        this.Power.Required = false;
                        this.Voltage.ReadOnly = true;
                        this.Voltage.Required = false;
                        this.Frequency.ReadOnly = true;
                        this.Frequency.Required = false;
                        
                        CheckProperty(stateGet);
                    }
                    //2.Aşama
                    if( fixedAssetDetailActionDet2.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                    {
                        stateGet = 2;
                        
                        this.UseStartDate.ReadOnly = false;
                        this.UseStartDate.Required = true;
                        this.ProposedNATOStockNo.ReadOnly = false;
                        this.ProposedNATOStockNo.Required = true;
                        this.ProposedStockcardName.ReadOnly =false ;
                        this.ProposedStockcardName.Required = true;
                        this.IntendedUse.ReadOnly = false;
                        this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.IsAdvancedTechnology.ReadOnly = false;
                        this.GuarantyStatus.ReadOnly = false;
                        this.CalibrationStatus.ReadOnly = false;
                        this.MaintanenceStatus.ReadOnly =false ;
                        this.Power.ReadOnly =false ;
                        this.Power.Required = true;
                        this.Voltage.ReadOnly =false ;
                        this.Voltage.Required = true;
                        this.Frequency.ReadOnly = false;
                        this.Frequency.Required =true ;
                        
                        //1.Aşama Kapalı alan
                        this.PhysicalBarcode.ReadOnly = true;
                        this.IsDemoded.ReadOnly = true;
                        this.OperationStatus.ReadOnly = true;
                        this.DetailType.ReadOnly = true;
                        this.MarkModelStatus.ReadOnly = true;
                        this.MarkModelReason.ReadOnly = true;
                        this.FixedAssetDetailMainClass.ReadOnly = true;
                        this.FixedAssetDetailMarkDef.ReadOnly = true;
                        this.FixedAssetDetailModelDef.ReadOnly = true;
                        this.FixedAssetDetailBodyDef.ReadOnly = true;
                        this.FixedAssetDetailEdgeDef.ReadOnly = true;
                        this.ReferansNo.ReadOnly = true;
                        this.SerialNumber.ReadOnly = true;
                        this.Length.ReadOnly = true;
                        this.Picture.ReadOnly = true;
                        this.ProductionDate.ReadOnly = true;
                        this.Description.ReadOnly = true;
                        this.cmdFind.ReadOnly = true;
                        this.OtherBody.ReadOnly = true;
                        this.OtherEdge.ReadOnly = true;
                        this.OtherLenght.ReadOnly = true;
                        this.OtherMainClass.ReadOnly = true;
                        this.OtherMark.ReadOnly = true;
                        this.OtherModel.ReadOnly = true;
                        
                        if(this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.HandTool)
                        {
                            this.Power.ReadOnly = true;
                            this.Power.Required = false;
                            this._SetMaterialDetailDef.Power = null;
                            
                            this.Frequency.ReadOnly = true;
                            this.Frequency.Required = false;
                            this._SetMaterialDetailDef.Frequency = null;
                            
                            this.Voltage.ReadOnly = true;
                            this.Voltage.Required = false;
                            this._SetMaterialDetailDef.Voltage = null;
                        }
                        
                        if(this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.Other && this._SetMaterialDetailDef.MarkModelStatus == VarYokGarantiEnum.Y)
                        {
                            this.Power.Required = false;
                            this.Frequency.Required = false;
                            this.Voltage.Required = false;
                        }
                        
                        CheckProperty(stateGet);
                        
                    }
                    //3.Aşama
                    if( fixedAssetDetailActionDet2.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                    {
                        stateGet = 3;
                        //1.Aşama Kapalı alan
                        this.PhysicalBarcode.ReadOnly = true;
                        this.IsDemoded.ReadOnly = true;
                        this.OperationStatus.ReadOnly = true;
                        this.DetailType.ReadOnly = true;
                        this.MarkModelStatus.ReadOnly = true;
                        this.MarkModelReason.ReadOnly = true;
                        this.FixedAssetDetailMainClass.ReadOnly = true;
                        this.FixedAssetDetailMarkDef.ReadOnly = true;
                        this.FixedAssetDetailModelDef.ReadOnly = true;
                        this.FixedAssetDetailBodyDef.ReadOnly = true;
                        this.FixedAssetDetailEdgeDef.ReadOnly = true;
                        this.ReferansNo.ReadOnly = true;
                        this.SerialNumber.ReadOnly = true;
                        this.Length.ReadOnly = true;
                        this.Picture.ReadOnly = true;
                        this.ProductionDate.ReadOnly = true;
                        this.Description.ReadOnly = true;
                        this.cmdFind.ReadOnly = true;
                        this.OtherBody.ReadOnly = true;
                        this.OtherEdge.ReadOnly = true;
                        this.OtherLenght.ReadOnly = true;
                        this.OtherMainClass.ReadOnly = true;
                        this.OtherMark.ReadOnly = true;
                        this.OtherModel.ReadOnly = true;
                        
                        if(this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.HandTool)
                        {
                            this.Power.ReadOnly = true;
                            this.Power.Required = false;
                            this._SetMaterialDetailDef.Power = null;
                            
                            this.Frequency.ReadOnly = true;
                            this.Frequency.Required = false;
                            this._SetMaterialDetailDef.Frequency = null;
                            
                            this.Voltage.ReadOnly = true;
                            this.Voltage.Required = false;
                            this._SetMaterialDetailDef.Voltage = null;
                        }
                        
                        if(this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.Other && this._SetMaterialDetailDef.MarkModelStatus == VarYokGarantiEnum.Y)
                        {
                            this.Power.Required = false;
                            this.Frequency.Required = false;
                            this.Voltage.Required = false;
                        }
                        
                        //2.Aşama Kapalı Taraf
                        this.UseStartDate.ReadOnly = true;
                        this.UseStartDate.Required = false;
                        this.ProposedNATOStockNo.ReadOnly = true;
                        this.ProposedNATOStockNo.Required = false;
                        this.ProposedStockcardName.ReadOnly = true;
                        this.ProposedStockcardName.Required = false;
                        this.IntendedUse.ReadOnly = true;
                        this.IntendedUse.Required = false;
                        this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                        this.IsAdvancedTechnology.ReadOnly = true;
                        this.IsAdvancedTechnology.Required = false;
                        this.GuarantiePeriod.ReadOnly = true;
                        this.GuarantiePeriod.Required = false;
                        this.GuarantyStartDate.ReadOnly = true;
                        this.GuarantyStartDate.Required = false;
                        this.GuarantyStatus.ReadOnly = true;
                        this.GuarantyStatus.Required = false;
                        this.CalibrationPeriod.ReadOnly = true;
                        this.CalibrationPeriod.Required = false;
                        this.CalibrationStatus.ReadOnly = true;
                        this.CalibrationStatus.Required=false;
                        this.LastCalibrationDate.ReadOnly = true;
                        this.LastCalibrationDate.Required = false;
                        this.MaintanenceStatus.ReadOnly = true;
                        this.MaintanenceStatus.Required = false;
                        this.MaintenancePeriod.ReadOnly = true;
                        this.MaintenancePeriod.Required = false;
                        this.LastMaintenanceDate.ReadOnly = true;
                        this.LastMaintenanceDate.Required = false;
                        this.Power.ReadOnly = true;
                        this.Power.Required = false;
                        this.Voltage.ReadOnly = true;
                        this.Voltage.Required = false;
                        this.Frequency.ReadOnly = true;
                        this.Frequency.Required = false;
                        
                        CheckProperty(stateGet);
                    }
                    //ilkaçılış
                    if(fixedAssetDetailActionDet2.FixedAssetDetailAction.CurrentStateDefID != FixedAssetDetailAction.States.StageOne &&
                       fixedAssetDetailActionDet2.FixedAssetDetailAction.CurrentStateDefID != FixedAssetDetailAction.States.StageTwo &&
                       fixedAssetDetailActionDet2.FixedAssetDetailAction.CurrentStateDefID != FixedAssetDetailAction.States.StageThree)
                    {
                        stateGet = 1;
                        
                         this.PhysicalBarcode.ReadOnly = false;
                        this.IsDemoded.ReadOnly = false;
                        this.IsDemoded.Required = true;
                        this.OperationStatus.ReadOnly = false;
                        this.OperationStatus.Required = true;
                        this.DetailType.ReadOnly = false;
                        this.DetailType.Required = true;
                        this.MarkModelStatus.ReadOnly =false ;
                        this.MarkModelStatus.Required =true ;
                        this.MarkModelReason.ReadOnly = false;
                        this.MarkModelReason.Required =true ;
                        this.FixedAssetDetailMainClass.ReadOnly = false;
                        this.FixedAssetDetailMainClass.Required = true;
                        this.FixedAssetDetailMarkDef.ReadOnly = false;
                        this.FixedAssetDetailMarkDef.Required =true ;
                        this.FixedAssetDetailModelDef.ReadOnly = false;
                        this.FixedAssetDetailModelDef.Required =true ;
                        this.FixedAssetDetailBodyDef.ReadOnly = false;
                        this.FixedAssetDetailBodyDef.Required =true ;
                        this.FixedAssetDetailEdgeDef.ReadOnly = false;
                        this.FixedAssetDetailEdgeDef.Required = true;
                        this.ReferansNo.ReadOnly =false ;
                        this.ReferansNo.Required = true;
                        this.SerialNumber.ReadOnly = false;
                        this.SerialNumber.Required = true;
                        this.Length.ReadOnly =false ;
                        this.Length.Required = true;
                        this.Picture.ReadOnly =false ;
                        this.Picture.Required =true ;
                        this.ProductionDate.ReadOnly =false ;
                        this.Description.ReadOnly = false;
                        this.cmdFind.ReadOnly = false;
                        this.OtherBody.ReadOnly = false;
                        this.OtherEdge.ReadOnly = false;
                        this.OtherLenght.ReadOnly = false;
                        this.OtherMainClass.ReadOnly = false;
                        this.OtherMark.ReadOnly = false;
                        this.OtherModel.ReadOnly = false;


                        //2.Aşama Kapalı Taraf
                        this.UseStartDate.ReadOnly = true;
                        this.UseStartDate.Required = false;
                        this.ProposedNATOStockNo.ReadOnly = true;
                        this.ProposedNATOStockNo.Required = false;
                        this.ProposedStockcardName.ReadOnly = true;
                        this.ProposedStockcardName.Required = false;
                        this.IntendedUse.ReadOnly = true;
                        this.IntendedUse.Required = false;
                        this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                        this.IsAdvancedTechnology.ReadOnly = true;
                        this.IsAdvancedTechnology.Required = false;
                        this.GuarantiePeriod.ReadOnly = true;
                        this.GuarantiePeriod.Required = false;
                        this.GuarantyStartDate.ReadOnly = true;
                        this.GuarantyStartDate.Required = false;
                        this.GuarantyStatus.ReadOnly = true;
                        this.GuarantyStatus.Required = false;
                        this.CalibrationPeriod.ReadOnly = true;
                        this.CalibrationPeriod.Required = false;
                        this.CalibrationStatus.ReadOnly = true;
                        this.CalibrationStatus.Required=false;
                        this.LastCalibrationDate.ReadOnly = true;
                        this.LastCalibrationDate.Required = false;
                        this.MaintanenceStatus.ReadOnly = true;
                        this.MaintanenceStatus.Required = false;
                        this.MaintenancePeriod.ReadOnly = true;
                        this.MaintenancePeriod.Required = false;
                        this.LastMaintenanceDate.ReadOnly = true;
                        this.LastMaintenanceDate.Required = false;
                        this.Power.ReadOnly = true;
                        this.Power.Required = false;
                        this.Voltage.ReadOnly = true;
                        this.Voltage.Required = false;
                        this.Frequency.ReadOnly = true;
                        this.Frequency.Required = false;
                        
                        
                        CheckProperty(stateGet);
                    }
                    
                    
                }
            }
            
            if(this.FixedAssetDetailMainClass.ReadOnly == true)
                this.OtherMainClass.ReadOnly = true;
            else
                this.OtherMainClass.ReadOnly = false;
            
            if(this.FixedAssetDetailMarkDef.ReadOnly == true)
                this.OtherMark.ReadOnly = true;
            else
                this.OtherMark.ReadOnly = false;
            
            if(this.FixedAssetDetailModelDef.ReadOnly == true)
                this.OtherModel.ReadOnly = true;
            else
                this.OtherModel.ReadOnly = false;
            
            if(this.FixedAssetDetailBodyDef.ReadOnly == true)
                this.OtherBody.ReadOnly = true;
            else
                this.OtherBody.ReadOnly = false;
            
            if(this.Length.ReadOnly == true)
                this.OtherLenght.ReadOnly = true;
            else
                this.OtherLenght.ReadOnly = false;
            
            if(this.FixedAssetDetailEdgeDef.ReadOnly == true)
                this.OtherEdge.ReadOnly = true;
            else
                this.OtherEdge.ReadOnly = false;
#endregion SetMaterialDetailDefForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SetMaterialDetailDefForm_PostScript
    base.PostScript(transDef);
            
            
            if(stateGet == 3)
            {
                if(this._SetMaterialDetailDef.OtherMainClass == true || this._SetMaterialDetailDef.OtherBody == true ||
                   this._SetMaterialDetailDef.OtherEdge == true ||  this._SetMaterialDetailDef.OtherLenght == true ||
                   this._SetMaterialDetailDef.OtherMark == true ||    this._SetMaterialDetailDef.OtherModel == true)
                {
                    throw new TTException("Diğer Seçenegi kaldırılmadan Kaydet ve Tamamlama İşlemi Yapılamaz.");
                }
                
            }
#endregion SetMaterialDetailDefForm_PostScript

            }
            
#region SetMaterialDetailDefForm_Methods
        public int stateGet;
        public bool hekMissingstatus = false;
        
        public void CheckProperty(int section)
        {
            if(section != 1 && section != 2  && section != 3)
                section = 1;
            
            otherControl();
            
            //1.Aşama
            if (section == 1)
            {
                //hekveKayıpkontrol
                if(this._SetMaterialDetailDef.OperationStatus != null)
                {
                    if (this._SetMaterialDetailDef.OperationStatus.Value == FixeAssetOperationStatusEnum.HEK || this._SetMaterialDetailDef.OperationStatus.Value == FixeAssetOperationStatusEnum.Missing)
                    {
                        hekMissingstatus = true;
                        HekAndMissingStatus(hekMissingstatus);
                    }
                    else
                    {
                        hekMissingstatus = false;
                        HekAndMissingStatus(hekMissingstatus);
                        FixModelType();
                        MarkModelStatusControl();
                    }
                }

            }
            //2.Aşama
            if (section == 2)
            {
                if ((this._SetMaterialDetailDef.OperationStatus.Value == FixeAssetOperationStatusEnum.HEK ||
                     this._SetMaterialDetailDef.OperationStatus.Value == FixeAssetOperationStatusEnum.Missing) &&
                    this._SetMaterialDetailDef.IsDemoded.Value == YesNoEnum.No)
                {
                    this.UseStartDate.ReadOnly = true;
                    this.UseStartDate.Required = false;
                    
                    this.IntendedUse.Required = false;
                    this.IntendedUse.ReadOnly = true;
                    this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                    this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.IsAdvancedTechnology.ReadOnly = true;
                    this.IsAdvancedTechnology.Required = false;
                    
                    this.GuarantyStatus.ReadOnly = true;
                    this.GuarantyStatus.Required = false;
                    this.CalibrationStatus.ReadOnly = true;
                    this.CalibrationStatus.Required = false;
                    this.MaintanenceStatus.ReadOnly = true;
                    this.MaintanenceStatus.Required = false;
                }
                else
                {
                    this.IntendedUse.Required = true;
                    this.IntendedUse.ReadOnly = false;
                    this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = true;
                    this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IsAdvancedTechnology.ReadOnly = false;
                    this.IsAdvancedTechnology.Required = true;
                    
                    this.GuarantyStatus.ReadOnly = false;
                    this.GuarantyStatus.Required = true;
                    this.CalibrationStatus.ReadOnly = false;
                    this.CalibrationStatus.Required = true;
                    this.MaintanenceStatus.ReadOnly = false;
                    this.MaintanenceStatus.Required = true;
                    
                }


                //garanti
                if (this._SetMaterialDetailDef.GuarantyStatus == VarYokGarantiEnum.V)
                {
                    this.GuarantyStartDate.Required = true;
                    this.GuarantiePeriod.Required = true;

                }
                if (this._SetMaterialDetailDef.GuarantyStatus == VarYokGarantiEnum.Y)
                {
                    this.GuarantyStartDate.ReadOnly = true;
                    this.GuarantyStartDate.Required = false;
                    this._SetMaterialDetailDef.GuarantyStartDate = null;

                    this.GuarantiePeriod.ReadOnly = true;
                    this.GuarantiePeriod.Required = false;
                    this._SetMaterialDetailDef.GuarantiePeriod = null;
                }
                //kalibrasyon
                if (this._SetMaterialDetailDef.CalibrationStatus == CMRequireEnum.Requires)
                {
                    this.CalibrationPeriod.Required = true;
                    this.CalibrationPeriod.ReadOnly = false;
                    this.LastCalibrationDate.Required = true;
                    this.LastCalibrationDate.ReadOnly = false;
                }
                if (this._SetMaterialDetailDef.CalibrationStatus == CMRequireEnum.NonRequires)
                {
                    this.CalibrationPeriod.ReadOnly = true;
                    this.CalibrationPeriod.Required = false;
                    this._SetMaterialDetailDef.CalibrationPeriod = null;

                    this.LastCalibrationDate.ReadOnly = true;
                    this.LastCalibrationDate.Required = false;
                    this._SetMaterialDetailDef.LastCalibrationDate = null;
                }
                //Bakım
                if (this._SetMaterialDetailDef.MaintanenceStatus == CMRequireEnum.Requires)
                {
                    this.MaintenancePeriod.Required = true;
                    this.MaintenancePeriod.ReadOnly = false;
                    this.LastMaintenanceDate.Required = true;
                    this.LastMaintenanceDate.ReadOnly = false;
                }
                if (this._SetMaterialDetailDef.MaintanenceStatus == CMRequireEnum.NonRequires)
                {
                    this.MaintenancePeriod.ReadOnly = true;
                    this.MaintenancePeriod.Required = false;
                    this._SetMaterialDetailDef.MaintenancePeriod = null;

                    this.LastMaintenanceDate.ReadOnly = true;
                    this.LastMaintenanceDate.Required = false;
                    this._SetMaterialDetailDef.LastMaintenanceDate = null;
                }
                
                if (this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.Device)
                {
                    this.UseStartDate.ReadOnly = false;
                    this.UseStartDate.Required = true;
                    this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = true;
                }
                

            }
            //3.Aşama
            if (section == 3)
            {
                this.PhysicalBarcode.ReadOnly = true;
                this.IsDemoded.ReadOnly = true;
                this.OperationStatus.ReadOnly = true;
                this.DetailType.ReadOnly = true;
                this.MarkModelStatus.ReadOnly = true;
                this.MarkModelReason.ReadOnly = true;
                this.FixedAssetDetailMainClass.ReadOnly = true;
                this.FixedAssetDetailMarkDef.ReadOnly = true;
                this.FixedAssetDetailModelDef.ReadOnly = true;
                this.FixedAssetDetailBodyDef.ReadOnly = true;
                this.FixedAssetDetailEdgeDef.ReadOnly = true;
                this.ReferansNo.ReadOnly = true;
                this.SerialNumber.ReadOnly = true;
                this.Length.ReadOnly = true;
                this.Picture.ReadOnly = true;
                this.ProductionDate.ReadOnly = true;
                this.Description.ReadOnly = false;
                this.cmdFind.ReadOnly = true;
                this.OtherBody.ReadOnly = true;
                this.OtherEdge.ReadOnly = true;
                this.OtherLenght.ReadOnly = true;
                this.OtherMainClass.ReadOnly = true;
                this.OtherMark.ReadOnly = true;
                this.OtherModel.ReadOnly = true;
                
                if(this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.HandTool)
                {
                    this.Power.ReadOnly = true;
                    this.Power.Required = false;
                    this._SetMaterialDetailDef.Power = null;
                    
                    this.Frequency.ReadOnly = true;
                    this.Frequency.Required = false;
                    this._SetMaterialDetailDef.Frequency = null;
                    
                    this.Voltage.ReadOnly = true;
                    this.Voltage.Required = false;
                    this._SetMaterialDetailDef.Voltage = null;
                }
                
                if(this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.Other && this._SetMaterialDetailDef.MarkModelStatus == VarYokGarantiEnum.Y)
                {
                    this.Power.Required = false;
                    this.Frequency.Required = false;
                    this.Voltage.Required = false;
                }
                
                //2.Aşama Kapalı Taraf
                this.UseStartDate.ReadOnly = true;
                this.UseStartDate.Required = false;
                this.ProposedNATOStockNo.ReadOnly = true;
                this.ProposedNATOStockNo.Required = false;
                this.ProposedStockcardName.ReadOnly = true;
                this.ProposedStockcardName.Required = false;
                this.IntendedUse.ReadOnly = true;
                this.IntendedUse.Required = false;
                this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this.IsAdvancedTechnology.ReadOnly = true;
                this.IsAdvancedTechnology.Required = false;
                this.GuarantiePeriod.ReadOnly = true;
                this.GuarantiePeriod.Required = false;
                this.GuarantyStartDate.ReadOnly = true;
                this.GuarantyStartDate.Required = false;
                this.GuarantyStatus.ReadOnly = true;
                this.GuarantyStatus.Required = false;
                this.CalibrationPeriod.ReadOnly = true;
                this.CalibrationPeriod.Required = false;
                this.CalibrationStatus.ReadOnly = true;
                this.CalibrationStatus.Required=false;
                this.LastCalibrationDate.ReadOnly = true;
                this.LastCalibrationDate.Required = false;
                this.MaintanenceStatus.ReadOnly = true;
                this.MaintanenceStatus.Required = false;
                this.MaintenancePeriod.ReadOnly = true;
                this.MaintenancePeriod.Required = false;
                this.LastMaintenanceDate.ReadOnly = true;
                this.LastMaintenanceDate.Required = false;
                this.Power.ReadOnly = true;
                this.Power.Required = false;
                this.Voltage.ReadOnly = true;
                this.Voltage.Required = false;
                this.Frequency.ReadOnly = true;
                this.Frequency.Required = false;
                
                this.ProposedNATOStockNo.Visible = true;
            }
            
            
             otherControl();
        }
        
        

        public void HekAndMissingStatus(bool statusHekMissing)
        {
            if (statusHekMissing == true)
            {
                
                this.PhysicalBarcode.ReadOnly = true;
                this.PhysicalBarcode.Required = false;
                this._SetMaterialDetailDef.PhysicalBarcode = null;
                
                this.IsDemoded.ReadOnly = true;
                
                
                this.DetailType.ReadOnly = true;
                this.DetailType.Required = false;
                this._SetMaterialDetailDef.DetailType = null;

                this.MarkModelStatus.ReadOnly = true;
                this.MarkModelStatus.Required = false;
                this._SetMaterialDetailDef.MarkModelStatus = null;

                this.MarkModelReason.ReadOnly = true;
                this.MarkModelReason.Required = false;
                this._SetMaterialDetailDef.MarkModelReason = null;

                this.FixedAssetDetailMainClass.ReadOnly = true;
                this.FixedAssetDetailMainClass.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailMainClass = null;

                this.FixedAssetDetailMarkDef.ReadOnly = true;
                this.FixedAssetDetailMarkDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailMarkDef = null;

                this.FixedAssetDetailModelDef.ReadOnly = true;
                this.FixedAssetDetailModelDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailModelDef = null;

                this.ReferansNo.ReadOnly = true;
                this.ReferansNo.Required = false;
                this._SetMaterialDetailDef.ReferansNo = null;

                this.SerialNumber.ReadOnly = true;
                this.SerialNumber.Required = false;
                this._SetMaterialDetailDef.SerialNumber = null;

                this.FixedAssetDetailBodyDef.ReadOnly = true;
                this.FixedAssetDetailBodyDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailBodyDef = null;

                this.FixedAssetDetailEdgeDef.ReadOnly = true;
                this.FixedAssetDetailEdgeDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailEdgeDef = null;

                this.Length.ReadOnly = true;
                this.Length.Required = false;
                this._SetMaterialDetailDef.Length = null;

                this.ProposedNATOStockNo.ReadOnly = true;
                this.ProposedNATOStockNo.Required = false;
                this._SetMaterialDetailDef.ProposedNATOStockNo = null;

                this.ProposedStockcardName.ReadOnly = true;
                this.ProposedStockcardName.Required = false;
                this._SetMaterialDetailDef.ProposedStockcardName = null;

                this.ProductionDate.ReadOnly = true;
                this.ProductionDate.Required = false;
                this._SetMaterialDetailDef.ProductionDate = null;

                this.Description.ReadOnly = false;
                

                this.OtherBody.ReadOnly = true;
                this.OtherEdge.ReadOnly = true;
                this.OtherLenght.ReadOnly = true;
                this.OtherMainClass.ReadOnly = true;
                this.OtherMark.ReadOnly = true;
                this.OtherModel.ReadOnly = true;

            }

            else
            {
                this.DetailType.ReadOnly = false;
                this.DetailType.Required = true;

                this.MarkModelStatus.ReadOnly = false;
                this.MarkModelStatus.Required = true;

                this.MarkModelReason.ReadOnly = false;
                this.MarkModelReason.Required = true;

                this.FixedAssetDetailMainClass.ReadOnly = false;
                this.FixedAssetDetailMainClass.Required = true;

                this.FixedAssetDetailMarkDef.ReadOnly = false;
                this.FixedAssetDetailMarkDef.Required = true;

                this.FixedAssetDetailModelDef.ReadOnly = false;
                this.FixedAssetDetailModelDef.Required = true;

                this.ReferansNo.ReadOnly = false;
                this.ReferansNo.Required = true;

                this.SerialNumber.ReadOnly = false;
                this.SerialNumber.Required = true;

                this.FixedAssetDetailBodyDef.ReadOnly = false;
                this.FixedAssetDetailBodyDef.Required = true;

                this.FixedAssetDetailEdgeDef.ReadOnly = false;
                this.FixedAssetDetailEdgeDef.Required = true;

                this.Length.ReadOnly = false;
                this.Length.Required = true;

                this.OtherBody.ReadOnly = false;
                this.OtherEdge.ReadOnly = false;
                this.OtherLenght.ReadOnly = false;
                this.OtherMainClass.ReadOnly = false;
                this.OtherMark.ReadOnly = false;
                this.OtherModel.ReadOnly = false;
            }

        }

        public void FixModelType()
        {
            //Cihaz
            if (this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.Device)
            {
                this.FixedAssetDetailBodyDef.ReadOnly = true;
                this.FixedAssetDetailBodyDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailBodyDef = null;

                this.FixedAssetDetailEdgeDef.ReadOnly = true;
                this.FixedAssetDetailEdgeDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailEdgeDef = null;

                this.Length.ReadOnly = true;
                this.Length.Required = false;
                this._SetMaterialDetailDef.Length = null;

                this.FixedAssetDetailMainClass.Required = true;
                this.FixedAssetDetailMainClass.ReadOnly = false;
                this.FixedAssetDetailModelDef.Required = true;
                this.FixedAssetDetailModelDef.ReadOnly = false;
                this.FixedAssetDetailMarkDef.Required = true;
                this.FixedAssetDetailMarkDef.ReadOnly = false;
                this.SerialNumber.Required = true;
                this.SerialNumber.ReadOnly = false;

                this.ReferansNo.ReadOnly = false;
                this.ReferansNo.Required = false;
                
                this.MarkModelReason.ReadOnly = false;
                this.MarkModelReason.Required = true;

            }
            //el aletleri
            if (this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.HandTool)
            {
                this.FixedAssetDetailMainClass.Required = true;
                this.FixedAssetDetailModelDef.Required = false;
                this.FixedAssetDetailMarkDef.Required = false;
                this.SerialNumber.Required = false;

                this.FixedAssetDetailBodyDef.ReadOnly = true;
                this.FixedAssetDetailBodyDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailBodyDef = null;

                this.FixedAssetDetailEdgeDef.ReadOnly = true;
                this.FixedAssetDetailEdgeDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailEdgeDef = null;

                this.Length.ReadOnly = true;
                this.Length.Required = false;
                this._SetMaterialDetailDef.Length = null;

                this.ReferansNo.Required = true;
                this.ReferansNo.ReadOnly = false;
                
                this.MarkModelReason.ReadOnly = true;
                this.MarkModelReason.Required = false;
                this._SetMaterialDetailDef.MarkModelReason = null;
                

            }
            //diğer
            if (this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.HandTool)
            {
                this.FixedAssetDetailMainClass.Required = true;
                this.FixedAssetDetailModelDef.Required = false;
                this.FixedAssetDetailMarkDef.Required = false;
                this.SerialNumber.Required = false;

                this.FixedAssetDetailBodyDef.ReadOnly = true;
                this.FixedAssetDetailBodyDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailBodyDef = null;

                this.FixedAssetDetailEdgeDef.ReadOnly = true;
                this.FixedAssetDetailEdgeDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailEdgeDef = null;

                this.Length.ReadOnly = true;
                this.Length.Required = false;
                this._SetMaterialDetailDef.Length = null;
                
                this.MarkModelReason.ReadOnly = false;
                this.MarkModelReason.Required = true;

            }

        }

        public void MarkModelStatusControl()
        {
            if (this._SetMaterialDetailDef.MarkModelStatus == VarYokGarantiEnum.V)
            {
                this.Description.ReadOnly = false;
                this.Description.Required = false;

                this.FixedAssetDetailBodyDef.ReadOnly = true;
                this.FixedAssetDetailBodyDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailBodyDef = null;

                this.FixedAssetDetailEdgeDef.ReadOnly = true;
                this.FixedAssetDetailEdgeDef.Required = false;
                this._SetMaterialDetailDef.FixedAssetDetailEdgeDef = null;

                this.Length.ReadOnly = true;
                this.Length.Required = false;
                this._SetMaterialDetailDef.Length = null;
                
                this.MarkModelReason.ReadOnly = true;
                this.MarkModelReason.Required = false;
                this._SetMaterialDetailDef.MarkModelReason = null;
                
                this.MarkModelReason.ReadOnly = false;
                this.MarkModelReason.Required = true;
                
                this.SerialNumber.ReadOnly = true;
                this.SerialNumber.Required = false;
                
                //cihaz
                if (this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.Device)
                {
                    
                    
                    this.MarkModelReason.ReadOnly = true;
                    this.MarkModelReason.Required = false;
                    this._SetMaterialDetailDef.MarkModelReason = null;
                    
                    this.SerialNumber.ReadOnly = false;
                    this.SerialNumber.Required = true;
                    
                }
                //diğer
                if (this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.Other)
                {
                    this.ReferansNo.ReadOnly = false;
                    this.ReferansNo.Required= false;
                    
                    this.MarkModelReason.ReadOnly = true;
                    this.MarkModelReason.Required = false;
                    this._SetMaterialDetailDef.MarkModelReason = null;
                    
                    this.FixedAssetDetailMarkDef.ReadOnly = false;
                    this.FixedAssetDetailModelDef.ReadOnly = false;
                    this.Description.ReadOnly = false;
                    this.SerialNumber.ReadOnly = false;
                    
                    this.FixedAssetDetailMarkDef.Required = false;
                    this.FixedAssetDetailModelDef.Required = false;
                    this.Description.Required = false;
                    this.SerialNumber.Required = false;
                    
                }
                
                //el alati
                if (this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.HandTool)
                {
                    
                    this.Description.ReadOnly = false;
                    this.Description.Required = false;
                    
                    this.FixedAssetDetailMainClass.ReadOnly = false;
                    this.FixedAssetDetailModelDef.ReadOnly = false;
                    this.FixedAssetDetailMarkDef.ReadOnly = false;
                    
                    this.FixedAssetDetailMainClass.Required = true;
                    this.FixedAssetDetailModelDef.Required = true;
                    this.FixedAssetDetailMarkDef.Required = true;
                    
                    this.MarkModelReason.ReadOnly = true;
                    this.MarkModelReason.Required = false;
                    this._SetMaterialDetailDef.MarkModelReason = null;
                }
                

            }
            else
            {
                this.SerialNumber.ReadOnly = false;
                this.SerialNumber.Required = true;
                
                // cihaz
                if (this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.Device)
                {
                    
                    
                    this.Description.ReadOnly = false;
                    //this.Description.Required = true;
                    this.FixedAssetDetailMainClass.Required = true;
                    this.FixedAssetDetailMainClass.ReadOnly = false;
                    this.ReferansNo.Required = false;
                    this.FixedAssetDetailMarkDef.ReadOnly = true;
                    this.FixedAssetDetailMarkDef.Required = false;
                    this._SetMaterialDetailDef.FixedAssetDetailMarkDef = null;
                    this.FixedAssetDetailModelDef.ReadOnly = true;
                    this.FixedAssetDetailModelDef.Required = false;
                    this._SetMaterialDetailDef.FixedAssetDetailModelDef = null;
                    this.SerialNumber.Required = false;
                    this.SerialNumber.ReadOnly = true;
                    this._SetMaterialDetailDef.SerialNumber = null;
                    
                    this.MarkModelReason.ReadOnly = false;
                    this.MarkModelReason.Required = true;
                    
                    
                }
                // el aletleri
                if (this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.HandTool)
                {
                    this.FixedAssetDetailMainClass.Required = true;
                    this.FixedAssetDetailMainClass.ReadOnly = false;
                    this.FixedAssetDetailBodyDef.ReadOnly = false;
                    this.FixedAssetDetailBodyDef.Required = true;
                    this.FixedAssetDetailEdgeDef.ReadOnly = false;
                    this.FixedAssetDetailEdgeDef.Required = true;
                    this.Length.ReadOnly = false;
                    this.Length.Required = true;
                    this.FixedAssetDetailMarkDef.ReadOnly = true;
                    this.FixedAssetDetailMarkDef.Required = false;
                    this._SetMaterialDetailDef.FixedAssetDetailMarkDef = null;
                    this.FixedAssetDetailModelDef.ReadOnly = true;
                    this.FixedAssetDetailModelDef.Required = false;
                    this._SetMaterialDetailDef.FixedAssetDetailModelDef = null;
                    this.ReferansNo.ReadOnly = true;
                    this.ReferansNo.Required = false;
                    this._SetMaterialDetailDef.ReferansNo = null;
                    this.SerialNumber.ReadOnly = true;
                    this.SerialNumber.Required = false;
                    this._SetMaterialDetailDef.SerialNumber = null;
                    
                    this.MarkModelReason.ReadOnly = false;
                    this.MarkModelReason.Required = true;
                    
                    this.Description.ReadOnly = false;
                    this.Description.Required = false;
                }
                //diğer
                if (this._SetMaterialDetailDef.DetailType == FixedAssetDetailTypeEnum.Other)
                {
                    this.FixedAssetDetailMainClass.ReadOnly = false;
                    this.FixedAssetDetailMainClass.Required = true;
                    this.SerialNumber.ReadOnly = true;
                    this.SerialNumber.Required = false;
                    this._SetMaterialDetailDef.SerialNumber = null;
                    this.FixedAssetDetailModelDef.ReadOnly = true;
                    this.FixedAssetDetailModelDef.Required = false;
                    this._SetMaterialDetailDef.FixedAssetDetailModelDef = null;
                    this.FixedAssetDetailMarkDef.ReadOnly = true;
                    this.FixedAssetDetailMarkDef.Required = false;
                    this._SetMaterialDetailDef.FixedAssetDetailMarkDef = null;
                    this.ReferansNo.ReadOnly = true;
                    this.ReferansNo.Required = false;
                    this._SetMaterialDetailDef.ReferansNo = null;
                    this.FixedAssetDetailBodyDef.ReadOnly = true;
                    this.FixedAssetDetailBodyDef.Required = false;
                    this._SetMaterialDetailDef.FixedAssetDetailBodyDef = null;
                    this.FixedAssetDetailEdgeDef.ReadOnly = true;
                    this.FixedAssetDetailEdgeDef.Required = false;
                    this._SetMaterialDetailDef.FixedAssetDetailEdgeDef = null;
                    
                    this.MarkModelReason.ReadOnly = false;
                    this.MarkModelReason.Required = true;
                    
                    this.Length.Required = false;
                    this.Length.ReadOnly = true;
                    
                    this.Description.ReadOnly = false;
                    this.Description.Required = false;
                    
                }

            }

        }
        
        public void otherControl()
        {
            
            if(this.FixedAssetDetailMainClass.ReadOnly == true)
                this.OtherMainClass.ReadOnly = true;
            else
                this.OtherMainClass.ReadOnly = false;
            
            if(this.FixedAssetDetailMarkDef.ReadOnly == true)
                this.OtherMark.ReadOnly = true;
            else
                this.OtherMark.ReadOnly = false;
            
            if(this.FixedAssetDetailModelDef.ReadOnly == true)
                this.OtherModel.ReadOnly = true;
            else
                this.OtherModel.ReadOnly = false;
            
            if(this.FixedAssetDetailBodyDef.ReadOnly == true)
                this.OtherBody.ReadOnly = true;
            else
                this.OtherBody.ReadOnly = false;
            
            if(this.Length.ReadOnly == true)
                this.OtherLenght.ReadOnly = true;
            else
                this.OtherLenght.ReadOnly = false;
            
            if(this.FixedAssetDetailEdgeDef.ReadOnly == true)
                this.OtherEdge.ReadOnly = true;
            else
                this.OtherEdge.ReadOnly = false;
        }
        
#endregion SetMaterialDetailDefForm_Methods
    }
}