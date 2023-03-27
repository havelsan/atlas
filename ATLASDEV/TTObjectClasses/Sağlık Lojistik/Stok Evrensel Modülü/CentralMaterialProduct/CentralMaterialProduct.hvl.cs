
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CentralMaterialProduct")] 

    public  partial class CentralMaterialProduct : TTObject
    {
        public class CentralMaterialProductList : TTObjectCollection<CentralMaterialProduct> { }
                    
        public class ChildCentralMaterialProductCollection : TTObject.TTChildObjectCollection<CentralMaterialProduct>
        {
            public ChildCentralMaterialProductCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCentralMaterialProductCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// TITUBB'da Bulunmayan Barkod
    /// </summary>
        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

        public ProductDefinition Product
        {
            get { return (ProductDefinition)((ITTObject)this).GetParent("PRODUCT"); }
            set { this["PRODUCT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MatchReasonDefinition MatchReason
        {
            get { return (MatchReasonDefinition)((ITTObject)this).GetParent("MATCHREASON"); }
            set { this["MATCHREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CentralMaterialProduct(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CentralMaterialProduct(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CentralMaterialProduct(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CentralMaterialProduct(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CentralMaterialProduct(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CENTRALMATERIALPRODUCT", dataRow) { }
        protected CentralMaterialProduct(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CENTRALMATERIALPRODUCT", dataRow, isImported) { }
        public CentralMaterialProduct(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CentralMaterialProduct(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CentralMaterialProduct() : base() { }

    }
}