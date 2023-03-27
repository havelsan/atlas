
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyLifeActivityDefinition")] 

    public  partial class DailyLifeActivityDefinition : TerminologyManagerDef
    {
        public class DailyLifeActivityDefinitionList : TTObjectCollection<DailyLifeActivityDefinition> { }
                    
        public class ChildDailyLifeActivityDefinitionCollection : TTObject.TTChildObjectCollection<DailyLifeActivityDefinition>
        {
            public ChildDailyLifeActivityDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyLifeActivityDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDailyLifeActivityDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DAILYLIFEACTIVITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public NursingDailyLifeActivityGrupEnum? ActivityGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVITYGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DAILYLIFEACTIVITYDEFINITION"].AllPropertyDefs["ACTIVITYGROUP"].DataType;
                    return (NursingDailyLifeActivityGrupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDailyLifeActivityDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDailyLifeActivityDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDailyLifeActivityDefinition_Class() : base() { }
        }

        public static BindingList<DailyLifeActivityDefinition.GetDailyLifeActivityDefinition_Class> GetDailyLifeActivityDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DAILYLIFEACTIVITYDEFINITION"].QueryDefs["GetDailyLifeActivityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DailyLifeActivityDefinition.GetDailyLifeActivityDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DailyLifeActivityDefinition.GetDailyLifeActivityDefinition_Class> GetDailyLifeActivityDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DAILYLIFEACTIVITYDEFINITION"].QueryDefs["GetDailyLifeActivityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DailyLifeActivityDefinition.GetDailyLifeActivityDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DailyLifeActivityDefinition> GetDailyLifeActivityDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DAILYLIFEACTIVITYDEFINITION"].QueryDefs["GetDailyLifeActivityDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DailyLifeActivityDefinition>(queryDef, paramList);
        }

        public static BindingList<DailyLifeActivityDefinition> GetDailyLifeActivityDefinitionList(TTObjectContext objectContext, bool ISACTIVE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DAILYLIFEACTIVITYDEFINITION"].QueryDefs["GetDailyLifeActivityDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ISACTIVE", ISACTIVE);

            return ((ITTQuery)objectContext).QueryObjects<DailyLifeActivityDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Grup
    /// </summary>
        public NursingDailyLifeActivityGrupEnum? ActivityGroup
        {
            get { return (NursingDailyLifeActivityGrupEnum?)(int?)this["ACTIVITYGROUP"]; }
            set { this["ACTIVITYGROUP"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected DailyLifeActivityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyLifeActivityDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyLifeActivityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyLifeActivityDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyLifeActivityDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYLIFEACTIVITYDEFINITION", dataRow) { }
        protected DailyLifeActivityDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYLIFEACTIVITYDEFINITION", dataRow, isImported) { }
        public DailyLifeActivityDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyLifeActivityDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyLifeActivityDefinition() : base() { }

    }
}