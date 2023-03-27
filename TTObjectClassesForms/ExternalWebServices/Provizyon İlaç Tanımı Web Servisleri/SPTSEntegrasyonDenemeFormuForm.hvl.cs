
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
    /// New Unbound Form
    /// </summary>
    public partial class SPTSEntegrasyonDenemeFormu : TTUnboundForm
    {
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTButton ttbutton2;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("4a01dbcb-4e40-4fde-8b66-cd28b2cca00d"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6a599551-ec74-4f7e-bac6-3ffb0712fe41"));
            ttbutton2 = (ITTButton)AddControl(new Guid("9af723eb-d894-4b22-be26-e3d1456af0d0"));
            ttbutton1 = (ITTButton)AddControl(new Guid("6052cdd1-04e1-4007-bc28-b5a69a5d2534"));
            base.InitializeControls();
        }

        public SPTSEntegrasyonDenemeFormu() : base("SPTSEntegrasyonDenemeFormu")
        {
        }

        protected SPTSEntegrasyonDenemeFormu(string formDefName) : base(formDefName)
        {
        }
    }
}