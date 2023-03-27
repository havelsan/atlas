
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
    /// Radyoloji Tetkik Açıklama Tanımları
    /// </summary>
    public partial class RadiologyTestDescriptionDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Radyoloji Tetkik Açıklama Tanımları
    /// </summary>
        protected TTObjectClasses.RadiologyTestDescriptionDefinition _RadiologyTestDescriptionDefinition
        {
            get { return (TTObjectClasses.RadiologyTestDescriptionDefinition)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTTextBox Name;
        protected ITTCheckBox ISACTIVE;
        protected ITTLabel labelOrderNo;
        protected ITTLabel labelDescription;
        protected ITTTextBox OrderNo;
        protected ITTLabel labelName;
        protected ITTCheckBox Bold;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("9157e576-1838-46c3-adea-6cda353dc367"));
            Name = (ITTTextBox)AddControl(new Guid("509d6e6a-d01a-4b2d-9abe-2a99761a71ab"));
            ISACTIVE = (ITTCheckBox)AddControl(new Guid("43f6e451-d5ba-4117-9e85-2e05ebcfbe65"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("4b1e3051-22d1-42b3-9fa6-2e96f888568e"));
            labelDescription = (ITTLabel)AddControl(new Guid("a6f6303e-6b98-442c-8fb1-3117a5f4512a"));
            OrderNo = (ITTTextBox)AddControl(new Guid("3958a8f3-0cbe-40fb-8933-385ea85494a9"));
            labelName = (ITTLabel)AddControl(new Guid("4a180876-276e-4dac-85f5-58e235fc61f8"));
            Bold = (ITTCheckBox)AddControl(new Guid("1c753cd0-5fa1-4c67-a7b1-ccbfdbf07a59"));
            base.InitializeControls();
        }

        public RadiologyTestDescriptionDefinitionForm() : base("RADIOLOGYTESTDESCRIPTIONDEFINITION", "RadiologyTestDescriptionDefinitionForm")
        {
        }

        protected RadiologyTestDescriptionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}