
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptBackDocumentDetail")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade Döküman Detayı
    /// </summary>
    public  partial class ReceiptBackDocumentDetail : AccountDocumentDetail
    {
        public class ReceiptBackDocumentDetailList : TTObjectCollection<ReceiptBackDocumentDetail> { }
                    
        public class ChildReceiptBackDocumentDetailCollection : TTObject.TTChildObjectCollection<ReceiptBackDocumentDetail>
        {
            public ChildReceiptBackDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptBackDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("ade57a4b-5f37-46aa-b189-5b861906b4b6"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("2851a384-2757-4334-958b-fad8359c2779"); } }
        }

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı Döküman Detayı İlişkisi
    /// </summary>
        public ReceiptDocumentDetail ReceiptDocumentDetail
        {
            get { return (ReceiptDocumentDetail)((ITTObject)this).GetParent("RECEIPTDOCUMENTDETAIL"); }
            set { this["RECEIPTDOCUMENTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ReceiptBackDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptBackDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptBackDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptBackDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptBackDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTBACKDOCUMENTDETAIL", dataRow) { }
        protected ReceiptBackDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTBACKDOCUMENTDETAIL", dataRow, isImported) { }
        public ReceiptBackDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptBackDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptBackDocumentDetail() : base() { }

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