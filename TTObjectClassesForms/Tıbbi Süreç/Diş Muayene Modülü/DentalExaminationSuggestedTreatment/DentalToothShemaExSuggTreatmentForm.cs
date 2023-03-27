
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
    /// <summary>
    /// Diş Şeması
    /// </summary>
    public partial class DentalToothShemaExSuggTreatmentForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ttbuttonLeftUpperJaw.Click += new TTControlEventDelegate(ttbuttonLeftUpperJaw_Click);
            ttbuttonRightUpperJaw.Click += new TTControlEventDelegate(ttbuttonRightUpperJaw_Click);
            ttbuttonUpperJaw.Click += new TTControlEventDelegate(ttbuttonUpperJaw_Click);
            ttbuttonWholeJaw.Click += new TTControlEventDelegate(ttbuttonWholeJaw_Click);
            ttbuttonLeftLowerJaw.Click += new TTControlEventDelegate(ttbuttonLeftLowerJaw_Click);
            ttbutton37.Click += new TTControlEventDelegate(ttbutton37_Click);
            ttbuttonWholeJaw2.Click += new TTControlEventDelegate(ttbuttonWholeJaw2_Click);
            ttbutton32.Click += new TTControlEventDelegate(ttbutton32_Click);
            ttbuttonLowerJaw.Click += new TTControlEventDelegate(ttbuttonLowerJaw_Click);
            ttbutton94.Click += new TTControlEventDelegate(ttbutton94_Click);
            ttbuttonRightLowerJaw.Click += new TTControlEventDelegate(ttbuttonRightLowerJaw_Click);
            ttbutton38.Click += new TTControlEventDelegate(ttbutton38_Click);
            ttbutton42.Click += new TTControlEventDelegate(ttbutton42_Click);
            ttbutton71.Click += new TTControlEventDelegate(ttbutton71_Click);
            ttbutton33.Click += new TTControlEventDelegate(ttbutton33_Click);
            ttbutton47.Click += new TTControlEventDelegate(ttbutton47_Click);
            ttbutton28.Click += new TTControlEventDelegate(ttbutton28_Click);
            ttbutton81.Click += new TTControlEventDelegate(ttbutton81_Click);
            ttbutton31.Click += new TTControlEventDelegate(ttbutton31_Click);
            ttbutton92.Click += new TTControlEventDelegate(ttbutton92_Click);
            ttbutton75.Click += new TTControlEventDelegate(ttbutton75_Click);
            ttbutton41.Click += new TTControlEventDelegate(ttbutton41_Click);
            ttbutton34.Click += new TTControlEventDelegate(ttbutton34_Click);
            ttbutton21.Click += new TTControlEventDelegate(ttbutton21_Click);
            ttbutton74.Click += new TTControlEventDelegate(ttbutton74_Click);
            ttbutton93.Click += new TTControlEventDelegate(ttbutton93_Click);
            ttbutton35.Click += new TTControlEventDelegate(ttbutton35_Click);
            ttbutton52.Click += new TTControlEventDelegate(ttbutton52_Click);
            ttbutton73.Click += new TTControlEventDelegate(ttbutton73_Click);
            ttbutton46.Click += new TTControlEventDelegate(ttbutton46_Click);
            ttbutton36.Click += new TTControlEventDelegate(ttbutton36_Click);
            ttbutton27.Click += new TTControlEventDelegate(ttbutton27_Click);
            ttbutton72.Click += new TTControlEventDelegate(ttbutton72_Click);
            ttbutton82.Click += new TTControlEventDelegate(ttbutton82_Click);
            ttbutton61.Click += new TTControlEventDelegate(ttbutton61_Click);
            ttbutton83.Click += new TTControlEventDelegate(ttbutton83_Click);
            ttbutton26.Click += new TTControlEventDelegate(ttbutton26_Click);
            ttbutton48.Click += new TTControlEventDelegate(ttbutton48_Click);
            ttbutton84.Click += new TTControlEventDelegate(ttbutton84_Click);
            ttbutton25.Click += new TTControlEventDelegate(ttbutton25_Click);
            ttbutton45.Click += new TTControlEventDelegate(ttbutton45_Click);
            ttbutton85.Click += new TTControlEventDelegate(ttbutton85_Click);
            ttbutton24.Click += new TTControlEventDelegate(ttbutton24_Click);
            ttbutton44.Click += new TTControlEventDelegate(ttbutton44_Click);
            ttbutton23.Click += new TTControlEventDelegate(ttbutton23_Click);
            ttbutton11.Click += new TTControlEventDelegate(ttbutton11_Click);
            ttbutton43.Click += new TTControlEventDelegate(ttbutton43_Click);
            ttbutton22.Click += new TTControlEventDelegate(ttbutton22_Click);
            ttbutton51.Click += new TTControlEventDelegate(ttbutton51_Click);
            ttbutton65.Click += new TTControlEventDelegate(ttbutton65_Click);
            ttbutton64.Click += new TTControlEventDelegate(ttbutton64_Click);
            ttbutton18.Click += new TTControlEventDelegate(ttbutton18_Click);
            ttbutton63.Click += new TTControlEventDelegate(ttbutton63_Click);
            ttbutton62.Click += new TTControlEventDelegate(ttbutton62_Click);
            ttbutton12.Click += new TTControlEventDelegate(ttbutton12_Click);
            ttbutton13.Click += new TTControlEventDelegate(ttbutton13_Click);
            ttbutton91.Click += new TTControlEventDelegate(ttbutton91_Click);
            ttbutton14.Click += new TTControlEventDelegate(ttbutton14_Click);
            ttbutton55.Click += new TTControlEventDelegate(ttbutton55_Click);
            ttbutton15.Click += new TTControlEventDelegate(ttbutton15_Click);
            ttbutton54.Click += new TTControlEventDelegate(ttbutton54_Click);
            ttbutton16.Click += new TTControlEventDelegate(ttbutton16_Click);
            ttbutton53.Click += new TTControlEventDelegate(ttbutton53_Click);
            ttbutton17.Click += new TTControlEventDelegate(ttbutton17_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbuttonLeftUpperJaw.Click -= new TTControlEventDelegate(ttbuttonLeftUpperJaw_Click);
            ttbuttonRightUpperJaw.Click -= new TTControlEventDelegate(ttbuttonRightUpperJaw_Click);
            ttbuttonUpperJaw.Click -= new TTControlEventDelegate(ttbuttonUpperJaw_Click);
            ttbuttonWholeJaw.Click -= new TTControlEventDelegate(ttbuttonWholeJaw_Click);
            ttbuttonLeftLowerJaw.Click -= new TTControlEventDelegate(ttbuttonLeftLowerJaw_Click);
            ttbutton37.Click -= new TTControlEventDelegate(ttbutton37_Click);
            ttbuttonWholeJaw2.Click -= new TTControlEventDelegate(ttbuttonWholeJaw2_Click);
            ttbutton32.Click -= new TTControlEventDelegate(ttbutton32_Click);
            ttbuttonLowerJaw.Click -= new TTControlEventDelegate(ttbuttonLowerJaw_Click);
            ttbutton94.Click -= new TTControlEventDelegate(ttbutton94_Click);
            ttbuttonRightLowerJaw.Click -= new TTControlEventDelegate(ttbuttonRightLowerJaw_Click);
            ttbutton38.Click -= new TTControlEventDelegate(ttbutton38_Click);
            ttbutton42.Click -= new TTControlEventDelegate(ttbutton42_Click);
            ttbutton71.Click -= new TTControlEventDelegate(ttbutton71_Click);
            ttbutton33.Click -= new TTControlEventDelegate(ttbutton33_Click);
            ttbutton47.Click -= new TTControlEventDelegate(ttbutton47_Click);
            ttbutton28.Click -= new TTControlEventDelegate(ttbutton28_Click);
            ttbutton81.Click -= new TTControlEventDelegate(ttbutton81_Click);
            ttbutton31.Click -= new TTControlEventDelegate(ttbutton31_Click);
            ttbutton92.Click -= new TTControlEventDelegate(ttbutton92_Click);
            ttbutton75.Click -= new TTControlEventDelegate(ttbutton75_Click);
            ttbutton41.Click -= new TTControlEventDelegate(ttbutton41_Click);
            ttbutton34.Click -= new TTControlEventDelegate(ttbutton34_Click);
            ttbutton21.Click -= new TTControlEventDelegate(ttbutton21_Click);
            ttbutton74.Click -= new TTControlEventDelegate(ttbutton74_Click);
            ttbutton93.Click -= new TTControlEventDelegate(ttbutton93_Click);
            ttbutton35.Click -= new TTControlEventDelegate(ttbutton35_Click);
            ttbutton52.Click -= new TTControlEventDelegate(ttbutton52_Click);
            ttbutton73.Click -= new TTControlEventDelegate(ttbutton73_Click);
            ttbutton46.Click -= new TTControlEventDelegate(ttbutton46_Click);
            ttbutton36.Click -= new TTControlEventDelegate(ttbutton36_Click);
            ttbutton27.Click -= new TTControlEventDelegate(ttbutton27_Click);
            ttbutton72.Click -= new TTControlEventDelegate(ttbutton72_Click);
            ttbutton82.Click -= new TTControlEventDelegate(ttbutton82_Click);
            ttbutton61.Click -= new TTControlEventDelegate(ttbutton61_Click);
            ttbutton83.Click -= new TTControlEventDelegate(ttbutton83_Click);
            ttbutton26.Click -= new TTControlEventDelegate(ttbutton26_Click);
            ttbutton48.Click -= new TTControlEventDelegate(ttbutton48_Click);
            ttbutton84.Click -= new TTControlEventDelegate(ttbutton84_Click);
            ttbutton25.Click -= new TTControlEventDelegate(ttbutton25_Click);
            ttbutton45.Click -= new TTControlEventDelegate(ttbutton45_Click);
            ttbutton85.Click -= new TTControlEventDelegate(ttbutton85_Click);
            ttbutton24.Click -= new TTControlEventDelegate(ttbutton24_Click);
            ttbutton44.Click -= new TTControlEventDelegate(ttbutton44_Click);
            ttbutton23.Click -= new TTControlEventDelegate(ttbutton23_Click);
            ttbutton11.Click -= new TTControlEventDelegate(ttbutton11_Click);
            ttbutton43.Click -= new TTControlEventDelegate(ttbutton43_Click);
            ttbutton22.Click -= new TTControlEventDelegate(ttbutton22_Click);
            ttbutton51.Click -= new TTControlEventDelegate(ttbutton51_Click);
            ttbutton65.Click -= new TTControlEventDelegate(ttbutton65_Click);
            ttbutton64.Click -= new TTControlEventDelegate(ttbutton64_Click);
            ttbutton18.Click -= new TTControlEventDelegate(ttbutton18_Click);
            ttbutton63.Click -= new TTControlEventDelegate(ttbutton63_Click);
            ttbutton62.Click -= new TTControlEventDelegate(ttbutton62_Click);
            ttbutton12.Click -= new TTControlEventDelegate(ttbutton12_Click);
            ttbutton13.Click -= new TTControlEventDelegate(ttbutton13_Click);
            ttbutton91.Click -= new TTControlEventDelegate(ttbutton91_Click);
            ttbutton14.Click -= new TTControlEventDelegate(ttbutton14_Click);
            ttbutton55.Click -= new TTControlEventDelegate(ttbutton55_Click);
            ttbutton15.Click -= new TTControlEventDelegate(ttbutton15_Click);
            ttbutton54.Click -= new TTControlEventDelegate(ttbutton54_Click);
            ttbutton16.Click -= new TTControlEventDelegate(ttbutton16_Click);
            ttbutton53.Click -= new TTControlEventDelegate(ttbutton53_Click);
            ttbutton17.Click -= new TTControlEventDelegate(ttbutton17_Click);
            base.UnBindControlEvents();
        }

        private void ttbuttonLeftUpperJaw_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbuttonLeftUpperJaw_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.leftUpperJaw5;
          //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbuttonLeftUpperJaw_Click
        }

        private void ttbuttonRightUpperJaw_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbuttonRightUpperJaw_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.rightUpperJaw4;
            //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbuttonRightUpperJaw_Click
        }

        private void ttbuttonUpperJaw_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbuttonUpperJaw_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.upperJaw2;
            //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.UpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbuttonUpperJaw_Click
        }

        private void ttbuttonWholeJaw_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbuttonWholeJaw_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.wholeJaw1;
            //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.AllJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbuttonWholeJaw_Click
        }

        private void ttbuttonLeftLowerJaw_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbuttonLeftLowerJaw_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.leftLowerJaw7;
            //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbuttonLeftLowerJaw_Click
        }

        private void ttbutton37_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton37_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth37;
            //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton37_Click
        }

        private void ttbuttonWholeJaw2_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbuttonWholeJaw2_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.wholeJaw1;
            //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.AllJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbuttonWholeJaw2_Click
        }

        private void ttbutton32_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton32_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth32;
            //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton32_Click
        }

        private void ttbuttonLowerJaw_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbuttonLowerJaw_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.lowerJaw3;
            //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbuttonLowerJaw_Click
        }

        private void ttbutton94_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton94_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.anomalyTooth94;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton94_Click
        }

        private void ttbuttonRightLowerJaw_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbuttonRightLowerJaw_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.rightLowerJaw6;
            //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbuttonRightLowerJaw_Click
        }

        private void ttbutton38_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton38_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth38;
            //this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton38_Click
        }

        private void ttbutton42_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton42_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth42;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton42_Click
        }

        private void ttbutton71_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton71_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth71;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton71_Click
        }

        private void ttbutton33_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton33_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth33;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton33_Click
        }

        private void ttbutton47_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton47_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth47;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton47_Click
        }

        private void ttbutton28_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton28_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth28;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton28_Click
        }

        private void ttbutton81_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton81_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth81;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton81_Click
        }

        private void ttbutton31_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton31_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth31;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton31_Click
        }

        private void ttbutton92_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton92_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.anomalyTooth92;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton92_Click
        }

        private void ttbutton75_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton75_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth75;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton75_Click
        }

        private void ttbutton41_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton41_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth41;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton41_Click
        }

        private void ttbutton34_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton34_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth34;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton34_Click
        }

        private void ttbutton21_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton21_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth21;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton21_Click
        }

        private void ttbutton74_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton74_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth74;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton74_Click
        }

        private void ttbutton93_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton93_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.anomalyTooth93;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton93_Click
        }

        private void ttbutton35_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton35_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth35;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton35_Click
        }

        private void ttbutton52_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton52_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth52;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton52_Click
        }

        private void ttbutton73_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton73_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth73;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton73_Click
        }

        private void ttbutton46_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton46_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth46;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton46_Click
        }

        private void ttbutton36_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton36_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth36;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton36_Click
        }

        private void ttbutton27_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton27_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth27;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton27_Click
        }

        private void ttbutton72_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton72_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth72;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton72_Click
        }

        private void ttbutton82_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton82_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth82;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton82_Click
        }

        private void ttbutton61_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton61_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth61;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton61_Click
        }

        private void ttbutton83_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton83_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth83;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton83_Click
        }

        private void ttbutton26_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton26_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth26;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton26_Click
        }

        private void ttbutton48_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton48_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth48;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton48_Click
        }

        private void ttbutton84_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton84_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth84;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton84_Click
        }

        private void ttbutton25_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton25_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth25;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton25_Click
        }

        private void ttbutton45_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton45_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth45;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton45_Click
        }

        private void ttbutton85_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton85_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth85;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton85_Click
        }

        private void ttbutton24_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton24_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth24;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton24_Click
        }

        private void ttbutton44_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton44_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth44;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton44_Click
        }

        private void ttbutton23_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton23_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth23;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton23_Click
        }

        private void ttbutton11_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton11_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth11;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton11_Click
        }

        private void ttbutton43_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton43_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth43;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton43_Click
        }

        private void ttbutton22_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton22_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth22;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton22_Click
        }

        private void ttbutton51_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton51_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth51;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton51_Click
        }

        private void ttbutton65_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton65_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth65;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton65_Click
        }

        private void ttbutton64_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton64_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth64;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton64_Click
        }

        private void ttbutton18_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton18_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth18;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton18_Click
        }

        private void ttbutton63_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton63_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth63;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton63_Click
        }

        private void ttbutton62_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton62_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth62;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton62_Click
        }

        private void ttbutton12_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton12_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth12;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton12_Click
        }

        private void ttbutton13_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton13_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth13;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton13_Click
        }

        private void ttbutton91_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton91_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.anomalyTooth91;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton91_Click
        }

        private void ttbutton14_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton14_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth14;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton14_Click
        }

        private void ttbutton55_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton55_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth55;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton55_Click
        }

        private void ttbutton15_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton15_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth15;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton15_Click
        }

        private void ttbutton54_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton54_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth54;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton54_Click
        }

        private void ttbutton16_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton16_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth16;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton16_Click
        }

        private void ttbutton53_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton53_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.milkTooth53;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton53_Click
        }

        private void ttbutton17_Click()
        {
#region DentalToothShemaExSuggTreatmentForm_ttbutton17_Click
   this._DentalExaminationSuggestedTreatment.ToothNumber = ToothNumberEnum.adultTooth17;
//this._DentalExaminationSuggestedTreatment.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothShemaExSuggTreatmentForm_ttbutton17_Click
        }
    }
}