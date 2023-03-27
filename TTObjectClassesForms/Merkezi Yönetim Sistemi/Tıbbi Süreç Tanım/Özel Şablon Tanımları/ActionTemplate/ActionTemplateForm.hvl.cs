
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
    /// Şablon Tanımı
    /// </summary>
    public partial class ActionTemplateForm : TTDefinitionForm
    {
        protected TTObjectClasses.ActionTemplate _ActionTemplate
        {
            get { return (TTObjectClasses.ActionTemplate)_ttObject; }
        }

        protected ITTButton ContentButton;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            ContentButton = (ITTButton)AddControl(new Guid("4c2d5604-c28e-46ef-a2a3-fc9a173d545d"));
            labelID = (ITTLabel)AddControl(new Guid("11065ded-ad53-4593-bccd-179492ed2576"));
            ID = (ITTTextBox)AddControl(new Guid("4fe43ce7-ee7e-467d-ba34-1ac2e9d23bd2"));
            labelDescription = (ITTLabel)AddControl(new Guid("e21bd800-d9d8-4af5-a311-10e5bfb37705"));
            Description = (ITTTextBox)AddControl(new Guid("28791abc-e132-4f32-9c9d-4c40e8775b34"));
            base.InitializeControls();
        }

        public ActionTemplateForm() : base("ACTIONTEMPLATE", "ActionTemplateForm")
        {
        }

        protected ActionTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}