
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
    public  partial class DeleteOldScheduledTaskLogs : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {
            try
            {
                TTObjectContext context = new TTObjectContext(false);
                int counter = 0;

                IBindingList oldLogs = context.QueryObjects(typeof(ScheduledTaskHistory).Name, "LOGDATE < " + Common.RecTime().AddDays(-365) + " AND ROWNUM < 501");
                while(oldLogs.Count > 0)
                {
                    foreach (ScheduledTaskHistory sth in oldLogs)
                    {
                        counter++;
                        ((ITTObject)sth).Delete();
                    }
                    context.Save();
                    context.Dispose();
                    if(Common.RecTime().Hour > 6)
                    {
                        AddLog(counter.ToString() + " adet planlı görev logu silinmiştir.");
                        return;
                    }
                    
                    context = new TTObjectContext(false);
                    oldLogs = context.QueryObjects(typeof(ScheduledTaskHistory).Name, "LOGDATE < " + Common.RecTime().AddDays(-365) + " AND ROWNUM < 501");
                }
                AddLog(counter.ToString() + " adet planlı görev logu silinmiştir.");
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }
        
#endregion Methods

    }
}