
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Temperature")] 

    public  partial class Temperature : VitalSign
    {
        public class TemperatureList : TTObjectCollection<Temperature> { }
                    
        public class ChildTemperatureCollection : TTObject.TTChildObjectCollection<Temperature>
        {
            public ChildTemperatureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTemperatureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTemperatureByEpisodeActionAndDate_Class : TTReportNqlObject 
        {
            public double? Ates
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEMPERATURE"].AllPropertyDefs["VALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetTemperatureByEpisodeActionAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTemperatureByEpisodeActionAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTemperatureByEpisodeActionAndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTemperatureByPatientId_Class : TTReportNqlObject 
        {
            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEMPERATURE"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEMPERATURE"].AllPropertyDefs["VALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetTemperatureByPatientId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTemperatureByPatientId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTemperatureByPatientId_Class() : base() { }
        }

        public static BindingList<Temperature.GetTemperatureByEpisodeActionAndDate_Class> GetTemperatureByEpisodeActionAndDate(Guid EpisodeAction, DateTime ExecutionDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEMPERATURE"].QueryDefs["GetTemperatureByEpisodeActionAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);
            paramList.Add("EXECUTIONDATE", ExecutionDate);

            return TTReportNqlObject.QueryObjects<Temperature.GetTemperatureByEpisodeActionAndDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Temperature.GetTemperatureByEpisodeActionAndDate_Class> GetTemperatureByEpisodeActionAndDate(TTObjectContext objectContext, Guid EpisodeAction, DateTime ExecutionDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEMPERATURE"].QueryDefs["GetTemperatureByEpisodeActionAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);
            paramList.Add("EXECUTIONDATE", ExecutionDate);

            return TTReportNqlObject.QueryObjects<Temperature.GetTemperatureByEpisodeActionAndDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Temperature.GetTemperatureByPatientId_Class> GetTemperatureByPatientId(Guid patientId, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEMPERATURE"].QueryDefs["GetTemperatureByPatientId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", patientId);

            return TTReportNqlObject.QueryObjects<Temperature.GetTemperatureByPatientId_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Temperature.GetTemperatureByPatientId_Class> GetTemperatureByPatientId(TTObjectContext objectContext, Guid patientId, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEMPERATURE"].QueryDefs["GetTemperatureByPatientId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", patientId);

            return TTReportNqlObject.QueryObjects<Temperature.GetTemperatureByPatientId_Class>(objectContext, queryDef, paramList, pi);
        }

        public double? Value
        {
            get { return (double?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        protected Temperature(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Temperature(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Temperature(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Temperature(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Temperature(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEMPERATURE", dataRow) { }
        protected Temperature(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEMPERATURE", dataRow, isImported) { }
        public Temperature(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Temperature(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Temperature() : base() { }

    }
}