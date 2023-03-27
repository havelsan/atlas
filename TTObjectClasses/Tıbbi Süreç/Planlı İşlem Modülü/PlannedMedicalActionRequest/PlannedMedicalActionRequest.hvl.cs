
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PlannedMedicalActionRequest")] 

    /// <summary>
    /// Planlı Tıbbi İşlem İstek
    /// </summary>
    public  partial class PlannedMedicalActionRequest : EpisodeActionWithDiagnosis, IAllocateSpeciality, IReasonOfReject
    {
        public class PlannedMedicalActionRequestList : TTObjectCollection<PlannedMedicalActionRequest> { }
                    
        public class ChildPlannedMedicalActionRequestCollection : TTObject.TTChildObjectCollection<PlannedMedicalActionRequest>
        {
            public ChildPlannedMedicalActionRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPlannedMedicalActionRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPlannedMedicalActionRequest_Class : TTReportNqlObject 
        {
            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Fno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Cityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYOFBIRTH"]);
                }
            }

            public Object Townofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOWNOFBIRTH"]);
                }
            }

            public Object Birthdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                }
            }

            public Object Homeaddress
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                }
            }

            public Object Homecountry
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECOUNTRY"]);
                }
            }

            public Object Homecity
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECITY"]);
                }
            }

            public Object Hometown
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMETOWN"]);
                }
            }

            public Object Homephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ClinicInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONREQUEST"].AllPropertyDefs["CLINICINFORMATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object ClinicInformationRTF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINFORMATIONRTF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONREQUEST"].AllPropertyDefs["CLINICINFORMATIONRTF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetPlannedMedicalActionRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPlannedMedicalActionRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPlannedMedicalActionRequest_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("bc8fb950-d513-45b3-b90e-c1835747dd89"); } }
            public static Guid Completed { get { return new Guid("0839fe8b-084d-4c9a-92ab-f3bb02a1bd6f"); } }
            public static Guid Request { get { return new Guid("c28dcf5c-10f6-4725-b7db-017bef872e79"); } }
        }

        public static BindingList<PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class> GetPlannedMedicalActionRequest(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONREQUEST"].QueryDefs["GetPlannedMedicalActionRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class> GetPlannedMedicalActionRequest(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONREQUEST"].QueryDefs["GetPlannedMedicalActionRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Klinik Bilgileri
    /// </summary>
        public string ClinicInformation
        {
            get { return (string)this["CLINICINFORMATION"]; }
            set { this["CLINICINFORMATION"] = value; }
        }

    /// <summary>
    /// Klinik Bulgular
    /// </summary>
        public object ClinicInformationRTF
        {
            get { return (object)this["CLINICINFORMATIONRTF"]; }
            set { this["CLINICINFORMATIONRTF"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Yatağında
    /// </summary>
        public bool? InPatientsBed
        {
            get { return (bool?)this["INPATIENTSBED"]; }
            set { this["INPATIENTSBED"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Yatan hastalarda yatağında check i işaretli olduğunda hastanın yattığı yatak set edilir.
    /// </summary>
        public ResBed InpatientBed
        {
            get { return (ResBed)((ITTObject)this).GetParent("INPATIENTBED"); }
            set { this["INPATIENTBED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePlannedMedicalActionOrdersCollection()
        {
            _PlannedMedicalActionOrders = new PlannedMedicalActionOrder.ChildPlannedMedicalActionOrderCollection(this, new Guid("3ea44105-aeef-43de-9b5a-dc5705d362e8"));
            ((ITTChildObjectCollection)_PlannedMedicalActionOrders).GetChildren();
        }

        protected PlannedMedicalActionOrder.ChildPlannedMedicalActionOrderCollection _PlannedMedicalActionOrders = null;
        public PlannedMedicalActionOrder.ChildPlannedMedicalActionOrderCollection PlannedMedicalActionOrders
        {
            get
            {
                if (_PlannedMedicalActionOrders == null)
                    CreatePlannedMedicalActionOrdersCollection();
                return _PlannedMedicalActionOrders;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _PlannedMedicalActionOrderDetails = new PlannedMedicalActionOrderDetail.ChildPlannedMedicalActionOrderDetailCollection(_SubactionProcedures, "PlannedMedicalActionOrderDetails");
        }

        private PlannedMedicalActionOrderDetail.ChildPlannedMedicalActionOrderDetailCollection _PlannedMedicalActionOrderDetails = null;
        public PlannedMedicalActionOrderDetail.ChildPlannedMedicalActionOrderDetailCollection PlannedMedicalActionOrderDetails
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PlannedMedicalActionOrderDetails;
            }            
        }

        protected PlannedMedicalActionRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PlannedMedicalActionRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PlannedMedicalActionRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PlannedMedicalActionRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PlannedMedicalActionRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PLANNEDMEDICALACTIONREQUEST", dataRow) { }
        protected PlannedMedicalActionRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PLANNEDMEDICALACTIONREQUEST", dataRow, isImported) { }
        public PlannedMedicalActionRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PlannedMedicalActionRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PlannedMedicalActionRequest() : base() { }

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