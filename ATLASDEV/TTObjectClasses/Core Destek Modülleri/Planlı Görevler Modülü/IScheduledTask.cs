
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
    public partial interface IScheduledTask : IAttributeInterface
    {
#region Methods
           
        void TaskScript();

        void AddLog(string log);

        bool? GetActive();

        void SetActive(bool? value);

        DateTime? GetEndDate();

        void SetEndDate(DateTime? value);

        bool? GetNoEndDate();

        void SetNoEndDate(bool? value);

        ScheduledTaskPeriodEnum? GetPeriod();

        void SetPeriod(ScheduledTaskPeriodEnum? value);
        
        int? GetRecurrency();

        void SetRecurrency(int? value);

        DateTime? GetStartDate();

        void SetStartDate(DateTime? value);

        String GetTaskName();

        void SetTaskName(String value);
        
        int? GetWorkHour();

        void SetWorkHour(int? value);


        #endregion Methods
    }
}