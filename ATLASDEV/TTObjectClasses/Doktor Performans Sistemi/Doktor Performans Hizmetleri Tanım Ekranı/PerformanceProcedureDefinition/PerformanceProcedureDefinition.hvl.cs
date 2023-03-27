
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PerformanceProcedureDefinition")] 

    /// <summary>
    /// Doktor Performans Hizmetleri Tanım Ekranı
    /// </summary>
    public  partial class PerformanceProcedureDefinition : ProcedureDefinition
    {
        public class PerformanceProcedureDefinitionList : TTObjectCollection<PerformanceProcedureDefinition> { }
                    
        public class ChildPerformanceProcedureDefinitionCollection : TTObject.TTChildObjectCollection<PerformanceProcedureDefinition>
        {
            public ChildPerformanceProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPerformanceProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPerformanceProcedureDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduretreeexternalcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURETREEEXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduretreedesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURETREEDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string GILCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GILCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].AllPropertyDefs["GILCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? GILPoint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GILPOINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].AllPropertyDefs["GILPOINT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetPerformanceProcedureDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPerformanceProcedureDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPerformanceProcedureDefinition_Class() : base() { }
        }

        public static BindingList<PerformanceProcedureDefinition.GetPerformanceProcedureDefinition_Class> GetPerformanceProcedureDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].QueryDefs["GetPerformanceProcedureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PerformanceProcedureDefinition.GetPerformanceProcedureDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PerformanceProcedureDefinition.GetPerformanceProcedureDefinition_Class> GetPerformanceProcedureDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PERFORMANCEPROCEDUREDEFINITION"].QueryDefs["GetPerformanceProcedureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PerformanceProcedureDefinition.GetPerformanceProcedureDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected PerformanceProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PerformanceProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PerformanceProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PerformanceProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PerformanceProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PERFORMANCEPROCEDUREDEFINITION", dataRow) { }
        protected PerformanceProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PERFORMANCEPROCEDUREDEFINITION", dataRow, isImported) { }
        public PerformanceProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PerformanceProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PerformanceProcedureDefinition() : base() { }

    }
}