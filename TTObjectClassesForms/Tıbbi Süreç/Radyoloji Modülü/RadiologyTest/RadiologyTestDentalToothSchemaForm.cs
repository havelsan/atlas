
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
    public partial class RadiologyTestDentalToothSchema : TTForm
    {
        override protected void BindControlEvents()
        {
            ttbutton94.Click += new TTControlEventDelegate(ttbutton94_Click);
            ttbutton75.Click += new TTControlEventDelegate(ttbutton75_Click);
            ttbutton74.Click += new TTControlEventDelegate(ttbutton74_Click);
            ttbutton73.Click += new TTControlEventDelegate(ttbutton73_Click);
            ttbutton72.Click += new TTControlEventDelegate(ttbutton72_Click);
            ttbutton71.Click += new TTControlEventDelegate(ttbutton71_Click);
            ttbutton37.Click += new TTControlEventDelegate(ttbutton37_Click);
            ttbutton36.Click += new TTControlEventDelegate(ttbutton36_Click);
            ttbutton35.Click += new TTControlEventDelegate(ttbutton35_Click);
            ttbutton38.Click += new TTControlEventDelegate(ttbutton38_Click);
            ttbutton34.Click += new TTControlEventDelegate(ttbutton34_Click);
            ttbutton31.Click += new TTControlEventDelegate(ttbutton31_Click);
            ttbutton32.Click += new TTControlEventDelegate(ttbutton32_Click);
            ttbutton33.Click += new TTControlEventDelegate(ttbutton33_Click);
            ttbuttonWholeJaw2.Click += new TTControlEventDelegate(ttbuttonWholeJaw2_Click);
            ttbuttonLowerJaw.Click += new TTControlEventDelegate(ttbuttonLowerJaw_Click);
            ttbutton19.Click += new TTControlEventDelegate(ttbutton19_Click);
            ttbuttonRightLowerJaw.Click += new TTControlEventDelegate(ttbuttonRightLowerJaw_Click);
            ttbutton93.Click += new TTControlEventDelegate(ttbutton93_Click);
            ttbutton84.Click += new TTControlEventDelegate(ttbutton84_Click);
            ttbutton85.Click += new TTControlEventDelegate(ttbutton85_Click);
            ttbutton83.Click += new TTControlEventDelegate(ttbutton83_Click);
            ttbutton82.Click += new TTControlEventDelegate(ttbutton82_Click);
            ttbutton81.Click += new TTControlEventDelegate(ttbutton81_Click);
            ttbutton44.Click += new TTControlEventDelegate(ttbutton44_Click);
            ttbutton41.Click += new TTControlEventDelegate(ttbutton41_Click);
            ttbutton42.Click += new TTControlEventDelegate(ttbutton42_Click);
            ttbutton43.Click += new TTControlEventDelegate(ttbutton43_Click);
            ttbutton45.Click += new TTControlEventDelegate(ttbutton45_Click);
            ttbutton46.Click += new TTControlEventDelegate(ttbutton46_Click);
            ttbutton47.Click += new TTControlEventDelegate(ttbutton47_Click);
            ttbutton48.Click += new TTControlEventDelegate(ttbutton48_Click);
            ttbutton28.Click += new TTControlEventDelegate(ttbutton28_Click);
            ttbutton27.Click += new TTControlEventDelegate(ttbutton27_Click);
            ttbutton26.Click += new TTControlEventDelegate(ttbutton26_Click);
            ttbutton25.Click += new TTControlEventDelegate(ttbutton25_Click);
            ttbutton24.Click += new TTControlEventDelegate(ttbutton24_Click);
            ttbutton23.Click += new TTControlEventDelegate(ttbutton23_Click);
            ttbutton22.Click += new TTControlEventDelegate(ttbutton22_Click);
            ttbutton21.Click += new TTControlEventDelegate(ttbutton21_Click);
            ttbutton92.Click += new TTControlEventDelegate(ttbutton92_Click);
            ttbutton65.Click += new TTControlEventDelegate(ttbutton65_Click);
            ttbutton64.Click += new TTControlEventDelegate(ttbutton64_Click);
            ttbutton63.Click += new TTControlEventDelegate(ttbutton63_Click);
            ttbutton62.Click += new TTControlEventDelegate(ttbutton62_Click);
            ttbutton61.Click += new TTControlEventDelegate(ttbutton61_Click);
            ttbutton11.Click += new TTControlEventDelegate(ttbutton11_Click);
            ttbutton12.Click += new TTControlEventDelegate(ttbutton12_Click);
            ttbutton13.Click += new TTControlEventDelegate(ttbutton13_Click);
            ttbutton14.Click += new TTControlEventDelegate(ttbutton14_Click);
            ttbutton15.Click += new TTControlEventDelegate(ttbutton15_Click);
            ttbutton16.Click += new TTControlEventDelegate(ttbutton16_Click);
            ttbutton17.Click += new TTControlEventDelegate(ttbutton17_Click);
            ttbutton18.Click += new TTControlEventDelegate(ttbutton18_Click);
            ttbutton51.Click += new TTControlEventDelegate(ttbutton51_Click);
            ttbutton52.Click += new TTControlEventDelegate(ttbutton52_Click);
            ttbutton53.Click += new TTControlEventDelegate(ttbutton53_Click);
            ttbutton54.Click += new TTControlEventDelegate(ttbutton54_Click);
            ttbutton55.Click += new TTControlEventDelegate(ttbutton55_Click);
            ttbutton91.Click += new TTControlEventDelegate(ttbutton91_Click);
            ttbuttonRightUpperJaw.Click += new TTControlEventDelegate(ttbuttonRightUpperJaw_Click);
            ttbuttonLeftUpperJaw.Click += new TTControlEventDelegate(ttbuttonLeftUpperJaw_Click);
            ttbuttonUpperJaw.Click += new TTControlEventDelegate(ttbuttonUpperJaw_Click);
            ttbuttonWholeJaw.Click += new TTControlEventDelegate(ttbuttonWholeJaw_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton94.Click -= new TTControlEventDelegate(ttbutton94_Click);
            ttbutton75.Click -= new TTControlEventDelegate(ttbutton75_Click);
            ttbutton74.Click -= new TTControlEventDelegate(ttbutton74_Click);
            ttbutton73.Click -= new TTControlEventDelegate(ttbutton73_Click);
            ttbutton72.Click -= new TTControlEventDelegate(ttbutton72_Click);
            ttbutton71.Click -= new TTControlEventDelegate(ttbutton71_Click);
            ttbutton37.Click -= new TTControlEventDelegate(ttbutton37_Click);
            ttbutton36.Click -= new TTControlEventDelegate(ttbutton36_Click);
            ttbutton35.Click -= new TTControlEventDelegate(ttbutton35_Click);
            ttbutton38.Click -= new TTControlEventDelegate(ttbutton38_Click);
            ttbutton34.Click -= new TTControlEventDelegate(ttbutton34_Click);
            ttbutton31.Click -= new TTControlEventDelegate(ttbutton31_Click);
            ttbutton32.Click -= new TTControlEventDelegate(ttbutton32_Click);
            ttbutton33.Click -= new TTControlEventDelegate(ttbutton33_Click);
            ttbuttonWholeJaw2.Click -= new TTControlEventDelegate(ttbuttonWholeJaw2_Click);
            ttbuttonLowerJaw.Click -= new TTControlEventDelegate(ttbuttonLowerJaw_Click);
            ttbutton19.Click -= new TTControlEventDelegate(ttbutton19_Click);
            ttbuttonRightLowerJaw.Click -= new TTControlEventDelegate(ttbuttonRightLowerJaw_Click);
            ttbutton93.Click -= new TTControlEventDelegate(ttbutton93_Click);
            ttbutton84.Click -= new TTControlEventDelegate(ttbutton84_Click);
            ttbutton85.Click -= new TTControlEventDelegate(ttbutton85_Click);
            ttbutton83.Click -= new TTControlEventDelegate(ttbutton83_Click);
            ttbutton82.Click -= new TTControlEventDelegate(ttbutton82_Click);
            ttbutton81.Click -= new TTControlEventDelegate(ttbutton81_Click);
            ttbutton44.Click -= new TTControlEventDelegate(ttbutton44_Click);
            ttbutton41.Click -= new TTControlEventDelegate(ttbutton41_Click);
            ttbutton42.Click -= new TTControlEventDelegate(ttbutton42_Click);
            ttbutton43.Click -= new TTControlEventDelegate(ttbutton43_Click);
            ttbutton45.Click -= new TTControlEventDelegate(ttbutton45_Click);
            ttbutton46.Click -= new TTControlEventDelegate(ttbutton46_Click);
            ttbutton47.Click -= new TTControlEventDelegate(ttbutton47_Click);
            ttbutton48.Click -= new TTControlEventDelegate(ttbutton48_Click);
            ttbutton28.Click -= new TTControlEventDelegate(ttbutton28_Click);
            ttbutton27.Click -= new TTControlEventDelegate(ttbutton27_Click);
            ttbutton26.Click -= new TTControlEventDelegate(ttbutton26_Click);
            ttbutton25.Click -= new TTControlEventDelegate(ttbutton25_Click);
            ttbutton24.Click -= new TTControlEventDelegate(ttbutton24_Click);
            ttbutton23.Click -= new TTControlEventDelegate(ttbutton23_Click);
            ttbutton22.Click -= new TTControlEventDelegate(ttbutton22_Click);
            ttbutton21.Click -= new TTControlEventDelegate(ttbutton21_Click);
            ttbutton92.Click -= new TTControlEventDelegate(ttbutton92_Click);
            ttbutton65.Click -= new TTControlEventDelegate(ttbutton65_Click);
            ttbutton64.Click -= new TTControlEventDelegate(ttbutton64_Click);
            ttbutton63.Click -= new TTControlEventDelegate(ttbutton63_Click);
            ttbutton62.Click -= new TTControlEventDelegate(ttbutton62_Click);
            ttbutton61.Click -= new TTControlEventDelegate(ttbutton61_Click);
            ttbutton11.Click -= new TTControlEventDelegate(ttbutton11_Click);
            ttbutton12.Click -= new TTControlEventDelegate(ttbutton12_Click);
            ttbutton13.Click -= new TTControlEventDelegate(ttbutton13_Click);
            ttbutton14.Click -= new TTControlEventDelegate(ttbutton14_Click);
            ttbutton15.Click -= new TTControlEventDelegate(ttbutton15_Click);
            ttbutton16.Click -= new TTControlEventDelegate(ttbutton16_Click);
            ttbutton17.Click -= new TTControlEventDelegate(ttbutton17_Click);
            ttbutton18.Click -= new TTControlEventDelegate(ttbutton18_Click);
            ttbutton51.Click -= new TTControlEventDelegate(ttbutton51_Click);
            ttbutton52.Click -= new TTControlEventDelegate(ttbutton52_Click);
            ttbutton53.Click -= new TTControlEventDelegate(ttbutton53_Click);
            ttbutton54.Click -= new TTControlEventDelegate(ttbutton54_Click);
            ttbutton55.Click -= new TTControlEventDelegate(ttbutton55_Click);
            ttbutton91.Click -= new TTControlEventDelegate(ttbutton91_Click);
            ttbuttonRightUpperJaw.Click -= new TTControlEventDelegate(ttbuttonRightUpperJaw_Click);
            ttbuttonLeftUpperJaw.Click -= new TTControlEventDelegate(ttbuttonLeftUpperJaw_Click);
            ttbuttonUpperJaw.Click -= new TTControlEventDelegate(ttbuttonUpperJaw_Click);
            ttbuttonWholeJaw.Click -= new TTControlEventDelegate(ttbuttonWholeJaw_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton94_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton94_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.anomalyTooth94;
#endregion RadiologyTestDentalToothSchema_ttbutton94_Click
        }

        private void ttbutton75_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton75_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth75;
#endregion RadiologyTestDentalToothSchema_ttbutton75_Click
        }

        private void ttbutton74_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton74_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth74;
#endregion RadiologyTestDentalToothSchema_ttbutton74_Click
        }

        private void ttbutton73_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton73_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth73;
#endregion RadiologyTestDentalToothSchema_ttbutton73_Click
        }

        private void ttbutton72_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton72_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth72;
