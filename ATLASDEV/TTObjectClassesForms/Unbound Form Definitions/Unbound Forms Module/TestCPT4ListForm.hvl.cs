
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
    /// TestCPT4ListForm
    /// </summary>
    public partial class TestCPT4ListForm : TTUnboundForm
    {
        protected ITTObjectListBox CPT4List;
        protected ITTButton ttbutton4;
        override protected void InitializeControls()
        {
            CPT4List = (ITTObjectListBox)AddControl(new Guid("b729ae47-bd89-4d62-8f20-09e378901b0b"));
            ttbutton4 = (ITTButton)AddControl(new Guid("8aae19db-4aed-4da4-aca2-b26b9b9292d8"));
            base.InitializeControls();
        }

        public TestCPT4ListForm() : base("TestCPT4ListForm")
        {
        }

        protected TestCPT4ListForm(string formDefName) : base(formDefName)
        {
        }
    }
}