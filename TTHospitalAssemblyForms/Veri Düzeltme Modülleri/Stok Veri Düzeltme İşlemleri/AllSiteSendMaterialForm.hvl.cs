
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
    /// Sahalara Malzeme Yollama
    /// </summary>
    public partial class AllSiteSendMaterial : TTUnboundForm
    {
        protected ITTButton sendMatbutton;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox MaterialListBox;
        override protected void InitializeControls()
        {
            sendMatbutton = (ITTButton)AddControl(new Guid("bcdf40d1-f3e5-42f1-b679-fc7f64485a20"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4086ea5c-2d48-4d5e-b8ef-debf07b760d9"));
            MaterialListBox = (ITTObjectListBox)AddControl(new Guid("f7ba5eab-2d19-4cca-aa46-6fd2c3fc00e3"));
            base.InitializeControls();
        }

        public AllSiteSendMaterial() : base("AllSiteSendMaterial")
        {
        }

        protected AllSiteSendMaterial(string formDefName) : base(formDefName)
        {
        }
    }
}