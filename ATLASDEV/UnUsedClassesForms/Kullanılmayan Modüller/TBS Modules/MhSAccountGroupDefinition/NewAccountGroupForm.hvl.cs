
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
    /// Hesap Grubu Tanımlama
    /// </summary>
    public partial class NewAccountGroupForm : TTForm
    {
    /// <summary>
    /// Hesap Grubu
    /// </summary>
        protected TTObjectClasses.MhSAccountGroupDefinition _MhSAccountGroupDefinition
        {
            get { return (TTObjectClasses.MhSAccountGroupDefinition)_ttObject; }
        }

        protected ITTEnumComboBox Level;
        protected ITTLabel labelLevel;
        protected ITTLabel labelCode;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            Level = (ITTEnumComboBox)AddControl(new Guid("5d14cc0f-de3b-49e1-a052-14f3532b54ea"));
            labelLevel = (ITTLabel)AddControl(new Guid("e956a3d5-323f-4ebe-82f5-56322e04639a"));
            labelCode = (ITTLabel)AddControl(new Guid("3b7fd5ce-33f9-4de9-897b-5cd7449c729b"));
            Name = (ITTTextBox)AddControl(new Guid("e2fc88b5-a7e6-485f-adc3-aeca33f70dd0"));
            Code = (ITTTextBox)AddControl(new Guid("5cab6caa-b6ef-4588-b4fa-b1e664a27ff7"));
            labelName = (ITTLabel)AddControl(new Guid("8260eacb-9124-47fe-a663-e36ffa2a763f"));
            base.InitializeControls();
        }

        public NewAccountGroupForm() : base("MHSACCOUNTGROUPDEFINITION", "NewAccountGroupForm")
        {
        }

        protected NewAccountGroupForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}