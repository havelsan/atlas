
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
    /// Sınıf Tanımlama
    /// </summary>
    public partial class MilitaryClassDefinitionsForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// XXXXXX Sınıf Tanımlama
    /// </summary>
        protected TTObjectClasses.MilitaryClassDefinitions _MilitaryClassDefinitions
        {
            get { return (TTObjectClasses.MilitaryClassDefinitions)_ttObject; }
        }

        protected ITTLabel labelExternalCode;
        protected ITTTextBox ExternalCode;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelExternalCode = (ITTLabel)AddControl(new Guid("16168f3b-edeb-410d-8420-df5063841438"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("fb4c1fcc-00f5-4d40-b7c0-d2633152ecc8"));
            Name = (ITTTextBox)AddControl(new Guid("ea25099b-e34f-4365-b6b8-e58958b46fef"));
            Code = (ITTTextBox)AddControl(new Guid("d6852a17-3ad0-4102-b852-3ed6a323169f"));
            labelName = (ITTLabel)AddControl(new Guid("8e268059-f89a-4ec1-abb6-92cdf832ce49"));
            labelCode = (ITTLabel)AddControl(new Guid("ed36d294-c09d-4e24-8f5c-563b31b86b3e"));
            IsActive = (ITTCheckBox)AddControl(new Guid("e6aebfe7-8e87-4405-ac09-f4f10a4b9809"));
            base.InitializeControls();
        }

        public MilitaryClassDefinitionsForm() : base("MILITARYCLASSDEFINITIONS", "MilitaryClassDefinitionsForm")
        {
        }

        protected MilitaryClassDefinitionsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}