
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeExamination_MatterSliceAnectodeGrid")] 

    /// <summary>
    /// Madde Dilim Fıkra
    /// </summary>
    public  partial class HealthCommitteeExamination_MatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public class HealthCommitteeExamination_MatterSliceAnectodeGridList : TTObjectCollection<HealthCommitteeExamination_MatterSliceAnectodeGrid> { }
                    
        public class ChildHealthCommitteeExamination_MatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<HealthCommitteeExamination_MatterSliceAnectodeGrid>
        {
            public ChildHealthCommitteeExamination_MatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeExamination_MatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCExam_MatterSliceAnectodesByExamID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public SliceEnum? Slice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SLICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION_MATTERSLICEANECTODEGRID"].AllPropertyDefs["SLICE"].DataType;
                    return (SliceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Anectode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANECTODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION_MATTERSLICEANECTODEGRID"].AllPropertyDefs["ANECTODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Matter
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATTER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION_MATTERSLICEANECTODEGRID"].AllPropertyDefs["MATTER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public HalfSliceEnum? HalfSlice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HALFSLICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION_MATTERSLICEANECTODEGRID"].AllPropertyDefs["HALFSLICE"].DataType;
                    return (HalfSliceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetHCExam_MatterSliceAnectodesByExamID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCExam_MatterSliceAnectodesByExamID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCExam_MatterSliceAnectodesByExamID_Class() : base() { }
        }

    /// <summary>
    /// HealthCommitteeExamination_MatterSliceAnectodeGrid i HealthCommitteeExamination ın objectID si ile getirir.
    /// </summary>
        public static BindingList<HealthCommitteeExamination_MatterSliceAnectodeGrid.GetHCExam_MatterSliceAnectodesByExamID_Class> GetHCExam_MatterSliceAnectodesByExamID(string HCEXAMINATIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION_MATTERSLICEANECTODEGRID"].QueryDefs["GetHCExam_MatterSliceAnectodesByExamID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HCEXAMINATIONID", HCEXAMINATIONID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination_MatterSliceAnectodeGrid.GetHCExam_MatterSliceAnectodesByExamID_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// HealthCommitteeExamination_MatterSliceAnectodeGrid i HealthCommitteeExamination ın objectID si ile getirir.
    /// </summary>
        public static BindingList<HealthCommitteeExamination_MatterSliceAnectodeGrid.GetHCExam_MatterSliceAnectodesByExamID_Class> GetHCExam_MatterSliceAnectodesByExamID(TTObjectContext objectContext, string HCEXAMINATIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION_MATTERSLICEANECTODEGRID"].QueryDefs["GetHCExam_MatterSliceAnectodesByExamID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HCEXAMINATIONID", HCEXAMINATIONID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination_MatterSliceAnectodeGrid.GetHCExam_MatterSliceAnectodesByExamID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Madde Dilim Fıkra
    /// </summary>
        public HealthCommitteeExamination HealthCommitteeExamination
        {
            get { return (HealthCommitteeExamination)((ITTObject)this).GetParent("HEALTHCOMMITTEEEXAMINATION"); }
            set { this["HEALTHCOMMITTEEEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommitteeExamination_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeExamination_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeExamination_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeExamination_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeExamination_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEEXAMINATION_MATTERSLICEANECTODEGRID", dataRow) { }
        protected HealthCommitteeExamination_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEEXAMINATION_MATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public HealthCommitteeExamination_MatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeExamination_MatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeExamination_MatterSliceAnectodeGrid() : base() { }

    }
}