
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
    /// Bakım Onarım Kontrol Parametreleri Tanımı
    /// </summary>
    public partial class MaintenanceParameterDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Bakım Peryodu Tanımlama
    /// </summary>
        protected TTObjectClasses.MaintenanceParameterDefinition _MaintenanceParameterDefinition
        {
            get { return (TTObjectClasses.MaintenanceParameterDefinition)_ttObject; }
        }

        protected ITTCheckBox AboutWithDevice;
        protected ITTCheckBox AllMaintenanceAction;
        protected ITTTextBox Parameter;
        protected ITTLabel labelParameter;
        override protected void InitializeControls()
        {
            AboutWithDevice = (ITTCheckBox)AddControl(new Guid("eff2c878-9560-4671-a6df-36a5fbbaaa63"));
            AllMaintenanceAction = (ITTCheckBox)AddControl(new Guid("1de5dc3e-2e20-47ce-b141-260081331008"));
            Parameter = (ITTTextBox)AddControl(new Guid("1c9939c8-dfcb-4e94-85c4-c33ed94f4169"));
            labelParameter = (ITTLabel)AddControl(new Guid("b9262c4c-904a-4157-ab09-c79d74680aba"));
            base.InitializeControls();
        }

        public MaintenanceParameterDefinitionForm() : base("MAINTENANCEPARAMETERDEFINITION", "MaintenanceParameterDefinitionForm")
        {
        }

        protected MaintenanceParameterDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}