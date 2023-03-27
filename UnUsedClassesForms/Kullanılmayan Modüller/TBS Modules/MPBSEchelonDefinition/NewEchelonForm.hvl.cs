
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
    /// Kademe Tanımlama
    /// </summary>
    public partial class NewEchelonForm : TTForm
    {
    /// <summary>
    /// Kademe Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSEchelonDefinition _MPBSEchelonDefinition
        {
            get { return (TTObjectClasses.MPBSEchelonDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("df8d4d31-6ced-458d-a0a7-7e987f005201"));
            Name = (ITTTextBox)AddControl(new Guid("714182e1-5de6-4c5d-8f4c-9cce2eeec67e"));
            base.InitializeControls();
        }

        public NewEchelonForm() : base("MPBSECHELONDEFINITION", "NewEchelonForm")
        {
        }

        protected NewEchelonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}