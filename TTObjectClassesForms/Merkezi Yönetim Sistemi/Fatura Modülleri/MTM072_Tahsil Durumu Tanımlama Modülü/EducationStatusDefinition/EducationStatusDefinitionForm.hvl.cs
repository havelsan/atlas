
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
    /// Eğitim Durumu Tanımlama Formu
    /// </summary>
    public partial class EducationStatusDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Eğitim Durumu
    /// </summary>
        protected TTObjectClasses.EducationStatusDefinition _EducationStatusDefinition
        {
            get { return (TTObjectClasses.EducationStatusDefinition)_ttObject; }
        }

        protected ITTLabel labelShortName;
        protected ITTTextBox ShortName;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelExtrenalCode;
        protected ITTTextBox ExternalCode;
        override protected void InitializeControls()
        {
            labelShortName = (ITTLabel)AddControl(new Guid("da8b7c89-349c-4bd2-833b-3ba6ab227cf5"));
            ShortName = (ITTTextBox)AddControl(new Guid("325b890f-2c2f-4a57-b0ee-6e42ab0c2329"));
            labelName = (ITTLabel)AddControl(new Guid("3d22eec7-4a3d-436e-9c2d-ab5bd5b6986a"));
            Name = (ITTTextBox)AddControl(new Guid("7c5f5244-1a54-4c4d-8a7b-7bc16eed031a"));
            labelExtrenalCode = (ITTLabel)AddControl(new Guid("d801f4ee-74c7-4a0a-a843-be63ef2293a2"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("13864660-df1e-43e0-b61d-5be260652bdd"));
            base.InitializeControls();
        }

        public EducationStatusDefinitionForm() : base("EDUCATIONSTATUSDEFINITION", "EducationStatusDefinitionForm")
        {
        }

        protected EducationStatusDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}