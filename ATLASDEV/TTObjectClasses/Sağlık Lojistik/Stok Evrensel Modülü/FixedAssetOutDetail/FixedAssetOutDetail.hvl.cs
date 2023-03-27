
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetOutDetail")] 

    public  partial class FixedAssetOutDetail : FixedAssetDetail
    {
        public class FixedAssetOutDetailList : TTObjectCollection<FixedAssetOutDetail> { }
                    
        public class ChildFixedAssetOutDetailCollection : TTObject.TTChildObjectCollection<FixedAssetOutDetail>
        {
            public ChildFixedAssetOutDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetOutDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public FixedAssetMaterialDefinition FixedAssetMaterialDefinition
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFINITION"); }
            set { this["FIXEDASSETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Saymanlık
    /// </summary>
        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetOutDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetOutDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetOutDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetOutDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetOutDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETOUTDETAIL", dataRow) { }
        protected FixedAssetOutDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETOUTDETAIL", dataRow, isImported) { }
        public FixedAssetOutDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetOutDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetOutDetail() : base() { }

    }
}