
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalTreatmentRequest")] 

    /// <summary>
    /// Diş Tedavi İstek
    /// </summary>
    public  partial class DentalTreatmentRequest : BaseDentalEpisodeAction, IAllocateSpeciality, ICreateSubEpisode, IAppointmentDef, IWorkListEpisodeAction
    {
        public class DentalTreatmentRequestList : TTObjectCollection<DentalTreatmentRequest> { }
                    
        public class ChildDentalTreatmentRequestCollection : TTObject.TTChildObjectCollection<DentalTreatmentRequest>
        {
            public ChildDentalTreatmentRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalTreatmentRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetCancelledDentalTreatmentResuest_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public OLAP_GetCancelledDentalTreatmentResuest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledDentalTreatmentResuest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledDentalTreatmentResuest_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetDentalTreatmentResuest_Class : TTReportNqlObject 
        {
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Doctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTOR"]);
                }
            }

            public Guid? Resource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCE"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public Object Paid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAID"]);
                }
            }

            public Object Reasonforadmission
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADMISSION"]);
                }
            }

            public Object Procedurename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                }
            }

            public Object Subspeciality
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SUBSPECIALITY"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetDentalTreatmentResuest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDentalTreatmentResuest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDentalTreatmentResuest_Class() : base() { }
        }

        public static class States
        {
            public static Guid Appointment { get { return new Guid("b016e132-dbbe-4f5f-9284-4f5b20a21498"); } }
            public static Guid Completed { get { return new Guid("2f00f16c-e84d-4258-85a3-5fbd2a1c3ebb"); } }
            public static Guid Rejected { get { return new Guid("11ea9173-bb50-446b-827c-66ef95136b47"); } }
            public static Guid Treatment { get { return new Guid("7816e24e-c8db-4866-891e-68eaf56413b1"); } }
            public static Guid RequestAcception { get { return new Guid("b2ea6a60-f9d4-4ebb-975c-61c95dcaa4d6"); } }
            public static Guid Request { get { return new Guid("fe1ba541-7c35-450b-8332-b13ed3d80713"); } }
        }

        public static BindingList<DentalTreatmentRequest.OLAP_GetCancelledDentalTreatmentResuest_Class> OLAP_GetCancelledDentalTreatmentResuest(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTREQUEST"].QueryDefs["OLAP_GetCancelledDentalTreatmentResuest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalTreatmentRequest.OLAP_GetCancelledDentalTreatmentResuest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalTreatmentRequest.OLAP_GetCancelledDentalTreatmentResuest_Class> OLAP_GetCancelledDentalTreatmentResuest(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTREQUEST"].QueryDefs["OLAP_GetCancelledDentalTreatmentResuest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalTreatmentRequest.OLAP_GetCancelledDentalTreatmentResuest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DentalTreatmentRequest.OLAP_GetDentalTreatmentResuest_Class> OLAP_GetDentalTreatmentResuest(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTREQUEST"].QueryDefs["OLAP_GetDentalTreatmentResuest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalTreatmentRequest.OLAP_GetDentalTreatmentResuest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalTreatmentRequest.OLAP_GetDentalTreatmentResuest_Class> OLAP_GetDentalTreatmentResuest(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTREQUEST"].QueryDefs["OLAP_GetDentalTreatmentResuest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalTreatmentRequest.OLAP_GetDentalTreatmentResuest_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Diş Tedavi Dosyası
    /// </summary>
        public object DentalExaminationFile
        {
            get { return (object)this["DENTALEXAMINATIONFILE"]; }
            set { this["DENTALEXAMINATIONFILE"] = value; }
        }

    /// <summary>
    /// Sol Üst
    /// </summary>
        public string LeftUpperJaw
        {
            get { return (string)this["LEFTUPPERJAW"]; }
            set { this["LEFTUPPERJAW"] = value; }
        }

    /// <summary>
    /// Sağ Alt
    /// </summary>
        public string RightLowerJaw
        {
            get { return (string)this["RIGHTLOWERJAW"]; }
            set { this["RIGHTLOWERJAW"] = value; }
        }

    /// <summary>
    /// Sağ Üst
    /// </summary>
        public string RightUpperJaw
        {
            get { return (string)this["RIGHTUPPERJAW"]; }
            set { this["RIGHTUPPERJAW"] = value; }
        }

    /// <summary>
    /// Sol Alt
    /// </summary>
        public string LeftLowerJaw
        {
            get { return (string)this["LEFTLOWERJAW"]; }
            set { this["LEFTLOWERJAW"] = value; }
        }

    /// <summary>
    /// Anomali
    /// </summary>
        public string Anomali
        {
            get { return (string)this["ANOMALI"]; }
            set { this["ANOMALI"] = value; }
        }

    /// <summary>
    /// Diş Taahhüt Numarası
    /// </summary>
        public int? DisTaahhutNo
        {
            get { return (int?)this["DISTAAHHUTNO"]; }
            set { this["DISTAAHHUTNO"] = value; }
        }

    /// <summary>
    /// Anestezi Doktor Tescil No
    /// </summary>
        public string DrAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

        virtual protected void CreateSuggestedTreatmentsCollection()
        {
            _SuggestedTreatments = new DentalTreatmentRequestSuggestedTreatment.ChildDentalTreatmentRequestSuggestedTreatmentCollection(this, new Guid("cdbaa25c-c885-4eb7-b232-d2b72bffb1df"));
            ((ITTChildObjectCollection)_SuggestedTreatments).GetChildren();
        }

        protected DentalTreatmentRequestSuggestedTreatment.ChildDentalTreatmentRequestSuggestedTreatmentCollection _SuggestedTreatments = null;
        public DentalTreatmentRequestSuggestedTreatment.ChildDentalTreatmentRequestSuggestedTreatmentCollection SuggestedTreatments
        {
            get
            {
                if (_SuggestedTreatments == null)
                    CreateSuggestedTreatmentsCollection();
                return _SuggestedTreatments;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _DentalTreatments = new DentalTreatmentProcedure.ChildDentalTreatmentProcedureCollection(_SubactionProcedures, "DentalTreatments");
        }

        private DentalTreatmentProcedure.ChildDentalTreatmentProcedureCollection _DentalTreatments = null;
        public DentalTreatmentProcedure.ChildDentalTreatmentProcedureCollection DentalTreatments
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _DentalTreatments;
            }            
        }

        protected DentalTreatmentRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalTreatmentRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalTreatmentRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalTreatmentRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalTreatmentRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALTREATMENTREQUEST", dataRow) { }
        protected DentalTreatmentRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALTREATMENTREQUEST", dataRow, isImported) { }
        public DentalTreatmentRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalTreatmentRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalTreatmentRequest() : base() { }

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