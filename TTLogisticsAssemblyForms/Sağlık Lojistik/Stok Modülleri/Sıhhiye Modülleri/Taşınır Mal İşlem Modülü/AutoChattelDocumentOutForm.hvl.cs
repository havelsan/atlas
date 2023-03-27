
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
    public partial class AutoChattelDocumentOut : TTUnboundForm
    {
        protected ITTObjectListBox MainStore;
        protected ITTButton ChattelDocCreat;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelAccountancy;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            MainStore = (ITTObjectListBox)AddControl(new Guid("bbb56d33-39b5-4360-82fa-13d3e2c6d625"));
            ChattelDocCreat = (ITTButton)AddControl(new Guid("623acfc3-d6a7-4512-94c8-29f5f3fd7edf"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("9bf87b3a-7938-44f4-a9d1-5ccd727cc77c"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("884f6c6f-d0f7-4c70-9c0b-2990dc63d02a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7d50c21b-2430-4a34-ace2-4077b720a5b3"));
            base.InitializeControls();
        }

        public AutoChattelDocumentOut() : base("AutoChattelDocumentOut")
        {
        }

        protected AutoChattelDocumentOut(string formDefName) : base(formDefName)
        {
        }
    }
}