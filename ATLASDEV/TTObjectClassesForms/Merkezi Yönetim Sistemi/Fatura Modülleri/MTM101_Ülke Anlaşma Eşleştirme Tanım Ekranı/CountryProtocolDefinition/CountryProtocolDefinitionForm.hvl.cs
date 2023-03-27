
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
    /// Ülke Anlaşma Eşleştirme Tanım Ekranı
    /// </summary>
    public partial class CountryProtocolDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Ülke Anlaşma Eşleştirme Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.CountryProtocolDefinition _CountryProtocolDefinition
        {
            get { return (TTObjectClasses.CountryProtocolDefinition)_ttObject; }
        }

        protected ITTEnumComboBox PatientType;
        protected ITTObjectListBox Country;
        protected ITTLabel labelCountry;
        protected ITTLabel labelProtocol;
        protected ITTObjectListBox Protocol;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ProtocolUniversity;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            PatientType = (ITTEnumComboBox)AddControl(new Guid("f439a1fb-9617-4d14-a09d-14c3259eb82d"));
            Country = (ITTObjectListBox)AddControl(new Guid("cd886fee-7617-4675-a67d-2271e3256783"));
            labelCountry = (ITTLabel)AddControl(new Guid("92bb08ae-ebcb-44fc-b7a3-5a422bbc5f85"));
            labelProtocol = (ITTLabel)AddControl(new Guid("ffd21733-db9b-441b-92c3-dbd24c2bee02"));
            Protocol = (ITTObjectListBox)AddControl(new Guid("ac2ee931-0621-4d35-a926-32dc8dba4696"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("389dc419-31a7-4ba0-a668-5ea1b533a1c5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3679cfd3-8d7b-4a1e-a1bc-625fc2e2a891"));
            ProtocolUniversity = (ITTObjectListBox)AddControl(new Guid("37383256-5804-4c96-aea3-ebd269128160"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("489d6c7b-e58d-49b1-b8c9-91d189d9ce53"));
            base.InitializeControls();
        }

        public CountryProtocolDefinitionForm() : base("COUNTRYPROTOCOLDEFINITION", "CountryProtocolDefinitionForm")
        {
        }

        protected CountryProtocolDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}