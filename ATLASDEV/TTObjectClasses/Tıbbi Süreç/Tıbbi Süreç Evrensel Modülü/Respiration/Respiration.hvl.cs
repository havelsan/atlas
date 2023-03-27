
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Respiration")] 

    public  partial class Respiration : VitalSign
    {
        public class RespirationList : TTObjectCollection<Respiration> { }
                    
        public class ChildRespirationCollection : TTObject.TTChildObjectCollection<Respiration>
        {
            public ChildRespirationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRespirationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRespirationByEpisodeActionAndDate_Class : TTReportNqlObject 
        {
            public int? Solunum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLUNUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPIRATION"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetRespirationByEpisodeActionAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRespirationByEpisodeActionAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRespirationByEpisodeActionAndDate_Class() : base() { }
        }

        public static BindingList<Respiration.GetRespirationByEpisodeActionAndDate_Class> GetRespirationByEpisodeActionAndDate(Guid EpisodeAction, DateTime ExecutionDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPIRATION"].QueryDefs["GetRespirationByEpisodeActionAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);
            paramList.Add("EXECUTIONDATE", ExecutionDate);

            return TTReportNqlObject.QueryObjects<Respiration.GetRespirationByEpisodeActionAndDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Respiration.GetRespirationByEpisodeActionAndDate_Class> GetRespirationByEpisodeActionAndDate(TTObjectContext objectContext, Guid EpisodeAction, DateTime ExecutionDate, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPIRATION"].QueryDefs["GetRespirationByEpisodeActionAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EpisodeAction);
            paramList.Add("EXECUTIONDATE", ExecutionDate);

            return TTReportNqlObject.QueryObjects<Respiration.GetRespirationByEpisodeActionAndDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? Value
        {
            get { return (int?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        protected Respiration(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Respiration(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Respiration(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Respiration(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Respiration(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESPIRATION", dataRow) { }
        protected Respiration(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESPIRATION", dataRow, isImported) { }
        public Respiration(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Respiration(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Respiration() : base() { }

    }
}