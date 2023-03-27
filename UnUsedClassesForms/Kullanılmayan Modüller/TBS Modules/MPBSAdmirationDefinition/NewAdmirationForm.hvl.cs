
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
    /// Takdir Türü Tanımlama
    /// </summary>
    public partial class NewAdmirationForm : TTForm
    {
    /// <summary>
    /// Takdir Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSAdmirationDefinition _MPBSAdmirationDefinition
        {
            get { return (TTObjectClasses.MPBSAdmirationDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("ede67ce1-a56d-4656-8373-1b0401f70316"));
            labelCode = (ITTLabel)AddControl(new Guid("9d9e849f-a922-40f1-a722-1d5ab95aa068"));
            Name = (ITTTextBox)AddControl(new Guid("89b64645-a536-4d69-b3e5-ed32947759e2"));
            Code = (ITTTextBox)AddControl(new Guid("11bf8e55-5368-4865-abf3-fde1e49cfa7e"));
            base.InitializeControls();
        }

        public NewAdmirationForm() : base("MPBSADMIRATIONDEFINITION", "NewAdmirationForm")
        {
        }

        protected NewAdmirationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}