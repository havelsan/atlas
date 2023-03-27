
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
    public partial class RadiologyDentalToothSchema : TTForm
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
#region RadiologyDentalToothSchema_ttbutton94_Click
   _Radiology.ToothNumber  = ToothNumberEnum.anomalyTooth94;
#endregion RadiologyDentalToothSchema_ttbutton94_Click
        }

        private void ttbutton75_Click()
        {
#region RadiologyDentalToothSchema_ttbutton75_Click
   _Radiology.ToothNumber = ToothNumberEnum.milkTooth75;
#endregion RadiologyDentalToothSchema_ttbutton75_Click
        }

        private void ttbutton74_Click()
        {
#region RadiologyDentalToothSchema_ttbutton74_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth74;
#endregion RadiologyDentalToothSchema_ttbutton74_Click
        }

        private void ttbutton73_Click()
        {
#region RadiologyDentalToothSchema_ttbutton73_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth73;
#endregion RadiologyDentalToothSchema_ttbutton73_Click
        }

        private void ttbutton72_Click()
        {
#region RadiologyDentalToothSchema_ttbutton72_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth72;
#endregion RadiologyDentalToothSchema_ttbutton72_Click
        }

        private void ttbutton71_Click()
        {
#region RadiologyDentalToothSchema_ttbutton71_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth71;
#endregion RadiologyDentalToothSchema_ttbutton71_Click
        }

        private void ttbutton37_Click()
        {
#region RadiologyDentalToothSchema_ttbutton37_Click
   _Radiology.ToothNumber = ToothNumberEnum.adultTooth37;
#endregion RadiologyDentalToothSchema_ttbutton37_Click
        }

        private void ttbutton36_Click()
        {
#region RadiologyDentalToothSchema_ttbutton36_Click
   _Radiology.ToothNumber = ToothNumberEnum.adultTooth36;
#endregion RadiologyDentalToothSchema_ttbutton36_Click
        }

        private void ttbutton35_Click()
        {
#region RadiologyDentalToothSchema_ttbutton35_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth35;
#endregion RadiologyDentalToothSchema_ttbutton35_Click
        }

        private void ttbutton38_Click()
        {
#region RadiologyDentalToothSchema_ttbutton38_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth38;
#endregion RadiologyDentalToothSchema_ttbutton38_Click
        }

        private void ttbutton34_Click()
        {
#region RadiologyDentalToothSchema_ttbutton34_Click
   _Radiology.ToothNumber = ToothNumberEnum.adultTooth34;
#endregion RadiologyDentalToothSchema_ttbutton34_Click
        }

        private void ttbutton31_Click()
        {
#region RadiologyDentalToothSchema_ttbutton31_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth31;
#endregion RadiologyDentalToothSchema_ttbutton31_Click
        }

        private void ttbutton32_Click()
        {
#region RadiologyDentalToothSchema_ttbutton32_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth32;
#endregion RadiologyDentalToothSchema_ttbutton32_Click
        }

        private void ttbutton33_Click()
        {
#region RadiologyDentalToothSchema_ttbutton33_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth33;
#endregion RadiologyDentalToothSchema_ttbutton33_Click
        }

        private void ttbuttonWholeJaw2_Click()
        {
#region RadiologyDentalToothSchema_ttbuttonWholeJaw2_Click
   _Radiology.ToothNumber  = ToothNumberEnum.wholeJaw1;
#endregion RadiologyDentalToothSchema_ttbuttonWholeJaw2_Click
        }

        private void ttbuttonLowerJaw_Click()
        {
#region RadiologyDentalToothSchema_ttbuttonLowerJaw_Click
   _Radiology.ToothNumber  = ToothNumberEnum.lowerJaw3;
#endregion RadiologyDentalToothSchema_ttbuttonLowerJaw_Click
        }

        private void ttbutton19_Click()
        {
#region RadiologyDentalToothSchema_ttbutton19_Click
   _Radiology.ToothNumber  = ToothNumberEnum.leftLowerJaw7;
#endregion RadiologyDentalToothSchema_ttbutton19_Click
        }

        private void ttbuttonRightLowerJaw_Click()
        {
#region RadiologyDentalToothSchema_ttbuttonRightLowerJaw_Click
   _Radiology.ToothNumber  = ToothNumberEnum.rightLowerJaw6;
#endregion RadiologyDentalToothSchema_ttbuttonRightLowerJaw_Click
        }

        private void ttbutton93_Click()
        {
#region RadiologyDentalToothSchema_ttbutton93_Click
   _Radiology.ToothNumber  = ToothNumberEnum.anomalyTooth93;
#endregion RadiologyDentalToothSchema_ttbutton93_Click
        }

        private void ttbutton84_Click()
        {
#region RadiologyDentalToothSchema_ttbutton84_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth84;
#endregion RadiologyDentalToothSchema_ttbutton84_Click
        }

        private void ttbutton85_Click()
        {
#region RadiologyDentalToothSchema_ttbutton85_Click
   _Radiology.ToothNumber = ToothNumberEnum.milkTooth85;
#endregion RadiologyDentalToothSchema_ttbutton85_Click
        }

        private void ttbutton83_Click()
        {
#region RadiologyDentalToothSchema_ttbutton83_Click
   _Radiology.ToothNumber = ToothNumberEnum.milkTooth83;
#endregion RadiologyDentalToothSchema_ttbutton83_Click
        }

        private void ttbutton82_Click()
        {
#region RadiologyDentalToothSchema_ttbutton82_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth82;
#endregion RadiologyDentalToothSchema_ttbutton82_Click
        }

        private void ttbutton81_Click()
        {
#region RadiologyDentalToothSchema_ttbutton81_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth81;
#endregion RadiologyDentalToothSchema_ttbutton81_Click
        }

        private void ttbutton44_Click()
        {
#region RadiologyDentalToothSchema_ttbutton44_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth44;
#endregion RadiologyDentalToothSchema_ttbutton44_Click
        }

        private void ttbutton41_Click()
        {
#region RadiologyDentalToothSchema_ttbutton41_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth41;
#endregion RadiologyDentalToothSchema_ttbutton41_Click
        }

        private void ttbutton42_Click()
        {
#region RadiologyDentalToothSchema_ttbutton42_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth42;
#endregion RadiologyDentalToothSchema_ttbutton42_Click
        }

        private void ttbutton43_Click()
        {
#region RadiologyDentalToothSchema_ttbutton43_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth43;
#endregion RadiologyDentalToothSchema_ttbutton43_Click
        }

        private void ttbutton45_Click()
        {
#region RadiologyDentalToothSchema_ttbutton45_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth45;
#endregion RadiologyDentalToothSchema_ttbutton45_Click
        }

        private void ttbutton46_Click()
        {
#region RadiologyDentalToothSchema_ttbutton46_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth46;
#endregion RadiologyDentalToothSchema_ttbutton46_Click
        }

        private void ttbutton47_Click()
        {
#region RadiologyDentalToothSchema_ttbutton47_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth47;
#endregion RadiologyDentalToothSchema_ttbutton47_Click
        }

        private void ttbutton48_Click()
        {
#region RadiologyDentalToothSchema_ttbutton48_Click
   _Radiology.ToothNumber = ToothNumberEnum.adultTooth48;
#endregion RadiologyDentalToothSchema_ttbutton48_Click
        }

        private void ttbutton28_Click()
        {
#region RadiologyDentalToothSchema_ttbutton28_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth28;
#endregion RadiologyDentalToothSchema_ttbutton28_Click
        }

        private void ttbutton27_Click()
        {
#region RadiologyDentalToothSchema_ttbutton27_Click
   _Radiology.ToothNumber = ToothNumberEnum.adultTooth27;
#endregion RadiologyDentalToothSchema_ttbutton27_Click
        }

        private void ttbutton26_Click()
        {
#region RadiologyDentalToothSchema_ttbutton26_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth26;
#endregion RadiologyDentalToothSchema_ttbutton26_Click
        }

        private void ttbutton25_Click()
        {
#region RadiologyDentalToothSchema_ttbutton25_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth25;
#endregion RadiologyDentalToothSchema_ttbutton25_Click
        }

        private void ttbutton24_Click()
        {
#region RadiologyDentalToothSchema_ttbutton24_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth24;
#endregion RadiologyDentalToothSchema_ttbutton24_Click
        }

        private void ttbutton23_Click()
        {
#region RadiologyDentalToothSchema_ttbutton23_Click
   _Radiology.ToothNumber = ToothNumberEnum.adultTooth23;
#endregion RadiologyDentalToothSchema_ttbutton23_Click
        }

        private void ttbutton22_Click()
        {
#region RadiologyDentalToothSchema_ttbutton22_Click
   _Radiology.ToothNumber = ToothNumberEnum.adultTooth22;
#endregion RadiologyDentalToothSchema_ttbutton22_Click
        }

        private void ttbutton21_Click()
        {
#region RadiologyDentalToothSchema_ttbutton21_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth21;
#endregion RadiologyDentalToothSchema_ttbutton21_Click
        }

        private void ttbutton92_Click()
        {
#region RadiologyDentalToothSchema_ttbutton92_Click
   _Radiology.ToothNumber  = ToothNumberEnum.anomalyTooth92;
#endregion RadiologyDentalToothSchema_ttbutton92_Click
        }

        private void ttbutton64_Click()
        {
#region RadiologyDentalToothSchema_ttbutton64_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth64;
#endregion RadiologyDentalToothSchema_ttbutton64_Click
        }

        private void ttbutton63_Click()
        {
#region RadiologyDentalToothSchema_ttbutton63_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth63;
#endregion RadiologyDentalToothSchema_ttbutton63_Click
        }

        private void ttbutton62_Click()
        {
#region RadiologyDentalToothSchema_ttbutton62_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth62;
#endregion RadiologyDentalToothSchema_ttbutton62_Click
        }

        private void ttbutton61_Click()
        {
#region RadiologyDentalToothSchema_ttbutton61_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth61;
#endregion RadiologyDentalToothSchema_ttbutton61_Click
        }

        private void ttbutton11_Click()
        {
#region RadiologyDentalToothSchema_ttbutton11_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth11;
#endregion RadiologyDentalToothSchema_ttbutton11_Click
        }

        private void ttbutton12_Click()
        {
#region RadiologyDentalToothSchema_ttbutton12_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth12;
#endregion RadiologyDentalToothSchema_ttbutton12_Click
        }

        private void ttbutton13_Click()
        {
#region RadiologyDentalToothSchema_ttbutton13_Click
   _Radiology.ToothNumber = ToothNumberEnum.adultTooth13;
#endregion RadiologyDentalToothSchema_ttbutton13_Click
        }

        private void ttbutton14_Click()
        {
#region RadiologyDentalToothSchema_ttbutton14_Click
   _Radiology.ToothNumber = ToothNumberEnum.adultTooth14;
#endregion RadiologyDentalToothSchema_ttbutton14_Click
        }

        private void ttbutton15_Click()
        {
#region RadiologyDentalToothSchema_ttbutton15_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth15;
#endregion RadiologyDentalToothSchema_ttbutton15_Click
        }

        private void ttbutton16_Click()
        {
#region RadiologyDentalToothSchema_ttbutton16_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth16;
#endregion RadiologyDentalToothSchema_ttbutton16_Click
        }

        private void ttbutton17_Click()
        {
#region RadiologyDentalToothSchema_ttbutton17_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth17;
#endregion RadiologyDentalToothSchema_ttbutton17_Click
        }

        private void ttbutton18_Click()
        {
#region RadiologyDentalToothSchema_ttbutton18_Click
   _Radiology.ToothNumber  = ToothNumberEnum.adultTooth18;
#endregion RadiologyDentalToothSchema_ttbutton18_Click
        }

        private void ttbutton51_Click()
        {
#region RadiologyDentalToothSchema_ttbutton51_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth51;
#endregion RadiologyDentalToothSchema_ttbutton51_Click
        }

        private void ttbutton52_Click()
        {
#region RadiologyDentalToothSchema_ttbutton52_Click
   _Radiology.ToothNumber = ToothNumberEnum.milkTooth52;
#endregion RadiologyDentalToothSchema_ttbutton52_Click
        }

        private void ttbutton53_Click()
        {
#region RadiologyDentalToothSchema_ttbutton53_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth53;
#endregion RadiologyDentalToothSchema_ttbutton53_Click
        }

        private void ttbutton54_Click()
        {
#region RadiologyDentalToothSchema_ttbutton54_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth54;
#endregion RadiologyDentalToothSchema_ttbutton54_Click
        }

        private void ttbutton55_Click()
        {
#region RadiologyDentalToothSchema_ttbutton55_Click
   _Radiology.ToothNumber  = ToothNumberEnum.milkTooth55;
#endregion RadiologyDentalToothSchema_ttbutton55_Click
        }

        private void ttbutton91_Click()
        {
#region RadiologyDentalToothSchema_ttbutton91_Click
   _Radiology.ToothNumber  = ToothNumberEnum.anomalyTooth91;
#endregion RadiologyDentalToothSchema_ttbutton91_Click
        }

        private void ttbuttonRightUpperJaw_Click()
        {
#region RadiologyDentalToothSchema_ttbuttonRightUpperJaw_Click
   _Radiology.ToothNumber = ToothNumberEnum.rightUpperJaw4;
#endregion RadiologyDentalToothSchema_ttbuttonRightUpperJaw_Click
        }

        private void ttbuttonLeftUpperJaw_Click()
        {
#region RadiologyDentalToothSchema_ttbuttonLeftUpperJaw_Click
   _Radiology.ToothNumber  = ToothNumberEnum.leftUpperJaw5;
#endregion RadiologyDentalToothSchema_ttbuttonLeftUpperJaw_Click
        }

        private void ttbuttonUpperJaw_Click()
        {
#region RadiologyDentalToothSchema_ttbuttonUpperJaw_Click
   _Radiology.ToothNumber = ToothNumberEnum.upperJaw2;
#endregion RadiologyDentalToothSchema_ttbuttonUpperJaw_Click
        }

        private void ttbuttonWholeJaw_Click()
        {
#region RadiologyDentalToothSchema_ttbuttonWholeJaw_Click
   _Radiology.ToothNumber = ToothNumberEnum.wholeJaw1;
#endregion RadiologyDentalToothSchema_ttbuttonWholeJaw_Click
        }

        protected override void PreScript()
        {
#region RadiologyDentalToothSchema_PreScript
    base.PreScript();
#endregion RadiologyDentalToothSchema_PreScript

            }
                }
}