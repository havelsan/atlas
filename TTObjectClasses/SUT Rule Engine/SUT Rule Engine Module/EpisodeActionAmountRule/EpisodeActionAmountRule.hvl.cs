
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeActionAmountRule")] 

    /// <summary>
    /// Epizot İşleminde Miktar Kuralı
    /// </summary>
    public  partial class EpisodeActionAmountRule : AmountRuleBase
    {
        public class EpisodeActionAmountRuleList : TTObjectCollection<EpisodeActionAmountRule> { }
                    
        public class ChildEpisodeActionAmountRuleCollection : TTObject.TTChildObjectCollection<EpisodeActionAmountRule>
        {
            public ChildEpisodeActionAmountRuleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeActionAmountRuleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEpisodeActionAmountRuleDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONAMOUNTRULE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RulePriorityEnum? RulePriority
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RULEPRIORITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONAMOUNTRULE"].AllPropertyDefs["RULEPRIORITY"].DataType;
                    return (RulePriorityEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONAMOUNTRULE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONAMOUNTRULE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEpisodeActionAmountRuleDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeActionAmountRuleDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeActionAmountRuleDefinitionQuery_Class() : base() { }
        }

        public static BindingList<EpisodeActionAmountRule.GetEpisodeActionAmountRuleDefinitionQuery_Class> GetEpisodeActionAmountRuleDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONAMOUNTRULE"].QueryDefs["GetEpisodeActionAmountRuleDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeActionAmountRule.GetEpisodeActionAmountRuleDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeActionAmountRule.GetEpisodeActionAmountRuleDefinitionQuery_Class> GetEpisodeActionAmountRuleDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONAMOUNTRULE"].QueryDefs["GetEpisodeActionAmountRuleDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeActionAmountRule.GetEpisodeActionAmountRuleDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected EpisodeActionAmountRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeActionAmountRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeActionAmountRule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeActionAmountRule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeActionAmountRule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEACTIONAMOUNTRULE", dataRow) { }
        protected EpisodeActionAmountRule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEACTIONAMOUNTRULE", dataRow, isImported) { }
        public EpisodeActionAmountRule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeActionAmountRule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeActionAmountRule() : base() { }

    }
}