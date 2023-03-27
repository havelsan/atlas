
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientAppointment")] 

    public  partial class InpatientAppointment : TTObject
    {
        public class InpatientAppointmentList : TTObjectCollection<InpatientAppointment> { }
                    
        public class ChildInpatientAppointmentCollection : TTObject.TTChildObjectCollection<InpatientAppointment>
        {
            public ChildInpatientAppointmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientAppointmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInpatientAppointmentForWorkList_Class : TTReportNqlObject 
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

            public string Clinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public int? InpatientDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTAPPOINTMENT"].AllPropertyDefs["INPATIENTDAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AppointmentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTAPPOINTMENT"].AllPropertyDefs["APPOINTMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Appointmentdoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Statename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATENAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public bool? IsQueue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISQUEUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTAPPOINTMENT"].AllPropertyDefs["ISQUEUE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetInpatientAppointmentForWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientAppointmentForWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientAppointmentForWorkList_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("197b703f-1d22-4892-88db-8cb77d9e1d94"); } }
            public static Guid Completed { get { return new Guid("e85d8126-9da1-4fbd-898d-407512f9a8da"); } }
            public static Guid Cancelled { get { return new Guid("6b6db50d-feed-4cb5-861f-ddf4e02a6ea8"); } }
        }

        public static BindingList<InpatientAppointment.GetInpatientAppointmentForWorkList_Class> GetInpatientAppointmentForWorkList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTAPPOINTMENT"].QueryDefs["GetInpatientAppointmentForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InpatientAppointment.GetInpatientAppointmentForWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InpatientAppointment.GetInpatientAppointmentForWorkList_Class> GetInpatientAppointmentForWorkList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTAPPOINTMENT"].QueryDefs["GetInpatientAppointmentForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InpatientAppointment.GetInpatientAppointmentForWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InpatientAppointment> GetInpatientAppByStarterInpatient(TTObjectContext objectContext, Guid StarterInPatient)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTAPPOINTMENT"].QueryDefs["GetInpatientAppByStarterInpatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTERINPATIENT", StarterInPatient);

            return ((ITTQuery)objectContext).QueryObjects<InpatientAppointment>(queryDef, paramList);
        }

        public static BindingList<InpatientAppointment> GetInpatientAppByPatientAndClinic(TTObjectContext objectContext, Guid Patient, Guid MasterResource)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTAPPOINTMENT"].QueryDefs["GetInpatientAppByPatientAndClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", Patient);
            paramList.Add("MASTERRESOURCE", MasterResource);

            return ((ITTQuery)objectContext).QueryObjects<InpatientAppointment>(queryDef, paramList);
        }

    /// <summary>
    /// Planlanan Yatış Süresi
    /// </summary>
        public int? InpatientDay
        {
            get { return (int?)this["INPATIENTDAY"]; }
            set { this["INPATIENTDAY"] = value; }
        }

    /// <summary>
    /// Öncelik için Yatış bekleyen hasta tipi(transfer vb.)
    /// </summary>
        public InpatientAcceptionTypeEnum? InpatientAcceptionType
        {
            get { return (InpatientAcceptionTypeEnum?)(int?)this["INPATIENTACCEPTIONTYPE"]; }
            set { this["INPATIENTACCEPTIONTYPE"] = value; }
        }

    /// <summary>
    /// Randevu Tarihi
    /// </summary>
        public DateTime? AppointmentDate
        {
            get { return (DateTime?)this["APPOINTMENTDATE"]; }
            set { this["APPOINTMENTDATE"] = value; }
        }

    /// <summary>
    /// Hastayı sıraya al
    /// </summary>
        public bool? IsQueue
        {
            get { return (bool?)this["ISQUEUE"]; }
            set { this["ISQUEUE"] = value; }
        }

        public DateTime? EntryDate
        {
            get { return (DateTime?)this["ENTRYDATE"]; }
            set { this["ENTRYDATE"] = value; }
        }

        public ResUser EntryUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("ENTRYUSER"); }
            set { this["ENTRYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta
    /// </summary>
        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Klinik
    /// </summary>
        public ResSection MasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Servis
    /// </summary>
        public ResWard PhysicalStateClinic
        {
            get { return (ResWard)((ITTObject)this).GetParent("PHYSICALSTATECLINIC"); }
            set { this["PHYSICALSTATECLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Oda
    /// </summary>
        public ResRoom Room
        {
            get { return (ResRoom)((ITTObject)this).GetParent("ROOM"); }
            set { this["ROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yatak
    /// </summary>
        public ResBed Bed
        {
            get { return (ResBed)((ITTObject)this).GetParent("BED"); }
            set { this["BED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Randveu başlatan episodeaction
    /// </summary>
        public InPatientTreatmentClinicApplication StarterInPatient
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("STARTERINPATIENT"); }
            set { this["STARTERINPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Randevuyu tamamlayan episodeaction
    /// </summary>
        public InPatientTreatmentClinicApplication CompletedInPatient
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("COMPLETEDINPATIENT"); }
            set { this["COMPLETEDINPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InpatientAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientAppointment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTAPPOINTMENT", dataRow) { }
        protected InpatientAppointment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTAPPOINTMENT", dataRow, isImported) { }
        public InpatientAppointment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientAppointment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientAppointment() : base() { }

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