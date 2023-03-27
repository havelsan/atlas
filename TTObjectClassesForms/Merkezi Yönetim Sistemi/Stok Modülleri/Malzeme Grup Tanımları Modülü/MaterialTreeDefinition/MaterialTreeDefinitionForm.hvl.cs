
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
    /// Malzeme Grup Tanımları
    /// </summary>
    public partial class MaterialTreeDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Malzeme Grup Tanımları
    /// </summary>
        protected TTObjectClasses.MaterialTreeDefinition _MaterialTreeDefinition
        {
            get { return (TTObjectClasses.MaterialTreeDefinition)_ttObject; }
        }

        protected ITTLabel labelGroupCodeMaterialTreeDefinition;
        protected ITTTextBox GroupCodeMaterialTreeDefinition;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTObjectListBox ParentMaterialTree;
        protected ITTLabel labelParentMaterialTree;
        protected ITTCheckBox IsGroup;
        override protected void InitializeControls()
        {
            labelGroupCodeMaterialTreeDefinition = (ITTLabel)AddControl(new Guid("6c4ae296-cace-444c-8fed-51e5eea6b031"));
            GroupCodeMaterialTreeDefinition = (ITTTextBox)AddControl(new Guid("b2dd0919-7b76-4570-bd2c-6d2ca8626131"));
            Name = (ITTTextBox)AddControl(new Guid("8ad5a76e-c9bb-4513-b08a-83333d630819"));
            labelName = (ITTLabel)AddControl(new Guid("8f9a8979-3caa-44f4-be67-4cb1da26f08a"));
            ParentMaterialTree = (ITTObjectListBox)AddControl(new Guid("e8b14291-cb41-4212-96f7-c0dccab9b439"));
            labelParentMaterialTree = (ITTLabel)AddControl(new Guid("1211ed33-7a96-411f-b2e1-e853fc0e65b8"));
            IsGroup = (ITTCheckBox)AddControl(new Guid("b07025ca-f598-4e25-918c-fc716fb6fe76"));
            base.InitializeControls();
        }

        public MaterialTreeDefinitionForm() : base("MATERIALTREEDEFINITION", "MaterialTreeDefinitionForm")
        {
        }

        protected MaterialTreeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}