#endregion RadiologyTestDentalToothSchema_ttbutton72_Click
        }

        private void ttbutton71_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton71_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth71;
#endregion RadiologyTestDentalToothSchema_ttbutton71_Click
        }

        private void ttbutton37_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton37_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth37;
#endregion RadiologyTestDentalToothSchema_ttbutton37_Click
        }

        private void ttbutton36_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton36_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth36;
#endregion RadiologyTestDentalToothSchema_ttbutton36_Click
        }

        private void ttbutton35_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton35_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth35;
#endregion RadiologyTestDentalToothSchema_ttbutton35_Click
        }

        private void ttbutton38_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton38_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth38;
#endregion RadiologyTestDentalToothSchema_ttbutton38_Click
        }

        private void ttbutton34_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton34_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth34;
#endregion RadiologyTestDentalToothSchema_ttbutton34_Click
        }

        private void ttbutton31_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton31_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth31;
#endregion RadiologyTestDentalToothSchema_ttbutton31_Click
        }

        private void ttbutton32_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton32_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth32;
#endregion RadiologyTestDentalToothSchema_ttbutton32_Click
        }

        private void ttbutton33_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton33_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth33;
#endregion RadiologyTestDentalToothSchema_ttbutton33_Click
        }

        private void ttbuttonWholeJaw2_Click()
        {
#region RadiologyTestDentalToothSchema_ttbuttonWholeJaw2_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.wholeJaw1;
#endregion RadiologyTestDentalToothSchema_ttbuttonWholeJaw2_Click
        }

        private void ttbuttonLowerJaw_Click()
        {
#region RadiologyTestDentalToothSchema_ttbuttonLowerJaw_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.lowerJaw3;
#endregion RadiologyTestDentalToothSchema_ttbuttonLowerJaw_Click
        }

        private void ttbutton19_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton19_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.leftLowerJaw7;
