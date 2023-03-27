
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryTabNamesGrid")] 

    public  partial class LaboratoryTabNamesGrid : TTObject
    {
        public class LaboratoryTabNamesGridList : TTObjectCollection<LaboratoryTabNamesGrid> { }
                    
        public class ChildLaboratoryTabNamesGridCollection : TTObject.TTChildObjectCollection<LaboratoryTabNamesGrid>
        {
            public ChildLaboratoryTabNamesGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryTabNamesGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLabTabNamesGridByInjection_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["ISPASSIVENOW"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string TabDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["TABDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsSubTest
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSUBTEST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["ISSUBTEST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetLabTabNamesGridByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabTabNamesGridByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabTabNamesGridByInjection_Class() : base() { }
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["ISPASSIVENOW"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string TabDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["TABDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsSubTest
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSUBTEST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["ISSUBTEST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetByTabs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByTabs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByTabs_Class() : base() { }
        }

        public static BindingList<LaboratoryTabNamesGrid> GetByTabName(TTObjectContext objectContext, string PARAMTAB)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTABNAMESGRID"].QueryDefs["GetByTabName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTAB", PARAMTAB);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryTabNamesGrid>(queryDef, paramList);
        }

        public static BindingList<LaboratoryTabNamesGrid.GetLabTabNamesGridByInjection_Class> GetLabTabNamesGridByInjection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTABNAMESGRID"].QueryDefs["GetLabTabNamesGridByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryTabNamesGrid.GetLabTabNamesGridByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryTabNamesGrid.GetLabTabNamesGridByInjection_Class> GetLabTabNamesGridByInjection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTABNAMESGRID"].QueryDefs["GetLabTabNamesGridByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryTabNamesGrid.GetLabTabNamesGridByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryTabNamesGrid.GetByTabs_Class> GetByTabs(string PARAMTAB, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTABNAMESGRID"].QueryDefs["GetByTabs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTAB", PARAMTAB);

            return TTReportNqlObject.QueryObjects<LaboratoryTabNamesGrid.GetByTabs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryTabNamesGrid.GetByTabs_Class> GetByTabs(TTObjectContext objectContext, string PARAMTAB, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTABNAMESGRID"].QueryDefs["GetByTabs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTAB", PARAMTAB);

            return TTReportNqlObject.QueryObjects<LaboratoryTabNamesGrid.GetByTabs_Class>(objectContext, queryDef, paramList, pi);
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
    /// İstek Formu Tab Tanım İlişkisi
    /// </summary>
        public LaboratoryRequestFormTabDefinition RequestFormTab
        {
            get { return (LaboratoryRequestFormTabDefinition)((ITTObject)this).GetParent("REQUESTFORMTAB"); }
            set { this["REQUESTFORMTAB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTESTDEFINITION"); }
            set { this["LABORATORYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryTabNamesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryTabNamesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryTabNamesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryTabNamesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryTabNamesGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYTABNAMESGRID", dataRow) { }
        protected LaboratoryTabNamesGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYTABNAMESGRID", dataRow, isImported) { }
        public LaboratoryTabNamesGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryTabNamesGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryTabNamesGrid() : base() { }

    }
}