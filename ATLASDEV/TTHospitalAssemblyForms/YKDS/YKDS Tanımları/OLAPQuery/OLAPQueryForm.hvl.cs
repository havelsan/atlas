
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
    public partial class OLAPQueryForm : OLAPBaseActionForm
    {
        protected TTObjectClasses.OLAPQuery _OLAPQuery
        {
            get { return (TTObjectClasses.OLAPQuery)_ttObject; }
        }

        protected ITTCheckBox chActive;
        protected ITTGroupBox QueryRoleGroup;
        protected ITTGrid OLAPQueryRoles;
        protected ITTTextBoxColumn RoleNameOLAPQueryRole;
        protected ITTCheckBoxColumn IsActive;
        protected ITTButton btnAddRole;
        protected ITTButton btnRemoveRole;
        protected ITTLabel labelQueryNO;
        protected ITTTextBox textboxQueryNO;
        protected ITTTextBox Description;
        protected ITTTextBox Caption;
        protected ITTTextBox OrderNo;
        protected ITTButton btnAddQuery;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCaption;
        protected ITTLabel labelOrderNo;
        protected ITTLabel labelOLAPCube;
        protected ITTObjectListBox OLAPCube;
        protected ITTObjectListBox OLAPMenu;
        protected ITTLabel labelCaptionOLAPMenu;
        override protected void InitializeControls()
        {
            chActive = (ITTCheckBox)AddControl(new Guid("dd12a376-5ab7-4ee0-bdd7-fd8775e6cee6"));
            QueryRoleGroup = (ITTGroupBox)AddControl(new Guid("d063fc6f-1fe2-4e83-bb90-8f047e413c9d"));
            OLAPQueryRoles = (ITTGrid)AddControl(new Guid("e5b8cc10-222d-4136-8afe-c597267e1a15"));
            RoleNameOLAPQueryRole = (ITTTextBoxColumn)AddControl(new Guid("e2b95e2b-bc0c-4748-b707-c5647cdd045d"));
            IsActive = (ITTCheckBoxColumn)AddControl(new Guid("4db98020-d8cf-46f8-8ccb-b6e2eaabbf7b"));
            btnAddRole = (ITTButton)AddControl(new Guid("fe57b214-c57e-483d-ab0f-d1f6bc3d6f8b"));
            btnRemoveRole = (ITTButton)AddControl(new Guid("07b7882f-60fe-404b-a2ae-13afd715a5de"));
            labelQueryNO = (ITTLabel)AddControl(new Guid("7ebe5c6f-853c-4d79-9ab0-610514b0ae3c"));
            textboxQueryNO = (ITTTextBox)AddControl(new Guid("1919da70-1054-4f18-96a1-85b48039f1ab"));
            Description = (ITTTextBox)AddControl(new Guid("0018ab2a-0b8a-478d-a6f2-df6c0ef91e91"));
            Caption = (ITTTextBox)AddControl(new Guid("16145d48-2132-49eb-926b-8525f230991c"));
            OrderNo = (ITTTextBox)AddControl(new Guid("bd91d880-49e5-4c43-8ebf-e321ac437c54"));
            btnAddQuery = (ITTButton)AddControl(new Guid("488bd850-c8ff-42aa-aeaa-78fbb46212e4"));
            labelDescription = (ITTLabel)AddControl(new Guid("96f55f43-1bf8-41b2-8a94-0130aee46d3c"));
            labelCaption = (ITTLabel)AddControl(new Guid("498d6002-b4f5-4dfc-a506-b669867347c5"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("615d9097-8575-49bd-8cc4-936e9b2be03b"));
            labelOLAPCube = (ITTLabel)AddControl(new Guid("53803ae5-9121-4534-9da3-52f9f1214c91"));
            OLAPCube = (ITTObjectListBox)AddControl(new Guid("89959e9d-f2e4-47f8-89a5-75fb9862471b"));
            OLAPMenu = (ITTObjectListBox)AddControl(new Guid("33d5f865-eb38-46f6-ab40-170170a8a55f"));
            labelCaptionOLAPMenu = (ITTLabel)AddControl(new Guid("382efa8b-1893-4b65-b815-50918f3e43f4"));
            base.InitializeControls();
        }

        public OLAPQueryForm() : base("OLAPQUERY", "OLAPQueryForm")
        {
        }

        protected OLAPQueryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}