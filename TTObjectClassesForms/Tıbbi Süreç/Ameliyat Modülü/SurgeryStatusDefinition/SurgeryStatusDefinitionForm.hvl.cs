
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
    /// Ameliyat Durumu Tanımlama
    /// </summary>
    public partial class SurgeryStatusDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Ameliyat Durumu Tanımlama
    /// </summary>
        protected TTObjectClasses.SurgeryStatusDefinition _SurgeryStatusDefinition
        {
            get { return (TTObjectClasses.SurgeryStatusDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("ea44341b-0d2c-4510-bf5d-9f886565dfcc"));
            Name = (ITTTextBox)AddControl(new Guid("84c6958f-115b-41ac-85a7-224f1f49baee"));
            Aktif = (ITTCheckBox)AddControl(new Guid("349f71fe-4d06-4860-b1de-02c0d9cd32c2"));
            base.InitializeControls();
        }

        public SurgeryStatusDefinitionForm() : base("SURGERYSTATUSDEFINITION", "SurgeryStatusDefinitionForm")
        {
        }

        protected SurgeryStatusDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}