
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptDocumentDetail")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı Döküman Detayı
    /// </summary>
    public  partial class ReceiptDocumentDetail : AccountDocumentDetail
    {
        public class ReceiptDocumentDetailList : TTObjectCollection<ReceiptDocumentDetail> { }
                    
        public class ChildReceiptDocumentDetailCollection : TTObject.TTChildObjectCollection<ReceiptDocumentDetail>
        {
            public ChildReceiptDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetReceiptDocumentDetail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Detailobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DETAILOBJID"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENTDETAIL"].AllPropertyDefs["TOTALDISCOUNTEDPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Object Ptype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PTYPE"]);
                }
            }

            public OLAP_GetReceiptDocumentDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetReceiptDocumentDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetReceiptDocumentDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialTotalPriceByCashierLog_Class : TTReportNqlObject 
        {
            public Object Totaldiscountedprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALDISCOUNTEDPRICE"]);
                }
            }

            public GetMaterialTotalPriceByCashierLog_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialTotalPriceByCashierLog_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialTotalPriceByCashierLog_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProceduresByCashierLog_Class : TTReportNqlObject 
        {
            public Guid? Procedure
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURE"]);
                }
            }

            public Object Totaldiscountedprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALDISCOUNTEDPRICE"]);
                }
            }

            public GetProceduresByCashierLog_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProceduresByCashierLog_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProceduresByCashierLog_Class() : base() { }
        }

        public static class States
        {
            public static Guid Paid { get { return new Guid("3f22d963-6b21-40b1-b18d-0d0fa5f1aab2"); } }
            public static Guid Cancelled { get { return new Guid("7b2445e1-2a6a-434e-a987-b7fa80dc8ec0"); } }
            public static Guid ReturnBack { get { return new Guid("2ba96034-b342-470d-aff1-dff342ccfa1a"); } }
        }

        public static BindingList<ReceiptDocumentDetail.OLAP_GetReceiptDocumentDetail_Class> OLAP_GetReceiptDocumentDetail(string DOCUMENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENTDETAIL"].QueryDefs["OLAP_GetReceiptDocumentDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCUMENTID", DOCUMENTID);

            return TTReportNqlObject.QueryObjects<ReceiptDocumentDetail.OLAP_GetReceiptDocumentDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocumentDetail.OLAP_GetReceiptDocumentDetail_Class> OLAP_GetReceiptDocumentDetail(TTObjectContext objectContext, string DOCUMENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENTDETAIL"].QueryDefs["OLAP_GetReceiptDocumentDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCUMENTID", DOCUMENTID);

            return TTReportNqlObject.QueryObjects<ReceiptDocumentDetail.OLAP_GetReceiptDocumentDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocumentDetail.GetMaterialTotalPriceByCashierLog_Class> GetMaterialTotalPriceByCashierLog(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENTDETAIL"].QueryDefs["GetMaterialTotalPriceByCashierLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ReceiptDocumentDetail.GetMaterialTotalPriceByCashierLog_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocumentDetail.GetMaterialTotalPriceByCashierLog_Class> GetMaterialTotalPriceByCashierLog(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENTDETAIL"].QueryDefs["GetMaterialTotalPriceByCashierLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ReceiptDocumentDetail.GetMaterialTotalPriceByCashierLog_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocumentDetail.GetProceduresByCashierLog_Class> GetProceduresByCashierLog(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENTDETAIL"].QueryDefs["GetProceduresByCashierLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ReceiptDocumentDetail.GetProceduresByCashierLog_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocumentDetail.GetProceduresByCashierLog_Class> GetProceduresByCashierLog(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENTDETAIL"].QueryDefs["GetProceduresByCashierLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ReceiptDocumentDetail.GetProceduresByCashierLog_Class>(objectContext, queryDef, paramList, pi);
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
    /// Avans İle Ödenen Tutar
    /// </summary>
        public Currency? PaymentPriceByAdvance
        {
            get { return (Currency?)this["PAYMENTPRICEBYADVANCE"]; }
            set { this["PAYMENTPRICEBYADVANCE"] = value; }
        }

    /// <summary>
    /// Katılım Payı mı
    /// </summary>
        public bool? IsParticipationShare
        {
            get { return (bool?)this["ISPARTICIPATIONSHARE"]; }
            set { this["ISPARTICIPATIONSHARE"] = value; }
        }

        virtual protected void CreateReceiptBackDocumentDetailsCollection()
        {
            _ReceiptBackDocumentDetails = new ReceiptBackDocumentDetail.ChildReceiptBackDocumentDetailCollection(this, new Guid("de1b8c6c-2016-47c5-9531-71726d575d36"));
            ((ITTChildObjectCollection)_ReceiptBackDocumentDetails).GetChildren();
        }

        protected ReceiptBackDocumentDetail.ChildReceiptBackDocumentDetailCollection _ReceiptBackDocumentDetails = null;
    /// <summary>
    /// Child collection for Muhasebe Yetkilisi Mutemedi Alındısı Döküman Detayı İlişkisi
    /// </summary>
        public ReceiptBackDocumentDetail.ChildReceiptBackDocumentDetailCollection ReceiptBackDocumentDetails
        {
            get
            {
                if (_ReceiptBackDocumentDetails == null)
                    CreateReceiptBackDocumentDetailsCollection();
                return _ReceiptBackDocumentDetails;
            }
        }

        virtual protected void CreateReceiptBackDetailCollection()
        {
            _ReceiptBackDetail = new ReceiptBackDetail.ChildReceiptBackDetailCollection(this, new Guid("307fe600-322d-4a94-a0a7-a3f7207ab292"));
            ((ITTChildObjectCollection)_ReceiptBackDetail).GetChildren();
        }

        protected ReceiptBackDetail.ChildReceiptBackDetailCollection _ReceiptBackDetail = null;
    /// <summary>
    /// Child collection for Muhasebe Yetkilisi Mutemedi Alındısı Döküman Detayı ilişkisi
    /// </summary>
        public ReceiptBackDetail.ChildReceiptBackDetailCollection ReceiptBackDetail
        {
            get
            {
                if (_ReceiptBackDetail == null)
                    CreateReceiptBackDetailCollection();
                return _ReceiptBackDetail;
            }
        }

        virtual protected void CreateAccountVoucherDetailsCollection()
        {
            _AccountVoucherDetails = new AccountVoucherDetail.ChildAccountVoucherDetailCollection(this, new Guid("5d4a17f2-7f57-4e4a-b798-513a6602c4ab"));
            ((ITTChildObjectCollection)_AccountVoucherDetails).GetChildren();
        }

        protected AccountVoucherDetail.ChildAccountVoucherDetailCollection _AccountVoucherDetails = null;
        public AccountVoucherDetail.ChildAccountVoucherDetailCollection AccountVoucherDetails
        {
            get
            {
                if (_AccountVoucherDetails == null)
                    CreateAccountVoucherDetailsCollection();
                return _AccountVoucherDetails;
            }
        }

        protected ReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTDOCUMENTDETAIL", dataRow) { }
        protected ReceiptDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTDOCUMENTDETAIL", dataRow, isImported) { }
        public ReceiptDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptDocumentDetail() : base() { }

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