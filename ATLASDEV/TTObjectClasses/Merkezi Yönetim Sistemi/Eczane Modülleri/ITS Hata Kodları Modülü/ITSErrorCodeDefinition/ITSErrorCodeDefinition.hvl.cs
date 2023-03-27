
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ITSErrorCodeDefinition")] 

    /// <summary>
    /// İts Hata Kodları
    /// </summary>
    public  partial class ITSErrorCodeDefinition : TerminologyManagerDef
    {
        public class ITSErrorCodeDefinitionList : TTObjectCollection<ITSErrorCodeDefinition> { }
                    
        public class ChildITSErrorCodeDefinitionCollection : TTObject.TTChildObjectCollection<ITSErrorCodeDefinition>
        {
            public ChildITSErrorCodeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildITSErrorCodeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class getErrorCodeDefinitionQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITSERRORCODEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ITSERRORCODEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public getErrorCodeDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public getErrorCodeDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected getErrorCodeDefinitionQuery_Class() : base() { }
        }

        public static BindingList<ITSErrorCodeDefinition.getErrorCodeDefinitionQuery_Class> getErrorCodeDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ITSERRORCODEDEFINITION"].QueryDefs["getErrorCodeDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ITSErrorCodeDefinition.getErrorCodeDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ITSErrorCodeDefinition.getErrorCodeDefinitionQuery_Class> getErrorCodeDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ITSERRORCODEDEFINITION"].QueryDefs["getErrorCodeDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ITSErrorCodeDefinition.getErrorCodeDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hata Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected ITSErrorCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ITSErrorCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ITSErrorCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ITSErrorCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ITSErrorCodeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ITSERRORCODEDEFINITION", dataRow) { }
        protected ITSErrorCodeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ITSERRORCODEDEFINITION", dataRow, isImported) { }
        public ITSErrorCodeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ITSErrorCodeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ITSErrorCodeDefinition() : base() { }

    }
}