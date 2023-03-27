
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
    /// Laboratuvar Sonuç Birim Tanım Formu
    /// </summary>
    public partial class LaboratoryResultUnitDefinitionForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Sonuç Birim Tanımı
    /// </summary>
        protected TTObjectClasses.LaboratoryResultUnitDefinition _LaboratoryResultUnitDefinition
        {
            get { return (TTObjectClasses.LaboratoryResultUnitDefinition)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("94c17a0f-d23d-4c4a-a3af-2c723190535f"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("fde51ef0-60aa-4121-97ba-39ef05a7fe24"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("51b1bdc7-805f-49ee-a9b6-a911318b5f20"));
            base.InitializeControls();
        }

        public LaboratoryResultUnitDefinitionForm() : base("LABORATORYRESULTUNITDEFINITION", "LaboratoryResultUnitDefinitionForm")
        {
        }

        protected LaboratoryResultUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}