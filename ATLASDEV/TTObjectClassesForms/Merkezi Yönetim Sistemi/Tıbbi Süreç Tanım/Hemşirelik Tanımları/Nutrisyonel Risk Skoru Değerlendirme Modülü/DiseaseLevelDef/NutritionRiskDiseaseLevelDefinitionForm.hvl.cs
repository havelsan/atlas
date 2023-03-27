
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
    public partial class NutritionRiskDiseaseLevelDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.DiseaseLevelDef _DiseaseLevelDef
        {
            get { return (TTObjectClasses.DiseaseLevelDef)_ttObject; }
        }

        protected ITTLabel labelScore;
        protected ITTTextBox Score;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            labelScore = (ITTLabel)AddControl(new Guid("3ba1172a-9d5b-40a5-a523-9da9a3491728"));
            Score = (ITTTextBox)AddControl(new Guid("49a3aa9e-af63-410f-96d9-283ab7427111"));
            Description = (ITTTextBox)AddControl(new Guid("8013cac8-1b7f-4bf3-a2b1-22fc78fed189"));
            labelDescription = (ITTLabel)AddControl(new Guid("21fcb83a-ddf5-439c-9de8-7838cd5b0856"));
            base.InitializeControls();
        }

        public NutritionRiskDiseaseLevelDefinitionForm() : base("DISEASELEVELDEF", "NutritionRiskDiseaseLevelDefinitionForm")
        {
        }

        protected NutritionRiskDiseaseLevelDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}