
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
    /// Radyofarmasötik Birim Tanımları
    /// </summary>
    public partial class RadioPharmaceuticalUnitForm : TTDefinitionForm
    {
    /// <summary>
    /// Radyofarmasötik Birim Tanımları
    /// </summary>
        protected TTObjectClasses.RadioPharmaceuticalUnitDefinition _RadioPharmaceuticalUnitDefinition
        {
            get { return (TTObjectClasses.RadioPharmaceuticalUnitDefinition)_ttObject; }
        }

        protected ITTTextBox txtDescription;
        protected ITTLabel lblDescription;
        protected ITTTextBox txtName;
        protected ITTLabel lblName;
        override protected void InitializeControls()
        {
            txtDescription = (ITTTextBox)AddControl(new Guid("55e57c8e-6614-4b97-8eca-559bf24f00e1"));
            lblDescription = (ITTLabel)AddControl(new Guid("00d2bb5f-ef21-4494-8ed9-a2b3ef6ab256"));
            txtName = (ITTTextBox)AddControl(new Guid("6ec5f173-8b25-4bca-9438-0a5d5de804f7"));
            lblName = (ITTLabel)AddControl(new Guid("b17268fd-4540-42af-8290-d3be61f8ea48"));
            base.InitializeControls();
        }

        public RadioPharmaceuticalUnitForm() : base("RADIOPHARMACEUTICALUNITDEFINITION", "RadioPharmaceuticalUnitForm")
        {
        }

        protected RadioPharmaceuticalUnitForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}