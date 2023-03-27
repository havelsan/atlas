
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
    /// Garnizon Tanımlama
    /// </summary>
    public partial class NewGarrisonForm : TTForm
    {
    /// <summary>
    /// Garnizon Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSGarrisonDefinition _MPBSGarrisonDefinition
        {
            get { return (TTObjectClasses.MPBSGarrisonDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("c483b10a-044d-4896-96d6-19f40ab777ba"));
            Name = (ITTTextBox)AddControl(new Guid("d4fe7020-84b6-4d33-a813-38b4be8433b7"));
            base.InitializeControls();
        }

        public NewGarrisonForm() : base("MPBSGARRISONDEFINITION", "NewGarrisonForm")
        {
        }

        protected NewGarrisonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}