
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
    /// Ana Bilim Dalı Tanımlama
    /// </summary>
    public partial class NewMainMajorForm : TTForm
    {
    /// <summary>
    /// Ana Bilim Dalı Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSMainMajorDefinition _MPBSMainMajorDefinition
        {
            get { return (TTObjectClasses.MPBSMainMajorDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("47787b63-6103-40bc-b4b4-544fe2c4af0d"));
            Name = (ITTTextBox)AddControl(new Guid("4e68336c-bff0-4f9b-bca0-dfcdc0c6043c"));
            base.InitializeControls();
        }

        public NewMainMajorForm() : base("MPBSMAINMAJORDEFINITION", "NewMainMajorForm")
        {
        }

        protected NewMainMajorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}