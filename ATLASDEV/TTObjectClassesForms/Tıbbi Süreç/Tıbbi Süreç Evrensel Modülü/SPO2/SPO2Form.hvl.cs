
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
    public partial class SPO2Form : TTForm
    {
        protected TTObjectClasses.SPO2 _SPO2
        {
            get { return (TTObjectClasses.SPO2)_ttObject; }
        }

        protected ITTLabel labelValue;
        protected ITTTextBox Value;
        override protected void InitializeControls()
        {
            labelValue = (ITTLabel)AddControl(new Guid("bb2f3011-af6e-4f55-8a96-5f9f899e9cc0"));
            Value = (ITTTextBox)AddControl(new Guid("f909bc10-67f4-47c7-8283-7aab9bdfd87f"));
            base.InitializeControls();
        }

        public SPO2Form() : base("SPO2", "SPO2Form")
        {
        }

        protected SPO2Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}