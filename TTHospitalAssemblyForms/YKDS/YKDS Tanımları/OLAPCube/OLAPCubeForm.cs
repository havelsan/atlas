
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
    public partial class OLAPCubeForm : OLAPBaseActionForm
    {
        override protected void BindControlEvents()
        {
            btnAddRole.Click += new TTControlEventDelegate(btnAddRole_Click);
            btnRemoveRole.Click += new TTControlEventDelegate(btnRemoveRole_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnAddRole.Click -= new TTControlEventDelegate(btnAddRole_Click);
            btnRemoveRole.Click -= new TTControlEventDelegate(btnRemoveRole_Click);
            base.UnBindControlEvents();
        }

        private void btnAddRole_Click()
        {
#region OLAPCubeForm_btnAddRole_Click
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
                    foreach(OLAPCubeRole value in this._OLAPCube.OLAPCubeRoles)
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
                        OLAPCubeRole olapCubeRole = this._OLAPCube.OLAPCubeRoles.AddNew();
                        olapCubeRole.RoleID = roleID;
                    }
                }
            }
#endregion OLAPCubeForm_btnAddRole_Click
        }

        private void btnRemoveRole_Click()
        {
#region OLAPCubeForm_btnRemoveRole_Click
   TTObjectContext context = new TTObjectContext(false);

            List<int> selectedRows = new List<int>();
            for (int i = 0; i < this.OLAPCubeRoles.Rows.Count; i++)
                if (OLAPCubeRoles.Rows[i].Selected)
                    selectedRows.Add(i);

            if (selectedRows.Count != 0)
            {
                foreach (BaseOLAPRole role in _OLAPCube.OLAPRoles)
                {
                    BaseOLAPRole _baseRole = (BaseOLAPRole)context.GetObject(role.ObjectID, role.ObjectDef);
                    foreach (int roleID in selectedRows)
                    {
                        if (role.RoleName == OLAPCubeRoles.Rows[roleID].Cells[0].Value.ToString())
                        {
                            _baseRole.IsActive = false;
                            context.Save();
                        }
                    }
                }
            }
#endregion OLAPCubeForm_btnRemoveRole_Click
        }

        protected override void PreScript()
        {
#region OLAPCubeForm_PreScript
    base.PreScript();
            if(this._OLAPCube.CubeNO.Value.HasValue)
                this.textBoxCubeNo.Text="CB_"+this._OLAPCube.CubeNO.Value.ToString();
            else
                this.textBoxCubeNo.Text="";
#endregion OLAPCubeForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OLAPCubeForm_PostScript
    base.PostScript(transDef);
            if (((ITTObject)this.__ttObject).IsNew)
                this._OLAPCube.CubeNO.GetNextValue();
#endregion OLAPCubeForm_PostScript

            }
                }
}