
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
    /// Kimyasal Malzeme Tanımı
    /// </summary>
    public partial class MagistralChemicalDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.MagistralChemicalDefinition _MagistralChemicalDefinition
        {
            get { return (TTObjectClasses.MagistralChemicalDefinition)_ttObject; }
        }

        protected ITTCheckBox IsActive;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelChemicalProperty;
        protected ITTEnumComboBox ChemicalProperty;
        override protected void InitializeControls()
        {
            IsActive = (ITTCheckBox)AddControl(new Guid("6b33b5d2-fc48-46a3-ae9d-10e9dc05d9f7"));
            labelMaterial = (ITTLabel)AddControl(new Guid("bb3f958c-73ca-4d92-9a38-50f8c123076b"));
            Material = (ITTObjectListBox)AddControl(new Guid("9f182b81-85cd-4e9c-8e12-93614e4f43c4"));
            labelName = (ITTLabel)AddControl(new Guid("3311a15d-91ec-44c2-8f89-bf38a58593c3"));
            Name = (ITTTextBox)AddControl(new Guid("258a22ca-10f3-4ac2-bf91-9b8dfe2a06be"));
            labelChemicalProperty = (ITTLabel)AddControl(new Guid("7326c38d-34c2-49ec-b396-e0575c5bf77a"));
            ChemicalProperty = (ITTEnumComboBox)AddControl(new Guid("7b10c8c4-84b2-4c01-aa2f-c7b418c06c22"));
            base.InitializeControls();
        }

        public MagistralChemicalDefinitionForm() : base("MAGISTRALCHEMICALDEFINITION", "MagistralChemicalDefinitionForm")
        {
        }

        protected MagistralChemicalDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}