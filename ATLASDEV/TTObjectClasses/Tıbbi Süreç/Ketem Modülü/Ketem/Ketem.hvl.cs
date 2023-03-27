
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Ketem")] 

    public  partial class Ketem : TTObject
    {
        public class KetemList : TTObjectCollection<Ketem> { }
                    
        public class ChildKetemCollection : TTObject.TTChildObjectCollection<Ketem>
        {
            public ChildKetemCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKetemCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Ketem(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Ketem(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Ketem(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Ketem(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Ketem(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KETEM", dataRow) { }
        protected Ketem(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KETEM", dataRow, isImported) { }
        public Ketem(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Ketem(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Ketem() : base() { }

    }
}