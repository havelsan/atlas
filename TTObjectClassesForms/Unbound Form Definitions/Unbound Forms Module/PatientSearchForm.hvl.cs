
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
    /// Hasta Arama Ek
    /// </summary>
    public partial class PatientSearch : TTUnboundForm
    {
        protected ITTButton ttbutton3;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox UNIQUREFNO;
        protected ITTLabel ttlabel1;
        protected ITTButton SearchWithUniqueRefNo;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTButton GeneralSearch;
        protected ITTLabel ttlabel6;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel7;
        protected ITTTextBox tttextbox5;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTTextBox tttextbox3;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn uniquerefno;
        protected ITTTextBoxColumn PNAME;
        protected ITTTextBoxColumn FATHERNAME;
        protected ITTTextBoxColumn MOTHERNAME;
        protected ITTTextBoxColumn BIRTHPLACECITY;
        protected ITTTextBoxColumn BIRTHPLACECOUNTRY;
        protected ITTTextBoxColumn BIRTHYEAR;
        protected ITTLabel ttlabel8;
        override protected void InitializeControls()
        {
            ttbutton3 = (ITTButton)AddControl(new Guid("ef42d114-672a-4077-a14e-3af42d61b3bd"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("4d1bf18f-80ef-441f-b256-374d3e76d91a"));
            UNIQUREFNO = (ITTTextBox)AddControl(new Guid("276aa4bf-de8e-44b8-b287-1588b09de644"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("12581600-c9cd-40db-9f56-906bd5f4f597"));
            SearchWithUniqueRefNo = (ITTButton)AddControl(new Guid("eb5111d4-4eca-4db5-9874-1a9d5c98ed90"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("18c8129a-5588-4d55-9cd1-9158c73cb906"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("7215757a-994d-4b5e-a3e6-51a4c5793e2e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("745b5dc4-1be3-4ae3-9de2-d85e084f50ee"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6704435c-a839-411b-8870-bf1856237d0f"));
            GeneralSearch = (ITTButton)AddControl(new Guid("973835a4-98a3-4fc4-aee7-d9b71f520359"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("2ff41866-a3a2-493c-8f5c-9e06c343f401"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("ea070c52-53e5-4ba0-b62c-fd663d646975"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ddd6f55d-c8e2-49f7-89e2-6fec6fc221ee"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("01d966e7-74da-4fb9-a0c2-a1def43f396d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e58342bd-ab8a-41be-8b73-4dc494505c21"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("6af82a47-d3b2-4edf-9c18-30e9c8991ce9"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("18be4bce-765d-470e-9d95-a230b3ad5862"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("45244284-1f76-4424-be16-ae1a9df630df"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("f7743d3c-43ed-446e-90f7-606cac546e7d"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("12399fee-1faa-4e50-b3ef-9956280896be"));
            uniquerefno = (ITTTextBoxColumn)AddControl(new Guid("6cbe8769-65f7-428a-9db0-9e410b7352d2"));
            PNAME = (ITTTextBoxColumn)AddControl(new Guid("ddaadaac-4593-4803-a025-9fd77bff5c12"));
            FATHERNAME = (ITTTextBoxColumn)AddControl(new Guid("c10d0b08-1e8c-42f9-83c6-4491b5d6771a"));
            MOTHERNAME = (ITTTextBoxColumn)AddControl(new Guid("749131e3-7b7e-4942-b3c1-83c60c339693"));
            BIRTHPLACECITY = (ITTTextBoxColumn)AddControl(new Guid("07916acb-f685-4f35-9472-b7d9daab1bee"));
            BIRTHPLACECOUNTRY = (ITTTextBoxColumn)AddControl(new Guid("efa070d7-7b0a-4809-bdeb-5333eca3e62c"));
            BIRTHYEAR = (ITTTextBoxColumn)AddControl(new Guid("71bc7ac5-2b12-4e66-acd8-ab7481a0a42b"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("fc0365db-bd43-4a12-acd3-1e5693240f92"));
            base.InitializeControls();
        }

        public PatientSearch() : base("PatientSearch")
        {
        }

        protected PatientSearch(string formDefName) : base(formDefName)
        {
        }
    }
}