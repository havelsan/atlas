
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ScheduleAppointmentType")] 

    public  partial class ScheduleAppointmentType : TTObject
    {
        public class ScheduleAppointmentTypeList : TTObjectCollection<ScheduleAppointmentType> { }
                    
        public class ChildScheduleAppointmentTypeCollection : TTObject.TTChildObjectCollection<ScheduleAppointmentType>
        {
            public ChildScheduleAppointmentTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildScheduleAppointmentTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public AppointmentTypeEnum? AppointmentType
        {
            get { return (AppointmentTypeEnum?)(int?)this["APPOINTMENTTYPE"]; }
            set { this["APPOINTMENTTYPE"] = value; }
        }

        public Schedule Schedule
        {
            get { return (Schedule)((ITTObject)this).GetParent("SCHEDULE"); }
            set { this["SCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ScheduleAppointmentType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ScheduleAppointmentType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ScheduleAppointmentType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ScheduleAppointmentType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ScheduleAppointmentType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SCHEDULEAPPOINTMENTTYPE", dataRow) { }
        protected ScheduleAppointmentType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SCHEDULEAPPOINTMENTTYPE", dataRow, isImported) { }
        public ScheduleAppointmentType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ScheduleAppointmentType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ScheduleAppointmentType() : base() { }

    }
}