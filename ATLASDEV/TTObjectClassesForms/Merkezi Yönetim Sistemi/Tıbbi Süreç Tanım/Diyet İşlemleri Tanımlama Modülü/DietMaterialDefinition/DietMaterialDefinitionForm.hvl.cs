
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
    public partial class DietMaterialDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Diyet Malzeme Tanımları
    /// </summary>
        protected TTObjectClasses.DietMaterialDefinition _DietMaterialDefinition
        {
            get { return (TTObjectClasses.DietMaterialDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelVitamins;
        protected ITTTextBox Vitamins;
        protected ITTTextBox MaterialName;
        protected ITTLabel labelMaterialName;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("666832ae-41ff-4bb7-8cb5-a3ee976325f4"));
            labelVitamins = (ITTLabel)AddControl(new Guid("b03dbf00-fda8-4cc6-a202-4dbe5f6e15b6"));
            Vitamins = (ITTTextBox)AddControl(new Guid("e9db67a2-ad5a-42b8-b7b6-2f2dc2868020"));
            MaterialName = (ITTTextBox)AddControl(new Guid("d37bd8ee-9999-4de2-aa9a-cc32296f2ca6"));
            labelMaterialName = (ITTLabel)AddControl(new Guid("963ae687-85ac-4092-9be3-4229223d6218"));
            base.InitializeControls();
        }

        public DietMaterialDefinitionForm() : base("DIETMATERIALDEFINITION", "DietMaterialDefinitionForm")
        {
        }

        protected DietMaterialDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}