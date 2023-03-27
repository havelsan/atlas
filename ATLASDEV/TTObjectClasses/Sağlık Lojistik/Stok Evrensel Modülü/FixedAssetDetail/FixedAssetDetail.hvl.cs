
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDetail")] 

    public  abstract  partial class FixedAssetDetail : TTObject
    {
        public class FixedAssetDetailList : TTObjectCollection<FixedAssetDetail> { }
                    
        public class ChildFixedAssetDetailCollection : TTObject.TTChildObjectCollection<FixedAssetDetail>
        {
            public ChildFixedAssetDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public StockActionDetail StockActionDetail
        {
            get { return (StockActionDetail)((ITTObject)this).GetParent("STOCKACTIONDETAIL"); }
            set { this["STOCKACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDETAIL", dataRow) { }
        protected FixedAssetDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDETAIL", dataRow, isImported) { }
        public FixedAssetDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDetail() : base() { }

    }
}