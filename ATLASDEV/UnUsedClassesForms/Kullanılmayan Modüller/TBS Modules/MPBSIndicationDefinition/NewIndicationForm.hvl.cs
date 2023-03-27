
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
    /// Gösterge Tanımlama
    /// </summary>
    public partial class NewIndicationForm : TTForm
    {
    /// <summary>
    /// Gösterge Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSIndicationDefinition _MPBSIndicationDefinition
        {
            get { return (TTObjectClasses.MPBSIndicationDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("dd8b5631-30c8-4293-bd4f-3cc368d9495e"));
            labelName = (ITTLabel)AddControl(new Guid("c6e9d709-6f0e-4a31-ad38-44535089061c"));
            base.InitializeControls();
        }

        public NewIndicationForm() : base("MPBSINDICATIONDEFINITION", "NewIndicationForm")
        {
        }

        protected NewIndicationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}