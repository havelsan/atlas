
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
    /// Diş Takımı Tanımları
    /// </summary>
    public partial class DentalSetDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Diş Takım Tanımları
    /// </summary>
        protected TTObjectClasses.DentalSetDefinition _DentalSetDefinition
        {
            get { return (TTObjectClasses.DentalSetDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelInheld;
        protected ITTTextBox Inheld;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("c5dff212-96f9-4ed4-82bb-0044983f24c0"));
            Name = (ITTTextBox)AddControl(new Guid("61e34c59-2712-4e5c-b5a4-8f0d35736f7a"));
            labelInheld = (ITTLabel)AddControl(new Guid("e0acb3c8-9f54-41f6-ae32-8a8d7463d21f"));
            Inheld = (ITTTextBox)AddControl(new Guid("3cb55c08-1a48-447b-a4d2-8a73f4ccd2ae"));
            labelCode = (ITTLabel)AddControl(new Guid("25a571a5-4ac8-487e-beef-9119297d1e92"));
            Code = (ITTTextBox)AddControl(new Guid("d1b66dd8-3e34-42aa-b7dd-f89bb8920045"));
            base.InitializeControls();
        }

        public DentalSetDefinitionForm() : base("DENTALSETDEFINITION", "DentalSetDefinitionForm")
        {
        }

        protected DentalSetDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}