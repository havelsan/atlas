
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
    /// Malzeme Kullanım Amacı Tanımı
    /// </summary>
    public partial class MaterialPurposeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.MaterialPurposeDefinition _MaterialPurposeDefinition
        {
            get { return (TTObjectClasses.MaterialPurposeDefinition)_ttObject; }
        }

        protected ITTLabel labelPurpose;
        protected ITTTextBox Purpose;
        override protected void InitializeControls()
        {
            labelPurpose = (ITTLabel)AddControl(new Guid("71ce707f-4a8f-4ce6-9e42-177bd33040ba"));
            Purpose = (ITTTextBox)AddControl(new Guid("4d27637b-22c6-4b0b-afdd-59a18198da56"));
            base.InitializeControls();
        }

        public MaterialPurposeDefinitionForm() : base("MATERIALPURPOSEDEFINITION", "MaterialPurposeDefinitionForm")
        {
        }

        protected MaterialPurposeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}