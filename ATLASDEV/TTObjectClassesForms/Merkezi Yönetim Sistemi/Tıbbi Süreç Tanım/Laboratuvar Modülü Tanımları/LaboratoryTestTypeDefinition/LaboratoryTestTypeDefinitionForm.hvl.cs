
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
    /// Laboratuvar Tetkik Tür Tanımları Formu
    /// </summary>
    public partial class LaboratoryTestTypeDefinitionForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Test Tür Tanımları
    /// </summary>
        protected TTObjectClasses.LaboratoryTestTypeDefinition _LaboratoryTestTypeDefinition
        {
            get { return (TTObjectClasses.LaboratoryTestTypeDefinition)_ttObject; }
        }

        protected ITTCheckBox chkActive;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            chkActive = (ITTCheckBox)AddControl(new Guid("e12e01c8-1b99-4da7-8222-ab4dc22eaeed"));
            Name = (ITTTextBox)AddControl(new Guid("93f10a3c-f5f5-4331-9a21-bebbaf1a3fdd"));
            labelName = (ITTLabel)AddControl(new Guid("4f06e813-0c0f-4c1f-9a3a-f77c436a3fb3"));
            base.InitializeControls();
        }

        public LaboratoryTestTypeDefinitionForm() : base("LABORATORYTESTTYPEDEFINITION", "LaboratoryTestTypeDefinitionForm")
        {
        }

        protected LaboratoryTestTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}