
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
    /// Ameliyat Kategorisi Tanımları
    /// </summary>
    public partial class SurgeryCategoryDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Ameliyat Kategorisi
    /// </summary>
        protected TTObjectClasses.SurgeryCategoryDefinition _SurgeryCategoryDefinition
        {
            get { return (TTObjectClasses.SurgeryCategoryDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("13815909-b703-426d-bba7-279342efb095"));
            Name = (ITTTextBox)AddControl(new Guid("c53ff525-cd69-45b0-a5a9-de107a3a31c1"));
            labelCode = (ITTLabel)AddControl(new Guid("05116ad5-ddc1-4ce7-ba23-709cba57eea6"));
            Code = (ITTTextBox)AddControl(new Guid("8c65d2f2-b336-43ba-9386-9d4645d4d004"));
            base.InitializeControls();
        }

        public SurgeryCategoryDefinitionForm() : base("SURGERYCATEGORYDEFINITION", "SurgeryCategoryDefinitionForm")
        {
        }

        protected SurgeryCategoryDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}