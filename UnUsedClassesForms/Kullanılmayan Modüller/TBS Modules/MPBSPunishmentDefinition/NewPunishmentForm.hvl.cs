
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
    /// Ceza Tanımlama
    /// </summary>
    public partial class NewPunishmentForm : TTForm
    {
    /// <summary>
    /// Ceza Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSPunishmentDefinition _MPBSPunishmentDefinition
        {
            get { return (TTObjectClasses.MPBSPunishmentDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("df819ff8-f262-443d-8a8b-2f9bda2c5ddf"));
            labelName = (ITTLabel)AddControl(new Guid("669c220d-9977-4925-b608-12cb3f5f00f8"));
            base.InitializeControls();
        }

        public NewPunishmentForm() : base("MPBSPUNISHMENTDEFINITION", "NewPunishmentForm")
        {
        }

        protected NewPunishmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}