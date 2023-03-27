
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakeOffDatetime")] 

    public  partial class TakeOffDatetime : TTDefinitionSet
    {
        public class TakeOffDatetimeList : TTObjectCollection<TakeOffDatetime> { }
                    
        public class ChildTakeOffDatetimeCollection : TTObject.TTChildObjectCollection<TakeOffDatetime>
        {
            public ChildTakeOffDatetimeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakeOffDatetimeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DateTime? TakeOffDate
        {
            get { return (DateTime?)this["TAKEOFFDATE"]; }
            set { this["TAKEOFFDATE"] = value; }
        }

        public DateTime? StartTime
        {
            get { return (DateTime?)this["STARTTIME"]; }
            set { this["STARTTIME"] = value; }
        }

        public DateTime? EndTime
        {
            get { return (DateTime?)this["ENDTIME"]; }
            set { this["ENDTIME"] = value; }
        }

        public bool? IsAllDayOff
        {
            get { return (bool?)this["ISALLDAYOFF"]; }
            set { this["ISALLDAYOFF"] = value; }
        }

        public bool? IsStart
        {
            get { return (bool?)this["ISSTART"]; }
            set { this["ISSTART"] = value; }
        }

        protected TakeOffDatetime(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakeOffDatetime(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakeOffDatetime(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakeOffDatetime(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakeOffDatetime(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKEOFFDATETIME", dataRow) { }
        protected TakeOffDatetime(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKEOFFDATETIME", dataRow, isImported) { }
        public TakeOffDatetime(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakeOffDatetime(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakeOffDatetime() : base() { }

    }
}