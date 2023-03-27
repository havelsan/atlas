
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
    /// Diş Protez Labaratuvar Tanımlama
    /// </summary>
    public partial class ToothProthesisLabDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Diş Protez Labaratuvar Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.ToothProthesisLabDefinition _ToothProthesisLabDefinition
        {
            get { return (TTObjectClasses.ToothProthesisLabDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("87b17a52-169b-4172-a5bf-1792e4688d27"));
            Name = (ITTTextBox)AddControl(new Guid("e4f0ec46-4092-4c84-a497-b3a0cdd30c78"));
            IsActive = (ITTCheckBox)AddControl(new Guid("9aa8a025-02a3-4b2b-b50c-69449af71120"));
            base.InitializeControls();
        }

        public ToothProthesisLabDefinitionForm() : base("TOOTHPROTHESISLABDEFINITION", "ToothProthesisLabDefinitionForm")
        {
        }

        protected ToothProthesisLabDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}