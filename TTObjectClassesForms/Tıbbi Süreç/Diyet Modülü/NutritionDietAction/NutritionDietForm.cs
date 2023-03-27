
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class NutritionDietForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            CalculateData.Click += new TTControlEventDelegate(CalculateData_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            CalculateData.Click -= new TTControlEventDelegate(CalculateData_Click);
            base.UnBindControlEvents();
        }

        private void CalculateData_Click()
        {
#region NutritionDietForm_CalculateData_Click
   double bmi = 0, weight = 0, height = 0,bodysurfaceArea= 0;
         
            if(!string.IsNullOrEmpty(this._NutritionDietAction.Weight.ToString()) && !string.IsNullOrEmpty(this._NutritionDietAction.Height.ToString()))
            {
                weight = Convert.ToDouble(this._NutritionDietAction.Weight);
                height = Convert.ToDouble(this._NutritionDietAction.Height);
                
                //BMI
                this._NutritionDietAction.BodyMassIndex = Common.CalculateBMI(weight, height); 

                //BodySurfaceArea
                this._NutritionDietAction.BodySurfaceArea = Common.CalculateBodySurfaceArea(weight, height); 

            }
#endregion NutritionDietForm_CalculateData_Click
        }

  

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            base.ClientSidePostScript(transDef);

            if(this._EpisodeAction.Episode.PatientStatus == PatientStatusEnum.Outpatient)
                this.DietDefinition.ListFilterExpression = "PATIENTTYPE IN ('"+ OutPatientInPatientBothEnum.OutPatient+"'"+",'"+ OutPatientInPatientBothEnum.Both + ")"; 
            else
                this.DietDefinition.ListFilterExpression = "PATIENTTYPE IN ('" + OutPatientInPatientBothEnum.InPatient + "'" + ",'" + OutPatientInPatientBothEnum.Both + ")";


        }

      


    }
}