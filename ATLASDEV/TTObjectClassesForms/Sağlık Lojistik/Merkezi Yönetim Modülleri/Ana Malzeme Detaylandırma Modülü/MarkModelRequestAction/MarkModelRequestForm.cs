
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
    /// Marka/Model/Gövde Yapısı/ Uç Yapısı / Uzunluk İstek  
    /// </summary>
    public partial class MarkModelRequestForm : CentralActionBaseForm
    {
        override protected void BindControlEvents()
        {
            FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailEdgeDefFixedAssetDetailLengthDef_SelectedObjectChanged);
            FixedAssetDetailBodyDef.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailBodyDef_SelectedObjectChanged);
            FixedAssetDetailEdgeDef.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailEdgeDef_SelectedObjectChanged);
            NoEdge.CheckedChanged += new TTControlEventDelegate(NoEdge_CheckedChanged);
            NoLength.CheckedChanged += new TTControlEventDelegate(NoLength_CheckedChanged);
            NoBody.CheckedChanged += new TTControlEventDelegate(NoBody_CheckedChanged);
            FixedAssetDetailMarkDefFixedAssetDetailModelDef.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailMarkDefFixedAssetDetailModelDef_SelectedObjectChanged);
            FixedAssetDetailMarkDef.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailMarkDef_SelectedObjectChanged);
            NoMark.CheckedChanged += new TTControlEventDelegate(NoMark_CheckedChanged);
            NoModel.CheckedChanged += new TTControlEventDelegate(NoModel_CheckedChanged);
            BodyEdgeLengt.CheckedChanged += new TTControlEventDelegate(BodyEdgeLengt_CheckedChanged);
            MarkModelReason.CheckedChanged += new TTControlEventDelegate(MarkModelReason_CheckedChanged);
            FixedAssetDetailMainClassDef.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDetailMainClassDef_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailEdgeDefFixedAssetDetailLengthDef_SelectedObjectChanged);
            FixedAssetDetailBodyDef.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailBodyDef_SelectedObjectChanged);
            FixedAssetDetailEdgeDef.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailEdgeDef_SelectedObjectChanged);
            NoEdge.CheckedChanged -= new TTControlEventDelegate(NoEdge_CheckedChanged);
            NoLength.CheckedChanged -= new TTControlEventDelegate(NoLength_CheckedChanged);
            NoBody.CheckedChanged -= new TTControlEventDelegate(NoBody_CheckedChanged);
            FixedAssetDetailMarkDefFixedAssetDetailModelDef.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailMarkDefFixedAssetDetailModelDef_SelectedObjectChanged);
            FixedAssetDetailMarkDef.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailMarkDef_SelectedObjectChanged);
            NoMark.CheckedChanged -= new TTControlEventDelegate(NoMark_CheckedChanged);
            NoModel.CheckedChanged -= new TTControlEventDelegate(NoModel_CheckedChanged);
            BodyEdgeLengt.CheckedChanged -= new TTControlEventDelegate(BodyEdgeLengt_CheckedChanged);
            MarkModelReason.CheckedChanged -= new TTControlEventDelegate(MarkModelReason_CheckedChanged);
            FixedAssetDetailMainClassDef.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDetailMainClassDef_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void FixedAssetDetailEdgeDefFixedAssetDetailLengthDef_SelectedObjectChanged()
        {
#region MarkModelRequestForm_FixedAssetDetailEdgeDefFixedAssetDetailLengthDef_SelectedObjectChanged
   if (this._MarkModelRequestAction.FixedAssetDetailLengthDef != null)
            {
                this._MarkModelRequestAction.Length = this._MarkModelRequestAction.FixedAssetDetailLengthDef.Length;
            }
#endregion MarkModelRequestForm_FixedAssetDetailEdgeDefFixedAssetDetailLengthDef_SelectedObjectChanged
        }

        private void FixedAssetDetailBodyDef_SelectedObjectChanged()
        {
#region MarkModelRequestForm_FixedAssetDetailBodyDef_SelectedObjectChanged
   if (this._MarkModelRequestAction.FixedAssetDetailBodyDef != null)
            {
                this._MarkModelRequestAction.FixedAssetDetailEdgeDef = null;
                //FixedAssetDetailEdgeDef.ListFilterExpression = "FIXEDASSETDETAILBODYDEF = " + ConnectionManager.GuidToString((this._MarkModelRequestAction.FixedAssetDetailBodyDef.ObjectID));
                this.BodyName.ReadOnly = true;
                this._MarkModelRequestAction.BodyName = this._MarkModelRequestAction.FixedAssetDetailBodyDef.BodyName;
                
                
                this._MarkModelRequestAction.FixedAssetDetailLengthDef = null;
            }
#endregion MarkModelRequestForm_FixedAssetDetailBodyDef_SelectedObjectChanged
        }

        private void FixedAssetDetailEdgeDef_SelectedObjectChanged()
        {
#region MarkModelRequestForm_FixedAssetDetailEdgeDef_SelectedObjectChanged
   if (this._MarkModelRequestAction.FixedAssetDetailEdgeDef != null)
            {
                this.EdgeName.ReadOnly = true;
                this._MarkModelRequestAction.EdgeName = this._MarkModelRequestAction.FixedAssetDetailEdgeDef.EdgeName;
                
                //FixedAssetDetailLengthDef.ListFilterExpression = "FIXEDASSETDETAILEDGEDEF = " + ConnectionManager.GuidToString((this._MarkModelRequestAction.FixedAssetDetailEdgeDef.ObjectID));
                this._MarkModelRequestAction.FixedAssetDetailLengthDef = null;
            }
#endregion MarkModelRequestForm_FixedAssetDetailEdgeDef_SelectedObjectChanged
        }

        private void NoEdge_CheckedChanged()
        {
#region MarkModelRequestForm_NoEdge_CheckedChanged
   if(this._MarkModelRequestAction.NoBody == null){this._MarkModelRequestAction.NoBody = false;}
            
            if (this._MarkModelRequestAction.NoBody.Value == true)
            {
                this._MarkModelRequestAction.NoEdge = true;
            }
            
            
            if(this._MarkModelRequestAction.NoEdge != null)
            {
                if (this._MarkModelRequestAction.NoEdge.Value == true)
                {
                    this.FixedAssetDetailEdgeDef.ReadOnly = true;
                    this.FixedAssetDetailEdgeDef.Required = false;
                    this._MarkModelRequestAction.FixedAssetDetailEdgeDef = null;
                    this.EdgeName.Required = true;
                    this.EdgeName.ReadOnly = false;
                    
                    
                    
                    //UZUNLUK
                    this._MarkModelRequestAction.NoLength = true;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.ReadOnly = true;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = false;
                    this._MarkModelRequestAction.FixedAssetDetailLengthDef = null;
                    this.Length.Required = true;
                    this.Length.ReadOnly = false;
                    
                }
                else
                {
                    this.FixedAssetDetailEdgeDef.Required = true;
                    this.FixedAssetDetailEdgeDef.ReadOnly = false;
                    this.EdgeName.Required = false;
                    this.EdgeName.ReadOnly = true;
                    
                    //UZUNLUK
                    this._MarkModelRequestAction.NoLength = false;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.ReadOnly = false;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = true;
                    this._MarkModelRequestAction.FixedAssetDetailLengthDef = null;
                    this.Length.Required = false;
                    this.Length.ReadOnly = true;
                }
            }
#endregion MarkModelRequestForm_NoEdge_CheckedChanged
        }

        private void NoLength_CheckedChanged()
        {
#region MarkModelRequestForm_NoLength_CheckedChanged
   if(this._MarkModelRequestAction.NoEdge == null){this._MarkModelRequestAction.NoEdge = false;}
            if(this._MarkModelRequestAction.NoBody == null){this._MarkModelRequestAction.NoBody = false;}
            
            if (this._MarkModelRequestAction.NoEdge.Value == true || this._MarkModelRequestAction.NoBody.Value == true)
            {
                this._MarkModelRequestAction.NoLength = true;
            }
            
            
            if(this._MarkModelRequestAction.NoLength != null)
            {
                if (this._MarkModelRequestAction.NoLength.Value == true)
                {
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.ReadOnly = true;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = false;
                    this._MarkModelRequestAction.FixedAssetDetailLengthDef = null;
                    this.Length.Required = true;
                    this.Length.ReadOnly = false;
                }
                else
                {
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.ReadOnly = false;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = true;
                    this.Length.Required = false;
                    this.Length.ReadOnly = true;
                }
            }
#endregion MarkModelRequestForm_NoLength_CheckedChanged
        }

        private void NoBody_CheckedChanged()
        {
#region MarkModelRequestForm_NoBody_CheckedChanged
   if(this._MarkModelRequestAction.NoBody != null)
            {
                if (this._MarkModelRequestAction.NoBody.Value == true)
                {
                    this.FixedAssetDetailBodyDef.ReadOnly = true;
                    this.FixedAssetDetailBodyDef.Required = false;
                    this._MarkModelRequestAction.FixedAssetDetailBodyDef = null;
                    this.BodyName.Required = true;
                    this.BodyName.ReadOnly = false;
                    
                    //UÇYAPISI
                    this._MarkModelRequestAction.NoEdge = true;
                    this.FixedAssetDetailEdgeDef.ReadOnly = true;
                    this.FixedAssetDetailEdgeDef.Required = false;
                    this._MarkModelRequestAction.FixedAssetDetailEdgeDef = null;
                    this.EdgeName.Required = true;
                    this.EdgeName.ReadOnly = false;
                    
                    //UZUNLUK
                    this._MarkModelRequestAction.NoLength = true;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.ReadOnly = true;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = false;
                    this._MarkModelRequestAction.FixedAssetDetailLengthDef = null;
                    this.Length.Required = true;
                    this.Length.ReadOnly = false;
                    
                    
                    
                }
                else
                {
                    this.FixedAssetDetailBodyDef.ReadOnly = false;
                    this.BodyName.Required = false;
                    this.BodyName.ReadOnly = true;
                    
                    
                    //UÇYAPISI
                    this._MarkModelRequestAction.NoEdge = false;
                    this.FixedAssetDetailEdgeDef.ReadOnly = false;
                    this.FixedAssetDetailEdgeDef.Required = true;
                    this._MarkModelRequestAction.FixedAssetDetailEdgeDef = null;
                    this.EdgeName.Required = false;
                    this.EdgeName.ReadOnly = true;
                    
                    //UZUNLUK
                    this._MarkModelRequestAction.NoLength = false;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.ReadOnly = false;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = true;
                    this._MarkModelRequestAction.FixedAssetDetailLengthDef = null;
                    this.Length.Required = false;
                    this.Length.ReadOnly = true;
                    
                    
                    
                }
            }
#endregion MarkModelRequestForm_NoBody_CheckedChanged
        }

        private void FixedAssetDetailMarkDefFixedAssetDetailModelDef_SelectedObjectChanged()
        {
#region MarkModelRequestForm_FixedAssetDetailMarkDefFixedAssetDetailModelDef_SelectedObjectChanged
   if (this._MarkModelRequestAction.FixedAssetDetailModelDef != null)
            {
                this._MarkModelRequestAction.ModelName = this._MarkModelRequestAction.FixedAssetDetailModelDef.ModelName;
            }
#endregion MarkModelRequestForm_FixedAssetDetailMarkDefFixedAssetDetailModelDef_SelectedObjectChanged
        }

        private void FixedAssetDetailMarkDef_SelectedObjectChanged()
        {
#region MarkModelRequestForm_FixedAssetDetailMarkDef_SelectedObjectChanged
   if (this._MarkModelRequestAction.FixedAssetDetailMarkDef != null)
            {
                this.MarkName.ReadOnly = true;
                this._MarkModelRequestAction.MarkName = this._MarkModelRequestAction.FixedAssetDetailMarkDef.MarkName;

     //FixedAssetDetailModelDef.ListFilterExpression =  "FIXEDASSETDETAILMARKDEF = " + ConnectionManager.GuidToString(this._MarkModelRequestAction.FixedAssetDetailMarkDef.ObjectID);
                 this._MarkModelRequestAction.FixedAssetDetailModelDef = null;
            }
#endregion MarkModelRequestForm_FixedAssetDetailMarkDef_SelectedObjectChanged
        }

        private void NoMark_CheckedChanged()
        {
#region MarkModelRequestForm_NoMark_CheckedChanged
   if(this._MarkModelRequestAction.NoMark != null)
            {
                if (this._MarkModelRequestAction.NoMark.Value == true)
                {
                    this.FixedAssetDetailMarkDef.ReadOnly = true;
                    this.FixedAssetDetailMarkDef.Required = false;
                    this._MarkModelRequestAction.FixedAssetDetailMarkDef = null;
                    this.MarkName.Required = true;
                    this.MarkName.ReadOnly = false;
                    
                    //MODEL
                    this._MarkModelRequestAction.NoModel = true;
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.ReadOnly = true;
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.Required = false;
                    this._MarkModelRequestAction.FixedAssetDetailModelDef = null;
                    this.ModelName.Required = true;
                    this.ModelName.ReadOnly = false;
                }
                else
                {
                    this.FixedAssetDetailMarkDef.Required = true;
                    this.FixedAssetDetailMarkDef.ReadOnly = false;
                    this.MarkName.Required = false;
                    this.MarkName.ReadOnly = true;
                    
                    //MODEL
                    this._MarkModelRequestAction.NoModel = false;
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.ReadOnly = false;
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.Required = true;
                    this._MarkModelRequestAction.FixedAssetDetailModelDef = null;
                    this.ModelName.Required = false;
                    this.ModelName.ReadOnly = true;
                    
                }
            }
#endregion MarkModelRequestForm_NoMark_CheckedChanged
        }

        private void NoModel_CheckedChanged()
        {
#region MarkModelRequestForm_NoModel_CheckedChanged
   if(this._MarkModelRequestAction.NoMark == null){this._MarkModelRequestAction.NoMark = false;}
            
            if (this._MarkModelRequestAction.NoMark.Value == true)
            {
                this._MarkModelRequestAction.NoModel = true;
            }
            
            
            if(this._MarkModelRequestAction.NoModel !=null)
            {
                if (this._MarkModelRequestAction.NoModel.Value == true)
                {
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.ReadOnly = true;
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.Required = false;
                    this._MarkModelRequestAction.FixedAssetDetailModelDef = null;
                    this.ModelName.Required = true;
                    this.ModelName.ReadOnly = false;
                }
                else
                {
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.Required = true;
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.ReadOnly = false;
                    this.ModelName.Required = false;
                    this.ModelName.ReadOnly = true;
                }
            }
#endregion MarkModelRequestForm_NoModel_CheckedChanged
        }

        private void BodyEdgeLengt_CheckedChanged()
        {
#region MarkModelRequestForm_BodyEdgeLengt_CheckedChanged
   controlCheck();
#endregion MarkModelRequestForm_BodyEdgeLengt_CheckedChanged
        }

        private void MarkModelReason_CheckedChanged()
        {
#region MarkModelRequestForm_MarkModelReason_CheckedChanged
   controlCheck();
#endregion MarkModelRequestForm_MarkModelReason_CheckedChanged
        }

        private void FixedAssetDetailMainClassDef_SelectedObjectChanged()
        {
#region MarkModelRequestForm_FixedAssetDetailMainClassDef_SelectedObjectChanged
   //if(this._MarkModelRequestAction.FixedAssetDetailMainClassDef != null)
               // FixedAssetDetailMarkDef.ListFilterExpression =  "FIXEDASSETDETAILMAINCLASS = " + ConnectionManager.GuidToString(this._MarkModelRequestAction.FixedAssetDetailMainClassDef.ObjectID);
            
            //if(this._MarkModelRequestAction.FixedAssetDetailMainClassDef != null)
            //    FixedAssetDetailBodyDef.ListFilterExpression =  "FIXEDASSETDETAILMAINCLASS = " + ConnectionManager.GuidToString(this._MarkModelRequestAction.FixedAssetDetailMainClassDef.ObjectID);
            
            this._MarkModelRequestAction.FixedAssetDetailMarkDef = null;
            this._MarkModelRequestAction.FixedAssetDetailModelDef = null;
            this._MarkModelRequestAction.FixedAssetDetailBodyDef = null;
            this._MarkModelRequestAction.FixedAssetDetailEdgeDef = null;
            this._MarkModelRequestAction.FixedAssetDetailLengthDef = null;
#endregion MarkModelRequestForm_FixedAssetDetailMainClassDef_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region MarkModelRequestForm_PreScript
    base.PreScript();
            
            
            
            if(this._MarkModelRequestAction.CurrentStateDefID == MarkModelRequestAction.States.Approval)
            {
                Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                if (Sites.SiteMerkezSagKom  != siteIDGuid)
                    throw new TTException("Bu işlem sadece Sağlık XXXXXX Merkez sahasında açılabilir");
            }

            
            if (this.NoMark.Value != true)
            {
                this.MarkName.ReadOnly = true;
                this.MarkName.Required = false;
                
                this.FixedAssetDetailMarkDef.ReadOnly = false;
                this.FixedAssetDetailMarkDef.Required = true;
            }
            else
            {
                this.FixedAssetDetailMarkDef.ReadOnly = true;
                this.FixedAssetDetailMarkDef.Required = false;
                this.MarkName.ReadOnly = false;
                this.MarkName.Required = true;
            }
            
            
            
            if (this.NoModel.Value  != true)
            {
                this.ModelName.ReadOnly = true;
                this.ModelName.Required = false;
                this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.ReadOnly = false;
                this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.Required = true;
            }
            else
            {
                this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.ReadOnly = true;
                this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.Required = false;
                this.ModelName.ReadOnly = false;
                this.ModelName.Required = true;
            }
            
            
            
            if (this.NoBody.Value  != true)
            {
                this.BodyName.ReadOnly = true;
                this.BodyName.Required = false;
                this.FixedAssetDetailBodyDef.ReadOnly = false;
                this.FixedAssetDetailBodyDef.Required = true;
            }
            else
            {
                this.FixedAssetDetailBodyDef.ReadOnly = true;
                this.FixedAssetDetailBodyDef.Required = false;
                this.BodyName.ReadOnly = false;
                this.BodyName.Required = true;
            }
            
            
            
            if (this.NoEdge.Value  != true)
            {
                this.EdgeName.ReadOnly = true;
                this.EdgeName.Required = false;
                this.FixedAssetDetailEdgeDef.ReadOnly = false;
                this.FixedAssetDetailEdgeDef.Required = true;
            }
            else
            {
                this.FixedAssetDetailEdgeDef.ReadOnly = true;
                this.FixedAssetDetailEdgeDef.Required = false;
                this.EdgeName.ReadOnly = false;
                this.EdgeName.Required = true;
            }
            
            
            
            if (this.NoLength.Value != true)
            {
                this.Length.ReadOnly = true;
                this.Length.Required = false;
                this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.ReadOnly = false;
                this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = true;
            }
            else
            {
                this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.ReadOnly = true;
                this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = false;
                this.Length.ReadOnly = false;
                this.Length.Required = true;
            }
            
            if(this._MarkModelRequestAction.CurrentStateDefID == MarkModelRequestAction.States.New)
                controlCheck();
#endregion MarkModelRequestForm_PreScript

            }
            
