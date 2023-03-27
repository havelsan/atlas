
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
    /// Hasta Dosyası İçerik Tanımları
    /// </summary>
    public partial class PatientFolderContentDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Hasta Dosyası İçindekiler Tanımlama
    /// </summary>
        protected TTObjectClasses.PatientFolderContentDefinition _PatientFolderContentDefinition
        {
            get { return (TTObjectClasses.PatientFolderContentDefinition)_ttObject; }
        }

        protected ITTTextBox FileName;
        protected ITTLabel labelFileName;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            FileName = (ITTTextBox)AddControl(new Guid("654e0751-9520-46c3-a7d8-0585726e7721"));
            labelFileName = (ITTLabel)AddControl(new Guid("5f206f0d-0f35-485c-ae11-80b19a7497ba"));
            Active = (ITTCheckBox)AddControl(new Guid("32441cb2-bf81-4e07-8beb-e69465aca92e"));
            base.InitializeControls();
        }

        public PatientFolderContentDefinitionForm() : base("PATIENTFOLDERCONTENTDEFINITION", "PatientFolderContentDefinitionForm")
        {
        }

        protected PatientFolderContentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}