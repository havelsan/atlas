
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
    /// Hemşirelik Uygulamaları - Hasta ve Aile Eğitim Tanımları
    /// </summary>
    public partial class PatientAndFamilyInstructionDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.PatientAndFamilyInstructionDefinition _PatientAndFamilyInstructionDefinition
        {
            get { return (TTObjectClasses.PatientAndFamilyInstructionDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("8fb2c102-294f-469a-a488-7431abc75b76"));
            Name = (ITTTextBox)AddControl(new Guid("0a17608d-db9a-416c-9500-d55dfb4953f9"));
            Aktif = (ITTCheckBox)AddControl(new Guid("48a6ea5d-677e-41ad-af78-fb6625f3f079"));
            base.InitializeControls();
        }

        public PatientAndFamilyInstructionDefinitionForm() : base("PATIENTANDFAMILYINSTRUCTIONDEFINITION", "PatientAndFamilyInstructionDefinitionForm")
        {
        }

        protected PatientAndFamilyInstructionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}