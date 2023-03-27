
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
    /// Demirbaş Malzeme Detayları
    /// </summary>
    public partial class FixedAssetInDetailForm : TTForm
    {
        override protected void BindControlEvents()
        {
            OtherModel.CheckedChanged += new TTControlEventDelegate(OtherModel_CheckedChanged);
            OtherMark.CheckedChanged += new TTControlEventDelegate(OtherMark_CheckedChanged);
            OtherMainClass.CheckedChanged += new TTControlEventDelegate(OtherMainClass_CheckedChanged);
            OtherLenght.CheckedChanged += new TTControlEventDelegate(OtherLenght_CheckedChanged);
            OtherEdge.CheckedChanged += new TTControlEventDelegate(OtherEdge_CheckedChanged);
            OtherBody.CheckedChanged += new TTControlEventDelegate(OtherBody_CheckedChanged);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            GuarantiePeriodFixedAssetMaterialDefinitionDetail.TextChanged += new TTControlEventDelegate(GuarantiePeriodFixedAssetMaterialDefinitionDetail_TextChanged);
            FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            OperationStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(OperationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            MarkModelStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(MarkModelStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            GuarantyStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(GuarantyStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            DetailTypeFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(DetailTypeFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            DetailClassFixedAssetMaterialDefinitionDetail.SelectedIndexChanged += new TTControlEventDelegate(DetailClassFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OtherModel.CheckedChanged -= new TTControlEventDelegate(OtherModel_CheckedChanged);
            OtherMark.CheckedChanged -= new TTControlEventDelegate(OtherMark_CheckedChanged);
            OtherMainClass.CheckedChanged -= new TTControlEventDelegate(OtherMainClass_CheckedChanged);
            OtherLenght.CheckedChanged -= new TTControlEventDelegate(OtherLenght_CheckedChanged);
            OtherEdge.CheckedChanged -= new TTControlEventDelegate(OtherEdge_CheckedChanged);
            OtherBody.CheckedChanged -= new TTControlEventDelegate(OtherBody_CheckedChanged);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            GuarantiePeriodFixedAssetMaterialDefinitionDetail.TextChanged -= new TTControlEventDelegate(GuarantiePeriodFixedAssetMaterialDefinitionDetail_TextChanged);
            FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail_SelectedObjectChanged);
            OperationStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(OperationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            MarkModelStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(MarkModelStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            GuarantyStatusFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(GuarantyStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            DetailTypeFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(DetailTypeFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            DetailClassFixedAssetMaterialDefinitionDetail.SelectedIndexChanged -= new TTControlEventDelegate(DetailClassFixedAssetMaterialDefinitionDetail_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void OtherModel_CheckedChanged()
        {
#region FixedAssetInDetailForm_OtherModel_CheckedChanged
   if (this._FixedAssetInDetail.OtherModel != null)
            {
                if (this._FixedAssetInDetail.OtherModel == true)
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetInDetailForm_OtherModel_CheckedChanged
        }

        private void OtherMark_CheckedChanged()
        {
#region FixedAssetInDetailForm_OtherMark_CheckedChanged
   if (this._FixedAssetInDetail.OtherMark != null)
            {
                if (this._FixedAssetInDetail.OtherMark == true)
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetInDetailForm_OtherMark_CheckedChanged
        }

        private void OtherMainClass_CheckedChanged()
        {
#region FixedAssetInDetailForm_OtherMainClass_CheckedChanged
   if (this._FixedAssetInDetail.OtherMainClass != null)
            {
                if (this._FixedAssetInDetail.OtherMainClass == true)
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetInDetailForm_OtherMainClass_CheckedChanged
        }

        private void OtherLenght_CheckedChanged()
        {
#region FixedAssetInDetailForm_OtherLenght_CheckedChanged
   if (this._FixedAssetInDetail.OtherLenght != null)
            {
                if (this._FixedAssetInDetail.OtherLenght == true)
                    this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    
                    this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetInDetailForm_OtherLenght_CheckedChanged
        }

        private void OtherEdge_CheckedChanged()
        {
#region FixedAssetInDetailForm_OtherEdge_CheckedChanged
   if (this._FixedAssetInDetail.OtherEdge != null)
            {
                if (this._FixedAssetInDetail.OtherEdge == true)
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetInDetailForm_OtherEdge_CheckedChanged
        }

        private void OtherBody_CheckedChanged()
        {
#region FixedAssetInDetailForm_OtherBody_CheckedChanged
   if (this._FixedAssetInDetail.OtherBody != null)
            {
                if (this._FixedAssetInDetail.OtherBody == true)
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                else
                    
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = true;
            }
#endregion FixedAssetInDetailForm_OtherBody_CheckedChanged
        }

        private void ttbutton1_Click()
        {
#region FixedAssetInDetailForm_ttbutton1_Click
   if (string.IsNullOrEmpty(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.ReferansNo) == false)
            {
                IList referanslar = this._FixedAssetInDetail.ObjectContext.QueryObjects("FIXEDASSETDETAILREFDEF", "REFERANCE ='" + this._FixedAssetInDetail.FixedAssetMaterialDefDetail.ReferansNo + "'");
                if (referanslar.Count > 0)
                {
                    FixedAssetDetailRefDef fadRef = (FixedAssetDetailRefDef)referanslar[0];

                    if (fadRef.FixedAssetDetailMainClass != null)
                        this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass = fadRef.FixedAssetDetailMainClass;

                    if (fadRef.FixedAssetDetailMarkDef != null)
                        this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = fadRef.FixedAssetDetailMarkDef;

                    if (fadRef.FixedAssetDetailModelDef != null)
                        this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = fadRef.FixedAssetDetailModelDef;

                    if (fadRef.FixedAssetDetailBodyDef != null)
                        this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = fadRef.FixedAssetDetailBodyDef;

                    if (fadRef.FixedAssetDetailEdgeDef != null)
                        this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = fadRef.FixedAssetDetailEdgeDef;

                    if (fadRef.FixedAssetDetailLengthDef != null)
                        this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = fadRef.FixedAssetDetailLengthDef;

                }
                else
                    InfoBox.Show("İlgili Referans No lu kayıt bulunamadı", MessageIconEnum.InformationMessage);
            }
            else
                InfoBox.Show("Referans No boş olamaz", MessageIconEnum.ErrorMessage);
#endregion FixedAssetInDetailForm_ttbutton1_Click
        }

        private void FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
#region FixedAssetInDetailForm_FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
   this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ListFilterExpression = "FIXEDASSETDETAILEDGEDEF = " + ConnectionManager.GuidToString(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef.ObjectID);
            
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef != null)
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            }
#endregion FixedAssetInDetailForm_FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
        }

        private void FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
#region FixedAssetInDetailForm_FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
   this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
            FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ListFilterExpression = "FIXEDASSETDETAILBODYDEF = " + ConnectionManager.GuidToString(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef.ObjectID);
            
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef != null)
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            }
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef != null)
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
            }
#endregion FixedAssetInDetailForm_FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
        }

        private void GuarantiePeriodFixedAssetMaterialDefinitionDetail_TextChanged()
        {
#region FixedAssetInDetailForm_GuarantiePeriodFixedAssetMaterialDefinitionDetail_TextChanged
   if (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStartDate != null && this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantiePeriod != null)
            {
                this.GuarantyEndDate.NullableValue = ((DateTime)this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStartDate).AddDays((int)this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantiePeriod);
            }
#endregion FixedAssetInDetailForm_GuarantiePeriodFixedAssetMaterialDefinitionDetail_TextChanged
        }

        private void FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
#region FixedAssetInDetailForm_FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
   this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef != null)
                FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ListFilterExpression = "FIXEDASSETDETAILMARKDEF = " + ConnectionManager.GuidToString(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef.ObjectID);
            
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef != null)
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;
            }
#endregion FixedAssetInDetailForm_FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
        }

        private void FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail_SelectedObjectChanged()
        {
#region FixedAssetInDetailForm_FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
   this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass != null)
                FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ListFilterExpression = "FIXEDASSETDETAILMAINCLASS = " + ConnectionManager.GuidToString(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass.ObjectID);

            this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass != null)
                FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ListFilterExpression = "FIXEDASSETDETAILMAINCLASS = " + ConnectionManager.GuidToString(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass.ObjectID);
            
            
            
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef != null)
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;
            }
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef != null)
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;
            }
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef != null)
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
            }
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef != null)
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
            }
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef != null)
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
            }
