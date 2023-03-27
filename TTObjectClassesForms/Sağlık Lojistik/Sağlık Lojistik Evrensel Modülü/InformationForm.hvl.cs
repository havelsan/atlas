
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
    public partial class InformationForm : TTUnboundForm
    {
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTButton ttbutton2;
        override protected void InitializeControls()
        {
            ttbutton1 = (ITTButton)AddControl(new Guid("8aca7352-5810-4101-af17-a91cd4e545aa"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e16dd444-6d68-443a-a242-8fb89703135b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("62c6b447-da8a-4509-ad94-19d06e91f870"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ec74b41b-9c6b-46d5-805c-818b1fa2d013"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6fcb5878-bb71-482d-8ac6-e509b03eb5ce"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("d3288469-f7eb-4615-84e7-3321f0ebcf73"));
            ttbutton2 = (ITTButton)AddControl(new Guid("37b3852d-e137-46ce-8db5-9c8a3fe1333e"));
            base.InitializeControls();
        }

        public InformationForm() : base("InformationForm")
        {
        }

        protected InformationForm(string formDefName) : base(formDefName)
        {
        }
    }
}