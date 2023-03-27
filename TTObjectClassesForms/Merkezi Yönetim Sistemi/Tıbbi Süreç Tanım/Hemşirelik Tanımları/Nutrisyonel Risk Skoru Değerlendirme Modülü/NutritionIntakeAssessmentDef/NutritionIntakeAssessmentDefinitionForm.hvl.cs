
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
    public partial class NutritionIntakeAssessmentDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Beslenme Durumundaki Bozulma
    /// </summary>
        protected TTObjectClasses.NutritionIntakeAssessmentDef _NutritionIntakeAssessmentDef
        {
            get { return (TTObjectClasses.NutritionIntakeAssessmentDef)_ttObject; }
        }

        protected ITTLabel labelScore;
        protected ITTTextBox Score;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            labelScore = (ITTLabel)AddControl(new Guid("c86e22ad-eddc-45c2-8c9c-b113a67306fb"));
            Score = (ITTTextBox)AddControl(new Guid("b3ce7706-4efb-45d9-9257-a69427360341"));
            Description = (ITTTextBox)AddControl(new Guid("36de4ed2-38fe-4a35-a148-22fa89a163cc"));
            labelDescription = (ITTLabel)AddControl(new Guid("cce99687-5c3c-485c-929f-823e3661d539"));
            base.InitializeControls();
        }

        public NutritionIntakeAssessmentDefinitionForm() : base("NUTRITIONINTAKEASSESSMENTDEF", "NutritionIntakeAssessmentDefinitionForm")
        {
        }

        protected NutritionIntakeAssessmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}