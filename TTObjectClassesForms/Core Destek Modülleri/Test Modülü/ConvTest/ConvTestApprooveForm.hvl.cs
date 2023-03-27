
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
    public partial class ConvTestApprooveForm : TTForm
    {
    /// <summary>
    /// ConvTest Kılası
    /// </summary>
        protected TTObjectClasses.ConvTest _ConvTest
        {
            get { return (TTObjectClasses.ConvTest)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Telephone;
        protected ITTTextBox No;
        protected ITTButton ttbutton1;
        protected ITTLabel labelCity;
        protected ITTObjectListBox City;
        protected ITTLabel labelTelephone;
        protected ITTLabel labelNo;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("d46eed29-c00d-4026-9e56-d7fef7b4c2f6"));
            Description = (ITTTextBox)AddControl(new Guid("058eb420-ba90-4e69-b219-5792d2e61ab7"));
            Telephone = (ITTTextBox)AddControl(new Guid("97f3ff33-6df1-4857-9263-307ae617ca38"));
            No = (ITTTextBox)AddControl(new Guid("6ad03006-f55f-43cc-b4e3-cf4da8dec1d8"));
            ttbutton1 = (ITTButton)AddControl(new Guid("f2f794bc-3b7e-4bef-8e2e-8f5e93bf8118"));
            labelCity = (ITTLabel)AddControl(new Guid("7e5ecf5e-5ecb-415e-ac65-abc4a718fe4d"));
            City = (ITTObjectListBox)AddControl(new Guid("2be2c508-087a-40fa-9338-2573695ce04a"));
            labelTelephone = (ITTLabel)AddControl(new Guid("7bed4616-f2e1-460a-b811-97a273edd748"));
            labelNo = (ITTLabel)AddControl(new Guid("0d3d344a-f2fc-4c0f-8e3b-e95174d841fd"));
            base.InitializeControls();
        }

        public ConvTestApprooveForm() : base("CONVTEST", "ConvTestApprooveForm")
        {
        }

        protected ConvTestApprooveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}