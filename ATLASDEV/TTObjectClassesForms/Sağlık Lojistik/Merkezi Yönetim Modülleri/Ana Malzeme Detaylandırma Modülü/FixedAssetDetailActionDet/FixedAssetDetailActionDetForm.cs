
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
    /// Ana Malzeme Detayı
    /// </summary>
    public partial class FixedAssetDetailActionDetForm : TTForm
    {
        override protected void BindControlEvents()
        {
            CalibrationPeriodFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(CalibrationPeriodFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            CalibrationStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(CalibrationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            GuarantiePeriodFixedAssetMaterialDefinitionDetail.TextChanged += new TTControlEventDelegate(GuarantiePeriodFixedAssetMaterialDefinitionDetail_TextChanged);
            GuarantyStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(GuarantyStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            MaintenancePeriodFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(MaintenancePeriodFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            MaintanenceStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(MaintanenceStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            OtherMainClass.CheckedChanged += new TTControlEventDelegate(OtherMainClass_CheckedChanged);
            OtherLenght.CheckedChanged += new TTControlEventDelegate(OtherLenght_CheckedChanged);
            cmdFind.Click += new TTControlEventDelegate(cmdFind_Click);
            OtherEdge.CheckedChanged += new TTControlEventDelegate(OtherEdge_CheckedChanged);
            OtherBody.CheckedChanged += new TTControlEventDelegate(OtherBody_CheckedChanged);
            LengthFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(LengthFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            OtherModel.CheckedChanged += new TTControlEventDelegate(OtherModel_CheckedChanged);
            OperationStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(OperationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            OtherMark.CheckedChanged += new TTControlEventDelegate(OtherMark_CheckedChanged);
            SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            DetailClassFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(DetailClassFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            DetailTypeFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(DetailTypeFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            IsFixedAssetFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(IsFixedAssetFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            IsSetSystemUnitFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(IsSetSystemUnitFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            MarkModelStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(MarkModelStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            CalibrationPeriodFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(CalibrationPeriodFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            CalibrationStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(CalibrationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            GuarantiePeriodFixedAssetMaterialDefinitionDetail.TextChanged -= new TTControlEventDelegate(GuarantiePeriodFixedAssetMaterialDefinitionDetail_TextChanged);
            GuarantyStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(GuarantyStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            MaintenancePeriodFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(MaintenancePeriodFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            MaintanenceStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(MaintanenceStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            OtherMainClass.CheckedChanged -= new TTControlEventDelegate(OtherMainClass_CheckedChanged);
            OtherLenght.CheckedChanged -= new TTControlEventDelegate(OtherLenght_CheckedChanged);
            cmdFind.Click -= new TTControlEventDelegate(cmdFind_Click);
            OtherEdge.CheckedChanged -= new TTControlEventDelegate(OtherEdge_CheckedChanged);
            OtherBody.CheckedChanged -= new TTControlEventDelegate(OtherBody_CheckedChanged);
            LengthFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(LengthFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            OtherModel.CheckedChanged -= new TTControlEventDelegate(OtherModel_CheckedChanged);
            OperationStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(OperationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            OtherMark.CheckedChanged -= new TTControlEventDelegate(OtherMark_CheckedChanged);
            SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            DetailClassFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(DetailClassFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            DetailTypeFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(DetailTypeFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            IsFixedAssetFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(IsFixedAssetFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            IsSetSystemUnitFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(IsSetSystemUnitFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            MarkModelStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(MarkModelStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void CalibrationPeriodFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_CalibrationPeriodFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_CalibrationPeriodFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void CalibrationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_CalibrationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_CalibrationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void GuarantiePeriodFixedAssetMaterialDefinitionDetail_TextChanged()
        {
#region FixedAssetDetailActionDetForm_GuarantiePeriodFixedAssetMaterialDefinitionDetail_TextChanged
   if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStartDate != null && this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantiePeriod != null)
            {
                this.GuarantyEndDate.NullableValue = ((DateTime)this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStartDate).AddDays((int)this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantiePeriod);
            }
#endregion FixedAssetDetailActionDetForm_GuarantiePeriodFixedAssetMaterialDefinitionDetail_TextChanged
        }

        private void GuarantyStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_GuarantyStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_GuarantyStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void MaintenancePeriodFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_MaintenancePeriodFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_MaintenancePeriodFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void MaintanenceStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_MaintanenceStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_MaintanenceStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void OtherMainClass_CheckedChanged()
        {
#region FixedAssetDetailActionDetForm_OtherMainClass_CheckedChanged
   if (this._FixedAssetDetailActionDet.OtherMainClass != null)
            {
                if (this._FixedAssetDetailActionDet.OtherMainClass == true)
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetDetailActionDetForm_OtherMainClass_CheckedChanged
        }

        private void OtherLenght_CheckedChanged()
        {
#region FixedAssetDetailActionDetForm_OtherLenght_CheckedChanged
   if(this._FixedAssetDetailActionDet.OtherLenght != null)
            {
                if(this._FixedAssetDetailActionDet.OtherLenght == true)
                    this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    this.LengthFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetDetailActionDetForm_OtherLenght_CheckedChanged
        }

        private void cmdFind_Click()
        {
#region FixedAssetDetailActionDetForm_cmdFind_Click
   if (string.IsNullOrEmpty(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ReferansNo) == false)
            {
                IList referanslar = this._FixedAssetDetailActionDet.ObjectContext.QueryObjects("FIXEDASSETDETAILREFDEF", "REFERANCE ='" + this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ReferansNo + "'");
                if (referanslar.Count > 0)
                {
                    FixedAssetDetailRefDef fadRef = (FixedAssetDetailRefDef)referanslar[0];

                    if (fadRef.FixedAssetDetailMainClass != null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass = fadRef.FixedAssetDetailMainClass;

                    if (fadRef.FixedAssetDetailMarkDef != null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = fadRef.FixedAssetDetailMarkDef;

                    if (fadRef.FixedAssetDetailModelDef != null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = fadRef.FixedAssetDetailModelDef;

                    if (fadRef.FixedAssetDetailBodyDef != null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = fadRef.FixedAssetDetailBodyDef;

                    if (fadRef.FixedAssetDetailEdgeDef != null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = fadRef.FixedAssetDetailEdgeDef;

                    if (fadRef.FixedAssetDetailLengthDef != null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = fadRef.FixedAssetDetailLengthDef;

                }
                else
                    InfoBox.Show("İlgili Referans No lu kayıt bulunamadı", MessageIconEnum.InformationMessage);
            }
            else
                InfoBox.Show("Referans No boş olamaz", MessageIconEnum.ErrorMessage);
#endregion FixedAssetDetailActionDetForm_cmdFind_Click
        }

        private void OtherEdge_CheckedChanged()
        {
#region FixedAssetDetailActionDetForm_OtherEdge_CheckedChanged
   if(this._FixedAssetDetailActionDet.OtherEdge != null)
            {
                if(this._FixedAssetDetailActionDet.OtherEdge == true)
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetDetailActionDetForm_OtherEdge_CheckedChanged
        }

        private void OtherBody_CheckedChanged()
        {
#region FixedAssetDetailActionDetForm_OtherBody_CheckedChanged
   if(this._FixedAssetDetailActionDet.OtherBody != null)
            {
                if(this._FixedAssetDetailActionDet.OtherBody == true)
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetDetailActionDetForm_OtherBody_CheckedChanged
        }

        private void LengthFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
#region FixedAssetDetailActionDetForm_LengthFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
   if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef != null)
            {
                if (string.IsNullOrEmpty(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef.ProposedNATOStockNo) == false)
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedNATOStockNo = this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef.ProposedNATOStockNo;

                if (string.IsNullOrEmpty(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef.ProposedStockcardName) == false)
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedStockcardName = this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef.ProposedStockcardName;
            }
#endregion FixedAssetDetailActionDetForm_LengthFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
        }

        private void OtherModel_CheckedChanged()
        {
#region FixedAssetDetailActionDetForm_OtherModel_CheckedChanged
   if(this._FixedAssetDetailActionDet.OtherModel != null)
            {
                if(this._FixedAssetDetailActionDet.OtherModel == true)
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetDetailActionDetForm_OtherModel_CheckedChanged
        }

        private void OperationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_OperationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_OperationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void OtherMark_CheckedChanged()
        {
#region FixedAssetDetailActionDetForm_OtherMark_CheckedChanged
   if(this._FixedAssetDetailActionDet.OtherMark != null)
            {
                if(this._FixedAssetDetailActionDet.OtherMark == true)
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetDetailActionDetForm_OtherMark_CheckedChanged
        }

        private void SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
        }

        private void FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
#region FixedAssetDetailActionDetForm_FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
   this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef != null)
                LengthFixedAssetMaterialDefinitionDetail.ListFilterExpression = "FIXEDASSETDETAILEDGEDEF = " + ConnectionManager.GuidToString(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef.ObjectID);
            
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef != null)
            {
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            }
#endregion FixedAssetDetailActionDetForm_FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
        }

        private void DetailClassFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_DetailClassFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_DetailClassFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
#region FixedAssetDetailActionDetForm_FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
   this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef != null)
                FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ListFilterExpression = "FIXEDASSETDETAILBODYDEF = " + ConnectionManager.GuidToString(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef.ObjectID);
            
            
          
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef != null)
            {
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
            }
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef != null)
            {
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            }
#endregion FixedAssetDetailActionDetForm_FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
        }

        private void DetailTypeFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_DetailTypeFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_DetailTypeFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
#region FixedAssetDetailActionDetForm_FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
   if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef != null)
            {
                if (string.IsNullOrEmpty(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef.ProposedNATOStockNo) == false)
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedNATOStockNo = this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef.ProposedNATOStockNo;

                if (string.IsNullOrEmpty(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef.ProposedStockcardName) == false)
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedStockcardName = this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef.ProposedStockcardName;

            }
#endregion FixedAssetDetailActionDetForm_FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
        }

        private void FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
#region FixedAssetDetailActionDetForm_FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
   this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef != null)
                FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ListFilterExpression = "FIXEDASSETDETAILMARKDEF = " + ConnectionManager.GuidToString(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef.ObjectID);
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef != null)
            {
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;
            }
#endregion FixedAssetDetailActionDetForm_FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
        }

        private void IsFixedAssetFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_IsFixedAssetFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_IsFixedAssetFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
#region FixedAssetDetailActionDetForm_FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
   this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass != null)
                FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ListFilterExpression = "FIXEDASSETDETAILMAINCLASS = " + ConnectionManager.GuidToString(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass.ObjectID);

            
            this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass != null)
                FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ListFilterExpression = "FIXEDASSETDETAILMAINCLASS = " + ConnectionManager.GuidToString(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass.ObjectID);
            
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef != null)
            {
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;
                
            }
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef != null)
            {
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;
            }
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef != null)
            {
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
            }
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef != null)
            {
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
            }
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef != null)
            {
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            }
#endregion FixedAssetDetailActionDetForm_FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
        }

        private void IsSetSystemUnitFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_IsSetSystemUnitFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
            
            
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.Yes)
            {
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetSystemUnitDefinition = null;
                
//                if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.Veterinary)
//                {
//                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit = YesNoEnum.No;
//                     throw new TTException("Veteriner Set/Sistem/Ünite Evet Seçilemez!");
//                }
            }
            else
            {
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
                
            }
#endregion FixedAssetDetailActionDetForm_IsSetSystemUnitFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void MarkModelStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetDetailActionDetForm_MarkModelStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetDetailActionDetForm_MarkModelStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region FixedAssetDetailActionDetForm_PreScript
    base.PreScript();
            
            stockCardTextBox.Text = this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard.NATOStockNO + " - " + this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard.Name;
            barcodeTextBox.Text = this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetDefinition.Barcode;
            materialNameTextBox.Text = this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;

            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.AccountancyEntryDate == null)
            {
                if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetTransactions.Select(string.Empty).Count > 0)
                {
                    StockTransaction firstTrx = this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetTransactions.Select(string.Empty)[0].StockTransaction.GetFirstInTransaction();
                    if(firstTrx != null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.AccountancyEntryDate = firstTrx.TransactionDate ;
                    else
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.AccountancyEntryDate =  this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetTransactions.Select(string.Empty)[0].StockTransaction.TransactionDate ;
                }
            }

            CheckProperty();

            if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageOne)
            {
                if (IsFixedAssetFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                {
                    IsFixedAssetFixedAssetMaterialDefinitionDetail.Required = true;
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsFixedAsset == null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsFixedAsset = YesNoEnum.Yes;
                }
                if (DetailClassFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                {
                    DetailClassFixedAssetMaterialDefinitionDetail.Required = true;
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass = DetailClassEnum.Medical;
                }
                if (IsSetSystemUnitFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                {
                    IsSetSystemUnitFixedAssetMaterialDefinitionDetail.Required = true;
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit = YesNoEnum.No;
                }

                if (IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                {
                    IsDemodedFixedAssetMaterialDefinitionDetail.Required = true;
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsDemoded == null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsDemoded = YesNoEnum.No;
                }
                if (OperationStatusFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                {
                    OperationStatusFixedAssetMaterialDefinitionDetail.Required = true;
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus = FixeAssetOperationStatusEnum.InOperation;
                }
                if (DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                {
                    DetailTypeFixedAssetMaterialDefinitionDetail.Required = true;
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType = FixedAssetDetailTypeEnum.Device;
                }
                if (MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                {
                    MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = true;
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus == null)
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus = VarYokGarantiEnum.V;
                }
                Stage2.ReadOnly = true;
            }

            if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
            {
                if (IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                {
                    IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = true;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsAdvancedTechnology = YesNoEnum.No;
                }

                if (GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                    GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = true;
                if (CalibrationStatusFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                    CalibrationStatusFixedAssetMaterialDefinitionDetail.Required = true;
                if (CalibrationPeriodFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                    CalibrationPeriodFixedAssetMaterialDefinitionDetail.Required = true;
                if (MaintanenceStatusFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                    MaintanenceStatusFixedAssetMaterialDefinitionDetail.Required = true;
                if (MaintenancePeriodFixedAssetMaterialDefinitionDetail.ReadOnly == false)
                    MaintenancePeriodFixedAssetMaterialDefinitionDetail.Required = true;
                Stage1.ReadOnly = true;
                
                
                this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = true;
                
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly= true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                
                this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = true;
                
                
                if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing ||
                   this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical ||
                   this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsFixedAsset == YesNoEnum.No)
                {
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = true;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.UseStartDate = null;

                }
                if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.Yes || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK)
                {
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                }
                
                if(this._FixedAssetDetailActionDet.IsNewFixedAsset == true)
                {
                    if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK ||
                       this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical)
                    {
                        IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = false;
                    }
                }
                
            }
            
            
            string filterExpression = string.Empty;
            filterExpression = " SITES = " + ConnectionManager.GuidToString(this._FixedAssetDetailActionDet.FixedAssetDetailAction.FromSite.ObjectID) ;
            this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ListFilterExpression = filterExpression;

            if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
            {
                if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetMaterialDetails.Count > 0)
                    this.SetMaterialDetailsSetMaterialDetailDef.ReadOnly = false;
                else
                    this.SetMaterialDetailsSetMaterialDetailDef.ReadOnly = true;
            }

            if(this._FixedAssetDetailActionDet.IsNewFixedAsset == true)
                
            {
                
                this.PhysicalBarcodeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyEndDate.ReadOnly = true;
                this.IsFixedAssetFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                
                
                this.PhysicalBarcodeFixedAssetMaterialDefinitionDetail.Required = false;
                this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.Required = false;;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = false;
                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyEndDate.Required = false;
                this.IsFixedAssetFixedAssetMaterialDefinitionDetail.Required = false;
            }
            
            if(this._FixedAssetDetailActionDet.IsNewFixedAsset == true)
            {
                this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                
                if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard.NATOStockNO != null)
                {
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Picture = this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard.CardPicture;
                }
                else
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Picture = null;
                
            }
            
            
            //SONHATADANDONENLER
            
            
            if(this._FixedAssetDetailActionDet.IsNewFixedAsset != true)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                {
                    this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required= false;
                    
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = true;
                    
                    if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.Veterinary)
                    {
                        if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.HandTool)
                        {
                            this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = true;
                            this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        }
                        if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Device
                           && this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
                        {
                            this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                            this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = true;
                        }
                    }
                    
                    
                }
                
            }
            
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical
               || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK
               || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing )
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                {
                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.PhysicalBarcodeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.DetailClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                }
            }
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Other &&
               this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                {
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = true;
                    this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = true;
                    this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = true;
                }
                
            }
            
            if(this._FixedAssetDetailActionDet.IsNewFixedAsset != true)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                {
                    this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = true;
                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required= false;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = true;
                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = true;
                    
                    if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.Yes)
                    {
                        this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                        this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                        
                    }
                    
                    
                }
                
            }
            
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical
               || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK
               || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing )
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                {
                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.PhysicalBarcodeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.IsFixedAssetFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                    this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                }
            }
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK
               || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing )
                this.DetailClassFixedAssetMaterialDefinitionDetail.ReadOnly = true;
            
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsFixedAsset == YesNoEnum.No ||
               this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical)
            {
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
            }
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.Yes && this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
            {
                this.UseStartDateFixedAssetMaterialDefinitionDetail.Required= false;
                this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly= true;
                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = false;
            }
            
            
            
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical)
            {

                this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType = null;

                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus = null;

                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelReason = null;

                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass = null;

                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;

                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;

                this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ReferansNo = null;

                this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SerialNumber = null;

                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProductionDate = null;

                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetSystemUnitDefinition = null;

                this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Description = null;

                this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Picture = null;

                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedNATOStockNo = null;

                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedStockcardName = null;

                this.IntendedUseFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IntendedUseFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IntendedUse = null;

                this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LifePeriod = null;

                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsAdvancedTechnology = null;

                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStatus = null;

                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStartDate = null;

                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantiePeriod = null;

                this.CalibrationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.CalibrationStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationStatus = null;

                this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastCalibrationDate = null;

                this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationPeriod = null;

                this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintanenceStatus = null;

                this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastMaintenanceDate = null;

                this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintenancePeriod = null;

                this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PowerFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Power = null;

                this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.VoltageFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Voltage = null;

                this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FrequencyFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Frequency = null;

                
                this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.UseStartDate = null;
                
                
            }
#endregion FixedAssetDetailActionDetForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region FixedAssetDetailActionDetForm_PostScript
    base.PostScript(transDef);

            if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageOne)
                this._FixedAssetDetailActionDet.IsAccountancy = true;

            if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                this._FixedAssetDetailActionDet.IsBMM = true;

            if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                this._FixedAssetDetailActionDet.IsETKM = true;
            
            //setse
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.Yes
                &&  this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetMaterialDetails.Count < 2)
            {
                throw new TTException("Set Detayları En Az 2 Satır Olmalıdır.!");
            }
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == null &&
               this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.No)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetMaterialDetails.Count > 0)
                {
                    throw new TTException("Set Detayları Girilmiştir.Set Detayları Silinmesi Gerekmektedir.");
                }
            }
            
            
            if(this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
            {
                if(this._FixedAssetDetailActionDet.OtherMainClass == true || this._FixedAssetDetailActionDet.OtherBody == true ||
                   this._FixedAssetDetailActionDet.OtherEdge == true ||  this._FixedAssetDetailActionDet.OtherLenght == true ||
                   this._FixedAssetDetailActionDet.OtherMark == true ||    this._FixedAssetDetailActionDet.OtherModel == true)
                {
                    throw new TTException("Diğer Seçenegi kaldırılmadan Kaydet ve Tamamlama İşlemi Yapılamaz.");
                }
                
            }
            
            if(this._FixedAssetDetailActionDet.IsNewFixedAsset == true)
            {
                this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
            }
            
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsFixedAsset == YesNoEnum.No || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing)
                this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = false;
