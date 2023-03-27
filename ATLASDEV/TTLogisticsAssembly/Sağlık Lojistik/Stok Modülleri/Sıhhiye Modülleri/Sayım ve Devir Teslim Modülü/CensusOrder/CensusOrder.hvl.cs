
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CensusOrder")] 

    /// <summary>
    /// Sayım Emri için kullanılan temel sınıftır
    /// </summary>
    public  partial class CensusOrder : StockAction
    {
        public class CensusOrderList : TTObjectCollection<CensusOrder> { }
                    
        public class ChildCensusOrderCollection : TTObject.TTChildObjectCollection<CensusOrder>
        {
            public ChildCensusOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCensusOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCensusListReportQuery_Class : TTReportNqlObject 
        {
            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? NewInheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERDETAIL"].AllPropertyDefs["NEWINHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetCensusListReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCensusListReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCensusListReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCensusOrderCensusReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCensusOrderCensusReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCensusOrderCensusReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCensusOrderCensusReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCensusOrderReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Orderdetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDERDETAILOBJECTID"]);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? OrderSequenceNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERSEQUENCENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERDETAIL"].AllPropertyDefs["ORDERSEQUENCENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? StockCardClass
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARDCLASS"]);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? NewInheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERDETAIL"].AllPropertyDefs["NEWINHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? UsedInheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERDETAIL"].AllPropertyDefs["USEDINHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetCensusOrderReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCensusOrderReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCensusOrderReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusRecordReportRQ_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Orderdetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDERDETAILOBJECTID"]);
                }
            }

            public long? OrderSequenceNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERSEQUENCENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERDETAIL"].AllPropertyDefs["ORDERSEQUENCENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheldnew
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELDNEW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERDETAIL"].AllPropertyDefs["CENSUSNEWINHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Inheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELD"]);
                }
            }

            public Currency? CensusNewInheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CENSUSNEWINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERDETAIL"].AllPropertyDefs["CENSUSNEWINHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public CensusRecordReportRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusRecordReportRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusRecordReportRQ_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("4754459d-eaf3-482a-8d3e-1cadc5b7f4bb"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("b42c368e-5fab-499f-a0f8-78a9e4da53df"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("30b6e3e3-7ef0-491b-bf23-6441c266606b"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("114288d3-6fd8-48fb-999c-30c988f4b598"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("bcc7261d-6451-4af1-bf7c-9777c4859f25"); } }
        }

        public static BindingList<CensusOrder.GetCensusListReportQuery_Class> GetCensusListReportQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].QueryDefs["GetCensusListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CensusOrder.GetCensusListReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CensusOrder.GetCensusListReportQuery_Class> GetCensusListReportQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].QueryDefs["GetCensusListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CensusOrder.GetCensusListReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CensusOrder.GetCensusOrderCensusReportQuery_Class> GetCensusOrderCensusReportQuery(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].QueryDefs["GetCensusOrderCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<CensusOrder.GetCensusOrderCensusReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CensusOrder.GetCensusOrderCensusReportQuery_Class> GetCensusOrderCensusReportQuery(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].QueryDefs["GetCensusOrderCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<CensusOrder.GetCensusOrderCensusReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CensusOrder.GetCensusOrderReportQuery_Class> GetCensusOrderReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].QueryDefs["GetCensusOrderReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CensusOrder.GetCensusOrderReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CensusOrder.GetCensusOrderReportQuery_Class> GetCensusOrderReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].QueryDefs["GetCensusOrderReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CensusOrder.GetCensusOrderReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CensusOrder.CensusRecordReportRQ_Class> CensusRecordReportRQ(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].QueryDefs["CensusRecordReportRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CensusOrder.CensusRecordReportRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CensusOrder.CensusRecordReportRQ_Class> CensusRecordReportRQ(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDER"].QueryDefs["CensusRecordReportRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CensusOrder.CensusRecordReportRQ_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sayım Emri Tipi
    /// </summary>
        public CensusOrderTypeEnum? CensusOrderType
        {
            get { return (CensusOrderTypeEnum?)(int?)this["CENSUSORDERTYPE"]; }
            set { this["CENSUSORDERTYPE"] = value; }
        }

    /// <summary>
    /// Toplam Kart Sayısı
    /// </summary>
        public long? TotalCardCount
        {
            get { return (long?)this["TOTALCARDCOUNT"]; }
            set { this["TOTALCARDCOUNT"] = value; }
        }

    /// <summary>
    /// Sayımın Yapıldığı Masa
    /// </summary>
        public ResCardDrawer CardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("CARDDRAWER"); }
            set { this["CARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCensusOrderDetailsCollection()
        {
            _CensusOrderDetails = new CensusOrderDetail.ChildCensusOrderDetailCollection(this, new Guid("9c2c4529-027b-4ad5-a6cb-c86fb87f5a3b"));
            ((ITTChildObjectCollection)_CensusOrderDetails).GetChildren();
        }

        protected CensusOrderDetail.ChildCensusOrderDetailCollection _CensusOrderDetails = null;
        public CensusOrderDetail.ChildCensusOrderDetailCollection CensusOrderDetails
        {
            get
            {
                if (_CensusOrderDetails == null)
                    CreateCensusOrderDetailsCollection();
                return _CensusOrderDetails;
            }
        }

        virtual protected void CreateCensusOrderMainClassesCollection()
        {
            _CensusOrderMainClasses = new CensusOrderMainClass.ChildCensusOrderMainClassCollection(this, new Guid("5af1335b-a235-477e-a8a7-dad9c43693f7"));
            ((ITTChildObjectCollection)_CensusOrderMainClasses).GetChildren();
        }

        protected CensusOrderMainClass.ChildCensusOrderMainClassCollection _CensusOrderMainClasses = null;
        public CensusOrderMainClass.ChildCensusOrderMainClassCollection CensusOrderMainClasses
        {
            get
            {
                if (_CensusOrderMainClasses == null)
                    CreateCensusOrderMainClassesCollection();
                return _CensusOrderMainClasses;
            }
        }

        protected CensusOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CensusOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CensusOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CensusOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CensusOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CENSUSORDER", dataRow) { }
        protected CensusOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CENSUSORDER", dataRow, isImported) { }
        public CensusOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CensusOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CensusOrder() : base() { }

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