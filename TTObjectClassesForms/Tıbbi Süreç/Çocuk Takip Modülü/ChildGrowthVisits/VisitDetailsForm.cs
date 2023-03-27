
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
    public partial class VisitDetailsForm : TTForm
    {
        //override protected void BindControlEvents()
        //{
        //    Weight.TextChanged += new TTControlEventDelegate(Weight_TextChanged);
        //    Height.TextChanged += new TTControlEventDelegate(Height_TextChanged);
        //    WalkingAloneCheckAllMotorDevelopment.CheckedChanged += new TTControlEventDelegate(WalkingAloneCheckAllMotorDevelopment_CheckedChanged);
        //    StandingAloneCheckAllMotorDevelopment.CheckedChanged += new TTControlEventDelegate(StandingAloneCheckAllMotorDevelopment_CheckedChanged);
        //    WalkingWAssistanceCheckAllMotorDevelopment.CheckedChanged += new TTControlEventDelegate(WalkingWAssistanceCheckAllMotorDevelopment_CheckedChanged);
        //    CrawlingCheckAllMotorDevelopment.CheckedChanged += new TTControlEventDelegate(CrawlingCheckAllMotorDevelopment_CheckedChanged);
        //    StandingWAssistanceCheckAllMotorDevelopment.CheckedChanged += new TTControlEventDelegate(StandingWAssistanceCheckAllMotorDevelopment_CheckedChanged);
        //    SittingWoSupportCheckAllMotorDevelopment.CheckedChanged += new TTControlEventDelegate(SittingWoSupportCheckAllMotorDevelopment_CheckedChanged);
        //    base.BindControlEvents();
        //}

        //override protected void UnBindControlEvents()
        //{
        //    Weight.TextChanged -= new TTControlEventDelegate(Weight_TextChanged);
        //    Height.TextChanged -= new TTControlEventDelegate(Height_TextChanged);
        //    WalkingAloneCheckAllMotorDevelopment.CheckedChanged -= new TTControlEventDelegate(WalkingAloneCheckAllMotorDevelopment_CheckedChanged);
        //    StandingAloneCheckAllMotorDevelopment.CheckedChanged -= new TTControlEventDelegate(StandingAloneCheckAllMotorDevelopment_CheckedChanged);
        //    WalkingWAssistanceCheckAllMotorDevelopment.CheckedChanged -= new TTControlEventDelegate(WalkingWAssistanceCheckAllMotorDevelopment_CheckedChanged);
        //    CrawlingCheckAllMotorDevelopment.CheckedChanged -= new TTControlEventDelegate(CrawlingCheckAllMotorDevelopment_CheckedChanged);
        //    StandingWAssistanceCheckAllMotorDevelopment.CheckedChanged -= new TTControlEventDelegate(StandingWAssistanceCheckAllMotorDevelopment_CheckedChanged);
        //    SittingWoSupportCheckAllMotorDevelopment.CheckedChanged -= new TTControlEventDelegate(SittingWoSupportCheckAllMotorDevelopment_CheckedChanged);
        //    base.UnBindControlEvents();
        //}

        private void Weight_TextChanged()
        {
#region VisitDetailsForm_Weight_TextChanged
   CalculateBMI();
#endregion VisitDetailsForm_Weight_TextChanged
        }

        private void Height_TextChanged()
        {
#region VisitDetailsForm_Height_TextChanged
   CalculateBMI();
#endregion VisitDetailsForm_Height_TextChanged
        }

        private void WalkingAloneCheckAllMotorDevelopment_CheckedChanged()
        {
#region VisitDetailsForm_WalkingAloneCheckAllMotorDevelopment_CheckedChanged
   if(((TTVisual.TTCheckBox)(WalkingAloneCheckAllMotorDevelopment)).Checked){
                ((TTVisual.TTCheckBox)(WalkingAlone1MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(WalkingAlone2MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(WalkingAlone3MotorDevelopment)).Checked = true;
               
           
            }else{
                ((TTVisual.TTCheckBox)(WalkingAlone1MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(WalkingAlone2MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(WalkingAlone3MotorDevelopment)).Checked = false;
         
            }
#endregion VisitDetailsForm_WalkingAloneCheckAllMotorDevelopment_CheckedChanged
        }

        private void StandingAloneCheckAllMotorDevelopment_CheckedChanged()
        {
#region VisitDetailsForm_StandingAloneCheckAllMotorDevelopment_CheckedChanged
   if(((TTVisual.TTCheckBox)(StandingAloneCheckAllMotorDevelopment)).Checked){
                ((TTVisual.TTCheckBox)(StandingAlone1MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(StandingAlone2MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(StandingAlone3MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(StandingAlone4MotorDevelopment)).Checked = true;
           
            }else{
                ((TTVisual.TTCheckBox)(StandingAlone1MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(StandingAlone2MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(StandingAlone3MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(StandingAlone4MotorDevelopment)).Checked = false;
            }
#endregion VisitDetailsForm_StandingAloneCheckAllMotorDevelopment_CheckedChanged
        }

        private void WalkingWAssistanceCheckAllMotorDevelopment_CheckedChanged()
        {
#region VisitDetailsForm_WalkingWAssistanceCheckAllMotorDevelopment_CheckedChanged
   if(((TTVisual.TTCheckBox)(WalkingWAssistanceCheckAllMotorDevelopment)).Checked){
                ((TTVisual.TTCheckBox)(WalkingWAssistance1MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(WalkingWAssistance2MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(WalkingWAssistance3MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(WalkingWAssistance4MotorDevelopment)).Checked = true;
           
            }else{
                ((TTVisual.TTCheckBox)(WalkingWAssistance1MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(WalkingWAssistance2MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(WalkingWAssistance3MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(WalkingWAssistance4MotorDevelopment)).Checked = false;
            }
#endregion VisitDetailsForm_WalkingWAssistanceCheckAllMotorDevelopment_CheckedChanged
        }

        private void CrawlingCheckAllMotorDevelopment_CheckedChanged()
        {
#region VisitDetailsForm_CrawlingCheckAllMotorDevelopment_CheckedChanged
   if(((TTVisual.TTCheckBox)(CrawlingCheckAllMotorDevelopment)).Checked){
                ((TTVisual.TTCheckBox)(Crawling1MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(Crawling2MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(Crawling3MotorDevelopment)).Checked = true;
              
           
            }else{
                ((TTVisual.TTCheckBox)(Crawling1MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(Crawling2MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(Crawling3MotorDevelopment)).Checked = false;
      
            }
#endregion VisitDetailsForm_CrawlingCheckAllMotorDevelopment_CheckedChanged
        }

        private void StandingWAssistanceCheckAllMotorDevelopment_CheckedChanged()
        {
#region VisitDetailsForm_StandingWAssistanceCheckAllMotorDevelopment_CheckedChanged
   if(((TTVisual.TTCheckBox)(StandingWAssistanceCheckAllMotorDevelopment)).Checked){
                ((TTVisual.TTCheckBox)(StandingWAssistance1MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(StandingWAssistance2MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(StandingWAssistance3MotorDevelopment)).Checked = true;
           
            }else{
                ((TTVisual.TTCheckBox)(StandingWAssistance1MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(StandingWAssistance2MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(StandingWAssistance3MotorDevelopment)).Checked = false;
            }
#endregion VisitDetailsForm_StandingWAssistanceCheckAllMotorDevelopment_CheckedChanged
        }

        private void SittingWoSupportCheckAllMotorDevelopment_CheckedChanged()
        {
#region VisitDetailsForm_SittingWoSupportCheckAllMotorDevelopment_CheckedChanged
   if(((TTVisual.TTCheckBox)(SittingWoSupportCheckAllMotorDevelopment)).Checked){
                ((TTVisual.TTCheckBox)(SittingWoSupport1MotorDevelopment)).Checked = true;
                ((TTVisual.TTCheckBox)(SittingWoSupport2MotorDevelopment)).Checked = true;
           
            }else{
                ((TTVisual.TTCheckBox)(SittingWoSupport1MotorDevelopment)).Checked = false;
                ((TTVisual.TTCheckBox)(SittingWoSupport2MotorDevelopment)).Checked = false;
            }
#endregion VisitDetailsForm_SittingWoSupportCheckAllMotorDevelopment_CheckedChanged
        }

#region VisitDetailsForm_ClientSideMethods
        public void CalculateBMI()
        {
            /*double bmi = 0, weight = 0,;
            int height = 0 ;
            if(!string.IsNullOrEmpty(this._ChildGrowthVisits.Weight.ToString()) && !string.IsNullOrEmpty(this._ChildGrowthVisits.Height.ToString()))
            {
                weight = Convert.ToDouble(this._ChildGrowthVisits.Weight);
                height = Convert.ToInt32(this._ChildGrowthVisits.Height);
                bmi = weight / ((height / 100) * (height / 100));
                this._ChildGrowthVisits.BMI = Math.Round(bmi, 2);
            }
            
           */
        }
        
#endregion VisitDetailsForm_ClientSideMethods
    }
}