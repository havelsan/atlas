
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BankPaymentDecountDocument")] 

    /// <summary>
    /// Banka Ödeme Fişi
    /// </summary>
    public  partial class BankPaymentDecountDocument : AccountDocument
    {
        public class BankPaymentDecountDocumentList : TTObjectCollection<BankPaymentDecountDocument> { }
                    
        public class ChildBankPaymentDecountDocumentCollection : TTObject.TTChildObjectCollection<BankPaymentDecountDocument>
        {
            public ChildBankPaymentDecountDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBankPaymentDecountDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("0e0712fb-5aa7-4c30-955c-839ffb4bc9a5"); } }
            public static Guid New { get { return new Guid("5bc68b6f-e772-44ad-9f39-8d912133cb90"); } }
            public static Guid Completed { get { return new Guid("4e5a31cb-5f38-487d-b0bf-aa9d488e1e62"); } }
        }

        public BankDecount BankDecount
        {
            get { return (BankDecount)((ITTObject)this).GetParent("BANKDECOUNT"); }
            set { this["BANKDECOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBankPaymentDecountCollection()
        {
            _BankPaymentDecount = new BankPaymentDecount.ChildBankPaymentDecountCollection(this, new Guid("affaefbe-86d4-4a34-9618-bb92099ba187"));
            ((ITTChildObjectCollection)_BankPaymentDecount).GetChildren();
        }

        protected BankPaymentDecount.ChildBankPaymentDecountCollection _BankPaymentDecount = null;
        public BankPaymentDecount.ChildBankPaymentDecountCollection BankPaymentDecount
        {
            get
            {
                if (_BankPaymentDecount == null)
                    CreateBankPaymentDecountCollection();
                return _BankPaymentDecount;
            }
        }

        protected BankPaymentDecountDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BankPaymentDecountDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BankPaymentDecountDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BankPaymentDecountDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BankPaymentDecountDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BANKPAYMENTDECOUNTDOCUMENT", dataRow) { }
        protected BankPaymentDecountDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BANKPAYMENTDECOUNTDOCUMENT", dataRow, isImported) { }
        public BankPaymentDecountDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BankPaymentDecountDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BankPaymentDecountDocument() : base() { }

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