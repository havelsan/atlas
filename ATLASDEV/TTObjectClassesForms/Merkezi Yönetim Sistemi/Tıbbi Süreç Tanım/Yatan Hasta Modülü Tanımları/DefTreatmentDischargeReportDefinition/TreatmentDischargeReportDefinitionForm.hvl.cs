
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
    /// New Form
    /// </summary>
    public partial class TreatmentDischargeReportDefinitionForm : TTForm
    {
        protected TTObjectClasses.DefTreatmentDischargeReportDefinition _DefTreatmentDischargeReportDefinition
        {
            get { return (TTObjectClasses.DefTreatmentDischargeReportDefinition)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Type;
        protected ITTTextBox Code;
        protected ITTLabel labelType;
        protected ITTTextBox Description;
        protected ITTTextBox Value;
        protected ITTLabel labelValue;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("85cc4ef6-0ca3-4c78-94b9-16d555e3eda4"));
            Type = (ITTTextBox)AddControl(new Guid("bf366320-71e2-4b8b-b984-3af304bae2e2"));
            Code = (ITTTextBox)AddControl(new Guid("25972930-1522-4e80-965c-51e99d3d77bc"));
            labelType = (ITTLabel)AddControl(new Guid("b7367f11-6db8-4351-8aae-6a8f889b3af6"));
            Description = (ITTTextBox)AddControl(new Guid("0b756b55-793c-455a-89a8-6ac95ebedd73"));
            Value = (ITTTextBox)AddControl(new Guid("56a3679d-4be3-4b51-9004-6e2384a7c34a"));
            labelValue = (ITTLabel)AddControl(new Guid("85d6e08d-bc62-435b-ab85-9a735de85a8b"));
            IsActive = (ITTCheckBox)AddControl(new Guid("3fd31de9-616d-4ef4-a6bb-b0cd437b3ab3"));
            labelCode = (ITTLabel)AddControl(new Guid("98cfa9ed-6558-47e4-9fd9-e90afd66732b"));
            base.InitializeControls();
        }

        public TreatmentDischargeReportDefinitionForm() : base("DEFTREATMENTDISCHARGEREPORTDEFINITION", "TreatmentDischargeReportDefinitionForm")
        {
        }

        protected TreatmentDischargeReportDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}