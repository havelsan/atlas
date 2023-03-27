
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
    /// Olap Menü Tanımları
    /// </summary>
    public partial class OLAPMenuForm : BaseOLAPDefinitionForm
    {
        override protected void BindControlEvents()
        {
            btnRemoveRole.Click += new TTControlEventDelegate(btnRemoveRole_Click);
            btnAddRole.Click += new TTControlEventDelegate(btnAddRole_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnRemoveRole.Click -= new TTControlEventDelegate(btnRemoveRole_Click);
            btnAddRole.Click -= new TTControlEventDelegate(btnAddRole_Click);
            base.UnBindControlEvents();
        }

        private void btnRemoveRole_Click()
        {
#region OLAPMenuForm_btnRemoveRole_Click
   TTObjectContext context = new TTObjectContext(false);

            List<int> selectedRows = new List<int>();
            for (int i = 0; i < OLAPMenuRoles.Rows.Count; i++)
                if (OLAPMenuRoles.Rows[i].Selected)
                    selectedRows.Add(i);

            if (selectedRows.Count != 0)
            {
                foreach (BaseOLAPRole role in _OLAPMenu.OLAPRoles)
                {
                    BaseOLAPRole _baseRole = (BaseOLAPRole)context.GetObject(role.ObjectID, role.ObjectDef);
                    foreach (int roleID in selectedRows)
                    {
                        if (role.RoleName == OLAPMenuRoles.Rows[roleID].Cells[0].Value.ToString())
                        {
                            _baseRole.IsActive = false;
                            context.Save();
                        }
                    }
                }
            }
#endregion OLAPMenuForm_btnRemoveRole_Click
        }

        private void btnAddRole_Click()
        {
#region OLAPMenuForm_btnAddRole_Click
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
                    foreach (OLAPMenuRole value in this._OLAPMenu.OLAPMenuRoles)
                    {
                        if (value.RoleID == roleID)
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
                        OLAPMenuRole olapMenuRole = this._OLAPMenu.OLAPMenuRoles.AddNew();
                        olapMenuRole.RoleID = roleID;
                    }
                }
            }
#endregion OLAPMenuForm_btnAddRole_Click
        }

        protected override void PreScript()
        {
#region OLAPMenuForm_PreScript
    base.PreScript();
            if (this._OLAPMenu.MenuNO.Value.HasValue)
                this.textBoxMenuNO.Text = "MD_" + this._OLAPMenu.MenuNO.Value.ToString();
            else
                this.textBoxMenuNO.Text = "";
            TTObjectContext context = new TTObjectContext(false);
#endregion OLAPMenuForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OLAPMenuForm_PostScript
    base.PostScript(transDef);
            if (((ITTObject)this.__ttObject).IsNew)
                this._OLAPMenu.MenuNO.GetNextValue();
#endregion OLAPMenuForm_PostScript

            }
                }
}