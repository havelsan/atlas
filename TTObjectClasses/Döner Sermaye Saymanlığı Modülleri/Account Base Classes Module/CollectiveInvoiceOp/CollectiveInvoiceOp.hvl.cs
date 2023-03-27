
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CollectiveInvoiceOp")] 

    /// <summary>
    /// Fatura ekranındaki toplu işlemlerin master objesi
    /// </summary>
    public  partial class CollectiveInvoiceOp : TTObject
    {
        public class CollectiveInvoiceOpList : TTObjectCollection<CollectiveInvoiceOp> { }
                    
        public class ChildCollectiveInvoiceOpCollection : TTObject.TTChildObjectCollection<CollectiveInvoiceOp>
        {
            public ChildCollectiveInvoiceOpCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCollectiveInvoiceOpCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCountOfDetail_Class : TTReportNqlObject 
        {
            public Object Succescount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SUCCESCOUNT"]);
                }
            }

            public Object Errorcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ERRORCOUNT"]);
                }
            }

            public Object Newcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NEWCOUNT"]);
                }
            }

            public GetCountOfDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountOfDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountOfDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSavedCIO_Class : TTReportNqlObject 
        {
            public String Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTIVEINVOICEOP"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreateDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COLLECTIVEINVOICEOP"].AllPropertyDefs["CREATEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetSavedCIO_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSavedCIO_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSavedCIO_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("aa2d12da-4596-472e-bf07-b09e2ce70a59"); } }
    /// <summary>
    /// Çalışıyor
    /// </summary>
            public static Guid Started { get { return new Guid("0a1f048c-5d8d-4f2b-b70f-6a919ca57c99"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Ended { get { return new Guid("be16878a-2fe7-4132-9eab-9f606849dfbd"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancel { get { return new Guid("55740982-d62a-4665-aa36-16f83a6c3686"); } }
    /// <summary>
    /// Beklemede
    /// </summary>
            public static Guid Pending { get { return new Guid("996b4d48-8eb4-4293-94c7-482f0e103a61"); } }
        }

        public static BindingList<CollectiveInvoiceOp> GetByStartDateAndStates(TTObjectContext objectContext, DateTime STARTDATE, IList<Guid> STATES, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTIVEINVOICEOP"].QueryDefs["GetByStartDateAndStates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<CollectiveInvoiceOp>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<CollectiveInvoiceOp.GetCountOfDetail_Class> GetCountOfDetail(Guid CIO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTIVEINVOICEOP"].QueryDefs["GetCountOfDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CIO", CIO);

            return TTReportNqlObject.QueryObjects<CollectiveInvoiceOp.GetCountOfDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectiveInvoiceOp.GetCountOfDetail_Class> GetCountOfDetail(TTObjectContext objectContext, Guid CIO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTIVEINVOICEOP"].QueryDefs["GetCountOfDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CIO", CIO);

            return TTReportNqlObject.QueryObjects<CollectiveInvoiceOp.GetCountOfDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CollectiveInvoiceOp.GetSavedCIO_Class> GetSavedCIO(DateTime STARTDATE, Guid USER, CollectiveInvoiceExecType EXECTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTIVEINVOICEOP"].QueryDefs["GetSavedCIO"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("USER", USER);
            paramList.Add("EXECTYPE", (int)EXECTYPE);

            return TTReportNqlObject.QueryObjects<CollectiveInvoiceOp.GetSavedCIO_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CollectiveInvoiceOp.GetSavedCIO_Class> GetSavedCIO(TTObjectContext objectContext, DateTime STARTDATE, Guid USER, CollectiveInvoiceExecType EXECTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTIVEINVOICEOP"].QueryDefs["GetSavedCIO"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("USER", USER);
            paramList.Add("EXECTYPE", (int)EXECTYPE);

            return TTReportNqlObject.QueryObjects<CollectiveInvoiceOp.GetSavedCIO_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Bitiş tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// İşlem türü
    /// </summary>
        public CollectiveInvoiceOpTypeEnum? OpType
        {
            get { return (CollectiveInvoiceOpTypeEnum?)(int?)this["OPTYPE"]; }
            set { this["OPTYPE"] = value; }
        }

    /// <summary>
    /// Başlama tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Kurum türü
    /// </summary>
        public PayerTypeEnum? PayerType
        {
            get { return (PayerTypeEnum?)(int?)this["PAYERTYPE"]; }
            set { this["PAYERTYPE"] = value; }
        }

    /// <summary>
    /// Faturalama tarihi
    /// </summary>
        public DateTime? InvoiceDate
        {
            get { return (DateTime?)this["INVOICEDATE"]; }
            set { this["INVOICEDATE"] = value; }
        }

        public string InvoiceDescription
        {
            get { return (string)this["INVOICEDESCRIPTION"]; }
            set { this["INVOICEDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Eklenecek İcmalin Numarası
    /// </summary>
        public Guid? InvoiceCollectionID
        {
            get { return (Guid?)this["INVOICECOLLECTIONID"]; }
            set { this["INVOICECOLLECTIONID"] = value; }
        }

        public string ExtraData
        {
            get { return (string)this["EXTRADATA"]; }
            set { this["EXTRADATA"] = value; }
        }

    /// <summary>
    /// Kayıt Tarihi
    /// </summary>
        public DateTime? CreateDate
        {
            get { return (DateTime?)this["CREATEDATE"]; }
            set { this["CREATEDATE"] = value; }
        }

    /// <summary>
    /// Kayıt Alanı
    /// </summary>
        public CollectiveInvoiceTaskType? TaskType
        {
            get { return (CollectiveInvoiceTaskType?)(int?)this["TASKTYPE"]; }
            set { this["TASKTYPE"] = value; }
        }

    /// <summary>
    /// Hata Mesajı
    /// </summary>
        public string ErrorCodeText
        {
            get { return (string)this["ERRORCODETEXT"]; }
            set { this["ERRORCODETEXT"] = value; }
        }

    /// <summary>
    /// Hatanın Sut Kodu
    /// </summary>
        public string ErrorSutCodeText
        {
            get { return (string)this["ERRORSUTCODETEXT"]; }
            set { this["ERRORSUTCODETEXT"] = value; }
        }

    /// <summary>
    /// Çalışma Türü
    /// </summary>
        public CollectiveInvoiceExecType? ExecType
        {
            get { return (CollectiveInvoiceExecType?)(int?)this["EXECTYPE"]; }
            set { this["EXECTYPE"] = value; }
        }

    /// <summary>
    /// Kullanıcı
    /// </summary>
        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sıradaki Toplu İşlem
    /// </summary>
        public CollectiveInvoiceOp NextCIO
        {
            get { return (CollectiveInvoiceOp)((ITTObject)this).GetParent("NEXTCIO"); }
            set { this["NEXTCIO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCollectiveInvoiceOpDetailsCollection()
        {
            _CollectiveInvoiceOpDetails = new CollectiveInvoiceOpDetail.ChildCollectiveInvoiceOpDetailCollection(this, new Guid("24ad5d39-f3c0-4171-85a5-1775d4450f1a"));
            ((ITTChildObjectCollection)_CollectiveInvoiceOpDetails).GetChildren();
        }

        protected CollectiveInvoiceOpDetail.ChildCollectiveInvoiceOpDetailCollection _CollectiveInvoiceOpDetails = null;
    /// <summary>
    /// Child collection for CollectiveInvoiceOp
    /// </summary>
        public CollectiveInvoiceOpDetail.ChildCollectiveInvoiceOpDetailCollection CollectiveInvoiceOpDetails
        {
            get
            {
                if (_CollectiveInvoiceOpDetails == null)
                    CreateCollectiveInvoiceOpDetailsCollection();
                return _CollectiveInvoiceOpDetails;
            }
        }

        virtual protected void CreateCollectiveInvoiceOpsCollection()
        {
            _CollectiveInvoiceOps = new CollectiveInvoiceOp.ChildCollectiveInvoiceOpCollection(this, new Guid("10cc6446-e483-442b-8627-8a7415f9ace3"));
            ((ITTChildObjectCollection)_CollectiveInvoiceOps).GetChildren();
        }

        protected CollectiveInvoiceOp.ChildCollectiveInvoiceOpCollection _CollectiveInvoiceOps = null;
    /// <summary>
    /// Child collection for Sıradaki Toplu İşlem
    /// </summary>
        public CollectiveInvoiceOp.ChildCollectiveInvoiceOpCollection CollectiveInvoiceOps
        {
            get
            {
                if (_CollectiveInvoiceOps == null)
                    CreateCollectiveInvoiceOpsCollection();
                return _CollectiveInvoiceOps;
            }
        }

        protected CollectiveInvoiceOp(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CollectiveInvoiceOp(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CollectiveInvoiceOp(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CollectiveInvoiceOp(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CollectiveInvoiceOp(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLLECTIVEINVOICEOP", dataRow) { }
        protected CollectiveInvoiceOp(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLLECTIVEINVOICEOP", dataRow, isImported) { }
        public CollectiveInvoiceOp(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CollectiveInvoiceOp(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CollectiveInvoiceOp() : base() { }

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