#endregion FixedAssetInDetailForm_FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail_SelectedObjectChanged
        }

        private void OperationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetInDetailForm_OperationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   if (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.Missing)
            {
                InfoBox.Show("Yeni girişlerde Kayıp seçilemez", MessageIconEnum.ErrorMessage);
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus = null;
            }
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK)
            {
                this.DetailClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.DetailClassFixedAssetMaterialDefinitionDetail.Required = true;
            }

            CheckProperty();
            
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK)
            {
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStartDate = null;
                
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantiePeriod = null;
                
                this.GuarantyEndDate.ReadOnly = true;
                this.GuarantyEndDate.Required = false;
                _FixedAssetInDetail.GuarantyEndDate = null;
            }
#endregion FixedAssetInDetailForm_OperationStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void MarkModelStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetInDetailForm_MarkModelStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetInDetailForm_MarkModelStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void GuarantyStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetInDetailForm_GuarantyStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   if (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus == VarYokGarantiEnum.V)
            {
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = true;

                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = true;
                
                this.GuarantyEndDate.ReadOnly = false;
                this.GuarantyEndDate.Required = true;
            }

            if (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus == VarYokGarantiEnum.Y)
            {
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;

                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                
                this.GuarantyEndDate.Required = false;
                this.GuarantyEndDate.ReadOnly = true;
            }

