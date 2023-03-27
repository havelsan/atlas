
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConsultedSubjectDefinition")] 

    /// <summary>
    /// Konsültasyon Danışılan Konular Tanımları
    /// </summary>
    public  partial class ConsultedSubjectDefinition : TerminologyManagerDef
    {
        public class ConsultedSubjectDefinitionList : TTObjectCollection<ConsultedSubjectDefinition> { }
                    
        public class ChildConsultedSubjectDefinitionCollection : TTObject.TTChildObjectCollection<ConsultedSubjectDefinition>
        {
            public ChildConsultedSubjectDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConsultedSubjectDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetConsultedSubjectDefinitionNql_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTEDSUBJECTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ConsultedSubject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSULTEDSUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTEDSUBJECTDEFINITION"].AllPropertyDefs["CONSULTEDSUBJECT"].DataType;
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

            public GetConsultedSubjectDefinitionNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetConsultedSubjectDefinitionNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetConsultedSubjectDefinitionNql_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetConsultedSubjectDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ConsultedSubject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSULTEDSUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSULTEDSUBJECTDEFINITION"].AllPropertyDefs["CONSULTEDSUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetConsultedSubjectDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetConsultedSubjectDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetConsultedSubjectDef_Class() : base() { }
        }

        public static BindingList<ConsultedSubjectDefinition.GetConsultedSubjectDefinitionNql_Class> GetConsultedSubjectDefinitionNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTEDSUBJECTDEFINITION"].QueryDefs["GetConsultedSubjectDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ConsultedSubjectDefinition.GetConsultedSubjectDefinitionNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ConsultedSubjectDefinition.GetConsultedSubjectDefinitionNql_Class> GetConsultedSubjectDefinitionNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTEDSUBJECTDEFINITION"].QueryDefs["GetConsultedSubjectDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ConsultedSubjectDefinition.GetConsultedSubjectDefinitionNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ConsultedSubjectDefinition.OLAP_GetConsultedSubjectDef_Class> OLAP_GetConsultedSubjectDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTEDSUBJECTDEFINITION"].QueryDefs["OLAP_GetConsultedSubjectDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ConsultedSubjectDefinition.OLAP_GetConsultedSubjectDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ConsultedSubjectDefinition.OLAP_GetConsultedSubjectDef_Class> OLAP_GetConsultedSubjectDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTEDSUBJECTDEFINITION"].QueryDefs["OLAP_GetConsultedSubjectDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ConsultedSubjectDefinition.OLAP_GetConsultedSubjectDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ConsultedSubjectDefinition> GetConsultedSubjectDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSULTEDSUBJECTDEFINITION"].QueryDefs["GetConsultedSubjectDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ConsultedSubjectDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string ConsultedSubject_Shadow
        {
            get { return (string)this["CONSULTEDSUBJECT_SHADOW"]; }
        }

    /// <summary>
    /// Danışılan Konular
    /// </summary>
        public string ConsultedSubject
        {
            get { return (string)this["CONSULTEDSUBJECT"]; }
            set { this["CONSULTEDSUBJECT"] = value; }
        }

        protected ConsultedSubjectDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConsultedSubjectDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConsultedSubjectDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConsultedSubjectDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConsultedSubjectDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONSULTEDSUBJECTDEFINITION", dataRow) { }
        protected ConsultedSubjectDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONSULTEDSUBJECTDEFINITION", dataRow, isImported) { }
        protected ConsultedSubjectDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConsultedSubjectDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConsultedSubjectDefinition() : base() { }

    }
}