
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
    public partial class CommonCodeGroupDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.CommonCodeGroup _CommonCodeGroup
        {
            get { return (TTObjectClasses.CommonCodeGroup)_ttObject; }
        }

        protected ITTLabel labelGROUP_CODE;
        protected ITTTextBox GROUP_CODE;
        protected ITTTextBox GROUP_NAME;
        protected ITTTextBox GROUP_DESCR;
        protected ITTLabel labelGROUP_NAME;
        protected ITTLabel labelGROUP_DESCR;
        override protected void InitializeControls()
        {
            labelGROUP_CODE = (ITTLabel)AddControl(new Guid("ed1ff22b-4cd4-4e58-9d6a-ae4182c19492"));
            GROUP_CODE = (ITTTextBox)AddControl(new Guid("8b37a66c-8779-45c5-affc-2c32dee456a7"));
            GROUP_NAME = (ITTTextBox)AddControl(new Guid("a27d8d47-1091-47e3-9a90-544587712200"));
            GROUP_DESCR = (ITTTextBox)AddControl(new Guid("55050521-6829-4cfb-927c-ec7abeeb1aff"));
            labelGROUP_NAME = (ITTLabel)AddControl(new Guid("e86b7fc0-4725-4c81-ac5d-a76f78b1623c"));
            labelGROUP_DESCR = (ITTLabel)AddControl(new Guid("b838f420-b68a-4efa-9b79-0552554e0a46"));
            base.InitializeControls();
        }

        public CommonCodeGroupDefinitionForm() : base("COMMONCODEGROUP", "CommonCodeGroupDefinitionForm")
        {
        }

        protected CommonCodeGroupDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}