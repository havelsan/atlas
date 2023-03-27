
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
    public partial class MissionDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.MissionDefinition _MissionDefinition
        {
            get { return (TTObjectClasses.MissionDefinition)_ttObject; }
        }

        protected ITTLabel labelSharedMissionId;
        protected ITTObjectListBox SharedMissionId;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelNAME;
        protected ITTTextBox NAME;
        override protected void InitializeControls()
        {
            labelSharedMissionId = (ITTLabel)AddControl(new Guid("bb6cb6f0-1c9d-4229-9903-7f71543bc807"));
            SharedMissionId = (ITTObjectListBox)AddControl(new Guid("9fce0898-1ac6-424e-a038-07c618e7178d"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("9797854b-fffd-4d48-8a73-f76551750422"));
            labelNAME = (ITTLabel)AddControl(new Guid("9fb7d203-bbc5-43de-ad0e-2a59d55c95d6"));
            NAME = (ITTTextBox)AddControl(new Guid("4d71963a-d131-4a90-9be3-321a5b54ea87"));
            base.InitializeControls();
        }

        public MissionDefinitionForm() : base("MISSIONDEFINITION", "MissionDefinitionForm")
        {
        }

        protected MissionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}