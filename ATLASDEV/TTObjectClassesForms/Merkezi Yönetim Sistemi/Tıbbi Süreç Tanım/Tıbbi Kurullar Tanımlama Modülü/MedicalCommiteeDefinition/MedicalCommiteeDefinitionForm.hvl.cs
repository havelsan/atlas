
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
    /// Tıbbi Kurullar Tanımlama
    /// </summary>
    public partial class MedicalCommiteeDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Tıbbi Kurullar Tanımlama
    /// </summary>
        protected TTObjectClasses.MedicalCommiteeDefinition _MedicalCommiteeDefinition
        {
            get { return (TTObjectClasses.MedicalCommiteeDefinition)_ttObject; }
        }

        protected ITTObjectListBox Resource;
        protected ITTLabel labelResource;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTLabel labelType;
        protected ITTTextBox Type;
        override protected void InitializeControls()
        {
            Resource = (ITTObjectListBox)AddControl(new Guid("4c7e7ed3-1578-4c7e-9610-2b169e1c8564"));
            labelResource = (ITTLabel)AddControl(new Guid("0e07d5e7-9636-41bb-adaf-3cff37bd87a6"));
            labelCode = (ITTLabel)AddControl(new Guid("116e01e1-007d-4fe7-9db3-62ed7c958b6b"));
            Code = (ITTTextBox)AddControl(new Guid("2e43279f-a271-4e0e-9859-9f55cf837f75"));
            labelType = (ITTLabel)AddControl(new Guid("2ae657e4-56b6-4856-aeca-dbae44f7158b"));
            Type = (ITTTextBox)AddControl(new Guid("c31a08c1-a534-4627-8cb6-f4e627c7d156"));
            base.InitializeControls();
        }

        public MedicalCommiteeDefinitionForm() : base("MEDICALCOMMITEEDEFINITION", "MedicalCommiteeDefinitionForm")
        {
        }

        protected MedicalCommiteeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}