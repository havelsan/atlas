
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdmissionAppointment")] 

    /// <summary>
    /// Kafa Randevusu
    /// </summary>
    public  partial class AdmissionAppointment : BaseAction, IAdmissionAppointmentDef, IWorkListAppointment
    {
        public class AdmissionAppointmentList : TTObjectCollection<AdmissionAppointment> { }
                    
        public class ChildAdmissionAppointmentCollection : TTObject.TTChildObjectCollection<AdmissionAppointment>
        {
            public ChildAdmissionAppointmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdmissionAppointmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByPatientAndDate_Class : TTReportNqlObject 
        {
            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByPatientAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByPatientAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByPatientAndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAdmissionAppointmentNQL_Class : TTReportNqlObject 
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PatientName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["PATIENTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SelectedPatientFiltered
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SELECTEDPATIENTFILTERED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["SELECTEDPATIENTFILTERED"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientSurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["PATIENTSURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? PatientUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["PATIENTUNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string PatientPhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["PATIENTPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PhoneTypeEnum? PhoneType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["PHONETYPE"].DataType;
                    return (PhoneTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? NotRequiredQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTREQUIREDQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].AllPropertyDefs["NOTREQUIREDQUOTA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetAdmissionAppointmentNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAdmissionAppointmentNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAdmissionAppointmentNQL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni Randevu
    /// </summary>
            public static Guid New { get { return new Guid("c50af8e0-7efa-47c7-9644-9dcfdd280abe"); } }
    /// <summary>
    /// Randevu İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("7b0b1c45-e784-4ab4-afd7-2579a5368a70"); } }
    /// <summary>
    /// Randevu Verildi
    /// </summary>
            public static Guid Appointment { get { return new Guid("e767ffcc-d13f-4bd0-a039-7a510f1f8be4"); } }
    /// <summary>
    /// Randevu Onaylandı
    /// </summary>
            public static Guid Completed { get { return new Guid("d895c293-abce-49d8-90cb-ddeb0e4afe7a"); } }
        }

        public static BindingList<AdmissionAppointment> GetByWorklistDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].QueryDefs["GetByWorklistDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<AdmissionAppointment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<AdmissionAppointment.GetByPatientAndDate_Class> GetByPatientAndDate(Guid PATIENT, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].QueryDefs["GetByPatientAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AdmissionAppointment.GetByPatientAndDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AdmissionAppointment.GetByPatientAndDate_Class> GetByPatientAndDate(TTObjectContext objectContext, Guid PATIENT, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].QueryDefs["GetByPatientAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AdmissionAppointment.GetByPatientAndDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AdmissionAppointment.GetAdmissionAppointmentNQL_Class> GetAdmissionAppointmentNQL(Guid OBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].QueryDefs["GetAdmissionAppointmentNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJID", OBJID);

            return TTReportNqlObject.QueryObjects<AdmissionAppointment.GetAdmissionAppointmentNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AdmissionAppointment.GetAdmissionAppointmentNQL_Class> GetAdmissionAppointmentNQL(TTObjectContext objectContext, Guid OBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].QueryDefs["GetAdmissionAppointmentNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJID", OBJID);

            return TTReportNqlObject.QueryObjects<AdmissionAppointment.GetAdmissionAppointmentNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AdmissionAppointment> GetByFilterExpression(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].QueryDefs["GetByFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<AdmissionAppointment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<AdmissionAppointment> GetAdmissionAppByUniqueRefNo(TTObjectContext objectContext, long UNIQUEREFNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].QueryDefs["GetAdmissionAppByUniqueRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return ((ITTQuery)objectContext).QueryObjects<AdmissionAppointment>(queryDef, paramList);
        }

        public static BindingList<AdmissionAppointment> GetActiveAppointmentByPatientAndSpeciality(TTObjectContext objectContext, Guid PATIENT, Guid SPECIALITY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONAPPOINTMENT"].QueryDefs["GetActiveAppointmentByPatientAndSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("SPECIALITY", SPECIALITY);

            return ((ITTQuery)objectContext).QueryObjects<AdmissionAppointment>(queryDef, paramList);
        }

    /// <summary>
    /// Hasta Adı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
        }

    /// <summary>
    /// Seçilen hastanın no, adı ve soyadını gösterir.
    /// </summary>
        public string SelectedPatientFiltered
        {
            get { return (string)this["SELECTEDPATIENTFILTERED"]; }
            set { this["SELECTEDPATIENTFILTERED"] = value; }
        }

    /// <summary>
    /// Hasta Soyadı
    /// </summary>
        public string PatientSurname
        {
            get { return (string)this["PATIENTSURNAME"]; }
            set { this["PATIENTSURNAME"] = value; }
        }

    /// <summary>
    /// Hasta T.C. No
    /// </summary>
        public long? PatientUniqueRefNo
        {
            get { return (long?)this["PATIENTUNIQUEREFNO"]; }
            set { this["PATIENTUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// İletişim Telefonu 1
    /// </summary>
        public string PatientPhone
        {
            get { return (string)this["PATIENTPHONE"]; }
            set { this["PATIENTPHONE"] = value; }
        }

        public PhoneTypeEnum? PhoneType
        {
            get { return (PhoneTypeEnum?)(int?)this["PHONETYPE"]; }
            set { this["PHONETYPE"] = value; }
        }

        public bool? NotRequiredQuota
        {
            get { return (bool?)this["NOTREQUIREDQUOTA"]; }
            set { this["NOTREQUIREDQUOTA"] = value; }
        }

    /// <summary>
    /// Hasta
    /// </summary>
        public Patient SelectedPatient
        {
            get { return (Patient)((ITTObject)this).GetParent("SELECTEDPATIENT"); }
            set { this["SELECTEDPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Resource MasterResource
        {
            get { return (Resource)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Randevu Türü
    /// </summary>
        public AppointmentDefinition AppointmentDefinition
        {
            get { return (AppointmentDefinition)((ITTObject)this).GetParent("APPOINTMENTDEFINITION"); }
            set { this["APPOINTMENTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePatientAdmissionCollection()
        {
            _PatientAdmission = new PatientAdmission.ChildPatientAdmissionCollection(this, new Guid("203b7afb-7619-4e42-8cb8-e53c386882fc"));
            ((ITTChildObjectCollection)_PatientAdmission).GetChildren();
        }

        protected PatientAdmission.ChildPatientAdmissionCollection _PatientAdmission = null;
    /// <summary>
    /// Child collection for Hasta Kabul Randevusu
    /// </summary>
        public PatientAdmission.ChildPatientAdmissionCollection PatientAdmission
        {
            get
            {
                if (_PatientAdmission == null)
                    CreatePatientAdmissionCollection();
                return _PatientAdmission;
            }
        }

        protected AdmissionAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdmissionAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdmissionAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdmissionAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdmissionAppointment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADMISSIONAPPOINTMENT", dataRow) { }
        protected AdmissionAppointment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADMISSIONAPPOINTMENT", dataRow, isImported) { }
        public AdmissionAppointment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdmissionAppointment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdmissionAppointment() : base() { }

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