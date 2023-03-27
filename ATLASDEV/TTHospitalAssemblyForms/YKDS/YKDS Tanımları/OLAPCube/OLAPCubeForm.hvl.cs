
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
    public partial class OLAPCubeForm : OLAPBaseActionForm
    {
        protected TTObjectClasses.OLAPCube _OLAPCube
        {
            get { return (TTObjectClasses.OLAPCube)_ttObject; }
        }

        protected ITTCheckBox chActive;
        protected ITTGroupBox CubeRoleGroup;
        protected ITTGrid OLAPCubeRoles;
        protected ITTTextBoxColumn RoleNameOLAPCubeRole;
        protected ITTCheckBoxColumn IsActive;
        protected ITTButton btnAddRole;
        protected ITTButton btnRemoveRole;
        protected ITTTextBox textBoxCubeNo;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTTextBox Caption;
        protected ITTTextBox OrderNO;
        protected ITTLabel labelCubeNO;
        protected ITTLabel labelCaptionOLAPMenu;
        protected ITTLabel labelDescription;
        protected ITTLabel labelName;
        protected ITTLabel labelCaption;
        protected ITTLabel labelOrderNO;
        protected ITTObjectListBox OLAPMenu;
        override protected void InitializeControls()
        {
            chActive = (ITTCheckBox)AddControl(new Guid("b96291ff-9407-469b-af80-4f12fe6112e8"));
            CubeRoleGroup = (ITTGroupBox)AddControl(new Guid("5c0e0d6f-5a48-4c9a-93d7-b07358bb9cdc"));
            OLAPCubeRoles = (ITTGrid)AddControl(new Guid("afe83f99-9384-48a3-9730-ff096400720b"));
            RoleNameOLAPCubeRole = (ITTTextBoxColumn)AddControl(new Guid("85e80206-4ec2-4f63-b48a-b2d39e2ffe4b"));
            IsActive = (ITTCheckBoxColumn)AddControl(new Guid("43c74041-8314-476d-90b3-997c8b9d15cb"));
            btnAddRole = (ITTButton)AddControl(new Guid("7d88561a-3f95-4736-9b2e-de758bdd3cee"));
            btnRemoveRole = (ITTButton)AddControl(new Guid("83abfee7-d6fe-46ca-b9ee-b25b758575c8"));
            textBoxCubeNo = (ITTTextBox)AddControl(new Guid("b3665b75-b581-4ec5-91d2-4f890bca6204"));
            Description = (ITTTextBox)AddControl(new Guid("e7c5d3dd-cc32-4ae6-a721-b70cdc6375e3"));
            Name = (ITTTextBox)AddControl(new Guid("647a9b13-6abd-49fa-9315-2dc159d73187"));
            Caption = (ITTTextBox)AddControl(new Guid("e97f46e2-c316-4719-9ee2-6f0b7973943a"));
            OrderNO = (ITTTextBox)AddControl(new Guid("5f225a72-f12d-4545-9b24-071adec2a386"));
            labelCubeNO = (ITTLabel)AddControl(new Guid("d77ec423-1216-4bc6-a603-ed74c92f0adc"));
            labelCaptionOLAPMenu = (ITTLabel)AddControl(new Guid("6ecf0801-55ce-4c35-b343-0461bace8ccc"));
            labelDescription = (ITTLabel)AddControl(new Guid("fea04913-310b-4815-b009-766e58868390"));
            labelName = (ITTLabel)AddControl(new Guid("b4c18e16-3904-484f-9ed3-a0248c8ca71e"));
            labelCaption = (ITTLabel)AddControl(new Guid("c58179e5-a67d-400d-9d69-e1c17eb2a424"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("c3e1953d-1664-4e16-86d1-00566942ac2b"));
            OLAPMenu = (ITTObjectListBox)AddControl(new Guid("6674bab6-0a32-4dba-abfb-e7e33e6616d9"));
            base.InitializeControls();
        }

        public OLAPCubeForm() : base("OLAPCUBE", "OLAPCubeForm")
        {
        }

        protected OLAPCubeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}