
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialTreeDefinition")] 

    /// <summary>
    /// Malzeme Grup Tanımları
    /// </summary>
    public  partial class MaterialTreeDefinition : TerminologyManagerDef
    {
        public class MaterialTreeDefinitionList : TTObjectCollection<MaterialTreeDefinition> { }
                    
        public class ChildMaterialTreeDefinitionCollection : TTObject.TTChildObjectCollection<MaterialTreeDefinition>
        {
            public ChildMaterialTreeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialTreeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_MaterialTree_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentMaterialTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTMATERIALTREE"]);
                }
            }

            public OLAP_MaterialTree_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_MaterialTree_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_MaterialTree_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialTreeDefinition_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["ISGROUP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Parentmaterialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARENTMATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GroupCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUPCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["GROUPCODE"].DataType;
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

            public GetMaterialTreeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialTreeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialTreeDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_MaterialTree_WithDate_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentMaterialTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTMATERIALTREE"]);
                }
            }

            public OLAP_MaterialTree_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_MaterialTree_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_MaterialTree_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialTreeForStock_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetMaterialTreeForStock_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialTreeForStock_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialTreeForStock_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialTreeDefAllProperty_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["ISGROUP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentMaterialTree
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTMATERIALTREE"]);
                }
            }

            public string GroupCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUPCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["GROUPCODE"].DataType;
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

            public GetMaterialTreeDefAllProperty_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialTreeDefAllProperty_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialTreeDefAllProperty_Class() : base() { }
        }

        public static BindingList<MaterialTreeDefinition.OLAP_MaterialTree_Class> OLAP_MaterialTree(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["OLAP_MaterialTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialTreeDefinition.OLAP_MaterialTree_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialTreeDefinition.OLAP_MaterialTree_Class> OLAP_MaterialTree(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["OLAP_MaterialTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialTreeDefinition.OLAP_MaterialTree_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaterialTreeDefinition.GetMaterialTreeDefinition_Class> GetMaterialTreeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["GetMaterialTreeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialTreeDefinition.GetMaterialTreeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaterialTreeDefinition.GetMaterialTreeDefinition_Class> GetMaterialTreeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["GetMaterialTreeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialTreeDefinition.GetMaterialTreeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaterialTreeDefinition.OLAP_MaterialTree_WithDate_Class> OLAP_MaterialTree_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["OLAP_MaterialTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<MaterialTreeDefinition.OLAP_MaterialTree_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialTreeDefinition.OLAP_MaterialTree_WithDate_Class> OLAP_MaterialTree_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["OLAP_MaterialTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<MaterialTreeDefinition.OLAP_MaterialTree_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaterialTreeDefinition> GetMaterialTreeDefbyLastupdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["GetMaterialTreeDefbyLastupdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MaterialTreeDefinition>(queryDef, paramList);
        }

        public static BindingList<MaterialTreeDefinition> GetMaterialTreeDefForSPTS(TTObjectContext objectContext, Guid ID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["GetMaterialTreeDefForSPTS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return ((ITTQuery)objectContext).QueryObjects<MaterialTreeDefinition>(queryDef, paramList);
        }

        public static BindingList<MaterialTreeDefinition.GetMaterialTreeForStock_Class> GetMaterialTreeForStock(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["GetMaterialTreeForStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialTreeDefinition.GetMaterialTreeForStock_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaterialTreeDefinition.GetMaterialTreeForStock_Class> GetMaterialTreeForStock(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["GetMaterialTreeForStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialTreeDefinition.GetMaterialTreeForStock_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaterialTreeDefinition.GetMaterialTreeDefAllProperty_Class> GetMaterialTreeDefAllProperty(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["GetMaterialTreeDefAllProperty"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialTreeDefinition.GetMaterialTreeDefAllProperty_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaterialTreeDefinition.GetMaterialTreeDefAllProperty_Class> GetMaterialTreeDefAllProperty(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].QueryDefs["GetMaterialTreeDefAllProperty"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialTreeDefinition.GetMaterialTreeDefAllProperty_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// IsGroup
    /// </summary>
        public bool? IsGroup
        {
            get { return (bool?)this["ISGROUP"]; }
            set { this["ISGROUP"] = value; }
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

    /// <summary>
    /// KOD
    /// </summary>
        public string GroupCode
        {
            get { return (string)this["GROUPCODE"]; }
            set { this["GROUPCODE"] = value; }
        }

        public MaterialTreeDefinition ParentMaterialTree
        {
            get { return (MaterialTreeDefinition)((ITTObject)this).GetParent("PARENTMATERIALTREE"); }
            set { this["PARENTMATERIALTREE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMaterialsCollection()
        {
            _Materials = new Material.ChildMaterialCollection(this, new Guid("cf1f0744-e68f-4625-8881-584dc189b0ec"));
            ((ITTChildObjectCollection)_Materials).GetChildren();
        }

        protected Material.ChildMaterialCollection _Materials = null;
        public Material.ChildMaterialCollection Materials
        {
            get
            {
                if (_Materials == null)
                    CreateMaterialsCollection();
                return _Materials;
            }
        }

        virtual protected void CreateMaterialGroupsCollection()
        {
            _MaterialGroups = new DiscountTypeMaterialGroupDefinition.ChildDiscountTypeMaterialGroupDefinitionCollection(this, new Guid("93fa95a3-302b-4693-a29a-644924f6727f"));
            ((ITTChildObjectCollection)_MaterialGroups).GetChildren();
        }

        protected DiscountTypeMaterialGroupDefinition.ChildDiscountTypeMaterialGroupDefinitionCollection _MaterialGroups = null;
    /// <summary>
    /// Child collection for MaterialTree ile DiscountType ilişkisi
    /// </summary>
        public DiscountTypeMaterialGroupDefinition.ChildDiscountTypeMaterialGroupDefinitionCollection MaterialGroups
        {
            get
            {
                if (_MaterialGroups == null)
                    CreateMaterialGroupsCollection();
                return _MaterialGroups;
            }
        }

        protected MaterialTreeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialTreeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialTreeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialTreeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialTreeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALTREEDEFINITION", dataRow) { }
        protected MaterialTreeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALTREEDEFINITION", dataRow, isImported) { }
        public MaterialTreeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialTreeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialTreeDefinition() : base() { }

    }
}