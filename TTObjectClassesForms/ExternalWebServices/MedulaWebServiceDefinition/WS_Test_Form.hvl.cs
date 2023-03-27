
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
    public partial class WS_Test_Form : TTUnboundForm
    {
        protected ITTButton ttbutton5;
        protected ITTButton ttbutton4;
        protected ITTButton ttbutton3;
        protected ITTButton ttbutton2;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            ttbutton5 = (ITTButton)AddControl(new Guid("69e34712-e8df-48d4-97d4-e1a295b0ad8f"));
            ttbutton4 = (ITTButton)AddControl(new Guid("fd6b9200-bfbf-49a3-b0eb-9ed9d9582d1f"));
            ttbutton3 = (ITTButton)AddControl(new Guid("648c75a7-aaaf-404a-9947-9f10e937dc72"));
            ttbutton2 = (ITTButton)AddControl(new Guid("af8680ca-0dfa-4eea-9e33-ff1761c49ea7"));
            ttbutton1 = (ITTButton)AddControl(new Guid("7c37c07d-9952-4d3e-918c-1e472b44034c"));
            base.InitializeControls();
        }

        public WS_Test_Form() : base("WS_Test_Form")
        {
        }

        protected WS_Test_Form(string formDefName) : base(formDefName)
        {
        }
    }
}