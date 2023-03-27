
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommunityHealthTestCategoryDefinition")] 

    /// <summary>
    /// Halk Sağlığı Tetkik Kategori
    /// </summary>
    public  partial class CommunityHealthTestCategoryDefinition : TerminologyManagerDef
    {
        public class CommunityHealthTestCategoryDefinitionList : TTObjectCollection<CommunityHealthTestCategoryDefinition> { }
                    
        public class ChildCommunityHealthTestCategoryDefinitionCollection : TTObject.TTChildObjectCollection<CommunityHealthTestCategoryDefinition>
        {
            public ChildCommunityHealthTestCategoryDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommunityHealthTestCategoryDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CommunityHealthTestCategoryDefNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public int? TabOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTCATEGORYDEFINITION"].AllPropertyDefs["TABORDER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTCATEGORYDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTCATEGORYDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? CalcMeqAndMval
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALCMEQANDMVAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTCATEGORYDEFINITION"].AllPropertyDefs["CALCMEQANDMVAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public CommunityHealthTestCategoryDefNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CommunityHealthTestCategoryDefNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CommunityHealthTestCategoryDefNQL_Class() : base() { }
        }

        public static BindingList<CommunityHealthTestCategoryDefinition> GetCommunityHealthTestCategory(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTCATEGORYDEFINITION"].QueryDefs["GetCommunityHealthTestCategory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<CommunityHealthTestCategoryDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<CommunityHealthTestCategoryDefinition.CommunityHealthTestCategoryDefNQL_Class> CommunityHealthTestCategoryDefNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTCATEGORYDEFINITION"].QueryDefs["CommunityHealthTestCategoryDefNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommunityHealthTestCategoryDefinition.CommunityHealthTestCategoryDefNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommunityHealthTestCategoryDefinition.CommunityHealthTestCategoryDefNQL_Class> CommunityHealthTestCategoryDefNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMUNITYHEALTHTESTCATEGORYDEFINITION"].QueryDefs["CommunityHealthTestCategoryDefNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommunityHealthTestCategoryDefinition.CommunityHealthTestCategoryDefNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kategori Sırası
    /// </summary>
        public int? TabOrder
        {
            get { return (int?)this["TABORDER"]; }
            set { this["TABORDER"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Name_Shadow
    /// </summary>
        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public bool? CalcMeqAndMval
        {
            get { return (bool?)this["CALCMEQANDMVAL"]; }
            set { this["CALCMEQANDMVAL"] = value; }
        }

        protected CommunityHealthTestCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommunityHealthTestCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommunityHealthTestCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommunityHealthTestCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommunityHealthTestCategoryDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMUNITYHEALTHTESTCATEGORYDEFINITION", dataRow) { }
        protected CommunityHealthTestCategoryDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMUNITYHEALTHTESTCATEGORYDEFINITION", dataRow, isImported) { }
        public CommunityHealthTestCategoryDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommunityHealthTestCategoryDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommunityHealthTestCategoryDefinition() : base() { }

    }
}