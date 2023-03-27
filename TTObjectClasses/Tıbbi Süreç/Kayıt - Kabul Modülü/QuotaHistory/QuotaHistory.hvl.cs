
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="QuotaHistory")] 

    /// <summary>
    /// Sivil Kontenjan Bilgileri
    /// </summary>
    public  partial class QuotaHistory : TTObject
    {
        public class QuotaHistoryList : TTObjectCollection<QuotaHistory> { }
                    
        public class ChildQuotaHistoryCollection : TTObject.TTChildObjectCollection<QuotaHistory>
        {
            public ChildQuotaHistoryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildQuotaHistoryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByStartEndDateAndPatient_Class : TTReportNqlObject 
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

            public DateTime? DateOfQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEOFQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUOTAHISTORY"].AllPropertyDefs["DATEOFQUOTA"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetByStartEndDateAndPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByStartEndDateAndPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByStartEndDateAndPatient_Class() : base() { }
        }

        public static BindingList<QuotaHistory> GetByEpisodeActionAndResSection(TTObjectContext objectContext, Guid EPISODEACTION, Guid RESSECTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUOTAHISTORY"].QueryDefs["GetByEpisodeActionAndResSection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);
            paramList.Add("RESSECTION", RESSECTION);

            return ((ITTQuery)objectContext).QueryObjects<QuotaHistory>(queryDef, paramList);
        }

        public static BindingList<QuotaHistory> GetByAdmissionAppointment(TTObjectContext objectContext, Guid ADMISSIONAPPOINTMENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUOTAHISTORY"].QueryDefs["GetByAdmissionAppointment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ADMISSIONAPPOINTMENT", ADMISSIONAPPOINTMENT);

            return ((ITTQuery)objectContext).QueryObjects<QuotaHistory>(queryDef, paramList);
        }

        public static BindingList<QuotaHistory> GetByStartEndDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid RESSECTIONOFQUOTA)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUOTAHISTORY"].QueryDefs["GetByStartEndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESSECTIONOFQUOTA", RESSECTIONOFQUOTA);

            return ((ITTQuery)objectContext).QueryObjects<QuotaHistory>(queryDef, paramList);
        }

        public static BindingList<QuotaHistory.GetByStartEndDateAndPatient_Class> GetByStartEndDateAndPatient(DateTime STARTDATE, DateTime ENDDATE, Guid RESSECTIONOFQUOTA, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUOTAHISTORY"].QueryDefs["GetByStartEndDateAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESSECTIONOFQUOTA", RESSECTIONOFQUOTA);
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<QuotaHistory.GetByStartEndDateAndPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<QuotaHistory.GetByStartEndDateAndPatient_Class> GetByStartEndDateAndPatient(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid RESSECTIONOFQUOTA, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUOTAHISTORY"].QueryDefs["GetByStartEndDateAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESSECTIONOFQUOTA", RESSECTIONOFQUOTA);
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<QuotaHistory.GetByStartEndDateAndPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<QuotaHistory> GetByPatientAndRessection(TTObjectContext objectContext, Guid PATIENT, Guid MASTERRESOURCE, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUOTAHISTORY"].QueryDefs["GetByPatientAndRessection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<QuotaHistory>(queryDef, paramList);
        }

        public static BindingList<QuotaHistory> GetByEpisodeAndResSection(TTObjectContext objectContext, Guid EPISODE, Guid RESSECTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["QUOTAHISTORY"].QueryDefs["GetByEpisodeAndResSection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("RESSECTION", RESSECTION);

            return ((ITTQuery)objectContext).QueryObjects<QuotaHistory>(queryDef, paramList);
        }

    /// <summary>
    /// Kontenjana Dahil Olma Tarihi
    /// </summary>
        public DateTime? DateOfQuota
        {
            get { return (DateTime?)this["DATEOFQUOTA"]; }
            set { this["DATEOFQUOTA"] = value; }
        }

    /// <summary>
    /// Hasta Kabul
    /// </summary>
        public PatientAdmission PatientAdmission
        {
            get { return (PatientAdmission)((ITTObject)this).GetParent("PATIENTADMISSION"); }
            set { this["PATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kaynak
    /// </summary>
        public ResSection ResSectionOfQuota
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTIONOFQUOTA"); }
            set { this["RESSECTIONOFQUOTA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kabul Randevusu
    /// </summary>
        public AdmissionAppointment AdmissionAppointment
        {
            get { return (AdmissionAppointment)((ITTObject)this).GetParent("ADMISSIONAPPOINTMENT"); }
            set { this["ADMISSIONAPPOINTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Yatan hasta sivil kontenjanı için hasta yatış işlemini tutması için eklendi.
    /// </summary>
        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected QuotaHistory(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected QuotaHistory(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected QuotaHistory(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected QuotaHistory(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected QuotaHistory(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "QUOTAHISTORY", dataRow) { }
        protected QuotaHistory(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "QUOTAHISTORY", dataRow, isImported) { }
        public QuotaHistory(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public QuotaHistory(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public QuotaHistory() : base() { }

    }
}