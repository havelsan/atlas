
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
    /// Laboratuvar Etken Madde Grup Tanım Formu
    /// </summary>
    public partial class LaboratoryIngredientGroupDefinitionForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Etken Madde Grup Tanımı
    /// </summary>
        protected TTObjectClasses.LaboratoryIngredientGroupDefinition _LaboratoryIngredientGroupDefinition
        {
            get { return (TTObjectClasses.LaboratoryIngredientGroupDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("c8facbd3-ff7e-457e-aab6-1cee8d2fb1ba"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("c0ed09df-71f8-400b-a56a-5e00630c5039"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("96589adf-49c2-4f63-ac99-e0f627b4c6a5"));
            base.InitializeControls();
        }

        public LaboratoryIngredientGroupDefinitionForm() : base("LABORATORYINGREDIENTGROUPDEFINITION", "LaboratoryIngredientGroupDefinitionForm")
        {
        }

        protected LaboratoryIngredientGroupDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}