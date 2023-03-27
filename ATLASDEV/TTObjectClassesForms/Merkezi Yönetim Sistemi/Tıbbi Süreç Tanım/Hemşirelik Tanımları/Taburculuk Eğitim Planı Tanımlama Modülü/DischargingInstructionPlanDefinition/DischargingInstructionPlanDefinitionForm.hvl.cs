
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
    /// Hemşirelik Uygulamaları - Taburculuk Eğitim Planı Tanımları
    /// </summary>
    public partial class DischargingInstructionPlanDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.DischargingInstructionPlanDefinition _DischargingInstructionPlanDefinition
        {
            get { return (TTObjectClasses.DischargingInstructionPlanDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("9854a11c-35f6-44db-b5b1-20c89381e377"));
            Name = (ITTTextBox)AddControl(new Guid("1bf9600c-f8d3-4349-9ab4-3bfecf04df42"));
            Aktif = (ITTCheckBox)AddControl(new Guid("8c7be57b-7d36-409f-b71d-58627b60588b"));
            base.InitializeControls();
        }

        public DischargingInstructionPlanDefinitionForm() : base("DISCHARGINGINSTRUCTIONPLANDEFINITION", "DischargingInstructionPlanDefinitionForm")
        {
        }

        protected DischargingInstructionPlanDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}