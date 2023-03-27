
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
    public partial class PatientHistoryDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hasta Özgeçmiş tanım objesi
    /// </summary>
        protected TTObjectClasses.PatientHistoryDefinition _PatientHistoryDefinition
        {
            get { return (TTObjectClasses.PatientHistoryDefinition)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("eb8c2f05-efdf-429c-a905-89b360309fe9"));
            Description = (ITTTextBox)AddControl(new Guid("b503709f-a746-429e-bf4b-267c196e120c"));
            Name = (ITTTextBox)AddControl(new Guid("ac642c1e-f95b-47fa-b4a0-10b22d848adc"));
            labelName = (ITTLabel)AddControl(new Guid("b5714307-87b4-4fd6-b6ac-5211641ea2ed"));
            base.InitializeControls();
        }

        public PatientHistoryDefinitionForm() : base("PATIENTHISTORYDEFINITION", "PatientHistoryDefinitionForm")
        {
        }

        protected PatientHistoryDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}