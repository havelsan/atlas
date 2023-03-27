
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
    /// Yeni Şube Tanımlama
    /// </summary>
    public partial class NewOfficeForm : TTForm
    {
    /// <summary>
    /// Şube Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSOfficeDefinition _MPBSOfficeDefinition
        {
            get { return (TTObjectClasses.MPBSOfficeDefinition)_ttObject; }
        }

        protected ITTCheckBox Active;
        protected ITTTextBox Name;
        protected ITTLabel labelUnit;
        protected ITTLabel labelName;
        protected ITTListDefComboBox ttlistdefcombobox1;
        override protected void InitializeControls()
        {
            Active = (ITTCheckBox)AddControl(new Guid("26d9ca22-6e2b-442d-93bf-050000f87c63"));
            Name = (ITTTextBox)AddControl(new Guid("58a13b29-c885-44f2-8722-2bb62a2002fa"));
            labelUnit = (ITTLabel)AddControl(new Guid("4afa730e-a481-4746-b8df-38bfb4594b8b"));
            labelName = (ITTLabel)AddControl(new Guid("35c4a141-d0d2-4f66-82d1-9b2154da2a26"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("d114bfd9-8c85-442e-9b0a-c022a1b21892"));
            base.InitializeControls();
        }

        public NewOfficeForm() : base("MPBSOFFICEDEFINITION", "NewOfficeForm")
        {
        }

        protected NewOfficeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}