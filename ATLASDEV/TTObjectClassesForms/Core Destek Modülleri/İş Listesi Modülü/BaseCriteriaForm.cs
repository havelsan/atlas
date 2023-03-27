
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
    /// Kriterler
    /// </summary>
    public partial class BaseCriteriaForm : TTUnboundForm
    {
#region BaseCriteriaForm_Methods
        protected TTObjectContext m_context;
        public TTObjectContext ObjectContext
        {
            get{ return this.m_context; }
            set{ this.m_context = value; }
        }
        
        protected WorkListDefinition m_ownerDefinition;
        public WorkListDefinition OwnerDefinition
        {
            get{ return this.m_ownerDefinition; }
            set{ this.m_ownerDefinition = value; }
        }
        
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);

            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.White, Color.White, 45, true);
            e.Graphics.FillRectangle(brush, 0, 0, Width, Height);
            brush.Dispose();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            //            if(this.Size.Width > 325)
            //                this.Size = new Size(324, this.Size.Height);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            //this.TopLevel =false;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.BackColor = System.Drawing.Color.White;
            this.statusBar.Visible = false;
        }
        
        protected CriteriaValue GetCriteriaValue(string crName)
        {
            CriteriaValue retValue = null;
            CriteriaDefinition pDef = this.GetCriteriaDefinition(crName);
            if(pDef != null)
            {
                //NE pDef.CriteriaValues ile tüm kullanıcılarınkriterlerinin çekip içinde dönüyordu.
                //Sistem yavaşlığı yapıyordu o yüzden o kod kapatılarak yenisi yazıldı.
                if(Common.CurrentResource != null && this.m_ownerDefinition.LastSpecialPanel != null)
                {
                    IList criteriaValueList = new List<CriteriaValue>();
                    criteriaValueList = CriteriaValue.GetCriteriaValuesBySpecialPanelAndUser(this.m_context,this.m_ownerDefinition.LastSpecialPanel.ObjectID.ToString(), Common.CurrentResource.ObjectID.ToString(), pDef.ObjectID.ToString());
                        
                    foreach(CriteriaValue crVal in criteriaValueList)
                    {
                        if(crVal.SpecialPanel != null )
                        {
                            retValue = crVal;
                            break;
                        }
                    }
                    
                    
//                    foreach(CriteriaValue crVal in pDef.CriteriaValues)
//                    {
//                        if(crVal.SpecialPanel != null && Common.CurrentResource != null && this.m_ownerDefinition.LastSpecialPanel != null)
//                        {
//                            if(crVal.User!=null)
//                            {
//                                if(Common.CurrentResource.ObjectID.Equals(crVal.User.ObjectID) && crVal.SpecialPanel.ObjectID.Equals(this.m_ownerDefinition.LastSpecialPanel.ObjectID))
//                                {
//                                    retValue = crVal;
//                                    break;
//                                }
//                            }
//                        }
//                    }
                }
            }
            
            return retValue;
        }
        
        protected CriteriaDefinition GetCriteriaDefinition(string crName)
        {
            CriteriaDefinition retValue = null;
            foreach(CriteriaDefinition pDef in this.m_ownerDefinition.Criterion)
            {
                if(pDef.Name == crName)
                {
                    retValue = pDef;
                    break;
                }
            }
            
            return retValue;
        }
        
        protected CriteriaDefinition CreateCriteriaDefinition(string crName, string sTypeName)
        {
            CriteriaDefinition newDef = new CriteriaDefinition(this.m_context);
            newDef.Criteria = this.m_ownerDefinition;
            newDef.Name = crName;
            newDef.CriteriaType = sTypeName;
            
            return newDef;
        }
        
        protected CriteriaDefinition CreateCriteriaDefinition(string crName, string sTypeName, string sDefaultValue)
        {
            CriteriaDefinition newDef = new CriteriaDefinition(this.m_context);
            newDef.Criteria = this.m_ownerDefinition;
            newDef.Name = crName;
            newDef.CriteriaType = sTypeName;
            newDef.DefaultValue = sDefaultValue;
            
            return newDef;
        }
        
        protected void SaveCriteria(string name, string type, string value)
        {
            CriteriaValue crValM = this.GetCriteriaValue(name);
            if(crValM == null)
            {
                CriteriaValue newCrVal = new CriteriaValue(this.m_context);
                newCrVal.Value = value;
                newCrVal.User = Common.CurrentResource;
                newCrVal.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                newCrVal.PCriteriaValue = this.GetCriteriaDefinition(name);
                if(newCrVal.PCriteriaValue == null) newCrVal.PCriteriaValue = this.CreateCriteriaDefinition(name,type);
                newCrVal.PCriteriaValue.Criteria = this.m_ownerDefinition;
            }
            else
            {
                crValM.Value = value;
            }
        }
        
        protected void SaveCriteria(string name, string type, string value, string defValue)
        {
            CriteriaValue crValM = this.GetCriteriaValue(name);
            if(crValM == null)
            {
                CriteriaValue newCrVal = new CriteriaValue(this.m_context);
                newCrVal.Value = value;
                newCrVal.User = Common.CurrentResource;
                newCrVal.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                newCrVal.PCriteriaValue = this.GetCriteriaDefinition(name);
                if(newCrVal.PCriteriaValue == null) newCrVal.PCriteriaValue = this.CreateCriteriaDefinition(name,type, defValue);
                newCrVal.PCriteriaValue.Criteria = this.m_ownerDefinition;
            }
            else
            {
                crValM.Value = value;
            }
        }
        
        public virtual IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return null;
        }
        
        public virtual IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression, List<TTObjectStateDef> selectedStateDefs)
        {
            return ExecuteReportNQL(dtStart, dtEnd, sExpression);
        }
        
        public virtual IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return null;
        }
        
        public virtual IList ExecuteReportNQL(string sExpression)
        {
            return null;
        }
        
        public virtual void OnSave()
        {
        }
        
        public virtual void OnLoadCriteria()
        {
        }

        public virtual TTDefinitionManagement.StateStatusEnum? GetStateStatus()
        {
            return null;
        }
        
#endregion BaseCriteriaForm_Methods
    }
}