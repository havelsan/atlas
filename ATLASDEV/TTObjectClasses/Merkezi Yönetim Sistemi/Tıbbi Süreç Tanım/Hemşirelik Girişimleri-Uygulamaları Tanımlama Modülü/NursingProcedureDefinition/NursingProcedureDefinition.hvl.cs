
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingProcedureDefinition")] 

    /// <summary>
    /// Hemşirelik Girişimleri/Uygulamaları Tanımı
    /// </summary>
    public  partial class NursingProcedureDefinition : ProcedureDefinition
    {
        public class NursingProcedureDefinitionList : TTObjectCollection<NursingProcedureDefinition> { }
                    
        public class ChildNursingProcedureDefinitionCollection : TTObject.TTChildObjectCollection<NursingProcedureDefinition>
        {
            public ChildNursingProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingProcedureDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROCEDUREDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public GetNursingProcedureDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingProcedureDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingProcedureDefinition_Class() : base() { }
        }

        public static BindingList<NursingProcedureDefinition> GetNursingProcedureDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROCEDUREDEFINITION"].QueryDefs["GetNursingProcedureDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<NursingProcedureDefinition>(queryDef, paramList);
        }

        public static BindingList<NursingProcedureDefinition.GetNursingProcedureDefinition_Class> GetNursingProcedureDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROCEDUREDEFINITION"].QueryDefs["GetNursingProcedureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingProcedureDefinition.GetNursingProcedureDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingProcedureDefinition.GetNursingProcedureDefinition_Class> GetNursingProcedureDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROCEDUREDEFINITION"].QueryDefs["GetNursingProcedureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingProcedureDefinition.GetNursingProcedureDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected NursingProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPROCEDUREDEFINITION", dataRow) { }
        protected NursingProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPROCEDUREDEFINITION", dataRow, isImported) { }
        public NursingProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingProcedureDefinition() : base() { }

    }
}