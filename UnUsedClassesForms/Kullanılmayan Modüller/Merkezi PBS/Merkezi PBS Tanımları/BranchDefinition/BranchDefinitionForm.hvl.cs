
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
    public partial class BranchDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.BranchDefinition _BranchDefinition
        {
            get { return (TTObjectClasses.BranchDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckboxActive;
        protected ITTLabel labelNAME;
        protected ITTTextBox NAME;
        override protected void InitializeControls()
        {
            ttcheckboxActive = (ITTCheckBox)AddControl(new Guid("2972d14f-2e17-4a06-badb-03c95640cbb2"));
            labelNAME = (ITTLabel)AddControl(new Guid("213bc4a4-f587-4d6d-9f4e-b3ebb939367b"));
            NAME = (ITTTextBox)AddControl(new Guid("5c50d481-1de9-494c-bb8c-9005d883e7bb"));
            base.InitializeControls();
        }

        public BranchDefinitionForm() : base("BRANCHDEFINITION", "BranchDefinitionForm")
        {
        }

        protected BranchDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}