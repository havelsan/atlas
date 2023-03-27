
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
    /// Sistem Parametre Tanımı
    /// </summary>
    public partial class SystemParameterForm : BaseParameterForm
    {
        protected TTObjectClasses.SystemParameter _SystemParameter
        {
            get { return (TTObjectClasses.SystemParameter)_ttObject; }
        }

        protected ITTButton cmdEncrypt;
        protected ITTCheckBox IsEncrypted;
        override protected void InitializeControls()
        {
            cmdEncrypt = (ITTButton)AddControl(new Guid("6c832f5a-6a2b-4660-bcf0-a0297a001e09"));
            IsEncrypted = (ITTCheckBox)AddControl(new Guid("a3f401de-cc2a-4e36-bac6-bd8ef8e8ea79"));
            base.InitializeControls();
        }

        public SystemParameterForm() : base("SYSTEMPARAMETER", "SystemParameterForm")
        {
        }

        protected SystemParameterForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}