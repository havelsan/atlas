
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
    public partial class WoundAssessmentDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.WoundAssessmentDef _WoundAssessmentDef
        {
            get { return (TTObjectClasses.WoundAssessmentDef)_ttObject; }
        }

        protected ITTCheckBox PlusTwentyRiskChecked;
        protected ITTCheckBox PlusFifteenRiskChecked;
        protected ITTCheckBox PlusTenRiskChecked;
        protected ITTLabel woundAssesmentDefinition;
        protected ITTTextBox Definition;
        override protected void InitializeControls()
        {
            PlusTwentyRiskChecked = (ITTCheckBox)AddControl(new Guid("f2952b2b-e09e-4ac7-9402-2db3cdf8b0dc"));
            PlusFifteenRiskChecked = (ITTCheckBox)AddControl(new Guid("ea17e900-0949-4400-8797-6d9adc60147f"));
            PlusTenRiskChecked = (ITTCheckBox)AddControl(new Guid("c6c2686b-f9ef-48b2-a6e0-070caf496d38"));
            woundAssesmentDefinition = (ITTLabel)AddControl(new Guid("19666a1b-28bc-402e-a058-9a7da354c156"));
            Definition = (ITTTextBox)AddControl(new Guid("7beef1c6-e265-4422-9451-63022c6ab0ef"));
            base.InitializeControls();
        }

        public WoundAssessmentDefinitionForm() : base("WOUNDASSESSMENTDEF", "WoundAssessmentDefinitionForm")
        {
        }

        protected WoundAssessmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}