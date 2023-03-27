
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
    /// Ameliyat Sonucu Tanımlama Formu
    /// </summary>
    public partial class SurgeryResultDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Ameliyat Sonucu Tanımlama
    /// </summary>
        protected TTObjectClasses.SurgeryResultDefinition _SurgeryResultDefinition
        {
            get { return (TTObjectClasses.SurgeryResultDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("1a66a367-ee0d-4380-9108-2007d4f12e34"));
            Name = (ITTTextBox)AddControl(new Guid("e70c005e-ab0f-4dc5-990f-1f0614046e06"));
            Aktif = (ITTCheckBox)AddControl(new Guid("918c50ea-ef1d-4587-9b38-7f1d2c18495a"));
            base.InitializeControls();
        }

        public SurgeryResultDefinitionForm() : base("SURGERYRESULTDEFINITION", "SurgeryResultDefinitionForm")
        {
        }

        protected SurgeryResultDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}