#endregion FixedAssetDetailActionDetForm_PostScript

            }
            
#region FixedAssetDetailActionDetForm_Methods
        public void CheckProperty()
        {
            otherControl();

            // Demirbaş değil.
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsFixedAsset == YesNoEnum.No)
            {
                this.DetailClassFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DetailClassFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass = null;

                this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit = null;

                this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsDemodedFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsDemoded = null;

                this.OperationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.OperationStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus = null;

                this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType = null;

                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus = null;

                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelReason = null;

                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass = null;

                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;

                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;

                this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ReferansNo = null;

                this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SerialNumber = null;

                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProductionDate = null;

                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetSystemUnitDefinition = null;

                this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Description = null;

                this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Picture = null;

                // BMM

                //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                //this.LengthFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                //this.LengthFixedAssetMaterialDefinitionDetail2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedNATOStockNo = null;

                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedStockcardName = null;

                this.IntendedUseFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IntendedUseFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IntendedUse = null;

                this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LifePeriod = null;

                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsAdvancedTechnology = null;

                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStatus = null;

                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStartDate = null;

                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantiePeriod = null;

                this.CalibrationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.CalibrationStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationStatus = null;

                this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastCalibrationDate = null;

                this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationPeriod = null;

                this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintanenceStatus = null;

                this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastMaintenanceDate = null;

                this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintenancePeriod = null;

                this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PowerFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Power = null;

                this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.VoltageFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Voltage = null;

                this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FrequencyFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Frequency = null;

            }
            //Demirbaş dır.
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsFixedAsset == YesNoEnum.Yes)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageOne || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.DetailClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.DetailClassFixedAssetMaterialDefinitionDetail.Required = true;

                    this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.Required = true;

                    this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IsDemodedFixedAssetMaterialDefinitionDetail.Required = true;

                    this.OperationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.OperationStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;

                    this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = true;

                    this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LengthFixedAssetMaterialDefinitionDetail.Required = true;

                    this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;

                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;

                    this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;

                    if(this._FixedAssetDetailActionDet.IsNewFixedAsset != true)
                    {
                        this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.PictureFixedAssetMaterialDefinitionDetail.Required = true;
                    }
                }



                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.ReadOnly = false;
                    //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.Required = true;

                    //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.ReadOnly = false;
                    //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.Required = true;

                    //this.LengthFixedAssetMaterialDefinitionDetail2.ReadOnly = false;
                    //this.LengthFixedAssetMaterialDefinitionDetail2.Required = true;
                    if(this._FixedAssetDetailActionDet.IsNewFixedAsset != true)
                    {
                        this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.PictureFixedAssetMaterialDefinitionDetail.Required = true;
                    }

                    this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    //  this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = true;

                    // this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    //  this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = true;

                    this.IntendedUseFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IntendedUseFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = true;

                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = true;

                    this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.CalibrationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.CalibrationStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.Required = true;

                    this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.PowerFixedAssetMaterialDefinitionDetail.Required = true;

                    this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.VoltageFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FrequencyFixedAssetMaterialDefinitionDetail.Required = true;

                    //this.ttpictureboxcontrol2.ReadOnly = false;
                    //this.ttpictureboxcontrol2.Required = true;

                    //this.DescriptionFixedAssetMaterialDefinitionDetail2.ReadOnly = false;
                    //this.DescriptionFixedAssetMaterialDefinitionDetail2.Required = true;
                }
            }

            //Set dir
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.Yes)
            {

                this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsDemodedFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsDemoded = null;

                this.OperationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.OperationStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus = null;

                this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType = null;

                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus = null;

                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelReason = null;

                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass = null;

                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;

                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;

                this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ReferansNo = null;

                this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SerialNumber = null;

                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProductionDate = null;

                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetSystemUnitDefinition = null;

                this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Description = null;

                this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Picture = null;

                // BMM

                //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                //this.LengthFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                //this.LengthFixedAssetMaterialDefinitionDetail2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedNATOStockNo = null;

                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedStockcardName = null;

                this.IntendedUseFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IntendedUseFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IntendedUse = null;

                this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LifePeriod = null;

                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsAdvancedTechnology = null;

                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStatus = null;

                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStartDate = null;

                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantiePeriod = null;

                this.CalibrationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.CalibrationStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationStatus = null;

                this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastCalibrationDate = null;

                this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationPeriod = null;

                this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintanenceStatus = null;

                this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastMaintenanceDate = null;

                this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintenancePeriod = null;

                this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PowerFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Power = null;

                this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.VoltageFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Voltage = null;

                this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FrequencyFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Frequency = null;

                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
            }
            //Set Değil  dır.
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.No)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageOne || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IsDemodedFixedAssetMaterialDefinitionDetail.Required = true;

                    this.OperationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.OperationStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;

                    this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = true;

                    this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LengthFixedAssetMaterialDefinitionDetail.Required = true;

                    this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;

                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;

                    this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;

                    if(this._FixedAssetDetailActionDet.IsNewFixedAsset != true)
                    {
                        this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.PictureFixedAssetMaterialDefinitionDetail.Required = true;
                    }

                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
                }



                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    //this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = true;

                    this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    //F this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = true;

                    this.IntendedUseFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IntendedUseFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = true;

                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = true;

                    this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.CalibrationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.CalibrationStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.Required = true;

                    this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.PowerFixedAssetMaterialDefinitionDetail.Required = true;

                    this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.VoltageFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FrequencyFixedAssetMaterialDefinitionDetail.Required = true;
                }
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
            }

            //SIHHİYE ANA MALZEME DEĞİL
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical)
            {
                

                this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit = null;

                this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsDemodedFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsDemoded = null;

                this.OperationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.OperationStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus = null;

                this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType = null;

                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus = null;

                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelReason = null;

                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass = null;

                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;

                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;

                this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ReferansNo = null;

                this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SerialNumber = null;

                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProductionDate = null;

                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetSystemUnitDefinition = null;

                this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Description = null;

                this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Picture = null;

                // BMM

                //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                //this.LengthFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                //this.LengthFixedAssetMaterialDefinitionDetail2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedNATOStockNo = null;

                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedStockcardName = null;

                this.IntendedUseFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IntendedUseFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IntendedUse = null;

                this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LifePeriod = null;

                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsAdvancedTechnology = null;

                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStatus = null;

                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStartDate = null;

                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantiePeriod = null;

                this.CalibrationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.CalibrationStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationStatus = null;

                this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastCalibrationDate = null;

                this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationPeriod = null;

                this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintanenceStatus = null;

                this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastMaintenanceDate = null;

                this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintenancePeriod = null;

                this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PowerFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Power = null;

                this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.VoltageFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Voltage = null;

                this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FrequencyFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Frequency = null;

                //this.ttpictureboxcontrol2.ReadOnly = true;
                //this.ttpictureboxcontrol2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Picture = null;

                //this.DescriptionFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                //this.DescriptionFixedAssetMaterialDefinitionDetail2.Required = false;
                //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Description = null;

            }

            //VeterinerSetDeğil
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.Veterinary && this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.No)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageOne || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.DetailClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.DetailClassFixedAssetMaterialDefinitionDetail.Required = true;

                    this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.Required = true;

                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    //this.IsDemodedFixedAssetMaterialDefinitionDetail.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsDemoded = null;

                    this.OperationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.OperationStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;

                    this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = true;

                    this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                    // this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                    this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                    this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;

                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;

                    this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;

                    if(this._FixedAssetDetailActionDet.IsNewFixedAsset != true)
                    {
                        this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.PictureFixedAssetMaterialDefinitionDetail.Required = true;
                    }
                }

                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                    //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                    //this.LengthFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.LengthFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                    this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = true;

                    this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = true;

                    this.IntendedUseFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.IntendedUseFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsAdvancedTechnology = null;

                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = true;

                    this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.CalibrationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.CalibrationStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.Required = true;

                    this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.Required = true;

                    this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.Required = true;

                    this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.Required = true;

                    this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.PowerFixedAssetMaterialDefinitionDetail.Required = false;

                    this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.VoltageFixedAssetMaterialDefinitionDetail.Required = false;

                    this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FrequencyFixedAssetMaterialDefinitionDetail.Required = false;

                    //this.ttpictureboxcontrol2.ReadOnly = false;
                    //this.ttpictureboxcontrol2.Required = true;

                    //this.DescriptionFixedAssetMaterialDefinitionDetail2.ReadOnly = false;
                    //this.DescriptionFixedAssetMaterialDefinitionDetail2.Required = true;
                }
            }

            //HEK ve Kayıp
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing)
            {

                this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType = null;

                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus = null;

                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelReason = null;

                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass = null;

                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;

                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;

                this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ReferansNo = null;

                this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SerialNumber = null;

                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProductionDate = null;

                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetSystemUnitDefinition = null;

                this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Description = null;

                this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Picture = null;

                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedNATOStockNo = null;

                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ProposedStockcardName = null;

                this.IntendedUseFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IntendedUseFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IntendedUse = null;

                this.LifePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LifePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LifePeriod = null;

                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsAdvancedTechnology = null;

                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStatus = null;

                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStartDate = null;

                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantiePeriod = null;

                this.CalibrationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.CalibrationStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationStatus = null;

                this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastCalibrationDate = null;

                this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationPeriod = null;

                this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MaintanenceStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintanenceStatus = null;

                this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastMaintenanceDate = null;

                this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintenancePeriod = null;

                this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.PowerFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Power = null;

                this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.VoltageFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Voltage = null;

                this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FrequencyFixedAssetMaterialDefinitionDetail.Required = false;
                this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Frequency = null;

                
            }

            //Cihaz
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Device)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageOne || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                    // this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                    //  this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                    this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                    // this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                    this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                }

                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                    //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                    //this.LengthFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.LengthFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;
                }
            }

            //Diğer
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Other)
            {
                
                
                
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageOne || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {

                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;

                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;

                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;

                    this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;

                    this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;

                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                    this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                    this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                }

                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.PowerFixedAssetMaterialDefinitionDetail.Required = false;

                    this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.VoltageFixedAssetMaterialDefinitionDetail.Required = false;

                    this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FrequencyFixedAssetMaterialDefinitionDetail.Required = false;

                    //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                    //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                    //this.LengthFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.LengthFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;
                }
            }

            //El Aletleri
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.HandTool)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.PowerFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Power = null;

                    this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.VoltageFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Voltage = null;

                    this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FrequencyFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Frequency = null;
                }
            }

            //Marka Model Var
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageOne || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelReason = null;

                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                    this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Device)
                    {
                        this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;

                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;

                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = true;

                    }

                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.HandTool)
                    {
                        this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;

                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = true;

                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SerialNumber = null;
                    }

                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Other)
                    {
                        this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;

                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;

                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;

                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;


                    }
                }

                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                    //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                    //this.LengthFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                    //this.LengthFixedAssetMaterialDefinitionDetail2.Required = false;
                    //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;

                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Device)
                    {
                        this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.PowerFixedAssetMaterialDefinitionDetail.Required = true;

                        this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.VoltageFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FrequencyFixedAssetMaterialDefinitionDetail.Required = true;
                    }

                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Other)
                    {
                        this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.PowerFixedAssetMaterialDefinitionDetail.Required = false;

                        this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.VoltageFixedAssetMaterialDefinitionDetail.Required = false;

                        this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FrequencyFixedAssetMaterialDefinitionDetail.Required = false;
                    }
                }
            }

            //Marka Model Yok
            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.Y)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageOne || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Device)
                    {
                        this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;

                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;

                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;

                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SerialNumber = null;
                    }
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.HandTool)
                    {
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = true;

                        this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.LengthFixedAssetMaterialDefinitionDetail.Required = true;

                        
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;

                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;

                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ReferansNo = null;

                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SerialNumber = null;
                    }
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Other)
                    {
                        this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;

                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;

                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.ReferansNo = null;

                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SerialNumber = null;

                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                        this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                        this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;
                    }
                }

                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Device)
                    {
                        this.PowerFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.PowerFixedAssetMaterialDefinitionDetail.Required = true;

                        this.VoltageFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.VoltageFixedAssetMaterialDefinitionDetail.Required = true;

                        this.FrequencyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FrequencyFixedAssetMaterialDefinitionDetail.Required = true;

                    }
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.HandTool)
                    {
                        //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.ReadOnly = false;
                        //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.Required = true;

                        //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.ReadOnly = false;
                        //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.Required = true;

                        //this.LengthFixedAssetMaterialDefinitionDetail2.ReadOnly = false;
                        //this.LengthFixedAssetMaterialDefinitionDetail2.Required = true;
                    }
                    if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Other)
                    {
                        //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                        //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail2.Required = false;
                        //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;

                        //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                        //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail2.Required = false;
                        //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;

                        //this.LengthFixedAssetMaterialDefinitionDetail2.ReadOnly = true;
                        //this.LengthFixedAssetMaterialDefinitionDetail2.Required = false;
                        //this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.Length = null;
                    }


                }
            }

            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStatus == VarYokGarantiEnum.Y)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantyStartDate = null;

                    this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.GuarantiePeriod = null;
                }
            }

            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintanenceStatus == CMRequireEnum.NonRequires)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.LastMaintenanceDateFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastMaintenanceDate = null;

                    this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.MaintenancePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MaintenancePeriod = null;
                }
            }

            if (this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationStatus == CMRequireEnum.NonRequires)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo || this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageThree)
                {
                    this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.LastCalibrationDateFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.LastCalibrationDate = null;

                    this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.CalibrationPeriodFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.CalibrationPeriod = null;
                }
            }
            
            if(this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required)
            {
                if(this._FixedAssetDetailActionDet.OtherMark != null)
                {
                    if(this._FixedAssetDetailActionDet.OtherMark == true)
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                }
            }

            if(this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required)
            {
                if(this._FixedAssetDetailActionDet.OtherModel != null)
                {
                    if(this._FixedAssetDetailActionDet.OtherModel == true)
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                }
            }

            if(this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required)
            {
                if(this._FixedAssetDetailActionDet.OtherBody != null)
                {
                    if(this._FixedAssetDetailActionDet.OtherBody == true)
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                }
            }

            if(this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required)
            {
                if(this._FixedAssetDetailActionDet.OtherEdge != null)
                {
                    if(this._FixedAssetDetailActionDet.OtherEdge == true)
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                }
            }

            if(this.LengthFixedAssetMaterialDefinitionDetail.Required)
            {
                if(this._FixedAssetDetailActionDet.OtherLenght != null)
                {
                    if(this._FixedAssetDetailActionDet.OtherLenght == true)
                        this.LengthFixedAssetMaterialDefinitionDetail.Required = false;
                }
            }
            
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
            {
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
            }
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.Y)
            {
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = true;
            }
            
            this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = false; //herdurumdaaçıkolmasıistendi
            
            //YenidenGelen
            if(this._FixedAssetDetailActionDet.IsNewFixedAsset == true)
            {
                this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                
                if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical
                   ||this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK
                   ||this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing )
                {
                    this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.IsDemodedFixedAssetMaterialDefinitionDetail.Required = false;
                    this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsDemoded = null;
                }
                
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;

                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                {
                    this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    
                    this.ProposedNATOStockNoFixedAssetMaterialDefinitionDetail.Required = false;
                    this.ProposedStockcardNameFixedAssetMaterialDefinitionDetail.Required = false;
                    
                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                }
            }
            
            
            
            
            //YENİİİİİİİİİİİİİ
            if(this._FixedAssetDetailActionDet.IsNewFixedAsset != true)
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                {
                    this.PictureFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                    this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required= false;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = true;
                    
                    
                    if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.Yes)
                    {
                        this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                        this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                        
                    }
                    
                    
                }
                
            }
            
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical
               || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK
               || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing )
            {
                if (this._FixedAssetDetailActionDet.FixedAssetDetailAction.CurrentStateDefID == FixedAssetDetailAction.States.StageTwo)
                {
                    this.IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.PhysicalBarcodeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.IsFixedAssetFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.IsSetSystemUnitFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                   this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                   this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
                }
            }
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK
               || this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing )
                this.DetailClassFixedAssetMaterialDefinitionDetail.ReadOnly = true;
            
            
            if(this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsFixedAsset == YesNoEnum.No ||
               this._FixedAssetDetailActionDet.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical)
            {
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this.PictureFixedAssetMaterialDefinitionDetail.Required = false;
            }
            
            
            otherControl();
        }
        
        public void otherControl()
        {
            
            if(this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly == true)
                this.OtherMainClass.ReadOnly = true;
            else
                this.OtherMainClass.ReadOnly = false;
            
            if(this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly == true)
                this.OtherMark.ReadOnly = true;
            else
                this.OtherMark.ReadOnly = false;
            
            if(this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly == true)
                this.OtherModel.ReadOnly = true;
            else
                this.OtherModel.ReadOnly = false;
            
            if(this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly == true)
                this.OtherBody.ReadOnly = true;
            else
                this.OtherBody.ReadOnly = false;
            
            if(this.LengthFixedAssetMaterialDefinitionDetail.ReadOnly == true)
                this.OtherLenght.ReadOnly = true;
            else
                this.OtherLenght.ReadOnly = false;
            
            if(this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly == true)
                this.OtherEdge.ReadOnly = true;
            else
                this.OtherEdge.ReadOnly = false;
        }
        
#endregion FixedAssetDetailActionDetForm_Methods
    }
}