
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StoneBreakUpDefinition")] 

    /// <summary>
    /// Taş Kırma işlemleri Tanımları
    /// </summary>
    public  partial class StoneBreakUpDefinition : ProcedureDefinition
    {
        public class StoneBreakUpDefinitionList : TTObjectCollection<StoneBreakUpDefinition> { }
                    
        public class ChildStoneBreakUpDefinitionCollection : TTObject.TTChildObjectCollection<StoneBreakUpDefinition>
        {
            public ChildStoneBreakUpDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStoneBreakUpDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStoneBreakUpDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public int? Seance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPDEFINITION"].AllPropertyDefs["SEANCE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetStoneBreakUpDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStoneBreakUpDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStoneBreakUpDefinition_Class() : base() { }
        }

        public static BindingList<StoneBreakUpDefinition.GetStoneBreakUpDefinition_Class> GetStoneBreakUpDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPDEFINITION"].QueryDefs["GetStoneBreakUpDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StoneBreakUpDefinition.GetStoneBreakUpDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StoneBreakUpDefinition.GetStoneBreakUpDefinition_Class> GetStoneBreakUpDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPDEFINITION"].QueryDefs["GetStoneBreakUpDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StoneBreakUpDefinition.GetStoneBreakUpDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StoneBreakUpDefinition> GetBySeance(TTObjectContext objectContext, int SEANCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPDEFINITION"].QueryDefs["GetBySeance"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEANCE", SEANCE);

            return ((ITTQuery)objectContext).QueryObjects<StoneBreakUpDefinition>(queryDef, paramList);
        }

        public static BindingList<StoneBreakUpDefinition> GetStoneBreakUpDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPDEFINITION"].QueryDefs["GetStoneBreakUpDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<StoneBreakUpDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Seans 
    /// </summary>
        public int? Seance
        {
            get { return (int?)this["SEANCE"]; }
            set { this["SEANCE"] = value; }
        }

        protected StoneBreakUpDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StoneBreakUpDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StoneBreakUpDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StoneBreakUpDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StoneBreakUpDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STONEBREAKUPDEFINITION", dataRow) { }
        protected StoneBreakUpDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STONEBREAKUPDEFINITION", dataRow, isImported) { }
        public StoneBreakUpDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StoneBreakUpDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StoneBreakUpDefinition() : base() { }

    }
}