
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
    /// Cinsiyet Tanımlama Formu
    /// </summary>
    public partial class SexDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Cinsiyet Tanımlama
    /// </summary>
        protected TTObjectClasses.SexDefinition _SexDefinition
        {
            get { return (TTObjectClasses.SexDefinition)_ttObject; }
        }

        protected ITTLabel labelExternalCode;
        protected ITTTextBox ExternalCode;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelExternalCode = (ITTLabel)AddControl(new Guid("f882781a-4446-4fa2-936f-53986e8c45e7"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("b824fc33-5fa7-4205-9451-f6e1a17db8b2"));
            labelName = (ITTLabel)AddControl(new Guid("39d4a939-f345-48c9-8df0-55f401128ee2"));
            Name = (ITTTextBox)AddControl(new Guid("b22f59b2-e0c4-427d-bdd4-eedef2f5ecfa"));
            base.InitializeControls();
        }

        public SexDefinitionForm() : base("SEXDEFINITION", "SexDefinitionForm")
        {
        }

        protected SexDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}