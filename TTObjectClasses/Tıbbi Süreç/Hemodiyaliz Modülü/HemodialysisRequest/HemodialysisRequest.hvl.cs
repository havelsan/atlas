
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HemodialysisRequest")] 

    /// <summary>
    /// Diyaliz İstek  İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
    public  partial class HemodialysisRequest : EpisodeActionWithDiagnosis
    {
        public class HemodialysisRequestList : TTObjectCollection<HemodialysisRequest> { }
                    
        public class ChildHemodialysisRequestCollection : TTObject.TTChildObjectCollection<HemodialysisRequest>
        {
            public ChildHemodialysisRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHemodialysisRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHemodialysisRequestForWorkList_Class : TTReportNqlObject 
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

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Currentstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

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

            public string Admissionnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Archivenumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARCHIVENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public int? YUPASSNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YUPASSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["YUPASSNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Admissiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HemodialysisRequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEMODIALYSISREQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISREQUEST"].AllPropertyDefs["HEMODIALYSISREQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetHemodialysisRequestForWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHemodialysisRequestForWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHemodialysisRequestForWorkList_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Planlama
    /// </summary>
            public static Guid Plan { get { return new Guid("c1e42333-bec4-490d-9d26-37fc0a0ede5a"); } }
    /// <summary>
    /// İşlem
    /// </summary>
            public static Guid Procedure { get { return new Guid("38d4ae54-8375-4f22-9068-d513709aebf6"); } }
            public static Guid Request { get { return new Guid("7806db6a-ec28-483a-b090-a4adaa70d3cd"); } }
            public static Guid Cancelled { get { return new Guid("e977c630-86f6-4a6b-93cf-7cf94c634772"); } }
            public static Guid Completed { get { return new Guid("5967054e-51fe-471a-84a5-ee85a38b42ab"); } }
        }

    /// <summary>
    /// Hastanın Devam Eden Hemodiyaliz İstekleri
    /// </summary>
        public static BindingList<HemodialysisRequest> GetHemodialysisRequestByPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISREQUEST"].QueryDefs["GetHemodialysisRequestByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<HemodialysisRequest>(queryDef, paramList);
        }

        public static BindingList<HemodialysisRequest.GetHemodialysisRequestForWorkList_Class> GetHemodialysisRequestForWorkList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISREQUEST"].QueryDefs["GetHemodialysisRequestForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HemodialysisRequest.GetHemodialysisRequestForWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HemodialysisRequest.GetHemodialysisRequestForWorkList_Class> GetHemodialysisRequestForWorkList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISREQUEST"].QueryDefs["GetHemodialysisRequestForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HemodialysisRequest.GetHemodialysisRequestForWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hemodiyaliz İstek Tarihi
    /// </summary>
        public DateTime? HemodialysisRequestDate
        {
            get { return (DateTime?)this["HEMODIALYSISREQUESTDATE"]; }
            set { this["HEMODIALYSISREQUESTDATE"] = value; }
        }

        virtual protected void CreateHemodialysisOrdersCollection()
        {
            _HemodialysisOrders = new HemodialysisOrder.ChildHemodialysisOrderCollection(this, new Guid("e3e7bef4-9d89-47db-8b97-0c5e9b91ff85"));
            ((ITTChildObjectCollection)_HemodialysisOrders).GetChildren();
        }

        protected HemodialysisOrder.ChildHemodialysisOrderCollection _HemodialysisOrders = null;
    /// <summary>
    /// Child collection for Hemodiyaliz Emirleri 
    /// </summary>
        public HemodialysisOrder.ChildHemodialysisOrderCollection HemodialysisOrders
        {
            get
            {
                if (_HemodialysisOrders == null)
                    CreateHemodialysisOrdersCollection();
                return _HemodialysisOrders;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _HemodialysisOrderDetail = new HemodialysisOrderDetail.ChildHemodialysisOrderDetailCollection(_SubactionProcedures, "HemodialysisOrderDetail");
        }

        private HemodialysisOrderDetail.ChildHemodialysisOrderDetailCollection _HemodialysisOrderDetail = null;
        public HemodialysisOrderDetail.ChildHemodialysisOrderDetailCollection HemodialysisOrderDetail
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _HemodialysisOrderDetail;
            }            
        }

        protected HemodialysisRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HemodialysisRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HemodialysisRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HemodialysisRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HemodialysisRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEMODIALYSISREQUEST", dataRow) { }
        protected HemodialysisRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEMODIALYSISREQUEST", dataRow, isImported) { }
        public HemodialysisRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HemodialysisRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HemodialysisRequest() : base() { }

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