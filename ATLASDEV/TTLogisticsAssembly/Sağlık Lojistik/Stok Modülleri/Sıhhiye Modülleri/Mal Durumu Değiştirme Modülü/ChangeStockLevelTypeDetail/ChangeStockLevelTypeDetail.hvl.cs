
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChangeStockLevelTypeDetail")] 

    public  partial class ChangeStockLevelTypeDetail : StockActionDetailOut
    {
        public class ChangeStockLevelTypeDetailList : TTObjectCollection<ChangeStockLevelTypeDetail> { }
                    
        public class ChildChangeStockLevelTypeDetailCollection : TTObject.TTChildObjectCollection<ChangeStockLevelTypeDetail>
        {
            public ChildChangeStockLevelTypeDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChangeStockLevelTypeDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public ChangeStockLevelType ChangeStockLevelType
        {
            get 
            {   
                if (StockAction is ChangeStockLevelType)
                    return (ChangeStockLevelType)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected ChangeStockLevelTypeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChangeStockLevelTypeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChangeStockLevelTypeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChangeStockLevelTypeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChangeStockLevelTypeDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHANGESTOCKLEVELTYPEDETAIL", dataRow) { }
        protected ChangeStockLevelTypeDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHANGESTOCKLEVELTYPEDETAIL", dataRow, isImported) { }
        public ChangeStockLevelTypeDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChangeStockLevelTypeDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChangeStockLevelTypeDetail() : base() { }

    }
}