
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDetailMainClassDefinition")] 

    public  partial class FixedAssetDetailMainClassDefinition : TerminologyManagerDef
    {
        public class FixedAssetDetailMainClassDefinitionList : TTObjectCollection<FixedAssetDetailMainClassDefinition> { }
                    
        public class ChildFixedAssetDetailMainClassDefinitionCollection : TTObject.TTChildObjectCollection<FixedAssetDetailMainClassDefinition>
        {
            public ChildFixedAssetDetailMainClassDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDetailMainClassDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFixedAssetDetailMainClassList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string MainClassName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILMAINCLASSDEFINITION"].AllPropertyDefs["MAINCLASSNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFixedAssetDetailMainClassList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetDetailMainClassList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetDetailMainClassList_Class() : base() { }
        }

        public static BindingList<FixedAssetDetailMainClassDefinition.GetFixedAssetDetailMainClassList_Class> GetFixedAssetDetailMainClassList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILMAINCLASSDEFINITION"].QueryDefs["GetFixedAssetDetailMainClassList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailMainClassDefinition.GetFixedAssetDetailMainClassList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDetailMainClassDefinition.GetFixedAssetDetailMainClassList_Class> GetFixedAssetDetailMainClassList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILMAINCLASSDEFINITION"].QueryDefs["GetFixedAssetDetailMainClassList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailMainClassDefinition.GetFixedAssetDetailMainClassList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string MainClassName
        {
            get { return (string)this["MAINCLASSNAME"]; }
            set { this["MAINCLASSNAME"] = value; }
        }

        protected FixedAssetDetailMainClassDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDetailMainClassDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDetailMainClassDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDetailMainClassDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDetailMainClassDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDETAILMAINCLASSDEFINITION", dataRow) { }
        protected FixedAssetDetailMainClassDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDETAILMAINCLASSDEFINITION", dataRow, isImported) { }
        public FixedAssetDetailMainClassDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDetailMainClassDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDetailMainClassDefinition() : base() { }

    }
}