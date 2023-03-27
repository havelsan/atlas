
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EducationStatusDefinition")] 

    /// <summary>
    /// Eğitim Durumu
    /// </summary>
    public  partial class EducationStatusDefinition : TTObject
    {
        public class EducationStatusDefinitionList : TTObjectCollection<EducationStatusDefinition> { }
                    
        public class ChildEducationStatusDefinitionCollection : TTObject.TTChildObjectCollection<EducationStatusDefinition>
        {
            public ChildEducationStatusDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEducationStatusDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEducationStatusDefinitionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONSTATUSDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShortName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONSTATUSDEFINITION"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEducationStatusDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEducationStatusDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEducationStatusDefinitionNQL_Class() : base() { }
        }

        public static BindingList<EducationStatusDefinition.GetEducationStatusDefinitionNQL_Class> GetEducationStatusDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONSTATUSDEFINITION"].QueryDefs["GetEducationStatusDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EducationStatusDefinition.GetEducationStatusDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EducationStatusDefinition.GetEducationStatusDefinitionNQL_Class> GetEducationStatusDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONSTATUSDEFINITION"].QueryDefs["GetEducationStatusDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EducationStatusDefinition.GetEducationStatusDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EducationStatusDefinition> GetEducationStatusDefinitionByExternalCode(TTObjectContext objectContext, string EXTERNALCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EDUCATIONSTATUSDEFINITION"].QueryDefs["GetEducationStatusDefinitionByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<EducationStatusDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Harici Kod
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Kısa Adı
    /// </summary>
        public string ShortName
        {
            get { return (string)this["SHORTNAME"]; }
            set { this["SHORTNAME"] = value; }
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

        public string ShortName_Shadow
        {
            get { return (string)this["SHORTNAME_SHADOW"]; }
        }

        protected EducationStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EducationStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EducationStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EducationStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EducationStatusDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EDUCATIONSTATUSDEFINITION", dataRow) { }
        protected EducationStatusDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EDUCATIONSTATUSDEFINITION", dataRow, isImported) { }
        public EducationStatusDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EducationStatusDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EducationStatusDefinition() : base() { }

    }
}