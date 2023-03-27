
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
    public partial class DentalToothSchemaSugProsthesis : TTForm
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
#region DentalToothSchemaSugProsthesis_ttbuttonLeftUpperJaw_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.leftUpperJaw5;
            //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbuttonLeftUpperJaw_Click
        }

        private void ttbuttonRightUpperJaw_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbuttonRightUpperJaw_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.rightUpperJaw4;
            //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbuttonRightUpperJaw_Click
        }

        private void ttbuttonUpperJaw_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbuttonUpperJaw_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.upperJaw2;
            //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.UpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbuttonUpperJaw_Click
        }

        private void ttbuttonWholeJaw_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbuttonWholeJaw_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.wholeJaw1;
            //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.AllJaw;
#endregion DentalToothSchemaSugProsthesis_ttbuttonWholeJaw_Click
        }

        private void ttbuttonLeftLowerJaw_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbuttonLeftLowerJaw_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.leftLowerJaw7;
            //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbuttonLeftLowerJaw_Click
        }

        private void ttbutton37_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton37_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth37;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton37_Click
        }

        private void ttbuttonWholeJaw2_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbuttonWholeJaw2_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.wholeJaw1;
            //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.AllJaw;
#endregion DentalToothSchemaSugProsthesis_ttbuttonWholeJaw2_Click
        }

        private void ttbutton32_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton32_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth32;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton32_Click
        }

        private void ttbuttonLowerJaw_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbuttonLowerJaw_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.lowerJaw3;
            //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbuttonLowerJaw_Click
        }

        private void ttbutton94_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton94_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.anomalyTooth94;
#endregion DentalToothSchemaSugProsthesis_ttbutton94_Click
        }

        private void ttbuttonRightLowerJaw_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbuttonRightLowerJaw_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.rightLowerJaw6;
            //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbuttonRightLowerJaw_Click
        }

        private void ttbutton38_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton38_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth38;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton38_Click
        }

        private void ttbutton42_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton42_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth42;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton42_Click
        }

        private void ttbutton71_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton71_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth71;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton71_Click
        }

        private void ttbutton33_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton33_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth33;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton33_Click
        }

        private void ttbutton47_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton47_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth47;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton47_Click
        }

        private void ttbutton28_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton28_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth28;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton28_Click
        }

        private void ttbutton81_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton81_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth81;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton81_Click
        }

        private void ttbutton31_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton31_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth31;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton31_Click
        }

        private void ttbutton92_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton92_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.anomalyTooth92;
#endregion DentalToothSchemaSugProsthesis_ttbutton92_Click
        }

        private void ttbutton75_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton75_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth75;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton75_Click
        }

        private void ttbutton41_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton41_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth41;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton41_Click
        }

        private void ttbutton34_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton34_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth34;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton34_Click
        }

        private void ttbutton21_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton21_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth21;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton21_Click
        }

        private void ttbutton74_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton74_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth74;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton74_Click
        }

        private void ttbutton93_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton93_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.anomalyTooth93;
#endregion DentalToothSchemaSugProsthesis_ttbutton93_Click
        }

        private void ttbutton35_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton35_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth35;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton35_Click
        }

        private void ttbutton52_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton52_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth52;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton52_Click
        }

        private void ttbutton73_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton73_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth73;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton73_Click
        }

        private void ttbutton46_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton46_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth46;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton46_Click
        }

        private void ttbutton36_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton36_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth36;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton36_Click
        }

        private void ttbutton27_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton27_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth27;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton27_Click
        }

        private void ttbutton72_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton72_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth72;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton72_Click
        }

        private void ttbutton82_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton82_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth82;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton82_Click
        }

        private void ttbutton61_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton61_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth61;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton61_Click
        }

        private void ttbutton83_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton83_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth83;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton83_Click
        }

        private void ttbutton26_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton26_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth26;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton26_Click
        }

        private void ttbutton48_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton48_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth48;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton48_Click
        }

        private void ttbutton84_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton84_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth84;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton84_Click
        }

        private void ttbutton25_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton25_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth25;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton25_Click
        }

        private void ttbutton45_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton45_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth45;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton45_Click
        }

        private void ttbutton85_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton85_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth85;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton85_Click
        }

        private void ttbutton24_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton24_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth24;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton24_Click
        }

        private void ttbutton44_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton44_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth44;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton44_Click
        }

        private void ttbutton23_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton23_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth23;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton23_Click
        }

        private void ttbutton11_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton11_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth11;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton11_Click
        }

        private void ttbutton43_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton43_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth43;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton43_Click
        }

        private void ttbutton22_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton22_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth22;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton22_Click
        }

        private void ttbutton51_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton51_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth51;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton51_Click
        }

        private void ttbutton65_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton65_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth65;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton65_Click
        }

        private void ttbutton64_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton64_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth64;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton64_Click
        }

        private void ttbutton18_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton18_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth18;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton18_Click
        }

        private void ttbutton63_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton63_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth63;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton63_Click
        }

        private void ttbutton62_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton62_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth62;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton62_Click
        }

        private void ttbutton12_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton12_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth12;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton12_Click
        }

        private void ttbutton13_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton13_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth13;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton13_Click
        }

        private void ttbutton91_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton91_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.anomalyTooth91;
#endregion DentalToothSchemaSugProsthesis_ttbutton91_Click
        }

        private void ttbutton14_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton14_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth14;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton14_Click
        }

        private void ttbutton55_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton55_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth55;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton55_Click
        }

        private void ttbutton15_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton15_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth15;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton15_Click
        }

        private void ttbutton54_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton54_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth54;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton54_Click
        }

        private void ttbutton16_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton16_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth16;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton16_Click
        }

        private void ttbutton53_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton53_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.milkTooth53;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton53_Click
        }

        private void ttbutton17_Click()
        {
#region DentalToothSchemaSugProsthesis_ttbutton17_Click
   this._DentalExaminationSuggestedProsthesis.ToothNumber = ToothNumberEnum.adultTooth17;
   //this._DentalExaminationSuggestedProsthesis.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchemaSugProsthesis_ttbutton17_Click
        }
    }
}