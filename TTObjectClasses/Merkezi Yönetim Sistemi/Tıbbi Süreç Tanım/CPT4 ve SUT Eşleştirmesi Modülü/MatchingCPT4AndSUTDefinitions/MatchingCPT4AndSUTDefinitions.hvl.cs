
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MatchingCPT4AndSUTDefinitions")] 

    /// <summary>
    /// CPT4 ve SUT eşleştirmesi
    /// </summary>
    public  partial class MatchingCPT4AndSUTDefinitions : TerminologyManagerDef
    {
        public class MatchingCPT4AndSUTDefinitionsList : TTObjectCollection<MatchingCPT4AndSUTDefinitions> { }
                    
        public class ChildMatchingCPT4AndSUTDefinitionsCollection : TTObject.TTChildObjectCollection<MatchingCPT4AndSUTDefinitions>
        {
            public ChildMatchingCPT4AndSUTDefinitionsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMatchingCPT4AndSUTDefinitionsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMatchingCPT4AndSUTDefinitions_Class : TTReportNqlObject 
        {
            public string CPTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CPTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CPT4DEFINITION"].AllPropertyDefs["CPTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cptoriginalname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CPTORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CPT4DEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sutcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sutname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMatchingCPT4AndSUTDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMatchingCPT4AndSUTDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMatchingCPT4AndSUTDefinitions_Class() : base() { }
        }

        public static BindingList<MatchingCPT4AndSUTDefinitions.GetMatchingCPT4AndSUTDefinitions_Class> GetMatchingCPT4AndSUTDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATCHINGCPT4ANDSUTDEFINITIONS"].QueryDefs["GetMatchingCPT4AndSUTDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MatchingCPT4AndSUTDefinitions.GetMatchingCPT4AndSUTDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MatchingCPT4AndSUTDefinitions.GetMatchingCPT4AndSUTDefinitions_Class> GetMatchingCPT4AndSUTDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATCHINGCPT4ANDSUTDEFINITIONS"].QueryDefs["GetMatchingCPT4AndSUTDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MatchingCPT4AndSUTDefinitions.GetMatchingCPT4AndSUTDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MatchingCPT4AndSUTDefinitions> GetMatchingCPT4AndSUTDefinitionsByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATCHINGCPT4ANDSUTDEFINITIONS"].QueryDefs["GetMatchingCPT4AndSUTDefinitionsByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MatchingCPT4AndSUTDefinitions>(queryDef, paramList);
        }

    /// <summary>
    /// CPT4 Hizmeti
    /// </summary>
        public CPT4Definition CPT4Definition
        {
            get { return (CPT4Definition)((ITTObject)this).GetParent("CPT4DEFINITION"); }
            set { this["CPT4DEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SUT Hizmeti
    /// </summary>
        public SUTDefinition SUTDefinition
        {
            get { return (SUTDefinition)((ITTObject)this).GetParent("SUTDEFINITION"); }
            set { this["SUTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MatchingCPT4AndSUTDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MatchingCPT4AndSUTDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MatchingCPT4AndSUTDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MatchingCPT4AndSUTDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MatchingCPT4AndSUTDefinitions(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATCHINGCPT4ANDSUTDEFINITIONS", dataRow) { }
        protected MatchingCPT4AndSUTDefinitions(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATCHINGCPT4ANDSUTDEFINITIONS", dataRow, isImported) { }
        public MatchingCPT4AndSUTDefinitions(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MatchingCPT4AndSUTDefinitions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MatchingCPT4AndSUTDefinitions() : base() { }

    }
}