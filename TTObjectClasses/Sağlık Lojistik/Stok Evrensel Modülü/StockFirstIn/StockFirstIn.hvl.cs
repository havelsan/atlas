
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockFirstIn")] 

    /// <summary>
    /// İlk Giriş işlemi için kullanılan ana sınıftır
    /// </summary>
    public  partial class StockFirstIn : StockAction, IStockInTransaction
    {
        public class StockFirstInList : TTObjectCollection<StockFirstIn> { }
                    
        public class ChildStockFirstInCollection : TTObject.TTChildObjectCollection<StockFirstIn>
        {
            public ChildStockFirstInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockFirstInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Completed { get { return new Guid("076f013e-d27f-4ab1-9950-4b7fb3a9e52d"); } }
            public static Guid Cancelled { get { return new Guid("951b21a9-ee70-43ec-8cce-4580b8394151"); } }
            public static Guid New { get { return new Guid("ef3be805-9b92-4a5f-aa37-19e0f8e60b54"); } }
        }

        protected StockFirstIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockFirstIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockFirstIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockFirstIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockFirstIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKFIRSTIN", dataRow) { }
        protected StockFirstIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKFIRSTIN", dataRow, isImported) { }
        public StockFirstIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockFirstIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockFirstIn() : base() { }

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