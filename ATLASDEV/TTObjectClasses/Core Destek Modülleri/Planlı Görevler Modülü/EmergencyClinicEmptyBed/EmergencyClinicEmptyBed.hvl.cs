
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyClinicEmptyBed")] 

    public  partial class EmergencyClinicEmptyBed : BaseScheduledTask
    {
        public class EmergencyClinicEmptyBedList : TTObjectCollection<EmergencyClinicEmptyBed> { }
                    
        public class ChildEmergencyClinicEmptyBedCollection : TTObject.TTChildObjectCollection<EmergencyClinicEmptyBed>
        {
            public ChildEmergencyClinicEmptyBedCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyClinicEmptyBedCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected EmergencyClinicEmptyBed(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyClinicEmptyBed(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyClinicEmptyBed(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyClinicEmptyBed(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyClinicEmptyBed(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYCLINICEMPTYBED", dataRow) { }
        protected EmergencyClinicEmptyBed(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYCLINICEMPTYBED", dataRow, isImported) { }
        public EmergencyClinicEmptyBed(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyClinicEmptyBed(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyClinicEmptyBed() : base() { }

    }
}