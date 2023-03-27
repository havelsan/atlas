
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResourceTypeTree")] 

    /// <summary>
    /// Kaynak Tip Ağacı
    /// </summary>
    public  partial class ResourceTypeTree : TTDefinitionSet
    {
        public class ResourceTypeTreeList : TTObjectCollection<ResourceTypeTree> { }
                    
        public class ChildResourceTypeTreeCollection : TTObject.TTChildObjectCollection<ResourceTypeTree>
        {
            public ChildResourceTypeTreeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResourceTypeTreeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

        public string ParentObjectDefName
        {
            get { return (string)this["PARENTOBJECTDEFNAME"]; }
            set { this["PARENTOBJECTDEFNAME"] = value; }
        }

        public string RelationDefID
        {
            get { return (string)this["RELATIONDEFID"]; }
            set { this["RELATIONDEFID"] = value; }
        }

        protected ResourceTypeTree(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResourceTypeTree(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResourceTypeTree(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResourceTypeTree(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResourceTypeTree(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESOURCETYPETREE", dataRow) { }
        protected ResourceTypeTree(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESOURCETYPETREE", dataRow, isImported) { }
        public ResourceTypeTree(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResourceTypeTree(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResourceTypeTree() : base() { }

    }
}