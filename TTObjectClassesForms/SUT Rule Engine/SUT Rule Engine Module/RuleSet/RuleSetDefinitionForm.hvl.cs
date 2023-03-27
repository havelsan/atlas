
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
    /// Kural Seti Tanımlama
    /// </summary>
    public partial class RuleSetDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.RuleSet _RuleSet
        {
            get { return (TTObjectClasses.RuleSet)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage rulesTabpage;
        protected ITTButton AddRule;
        protected ITTButton RemoveRule;
        protected ITTGrid RuleSetRules;
        protected ITTTextBoxColumn RuleRuleSetRule;
        protected ITTTextBoxColumn ResultRuleSetRule;
        protected ITTButton EditRule;
        protected ITTTabPage materialsTabpage;
        protected ITTGrid MaterialRuleSets;
        protected ITTListBoxColumn MaterialMaterialRuleSet;
        protected ITTTabPage proceduresTabpage;
        protected ITTGrid ProcedureRuleSets;
        protected ITTListBoxColumn ProcedureObjectProcedureRuleSet;
        protected ITTTabPage diagnosisTabpage;
        protected ITTGrid DiagnosisRuleSets;
        protected ITTListBoxColumn DiagnosisDiagnosisRuleSet;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e0c560df-aeba-426a-b9ea-b078a333c3b5"));
            rulesTabpage = (ITTTabPage)AddControl(new Guid("76d41716-26d4-4958-bc85-021dea259f68"));
            AddRule = (ITTButton)AddControl(new Guid("be7f5614-b028-4058-a0e2-61b7aa4d50a7"));
            RemoveRule = (ITTButton)AddControl(new Guid("f3801c45-2d72-4133-a59a-793bef16c2c8"));
            RuleSetRules = (ITTGrid)AddControl(new Guid("3b4f509b-808f-49a6-8e84-c0dbc4951601"));
            RuleRuleSetRule = (ITTTextBoxColumn)AddControl(new Guid("2a188b83-8e3e-460d-bb1b-e9b68f4d348e"));
            ResultRuleSetRule = (ITTTextBoxColumn)AddControl(new Guid("48a65441-ff67-42eb-ab55-37462ee20859"));
            EditRule = (ITTButton)AddControl(new Guid("59c3c35d-9d20-4e79-aa2f-2c60ef8484cb"));
            materialsTabpage = (ITTTabPage)AddControl(new Guid("ba4c57d0-db9b-40e6-bfe4-c5140635fe98"));
            MaterialRuleSets = (ITTGrid)AddControl(new Guid("b56110e3-c8e0-4999-ae07-02d9cbfd2ab9"));
            MaterialMaterialRuleSet = (ITTListBoxColumn)AddControl(new Guid("22aef068-6ff3-48ed-a99c-855c891cfe6a"));
            proceduresTabpage = (ITTTabPage)AddControl(new Guid("231e732e-a3db-4ec8-b076-16ebcc5c01ec"));
            ProcedureRuleSets = (ITTGrid)AddControl(new Guid("a3b2bd88-884a-4df2-be59-c9fa91d4b3ee"));
            ProcedureObjectProcedureRuleSet = (ITTListBoxColumn)AddControl(new Guid("269ae373-999c-40bf-b085-9109b84b2c74"));
            diagnosisTabpage = (ITTTabPage)AddControl(new Guid("10b25a99-2167-4028-934e-83349479d5f4"));
            DiagnosisRuleSets = (ITTGrid)AddControl(new Guid("0f3d562a-a4cd-4821-ae5a-7a9e9aa008ba"));
            DiagnosisDiagnosisRuleSet = (ITTListBoxColumn)AddControl(new Guid("9d207b5e-d1a6-477d-9cc4-4fd97ced309b"));
            labelStartDate = (ITTLabel)AddControl(new Guid("c945e2d4-c328-4916-8151-7c6e711d2065"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("6fe3b9a4-db79-4b17-ac04-1661bc6f8c44"));
            labelName = (ITTLabel)AddControl(new Guid("99337476-610b-4f29-a356-e1d17ac41158"));
            Name = (ITTTextBox)AddControl(new Guid("a132fe00-158c-4a27-8a54-b89ddec68945"));
            labelEndDate = (ITTLabel)AddControl(new Guid("f0f95349-df34-4e41-9989-00727a56719d"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("db43b226-c190-40e0-8e08-e958e4218d0c"));
            labelDescription = (ITTLabel)AddControl(new Guid("273c8f97-051e-4cdf-9811-65e4a3d4341e"));
            Description = (ITTTextBox)AddControl(new Guid("8b12ebd2-91a5-4f97-94e6-dbaaa03e74c5"));
            IsActive = (ITTCheckBox)AddControl(new Guid("cec51ee1-a5aa-46f2-916d-fe996daf32a3"));
            base.InitializeControls();
        }

        public RuleSetDefinitionForm() : base("RULESET", "RuleSetDefinitionForm")
        {
        }

        protected RuleSetDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}