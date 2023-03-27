
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
    /// Tertip Tanımlama
    /// </summary>
    public partial class NewArrangementForm : TTForm
    {
    /// <summary>
    /// Tertip Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSArrangementDefinition _MPBSArrangementDefinition
        {
            get { return (TTObjectClasses.MPBSArrangementDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("1e544b51-a53c-4145-bb37-1848efd0c26d"));
            Name = (ITTTextBox)AddControl(new Guid("19001740-7d9d-41be-b322-30f7247b8e2d"));
            labelCode = (ITTLabel)AddControl(new Guid("6202a182-9c87-424f-9b2b-5394edc25c83"));
            Code = (ITTTextBox)AddControl(new Guid("c192777e-4514-4a90-bfb0-c5d60769670c"));
            base.InitializeControls();
        }

        public NewArrangementForm() : base("MPBSARRANGEMENTDEFINITION", "NewArrangementForm")
        {
        }

        protected NewArrangementForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}