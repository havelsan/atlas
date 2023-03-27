
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResTreatmentDiagnosisUnit")] 

    /// <summary>
    /// Tanı Tedavi Birimi
    /// </summary>
    public  partial class ResTreatmentDiagnosisUnit : ResSection
    {
        public class ResTreatmentDiagnosisUnitList : TTObjectCollection<ResTreatmentDiagnosisUnit> { }
                    
        public class ChildResTreatmentDiagnosisUnitCollection : TTObject.TTChildObjectCollection<ResTreatmentDiagnosisUnit>
        {
            public ChildResTreatmentDiagnosisUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResTreatmentDiagnosisUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetResTreatmentDiagnosisUnitNql_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["QREF"].DataType;
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

            public GetResTreatmentDiagnosisUnitNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResTreatmentDiagnosisUnitNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResTreatmentDiagnosisUnitNql_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ResTreatmentDiagnosisUnit_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Department
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPARTMENT"]);
                }
            }

            public OLAP_ResTreatmentDiagnosisUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResTreatmentDiagnosisUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResTreatmentDiagnosisUnit_Class() : base() { }
        }

        public static BindingList<ResTreatmentDiagnosisUnit> GetResTreatmentDiagnosisUnits(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].QueryDefs["GetResTreatmentDiagnosisUnits"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResTreatmentDiagnosisUnit>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResTreatmentDiagnosisUnit.GetResTreatmentDiagnosisUnitNql_Class> GetResTreatmentDiagnosisUnitNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].QueryDefs["GetResTreatmentDiagnosisUnitNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResTreatmentDiagnosisUnit.GetResTreatmentDiagnosisUnitNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResTreatmentDiagnosisUnit.GetResTreatmentDiagnosisUnitNql_Class> GetResTreatmentDiagnosisUnitNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].QueryDefs["GetResTreatmentDiagnosisUnitNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResTreatmentDiagnosisUnit.GetResTreatmentDiagnosisUnitNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResTreatmentDiagnosisUnit.OLAP_ResTreatmentDiagnosisUnit_Class> OLAP_ResTreatmentDiagnosisUnit(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].QueryDefs["OLAP_ResTreatmentDiagnosisUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResTreatmentDiagnosisUnit.OLAP_ResTreatmentDiagnosisUnit_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResTreatmentDiagnosisUnit.OLAP_ResTreatmentDiagnosisUnit_Class> OLAP_ResTreatmentDiagnosisUnit(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESTREATMENTDIAGNOSISUNIT"].QueryDefs["OLAP_ResTreatmentDiagnosisUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResTreatmentDiagnosisUnit.OLAP_ResTreatmentDiagnosisUnit_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Cumartesi  Günü Açık Mı?
    /// </summary>
        public bool? OpenOnSaturday
        {
            get { return (bool?)this["OPENONSATURDAY"]; }
            set { this["OPENONSATURDAY"] = value; }
        }

    /// <summary>
    /// Pazar Günü Açık Mı?
    /// </summary>
        public bool? OpenOnSunday
        {
            get { return (bool?)this["OPENONSUNDAY"]; }
            set { this["OPENONSUNDAY"] = value; }
        }

    /// <summary>
    /// Salı Günü Açık Mı?
    /// </summary>
        public bool? OpenOnTuesday
        {
            get { return (bool?)this["OPENONTUESDAY"]; }
            set { this["OPENONTUESDAY"] = value; }
        }

    /// <summary>
    /// Çarşamba Günü Açık Mı?
    /// </summary>
        public bool? OpenOnWednesday
        {
            get { return (bool?)this["OPENONWEDNESDAY"]; }
            set { this["OPENONWEDNESDAY"] = value; }
        }

    /// <summary>
    /// Cuma Günü Açık Mı?
    /// </summary>
        public bool? OpenOnFriday
        {
            get { return (bool?)this["OPENONFRIDAY"]; }
            set { this["OPENONFRIDAY"] = value; }
        }

    /// <summary>
    /// Pazartesi Günü Açık Mı?
    /// </summary>
        public bool? OpenOnMonday
        {
            get { return (bool?)this["OPENONMONDAY"]; }
            set { this["OPENONMONDAY"] = value; }
        }

    /// <summary>
    /// Perşembe Günü Açık Mı?
    /// </summary>
        public bool? OpenOnThursday
        {
            get { return (bool?)this["OPENONTHURSDAY"]; }
            set { this["OPENONTHURSDAY"] = value; }
        }

    /// <summary>
    /// Bölüm
    /// </summary>
        public ResDepartment Department
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateEquipmentsCollection()
        {
            _Equipments = new ResEquipment.ChildResEquipmentCollection(this, new Guid("76f2e163-48d3-4d0f-aeb2-7c3f07bbb7af"));
            ((ITTChildObjectCollection)_Equipments).GetChildren();
        }

        protected ResEquipment.ChildResEquipmentCollection _Equipments = null;
        public ResEquipment.ChildResEquipmentCollection Equipments
        {
            get
            {
                if (_Equipments == null)
                    CreateEquipmentsCollection();
                return _Equipments;
            }
        }

        virtual protected void CreateTreatmentUnitGridCollection()
        {
            _TreatmentUnitGrid = new PhysiotherapyTreatmentUnitGrid.ChildPhysiotherapyTreatmentUnitGridCollection(this, new Guid("4f83eed4-6644-47ea-ac61-abe5a0662e79"));
            ((ITTChildObjectCollection)_TreatmentUnitGrid).GetChildren();
        }

        protected PhysiotherapyTreatmentUnitGrid.ChildPhysiotherapyTreatmentUnitGridCollection _TreatmentUnitGrid = null;
    /// <summary>
    /// Child collection for Tanı Tedavi Ünitesi
    /// </summary>
        public PhysiotherapyTreatmentUnitGrid.ChildPhysiotherapyTreatmentUnitGridCollection TreatmentUnitGrid
        {
            get
            {
                if (_TreatmentUnitGrid == null)
                    CreateTreatmentUnitGridCollection();
                return _TreatmentUnitGrid;
            }
        }

        virtual protected void CreateTreatmentDiagnosisRoomsCollection()
        {
            _TreatmentDiagnosisRooms = new ResTreatmentDiagnosisRoom.ChildResTreatmentDiagnosisRoomCollection(this, new Guid("c681bf9d-9388-407f-8710-d8ca37859586"));
            ((ITTChildObjectCollection)_TreatmentDiagnosisRooms).GetChildren();
        }

        protected ResTreatmentDiagnosisRoom.ChildResTreatmentDiagnosisRoomCollection _TreatmentDiagnosisRooms = null;
    /// <summary>
    /// Child collection for Tanı Tedavi Ünitesi
    /// </summary>
        public ResTreatmentDiagnosisRoom.ChildResTreatmentDiagnosisRoomCollection TreatmentDiagnosisRooms
        {
            get
            {
                if (_TreatmentDiagnosisRooms == null)
                    CreateTreatmentDiagnosisRoomsCollection();
                return _TreatmentDiagnosisRooms;
            }
        }

        virtual protected void CreateDialysisTreatmentUnitGridsCollection()
        {
            _DialysisTreatmentUnitGrids = new DialysisTreatmentUnitGrid.ChildDialysisTreatmentUnitGridCollection(this, new Guid("ac45fde6-fea0-42cf-bf5c-d45069ac18b1"));
            ((ITTChildObjectCollection)_DialysisTreatmentUnitGrids).GetChildren();
        }

        protected DialysisTreatmentUnitGrid.ChildDialysisTreatmentUnitGridCollection _DialysisTreatmentUnitGrids = null;
        public DialysisTreatmentUnitGrid.ChildDialysisTreatmentUnitGridCollection DialysisTreatmentUnitGrids
        {
            get
            {
                if (_DialysisTreatmentUnitGrids == null)
                    CreateDialysisTreatmentUnitGridsCollection();
                return _DialysisTreatmentUnitGrids;
            }
        }

        protected ResTreatmentDiagnosisUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResTreatmentDiagnosisUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResTreatmentDiagnosisUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResTreatmentDiagnosisUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResTreatmentDiagnosisUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESTREATMENTDIAGNOSISUNIT", dataRow) { }
        protected ResTreatmentDiagnosisUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESTREATMENTDIAGNOSISUNIT", dataRow, isImported) { }
        public ResTreatmentDiagnosisUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResTreatmentDiagnosisUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResTreatmentDiagnosisUnit() : base() { }

    }
}