
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GrantMaterialDetail")] 

    public  partial class GrantMaterialDetail : StockActionDetailIn
    {
        public class GrantMaterialDetailList : TTObjectCollection<GrantMaterialDetail> { }
                    
        public class ChildGrantMaterialDetailCollection : TTObject.TTChildObjectCollection<GrantMaterialDetail>
        {
            public ChildGrantMaterialDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGrantMaterialDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected GrantMaterialDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GrantMaterialDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GrantMaterialDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GrantMaterialDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GrantMaterialDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GRANTMATERIALDETAIL", dataRow) { }
        protected GrantMaterialDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GRANTMATERIALDETAIL", dataRow, isImported) { }
        public GrantMaterialDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GrantMaterialDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GrantMaterialDetail() : base() { }

    }
}