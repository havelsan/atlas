
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashOfficeReceiptDocument")] 

    /// <summary>
    /// Vezne Tahsilat Alındısı
    /// </summary>
    public  partial class CashOfficeReceiptDocument : AccountDocument
    {
        public class CashOfficeReceiptDocumentList : TTObjectCollection<CashOfficeReceiptDocument> { }
                    
        public class ChildCashOfficeReceiptDocumentCollection : TTObject.TTChildObjectCollection<CashOfficeReceiptDocument>
        {
            public ChildCashOfficeReceiptDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashOfficeReceiptDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("d2252485-1d51-4557-989e-1d2001513108"); } }
            public static Guid New { get { return new Guid("c3073ef8-5451-4b74-bcfb-b4f7ab78c845"); } }
            public static Guid Paid { get { return new Guid("9e26c766-fb72-4607-8b3d-3eac2ce48cea"); } }
        }

    /// <summary>
    /// Teslim Edenin Adresi
    /// </summary>
        public string PayeeAddress
        {
            get { return (string)this["PAYEEADDRESS"]; }
            set { this["PAYEEADDRESS"] = value; }
        }

    /// <summary>
    /// Teslim Edenin Adı
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

    /// <summary>
    /// Teslim Edenin TC Kimlik No
    /// </summary>
        public string PayeeUniqueRefNo
        {
            get { return (string)this["PAYEEUNIQUEREFNO"]; }
            set { this["PAYEEUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Telefon
    /// </summary>
        public string Phone
        {
            get { return (string)this["PHONE"]; }
            set { this["PHONE"] = value; }
        }

    /// <summary>
    /// İhale Adı
    /// </summary>
        public string TenderName
        {
            get { return (string)this["TENDERNAME"]; }
            set { this["TENDERNAME"] = value; }
        }

    /// <summary>
    /// İhale No
    /// </summary>
        public string TenderNo
        {
            get { return (string)this["TENDERNO"]; }
            set { this["TENDERNO"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Vezne Tahsilat Tipleriyle ilişkisi
    /// </summary>
        public MainCashOfficePaymentTypeDefinition MoneyReceivedType
        {
            get { return (MainCashOfficePaymentTypeDefinition)((ITTObject)this).GetParent("MONEYRECEIVEDTYPE"); }
            set { this["MONEYRECEIVEDTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BankDecount BankDecount
        {
            get { return (BankDecount)((ITTObject)this).GetParent("BANKDECOUNT"); }
            set { this["BANKDECOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMainCashOfficeOperationCollection()
        {
            _MainCashOfficeOperation = new MainCashOfficeOperation.ChildMainCashOfficeOperationCollection(this, new Guid("04b49b82-cc3b-4f23-a0b6-1e852332dad9"));
            ((ITTChildObjectCollection)_MainCashOfficeOperation).GetChildren();
        }

        protected MainCashOfficeOperation.ChildMainCashOfficeOperationCollection _MainCashOfficeOperation = null;
    /// <summary>
    /// Child collection for Vezne Tahsilat Alındısı İlişkisi
    /// </summary>
        public MainCashOfficeOperation.ChildMainCashOfficeOperationCollection MainCashOfficeOperation
        {
            get
            {
                if (_MainCashOfficeOperation == null)
                    CreateMainCashOfficeOperationCollection();
                return _MainCashOfficeOperation;
            }
        }

        protected CashOfficeReceiptDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashOfficeReceiptDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashOfficeReceiptDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashOfficeReceiptDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashOfficeReceiptDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHOFFICERECEIPTDOCUMENT", dataRow) { }
        protected CashOfficeReceiptDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHOFFICERECEIPTDOCUMENT", dataRow, isImported) { }
        public CashOfficeReceiptDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashOfficeReceiptDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashOfficeReceiptDocument() : base() { }

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