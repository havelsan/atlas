
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResStorageSection")] 

    public  partial class ResStorageSection : ResSection
    {
        public class ResStorageSectionList : TTObjectCollection<ResStorageSection> { }
                    
        public class ChildResStorageSectionCollection : TTObject.TTChildObjectCollection<ResStorageSection>
        {
            public ChildResStorageSectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResStorageSectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResAccountancy Accountancy
        {
            get { return (ResAccountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResStorageSection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResStorageSection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResStorageSection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResStorageSection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResStorageSection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESSTORAGESECTION", dataRow) { }
        protected ResStorageSection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESSTORAGESECTION", dataRow, isImported) { }
        public ResStorageSection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResStorageSection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResStorageSection() : base() { }

    }
}