
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
    /// Sağlık Kurulu Karar Tanımı
    /// </summary>
    public partial class HCDecisionDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Sağlık Kurulu Karar Tanımı
    /// </summary>
        protected TTObjectClasses.HealthCommitteeDecisionDefinition _HealthCommitteeDecisionDefinition
        {
            get { return (TTObjectClasses.HealthCommitteeDecisionDefinition)_ttObject; }
        }

        protected ITTGrid HCDesicionDefPatGroupGrid;
        protected ITTListBoxColumn PatientGroupHCDesicionDefPatGroupGrid;
        protected ITTCheckBox chkRequiresTimeInfo;
        protected ITTTextBox NAME;
        protected ITTTextBox CODE;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox chkRequiresAddDecision;
        protected ITTCheckBox chkShowOnlyAddDecOnReports;
        protected ITTCheckBox chkUnsuitableForMilitaryService;
        protected ITTCheckBox isActive;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox Category;
        override protected void InitializeControls()
        {
            HCDesicionDefPatGroupGrid = (ITTGrid)AddControl(new Guid("19f70ea1-40cb-40dd-96e2-ea3f7e886930"));
            PatientGroupHCDesicionDefPatGroupGrid = (ITTListBoxColumn)AddControl(new Guid("c86577d5-b18c-4d45-b599-49f14089bebb"));
            chkRequiresTimeInfo = (ITTCheckBox)AddControl(new Guid("80d26de5-d150-4e6e-a178-e7f175cc625f"));
            NAME = (ITTTextBox)AddControl(new Guid("d884f15c-9a3b-4dcb-badd-93bb99def972"));
            CODE = (ITTTextBox)AddControl(new Guid("ad7305a7-254a-4470-8e1e-17525e73c8b0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("dc1b35e1-d53b-4d86-9e77-1bdda3c12318"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d6438ab7-ad8c-48e3-bf26-8c6478662abc"));
            chkRequiresAddDecision = (ITTCheckBox)AddControl(new Guid("2c4b9967-0731-42b1-b5d0-d72fc8c6d7e3"));
            chkShowOnlyAddDecOnReports = (ITTCheckBox)AddControl(new Guid("dce65860-3acb-4924-b381-0d34ee1ebae3"));
            chkUnsuitableForMilitaryService = (ITTCheckBox)AddControl(new Guid("192b4cdd-0e3a-485c-b3b6-8319b0f20607"));
            isActive = (ITTCheckBox)AddControl(new Guid("a2c5d4f1-5e6e-4f81-8933-b3a0155c927b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cd32cd0a-b2b8-41a3-9b14-4d0516c17d26"));
            Category = (ITTObjectListBox)AddControl(new Guid("77ac65ce-5c4e-40b1-8e15-6faef09b1140"));
            base.InitializeControls();
        }

        public HCDecisionDefinitionForm() : base("HEALTHCOMMITTEEDECISIONDEFINITION", "HCDecisionDefinitionForm")
        {
        }

        protected HCDecisionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}