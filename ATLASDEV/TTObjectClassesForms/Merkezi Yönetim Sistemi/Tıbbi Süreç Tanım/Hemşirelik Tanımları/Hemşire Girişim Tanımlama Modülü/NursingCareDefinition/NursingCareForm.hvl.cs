
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
    /// Hemşirelik Uygulamaları -Nanda Girişim Tanımları
    /// </summary>
    public partial class NursingCareForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hemşirelik Girişimi Tanımlama
    /// </summary>
        protected TTObjectClasses.NursingCareDefinition _NursingCareDefinition
        {
            get { return (TTObjectClasses.NursingCareDefinition)_ttObject; }
        }

        protected ITTLabel labelNursingCare;
        protected ITTTextBox NursingCare;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelNursingCare = (ITTLabel)AddControl(new Guid("13d9f6e5-97b1-47f5-9d1f-965554e4058d"));
            NursingCare = (ITTTextBox)AddControl(new Guid("293363ce-f6e3-413e-b4e3-e784f8c16912"));
            Aktif = (ITTCheckBox)AddControl(new Guid("2660a4f2-c846-4203-8a3e-240b6c14bd1e"));
            base.InitializeControls();
        }

        public NursingCareForm() : base("NURSINGCAREDEFINITION", "NursingCareForm")
        {
        }

        protected NursingCareForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}