
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
    public partial class PurchaseOrderWorkListForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region PurchaseOrderWorkListForm_Methods
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return PurchaseOrder.WorkListNQL(context, dtStart, dtEnd, sExpression);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.LoadCriteria();
        }
        
        public override void OnSave()
        {
            this.SaveCriteria();
        }
        private void LoadCriteria()
        {
            
        }
        
        private void SaveCriteria()
        {
            //ORDERNO
            CriteriaValue crValID = this.GetCriteriaValue("ORDERNO");
            if(crValID == null)
            {
                CriteriaValue newCrValID = new CriteriaValue(this.m_context);
                newCrValID.Value = this.txtOrderNo.Text;
                newCrValID.User = Common.CurrentResource;
                newCrValID.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                newCrValID.PCriteriaValue = this.GetCriteriaDefinition("ORDERNO");
                newCrValID.PCriteriaValue.Criteria = this.m_ownerDefinition;
            }
            else
            {
                crValID.Value = this.txtOrderNo.Text;
            }
        }
        
#endregion PurchaseOrderWorkListForm_Methods
    }
}