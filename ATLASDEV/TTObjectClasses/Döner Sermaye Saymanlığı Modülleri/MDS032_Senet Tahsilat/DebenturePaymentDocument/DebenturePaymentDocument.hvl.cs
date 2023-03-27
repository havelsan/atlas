
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebenturePaymentDocument")] 

    /// <summary>
    /// Senet Tahsilat Dökümanı
    /// </summary>
    public  partial class DebenturePaymentDocument : AccountDocument
    {
        public class DebenturePaymentDocumentList : TTObjectCollection<DebenturePaymentDocument> { }
                    
        public class ChildDebenturePaymentDocumentCollection : TTObject.TTChildObjectCollection<DebenturePaymentDocument>
        {
            public ChildDebenturePaymentDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebenturePaymentDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("93aa6c09-3511-4094-a3c2-27ee41e1b9ff"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f2b771b9-1299-4a69-8611-f75cf701200b"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("1d648b1a-7848-4c4a-976a-e15e71a777f3"); } }
        }

    /// <summary>
    /// Kredi Kartı Alındısı Özel Numarası
    /// </summary>
        public TTSequence CreditCardSpecialNo
        {
            get { return GetSequence("CREDITCARDSPECIALNO"); }
        }

    /// <summary>
    /// Kredi Kartı Alındısı Numarası
    /// </summary>
        public string CreditCardDocumentNo
        {
            get { return (string)this["CREDITCARDDOCUMENTNO"]; }
            set { this["CREDITCARDDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Teslim Eden Kişi
    /// </summary>
        public string PayeeName
        {
            get { return (string)this["PAYEENAME"]; }
            set { this["PAYEENAME"] = value; }
        }

    /// <summary>
    /// Özel No
    /// </summary>
        public TTSequence SpecialNo
        {
            get { return GetSequence("SPECIALNO"); }
        }

        virtual protected void CreateDebenturePaymentPatientDebenturesCollection()
        {
            _DebenturePaymentPatientDebentures = new DebenturePaymentPatientDebentures.ChildDebenturePaymentPatientDebenturesCollection(this, new Guid("781bb7b7-d795-42ee-9a4e-12617fb9cb8f"));
            ((ITTChildObjectCollection)_DebenturePaymentPatientDebentures).GetChildren();
        }

        protected DebenturePaymentPatientDebentures.ChildDebenturePaymentPatientDebenturesCollection _DebenturePaymentPatientDebentures = null;
    /// <summary>
    /// Child collection for Senet Tahsilat Dökümanıyla İlişki
    /// </summary>
        public DebenturePaymentPatientDebentures.ChildDebenturePaymentPatientDebenturesCollection DebenturePaymentPatientDebentures
        {
            get
            {
                if (_DebenturePaymentPatientDebentures == null)
                    CreateDebenturePaymentPatientDebenturesCollection();
                return _DebenturePaymentPatientDebentures;
            }
        }

        virtual protected void CreateDebenturePaymentCollection()
        {
            _DebenturePayment = new DebenturePayment.ChildDebenturePaymentCollection(this, new Guid("91f3fbd3-877b-4c1d-be06-1d83a1bb2b1f"));
            ((ITTChildObjectCollection)_DebenturePayment).GetChildren();
        }

        protected DebenturePayment.ChildDebenturePaymentCollection _DebenturePayment = null;
    /// <summary>
    /// Child collection for Senet Tahsilat Dökümanıyla İlişkisi
    /// </summary>
        public DebenturePayment.ChildDebenturePaymentCollection DebenturePayment
        {
            get
            {
                if (_DebenturePayment == null)
                    CreateDebenturePaymentCollection();
                return _DebenturePayment;
            }
        }

        protected DebenturePaymentDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebenturePaymentDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebenturePaymentDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebenturePaymentDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebenturePaymentDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREPAYMENTDOCUMENT", dataRow) { }
        protected DebenturePaymentDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREPAYMENTDOCUMENT", dataRow, isImported) { }
        public DebenturePaymentDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebenturePaymentDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebenturePaymentDocument() : base() { }

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