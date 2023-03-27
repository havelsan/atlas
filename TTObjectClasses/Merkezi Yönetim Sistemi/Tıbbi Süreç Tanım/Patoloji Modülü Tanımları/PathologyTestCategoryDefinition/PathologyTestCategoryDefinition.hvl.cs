
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyTestCategoryDefinition")] 

    /// <summary>
    /// Kategori
    /// </summary>
    public  partial class PathologyTestCategoryDefinition : TerminologyManagerDef
    {
        public class PathologyTestCategoryDefinitionList : TTObjectCollection<PathologyTestCategoryDefinition> { }
                    
        public class ChildPathologyTestCategoryDefinitionCollection : TTObject.TTChildObjectCollection<PathologyTestCategoryDefinition>
        {
            public ChildPathologyTestCategoryDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyTestCategoryDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PathologyTestCategoryDefFormNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTCATEGORYDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string MaterialProtocolNoPrefix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPROTOCOLNOPREFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTCATEGORYDEFINITION"].AllPropertyDefs["MATERIALPROTOCOLNOPREFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PathologyTestCategoryDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyTestCategoryDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyTestCategoryDefFormNQL_Class() : base() { }
        }

        public static BindingList<PathologyTestCategoryDefinition.PathologyTestCategoryDefFormNQL_Class> PathologyTestCategoryDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTCATEGORYDEFINITION"].QueryDefs["PathologyTestCategoryDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestCategoryDefinition.PathologyTestCategoryDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyTestCategoryDefinition.PathologyTestCategoryDefFormNQL_Class> PathologyTestCategoryDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTCATEGORYDEFINITION"].QueryDefs["PathologyTestCategoryDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestCategoryDefinition.PathologyTestCategoryDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyTestCategoryDefinition> GetPathologyTestCategoryDefByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTCATEGORYDEFINITION"].QueryDefs["GetPathologyTestCategoryDefByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PathologyTestCategoryDefinition>(queryDef, paramList);
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
    /// Materyal Protokol No Öneki
    /// </summary>
        public string MaterialProtocolNoPrefix
        {
            get { return (string)this["MATERIALPROTOCOLNOPREFIX"]; }
            set { this["MATERIALPROTOCOLNOPREFIX"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected PathologyTestCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyTestCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyTestCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyTestCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyTestCategoryDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYTESTCATEGORYDEFINITION", dataRow) { }
        protected PathologyTestCategoryDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYTESTCATEGORYDEFINITION", dataRow, isImported) { }
        public PathologyTestCategoryDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyTestCategoryDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyTestCategoryDefinition() : base() { }

    }
}