#region MarkModelRequestForm_Methods
        public void controlCheck()
        {
            //MARKAMODELISTEK
            if(this._MarkModelRequestAction.MarkModelReason != null)
            {
                if(this._MarkModelRequestAction.MarkModelReason.Value == true)
                {
                    this.MarkModelRequestBox.ReadOnly = false;
                    this.FixedAssetDetailBodyDef.Required = false;
                    this.FixedAssetDetailEdgeDef.Required = false;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = false;
                    this.BodyName.Required = false;
                    this.EdgeName.Required = false;
                    this.Length.Required = false;
                    
                    if(this._MarkModelRequestAction.CurrentStateDefID == MarkModelRequestAction.States.New)
                    {
                        this._MarkModelRequestAction.FixedAssetDetailBodyDef = null;
                        this._MarkModelRequestAction.FixedAssetDetailEdgeDef = null;
                        this._MarkModelRequestAction.FixedAssetDetailLengthDef = null;
                        
                        this._MarkModelRequestAction.BodyName = null;
                        this._MarkModelRequestAction.EdgeName = null;
                        this._MarkModelRequestAction.Length = null;
                    }
                    
                }
                else
                {
                    this.MarkModelRequestBox.ReadOnly = true;
                    this.FixedAssetDetailBodyDef.Required = true;
                    this.FixedAssetDetailEdgeDef.Required = true;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = true;
                    
                    this._MarkModelRequestAction.NoModel = false;
                    this._MarkModelRequestAction.NoMark = false;
                }
            }
            else
            {
                this.MarkModelRequestBox.ReadOnly = true;
            }
            
            
            //GÖVDEUÇUZUNLUKİSTEK
            if(this._MarkModelRequestAction.BodyEdgeLengt != null)
            {
                if(this._MarkModelRequestAction.BodyEdgeLengt.Value == true)
                {
                    this.BodyEdgeLengthRequestBox.ReadOnly = false;
                    this.FixedAssetDetailMarkDef.Required= false;
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.Required = false;
                    this.MarkName.Required = false;
                    this.ModelName.Required = false;
                    
                    if(this._MarkModelRequestAction.CurrentStateDefID == MarkModelRequestAction.States.New)
                    {
                        this._MarkModelRequestAction.FixedAssetDetailMarkDef = null;
                        this._MarkModelRequestAction.FixedAssetDetailModelDef = null;
                        
                        this._MarkModelRequestAction.MarkName = null;
                        this._MarkModelRequestAction.ModelName = null;
                    }
                    
                }
                else
                {
                    this.BodyEdgeLengthRequestBox.ReadOnly = true;
                    this.FixedAssetDetailMarkDef.Required= true;
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.Required = true;
                    
                    this._MarkModelRequestAction.NoLength = false;
                    this._MarkModelRequestAction.NoEdge = false;
                    this._MarkModelRequestAction.NoBody = false;
                }
            }
            else
            {
                this.BodyEdgeLengthRequestBox.ReadOnly = true;
            }
            
            //EĞERİKİSİNİDEİSTİYORLARSA
            if(this._MarkModelRequestAction.MarkModelReason != null && this._MarkModelRequestAction.BodyEdgeLengt != null)
            {
                if(this._MarkModelRequestAction.MarkModelReason.Value == true && this._MarkModelRequestAction.BodyEdgeLengt.Value == true)
                {
                    this.MarkModelRequestBox.ReadOnly = false;
                    this.BodyEdgeLengthRequestBox.ReadOnly = false;
                    this.FixedAssetDetailBodyDef.Required = true;
                    this.FixedAssetDetailEdgeDef.Required = true;
                    this.FixedAssetDetailEdgeDefFixedAssetDetailLengthDef.Required = true;
                    this.FixedAssetDetailMarkDef.Required= true;
                    this.FixedAssetDetailMarkDefFixedAssetDetailModelDef.Required = true;
                    
                    this._MarkModelRequestAction.NoModel = false;
                    this._MarkModelRequestAction.NoMark = false;
                    this._MarkModelRequestAction.NoLength = false;
                    this._MarkModelRequestAction.NoEdge = false;
                    this._MarkModelRequestAction.NoBody = false;
                    
                    
                }
                
            }
            
        }
        
#endregion MarkModelRequestForm_Methods
    }
}