#endregion RadiologyTestDentalToothSchema_ttbutton19_Click
        }

        private void ttbuttonRightLowerJaw_Click()
        {
#region RadiologyTestDentalToothSchema_ttbuttonRightLowerJaw_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.rightLowerJaw6;
#endregion RadiologyTestDentalToothSchema_ttbuttonRightLowerJaw_Click
        }

        private void ttbutton93_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton93_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.anomalyTooth93;
#endregion RadiologyTestDentalToothSchema_ttbutton93_Click
        }

        private void ttbutton84_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton84_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth84;
#endregion RadiologyTestDentalToothSchema_ttbutton84_Click
        }

        private void ttbutton85_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton85_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth85;
#endregion RadiologyTestDentalToothSchema_ttbutton85_Click
        }

        private void ttbutton83_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton83_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth83;
#endregion RadiologyTestDentalToothSchema_ttbutton83_Click
        }

        private void ttbutton82_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton82_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth82;
#endregion RadiologyTestDentalToothSchema_ttbutton82_Click
        }

        private void ttbutton81_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton81_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth81;
#endregion RadiologyTestDentalToothSchema_ttbutton81_Click
        }

        private void ttbutton44_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton44_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth44;
#endregion RadiologyTestDentalToothSchema_ttbutton44_Click
        }

        private void ttbutton41_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton41_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth41;
