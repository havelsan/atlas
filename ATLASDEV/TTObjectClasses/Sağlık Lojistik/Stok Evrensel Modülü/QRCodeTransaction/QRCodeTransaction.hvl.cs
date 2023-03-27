
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="QRCodeTransaction")] 

    public  partial class QRCodeTransaction : TTObject
    {
        public class QRCodeTransactionList : TTObjectCollection<QRCodeTransaction> { }
                    
        public class ChildQRCodeTransactionCollection : TTObject.TTChildObjectCollection<QRCodeTransaction>
        {
            public ChildQRCodeTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildQRCodeTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class QRCodeOutableQRCodeTransactions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExpireDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["EXPIREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LotNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["LOTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PalletNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PALLETNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["PALLETNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PackageNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["PACKAGENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BunchNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUNCHNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["BUNCHNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BoxNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["BOXNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SmallBunchNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMALLBUNCHNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["SMALLBUNCHNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public QRCodeOutableQRCodeTransactions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public QRCodeOutableQRCodeTransactions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected QRCodeOutableQRCodeTransactions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetQRCodeTransaction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExpireDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["EXPIREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LotNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["LOTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PalletNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PALLETNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["PALLETNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PackageNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["PACKAGENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BoxNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["BOXNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BunchNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUNCHNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["BUNCHNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SmallBunchNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMALLBUNCHNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].AllPropertyDefs["SMALLBUNCHNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetQRCodeTransaction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetQRCodeTransaction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetQRCodeTransaction_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Kullanılabilir
    /// </summary>
            public static Guid Usable { get { return new Guid("4abcb62a-47b9-4e47-8dd3-739664255937"); } }
    /// <summary>
    /// Ayırtılmış
    /// </summary>
            public static Guid Reserved { get { return new Guid("0a25ba34-7179-439d-8d79-f3d9538a1560"); } }
    /// <summary>
    /// Kullanılmış
    /// </summary>
            public static Guid Used { get { return new Guid("6eac968f-bf93-4f48-917b-ba9038178889"); } }
        }

        public static BindingList<QRCodeTransaction.QRCodeOutableQRCodeTransactions_Class> QRCodeOutableQRCodeTransactions(Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].QueryDefs["QRCodeOutableQRCodeTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<QRCodeTransaction.QRCodeOutableQRCodeTransactions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<QRCodeTransaction.QRCodeOutableQRCodeTransactions_Class> QRCodeOutableQRCodeTransactions(TTObjectContext objectContext, Guid STOCKID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].QueryDefs["QRCodeOutableQRCodeTransactions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKID", STOCKID);

            return TTReportNqlObject.QueryObjects<QRCodeTransaction.QRCodeOutableQRCodeTransactions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<QRCodeTransaction> GetQRCodeTransactionByQRCode(TTObjectContext objectContext, Guid STOCK, string BARCODE, string LOTNO, string ORDERNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].QueryDefs["GetQRCodeTransactionByQRCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCK", STOCK);
            paramList.Add("BARCODE", BARCODE);
            paramList.Add("LOTNO", LOTNO);
            paramList.Add("ORDERNO", ORDERNO);

            return ((ITTQuery)objectContext).QueryObjects<QRCodeTransaction>(queryDef, paramList);
        }

        public static BindingList<QRCodeTransaction.GetQRCodeTransaction_Class> GetQRCodeTransaction(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].QueryDefs["GetQRCodeTransaction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<QRCodeTransaction.GetQRCodeTransaction_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<QRCodeTransaction.GetQRCodeTransaction_Class> GetQRCodeTransaction(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QRCODETRANSACTION"].QueryDefs["GetQRCodeTransaction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<QRCodeTransaction.GetQRCodeTransaction_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Barkod
    /// </summary>
        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpireDate
        {
            get { return (DateTime?)this["EXPIREDATE"]; }
            set { this["EXPIREDATE"] = value; }
        }

    /// <summary>
    /// Sıra Nu.
    /// </summary>
        public string OrderNo
        {
            get { return (string)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Lot Nu.
    /// </summary>
        public string LotNo
        {
            get { return (string)this["LOTNO"]; }
            set { this["LOTNO"] = value; }
        }

    /// <summary>
    /// Palet Nu.
    /// </summary>
        public string PalletNo
        {
            get { return (string)this["PALLETNO"]; }
            set { this["PALLETNO"] = value; }
        }

    /// <summary>
    /// Koli Nu.
    /// </summary>
        public string PackageNo
        {
            get { return (string)this["PACKAGENO"]; }
            set { this["PACKAGENO"] = value; }
        }

    /// <summary>
    /// Bağ Nu.
    /// </summary>
        public string BunchNo
        {
            get { return (string)this["BUNCHNO"]; }
            set { this["BUNCHNO"] = value; }
        }

    /// <summary>
    /// Koli İçi Kutu
    /// </summary>
        public string BoxNo
        {
            get { return (string)this["BOXNO"]; }
            set { this["BOXNO"] = value; }
        }

    /// <summary>
    /// Küçük Bağ Nu.
    /// </summary>
        public string SmallBunchNo
        {
            get { return (string)this["SMALLBUNCHNO"]; }
            set { this["SMALLBUNCHNO"] = value; }
        }

        public StockTransaction StockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("STOCKTRANSACTION"); }
            set { this["STOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected QRCodeTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected QRCodeTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected QRCodeTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected QRCodeTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected QRCodeTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "QRCODETRANSACTION", dataRow) { }
        protected QRCodeTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "QRCODETRANSACTION", dataRow, isImported) { }
        public QRCodeTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public QRCodeTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public QRCodeTransaction() : base() { }

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