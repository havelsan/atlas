
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Pulse")] 

    public  partial class Pulse : VitalSign
    {
        public class PulseList : TTObjectCollection<Pulse> { }
                    
        public class ChildPulseCollection : TTObject.TTChildObjectCollection<Pulse>
        {
            public ChildPulseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPulseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPulseByEpisodeActionAndDate_Class : TTReportNqlObject 
        {
            public int? Nabiz
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NABIZ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PULSE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetPulseByEpisodeActionAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPulseByEpisodeActionAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPulseByEpisodeActionAndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPulseByPatientId_Class : TTReportNqlObject 
        {
            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PULSE"].AllPropertyDefs["EXECUTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PULSE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetPulseByPatientId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPulseByPatientId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPulseByPatientId_Class() : base() { }
        }

        public static BindingList<Pulse.GetPulseByEpisodeActionAndDate_Class> GetPulseByEpisodeActionAndDate(Guid EpisodeAction, DateTime ExecutionDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PULSE"].QueryDefs["GetPulseByEpisodeActionAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);
            paramList.Add("EXECUTIONDATE", ExecutionDate);

            return TTReportNqlObject.QueryObjects<Pulse.GetPulseByEpisodeActionAndDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pulse.GetPulseByEpisodeActionAndDate_Class> GetPulseByEpisodeActionAndDate(TTObjectContext objectContext, Guid EpisodeAction, DateTime ExecutionDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PULSE"].QueryDefs["GetPulseByEpisodeActionAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);
            paramList.Add("EXECUTIONDATE", ExecutionDate);

            return TTReportNqlObject.QueryObjects<Pulse.GetPulseByEpisodeActionAndDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pulse.GetPulseByPatientId_Class> GetPulseByPatientId(Guid patientId, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PULSE"].QueryDefs["GetPulseByPatientId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", patientId);

            return TTReportNqlObject.QueryObjects<Pulse.GetPulseByPatientId_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pulse.GetPulseByPatientId_Class> GetPulseByPatientId(TTObjectContext objectContext, Guid patientId, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PULSE"].QueryDefs["GetPulseByPatientId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", patientId);

            return TTReportNqlObject.QueryObjects<Pulse.GetPulseByPatientId_Class>(objectContext, queryDef, paramList, pi);
        }

        public int? Value
        {
            get { return (int?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        protected Pulse(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Pulse(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Pulse(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Pulse(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Pulse(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PULSE", dataRow) { }
        protected Pulse(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PULSE", dataRow, isImported) { }
        public Pulse(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Pulse(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Pulse() : base() { }

    }
}