
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingCareDefinition")] 

    /// <summary>
    /// Hemşirelik Girişimi Tanımlama
    /// </summary>
    public  partial class NursingCareDefinition : TerminologyManagerDef
    {
        public class NursingCareDefinitionList : TTObjectCollection<NursingCareDefinition> { }
                    
        public class ChildNursingCareDefinitionCollection : TTObject.TTChildObjectCollection<NursingCareDefinition>
        {
            public ChildNursingCareDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingCareDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingCareDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGCAREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNursingCareDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingCareDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingCareDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNursingCareList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGCAREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNursingCareList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingCareList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingCareList_Class() : base() { }
        }

        public static BindingList<NursingCareDefinition.GetNursingCareDefinition_Class> GetNursingCareDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGCAREDEFINITION"].QueryDefs["GetNursingCareDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingCareDefinition.GetNursingCareDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingCareDefinition.GetNursingCareDefinition_Class> GetNursingCareDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGCAREDEFINITION"].QueryDefs["GetNursingCareDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingCareDefinition.GetNursingCareDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingCareDefinition.GetNursingCareList_Class> GetNursingCareList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGCAREDEFINITION"].QueryDefs["GetNursingCareList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingCareDefinition.GetNursingCareList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingCareDefinition.GetNursingCareList_Class> GetNursingCareList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGCAREDEFINITION"].QueryDefs["GetNursingCareList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingCareDefinition.GetNursingCareList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingCareDefinition> GetNursingCareDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGCAREDEFINITION"].QueryDefs["GetNursingCareDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<NursingCareDefinition>(queryDef, paramList);
        }

        public static BindingList<NursingCareDefinition> GetNursingCareDefinitionByProblemID(TTObjectContext objectContext, string NURSINGPROBLEM)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGCAREDEFINITION"].QueryDefs["GetNursingCareDefinitionByProblemID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGPROBLEM", NURSINGPROBLEM);

            return ((ITTQuery)objectContext).QueryObjects<NursingCareDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Hemşirelik Bakımı
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

        virtual protected void CreateNursingProblemCareRelationsCollection()
        {
            _NursingProblemCareRelations = new NursingProblemCareRelation.ChildNursingProblemCareRelationCollection(this, new Guid("64a464b4-e580-422c-88b2-da4132cffda6"));
            ((ITTChildObjectCollection)_NursingProblemCareRelations).GetChildren();
        }

        protected NursingProblemCareRelation.ChildNursingProblemCareRelationCollection _NursingProblemCareRelations = null;
        public NursingProblemCareRelation.ChildNursingProblemCareRelationCollection NursingProblemCareRelations
        {
            get
            {
                if (_NursingProblemCareRelations == null)
                    CreateNursingProblemCareRelationsCollection();
                return _NursingProblemCareRelations;
            }
        }

        protected NursingCareDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingCareDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingCareDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingCareDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingCareDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGCAREDEFINITION", dataRow) { }
        protected NursingCareDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGCAREDEFINITION", dataRow, isImported) { }
        public NursingCareDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingCareDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingCareDefinition() : base() { }

    }
}