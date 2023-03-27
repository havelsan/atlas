
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingTargetDefinition")] 

    /// <summary>
    /// Hemşirelik Hedef Tanımları
    /// </summary>
    public  partial class NursingTargetDefinition : TerminologyManagerDef
    {
        public class NursingTargetDefinitionList : TTObjectCollection<NursingTargetDefinition> { }
                    
        public class ChildNursingTargetDefinitionCollection : TTObject.TTChildObjectCollection<NursingTargetDefinition>
        {
            public ChildNursingTargetDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingTargetDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingTargetDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGTARGETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNursingTargetDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingTargetDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingTargetDefinition_Class() : base() { }
        }

        public static BindingList<NursingTargetDefinition.GetNursingTargetDefinition_Class> GetNursingTargetDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGTARGETDEFINITION"].QueryDefs["GetNursingTargetDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingTargetDefinition.GetNursingTargetDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingTargetDefinition.GetNursingTargetDefinition_Class> GetNursingTargetDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGTARGETDEFINITION"].QueryDefs["GetNursingTargetDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingTargetDefinition.GetNursingTargetDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingTargetDefinition> GetNursingTargetDefinitionByProblemID(TTObjectContext objectContext, string NURSINGPROBLEM)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGTARGETDEFINITION"].QueryDefs["GetNursingTargetDefinitionByProblemID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGPROBLEM", NURSINGPROBLEM);

            return ((ITTQuery)objectContext).QueryObjects<NursingTargetDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Hemşirelik Hedefi
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

        virtual protected void CreateNursingProblemTargetRelationsCollection()
        {
            _NursingProblemTargetRelations = new NursingProblemTargetRelation.ChildNursingProblemTargetRelationCollection(this, new Guid("adf7e50a-88ce-499f-ab1a-3b0cdba0d66b"));
            ((ITTChildObjectCollection)_NursingProblemTargetRelations).GetChildren();
        }

        protected NursingProblemTargetRelation.ChildNursingProblemTargetRelationCollection _NursingProblemTargetRelations = null;
        public NursingProblemTargetRelation.ChildNursingProblemTargetRelationCollection NursingProblemTargetRelations
        {
            get
            {
                if (_NursingProblemTargetRelations == null)
                    CreateNursingProblemTargetRelationsCollection();
                return _NursingProblemTargetRelations;
            }
        }

        protected NursingTargetDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingTargetDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingTargetDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingTargetDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingTargetDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGTARGETDEFINITION", dataRow) { }
        protected NursingTargetDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGTARGETDEFINITION", dataRow, isImported) { }
        public NursingTargetDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingTargetDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingTargetDefinition() : base() { }

    }
}