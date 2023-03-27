
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
    public partial class PulseForm : TTForm
    {
        protected TTObjectClasses.Pulse _Pulse
        {
            get { return (TTObjectClasses.Pulse)_ttObject; }
        }

        protected ITTLabel labelValue;
        protected ITTTextBox Value;
        override protected void InitializeControls()
        {
            labelValue = (ITTLabel)AddControl(new Guid("b63ddf9c-3681-4289-8072-973bfa32a0f6"));
            Value = (ITTTextBox)AddControl(new Guid("2078cd6e-77b4-4e22-b20e-89129b5dddad"));
            base.InitializeControls();
        }

        public PulseForm() : base("PULSE", "PulseForm")
        {
        }

        protected PulseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}