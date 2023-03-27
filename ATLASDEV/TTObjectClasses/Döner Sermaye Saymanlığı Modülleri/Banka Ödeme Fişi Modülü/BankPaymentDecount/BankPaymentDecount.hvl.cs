
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BankPaymentDecount")] 

    /// <summary>
    /// Banka Ödeme Fişi
    /// </summary>
    public  partial class BankPaymentDecount : AccountAction, IWorkListBaseAction
    {
        public class BankPaymentDecountList : TTObjectCollection<BankPaymentDecount> { }
                    
        public class ChildBankPaymentDecountCollection : TTObject.TTChildObjectCollection<BankPaymentDecount>
        {
            public ChildBankPaymentDecountCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBankPaymentDecountCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("ebd4cd39-56fe-4526-b18c-d1a5daa05517"); } }
            public static Guid New { get { return new Guid("c15d8145-94dc-498e-9401-9030fcd41a20"); } }
            public static Guid Completed { get { return new Guid("23d1a336-fac9-4f81-87a1-acb41e5407df"); } }
        }

        public BankPaymentDecountDocument BankPaymentDecountDocument
        {
            get { return (BankPaymentDecountDocument)((ITTObject)this).GetParent("BANKPAYMENTDECOUNTDOCUMENT"); }
            set { this["BANKPAYMENTDECOUNTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("12e0a899-69ec-4197-97d3-9f099329616f"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        protected BankPaymentDecount(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BankPaymentDecount(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BankPaymentDecount(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BankPaymentDecount(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BankPaymentDecount(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BANKPAYMENTDECOUNT", dataRow) { }
        protected BankPaymentDecount(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BANKPAYMENTDECOUNT", dataRow, isImported) { }
        public BankPaymentDecount(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BankPaymentDecount(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BankPaymentDecount() : base() { }

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