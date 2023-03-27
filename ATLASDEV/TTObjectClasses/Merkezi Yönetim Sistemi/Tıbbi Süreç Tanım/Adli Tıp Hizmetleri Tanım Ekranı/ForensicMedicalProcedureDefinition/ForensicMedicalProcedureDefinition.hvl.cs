
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ForensicMedicalProcedureDefinition")] 

    /// <summary>
    /// Adli Tıp Hizmetleri Tanım Ekranı
    /// </summary>
    public  partial class ForensicMedicalProcedureDefinition : ProcedureDefinition
    {
        public class ForensicMedicalProcedureDefinitionList : TTObjectCollection<ForensicMedicalProcedureDefinition> { }
                    
        public class ChildForensicMedicalProcedureDefinitionCollection : TTObject.TTChildObjectCollection<ForensicMedicalProcedureDefinition>
        {
            public ChildForensicMedicalProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildForensicMedicalProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetForensicMedicalProcedureDefiniton_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALPROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALPROCEDUREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALPROCEDUREDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALPROCEDUREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALPROCEDUREDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALPROCEDUREDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ISFORENSICMEDICALEXAMINATION
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISFORENSICMEDICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALPROCEDUREDEFINITION"].AllPropertyDefs["ISFORENSICMEDICALEXAMINATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetForensicMedicalProcedureDefiniton_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetForensicMedicalProcedureDefiniton_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetForensicMedicalProcedureDefiniton_Class() : base() { }
        }

        public static BindingList<ForensicMedicalProcedureDefinition.GetForensicMedicalProcedureDefiniton_Class> GetForensicMedicalProcedureDefiniton(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALPROCEDUREDEFINITION"].QueryDefs["GetForensicMedicalProcedureDefiniton"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ForensicMedicalProcedureDefinition.GetForensicMedicalProcedureDefiniton_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ForensicMedicalProcedureDefinition.GetForensicMedicalProcedureDefiniton_Class> GetForensicMedicalProcedureDefiniton(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FORENSICMEDICALPROCEDUREDEFINITION"].QueryDefs["GetForensicMedicalProcedureDefiniton"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ForensicMedicalProcedureDefinition.GetForensicMedicalProcedureDefiniton_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Adli Tıp Muayenesi
    /// </summary>
        public bool? ISFORENSICMEDICALEXAMINATION
        {
            get { return (bool?)this["ISFORENSICMEDICALEXAMINATION"]; }
            set { this["ISFORENSICMEDICALEXAMINATION"] = value; }
        }

        protected ForensicMedicalProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ForensicMedicalProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ForensicMedicalProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ForensicMedicalProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ForensicMedicalProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FORENSICMEDICALPROCEDUREDEFINITION", dataRow) { }
        protected ForensicMedicalProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FORENSICMEDICALPROCEDUREDEFINITION", dataRow, isImported) { }
        public ForensicMedicalProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ForensicMedicalProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ForensicMedicalProcedureDefinition() : base() { }

    }
}