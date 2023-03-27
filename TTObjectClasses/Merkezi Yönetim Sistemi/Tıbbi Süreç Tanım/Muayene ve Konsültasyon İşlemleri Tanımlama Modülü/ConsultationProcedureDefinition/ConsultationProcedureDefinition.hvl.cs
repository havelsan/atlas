
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConsultationProcedureDefinition")] 

    /// <summary>
    /// Muayene ve Konsültasyon İşlemleri Tanımlama
    /// </summary>
    public  partial class ConsultationProcedureDefinition : ProcedureDefinition
    {
        public class ConsultationProcedureDefinitionList : TTObjectCollection<ConsultationProcedureDefinition> { }
                    
        public class ChildConsultationProcedureDefinitionCollection : TTObject.TTChildObjectCollection<ConsultationProcedureDefinition>
        {
            public ChildConsultationProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConsultationProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetConsultationProcedureDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONPROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONPROCEDUREDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public GetConsultationProcedureDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetConsultationProcedureDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetConsultationProcedureDefinition_Class() : base() { }
        }

        public static BindingList<ConsultationProcedureDefinition.GetConsultationProcedureDefinition_Class> GetConsultationProcedureDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONPROCEDUREDEFINITION"].QueryDefs["GetConsultationProcedureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ConsultationProcedureDefinition.GetConsultationProcedureDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ConsultationProcedureDefinition.GetConsultationProcedureDefinition_Class> GetConsultationProcedureDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONPROCEDUREDEFINITION"].QueryDefs["GetConsultationProcedureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ConsultationProcedureDefinition.GetConsultationProcedureDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ConsultationProcedureDefinition> GetConsultProcDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTATIONPROCEDUREDEFINITION"].QueryDefs["GetConsultProcDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ConsultationProcedureDefinition>(queryDef, paramList);
        }

        protected ConsultationProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConsultationProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConsultationProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConsultationProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConsultationProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONSULTATIONPROCEDUREDEFINITION", dataRow) { }
        protected ConsultationProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONSULTATIONPROCEDUREDEFINITION", dataRow, isImported) { }
        public ConsultationProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConsultationProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConsultationProcedureDefinition() : base() { }

    }
}