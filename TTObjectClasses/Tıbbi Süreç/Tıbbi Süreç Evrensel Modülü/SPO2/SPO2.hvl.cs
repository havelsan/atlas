
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SPO2")] 

    public  partial class SPO2 : VitalSign
    {
        public class SPO2List : TTObjectCollection<SPO2> { }
                    
        public class ChildSPO2Collection : TTObject.TTChildObjectCollection<SPO2>
        {
            public ChildSPO2Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSPO2Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSPO2ByEpisodeActionAndDate_Class : TTReportNqlObject 
        {
            public int? Spo2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPO2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPO2"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetSPO2ByEpisodeActionAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSPO2ByEpisodeActionAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSPO2ByEpisodeActionAndDate_Class() : base() { }
        }

        public static BindingList<SPO2.GetSPO2ByEpisodeActionAndDate_Class> GetSPO2ByEpisodeActionAndDate(Guid EpisodeAction, DateTime ExecutionDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPO2"].QueryDefs["GetSPO2ByEpisodeActionAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);
            paramList.Add("EXECUTIONDATE", ExecutionDate);

            return TTReportNqlObject.QueryObjects<SPO2.GetSPO2ByEpisodeActionAndDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SPO2.GetSPO2ByEpisodeActionAndDate_Class> GetSPO2ByEpisodeActionAndDate(TTObjectContext objectContext, Guid EpisodeAction, DateTime ExecutionDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPO2"].QueryDefs["GetSPO2ByEpisodeActionAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);
            paramList.Add("EXECUTIONDATE", ExecutionDate);

            return TTReportNqlObject.QueryObjects<SPO2.GetSPO2ByEpisodeActionAndDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? Value
        {
            get { return (int?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        protected SPO2(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SPO2(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SPO2(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SPO2(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SPO2(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPO2", dataRow) { }
        protected SPO2(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPO2", dataRow, isImported) { }
        public SPO2(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SPO2(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SPO2() : base() { }

    }
}