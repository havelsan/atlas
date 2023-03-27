
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockCensusLevel")] 

    /// <summary>
    /// Yılsonu Devir Detayları Durumları Sekmesi
    /// </summary>
    public  partial class StockCensusLevel : TTObject
    {
        public class StockCensusLevelList : TTObjectCollection<StockCensusLevel> { }
                    
        public class ChildStockCensusLevelCollection : TTObject.TTChildObjectCollection<StockCensusLevel>
        {
            public ChildStockCensusLevelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockCensusLevelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mevcut
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public StockLevelType StockLevelType
        {
            get { return (StockLevelType)((ITTObject)this).GetParent("STOCKLEVELTYPE"); }
            set { this["STOCKLEVELTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockCensusDetail StockCensusDetail
        {
            get { return (StockCensusDetail)((ITTObject)this).GetParent("STOCKCENSUSDETAIL"); }
            set { this["STOCKCENSUSDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockCensusLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockCensusLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockCensusLevel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockCensusLevel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockCensusLevel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKCENSUSLEVEL", dataRow) { }
        protected StockCensusLevel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKCENSUSLEVEL", dataRow, isImported) { }
        public StockCensusLevel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockCensusLevel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockCensusLevel() : base() { }

    }
}