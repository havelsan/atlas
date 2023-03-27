
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="E2Material")] 

    /// <summary>
    /// E2 Belgesi Malzemeler Sekmesi
    /// </summary>
    public  partial class E2Material : StockActionDetailOut
    {
        public class E2MaterialList : TTObjectCollection<E2Material> { }
                    
        public class ChildE2MaterialCollection : TTObject.TTChildObjectCollection<E2Material>
        {
            public ChildE2MaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildE2MaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected E2Material(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected E2Material(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected E2Material(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected E2Material(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected E2Material(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "E2MATERIAL", dataRow) { }
        protected E2Material(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "E2MATERIAL", dataRow, isImported) { }
        public E2Material(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public E2Material(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public E2Material() : base() { }

    }
}