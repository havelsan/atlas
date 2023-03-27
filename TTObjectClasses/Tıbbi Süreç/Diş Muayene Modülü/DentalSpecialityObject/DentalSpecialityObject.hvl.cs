
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalSpecialityObject")] 

    /// <summary>
    /// Diş Uzmanlık Dalı Ortak Bilgi Paneli Objesi
    /// </summary>
    public  partial class DentalSpecialityObject : SpecialityBasedObject
    {
        public class DentalSpecialityObjectList : TTObjectCollection<DentalSpecialityObject> { }
                    
        public class ChildDentalSpecialityObjectCollection : TTObject.TTChildObjectCollection<DentalSpecialityObject>
        {
            public ChildDentalSpecialityObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalSpecialityObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DentalSpecialityObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalSpecialityObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalSpecialityObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalSpecialityObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalSpecialityObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALSPECIALITYOBJECT", dataRow) { }
        protected DentalSpecialityObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALSPECIALITYOBJECT", dataRow, isImported) { }
        public DentalSpecialityObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalSpecialityObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalSpecialityObject() : base() { }

    }
}