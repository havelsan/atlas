
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AppointmentType")] 

    public  partial class AppointmentType : TTObject
    {
        public class AppointmentTypeList : TTObjectCollection<AppointmentType> { }
                    
        public class ChildAppointmentTypeCollection : TTObject.TTChildObjectCollection<AppointmentType>
        {
            public ChildAppointmentTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAppointmentTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Türü
    /// </summary>
        public AppointmentTypeEnum? Type
        {
            get { return (AppointmentTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Randevu Türü
    /// </summary>
        public AppointmentCarrier AppointmentCarrier
        {
            get { return (AppointmentCarrier)((ITTObject)this).GetParent("APPOINTMENTCARRIER"); }
            set { this["APPOINTMENTCARRIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AppointmentType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AppointmentType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AppointmentType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AppointmentType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AppointmentType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APPOINTMENTTYPE", dataRow) { }
        protected AppointmentType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APPOINTMENTTYPE", dataRow, isImported) { }
        public AppointmentType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AppointmentType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AppointmentType() : base() { }

    }
}