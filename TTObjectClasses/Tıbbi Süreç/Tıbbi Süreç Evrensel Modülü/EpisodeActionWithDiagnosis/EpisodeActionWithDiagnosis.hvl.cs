
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeActionWithDiagnosis")] 

    public  abstract  partial class EpisodeActionWithDiagnosis : EpisodeAction
    {
        public class EpisodeActionWithDiagnosisList : TTObjectCollection<EpisodeActionWithDiagnosis> { }
                    
        public class ChildEpisodeActionWithDiagnosisCollection : TTObject.TTChildObjectCollection<EpisodeActionWithDiagnosis>
        {
            public ChildEpisodeActionWithDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeActionWithDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetLastDiagnosis_Class : TTReportNqlObject 
        {
            public Guid? Diagnose
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public OLAP_GetLastDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLastDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLastDiagnosis_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetEpisodeDiagnosis_Class : TTReportNqlObject 
        {
            public Guid? Diagnose
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public OLAP_GetEpisodeDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetEpisodeDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetEpisodeDiagnosis_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForSurgery_Class : TTReportNqlObject 
        {
            public Guid? Surgeryobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SURGERYOBJECTID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public String Defname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public DateTime? SurgeryStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOldInfoForSurgery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForSurgery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForSurgery_Class() : base() { }
        }

        public static BindingList<EpisodeActionWithDiagnosis.OLAP_GetLastDiagnosis_Class> OLAP_GetLastDiagnosis(string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONWITHDIAGNOSIS"].QueryDefs["OLAP_GetLastDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<EpisodeActionWithDiagnosis.OLAP_GetLastDiagnosis_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeActionWithDiagnosis.OLAP_GetLastDiagnosis_Class> OLAP_GetLastDiagnosis(TTObjectContext objectContext, string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONWITHDIAGNOSIS"].QueryDefs["OLAP_GetLastDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<EpisodeActionWithDiagnosis.OLAP_GetLastDiagnosis_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeActionWithDiagnosis.OLAP_GetEpisodeDiagnosis_Class> OLAP_GetEpisodeDiagnosis(string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONWITHDIAGNOSIS"].QueryDefs["OLAP_GetEpisodeDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<EpisodeActionWithDiagnosis.OLAP_GetEpisodeDiagnosis_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeActionWithDiagnosis.OLAP_GetEpisodeDiagnosis_Class> OLAP_GetEpisodeDiagnosis(TTObjectContext objectContext, string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONWITHDIAGNOSIS"].QueryDefs["OLAP_GetEpisodeDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<EpisodeActionWithDiagnosis.OLAP_GetEpisodeDiagnosis_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeActionWithDiagnosis.GetOldInfoForSurgery_Class> GetOldInfoForSurgery(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONWITHDIAGNOSIS"].QueryDefs["GetOldInfoForSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<EpisodeActionWithDiagnosis.GetOldInfoForSurgery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeActionWithDiagnosis.GetOldInfoForSurgery_Class> GetOldInfoForSurgery(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONWITHDIAGNOSIS"].QueryDefs["GetOldInfoForSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<EpisodeActionWithDiagnosis.GetOldInfoForSurgery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateDiagnosisCollection()
        {
            _Diagnosis = new DiagnosisGrid.ChildDiagnosisGridCollection(this, new Guid("1af2190c-bf9a-4597-809d-4a7f93da283c"));
            ((ITTChildObjectCollection)_Diagnosis).GetChildren();
        }

        protected DiagnosisGrid.ChildDiagnosisGridCollection _Diagnosis = null;
        public DiagnosisGrid.ChildDiagnosisGridCollection Diagnosis
        {
            get
            {
                if (_Diagnosis == null)
                    CreateDiagnosisCollection();
                return _Diagnosis;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _IntegrationSubActionProcedures = new IntegrationSubActionProcedure.ChildIntegrationSubActionProcedureCollection(_SubactionProcedures, "IntegrationSubActionProcedures");
        }

        private IntegrationSubActionProcedure.ChildIntegrationSubActionProcedureCollection _IntegrationSubActionProcedures = null;
        public IntegrationSubActionProcedure.ChildIntegrationSubActionProcedureCollection IntegrationSubActionProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _IntegrationSubActionProcedures;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _IntegrationTreatmentMaterials = new IntegrationTreatmentMaterial.ChildIntegrationTreatmentMaterialCollection(_TreatmentMaterials, "IntegrationTreatmentMaterials");
        }

        private IntegrationTreatmentMaterial.ChildIntegrationTreatmentMaterialCollection _IntegrationTreatmentMaterials = null;
        public IntegrationTreatmentMaterial.ChildIntegrationTreatmentMaterialCollection IntegrationTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _IntegrationTreatmentMaterials;
            }            
        }

        protected EpisodeActionWithDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeActionWithDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeActionWithDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeActionWithDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeActionWithDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEACTIONWITHDIAGNOSIS", dataRow) { }
        protected EpisodeActionWithDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEACTIONWITHDIAGNOSIS", dataRow, isImported) { }
        public EpisodeActionWithDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeActionWithDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeActionWithDiagnosis() : base() { }

    }
}