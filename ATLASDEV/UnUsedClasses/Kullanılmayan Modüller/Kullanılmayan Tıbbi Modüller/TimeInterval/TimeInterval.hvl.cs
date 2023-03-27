
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TimeInterval")] 

    public  partial class TimeInterval : TTObject
    {
        public class TimeIntervalList : TTObjectCollection<TimeInterval> { }
                    
        public class ChildTimeIntervalCollection : TTObject.TTChildObjectCollection<TimeInterval>
        {
            public ChildTimeIntervalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTimeIntervalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bitiş Saati
    /// </summary>
        public DateTime? EndTime
        {
            get { return (DateTime?)this["ENDTIME"]; }
            set { this["ENDTIME"] = value; }
        }

    /// <summary>
    /// Başlangıç Saati
    /// </summary>
        public DateTime? StartTime
        {
            get { return (DateTime?)this["STARTTIME"]; }
            set { this["STARTTIME"] = value; }
        }

        protected TimeInterval(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TimeInterval(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TimeInterval(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TimeInterval(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TimeInterval(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TIMEINTERVAL", dataRow) { }
        protected TimeInterval(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TIMEINTERVAL", dataRow, isImported) { }
        public TimeInterval(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TimeInterval(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TimeInterval() : base() { }

    }
}