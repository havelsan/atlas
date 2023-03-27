
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
    public partial class CommunityHealthTemplateForm : TTDefinitionForm
    {
        protected TTObjectClasses.CommunityHealthTemplate _CommunityHealthTemplate
        {
            get { return (TTObjectClasses.CommunityHealthTemplate)_ttObject; }
        }

        protected ITTGrid Details;
        protected ITTListBoxColumn ProcedureObjectCommunityHealthTemlateDetail;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            Details = (ITTGrid)AddControl(new Guid("9612ee66-aadd-40a9-b472-193038a1addf"));
            ProcedureObjectCommunityHealthTemlateDetail = (ITTListBoxColumn)AddControl(new Guid("ef5e7cb9-f3b1-43c4-9653-c9f2578a2623"));
            labelName = (ITTLabel)AddControl(new Guid("30d15596-bfcd-4d90-80cc-ee63b2a9ed48"));
            Name = (ITTTextBox)AddControl(new Guid("371f2595-5e22-4ece-9be0-5bec50b35cd5"));
            base.InitializeControls();
        }

        public CommunityHealthTemplateForm() : base("COMMUNITYHEALTHTEMPLATE", "CommunityHealthTemplateForm")
        {
        }

        protected CommunityHealthTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}