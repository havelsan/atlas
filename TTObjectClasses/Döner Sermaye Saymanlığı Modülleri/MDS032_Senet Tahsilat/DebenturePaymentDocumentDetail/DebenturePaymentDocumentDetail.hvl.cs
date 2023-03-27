
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebenturePaymentDocumentDetail")] 

    /// <summary>
    /// Senet Tahsilat Döküman Detayı
    /// </summary>
    public  partial class DebenturePaymentDocumentDetail : AccountDocumentDetail
    {
        public class DebenturePaymentDocumentDetailList : TTObjectCollection<DebenturePaymentDocumentDetail> { }
                    
        public class ChildDebenturePaymentDocumentDetailCollection : TTObject.TTChildObjectCollection<DebenturePaymentDocumentDetail>
        {
            public ChildDebenturePaymentDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebenturePaymentDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid ReturnBack { get { return new Guid("45b1f013-aadf-4ac2-b1f9-9ae76085f321"); } }
            public static Guid Paid { get { return new Guid("ad09b175-3aa7-4ccd-ac7c-ab4023cdc76c"); } }
            public static Guid Cancelled { get { return new Guid("c304d22b-1b6d-46d1-a226-c88c71f7efbb"); } }
        }

        protected DebenturePaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebenturePaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebenturePaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebenturePaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebenturePaymentDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREPAYMENTDOCUMENTDETAIL", dataRow) { }
        protected DebenturePaymentDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREPAYMENTDOCUMENTDETAIL", dataRow, isImported) { }
        public DebenturePaymentDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebenturePaymentDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebenturePaymentDocumentDetail() : base() { }

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