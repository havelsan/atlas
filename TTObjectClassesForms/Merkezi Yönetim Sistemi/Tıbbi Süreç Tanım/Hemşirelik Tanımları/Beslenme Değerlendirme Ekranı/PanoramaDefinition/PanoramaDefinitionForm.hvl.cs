
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
    public partial class PanoramaDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.PanoramaDefinition _PanoramaDefinition
        {
            get { return (TTObjectClasses.PanoramaDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("68ef966c-d1f0-4101-9975-4907f83072e0"));
            Name = (ITTTextBox)AddControl(new Guid("b3acafe1-e981-4659-8f35-03df144ca062"));
            Aktif = (ITTCheckBox)AddControl(new Guid("fa914569-9456-434f-8680-5aac2f90082b"));
            base.InitializeControls();
        }

        public PanoramaDefinitionForm() : base("PANORAMADEFINITION", "PanoramaDefinitionForm")
        {
        }

        protected PanoramaDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}