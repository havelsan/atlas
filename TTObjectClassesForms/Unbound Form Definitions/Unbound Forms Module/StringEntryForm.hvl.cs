
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
    public partial class StringEntryForm : TTUnboundForm
    {
        protected ITTButton Ok;
        protected ITTLabel Title;
        protected ITTTextBox StringField;
        protected ITTButton Cancel;
        override protected void InitializeControls()
        {
            Ok = (ITTButton)AddControl(new Guid("6e5f2729-ac72-4dd0-bcb3-6232c47385fb"));
            Title = (ITTLabel)AddControl(new Guid("1ddbb946-83ba-49cb-aab4-8afe45cdc82b"));
            StringField = (ITTTextBox)AddControl(new Guid("ea3536bd-14a3-4323-8cdf-fc7b3511e4b9"));
            Cancel = (ITTButton)AddControl(new Guid("ad8a8045-d4a8-4be1-b855-446c9cb7ecee"));
            base.InitializeControls();
        }

        public StringEntryForm() : base("StringEntryForm")
        {
        }

        protected StringEntryForm(string formDefName) : base(formDefName)
        {
        }
    }
}