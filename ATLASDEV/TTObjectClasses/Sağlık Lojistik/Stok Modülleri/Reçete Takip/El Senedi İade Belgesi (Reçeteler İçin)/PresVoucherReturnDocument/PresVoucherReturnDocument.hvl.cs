
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresVoucherReturnDocument")] 

    /// <summary>
    /// El Senedi İade Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PresVoucherReturnDocument : VoucherReturnDocument, IStockTransferTransaction, IVoucherReturnDocument, IBasePrescriptionTransaction
    {
        public class PresVoucherReturnDocumentList : TTObjectCollection<PresVoucherReturnDocument> { }
                    
        public class ChildPresVoucherReturnDocumentCollection : TTObject.TTChildObjectCollection<PresVoucherReturnDocument>
        {
            public ChildPresVoucherReturnDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresVoucherReturnDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("16fe2a2f-7dcf-4395-91f0-822604896050"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("e4c316d5-71d8-45f5-a928-0bdaf0762815"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("23d55756-bf3a-45e8-b96d-487d4bf62d60"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("a36bd978-40e1-456f-9497-1255e4610fc7"); } }
        }

        protected PresVoucherReturnDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresVoucherReturnDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresVoucherReturnDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresVoucherReturnDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresVoucherReturnDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESVOUCHERRETURNDOCUMENT", dataRow) { }
        protected PresVoucherReturnDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESVOUCHERRETURNDOCUMENT", dataRow, isImported) { }
        public PresVoucherReturnDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresVoucherReturnDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresVoucherReturnDocument() : base() { }

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