
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
    public partial class SutRuleCheckResultsForm : TTUnboundForm
    {
        protected ITTButton btnCancel;
        protected ITTButton btnContinue;
        protected ITTGrid grdResults;
        protected ITTTextBoxColumn dgvcMessage;
        protected ITTTextBoxColumn dgvcDiagList;
        override protected void InitializeControls()
        {
            btnCancel = (ITTButton)AddControl(new Guid("f5b6689f-4cb8-42a8-b702-370f4698c4ed"));
            btnContinue = (ITTButton)AddControl(new Guid("1f8b1639-c09f-4d92-b6cd-db1810efd0cc"));
            grdResults = (ITTGrid)AddControl(new Guid("fb10d916-1104-4d48-95dc-0cec4beb9d91"));
            dgvcMessage = (ITTTextBoxColumn)AddControl(new Guid("1620b5a3-8bb0-4960-a8ee-bbfb5ba44138"));
            dgvcDiagList = (ITTTextBoxColumn)AddControl(new Guid("8324da31-e72c-4a3b-88c9-256573d1e553"));
            base.InitializeControls();
        }

        public SutRuleCheckResultsForm() : base("SutRuleCheckResultsForm")
        {
        }

        protected SutRuleCheckResultsForm(string formDefName) : base(formDefName)
        {
        }
    }
}