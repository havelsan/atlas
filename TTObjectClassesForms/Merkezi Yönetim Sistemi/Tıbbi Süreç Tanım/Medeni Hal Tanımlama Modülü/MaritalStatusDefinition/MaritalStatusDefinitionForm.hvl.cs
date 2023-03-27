
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
    /// Medini Durum Tanım
    /// </summary>
    public partial class MaritalStatusDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Medeni Durum Tanımlama
    /// </summary>
        protected TTObjectClasses.MaritalStatusDefinition _MaritalStatusDefinition
        {
            get { return (TTObjectClasses.MaritalStatusDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("24488502-2e90-4561-9ceb-116096088dcc"));
            Name = (ITTTextBox)AddControl(new Guid("ff73b41c-2087-4c0d-b708-c696c9feede9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("28a26f28-0366-4ff1-abb7-53c3c751ff33"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("bbc4458a-cb2d-4773-9829-817ca928265f"));
            base.InitializeControls();
        }

        public MaritalStatusDefinitionForm() : base("MARITALSTATUSDEFINITION", "MaritalStatusDefinitionForm")
        {
        }

        protected MaritalStatusDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}