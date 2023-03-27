
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockActionDetailOut")] 

    /// <summary>
    /// Stok hareketlerinde çıkış detaylarını barındıran sınıftır. Stok modüllerindeki çıkış tipindeki detay sınıfları bu sınıftan türer
    /// </summary>
    public  abstract  partial class StockActionDetailOut : StockActionDetail, IStockActionDetailOut
    {
        public class StockActionDetailOutList : TTObjectCollection<StockActionDetailOut> { }
                    
        public class ChildStockActionDetailOutCollection : TTObject.TTChildObjectCollection<StockActionDetailOut>
        {
            public ChildStockActionDetailOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockActionDetailOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStoreNameForMaterialRequestReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Storeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOREID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetStoreNameForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStoreNameForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStoreNameForMaterialRequestReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReturningByStoreIDForMaterialRequestReportQuery_Class : TTReportNqlObject 
        {
            public Object Returningamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RETURNINGAMOUNT"]);
                }
            }

            public GetReturningByStoreIDForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReturningByStoreIDForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReturningByStoreIDForMaterialRequestReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReturningForMaterialRequestReportQuery_Class : TTReportNqlObject 
        {
            public Object Returningamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RETURNINGAMOUNT"]);
                }
            }

            public GetReturningForMaterialRequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReturningForMaterialRequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReturningForMaterialRequestReportQuery_Class() : base() { }
        }

        public static BindingList<StockActionDetailOut.GetStoreNameForMaterialRequestReportQuery_Class> GetStoreNameForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILOUT"].QueryDefs["GetStoreNameForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockActionDetailOut.GetStoreNameForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockActionDetailOut.GetStoreNameForMaterialRequestReportQuery_Class> GetStoreNameForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILOUT"].QueryDefs["GetStoreNameForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockActionDetailOut.GetStoreNameForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockActionDetailOut.GetReturningByStoreIDForMaterialRequestReportQuery_Class> GetReturningByStoreIDForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILOUT"].QueryDefs["GetReturningByStoreIDForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockActionDetailOut.GetReturningByStoreIDForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockActionDetailOut.GetReturningByStoreIDForMaterialRequestReportQuery_Class> GetReturningByStoreIDForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILOUT"].QueryDefs["GetReturningByStoreIDForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<StockActionDetailOut.GetReturningByStoreIDForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StockActionDetailOut.GetReturningForMaterialRequestReportQuery_Class> GetReturningForMaterialRequestReportQuery(DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILOUT"].QueryDefs["GetReturningForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockActionDetailOut.GetReturningForMaterialRequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockActionDetailOut.GetReturningForMaterialRequestReportQuery_Class> GetReturningForMaterialRequestReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string STOCKCARDID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAILOUT"].QueryDefs["GetReturningForMaterialRequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOCKCARDID", STOCKCARDID);

            return TTReportNqlObject.QueryObjects<StockActionDetailOut.GetReturningForMaterialRequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sadece Sıfır Fiyatlı Girişler
    /// </summary>
        public bool? IsZeroUnitPrice
        {
            get { return (bool?)this["ISZEROUNITPRICE"]; }
            set { this["ISZEROUNITPRICE"] = value; }
        }

    /// <summary>
    /// Kare Kod Okundu
    /// </summary>
        public bool? ReadQRCode
        {
            get { return (bool?)this["READQRCODE"]; }
            set { this["READQRCODE"] = value; }
        }

    /// <summary>
    /// KDV
    /// </summary>
        public long? VatRate
        {
            get { return (long?)this["VATRATE"]; }
            set { this["VATRATE"] = value; }
        }

    /// <summary>
    /// Künye Numarası
    /// </summary>
        public string TagNo
        {
            get { return (string)this["TAGNO"]; }
            set { this["TAGNO"] = value; }
        }

        public bool? UserSelectedOutableTrx
        {
            get { return (bool?)this["USERSELECTEDOUTABLETRX"]; }
            set { this["USERSELECTEDOUTABLETRX"] = value; }
        }

        public StockReservation StockReservation
        {
            get { return (StockReservation)((ITTObject)this).GetParent("STOCKRESERVATION"); }
            set { this["STOCKRESERVATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOuttableLotsCollection()
        {
            _OuttableLots = new OuttableLot.ChildOuttableLotCollection(this, new Guid("7255c1dc-a027-49c4-97de-12085270711d"));
            ((ITTChildObjectCollection)_OuttableLots).GetChildren();
        }

        protected OuttableLot.ChildOuttableLotCollection _OuttableLots = null;
        public OuttableLot.ChildOuttableLotCollection OuttableLots
        {
            get
            {
                if (_OuttableLots == null)
                    CreateOuttableLotsCollection();
                return _OuttableLots;
            }
        }

        override protected void CreateFixedAssetDetailsCollectionViews()
        {
            base.CreateFixedAssetDetailsCollectionViews();
            _FixedAssetOutDetails = new FixedAssetOutDetail.ChildFixedAssetOutDetailCollection(_FixedAssetDetails, "FixedAssetOutDetails");
        }

        private FixedAssetOutDetail.ChildFixedAssetOutDetailCollection _FixedAssetOutDetails = null;
        public FixedAssetOutDetail.ChildFixedAssetOutDetailCollection FixedAssetOutDetails
        {
            get
            {
                if (_FixedAssetDetails == null)
                    CreateFixedAssetDetailsCollection();
                return _FixedAssetOutDetails;
            }            
        }

        override protected void CreateQRCodeDetailsCollectionViews()
        {
            base.CreateQRCodeDetailsCollectionViews();
            _QRCodeOutDetails = new QRCodeOutDetail.ChildQRCodeOutDetailCollection(_QRCodeDetails, "QRCodeOutDetails");
        }

        private QRCodeOutDetail.ChildQRCodeOutDetailCollection _QRCodeOutDetails = null;
        public QRCodeOutDetail.ChildQRCodeOutDetailCollection QRCodeOutDetails
        {
            get
            {
                if (_QRCodeDetails == null)
                    CreateQRCodeDetailsCollection();
                return _QRCodeOutDetails;
            }            
        }

        override protected void CreatePrescriptionPaperDetailsCollectionViews()
        {
            base.CreatePrescriptionPaperDetailsCollectionViews();
            _PrescriptionPaperOutDetails = new PrescriptionPaperOutDetail.ChildPrescriptionPaperOutDetailCollection(_PrescriptionPaperDetails, "PrescriptionPaperOutDetails");
        }

        private PrescriptionPaperOutDetail.ChildPrescriptionPaperOutDetailCollection _PrescriptionPaperOutDetails = null;
        public PrescriptionPaperOutDetail.ChildPrescriptionPaperOutDetailCollection PrescriptionPaperOutDetails
        {
            get
            {
                if (_PrescriptionPaperDetails == null)
                    CreatePrescriptionPaperDetailsCollection();
                return _PrescriptionPaperOutDetails;
            }            
        }

        protected StockActionDetailOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockActionDetailOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockActionDetailOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockActionDetailOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockActionDetailOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKACTIONDETAILOUT", dataRow) { }
        protected StockActionDetailOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKACTIONDETAILOUT", dataRow, isImported) { }
        public StockActionDetailOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockActionDetailOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockActionDetailOut() : base() { }

    }
}