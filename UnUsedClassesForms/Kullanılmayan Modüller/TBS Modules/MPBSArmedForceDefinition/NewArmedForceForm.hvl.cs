
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
    /// Kuvvet Tanımlama
    /// </summary>
    public partial class NewArmedForceForm : TTForm
    {
    /// <summary>
    /// Kuvvet Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSArmedForceDefinition _MPBSArmedForceDefinition
        {
            get { return (TTObjectClasses.MPBSArmedForceDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("94d5c4b7-e51d-41d2-af63-73e11daef711"));
            Name = (ITTTextBox)AddControl(new Guid("953992d9-bdd3-4eae-a608-77aee43630b9"));
            base.InitializeControls();
        }

        public NewArmedForceForm() : base("MPBSARMEDFORCEDEFINITION", "NewArmedForceForm")
        {
        }

        protected NewArmedForceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}