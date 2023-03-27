
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockActionVatRate")] 

    public  partial class StockActionVatRate : TTObject
    {
        public class StockActionVatRateList : TTObjectCollection<StockActionVatRate> { }
                    
        public class ChildStockActionVatRateCollection : TTObject.TTChildObjectCollection<StockActionVatRate>
        {
            public ChildStockActionVatRateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockActionVatRateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// KDV Tutarı
    /// </summary>
        public Currency? VatPrice
        {
            get { return (Currency?)this["VATPRICE"]; }
            set { this["VATPRICE"] = value; }
        }

    /// <summary>
    /// KDV
    /// </summary>
        public long? VatRate
        {
            get { return (long?)this["VATRATE"]; }
            set { this["VATRATE"] = value; }
        }

        public StockAction StockAction
        {
            get { return (StockAction)((ITTObject)this).GetParent("STOCKACTION"); }
            set { this["STOCKACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockActionVatRate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockActionVatRate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockActionVatRate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockActionVatRate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockActionVatRate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKACTIONVATRATE", dataRow) { }
        protected StockActionVatRate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKACTIONVATRATE", dataRow, isImported) { }
        public StockActionVatRate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockActionVatRate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockActionVatRate() : base() { }

    }
}