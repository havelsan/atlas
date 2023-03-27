
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
    public partial class MedicalWasteContainerForm : TTDefinitionForm
    {
        protected TTObjectClasses.MedicalWasteContainerDefinition _MedicalWasteContainerDefinition
        {
            get { return (TTObjectClasses.MedicalWasteContainerDefinition)_ttObject; }
        }

        protected ITTCheckBox IsActive;
        protected ITTLabel labelCapacity;
        protected ITTTextBox Capacity;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            IsActive = (ITTCheckBox)AddControl(new Guid("207b9ebe-a9af-43bf-8597-f7f920759a8b"));
            labelCapacity = (ITTLabel)AddControl(new Guid("f1a11be9-d548-44ab-a9ff-84317f863499"));
            Capacity = (ITTTextBox)AddControl(new Guid("d151eec2-e82e-41b6-ae6d-b22bcabe3543"));
            Name = (ITTTextBox)AddControl(new Guid("c2e9230f-3938-4037-b025-757e37a23411"));
            labelName = (ITTLabel)AddControl(new Guid("1a9f9e7f-909b-4750-a6ed-7c092c032658"));
            base.InitializeControls();
        }

        public MedicalWasteContainerForm() : base("MEDICALWASTECONTAINERDEFINITION", "MedicalWasteContainerForm")
        {
        }

        protected MedicalWasteContainerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}