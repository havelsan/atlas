
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommittee_MatterSliceAnectodeGrid")] 

    public  partial class HealthCommittee_MatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public class HealthCommittee_MatterSliceAnectodeGridList : TTObjectCollection<HealthCommittee_MatterSliceAnectodeGrid> { }
                    
        public class ChildHealthCommittee_MatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<HealthCommittee_MatterSliceAnectodeGrid>
        {
            public ChildHealthCommittee_MatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommittee_MatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMatterSliceAnectodeByParentObjectID_Class : TTReportNqlObject 
        {
            public int? Fikra
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIKRA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_MATTERSLICEANECTODEGRID"].AllPropertyDefs["ANECTODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Madde
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MADDE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_MATTERSLICEANECTODEGRID"].AllPropertyDefs["MATTER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public SliceEnum? Dilim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DILIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_MATTERSLICEANECTODEGRID"].AllPropertyDefs["SLICE"].DataType;
                    return (SliceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetMatterSliceAnectodeByParentObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMatterSliceAnectodeByParentObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMatterSliceAnectodeByParentObjectID_Class() : base() { }
        }

    /// <summary>
    /// Parent OnjectId ile HealthCommittee_MatterSliceAnectodeGrid i get eder
    /// </summary>
        public static BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> GetMatterSliceAnectodeByParentObjectID(string PARENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_MATTERSLICEANECTODEGRID"].QueryDefs["GetMatterSliceAnectodeByParentObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTOBJECTID", PARENTOBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Parent OnjectId ile HealthCommittee_MatterSliceAnectodeGrid i get eder
    /// </summary>
        public static BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> GetMatterSliceAnectodeByParentObjectID(TTObjectContext objectContext, string PARENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_MATTERSLICEANECTODEGRID"].QueryDefs["GetMatterSliceAnectodeByParentObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTOBJECTID", PARENTOBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public HealthCommittee HealthCommittee
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("HEALTHCOMMITTEE"); }
            set { this["HEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommittee_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommittee_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommittee_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommittee_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommittee_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEE_MATTERSLICEANECTODEGRID", dataRow) { }
        protected HealthCommittee_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEE_MATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public HealthCommittee_MatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommittee_MatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommittee_MatterSliceAnectodeGrid() : base() { }

    }
}