#endregion RadiologyTestDentalToothSchema_ttbutton41_Click
        }

        private void ttbutton42_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton42_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth42;
#endregion RadiologyTestDentalToothSchema_ttbutton42_Click
        }

        private void ttbutton43_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton43_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth43;
#endregion RadiologyTestDentalToothSchema_ttbutton43_Click
        }

        private void ttbutton45_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton45_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth45;
#endregion RadiologyTestDentalToothSchema_ttbutton45_Click
        }

        private void ttbutton46_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton46_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth46;
#endregion RadiologyTestDentalToothSchema_ttbutton46_Click
        }

        private void ttbutton47_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton47_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth47;
#endregion RadiologyTestDentalToothSchema_ttbutton47_Click
        }

        private void ttbutton48_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton48_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth48;
#endregion RadiologyTestDentalToothSchema_ttbutton48_Click
        }

        private void ttbutton28_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton28_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth28;
#endregion RadiologyTestDentalToothSchema_ttbutton28_Click
        }

        private void ttbutton27_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton27_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth27;
#endregion RadiologyTestDentalToothSchema_ttbutton27_Click
        }

        private void ttbutton26_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton26_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth26;
#endregion RadiologyTestDentalToothSchema_ttbutton26_Click
        }

        private void ttbutton25_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton25_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth25;
#endregion RadiologyTestDentalToothSchema_ttbutton25_Click
        }

        private void ttbutton24_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton24_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth24;
#endregion RadiologyTestDentalToothSchema_ttbutton24_Click
        }

        private void ttbutton23_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton23_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth23;
