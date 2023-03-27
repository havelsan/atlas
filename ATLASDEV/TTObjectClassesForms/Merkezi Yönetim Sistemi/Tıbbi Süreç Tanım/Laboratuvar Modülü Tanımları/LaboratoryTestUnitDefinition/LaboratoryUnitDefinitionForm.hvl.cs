
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
    /// Test Birimi Tanımı
    /// </summary>
    public partial class LaboratoryUnitDefinitionForm : TTForm
    {
        protected TTObjectClasses.LaboratoryTestUnitDefinition _LaboratoryTestUnitDefinition
        {
            get { return (TTObjectClasses.LaboratoryTestUnitDefinition)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c6581bd8-6a0e-468b-930d-b75e49f64334"));
            base.InitializeControls();
        }

        public LaboratoryUnitDefinitionForm() : base("LABORATORYTESTUNITDEFINITION", "LaboratoryUnitDefinitionForm")
        {
        }

        protected LaboratoryUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}