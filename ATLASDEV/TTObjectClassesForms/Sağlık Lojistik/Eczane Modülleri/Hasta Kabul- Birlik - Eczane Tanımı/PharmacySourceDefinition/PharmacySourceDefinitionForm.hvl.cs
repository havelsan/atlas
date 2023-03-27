
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
    /// Hasta Kabul- Birlik - Eczane Tanımı
    /// </summary>
    public partial class PharmacySourceDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Hasta Kabul- Birlik - Eczane Tanımı
    /// </summary>
        protected TTObjectClasses.PharmacySourceDefinition _PharmacySourceDefinition
        {
            get { return (TTObjectClasses.PharmacySourceDefinition)_ttObject; }
        }

        protected ITTCheckBox AllMilitaryUnit;
        protected ITTGrid PharmacySourceMilitaryUnits;
        protected ITTListBoxColumn MilitaryUnitPharmacySourceMilitaryUnit;
        protected ITTLabel labelPatientGroup;
        protected ITTEnumComboBox PatientGroup;
        override protected void InitializeControls()
        {
            AllMilitaryUnit = (ITTCheckBox)AddControl(new Guid("9eecc605-7952-4c6b-8a92-c8ef6bc08cf7"));
            PharmacySourceMilitaryUnits = (ITTGrid)AddControl(new Guid("6977770a-3e55-48e0-83aa-eae25137c487"));
            MilitaryUnitPharmacySourceMilitaryUnit = (ITTListBoxColumn)AddControl(new Guid("fda6997a-2cd0-4177-a8a4-21ea14cf5d40"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("417b400f-e569-450d-ada6-3a620e6aac1b"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("99d3e058-70b3-4bb9-8163-6e4a91a48764"));
            base.InitializeControls();
        }

        public PharmacySourceDefinitionForm() : base("PHARMACYSOURCEDEFINITION", "PharmacySourceDefinitionForm")
        {
        }

        protected PharmacySourceDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}