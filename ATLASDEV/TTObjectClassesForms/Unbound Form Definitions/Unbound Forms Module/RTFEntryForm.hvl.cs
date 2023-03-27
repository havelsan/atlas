
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
    public partial class RTFEntryForm : TTUnboundForm
    {
        protected ITTLabel Title;
        protected ITTButton Ok;
        protected ITTRichTextBoxControl RTFField;
        protected ITTButton Cancel;
        override protected void InitializeControls()
        {
            Title = (ITTLabel)AddControl(new Guid("bedd64e7-45f5-42d0-bb34-a2311f1ee155"));
            Ok = (ITTButton)AddControl(new Guid("30696651-73c1-4872-ab12-ee3340f86562"));
            RTFField = (ITTRichTextBoxControl)AddControl(new Guid("d19319a2-35bc-4922-a4ea-03b3c169c4e2"));
            Cancel = (ITTButton)AddControl(new Guid("a61e0970-d05b-455f-991d-43c8a14d6d1d"));
            base.InitializeControls();
        }

        public RTFEntryForm() : base("RTFEntryForm")
        {
        }

        protected RTFEntryForm(string formDefName) : base(formDefName)
        {
        }
    }
}