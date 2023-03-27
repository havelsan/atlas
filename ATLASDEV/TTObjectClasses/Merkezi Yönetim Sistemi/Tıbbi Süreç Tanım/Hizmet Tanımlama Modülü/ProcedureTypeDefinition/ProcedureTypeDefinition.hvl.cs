
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureTypeDefinition")] 

    /// <summary>
    /// Hizmet Türleri Tanımlama
    /// </summary>
    public  partial class ProcedureTypeDefinition : TerminologyManagerDef, ITTListTreeObject
    {
        public class ProcedureTypeDefinitionList : TTObjectCollection<ProcedureTypeDefinition> { }
                    
        public class ChildProcedureTypeDefinitionCollection : TTObject.TTChildObjectCollection<ProcedureTypeDefinition>
        {
            public ChildProcedureTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProcedureTypeDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProcedureTypeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURETYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETYPEDEFINITION"].AllPropertyDefs["PROCEDURETYPENAME"].DataType;
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

            public GetProcedureTypeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureTypeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureTypeDefinition_Class() : base() { }
        }

        public static BindingList<ProcedureTypeDefinition.GetProcedureTypeDefinition_Class> GetProcedureTypeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETYPEDEFINITION"].QueryDefs["GetProcedureTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTypeDefinition.GetProcedureTypeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureTypeDefinition.GetProcedureTypeDefinition_Class> GetProcedureTypeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETYPEDEFINITION"].QueryDefs["GetProcedureTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTypeDefinition.GetProcedureTypeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureTypeDefinition> GetProcedureTypeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETYPEDEFINITION"].QueryDefs["GetProcedureTypeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureTypeDefinition>(queryDef, paramList);
        }

        public string ProcedureTypeName_Shadow
        {
            get { return (string)this["PROCEDURETYPENAME_SHADOW"]; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Prosedür Tip Adı
    /// </summary>
        public string ProcedureTypeName
        {
            get { return (string)this["PROCEDURETYPENAME"]; }
            set { this["PROCEDURETYPENAME"] = value; }
        }

        public ProcedureTypeDefinition ParentProcedureType
        {
            get { return (ProcedureTypeDefinition)((ITTObject)this).GetParent("PARENTPROCEDURETYPE"); }
            set { this["PARENTPROCEDURETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCPT4DefinitionsCollection()
        {
            _CPT4Definitions = new CPT4Definition.ChildCPT4DefinitionCollection(this, new Guid("657e9553-2fdd-4551-b841-b9cff7be8662"));
            ((ITTChildObjectCollection)_CPT4Definitions).GetChildren();
        }

        protected CPT4Definition.ChildCPT4DefinitionCollection _CPT4Definitions = null;
        public CPT4Definition.ChildCPT4DefinitionCollection CPT4Definitions
        {
            get
            {
                if (_CPT4Definitions == null)
                    CreateCPT4DefinitionsCollection();
                return _CPT4Definitions;
            }
        }

        virtual protected void CreateProcedureTypesCollection()
        {
            _ProcedureTypes = new ProcedureTypeDefinition.ChildProcedureTypeDefinitionCollection(this, new Guid("b5a8e64b-57cc-4d8e-9e15-24240205e33c"));
            ((ITTChildObjectCollection)_ProcedureTypes).GetChildren();
        }

        protected ProcedureTypeDefinition.ChildProcedureTypeDefinitionCollection _ProcedureTypes = null;
        public ProcedureTypeDefinition.ChildProcedureTypeDefinitionCollection ProcedureTypes
        {
            get
            {
                if (_ProcedureTypes == null)
                    CreateProcedureTypesCollection();
                return _ProcedureTypes;
            }
        }

        protected ProcedureTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDURETYPEDEFINITION", dataRow) { }
        protected ProcedureTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDURETYPEDEFINITION", dataRow, isImported) { }
        public ProcedureTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureTypeDefinition() : base() { }

    }
}