
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockControl")] 

    /// <summary>
    /// Stok Kontrol
    /// </summary>
    public  partial class StockControl : TTObject
    {
        public class StockControlList : TTObjectCollection<StockControl> { }
                    
        public class ChildStockControlCollection : TTObject.TTChildObjectCollection<StockControl>
        {
            public ChildStockControlCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockControlCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("810596bb-96cc-4b0d-a6be-71d564ebdfa9"); } }
            public static Guid Control { get { return new Guid("144d49f8-d841-40d6-8c79-af2581df74cf"); } }
        }

        protected StockControl(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockControl(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockControl(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockControl(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockControl(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKCONTROL", dataRow) { }
        protected StockControl(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKCONTROL", dataRow, isImported) { }
        public StockControl(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockControl(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockControl() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}