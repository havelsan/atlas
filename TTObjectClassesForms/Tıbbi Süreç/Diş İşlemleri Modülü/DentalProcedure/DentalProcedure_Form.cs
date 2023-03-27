
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
    /// Diş İşlemleri
    /// </summary>
    public partial class DentalProcedure : TTForm
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
#region DentalProcedure_ttbuttonLeftUpperJaw_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.leftUpperJaw5;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbuttonLeftUpperJaw_Click
        }

        private void ttbuttonRightUpperJaw_Click()
        {
#region DentalProcedure_ttbuttonRightUpperJaw_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.rightUpperJaw4;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbuttonRightUpperJaw_Click
        }

        private void ttbuttonUpperJaw_Click()
        {
#region DentalProcedure_ttbuttonUpperJaw_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.upperJaw2;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.UpperJaw;
#endregion DentalProcedure_ttbuttonUpperJaw_Click
        }

        private void ttbuttonWholeJaw_Click()
        {
#region DentalProcedure_ttbuttonWholeJaw_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.wholeJaw1;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.AllJaw;
#endregion DentalProcedure_ttbuttonWholeJaw_Click
        }

        private void ttbuttonLeftLowerJaw_Click()
        {
#region DentalProcedure_ttbuttonLeftLowerJaw_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.leftLowerJaw7;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbuttonLeftLowerJaw_Click
        }

        private void ttbutton37_Click()
        {
#region DentalProcedure_ttbutton37_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth37;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton37_Click
        }

        private void ttbuttonWholeJaw2_Click()
        {
#region DentalProcedure_ttbuttonWholeJaw2_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.wholeJaw1;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.AllJaw;
#endregion DentalProcedure_ttbuttonWholeJaw2_Click
        }

        private void ttbutton32_Click()
        {
#region DentalProcedure_ttbutton32_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth32;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton32_Click
        }

        private void ttbuttonLowerJaw_Click()
        {
#region DentalProcedure_ttbuttonLowerJaw_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.lowerJaw3;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LowerJaw;
#endregion DentalProcedure_ttbuttonLowerJaw_Click
        }

        private void ttbutton94_Click()
        {
#region DentalProcedure_ttbutton94_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.anomalyTooth94;
#endregion DentalProcedure_ttbutton94_Click
        }

        private void ttbuttonRightLowerJaw_Click()
        {
#region DentalProcedure_ttbuttonRightLowerJaw_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.rightLowerJaw6;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbuttonRightLowerJaw_Click
        }

        private void ttbutton38_Click()
        {
#region DentalProcedure_ttbutton38_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth38;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton38_Click
        }

        private void ttbutton42_Click()
        {
#region DentalProcedure_ttbutton42_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth42;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton42_Click
        }

        private void ttbutton71_Click()
        {
#region DentalProcedure_ttbutton71_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth71;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton71_Click
        }

        private void ttbutton33_Click()
        {
#region DentalProcedure_ttbutton33_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth33;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton33_Click
        }

        private void ttbutton47_Click()
        {
#region DentalProcedure_ttbutton47_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth47;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton47_Click
        }

        private void ttbutton28_Click()
        {
#region DentalProcedure_ttbutton28_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth28;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton28_Click
        }

        private void ttbutton81_Click()
        {
#region DentalProcedure_ttbutton81_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth81;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton81_Click
        }

        private void ttbutton31_Click()
        {
#region DentalProcedure_ttbutton31_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth31;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton31_Click
        }

        private void ttbutton92_Click()
        {
#region DentalProcedure_ttbutton92_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.anomalyTooth92;
#endregion DentalProcedure_ttbutton92_Click
        }

        private void ttbutton75_Click()
        {
#region DentalProcedure_ttbutton75_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth75;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton75_Click
        }

        private void ttbutton41_Click()
        {
#region DentalProcedure_ttbutton41_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth41;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton41_Click
        }

        private void ttbutton34_Click()
        {
#region DentalProcedure_ttbutton34_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth34;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton34_Click
        }

        private void ttbutton21_Click()
        {
#region DentalProcedure_ttbutton21_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth21;
        //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton21_Click
        }

        private void ttbutton74_Click()
        {
#region DentalProcedure_ttbutton74_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth74;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton74_Click
        }

        private void ttbutton93_Click()
        {
#region DentalProcedure_ttbutton93_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.anomalyTooth93;
#endregion DentalProcedure_ttbutton93_Click
        }

        private void ttbutton35_Click()
        {
#region DentalProcedure_ttbutton35_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth35;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton35_Click
        }

        private void ttbutton52_Click()
        {
#region DentalProcedure_ttbutton52_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth52;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton52_Click
        }

        private void ttbutton73_Click()
        {
#region DentalProcedure_ttbutton73_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth73;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton73_Click
        }

        private void ttbutton46_Click()
        {
#region DentalProcedure_ttbutton46_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth46;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton46_Click
        }

        private void ttbutton36_Click()
        {
#region DentalProcedure_ttbutton36_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth36;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton36_Click
        }

        private void ttbutton27_Click()
        {
#region DentalProcedure_ttbutton27_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth27;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton27_Click
        }

        private void ttbutton72_Click()
        {
#region DentalProcedure_ttbutton72_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth72;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftLowerJaw;
#endregion DentalProcedure_ttbutton72_Click
        }

        private void ttbutton82_Click()
        {
#region DentalProcedure_ttbutton82_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth82;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton82_Click
        }

        private void ttbutton61_Click()
        {
#region DentalProcedure_ttbutton61_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth61;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton61_Click
        }

        private void ttbutton83_Click()
        {
#region DentalProcedure_ttbutton83_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth83;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton83_Click
        }

        private void ttbutton26_Click()
        {
#region DentalProcedure_ttbutton26_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth26;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton26_Click
        }

        private void ttbutton48_Click()
        {
#region DentalProcedure_ttbutton48_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth48;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton48_Click
        }

        private void ttbutton84_Click()
        {
#region DentalProcedure_ttbutton84_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth84;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton84_Click
        }

        private void ttbutton25_Click()
        {
#region DentalProcedure_ttbutton25_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth25;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton25_Click
        }

        private void ttbutton45_Click()
        {
#region DentalProcedure_ttbutton45_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth45;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton45_Click
        }

        private void ttbutton85_Click()
        {
#region DentalProcedure_ttbutton85_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth85;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton85_Click
        }

        private void ttbutton24_Click()
        {
#region DentalProcedure_ttbutton24_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth24;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton24_Click
        }

        private void ttbutton44_Click()
        {
#region DentalProcedure_ttbutton44_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth44;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton44_Click
        }

        private void ttbutton23_Click()
        {
#region DentalProcedure_ttbutton23_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth23;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton23_Click
        }

        private void ttbutton11_Click()
        {
#region DentalProcedure_ttbutton11_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth11;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton11_Click
        }

        private void ttbutton43_Click()
        {
#region DentalProcedure_ttbutton43_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth43;
            //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightLowerJaw;
#endregion DentalProcedure_ttbutton43_Click
        }

        private void ttbutton22_Click()
        {
#region DentalProcedure_ttbutton22_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth22;
             //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton22_Click
        }

        private void ttbutton51_Click()
        {
#region DentalProcedure_ttbutton51_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth51;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton51_Click
        }

        private void ttbutton65_Click()
        {
#region DentalProcedure_ttbutton65_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth65;
        //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton65_Click
        }

        private void ttbutton64_Click()
        {
#region DentalProcedure_ttbutton64_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth64;
    //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton64_Click
        }

        private void ttbutton18_Click()
        {
#region DentalProcedure_ttbutton18_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth18;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton18_Click
        }

        private void ttbutton63_Click()
        {
#region DentalProcedure_ttbutton63_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth63;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton63_Click
        }

        private void ttbutton62_Click()
        {
#region DentalProcedure_ttbutton62_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth62;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.LeftUpperJaw;
#endregion DentalProcedure_ttbutton62_Click
        }

        private void ttbutton12_Click()
        {
#region DentalProcedure_ttbutton12_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth12;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton12_Click
        }

        private void ttbutton13_Click()
        {
#region DentalProcedure_ttbutton13_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth13;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton13_Click
        }

        private void ttbutton91_Click()
        {
#region DentalProcedure_ttbutton91_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.anomalyTooth91;
#endregion DentalProcedure_ttbutton91_Click
        }

        private void ttbutton14_Click()
        {
#region DentalProcedure_ttbutton14_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth14;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton14_Click
        }

        private void ttbutton55_Click()
        {
#region DentalProcedure_ttbutton55_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth55;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton55_Click
        }

        private void ttbutton15_Click()
        {
#region DentalProcedure_ttbutton15_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth15;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton15_Click
        }

        private void ttbutton54_Click()
        {
#region DentalProcedure_ttbutton54_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth54;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton54_Click
        }

        private void ttbutton16_Click()
        {
#region DentalProcedure_ttbutton16_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth16;
  //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton16_Click
        }

        private void ttbutton53_Click()
        {
#region DentalProcedure_ttbutton53_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.milkTooth53;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton53_Click
        }

        private void ttbutton17_Click()
        {
#region DentalProcedure_ttbutton17_Click
   this._DentalProcedure.ToothNumber = ToothNumberEnum.adultTooth17;
   //this._DentalProcedure.DentalPosition = DentalPositionEnum.RightUpperJaw;
#endregion DentalProcedure_ttbutton17_Click
        }

        protected override void PreScript()
        {
#region DentalProcedure_PreScript
    base.PreScript();
#endregion DentalProcedure_PreScript

            }
                }
}