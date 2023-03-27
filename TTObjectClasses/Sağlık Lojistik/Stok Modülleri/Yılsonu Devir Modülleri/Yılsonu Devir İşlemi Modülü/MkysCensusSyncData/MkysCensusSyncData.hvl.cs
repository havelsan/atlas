
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MkysCensusSyncData")] 

    public  partial class MkysCensusSyncData : TTObject
    {
        public class MkysCensusSyncDataList : TTObjectCollection<MkysCensusSyncData> { }
                    
        public class ChildMkysCensusSyncDataCollection : TTObject.TTChildObjectCollection<MkysCensusSyncData>
        {
            public ChildMkysCensusSyncDataCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMkysCensusSyncDataCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInStockTransactionID_Class : TTReportNqlObject 
        {
            public Guid? StockTransactionGuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKTRANSACTIONGUID"]);
                }
            }

            public GetInStockTransactionID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInStockTransactionID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInStockTransactionID_Class() : base() { }
        }

        public static BindingList<MkysCensusSyncData.GetInStockTransactionID_Class> GetInStockTransactionID(Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MKYSCENSUSSYNCDATA"].QueryDefs["GetInStockTransactionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<MkysCensusSyncData.GetInStockTransactionID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MkysCensusSyncData.GetInStockTransactionID_Class> GetInStockTransactionID(TTObjectContext objectContext, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MKYSCENSUSSYNCDATA"].QueryDefs["GetInStockTransactionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<MkysCensusSyncData.GetInStockTransactionID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yeni Birim Fiyatı
    /// </summary>
        public BigCurrency? YeniBirimFiyat
        {
            get { return (BigCurrency?)this["YENIBIRIMFIYAT"]; }
            set { this["YENIBIRIMFIYAT"] = value; }
        }

    /// <summary>
    /// Eski Birim Fiyatı
    /// </summary>
        public BigCurrency? EskiBirimFiyat
        {
            get { return (BigCurrency?)this["ESKIBIRIMFIYAT"]; }
            set { this["ESKIBIRIMFIYAT"] = value; }
        }

    /// <summary>
    /// Yeni Stok Hareket ID
    /// </summary>
        public int? YeniStokHareketId
        {
            get { return (int?)this["YENISTOKHAREKETID"]; }
            set { this["YENISTOKHAREKETID"] = value; }
        }

    /// <summary>
    /// Eski Stok Hareket ID
    /// </summary>
        public int? EskiStokHareketId
        {
            get { return (int?)this["ESKISTOKHAREKETID"]; }
            set { this["ESKISTOKHAREKETID"] = value; }
        }

    /// <summary>
    /// Stok Transaction ObjectID
    /// </summary>
        public Guid? StockTransactionGuid
        {
            get { return (Guid?)this["STOCKTRANSACTIONGUID"]; }
            set { this["STOCKTRANSACTIONGUID"] = value; }
        }

    /// <summary>
    /// Stok ObjectID
    /// </summary>
        public Guid? StockGuid
        {
            get { return (Guid?)this["STOCKGUID"]; }
            set { this["STOCKGUID"] = value; }
        }

        public StockCensus StockCensus
        {
            get { return (StockCensus)((ITTObject)this).GetParent("STOCKCENSUS"); }
            set { this["STOCKCENSUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MkysCensusSyncData(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MkysCensusSyncData(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MkysCensusSyncData(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MkysCensusSyncData(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MkysCensusSyncData(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MKYSCENSUSSYNCDATA", dataRow) { }
        protected MkysCensusSyncData(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MKYSCENSUSSYNCDATA", dataRow, isImported) { }
        public MkysCensusSyncData(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MkysCensusSyncData(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MkysCensusSyncData() : base() { }

    }
}