
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReadyToCollectedInvoiceDetail")] 

    public  partial class ReadyToCollectedInvoiceDetail : TTObject
    {
        public class ReadyToCollectedInvoiceDetailList : TTObjectCollection<ReadyToCollectedInvoiceDetail> { }
                    
        public class ChildReadyToCollectedInvoiceDetailCollection : TTObject.TTChildObjectCollection<ReadyToCollectedInvoiceDetail>
        {
            public ChildReadyToCollectedInvoiceDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReadyToCollectedInvoiceDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SelectReadyToCollectedInvoiceDetailRQ_Class : TTReportNqlObject 
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

            public Guid? Parentobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTOBJECTID"]);
                }
            }

            public Guid? Parentobjectdefid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTOBJECTDEFID"]);
                }
            }

            public string Cashofficename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Cashierlogobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CASHIERLOGOBJECTID"]);
                }
            }

            public CollectedInvoiceProcedureGroupEnum? ProcedureGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["READYTOCOLLECTEDINVOICE"].AllPropertyDefs["PROCEDUREGROUP"].DataType;
                    return (CollectedInvoiceProcedureGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PayerInvoicePatientStatusEnum? PayerInvoicePatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERINVOICEPATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["READYTOCOLLECTEDINVOICE"].AllPropertyDefs["PAYERINVOICEPATIENTSTATUS"].DataType;
                    return (PayerInvoicePatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public Guid? Subepisodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODEOBJECTID"]);
                }
            }

            public SelectReadyToCollectedInvoiceDetailRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SelectReadyToCollectedInvoiceDetailRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SelectReadyToCollectedInvoiceDetailRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class SelectUncompletedReadyToCollectedInvoiceDetailsRQ_Class : TTReportNqlObject 
        {
            public Object Detailcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DETAILCOUNT"]);
                }
            }

            public SelectUncompletedReadyToCollectedInvoiceDetailsRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SelectUncompletedReadyToCollectedInvoiceDetailsRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SelectUncompletedReadyToCollectedInvoiceDetailsRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFailedReadyToCollectedInvoiceDetails_Class : TTReportNqlObject 
        {
            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? HospitalProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Subepisode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SUBEPISODE"]);
                }
            }

            public string ErrorMessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERRORMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["READYTOCOLLECTEDINVOICEDETAIL"].AllPropertyDefs["ERRORMESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFailedReadyToCollectedInvoiceDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFailedReadyToCollectedInvoiceDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFailedReadyToCollectedInvoiceDetails_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("c8953254-3f69-4275-83d1-2fc8d9c7332c"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("83e67d75-868e-45cb-ae93-7e09f49d08f7"); } }
    /// <summary>
    /// Hata Alındı
    /// </summary>
            public static Guid Failed { get { return new Guid("2841344c-6b0b-4bd0-a1b5-51c21d338d04"); } }
        }

        public static BindingList<ReadyToCollectedInvoiceDetail.SelectReadyToCollectedInvoiceDetailRQ_Class> SelectReadyToCollectedInvoiceDetailRQ(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["READYTOCOLLECTEDINVOICEDETAIL"].QueryDefs["SelectReadyToCollectedInvoiceDetailRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReadyToCollectedInvoiceDetail.SelectReadyToCollectedInvoiceDetailRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReadyToCollectedInvoiceDetail.SelectReadyToCollectedInvoiceDetailRQ_Class> SelectReadyToCollectedInvoiceDetailRQ(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["READYTOCOLLECTEDINVOICEDETAIL"].QueryDefs["SelectReadyToCollectedInvoiceDetailRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReadyToCollectedInvoiceDetail.SelectReadyToCollectedInvoiceDetailRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReadyToCollectedInvoiceDetail.SelectUncompletedReadyToCollectedInvoiceDetailsRQ_Class> SelectUncompletedReadyToCollectedInvoiceDetailsRQ(Guid READYTOCOLLECTEDINVOICEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["READYTOCOLLECTEDINVOICEDETAIL"].QueryDefs["SelectUncompletedReadyToCollectedInvoiceDetailsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("READYTOCOLLECTEDINVOICEID", READYTOCOLLECTEDINVOICEID);

            return TTReportNqlObject.QueryObjects<ReadyToCollectedInvoiceDetail.SelectUncompletedReadyToCollectedInvoiceDetailsRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReadyToCollectedInvoiceDetail.SelectUncompletedReadyToCollectedInvoiceDetailsRQ_Class> SelectUncompletedReadyToCollectedInvoiceDetailsRQ(TTObjectContext objectContext, Guid READYTOCOLLECTEDINVOICEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["READYTOCOLLECTEDINVOICEDETAIL"].QueryDefs["SelectUncompletedReadyToCollectedInvoiceDetailsRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("READYTOCOLLECTEDINVOICEID", READYTOCOLLECTEDINVOICEID);

            return TTReportNqlObject.QueryObjects<ReadyToCollectedInvoiceDetail.SelectUncompletedReadyToCollectedInvoiceDetailsRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReadyToCollectedInvoiceDetail.GetFailedReadyToCollectedInvoiceDetails_Class> GetFailedReadyToCollectedInvoiceDetails(string READYTOCOLLECTEDINVOICEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["READYTOCOLLECTEDINVOICEDETAIL"].QueryDefs["GetFailedReadyToCollectedInvoiceDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("READYTOCOLLECTEDINVOICEID", READYTOCOLLECTEDINVOICEID);

            return TTReportNqlObject.QueryObjects<ReadyToCollectedInvoiceDetail.GetFailedReadyToCollectedInvoiceDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReadyToCollectedInvoiceDetail.GetFailedReadyToCollectedInvoiceDetails_Class> GetFailedReadyToCollectedInvoiceDetails(TTObjectContext objectContext, string READYTOCOLLECTEDINVOICEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["READYTOCOLLECTEDINVOICEDETAIL"].QueryDefs["GetFailedReadyToCollectedInvoiceDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("READYTOCOLLECTEDINVOICEID", READYTOCOLLECTEDINVOICEID);

            return TTReportNqlObject.QueryObjects<ReadyToCollectedInvoiceDetail.GetFailedReadyToCollectedInvoiceDetails_Class>(objectContext, queryDef, paramList, pi);
        }

        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

        public string ErrorMessage
        {
            get { return (string)this["ERRORMESSAGE"]; }
            set { this["ERRORMESSAGE"] = value; }
        }

        public ReadyToCollectedInvoice ReadyToCollectedInvoice
        {
            get { return (ReadyToCollectedInvoice)((ITTObject)this).GetParent("READYTOCOLLECTEDINVOICE"); }
            set { this["READYTOCOLLECTEDINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PayerInvoice PayerInvoice
        {
            get { return (PayerInvoice)((ITTObject)this).GetParent("PAYERINVOICE"); }
            set { this["PAYERINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ReadyToCollectedInvoiceDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReadyToCollectedInvoiceDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReadyToCollectedInvoiceDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReadyToCollectedInvoiceDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReadyToCollectedInvoiceDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "READYTOCOLLECTEDINVOICEDETAIL", dataRow) { }
        protected ReadyToCollectedInvoiceDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "READYTOCOLLECTEDINVOICEDETAIL", dataRow, isImported) { }
        public ReadyToCollectedInvoiceDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReadyToCollectedInvoiceDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReadyToCollectedInvoiceDetail() : base() { }

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