
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MatchFixedAsset")] 

    public  partial class MatchFixedAsset : TTObject
    {
        public class MatchFixedAssetList : TTObjectCollection<MatchFixedAsset> { }
                    
        public class ChildMatchFixedAssetCollection : TTObject.TTChildObjectCollection<MatchFixedAsset>
        {
            public ChildMatchFixedAssetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMatchFixedAssetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetParameterMatch FixedAssetParameterMatch
        {
            get { return (FixedAssetParameterMatch)((ITTObject)this).GetParent("FIXEDASSETPARAMETERMATCH"); }
            set { this["FIXEDASSETPARAMETERMATCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MatchFixedAsset(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MatchFixedAsset(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MatchFixedAsset(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MatchFixedAsset(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MatchFixedAsset(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATCHFIXEDASSET", dataRow) { }
        protected MatchFixedAsset(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATCHFIXEDASSET", dataRow, isImported) { }
        public MatchFixedAsset(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MatchFixedAsset(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MatchFixedAsset() : base() { }

    }
}