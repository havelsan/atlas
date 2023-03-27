
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AppointmentCarrierUserTypes")] 

    /// <summary>
    /// Kullanıcı Tipleri
    /// </summary>
    public  partial class AppointmentCarrierUserTypes : TTObject
    {
        public class AppointmentCarrierUserTypesList : TTObjectCollection<AppointmentCarrierUserTypes> { }
                    
        public class ChildAppointmentCarrierUserTypesCollection : TTObject.TTChildObjectCollection<AppointmentCarrierUserTypes>
        {
            public ChildAppointmentCarrierUserTypesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAppointmentCarrierUserTypesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kullanıcı Tipi
    /// </summary>
        public UserTypeEnum? UserType
        {
            get { return (UserTypeEnum?)(int?)this["USERTYPE"]; }
            set { this["USERTYPE"] = value; }
        }

        public AppointmentCarrier AppointmentCarrier
        {
            get { return (AppointmentCarrier)((ITTObject)this).GetParent("APPOINTMENTCARRIER"); }
            set { this["APPOINTMENTCARRIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AppointmentCarrierUserTypes(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AppointmentCarrierUserTypes(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AppointmentCarrierUserTypes(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AppointmentCarrierUserTypes(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AppointmentCarrierUserTypes(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APPOINTMENTCARRIERUSERTYPES", dataRow) { }
        protected AppointmentCarrierUserTypes(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APPOINTMENTCARRIERUSERTYPES", dataRow, isImported) { }
        public AppointmentCarrierUserTypes(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AppointmentCarrierUserTypes(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AppointmentCarrierUserTypes() : base() { }

    }
}