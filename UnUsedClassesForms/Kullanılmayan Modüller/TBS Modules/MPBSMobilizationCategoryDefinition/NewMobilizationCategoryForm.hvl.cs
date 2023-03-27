
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
    /// Seferberlik Kategori Tanımlama
    /// </summary>
    public partial class NewMobilizationCategoryForm : TTForm
    {
    /// <summary>
    /// Seferberlik Kategori Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSMobilizationCategoryDefinition _MPBSMobilizationCategoryDefinition
        {
            get { return (TTObjectClasses.MPBSMobilizationCategoryDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("cdc00f20-dcf7-4c50-9bb2-d80d2ddf88bc"));
            labelName = (ITTLabel)AddControl(new Guid("dd3a5575-f984-4661-b013-eab2b296253e"));
            base.InitializeControls();
        }

        public NewMobilizationCategoryForm() : base("MPBSMOBILIZATIONCATEGORYDEFINITION", "NewMobilizationCategoryForm")
        {
        }

        protected NewMobilizationCategoryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}