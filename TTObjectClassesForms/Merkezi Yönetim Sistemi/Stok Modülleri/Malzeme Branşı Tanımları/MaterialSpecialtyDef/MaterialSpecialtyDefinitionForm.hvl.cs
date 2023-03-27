
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
    /// Malzeme Branş Tanımı
    /// </summary>
    public partial class MaterialSpecialtyDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Malzeme Branşı Tanımı
    /// </summary>
        protected TTObjectClasses.MaterialSpecialtyDef _MaterialSpecialtyDef
        {
            get { return (TTObjectClasses.MaterialSpecialtyDef)_ttObject; }
        }

        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelCode = (ITTLabel)AddControl(new Guid("2e5ed27b-6119-448e-9dcf-042e4c977156"));
            Code = (ITTTextBox)AddControl(new Guid("e27cb043-4fbf-47ab-b74d-3bf838e0f809"));
            Name = (ITTTextBox)AddControl(new Guid("68d1e90e-9cd9-4104-82a6-20081b62a44e"));
            labelName = (ITTLabel)AddControl(new Guid("147f053c-f6ba-45e9-893d-9fc4e198dd02"));
            base.InitializeControls();
        }

        public MaterialSpecialtyDefinitionForm() : base("MATERIALSPECIALTYDEF", "MaterialSpecialtyDefinitionForm")
        {
        }

        protected MaterialSpecialtyDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}