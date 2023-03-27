
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerAdvancePaymentDocument")] 

    /// <summary>
    /// Kurum Avans Tahsilat Dökümanı
    /// </summary>
    public  partial class PayerAdvancePaymentDocument : AccountDocument
    {
        public class PayerAdvancePaymentDocumentList : TTObjectCollection<PayerAdvancePaymentDocument> { }
                    
        public class ChildPayerAdvancePaymentDocumentCollection : TTObject.TTChildObjectCollection<PayerAdvancePaymentDocument>
        {
            public ChildPayerAdvancePaymentDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerAdvancePaymentDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("48d39d0f-4b0c-448c-9893-0def4b60beef"); } }
            public static Guid Paid { get { return new Guid("b7410d6c-4dd3-49b0-8e53-69a05763d83e"); } }
            public static Guid New { get { return new Guid("d1c49db0-4d7c-4036-a9b9-e8a0ef515c73"); } }
        }

        virtual protected void CreatePayerAdvancePaymentCollection()
        {
            _PayerAdvancePayment = new PayerAdvancePayment.ChildPayerAdvancePaymentCollection(this, new Guid("49efa42e-7990-4e51-a4aa-a4f652417ea2"));
            ((ITTChildObjectCollection)_PayerAdvancePayment).GetChildren();
        }

        protected PayerAdvancePayment.ChildPayerAdvancePaymentCollection _PayerAdvancePayment = null;
    /// <summary>
    /// Child collection for Kurum Avans Tahsilat Dökümanı ile ilişki
    /// </summary>
        public PayerAdvancePayment.ChildPayerAdvancePaymentCollection PayerAdvancePayment
        {
            get
            {
                if (_PayerAdvancePayment == null)
                    CreatePayerAdvancePaymentCollection();
                return _PayerAdvancePayment;
            }
        }

        protected PayerAdvancePaymentDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerAdvancePaymentDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerAdvancePaymentDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerAdvancePaymentDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerAdvancePaymentDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERADVANCEPAYMENTDOCUMENT", dataRow) { }
        protected PayerAdvancePaymentDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERADVANCEPAYMENTDOCUMENT", dataRow, isImported) { }
        public PayerAdvancePaymentDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerAdvancePaymentDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerAdvancePaymentDocument() : base() { }

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