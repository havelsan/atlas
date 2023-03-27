
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
    /// Maaş Mutemetliği Tanımları
    /// </summary>
    public partial class SalaryPayMasterDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Maaş Mutemetliği Tanımları
    /// </summary>
        protected TTObjectClasses.SalaryPayMasterDefinition _SalaryPayMasterDefinition
        {
            get { return (TTObjectClasses.SalaryPayMasterDefinition)_ttObject; }
        }

        protected ITTLabel labelExternalCode;
        protected ITTTextBox ExternalCode;
        protected ITTCheckBox Activechcbox;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelExternalCode = (ITTLabel)AddControl(new Guid("7222f52e-a983-4519-8a89-4406a4cb5e9a"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("b29186f1-70d1-4684-a768-b77dcfca8abf"));
            Activechcbox = (ITTCheckBox)AddControl(new Guid("fb0b0955-5a5b-478a-b6b7-e8cae96caa10"));
            labelName = (ITTLabel)AddControl(new Guid("8d64d3c3-6e69-492d-a15b-ed021fd07e1a"));
            Name = (ITTTextBox)AddControl(new Guid("37063bb8-8d1f-4fc0-8880-0a405c8b8d45"));
            labelCode = (ITTLabel)AddControl(new Guid("4d983faf-0efe-4ae7-912d-6c95ef043539"));
            Code = (ITTTextBox)AddControl(new Guid("d5a22db3-825e-4aa7-9d0d-84af0b6d41c2"));
            base.InitializeControls();
        }

        public SalaryPayMasterDefinitionForm() : base("SALARYPAYMASTERDEFINITION", "SalaryPayMasterDefinitionForm")
        {
        }

        protected SalaryPayMasterDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}