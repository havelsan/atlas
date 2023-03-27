
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
    /// Waterlow Bası Riski
    /// </summary>
    public partial class NursingWaterlowRiskForm : TTForm
    {
        override protected void BindControlEvents()
        {
            SkinType.SelectedObjectChanged += new TTControlEventDelegate(SkinType_SelectedObjectChanged);
            HeightSizeRate.SelectedObjectChanged += new TTControlEventDelegate(HeightSizeRate_SelectedObjectChanged);
            Drugs.SelectedObjectChanged += new TTControlEventDelegate(Drugs_SelectedObjectChanged);
            Sex.SelectedObjectChanged += new TTControlEventDelegate(Sex_SelectedObjectChanged);
            Kontinans.SelectedObjectChanged += new TTControlEventDelegate(Kontinans_SelectedObjectChanged);
            SurgerAndTrauma.SelectedObjectChanged += new TTControlEventDelegate(SurgerAndTrauma_SelectedObjectChanged);
            Age.SelectedObjectChanged += new TTControlEventDelegate(Age_SelectedObjectChanged);
            NeurologicalProblem.SelectedObjectChanged += new TTControlEventDelegate(NeurologicalProblem_SelectedObjectChanged);
            Appetite.SelectedObjectChanged += new TTControlEventDelegate(Appetite_SelectedObjectChanged);
            TextureMalnutrusyon.SelectedObjectChanged += new TTControlEventDelegate(TextureMalnutrusyon_SelectedObjectChanged);
            Mobilite.SelectedObjectChanged += new TTControlEventDelegate(Mobilite_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SkinType.SelectedObjectChanged -= new TTControlEventDelegate(SkinType_SelectedObjectChanged);
            HeightSizeRate.SelectedObjectChanged -= new TTControlEventDelegate(HeightSizeRate_SelectedObjectChanged);
            Drugs.SelectedObjectChanged -= new TTControlEventDelegate(Drugs_SelectedObjectChanged);
            Sex.SelectedObjectChanged -= new TTControlEventDelegate(Sex_SelectedObjectChanged);
            Kontinans.SelectedObjectChanged -= new TTControlEventDelegate(Kontinans_SelectedObjectChanged);
            SurgerAndTrauma.SelectedObjectChanged -= new TTControlEventDelegate(SurgerAndTrauma_SelectedObjectChanged);
            Age.SelectedObjectChanged -= new TTControlEventDelegate(Age_SelectedObjectChanged);
            NeurologicalProblem.SelectedObjectChanged -= new TTControlEventDelegate(NeurologicalProblem_SelectedObjectChanged);
            Appetite.SelectedObjectChanged -= new TTControlEventDelegate(Appetite_SelectedObjectChanged);
            TextureMalnutrusyon.SelectedObjectChanged -= new TTControlEventDelegate(TextureMalnutrusyon_SelectedObjectChanged);
            Mobilite.SelectedObjectChanged -= new TTControlEventDelegate(Mobilite_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void SkinType_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_SkinType_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_SkinType_SelectedObjectChanged
        }

        private void HeightSizeRate_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_HeightSizeRate_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_HeightSizeRate_SelectedObjectChanged
        }

        private void Drugs_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_Drugs_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_Drugs_SelectedObjectChanged
        }

        private void Sex_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_Sex_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_Sex_SelectedObjectChanged
        }

        private void Kontinans_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_Kontinans_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_Kontinans_SelectedObjectChanged
        }

        private void SurgerAndTrauma_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_SurgerAndTrauma_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_SurgerAndTrauma_SelectedObjectChanged
        }

        private void Age_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_Age_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_Age_SelectedObjectChanged
        }

        private void NeurologicalProblem_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_NeurologicalProblem_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_NeurologicalProblem_SelectedObjectChanged
        }

        private void Appetite_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_Appetite_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_Appetite_SelectedObjectChanged
        }

        private void TextureMalnutrusyon_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_TextureMalnutrusyon_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_TextureMalnutrusyon_SelectedObjectChanged
        }

        private void Mobilite_SelectedObjectChanged()
        {
            #region NursingWaterlowRiskForm_Mobilite_SelectedObjectChanged
            NursingWaterlowRisk.CalcWaterlowRiskScore(this._NursingWaterlowRisk);
#endregion NursingWaterlowRiskForm_Mobilite_SelectedObjectChanged
        }
    }
}