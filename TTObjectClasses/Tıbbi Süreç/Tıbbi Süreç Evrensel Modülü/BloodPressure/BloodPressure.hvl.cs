
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodPressure")] 

    public  partial class BloodPressure : VitalSign
    {
        public class BloodPressureList : TTObjectCollection<BloodPressure> { }
                    
        public class ChildBloodPressureCollection : TTObject.TTChildObjectCollection<BloodPressure>
        {
            public ChildBloodPressureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodPressureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBloodPressureByEpisodeActionAndDate_Class : TTReportNqlObject 
        {
            public int? Diastolik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIASTOLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODPRESSURE"].AllPropertyDefs["DIASTOLIK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Sistolik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTOLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODPRESSURE"].AllPropertyDefs["SISTOLIK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetBloodPressureByEpisodeActionAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBloodPressureByEpisodeActionAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBloodPressureByEpisodeActionAndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBloodPressureByPatientId_Class : TTReportNqlObject 
        {
            public int? Sistolik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTOLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODPRESSURE"].AllPropertyDefs["SISTOLIK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Diastolik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIASTOLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODPRESSURE"].AllPropertyDefs["DIASTOLIK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExecutionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXECUTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODPRESSURE"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetBloodPressureByPatientId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBloodPressureByPatientId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBloodPressureByPatientId_Class() : base() { }
        }

        public static BindingList<BloodPressure.GetBloodPressureByEpisodeActionAndDate_Class> GetBloodPressureByEpisodeActionAndDate(Guid EpisodeAction, DateTime ExecutionDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODPRESSURE"].QueryDefs["GetBloodPressureByEpisodeActionAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);
            paramList.Add("EXECUTIONDATE", ExecutionDate);

            return TTReportNqlObject.QueryObjects<BloodPressure.GetBloodPressureByEpisodeActionAndDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BloodPressure.GetBloodPressureByEpisodeActionAndDate_Class> GetBloodPressureByEpisodeActionAndDate(TTObjectContext objectContext, Guid EpisodeAction, DateTime ExecutionDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODPRESSURE"].QueryDefs["GetBloodPressureByEpisodeActionAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);
            paramList.Add("EXECUTIONDATE", ExecutionDate);

            return TTReportNqlObject.QueryObjects<BloodPressure.GetBloodPressureByEpisodeActionAndDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BloodPressure.GetBloodPressureByPatientId_Class> GetBloodPressureByPatientId(Guid patientId, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODPRESSURE"].QueryDefs["GetBloodPressureByPatientId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", patientId);

            return TTReportNqlObject.QueryObjects<BloodPressure.GetBloodPressureByPatientId_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BloodPressure.GetBloodPressureByPatientId_Class> GetBloodPressureByPatientId(TTObjectContext objectContext, Guid patientId, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODPRESSURE"].QueryDefs["GetBloodPressureByPatientId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", patientId);

            return TTReportNqlObject.QueryObjects<BloodPressure.GetBloodPressureByPatientId_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Küçük Tansiyon
    /// </summary>
        public int? Sistolik
        {
            get { return (int?)this["SISTOLIK"]; }
            set { this["SISTOLIK"] = value; }
        }

    /// <summary>
    /// Büyük tansiyon
    /// </summary>
        public int? Diastolik
        {
            get { return (int?)this["DIASTOLIK"]; }
            set { this["DIASTOLIK"] = value; }
        }

        protected BloodPressure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodPressure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodPressure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodPressure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodPressure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODPRESSURE", dataRow) { }
        protected BloodPressure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODPRESSURE", dataRow, isImported) { }
        public BloodPressure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodPressure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodPressure() : base() { }

    }
}