
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
    public partial class CommonCodeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.CommonCode _CommonCode
        {
            get { return (TTObjectClasses.CommonCode)_ttObject; }
        }

        protected ITTCheckBox ttcheckboxActive;
        protected ITTLabel labelCommonCodeGroup;
        protected ITTObjectListBox CommonCodeGroup;
        protected ITTLabel labelVALUE;
        protected ITTTextBox VALUE;
        protected ITTTextBox DEFINITION;
        protected ITTTextBox CODE_NAME;
        protected ITTTextBox CODE;
        protected ITTLabel labelDEFINITION;
        protected ITTLabel labelCODE_NAME;
        protected ITTLabel labelCODE;
        override protected void InitializeControls()
        {
            ttcheckboxActive = (ITTCheckBox)AddControl(new Guid("030d7620-ab13-4e17-a1c1-397d1b12b09c"));
            labelCommonCodeGroup = (ITTLabel)AddControl(new Guid("5938f6f0-2d58-4332-9e3a-eb3a5baf45a8"));
            CommonCodeGroup = (ITTObjectListBox)AddControl(new Guid("acbad46e-16cd-4177-8fd4-e9e04c6d45aa"));
            labelVALUE = (ITTLabel)AddControl(new Guid("37059cd6-c7bd-41b4-99cc-b0f83b98729a"));
            VALUE = (ITTTextBox)AddControl(new Guid("99c8ff5f-2e57-4cd4-af55-9dde7cc90855"));
            DEFINITION = (ITTTextBox)AddControl(new Guid("21ea72b8-5e42-48d1-8e5a-9d92ca4a825f"));
            CODE_NAME = (ITTTextBox)AddControl(new Guid("d8eeb996-dc90-4c37-9138-32799911730e"));
            CODE = (ITTTextBox)AddControl(new Guid("89046282-4715-41d6-a4de-e0e4afce13e5"));
            labelDEFINITION = (ITTLabel)AddControl(new Guid("d56751f1-931d-4800-90f1-53064a3d225d"));
            labelCODE_NAME = (ITTLabel)AddControl(new Guid("60bef312-6a90-41d8-a92b-49c86228a844"));
            labelCODE = (ITTLabel)AddControl(new Guid("328472f8-97c2-4280-abae-42c1b8499102"));
            base.InitializeControls();
        }

        public CommonCodeDefinitionForm() : base("COMMONCODE", "CommonCodeDefinitionForm")
        {
        }

        protected CommonCodeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}