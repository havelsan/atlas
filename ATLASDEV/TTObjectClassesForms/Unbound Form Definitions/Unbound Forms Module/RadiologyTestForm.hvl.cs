
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
    /// Radyoloji Test Formu
    /// </summary>
    public partial class RadiologyTestForm : TTUnboundForm
    {
        protected ITTLabel lblCount;
        protected ITTButton cmdSendUsersToPACS;
        override protected void InitializeControls()
        {
            lblCount = (ITTLabel)AddControl(new Guid("fd7864d5-9459-4a53-87cd-de2ce390419f"));
            cmdSendUsersToPACS = (ITTButton)AddControl(new Guid("cc69f1c1-cdae-445e-8408-22ae0db150d9"));
            base.InitializeControls();
        }

        public RadiologyTestForm() : base("RadiologyTestForm")
        {
        }

        protected RadiologyTestForm(string formDefName) : base(formDefName)
        {
        }
    }
}