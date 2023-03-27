
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
    /// Göz Rengi Tanımlama
    /// </summary>
    public partial class EyeColorDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Göz Rengi Tanımlama
    /// </summary>
        protected TTObjectClasses.EyeColorDefinition _EyeColorDefinition
        {
            get { return (TTObjectClasses.EyeColorDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelExternalCode;
        protected ITTTextBox ExternalCode;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("9ab91c09-a27f-444e-9f22-53844a6806cd"));
            Name = (ITTTextBox)AddControl(new Guid("fca95e7c-759a-46bd-9eb8-8930c7e34279"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("a9a0b698-c6d1-4e9c-9ddb-8a59ebe53fac"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("0da23075-07a7-4408-ad17-6df1049ab6bb"));
            base.InitializeControls();
        }

        public EyeColorDefinitionForm() : base("EYECOLORDEFINITION", "EyeColorDefinitionForm")
        {
        }

        protected EyeColorDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}