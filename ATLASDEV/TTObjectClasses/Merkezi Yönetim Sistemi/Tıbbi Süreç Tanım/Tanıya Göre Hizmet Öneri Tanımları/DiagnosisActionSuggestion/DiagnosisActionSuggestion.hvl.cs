
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnosisActionSuggestion")] 

    /// <summary>
    /// Tanıya Göre Hizmet Öneri Tanımları
    /// </summary>
    public  partial class DiagnosisActionSuggestion : TerminologyManagerDef
    {
        public class DiagnosisActionSuggestionList : TTObjectCollection<DiagnosisActionSuggestion> { }
                    
        public class ChildDiagnosisActionSuggestionCollection : TTObject.TTChildObjectCollection<DiagnosisActionSuggestion>
        {
            public ChildDiagnosisActionSuggestionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnosisActionSuggestionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDiagnosisActionSuggestionDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ActionTypeEnum? ActionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISACTIONSUGGESTION"].AllPropertyDefs["ACTIONTYPE"].DataType;
                    return (ActionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDiagnosisActionSuggestionDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisActionSuggestionDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisActionSuggestionDefinition_Class() : base() { }
        }

        public static BindingList<DiagnosisActionSuggestion.GetDiagnosisActionSuggestionDefinition_Class> GetDiagnosisActionSuggestionDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISACTIONSUGGESTION"].QueryDefs["GetDiagnosisActionSuggestionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisActionSuggestion.GetDiagnosisActionSuggestionDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnosisActionSuggestion.GetDiagnosisActionSuggestionDefinition_Class> GetDiagnosisActionSuggestionDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISACTIONSUGGESTION"].QueryDefs["GetDiagnosisActionSuggestionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnosisActionSuggestion.GetDiagnosisActionSuggestionDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İşlem Tipi 
    /// </summary>
        public ActionTypeEnum? ActionType
        {
            get { return (ActionTypeEnum?)(int?)this["ACTIONTYPE"]; }
            set { this["ACTIONTYPE"] = value; }
        }

    /// <summary>
    /// Önerilen Hizmet
    /// </summary>
        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisDefinition DiagnosisDefinition
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSISDEFINITION"); }
            set { this["DIAGNOSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiagnosisActionSuggestion(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnosisActionSuggestion(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnosisActionSuggestion(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnosisActionSuggestion(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnosisActionSuggestion(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSISACTIONSUGGESTION", dataRow) { }
        protected DiagnosisActionSuggestion(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSISACTIONSUGGESTION", dataRow, isImported) { }
        public DiagnosisActionSuggestion(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnosisActionSuggestion(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnosisActionSuggestion() : base() { }

    }
}