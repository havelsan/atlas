
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EstheticAlternativeProcedureDefinition")] 

    /// <summary>
    /// Estetik, Geleneksel, Alternatif Tıp Hizmetleri Tanım Ekranı
    /// </summary>
    public  partial class EstheticAlternativeProcedureDefinition : ProcedureDefinition
    {
        public class EstheticAlternativeProcedureDefinitionList : TTObjectCollection<EstheticAlternativeProcedureDefinition> { }
                    
        public class ChildEstheticAlternativeProcedureDefinitionCollection : TTObject.TTChildObjectCollection<EstheticAlternativeProcedureDefinition>
        {
            public ChildEstheticAlternativeProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEstheticAlternativeProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEstheticAlternativeProcedureDefiniton_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESTHETICALTERNATIVEPROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESTHETICALTERNATIVEPROCEDUREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESTHETICALTERNATIVEPROCEDUREDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESTHETICALTERNATIVEPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESTHETICALTERNATIVEPROCEDUREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESTHETICALTERNATIVEPROCEDUREDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ESTHETICALTERNATIVEPROCEDUREDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetEstheticAlternativeProcedureDefiniton_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEstheticAlternativeProcedureDefiniton_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEstheticAlternativeProcedureDefiniton_Class() : base() { }
        }

        public static BindingList<EstheticAlternativeProcedureDefinition.GetEstheticAlternativeProcedureDefiniton_Class> GetEstheticAlternativeProcedureDefiniton(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ESTHETICALTERNATIVEPROCEDUREDEFINITION"].QueryDefs["GetEstheticAlternativeProcedureDefiniton"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EstheticAlternativeProcedureDefinition.GetEstheticAlternativeProcedureDefiniton_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EstheticAlternativeProcedureDefinition.GetEstheticAlternativeProcedureDefiniton_Class> GetEstheticAlternativeProcedureDefiniton(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ESTHETICALTERNATIVEPROCEDUREDEFINITION"].QueryDefs["GetEstheticAlternativeProcedureDefiniton"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EstheticAlternativeProcedureDefinition.GetEstheticAlternativeProcedureDefiniton_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected EstheticAlternativeProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EstheticAlternativeProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EstheticAlternativeProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EstheticAlternativeProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EstheticAlternativeProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ESTHETICALTERNATIVEPROCEDUREDEFINITION", dataRow) { }
        protected EstheticAlternativeProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ESTHETICALTERNATIVEPROCEDUREDEFINITION", dataRow, isImported) { }
        public EstheticAlternativeProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EstheticAlternativeProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EstheticAlternativeProcedureDefinition() : base() { }

    }
}