//            if (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus == VarYokEnum.B)
//            {
//                InfoBox.Show("Garanti Durumu Bilinmiyor seçilemez.", MessageIconEnum.ErrorMessage);
//                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus = null;
//            }
#endregion FixedAssetInDetailForm_GuarantyStatusFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void DetailTypeFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetInDetailForm_DetailTypeFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetInDetailForm_DetailTypeFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        private void DetailClassFixedAssetMaterialDefinitionDetail_SelectedIndexChanged()
        {
#region FixedAssetInDetailForm_DetailClassFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
   CheckProperty();
#endregion FixedAssetInDetailForm_DetailClassFixedAssetMaterialDefinitionDetail_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region FixedAssetInDetailForm_PreScript
    base.PreScript();

            
            
            if (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailClass == null)
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailClass = DetailClassEnum.Medical;

            if (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.IsDemoded == null)
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.IsDemoded = YesNoEnum.No;

            if (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus == null)
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus = FixeAssetOperationStatusEnum.InOperation;

            if (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailType == null)
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailType = FixedAssetDetailTypeEnum.Device;

            if (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == null)
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus = VarYokGarantiEnum.V;

            if (this._FixedAssetInDetail.StockActionDetail.StockAction is IChattelDocumentWithPurchase)
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus = VarYokGarantiEnum.V;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;
            }
            
            if((this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailClass != null && this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.NonMedical) ||
               (this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus != null && this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK))
            {
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus = null;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyEndDate.ReadOnly = true;
                
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyEndDate.Required = false;
                
                this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;
            }
#endregion FixedAssetInDetailForm_PreScript

            }
            
