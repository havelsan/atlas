
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
    /// ESAW Kod Değeri
    /// </summary>
    public partial class CodeValueForm : TTDefinitionForm
    {
    /// <summary>
    /// ESAW Kod Değerleri
    /// </summary>
        protected TTObjectClasses.CodeValue _CodeValue
        {
            get { return (TTObjectClasses.CodeValue)_ttObject; }
        }

        protected ITTLabel labelCodeType;
        protected ITTObjectListBox CodeType;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTTextBox CadeValueName;
        protected ITTLabel labelCadeValueName;
        override protected void InitializeControls()
        {
            labelCodeType = (ITTLabel)AddControl(new Guid("d8f7e483-6ba9-4e3e-adb6-0128f3690bbd"));
            CodeType = (ITTObjectListBox)AddControl(new Guid("bbef6c92-92c7-4a8f-8c27-9e60ed4db360"));
            labelCode = (ITTLabel)AddControl(new Guid("7f80f647-edfd-4303-9dd2-b09ea1caf07d"));
            Code = (ITTTextBox)AddControl(new Guid("975be97f-d524-4a0e-8504-0dd0a8520b09"));
            CadeValueName = (ITTTextBox)AddControl(new Guid("257a00f9-885a-47d8-b666-19c1d0407bd7"));
            labelCadeValueName = (ITTLabel)AddControl(new Guid("7d581790-7e1d-4832-9a19-136c244bfc50"));
            base.InitializeControls();
        }

        public CodeValueForm() : base("CODEVALUE", "CodeValueForm")
        {
        }

        protected CodeValueForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}