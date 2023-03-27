
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WaterlowRiskDefinition")] 

    public  partial class WaterlowRiskDefinition : TerminologyManagerDef
    {
        public class WaterlowRiskDefinitionList : TTObjectCollection<WaterlowRiskDefinition> { }
                    
        public class ChildWaterlowRiskDefinitionCollection : TTObject.TTChildObjectCollection<WaterlowRiskDefinition>
        {
            public ChildWaterlowRiskDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWaterlowRiskDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWaterlowRiskDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WATERLOWRISKDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Score
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WATERLOWRISKDEFINITION"].AllPropertyDefs["SCORE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public WaterlowTypeEnum? WaterlowType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WATERLOWTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WATERLOWRISKDEFINITION"].AllPropertyDefs["WATERLOWTYPE"].DataType;
                    return (WaterlowTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetWaterlowRiskDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWaterlowRiskDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWaterlowRiskDefinition_Class() : base() { }
        }

        public static BindingList<WaterlowRiskDefinition.GetWaterlowRiskDefinition_Class> GetWaterlowRiskDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WATERLOWRISKDEFINITION"].QueryDefs["GetWaterlowRiskDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WaterlowRiskDefinition.GetWaterlowRiskDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WaterlowRiskDefinition.GetWaterlowRiskDefinition_Class> GetWaterlowRiskDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WATERLOWRISKDEFINITION"].QueryDefs["GetWaterlowRiskDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WaterlowRiskDefinition.GetWaterlowRiskDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WaterlowRiskDefinition> GetByWaterlowRiskDefinitionLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WATERLOWRISKDEFINITION"].QueryDefs["GetByWaterlowRiskDefinitionLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<WaterlowRiskDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Tipi
    /// </summary>
        public WaterlowTypeEnum? WaterlowType
        {
            get { return (WaterlowTypeEnum?)(int?)this["WATERLOWTYPE"]; }
            set { this["WATERLOWTYPE"] = value; }
        }

    /// <summary>
    /// Puan
    /// </summary>
        public int? Score
        {
            get { return (int?)this["SCORE"]; }
            set { this["SCORE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Değerlendirme Kriteri
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected WaterlowRiskDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WaterlowRiskDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WaterlowRiskDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WaterlowRiskDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WaterlowRiskDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WATERLOWRISKDEFINITION", dataRow) { }
        protected WaterlowRiskDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WATERLOWRISKDEFINITION", dataRow, isImported) { }
        public WaterlowRiskDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WaterlowRiskDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WaterlowRiskDefinition() : base() { }

    }
}