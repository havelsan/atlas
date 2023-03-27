
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingReasonDefinition")] 

    /// <summary>
    /// Hemşirelik Neden Tanımlama
    /// </summary>
    public  partial class NursingReasonDefinition : TerminologyManagerDef
    {
        public class NursingReasonDefinitionList : TTObjectCollection<NursingReasonDefinition> { }
                    
        public class ChildNursingReasonDefinitionCollection : TTObject.TTChildObjectCollection<NursingReasonDefinition>
        {
            public ChildNursingReasonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingReasonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingReasonDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGREASONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNursingReasonDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingReasonDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingReasonDefinition_Class() : base() { }
        }

        public static BindingList<NursingReasonDefinition> GetNursingReasonDefinitionByProblemID(TTObjectContext objectContext, string NURSINGPROBLEM)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGREASONDEFINITION"].QueryDefs["GetNursingReasonDefinitionByProblemID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGPROBLEM", NURSINGPROBLEM);

            return ((ITTQuery)objectContext).QueryObjects<NursingReasonDefinition>(queryDef, paramList);
        }

        public static BindingList<NursingReasonDefinition.GetNursingReasonDefinition_Class> GetNursingReasonDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGREASONDEFINITION"].QueryDefs["GetNursingReasonDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingReasonDefinition.GetNursingReasonDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingReasonDefinition.GetNursingReasonDefinition_Class> GetNursingReasonDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGREASONDEFINITION"].QueryDefs["GetNursingReasonDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingReasonDefinition.GetNursingReasonDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hemşirelik Nedeni
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreateNursingReasonProblemRelationsCollection()
        {
            _NursingReasonProblemRelations = new NursingProblemReasonRelation.ChildNursingProblemReasonRelationCollection(this, new Guid("6dc47cfd-aa76-4758-9fc8-deba74bf5a54"));
            ((ITTChildObjectCollection)_NursingReasonProblemRelations).GetChildren();
        }

        protected NursingProblemReasonRelation.ChildNursingProblemReasonRelationCollection _NursingReasonProblemRelations = null;
        public NursingProblemReasonRelation.ChildNursingProblemReasonRelationCollection NursingReasonProblemRelations
        {
            get
            {
                if (_NursingReasonProblemRelations == null)
                    CreateNursingReasonProblemRelationsCollection();
                return _NursingReasonProblemRelations;
            }
        }

        protected NursingReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingReasonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGREASONDEFINITION", dataRow) { }
        protected NursingReasonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGREASONDEFINITION", dataRow, isImported) { }
        public NursingReasonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingReasonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingReasonDefinition() : base() { }

    }
}