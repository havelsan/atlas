
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UFESectorDefinition")] 

    /// <summary>
    /// ÜFE Sektör/Alt Sektör Tanımı
    /// </summary>
    public  partial class UFESectorDefinition : TTDefinitionSet
    {
        public class UFESectorDefinitionList : TTObjectCollection<UFESectorDefinition> { }
                    
        public class ChildUFESectorDefinitionCollection : TTObject.TTChildObjectCollection<UFESectorDefinition>
        {
            public ChildUFESectorDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUFESectorDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class UFESectorDefFormNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UFESECTORDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UFESECTORDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UFESectorDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UFESectorDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UFESectorDefFormNQL_Class() : base() { }
        }

        public static BindingList<UFESectorDefinition.UFESectorDefFormNQL_Class> UFESectorDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UFESECTORDEFINITION"].QueryDefs["UFESectorDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UFESectorDefinition.UFESectorDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UFESectorDefinition.UFESectorDefFormNQL_Class> UFESectorDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UFESECTORDEFINITION"].QueryDefs["UFESectorDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UFESectorDefinition.UFESectorDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        protected UFESectorDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UFESectorDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UFESectorDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UFESectorDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UFESectorDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UFESECTORDEFINITION", dataRow) { }
        protected UFESectorDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UFESECTORDEFINITION", dataRow, isImported) { }
        public UFESectorDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UFESectorDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UFESectorDefinition() : base() { }

    }
}