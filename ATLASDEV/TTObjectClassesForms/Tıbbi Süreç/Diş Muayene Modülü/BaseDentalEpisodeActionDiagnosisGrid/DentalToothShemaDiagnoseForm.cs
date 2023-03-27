
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
    public partial class DentalToothShemaDiagnoseForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ttbuttonLeftUpperJaw.Click += new TTControlEventDelegate(ttbuttonLeftUpperJaw_Click);
            ttbuttonRightUpperJaw.Click += new TTControlEventDelegate(ttbuttonRightUpperJaw_Click);
            ttbuttonUpperJaw.Click += new TTControlEventDelegate(ttbuttonUpperJaw_Click);
            ttbuttonWholeJaw.Click += new TTControlEventDelegate(ttbuttonWholeJaw_Click);
            ttbuttonLeftLowerJaw.Click += new TTControlEventDelegate(ttbuttonLeftLowerJaw_Click);
            ttbuttonWholeJaw2.Click += new TTControlEventDelegate(ttbuttonWholeJaw2_Click);
            ttbuttonLowerJaw.Click += new TTControlEventDelegate(ttbuttonLowerJaw_Click);
            ttbuttonRightLowerJaw.Click += new TTControlEventDelegate(ttbuttonRightLowerJaw_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbuttonLeftUpperJaw.Click -= new TTControlEventDelegate(ttbuttonLeftUpperJaw_Click);
            ttbuttonRightUpperJaw.Click -= new TTControlEventDelegate(ttbuttonRightUpperJaw_Click);
            ttbuttonUpperJaw.Click -= new TTControlEventDelegate(ttbuttonUpperJaw_Click);
            ttbuttonWholeJaw.Click -= new TTControlEventDelegate(ttbuttonWholeJaw_Click);
            ttbuttonLeftLowerJaw.Click -= new TTControlEventDelegate(ttbuttonLeftLowerJaw_Click);
            ttbuttonWholeJaw2.Click -= new TTControlEventDelegate(ttbuttonWholeJaw2_Click);
            ttbuttonLowerJaw.Click -= new TTControlEventDelegate(ttbuttonLowerJaw_Click);
            ttbuttonRightLowerJaw.Click -= new TTControlEventDelegate(ttbuttonRightLowerJaw_Click);
            base.UnBindControlEvents();
        }

        private void ttbuttonLeftUpperJaw_Click()
        {
#region DentalToothShemaDiagnoseForm_ttbuttonLeftUpperJaw_Click
   this._BaseDentalEpisodeActionDiagnosisGrid.ToothNumber = ToothNumberEnum.leftUpperJaw5;
#endregion DentalToothShemaDiagnoseForm_ttbuttonLeftUpperJaw_Click
        }

        private void ttbuttonRightUpperJaw_Click()
        {
#region DentalToothShemaDiagnoseForm_ttbuttonRightUpperJaw_Click
   this._BaseDentalEpisodeActionDiagnosisGrid.ToothNumber = ToothNumberEnum.rightUpperJaw4;
#endregion DentalToothShemaDiagnoseForm_ttbuttonRightUpperJaw_Click
        }

        private void ttbuttonUpperJaw_Click()
        {
#region DentalToothShemaDiagnoseForm_ttbuttonUpperJaw_Click
   this._BaseDentalEpisodeActionDiagnosisGrid.ToothNumber = ToothNumberEnum.upperJaw2;
#endregion DentalToothShemaDiagnoseForm_ttbuttonUpperJaw_Click
        }

        private void ttbuttonWholeJaw_Click()
        {
#region DentalToothShemaDiagnoseForm_ttbuttonWholeJaw_Click
   this._BaseDentalEpisodeActionDiagnosisGrid.ToothNumber = ToothNumberEnum.wholeJaw1;
#endregion DentalToothShemaDiagnoseForm_ttbuttonWholeJaw_Click
        }

        private void ttbuttonLeftLowerJaw_Click()
        {
#region DentalToothShemaDiagnoseForm_ttbuttonLeftLowerJaw_Click
   this._BaseDentalEpisodeActionDiagnosisGrid.ToothNumber = ToothNumberEnum.leftLowerJaw7;
#endregion DentalToothShemaDiagnoseForm_ttbuttonLeftLowerJaw_Click
        }

        private void ttbuttonWholeJaw2_Click()
        {
#region DentalToothShemaDiagnoseForm_ttbuttonWholeJaw2_Click
   this._BaseDentalEpisodeActionDiagnosisGrid.ToothNumber = ToothNumberEnum.wholeJaw1;
#endregion DentalToothShemaDiagnoseForm_ttbuttonWholeJaw2_Click
        }

        private void ttbuttonLowerJaw_Click()
        {
#region DentalToothShemaDiagnoseForm_ttbuttonLowerJaw_Click
   this._BaseDentalEpisodeActionDiagnosisGrid.ToothNumber = ToothNumberEnum.lowerJaw3;
#endregion DentalToothShemaDiagnoseForm_ttbuttonLowerJaw_Click
        }

        private void ttbuttonRightLowerJaw_Click()
        {
#region DentalToothShemaDiagnoseForm_ttbuttonRightLowerJaw_Click
   this._BaseDentalEpisodeActionDiagnosisGrid.ToothNumber = ToothNumberEnum.rightLowerJaw6;
#endregion DentalToothShemaDiagnoseForm_ttbuttonRightLowerJaw_Click
        }
    }
}