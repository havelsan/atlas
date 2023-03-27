
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
    /// Laboratuvar Bakteri Tanım Formu
    /// </summary>
    public partial class LaboratoryBacteriaDefinitionForm : TTForm
    {
        protected TTObjectClasses.LaboratoryBacteriaDefinition _LaboratoryBacteriaDefinition
        {
            get { return (TTObjectClasses.LaboratoryBacteriaDefinition)_ttObject; }
        }

        protected ITTValueListBox ttvaluelistbox1;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox2;
        protected ITTCheckBox ttcheckbox1;
        override protected void InitializeControls()
        {
            ttvaluelistbox1 = (ITTValueListBox)AddControl(new Guid("00b343ea-bfff-45cf-a75e-2d795848c3dc"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c06689d7-ca0f-4baf-a65f-43202025d1b7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f3ffed0d-f93d-44a3-8baf-6298dd8bd6d5"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("ed4b34ea-71bb-4261-b159-cefa558bc7e8"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("394a9d8b-22f4-45cd-9ac5-f3cb03537728"));
            base.InitializeControls();
        }

        public LaboratoryBacteriaDefinitionForm() : base("LABORATORYBACTERIADEFINITION", "LaboratoryBacteriaDefinitionForm")
        {
        }

        protected LaboratoryBacteriaDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}