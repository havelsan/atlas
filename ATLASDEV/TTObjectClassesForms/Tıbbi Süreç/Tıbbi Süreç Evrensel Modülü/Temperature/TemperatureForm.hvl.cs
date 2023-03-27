
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
    public partial class TemperatureForm : TTForm
    {
        protected TTObjectClasses.Temperature _Temperature
        {
            get { return (TTObjectClasses.Temperature)_ttObject; }
        }

        protected ITTLabel labelValue;
        protected ITTTextBox Value;
        override protected void InitializeControls()
        {
            labelValue = (ITTLabel)AddControl(new Guid("c27e0900-a3c1-41df-883f-463c126a0cca"));
            Value = (ITTTextBox)AddControl(new Guid("086fa2b9-a75a-44a1-9d77-e84b37a64de9"));
            base.InitializeControls();
        }

        public TemperatureForm() : base("TEMPERATURE", "TemperatureForm")
        {
        }

        protected TemperatureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}