
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MorgueDeathType")] 

    public  partial class MorgueDeathType : TTObject
    {
        public class MorgueDeathTypeList : TTObjectCollection<MorgueDeathType> { }
                    
        public class ChildMorgueDeathTypeCollection : TTObject.TTChildObjectCollection<MorgueDeathType>
        {
            public ChildMorgueDeathTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMorgueDeathTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSOlumSekli SKRSOlumSekli
        {
            get { return (SKRSOlumSekli)((ITTObject)this).GetParent("SKRSOLUMSEKLI"); }
            set { this["SKRSOLUMSEKLI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Morgue Morgue
        {
            get { return (Morgue)((ITTObject)this).GetParent("MORGUE"); }
            set { this["MORGUE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MorgueDeathType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MorgueDeathType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MorgueDeathType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MorgueDeathType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MorgueDeathType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MORGUEDEATHTYPE", dataRow) { }
        protected MorgueDeathType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MORGUEDEATHTYPE", dataRow, isImported) { }
        public MorgueDeathType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MorgueDeathType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MorgueDeathType() : base() { }

    }
}