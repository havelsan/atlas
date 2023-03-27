
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseScheduledTask")] 

    public  abstract  partial class BaseScheduledTask : TTObject, IScheduledTask
    {
        public class BaseScheduledTaskList : TTObjectCollection<BaseScheduledTask> { }
                    
        public class ChildBaseScheduledTaskCollection : TTObject.TTChildObjectCollection<BaseScheduledTask>
        {
            public ChildBaseScheduledTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseScheduledTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<BaseScheduledTask> GetAvailableTasks(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASESCHEDULEDTASK"].QueryDefs["GetAvailableTasks"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<BaseScheduledTask>(queryDef, paramList);
        }

        public static BindingList<BaseScheduledTask> GetBaseScheduledTask(TTObjectContext objectContext, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASESCHEDULEDTASK"].QueryDefs["GetBaseScheduledTask"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<BaseScheduledTask>(queryDef, paramList);
        }

    /// <summary>
    /// Çalışma Saati
    /// </summary>
        public int? WorkHour
        {
            get { return (int?)this["WORKHOUR"]; }
            set { this["WORKHOUR"] = value; }
        }

    /// <summary>
    /// Tekrar Sayısı
    /// </summary>
        public int? Recurrency
        {
            get { return (int?)this["RECURRENCY"]; }
            set { this["RECURRENCY"] = value; }
        }

    /// <summary>
    /// Son Çalışma Tarihi
    /// </summary>
        public DateTime? LastExecutionDate
        {
            get { return (DateTime?)this["LASTEXECUTIONDATE"]; }
            set { this["LASTEXECUTIONDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi Yok
    /// </summary>
        public bool? NoEndDate
        {
            get { return (bool?)this["NOENDDATE"]; }
            set { this["NOENDDATE"] = value; }
        }

    /// <summary>
    /// Görev Adı
    /// </summary>
        public string TaskName
        {
            get { return (string)this["TASKNAME"]; }
            set { this["TASKNAME"] = value; }
        }

    /// <summary>
    /// Çalışma Periyodu
    /// </summary>
        public ScheduledTaskPeriodEnum? Period
        {
            get { return (ScheduledTaskPeriodEnum?)(int?)this["PERIOD"]; }
            set { this["PERIOD"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Kaç Defa Çalıştı
    /// </summary>
        public int? ExecutionCount
        {
            get { return (int?)this["EXECUTIONCOUNT"]; }
            set { this["EXECUTIONCOUNT"] = value; }
        }

        public string CronExpression
        {
            get { return (string)this["CRONEXPRESSION"]; }
            set { this["CRONEXPRESSION"] = value; }
        }

    /// <summary>
    /// Çalışma Dakikası
    /// </summary>
        public int? WorkMinute
        {
            get { return (int?)this["WORKMINUTE"]; }
            set { this["WORKMINUTE"] = value; }
        }

        virtual protected void CreateScheduledTaskHistoriesCollection()
        {
            _ScheduledTaskHistories = new ScheduledTaskHistory.ChildScheduledTaskHistoryCollection(this, new Guid("787d4a99-e9df-488a-b38d-9c946cc20c4b"));
            ((ITTChildObjectCollection)_ScheduledTaskHistories).GetChildren();
        }

        protected ScheduledTaskHistory.ChildScheduledTaskHistoryCollection _ScheduledTaskHistories = null;
        public ScheduledTaskHistory.ChildScheduledTaskHistoryCollection ScheduledTaskHistories
        {
            get
            {
                if (_ScheduledTaskHistories == null)
                    CreateScheduledTaskHistoriesCollection();
                return _ScheduledTaskHistories;
            }
        }

        protected BaseScheduledTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseScheduledTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseScheduledTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseScheduledTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseScheduledTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASESCHEDULEDTASK", dataRow) { }
        protected BaseScheduledTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASESCHEDULEDTASK", dataRow, isImported) { }
        public BaseScheduledTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseScheduledTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseScheduledTask() : base() { }

    }
}