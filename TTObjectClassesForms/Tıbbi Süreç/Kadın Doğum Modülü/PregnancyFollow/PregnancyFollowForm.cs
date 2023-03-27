
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
    public partial class PregnancyFollowForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        private int? GetPregnancyWeek(DateTime lastMenstrualPeriod)
        {
            DateTime today = DateTime.Today;
            int weeks = (today - lastMenstrualPeriod).Days / 7;

            //let today: Date = Date.Now;
            //let weeks: number = Math.floor((today.valueOf() - lastMenstrualPeriod.valueOf() + 1) / (1000 * 60 * 60 * 24) / 7);

            return weeks;
        }

        protected override void PreScript()
        {
            base.PreScript();

            int pregnancWeek =Convert.ToInt32(this.GetPregnancyWeek(this._PregnancyFollow.Pregnancy.LastMenstrualPeriod.Value));

            FetusGrowingDefinition fetusGrow = FetusGrowingDefinition.GetFetusGrowingByPregnancyWeek(this._PregnancyFollow.ObjectContext,pregnancWeek);

            this.PregnancyWeekFetusGrowingDefinition.Text = pregnancWeek.ToString();
            this.LengthFetusGrowingDefinition.Text = fetusGrow.Length.ToString();
            this.WeightFetusGrowingDefinition.Text = fetusGrow.Weight.ToString();
            this.AbdominalCircumferenceFetusGrowingDefinition.Text = fetusGrow.AbdominalCircumference.ToString();
            this.BiparietalDiameterFetusGrowingDefinition.Text = fetusGrow.BiparietalDiameter.ToString();
            this.FemurLengthFetusGrowingDefinition.Text = fetusGrow.FemurLength.ToString();
            this.HeadCircumferenceFetusGrowingDefinition.Text = fetusGrow.HeadCircumference.ToString();
        }
    }
}