
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCWithThreeSpecialist_MatterSliceAnectodeGrid")] 

    /// <summary>
    /// Madde Dilim Fıkra
    /// </summary>
    public  partial class HCWithThreeSpecialist_MatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public class HCWithThreeSpecialist_MatterSliceAnectodeGridList : TTObjectCollection<HCWithThreeSpecialist_MatterSliceAnectodeGrid> { }
                    
        public class ChildHCWithThreeSpecialist_MatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<HCWithThreeSpecialist_MatterSliceAnectodeGrid>
        {
            public ChildHCWithThreeSpecialist_MatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCWithThreeSpecialist_MatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCWTS_MatterSliceAnectodeGridByParent_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCWITHTHREESPECIALIST_MATTERSLICEANECTODEGRID"].AllPropertyDefs["SLICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCWITHTHREESPECIALIST_MATTERSLICEANECTODEGRID"].AllPropertyDefs["ANECTODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCWITHTHREESPECIALIST_MATTERSLICEANECTODEGRID"].AllPropertyDefs["MATTER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCWITHTHREESPECIALIST_MATTERSLICEANECTODEGRID"].AllPropertyDefs["HALFSLICE"].DataType;
                    return (HalfSliceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetHCWTS_MatterSliceAnectodeGridByParent_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCWTS_MatterSliceAnectodeGridByParent_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCWTS_MatterSliceAnectodeGridByParent_Class() : base() { }
        }

    /// <summary>
    /// HCWithThreeSpecialist_MatterSliceAnectodeGrid i parent ID ile get eder
    /// </summary>
        public static BindingList<HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class> GetHCWTS_MatterSliceAnectodeGridByParent(string PARENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCWITHTHREESPECIALIST_MATTERSLICEANECTODEGRID"].QueryDefs["GetHCWTS_MatterSliceAnectodeGridByParent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTID", PARENTID);

            return TTReportNqlObject.QueryObjects<HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// HCWithThreeSpecialist_MatterSliceAnectodeGrid i parent ID ile get eder
    /// </summary>
        public static BindingList<HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class> GetHCWTS_MatterSliceAnectodeGridByParent(TTObjectContext objectContext, string PARENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCWITHTHREESPECIALIST_MATTERSLICEANECTODEGRID"].QueryDefs["GetHCWTS_MatterSliceAnectodeGridByParent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTID", PARENTID);

            return TTReportNqlObject.QueryObjects<HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Madde Dilim Fıkra
    /// </summary>
        public HealthCommitteeWithThreeSpecialist HCommitteeWithThreeSpecialist
        {
            get { return (HealthCommitteeWithThreeSpecialist)((ITTObject)this).GetParent("HCOMMITTEEWITHTHREESPECIALIST"); }
            set { this["HCOMMITTEEWITHTHREESPECIALIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCWithThreeSpecialist_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCWithThreeSpecialist_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCWithThreeSpecialist_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCWithThreeSpecialist_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCWithThreeSpecialist_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCWITHTHREESPECIALIST_MATTERSLICEANECTODEGRID", dataRow) { }
        protected HCWithThreeSpecialist_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCWITHTHREESPECIALIST_MATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public HCWithThreeSpecialist_MatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCWithThreeSpecialist_MatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCWithThreeSpecialist_MatterSliceAnectodeGrid() : base() { }

    }
}