
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
    /// Branş Tanımlama
    /// </summary>
    public partial class NewBranchForm : TTForm
    {
    /// <summary>
    /// Branş Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSBranchDefinition _MPBSBranchDefinition
        {
            get { return (TTObjectClasses.MPBSBranchDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("4d4d3805-76fe-420d-88b3-3525f19748f4"));
            Name = (ITTTextBox)AddControl(new Guid("034c2b81-2fbf-4314-a49e-ad49c2edaaba"));
            base.InitializeControls();
        }

        public NewBranchForm() : base("MPBSBRANCHDEFINITION", "NewBranchForm")
        {
        }

        protected NewBranchForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}