
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
    public partial class MainToeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.MainToeDefinition _MainToeDefinition
        {
            get { return (TTObjectClasses.MainToeDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckboxActive;
        protected ITTLabel labelUnitId;
        protected ITTObjectListBox UnitId;
        protected ITTLabel labelMAINTOECODE;
        protected ITTTextBox MAINTOECODE;
        override protected void InitializeControls()
        {
            ttcheckboxActive = (ITTCheckBox)AddControl(new Guid("2a9b5419-b49f-4062-812f-880a25279a4c"));
            labelUnitId = (ITTLabel)AddControl(new Guid("21698880-6e8f-4cfe-958e-34b8a8993f09"));
            UnitId = (ITTObjectListBox)AddControl(new Guid("f862dea4-8c40-4bee-8596-0ee204242f8d"));
            labelMAINTOECODE = (ITTLabel)AddControl(new Guid("7ebde9a9-801c-4e90-ac52-1d6b9d8e6a6f"));
            MAINTOECODE = (ITTTextBox)AddControl(new Guid("3d6fef8b-e8e7-43b9-bfa5-b8391e2792d5"));
            base.InitializeControls();
        }

        public MainToeDefinitionForm() : base("MAINTOEDEFINITION", "MainToeDefinitionForm")
        {
        }

        protected MainToeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}