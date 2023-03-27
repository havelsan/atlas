
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResTreatmentDiagnosisRoom")] 

    /// <summary>
    /// Tanı Tedavi Odası
    /// </summary>
    public  partial class ResTreatmentDiagnosisRoom : ResSection
    {
        public class ResTreatmentDiagnosisRoomList : TTObjectCollection<ResTreatmentDiagnosisRoom> { }
                    
        public class ChildResTreatmentDiagnosisRoomCollection : TTObject.TTChildObjectCollection<ResTreatmentDiagnosisRoom>
        {
            public ChildResTreatmentDiagnosisRoomCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResTreatmentDiagnosisRoomCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetResTreatmentDiagnosisRoomNql_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Treatmentdiagnosisunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDIAGNOSISUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["NAME"].DataType;
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

            public GetResTreatmentDiagnosisRoomNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResTreatmentDiagnosisRoomNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResTreatmentDiagnosisRoomNql_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ResTreatmentDiagnosisRoom_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? TreatmentDiagnosisUnit
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENTDIAGNOSISUNIT"]);
                }
            }

            public OLAP_ResTreatmentDiagnosisRoom_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResTreatmentDiagnosisRoom_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResTreatmentDiagnosisRoom_Class() : base() { }
        }

        public static BindingList<ResTreatmentDiagnosisRoom> GetResTreatmentDiagnosisRooms(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].QueryDefs["GetResTreatmentDiagnosisRooms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResTreatmentDiagnosisRoom>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResTreatmentDiagnosisRoom.GetResTreatmentDiagnosisRoomNql_Class> GetResTreatmentDiagnosisRoomNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].QueryDefs["GetResTreatmentDiagnosisRoomNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResTreatmentDiagnosisRoom.GetResTreatmentDiagnosisRoomNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResTreatmentDiagnosisRoom.GetResTreatmentDiagnosisRoomNql_Class> GetResTreatmentDiagnosisRoomNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].QueryDefs["GetResTreatmentDiagnosisRoomNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResTreatmentDiagnosisRoom.GetResTreatmentDiagnosisRoomNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResTreatmentDiagnosisRoom.OLAP_ResTreatmentDiagnosisRoom_Class> OLAP_ResTreatmentDiagnosisRoom(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].QueryDefs["OLAP_ResTreatmentDiagnosisRoom"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResTreatmentDiagnosisRoom.OLAP_ResTreatmentDiagnosisRoom_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResTreatmentDiagnosisRoom.OLAP_ResTreatmentDiagnosisRoom_Class> OLAP_ResTreatmentDiagnosisRoom(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISROOM"].QueryDefs["OLAP_ResTreatmentDiagnosisRoom"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResTreatmentDiagnosisRoom.OLAP_ResTreatmentDiagnosisRoom_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tanı Tedavi Ünitesi
    /// </summary>
        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit
        {
            get { return (ResTreatmentDiagnosisUnit)((ITTObject)this).GetParent("TREATMENTDIAGNOSISUNIT"); }
            set { this["TREATMENTDIAGNOSISUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTreatmentRoomGridsCollection()
        {
            _TreatmentRoomGrids = new PhysiotherapyTreatmentRoomGrid.ChildPhysiotherapyTreatmentRoomGridCollection(this, new Guid("76c1cb68-946a-4a9a-9200-36dd2ffdeb39"));
            ((ITTChildObjectCollection)_TreatmentRoomGrids).GetChildren();
        }

        protected PhysiotherapyTreatmentRoomGrid.ChildPhysiotherapyTreatmentRoomGridCollection _TreatmentRoomGrids = null;
    /// <summary>
    /// Child collection for Tedavi Odası
    /// </summary>
        public PhysiotherapyTreatmentRoomGrid.ChildPhysiotherapyTreatmentRoomGridCollection TreatmentRoomGrids
        {
            get
            {
                if (_TreatmentRoomGrids == null)
                    CreateTreatmentRoomGridsCollection();
                return _TreatmentRoomGrids;
            }
        }

        virtual protected void CreateTreatmentDiagnosisChairsCollection()
        {
            _TreatmentDiagnosisChairs = new ResTreatmentDiagnosisChair.ChildResTreatmentDiagnosisChairCollection(this, new Guid("a1724783-eb0f-408d-a6ef-f01a645b9532"));
            ((ITTChildObjectCollection)_TreatmentDiagnosisChairs).GetChildren();
        }

        protected ResTreatmentDiagnosisChair.ChildResTreatmentDiagnosisChairCollection _TreatmentDiagnosisChairs = null;
    /// <summary>
    /// Child collection for Tanı Tedavi Odası
    /// </summary>
        public ResTreatmentDiagnosisChair.ChildResTreatmentDiagnosisChairCollection TreatmentDiagnosisChairs
        {
            get
            {
                if (_TreatmentDiagnosisChairs == null)
                    CreateTreatmentDiagnosisChairsCollection();
                return _TreatmentDiagnosisChairs;
            }
        }

        protected ResTreatmentDiagnosisRoom(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResTreatmentDiagnosisRoom(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResTreatmentDiagnosisRoom(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResTreatmentDiagnosisRoom(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResTreatmentDiagnosisRoom(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESTREATMENTDIAGNOSISROOM", dataRow) { }
        protected ResTreatmentDiagnosisRoom(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESTREATMENTDIAGNOSISROOM", dataRow, isImported) { }
        public ResTreatmentDiagnosisRoom(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResTreatmentDiagnosisRoom(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResTreatmentDiagnosisRoom() : base() { }

    }
}