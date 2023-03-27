
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
    public  abstract  partial class BaseScheduledTask : TTObject, IScheduledTask
    {
        #region IScheduledTask Members

        public bool? GetActive()
        {
            return Active;
        }

        public void SetActive(bool? value)
        {
            Active = value;
        }

        public DateTime? GetEndDate()
        {
            return EndDate;
        }

        public void SetEndDate(DateTime? value)
        {
            EndDate = value;
        }

        public bool? GetNoEndDate()
        {
            return NoEndDate;
        }

        public void SetNoEndDate(bool? value)
        {
            NoEndDate = value;
        }

        public ScheduledTaskPeriodEnum? GetPeriod()
        {
            return Period;
        }

        public void SetPeriod(ScheduledTaskPeriodEnum? value)
        {
            Period = value;
        }

        public int? GetRecurrency()
        {
            return Recurrency;
        }

        public void SetRecurrency(int? value)
        {
            Recurrency = value;
        }

        public DateTime? GetStartDate()
        {
            return StartDate;
        }

        public void SetStartDate(DateTime? value)
        {
            StartDate = value;
        }

        public String GetTaskName()
        {
            return TaskName;
        }

        public void SetTaskName(String value)
        {
            TaskName = value;
        }

        public int? GetWorkHour()
        {
            return WorkHour;
        }

        public void SetWorkHour(int? value)
        {
            WorkHour = value;
        }

        #endregion
        #region Methods
        public abstract void TaskScript();

        public virtual void AddLog(string log)
        {
            TTObjectContext context = new TTObjectContext(false);
            try
            {
                ScheduledTaskHistory scheduledTaskHistory = new ScheduledTaskHistory(context);
                scheduledTaskHistory.BaseScheduledTask = this;
                scheduledTaskHistory.LogDate = Common.RecTime();
                if(log.Length < 4000)
                    scheduledTaskHistory.Log = log;
                else
                    scheduledTaskHistory.Log = log.Substring(0,3999);
                context.Save();
            }
            catch (Exception ex2)
            {
                TTUtils.Logger.WriteException("RunTaskScript " + ToString() + " AddLog failed.", ex2);
            }
            finally
            {
                context.Dispose();
            }
        }
        
#endregion Methods

    }
}