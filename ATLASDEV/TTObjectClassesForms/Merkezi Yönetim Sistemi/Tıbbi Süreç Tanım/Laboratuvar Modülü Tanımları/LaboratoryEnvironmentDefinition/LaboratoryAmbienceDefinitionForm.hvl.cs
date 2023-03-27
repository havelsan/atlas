
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
    /// Laboratuvar Örnek Ortam Tanım Formu
    /// </summary>
    public partial class LaboratoryAmbienceDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Laboratuvar Örnek Ortam Tanımları
    /// </summary>
        protected TTObjectClasses.LaboratoryEnvironmentDefinition _LaboratoryEnvironmentDefinition
        {
            get { return (TTObjectClasses.LaboratoryEnvironmentDefinition)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("945548fa-bbe4-4efc-a0a9-2a9f0b1c9804"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("505aab44-8389-4203-835a-470b632b9fb2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d989b735-15a2-4112-9736-6fc764b9bc71"));
            base.InitializeControls();
        }

        public LaboratoryAmbienceDefinitionForm() : base("LABORATORYENVIRONMENTDEFINITION", "LaboratoryAmbienceDefinitionForm")
        {
        }

        protected LaboratoryAmbienceDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}