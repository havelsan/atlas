
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
    public partial class EducationApproachDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.EducationDef _EducationDef
        {
            get { return (TTObjectClasses.EducationDef)_ttObject; }
        }

        protected ITTCheckBox PlusTwentyRiskChecked;
        protected ITTCheckBox PlusFifteenRiskChecked;
        protected ITTCheckBox PlusTenRiskChecked;
        protected ITTLabel educationDefinition;
        protected ITTTextBox Definition;
        override protected void InitializeControls()
        {
            PlusTwentyRiskChecked = (ITTCheckBox)AddControl(new Guid("1f9cfeff-396f-4905-a7b3-decd214e54b5"));
            PlusFifteenRiskChecked = (ITTCheckBox)AddControl(new Guid("fd759f59-2823-4eaa-aa10-3e1295604169"));
            PlusTenRiskChecked = (ITTCheckBox)AddControl(new Guid("a82e7324-c3ab-4632-bce3-9a41100e8473"));
            educationDefinition = (ITTLabel)AddControl(new Guid("9b401afc-a967-4849-bf8d-68a33b5297de"));
            Definition = (ITTTextBox)AddControl(new Guid("9bdbb564-17a6-4b8f-b22b-9f2b5705e4bd"));
            base.InitializeControls();
        }

        public EducationApproachDefForm() : base("EDUCATIONDEF", "EducationApproachDefForm")
        {
        }

        protected EducationApproachDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}