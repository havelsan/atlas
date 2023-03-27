
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
    public partial class SmartCardLoginForm : TTUnboundForm
    {
        protected ITTButton cmdCancel;
        protected ITTButton cmdPinOK;
        protected ITTComboBox cboCardList;
        protected ITTTextBox SmartCardPin;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            cmdCancel = (ITTButton)AddControl(new Guid("adc1e2fc-f7eb-4ab1-ab11-52a340d12407"));
            cmdPinOK = (ITTButton)AddControl(new Guid("67424da0-94f8-480e-ada5-67700f9b7a4f"));
            cboCardList = (ITTComboBox)AddControl(new Guid("f93986fa-1a35-44cf-8d51-b518b5c42932"));
            SmartCardPin = (ITTTextBox)AddControl(new Guid("c397c017-2a04-4d9f-8339-0a243da1832f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("42ea0d82-7f74-45fa-9b7f-a430445f50a6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c8bd63b7-036f-4505-90ef-7d10f3e13806"));
            base.InitializeControls();
        }

        public SmartCardLoginForm() : base("SmartCardLoginForm")
        {
        }

        protected SmartCardLoginForm(string formDefName) : base(formDefName)
        {
        }
    }
}