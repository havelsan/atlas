
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
    public partial class BaseResDevDefForm : TTDefinitionForm
    {
        protected TTObjectClasses.BaseResDevDef _BaseResDevDef
        {
            get { return (TTObjectClasses.BaseResDevDef)_ttObject; }
        }

        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelCode = (ITTLabel)AddControl(new Guid("f240dd32-7b92-4b5d-9022-4d1d882a3a40"));
            Code = (ITTTextBox)AddControl(new Guid("3abbe399-4e6f-44a0-a0e5-65d9cb3810fd"));
            Name = (ITTTextBox)AddControl(new Guid("59824293-d43d-4da1-8ac8-2fac23b12919"));
            labelName = (ITTLabel)AddControl(new Guid("ba11e88c-f0d2-4882-9a15-fd0ba3dd4c94"));
            base.InitializeControls();
        }

        public BaseResDevDefForm() : base("BASERESDEVDEF", "BaseResDevDefForm")
        {
        }

        protected BaseResDevDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}