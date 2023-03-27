
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubActionMaterialStockActionDetailRelation")] 

    public  partial class SubActionMaterialStockActionDetailRelation : TTObject
    {
        public class SubActionMaterialStockActionDetailRelationList : TTObjectCollection<SubActionMaterialStockActionDetailRelation> { }
                    
        public class ChildSubActionMaterialStockActionDetailRelationCollection : TTObject.TTChildObjectCollection<SubActionMaterialStockActionDetailRelation>
        {
            public ChildSubActionMaterialStockActionDetailRelationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubActionMaterialStockActionDetailRelationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public bool? Status
        {
            get { return (bool?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

        public StockActionDetailOut StockActionDetailOut
        {
            get { return (StockActionDetailOut)((ITTObject)this).GetParent("STOCKACTIONDETAILOUT"); }
            set { this["STOCKACTIONDETAILOUT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionMaterial SubActionMaterial
        {
            get { return (SubActionMaterial)((ITTObject)this).GetParent("SUBACTIONMATERIAL"); }
            set { this["SUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SubActionMaterialStockActionDetailRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubActionMaterialStockActionDetailRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubActionMaterialStockActionDetailRelation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubActionMaterialStockActionDetailRelation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubActionMaterialStockActionDetailRelation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBACTIONMATERIALSTOCKACTIONDETAILRELATION", dataRow) { }
        protected SubActionMaterialStockActionDetailRelation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBACTIONMATERIALSTOCKACTIONDETAILRELATION", dataRow, isImported) { }
        public SubActionMaterialStockActionDetailRelation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubActionMaterialStockActionDetailRelation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubActionMaterialStockActionDetailRelation() : base() { }

    }
}