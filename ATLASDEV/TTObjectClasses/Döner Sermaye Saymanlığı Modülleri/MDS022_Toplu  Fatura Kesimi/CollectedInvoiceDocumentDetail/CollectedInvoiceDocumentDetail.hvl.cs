
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CollectedInvoiceDocumentDetail")] 

    /// <summary>
    /// Toplu Fatura Döküman Detayı
    /// </summary>
    public  partial class CollectedInvoiceDocumentDetail : AccountDocumentDetail
    {
        public class CollectedInvoiceDocumentDetailList : TTObjectCollection<CollectedInvoiceDocumentDetail> { }
                    
        public class ChildCollectedInvoiceDocumentDetailCollection : TTObject.TTChildObjectCollection<CollectedInvoiceDocumentDetail>
        {
            public ChildCollectedInvoiceDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCollectedInvoiceDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Gönderildi
    /// </summary>
            public static Guid Send { get { return new Guid("15dcbc44-0545-4483-b3c9-4cdd67532fc5"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f46f2c7d-cd3d-4f24-8eb9-8ab083fd5f91"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("29619f08-76b8-4b2a-b0bb-a8961e85ecf9"); } }
        }

        protected CollectedInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CollectedInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CollectedInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CollectedInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CollectedInvoiceDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLLECTEDINVOICEDOCUMENTDETAIL", dataRow) { }
        protected CollectedInvoiceDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLLECTEDINVOICEDOCUMENTDETAIL", dataRow, isImported) { }
        public CollectedInvoiceDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CollectedInvoiceDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CollectedInvoiceDocumentDetail() : base() { }

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