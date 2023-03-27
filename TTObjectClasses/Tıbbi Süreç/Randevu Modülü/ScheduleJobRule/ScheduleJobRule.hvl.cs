
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ScheduleJobRule")] 

    public  partial class ScheduleJobRule : TTObject
    {
        public class ScheduleJobRuleList : TTObjectCollection<ScheduleJobRule> { }
                    
        public class ChildScheduleJobRuleCollection : TTObject.TTChildObjectCollection<ScheduleJobRule>
        {
            public ChildScheduleJobRuleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildScheduleJobRuleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// MHRS den dönen kaydedilmiş iş kuralı ID si
    /// </summary>
        public int? IsKuraliId
        {
            get { return (int?)this["ISKURALIID"]; }
            set { this["ISKURALIID"] = value; }
        }

    /// <summary>
    /// Zaman Kriteri
    /// </summary>
        public MHRSJobRuleTimeCriteriaEnum? TimeCriteria
        {
            get { return (MHRSJobRuleTimeCriteriaEnum?)(int?)this["TIMECRITERIA"]; }
            set { this["TIMECRITERIA"] = value; }
        }

    /// <summary>
    /// İş Kuralı Tipi
    /// </summary>
        public MHRSJobRuleTypeEnum? RuleType
        {
            get { return (MHRSJobRuleTypeEnum?)(int?)this["RULETYPE"]; }
            set { this["RULETYPE"] = value; }
        }

    /// <summary>
    /// Değer
    /// </summary>
        public int? RuleValue
        {
            get { return (int?)this["RULEVALUE"]; }
            set { this["RULEVALUE"] = value; }
        }

        public Schedule Schedule
        {
            get { return (Schedule)((ITTObject)this).GetParent("SCHEDULE"); }
            set { this["SCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ScheduleJobRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ScheduleJobRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ScheduleJobRule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ScheduleJobRule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ScheduleJobRule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SCHEDULEJOBRULE", dataRow) { }
        protected ScheduleJobRule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SCHEDULEJOBRULE", dataRow, isImported) { }
        public ScheduleJobRule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ScheduleJobRule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ScheduleJobRule() : base() { }

    }
}