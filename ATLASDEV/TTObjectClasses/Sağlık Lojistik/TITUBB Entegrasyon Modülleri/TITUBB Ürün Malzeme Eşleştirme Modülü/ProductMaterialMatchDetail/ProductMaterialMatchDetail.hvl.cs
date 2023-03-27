
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductMaterialMatchDetail")] 

    public  partial class ProductMaterialMatchDetail : TTObject
    {
        public class ProductMaterialMatchDetailList : TTObjectCollection<ProductMaterialMatchDetail> { }
                    
        public class ChildProductMaterialMatchDetailCollection : TTObject.TTChildObjectCollection<ProductMaterialMatchDetail>
        {
            public ChildProductMaterialMatchDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductMaterialMatchDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// TITUBB'da Olmayan Malzemenin Barkod
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

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProductMaterialMatchAction ProductMaterialMatchAction
        {
            get { return (ProductMaterialMatchAction)((ITTObject)this).GetParent("PRODUCTMATERIALMATCHACTION"); }
            set { this["PRODUCTMATERIALMATCHACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MatchReasonDefinition MatchReasonDefinition
        {
            get { return (MatchReasonDefinition)((ITTObject)this).GetParent("MATCHREASONDEFINITION"); }
            set { this["MATCHREASONDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProductMaterialMatchDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductMaterialMatchDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductMaterialMatchDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductMaterialMatchDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductMaterialMatchDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTMATERIALMATCHDETAIL", dataRow) { }
        protected ProductMaterialMatchDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTMATERIALMATCHDETAIL", dataRow, isImported) { }
        public ProductMaterialMatchDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductMaterialMatchDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductMaterialMatchDetail() : base() { }

    }
}