
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaritalStatusDefinition")] 

    /// <summary>
    /// Medeni Durum Tanımlama
    /// </summary>
    public  partial class MaritalStatusDefinition : TTObject
    {
        public class MaritalStatusDefinitionList : TTObjectCollection<MaritalStatusDefinition> { }
                    
        public class ChildMaritalStatusDefinitionCollection : TTObject.TTChildObjectCollection<MaritalStatusDefinition>
        {
            public ChildMaritalStatusDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaritalStatusDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMaritalStatusDefinitionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MARITALSTATUSDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MARITALSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaritalStatusDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaritalStatusDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaritalStatusDefinitionNQL_Class() : base() { }
        }

        public static BindingList<MaritalStatusDefinition.GetMaritalStatusDefinitionNQL_Class> GetMaritalStatusDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MARITALSTATUSDEFINITION"].QueryDefs["GetMaritalStatusDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaritalStatusDefinition.GetMaritalStatusDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaritalStatusDefinition.GetMaritalStatusDefinitionNQL_Class> GetMaritalStatusDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MARITALSTATUSDEFINITION"].QueryDefs["GetMaritalStatusDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaritalStatusDefinition.GetMaritalStatusDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaritalStatusDefinition> GetMaritalStatusByExternalCode(TTObjectContext objectContext, string EXTERNALCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MARITALSTATUSDEFINITION"].QueryDefs["GetMaritalStatusByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<MaritalStatusDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Harici Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
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

        protected MaritalStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaritalStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaritalStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaritalStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaritalStatusDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MARITALSTATUSDEFINITION", dataRow) { }
        protected MaritalStatusDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MARITALSTATUSDEFINITION", dataRow, isImported) { }
        public MaritalStatusDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaritalStatusDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaritalStatusDefinition() : base() { }

    }
}