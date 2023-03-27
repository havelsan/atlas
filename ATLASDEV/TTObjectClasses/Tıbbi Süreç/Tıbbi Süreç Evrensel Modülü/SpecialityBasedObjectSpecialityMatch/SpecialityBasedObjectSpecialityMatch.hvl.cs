
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecialityBasedObjectSpecialityMatch")] 

    /// <summary>
    /// Uzmanlık dalına özel objelerin uzmanlık dalı ile eşleştirildiği obje
    /// </summary>
    public  partial class SpecialityBasedObjectSpecialityMatch : TTObject
    {
        public class SpecialityBasedObjectSpecialityMatchList : TTObjectCollection<SpecialityBasedObjectSpecialityMatch> { }
                    
        public class ChildSpecialityBasedObjectSpecialityMatchCollection : TTObject.TTChildObjectCollection<SpecialityBasedObjectSpecialityMatch>
        {
            public ChildSpecialityBasedObjectSpecialityMatchCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecialityBasedObjectSpecialityMatchCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityBasedObject SpecialityBasedObject
        {
            get { return (SpecialityBasedObject)((ITTObject)this).GetParent("SPECIALITYBASEDOBJECT"); }
            set { this["SPECIALITYBASEDOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SpecialityBasedObjectSpecialityMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecialityBasedObjectSpecialityMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecialityBasedObjectSpecialityMatch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecialityBasedObjectSpecialityMatch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecialityBasedObjectSpecialityMatch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIALITYBASEDOBJECTSPECIALITYMATCH", dataRow) { }
        protected SpecialityBasedObjectSpecialityMatch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIALITYBASEDOBJECTSPECIALITYMATCH", dataRow, isImported) { }
        public SpecialityBasedObjectSpecialityMatch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecialityBasedObjectSpecialityMatch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecialityBasedObjectSpecialityMatch() : base() { }

    }
}