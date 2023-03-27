
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
    public partial class SectionDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.SectionDefinition _SectionDefinition
        {
            get { return (TTObjectClasses.SectionDefinition)_ttObject; }
        }

        protected ITTLabel labelPARAGRAPHTOECODE;
        protected ITTTextBox PARAGRAPHTOECODE;
        protected ITTCheckBox ttcheckboxActive;
        protected ITTLabel labelUnitId;
        protected ITTObjectListBox UnitId;
        protected ITTLabel labelOfficeId;
        protected ITTObjectListBox OfficeId;
        protected ITTLabel labelSHORT_NAME;
        protected ITTTextBox SHORT_NAME;
        protected ITTTextBox NAME;
        protected ITTLabel labelNAME;
        override protected void InitializeControls()
        {
            labelPARAGRAPHTOECODE = (ITTLabel)AddControl(new Guid("56cdc9d7-8aa0-41de-85b1-dd786b7f827c"));
            PARAGRAPHTOECODE = (ITTTextBox)AddControl(new Guid("6f7222f1-ca60-42a8-93ed-9dc3aae386f1"));
            ttcheckboxActive = (ITTCheckBox)AddControl(new Guid("9499e07b-a299-4b2f-a9de-2a52e5e9d014"));
            labelUnitId = (ITTLabel)AddControl(new Guid("56894c4a-bebc-49eb-8a4e-08ae11b03aa9"));
            UnitId = (ITTObjectListBox)AddControl(new Guid("c0388dda-f75e-4e4e-afda-474a0b594349"));
            labelOfficeId = (ITTLabel)AddControl(new Guid("9ddab7eb-7056-4b97-aa43-1893fbd3b6fd"));
            OfficeId = (ITTObjectListBox)AddControl(new Guid("afb1bb08-bde6-4f12-baf9-d4ace6dbcf82"));
            labelSHORT_NAME = (ITTLabel)AddControl(new Guid("8f007558-a539-4ef3-842a-74577d20a27f"));
            SHORT_NAME = (ITTTextBox)AddControl(new Guid("cabb5d36-cf6f-4043-acc5-dba34ed66f56"));
            NAME = (ITTTextBox)AddControl(new Guid("b3f7858e-b163-4be9-9e7c-f37e0fd896c8"));
            labelNAME = (ITTLabel)AddControl(new Guid("c793d5ee-ff13-4d19-8661-ebe0a42d2c36"));
            base.InitializeControls();
        }

        public SectionDefinitionForm() : base("SECTIONDEFINITION", "SectionDefinitionForm")
        {
        }

        protected SectionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}