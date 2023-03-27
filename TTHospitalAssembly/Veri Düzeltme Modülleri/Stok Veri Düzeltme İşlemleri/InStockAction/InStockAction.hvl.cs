
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InStockAction")] 

    public  partial class InStockAction : TTObject
    {
        public class InStockActionList : TTObjectCollection<InStockAction> { }
                    
        public class ChildInStockActionCollection : TTObject.TTChildObjectCollection<InStockAction>
        {
            public ChildInStockActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInStockActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// StockTransactionObjectID
    /// </summary>
        public Guid? StockTransactionObjectID
        {
            get { return (Guid?)this["STOCKTRANSACTIONOBJECTID"]; }
            set { this["STOCKTRANSACTIONOBJECTID"] = value; }
        }

    /// <summary>
    /// İşlem Adı
    /// </summary>
        public string StockActionDescription
        {
            get { return (string)this["STOCKACTIONDESCRIPTION"]; }
            set { this["STOCKACTIONDESCRIPTION"] = value; }
        }

        public FirstInStockAction FirstInStockAction
        {
            get { return (FirstInStockAction)((ITTObject)this).GetParent("FIRSTINSTOCKACTION"); }
            set { this["FIRSTINSTOCKACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockAction StockAction
        {
            get { return (StockAction)((ITTObject)this).GetParent("STOCKACTION"); }
            set { this["STOCKACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InStockAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InStockAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InStockAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InStockAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InStockAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INSTOCKACTION", dataRow) { }
        protected InStockAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INSTOCKACTION", dataRow, isImported) { }
        public InStockAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InStockAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InStockAction() : base() { }

    }
}