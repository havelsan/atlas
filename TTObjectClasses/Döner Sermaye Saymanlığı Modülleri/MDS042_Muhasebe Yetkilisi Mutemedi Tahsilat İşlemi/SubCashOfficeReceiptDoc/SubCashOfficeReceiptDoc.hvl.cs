
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubCashOfficeReceiptDoc")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Tahsilat Dökümanı
    /// </summary>
    public  partial class SubCashOfficeReceiptDoc : AccountDocument
    {
        public class SubCashOfficeReceiptDocList : TTObjectCollection<SubCashOfficeReceiptDoc> { }
                    
        public class ChildSubCashOfficeReceiptDocCollection : TTObject.TTChildObjectCollection<SubCashOfficeReceiptDoc>
        {
            public ChildSubCashOfficeReceiptDocCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubCashOfficeReceiptDocCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("645997c1-3791-4000-bc13-dafc8e4c16ae"); } }
            public static Guid Paid { get { return new Guid("de13b24c-3687-42b4-aef6-e4e234866395"); } }
            public static Guid Cancelled { get { return new Guid("f3f90fde-2984-43f8-95fd-4f306d7f020d"); } }
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
    /// Alındı Özel Numarası
    /// </summary>
        public TTSequence SpecialNo
        {
            get { return GetSequence("SPECIALNO"); }
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
    /// Kredi Kartı Özel Numarası
    /// </summary>
        public TTSequence CreditCardSpecialNo
        {
            get { return GetSequence("CREDITCARDSPECIALNO"); }
        }

    /// <summary>
    /// Tahsilat türüne ilişki
    /// </summary>
        public MainCashOfficePaymentTypeDefinition MoneyReceivedType
        {
            get { return (MainCashOfficePaymentTypeDefinition)((ITTObject)this).GetParent("MONEYRECEIVEDTYPE"); }
            set { this["MONEYRECEIVEDTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSubCashOfficeOperationCollection()
        {
            _SubCashOfficeOperation = new SubCashOfficeOperation.ChildSubCashOfficeOperationCollection(this, new Guid("e4c0d2b9-1cd0-438b-97c9-bc4316e4ff99"));
            ((ITTChildObjectCollection)_SubCashOfficeOperation).GetChildren();
        }

        protected SubCashOfficeOperation.ChildSubCashOfficeOperationCollection _SubCashOfficeOperation = null;
    /// <summary>
    /// Child collection for SubCashOfficeReceiptDocument ile ilişki
    /// </summary>
        public SubCashOfficeOperation.ChildSubCashOfficeOperationCollection SubCashOfficeOperation
        {
            get
            {
                if (_SubCashOfficeOperation == null)
                    CreateSubCashOfficeOperationCollection();
                return _SubCashOfficeOperation;
            }
        }

        protected SubCashOfficeReceiptDoc(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubCashOfficeReceiptDoc(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubCashOfficeReceiptDoc(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubCashOfficeReceiptDoc(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubCashOfficeReceiptDoc(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBCASHOFFICERECEIPTDOC", dataRow) { }
        protected SubCashOfficeReceiptDoc(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBCASHOFFICERECEIPTDOC", dataRow, isImported) { }
        public SubCashOfficeReceiptDoc(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubCashOfficeReceiptDoc(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubCashOfficeReceiptDoc() : base() { }

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