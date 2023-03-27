
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
    /// RuleBaseDefinitionForm
    /// </summary>
    public partial class RuleBaseDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.RuleBase _RuleBase
        {
            get { return (TTObjectClasses.RuleBase)_ttObject; }
        }

        protected ITTCheckBox IsPayable;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage SexConditionsTabpage;
        protected ITTGrid SexConditions;
        protected ITTEnumComboBoxColumn OperatorTypeSexCondition;
        protected ITTEnumComboBoxColumn SexSexCondition;
        protected ITTTabPage AgeConditionsTabpage;
        protected ITTGrid AgeConditions;
        protected ITTEnumComboBoxColumn OperatorTypeAgeCondition;
        protected ITTEnumComboBoxColumn AgeTypeAgeCondition;
        protected ITTTextBoxColumn FirstValueAgeCondition;
        protected ITTTextBoxColumn LastValueAgeCondition;
        protected ITTTabPage ProcedureConditionsTabpage;
        protected ITTGrid ProcedureConditions;
        protected ITTEnumComboBoxColumn OperatorTypeProcedureCondition;
        protected ITTListBoxColumn ProcedureObjectProcedureCondition;
        protected ITTTabPage DiagnosisConditionsTabpage;
        protected ITTGrid DiagnosisConditions;
        protected ITTEnumComboBoxColumn OperatorTypeDiagnosisCondition;
        protected ITTListBoxColumn DiagnosisDiagnosisCondition;
        protected ITTTabPage SpecialDiagnosisConditionsTabpage;
        protected ITTTabPage SpecialityConditionsTabpage;
        protected ITTGrid SpecialityConditions;
        protected ITTEnumComboBoxColumn OperatorTypeSpecialityCondition;
        protected ITTListDefComboBoxColumn SpecialitySpecialityCondition;
        protected ITTTabPage HealthCommitteeReportConditionsTabpage;
        protected ITTTabPage TherapyTypeConditionsTabpage;
        protected ITTGrid TherapyTypeConditions;
        protected ITTEnumComboBoxColumn OperatorTypeTherapyTypeCondition;
        protected ITTListDefComboBoxColumn TherapyTypeTherapyTypeCondition;
        protected ITTTabPage TherapyKindConditionsTabpage;
        protected ITTGrid TherapyKindConditions;
        protected ITTEnumComboBoxColumn OperatorTypeTherapyKindCondition;
        protected ITTListDefComboBoxColumn TherapyKindTherapyKindCondition;
        protected ITTTabPage ProvisionTypeConditionsTabpage;
        protected ITTGrid ProvisionTypeConditions;
        protected ITTEnumComboBoxColumn OperatorTypeProvisionTypeCondition;
        protected ITTListDefComboBoxColumn ProvisionTypeProvisionTypeCondition;
        protected ITTTabPage SocialSecurityTypeConditionsTabpage;
        protected ITTGrid SocialSecurityTypeConditions;
        protected ITTEnumComboBoxColumn OperatorTypeSocialSecurityTypeCondition;
        protected ITTListDefComboBoxColumn SocialSecurityTypeSocialSecurityTypeCondition;
        protected ITTCheckBox IsWarningOnly;
        protected ITTTextBox WarningMessage;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelRulePriority;
        protected ITTEnumComboBox RulePriority;
        protected ITTLabel labelResult;
        protected ITTTextBox RuleDescription;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            IsPayable = (ITTCheckBox)AddControl(new Guid("307b629b-ca95-49db-9a8b-8c39094cf875"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("3ce4fff5-50ea-4103-b70f-24fce4ffe082"));
            SexConditionsTabpage = (ITTTabPage)AddControl(new Guid("3b99446e-4020-42d3-abaa-9ca33200a9cb"));
            SexConditions = (ITTGrid)AddControl(new Guid("7cbe8a59-dc6c-4c0b-9aae-3b4e673dd2d6"));
            OperatorTypeSexCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("22bbf25a-b51d-408e-be25-a9a010b25090"));
            SexSexCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("c53dc62a-6cfa-4937-92e8-2db0035da6cc"));
            AgeConditionsTabpage = (ITTTabPage)AddControl(new Guid("ef76a4bb-e0d9-4b10-bbb9-5d4daf7b879f"));
            AgeConditions = (ITTGrid)AddControl(new Guid("ea409415-1979-4c1c-b9b6-9ece25ff2118"));
            OperatorTypeAgeCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("e4338e11-1327-48e2-89da-a76911358ac5"));
            AgeTypeAgeCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("010cc0cd-3821-4bd9-8678-21588da182fa"));
            FirstValueAgeCondition = (ITTTextBoxColumn)AddControl(new Guid("b7912f46-a26c-4b74-a503-b26ac3c81a16"));
            LastValueAgeCondition = (ITTTextBoxColumn)AddControl(new Guid("8c4b2111-e7b2-4ab6-be04-0caba31ad81e"));
            ProcedureConditionsTabpage = (ITTTabPage)AddControl(new Guid("fd063741-7df7-4755-b05e-7d893db95f1b"));
            ProcedureConditions = (ITTGrid)AddControl(new Guid("cf38258c-0acb-4e73-b0de-ca2f9983cbc5"));
            OperatorTypeProcedureCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("0b4e3624-2803-4dd5-ba0d-41204e73a7e8"));
            ProcedureObjectProcedureCondition = (ITTListBoxColumn)AddControl(new Guid("a0d3e7e9-25e2-41bd-bd7b-5761c81eb494"));
            DiagnosisConditionsTabpage = (ITTTabPage)AddControl(new Guid("894c4213-50c6-47ca-9d49-677982a64ff7"));
            DiagnosisConditions = (ITTGrid)AddControl(new Guid("351a3b8f-8ad9-4947-af6d-e089c7980312"));
            OperatorTypeDiagnosisCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("f014e8b7-3037-43a4-9298-3d9a95efad6c"));
            DiagnosisDiagnosisCondition = (ITTListBoxColumn)AddControl(new Guid("58cc9a89-8b74-4a1e-9d63-4bd790a40022"));
            SpecialDiagnosisConditionsTabpage = (ITTTabPage)AddControl(new Guid("63a0af81-3652-41b8-883e-fbec3f065b15"));
            SpecialityConditionsTabpage = (ITTTabPage)AddControl(new Guid("6899e639-576a-4e3e-8d1d-fe62ed2d9c47"));
            SpecialityConditions = (ITTGrid)AddControl(new Guid("0d0aa9fb-c5e5-40b4-ac88-a3f8ae9f0b00"));
            OperatorTypeSpecialityCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("b52344f4-e476-4d7f-a369-b9e82eefbeab"));
            SpecialitySpecialityCondition = (ITTListDefComboBoxColumn)AddControl(new Guid("f5b09c99-f216-40c8-a2a3-cc5d20b7ac63"));
            HealthCommitteeReportConditionsTabpage = (ITTTabPage)AddControl(new Guid("c9f38a84-76f9-4a0d-a1bd-93adaff689fd"));
            TherapyTypeConditionsTabpage = (ITTTabPage)AddControl(new Guid("ad5e4e85-66ed-4bd4-b46d-c68adc2f2c12"));
            TherapyTypeConditions = (ITTGrid)AddControl(new Guid("9cfa6077-9477-4ac3-beaa-abf1daa41c50"));
            OperatorTypeTherapyTypeCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("837a8cf9-5645-41fb-8016-d049e0c597f5"));
            TherapyTypeTherapyTypeCondition = (ITTListDefComboBoxColumn)AddControl(new Guid("f6ff656d-faa4-44ec-a2b9-b78a2d3f8d02"));
            TherapyKindConditionsTabpage = (ITTTabPage)AddControl(new Guid("166b6654-d05b-414f-afbf-18c12e447c43"));
            TherapyKindConditions = (ITTGrid)AddControl(new Guid("93942ec7-d29e-4e78-b236-cbf0f50e74b1"));
            OperatorTypeTherapyKindCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("e9151d66-6fb5-4d29-a455-5a13c4fa9ad7"));
            TherapyKindTherapyKindCondition = (ITTListDefComboBoxColumn)AddControl(new Guid("9c82b6bd-d318-4658-8dd4-fd0a2fff5a4d"));
            ProvisionTypeConditionsTabpage = (ITTTabPage)AddControl(new Guid("e300a82f-be37-4be6-a254-42a99e7e5901"));
            ProvisionTypeConditions = (ITTGrid)AddControl(new Guid("97b67e28-e96e-4d0e-ae74-83e3708476db"));
            OperatorTypeProvisionTypeCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("063dfda2-8372-4cda-a94f-46d5934a5d1e"));
            ProvisionTypeProvisionTypeCondition = (ITTListDefComboBoxColumn)AddControl(new Guid("eec54ebf-5414-4df7-8c2f-0aa04b7c8dcc"));
            SocialSecurityTypeConditionsTabpage = (ITTTabPage)AddControl(new Guid("3df7126f-93a6-4875-9b5d-096534b31308"));
            SocialSecurityTypeConditions = (ITTGrid)AddControl(new Guid("f1126ca7-953f-41e1-b447-1867342578fd"));
            OperatorTypeSocialSecurityTypeCondition = (ITTEnumComboBoxColumn)AddControl(new Guid("1462ee4e-4a97-4b85-88af-f1e280485c03"));
            SocialSecurityTypeSocialSecurityTypeCondition = (ITTListDefComboBoxColumn)AddControl(new Guid("78af147f-2950-4c01-902b-6bba2ffc0ad1"));
            IsWarningOnly = (ITTCheckBox)AddControl(new Guid("cc9cba33-f09a-4be0-8241-7293afb0d40f"));
            WarningMessage = (ITTTextBox)AddControl(new Guid("c4a500a4-1cc0-4b04-ba91-110431bb863d"));
            labelName = (ITTLabel)AddControl(new Guid("fc52d44b-afca-4d8d-9303-e3fdfd472f75"));
            Name = (ITTTextBox)AddControl(new Guid("2590b8b8-89c6-4548-a62f-f7d625b88441"));
            labelRulePriority = (ITTLabel)AddControl(new Guid("9f6c671d-8083-4e40-95ea-3f20d8462fee"));
            RulePriority = (ITTEnumComboBox)AddControl(new Guid("c7e225af-3c46-4a05-9ac1-5dcb19d5793a"));
            labelResult = (ITTLabel)AddControl(new Guid("a01c5ca6-a3ae-4feb-be7d-a4d5a9fb5f7e"));
            RuleDescription = (ITTTextBox)AddControl(new Guid("429a917b-b82e-49ac-a6a4-671437b82fc9"));
            IsActive = (ITTCheckBox)AddControl(new Guid("f14eec2d-ce0c-4e6d-a1c6-4448fb22ef66"));
            base.InitializeControls();
        }

        public RuleBaseDefinitionForm() : base("RULEBASE", "RuleBaseDefinitionForm")
        {
        }

        protected RuleBaseDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}