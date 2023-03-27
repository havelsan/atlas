
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
    public partial class OLAPQueryForm : OLAPBaseActionForm
    {
        override protected void BindControlEvents()
        {
            btnAddRole.Click += new TTControlEventDelegate(btnAddRole_Click);
            btnRemoveRole.Click += new TTControlEventDelegate(btnRemoveRole_Click);
            btnAddQuery.Click += new TTControlEventDelegate(btnAddQuery_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnAddRole.Click -= new TTControlEventDelegate(btnAddRole_Click);
            btnRemoveRole.Click -= new TTControlEventDelegate(btnRemoveRole_Click);
            btnAddQuery.Click -= new TTControlEventDelegate(btnAddQuery_Click);
            base.UnBindControlEvents();
        }

        private void btnAddRole_Click()
        {
#region OLAPQueryForm_btnAddRole_Click
   TTObjectContext context = new TTObjectContext(false);
            MultiSelectForm multiSelectForm = new MultiSelectForm();

            foreach (TTRole role in TTObjectDefManager.Instance.Roles)
                if (role.Subtype == RoleSubTypeEnum.User)
                    multiSelectForm.AddMSItem(role.Name + (role.Members.Count > 0 ? " -->" : ""), role.ID.ToString(), role);

            multiSelectForm.GetMSItem(this, "Rol Seçiniz...", false, true, true, false, "Seç", "Vazgeç", string.Empty, true, false);

            List<Guid> selectedRoles;
            if (multiSelectForm.MSSelectedItems.Count == 0)
                selectedRoles = null;
            else
            {
                selectedRoles = new List<Guid>();
                foreach (KeyValuePair<string, string> keyValuePair in multiSelectForm.MSSelectedItems)
                    if (Globals.IsGuid(keyValuePair.Key))
                        selectedRoles.Add(new Guid(keyValuePair.Key));
            }

            if (selectedRoles != null)
            {
                foreach (Guid roleID in selectedRoles)
                {
                    bool isAdded = false;
                    BaseOLAPRole _baseRole;
                    foreach(OLAPQueryRole value in this._OLAPQuery.OLAPQueryRoles)
                    {
                        if(value.RoleID ==roleID)
                        {
                            _baseRole = (BaseOLAPRole)context.GetObject(value.ObjectID, value.ObjectDef);
                            isAdded = true;
                            _baseRole.IsActive = true;
                            context.Save();
                            break;
                        }
                    
                    }  
                    if (!isAdded)
                    {
                        OLAPQueryRole olapQueryRole = this._OLAPQuery.OLAPQueryRoles.AddNew();
                        olapQueryRole.RoleID = roleID;
                    }
                }
            }
#endregion OLAPQueryForm_btnAddRole_Click
        }

        private void btnRemoveRole_Click()
        {
#region OLAPQueryForm_btnRemoveRole_Click
   TTObjectContext context = new TTObjectContext(false);

            List<int> selectedRows = new List<int>();
            for (int i = 0; i < OLAPQueryRoles.Rows.Count; i++)
                if (OLAPQueryRoles.Rows[i].Selected)
                    selectedRows.Add(i);

            if (selectedRows.Count != 0)
            {
                foreach (BaseOLAPRole role in _OLAPQuery.OLAPRoles)
                {
                    BaseOLAPRole _baseRole = (BaseOLAPRole)context.GetObject(role.ObjectID, role.ObjectDef);
                    foreach (int roleID in selectedRows)
                    {
                        if (role.RoleName == OLAPQueryRoles.Rows[roleID].Cells[0].Value.ToString())
                        {
                            _baseRole.IsActive = false;
                            context.Save();
                        }
                    }
                }
            }
#endregion OLAPQueryForm_btnRemoveRole_Click
        }

        private void btnAddQuery_Click()
        {
#region OLAPQueryForm_btnAddQuery_Click
   string executeURL = TTObjectClasses.SystemParameter.GetParameterValue("YKDSSERVERIP", "http://localhost/default.aspx") + "?";
           executeURL += "UToken=" + System.Net.WebUtility.UrlEncode(Globals.EncyrptedUserName);
          executeURL += "&PToken=" + System.Net.WebUtility.UrlEncode(Globals.EncyrptedPassword);
           executeURL += "&PageType=2&ObjectId=" + System.Net.WebUtility.UrlEncode(this._OLAPQuery.ObjectID.ToString());
                       System.Diagnostics.Process.Start(executeURL);
#endregion OLAPQueryForm_btnAddQuery_Click
        }

        protected override void PreScript()
        {
#region OLAPQueryForm_PreScript
    base.PreScript();

            //if(base.IsEditor.HasValue&& base.IsEditor.Value==true)
            if(TTUser.CurrentUser.IsSuperUser)
            {
                if (((ITTObject)this.__ttObject).IsNew)
                this.btnAddQuery.Visible = false;
                
                if (!(((ITTObject)this.__ttObject).IsNew))
                this.btnAddQuery.Visible = true;
            }
            else                
                this.btnAddQuery.Visible = false;
            
            if (this._OLAPQuery.QueryNO.Value.HasValue)
                this.textboxQueryNO.Text = "QU_" + this._OLAPQuery.QueryNO.Value.ToString();
            else
                this.textboxQueryNO.Text = "";

            if (this._OLAPQuery.Query == null)
                btnAddQuery.Text = "Sorgu Ekle";
            else
                btnAddQuery.Text = "Sorgu Düzenle";
#endregion OLAPQueryForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OLAPQueryForm_PostScript
    base.PostScript(transDef);
            if (((ITTObject)this.__ttObject).IsNew)
                this._OLAPQuery.QueryNO.GetNextValue();
#endregion OLAPQueryForm_PostScript

            }
                }
}