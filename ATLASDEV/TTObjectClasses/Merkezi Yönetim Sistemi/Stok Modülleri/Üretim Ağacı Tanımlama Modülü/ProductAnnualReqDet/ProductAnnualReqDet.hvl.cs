
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductAnnualReqDet")] 

    public  partial class ProductAnnualReqDet : TTObject
    {
        public class ProductAnnualReqDetList : TTObjectCollection<ProductAnnualReqDet> { }
                    
        public class ChildProductAnnualReqDetCollection : TTObject.TTChildObjectCollection<ProductAnnualReqDet>
        {
            public ChildProductAnnualReqDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductAnnualReqDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İhtiyaç Miktarı
    /// </summary>
        public double? RequirementAmount
        {
            get { return (double?)this["REQUIREMENTAMOUNT"]; }
            set { this["REQUIREMENTAMOUNT"] = value; }
        }

    /// <summary>
    /// İBF Yılı
    /// </summary>
        public int? IBFYear
        {
            get { return (int?)this["IBFYEAR"]; }
            set { this["IBFYEAR"] = value; }
        }

    /// <summary>
    /// Fire Yüzdesi
    /// </summary>
        public int? LossPercentage
        {
            get { return (int?)this["LOSSPERCENTAGE"]; }
            set { this["LOSSPERCENTAGE"] = value; }
        }

    /// <summary>
    /// Ürün Ağacı-İBF İhtiyaçları
    /// </summary>
        public ProductTreeDefinition ProductTreeDefinition
        {
            get { return (ProductTreeDefinition)((ITTObject)this).GetParent("PRODUCTTREEDEFINITION"); }
            set { this["PRODUCTTREEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProductAnnualReqDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductAnnualReqDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductAnnualReqDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductAnnualReqDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductAnnualReqDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTANNUALREQDET", dataRow) { }
        protected ProductAnnualReqDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTANNUALREQDET", dataRow, isImported) { }
        public ProductAnnualReqDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductAnnualReqDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductAnnualReqDet() : base() { }

    }
}