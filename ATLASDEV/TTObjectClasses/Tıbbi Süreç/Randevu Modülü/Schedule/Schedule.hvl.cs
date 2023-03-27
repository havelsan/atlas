
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Schedule")] 

    /// <summary>
    /// Randevu Planı
    /// </summary>
    public  partial class Schedule : TTObject
    {
        public class ScheduleList : TTObjectCollection<Schedule> { }
                    
        public class ChildScheduleCollection : TTObject.TTChildObjectCollection<Schedule>
        {
            public ChildScheduleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildScheduleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWorkingResourcesForAsal_Class : TTReportNqlObject 
        {
            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public DateTime? ScheduleDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SCHEDULEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].AllPropertyDefs["SCHEDULEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetWorkingResourcesForAsal_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkingResourcesForAsal_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkingResourcesForAsal_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMHRSSchedules_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? MHRSKesinCetvelID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSKESINCETVELID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].AllPropertyDefs["MHRSKESINCETVELID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string MHRSTaslakCetvelID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSTASLAKCETVELID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].AllPropertyDefs["MHRSTASLAKCETVELID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? MHRSIstisnaID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MHRSISTISNAID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].AllPropertyDefs["MHRSISTISNAID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].AllPropertyDefs["STARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].AllPropertyDefs["ENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Duration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].AllPropertyDefs["DURATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? Resource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCE"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public string ActionName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MHRSACTIONTYPEDEFINITION"].AllPropertyDefs["ACTIONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? MHRSActionTypeDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MHRSACTIONTYPEDEFINITION"]);
                }
            }

            public bool? OpenMHRS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENMHRS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MHRSACTIONTYPEDEFINITION"].AllPropertyDefs["OPENMHRS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetMHRSSchedules_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMHRSSchedules_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMHRSSchedules_Class() : base() { }
        }

        public static BindingList<Schedule> GetByInjection(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Schedule> GetWorkHourSchByDateAndResource(TTObjectContext objectContext, DateTime STARTTIME, string RESOURCE, string APPDEF)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetWorkHourSchByDateAndResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("APPDEF", APPDEF);

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList);
        }

        public static BindingList<Schedule> GetByScheduleDateAndResource(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME, string RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetByScheduleDateAndResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList);
        }

        public static BindingList<Schedule> GrtScheduleByMHRSKesinCetvelID(TTObjectContext objectContext, long MHRSKESINCETVELID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GrtScheduleByMHRSKesinCetvelID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MHRSKESINCETVELID", MHRSKESINCETVELID);

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList);
        }

    /// <summary>
    /// Çalışan Poliklinikler (Asal)
    /// </summary>
        public static BindingList<Schedule.GetWorkingResourcesForAsal_Class> GetWorkingResourcesForAsal(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetWorkingResourcesForAsal"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Schedule.GetWorkingResourcesForAsal_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Çalışan Poliklinikler (Asal)
    /// </summary>
        public static BindingList<Schedule.GetWorkingResourcesForAsal_Class> GetWorkingResourcesForAsal(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetWorkingResourcesForAsal"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Schedule.GetWorkingResourcesForAsal_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Schedule> GetSchedulaForMHRSTask(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetSchedulaForMHRSTask"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList);
        }

        public static BindingList<Schedule> GrtScheduleByMHRSTaslakID(TTObjectContext objectContext, long TASLAKCETVELID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GrtScheduleByMHRSTaslakID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TASLAKCETVELID", TASLAKCETVELID);

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList);
        }

        public static BindingList<Schedule> GetScheduleByResourceAndDate(TTObjectContext objectContext, string RESOURCE, DateTime STARTTIME, DateTime ENDTIME, string MASTERRESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetScheduleByResourceAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList);
        }

        public static BindingList<Schedule> GetScheduleByMHRSIstisnaID(TTObjectContext objectContext, long MHRSISTISNAID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetScheduleByMHRSIstisnaID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MHRSISTISNAID", MHRSISTISNAID);

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList);
        }

        public static BindingList<Schedule.GetMHRSSchedules_Class> GetMHRSSchedules(Guid MASTERRESOURCE, Guid RESOURCE, DateTime STARTTIME, DateTime ENDTIME, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetMHRSSchedules"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);

            return TTReportNqlObject.QueryObjects<Schedule.GetMHRSSchedules_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Schedule.GetMHRSSchedules_Class> GetMHRSSchedules(TTObjectContext objectContext, Guid MASTERRESOURCE, Guid RESOURCE, DateTime STARTTIME, DateTime ENDTIME, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetMHRSSchedules"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);

            return TTReportNqlObject.QueryObjects<Schedule.GetMHRSSchedules_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Schedule> GetScheduleForMHRS(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME, Guid MASTERRESOURCE, Guid RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetScheduleForMHRS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList);
        }

        public static BindingList<Schedule> GetScheduleByResourceAndDateForMHRSTask(TTObjectContext objectContext, DateTime ENDTIME, DateTime STARTTIME, string RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetScheduleByResourceAndDateForMHRSTask"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList);
        }

        public static BindingList<Schedule> GetUserSchedulesByDateTime(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME, Guid USER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SCHEDULE"].QueryDefs["GetUserSchedulesByDateTime"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);
            paramList.Add("USER", USER);

            return ((ITTQuery)objectContext).QueryObjects<Schedule>(queryDef, paramList);
        }

    /// <summary>
    /// Süre
    /// </summary>
        public int? Duration
        {
            get { return (int?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Planlama Tipi
    /// </summary>
        public ScheduleTypeEnum? ScheduleType
        {
            get { return (ScheduleTypeEnum?)(int?)this["SCHEDULETYPE"]; }
            set { this["SCHEDULETYPE"] = value; }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public string Notes
        {
            get { return (string)this["NOTES"]; }
            set { this["NOTES"] = value; }
        }

        public string RecurrenceID
        {
            get { return (string)this["RECURRENCEID"]; }
            set { this["RECURRENCEID"] = value; }
        }

    /// <summary>
    /// Randevu Sayısı
    /// </summary>
        public int? CountLimit
        {
            get { return (int?)this["COUNTLIMIT"]; }
            set { this["COUNTLIMIT"] = value; }
        }

    /// <summary>
    /// Çalışma Saatli
    /// </summary>
        public bool? IsWorkHour
        {
            get { return (bool?)this["ISWORKHOUR"]; }
            set { this["ISWORKHOUR"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndTime
        {
            get { return (DateTime?)this["ENDTIME"]; }
            set { this["ENDTIME"] = value; }
        }

    /// <summary>
    /// Plan Tarihi
    /// </summary>
        public DateTime? ScheduleDate
        {
            get { return (DateTime?)this["SCHEDULEDATE"]; }
            set { this["SCHEDULEDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Saati
    /// </summary>
        public DateTime? StartTime
        {
            get { return (DateTime?)this["STARTTIME"]; }
            set { this["STARTTIME"] = value; }
        }

    /// <summary>
    /// MHRS Talak Cetvel ID
    /// </summary>
        public string MHRSTaslakCetvelID
        {
            get { return (string)this["MHRSTASLAKCETVELID"]; }
            set { this["MHRSTASLAKCETVELID"] = value; }
        }

    /// <summary>
    /// MHRS Kesin Cetvel ID
    /// </summary>
        public long? MHRSKesinCetvelID
        {
            get { return (long?)this["MHRSKESINCETVELID"]; }
            set { this["MHRSKESINCETVELID"] = value; }
        }

    /// <summary>
    /// MHRS'ye Bildir
    /// </summary>
        public bool? SentToMHRS
        {
            get { return (bool?)this["SENTTOMHRS"]; }
            set { this["SENTTOMHRS"] = value; }
        }

        public long? MHRSIstisnaID
        {
            get { return (long?)this["MHRSISTISNAID"]; }
            set { this["MHRSISTISNAID"] = value; }
        }

    /// <summary>
    /// MHRS İstisna Durum Tipi
    /// </summary>
        public MHRSScheduleTypeEnum? MHRSScheduleType
        {
            get { return (MHRSScheduleTypeEnum?)(int?)this["MHRSSCHEDULETYPE"]; }
            set { this["MHRSSCHEDULETYPE"] = value; }
        }

    /// <summary>
    /// MHRS Kesinleştirme Hatası
    /// </summary>
        public string ErrorOfMHRSApprove
        {
            get { return (string)this["ERROROFMHRSAPPROVE"]; }
            set { this["ERROROFMHRSAPPROVE"] = value; }
        }

    /// <summary>
    /// Cetvel Tipi
    /// </summary>
        public CetvelTipiEnum? CetvelTipiValue
        {
            get { return (CetvelTipiEnum?)(int?)this["CETVELTIPIVALUE"]; }
            set { this["CETVELTIPIVALUE"] = value; }
        }

        public Schedule MasterSchedule
        {
            get { return (Schedule)((ITTObject)this).GetParent("MASTERSCHEDULE"); }
            set { this["MASTERSCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kaynak
    /// </summary>
        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AppointmentDefinition AppointmentDefinition
        {
            get { return (AppointmentDefinition)((ITTObject)this).GetParent("APPOINTMENTDEFINITION"); }
            set { this["APPOINTMENTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Resource MasterResource
        {
            get { return (Resource)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MHRSActionTypeDefinition MHRSActionTypeDefinition
        {
            get { return (MHRSActionTypeDefinition)((ITTObject)this).GetParent("MHRSACTIONTYPEDEFINITION"); }
            set { this["MHRSACTIONTYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Cihaz Bakım Entegrasyonu için kullanılacak.
    /// </summary>
        public ResEquipmentAppointment ResEquipmentAppointment
        {
            get { return (ResEquipmentAppointment)((ITTObject)this).GetParent("RESEQUIPMENTAPPOINTMENT"); }
            set { this["RESEQUIPMENTAPPOINTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateScheduleAppointmentTypesCollection()
        {
            _ScheduleAppointmentTypes = new ScheduleAppointmentType.ChildScheduleAppointmentTypeCollection(this, new Guid("0adcf9fd-a4e8-47b6-b6ef-1b7b9a86f765"));
            ((ITTChildObjectCollection)_ScheduleAppointmentTypes).GetChildren();
        }

        protected ScheduleAppointmentType.ChildScheduleAppointmentTypeCollection _ScheduleAppointmentTypes = null;
        public ScheduleAppointmentType.ChildScheduleAppointmentTypeCollection ScheduleAppointmentTypes
        {
            get
            {
                if (_ScheduleAppointmentTypes == null)
                    CreateScheduleAppointmentTypesCollection();
                return _ScheduleAppointmentTypes;
            }
        }

        virtual protected void CreateChildSchedulesCollection()
        {
            _ChildSchedules = new Schedule.ChildScheduleCollection(this, new Guid("3ff501e5-433c-4417-a30e-69154132716a"));
            ((ITTChildObjectCollection)_ChildSchedules).GetChildren();
        }

        protected Schedule.ChildScheduleCollection _ChildSchedules = null;
        public Schedule.ChildScheduleCollection ChildSchedules
        {
            get
            {
                if (_ChildSchedules == null)
                    CreateChildSchedulesCollection();
                return _ChildSchedules;
            }
        }

        virtual protected void CreateScheduleJobRulesCollection()
        {
            _ScheduleJobRules = new ScheduleJobRule.ChildScheduleJobRuleCollection(this, new Guid("cdc92e8e-f063-47ba-beba-1738da091cff"));
            ((ITTChildObjectCollection)_ScheduleJobRules).GetChildren();
        }

        protected ScheduleJobRule.ChildScheduleJobRuleCollection _ScheduleJobRules = null;
        public ScheduleJobRule.ChildScheduleJobRuleCollection ScheduleJobRules
        {
            get
            {
                if (_ScheduleJobRules == null)
                    CreateScheduleJobRulesCollection();
                return _ScheduleJobRules;
            }
        }

        protected Schedule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Schedule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Schedule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Schedule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Schedule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SCHEDULE", dataRow) { }
        protected Schedule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SCHEDULE", dataRow, isImported) { }
        public Schedule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Schedule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Schedule() : base() { }

    }
}