
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
    /// Radyoloji Tetkik Alt Tür Tanımı
    /// </summary>
    public partial class RadiologyTestSubTypeForm : TTForm
    {
    /// <summary>
    /// Radyoloji Tetkik Alt Tür Tanımları
    /// </summary>
        protected TTObjectClasses.RadiologyTestSubTypeDefinition _RadiologyTestSubTypeDefinition
        {
            get { return (TTObjectClasses.RadiologyTestSubTypeDefinition)_ttObject; }
        }

        protected ITTTextBox Id;
        protected ITTLabel labelName;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTLabel labelDescription;
        protected ITTLabel labelId;
        override protected void InitializeControls()
        {
            Id = (ITTTextBox)AddControl(new Guid("e4d8bfd8-64cd-4c08-a2e7-04a6d365194f"));
            labelName = (ITTLabel)AddControl(new Guid("88c4f912-7e9f-4499-b197-2b2726ddbcba"));
            Description = (ITTTextBox)AddControl(new Guid("496bd12c-483e-41e2-b081-725850339426"));
            Name = (ITTTextBox)AddControl(new Guid("93081568-c883-4244-90cf-5f2b51ed23a9"));
            labelDescription = (ITTLabel)AddControl(new Guid("e7e35027-9278-4199-98ad-768b31feaeed"));
            labelId = (ITTLabel)AddControl(new Guid("1ca21103-a083-4521-8e2c-abf0c5b1e0cd"));
            base.InitializeControls();
        }

        public RadiologyTestSubTypeForm() : base("RADIOLOGYTESTSUBTYPEDEFINITION", "RadiologyTestSubTypeForm")
        {
        }

        protected RadiologyTestSubTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}