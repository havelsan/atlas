
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
    /// Kan Grubu Tanımlama Formu
    /// </summary>
    public partial class BloodGroupDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Kan Grubu Tanımlama
    /// </summary>
        protected TTObjectClasses.BloodGroupDefinition _BloodGroupDefinition
        {
            get { return (TTObjectClasses.BloodGroupDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelExternalCode;
        protected ITTTextBox ExternalCode;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("852a784e-15dd-43ad-a670-dc185af0a76a"));
            Name = (ITTTextBox)AddControl(new Guid("7e598d79-0270-4e60-a258-ce2f02e1932d"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("3528251b-616c-4499-9de0-e6087dab4ea6"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("4e28f180-c4fb-4719-960f-1d158413b06c"));
            base.InitializeControls();
        }

        public BloodGroupDefinitionForm() : base("BLOODGROUPDEFINITION", "BloodGroupDefinitionForm")
        {
        }

        protected BloodGroupDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}