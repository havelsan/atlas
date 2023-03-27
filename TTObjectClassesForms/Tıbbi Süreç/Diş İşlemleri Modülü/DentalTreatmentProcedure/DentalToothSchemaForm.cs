
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
    public partial class DentalToothSchema : TTForm
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
#region DentalToothSchema_ttbuttonLeftUpperJaw_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.leftUpperJaw5;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbuttonLeftUpperJaw_Click
        }

        private void ttbuttonRightUpperJaw_Click()
        {
#region DentalToothSchema_ttbuttonRightUpperJaw_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.rightUpperJaw4;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbuttonRightUpperJaw_Click
        }

        private void ttbuttonUpperJaw_Click()
        {
#region DentalToothSchema_ttbuttonUpperJaw_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.upperJaw2;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.UpperJaw;
#endregion DentalToothSchema_ttbuttonUpperJaw_Click
        }

        private void ttbuttonWholeJaw_Click()
        {
#region DentalToothSchema_ttbuttonWholeJaw_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.wholeJaw1;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.AllJaw;
#endregion DentalToothSchema_ttbuttonWholeJaw_Click
        }

        private void ttbuttonLeftLowerJaw_Click()
        {
#region DentalToothSchema_ttbuttonLeftLowerJaw_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.leftLowerJaw7;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbuttonLeftLowerJaw_Click
        }

        private void ttbutton37_Click()
        {
#region DentalToothSchema_ttbutton37_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth37;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton37_Click
        }

        private void ttbuttonWholeJaw2_Click()
        {
#region DentalToothSchema_ttbuttonWholeJaw2_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.wholeJaw1;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.AllJaw;
#endregion DentalToothSchema_ttbuttonWholeJaw2_Click
        }

        private void ttbutton32_Click()
        {
#region DentalToothSchema_ttbutton32_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth32;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton32_Click
        }

        private void ttbuttonLowerJaw_Click()
        {
#region DentalToothSchema_ttbuttonLowerJaw_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.lowerJaw3;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LowerJaw;
#endregion DentalToothSchema_ttbuttonLowerJaw_Click
        }

        private void ttbutton94_Click()
        {
#region DentalToothSchema_ttbutton94_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.anomalyTooth94;
#endregion DentalToothSchema_ttbutton94_Click
        }

        private void ttbuttonRightLowerJaw_Click()
        {
#region DentalToothSchema_ttbuttonRightLowerJaw_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.rightLowerJaw6;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbuttonRightLowerJaw_Click
        }

        private void ttbutton38_Click()
        {
#region DentalToothSchema_ttbutton38_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth38;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton38_Click
        }

        private void ttbutton42_Click()
        {
#region DentalToothSchema_ttbutton42_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth42;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton42_Click
        }

        private void ttbutton71_Click()
        {
#region DentalToothSchema_ttbutton71_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth71;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton71_Click
        }

        private void ttbutton33_Click()
        {
#region DentalToothSchema_ttbutton33_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth33;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton33_Click
        }

        private void ttbutton47_Click()
        {
#region DentalToothSchema_ttbutton47_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth47;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton47_Click
        }

        private void ttbutton28_Click()
        {
#region DentalToothSchema_ttbutton28_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth28;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton28_Click
        }

        private void ttbutton81_Click()
        {
#region DentalToothSchema_ttbutton81_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth81;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton81_Click
        }

        private void ttbutton31_Click()
        {
#region DentalToothSchema_ttbutton31_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth31;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton31_Click
        }

        private void ttbutton92_Click()
        {
#region DentalToothSchema_ttbutton92_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.anomalyTooth92;
#endregion DentalToothSchema_ttbutton92_Click
        }

        private void ttbutton75_Click()
        {
#region DentalToothSchema_ttbutton75_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth75;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton75_Click
        }

        private void ttbutton41_Click()
        {
#region DentalToothSchema_ttbutton41_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth41;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton41_Click
        }

        private void ttbutton34_Click()
        {
#region DentalToothSchema_ttbutton34_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth34;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton34_Click
        }

        private void ttbutton21_Click()
        {
#region DentalToothSchema_ttbutton21_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth21;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton21_Click
        }

        private void ttbutton74_Click()
        {
#region DentalToothSchema_ttbutton74_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth74;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton74_Click
        }

        private void ttbutton93_Click()
        {
#region DentalToothSchema_ttbutton93_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.anomalyTooth93;
#endregion DentalToothSchema_ttbutton93_Click
        }

        private void ttbutton35_Click()
        {
#region DentalToothSchema_ttbutton35_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth35;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton35_Click
        }

        private void ttbutton52_Click()
        {
#region DentalToothSchema_ttbutton52_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth52;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton52_Click
        }

        private void ttbutton73_Click()
        {
#region DentalToothSchema_ttbutton73_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth73;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton73_Click
        }

        private void ttbutton46_Click()
        {
#region DentalToothSchema_ttbutton46_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth46;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton46_Click
        }

        private void ttbutton36_Click()
        {
#region DentalToothSchema_ttbutton36_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth36;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton36_Click
        }

        private void ttbutton27_Click()
        {
#region DentalToothSchema_ttbutton27_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth27;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton27_Click
        }

        private void ttbutton72_Click()
        {
#region DentalToothSchema_ttbutton72_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth72;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalToothSchema_ttbutton72_Click
        }

        private void ttbutton82_Click()
        {
#region DentalToothSchema_ttbutton82_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth82;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton82_Click
        }

        private void ttbutton61_Click()
        {
#region DentalToothSchema_ttbutton61_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth61;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton61_Click
        }

        private void ttbutton83_Click()
        {
#region DentalToothSchema_ttbutton83_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth83;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton83_Click
        }

        private void ttbutton26_Click()
        {
#region DentalToothSchema_ttbutton26_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth26;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton26_Click
        }

        private void ttbutton48_Click()
        {
#region DentalToothSchema_ttbutton48_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth48;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton48_Click
        }

        private void ttbutton84_Click()
        {
#region DentalToothSchema_ttbutton84_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth84;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton84_Click
        }

        private void ttbutton25_Click()
        {
#region DentalToothSchema_ttbutton25_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth25;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton25_Click
        }

        private void ttbutton45_Click()
        {
#region DentalToothSchema_ttbutton45_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth45;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton45_Click
        }

        private void ttbutton85_Click()
        {
#region DentalToothSchema_ttbutton85_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth85;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton85_Click
        }

        private void ttbutton24_Click()
        {
#region DentalToothSchema_ttbutton24_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth24;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton24_Click
        }

        private void ttbutton44_Click()
        {
#region DentalToothSchema_ttbutton44_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth44;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton44_Click
        }

        private void ttbutton23_Click()
        {
#region DentalToothSchema_ttbutton23_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth23;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton23_Click
        }

        private void ttbutton11_Click()
        {
#region DentalToothSchema_ttbutton11_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth11;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton11_Click
        }

        private void ttbutton43_Click()
        {
#region DentalToothSchema_ttbutton43_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth43;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalToothSchema_ttbutton43_Click
        }

        private void ttbutton22_Click()
        {
#region DentalToothSchema_ttbutton22_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth22;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton22_Click
        }

        private void ttbutton51_Click()
        {
#region DentalToothSchema_ttbutton51_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth51;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton51_Click
        }

        private void ttbutton65_Click()
        {
#region DentalToothSchema_ttbutton65_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth65;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton65_Click
        }

        private void ttbutton64_Click()
        {
#region DentalToothSchema_ttbutton64_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth64;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton64_Click
        }

        private void ttbutton18_Click()
        {
#region DentalToothSchema_ttbutton18_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth18;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton18_Click
        }

        private void ttbutton63_Click()
        {
#region DentalToothSchema_ttbutton63_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth63;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton63_Click
        }

        private void ttbutton62_Click()
        {
#region DentalToothSchema_ttbutton62_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth62;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalToothSchema_ttbutton62_Click
        }

        private void ttbutton12_Click()
        {
#region DentalToothSchema_ttbutton12_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth12;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton12_Click
        }

        private void ttbutton13_Click()
        {
#region DentalToothSchema_ttbutton13_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth13;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton13_Click
        }

        private void ttbutton91_Click()
        {
#region DentalToothSchema_ttbutton91_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.anomalyTooth91;
#endregion DentalToothSchema_ttbutton91_Click
        }

        private void ttbutton14_Click()
        {
#region DentalToothSchema_ttbutton14_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth14;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton14_Click
        }

        private void ttbutton55_Click()
        {
#region DentalToothSchema_ttbutton55_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth55;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton55_Click
        }

        private void ttbutton15_Click()
        {
#region DentalToothSchema_ttbutton15_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth15;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton15_Click
        }

        private void ttbutton54_Click()
        {
#region DentalToothSchema_ttbutton54_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth54;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton54_Click
        }

        private void ttbutton16_Click()
        {
#region DentalToothSchema_ttbutton16_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth16;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton16_Click
        }

        private void ttbutton53_Click()
        {
#region DentalToothSchema_ttbutton53_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.milkTooth53;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton53_Click
        }

        private void ttbutton17_Click()
        {
#region DentalToothSchema_ttbutton17_Click
   this._DentalTreatmentProcedure.ToothNumber = ToothNumberEnum.adultTooth17;
            //this._DentalTreatmentProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalToothSchema_ttbutton17_Click
        }

        protected override void PreScript()
        {
#region DentalToothSchema_PreScript
    base.PreScript();
#endregion DentalToothSchema_PreScript

            }
                }
}