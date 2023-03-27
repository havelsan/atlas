
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManipulationFormBaseObject")] 

    /// <summary>
    /// Manipulasyon Hizmet Gruplarına Özelleşmiş Formların Ana Objesi
    /// </summary>
    public  partial class ManipulationFormBaseObject : TTObject
    {
        public class ManipulationFormBaseObjectList : TTObjectCollection<ManipulationFormBaseObject> { }
                    
        public class ChildManipulationFormBaseObjectCollection : TTObject.TTChildObjectCollection<ManipulationFormBaseObject>
        {
            public ChildManipulationFormBaseObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManipulationFormBaseObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Manipulation Manipulation
        {
            get { return (Manipulation)((ITTObject)this).GetParent("MANIPULATION"); }
            set { this["MANIPULATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ManipulationFormBaseObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManipulationFormBaseObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManipulationFormBaseObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManipulationFormBaseObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManipulationFormBaseObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANIPULATIONFORMBASEOBJECT", dataRow) { }
        protected ManipulationFormBaseObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANIPULATIONFORMBASEOBJECT", dataRow, isImported) { }
        public ManipulationFormBaseObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManipulationFormBaseObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManipulationFormBaseObject() : base() { }

    }
}