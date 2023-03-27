
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
    /// Düşme Riski
    /// </summary>
    public partial class NursingFallingDownRiskForm : TTForm
    {
        override protected void BindControlEvents()
        {
            RiskFactor.SelectedObjectChanged += new TTControlEventDelegate(RiskFactor_SelectedObjectChanged);
            //StandUpTest.SelectedObjectChanged += new TTControlEventDelegate(StandUpTest_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            RiskFactor.SelectedObjectChanged -= new TTControlEventDelegate(RiskFactor_SelectedObjectChanged);
            //StandUpTest.SelectedObjectChanged -= new TTControlEventDelegate(StandUpTest_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void RiskFactor_SelectedObjectChanged()
        {
            #region NursingFallingDownRiskForm_RiskFactor_SelectedObjectChanged
            NursingFallingDownRisk.CalcFallingDownRiskTotalScore(this._NursingFallingDownRisk);
#endregion NursingFallingDownRiskForm_RiskFactor_SelectedObjectChanged
        }

        private void StandUpTest_SelectedObjectChanged()
        {
            #region NursingFallingDownRiskForm_StandUpTest_SelectedObjectChanged
            NursingFallingDownRisk.CalcFallingDownRiskTotalScore(this._NursingFallingDownRisk);
#endregion NursingFallingDownRiskForm_StandUpTest_SelectedObjectChanged
        }
    }
}