
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureActionSuggestion")] 

    public  partial class ProcedureActionSuggestion : TerminologyManagerDef
    {
        public class ProcedureActionSuggestionList : TTObjectCollection<ProcedureActionSuggestion> { }
                    
        public class ChildProcedureActionSuggestionCollection : TTObject.TTChildObjectCollection<ProcedureActionSuggestion>
        {
            public ChildProcedureActionSuggestionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureActionSuggestionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProcedureActionSuggestionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Message
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREACTIONSUGGESTION"].AllPropertyDefs["MESSAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREACTIONSUGGESTION"].AllPropertyDefs["ACTIONTYPE"].DataType;
                    return (ActionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Suggestedprocedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUGGESTEDPROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProcedureActionSuggestionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureActionSuggestionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureActionSuggestionList_Class() : base() { }
        }

        public static BindingList<ProcedureActionSuggestion.GetProcedureActionSuggestionList_Class> GetProcedureActionSuggestionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREACTIONSUGGESTION"].QueryDefs["GetProcedureActionSuggestionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureActionSuggestion.GetProcedureActionSuggestionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureActionSuggestion.GetProcedureActionSuggestionList_Class> GetProcedureActionSuggestionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREACTIONSUGGESTION"].QueryDefs["GetProcedureActionSuggestionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureActionSuggestion.GetProcedureActionSuggestionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İşlem Tipi 
    /// </summary>
        public ActionTypeEnum? ActionType
        {
            get { return (ActionTypeEnum?)(int?)this["ACTIONTYPE"]; }
            set { this["ACTIONTYPE"] = value; }
        }

        public string Message
        {
            get { return (string)this["MESSAGE"]; }
            set { this["MESSAGE"] = value; }
        }

    /// <summary>
    /// Önerilen Hizmet
    /// </summary>
        public ProcedureDefinition SuggestedProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("SUGGESTEDPROCEDUREDEFINITION"); }
            set { this["SUGGESTEDPROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Yapan Birimin  Tutulduğu Alan
    /// </summary>
        public ResSection SuggestedMasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("SUGGESTEDMASTERRESOURCE"); }
            set { this["SUGGESTEDMASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSuggestionCasesCollection()
        {
            _SuggestionCases = new SuggestionCase.ChildSuggestionCaseCollection(this, new Guid("1c8658e9-95c8-4705-bf14-8c2a7b693a79"));
            ((ITTChildObjectCollection)_SuggestionCases).GetChildren();
        }

        protected SuggestionCase.ChildSuggestionCaseCollection _SuggestionCases = null;
        public SuggestionCase.ChildSuggestionCaseCollection SuggestionCases
        {
            get
            {
                if (_SuggestionCases == null)
                    CreateSuggestionCasesCollection();
                return _SuggestionCases;
            }
        }

        protected ProcedureActionSuggestion(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureActionSuggestion(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureActionSuggestion(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureActionSuggestion(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureActionSuggestion(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREACTIONSUGGESTION", dataRow) { }
        protected ProcedureActionSuggestion(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREACTIONSUGGESTION", dataRow, isImported) { }
        public ProcedureActionSuggestion(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureActionSuggestion(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureActionSuggestion() : base() { }

    }
}