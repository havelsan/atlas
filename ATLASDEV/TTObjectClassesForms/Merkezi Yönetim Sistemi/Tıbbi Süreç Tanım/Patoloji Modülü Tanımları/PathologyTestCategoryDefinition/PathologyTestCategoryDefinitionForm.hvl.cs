
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
    /// Patoloji Tetkik Kategori Tanım Ekranı
    /// </summary>
    public partial class PathologyTestCategoryDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kategori
    /// </summary>
        protected TTObjectClasses.PathologyTestCategoryDefinition _PathologyTestCategoryDefinition
        {
            get { return (TTObjectClasses.PathologyTestCategoryDefinition)_ttObject; }
        }

        protected ITTCheckBox IsActive;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelMaterialProtocolNoPrefix;
        protected ITTTextBox MaterialProtocolNoPrefix;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            IsActive = (ITTCheckBox)AddControl(new Guid("4d3767bf-da7c-4598-9aa7-f02fe3ef9aef"));
            labelName = (ITTLabel)AddControl(new Guid("5859732b-f040-4997-b19e-87da41e334e4"));
            Name = (ITTTextBox)AddControl(new Guid("e9b5a538-8613-4b52-8253-408a7a23dd05"));
            labelMaterialProtocolNoPrefix = (ITTLabel)AddControl(new Guid("757e4a33-bb9f-44e9-a52b-9b0687e49438"));
            MaterialProtocolNoPrefix = (ITTTextBox)AddControl(new Guid("0849f11c-7660-4be4-b8f9-07033c2c33e9"));
            labelDescription = (ITTLabel)AddControl(new Guid("c14418f0-8741-4cd1-8f12-e81b6e56ad46"));
            Description = (ITTTextBox)AddControl(new Guid("28bef760-0399-496f-af6c-dadc4c17fd75"));
            base.InitializeControls();
        }

        public PathologyTestCategoryDefinitionForm() : base("PATHOLOGYTESTCATEGORYDEFINITION", "PathologyTestCategoryDefinitionForm")
        {
        }

        protected PathologyTestCategoryDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}