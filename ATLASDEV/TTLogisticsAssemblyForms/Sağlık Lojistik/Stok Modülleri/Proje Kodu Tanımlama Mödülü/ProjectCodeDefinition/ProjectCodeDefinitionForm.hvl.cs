
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
    /// Proje Kodu Tanımlama
    /// </summary>
    public partial class ProjectCodeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ProjectCodeDefinition _ProjectCodeDefinition
        {
            get { return (TTObjectClasses.ProjectCodeDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("22aa8d71-dfb3-4af0-8e95-5df0c46d97b5"));
            Name = (ITTTextBox)AddControl(new Guid("0184dc23-1d62-4636-b099-4985659040b2"));
            Code = (ITTTextBox)AddControl(new Guid("aa269bfd-1fff-4225-8fb8-2055ef625612"));
            labelCode = (ITTLabel)AddControl(new Guid("a2cda441-436e-4a1d-90da-81b5f1721a54"));
            base.InitializeControls();
        }

        public ProjectCodeDefinitionForm() : base("PROJECTCODEDEFINITION", "ProjectCodeDefinitionForm")
        {
        }

        protected ProjectCodeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}