
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
    /// Patoloji Paket Tanım Formu
    /// </summary>
    public partial class PathologyAcceptTemplateForm : TTDefinitionForm
    {
    /// <summary>
    /// Patoloji Paket Tanımları
    /// </summary>
        protected TTObjectClasses.PathologyAcceptTemplateDefinition _PathologyAcceptTemplateDefinition
        {
            get { return (TTObjectClasses.PathologyAcceptTemplateDefinition)_ttObject; }
        }

        protected ITTGrid GRIDUSERRESOURCES;
        protected ITTListBoxColumn Test;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox NAME;
        protected ITTObjectListBox RESUSER;
        override protected void InitializeControls()
        {
            GRIDUSERRESOURCES = (ITTGrid)AddControl(new Guid("71312bdd-7a76-45a6-b645-1a1dd805f419"));
            Test = (ITTListBoxColumn)AddControl(new Guid("2ee6bede-8cd8-495e-8d9e-1770a5e05e13"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("3ebcbdcf-1e52-4ced-9221-3dbbbabf819d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2031ab37-fb85-4f1f-a830-b55ccd9aa4da"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4000a738-a494-4bf9-be7a-a8481dc558d8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cb17b259-817f-42fc-a912-c7d9e32eb5d9"));
            NAME = (ITTTextBox)AddControl(new Guid("4dba9f1c-7d2e-4661-b263-6f5581a3279d"));
            RESUSER = (ITTObjectListBox)AddControl(new Guid("fb9d5667-1336-4492-aeb8-bb692ff5cffd"));
            base.InitializeControls();
        }

        public PathologyAcceptTemplateForm() : base("PATHOLOGYACCEPTTEMPLATEDEFINITION", "PathologyAcceptTemplateForm")
        {
        }

        protected PathologyAcceptTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}