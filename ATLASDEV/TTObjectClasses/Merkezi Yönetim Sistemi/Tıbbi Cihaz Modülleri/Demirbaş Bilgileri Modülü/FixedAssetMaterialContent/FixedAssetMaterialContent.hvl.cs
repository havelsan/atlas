
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetMaterialContent")] 

    /// <summary>
    /// Demirbaş Malzeme Muhteviyatı
    /// </summary>
    public  partial class FixedAssetMaterialContent : TTObject
    {
        public class FixedAssetMaterialContentList : TTObjectCollection<FixedAssetMaterialContent> { }
                    
        public class ChildFixedAssetMaterialContentCollection : TTObject.TTChildObjectCollection<FixedAssetMaterialContent>
        {
            public ChildFixedAssetMaterialContentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetMaterialContentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public long? ContentAmount
        {
            get { return (long?)this["CONTENTAMOUNT"]; }
            set { this["CONTENTAMOUNT"] = value; }
        }

        public FixedAssetMaterialDefinition FixedAssetMaterialDefinition
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFINITION"); }
            set { this["FIXEDASSETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DistributionTypeDefinition DistributionType
        {
            get { return (DistributionTypeDefinition)((ITTObject)this).GetParent("DISTRIBUTIONTYPE"); }
            set { this["DISTRIBUTIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetMaterialContent(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetMaterialContent(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetMaterialContent(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetMaterialContent(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetMaterialContent(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETMATERIALCONTENT", dataRow) { }
        protected FixedAssetMaterialContent(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETMATERIALCONTENT", dataRow, isImported) { }
        public FixedAssetMaterialContent(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetMaterialContent(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetMaterialContent() : base() { }

    }
}