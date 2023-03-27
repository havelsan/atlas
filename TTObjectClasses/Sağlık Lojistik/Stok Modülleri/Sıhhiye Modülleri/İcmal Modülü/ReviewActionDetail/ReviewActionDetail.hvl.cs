
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReviewActionDetail")] 

    /// <summary>
    /// İcmal Detayı
    /// </summary>
    public  partial class ReviewActionDetail : StockActionDetailOut
    {
        public class ReviewActionDetailList : TTObjectCollection<ReviewActionDetail> { }
                    
        public class ChildReviewActionDetailCollection : TTObject.TTChildObjectCollection<ReviewActionDetail>
        {
            public ChildReviewActionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReviewActionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// StoreObjID
    /// </summary>
        public Guid? StoreObjID
        {
            get { return (Guid?)this["STOREOBJID"]; }
            set { this["STOREOBJID"] = value; }
        }

        public string StoreName
        {
            get { return (string)this["STORENAME"]; }
            set { this["STORENAME"] = value; }
        }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

        public Guid? StockTranactionGuid
        {
            get { return (Guid?)this["STOCKTRANACTIONGUID"]; }
            set { this["STOCKTRANACTIONGUID"] = value; }
        }

        public BudgetTypeDefinition BudgetTypeDefinition
        {
            get { return (BudgetTypeDefinition)((ITTObject)this).GetParent("BUDGETTYPEDEFINITION"); }
            set { this["BUDGETTYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ReviewActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReviewActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReviewActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReviewActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReviewActionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REVIEWACTIONDETAIL", dataRow) { }
        protected ReviewActionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REVIEWACTIONDETAIL", dataRow, isImported) { }
        public ReviewActionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReviewActionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReviewActionDetail() : base() { }

    }
}