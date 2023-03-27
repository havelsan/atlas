
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Ambulance")] 

    /// <summary>
    /// Ambulans İşlemlerinin Gerçekleştirildiği Nesne
    /// </summary>
    public  partial class Ambulance : BaseAction, IWorkListBaseAction
    {
        public class AmbulanceList : TTObjectCollection<Ambulance> { }
                    
        public class ChildAmbulanceCollection : TTObject.TTChildObjectCollection<Ambulance>
        {
            public ChildAmbulanceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAmbulanceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAmbulanceNQL_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReturnTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["RETURNTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExitTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXITTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["EXITTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DutyDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DUTYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["DUTYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ArrivalRegion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALREGION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["ARRIVALREGION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public AmbulanceReasonTypeEnum? TransportationReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSPORTATIONREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["TRANSPORTATIONREASON"].DataType;
                    return (AmbulanceReasonTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public AmbulanceTypeEnum? AmbulanceType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMBULANCETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["AMBULANCETYPE"].DataType;
                    return (AmbulanceTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string PatientName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["PATIENTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["NOTE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Duty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DUTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["DUTY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? AmbulanceKilometer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMBULANCEKILOMETER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["AMBULANCEKILOMETER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EstimatedReturnTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDRETURNTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["ESTIMATEDRETURNTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public AmbulanceDutyEnum? DutyType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DUTYTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["DUTYTYPE"].DataType;
                    return (AmbulanceDutyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string StartRegion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTREGION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["STARTREGION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CommitterTelNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMITTERTELNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["COMMITTERTELNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DriverTelNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRIVERTELNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["DRIVERTELNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public AmbulanceStretcherEnum? Stretcher
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STRETCHER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["STRETCHER"].DataType;
                    return (AmbulanceStretcherEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string PatientAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["PATIENTADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Committer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMITTER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].AllPropertyDefs["COMMITTER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientrankname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTRANKNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["SHORTNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Plate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCEPLATEDEFINITION"].AllPropertyDefs["PLATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAmbulanceNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAmbulanceNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAmbulanceNQL_Class() : base() { }
        }

        public static class States
        {
            public static Guid OutOfHospital { get { return new Guid("98fb6a11-19f7-486b-bc27-385a0d288c04"); } }
            public static Guid Completed { get { return new Guid("05704ea4-d2ee-45a8-8241-9c14e90a329f"); } }
            public static Guid Request { get { return new Guid("d57a0a45-7ccd-4a0c-b3d8-62240841d455"); } }
        }

        public static BindingList<Ambulance.GetAmbulanceNQL_Class> GetAmbulanceNQL(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].QueryDefs["GetAmbulanceNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Ambulance.GetAmbulanceNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Ambulance.GetAmbulanceNQL_Class> GetAmbulanceNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AMBULANCE"].QueryDefs["GetAmbulanceNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Ambulance.GetAmbulanceNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Dönüş Saati
    /// </summary>
        public DateTime? ReturnTime
        {
            get { return (DateTime?)this["RETURNTIME"]; }
            set { this["RETURNTIME"] = value; }
        }

    /// <summary>
    /// Çıkış Saati
    /// </summary>
        public DateTime? ExitTime
        {
            get { return (DateTime?)this["EXITTIME"]; }
            set { this["EXITTIME"] = value; }
        }

    /// <summary>
    /// Görev Tarihi
    /// </summary>
        public DateTime? DutyDate
        {
            get { return (DateTime?)this["DUTYDATE"]; }
            set { this["DUTYDATE"] = value; }
        }

    /// <summary>
    /// Bırakıldığı Yer
    /// </summary>
        public string ArrivalRegion
        {
            get { return (string)this["ARRIVALREGION"]; }
            set { this["ARRIVALREGION"] = value; }
        }

    /// <summary>
    /// Transport Nedeni
    /// </summary>
        public AmbulanceReasonTypeEnum? TransportationReason
        {
            get { return (AmbulanceReasonTypeEnum?)(int?)this["TRANSPORTATIONREASON"]; }
            set { this["TRANSPORTATIONREASON"] = value; }
        }

    /// <summary>
    /// Ambulans Türü
    /// </summary>
        public AmbulanceTypeEnum? AmbulanceType
        {
            get { return (AmbulanceTypeEnum?)(int?)this["AMBULANCETYPE"]; }
            set { this["AMBULANCETYPE"] = value; }
        }

    /// <summary>
    /// Hasta Adı Soyadı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public object Note
        {
            get { return (object)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public string Duty
        {
            get { return (string)this["DUTY"]; }
            set { this["DUTY"] = value; }
        }

    /// <summary>
    /// Ambulansın Katedeceği Mesafe Kilometre Cinsinden
    /// </summary>
        public long? AmbulanceKilometer
        {
            get { return (long?)this["AMBULANCEKILOMETER"]; }
            set { this["AMBULANCEKILOMETER"] = value; }
        }

    /// <summary>
    /// Tahmini Dönüş Tarih Saati
    /// </summary>
        public DateTime? EstimatedReturnTime
        {
            get { return (DateTime?)this["ESTIMATEDRETURNTIME"]; }
            set { this["ESTIMATEDRETURNTIME"] = value; }
        }

    /// <summary>
    /// Görev Türü
    /// </summary>
        public AmbulanceDutyEnum? DutyType
        {
            get { return (AmbulanceDutyEnum?)(int?)this["DUTYTYPE"]; }
            set { this["DUTYTYPE"] = value; }
        }

    /// <summary>
    /// Alındığı Yer
    /// </summary>
        public string StartRegion
        {
            get { return (string)this["STARTREGION"]; }
            set { this["STARTREGION"] = value; }
        }

    /// <summary>
    /// Çıkış Emri Verenin Telefonu
    /// </summary>
        public string CommitterTelNo
        {
            get { return (string)this["COMMITTERTELNO"]; }
            set { this["COMMITTERTELNO"] = value; }
        }

    /// <summary>
    /// Şöforün Telefonu
    /// </summary>
        public string DriverTelNo
        {
            get { return (string)this["DRIVERTELNO"]; }
            set { this["DRIVERTELNO"] = value; }
        }

    /// <summary>
    /// Sedye Durumu
    /// </summary>
        public AmbulanceStretcherEnum? Stretcher
        {
            get { return (AmbulanceStretcherEnum?)(int?)this["STRETCHER"]; }
            set { this["STRETCHER"] = value; }
        }

    /// <summary>
    /// Hasta Ev Adresi
    /// </summary>
        public string PatientAddress
        {
            get { return (string)this["PATIENTADDRESS"]; }
            set { this["PATIENTADDRESS"] = value; }
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Çıkış Emri Verenin Adı  Soyadı
    /// </summary>
        public string Committer
        {
            get { return (string)this["COMMITTER"]; }
            set { this["COMMITTER"] = value; }
        }

    /// <summary>
    /// Personel
    /// </summary>
        public ResUser Personnel
        {
            get { return (ResUser)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Rütbesi
    /// </summary>
        public RankDefinitions PatientRank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("PATIENTRANK"); }
            set { this["PATIENTRANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Birliği
    /// </summary>
        public MilitaryUnit PatientMilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("PATIENTMILITARYUNIT"); }
            set { this["PATIENTMILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AmbulancePlateDefinition Plate
        {
            get { return (AmbulancePlateDefinition)((ITTObject)this).GetParent("PLATE"); }
            set { this["PLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAmbulancePersonnelsCollection()
        {
            _AmbulancePersonnels = new AmbulancePersonnel.ChildAmbulancePersonnelCollection(this, new Guid("610492c6-fdeb-4afd-8447-bc16b62b2d83"));
            ((ITTChildObjectCollection)_AmbulancePersonnels).GetChildren();
        }

        protected AmbulancePersonnel.ChildAmbulancePersonnelCollection _AmbulancePersonnels = null;
        public AmbulancePersonnel.ChildAmbulancePersonnelCollection AmbulancePersonnels
        {
            get
            {
                if (_AmbulancePersonnels == null)
                    CreateAmbulancePersonnelsCollection();
                return _AmbulancePersonnels;
            }
        }

        protected Ambulance(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Ambulance(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Ambulance(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Ambulance(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Ambulance(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AMBULANCE", dataRow) { }
        protected Ambulance(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AMBULANCE", dataRow, isImported) { }
        public Ambulance(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Ambulance(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Ambulance() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}