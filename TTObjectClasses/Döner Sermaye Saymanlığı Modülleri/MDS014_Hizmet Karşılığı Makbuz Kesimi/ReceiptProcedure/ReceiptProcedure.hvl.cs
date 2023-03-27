
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptProcedure")] 

    /// <summary>
    /// Makbuz Hizmetleri
    /// </summary>
    public  partial class ReceiptProcedure : TTObject
    {
        public class ReceiptProcedureList : TTObjectCollection<ReceiptProcedure> { }
                    
        public class ChildReceiptProcedureCollection : TTObject.TTChildObjectCollection<ReceiptProcedure>
        {
            public ChildReceiptProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// İlgili Hizmet Kaleminin Ödemesi yapılırken seçilmelidir
    /// </summary>
        public bool? Paid
        {
            get { return (bool?)this["PAID"]; }
            set { this["PAID"] = value; }
        }

    /// <summary>
    /// Toplam indirim tutarı
    /// </summary>
        public Currency? TotalDiscountPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTPRICE"]; }
            set { this["TOTALDISCOUNTPRICE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public Currency? UnitPrice
        {
            get { return (Currency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// İndirimli toplam fiyat
    /// </summary>
        public Currency? TotalDiscountedPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTEDPRICE"]; }
            set { this["TOTALDISCOUNTEDPRICE"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

    /// <summary>
    /// Gelir Türü
    /// </summary>
        public string RevenueType
        {
            get { return (string)this["REVENUETYPE"]; }
            set { this["REVENUETYPE"] = value; }
        }

    /// <summary>
    /// Kalan Tutar
    /// </summary>
        public Currency? RemainingPrice
        {
            get { return (Currency?)this["REMAININGPRICE"]; }
            set { this["REMAININGPRICE"] = value; }
        }

    /// <summary>
    /// Ödenecek Tutar
    /// </summary>
        public Currency? PaymentPrice
        {
            get { return (Currency?)this["PAYMENTPRICE"]; }
            set { this["PAYMENTPRICE"] = value; }
        }

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı ilişkisi
    /// </summary>
        public Receipt Receipt
        {
            get { return (Receipt)((ITTObject)this).GetParent("RECEIPT"); }
            set { this["RECEIPT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountTransactionCollection()
        {
            _AccountTransaction = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("829fa9c6-1c44-4d2b-9394-f392d2dd7db3"));
            ((ITTChildObjectCollection)_AccountTransaction).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransaction = null;
    /// <summary>
    /// Child collection for Muhasebe yetkilisi mutemedi alındısı hizmet bilgisine ilişki
    /// </summary>
        public AccountTransaction.ChildAccountTransactionCollection AccountTransaction
        {
            get
            {
                if (_AccountTransaction == null)
                    CreateAccountTransactionCollection();
                return _AccountTransaction;
            }
        }

        protected ReceiptProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTPROCEDURE", dataRow) { }
        protected ReceiptProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTPROCEDURE", dataRow, isImported) { }
        public ReceiptProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptProcedure() : base() { }

    }
}