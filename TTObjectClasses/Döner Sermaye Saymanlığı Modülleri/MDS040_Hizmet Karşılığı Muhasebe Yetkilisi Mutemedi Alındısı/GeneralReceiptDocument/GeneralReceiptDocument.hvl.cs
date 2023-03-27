
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralReceiptDocument")] 

    /// <summary>
    /// Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı Dökümanı
    /// </summary>
    public  partial class GeneralReceiptDocument : AccountDocument
    {
        public class GeneralReceiptDocumentList : TTObjectCollection<GeneralReceiptDocument> { }
                    
        public class ChildGeneralReceiptDocumentCollection : TTObject.TTChildObjectCollection<GeneralReceiptDocument>
        {
            public ChildGeneralReceiptDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralReceiptDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("29a3e2eb-9182-4648-9def-71ad60abd75c"); } }
            public static Guid Paid { get { return new Guid("2e27cc5b-42cc-47a7-bbca-6dc7305321d2"); } }
            public static Guid Cancelled { get { return new Guid("62f967b3-b9a2-4299-839e-97c710801dc6"); } }
        }

    /// <summary>
    /// Kredi Kartı Alındı Numarası
    /// </summary>
        public string CreditCardDocumentNo
        {
            get { return (string)this["CREDITCARDDOCUMENTNO"]; }
            set { this["CREDITCARDDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Kredi Kartı Özel Numarası
    /// </summary>
        public TTSequence CreditCardSpecialNo
        {
            get { return GetSequence("CREDITCARDSPECIALNO"); }
        }

    /// <summary>
    /// Teslim Edenin adresi
    /// </summary>
        public string PayeeAddress
        {
            get { return (string)this["PAYEEADDRESS"]; }
            set { this["PAYEEADDRESS"] = value; }
        }

    /// <summary>
    /// Teslim Edenin adı
    /// </summary>
        public string PayeeName
        {
            get { return (string)this["PAYEENAME"]; }
            set { this["PAYEENAME"] = value; }
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
    /// Alındı Özel Numarası
    /// </summary>
        public TTSequence SpecialNo
        {
            get { return GetSequence("SPECIALNO"); }
        }

        virtual protected void CreateGeneralReceiptCollection()
        {
            _GeneralReceipt = new GeneralReceipt.ChildGeneralReceiptCollection(this, new Guid("d3b6f9d4-0d84-4d90-8f5d-71fae7f43555"));
            ((ITTChildObjectCollection)_GeneralReceipt).GetChildren();
        }

        protected GeneralReceipt.ChildGeneralReceiptCollection _GeneralReceipt = null;
    /// <summary>
    /// Child collection for GeneralReceiptDocument ile ilişki
    /// </summary>
        public GeneralReceipt.ChildGeneralReceiptCollection GeneralReceipt
        {
            get
            {
                if (_GeneralReceipt == null)
                    CreateGeneralReceiptCollection();
                return _GeneralReceipt;
            }
        }

        virtual protected void CreateAccountingLinesForCashCollection()
        {
            _AccountingLinesForCash = new AccountingLinesForCash.ChildAccountingLinesForCashCollection(this, new Guid("f671360e-8e84-4996-9d94-00210ffb3ee8"));
            ((ITTChildObjectCollection)_AccountingLinesForCash).GetChildren();
        }

        protected AccountingLinesForCash.ChildAccountingLinesForCashCollection _AccountingLinesForCash = null;
    /// <summary>
    /// Child collection for Genel muhasebe yetkilisi mutemedi alındısı ile ilişki
    /// </summary>
        public AccountingLinesForCash.ChildAccountingLinesForCashCollection AccountingLinesForCash
        {
            get
            {
                if (_AccountingLinesForCash == null)
                    CreateAccountingLinesForCashCollection();
                return _AccountingLinesForCash;
            }
        }

        protected GeneralReceiptDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralReceiptDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralReceiptDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralReceiptDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralReceiptDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALRECEIPTDOCUMENT", dataRow) { }
        protected GeneralReceiptDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALRECEIPTDOCUMENT", dataRow, isImported) { }
        public GeneralReceiptDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralReceiptDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralReceiptDocument() : base() { }

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