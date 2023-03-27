
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
    /// Radyoloji Şablon Tanım Formu
    /// </summary>
    public partial class RadiologyTemplateDefinitionForm : TTForm
    {
        protected TTObjectClasses.RadiologyTemplateDefinition _RadiologyTemplateDefinition
        {
            get { return (TTObjectClasses.RadiologyTemplateDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTTextBox Id;
        protected ITTLabel labelId;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("8710580f-0488-41e5-a278-3b69c0c8c7ac"));
            labelName = (ITTLabel)AddControl(new Guid("7b2067af-caf3-42d8-a8e9-23b0366c568b"));
            Id = (ITTTextBox)AddControl(new Guid("d106e973-7923-46eb-906d-6298fd894c50"));
            labelId = (ITTLabel)AddControl(new Guid("bd011309-7920-43e7-a541-6a5d9256922c"));
            Description = (ITTTextBox)AddControl(new Guid("900d6b43-1870-42a9-888c-b204e9414d8f"));
            labelDescription = (ITTLabel)AddControl(new Guid("30d561c5-49be-442a-8494-7bdc6c544131"));
            base.InitializeControls();
        }

        public RadiologyTemplateDefinitionForm() : base("RADIOLOGYTEMPLATEDEFINITION", "RadiologyTemplateDefinitionForm")
        {
        }

        protected RadiologyTemplateDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}