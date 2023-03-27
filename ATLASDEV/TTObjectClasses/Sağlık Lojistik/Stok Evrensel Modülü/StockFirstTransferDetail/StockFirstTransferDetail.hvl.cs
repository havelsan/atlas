
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockFirstTransferDetail")] 

    /// <summary>
    /// İlk transfer işlemi için transferi yapılacak malzeme bilgilerini barındıran sınıftır
    /// </summary>
    public  partial class StockFirstTransferDetail : StockActionDetailOut
    {
        public class StockFirstTransferDetailList : TTObjectCollection<StockFirstTransferDetail> { }
                    
        public class ChildStockFirstTransferDetailCollection : TTObject.TTChildObjectCollection<StockFirstTransferDetail>
        {
            public ChildStockFirstTransferDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockFirstTransferDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected StockFirstTransferDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockFirstTransferDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockFirstTransferDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockFirstTransferDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockFirstTransferDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKFIRSTTRANSFERDETAIL", dataRow) { }
        protected StockFirstTransferDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKFIRSTTRANSFERDETAIL", dataRow, isImported) { }
        public StockFirstTransferDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockFirstTransferDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockFirstTransferDetail() : base() { }

    }
}