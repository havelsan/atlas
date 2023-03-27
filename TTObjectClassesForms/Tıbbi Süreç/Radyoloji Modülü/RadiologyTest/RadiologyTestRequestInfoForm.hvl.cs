
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
    public partial class RadiologyTestRequestInfoForm : TTForm
    {
    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
        protected TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get { return (TTObjectClasses.RadiologyTest)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTTextBox PreDiagnosis;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox Acil;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("f5df2f98-bf24-4a56-8663-183ade980bda"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("e298a741-5b68-4ee9-a951-b587fdcf9a7b"));
            Description = (ITTTextBox)AddControl(new Guid("f417e434-3950-46dd-a57a-26092c4c0a5d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("78a8e237-7ad1-4929-bfd8-4ba4d394f35c"));
            Acil = (ITTCheckBox)AddControl(new Guid("79abab57-8eec-40cc-aec1-5ab07317f100"));
            base.InitializeControls();
        }

        public RadiologyTestRequestInfoForm() : base("RADIOLOGYTEST", "RadiologyTestRequestInfoForm")
        {
        }

        protected RadiologyTestRequestInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}