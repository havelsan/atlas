
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneticTestDefinition")] 

    public  partial class GeneticTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public class GeneticTestDefinitionList : TTObjectCollection<GeneticTestDefinition> { }
                    
        public class ChildGeneticTestDefinitionCollection : TTObject.TTChildObjectCollection<GeneticTestDefinition>
        {
            public ChildGeneticTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneticTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GeneticTestDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GeneticTestDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GeneticTestDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GeneticTestDefFormNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetGeneticTestDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURETREE"]);
                }
            }

            public OLAP_GetGeneticTestDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetGeneticTestDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetGeneticTestDef_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetGeneticTestDef_WithDate_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURETREE"]);
                }
            }

            public OLAP_GetGeneticTestDef_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetGeneticTestDef_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetGeneticTestDef_WithDate_Class() : base() { }
        }

        public static BindingList<GeneticTestDefinition.GeneticTestDefFormNQL_Class> GeneticTestDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].QueryDefs["GeneticTestDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GeneticTestDefinition.GeneticTestDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GeneticTestDefinition.GeneticTestDefFormNQL_Class> GeneticTestDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].QueryDefs["GeneticTestDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GeneticTestDefinition.GeneticTestDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GeneticTestDefinition> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<GeneticTestDefinition>(queryDef, paramList);
        }

        public static BindingList<GeneticTestDefinition> GetGeneticTestDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].QueryDefs["GetGeneticTestDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<GeneticTestDefinition>(queryDef, paramList);
        }

        public static BindingList<GeneticTestDefinition.OLAP_GetGeneticTestDef_Class> OLAP_GetGeneticTestDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].QueryDefs["OLAP_GetGeneticTestDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GeneticTestDefinition.OLAP_GetGeneticTestDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneticTestDefinition.OLAP_GetGeneticTestDef_Class> OLAP_GetGeneticTestDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].QueryDefs["OLAP_GetGeneticTestDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GeneticTestDefinition.OLAP_GetGeneticTestDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<GeneticTestDefinition.OLAP_GetGeneticTestDef_WithDate_Class> OLAP_GetGeneticTestDef_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].QueryDefs["OLAP_GetGeneticTestDef_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<GeneticTestDefinition.OLAP_GetGeneticTestDef_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneticTestDefinition.OLAP_GetGeneticTestDef_WithDate_Class> OLAP_GetGeneticTestDef_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICTESTDEFINITION"].QueryDefs["OLAP_GetGeneticTestDef_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<GeneticTestDefinition.OLAP_GetGeneticTestDef_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public ResGeneticDepartment Department
        {
            get { return (ResGeneticDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateEquipmentCollection()
        {
            _Equipment = new GeneticGridEquipmentDefinition.ChildGeneticGridEquipmentDefinitionCollection(this, new Guid("2832db43-6190-4718-84ab-74f843673ba3"));
            ((ITTChildObjectCollection)_Equipment).GetChildren();
        }

        protected GeneticGridEquipmentDefinition.ChildGeneticGridEquipmentDefinitionCollection _Equipment = null;
        public GeneticGridEquipmentDefinition.ChildGeneticGridEquipmentDefinitionCollection Equipment
        {
            get
            {
                if (_Equipment == null)
                    CreateEquipmentCollection();
                return _Equipment;
            }
        }

        virtual protected void CreateGeneticGridMaterialDefinitionsCollection()
        {
            _GeneticGridMaterialDefinitions = new GeneticGridMaterialDefinition.ChildGeneticGridMaterialDefinitionCollection(this, new Guid("c26f1c6e-3792-4b8b-869b-a9a8419c3f40"));
            ((ITTChildObjectCollection)_GeneticGridMaterialDefinitions).GetChildren();
        }

        protected GeneticGridMaterialDefinition.ChildGeneticGridMaterialDefinitionCollection _GeneticGridMaterialDefinitions = null;
        public GeneticGridMaterialDefinition.ChildGeneticGridMaterialDefinitionCollection GeneticGridMaterialDefinitions
        {
            get
            {
                if (_GeneticGridMaterialDefinitions == null)
                    CreateGeneticGridMaterialDefinitionsCollection();
                return _GeneticGridMaterialDefinitions;
            }
        }

        protected GeneticTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneticTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneticTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneticTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneticTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENETICTESTDEFINITION", dataRow) { }
        protected GeneticTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENETICTESTDEFINITION", dataRow, isImported) { }
        public GeneticTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneticTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneticTestDefinition() : base() { }

    }
}