#endregion RadiologyTestDentalToothSchema_ttbutton23_Click
        }

        private void ttbutton22_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton22_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth22;
#endregion RadiologyTestDentalToothSchema_ttbutton22_Click
        }

        private void ttbutton21_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton21_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth21;
#endregion RadiologyTestDentalToothSchema_ttbutton21_Click
        }

        private void ttbutton92_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton92_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.anomalyTooth92;
#endregion RadiologyTestDentalToothSchema_ttbutton92_Click
        }

        private void ttbutton65_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton65_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth65;
#endregion RadiologyTestDentalToothSchema_ttbutton65_Click
        }

        private void ttbutton64_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton64_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth64;
#endregion RadiologyTestDentalToothSchema_ttbutton64_Click
        }

        private void ttbutton63_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton63_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth63;
#endregion RadiologyTestDentalToothSchema_ttbutton63_Click
        }

        private void ttbutton62_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton62_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth62;
#endregion RadiologyTestDentalToothSchema_ttbutton62_Click
        }

        private void ttbutton61_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton61_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth61;
#endregion RadiologyTestDentalToothSchema_ttbutton61_Click
        }

        private void ttbutton11_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton11_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth11;
#endregion RadiologyTestDentalToothSchema_ttbutton11_Click
        }

        private void ttbutton12_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton12_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth12;
#endregion RadiologyTestDentalToothSchema_ttbutton12_Click
        }

        private void ttbutton13_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton13_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth13;
#endregion RadiologyTestDentalToothSchema_ttbutton13_Click
        }

        private void ttbutton14_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton14_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth14;
#endregion RadiologyTestDentalToothSchema_ttbutton14_Click
        }

        private void ttbutton15_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton15_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth15;
#endregion RadiologyTestDentalToothSchema_ttbutton15_Click
        }

        private void ttbutton16_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton16_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth16;
#endregion RadiologyTestDentalToothSchema_ttbutton16_Click
        }

        private void ttbutton17_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton17_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth17;
#endregion RadiologyTestDentalToothSchema_ttbutton17_Click
        }

        private void ttbutton18_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton18_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.adultTooth18;
#endregion RadiologyTestDentalToothSchema_ttbutton18_Click
        }

        private void ttbutton51_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton51_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth51;
#endregion RadiologyTestDentalToothSchema_ttbutton51_Click
        }

        private void ttbutton52_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton52_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth52;
#endregion RadiologyTestDentalToothSchema_ttbutton52_Click
        }

        private void ttbutton53_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton53_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth53;
#endregion RadiologyTestDentalToothSchema_ttbutton53_Click
        }

        private void ttbutton54_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton54_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth54;
#endregion RadiologyTestDentalToothSchema_ttbutton54_Click
        }

        private void ttbutton55_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton55_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.milkTooth55;
#endregion RadiologyTestDentalToothSchema_ttbutton55_Click
        }

        private void ttbutton91_Click()
        {
#region RadiologyTestDentalToothSchema_ttbutton91_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.anomalyTooth91;
#endregion RadiologyTestDentalToothSchema_ttbutton91_Click
        }

        private void ttbuttonRightUpperJaw_Click()
        {
#region RadiologyTestDentalToothSchema_ttbuttonRightUpperJaw_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.rightUpperJaw4;
#endregion RadiologyTestDentalToothSchema_ttbuttonRightUpperJaw_Click
        }

        private void ttbuttonLeftUpperJaw_Click()
        {
#region RadiologyTestDentalToothSchema_ttbuttonLeftUpperJaw_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.leftUpperJaw5;
#endregion RadiologyTestDentalToothSchema_ttbuttonLeftUpperJaw_Click
        }

        private void ttbuttonUpperJaw_Click()
        {
#region RadiologyTestDentalToothSchema_ttbuttonUpperJaw_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.upperJaw2;
#endregion RadiologyTestDentalToothSchema_ttbuttonUpperJaw_Click
        }

        private void ttbuttonWholeJaw_Click()
        {
#region RadiologyTestDentalToothSchema_ttbuttonWholeJaw_Click
   _RadiologyTest.TestToothNumber = ToothNumberEnum.wholeJaw1;
#endregion RadiologyTestDentalToothSchema_ttbuttonWholeJaw_Click
        }
    }
}