
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockExpendableDetail")] 

    public  partial class StockExpendableDetail : TTObject
    {
        public class StockExpendableDetailList : TTObjectCollection<StockExpendableDetail> { }
                    
        public class ChildStockExpendableDetailCollection : TTObject.TTChildObjectCollection<StockExpendableDetail>
        {
            public ChildStockExpendableDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockExpendableDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockExpendableDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockExpendableDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockExpendableDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockExpendableDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockExpendableDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKEXPENDABLEDETAIL", dataRow) { }
        protected StockExpendableDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKEXPENDABLEDETAIL", dataRow, isImported) { }
        public StockExpendableDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockExpendableDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockExpendableDetail() : base() { }

    }
}