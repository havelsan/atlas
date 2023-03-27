
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdditionalApplicationDefinition")] 

    public  partial class AdditionalApplicationDefinition : ProcedureDefinition
    {
        public class AdditionalApplicationDefinitionList : TTObjectCollection<AdditionalApplicationDefinition> { }
                    
        public class ChildAdditionalApplicationDefinitionCollection : TTObject.TTChildObjectCollection<AdditionalApplicationDefinition>
        {
            public ChildAdditionalApplicationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdditionalApplicationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAdditionalApplicationDefinitionNql_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALAPPLICATIONDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALAPPLICATIONDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALAPPLICATIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALAPPLICATIONDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduretree
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURETREE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALAPPLICATIONDEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALAPPLICATIONDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetAdditionalApplicationDefinitionNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAdditionalApplicationDefinitionNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAdditionalApplicationDefinitionNql_Class() : base() { }
        }

        public static BindingList<AdditionalApplicationDefinition> GetAdditionalAppDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALAPPLICATIONDEFINITION"].QueryDefs["GetAdditionalAppDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<AdditionalApplicationDefinition>(queryDef, paramList);
        }

        public static BindingList<AdditionalApplicationDefinition.GetAdditionalApplicationDefinitionNql_Class> GetAdditionalApplicationDefinitionNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALAPPLICATIONDEFINITION"].QueryDefs["GetAdditionalApplicationDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AdditionalApplicationDefinition.GetAdditionalApplicationDefinitionNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AdditionalApplicationDefinition.GetAdditionalApplicationDefinitionNql_Class> GetAdditionalApplicationDefinitionNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALAPPLICATIONDEFINITION"].QueryDefs["GetAdditionalApplicationDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AdditionalApplicationDefinition.GetAdditionalApplicationDefinitionNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected AdditionalApplicationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdditionalApplicationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdditionalApplicationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdditionalApplicationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdditionalApplicationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADDITIONALAPPLICATIONDEFINITION", dataRow) { }
        protected AdditionalApplicationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADDITIONALAPPLICATIONDEFINITION", dataRow, isImported) { }
        public AdditionalApplicationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdditionalApplicationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdditionalApplicationDefinition() : base() { }

    }
}