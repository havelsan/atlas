
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashOfficeReceiptDocumentDetail")] 

    /// <summary>
    /// Vezne Tahsilat Alındısı Detayı
    /// </summary>
    public  partial class CashOfficeReceiptDocumentDetail : AccountDocumentDetail
    {
        public class CashOfficeReceiptDocumentDetailList : TTObjectCollection<CashOfficeReceiptDocumentDetail> { }
                    
        public class ChildCashOfficeReceiptDocumentDetailCollection : TTObject.TTChildObjectCollection<CashOfficeReceiptDocumentDetail>
        {
            public ChildCashOfficeReceiptDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashOfficeReceiptDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("3dd0a7a2-da24-4b26-aef4-5bdbb5306696"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("07e61ac3-db1e-42f1-977a-e547a629c24e"); } }
        }

        protected CashOfficeReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashOfficeReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashOfficeReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashOfficeReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashOfficeReceiptDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHOFFICERECEIPTDOCUMENTDETAIL", dataRow) { }
        protected CashOfficeReceiptDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHOFFICERECEIPTDOCUMENTDETAIL", dataRow, isImported) { }
        public CashOfficeReceiptDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashOfficeReceiptDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashOfficeReceiptDocumentDetail() : base() { }

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