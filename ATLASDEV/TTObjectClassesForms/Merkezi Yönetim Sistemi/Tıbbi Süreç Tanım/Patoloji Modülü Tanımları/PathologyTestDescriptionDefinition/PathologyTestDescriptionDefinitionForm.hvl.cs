
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
    /// Patoloji Tetkik Açıklamaları Formu
    /// </summary>
    public partial class PathologyTestDescriptionDefinitionForm : TTForm
    {
        protected TTObjectClasses.PathologyTestDescriptionDefinition _PathologyTestDescriptionDefinition
        {
            get { return (TTObjectClasses.PathologyTestDescriptionDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTLabel labelDescription;
        protected ITTTextBox OrderNo;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelOrderNo;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("6ae02a87-74ba-431e-8e41-5f5cee015f69"));
            Description = (ITTTextBox)AddControl(new Guid("2b8bba2a-daf1-4d9f-ac6e-7df753810424"));
            Name = (ITTTextBox)AddControl(new Guid("23b05a56-f11f-4bbd-bfc5-9b9279937a17"));
            labelDescription = (ITTLabel)AddControl(new Guid("3837de33-bae9-4ed5-ba7e-b410d73359f8"));
            OrderNo = (ITTTextBox)AddControl(new Guid("3a9cc995-d18e-4613-a831-b7f7fb0c5f41"));
            IsActive = (ITTCheckBox)AddControl(new Guid("33944ddc-bcbe-4c47-8bd3-dda51b91eab7"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("eaab7fba-e237-40eb-986b-f9cb138cad00"));
            base.InitializeControls();
        }

        public PathologyTestDescriptionDefinitionForm() : base("PATHOLOGYTESTDESCRIPTIONDEFINITION", "PathologyTestDescriptionDefinitionForm")
        {
        }

        protected PathologyTestDescriptionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}