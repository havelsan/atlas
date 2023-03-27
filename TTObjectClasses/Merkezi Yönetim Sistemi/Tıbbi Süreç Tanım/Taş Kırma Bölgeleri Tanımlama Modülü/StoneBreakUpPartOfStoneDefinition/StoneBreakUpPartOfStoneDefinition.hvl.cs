
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StoneBreakUpPartOfStoneDefinition")] 

    /// <summary>
    /// Taş Kırma Bölgeleri Tanımları
    /// </summary>
    public  partial class StoneBreakUpPartOfStoneDefinition : TerminologyManagerDef
    {
        public class StoneBreakUpPartOfStoneDefinitionList : TTObjectCollection<StoneBreakUpPartOfStoneDefinition> { }
                    
        public class ChildStoneBreakUpPartOfStoneDefinitionCollection : TTObject.TTChildObjectCollection<StoneBreakUpPartOfStoneDefinition>
        {
            public ChildStoneBreakUpPartOfStoneDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStoneBreakUpPartOfStoneDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStoneBreakUpPartOfStoneDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string PartOfStone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARTOFSTONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPARTOFSTONEDEFINITION"].AllPropertyDefs["PARTOFSTONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetStoneBreakUpPartOfStoneDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStoneBreakUpPartOfStoneDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStoneBreakUpPartOfStoneDefinition_Class() : base() { }
        }

        public static BindingList<StoneBreakUpPartOfStoneDefinition.GetStoneBreakUpPartOfStoneDefinition_Class> GetStoneBreakUpPartOfStoneDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPARTOFSTONEDEFINITION"].QueryDefs["GetStoneBreakUpPartOfStoneDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StoneBreakUpPartOfStoneDefinition.GetStoneBreakUpPartOfStoneDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StoneBreakUpPartOfStoneDefinition.GetStoneBreakUpPartOfStoneDefinition_Class> GetStoneBreakUpPartOfStoneDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPARTOFSTONEDEFINITION"].QueryDefs["GetStoneBreakUpPartOfStoneDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StoneBreakUpPartOfStoneDefinition.GetStoneBreakUpPartOfStoneDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StoneBreakUpPartOfStoneDefinition> GetStoneBreakUpPartOfStnDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPARTOFSTONEDEFINITION"].QueryDefs["GetStoneBreakUpPartOfStnDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<StoneBreakUpPartOfStoneDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Taş Kırma Bölgesi
    /// </summary>
        public string PartOfStone
        {
            get { return (string)this["PARTOFSTONE"]; }
            set { this["PARTOFSTONE"] = value; }
        }

        public string PartOfStone_Shadow
        {
            get { return (string)this["PARTOFSTONE_SHADOW"]; }
        }

        protected StoneBreakUpPartOfStoneDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StoneBreakUpPartOfStoneDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StoneBreakUpPartOfStoneDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StoneBreakUpPartOfStoneDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StoneBreakUpPartOfStoneDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STONEBREAKUPPARTOFSTONEDEFINITION", dataRow) { }
        protected StoneBreakUpPartOfStoneDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STONEBREAKUPPARTOFSTONEDEFINITION", dataRow, isImported) { }
        protected StoneBreakUpPartOfStoneDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StoneBreakUpPartOfStoneDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StoneBreakUpPartOfStoneDefinition() : base() { }

    }
}