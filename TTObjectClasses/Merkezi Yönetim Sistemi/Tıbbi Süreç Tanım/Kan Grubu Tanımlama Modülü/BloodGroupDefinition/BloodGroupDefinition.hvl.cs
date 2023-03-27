
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodGroupDefinition")] 

    /// <summary>
    /// Kan Grubu Tanımlama
    /// </summary>
    public  partial class BloodGroupDefinition : TTObject
    {
        public class BloodGroupDefinitionList : TTObjectCollection<BloodGroupDefinition> { }
                    
        public class ChildBloodGroupDefinitionCollection : TTObject.TTChildObjectCollection<BloodGroupDefinition>
        {
            public ChildBloodGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBloodGroupDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODGROUPDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODGROUPDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBloodGroupDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBloodGroupDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBloodGroupDefinitionNQL_Class() : base() { }
        }

        public static BindingList<BloodGroupDefinition> GetBloodGroupDefinitionByExternalCode(TTObjectContext objectContext, string EXTERNALCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODGROUPDEFINITION"].QueryDefs["GetBloodGroupDefinitionByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<BloodGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<BloodGroupDefinition.GetBloodGroupDefinitionNQL_Class> GetBloodGroupDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODGROUPDEFINITION"].QueryDefs["GetBloodGroupDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BloodGroupDefinition.GetBloodGroupDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BloodGroupDefinition.GetBloodGroupDefinitionNQL_Class> GetBloodGroupDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODGROUPDEFINITION"].QueryDefs["GetBloodGroupDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BloodGroupDefinition.GetBloodGroupDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Harici Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected BloodGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODGROUPDEFINITION", dataRow) { }
        protected BloodGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODGROUPDEFINITION", dataRow, isImported) { }
        public BloodGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodGroupDefinition() : base() { }

    }
}