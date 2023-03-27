
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
    public partial class GILDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Girişimsel İşlem Listesi
    /// </summary>
        protected TTObjectClasses.GILDefinition _GILDefinition
        {
            get { return (TTObjectClasses.GILDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelSurgeryGroup;
        protected ITTTextBox SurgeryGroup;
        protected ITTTextBox Point;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelPoint;
        protected ITTLabel labelDescription;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("c9f4ac2a-c336-4682-b27b-1f7ed2f35433"));
            labelSurgeryGroup = (ITTLabel)AddControl(new Guid("448ee424-36c4-4fc0-a4ac-92387593ac33"));
            SurgeryGroup = (ITTTextBox)AddControl(new Guid("75a932ee-4b0e-4ee4-8ee4-97e4959d904a"));
            Point = (ITTTextBox)AddControl(new Guid("99ef7e96-0650-4205-9717-ed16c2c0f4d3"));
            Description = (ITTTextBox)AddControl(new Guid("ec78b40a-b476-4f95-a13d-ac526a0d0bcc"));
            Name = (ITTTextBox)AddControl(new Guid("c6c8042a-4478-40e0-8789-aa508dc73e36"));
            Code = (ITTTextBox)AddControl(new Guid("3c5cddd3-db55-49ea-83df-875d15db11c3"));
            labelPoint = (ITTLabel)AddControl(new Guid("45b3d8bf-0339-4447-9874-d387ee42f236"));
            labelDescription = (ITTLabel)AddControl(new Guid("6ee43770-5ec2-4e8c-b4db-0ebfcc82d040"));
            labelName = (ITTLabel)AddControl(new Guid("cab59bfa-bc5a-4b52-afbd-4bbb463b6bc0"));
            labelCode = (ITTLabel)AddControl(new Guid("ec5c73c3-a520-487a-b154-565070d6097d"));
            base.InitializeControls();
        }

        public GILDefinitionForm() : base("GILDEFINITION", "GILDefinitionForm")
        {
        }

        protected GILDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}