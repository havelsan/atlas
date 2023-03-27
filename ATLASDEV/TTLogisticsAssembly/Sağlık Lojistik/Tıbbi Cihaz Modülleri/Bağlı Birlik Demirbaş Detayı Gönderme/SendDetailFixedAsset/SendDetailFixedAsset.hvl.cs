
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendDetailFixedAsset")] 

    public  partial class SendDetailFixedAsset : TTObject
    {
        public class SendDetailFixedAssetList : TTObjectCollection<SendDetailFixedAsset> { }
                    
        public class ChildSendDetailFixedAssetCollection : TTObject.TTChildObjectCollection<SendDetailFixedAsset>
        {
            public ChildSendDetailFixedAssetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendDetailFixedAssetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SendDetailDependentStore SendDetailDependentStore
        {
            get { return (SendDetailDependentStore)((ITTObject)this).GetParent("SENDDETAILDEPENDENTSTORE"); }
            set { this["SENDDETAILDEPENDENTSTORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetMaterialDefinition FixedAssetMaterialDefinition
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFINITION"); }
            set { this["FIXEDASSETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SendDetailFixedAsset(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendDetailFixedAsset(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendDetailFixedAsset(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendDetailFixedAsset(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendDetailFixedAsset(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDDETAILFIXEDASSET", dataRow) { }
        protected SendDetailFixedAsset(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDDETAILFIXEDASSET", dataRow, isImported) { }
        public SendDetailFixedAsset(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendDetailFixedAsset(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendDetailFixedAsset() : base() { }

    }
}