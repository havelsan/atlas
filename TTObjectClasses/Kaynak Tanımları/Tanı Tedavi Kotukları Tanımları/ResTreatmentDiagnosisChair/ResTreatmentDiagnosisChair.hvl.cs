
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResTreatmentDiagnosisChair")] 

    /// <summary>
    /// Tanı Tedavi Kotukları Tanımları
    /// </summary>
    public  partial class ResTreatmentDiagnosisChair : ResSection
    {
        public class ResTreatmentDiagnosisChairList : TTObjectCollection<ResTreatmentDiagnosisChair> { }
                    
        public class ChildResTreatmentDiagnosisChairCollection : TTObject.TTChildObjectCollection<ResTreatmentDiagnosisChair>
        {
            public ChildResTreatmentDiagnosisChairCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResTreatmentDiagnosisChairCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetResTreatmentDiagnosisChairNql_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISCHAIR"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISCHAIR"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISCHAIR"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Treatmentdiagnosisroomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDIAGNOSISROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetResTreatmentDiagnosisChairNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResTreatmentDiagnosisChairNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResTreatmentDiagnosisChairNql_Class() : base() { }
        }

        public static BindingList<ResTreatmentDiagnosisChair.GetResTreatmentDiagnosisChairNql_Class> GetResTreatmentDiagnosisChairNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISCHAIR"].QueryDefs["GetResTreatmentDiagnosisChairNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResTreatmentDiagnosisChair.GetResTreatmentDiagnosisChairNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResTreatmentDiagnosisChair.GetResTreatmentDiagnosisChairNql_Class> GetResTreatmentDiagnosisChairNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISCHAIR"].QueryDefs["GetResTreatmentDiagnosisChairNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResTreatmentDiagnosisChair.GetResTreatmentDiagnosisChairNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResTreatmentDiagnosisChair> GetResTreatmentDiagnosisChairs(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISCHAIR"].QueryDefs["GetResTreatmentDiagnosisChairs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResTreatmentDiagnosisChair>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Tanı Tedavi Odası
    /// </summary>
        public ResTreatmentDiagnosisRoom TreatmentDiagnosisRoom
        {
            get { return (ResTreatmentDiagnosisRoom)((ITTObject)this).GetParent("TREATMENTDIAGNOSISROOM"); }
            set { this["TREATMENTDIAGNOSISROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResTreatmentDiagnosisChair(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResTreatmentDiagnosisChair(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResTreatmentDiagnosisChair(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResTreatmentDiagnosisChair(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResTreatmentDiagnosisChair(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESTREATMENTDIAGNOSISCHAIR", dataRow) { }
        protected ResTreatmentDiagnosisChair(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESTREATMENTDIAGNOSISCHAIR", dataRow, isImported) { }
        public ResTreatmentDiagnosisChair(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResTreatmentDiagnosisChair(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResTreatmentDiagnosisChair() : base() { }

    }
}