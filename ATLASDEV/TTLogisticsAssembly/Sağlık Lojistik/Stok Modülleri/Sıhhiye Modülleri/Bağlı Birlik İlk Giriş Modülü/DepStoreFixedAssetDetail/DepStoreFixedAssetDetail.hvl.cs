
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DepStoreFixedAssetDetail")] 

    public  partial class DepStoreFixedAssetDetail : TTObject
    {
        public class DepStoreFixedAssetDetailList : TTObjectCollection<DepStoreFixedAssetDetail> { }
                    
        public class ChildDepStoreFixedAssetDetailCollection : TTObject.TTChildObjectCollection<DepStoreFixedAssetDetail>
        {
            public ChildDepStoreFixedAssetDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDepStoreFixedAssetDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public FixedAssetMaterialDefinition FixedAssetMaterialDefinition
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFINITION"); }
            set { this["FIXEDASSETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DepStoreFirstInActionDet DepStoreFirstInActionDet
        {
            get { return (DepStoreFirstInActionDet)((ITTObject)this).GetParent("DEPSTOREFIRSTINACTIONDET"); }
            set { this["DEPSTOREFIRSTINACTIONDET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DepStoreFixedAssetDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DepStoreFixedAssetDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DepStoreFixedAssetDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DepStoreFixedAssetDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DepStoreFixedAssetDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEPSTOREFIXEDASSETDETAIL", dataRow) { }
        protected DepStoreFixedAssetDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEPSTOREFIXEDASSETDETAIL", dataRow, isImported) { }
        public DepStoreFixedAssetDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DepStoreFixedAssetDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DepStoreFixedAssetDetail() : base() { }

    }
}