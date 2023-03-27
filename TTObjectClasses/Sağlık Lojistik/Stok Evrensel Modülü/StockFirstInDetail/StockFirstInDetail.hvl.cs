
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockFirstInDetail")] 

    /// <summary>
    /// İlk giriş işlemi için girişi yapılacak malzeme bilgilerini barındıran sınıftır
    /// </summary>
    public  partial class StockFirstInDetail : StockActionDetailIn
    {
        public class StockFirstInDetailList : TTObjectCollection<StockFirstInDetail> { }
                    
        public class ChildStockFirstInDetailCollection : TTObject.TTChildObjectCollection<StockFirstInDetail>
        {
            public ChildStockFirstInDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockFirstInDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// MkysStokHareketID
    /// </summary>
        public int? MkysStokHareketID
        {
            get { return (int?)this["MKYSSTOKHAREKETID"]; }
            set { this["MKYSSTOKHAREKETID"] = value; }
        }

        protected StockFirstInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockFirstInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockFirstInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockFirstInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockFirstInDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKFIRSTINDETAIL", dataRow) { }
        protected StockFirstInDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKFIRSTINDETAIL", dataRow, isImported) { }
        public StockFirstInDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockFirstInDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockFirstInDetail() : base() { }

    }
}