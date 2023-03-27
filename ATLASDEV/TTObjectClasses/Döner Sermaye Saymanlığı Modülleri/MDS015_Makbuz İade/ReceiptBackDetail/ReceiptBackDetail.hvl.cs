
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptBackDetail")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade Detayı
    /// </summary>
    public  partial class ReceiptBackDetail : TTObject
    {
        public class ReceiptBackDetailList : TTObjectCollection<ReceiptBackDetail> { }
                    
        public class ChildReceiptBackDetailCollection : TTObject.TTChildObjectCollection<ReceiptBackDetail>
        {
            public ChildReceiptBackDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptBackDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ReceiptBackReportDetailsQuery_Class : TTReportNqlObject 
        {
            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACKDETAIL"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACKDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACKDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACKDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACKDETAIL"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalDiscountedPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTEDPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACKDETAIL"].AllPropertyDefs["TOTALDISCOUNTEDPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? PaymentPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACKDETAIL"].AllPropertyDefs["PAYMENTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public ReceiptBackReportDetailsQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ReceiptBackReportDetailsQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ReceiptBackReportDetailsQuery_Class() : base() { }
        }

        public static BindingList<ReceiptBackDetail.ReceiptBackReportDetailsQuery_Class> ReceiptBackReportDetailsQuery(string RECEIPTBACKOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACKDETAIL"].QueryDefs["ReceiptBackReportDetailsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RECEIPTBACKOBJECTID", RECEIPTBACKOBJECTID);

            return TTReportNqlObject.QueryObjects<ReceiptBackDetail.ReceiptBackReportDetailsQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReceiptBackDetail.ReceiptBackReportDetailsQuery_Class> ReceiptBackReportDetailsQuery(TTObjectContext objectContext, string RECEIPTBACKOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACKDETAIL"].QueryDefs["ReceiptBackReportDetailsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RECEIPTBACKOBJECTID", RECEIPTBACKOBJECTID);

            return TTReportNqlObject.QueryObjects<ReceiptBackDetail.ReceiptBackReportDetailsQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
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
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// İade edilecek kalemi seçmek için kullanılır
    /// </summary>
        public bool? Return
        {
            get { return (bool?)this["RETURN"]; }
            set { this["RETURN"] = value; }
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
    /// İndirimli Toplam Fiyat
    /// </summary>
        public Currency? TotalDiscountedPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTEDPRICE"]; }
            set { this["TOTALDISCOUNTEDPRICE"] = value; }
        }

    /// <summary>
    /// Muhasebe Yetkilisi Alındısı Durumu
    /// </summary>
        public string State
        {
            get { return (string)this["STATE"]; }
            set { this["STATE"] = value; }
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
    /// Ödenen Tutar
    /// </summary>
        public Currency? PaymentPrice
        {
            get { return (Currency?)this["PAYMENTPRICE"]; }
            set { this["PAYMENTPRICE"] = value; }
        }

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı Döküman Detayı ilişkisi
    /// </summary>
        public ReceiptDocumentDetail ReceiptDocumentDetail
        {
            get { return (ReceiptDocumentDetail)((ITTObject)this).GetParent("RECEIPTDOCUMENTDETAIL"); }
            set { this["RECEIPTDOCUMENTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade İşlemiyle İlişki
    /// </summary>
        public ReceiptBack ReceiptBack
        {
            get { return (ReceiptBack)((ITTObject)this).GetParent("RECEIPTBACK"); }
            set { this["RECEIPTBACK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountTransactionCollection()
        {
            _AccountTransaction = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("5f64e287-9c27-49ba-93e8-d76f9622dcc4"));
            ((ITTChildObjectCollection)_AccountTransaction).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransaction = null;
    /// <summary>
    /// Child collection for Muhasebe yetkilisi mutemedi alındısı iade işlemi ile ilişki
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

        protected ReceiptBackDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptBackDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptBackDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptBackDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptBackDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTBACKDETAIL", dataRow) { }
        protected ReceiptBackDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTBACKDETAIL", dataRow, isImported) { }
        public ReceiptBackDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptBackDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptBackDetail() : base() { }

    }
}