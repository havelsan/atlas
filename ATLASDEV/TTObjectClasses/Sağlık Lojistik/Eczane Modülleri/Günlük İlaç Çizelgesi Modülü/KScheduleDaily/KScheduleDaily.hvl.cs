
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KScheduleDaily")] 

    /// <summary>
    /// Günübirlik K-Çizelgesi
    /// </summary>
    public  partial class KScheduleDaily : KSchedule
    {
        public class KScheduleDailyList : TTObjectCollection<KScheduleDaily> { }
                    
        public class ChildKScheduleDailyCollection : TTObject.TTChildObjectCollection<KScheduleDaily>
        {
            public ChildKScheduleDailyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKScheduleDailyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetKScheduleDailyReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Store
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Destinationstore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public string PatientID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEMATERIAL"].AllPropertyDefs["PATIENTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEMATERIAL"].AllPropertyDefs["PATIENTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetKScheduleDailyReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleDailyReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleDailyReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetKScheduleDailyDrugReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Store
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Destinationstore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetKScheduleDailyDrugReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleDailyDrugReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleDailyDrugReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("2dc13622-ea16-4999-a45b-289d6b47bad0"); } }
    /// <summary>
    /// İstek Hazırlama
    /// </summary>
            public static Guid RequestPreparation { get { return new Guid("ea15aaaa-7a1c-43b0-a0e9-6df1c7db73b5"); } }
    /// <summary>
    /// İstek Karşılandı
    /// </summary>
            public static Guid RequestFulfilled { get { return new Guid("ca4b60ca-6051-4174-9d73-c63648b16be5"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("a3937597-6638-47b0-a6dc-b2b8ee8688c7"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("2261e88b-4395-43b8-a3e5-935b61bdade4"); } }
    /// <summary>
    /// Enfeksiyon Komitesi Onay
    /// </summary>
            public static Guid InfectionApproval { get { return new Guid("fa0b4eab-f0fc-4744-ae8d-a288be0560e4"); } }
    /// <summary>
    /// MKYS
    /// </summary>
            public static Guid MKYS { get { return new Guid("cc2f6fd8-41db-4e4e-960c-8eff7cc4dffb"); } }
        }

    /// <summary>
    /// Günübirlik K-Çizelgesi Rapor Sorgusu
    /// </summary>
        public static BindingList<KScheduleDaily.GetKScheduleDailyReportQuery_Class> GetKScheduleDailyReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].QueryDefs["GetKScheduleDailyReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<KScheduleDaily.GetKScheduleDailyReportQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Günübirlik K-Çizelgesi Rapor Sorgusu
    /// </summary>
        public static BindingList<KScheduleDaily.GetKScheduleDailyReportQuery_Class> GetKScheduleDailyReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].QueryDefs["GetKScheduleDailyReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<KScheduleDaily.GetKScheduleDailyReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Günübirlik K-Çizelgesi İlaç Sorgusu
    /// </summary>
        public static BindingList<KScheduleDaily.GetKScheduleDailyDrugReportQuery_Class> GetKScheduleDailyDrugReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].QueryDefs["GetKScheduleDailyDrugReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<KScheduleDaily.GetKScheduleDailyDrugReportQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Günübirlik K-Çizelgesi İlaç Sorgusu
    /// </summary>
        public static BindingList<KScheduleDaily.GetKScheduleDailyDrugReportQuery_Class> GetKScheduleDailyDrugReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEDAILY"].QueryDefs["GetKScheduleDailyDrugReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<KScheduleDaily.GetKScheduleDailyDrugReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        protected KScheduleDaily(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KScheduleDaily(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KScheduleDaily(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KScheduleDaily(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KScheduleDaily(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KSCHEDULEDAILY", dataRow) { }
        protected KScheduleDaily(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KSCHEDULEDAILY", dataRow, isImported) { }
        public KScheduleDaily(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KScheduleDaily(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KScheduleDaily() : base() { }

    }
}