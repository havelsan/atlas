
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResType")] 

    public  partial class ResType : TTObject
    {
        public class ResTypeList : TTObjectCollection<ResType> { }
                    
        public class ChildResTypeCollection : TTObject.TTChildObjectCollection<ResType>
        {
            public ChildResTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateResourcesCollection()
        {
            _Resources = new Resource.ChildResourceCollection(this, new Guid("623b833d-9b34-43b2-a7dc-95254142b9a5"));
            ((ITTChildObjectCollection)_Resources).GetChildren();
        }

        protected Resource.ChildResourceCollection _Resources = null;
    /// <summary>
    /// Child collection for Kaynak Tipi
    /// </summary>
        public Resource.ChildResourceCollection Resources
        {
            get
            {
                if (_Resources == null)
                    CreateResourcesCollection();
                return _Resources;
            }
        }

        protected ResType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESTYPE", dataRow) { }
        protected ResType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESTYPE", dataRow, isImported) { }
        public ResType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResType() : base() { }

    }
}