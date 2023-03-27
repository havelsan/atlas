
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
    public partial class AutoReturningDocument : TTUnboundForm
    {
        protected ITTButton ReturningDocCreat;
        override protected void InitializeControls()
        {
            ReturningDocCreat = (ITTButton)AddControl(new Guid("3a510f13-c13d-4530-b8d3-df8ff003c084"));
            base.InitializeControls();
        }

        public AutoReturningDocument() : base("AutoReturningDocument")
        {
        }

        protected AutoReturningDocument(string formDefName) : base(formDefName)
        {
        }
    }
}