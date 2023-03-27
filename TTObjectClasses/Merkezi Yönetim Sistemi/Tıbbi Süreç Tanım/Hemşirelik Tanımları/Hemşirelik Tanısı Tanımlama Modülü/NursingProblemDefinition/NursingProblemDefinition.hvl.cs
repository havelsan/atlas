
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingProblemDefinition")] 

    /// <summary>
    /// Hemşirelik Tanısı Tanımlama Modülü (Hemşirelik Sorunu)
    /// </summary>
    public  partial class NursingProblemDefinition : TerminologyManagerDef
    {
        public class NursingProblemDefinitionList : TTObjectCollection<NursingProblemDefinition> { }
                    
        public class ChildNursingProblemDefinitionCollection : TTObject.TTChildObjectCollection<NursingProblemDefinition>
        {
            public ChildNursingProblemDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingProblemDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingProblemDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROBLEMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNursingProblemDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingProblemDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingProblemDefinition_Class() : base() { }
        }

        public static BindingList<NursingProblemDefinition.GetNursingProblemDefinition_Class> GetNursingProblemDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROBLEMDEFINITION"].QueryDefs["GetNursingProblemDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingProblemDefinition.GetNursingProblemDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingProblemDefinition.GetNursingProblemDefinition_Class> GetNursingProblemDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROBLEMDEFINITION"].QueryDefs["GetNursingProblemDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingProblemDefinition.GetNursingProblemDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingProblemDefinition> GetNursingProbDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROBLEMDEFINITION"].QueryDefs["GetNursingProbDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<NursingProblemDefinition>(queryDef, paramList);
        }

        public static BindingList<NursingProblemDefinition> GetAllNursingProbDef(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPROBLEMDEFINITION"].QueryDefs["GetAllNursingProbDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<NursingProblemDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Hemşirelik Sorunu
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
            _NursingProblemCareRelations = new NursingProblemCareRelation.ChildNursingProblemCareRelationCollection(this, new Guid("8daca5d1-51ee-46b2-8814-83ed71bf0aef"));
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

        virtual protected void CreateNursingReasonProblemRelationsCollection()
        {
            _NursingReasonProblemRelations = new NursingProblemReasonRelation.ChildNursingProblemReasonRelationCollection(this, new Guid("597dcf6b-6723-4730-a54d-ace6ad6f57bf"));
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

        virtual protected void CreateNursingProblemTargetRelationsCollection()
        {
            _NursingProblemTargetRelations = new NursingProblemTargetRelation.ChildNursingProblemTargetRelationCollection(this, new Guid("86258ccd-1229-4adc-ab08-d6a832dddc76"));
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

        protected NursingProblemDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingProblemDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingProblemDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingProblemDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingProblemDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPROBLEMDEFINITION", dataRow) { }
        protected NursingProblemDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPROBLEMDEFINITION", dataRow, isImported) { }
        public NursingProblemDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingProblemDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingProblemDefinition() : base() { }

    }
}