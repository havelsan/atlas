
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseChattelDocument")] 

    public  abstract  partial class BaseChattelDocument : StockAction, IBaseChattelDocument
    {
        public class BaseChattelDocumentList : TTObjectCollection<BaseChattelDocument> { }
                    
        public class ChildBaseChattelDocumentCollection : TTObject.TTChildObjectCollection<BaseChattelDocument>
        {
            public ChildBaseChattelDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseChattelDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Approved { get { return new Guid("571c819e-f1eb-4caa-b806-2ecf27637dff"); } }
            public static Guid Cancelled { get { return new Guid("86e94272-5b6a-49cd-ab04-a240ed06bc56"); } }
            public static Guid Completed { get { return new Guid("59902f62-50e7-406f-972f-8394bc6b86e9"); } }
            public static Guid New { get { return new Guid("339c3681-5a62-4a03-b7bb-a43f2cc4f446"); } }
        }

    /// <summary>
    /// Harcama Birim
    /// </summary>
        public string SpendingUnit
        {
            get { return (string)this["SPENDINGUNIT"]; }
            set { this["SPENDINGUNIT"] = value; }
        }

    /// <summary>
    /// Harcama Birim Kodu
    /// </summary>
        public string SpendingUnitCode
        {
            get { return (string)this["SPENDINGUNITCODE"]; }
            set { this["SPENDINGUNITCODE"] = value; }
        }

        public string BaseNumber
        {
            get { return (string)this["BASENUMBER"]; }
            set { this["BASENUMBER"] = value; }
        }

        public DateTime? BaseDateTime
        {
            get { return (DateTime?)this["BASEDATETIME"]; }
            set { this["BASEDATETIME"] = value; }
        }

        protected BaseChattelDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseChattelDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseChattelDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseChattelDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseChattelDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASECHATTELDOCUMENT", dataRow) { }
        protected BaseChattelDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASECHATTELDOCUMENT", dataRow, isImported) { }
        public BaseChattelDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseChattelDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseChattelDocument() : base() { }

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