#region FixedAssetInDetailForm_Methods
        public void CheckProperty()
        {
            this.StockCardMaterial.ReadOnly = true;
            this.BarcodeMaterial.ReadOnly = true;
            this.NameMaterial.ReadOnly = true;
            this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = true;
            
            
            
            this.DetailClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            this.DetailClassFixedAssetMaterialDefinitionDetail.Required = true;
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
            //this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = true;
            this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = true;
            //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            //this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = true;
            //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            //this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = true;
            //this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            // this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = true;
            this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;
            this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
            this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;
            
            
            this.OtherMainClass.ReadOnly = false;
            this.OtherMark.ReadOnly = false;
            this.OtherModel.ReadOnly = false;
            this.OtherBody.ReadOnly = false;
            this.OtherEdge.ReadOnly = false;
            this.OtherLenght.ReadOnly = false;
            this.ttbutton1.ReadOnly = false;

            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus != null)
                GarantiStatus();
            
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus !=null)
                HekStatus();
            
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
            {
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
            }
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.Y)
            {
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = true;
            }
            
            //MalzemeninSınıfıSağlık
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.Medical)
            {
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = true;
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus = VarYokGarantiEnum.V;
                
                
                //El Aleti
                if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailType ==  FixedAssetDetailTypeEnum.HandTool)
                {
                    //MarkaModelVar
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
                    {
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        
                        this.OtherBody.ReadOnly = true;
                        this.OtherEdge.ReadOnly = true;
                        this.OtherLenght.ReadOnly = true;
                        
                        this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.SerialNumber = null;
                        
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = true;
                        
                    }
                    //MarkaModelYOK
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.Y)
                    {
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        
                        
                        this.OtherBody.ReadOnly = false;
                        this.OtherEdge.ReadOnly = false;
                        this.OtherLenght.ReadOnly = false;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = true;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = true;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = true;
                        
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                    }
                    
                }
                //Cihaz
                else if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailType ==  FixedAssetDetailTypeEnum.Device)
                {
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    
                    this.OtherBody.ReadOnly = true;
                    this.OtherEdge.ReadOnly = true;
                    this.OtherLenght.ReadOnly = true;
                    
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;
                    this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = true;
                    
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                    this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                    this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                    
                    //markamodelvar
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
                    {
                        
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = true;
                        
                        
                    }
                    //markamodelyok
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.Y)
                    {
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        
                        this.OtherBody.ReadOnly = true;
                        this.OtherEdge.ReadOnly = true;
                        this.OtherLenght.ReadOnly = true;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.SerialNumber = null;
                        
                        
                    }
                    
                    
                }
                //Diğer
                else if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailType == FixedAssetDetailTypeEnum.Other)
                {
                    //MarkaModelVar
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
                    {
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        
                        this.OtherBody.ReadOnly = true;
                        this.OtherEdge.ReadOnly = true;
                        this.OtherLenght.ReadOnly = true;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
                        
                        
                    }
                    //MarkaModelYOK
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.Y)
                    {
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                    }
                    
                }
                
            }
            //MalzemeninSınıfıVeteriner
            else if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailClass == DetailClassEnum.Veterinary)
            {
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = true;
                this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus = VarYokGarantiEnum.V;
                
                //El Aleti
                if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailType ==  FixedAssetDetailTypeEnum.HandTool)
                {
                    //MarkaModelVar
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
                    {
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = true;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        
                        this.OtherBody.ReadOnly = true;
                        this.OtherEdge.ReadOnly = true;
                        this.OtherLenght.ReadOnly = true;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.SerialNumber = null;
                        
                    }
                    //MarkaModelYOK
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.Y)
                    {
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        
                        
                        this.OtherBody.ReadOnly = false;
                        this.OtherEdge.ReadOnly = false;
                        this.OtherLenght.ReadOnly = false;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = true;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = true;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = true;
                        
                        
                    }
                }
                //Cihaz
                else if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailType ==  FixedAssetDetailTypeEnum.Device)
                {
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                    
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                    
                    this.OtherBody.ReadOnly = true;
                    this.OtherEdge.ReadOnly = true;
                    this.OtherLenght.ReadOnly = true;
                    
                    this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;
                    this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;
                    this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;
                    this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = true;
                    
                    this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                    this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                    this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                    this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                    
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
                    {
                        
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = true;
                    }
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.Y)
                    {
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        
                    }
                    
                    
                }
                //Diğer
                else if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailType ==  FixedAssetDetailTypeEnum.Other)
                {
                    //MarkaModelVar
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.V)
                    {
                        
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                        
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        
                        
                        this.OtherBody.ReadOnly = true;
                        this.OtherEdge.ReadOnly = true;
                        this.OtherLenght.ReadOnly = true;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
                        _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
                        
                        
                    }
                    //MarkaModelYOK
                    if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus == VarYokGarantiEnum.Y)
                    {
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                        
                        this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                        
                        this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                        this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                        this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                    }
                    
                }
            }
            //MalzemeninSınıfıSHHDEĞİL
            else
            {
                
                this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.OperationStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ttbutton1.ReadOnly = true;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyEndDate.ReadOnly = true;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.OtherMainClass.ReadOnly = true;
                this.OtherMark.ReadOnly = true;
                this.OtherModel.ReadOnly = true;
                this.OtherBody.ReadOnly = true;
                this.OtherEdge.ReadOnly = true;
                this.OtherLenght.ReadOnly = true;
                
                
                this.IsDemodedFixedAssetMaterialDefinitionDetail.Required = false;
                this.OperationStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = false;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyEndDate.Required = false;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;
                this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;
                
                
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.IsDemoded = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailType = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelReason = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.ReferansNo = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.SerialNumber = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.SetSystemUnitDefinition = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStartDate = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantiePeriod = null;
                _FixedAssetInDetail.GuarantyEndDate = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.ProductionDate = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.Description = null;
                
                this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.UseStartDate = null;
                
            }
            
            
            
            
            
            this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK)
            {
                
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly= true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = true;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStartDate = null;
                
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = true;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantiePeriod = null;
                
                this.GuarantyEndDate.ReadOnly = false;
                this.GuarantyEndDate.Required = true;
                _FixedAssetInDetail.GuarantyEndDate = null;
                
            }
            
            this.OtherMainClass.ReadOnly = false;
            this.OtherMark.ReadOnly = false;
            this.OtherModel.ReadOnly = false;
            this.OtherBody.ReadOnly = false;
            this.OtherEdge.ReadOnly = false;
            this.OtherLenght.ReadOnly = false;
            
            
            
            
            this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
            this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;
            
            otherControl();
        }
        
        public void GarantiStatus()
        {
            //GarantiVarsa
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus == VarYokGarantiEnum.V)
            {
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = true;
                
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = true;
                
                this.GuarantyEndDate.ReadOnly = false;
                this.GuarantyEndDate.Required = true;
            }
            //GarantiYoksa
            else
            {
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = true;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStartDate = null;
                
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = true;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantiePeriod = null;
                
                this.GuarantyEndDate.ReadOnly = false;
                this.GuarantyEndDate.Required = true;
                _FixedAssetInDetail.GuarantyEndDate = null;
            }
            otherControl();
        }
        
        
        public void HekStatus()
        {
            if(this._FixedAssetInDetail.FixedAssetMaterialDefDetail.OperationStatus == FixeAssetOperationStatusEnum.HEK)
            {
                this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.ttbutton1.ReadOnly = true;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.GuarantyEndDate.ReadOnly = true;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.OtherMainClass.ReadOnly = true;
                this.OtherMark.ReadOnly = true;
                this.OtherModel.ReadOnly = true;
                this.OtherBody.ReadOnly = true;
                this.OtherEdge.ReadOnly = true;
                this.OtherLenght.ReadOnly = true;
                
                
                this.IsDemodedFixedAssetMaterialDefinitionDetail.Required = false;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = false;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = false;
                this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = false;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = false;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.Required = false;
                this.GuarantyEndDate.Required = false;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = false;
                this.DescriptionFixedAssetMaterialDefinitionDetail.Required = false;
                
                
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.IsDemoded = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.DetailType = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelStatus = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.MarkModelReason = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMainClass = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailMarkDef = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailModelDef = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailBodyDef = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailEdgeDef = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.FixedAssetDetailLengthDef = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.ReferansNo = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.SerialNumber = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.SetSystemUnitDefinition = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStatus = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantyStartDate = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.GuarantiePeriod = null;
                _FixedAssetInDetail.GuarantyEndDate = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.ProductionDate = null;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.Description = null;
                
                this.UseStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = true;
                this.UseStartDateFixedAssetMaterialDefinitionDetail.Required = false;
                _FixedAssetInDetail.FixedAssetMaterialDefDetail.UseStartDate = null;
            }
            else
            {
                this.IsDemodedFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.ReferansNoFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.ttbutton1.ReadOnly = false;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantyStartDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantiePeriodFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.GuarantyEndDate.ReadOnly = false;
                this.ProductionDateFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.DescriptionFixedAssetMaterialDefinitionDetail.ReadOnly = false;
                this.OtherMainClass.ReadOnly = false;
                this.OtherMark.ReadOnly = false;
                this.OtherModel.ReadOnly = false;
                this.OtherBody.ReadOnly = false;
                this.OtherEdge.ReadOnly = false;
                this.OtherLenght.ReadOnly = false;
                
                
                this.IsDemodedFixedAssetMaterialDefinitionDetail.Required = true;
                this.DetailTypeFixedAssetMaterialDefinitionDetail.Required = true;
                this.MarkModelStatusFixedAssetMaterialDefinitionDetail.Required = true;
                this.MarkModelReasonFixedAssetMaterialDefinitionDetail.Required = true;
                this.FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail.Required = true;
                this.FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail.Required = true;
                this.FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail.Required = true;
                this.FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail.Required = true;
                this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.Required = true;
                this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.Required = true;
                //this.ReferansNoFixedAssetMaterialDefinitionDetail.Required = true;
                this.SerialNumberFixedAssetMaterialDefinitionDetail.Required = true;
                //this.SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail.Required = true;
                this.GuarantyStatusFixedAssetMaterialDefinitionDetail.Required = true;
                //this.ProductionDateFixedAssetMaterialDefinitionDetail.Required = true;
                this.DescriptionFixedAssetMaterialDefinitionDetail.Required = true;
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
            
            if(this.FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail.ReadOnly == true)
                this.OtherLenght.ReadOnly = true;
            else
                this.OtherLenght.ReadOnly = false;
            
            if(this.FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail.ReadOnly == true)
                this.OtherEdge.ReadOnly = true;
            else
                this.OtherEdge.ReadOnly = false;
        }
        
#endregion FixedAssetInDetailForm_Methods
    }
}