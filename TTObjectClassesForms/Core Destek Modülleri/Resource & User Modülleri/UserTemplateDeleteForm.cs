
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
    /// Şablon İnceleme / Silme
    /// </summary>
    public partial class UserTemplateDeleteForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdCancel.Click += new TTControlEventDelegate(cmdCancel_Click);
            cmdTemplateDelete.Click += new TTControlEventDelegate(cmdTemplateDelete_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdCancel.Click -= new TTControlEventDelegate(cmdCancel_Click);
            cmdTemplateDelete.Click -= new TTControlEventDelegate(cmdTemplateDelete_Click);
            base.UnBindControlEvents();
        }

        private void cmdCancel_Click()
        {
#region UserTemplateDeleteForm_cmdCancel_Click
   this.Close();
#endregion UserTemplateDeleteForm_cmdCancel_Click
        }

        private void cmdTemplateDelete_Click()
        {
#region UserTemplateDeleteForm_cmdTemplateDelete_Click
   bool select = false;
            for (int i = 0; i < this.UserTemplateGrid.Rows.Count; i++)
            {
                if(Convert.ToBoolean(this.UserTemplateGrid.Rows[i].Cells["Select"].Value))
                {
                    select = true;
                    TTObjectContext context = new TTObjectContext(false);
                    UserTemplate deletedTempalete = (UserTemplate)context.GetObject(new Guid(this.UserTemplateGrid.Rows[i].Cells["UserTemplateObjectID"].Value.ToString()), typeof(UserTemplate));
                    ((ITTObject)deletedTempalete).Delete();
                    context.Save();
                    context.Dispose();
                }
            }
            if(select)
            {
                GetUserTemplate();
                InfoBox.Show("Seçtiğiniz şablon(lar) silinmiştir.",MessageIconEnum.InformationMessage);
            }
            else
                InfoBox.Show("Hiç şablon seçmediniz",MessageIconEnum.InformationMessage);
#endregion UserTemplateDeleteForm_cmdTemplateDelete_Click
        }

#region UserTemplateDeleteForm_Methods
        protected override void OnLoad(EventArgs e)
        {
            this.CenterToScreen();
            GetUserTemplate();

        }

        public void GetUserTemplate()
        {
            this.UserTemplateGrid.Rows.Clear();
            TTObjectContext context = new TTObjectContext(true);
            ResUser currentUser = ((ResUser)Common.CurrentUser.UserObject);
            IList userTemplates = context.QueryObjects("USERTEMPLATE", "RESUSER = " + ConnectionManager.GuidToString(currentUser.ObjectID));

            foreach (UserTemplate userTemplate in userTemplates)
            {
                ITTGridRow addedRow = this.UserTemplateGrid.Rows.Add();
                addedRow.Cells["Select"].Value = false;
                addedRow.Cells["Description"].Value = userTemplate.Description;
                addedRow.Cells["TemplateType"].Value = TTObjectDefManager.Instance.ObjectDefs[userTemplate.TAObjectDefID].Description;
                addedRow.Cells["UserTemplateObjectID"].Value = userTemplate.ObjectID.ToString();
            }

        }
        
#endregion UserTemplateDeleteForm_Methods
    }
}