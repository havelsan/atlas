
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientHistoryDefinition")] 

    /// <summary>
    /// Hasta Özgeçmiş tanım objesi
    /// </summary>
    public  partial class PatientHistoryDefinition : TerminologyManagerDef
    {
        public class PatientHistoryDefinitionList : TTObjectCollection<PatientHistoryDefinition> { }
                    
        public class ChildPatientHistoryDefinitionCollection : TTObject.TTChildObjectCollection<PatientHistoryDefinition>
        {
            public ChildPatientHistoryDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientHistoryDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientHistoryDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTHISTORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientHistoryDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientHistoryDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientHistoryDefinitionList_Class() : base() { }
        }

        public static BindingList<PatientHistoryDefinition.GetPatientHistoryDefinitionList_Class> GetPatientHistoryDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTHISTORYDEFINITION"].QueryDefs["GetPatientHistoryDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientHistoryDefinition.GetPatientHistoryDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientHistoryDefinition.GetPatientHistoryDefinitionList_Class> GetPatientHistoryDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTHISTORYDEFINITION"].QueryDefs["GetPatientHistoryDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientHistoryDefinition.GetPatientHistoryDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Özgeçmiş Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected PatientHistoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientHistoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientHistoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientHistoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientHistoryDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTHISTORYDEFINITION", dataRow) { }
        protected PatientHistoryDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTHISTORYDEFINITION", dataRow, isImported) { }
        public PatientHistoryDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientHistoryDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientHistoryDefinition() : base() { }

    }
}