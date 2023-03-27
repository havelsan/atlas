
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
    public partial class Unbound__Test_Form : TTUnboundForm
    {
        protected ITTLabel ttlabel1;
        protected ITTTextBox tbIdentityNumber;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("63810f3b-5df1-440e-a166-31f1c582ec01"));
            tbIdentityNumber = (ITTTextBox)AddControl(new Guid("21499622-261a-4a05-b6ec-98a7521029c0"));
            ttbutton1 = (ITTButton)AddControl(new Guid("6a6842ea-9b3a-497d-b7e0-96de4b25a049"));
            base.InitializeControls();
        }

        public Unbound__Test_Form() : base("Unbound__Test_Form")
        {
        }

        protected Unbound__Test_Form(string formDefName) : base(formDefName)
        {
        }
    }
}