
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
    /// Radyoloji Kategori Tanımları
    /// </summary>
    public partial class RadiologyTabDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Radyoloji İstek Ekran Tanımları
    /// </summary>
        protected TTObjectClasses.RadiologyTabDefinition _RadiologyTabDefinition
        {
            get { return (TTObjectClasses.RadiologyTabDefinition)_ttObject; }
        }

        protected ITTCheckBox ISACTIVE;
        protected ITTLabel labelName;
        protected ITTTextBox TabDescription;
        protected ITTTextBox TabOrder;
        protected ITTTextBox Name;
        protected ITTLabel labelTabOrder;
        protected ITTLabel labelTabDescription;
        protected ITTObjectListBox Department;
        protected ITTLabel lblDepartment;
        override protected void InitializeControls()
        {
            ISACTIVE = (ITTCheckBox)AddControl(new Guid("2491c463-b4f5-4dea-8d90-34b2c8af3a1d"));
            labelName = (ITTLabel)AddControl(new Guid("5d4c1dda-7cfb-4f6b-a2c1-4ac38146c34e"));
            TabDescription = (ITTTextBox)AddControl(new Guid("94570356-05b3-4b39-a068-982b04f1f2a5"));
            TabOrder = (ITTTextBox)AddControl(new Guid("7a1b90dc-939f-4642-b1df-9efecebe596b"));
            Name = (ITTTextBox)AddControl(new Guid("889d3cf7-b1dc-4e8a-8b5e-cec99fc26cfa"));
            labelTabOrder = (ITTLabel)AddControl(new Guid("5de639bf-22ee-4756-aaaf-b0d6db61b650"));
            labelTabDescription = (ITTLabel)AddControl(new Guid("a9aa8429-e2e3-4cb1-ad70-d8a0ca8a2aa8"));
            Department = (ITTObjectListBox)AddControl(new Guid("e13a32cb-bc00-4676-9798-25c558db755d"));
            lblDepartment = (ITTLabel)AddControl(new Guid("e885866d-9e55-4f94-859c-76466cfca51e"));
            base.InitializeControls();
        }

        public RadiologyTabDefinitionForm() : base("RADIOLOGYTABDEFINITION", "RadiologyTabDefinitionForm")
        {
        }

        protected RadiologyTabDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}