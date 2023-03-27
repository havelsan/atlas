
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
    public partial class PregnancyStartForm : TTForm
    {
        override protected void BindControlEvents()
        {
            LastMenstrualPeriod.ValueChanged += new TTControlEventDelegate(LastMenstrualPeriod_ValueChanged);
            EggCollectionDate.ValueChanged += new TTControlEventDelegate(EggCollectionDate_ValueChanged);
            EmbryoTransferDate.ValueChanged += new TTControlEventDelegate(EmbryoTransferDate_ValueChanged);
            BlastocystTransferDate.ValueChanged += new TTControlEventDelegate(BlastocystTransferDate_ValueChanged);
            MeasuredPregnancyDay.TextChanged += new TTControlEventDelegate(MeasuredPregnancyDay_TextChanged);
            MeasuredPregnancyWeek.TextChanged += new TTControlEventDelegate(MeasuredPregnancyWeek_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            LastMenstrualPeriod.ValueChanged -= new TTControlEventDelegate(LastMenstrualPeriod_ValueChanged);
            EggCollectionDate.ValueChanged -= new TTControlEventDelegate(EggCollectionDate_ValueChanged);
            EmbryoTransferDate.ValueChanged -= new TTControlEventDelegate(EmbryoTransferDate_ValueChanged);
            BlastocystTransferDate.ValueChanged -= new TTControlEventDelegate(BlastocystTransferDate_ValueChanged);
            MeasuredPregnancyDay.TextChanged -= new TTControlEventDelegate(MeasuredPregnancyDay_TextChanged);
            MeasuredPregnancyWeek.TextChanged -= new TTControlEventDelegate(MeasuredPregnancyWeek_TextChanged);
            base.UnBindControlEvents();
        }


        [Serializable]
        public class Age
        {
            public int Years { get; set; }
            public int Months { get; set; }
            public int Weeks { get; set; }
            public int Days { get; set; }
        }

        private Age CalculateAge(DateTime birthDate)
        {
            Age age = new Age();

            DateTime today = DateTime.Today;
            int months = today.Month - birthDate.Month;
            int years = today.Year - birthDate.Year;

            if (today.Day < birthDate.Day)
            {
                months--;
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }
            int days = (today - birthDate.AddMonths((years * 12) + months)).Days;

            age.Years = years;
            age.Months = months;
            age.Days = days;

            return age;
        }

        private GestationalAgeEnum GetGestationalAgeRisk(DateTime birthDate)
        {
            //let today: Date = Date.Now;
            //let month: number = today.Month - birthDate.Month;
            //var year: number = today.Year - birthDate.Year;
            //if (month < 0)
            //{
            //    year--;
            //}
            //let age: number = year; //await CommonService.CalculateAge(birthDate).Years;

            int age = CalculateAge(birthDate).Years;

            if (age < 18)
            {
                return GestationalAgeEnum.TeenagePregnancy;
            }
            else if (age > 35)
            {
                return GestationalAgeEnum.MidLifePregnancy;
            }
            else
            {
                return GestationalAgeEnum.NormalPregnancy;
            }
        }

        private DateTime GetEstimatedBirthDate(DateTime lastMenstrualPeriod)
        {
            DateTime estimatedBirthDate = lastMenstrualPeriod.AddDays(280);//Gebelik Süreci tahmini doðum tarihi => yaklaþýk 40 hafta = 280 gün 
            return estimatedBirthDate;
        }

        private DateTime LastMenstrualPeriodByMeasuredDate(int measuredPregnancyDay, int measuredPregnancyWeek, DateTime measuredPregnancyDate)
        {
            DateTime lastMenstrualPeriod;

            int examinationDaysAgo = (DateTime.Now - measuredPregnancyDate).Days / 365;//günlemenin kaç gün önce yapýldýðý
            int measuredDay = measuredPregnancyDay + (measuredPregnancyWeek * 7);//günleme toplam gün sayýsý = günleme günü + (günleme haftasý*7)

            lastMenstrualPeriod = DateTime.Now.AddDays(examinationDaysAgo);//günlemenin yapýldýðý muayene tarihi hesaplandý
            lastMenstrualPeriod = lastMenstrualPeriod.AddDays(-(measuredDay));//günleme toplam gün sayýsý kadar geriye gidilerek son adet tarihi hesaplandý

            return lastMenstrualPeriod;
        }

        private DateTime LastMenstrualPeriodByEggCollectionDate(DateTime eggCollectionDate)
        {
            DateTime lastMenstrualPeriod;
            lastMenstrualPeriod = eggCollectionDate.AddDays(-(14));
            return lastMenstrualPeriod;
        }

        private DateTime LastMenstrualPeriodByEmbryoTransferDate(DateTime embryoTransferDate)
        {
            DateTime lastMenstrualPeriod;
            lastMenstrualPeriod = embryoTransferDate.AddDays(-(16));
            return lastMenstrualPeriod;
        }

        private DateTime LastMenstrualPeriodByBlastocystTransferDate(DateTime blastocystTransferDate)
        {
            DateTime lastMenstrualPeriod;
            lastMenstrualPeriod = blastocystTransferDate.AddDays(-(19));
            return lastMenstrualPeriod;
        }

        protected override void PreScript()
        {
            base.PreScript();

            _Pregnancy.RiskOfGestationalAge = this.GetGestationalAgeRisk(Convert.ToDateTime(this._Pregnancy.Patient.BirthDate));

            MeasuredPregnancyDate.ControlValue = DateTime.Now;
        }

        private void LastMenstrualPeriod_ValueChanged()
        {
            //_Pregnancy.LastMenstrualPeriod = Convert.ToDateTime(LastMenstrualPeriod.ControlValue);
            EstimatedBirthDate.ControlValue = this.GetEstimatedBirthDate(Convert.ToDateTime(LastMenstrualPeriod.ControlValue));
            //this.EstimatedBirthDate.Text = this.GetEstimatedBirthDate(Convert.ToDateTime(this.LastMenstrualPeriod.Text)).toString();

            //_Pregnancy.EggCollectionDate = null;
            //_Pregnancy.EmbryoTransferDate = null;
            //_Pregnancy.BlastocystTransferDate = null;
        }
        private void EggCollectionDate_ValueChanged()
        {
            LastMenstrualPeriod.ControlValue = this.LastMenstrualPeriodByEggCollectionDate(Convert.ToDateTime(EggCollectionDate.ControlValue));
        }
        private void EmbryoTransferDate_ValueChanged()
        {
            LastMenstrualPeriod.ControlValue = this.LastMenstrualPeriodByEmbryoTransferDate(Convert.ToDateTime(EmbryoTransferDate.ControlValue));
        }
        private void BlastocystTransferDate_ValueChanged()
        {
            LastMenstrualPeriod.ControlValue = this.LastMenstrualPeriodByBlastocystTransferDate(Convert.ToDateTime(BlastocystTransferDate.ControlValue));
            //this.LastMenstrualPeriod.Text = this.LastMenstrualPeriodByBlastocystTransferDate(Convert.ToDateTime(this.BlastocystTransferDate.Text)).toString();
        }
        private void MeasuredPregnancyDay_TextChanged()
        {
            if (MeasuredPregnancyDay.Text != null || MeasuredPregnancyDay.Text != "")
            {
                if (MeasuredPregnancyWeek.Text == null || MeasuredPregnancyWeek.Text == "")
                {
                    LastMenstrualPeriod.ControlValue = this.LastMenstrualPeriodByMeasuredDate(Convert.ToInt32(MeasuredPregnancyDay.Text), 0, DateTime.Now);
                }
                else
                {
                    LastMenstrualPeriod.ControlValue = this.LastMenstrualPeriodByMeasuredDate(Convert.ToInt32(MeasuredPregnancyDay.Text), Convert.ToInt32(MeasuredPregnancyWeek.Text), DateTime.Now);
                }
            }
        }
        private void MeasuredPregnancyWeek_TextChanged()
        {
            if (MeasuredPregnancyWeek.Text != null || MeasuredPregnancyWeek.Text != "")
            {
                if (MeasuredPregnancyDay.Text == null || MeasuredPregnancyDay.Text == "")
                {
                    LastMenstrualPeriod.ControlValue = this.LastMenstrualPeriodByMeasuredDate(0, Convert.ToInt32(MeasuredPregnancyWeek.Text), DateTime.Now);
                }
                else
                {
                    LastMenstrualPeriod.ControlValue = this.LastMenstrualPeriodByMeasuredDate(Convert.ToInt32(MeasuredPregnancyDay.Text), Convert.ToInt32(MeasuredPregnancyWeek.Text), DateTime.Now);
                }
            }
        }
    }
}