
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
    /// Glaskow Koma  Skalası
    /// </summary>
    public partial class NursingGlaskowComaScaleForm : BaseNursingDataEntryForm
    {
        override protected void BindControlEvents()
        {
            MotorAnswer.SelectedObjectChanged += new TTControlEventDelegate(MotorAnswer_SelectedObjectChanged);
            Eyes.SelectedObjectChanged += new TTControlEventDelegate(Eyes_SelectedObjectChanged);
            OralAnswer.SelectedObjectChanged += new TTControlEventDelegate(OralAnswer_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MotorAnswer.SelectedObjectChanged -= new TTControlEventDelegate(MotorAnswer_SelectedObjectChanged);
            Eyes.SelectedObjectChanged -= new TTControlEventDelegate(Eyes_SelectedObjectChanged);
            OralAnswer.SelectedObjectChanged -= new TTControlEventDelegate(OralAnswer_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void MotorAnswer_SelectedObjectChanged()
        {
            #region NursingGlaskowComaScaleForm_MotorAnswer_SelectedObjectChanged
            TotalScore.SelectedValue = NursingGlaskowComaScale.CalcGlaskowComaScaleTotalScore(this._NursingGlaskowComaScale);
#endregion NursingGlaskowComaScaleForm_MotorAnswer_SelectedObjectChanged
        }

        private void Eyes_SelectedObjectChanged()
        {
            #region NursingGlaskowComaScaleForm_Eyes_SelectedObjectChanged
            TotalScore.SelectedValue = NursingGlaskowComaScale.CalcGlaskowComaScaleTotalScore(this._NursingGlaskowComaScale);
#endregion NursingGlaskowComaScaleForm_Eyes_SelectedObjectChanged
        }

        private void OralAnswer_SelectedObjectChanged()
        {
            #region NursingGlaskowComaScaleForm_OralAnswer_SelectedObjectChanged
            TotalScore.SelectedValue = NursingGlaskowComaScale.CalcGlaskowComaScaleTotalScore(this._NursingGlaskowComaScale);
#endregion NursingGlaskowComaScaleForm_OralAnswer_SelectedObjectChanged
        }
    }
}