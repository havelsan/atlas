
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
    /// Yeni Birlik Tanımlama
    /// </summary>
    public partial class NewUnitForm : TTForm
    {
    /// <summary>
    /// Birlik Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSUnitDefinition _MPBSUnitDefinition
        {
            get { return (TTObjectClasses.MPBSUnitDefinition)_ttObject; }
        }

        protected ITTCheckBox Active;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            Active = (ITTCheckBox)AddControl(new Guid("8df064e2-87d0-4624-8987-07c00f6693fd"));
            labelName = (ITTLabel)AddControl(new Guid("4bcebb38-d520-479c-8889-2fb47898eae0"));
            Name = (ITTTextBox)AddControl(new Guid("133e8b9d-3f58-4526-b40e-66a539e04ca1"));
            base.InitializeControls();
        }

        public NewUnitForm() : base("MPBSUNITDEFINITION", "NewUnitForm")
        {
        }

        protected NewUnitForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}