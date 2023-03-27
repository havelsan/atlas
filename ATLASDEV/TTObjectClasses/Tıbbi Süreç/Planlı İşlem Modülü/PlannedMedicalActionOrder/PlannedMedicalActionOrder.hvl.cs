
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PlannedMedicalActionOrder")] 

    /// <summary>
    /// Planlı Tıbbi İşlem Emri
    /// </summary>
    public  partial class PlannedMedicalActionOrder : PlannedAction, IAllocateSpeciality, IOldActions, IPlanPlannedAction, IReasonOfReject
    {
        public class PlannedMedicalActionOrderList : TTObjectCollection<PlannedMedicalActionOrder> { }
                    
        public class ChildPlannedMedicalActionOrderCollection : TTObject.TTChildObjectCollection<PlannedMedicalActionOrder>
        {
            public ChildPlannedMedicalActionOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPlannedMedicalActionOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPlannedMedicalActionOrders_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Objectid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID1"]);
                }
            }

            public long? Duration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["DURATION"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ApplicationArea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONAREA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["APPLICATIONAREA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPlannedMedicalActionOrders_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPlannedMedicalActionOrders_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPlannedMedicalActionOrders_Class() : base() { }
        }

        [Serializable] 

        public partial class PlannedMedicalActionAcceptionReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
                }
            }

            public string Townname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public string Fromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Plannedmedicactionreqobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PLANNEDMEDICACTIONREQOBJECTID"]);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONREQUEST"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Plannedmedicactreqprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDMEDICACTREQPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Docdiplomano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCDIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docemploymentrecordid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCEMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Doctitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Dokrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docmilitaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCMILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docwork
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCWORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docspeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCSPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PlannedMedicalActionAcceptionReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PlannedMedicalActionAcceptionReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PlannedMedicalActionAcceptionReportNQL_Class() : base() { }
        }

        public static class States
        {
            public static Guid Aborted { get { return new Guid("07c72899-b651-4117-9c82-ca13b3ca7d6e"); } }
            public static Guid ApprovalForAbort { get { return new Guid("19e32b43-b99b-4b60-84d5-806464ffa219"); } }
            public static Guid Cancelled { get { return new Guid("3cef8d5d-b161-4ec6-9dc7-26bd593d7403"); } }
            public static Guid Completed { get { return new Guid("b76ec205-be5d-4b10-af17-bd406630f2a0"); } }
            public static Guid Plan { get { return new Guid("71729f23-07f2-4b64-b539-b016ba3bc081"); } }
            public static Guid Rejected { get { return new Guid("a1337602-d232-4401-8da4-30aa9778824f"); } }
            public static Guid RequestAcception { get { return new Guid("bf9aa725-582f-4523-9d6e-0516c3db4c2c"); } }
            public static Guid Therapy { get { return new Guid("96e79d43-60dd-4bc5-a9cd-8c21d94b3561"); } }
        }

        public static BindingList<PlannedMedicalActionOrder.GetPlannedMedicalActionOrders_Class> GetPlannedMedicalActionOrders(string PLANNEDMEDICALACTIONREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].QueryDefs["GetPlannedMedicalActionOrders"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PLANNEDMEDICALACTIONREQUEST", PLANNEDMEDICALACTIONREQUEST);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrder.GetPlannedMedicalActionOrders_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrder.GetPlannedMedicalActionOrders_Class> GetPlannedMedicalActionOrders(TTObjectContext objectContext, string PLANNEDMEDICALACTIONREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].QueryDefs["GetPlannedMedicalActionOrders"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PLANNEDMEDICALACTIONREQUEST", PLANNEDMEDICALACTIONREQUEST);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrder.GetPlannedMedicalActionOrders_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrder.PlannedMedicalActionAcceptionReportNQL_Class> PlannedMedicalActionAcceptionReportNQL(string PLANNEDMEDICALACTIONORDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].QueryDefs["PlannedMedicalActionAcceptionReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PLANNEDMEDICALACTIONORDER", PLANNEDMEDICALACTIONORDER);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrder.PlannedMedicalActionAcceptionReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrder.PlannedMedicalActionAcceptionReportNQL_Class> PlannedMedicalActionAcceptionReportNQL(TTObjectContext objectContext, string PLANNEDMEDICALACTIONORDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].QueryDefs["PlannedMedicalActionAcceptionReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PLANNEDMEDICALACTIONORDER", PLANNEDMEDICALACTIONORDER);

            return TTReportNqlObject.QueryObjects<PlannedMedicalActionOrder.PlannedMedicalActionAcceptionReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PlannedMedicalActionOrder> GetMySiblingObjectsForAppointment(TTObjectContext objectContext, string PARAMEPISODE, string PARAMCURRENTOBJECT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PLANNEDMEDICALACTIONORDER"].QueryDefs["GetMySiblingObjectsForAppointment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISODE", PARAMEPISODE);
            paramList.Add("PARAMCURRENTOBJECT", PARAMCURRENTOBJECT);

            return ((ITTQuery)objectContext).QueryObjects<PlannedMedicalActionOrder>(queryDef, paramList);
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Tedavi Özellikleri
    /// </summary>
        public string TreatmentProperties
        {
            get { return (string)this["TREATMENTPROPERTIES"]; }
            set { this["TREATMENTPROPERTIES"] = value; }
        }

    /// <summary>
    /// Uygulama Alanı
    /// </summary>
        public string ApplicationArea
        {
            get { return (string)this["APPLICATIONAREA"]; }
            set { this["APPLICATIONAREA"] = value; }
        }

    /// <summary>
    /// Süre/dk
    /// </summary>
        public long? Duration
        {
            get { return (long?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

        public ResSection TreatmentUnit
        {
            get { return (ResSection)((ITTObject)this).GetParent("TREATMENTUNIT"); }
            set { this["TREATMENTUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PlannedMedicalActionRequest PlannedMedicalActionRequest
        {
            get { return (PlannedMedicalActionRequest)((ITTObject)this).GetParent("PLANNEDMEDICALACTIONREQUEST"); }
            set { this["PLANNEDMEDICALACTIONREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateOrderDetailsCollection()
        {
            _OrderDetails = new SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection(this, new Guid("b304cbb5-f693-47ee-b2fb-b0379154ef5d"));
            CreateOrderDetailsCollectionViews();
            ((ITTChildObjectCollection)_OrderDetails).GetChildren();
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _PlannedMedicalActionTreatmentMaterials = new PlannedMedicalActionTreatmentMaterial.ChildPlannedMedicalActionTreatmentMaterialCollection(_TreatmentMaterials, "PlannedMedicalActionTreatmentMaterials");
        }

        private PlannedMedicalActionTreatmentMaterial.ChildPlannedMedicalActionTreatmentMaterialCollection _PlannedMedicalActionTreatmentMaterials = null;
        public PlannedMedicalActionTreatmentMaterial.ChildPlannedMedicalActionTreatmentMaterialCollection PlannedMedicalActionTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _PlannedMedicalActionTreatmentMaterials;
            }            
        }

        protected PlannedMedicalActionOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PlannedMedicalActionOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PlannedMedicalActionOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PlannedMedicalActionOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PlannedMedicalActionOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PLANNEDMEDICALACTIONORDER", dataRow) { }
        protected PlannedMedicalActionOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PLANNEDMEDICALACTIONORDER", dataRow, isImported) { }
        public PlannedMedicalActionOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PlannedMedicalActionOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PlannedMedicalActionOrder() : base() { }

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