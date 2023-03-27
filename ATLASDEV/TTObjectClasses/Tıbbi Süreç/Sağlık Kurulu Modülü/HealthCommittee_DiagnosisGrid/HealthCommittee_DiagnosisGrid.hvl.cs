
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommittee_DiagnosisGrid")] 

    /// <summary>
    /// Tanı
    /// </summary>
    public  partial class HealthCommittee_DiagnosisGrid : DiagnosisGrid
    {
        public class HealthCommittee_DiagnosisGridList : TTObjectCollection<HealthCommittee_DiagnosisGrid> { }
                    
        public class ChildHealthCommittee_DiagnosisGridCollection : TTObject.TTChildObjectCollection<HealthCommittee_DiagnosisGrid>
        {
            public ChildHealthCommittee_DiagnosisGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommittee_DiagnosisGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDiagnosisByParentObjectID_Class : TTReportNqlObject 
        {
            public bool? Ozgecmiseekle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZGECMISEEKLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_DIAGNOSISGRID"].AllPropertyDefs["ADDTOHISTORY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DiagnosisTypeEnum? Tanitipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANITIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Taniadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Tanikodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Serbesttani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERBESTTANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_DIAGNOSISGRID"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDiagnosisByParentObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisByParentObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisByParentObjectID_Class() : base() { }
        }

    /// <summary>
    /// Parent ObjectID ile Diagnosis i get eder
    /// </summary>
        public static BindingList<HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class> GetDiagnosisByParentObjectID(string PARENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_DIAGNOSISGRID"].QueryDefs["GetDiagnosisByParentObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTOBJECTID", PARENTOBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Parent ObjectID ile Diagnosis i get eder
    /// </summary>
        public static BindingList<HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class> GetDiagnosisByParentObjectID(TTObjectContext objectContext, string PARENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_DIAGNOSISGRID"].QueryDefs["GetDiagnosisByParentObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTOBJECTID", PARENTOBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        protected HealthCommittee_DiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommittee_DiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommittee_DiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommittee_DiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommittee_DiagnosisGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEE_DIAGNOSISGRID", dataRow) { }
        protected HealthCommittee_DiagnosisGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEE_DIAGNOSISGRID", dataRow, isImported) { }
        public HealthCommittee_DiagnosisGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommittee_DiagnosisGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommittee_DiagnosisGrid() : base() { }

    }
}