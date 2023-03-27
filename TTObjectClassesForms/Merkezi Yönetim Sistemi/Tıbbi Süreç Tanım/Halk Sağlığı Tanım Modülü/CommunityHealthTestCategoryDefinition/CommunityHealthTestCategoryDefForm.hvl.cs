
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
    /// Halk Sağlığı Tetkik Kategori  Tanımları
    /// </summary>
    public partial class CommunityHealthTestCategoryDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Halk Sağlığı Tetkik Kategori
    /// </summary>
        protected TTObjectClasses.CommunityHealthTestCategoryDefinition _CommunityHealthTestCategoryDefinition
        {
            get { return (TTObjectClasses.CommunityHealthTestCategoryDefinition)_ttObject; }
        }

        protected ITTCheckBox CalcMeqAndMval;
        protected ITTLabel labelTabOrder;
        protected ITTTextBox TabOrder;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTLabel labelDescription;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            CalcMeqAndMval = (ITTCheckBox)AddControl(new Guid("917e2091-e453-4cba-9f3d-c88d2d965c8f"));
            labelTabOrder = (ITTLabel)AddControl(new Guid("3cbe0e42-1b82-46f2-83dc-8a2bc9fcd358"));
            TabOrder = (ITTTextBox)AddControl(new Guid("9970c60c-81a5-4ddd-b6de-5a22eb947475"));
            Description = (ITTTextBox)AddControl(new Guid("6ec61d23-8e41-406b-95a0-800d76af3f39"));
            Name = (ITTTextBox)AddControl(new Guid("3f96f898-94b5-4ace-9050-d46c47ee09e5"));
            labelDescription = (ITTLabel)AddControl(new Guid("fa9aca56-21ce-4b6f-bfdb-82815d6b741f"));
            labelName = (ITTLabel)AddControl(new Guid("509f3b4d-c99a-46d8-b4cb-8dd8574a15ae"));
            base.InitializeControls();
        }

        public CommunityHealthTestCategoryDefForm() : base("COMMUNITYHEALTHTESTCATEGORYDEFINITION", "CommunityHealthTestCategoryDefForm")
        {
        }

        protected CommunityHealthTestCategoryDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}