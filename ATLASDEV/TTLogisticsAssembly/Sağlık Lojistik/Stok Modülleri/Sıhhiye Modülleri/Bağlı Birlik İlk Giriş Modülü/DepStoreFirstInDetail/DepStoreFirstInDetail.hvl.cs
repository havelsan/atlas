
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DepStoreFirstInDetail")] 

    public  partial class DepStoreFirstInDetail : StockActionDetailIn
    {
        public class DepStoreFirstInDetailList : TTObjectCollection<DepStoreFirstInDetail> { }
                    
        public class ChildDepStoreFirstInDetailCollection : TTObject.TTChildObjectCollection<DepStoreFirstInDetail>
        {
            public ChildDepStoreFirstInDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDepStoreFirstInDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DepStoreFirstInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DepStoreFirstInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DepStoreFirstInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DepStoreFirstInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DepStoreFirstInDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEPSTOREFIRSTINDETAIL", dataRow) { }
        protected DepStoreFirstInDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEPSTOREFIRSTINDETAIL", dataRow, isImported) { }
        public DepStoreFirstInDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DepStoreFirstInDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DepStoreFirstInDetail() : base() { }

    }
}