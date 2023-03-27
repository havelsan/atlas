
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExaminationQueueItem")] 

    /// <summary>
    /// Randevu Sırası Nesnesi
    /// </summary>
    public  partial class ExaminationQueueItem : TTObject
    {
        public class ExaminationQueueItemList : TTObjectCollection<ExaminationQueueItem> { }
                    
        public class ChildExaminationQueueItemCollection : TTObject.TTChildObjectCollection<ExaminationQueueItem>
        {
            public ChildExaminationQueueItemCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExaminationQueueItemCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetActiveExaminationItems_Class : TTReportNqlObject 
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

            public string PriorityReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITYREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["PRIORITYREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsEmergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["ISEMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? CallCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALLCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["CALLCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? QueueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUEUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["QUEUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? NextItemsCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEXTITEMSCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["NEXTITEMSCOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CallTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALLTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["CALLTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DivertedTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVERTEDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["DIVERTEDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Priority
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["PRIORITY"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? IsResultExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["ISRESULTEXAMINATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetActiveExaminationItems_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveExaminationItems_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveExaminationItems_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCompletedExaminationQueueItemsGroupedByDoctors_Class : TTReportNqlObject 
        {
            public DateTime? QueueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUEUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["QUEUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ExaminationQueueDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EXAMINATIONQUEUEDEFINITION"]);
                }
            }

            public Guid? CompletedBy
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["COMPLETEDBY"]);
                }
            }

            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GetCompletedExaminationQueueItemsGroupedByDoctors_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompletedExaminationQueueItemsGroupedByDoctors_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompletedExaminationQueueItemsGroupedByDoctors_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveQueueItemsCountInQueueInDate_Class : TTReportNqlObject 
        {
            public Object Queueitemscount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["QUEUEITEMSCOUNT"]);
                }
            }

            public GetActiveQueueItemsCountInQueueInDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveQueueItemsCountInQueueInDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveQueueItemsCountInQueueInDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCompletedItemsGroupedByCompletedBy_Class : TTReportNqlObject 
        {
            public Guid? CompletedBy
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["COMPLETEDBY"]);
                }
            }

            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GetCompletedItemsGroupedByCompletedBy_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompletedItemsGroupedByCompletedBy_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompletedItemsGroupedByCompletedBy_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCompletedExaminationQueueItems_Class : TTReportNqlObject 
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

            public string PriorityReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITYREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["PRIORITYREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsEmergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["ISEMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? CallCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALLCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["CALLCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? QueueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUEUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["QUEUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? NextItemsCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEXTITEMSCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["NEXTITEMSCOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CallTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALLTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["CALLTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DivertedTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVERTEDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["DIVERTEDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Priority
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["PRIORITY"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? IsResultExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["ISRESULTEXAMINATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCompletedExaminationQueueItems_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompletedExaminationQueueItems_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompletedExaminationQueueItems_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCompletedItemsGroupedByCompletedByAndDate_Class : TTReportNqlObject 
        {
            public DateTime? QueueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUEUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["QUEUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? CompletedBy
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["COMPLETEDBY"]);
                }
            }

            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GetCompletedItemsGroupedByCompletedByAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompletedItemsGroupedByCompletedByAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompletedItemsGroupedByCompletedByAndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyActiveQueByDate_Class : TTReportNqlObject 
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

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Admissiontime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? QueueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUEUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["QUEUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Priority
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["PRIORITY"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DivertedTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVERTEDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].AllPropertyDefs["DIVERTEDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ExaminationQueueDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EXAMINATIONQUEUEDEFINITION"]);
                }
            }

            public GetEmergencyActiveQueByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyActiveQueByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyActiveQueByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveQueueItemByPolID_Class : TTReportNqlObject 
        {
            public Object Toplam
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAM"]);
                }
            }

            public Guid? Doctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTOR"]);
                }
            }

            public Guid? ResSection
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESSECTION"]);
                }
            }

            public GetActiveQueueItemByPolID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveQueueItemByPolID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveQueueItemByPolID_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("5817138b-757d-40c6-8e92-6fc1aa88efb5"); } }
    /// <summary>
    /// Çağrıldı
    /// </summary>
            public static Guid Called { get { return new Guid("15aceac3-4577-4a3e-b3bf-95cfe19bf92a"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("85550f84-7380-4159-b93f-6389b3d0d236"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("42c857cf-f41c-46ae-808b-9d52f8237d01"); } }
    /// <summary>
    /// Ötelendi
    /// </summary>
            public static Guid Diverted { get { return new Guid("689ff379-2e1d-4749-b20b-620049687213"); } }
        }

        public static BindingList<ExaminationQueueItem> GetNextItemsByQueueByDate(TTObjectContext objectContext, Guid QUEUEDEF, DateTime QUEUESTARTDATE, DateTime QUEUEENDDATE, IList<Guid> DOCTORS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetNextItemsByQueueByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUEDEF", QUEUEDEF);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);
            paramList.Add("DOCTORS", DOCTORS);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem> GetCalledItems(TTObjectContext objectContext, IList<Guid> QUEUEDEF, DateTime QUEUEENDDATE, DateTime QUEUESTARTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetCalledItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUEDEF", QUEUEDEF);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem> GetDeletableItems(TTObjectContext objectContext, DateTime DUEDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetDeletableItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DUEDATE", DUEDATE);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem.GetActiveExaminationItems_Class> GetActiveExaminationItems(DateTime STARTDATE, DateTime ENDDATE, IList<string> EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetActiveExaminationItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetActiveExaminationItems_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetActiveExaminationItems_Class> GetActiveExaminationItems(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetActiveExaminationItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetActiveExaminationItems_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem> GetActiveQueueItemsByQueueByDate(TTObjectContext objectContext, IList<Guid> DOCTORS, Guid QUEUEDEF, DateTime QUEUEENDDATE, DateTime QUEUESTARTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetActiveQueueItemsByQueueByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCTORS", DOCTORS);
            paramList.Add("QUEUEDEF", QUEUEDEF);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem> GetByEpisodeAction(TTObjectContext objectContext, Guid EPISODEACTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem> GetQueueItems(TTObjectContext objectContext, Guid QUEUEDEF, DateTime QUEUESTARTDATE, DateTime QUEUEENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetQueueItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUEDEF", QUEUEDEF);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem> GetPatientQueueItems(TTObjectContext objectContext, DateTime QUEUESTARTDATE, DateTime QUEUEENDDATE, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetPatientQueueItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem> GetByAppointment(TTObjectContext objectContext, Guid APPOINTMENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetByAppointment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APPOINTMENT", APPOINTMENT);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem> GetActiveQueueItemsOfPatientByQueueByDate(TTObjectContext objectContext, IList<Guid> DOCTORS, Guid QUEUEDEF, DateTime QUEUEENDDATE, DateTime QUEUESTARTDATE, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetActiveQueueItemsOfPatientByQueueByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCTORS", DOCTORS);
            paramList.Add("QUEUEDEF", QUEUEDEF);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem> GetBySubactionProcedureFlowable(TTObjectContext objectContext, Guid SUBACTIONPROCEDUREFLOWABLE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetBySubactionProcedureFlowable"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBACTIONPROCEDUREFLOWABLE", SUBACTIONPROCEDUREFLOWABLE);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class> GetCompletedExaminationQueueItemsGroupedByDoctors(DateTime ENDDATE, DateTime STARTDATE, IList<Guid> EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetCompletedExaminationQueueItemsGroupedByDoctors"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class> GetCompletedExaminationQueueItemsGroupedByDoctors(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, IList<Guid> EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetCompletedExaminationQueueItemsGroupedByDoctors"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem> GetCompletedItemsByQueueAndDate(TTObjectContext objectContext, Guid QUEUEDEF, DateTime QUEUESTARTDATE, DateTime QUEUEENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetCompletedItemsByQueueAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUEDEF", QUEUEDEF);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueItem>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueItem.GetActiveQueueItemsCountInQueueInDate_Class> GetActiveQueueItemsCountInQueueInDate(DateTime STARTDATE, DateTime ENDDATE, string EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetActiveQueueItemsCountInQueueInDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetActiveQueueItemsCountInQueueInDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetActiveQueueItemsCountInQueueInDate_Class> GetActiveQueueItemsCountInQueueInDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetActiveQueueItemsCountInQueueInDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetActiveQueueItemsCountInQueueInDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy_Class> GetCompletedItemsGroupedByCompletedBy(DateTime STARTDATE, DateTime ENDDATE, IList<Guid> EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetCompletedItemsGroupedByCompletedBy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy_Class> GetCompletedItemsGroupedByCompletedBy(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetCompletedItemsGroupedByCompletedBy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetCompletedExaminationQueueItems_Class> GetCompletedExaminationQueueItems(DateTime STARTDATE, DateTime ENDDATE, string EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetCompletedExaminationQueueItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetCompletedExaminationQueueItems_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetCompletedExaminationQueueItems_Class> GetCompletedExaminationQueueItems(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetCompletedExaminationQueueItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetCompletedExaminationQueueItems_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedByAndDate_Class> GetCompletedItemsGroupedByCompletedByAndDate(DateTime STARTDATE, DateTime ENDDATE, IList<Guid> EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetCompletedItemsGroupedByCompletedByAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedByAndDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedByAndDate_Class> GetCompletedItemsGroupedByCompletedByAndDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> EXAMINATIONQUEUEDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetCompletedItemsGroupedByCompletedByAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EXAMINATIONQUEUEDEFINITION", EXAMINATIONQUEUEDEFINITION);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedByAndDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetEmergencyActiveQueByDate_Class> GetEmergencyActiveQueByDate(DateTime QUEUEENDDATE, DateTime QUEUESTARTDATE, IList<Guid> DOCTORS, IList<Guid> EPISODEACTIONS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetEmergencyActiveQueByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("DOCTORS", DOCTORS);
            paramList.Add("EPISODEACTIONS", EPISODEACTIONS);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetEmergencyActiveQueByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetEmergencyActiveQueByDate_Class> GetEmergencyActiveQueByDate(TTObjectContext objectContext, DateTime QUEUEENDDATE, DateTime QUEUESTARTDATE, IList<Guid> DOCTORS, IList<Guid> EPISODEACTIONS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetEmergencyActiveQueByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("DOCTORS", DOCTORS);
            paramList.Add("EPISODEACTIONS", EPISODEACTIONS);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetEmergencyActiveQueByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetActiveQueueItemByPolID_Class> GetActiveQueueItemByPolID(IList<Guid> POLICLINICLIST, DateTime QUEUESTARTDATE, DateTime QUEUEENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetActiveQueueItemByPolID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("POLICLINICLIST", POLICLINICLIST);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetActiveQueueItemByPolID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueItem.GetActiveQueueItemByPolID_Class> GetActiveQueueItemByPolID(TTObjectContext objectContext, IList<Guid> POLICLINICLIST, DateTime QUEUESTARTDATE, DateTime QUEUEENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEITEM"].QueryDefs["GetActiveQueueItemByPolID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("POLICLINICLIST", POLICLINICLIST);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);

            return TTReportNqlObject.QueryObjects<ExaminationQueueItem.GetActiveQueueItemByPolID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Öncelik Sebebi
    /// </summary>
        public string PriorityReason
        {
            get { return (string)this["PRIORITYREASON"]; }
            set { this["PRIORITYREASON"] = value; }
        }

    /// <summary>
    /// Acil Sırası
    /// </summary>
        public bool? IsEmergency
        {
            get { return (bool?)this["ISEMERGENCY"]; }
            set { this["ISEMERGENCY"] = value; }
        }

        public int? CallCount
        {
            get { return (int?)this["CALLCOUNT"]; }
            set { this["CALLCOUNT"] = value; }
        }

    /// <summary>
    /// Yaratılma Tarihi
    /// </summary>
        public DateTime? QueueDate
        {
            get { return (DateTime?)this["QUEUEDATE"]; }
            set { this["QUEUEDATE"] = value; }
        }

    /// <summary>
    /// Kalan item sayısı
    /// </summary>
        public long? NextItemsCount
        {
            get { return (long?)this["NEXTITEMSCOUNT"]; }
            set { this["NEXTITEMSCOUNT"] = value; }
        }

    /// <summary>
    /// Çağrılacağı Zaman
    /// </summary>
        public DateTime? CallTime
        {
            get { return (DateTime?)this["CALLTIME"]; }
            set { this["CALLTIME"] = value; }
        }

    /// <summary>
    /// Ötelenmiş Zaman
    /// </summary>
        public DateTime? DivertedTime
        {
            get { return (DateTime?)this["DIVERTEDTIME"]; }
            set { this["DIVERTEDTIME"] = value; }
        }

    /// <summary>
    /// Öncelik
    /// </summary>
        public long? Priority
        {
            get { return (long?)this["PRIORITY"]; }
            set { this["PRIORITY"] = value; }
        }

    /// <summary>
    /// Sonuç Sırası
    /// </summary>
        public bool? IsResultExamination
        {
            get { return (bool?)this["ISRESULTEXAMINATION"]; }
            set { this["ISRESULTEXAMINATION"] = value; }
        }

        public string OrderNo
        {
            get { return (string)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Muayene Odası
    /// </summary>
        public Resource DestinationResource
        {
            get { return (Resource)((ITTObject)this).GetParent("DESTINATIONRESOURCE"); }
            set { this["DESTINATIONRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExaminationQueueDefinition ExaminationQueueDefinition
        {
            get { return (ExaminationQueueDefinition)((ITTObject)this).GetParent("EXAMINATIONQUEUEDEFINITION"); }
            set { this["EXAMINATIONQUEUEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Appointment Appointment
        {
            get { return (Appointment)((ITTObject)this).GetParent("APPOINTMENT"); }
            set { this["APPOINTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubactionProcedureFlowable SubactionProcedureFlowable
        {
            get { return (SubactionProcedureFlowable)((ITTObject)this).GetParent("SUBACTIONPROCEDUREFLOWABLE"); }
            set { this["SUBACTIONPROCEDUREFLOWABLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser CompletedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("COMPLETEDBY"); }
            set { this["COMPLETEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExaminationQueueItem(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExaminationQueueItem(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExaminationQueueItem(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExaminationQueueItem(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExaminationQueueItem(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXAMINATIONQUEUEITEM", dataRow) { }
        protected ExaminationQueueItem(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXAMINATIONQUEUEITEM", dataRow, isImported) { }
        public ExaminationQueueItem(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExaminationQueueItem(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExaminationQueueItem() : base() { }

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