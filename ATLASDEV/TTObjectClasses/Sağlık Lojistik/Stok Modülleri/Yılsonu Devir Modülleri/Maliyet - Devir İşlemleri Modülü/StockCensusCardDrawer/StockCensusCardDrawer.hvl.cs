
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockCensusCardDrawer")] 

    public  partial class StockCensusCardDrawer : TTObject
    {
        public class StockCensusCardDrawerList : TTObjectCollection<StockCensusCardDrawer> { }
                    
        public class ChildStockCensusCardDrawerCollection : TTObject.TTChildObjectCollection<StockCensusCardDrawer>
        {
            public ChildStockCensusCardDrawerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockCensusCardDrawerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Çfit Sıfırlı
    /// </summary>
        public bool? IsDoubleZeroCompleted
        {
            get { return (bool?)this["ISDOUBLEZEROCOMPLETED"]; }
            set { this["ISDOUBLEZEROCOMPLETED"] = value; }
        }

    /// <summary>
    /// Yılsonu Devir
    /// </summary>
        public bool? IsStockCensusCompleted
        {
            get { return (bool?)this["ISSTOCKCENSUSCOMPLETED"]; }
            set { this["ISSTOCKCENSUSCOMPLETED"] = value; }
        }

        public Guid? DoubleZeroObjectID
        {
            get { return (Guid?)this["DOUBLEZEROOBJECTID"]; }
            set { this["DOUBLEZEROOBJECTID"] = value; }
        }

        public Guid? StockCensusObjectID
        {
            get { return (Guid?)this["STOCKCENSUSOBJECTID"]; }
            set { this["STOCKCENSUSOBJECTID"] = value; }
        }

        public ResCardDrawer CardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("CARDDRAWER"); }
            set { this["CARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CheckStockCensusAction CheckStockCensusAction
        {
            get { return (CheckStockCensusAction)((ITTObject)this).GetParent("CHECKSTOCKCENSUSACTION"); }
            set { this["CHECKSTOCKCENSUSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockCensusCardDrawer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockCensusCardDrawer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockCensusCardDrawer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockCensusCardDrawer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockCensusCardDrawer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKCENSUSCARDDRAWER", dataRow) { }
        protected StockCensusCardDrawer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKCENSUSCARDDRAWER", dataRow, isImported) { }
        public StockCensusCardDrawer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockCensusCardDrawer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockCensusCardDrawer() : base() { }

    }
}