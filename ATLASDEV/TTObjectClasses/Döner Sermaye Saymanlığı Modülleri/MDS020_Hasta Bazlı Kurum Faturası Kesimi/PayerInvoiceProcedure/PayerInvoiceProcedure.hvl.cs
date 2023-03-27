
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerInvoiceProcedure")] 

    /// <summary>
    /// Kurum Faturası Hizmet Kalemleri
    /// </summary>
    public  partial class PayerInvoiceProcedure : TTObject
    {
        public class PayerInvoiceProcedureList : TTObjectCollection<PayerInvoiceProcedure> { }
                    
        public class ChildPayerInvoiceProcedureCollection : TTObject.TTChildObjectCollection<PayerInvoiceProcedure>
        {
            public ChildPayerInvoiceProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerInvoiceProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// İndirimli toplam fiyat
    /// </summary>
        public Currency? TotalDiscountedPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTEDPRICE"]; }
            set { this["TOTALDISCOUNTEDPRICE"] = value; }
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
    /// Kod
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Toplam Fiyat
    /// </summary>
        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
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
    /// Ödenecek
    /// </summary>
        public bool? Paid
        {
            get { return (bool?)this["PAID"]; }
            set { this["PAID"] = value; }
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
    /// Toplam İndirim tutarı
    /// </summary>
        public Currency? TotalDiscountPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTPRICE"]; }
            set { this["TOTALDISCOUNTPRICE"] = value; }
        }

    /// <summary>
    /// Kurum Faturası İşlemiyle İlişki
    /// </summary>
        public PayerInvoice PayerInvoice
        {
            get { return (PayerInvoice)((ITTObject)this).GetParent("PAYERINVOICE"); }
            set { this["PAYERINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountTransactionCollection()
        {
            _AccountTransaction = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("c6bfa191-55cc-4bf8-9dcd-d6a6ffa054ee"));
            ((ITTChildObjectCollection)_AccountTransaction).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransaction = null;
    /// <summary>
    /// Child collection for Kurum faturası hizmet bilgisine ilişki
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

        protected PayerInvoiceProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerInvoiceProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerInvoiceProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerInvoiceProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerInvoiceProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERINVOICEPROCEDURE", dataRow) { }
        protected PayerInvoiceProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERINVOICEPROCEDURE", dataRow, isImported) { }
        public PayerInvoiceProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerInvoiceProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerInvoiceProcedure() : base() { }

    }
}