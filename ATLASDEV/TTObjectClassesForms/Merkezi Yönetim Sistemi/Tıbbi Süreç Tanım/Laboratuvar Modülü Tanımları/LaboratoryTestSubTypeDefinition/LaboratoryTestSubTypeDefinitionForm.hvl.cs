
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
    /// Laboratuvar Tetkik Alt Tür Tanımları Formu
    /// </summary>
    public partial class LaboratoryTestSubTypeDefinitionForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Tetkik Alt Tür Tanımları
    /// </summary>
        protected TTObjectClasses.LaboratoryTestSubTypeDefinition _LaboratoryTestSubTypeDefinition
        {
            get { return (TTObjectClasses.LaboratoryTestSubTypeDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTCheckBox chkActive;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("85f2e800-842e-4945-bd39-04d1d82b0a70"));
            chkActive = (ITTCheckBox)AddControl(new Guid("cea3a971-e0b3-4ae9-95b0-65402f241f8f"));
            Name = (ITTTextBox)AddControl(new Guid("aca6d635-0fa7-44d2-b7f8-7d9dc733a4a8"));
            base.InitializeControls();
        }

        public LaboratoryTestSubTypeDefinitionForm() : base("LABORATORYTESTSUBTYPEDEFINITION", "LaboratoryTestSubTypeDefinitionForm")
        {
        }

        protected LaboratoryTestSubTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}