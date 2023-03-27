
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
    public partial class CommonSKRStest : TTUnboundForm
    {
        protected ITTLabel ttlabel1;
        protected ITTTextBox ttObjectGuid;
        protected ITTTextBox ttSubEpisode;
        protected ITTRichTextBoxControl RichText;
        protected ITTButton ttbutton101;
        protected ITTLabel ttlabel2;
        protected ITTButton ttbutton1;
        protected ITTButton ttbutton103;
        protected ITTButton btn104;
        protected ITTButton btn105;
        protected ITTButton btn106;
        protected ITTButton btn901;
        protected ITTButton ttbutton252;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("75814a3e-67a6-49dd-abc8-e9d33607e54b"));
            ttObjectGuid = (ITTTextBox)AddControl(new Guid("1dc2d91e-385b-41fb-8eb9-9af1bca3d4d4"));
            ttSubEpisode = (ITTTextBox)AddControl(new Guid("119d794a-6e16-409b-bda7-42ac5f14719d"));
            RichText = (ITTRichTextBoxControl)AddControl(new Guid("5c50b621-0962-4a34-989c-cfc8918363b9"));
            ttbutton101 = (ITTButton)AddControl(new Guid("f371622a-b028-44ab-a013-58316325bf17"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e67419b2-d478-440b-b784-c0e87263487e"));
            ttbutton1 = (ITTButton)AddControl(new Guid("6ee906b8-bb17-4d59-bdef-5db918c79bdf"));
            ttbutton103 = (ITTButton)AddControl(new Guid("14c93f59-539d-46bd-9ada-40766a212014"));
            btn104 = (ITTButton)AddControl(new Guid("7a9470e0-7de8-4ca9-ba50-b5aa80e46caf"));
            btn105 = (ITTButton)AddControl(new Guid("e29d1ea2-6014-45c6-9c55-61618ec951f1"));
            btn106 = (ITTButton)AddControl(new Guid("686074b6-beb6-4f1c-adad-d86e71cdaa0e"));
            btn901 = (ITTButton)AddControl(new Guid("84179a51-f1a1-45e6-b90b-0e036c8423f2"));
            ttbutton252 = (ITTButton)AddControl(new Guid("ec6d24cd-bd5c-49c4-904e-093420014453"));
            base.InitializeControls();
        }

        public CommonSKRStest() : base("CommonSKRStest")
        {
        }

        protected CommonSKRStest(string formDefName) : base(formDefName)
        {
        }
    }
}