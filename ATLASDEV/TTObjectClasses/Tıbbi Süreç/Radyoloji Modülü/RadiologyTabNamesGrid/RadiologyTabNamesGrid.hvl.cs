
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTabNamesGrid")] 

    public  partial class RadiologyTabNamesGrid : TTObject
    {
        public class RadiologyTabNamesGridList : TTObjectCollection<RadiologyTabNamesGrid> { }
                    
        public class ChildRadiologyTabNamesGridCollection : TTObject.TTChildObjectCollection<RadiologyTabNamesGrid>
        {
            public ChildRadiologyTabNamesGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTabNamesGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByTabs_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Testdefid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TESTDEFID"]);
                }
            }

            public string Testname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsPassiveNow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPASSIVENOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDEFINITION"].AllPropertyDefs["ISPASSIVENOW"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetByTabs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByTabs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByTabs_Class() : base() { }
        }

        public static BindingList<RadiologyTabNamesGrid> GetByTabName(TTObjectContext objectContext, string PARAMTAB)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTABNAMESGRID"].QueryDefs["GetByTabName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTAB", PARAMTAB);

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTabNamesGrid>(queryDef, paramList);
        }

        public static BindingList<RadiologyTabNamesGrid.GetByTabs_Class> GetByTabs(string PARAMTAB, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTABNAMESGRID"].QueryDefs["GetByTabs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTAB", PARAMTAB);

            return TTReportNqlObject.QueryObjects<RadiologyTabNamesGrid.GetByTabs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTabNamesGrid.GetByTabs_Class> GetByTabs(TTObjectContext objectContext, string PARAMTAB, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTABNAMESGRID"].QueryDefs["GetByTabs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTAB", PARAMTAB);

            return TTReportNqlObject.QueryObjects<RadiologyTabNamesGrid.GetByTabs_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tab Sırası
    /// </summary>
        public int? TabOrder
        {
            get { return (int?)this["TABORDER"]; }
            set { this["TABORDER"] = value; }
        }

    /// <summary>
    /// Test Tanımı İlişkisi
    /// </summary>
        public RadiologyTestDefinition RadiologyTestDefinition
        {
            get { return (RadiologyTestDefinition)((ITTObject)this).GetParent("RADIOLOGYTESTDEFINITION"); }
            set { this["RADIOLOGYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Radyoloji Tab Tanımı İlişkisi
    /// </summary>
        public RadiologyTabDefinition RequestFormTab
        {
            get { return (RadiologyTabDefinition)((ITTObject)this).GetParent("REQUESTFORMTAB"); }
            set { this["REQUESTFORMTAB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RadiologyTabNamesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTabNamesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTabNamesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTabNamesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTabNamesGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTABNAMESGRID", dataRow) { }
        protected RadiologyTabNamesGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTABNAMESGRID", dataRow, isImported) { }
        public RadiologyTabNamesGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTabNamesGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTabNamesGrid() : base() { }

    }
}