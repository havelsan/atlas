
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalProsthesisRequest")] 

    /// <summary>
    /// Diş Protez İstek  İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
    public  partial class DentalProsthesisRequest : BaseDentalEpisodeAction, IAllocateSpeciality, IAppointmentDef, IWorkListEpisodeAction, ICreateSubEpisode
    {
        public class DentalProsthesisRequestList : TTObjectCollection<DentalProsthesisRequest> { }
                    
        public class ChildDentalProsthesisRequestCollection : TTObject.TTChildObjectCollection<DentalProsthesisRequest>
        {
            public ChildDentalProsthesisRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalProsthesisRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetCancelledDentalProsthesisRequest_Class : TTReportNqlObject 
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

            public OLAP_GetCancelledDentalProsthesisRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledDentalProsthesisRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledDentalProsthesisRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetDentalProsthesisRequest_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public OLAP_GetDentalProsthesisRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDentalProsthesisRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDentalProsthesisRequest_Class() : base() { }
        }

        public static class States
        {
            public static Guid Request { get { return new Guid("5a9291b7-0998-4533-9345-5f7b10055d2b"); } }
            public static Guid Rejected { get { return new Guid("e3451831-cc58-4202-a223-2e9f4e4e779f"); } }
            public static Guid RequestAcception { get { return new Guid("3a0e6fff-3d3e-4d3a-83d3-5a269957511c"); } }
            public static Guid Completed { get { return new Guid("56b2d66b-fa86-465b-8e58-33c9d071a17f"); } }
            public static Guid Procedure { get { return new Guid("8b77c316-6499-4435-b0a9-525e8d748b86"); } }
            public static Guid Appointment { get { return new Guid("6eb0591c-b2a6-4239-8056-d56f52b26cb7"); } }
        }

        public static BindingList<DentalProsthesisRequest.OLAP_GetCancelledDentalProsthesisRequest_Class> OLAP_GetCancelledDentalProsthesisRequest(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISREQUEST"].QueryDefs["OLAP_GetCancelledDentalProsthesisRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalProsthesisRequest.OLAP_GetCancelledDentalProsthesisRequest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalProsthesisRequest.OLAP_GetCancelledDentalProsthesisRequest_Class> OLAP_GetCancelledDentalProsthesisRequest(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISREQUEST"].QueryDefs["OLAP_GetCancelledDentalProsthesisRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalProsthesisRequest.OLAP_GetCancelledDentalProsthesisRequest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DentalProsthesisRequest.OLAP_GetDentalProsthesisRequest_Class> OLAP_GetDentalProsthesisRequest(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISREQUEST"].QueryDefs["OLAP_GetDentalProsthesisRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalProsthesisRequest.OLAP_GetDentalProsthesisRequest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalProsthesisRequest.OLAP_GetDentalProsthesisRequest_Class> OLAP_GetDentalProsthesisRequest(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISREQUEST"].QueryDefs["OLAP_GetDentalProsthesisRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DentalProsthesisRequest.OLAP_GetDentalProsthesisRequest_Class>(objectContext, queryDef, paramList, pi);
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
    /// Sol Üst
    /// </summary>
        public string LeftUpperJaw
        {
            get { return (string)this["LEFTUPPERJAW"]; }
            set { this["LEFTUPPERJAW"] = value; }
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

        virtual protected void CreateSuggestedProsthesisCollection()
        {
            _SuggestedProsthesis = new DentalProsthesisRequestSuggestedProsthesis.ChildDentalProsthesisRequestSuggestedProsthesisCollection(this, new Guid("b6bb866a-3385-4fe9-8e97-5f17f6231745"));
            ((ITTChildObjectCollection)_SuggestedProsthesis).GetChildren();
        }

        protected DentalProsthesisRequestSuggestedProsthesis.ChildDentalProsthesisRequestSuggestedProsthesisCollection _SuggestedProsthesis = null;
        public DentalProsthesisRequestSuggestedProsthesis.ChildDentalProsthesisRequestSuggestedProsthesisCollection SuggestedProsthesis
        {
            get
            {
                if (_SuggestedProsthesis == null)
                    CreateSuggestedProsthesisCollection();
                return _SuggestedProsthesis;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _DentalProsthesis = new DentalProsthesisProcedure.ChildDentalProsthesisProcedureCollection(_SubactionProcedures, "DentalProsthesis");
        }

        private DentalProsthesisProcedure.ChildDentalProsthesisProcedureCollection _DentalProsthesis = null;
        public DentalProsthesisProcedure.ChildDentalProsthesisProcedureCollection DentalProsthesis
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _DentalProsthesis;
            }            
        }

        protected DentalProsthesisRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalProsthesisRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalProsthesisRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalProsthesisRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalProsthesisRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALPROSTHESISREQUEST", dataRow) { }
        protected DentalProsthesisRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALPROSTHESISREQUEST", dataRow, isImported) { }
        public DentalProsthesisRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalProsthesisRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalProsthesisRequest() : base() { }

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