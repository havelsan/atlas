
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExtendExpDateInDetail")] 

    public  partial class ExtendExpDateInDetail : StockActionDetailIn
    {
        public class ExtendExpDateInDetailList : TTObjectCollection<ExtendExpDateInDetail> { }
                    
        public class ChildExtendExpDateInDetailCollection : TTObject.TTChildObjectCollection<ExtendExpDateInDetail>
        {
            public ChildExtendExpDateInDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExtendExpDateInDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ExtendExpDateInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExtendExpDateInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExtendExpDateInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExtendExpDateInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExtendExpDateInDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTENDEXPDATEINDETAIL", dataRow) { }
        protected ExtendExpDateInDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTENDEXPDATEINDETAIL", dataRow, isImported) { }
        public ExtendExpDateInDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExtendExpDateInDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExtendExpDateInDetail() : base() { }

    }
}