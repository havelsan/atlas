
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid")] 

    public  partial class HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public class HCExaminationFromOtherHospitals_MatterSliceAnectodeGridList : TTObjectCollection<HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid> { }
                    
        public class ChildHCExaminationFromOtherHospitals_MatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid>
        {
            public ChildHCExaminationFromOtherHospitals_MatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCExaminationFromOtherHospitals_MatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCEFromOtherHosp_MatterSliceAnectodesByExamID_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCEXAMINATIONFROMOTHERHOSPITALS_MATTERSLICEANECTODEGRID"].AllPropertyDefs["SLICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCEXAMINATIONFROMOTHERHOSPITALS_MATTERSLICEANECTODEGRID"].AllPropertyDefs["ANECTODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCEXAMINATIONFROMOTHERHOSPITALS_MATTERSLICEANECTODEGRID"].AllPropertyDefs["MATTER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCEXAMINATIONFROMOTHERHOSPITALS_MATTERSLICEANECTODEGRID"].AllPropertyDefs["HALFSLICE"].DataType;
                    return (HalfSliceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetHCEFromOtherHosp_MatterSliceAnectodesByExamID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCEFromOtherHosp_MatterSliceAnectodesByExamID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCEFromOtherHosp_MatterSliceAnectodesByExamID_Class() : base() { }
        }

    /// <summary>
    /// HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid i HealthCommitteeExaminationFromOtherHospitals ın objectID si ile getirir.
    /// </summary>
        public static BindingList<HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid.GetHCEFromOtherHosp_MatterSliceAnectodesByExamID_Class> GetHCEFromOtherHosp_MatterSliceAnectodesByExamID(string HCEFROMOTHERHOSPID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCEXAMINATIONFROMOTHERHOSPITALS_MATTERSLICEANECTODEGRID"].QueryDefs["GetHCEFromOtherHosp_MatterSliceAnectodesByExamID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HCEFROMOTHERHOSPID", HCEFROMOTHERHOSPID);

            return TTReportNqlObject.QueryObjects<HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid.GetHCEFromOtherHosp_MatterSliceAnectodesByExamID_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid i HealthCommitteeExaminationFromOtherHospitals ın objectID si ile getirir.
    /// </summary>
        public static BindingList<HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid.GetHCEFromOtherHosp_MatterSliceAnectodesByExamID_Class> GetHCEFromOtherHosp_MatterSliceAnectodesByExamID(TTObjectContext objectContext, string HCEFROMOTHERHOSPID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCEXAMINATIONFROMOTHERHOSPITALS_MATTERSLICEANECTODEGRID"].QueryDefs["GetHCEFromOtherHosp_MatterSliceAnectodesByExamID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HCEFROMOTHERHOSPID", HCEFROMOTHERHOSPID);

            return TTReportNqlObject.QueryObjects<HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid.GetHCEFromOtherHosp_MatterSliceAnectodesByExamID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// MAdde Dilim Fıkra
    /// </summary>
        public HealthCommitteeExaminationFromOtherHospitals HCExaminationFromOtherHosp
        {
            get { return (HealthCommitteeExaminationFromOtherHospitals)((ITTObject)this).GetParent("HCEXAMINATIONFROMOTHERHOSP"); }
            set { this["HCEXAMINATIONFROMOTHERHOSP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCEXAMINATIONFROMOTHERHOSPITALS_MATTERSLICEANECTODEGRID", dataRow) { }
        protected HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCEXAMINATIONFROMOTHERHOSPITALS_MATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid() : base() { }

    }
}