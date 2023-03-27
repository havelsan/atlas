
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
        protected TTObjectClasses.OLAPMenu _OLAPMenu
        {
            get { return (TTObjectClasses.OLAPMenu)_ttObject; }
        }

        protected ITTCheckBox chActive;
        protected ITTGroupBox MenuRoleGroup;
        protected ITTButton btnRemoveRole;
        protected ITTGrid OLAPMenuRoles;
        protected ITTTextBoxColumn RoleNameOLAPMenuRole;
        protected ITTCheckBoxColumn IsActive;
        protected ITTButton btnAddRole;
        protected ITTLabel labelParentMenu;
        protected ITTObjectListBox ParentMenu;
        protected ITTLabel labelOrderNO;
        protected ITTTextBox OrderNO;
        protected ITTTextBox textBoxMenuNO;
        protected ITTTextBox Caption;
        protected ITTLabel labelMenuNO;
        protected ITTLabel labelCaption;
        override protected void InitializeControls()
        {
            chActive = (ITTCheckBox)AddControl(new Guid("a51a921e-84bd-4841-b70a-1d922105ec26"));
            MenuRoleGroup = (ITTGroupBox)AddControl(new Guid("8e7436dd-8cc6-4462-811f-b0f5574556a6"));
            btnRemoveRole = (ITTButton)AddControl(new Guid("710bf721-ee67-457d-a259-92d808b21fff"));
            OLAPMenuRoles = (ITTGrid)AddControl(new Guid("37ed7c75-8369-45d3-bb15-d7ca0b46f070"));
            RoleNameOLAPMenuRole = (ITTTextBoxColumn)AddControl(new Guid("18b127ea-2208-4cdb-9bac-ac9bc4032727"));
            IsActive = (ITTCheckBoxColumn)AddControl(new Guid("a9cc6650-1a02-4f3a-a068-65ee5a7b99dd"));
            btnAddRole = (ITTButton)AddControl(new Guid("ec0000b7-a314-45d6-b842-cc4aa44a1d61"));
            labelParentMenu = (ITTLabel)AddControl(new Guid("bdafeb00-bef1-45c5-aa1d-4c3256eef590"));
            ParentMenu = (ITTObjectListBox)AddControl(new Guid("de667927-5da2-4f92-b1bf-1d3eb2450aa1"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("9bdddbfe-fdbc-477d-82f1-550f8d4d1482"));
            OrderNO = (ITTTextBox)AddControl(new Guid("c6262be3-2988-4472-ada5-d0a262cba429"));
            textBoxMenuNO = (ITTTextBox)AddControl(new Guid("2b366ab0-e96b-4386-a3a1-3a0e87743ac3"));
            Caption = (ITTTextBox)AddControl(new Guid("8c172af1-da4e-40f1-84a3-391f9072a3bb"));
            labelMenuNO = (ITTLabel)AddControl(new Guid("e6d7415f-d25c-4b2c-a4c3-e7befba341c7"));
            labelCaption = (ITTLabel)AddControl(new Guid("c347dea6-16f0-4b9a-ae8b-17ddc006c257"));
            base.InitializeControls();
        }

        public OLAPMenuForm() : base("OLAPMENU", "OLAPMenuForm")
        {
        }

        protected OLAPMenuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}