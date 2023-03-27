
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
    public  partial class WorkDayExceptionDef : TerminologyManagerDef
    {
        public partial class GetWorkDayExceptionDefs_Class : TTReportNqlObject 
        {
        }

        public partial class WorkDayExceptionDefFormNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetWorkDayExcesptionsQuery_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            
            //if (this.Date.Value.DayOfWeek == DayOfWeek.Saturday || this.Date.Value.DayOfWeek == DayOfWeek.Saturday)
            //{
            //    throw new TTUtils.TTException(SystemMessage.GetMessage(555));
            //}
            Date = ((DateTime)Date.Value).Date ; 

#endregion PreInsert
        }

#region Methods
        public bool IsWorkDay(DateTime date)
        {
            
            TTObjectContext objectContext = new TTObjectContext(false);
            BindingList<WorkDayExceptionDef> workDay = WorkDayExceptionDef.GetWorkDayExceptions(objectContext,date);
            objectContext.Dispose();

            if (workDay != null && workDay.Count > 0)
            {
                return false;
            }
            else
            {

                if ( date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.WorkDayExceptionDefInfo;
        }
        
#endregion Methods

    }
}