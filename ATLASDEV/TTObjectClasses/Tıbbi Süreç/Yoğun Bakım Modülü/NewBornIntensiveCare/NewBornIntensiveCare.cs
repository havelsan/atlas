
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
    public  partial class NewBornIntensiveCare : TTObject
    {
        public string GetChronologicalAge(DateTime birthDate)
        {
            Common.Age age = Common.CalculateAge(birthDate);
            StringBuilder chronologicalAge = new StringBuilder("");
            if (age.Years > 0)
            {
                chronologicalAge.Append(age.Years.ToString());
                chronologicalAge.Append(" Yýl ");
            }
            if (age.Months > 0)
            {
                chronologicalAge.Append(age.Months.ToString());
                chronologicalAge.Append(" Ay ");
            }
            if (age.Days > 7)
            {
                int week = age.Days / 7;
                int day = age.Days % 7;

                chronologicalAge.Append(week.ToString());
                chronologicalAge.Append(" Hafta ");

                chronologicalAge.Append(day.ToString());
                chronologicalAge.Append(" Gün");
            }
            else
            {
                chronologicalAge.Append(age.Days.ToString());
                chronologicalAge.Append(" Gün");
            }

            return chronologicalAge.ToString();
        }

        public string GetCorrectedAge(int gestationalWeek, int gestationalDay, DateTime birthDate)
        {
            StringBuilder correctedAgeStr = new StringBuilder("");

            int gestationalAge = gestationalDay + (gestationalWeek * 7);
            int chronologicalAge = Convert.ToInt32((DateTime.Now - birthDate).TotalDays);
            int correctedAge = 280 - gestationalAge + chronologicalAge;

            if (correctedAge > 7)
            {
                int week = correctedAge / 7;
                int day = correctedAge % 7;

                correctedAgeStr.Append(week.ToString());
                correctedAgeStr.Append(" Hafta ");
                correctedAgeStr.Append(day.ToString());
                correctedAgeStr.Append(" Gün");
            }
            else
            {
                correctedAgeStr.Append(correctedAge.ToString());
                correctedAgeStr.Append(" Gün");
            }

            return correctedAgeStr.ToString();
        }
    }
}