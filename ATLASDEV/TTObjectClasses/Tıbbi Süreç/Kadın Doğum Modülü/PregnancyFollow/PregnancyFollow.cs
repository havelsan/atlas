
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public partial class PregnancyFollow : TTObject
    {
        public class PregnancyCalender
        {
            public string PeriodName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime FinishDate { get; set; }
        }

        public static BindingList<PregnancyFollow.PregnancyCalender> FillPregnancyCalender(TTObjectContext context, DateTime lastMenstrualPeriod, PregnancyTypeEnum pregnancyType)
        {
            BindingList<PregnancyCalendarDefinition> pregnancyCalendarDefinitionList = PregnancyCalendarDefinition.GetAllNQL(context, pregnancyType, "");

            PregnancyFollow.PregnancyCalender pregnancyCalender = new PregnancyFollow.PregnancyCalender();
            BindingList<PregnancyFollow.PregnancyCalender> pregnancyCalenderList = new BindingList<PregnancyFollow.PregnancyCalender>();

            foreach (var item in pregnancyCalendarDefinitionList)
            {
                pregnancyCalender.PeriodName = item.PeriodName;
                pregnancyCalender.StartDate = lastMenstrualPeriod.AddDays(Convert.ToDouble(item.StartDate * 7));//item.StartDate*7 => haftadan güne dönüşüm
                pregnancyCalender.FinishDate = lastMenstrualPeriod.AddDays(Convert.ToDouble(item.FinishDate * 7));

                pregnancyCalenderList.Add(pregnancyCalender);
            }

            return pregnancyCalenderList;
        }

    }
}