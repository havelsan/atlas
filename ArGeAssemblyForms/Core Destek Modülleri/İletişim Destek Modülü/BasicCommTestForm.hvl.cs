
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
    /// Basic Comm Test Form
    /// </summary>
    public partial class BasicCommTestForm : TTUnboundForm
    {
        protected ITTTextBox result3;
        protected ITTTextBox result2;
        protected ITTTextBox result1;
        protected ITTTextBox field2;
        protected ITTTextBox field1;
        protected ITTButton ttbutton3;
        protected ITTButton ttbutton2;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            result3 = (ITTTextBox)AddControl(new Guid("633bbed6-1464-4649-b8df-6771fd99fbb8"));
            result2 = (ITTTextBox)AddControl(new Guid("3134a1b6-878c-4437-b8a5-a80553e12f91"));
            result1 = (ITTTextBox)AddControl(new Guid("363b6719-9f6b-4209-8f69-b18dd9dbc696"));
            field2 = (ITTTextBox)AddControl(new Guid("43261ec6-47bb-496c-b5ca-3b42afd743b5"));
            field1 = (ITTTextBox)AddControl(new Guid("dcf8e506-bfbe-4a2c-b39f-db8a03f828f3"));
            ttbutton3 = (ITTButton)AddControl(new Guid("81adcbb9-474b-4506-a921-ddd0e44284fa"));
            ttbutton2 = (ITTButton)AddControl(new Guid("54d977f9-198f-465a-bd5e-bf178c3b1567"));
            ttbutton1 = (ITTButton)AddControl(new Guid("f1b6615f-bc02-4aec-97e9-b88479100d02"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("076aab0f-6e68-42bd-92e7-0da47e3f8198"));
            base.InitializeControls();
        }

        public BasicCommTestForm() : base("BasicCommTestForm")
        {
        }

        protected BasicCommTestForm(string formDefName) : base(formDefName)
        {
        }
    }
}