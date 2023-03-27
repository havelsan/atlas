
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
    public partial class SKRSGuncellemeForm : TTUnboundForm
    {
        protected ITTButton ttbutton3;
        protected ITTTextBox txtmatchDef;
        protected ITTTextBox txtSonuc;
        protected ITTLabel ttlabel2;
        protected ITTListView SKRSListView;
        protected ITTButton ttbutton1;
        protected ITTButton ttbutton2;
        protected ITTButton TopluGetir;
        override protected void InitializeControls()
        {
            ttbutton3 = (ITTButton)AddControl(new Guid("649faf2c-37cc-4ead-83fc-469dbe77b775"));
            txtmatchDef = (ITTTextBox)AddControl(new Guid("b86934f6-919f-4831-8fbc-1031cbefde83"));
            txtSonuc = (ITTTextBox)AddControl(new Guid("333f3364-1c47-493e-8090-66e41cf9b3c7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("93f9c250-a97d-448f-b1d0-5218b9ff174d"));
            SKRSListView = (ITTListView)AddControl(new Guid("d1e7099b-d9fa-4105-bec0-cff0481a82e1"));
            ttbutton1 = (ITTButton)AddControl(new Guid("59ecd0d9-4191-4be9-b2d2-ed61231072e3"));
            ttbutton2 = (ITTButton)AddControl(new Guid("a71fcd59-0ce8-43bd-b5de-51cfd00b1f4e"));
            TopluGetir = (ITTButton)AddControl(new Guid("a86048ee-3b90-4fb9-ae96-c3e27c4a4dc9"));
            base.InitializeControls();
        }

        public SKRSGuncellemeForm() : base("SKRSGuncellemeForm")
        {
        }

        protected SKRSGuncellemeForm(string formDefName) : base(formDefName)
        {
        }
    }
}