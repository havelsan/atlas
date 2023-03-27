
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
    public partial class SendToENabizTestFormFromTextEditor : TTUnboundForm
    {
        protected ITTLabel ttlabel3;
        protected ITTButton sysGonder;
        protected ITTRichTextBoxControl txtResponceXML;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTRichTextBoxControl txtSendXML;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("c53a1b07-f3ba-43c1-810d-ccdcde87cb53"));
            sysGonder = (ITTButton)AddControl(new Guid("06de6b00-c09b-4fcd-b0e5-053d8f3a2069"));
            txtResponceXML = (ITTRichTextBoxControl)AddControl(new Guid("93193190-768b-44dc-8b0c-7f6ca9ee3411"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2b6369a0-59db-4367-8a48-0e9cc2dcb879"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("242d9425-d029-4a16-8f2b-423162ebf5ce"));
            txtSendXML = (ITTRichTextBoxControl)AddControl(new Guid("d335c174-184b-4433-a5a4-7b224d17fadf"));
            base.InitializeControls();
        }

        public SendToENabizTestFormFromTextEditor() : base("SendToENabizTestFormFromTextEditor")
        {
        }

        protected SendToENabizTestFormFromTextEditor(string formDefName) : base(formDefName)
        {
        }
    }
}