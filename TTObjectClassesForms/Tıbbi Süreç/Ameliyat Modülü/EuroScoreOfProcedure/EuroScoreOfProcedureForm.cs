
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
    public partial class EuroScoreOfProcedureForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
           // Save.Click += new TTControlEventDelegate(Save_Click);
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
           // Save.Click -= new TTControlEventDelegate(Save_Click);
        }


        private void Save_Click()
        {
            #region AnesthesiaReportForm_CreateConsultation_Click
            CalcScoreAndEuroScoreRisk();
            #endregion AnesthesiaReportForm_CreateConsultation_Click
        }

        #region EuroScoreOfProcedureForm_Methods

        public void CalcScoreAndEuroScoreRisk()
        {
            Int32 score = 0;

            if (this._EuroScoreOfProcedure.EuroScoreAge != null)
                score += Convert.ToInt32(this._EuroScoreOfProcedure.EuroScoreAge.Value);

            if (this._EuroScoreOfProcedure.Sex != null && this._EuroScoreOfProcedure.Sex == SexEnum.Female)
                score += 1;
            if (this._EuroScoreOfProcedure.ChronicPulmonaryDisease != null && this._EuroScoreOfProcedure.ChronicPulmonaryDisease == true)
                score += 1;
            if (this._EuroScoreOfProcedure.ExtracardiacArteriopathy != null && this._EuroScoreOfProcedure.ExtracardiacArteriopathy == true)
                score += 2;
            if (this._EuroScoreOfProcedure.PreviousCardiacSurgery != null && this._EuroScoreOfProcedure.PreviousCardiacSurgery == true)
                score += 3;

            if (this._EuroScoreOfProcedure.HemodiyalizPatient != null && this._EuroScoreOfProcedure.HemodiyalizPatient == true)
                score += 5;
            else if (this._EuroScoreOfProcedure.NeurologicalDysfunction != null && this._EuroScoreOfProcedure.NeurologicalDysfunction == true)//
                score += 2;
           
            if (this._EuroScoreOfProcedure.ActiveEndokardit != null && this._EuroScoreOfProcedure.ActiveEndokardit == true)
                score += 3;
            if (this._EuroScoreOfProcedure.CriticalPreoperativeState != null && this._EuroScoreOfProcedure.CriticalPreoperativeState == true)
                score += 3;
            if (this._EuroScoreOfProcedure.DiabetesMellitus != null && this._EuroScoreOfProcedure.DiabetesMellitus == true)
                score += 2;

            if (this._EuroScoreOfProcedure.LvDysfunction != null )
                score += Convert.ToInt32(this._EuroScoreOfProcedure.LvDysfunction.Value);

            if (this._EuroScoreOfProcedure.PulmonerHipertansiyon != null && this._EuroScoreOfProcedure.PulmonerHipertansiyon == true)
                score += 2;
            if (this._EuroScoreOfProcedure.TorasikAortaSurgery != null && this._EuroScoreOfProcedure.TorasikAortaSurgery == true)
                score += 4;
            if (this._EuroScoreOfProcedure.PostMI_VSD != null && this._EuroScoreOfProcedure.PostMI_VSD == true)
                score += 5;

            this._EuroScoreOfProcedure.Score = score;
            if (score < 4)
                this._EuroScoreOfProcedure.MedulaEuroScoreRisk = MedulaEuroScoreEnum.LowRisk;
            else if(score<7)
                this._EuroScoreOfProcedure.MedulaEuroScoreRisk = MedulaEuroScoreEnum.MediumRisk;
            else
                this._EuroScoreOfProcedure.MedulaEuroScoreRisk = MedulaEuroScoreEnum.HighRisk;
        }
        #endregion EuroScoreOfProcedureForm_Methods
    }
}