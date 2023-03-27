
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
    /// Şablon Grubu Tanımı
    /// </summary>
    public partial class RTFTemplateGroupForm : TTForm
    {
        protected TTObjectClasses.TemplateGroup _TemplateGroup
        {
            get { return (TTObjectClasses.TemplateGroup)_ttObject; }
        }

        protected ITTLabel labelGroupName;
        protected ITTTextBox GroupName;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            labelGroupName = (ITTLabel)AddControl(new Guid("1e56b91d-b3c3-4b5d-91ab-c763ccb01074"));
            GroupName = (ITTTextBox)AddControl(new Guid("1af9f3f1-b7a2-473a-87e6-b662e0c236f5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("db1894ee-377b-485a-b69c-bac90002ae1e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("bac174ca-912a-4c9a-86c5-a944031a0dae"));
            base.InitializeControls();
        }

        public RTFTemplateGroupForm() : base("TEMPLATEGROUP", "RTFTemplateGroupForm")
        {
        }

        protected RTFTemplateGroupForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}