
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
    /// Tahakkuk Birimi Tanımları
    /// </summary>
    public partial class AssessmentDepartmentDef : TTDefinitionForm
    {
    /// <summary>
    /// Tahakkuk Birimi Tanımları
    /// </summary>
        protected TTObjectClasses.AssessmentDepartmentDef _AssessmentDepartmentDef
        {
            get { return (TTObjectClasses.AssessmentDepartmentDef)_ttObject; }
        }

        protected ITTCheckBox activeChck;
        protected ITTLabel labelExternalCode;
        protected ITTTextBox ExternalCode;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            activeChck = (ITTCheckBox)AddControl(new Guid("69ea57bd-4a4a-4498-b989-1e971060eeea"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("10a8b79d-fb50-4cf5-a924-87f3688ad1fd"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("862870a4-93d1-4bdf-b58c-61d4f20f925e"));
            labelCode = (ITTLabel)AddControl(new Guid("9355c473-11f9-440f-b73f-62bd592a54cc"));
            Code = (ITTTextBox)AddControl(new Guid("af4876ef-1c66-4256-8aaa-6f9bcd1618cf"));
            labelName = (ITTLabel)AddControl(new Guid("9d778807-a0b6-4614-8653-70c05fdb8ace"));
            Name = (ITTTextBox)AddControl(new Guid("c700a987-e1bd-4c81-99a7-b6e92e850c5b"));
            base.InitializeControls();
        }

        public AssessmentDepartmentDef() : base("ASSESSMENTDEPARTMENTDEF", "AssessmentDepartmentDef")
        {
        }

        protected AssessmentDepartmentDef(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}