
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
    public partial class ProcedureWorksAcceptNoticeWorkListForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region ProcedureWorksAcceptNoticeWorkListForm_Methods
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return ProcedureWorksAcceptNotice.WorkListNQL(context, dtStart, dtEnd, sExpression);
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
            //ID
            CriteriaValue crValID = this.GetCriteriaValue("ID");
            if(crValID == null)
            {
                CriteriaValue newCrValID = new CriteriaValue(this.m_context);
                newCrValID.Value = this.txtID.Text;
                newCrValID.User = Common.CurrentResource;
                newCrValID.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                newCrValID.PCriteriaValue = this.GetCriteriaDefinition("ID");
                newCrValID.PCriteriaValue.Criteria = this.m_ownerDefinition;
            }
            else
            {
                crValID.Value = this.txtID.Text;
            }
        }
        
#endregion ProcedureWorksAcceptNoticeWorkListForm_Methods
    }
}