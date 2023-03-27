
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BondPaymentDocument")] 

    /// <summary>
    /// Senet Tahsilat Dökümanı
    /// </summary>
    public  partial class BondPaymentDocument : AccountDocument
    {
        public class BondPaymentDocumentList : TTObjectCollection<BondPaymentDocument> { }
                    
        public class ChildBondPaymentDocumentCollection : TTObject.TTChildObjectCollection<BondPaymentDocument>
        {
            public ChildBondPaymentDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBondPaymentDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("e99735b1-a384-4cef-90b5-dd60f9f07ea3"); } }
            public static Guid Paid { get { return new Guid("9b3e180f-5281-4ac3-b84b-6e7fff2e0f7f"); } }
            public static Guid Cancelled { get { return new Guid("51f57107-8821-43db-a776-0e1834f188ff"); } }
        }

    /// <summary>
    /// Ödeme Yapan Kişi
    /// </summary>
        public string PayeeName
        {
            get { return (string)this["PAYEENAME"]; }
            set { this["PAYEENAME"] = value; }
        }

    /// <summary>
    /// Özel Numara
    /// </summary>
        public TTSequence SpecialNo
        {
            get { return GetSequence("SPECIALNO"); }
        }

        public BankDecount BankDecount
        {
            get { return (BankDecount)((ITTObject)this).GetParent("BANKDECOUNT"); }
            set { this["BANKDECOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBondPaymentCollection()
        {
            _BondPayment = new BondPayment.ChildBondPaymentCollection(this, new Guid("d210e35b-b1d8-4a90-a905-f1fd6edd3b3e"));
            ((ITTChildObjectCollection)_BondPayment).GetChildren();
        }

        protected BondPayment.ChildBondPaymentCollection _BondPayment = null;
        public BondPayment.ChildBondPaymentCollection BondPayment
        {
            get
            {
                if (_BondPayment == null)
                    CreateBondPaymentCollection();
                return _BondPayment;
            }
        }

        protected BondPaymentDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BondPaymentDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BondPaymentDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BondPaymentDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BondPaymentDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BONDPAYMENTDOCUMENT", dataRow) { }
        protected BondPaymentDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BONDPAYMENTDOCUMENT", dataRow, isImported) { }
        public BondPaymentDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BondPaymentDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BondPaymentDocument() : base() { }

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