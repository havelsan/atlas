
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InternalProcedureRequest")] 

    /// <summary>
    /// Diğer XXXXXXlerden Tetkik İstek
    /// </summary>
    public  partial class InternalProcedureRequest : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class InternalProcedureRequestList : TTObjectCollection<InternalProcedureRequest> { }
                    
        public class ChildInternalProcedureRequestCollection : TTObject.TTChildObjectCollection<InternalProcedureRequest>
        {
            public ChildInternalProcedureRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInternalProcedureRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInternalProcedureRequestInfo_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALPROCEDUREREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALPROCEDUREREQUEST"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INTERNALPROCEDUREREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Patientbirthdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientcityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTCITYOFBIRTH"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public DateTime? Quarantineinpatientdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetInternalProcedureRequestInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInternalProcedureRequestInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInternalProcedureRequestInfo_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Tetkik İstek
    /// </summary>
            public static Guid Request { get { return new Guid("817531b3-5853-4310-9eb6-c0aade27821c"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("cbcddcf5-c3c0-430a-a4be-6e32ba088aa3"); } }
    /// <summary>
    /// İşlem
    /// </summary>
            public static Guid Procedure { get { return new Guid("f7d030c2-46b1-462e-9780-922a0bf5cc58"); } }
        }

        public static BindingList<InternalProcedureRequest> GetInternalProcedureRequestByCreatedEpisodeAction(TTObjectContext objectContext, Guid PARAMOBJID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INTERNALPROCEDUREREQUEST"].QueryDefs["GetInternalProcedureRequestByCreatedEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return ((ITTQuery)objectContext).QueryObjects<InternalProcedureRequest>(queryDef, paramList);
        }

        public static BindingList<InternalProcedureRequest.GetInternalProcedureRequestInfo_Class> GetInternalProcedureRequestInfo(string INTERNALPROCEDUREREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INTERNALPROCEDUREREQUEST"].QueryDefs["GetInternalProcedureRequestInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERNALPROCEDUREREQUEST", INTERNALPROCEDUREREQUEST);

            return TTReportNqlObject.QueryObjects<InternalProcedureRequest.GetInternalProcedureRequestInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InternalProcedureRequest.GetInternalProcedureRequestInfo_Class> GetInternalProcedureRequestInfo(TTObjectContext objectContext, string INTERNALPROCEDUREREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INTERNALPROCEDUREREQUEST"].QueryDefs["GetInternalProcedureRequestInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERNALPROCEDUREREQUEST", INTERNALPROCEDUREREQUEST);

            return TTReportNqlObject.QueryObjects<InternalProcedureRequest.GetInternalProcedureRequestInfo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public string NotesString
        {
            get { return (string)this["NOTESSTRING"]; }
            set { this["NOTESSTRING"] = value; }
        }

    /// <summary>
    /// İşlem Türü
    /// </summary>
        public ActionTypeEnum? ActionType
        {
            get { return (ActionTypeEnum?)(int?)this["ACTIONTYPE"]; }
            set { this["ACTIONTYPE"] = value; }
        }

        public string MessageID
        {
            get { return (string)this["MESSAGEID"]; }
            set { this["MESSAGEID"] = value; }
        }

    /// <summary>
    /// Kısa Anamnez Ve Klinik Bulgular
    /// </summary>
        public string PreDiagnosisString
        {
            get { return (string)this["PREDIAGNOSISSTRING"]; }
            set { this["PREDIAGNOSISSTRING"] = value; }
        }

        public ResOtherHospital OtherHospital
        {
            get { return (ResOtherHospital)((ITTObject)this).GetParent("OTHERHOSPITAL"); }
            set { this["OTHERHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeActionWithDiagnosis CreatedEpisodeAction
        {
            get { return (EpisodeActionWithDiagnosis)((ITTObject)this).GetParent("CREATEDEPISODEACTION"); }
            set { this["CREATEDEPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Doktor
    /// </summary>
        public ResUser RequestDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTDOCTOR"); }
            set { this["REQUESTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _InternalSubActionProcedures = new InternalSubActionProcedure.ChildInternalSubActionProcedureCollection(_SubactionProcedures, "InternalSubActionProcedures");
        }

        private InternalSubActionProcedure.ChildInternalSubActionProcedureCollection _InternalSubActionProcedures = null;
        public InternalSubActionProcedure.ChildInternalSubActionProcedureCollection InternalSubActionProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _InternalSubActionProcedures;
            }            
        }

        protected InternalProcedureRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InternalProcedureRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InternalProcedureRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InternalProcedureRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InternalProcedureRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTERNALPROCEDUREREQUEST", dataRow) { }
        protected InternalProcedureRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTERNALPROCEDUREREQUEST", dataRow, isImported) { }
        public InternalProcedureRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InternalProcedureRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InternalProcedureRequest() : base() { }

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