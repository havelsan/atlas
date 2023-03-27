
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
    public partial class PurchaseProjectWorkListForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            txtProjectNo.TextChanged += new TTControlEventDelegate(txtProjectNo_TextChanged);
            txtConfirmNo.TextChanged += new TTControlEventDelegate(txtConfirmNo_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            txtProjectNo.TextChanged -= new TTControlEventDelegate(txtProjectNo_TextChanged);
            txtConfirmNo.TextChanged -= new TTControlEventDelegate(txtConfirmNo_TextChanged);
            base.UnBindControlEvents();
        }

        private void txtProjectNo_TextChanged()
        {
#region PurchaseProjectWorkListForm_txtProjectNo_TextChanged
   if(string.IsNullOrEmpty(txtProjectNo.Text))
                txtConfirmNo.Enabled = true;
            else
                txtConfirmNo.Enabled = false;
#endregion PurchaseProjectWorkListForm_txtProjectNo_TextChanged
        }

        private void txtConfirmNo_TextChanged()
        {
#region PurchaseProjectWorkListForm_txtConfirmNo_TextChanged
   if(string.IsNullOrEmpty(txtConfirmNo.Text))
                txtProjectNo.Enabled = true;
            else
                txtProjectNo.Enabled = false;
#endregion PurchaseProjectWorkListForm_txtConfirmNo_TextChanged
        }

#region PurchaseProjectWorkListForm_Methods
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return PurchaseProject.WorkListNQL(context, dtStart, dtEnd, sExpression);
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
            //PROJECTNO
            CriteriaValue crValID = this.GetCriteriaValue("PURCHASEPROJECTNO");
            if(crValID == null)
            {
                CriteriaValue newCrValID = new CriteriaValue(this.m_context);
                newCrValID.Value = this.txtProjectNo.Text;
                newCrValID.User = Common.CurrentResource;
                newCrValID.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                newCrValID.PCriteriaValue = this.GetCriteriaDefinition("PURCHASEPROJECTNO");
                newCrValID.PCriteriaValue.Criteria = this.m_ownerDefinition;
            }
            else
            {
                crValID.Value = this.txtProjectNo.Text;
            }
            
            //CONFIRMNO
            crValID = this.GetCriteriaValue("CONFIRMNO");
            if(crValID == null)
            {
                CriteriaValue newCrValID = new CriteriaValue(this.m_context);
                newCrValID.Value = this.txtConfirmNo.Text;
                newCrValID.User = Common.CurrentResource;
                newCrValID.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                newCrValID.PCriteriaValue = this.GetCriteriaDefinition("CONFIRMNO");
                newCrValID.PCriteriaValue.Criteria = this.m_ownerDefinition;
            }
            else
            {
                crValID.Value = this.txtConfirmNo.Text;
            }
        }
        
#endregion PurchaseProjectWorkListForm_Methods
    }
}