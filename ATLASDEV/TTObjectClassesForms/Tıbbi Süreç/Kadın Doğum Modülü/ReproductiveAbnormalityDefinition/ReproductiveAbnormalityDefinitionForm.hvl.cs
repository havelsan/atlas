
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
    public partial class ReproductiveAbnormalityDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.ReproductiveAbnormalityDefinition _ReproductiveAbnormalityDefinition
        {
            get { return (TTObjectClasses.ReproductiveAbnormalityDefinition)_ttObject; }
        }

        protected ITTLabel labelParentGroup;
        protected ITTObjectListBox ParentGroup;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            labelParentGroup = (ITTLabel)AddControl(new Guid("4144ceb3-a836-401c-8985-c9e14ca3a2ac"));
            ParentGroup = (ITTObjectListBox)AddControl(new Guid("95d041bb-c613-470d-9f74-0a6bfe295b83"));
            labelName = (ITTLabel)AddControl(new Guid("e37edfc9-9424-4fd2-ae79-8cce02984db0"));
            Name = (ITTTextBox)AddControl(new Guid("975ebf7d-32a6-44be-b362-371d8aaf71b9"));
            Active = (ITTCheckBox)AddControl(new Guid("5a309d6f-acf7-49d5-b86e-23c7bf715aa0"));
            base.InitializeControls();
        }

        public ReproductiveAbnormalityDefinitionForm() : base("REPRODUCTIVEABNORMALITYDEFINITION", "ReproductiveAbnormalityDefinitionForm")
        {
        }

        protected ReproductiveAbnormalityDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}