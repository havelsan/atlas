
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
    /// TT Communication Sample Form
    /// </summary>
    public partial class TTCommSampleForm : TTUnboundForm
    {
        protected ITTButton ttbutton3;
        protected ITTButton ttbutton2;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            ttbutton3 = (ITTButton)AddControl(new Guid("6f71a58a-5321-4965-9108-b141ffb8696e"));
            ttbutton2 = (ITTButton)AddControl(new Guid("a0ab1d95-f7f0-4253-a10c-6e6d0fc1df11"));
            ttbutton1 = (ITTButton)AddControl(new Guid("0b88e1f6-41ea-4f49-b4e8-6fd01aed952f"));
            base.InitializeControls();
        }

        public TTCommSampleForm() : base("TTCommSampleForm")
        {
        }

        protected TTCommSampleForm(string formDefName) : base(formDefName)
        {
        }
    }
}