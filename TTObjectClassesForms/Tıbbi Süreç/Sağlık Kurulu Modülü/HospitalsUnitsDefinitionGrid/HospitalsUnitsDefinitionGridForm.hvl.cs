
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
    /// Muayene Edecek Birimler/XXXXXXler  
    /// </summary>
    public partial class HospitalsUnitsDefinitionGridForm : TTForm
    {
    /// <summary>
    /// Muayene Edecek Birimler/XXXXXXler  
    /// </summary>
        protected TTObjectClasses.HospitalsUnitsDefinitionGrid _HospitalsUnitsDefinitionGrid
        {
            get { return (TTObjectClasses.HospitalsUnitsDefinitionGrid)_ttObject; }
        }

        protected ITTLabel labelPolicklinic;
        protected ITTObjectListBox Policklinic;
        protected ITTObjectListBox ActionTemplate;
        protected ITTLabel labelMaxOld;
        protected ITTTextBox MinOld;
        protected ITTTextBox MaxOld;
        protected ITTLabel labelMinOld;
        protected ITTLabel labelSex;
        protected ITTEnumComboBox Sex;
        protected ITTLabel labelTemplateDefinition;
        override protected void InitializeControls()
        {
            labelPolicklinic = (ITTLabel)AddControl(new Guid("c7994374-e9f8-4237-9a80-a9506dc2eeb0"));
            Policklinic = (ITTObjectListBox)AddControl(new Guid("f390c388-84e6-490b-8f95-5edeb41854c7"));
            ActionTemplate = (ITTObjectListBox)AddControl(new Guid("44ff9ddd-43af-43ea-8803-b45e57cca8e5"));
            labelMaxOld = (ITTLabel)AddControl(new Guid("5db24445-356e-42c3-a546-04796706542d"));
            MinOld = (ITTTextBox)AddControl(new Guid("467296c1-f259-4d7f-bce4-1e76ba636652"));
            MaxOld = (ITTTextBox)AddControl(new Guid("485e338c-0c7f-40a4-9aaf-d446e51c3100"));
            labelMinOld = (ITTLabel)AddControl(new Guid("fd44faf1-b220-4ff7-b016-5beabac2c8ce"));
            labelSex = (ITTLabel)AddControl(new Guid("d3f29931-6ef6-43de-9ceb-9fc120fcf64b"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("476d3144-264d-4b58-b583-c32803ba636b"));
            labelTemplateDefinition = (ITTLabel)AddControl(new Guid("3f44f8b9-f438-4e22-af4d-eeeec77d479c"));
            base.InitializeControls();
        }

        public HospitalsUnitsDefinitionGridForm() : base("HOSPITALSUNITSDEFINITIONGRID", "HospitalsUnitsDefinitionGridForm")
        {
        }

        protected HospitalsUnitsDefinitionGridForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}